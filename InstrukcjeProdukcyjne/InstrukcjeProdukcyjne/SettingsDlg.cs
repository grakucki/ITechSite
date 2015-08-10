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
            textBox3.Text = Properties.Settings.Default.App.CardReaderFileDat;
            int? id = Properties.Settings.Default.App.Stanowisko;

            db.WorkDir = Properties.Settings.Default.App.LocalDoc;

            var workstations = GetWorsktationList();

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
            var w = (Resource) WorkstationComboBox.SelectedItem;

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
            // ustawienia sterownika
            try
            {
                var dial = new SimaticDlg();
                dial.Workstation = GetCurrent().Workstation.FirstOrDefault();
                if (dial.Workstation==null)
                {
                    //dodajemy nowy bo nie ma jeszcze konfiguracji
                    dial.Workstation = new Workstation();
                    dial.Workstation.idR = GetCurrent().Id;
                    GetCurrent().Workstation = new List<Workstation>();
                    GetCurrent().Workstation.Add(dial.Workstation);
                }
                if (dial.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;



                var addr = textBox1.Text;
                //http://localhost:53854/ServiceWorkstation.svc



                ServiceWorkstation.ServiceWorkstationClientEx client = null;
                try
                {
                    string s = string.Empty;
                    int idR = GetCurrent().Id;
                    using (new CursorWait())
                    {
                        client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient(addr);
                        client.UpdateWorkstation(dial.Workstation);
                        client.Close();
                    }
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

        private List<Resource> GetWorsktationList()
        {
            ServiceWorkstation.ServiceWorkstationClientEx client = null;
            var addr = textBox1.Text;
            if (string.IsNullOrEmpty(textBox1.Text))
                throw new Exception("Podaj adres serwera");

             List<Resource> s =null;
            using (new CursorWait())
            {
                client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient(addr);
                s = client.GetWorkstationList().ToList();
                client.Close();
            }
            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // test połaczenia
            var addr = textBox1.Text;
            //http://localhost:53854/ServiceWorkstation.svc



            ServiceWorkstation.ServiceWorkstationClientEx client = null;
            try
            {
                string s = string.Empty;
                int idR = 0;// GetCurrent().Id;
                using(new CursorWait())
                { 
                    client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient(addr);
                    s = client.TestConnection(idR);
                    resourceBindingSource.DataSource = client.GetWorkstationList();
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

        private void button3_Click(object sender, EventArgs e)
        {
            // ustawienia modeli
            try 
	        {	        
	            ModelsWorkstationDlg dial = new ModelsWorkstationDlg(GetCurrent());
                dial.ShowDialog();
	        }
	        catch (Exception ex) 
	        {

                MessageBox.Show(ex.Message);
	        }

        }

    }
}
