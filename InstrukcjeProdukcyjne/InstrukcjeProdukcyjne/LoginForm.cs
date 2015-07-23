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
            
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                User = new SitechUser { UserName = "Aleksander Kowalski", NrKarty = "17457458"};
            }
        }

      

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
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
            try
            {
                System.Threading.Thread.Sleep(200);
                var f = File.ReadAllLines(CardReaderFileDat);
                {
                    label2.Text= string.Join(",", f);
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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
