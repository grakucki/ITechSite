
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
        public ModelsWorkstationDlg()
        {
            InitializeComponent();
        }

        public int? idR { get; set; }
        private void ModelsWorkstationDlg_Load(object sender, EventArgs e)
        {
            if (!idR.HasValue)
            {
                MessageBox.Show("Nie skonfigurowano poprawnie stacji roboczje. Ustawa porawne właściwości i spróbuj poniwnie");
                this.Close();
                return;
            }

            try 
	        {	        
                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                        modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(idR.Value).ToList();
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
                ble ble
                    dodac identity namespace idDataGridViewTextBoxColumn w 
                // dodaj nowy model [ModelsWorkstation] w sql
                var n = new ServiceWorkstation.ModelWorkstationInfo();
                n.idW = idR;

                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    if (_Models == null)
                        _Models = client.GetModels().ToList();

                    ModelsWorkstationEditDlg dial = new ModelsWorkstationEditDlg();
                    dial.Models = _Models;
                    dial.ModelWorkstationInfo = n;
                    if (dial.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    //zapis do bazy
                    client.UpdateModelWorkstationInfo(n, false);
                    modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(idR.Value).ToList();

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                if (dial.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;

                //zapis do bazy
                client.UpdateModelWorkstationInfo(n, false);
                modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(idR.Value).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string s = "Czy jesteś pewien, że chcesz usunąc ten model z listy?";
            if (MessageBox.Show(s, "Uwaga",  MessageBoxButtons.OKCancel, MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.OK)
                return;

            // edytuj model
            var n = GetCurrent();
            using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
            {
                //zapis do bazy
                client.UpdateModelWorkstationInfo(n, true);
                modelWorkstationInfoBindingSource.DataSource = client.GetModelWorkstationInfo(idR.Value).ToList();

            }
            // usuń model
        }
    }
}
