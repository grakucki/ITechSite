using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    class VirtualKeyboard
    {

        public static bool IsRuning()
        {
            Process[] oskProcessArray = Process.GetProcessesByName("TabTip");
            return (oskProcessArray.Count() > 0);
        }

        public static void Show()
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string onScreenKeyboardPath = System.IO.Path.Combine(progFiles, "TabTip.exe");
            System.Diagnostics.Process.Start(onScreenKeyboardPath);
        }
    }
}
