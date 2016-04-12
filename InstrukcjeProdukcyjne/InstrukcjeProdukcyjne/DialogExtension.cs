using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    static class DialogExtension
    {
        public static void FullScreen(this Form dial, bool fullscreen)
        {
            MinimalizeCmdWindow();
            if (fullscreen)
            {
                dial.WindowState = FormWindowState.Normal;
                dial.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                dial.Bounds = Screen.PrimaryScreen.Bounds;
                dial.TopLevel = true;
                dial.Select();
                dial.Activate();
                //MessageBox.Show("Fullscrean On");
            }
            else
            {
                dial.TopMost = true;
                dial.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                dial.WindowState = FormWindowState.Maximized;
            }

        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void MinimalizeCmdWindow()
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if (process.ProcessName == "cmd")
                    ShowWindow(process.MainWindowHandle, 2);
            }

        }
    }
}
