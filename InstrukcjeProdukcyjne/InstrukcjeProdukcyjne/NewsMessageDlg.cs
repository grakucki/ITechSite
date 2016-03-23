using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    public partial class NewsMessageDlg : Form
    {
        public NewsMessageDlg()
        {
            InitializeComponent();
        }


        public string Message { get; set; }
        public int MessageId { get; set; }
        public Color MessageColor { get; set; }

        private void NewsMessageDlg_Load(object sender, EventArgs e)
        {
            customPanel1.BackColor = MessageColor;
            customPanel1.BackColor2 = MessageColor;
            label1.Text=Message;
            customPanel1.Refresh();

        }

        private void scaleFont(Label lab)
        {
            Image fakeImage = new Bitmap(1, 1); //As we cannot use CreateGraphics() in a class library, so the fake image is used to load the Graphics.
            Graphics graphics = Graphics.FromImage(fakeImage);


            SizeF extent = graphics.MeasureString(lab.Text, lab.Font);


            float hRatio = lab.Height / extent.Height;
            float wRatio = lab.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = lab.Font.Size * ratio;



            lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);

        }
    }
}
