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
    public partial class DokumentShowDlg : Form, IMediaViewer
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
            try
            {
                //this.WindowState = FormWindowState.Maximized;
                this.FullScreen(true);
                //GoFullscreen(true);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mediaViewerControl1.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void Start(string fileName)
        {
            mediaViewerControl1.Start(fileName);
        }

        public void Pause(bool value)
        {
            mediaViewerControl1.Pause(value);
        }

        public void Stop()
        {
            mediaViewerControl1.Stop();
        }

        public bool IsPause()
        {
            return mediaViewerControl1.IsPause();
        }

    }
}
