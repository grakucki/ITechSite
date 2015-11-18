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
    public partial class Form2 : Form
    {
        public Form2()
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
            labelUserNo.Text = user2.UserId + "(" + LoginUser.NrKarty + ")";

            
            // sprawdzamy czy należy wykonać test
            //SprawdźTestKompetencji(user2);
            
            //zapis do sterownika
            SimaticWriteAsync(user2.UserId, true);

            return true;
        }

        private void DoLogOut()
        {
            
            SimaticWriteAsync(string.Empty, false);
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

       
        private DialogResult ShowLoginDlg(String message, bool allowCancel, string allowroles)
        {
            LoginForm login = new LoginForm();
            login.Message = message;
            login.db = db;
            login.AllowRoles = allowroles;
            try
            {
                _LoginForm = login;
                _LoginForm.SetStanowiskoStatus(LastStanowiskoStatus);


                while (true)
                {
                    var ret = login.ShowDialog();
                    if (allowCancel)
                    {
                        if (ret == System.Windows.Forms.DialogResult.Cancel)
                        {
                            _LoginForm = null;
                            return ret;
                        }
                 }
                    if (ret == System.Windows.Forms.DialogResult.OK)
                    {
                        if (DoLogin(login.User, login.User2))
                        {
                            _LoginForm = null;
                            return ret;
                        }
                    }
                }
            }
            finally
            {
                _LoginForm = null;
            }
        }


        private DialogResult ShowLoginInpersonateDlg(String message, bool allowCancel, string allowroles = "pracownik,kierownik")
        {
            LoginForm login = new LoginForm();
            login.Message = message;
            login.db = db;
            login.AllowRoles = allowroles;

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


        private int BlockThread(int sec)
        {
            DateTime d = DateTime.Now.AddSeconds(sec);
            DateTime x = DateTime.Now;
            while (DateTime.Now < d)
            {
                x = DateTime.Now;
            }
            return x.Second;
        }




        private void SimaticWrite(string NrEwidencyjnyDrukarka, bool OdblokowanieStan)
        {
            try
            {
                Workstation w = this.CurrentWorkstation.Workstation.FirstOrDefault();
                if (w == null)
                    return;

                var conn = SitechSimaticDeviceEx.CreateFromWorkstation(w);
                if (conn.CpuType == S7.Net.CpuType.Demo)
                    conn.Fill(true);
                conn.NrEwidencyjnyDrukarka = NrEwidencyjnyDrukarka;
                conn.OdblokowanieMaszyny =  OdblokowanieStan;
                conn.Update();
            }
            catch (Exception)
            {
            }
        }

        private string _LastReadModelIndex = "";
        private string _LastSimaticError = "";

        private StatusMessage _LastStanowiskoStatus = null;
        private LoginForm _LoginForm = null;

        public StatusMessage LastStanowiskoStatus
        {
            get { return _LastStanowiskoStatus; }
            set
            {
                _LastStanowiskoStatus = value;

                
                OdblokowanieToolStripStatusLabel.Text = value.Message;
                this.Invoke( new MethodInvoker( () =>
                {
                    if (value.Code < 0)
                        OdblokowanieToolStripStatusLabel.BackColor = Color.Red;
                    else
                        OdblokowanieToolStripStatusLabel.BackColor = Color.Green;
                    if (_LoginForm != null)
                        _LoginForm.SetStanowiskoStatus(value);
                }

                ));


            }
        }


        AutoResetEvent _TaskSimaticReadRunning = new AutoResetEvent(true);

        private Resource SimaticRead()
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
                SimaticStatusMsg(conn);

                //BlockThread(5);
                toolStripStatusLabel2.Text = "Sterownik : '" + conn.NrModelu.ToString()+"'";
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
                    _LastSimaticError = " Ok";
                }
                else
                _LastSimaticError = " Ok. Nieznany index modelu.";

            }
            catch (Exception ex)
            {
               _LastSimaticError= ex.Message;
               SimaticStatusMsg(null);
            }
            _TaskSimaticReadRunning.Set();
            return ret; //CurrentModel
        }


        // generuje komunikat o stanie sterownika, zablokowany, odblokowany, klucz
        private void SimaticStatusMsg(ItechSimatic.SitechSimaticDevice conn)
        {

            if (conn==null)
            {
                LastStanowiskoStatus = new StatusMessage(0, "???");
                return;
            }
            if (conn.OdblokowanieKlucz)
            {
                LastStanowiskoStatus = new StatusMessage(1, "Stanowisko odblokowane kluczem.");
                return;
            }
            if (conn.OdblokowanieStan)
                LastStanowiskoStatus = new StatusMessage(2, "Stanowisko odblokowane.");
            else
                LastStanowiskoStatus = new StatusMessage(-1, "Stanowisko zablokowane");
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

                
                this.groupListViewWorkstation.Focus();
                ClearControls();
                // ustawiamy aplikację pełnoekranową
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

            ShowTestKompetencji();
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
            groupListViewWorkstation.ColumnsCnt = 1;
            groupListViewWorkstation.OnMouseDoubleClickItem+=groupListViewWorkstation_OnMouseDoubleClick;
            groupListViewModels.OnMouseDoubleClickItem += groupListViewWorkstation_OnMouseDoubleClick;

            //PrepareListView(listView1);
            //PrepareListView(listView2);
            //PrepareListView(listView3);
        }


        void SaveErrorStatusSerwer(string msg, string filename)
        {
            var fullfilename = Path.Combine(Settings.Default.App.LocalDoc, filename);
            try 
	        {
                using (var f = File.CreateText(fullfilename))
                {
                    f.WriteLine("Status serwera pliku : " + DateTime.Now);
                    f.WriteLine("adress: " + Settings.Default.App.ServerDoc);
                    f.WriteLine("====================");
                    f.Write(msg);
                }
        	}
	        catch (Exception)
	        {
	        }
        }

        void SaveError(string msg, string filename)
        {
            var fullfilename = Path.Combine(Settings.Default.App.LocalDoc, filename);
            try
            {
                using (var f = File.CreateText(fullfilename))
                {
                    f.Write(msg);
                }
            }
            catch (Exception)
            {
            }
        }

        void SetSerwerStatus(string msg, string longmsg)
        {
            toolStripStatusLabelSerwer.Text = "Serwer : " + msg;
            _SerwerLastMsg = longmsg;
            if (!string.IsNullOrEmpty(longmsg))
                SaveErrorStatusSerwer(longmsg, "serwerstatus.txt");
        }

        string _SimaticLastMsg = string.Empty; 
        string _SerwerLastMsg = string.Empty;
        bool _RunTestKompetencji = false;


        async Task LoadResource_Async(int? idR)
        {
            if (!idR.HasValue)
                return;
#if !DEBUGE
            using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
            {
                try
                {
                    SetSerwerStatus("łączę",null);
                    if (client.IsOnLine())
                    {
                        var t = await client.GetInformationPlainsListAsync(idR.Value);
                        db.Resource_Local = t.ToList();
                        db.ExportResources(null);
                        var i = await client.GetITechUserListAsync();
                        db.ItechUsers_Local = i.ToList();
                        db.ExportItechUsers(null);

                        SetSerwerStatus("Ok", "Połaczony");
                    }
                    else
                        SetSerwerStatus("Rozłączony", "Rozłączony");
                }
                catch (Exception ex)
                {
                    SetSerwerStatus("Błąd", ex.Message);
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
                if (client.IsOnLine())
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
                ZaładujPliki2(null, null);
                return;
            }

            Resource NewModel = (Resource)x;
            ZaładujPliki2(NewModel, groupListViewModels);
        }

        //private void OnModelChanged(Resource newModel)
        //{
        //    if (newModel == null)
        //    {
        //        ZaładujPliki2(null, null);
        //        return;
        //    }
        //    ZaładujPliki(newModel, null);
        //}

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
            ZaładujPliki2(CurrentWorkstation, groupListViewWorkstation);
            ZaładujPliki2(CurrentModel, groupListViewModels);
        }
 


        private void ZaładujPliki2(Resource res, GroupListView2 listView)
        {
            if (listView == null)
                return;
            listView.Items.Clear();

            if (res == null)
                return;
            //var IP = res.InformationPlanModel;
            ICollection<InformationPlan> IP = null;
            if (res.Type==1)
                IP = res.InformationPlanWorkstation.Where(m => m.IdM == null || m.IdM == res.Id).ToList();
            else
                IP = res.InformationPlanModel;

            var g = IP.Where(m => m.Dokument.Kategorie != null).Select(m => m.Dokument.Kategorie.name).Distinct();


            var my = new List<Object>();
            MyFileInfoEx fe = new MyFileInfoEx();
            foreach (var item in IP)
            {
                if (item.Dokument != null)
                {
                    var d = new MyFileInfo { FileName = item.Dokument.FileName, FullFileName = db.CreateLocalFileName(item.Dokument), Dok = item.Dokument };
                    var s = string.IsNullOrEmpty(item.Dokument.Description) ? item.Dokument.FileName : item.Dokument.Description;

                    d.ItemText = s;
                    d.ItemText2 = d.Dok.CodeName;
                    d.ItemIcon = fe.GetBitmapForFileExt(d.Extension);
                    if (item.Dokument.Kategorie != null)
                        d.GroupBy = item.Dokument.Kategorie.name;
                    else
                        d.GroupBy = "inne";
                    my.Add(d);
                }
            }

            listView.DataSource = my;
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


        void groupListViewWorkstation_OnMouseDoubleClick(object sender, object e)
        {
            try
            {
                if (e == null)
                    return;

                var mfi = (MyFileInfo)e;
                if (mfi != null)
                {
                    if (File.Exists(mfi.FullFileName))
                        OnDokumentShow(mfi);
                    else
                        MessageBox.Show("Nie odnaleziono pliku." + mfi.FileName);
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
                DoLogOut();
                ShowLoginDlg("Użyj kart aby odblokować", false, AllowRoles.All);
                Application.DoEvents();
                using (var dial = new WaitDlg())
                {
                    dial.Show();
                    await LoadResource_Async(Properties.Settings.Default.App.Stanowisko);
                    ZaładujPliki();
                    DocSyncDlg.Sync();
                    ShowTestKompetencji();
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
                    DisplaySimaticState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DisplaySimaticState()
        {
            SimaticWriteAsync(LoginUser2.UserId, true);
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

            if (!AllowAction(AllowRoles.Kierownik, "Aby zamknąć przyłóż kartę"))
                return;
            // zakończ
            this.Close();
        }

        private bool AllowAction(string allowRoles, string LoginMsg)
        {
            if (LoginUser2 == null)
            {
                return true;
            }
            var b = LoginUser2.IsInRole(allowRoles);
            if (b == true)
                return true;
            if (ShowLoginInpersonateDlg(LoginMsg, true, allowRoles)==System.Windows.Forms.DialogResult.OK)
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


        NewsCssColection NewsCss = new NewsCssColection();

        void DisplayNews(string news, int CssId)
        {
            KomunikatLabel.Text = news;
            var css = NewsCss.GetCss(CssId);
            NewsCustomPanel.BackColor = css.BackgroundColor;
            NewsCustomPanel.BackColor2 = css.BackgroundColor;
            NewsCustomPanel.GradientMode = CustomPanelControl.LinearGradientMode.None;
            NewsCustomPanel.Refresh();

            KomunikatLabel.ForeColor = css.Color;
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
                            DisplayNews(news.News1, (news.NewsPriorityId));
                        else
                            DisplayNews("",0);
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


        private void KomunikatLabel_DoubleClick(object sender, EventArgs e)
        {
            OnSeverClick();
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

        private void ShowTestKompetencji()
        {
            try
            {

                using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
                {
                    _RunTestKompetencji = client.RunTestKompetencji(LoginUser2.UserId);

                    if (!_RunTestKompetencji)
                        return;
                    _RunTestKompetencji = false;
                    var dial = new TestKompetencjiDlg();
                    dial.UserId = LoginUser2.UserId;
                    dial.ShowDialog();

                    //dial.TestRes;
                    client.UpdateTestKompetencjiAsync(LoginUser2.UserId, dial.TestRes? 1:0);
                }
            }
            catch (Exception ex)
            {
                SaveError(ex.Message, "TestKompetencji.txt");
            }
            return;
        }


        private void testKompetencjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dial = new TestKompetencjiDlg();
                dial.UserId = LoginUser2.UserId;
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
            e.DrawDefault = true;
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            _LastReadModelIndex = "";
            SimaticReadAsync();
            MessageBox.Show("Komunikacja Simatic" + _LastSimaticError);
        }



        private async void SimaticReadAsync()
        {
            try
            {
               var x= await Task.Run(() => SimaticRead());
                
                if (x != null)
                    CurrentModel = x;

            }
            catch (Exception)
            {

            }
        }

        private async void SimaticWriteAsync(string NrEwidencyjnyDrukarka, bool OdblokowanieStan)
        {
            try
            {
                toolStripStatusLabel2.ToolTipText = ">>>";
                toolStripStatusLabel2.BackColor = Color.OrangeRed;

                if (!Properties.Settings.Default.App.PozwalajNaBlokowanieStanowiska.Value)
                {
                    OdblokowanieStan = true;
                }
                await Task.Run(() => SimaticWrite(NrEwidencyjnyDrukarka, OdblokowanieStan));

                if (!Properties.Settings.Default.App.PozwalajNaBlokowanieStanowiska.Value)
                {
                    toolStripStatusLabel2.ToolTipText = "Praca bez blokady";
                    toolStripStatusLabel2.BackColor = Color.Blue;
                }
                else
                {
                    if (OdblokowanieStan)
                    {
                        toolStripStatusLabel2.ToolTipText = "Odblokowane"; 
                        toolStripStatusLabel2.BackColor = Color.Green;
                    }
                    else
                    {
                        toolStripStatusLabel2.ToolTipText = "Zablokowane";
                        toolStripStatusLabel2.BackColor = Color.Red;
                    }
                }


                    
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.ToolTipText = ex.Message;
            }
        }


        
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            SimaticReadAsync();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DoLogOut();
            }
            catch (Exception)
            {
                
            }
        }

        

    }
}



