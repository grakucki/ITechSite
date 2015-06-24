using ITechInstrukcjeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    public partial class SettingsDlg : Form
    {
        public SettingsDlg()
        {
            InitializeComponent();
        }

        ITechInstrukcjeModel.ITechEntities db = new ITechInstrukcjeModel.ITechEntities();

        private void SettingsDlg_Load(object sender, EventArgs e)
        {
            try
            {

                LoadSettings();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

        }


        private void SettingsDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                                        

                    SaveSettings();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSettings()
        {
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString();
            //var file = Path.Combine(path, "setings.xml");
            //label1.Text = file;
            //if (File.Exists(file))
            //{
            //    textBox1.Text= File.ReadAllText(file);
            //}
            var x = Properties.Settings.Default.App;
            textBox1.Text = Properties.Settings.Default.App.ServerDoc;
            textBox2.Text = Properties.Settings.Default.App.LocalDoc;
            int? id = Properties.Settings.Default.App.Stanowisko;

            db.WorkDir = Properties.Settings.Default.App.LocalDoc;
            
            var r = db.ImportResource(null);


            var workstations = db.ResourceWorkstation_Local;

            resourceBindingSource.DataSource = workstations;

            ITechInstrukcjeModel.Resource w = null;
            if (id != null)
                w = workstations.Where(m => m.Id == id).FirstOrDefault();
            WorkstationComboBox.SelectedItem = w;

        }

        private void SaveSettings()
        {
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString();

            var s= textBox1.Text;
            //File.WriteAllText(Path.Combine(path, "setings.xml"), s);
            Properties.Settings.Default.App.ServerDoc = textBox1.Text;
            Properties.Settings.Default.App.LocalDoc = textBox2.Text;
            var w = (ITechInstrukcjeModel.Resource) WorkstationComboBox.SelectedItem;

            if (w != null)
                Properties.Settings.Default.App.Stanowisko = w.Id;
            else
                Properties.Settings.Default.App.Stanowisko = null;
            Properties.Settings.Default.Save();
        }

        private Resource GetCurrent()
        {
            return (Resource)resourceBindingSource.Current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dial = new SimaticDlg();
                dial.Workstation = GetCurrent().Workstation.FirstOrDefault();
                dial.ShowDialog();


                db.SaveChanges();

                MessageBox.Show(GetCurrent().Workstation.FirstOrDefault().Sterownik_Ip);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static string UrlPathCombine(string path1, string path2)
        {
            path1 = path1.TrimEnd('/') + "/";
            path2 = path2.TrimStart('/');

            return Path.Combine(path1, path2)
                .Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var addr = textBox1.Text;
            //http://localhost:53854/ServiceWorkstation.svc



            ServiceWorkstation.ServiceWorkstationClient client = null;
            try
            {
                string s = string.Empty;
                int idR = GetCurrent().Workstation.FirstOrDefault().idR;
                using(new CursorWait())
                { 
                    client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient(addr);
                    s = client.TestConnection(idR);
                    client.Close();
                }
                MessageBox.Show(s);
            }
           
            catch (CommunicationException exception)
            {
                if (client != null)
                    client.Abort();
                MessageBox.Show(string.Format("3.{0} : {1}", exception.GetType(), exception.Message));
            }
            catch (Exception ex)
            {
                if (client != null)
                    client.Abort();
                MessageBox.Show(string.Format("4.{0} : {1}", ex.GetType(), ex.Message));
            }

        }

    }
}
