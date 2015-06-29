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

        private void LoginForm_Load(object sender, EventArgs e)
        {

            SetError(textBoxUser, "");
            SetError(textBoxCard, "");
            CardReaderFileDat = Path.Combine(InstrukcjeProdukcyjne.Properties.Settings.Default.LocalDir, "reader1.dat");
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

            fileSystemWatcher1.Path = InstrukcjeProdukcyjne.Properties.Settings.Default.LocalDir;
            fileSystemWatcher1.Filter = "reader1.dat";

            textBoxUser.Focus();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                User = new SitechUser { UserName = textBoxUser.Text, NrKarty = textBoxUser.Text };
            }
        }

        private void SetError(Control control, string msg)
        {
            errorProvider1.SetError(control, msg);

            if (control == textBoxCard)
            {
                labelCard.Text = msg;
                return;
            }

            if (control == textBoxUser)
            {

                labelUser.Text = msg;
                return;
            }


        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool Requed = false;

            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (Requed)
                {
                    if (string.IsNullOrEmpty(textBoxUser.Text))
                    {
                        e.Cancel = true;
                        SetError(textBoxUser, "Podaj Użytkownika");
                    }
                    else
                        SetError(textBoxUser, "");

                    if (string.IsNullOrEmpty(textBoxCard.Text))
                    {
                        e.Cancel = true;
                        SetError(textBoxCard, "Podaj Nr karty");
                    }
                    else
                        SetError(textBoxCard, "");
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VirtualKeyboard.Show();

        }

        private void ReadCard()
        {
            System.Threading.Thread.Sleep(200);
            try
            {
                var f = File.ReadAllLines(CardReaderFileDat);
                {
                    if (f.Count() > 0)
                        textBoxUser.Text = f[0].Trim();
                    if (f.Count() > 1)
                        textBoxCard.Text = f[1].Trim();
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

        
    }
}
