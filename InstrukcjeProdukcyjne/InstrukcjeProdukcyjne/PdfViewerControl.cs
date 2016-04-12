using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

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
            
            
            this.axAcroPDF1.setShowScrollbars(true);
            this.axAcroPDF1.setShowToolbar(false);
            this.axAcroPDF1.setPageMode("bookmarks");
            axAcroPDF1.setView("Fit");
            this.axAcroPDF1.Focus();

            var d = new NoneDlg();
            d.Show();
            d.Close();
        }

        public void Pause(bool value)
        {
            return;
        }

        public bool IsPause()
        {
            return false;
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
            // Powiększ
           
            SendPdfCommand("^{+}");
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            // pomniejsz
           
            SendPdfCommand("^{-}");
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
            SendPdfCommand("{PGUP}");
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            //SendPdfCommand_Begin("{UP}");
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            //SendPdfCommand_End();

        }


        private void button6_Click(object sender, EventArgs e)
        {
            // w lewo
            SendPdfCommand("{LEFT}");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // w prawo
            SendPdfCommand("{RIGHT}");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // w dół
            SendPdfCommand("{PGDN}");
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

        string _SendWait = string.Empty;
        bool _OneShot = true;
        void SendPdfCommand(string command)
        {
            timer1.Interval = 50;
            _SendWait = command;
            _OneShot = true;
            axAcroPDF1.Focus();
            SendKeys.Send(command);
            SendKeys.Flush();
            timer1.Start();
        }

        void SendPdfCommand_Begin(string command)
        {
            timer1.Interval = 200;
            _SendWait = command;
            _OneShot = false;
            axAcroPDF1.Focus();
            SendKeys.Send(command);
            SendKeys.Flush();
            timer1.Start();
        }

        void SendPdfCommand_End()
        {
            _OneShot = true;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_OneShot)
                timer1.Stop();
            axAcroPDF1.Focus();
            SendKeys.SendWait(_SendWait);
            Debug.WriteLine(_SendWait);
        }
    }
}
