using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    public static class ClickOnceHelper
    { 
        public static void AddShortcutToStartupGroup()
        {
            try
            {
                string publisherName = @"insofter\sitech";
                string productName = @"InstrukcjeProdukcyjne";
                AddShortcutToStartupGroup(publisherName, productName);

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
        }

        public static void AddShortcutToStartupGroup(string publisherName, string productName)
        {
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                startupPath = Path.Combine(startupPath, productName) + ".appref-ms";
                if (!File.Exists(startupPath))
                {
                    string allProgramsPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
                    string shortcutPath = Path.Combine(allProgramsPath, publisherName);
                    shortcutPath = Path.Combine(shortcutPath, productName) + ".appref-ms";
                    File.Copy(shortcutPath, startupPath); 
                }
            }
        }
    }
}
