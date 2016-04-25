using System;
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
using System.Net;
using System.Threading;
using System.Drawing.Drawing2D;

namespace InstrukcjeProdukcyjne
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private string DataDir = "Instrukcje";
        private string StanowiskaFolder = "stanowiska";
        private string ElementyFolder = "elementy";

        ITechInstrukcjeModel.ITechEntities db = new ITechInstrukcjeModel.ITechEntities();

        private SitechUser LoginUser = null;
        private ItechUsers LoginUser2 = null;
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

        public Resource CurrentModel 
        {
            get
            {
                return (Resource) ModelBindingSource.Current;
            }
            set
            {
                int i=ModelBindingSource.IndexOf(value);
                ModelBindingSource.Position=i;
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

        private bool DoLogin(SitechUser user, ItechUsers user2)
        {
            LoginUser = null;
            LoginUser = user;
            LoginUser2 = user2;

            labelUserName.Text = LoginUser.UserName;
            labelUserNo.Text = LoginUser.NrKarty;

            
            // sprawdzamy czy należy wykonać test
            //SprawdźTestKompetencji(user2);
            
            //zapis do sterownika
            //WriteToSimatic(user.NrKarty, true);

            return true;
        }

       

        private void SprawdźTestKompetencji(ItechUsers user2)
        {
            // 1. sprawdzamy kiedy ostatni został wykonany test kompetencji
            if (CzyNależyWykonacTest(user2))
                UruchomTest(user2);

        }

        private void UruchomTest(ItechUsers user2)
        {
            throw new NotImplementedException();
        }

        private bool CzyNależyWykonacTest(ItechUsers user2)
        {
            if (user2.LastTestKompetencjiDtm == null)
                return true;
            return false;
        }

        private void WriteToSimatic(string NrEwidencyjny, bool OdblokowanieMaszyny)
        {
            try
            {
                Task t = new Task(() => WriteToSimatic_Async(NrEwidencyjny, OdblokowanieMaszyny));
                t.Start();

            }
            catch (Exception)
            {
            }
        }

        private void WriteToSimatic_Async(string NrEwidencyjny, bool OdblokowanieMaszyny)
        {
            // do sprawdzenia
                Workstation w = this.CurrentWorkstation.Workstation.FirstOrDefault();
                if (w == null)
                    return;

                var conn = SitechSimaticDeviceEx.CreateFromWorkstation(w);
                conn.Fill(true);
                conn.NrEwidencyjnyDrukarka = NrEwidencyjny;
                conn.OdblokowanieMaszyny = OdblokowanieMaszyny;
                conn.Update();
        }

        private DialogResult ShowLoginDlg(String message, bool allowCancel, string allowroles)
        {
            LoginForm login = new LoginForm();
            login.Message = message;
            login.db = db;
            login.AllowRoles2 = allowroles;

            while (true)
            {
                var ret = login.ShowDialog();
                if (allowCancel)
                {
                    if (ret == System.Windows.Forms.DialogResult.Cancel)
                        return ret;
                }
                if (ret == System.Windows.Forms.DialogResult.OK)
                {
                    if (DoLogin(login.User, login.User2))
                        return ret;
                }
            }
        }


        private DialogResult ShowLoginInpersonateDlg(String message, bool allowCancel, string allowroles = "pracownik,kierownik")
        {
            LoginForm login = new LoginForm();
            login.Message = message;
            login.db = db;
            login.AllowRoles2 = allowroles;

            while (true)
            {
                var ret = login.ShowDialog();
                if (allowCancel)
                {
                    if (ret == System.Windows.Forms.DialogResult.Cancel)
                        return ret;
                }
                if (ret == System.Windows.Forms.DialogResult.OK)
                {
                    LoginUser2 = login.User2;
                    return ret;
                }
            }
        }
        private string _LastReadModelIndex = "";
        private string _LastSimaticError = "";
        AutoResetEvent _TaskSimaticReadRunning = new AutoResetEvent(true);
        private async Task<Resource> SimaticRead()
        {
            Resource ret = null;
            if (!_TaskSimaticReadRunning.WaitOne(0))
                return null;
            try
            {
                toolStripStatusLabel2.Text = "Sterownik : ???";
                if (this.CurrentWorkstation == null)
                    return null;

                Workstation w = this.CurrentWorkstation.Workstation.FirstOrDefault();
                if (w == null)
                    return null;

                var conn = SitechSimaticDeviceEx.CreateFromWorkstation(w);
                conn.Fill(false);

                toolStripStatusLabel2.Text = "Sterownik : " + conn.NrModelu.ToString();
                var modelindex = this.CurrentWorkstation.ModelsWorkstation.Where(m=>m.index==conn.NrModelu.ToString()).FirstOrDefault();
                if (modelindex!=null)
                {
                    // znajdź nazwę modelu
                    if (modelindex.index !=_LastReadModelIndex)
                    {
                        var model = modelindex.idM;

                        if (db.ResourceModel_Local != null)
                        {
                            var NewModel = db.ResourceModel_Local.Where(m => m.Id == model).FirstOrDefault();
                            if (NewModel != null)
                                ret = NewModel;
                        }
                        _LastReadModelIndex = modelindex.index;
                    }
                }
            }
            catch (Exception ex)
            {
               _LastSimaticError= ex.Message;
            }
            _TaskSimaticReadRunning.Set();
            return ret; //CurrentModel
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            var waitDlg = new WaitDlg();
            waitDlg.Show(this);
            Application.DoEvents();
            CheckUpdate();
            try
            {
                //var t1=DateTime.Now.AddSeconds(5);
                //var t2 = DateTime.Now;
                //while(t2<t1)
                //{
                //    Application.DoEvents();
                //    t2 = DateTime.Now;
                //}

                // ustawiamy aplikację pełnoekranową
                this.listView1.Focus();
                ClearControls();
                GoFullscreen(true);
                PrepareListView();

                // ładujemy ustawienia aplikacji
                var s = Settings.Default.Load;
                db.WorkDir = Settings.Default.App.LocalDoc;
                toolStripStatusLabel1.Text = "Sitech";// Path.GetFullPath(db.WorkDir);
                StartupApp.CreateWorkDirektory(db.WorkDir);


                Application.DoEvents();
                if (Settings.Default.App.Stanowisko.Value == 0)
                {
                    waitDlg.Hide();
                    ShowSettings();
                    waitDlg.Show();
                }
                // ładujemy resources
                //LoadResource(Settings.Default.App.Stanowisko);
                await LoadResource_Async(Settings.Default.App.Stanowisko);

                waitDlg.Hide();
                if (ShowLoginDlg("", true, AllowRoles.All) == System.Windows.Forms.DialogResult.Cancel)
                    this.Close();
                waitDlg.Show();

                ZaładujPliki();

                waitDlg.Close();
            }
            catch (Exception ex)
            {
                waitDlg.Close();
                MessageBox.Show(ex.Message);
            }
            timer1.Enabled = true;
            timer1_Tick(sender, e);

            timer3.Enabled = true;
            timer3_Tick(sender, e);
            DocSyncDlg.Sync();
        }

        private void CheckUpdate()
        {
            try
            {
                var d = new AboutBox1();
                d.InstallUpdateSync();
            }
            catch (Exception)
            {
                
                
            }
        }

        private void ClearControls()
        {
            labelUserName.Text = string.Empty;
            labelUserNo.Text = string.Empty;
            labelTime.Text = string.Empty;
            KomunikatLabel.Text = string.Empty;

        }
        private void PrepareListView(ListView listView)
        {
            listView.Columns.Add("Plik", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Opis", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nazwa kodowa", -2, HorizontalAlignment.Left);

            //listView.Groups.Add(new ListViewGroup("Grupa1", HorizontalAlignment.Left));
            //listView.Groups.Add(new ListViewGroup("Grupa2", HorizontalAlignment.Left));

        }
        private void PrepareListView()
        {
            PrepareListView(listView1);
            PrepareListView(listView2);
        }

        string _SimaticLastMsg = string.Empty;
        async Task LoadResource_Async(int? idR)
        {
            if (!idR.HasValue)
                return;
#if !DEBUGE
            using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
            {
                try
                {
                    client.IsOnLine();
                    {
                        var t = await client.GetInformationPlainsListAsync(idR.Value);
                        db.Resource_Local = t.ToList();
                        db.ExportResources(null);
                        var i = await client.GetITechUserListAsync();
                        db.ItechUsers_Local = i.ToList();
                        db.ExportItechUsers(null);
                    }
                }
                catch (Exception ex)
                {
                   _SimaticLastMsg= ex.Message;
                }
            }
#endif
            if (db.Resource_Local == null)
            {
                // pobieramy z pliku
                db.ImportResource(null);
            }

            if (db.ItechUsers_Local == null)
                db.ImportItechUsers(null);

            if (idR.HasValue)
                CurrentWorkstation = db.ResourceWorkstation_Local.Where(m => m.Id == idR.Value).FirstOrDefault();
            else
                CurrentWorkstation = null;

            ZaładujElementy(CurrentWorkstation);
        }

        /// <summary>
        /// Załaduj Resource 
        /// Ustaw  Workstation o zadanym idR
        /// Jeśli jest dostępna baza to z bazy jeśli nie to z pliku
        /// </summary>
        /// <param name="idR"></param>
        private void LoadResource(int? idR)
        {
            if (!idR.HasValue)
                return;

            using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
            {
                if (client.IsOnLineTry())
                {
                    db.Resource_Local =  client.GetInformationPlainsList(idR.Value).ToList();
                    db.ExportResources(null);
                    var i = client.GetITechUserList();
                    db.ItechUsers_Local = i.ToList();
                    db.ExportItechUsers(null);
                }
            }

            if (db.Resource_Local == null)
            {
                // pobieramy z pliku
                db.ImportResource(null);
            }

            if (db.ItechUsers_Local == null)
                db.ImportItechUsers(null);

            if (idR.HasValue)
                CurrentWorkstation = db.ResourceWorkstation_Local.Where(m => m.Id == idR.Value).FirstOrDefault();
            else
                CurrentWorkstation = null;

            ZaładujElementy(CurrentWorkstation);

        }


        private void ZaładujElementy(Resource res)
        {
            var data = db.GetResourceModel_Local(res);
            ModelBindingSource.DataSource = data;
        }

       

        private void OnModelChanged()
        {
            var x = ModelBindingSource.Current;
            if (x == null)
            {
                ZaładujPliki(null, listView2);
                return;
            }

            Resource NewModel = (Resource)x;
            ZaładujPliki(NewModel, listView2);
        }

        private void OnModelChanged(Resource newModel)
        {
            if (newModel == null)
            {
                ZaładujPliki(null, listView2);
                return;
            }
            ZaładujPliki(newModel, listView2);
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

        private void ZaładujPliki()
        {
            ZaładujPliki(CurrentWorkstation, listView1);
            ZaładujPliki(CurrentModel, listView2);
        }
 


        private void ZaładujPliki(Resource res, ListView listView)
        {
            listView.Items.Clear();
            if (res == null)
                return;
            listView1.BeginUpdate();
            var IP = res.InformationPlanWorkstation;
            var g = IP.Where(m=>m.Dokument.Kategorie != null).Select(m => m.Dokument.Kategorie.name).Distinct();
            listView.Groups.Clear();
            foreach (var item in g)
            {
                if (item!=null)
                    listView.Groups.Add(item, item);
            }
            listView.Groups.Add("inne", "inne");

            foreach (var item in IP)
            {
                if (item.Dokument != null)
                {
                    var d = new MyFileInfo { FileName = item.Dokument.FileName, FullFileName = db.CreateLocalFileName(item.Dokument), Dok = item.Dokument };
                    var s = string.IsNullOrEmpty(item.Dokument.Description) ? item.Dokument.FileName : item.Dokument.Description;
                    var i = listView.Items.Add(d.FullFileName, s, d.ExtensionIndex);
                    i.SubItems.Add(item.Dokument.CodeName);
                    i.Tag = d;

                    if (item.Dokument.Kategorie != null)
                        i.Group = listView.Groups[item.Dokument.Kategorie.name];
                    else
                        i.Group = listView.Groups["inne"];
                }
                
                
            }
            listView1.EndUpdate();
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listView_MouseDoubleClick(sender, e);
        }


        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
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
                            //mediaViewerControl1.ShowDokument(mfi.FullFileName);
                            OnDokumentShow(mfi);
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listView_MouseDoubleClick(sender, e);
        }

        private void OnDokumentShow(MyFileInfo file)
        {
            try
            {
                var dial = new DokumentShowDlg(file, LoginUser);
                dial.ShowDialog();

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
            ShowMyMenu(sender, e);
        }

        private void ShowMyMenu(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            contextMenuStrip1.Show(c, 0, c.Size.Height);
        }

        private async void LogOut()
        {
            try
            {
                ShowLoginDlg("Użyj kart aby odblokować", false, AllowRoles.All);
                Application.DoEvents();
                using (var dial = new WaitDlg())
                {
                    dial.Show();
                    await LoadResource_Async(Properties.Settings.Default.App.Stanowisko);
                    DocSyncDlg.Sync();
                }

            }
            catch (Exception)
            {
                
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private async void ShowSettings()
        {
            try
            {
                var dial = new SettingsDlg();
                if (dial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    await LoadResource_Async(Properties.Settings.Default.App.Stanowisko);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!AllowAction(AllowRoles.Kierownik, "Aby zmienić ustawienia przyłóż kartę"))
                return;

            ShowSettings();
            // ustawienia
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
#if !DEBUG
            if (!AllowAction(AllowRoles.Kierownik, "Aby zamknąć przyłóż kartę"))
                return;
            // zakończ
#endif
            this.Close();
        }

        private bool AllowAction(string allowRoles, string LoginMsg)
        {
            var b = LoginUser2.IsInRole(allowRoles);
            if (b == true)
                return true;
            if (ShowLoginDlg(LoginMsg, true, allowRoles)==System.Windows.Forms.DialogResult.OK)
                return true;
            return false;

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

        public DateTime _LastReadNews { get; set; }
        AutoResetEvent _TaskNewsIsRunning = new AutoResetEvent(true);
        private async void LoadNews(int idR)
        {
            try
            {

                if (!_TaskNewsIsRunning.WaitOne(0))
                    return;

                using (var Work = new InstrukcjeProdukcyjne.ActionControlStatus(buttonItech))
                {
                    Work.SetState(ActionControlStatus.ActionControlState.Working, "");
                    using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                    {
                        var d = await client.PingAsync();
                        toolStripStatusITechTime.Text = (d.ToShortTimeString());
                        News news = await client.GetNewsAsync(idR);
                        if (news != null)
                        {
                            KomunikatLabel.Text = news.News1;
                        }
                        else
                        {
                            KomunikatLabel.Text = "";
                        }
                    }
                    Work.SetState(ActionControlStatus.ActionControlState.Ok, "");
                }
            }
            catch (Exception /*ex*/)
            {

            }
            finally
            {
                _LastReadNews = DateTime.Now;
                _TaskNewsIsRunning.Set();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentWorkstation != null)
                    LoadNews(CurrentWorkstation.Id);
                DownloadDocIf();
            }
            catch (Exception /*ex*/)
            {
            }
        }

        DateTime DownloadDocNext = DateTime.MinValue;
        DateTime DownloadDocLast= DateTime.Now;
        TimeSpan DownloadDocPeriod = new TimeSpan(1, 0, 0, 0);
        private void DownloadDocIf()
        {
                if (DownloadDocNext==DateTime.MinValue)
                {
                    // losujemy kiedy ma odbyć się następne downloads
                    var r = new Random();
                    var time = new TimeSpan(0, 3, r.Next(59), r.Next(59));
                    DownloadDocNext = DateTime.Now.Date.Add(DownloadDocPeriod).Add(time);

                    if (DownloadDocPeriod.TotalDays < 1)
                    {
                        time = new TimeSpan(0, 0, r.Next(59), r.Next(59));
                        if (DownloadDocPeriod.TotalHours < 1)
                            time = new TimeSpan(0, 0, 0, r.Next(59), r.Next(99));

                        DownloadDocNext = DateTime.Now.Add(time);
                    }


                }
                if (DownloadDocNext<DateTime.Now)
                {
                    // ustaw nowy czas
                    DownloadDocNext=DownloadDocNext.Add(DownloadDocPeriod);
                    
                    // pobierz dokumenty
                    DocSyncDlg.Sync();
                    //DocSyncDlg.Show(this);

                }
        }

        private void OnSeverClick()
        {
            try
            {
                if (CurrentWorkstation == null)
                    return;

                LoadNews(CurrentWorkstation.Id);
            }
            catch (CommunicationException ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message);
                else
                    MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OnSeverClick();
        }

        private void buttonCzytnik_Click(object sender, EventArgs e)
        {

        }

        private void elementyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ModelBindingSource_PositionChanged(object sender, EventArgs e)
        {
            OnModelChanged();
        }

        private DokumentSyncDlg DocSyncDlg = new DokumentSyncDlg();

        private void synchronizujPlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DocSyncDlg.Sync();
            DocSyncDlg.Show(this);

            //TODO: Podłączyć sterowniki simatic
            //czytnik
            //testy
        }

        private void testKompetencjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dial = new TestKompetencjiDlg();
                dial.UserId=LoginUser2.UserId;
                dial.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString();
        }

        private void buttonSterownik_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ShowMyMenu(sender, e);
        }


        private void panel3_Click(object sender, EventArgs e)
        {
            ShowMyMenu(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ShowMyMenu(sender, e);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LogOut();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listView2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

            //if ((e.State & ListViewItemStates.Selected) != 0)
            //{
            //    // Draw the background and focus rectangle for a selected item.
            //    e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
            //    e.DrawFocusRectangle();
            //}
            //else
            //{
            //    // Draw the background for an unselected item.
            //    using (LinearGradientBrush brush =
            //        new LinearGradientBrush(e.Bounds, Color.Orange,
            //        Color.Maroon, LinearGradientMode.BackwardDiagonal))
            //    {
            //        e.Graphics.FillRectangle(brush, e.Bounds);
            //    }
            //}

            //// Draw the item text for views other than the Details view.
            //if (listView1.View != View.Details)
            //{
            //    e.DrawText();
            //}

            //var p = new Pen(Color.Red, 3);
            //e.Graphics.DrawRectangle(p, e.Bounds);

            e.DrawDefault = true;
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            StartSimaticRead();
        }


        private Task<Resource> SimaticReadTask = null;
        private async void StartSimaticRead()
        {
            if ((SimaticReadTask != null) && (SimaticReadTask.IsCompleted == false ||
                                       SimaticReadTask.Status == TaskStatus.Running ||
                                       SimaticReadTask.Status == TaskStatus.WaitingToRun ||
                                       SimaticReadTask.Status == TaskStatus.WaitingForActivation))
                return;
            
            try
            {
                SimaticReadTask = Task.Run(() => SimaticRead());
                
                //SimaticReadTask.ConfigureAwait(false);
                var x = SimaticReadTask.Result;
                //var x = await Task.Run(() => SimaticRead());
                if (x != null)
                    CurrentModel = x;

            }
            catch (Exception)
            {

            }
        }
        
        private void timer3_Tick(object sender, EventArgs e)
        {

            StartSimaticRead();
        }

    


    }
}



