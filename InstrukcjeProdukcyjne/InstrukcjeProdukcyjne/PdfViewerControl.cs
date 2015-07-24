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
            OnInitButton();
        }

        private void OnInitButton()
        {
            OnInitButton(button1);
            OnInitButton(button2);
            OnInitButton(button3);
            OnInitButton(button4);
            OnInitButton(button5);
            OnInitButton(button6);
            OnInitButton(button7);
            OnInitButton(button8);
        }

        private void OnInitButton(Button b)
        {

            toolTip1.SetToolTip(b, b.Text);
            b.Text = "";
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(100,255,0,0);

        }

        public static bool MediaSuported(string filetype)
        {
            string SuportedEx = ".pdf";
            return (SuportedEx.IndexOf(filetype) >= 0);
        }

        public void Start(string fileName)
        {
            FileName = fileName;
            this.axAcroPDF1.Focus();
            this.axAcroPDF1.setShowScrollbars(true);
            this.axAcroPDF1.setShowToolbar(false);
            this.axAcroPDF1.setPageMode("thumbs");
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
            MessageBox.Show("Pdf Error");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);

        }

        private void button7_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);

        }

        private void CloseOwnerForm()
        {
            var p = this.Parent;
            while (p != null)
            {
                if (p is Form)
                {
                    ((Form)p).Close();
                    ((Form)p).Dispose();
                    return;
                }
                p = p.Parent;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            CloseOwnerForm();
        }
    }
}
