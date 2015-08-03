using ITechInstrukcjeModel;
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
        public Workstation Workstation { get; set; }

        private void ModelsWorkstationEditDlg_Load(object sender, EventArgs e)
        {
            resourceBindingSource.DataSource = Models;
            bindingSource1.DataSource = ModelWorkstationInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // odczytujemy aktualny index ze sterwonika oraz model według odytczaneg indexu
            try
            {
                ItechSimatic.SitechSimaticDevice sitech = new ItechSimatic.SitechSimaticDevice(
                   (S7.Net.CpuType)Enum.Parse(typeof(S7.Net.CpuType),  Workstation.Sterownik_Model), 
                    Workstation.Sterownik_Ip, 
                    (ushort) Workstation.Setrownik_DB.GetValueOrDefault(22),
                    Workstation.AllowIp
                    );

                if (!sitech.IsAvailable())
                {
                    MessageBox.Show("Sterownik nie jest dostępny.");
                    return;
                }
                sitech.FileName = Properties.Settings.Default.App.LocalDoc + @"\simatic.xml";
                sitech.Fill();
                int nrModelu = sitech.NrModelu;
                string nazwaModelu = string.Empty;
                if (nrModelu < sitech.Nazwa_Modelu().Count)
                    nazwaModelu = sitech.Nazwa_Modelu()[nrModelu];

                ModelWorkstationInfo.SterownikIndex = nrModelu.ToString();

                int i= comboBox1.FindStringExact(nazwaModelu);
                if (i >= 0)
                {
                    
                    
                    //textBox2.Text = nrModelu.ToString(
                    comboBox1.SelectedIndex = i;
                    //ModelWorkstationInfo.ModelName = nazwaModelu;
                    bindingSource1.EndEdit();

                }
                else
                    MessageBox.Show(String.Format("Nie odnaleziono modelu o nazwie '{0}' na liście dostępnych modeli.", nazwaModelu));

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
