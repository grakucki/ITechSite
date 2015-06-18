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
    public partial class PdfViewerControl : UserControl, IMediaViewer
    {
        public PdfViewerControl()
        {
            InitializeComponent();
        }

        private string _FileName = "";
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
                //label1.Text = _FileName;
                var b =this.axAcroPDF1.LoadFile(_FileName);
            }
        }
        private void PdfViewerControl_Load(object sender, EventArgs e)
        {

        }

        public static bool MediaSuported(string filetype)
        {
            string SuportedEx = ".pdf";
            return (SuportedEx.IndexOf(filetype) >= 0);
        }

        public void Start(string fileName)
        {
            FileName = fileName;
            this.Show();            
            this.axAcroPDF1.Focus();
            //this.axAcroPDF1.setPageMode("thumbs");
        }

        public void Pause()
        {
            return;
        }

        public void Stop()
        {
            return;
        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {
            MessageBox.Show("PdfError");
        }
    }
}
