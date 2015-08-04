
using ITechInstrukcjeModel;
using ItechSimatic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    public partial class ModelsWorkstationDlg : Form
    {
        public ModelsWorkstationDlg(Workstation workstation)
        {
            InitializeComponent();
            Workstation = workstation;
        }

        //public int? idR { get; set; }
        
        public Workstation Workstation { get; set; }
        private void ModelsWorkstationDlg_Load(object sender, EventArgs e)
        {
            if (Workstation==null)
            {
                MessageBox.Show("Nie skonfigurowano poprawnie stacji roboczje. Ustawa porawne właściwości i spróbuj poniwnie");
                this.Close();
                return;
            }

            try 
	        {	        
                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR).ToList();
                }
		
	        }
	        catch (ConstraintException ex)
	        {
		        MessageBox.Show("Musisz być połączony s serweram aby dokonywać tu zmian. " + ex.Message);
                this.Close();
	        }
	        catch (Exception ex)
	        {
                this.Close();
		        MessageBox.Show(ex.Message);
	        }

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

        }

        ServiceWorkstation.ModelWorkstationInfo GetCurrent()
        {
            if (modelWorkstationInfoBindingSource.Position < 0)
                throw new Exception("Wybierz pozycję do edycji");
            return (ServiceWorkstation.ModelWorkstationInfo) modelWorkstationInfoBindingSource.Current;
        }


        private List<ITechInstrukcjeModel.Resource> _Models=null;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //    dodac identity namespace idDataGridViewTextBoxColumn w 
                // dodaj nowy model [ModelsWorkstation] w sql
                var n = new ServiceWorkstation.ModelWorkstationInfo();
                n.idW = Workstation.idR;

                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    if (_Models == null)
                        _Models = client.GetModels().ToList();

                    ModelsWorkstationEditDlg dial = new ModelsWorkstationEditDlg();
                    dial.Models = _Models;
                    dial.ModelWorkstationInfo = n;
                    dial.Workstation = Workstation;
                    if (dial.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    //zapis do bazy
                    client.UpdateModelWorkstationInfo(n, false);
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR).ToList();

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
                // edytuj model
                var n = GetCurrent();
                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    if (_Models == null)
                        _Models = client.GetModels().ToList();

                    ModelsWorkstationEditDlg dial = new ModelsWorkstationEditDlg();
                    dial.Models = _Models;
                    dial.ModelWorkstationInfo = n;
                    dial.Workstation = Workstation;
                    if (dial.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    //zapis do bazy
                    client.UpdateModelWorkstationInfo(n, false);
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                // usuń model
                string s = "Czy jesteś pewien, że chcesz usunąc ten model z listy?";
                if (MessageBox.Show(s, "Uwaga",  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.OK)
                    return;

                // edytuj model
                var n = GetCurrent();
                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    //zapis do bazy
                    client.UpdateModelWorkstationInfo(n, true);
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // zwraca listrę modeli na sterowniku
        private List<string> ReadFromSimatic()
        {
                SitechSimaticDevice sitech = new SitechSimaticDevice(
                   (S7.Net.CpuType)Enum.Parse(typeof(S7.Net.CpuType),  Workstation.Sterownik_Model), 
                    Workstation.Sterownik_Ip, 
                    (ushort) Workstation.Setrownik_DB.GetValueOrDefault(22),
                    Workstation.AllowIp
                    );

                if (!sitech.IsAvailable())
                {
                    MessageBox.Show("Sterownik nie jest dostępny.");
                    return null;
                }
                sitech.FileName = Properties.Settings.Default.App.LocalDoc + @"\simatic.xml";
                sitech.Fill();

                int nrModelu = sitech.NrModelu;
                return sitech.Nazwa_Modelu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var modelsFromSimatic = ReadFromSimatic();
                List<ServiceWorkstation.ModelWorkstationInfo> modelsFromDb = (List<ServiceWorkstation.ModelWorkstationInfo>) modelWorkstationInfoBindingSource.DataSource;
                List<ServiceWorkstation.ModelWorkstationInfo> modelsFromDb2Delete = new List<ServiceWorkstation.ModelWorkstationInfo>(modelsFromDb);
 
                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    var AllModels = client.GetModels().ToList();
                    int index = 0;
                    foreach (var item in modelsFromSimatic)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            // szukamy czy mamy go już na liście
                            var modeldb = modelsFromDb.FirstOrDefault(m=>m.SterownikIndex==index.ToString());
                            if (modeldb==null)
                            {
                                //dodajemy 
                                modeldb = new ServiceWorkstation.ModelWorkstationInfo();
                                modeldb.SterownikIndex=index.ToString();
                                modeldb.idW=Workstation.idR;
                            }
                            else
                            {
                                modelsFromDb2Delete.Remove(modeldb);
                            }

                            // update
                            var model = AllModels.Where(m => m.Name == item).FirstOrDefault();
                            if (model == null)
                            {
                                MessageBox.Show("Nieznana nazwa modelu : ", item);
                                continue;
                            }
                            if (modeldb.idM != model.Id)
                            {
                                modeldb.idM = model.Id;
                                client.UpdateModelWorkstationInfo(modeldb, false);
                            }

                        }
                        index++;  
                    }
                    foreach (var delmodeldb in modelsFromDb2Delete)
                    {
                            client.UpdateModelWorkstationInfo(delmodeldb, true);
                    }
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR).ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
