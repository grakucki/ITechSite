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
            PopulateComboTreeView(x, true);
        }

        private void PopulateComboTreeView(List<Resource> r, bool AllItems)
        {

            var col = r;
            if (!AllItems)
                col = r.Where(m => m.ModelsWorkstation.Any(n => n.idW == Workstation.Id)).ToList();

            comboTreeBox1.Nodes.Clear();

            Action<ComboTreeNodeCollection> addNodesHelper = nodes =>
            {
                foreach (var grp in col)
                {
                    ComboTreeNode parent = nodes.Add(grp.Id.ToString(), grp.Name);
                    foreach (var item in grp.Resource1)
                    {
                        parent.Nodes.Add(item.Id.ToString(), item.Name);
                    }
                }
            };

            // anonymous method delegate for transforming the above into nodes
            Action<ComboTreeBox> addNodes = ctb =>
            {
                addNodesHelper(ctb.Nodes);
                ctb.Sort();
                if (ctb.Nodes.Count > 0)
                    ctb.SelectedNode = ctb.Nodes[0];
            };


            addNodes(comboTreeBox1);

            // select node by name
            var key = ModelWorkstationInfo.idM.ToString();
            var node = comboTreeBox1.Nodes.FindName(key, StringComparison.CurrentCulture, true);
            comboTreeBox1.SelectedNode = node;
        }

        private void PopulateComboTreeView2(List<Resource> r)
        {
            // define our collection of list items
            var groupedItems = new[] { 
				new { Group = "Gases", Value = 1, Display = "Helium" }, 
				new { Group = "Gases", Value = 2, Display = "Hydrogen" },
				new { Group = "Gases", Value = 3, Display = "Oxygen" },
				new { Group = "Gases", Value = 4, Display = "Argon" },
				new { Group = "Metals", Value = 5, Display = "Iron" },
				new { Group = "Metals", Value = 6, Display = "Lithium" },
				new { Group = "Metals", Value = 7, Display = "Copper" },
				new { Group = "Metals", Value = 8, Display = "Gold" },
				new { Group = "Metals", Value = 9, Display = "Silver" },
				new { Group = "Radioactive", Value = 10, Display = "Uranium" },
				new { Group = "Radioactive", Value = 11, Display = "Plutonium" },
				new { Group = "Radioactive", Value = 12, Display = "Americium" },
				new { Group = "Radioactive", Value = 13, Display = "Radon" }
			};


            Action<ComboTreeNodeCollection> addNodesHelper = nodes =>
            {
                foreach (var grp in groupedItems.GroupBy(x => x.Group))
                {
                    ComboTreeNode parent = nodes.Add(grp.Key, grp.Key);
                    foreach (var item in grp)
                    {
                        parent.Nodes.Add(item.Value.ToString(), item.Display);
                    }
                }
            };

            // anonymous method delegate for transforming the above into nodes
            Action<ComboTreeBox> addNodes = ctb =>
            {
                addNodesHelper(ctb.Nodes);
                ctb.Sort();
                if (ctb.Nodes.Count>0)
                    ctb.SelectedNode = ctb.Nodes[0];
            };


            addNodes(comboTreeBox1);

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
                //if (nrModelu < sitech.Nazwa_Modelu().Count)
                //    nazwaModelu = sitech.Nazwa_Modelu()[nrModelu];
                

                //step = 7;

                //int i= comboBox1.FindStringExact(nazwaModelu);
                //if (i >= 0)
                //{

                //    step = 8;

                //    //textBox2.Text = nrModelu.ToString(
                //    comboBox1.SelectedIndex = i;
                //    //ModelWorkstationInfo.ModelName = nazwaModelu;
                //    step = 9;

                //    bindingSource1.EndEdit();

                //}
                //else
                //    MessageBox.Show(String.Format("Nie odnaleziono modelu o nazwie '{0}' na liście dostępnych modeli.", nazwaModelu));

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
            try
            {
                var idr = Workstation.Id;
                if (checkBox1.Checked)
                    resourceBindingSource.DataSource = Models;
                else
                {
                    var x = Models.Where(m => m.ModelsWorkstation.Any(n => n.idW == idr)).ToList();
                    resourceBindingSource.DataSource = x;
                }

                PopulateComboTreeView(Models, checkBox1.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var key = ModelWorkstationInfo.idM.ToString();
            var x = comboTreeBox1.SelectedNode;
            if (x!=null)
            {
                var s = x.Name;
                if (!string.IsNullOrEmpty(s))
                {
                    int res;
                    if (int.TryParse(s, out res))
                        ModelWorkstationInfo.idM = res;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
