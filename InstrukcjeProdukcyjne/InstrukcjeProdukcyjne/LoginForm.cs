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
        public LoginForm()
        {
            InitializeComponent();
        }

        public SitechUser User { get; set; }
        public ITechInstrukcjeModel.ItechUsers User2 { get; set; }
        public String Message { get; set; }
        //public string CardReaderFileDat { get; set; }

        public ITechInstrukcjeModel.ITechEntities db = null;
        public string AllowRoles = string.Empty;


        private void LoginForm_Load(object sender, EventArgs e)
        {

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

        private void ManualLogin()
        {
            try
            {

                var cardno = textBoxCarNo.Text;
                var pass = textBoxPass.Text;
                label2.Text = cardno;

                var u = db.ItechUsers_Local.Where(m => m.CardNo == cardno && m.Password==pass && m.IsInRoles(AllowRoles)).FirstOrDefault();
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

                    var u = db.ItechUsers_Local.Where(m => m.CardNo == cardno && m.IsInRoles(AllowRoles)).FirstOrDefault();
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
                        TimerGo(true,1);
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
            if (f.Length < mask.Length)
                throw new Exception("Nieprawidłowy format numeru karty");

            return f.Substring(mask.LastIndexOf("X") + 1);

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
                    this.Close();
                }
                else
                    LabelClear();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VirtualKeyboard.Show();
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

        
    }
}
