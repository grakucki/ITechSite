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
    public partial class TestKompetencjiDlg : Form
    {
        public TestKompetencjiDlg()
        {
            InitializeComponent();
        }

        public string TestUri { get; set; }
        public int UserId { get; set; }
        private void TestKompetencjiDlg_Load(object sender, EventArgs e)
        {
            TestUri = Properties.Settings.Default.App.ServerTestKompetencjiAddress;
            TestUri += string.Format(@"?resourceId={0}&accessionNumber={1}@user_id={2}",
                Properties.Settings.Default.App.Stanowisko,
                Guid.NewGuid().ToString(),
                UserId);
            webBrowser1.Navigate(TestUri);
        }
    }
}
