﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ClickOnceHelper.AddShortcutToStartupGroupFirstRun();
                Application.Run(new Form2());
        }
        

    }
}
