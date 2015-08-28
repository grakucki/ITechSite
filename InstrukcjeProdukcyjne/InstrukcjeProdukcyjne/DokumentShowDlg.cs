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
    public partial class DokumentShowDlg : Form
    {
        public DokumentShowDlg(MyFileInfo file, SitechUser user)
        {
            File= file;
            User = user;
            InitializeComponent();
        }

        public MyFileInfo File { get; set; }
        public SitechUser User { get; set; }


        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else 
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }

        }

        private void DokumentShowDlg_Load(object sender, EventArgs e)
        {
             GoFullscreen(true);
            if (User != null)
            {
                labelUserName.Text = User.UserName;
                labelUserNo.Text = User.NrKarty;
            }
            if (File != null)
            {
                KomunikatLabel.Text = File.Dok.Description;
                mediaViewerControl1.ShowDokument(File.FullFileName);
            }
            else
            {
                MessageBox.Show("Nie określono dokumentu");
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mediaViewerControl1.Stop();
            this.Close();
        }
    }
}
