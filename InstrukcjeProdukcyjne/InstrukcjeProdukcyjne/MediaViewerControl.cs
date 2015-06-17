using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace InstrukcjeProdukcyjne
{
    public partial class MediaViewerControl : UserControl
    {
        public MediaViewerControl()
        {
            InitializeComponent();
        }

        private void MediaViewerControl_Load(object sender, EventArgs e)
        {

        }

        private void ChangeDokument(string fileName)
        {
            this.Controls.Clear();

            string filetype = Path.GetExtension(fileName).ToLower();
            if (".pdf".IndexOf(filetype) >= 0)
            {
                var uc = new PdfViewerControl();
                uc.FileName = fileName;
                uc.Dock = DockStyle.Fill;
                this.Controls.Add(uc);
                return;
            }

            if (".mp4.avi".IndexOf(filetype) >= 0)
            {
                var uc = new VideoViewerControl();
                uc.FileName = fileName;
                uc.Dock = DockStyle.Fill;
                this.Controls.Add(uc);
                return;
            }

            if (".jpg.avi".IndexOf(filetype) >= 0)
            {
                var uc = new PictureBox();
                uc.Image = Image.FromFile(fileName);
                uc.Dock = DockStyle.Fill;
                uc.SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(uc);
                return;
            }

            throw new Exception("Pliki " + Path.GetExtension(fileName) + " nie są obsługiwane");

        }

    }
}
