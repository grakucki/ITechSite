﻿using System;
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
                label1.Text = _FileName;
                //this.axAcroPDF1.LoadFile(_FileName);
            }
        }
        private void PdfViewerControl_Load(object sender, EventArgs e)
        {

        }
    }
}
