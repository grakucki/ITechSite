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
    public partial class VideoViewerControl : UserControl, IMediaViewer
    {
        public VideoViewerControl()
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
                axWindowsMediaPlayer1.URL = _FileName;
                
            }
        }


        public static bool MediaSuported(string filetype)
        {
            string SuportedEx = ".mp4.avi.wmv";
            return (SuportedEx.IndexOf(filetype) >= 0);
        }

        private void VideoViewerControl_Load(object sender, EventArgs e)
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
           
        }

        private void OnInitButton(Button b)
        {

            toolTip1.SetToolTip(b, b.Text);
            b.Text = "";
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 255, 0, 0);

        }
        public void Start(string fileName)
        {
            FileName = fileName;
        }

        public void Pause()
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        public void Stop()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
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

        private void button1_Click(object sender, EventArgs e)
        {
            // fullscrean
            axWindowsMediaPlayer1.fullScreen = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // do przodu

            if (axWindowsMediaPlayer1.Ctlcontrols.get_isAvailable("fastForward"))
                axWindowsMediaPlayer1.Ctlcontrols.fastForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // do tyłu
            if (axWindowsMediaPlayer1.Ctlcontrols.get_isAvailable("fastReverse"))
                axWindowsMediaPlayer1.Ctlcontrols.fastReverse();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState== WMPLib.WMPPlayState.wmppsPlaying)
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            else
                axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }
}
