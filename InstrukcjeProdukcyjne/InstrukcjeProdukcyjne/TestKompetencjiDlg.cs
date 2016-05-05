using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        public Guid AccessionNumber { get; set; }
        public bool TestRes { get; set; }

        private void TestKompetencjiDlg_Load(object sender, EventArgs e)
        {
            TestRes = false;
            splitContainer1.Panel2Collapsed = true;
            this.FullScreen(true);

            if (AccessionNumber == Guid.Empty)
                AccessionNumber = Guid.NewGuid();
            TestUri = Properties.Settings.Default.App.ServerTestKompetencjiAddress;
            TestUri += string.Format(@"?resourceId={0}&accessionNumber={1}&UserId={2}",
                Properties.Settings.Default.App.Stanowisko,
                AccessionNumber.ToString(),
                UserId);
            webBrowser1.Navigate(TestUri);
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().IndexOf("/getTestResult?") > 0)
           {
               e.Cancel=true;
               this.Close();
           }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // if find in url "EndViewAcction=true" to zamykamy okno i sprawdzamy czy test został zdany
            string u = e.Url.ToString().ToLower();
            if (u.IndexOf("endtest".ToLower()) < 0)
                return;

            TestRes = false;
            WebClient web = new WebClient();
            var addr = e.Url.ToString().ToLower().Replace("/endtest", "/getTestResult");
            string response = web.DownloadString(addr).ToLower();
            if (response.IndexOf("<state>zdany</state>") >= 0)
                TestRes = true;
            

            splitContainer1.Panel2Collapsed = false;
            if (TestRes)
                button1.BackColor = Color.Green;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
