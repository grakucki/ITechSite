using ITechInstrukcjeModel;
using ItechSimatic;
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
    public partial class ModelsWorkstationEditDlg : Form
    {
        public ModelsWorkstationEditDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// lista dostępnych modeli
        /// </summary>
        public List<ITechInstrukcjeModel.Resource> Models { get; set; }

        /// <summary>
        /// przypisanie modelu do stanowiska
        /// </summary>
        public ServiceWorkstation.ModelWorkstationInfo ModelWorkstationInfo { get; set; }
        //public Workstation Workstation { get; set; }
        public Resource Workstation { get; set; }

        private void ModelsWorkstationEditDlg_Load(object sender, EventArgs e)
        {

            var idr= Workstation.Id;
            //resourceBindingSource.DataSource = Models;
            var x = Models.ToList();
            resourceBindingSource.DataSource = x;
            bindingSource1.DataSource = ModelWorkstationInfo;

            textBox1.Text = Workstation.Name;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // odczytujemy aktualny index ze sterwonika oraz model według odczytanego indexu
            int step = 0;
            try
            {
                step = 1;
                SitechSimaticDevice sitech = SitechSimaticDeviceEx.CreateFromWorkstation(Workstation.Workstation.FirstOrDefault());

                step = 2;
                if (!sitech.IsAvailable())
                {
                    MessageBox.Show("Sterownik nie jest dostępny.");
                    return;
                }
                step = 3;

                sitech.FileName = Properties.Settings.Default.App.LocalDoc + @"\simatic.xml";
                step = 4;
                sitech.Fill(false);
                step = 5;

                int nrModelu = sitech.NrModelu;
                ModelWorkstationInfo.SterownikIndex = nrModelu.ToString();
                step = 6;

                string nazwaModelu = string.Empty;
                if (nrModelu < sitech.Nazwa_Modelu().Count)
                    nazwaModelu = sitech.Nazwa_Modelu()[nrModelu];
                

                step = 7;

                int i= comboBox1.FindStringExact(nazwaModelu);
                if (i >= 0)
                {

                    step = 8;

                    //textBox2.Text = nrModelu.ToString(
                    comboBox1.SelectedIndex = i;
                    //ModelWorkstationInfo.ModelName = nazwaModelu;
                    step = 9;

                    bindingSource1.EndEdit();

                }
                else
                    MessageBox.Show(String.Format("Nie odnaleziono modelu o nazwie '{0}' na liście dostępnych modeli.", nazwaModelu));

            }

            catch (Exception ex)
            {
                MessageBox.Show(step + ":"+ ex.Message);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var idr = Workstation.Id;
            if (checkBox1.Checked)
                resourceBindingSource.DataSource = Models;
            else
            {
                var x = Models.Where(m => m.ModelsWorkstation.Any(n => n.idW == idr)).ToList();
                resourceBindingSource.DataSource = x;
            }
                
        }
    }
}
