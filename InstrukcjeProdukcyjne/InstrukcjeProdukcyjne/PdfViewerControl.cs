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
                this.axAcroPDF1.LoadFile(_FileName);
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
        }

        public void Pause()
        {
            return;
        }

        public void Stop()
        {
            return;
        }
    }
}
