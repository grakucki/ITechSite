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
    public partial class PdfViewerControl : UserControl
    {
        public PdfViewerControl()
        {
            InitializeComponent();
        }

        public string FileName { get; set; }
        private void PdfViewerControl_Load(object sender, EventArgs e)
        {

        }
    }
}
