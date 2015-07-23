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
        public String Message { get; set; }
        public string CardReaderFileDat { get; set; }

        public ITechInstrukcjeModel.ITechEntities db = null;
        public string AllowRoles = string.Empty;

        private void LoginForm_Load(object sender, EventArgs e)
        {

            panel3.Visible = false;
            User = new SitechUser();
            label2.Text = ""; 
            label3.Text = "";
            CardReaderFileDat = "c:/Bedanet/transfer/reader1.dat";
            if (!File.Exists(CardReaderFileDat))
            {
                using (var x = File.CreateText(CardReaderFileDat))
                {
                    x.Close();
                    x.Dispose();
                }                    
            }

            if (!string.IsNullOrEmpty(Message))
                labelMessage.Text = Message;

            fileSystemWatcher1.Path = Path.GetDirectoryName(CardReaderFileDat);
            fileSystemWatcher1.Filter = Path.GetFileName(CardReaderFileDat);
            textBoxCarNo.Focus();
            
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
                System.Threading.Thread.Sleep(200);
                var f = File.ReadAllLines(CardReaderFileDat);
                {

                    var cardno = textBoxCarNo.Text;
                    var pass = textBoxPass.Text;
                    label2.Text = cardno;

                    var u = db.ItechUsers_Local.Where(m => m.CardNo == cardno && m.Password==pass && m.IsInRoles(AllowRoles)).FirstOrDefault();
                    if (u == null)
                    {
                        label3.Text = "Brak uprawnień do zalogowania";
                        User = new SitechUser();
                    }
                    else
                    {
                        label3.Text = u.UserName;
                        User = new SitechUser { UserName = u.UserName, NrKarty = cardno, IsLogin = true };
                        timer1.Enabled = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ReadCard()
        {
            try
            {
                System.Threading.Thread.Sleep(200);
                var f = File.ReadAllLines(CardReaderFileDat);
                {
                    
                    var cardno =  string.Join(",", f);
                    label2.Text = cardno;

                    var u = db.ItechUsers_Local.Where(m => m.CardNo == cardno && m.IsInRoles(AllowRoles)).FirstOrDefault();
                    if (u == null)
                    {
                        label3.Text = "brak uprawnień do zalogowania";
                        User = new SitechUser();
                    }
                    else
                    {
                        label3.Text = u.UserName;
                        User = new SitechUser { UserName = u.UserName, NrKarty = cardno, IsLogin = true };
                        timer1.Enabled = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            timer1.Enabled = false;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VirtualKeyboard.Show();
        }

        
    }
}
