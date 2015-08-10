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
    public partial class ModelsWorkstationImprtDlg : Form
    {
        public ModelsWorkstationImprtDlg()
        {
            InitializeComponent();
        }


        public List<ServiceWorkstation.ModelWorkstationInfo> modelsFromDb { get; set; }
        public List<ServiceWorkstation.ModelWorkstationInfo> modelsFromSimatic { get; set; }
        public List<ServiceWorkstation.ModelWorkstationInfo> modelsDelete { get; set; }

        public bool NoDeleteModeles
        {
            get
            {
                return checkBox1.Checked;
            }
        }

        private void ModelsWorkstationImprtDlg_Load(object sender, EventArgs e)
        {
            modelWorkstationInfoFromDBBindingSource.DataSource = modelsFromDb;
            modelWorkstationInfoFromSimaticBindingSource.DataSource = modelsFromSimatic;
            modelWorkstationInfoDeleteBindingSource.DataSource = modelsDelete;
        }
    }
}
