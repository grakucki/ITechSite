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
    public partial class SettingsDlg : Form
    {
        public SettingsDlg()
        {
            InitializeComponent();
        }

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
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString();
            var file = Path.Combine(path, "setings.xml");
            label1.Text = file;
            if (File.Exists(file))
            {
                textBox1.Text= File.ReadAllText(file);
            }

        }

        private void SaveSettings()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString();

            var s= textBox1.Text;
            File.WriteAllText(Path.Combine(path, "setings.xml"), s);
        }

    }
}
