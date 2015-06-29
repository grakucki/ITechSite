using ITechInstrukcjeModel;
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
    public partial class SimaticDlg : Form
    {
        public SimaticDlg()
        {
            InitializeComponent();
        }

        public Workstation Workstation { get; set; }
        private void SimaticDlg_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(ITechInstrukcjeModel.Simatic.AvalibleSimaticCpuType);
            bindingSource1.DataSource = Workstation;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            var o = bindingSource1.Current;
        }
    }
}
