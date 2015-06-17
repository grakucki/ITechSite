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
    }
}
