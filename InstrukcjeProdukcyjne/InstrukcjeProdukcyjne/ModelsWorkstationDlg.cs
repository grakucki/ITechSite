
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
        public ModelsWorkstationDlg(Resource workstation)
        {
            InitializeComponent();
            ResourceWorkstation = workstation;
            Workstation = workstation.Workstation.FirstOrDefault();
        }

        //public int? idR { get; set; }

        public Resource ResourceWorkstation { get; set; }
        public Workstation Workstation { get; set; }
        private void ModelsWorkstationDlg_Load(object sender, EventArgs e)
        {
            if (Workstation==null)
            {
                MessageBox.Show("Nie skonfigurowano poprawnie komunikacji stacji roboczje ze sterwonikiem. Ustawa porawne właściwości i spróbuj poniwnie");
                this.Close();
                return;
            }

            try 
	        {	        
                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR.Value).OrderBy(m=>m.ModelName).ToList();
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
                    dial.Workstation = ResourceWorkstation;
                    if (dial.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    //zapis do bazy
                    client.UpdateModelWorkstationInfo(n, false);
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR.Value).ToList();

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
                    dial.Workstation = ResourceWorkstation;
                    if (dial.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    //zapis do bazy
                    client.UpdateModelWorkstationInfo(n, false);
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR.Value).ToList();
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
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR.Value).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // zwraca listrę modeli na sterowniku
        private List<string> ReadFromSimatic2()
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


        // zwraca listrę modeli na sterowniku
        private List<ServiceWorkstation.ModelWorkstationInfo> ReadFromSimatic()
        {
            SitechSimaticDevice sitech = new SitechSimaticDevice(
               (S7.Net.CpuType)Enum.Parse(typeof(S7.Net.CpuType), Workstation.Sterownik_Model),
                Workstation.Sterownik_Ip,
                (ushort)Workstation.Setrownik_DB.GetValueOrDefault(22),
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

            List<ServiceWorkstation.ModelWorkstationInfo> ret = new List<ServiceWorkstation.ModelWorkstationInfo>();
            int cnt = 0;
            foreach (var item in sitech.Nazwa_Modelu())
            {
                
                if (!string.IsNullOrEmpty(item))
                {
                    var x = new ServiceWorkstation.ModelWorkstationInfo();
                    x.ModelName=item;
                    x.SterownikIndex=cnt.ToString();
                    ret.Add(x);
                }
                cnt++;
            }

            return ret.OrderBy(m=>m.ModelName).ToList();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var modelsFromSimatic = ReadFromSimatic();
                List<ServiceWorkstation.ModelWorkstationInfo> modelsFromDb = ((List<ServiceWorkstation.ModelWorkstationInfo>) modelWorkstationInfoBindingSource.DataSource).OrderBy(m=>m.ModelName).ToList();
                List<ServiceWorkstation.ModelWorkstationInfo> modelsFromDb2Delete = new List<ServiceWorkstation.ModelWorkstationInfo>();

 
                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    var AllModels = client.GetModels().ToList();

                    // prepare toDeleteList
                    foreach (var item in modelsFromDb)
                    {
                        if (!string.IsNullOrEmpty(item.ModelName))
                        {
                            // szukamy czy mamy go już na liście
                            var modeldb = modelsFromSimatic.FirstOrDefault(m=>m.ModelName== item.ModelName);
                            if (modeldb == null)
                                modelsFromDb2Delete.Add(item);
                        }
                    }
                    modelsFromDb2Delete = modelsFromDb2Delete.OrderBy(m => m.ModelName).ToList();
                    // import dialog
                    var dImport = new ModelsWorkstationImprtDlg();
                    dImport.modelsFromDb = modelsFromDb;
                    dImport.modelsFromSimatic = modelsFromSimatic;
                    dImport.modelsDelete = modelsFromDb2Delete;

                    if (dImport.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    // usuwamy
                    if (modelsFromDb2Delete.Count > 0)
                    {
                        if (dImport.NoDeleteModeles == false)
                        {
                            foreach (var delmodeldb in modelsFromDb2Delete)
                            {
                                client.UpdateModelWorkstationInfo(delmodeldb, true);
                            }
                        }
                    }


                    int index = 0;
                    foreach (var item in modelsFromSimatic)
                    {
                        if (!string.IsNullOrEmpty(item.ModelName))
                        {
                            // szukamy czy mamy go już na liście
                            var modeldb = modelsFromDb.FirstOrDefault(m=>m.ModelName==item.ModelName);
                            if (modeldb==null)
                            {
                                // dodajemy 
                                modeldb = new ServiceWorkstation.ModelWorkstationInfo();
                            }

                            // update
                            var model = AllModels.Where(m => m.Name == item.ModelName).FirstOrDefault();
                            if (model == null)
                            {
                                MessageBox.Show("Nieznana nazwa modelu : " + item.ModelName);
                                continue;
                            }

                            modeldb.SterownikIndex = item.SterownikIndex;
                            modeldb.idW = Workstation.idR;
                            modeldb.idM = model.Id;
                            client.UpdateModelWorkstationInfo(modeldb, false);
                        }
                        index++;  
                    }

                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(Workstation.idR.Value).OrderBy(m=>m.ModelName).ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
