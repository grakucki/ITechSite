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

        public void Stop()
        {
            if (this.Controls.Count > 0)
            {
                IMediaViewer mv = (IMediaViewer)this.Controls[0];
                if (mv!=null)
                    mv.Stop();
            }
        }

        public void ShowDokument(string fileName)
        {
            if (this.Controls.Count > 0)
            {
                IMediaViewer mv = (IMediaViewer)this.Controls[0];
                mv.Stop();
                this.Controls.Clear();
            }



            IMediaViewer newmv = null;

            string filetype = Path.GetExtension(fileName).ToLower();
            if (PdfViewerControl.MediaSuported(filetype))
            {
                newmv = new PdfViewerControl();
            }
            else
                if (VideoViewerControl.MediaSuported(filetype))
                {
                    newmv = new VideoViewerControl();
                }
                else
                    if (PictureViewerControl.MediaSuported(filetype))
                    {
                        newmv = new PictureViewerControl();
                    }

            if (newmv==null)
                throw new Exception("Pliki " + Path.GetExtension(fileName) + " nie są obsługiwane");


            Control c = (Control)newmv;
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);

            newmv.Start(fileName);
        }

    }
}
