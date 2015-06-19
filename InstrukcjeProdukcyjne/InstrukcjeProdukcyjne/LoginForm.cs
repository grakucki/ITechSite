using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetError(textBoxUser, "");
            SetError(textBoxCard, "");

            
            if (!string.IsNullOrEmpty(Message))
                labelMessage.Text = Message;

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
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
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
}
