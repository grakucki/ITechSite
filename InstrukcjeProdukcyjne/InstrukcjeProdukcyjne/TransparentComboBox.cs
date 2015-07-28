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
    public partial class TransparentComboBox : ComboBox
    {

        ControlStyles styleTrue = ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer |
            ControlStyles.FixedHeight |
            ControlStyles.ResizeRedraw |
            //ControlStyles.SupportsTransparentBackColor |
            //ControlStyles.Opaque |
            ControlStyles.UserPaint;

        //private Rectangle m_clickButton;
        //private Color _ButtonBackColor;
        //private static string strcmbo = "";

        public TransparentComboBox()
        {
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);
            //BackColor = Color.Transparent;


            SetStyle(styleTrue, true);
            SetStyle(ControlStyles.Selectable, false); //to recive focuse if true
 

            InitializeComponent();
        }



        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //BackColor = Color.Transparent;
            base.OnPaintBackground(pevent);

            Graphics g = pevent.Graphics;
            Rectangle rect = new Rectangle(pevent.ClipRectangle.Location, pevent.ClipRectangle.Size);
            //ControlPaint.DrawBorder(g, rect, Color.Red, ButtonBorderStyle.Solid);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            OnPaintBackground(e);

            OnPaintText(e);
        }

        
        #region Virtual Events
        protected virtual void OnPaintComboButtonBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            Rectangle rc = ClientRectangle;
            //g.FillRectangle(new SolidBrush(Color.Tomato), rc.Right - 17, rc.Y + 2, 15, rc.Height - 4);
        }

        protected void OnPaintText(System.Windows.Forms.PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            Rectangle rc = ClientRectangle;
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rc);

        }

        #endregion

    }
}
