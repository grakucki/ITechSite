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
    public partial class ModelsWorkstationEditDlg : Form
    {
        public ModelsWorkstationEditDlg()
        {
            InitializeComponent();
        }

        public List<ITechInstrukcjeModel.Resource> Models { get; set; }
        public ServiceWorkstation.ModelWorkstationInfo ModelWorkstationInfo { get; set; }

        private void ModelsWorkstationEditDlg_Load(object sender, EventArgs e)
        {
            resourceBindingSource.DataSource = Models;
            bindingSource1.DataSource = ModelWorkstationInfo;
        }
    }
}
