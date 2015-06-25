﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml;
using InstrukcjeProdukcyjne.Properties;
using ITechInstrukcjeModel;
using System.ServiceModel;

namespace InstrukcjeProdukcyjne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string DataDir = "Instrukcje";
        private string StanowiskaFolder = "stanowiska";
        private string ElementyFolder = "elementy";

        ITechInstrukcjeModel.ITechEntities db = new ITechInstrukcjeModel.ITechEntities();

        private SitechUser LoginUser = null;
        private Resource _CurrentWorkstation = null;
        public Resource CurrentWorkstation
        {
            get
            {
                return _CurrentWorkstation;
            }
            set
            {
                _CurrentWorkstation = value;
                WorkStationBindingSource.DataSource = _CurrentWorkstation;
            }
        }


        private enum FolderType
	    {
	        Stanowsika,
            Elementy
	    }


        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private bool DoLogin(SitechUser user)
        {
            LoginUser = user;
            return true;
        }

        private DialogResult ShowLoginDlg(String message, bool allowCancel)
        {
            LoginForm login = new LoginForm();
            login.Message=message;

            while (true)
            {
                var ret = login.ShowDialog();
                if (allowCancel)
                {
                    if (ret == System.Windows.Forms.DialogResult.Cancel)
                        return ret;
                }
                if (ret== System.Windows.Forms.DialogResult.OK)
                {
                    if (DoLogin(login.User))
                        return ret;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // ustawiamy aplikację pełnoekranową
                GoFullscreen(true);

                // ładujemy ustawienia aplikacji
                var s = Settings.Default.Load;
                db.WorkDir = Settings.Default.App.LocalDoc;
                toolStripStatusLabel1.Text = Path.GetFullPath(db.WorkDir);
                StartupApp.CreateWorkDirektory(db.WorkDir);


                // ładujemy resources
                LoadResource(Settings.Default.App.Stanowisko);

                //ZaładujStanowiska();

                
                OnResourceFileListChange(0);

                if (ShowLoginDlg("",true)==System.Windows.Forms.DialogResult.Cancel)
                    this.Close();


                

                textBoxUser.Text = string.Format("{0} ({1})", LoginUser.UserName, LoginUser.NrKarty);

                
//                StartupApp.CreateWorkDirektory(@"C:\ItechTest");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// Załaduj Resource 
        /// Ustaw  Workstation o zadanym idR
        /// Jeśli jest dostępna baza to z bazy jeśli nie to z pliku
        /// </summary>
        /// <param name="idR"></param>
        private void LoadResource(int? idR)
        {
            using(var stat = new  ActionControlStatus(buttonItech))
            {
                using(var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    if (client.IsOnLine())
                    {
                            db.ResourceList = client.GetInformationPlainsList().ToList();
                    }
                    else
                    {
                        var resourcesFile = Path.Combine(db.WorkDir, "resources.xml");
                        if (!File.Exists(resourcesFile))
                        {
                            throw new Exception("Nie odnaleziono plików konfiguracyjnych. Musisz być połaczony aby zainicjować aplikację.");
                        }

                        // pobieramy z pliku
                        db.ImportResource(null);
                    }
                }

                if (idR.HasValue)
                    CurrentWorkstation = db.ResourceWorkstation_Local.Where(m => m.Id == idR.Value).FirstOrDefault();
                else
                    CurrentWorkstation = null;


                if (CurrentWorkstation==null)
                    stat.SetState(ActionControlStatus.ActionControlState.Warning,"");
                else
                    stat.SetState(ActionControlStatus.ActionControlState.Ok, "");


                ZaładujElementy(CurrentWorkstation);
                LoadNews(CurrentWorkstation.Id);

            }
        }

        //private void SelectWorkstation(int? newidR=null)
        //{
        //    if (newidR==null)
        //    {
        //        //Load from settings
        //        if (Settings.Default.App.Stanowisko.HasValue)
        //            newidR = Settings.Default.App.Stanowisko.Value;
        //        else
        //        {
        //            ShowSettings();
        //            if (Settings.Default.App.Stanowisko.HasValue)
        //                newidR = Settings.Default.App.Stanowisko.Value;
        //        }
        //    }

        //    if (!newidR.HasValue)
        //        return;

        //    var q = db.ResourceWorkstation_Local.Where(m => m.Id == newidR).FirstOrDefault();
        //    if (q==null)
        //        return;

        //    CurrentWorkstation = q;
        //    stanowiskaComboBox.SelectedValue = q.Id;
        //}

        private void ZaładujElementy(Resource res)
        {
            var data = db.ResourceModel_Local;
            ModelBindingSource.DataSource = data;

        }

        private void ZaładujStanowiska()
        {
            var data = db.ResourceWorkstation_Local;
            WorkStationBindingSource.DataSource = data;
        }

        private void OnResourceFileListChange(int NewResurceType)
        {
            Color cOn = Color.Green;
            Color cOff = Color.Orange;
            buttonWorkstation.BackColor = NewResurceType==1 ? cOn : cOff;
            buttonModel.BackColor = NewResurceType == 2 ? cOn : cOff;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // załaduj instrukcje stanowiskowe
            var x = WorkStationBindingSource.Current;
            if (x == null)
                return;
            Resource xx = (Resource )x;
            OnResourceFileListChange(xx.Type);
            ZaładujPliki(xx);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // załaduj instrukcje Modelu
            //ZaładujPliki(FolderType.Elementy, elementyComboBox.Text);
            var x = ModelBindingSource.Current;
            if (x == null)
                return;

            Resource xx = (Resource )x;
            OnResourceFileListChange(xx.Type);
            ZaładujPliki(xx);
        }



        private string GetFullPath(FolderType folderType, string DetalName)
        {
            string path = Path.Combine(Path.GetFullPath(DataDir));
            string folder = string.Empty;
            if (folderType == FolderType.Elementy)
                folder = ElementyFolder;
            else
                folder = StanowiskaFolder;
            path = Path.Combine(Path.GetFullPath(DataDir), folder);
            return Path.Combine(path, DetalName); 
        }

       
        //private string[] GetFiles(string folderName)
        //{
        //    string dir = Path.Combine(Path.GetFullPath(DataDir), folderName);
        //    return Directory.GetFiles(dir);
        //}

        //private List<MyFileInfo> _FileList = new List<MyFileInfo>();

        //private void ZaładujPliki(FolderType folderType, string detalName)
        //{
        //    string folderName = GetFullPath(folderType, detalName);
        //    //MessageBox.Show(GetFullPath(folderType, detalName));
        //    listView1.Items.Clear();
        //    string[] data = GetFiles(folderName);
        //    foreach (var item in data)
        //    {
        //        var d = new MyFileInfo { FileName = Path.GetFileName(item), FullFileName = item };
        //        var i=listView1.Items.Add(d.FullFileName, d.FileName, d.ExtensionIndex);
        //        i.Tag = d;
        //    }
        //}


        private void ZaładujPliki(Resource res)
        {
            listView1.Items.Clear();
            var IP = res.InformationPlan;
            foreach (var item in IP)
            {
                if (item.Dokument != null)
                {
                    var d = new MyFileInfo { FileName = item.Dokument.FileName, FullFileName = db.CreateLocalFileName(item.Dokument), Tag=item.Dokument };
                    var i = listView1.Items.Add(d.FullFileName, d.FileName, d.ExtensionIndex);
                    i.Tag = d;
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var senderList = (ListView)sender;
                var clickedItem = senderList.HitTest(e.Location).Item;
                if (clickedItem != null)
                {
                    var mfi = (MyFileInfo)clickedItem.Tag;
                    if (mfi != null)
                    {
                        if (File.Exists(mfi.FullFileName))
                            mediaViewerControl1.ShowDokument(mfi.FullFileName);
                        else
                            MessageBox.Show("Nie odnaleziono pliku." + mfi.FileName);
                    }
                }        

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            contextMenuStrip1.Show(c, 0, c.Size.Height);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowLoginDlg("Użyj kart aby odblokować", false);
        }

        private void ShowSettings()
        {
            try
            {
                var dial = new SettingsDlg();
                if (dial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    LoadResource(Properties.Settings.Default.App.Stanowisko);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowSettings();
            // ustawienia
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // zakończ
            this.Close();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Normal)
            //    this.WindowState = FormWindowState.Maximized;
        }

        private void oAplikacjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox1 dial = new AboutBox1();
                dial.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void klawiaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VirtualKeyboard.Show();
        }


        private void LoadNews(int idR)
        {
            using (var Work = new InstrukcjeProdukcyjne.ActionControlStatus(buttonItech))
            {
                Work.SetState(ActionControlStatus.ActionControlState.Working, "");
                using(var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    var d = client.Ping();
                    toolStripStatusITechTime.Text = (d.ToShortTimeString());
                    var news = client.GetNews(idR);
                    if (news != null)
                    {
                        KomunikatLabel.Text =news.News1;
                        labelCzasNews.Text = (news.CreatedAt.HasValue ? news.CreatedAt.Value.ToString() : "");
                    }
                    else
                    {
                        KomunikatLabel.Text = "";
                        labelCzasNews.Text = "";
                    }
                }
                Work.SetState(ActionControlStatus.ActionControlState.Ok, "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentWorkstation==null)
                    return;

                LoadNews(CurrentWorkstation.Id);
            }
            catch(CommunicationException ex)
            {
                if (ex.InnerException!=null)
                    MessageBox.Show(ex.InnerException.Message);
                else
                    MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonCzytnik_Click(object sender, EventArgs e)
        {

        }

       


             

       
    }
}
