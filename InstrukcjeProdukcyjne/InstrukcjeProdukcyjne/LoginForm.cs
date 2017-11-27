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

namespace InstrukcjeProdukcyjne
{

    public partial class LoginForm : Form
    {
        public enum LoginDlgAction
        {
            None,
            Logon,
            AppClose
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        public SitechUser User { get; set; }
        public ITechInstrukcjeModel.ItechUsers User2 { get; set; }
        private LoginDlgAction DlgAction { get; set; }

        public String Message { get; set; }
        //public string CardReaderFileDat { get; set; }

        public ITechInstrukcjeModel.ITechEntities db = null;
        public string AllowRoles2 = AllowRoles.RoleCanLogon;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.FullScreen(true);
            panel3.Visible = false;
            User = new SitechUser();
            LabelClear();
            //CardReaderFileDat = @"C:\Programs\interfaces\reader1.dat";

            if (!Directory.Exists(Path.GetDirectoryName(Properties.Settings.Default.App.CardReaderFileDat)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Properties.Settings.Default.App.CardReaderFileDat));
            }

            //if (!File.Exists(CardReaderFileDat))
            //{
            //    using (var x = File.CreateText(CardReaderFileDat))
            //    {
            //        x.Close();
            //        x.Dispose();
            //    }                    
            //}

            CardClearCmd();

            if (!string.IsNullOrEmpty(Message))
                label1.Text = Message;
                //labelMessage.Text = Message;

            fileSystemWatcher1.Path = Path.GetDirectoryName(Properties.Settings.Default.App.CardReaderFileDat);
            fileSystemWatcher1.Filter = Path.GetFileName(Properties.Settings.Default.App.CardReaderFileDat);
            textBoxCarNo.Focus();
            labelVer.Text = Application.ProductVersion;

            AutoLogin();
            
        }

        public StatusMessage StatusStanowiska { get; set; }


        public void SetStanowiskoStatus(StatusMessage msg)
        {
            StatusStanowiska = msg;
            if (msg == null)
            {
                labelSterownik.Text = string.Empty;
                return;
            }
            labelSterownik.Text= msg.Message;
            
            if (msg.Code>=0)
                pictureBox1.BackColor = Color.Gainsboro;
        }

        private void AutoLogin()
        {
           // automatyczne logowanie jeśli plik "autologin istnieje
            // pierwsza linia numer karty - to co zapisuje czytnik
            try 
	        {
                var AutoFileName = Path.Combine(Properties.Settings.Default.App.LocalDoc, "auto.dat");
                if (File.Exists(AutoFileName))
                {
                    File.Copy(AutoFileName, Properties.Settings.Default.App.CardReaderFileDat, true);
                }
	        }
	        catch (Exception)
	        {
		     
	        }
        }

        private void LabelClear()
        {
            label2.Text = "";
            label3.Text = "";
        }

        private void CardClearCmd()
        {
            var cmdFile = Path.ChangeExtension(Properties.Settings.Default.App.CardReaderFileDat, ".cmd");
            if (File.Exists(cmdFile))
                File.Delete(cmdFile);
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                
            }
        }

      

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FullScreen(true);

            if (this.DialogResult!= System.Windows.Forms.DialogResult.Cancel)
                if (!User.IsLogin)
                {
                    e.Cancel = true;
                    label3.Text = "Użyj karty!";
                }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ManualLogin();
        }


        private bool CanLogon(ITechInstrukcjeModel.ItechUsers user)
        {
            if (user==null)
                return false;

            return user.IsInRoles(AllowRoles.RoleCanLogon);
        }

        private bool CanAppExit(ITechInstrukcjeModel.ItechUsers user)
        {
            if (user == null)
                return false;

            return user.IsInRoles(AllowRoles.RoleCanAppExit);
        }


        /// <summary>
        /// pobiera użytkownika
        /// </summary>
        /// <param name="cardno">numer karty</param>
        /// <param name="passowrd">if null to logowanie za pomocą karty lub hasło</param>
        /// <returns></returns>
        private ITechInstrukcjeModel.ItechUsers GetLoginUser(string cardno, string passowrd, bool OnlyCardNo)
        {
            ITechInstrukcjeModel.ItechUsers u = null;

            using (var client = ServiceWorkstation.ServiceWorkstationClientEx.WorkstationClient())
            {
                try 
	                {
                        
                        client.IsOnLine();
                        u=client.GetLoginUser(cardno, passowrd, OnlyCardNo);
	                }
	                catch (Exception ex)
	                {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
	                }
            }

            //gdy logowanie onlien się niepowiodło
            if (u==null)
            {
                if (OnlyCardNo)
                    u = db.ItechUsers_Local.Where(m => m.CardNo == cardno).FirstOrDefault();
                else
                    u = db.ItechUsers_Local.Where(m => m.CardNo == cardno && m.Password == passowrd).FirstOrDefault();
            }
            return u;
            
        }

        private void LoginByCard(string cardno)
        {
            var u = GetLoginUser(cardno, string.Empty,true);
            RunAction(u);
        }


        private void ManualLogin()
        {
            try
            {

                var cardno = textBoxCarNo.Text;
                var pass = textBoxPass.Text;
                label2.Text = cardno;
                if (string.IsNullOrEmpty(pass))
                {
                    label3.Text = "Podaj hasło.";
                    User = new SitechUser();
                    TimerGo(false, 5);
                    return;
                }

                //var u = db.ItechUsers_Local.Where(m => m.CardNo == cardno && m.Password==pass).FirstOrDefault();
                var u = GetLoginUser(cardno, pass, false);
                RunAction(u);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RunAction(ITechInstrukcjeModel.ItechUsers user)
        {
            User2 = user;
            DlgAction = GetAction();
            string roletocheck = GetActionRole();


            if (user == null || !user.IsInRoles(roletocheck))
            {
                label3.Text = "Brak uprawnień.";
                User = new SitechUser();
                TimerGo(false, 5);

            }
            else
            {
                label3.Text = user.UserName;
                User = new SitechUser { UserName = user.UserName, NrKarty = user.CardNo, IsLogin = true };
                TimerGo(true, 1);
            }
        }

        private LoginDlgAction GetAction()
        {
            LoginDlgAction ret = LoginDlgAction.None;
            string roletocheck = AllowRoles.RoleCanLogon;
            if (AppCloseRadioButton.Checked)
                ret = LoginDlgAction.AppClose;
            else
                ret = LoginDlgAction.Logon;
            return ret;
        }

        private string GetActionRole()
        {
            string roletocheck = AllowRoles2;
            if (AppCloseRadioButton.Checked)
                roletocheck = AllowRoles.RoleCanAppExit;
            return roletocheck;
        }

        private void ManualLogin_old()
        {
            try
            {

                var cardno = textBoxCarNo.Text;
                var pass = textBoxPass.Text;
                label2.Text = cardno;
                if (string.IsNullOrEmpty(pass))
                {
                    label3.Text = "Podaj hasło.";
                    User = new SitechUser();
                    TimerGo(false, 5);
                    return;
                }

                var u = db.ItechUsers_Local.Where(m => m.CardNo == cardno && m.Password == pass && m.IsInRoles(AllowRoles2)).FirstOrDefault();
                User2 = u;
                if (u == null)
                {
                    label3.Text = "Brak uprawnień.";
                    User = new SitechUser();
                    TimerGo(false, 5);

                }
                else
                {
                    label3.Text = u.UserName;
                    User = new SitechUser { UserName = u.UserName, NrKarty = cardno, IsLogin = true };
                    TimerGo(true, 1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool Timer_EndForm = false;
        DateTime Timer_ActionAt = DateTime.Now;


        private void ReadCard()
        {
            try
            {
                System.Threading.Thread.Sleep(200);
                var f = File.ReadAllText(Properties.Settings.Default.App.CardReaderFileDat);
                {
                    var cardno =  GetCardNo(f);
                    label2.Text = cardno;
                    LoginByCard(cardno);
                }

            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }

            try
            {
                CardClearCmd();
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }

        }

        private void ReadCard_old()
        {
            try
            {
                System.Threading.Thread.Sleep(200);
                var f = File.ReadAllText(Properties.Settings.Default.App.CardReaderFileDat);
                {
                    var cardno = GetCardNo(f);
                    label2.Text = cardno;

                    var u = db.ItechUsers_Local.Where(m => m.CardNo == cardno && m.IsInRoles(AllowRoles2)).FirstOrDefault();
                    User2 = u;
                    if (u == null)
                    {
                        label3.Text = "brak uprawnień do zalogowania";
                        User = new SitechUser();
                    }
                    else
                    {
                        // login ok
                        label3.Text = u.UserName;
                        User = new SitechUser { UserName = u.UserName, NrKarty = cardno, IsLogin = true };
                        TimerGo(true, 1);
                    }
                }

            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }

            try
            {
                CardClearCmd();
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }

        }


        private void TimerGo(bool EndfForm, int delay)
        {
            Timer_ActionAt = DateTime.Now.AddSeconds(delay);
            Timer_EndForm = EndfForm;
            timer1.Enabled = true;
        }

        private string GetCardNo(string f)
        {
            var mask = "0800040029011X99";
            // na życzenie sitech odczytujemy tylko 6 ostatnich numerów karty
            var l = f.Length;
            if (l < mask.Length)
                throw new Exception("Nieprawidłowy format numeru karty. Za mało znaków.");

//            return f.Substring(mask.LastIndexOf("X") + 1);
            return f.Substring(l - 6, 6);

        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            ReadCard();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            ReadCard();
        }

        private void labelMessage_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            textBoxCarNo.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Timer_ActionAt < DateTime.Now)
            {
                timer1.Enabled = false;
                if (Timer_EndForm)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    if (DlgAction == LoginDlgAction.AppClose)
                        Application.Exit();

                    this.Close();
                }
                else
                    LabelClear();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VirtualKeyboard.Show();
            textBoxPass.Focus();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Properties.Settings.Default.App.CardReaderFileDat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (StatusStanowiska == null)
                return;

            if (StatusStanowiska.Code<0)
            {
                if (pictureBox1.BackColor == Color.Red)
                {
                    pictureBox1.BackColor = Color.Gainsboro;
                    labelSterownik.BackColor = Color.Gainsboro;
                }
                else
                {
                    pictureBox1.BackColor = Color.Red;
                    labelSterownik.BackColor = Color.Red;
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton) sender;
            if (rb.Checked==true)
                buttonOk.Text = "Zamknij aplikację";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked == true)
                buttonOk.Text = "Zaloguj";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
