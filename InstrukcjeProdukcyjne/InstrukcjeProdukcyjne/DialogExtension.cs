using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    static class DialogExtension
    {
        public static void FullScreen(this Form dial, bool fullscreen)
        {
            if (fullscreen)
            {
                dial.WindowState = FormWindowState.Normal;
                dial.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                dial.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                dial.WindowState = FormWindowState.Maximized;
                dial.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }

        }
    }
}
