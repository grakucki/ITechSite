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
                        var d= client.GetInformationPlainsList(idR.Value).ToList();
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
    }
}
