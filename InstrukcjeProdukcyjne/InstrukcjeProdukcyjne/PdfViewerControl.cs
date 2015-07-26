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
            OnInitButton(button10);
            OnInitButton(button11);
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

        float _Zoom = 100;
        private void button1_Click(object sender, EventArgs e)
        {
            // Powiększ
            _Zoom = Math.Min(_Zoom+20,500);
            axAcroPDF1.setZoom(_Zoom);
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            // pomniejsz
            _Zoom = Math.Max(_Zoom - 20,20);
            axAcroPDF1.setZoom(_Zoom);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // strona w dół
            axAcroPDF1.gotoNextPage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // strona w górę
            axAcroPDF1.gotoPreviousPage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // w górę
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // w lewo
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // w prawo
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // w dół
            Button b = (Button)sender;
            MessageBox.Show("Action : " + b.Name);
        }


        private void button11_Click(object sender, EventArgs e)
        {
            // Cała strona
            axAcroPDF1.setView("Fit");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Szerokośc strony
            axAcroPDF1.setView("FitH");
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
