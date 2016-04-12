using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    public partial class PictureViewerControl : UserControl, IMediaViewer
    {
        public PictureViewerControl()
        {
            InitializeComponent();
        }

        private void PictureViewerControl_Load(object sender, EventArgs e)
        {

        }


        public static bool MediaSuported(string filetype)
        {
            string SuportedEx = ".jpg.bmp.png";
            return (SuportedEx.IndexOf(filetype) >= 0);
        }


        public void Start(string fileName)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.Image = Image.FromFile(fileName);
        }

        public bool IsPause()
        {
            return false;
        }

        public void Pause(bool value)
        {
            return;
        }

        public void Stop()
        {
            return;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
