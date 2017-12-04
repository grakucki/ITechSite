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
        private static string publisherName = @"insofter\sitech";
        private static string productName = @"InstrukcjeProdukcyjne";

        
        public static void AddShortcutToStartupGroupFirstRun()
        {
            try
            {
                AddShortcutToStartupGroupFirstRun(publisherName, productName);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        public static void AddShortcutToStartupGroup()
        {
            try
            {
                AddShortcutToStartupGroup(publisherName, productName);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public static void RemoveShortcutToStartupGroup()
        {
            try
            {
                RemoveShortcutToStartupGroup(publisherName, productName);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public static bool IsShortcutToStartupGroup()
        {
            try
            {
                return IsShortcutToStartupGroup(publisherName, productName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }


        public static void AddShortcutToStartupGroupFirstRun(string publisherName, string productName)
        {
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                AddShortcutToStartupGroup(publisherName, productName);
            }
        }

        public static void AddShortcutToStartupGroup(string publisherName, string productName)
        {
            //if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
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

        public static void RemoveShortcutToStartupGroup(string publisherName, string productName)
        {
            //if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                startupPath = Path.Combine(startupPath, productName) + ".appref-ms";
                if (File.Exists(startupPath))
                    File.Delete(startupPath); 
            }
        }


        public static bool IsShortcutToStartupGroup(string publisherName, string productName)
        {
            //if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                startupPath = Path.Combine(startupPath, productName) + ".appref-ms";
                return File.Exists(startupPath);
            }
        }

    }
}
