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
using System.Runtime.Serialization;
using System.Xml;
using InstrukcjeProdukcyjne.Properties;
using ITechInstrukcjeModel;

namespace InstrukcjeProdukcyjne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string DataDir = "Instrukcje";
        private string StanowiskaFolder = "stanowiska";
        private string ElementyFolder = "elementy";

        ITechInstrukcjeModel.ITechEntities db = new ITechInstrukcjeModel.ITechEntities();

        private enum FolderType
	    {
	         Stanowsika,
            Elementy
	    }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                db.WorkDir = Settings.Default.WorkDir;
                toolStripStatusLabel1.Text = Path.GetFullPath(db.WorkDir);
                db.ImportResource();

                ZaładujStanowiska();
                ZaładujElementy();
                OnResourceChange(0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ZaładujElementy()
        {
            var data = db.ResourceModel;
            ModelBindingSource.DataSource = data;

        }

        private void ZaładujStanowiska()
        {
            var data = db.ResourceWorkstation;
            WorkStationBindingSource.DataSource = data;
        }

        private void OnResourceChange(int NewResurceType)
        {
            Color cOn = Color.Green;
            Color cOff = Color.Orange;
            buttonWorkstation.BackColor = NewResurceType==1 ? cOn : cOff;
            buttonModel.BackColor = NewResurceType == 2 ? cOn : cOff;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // załaduj instrukcje stanowiskowe
            var x = WorkStationBindingSource.Current;
            Resource xx = (Resource )x;
            OnResourceChange(xx.Type);
            ZaładujPliki(xx);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // załaduj instrukcje Modelu
            //ZaładujPliki(FolderType.Elementy, elementyComboBox.Text);
            var x = ModelBindingSource.Current;
            Resource xx = (Resource )x;
            OnResourceChange(xx.Type);
            ZaładujPliki(xx);
        }



        private string GetFullPath(FolderType folderType, string DetalName)
        {
            string path = Path.Combine(Path.GetFullPath(DataDir));
            string folder = string.Empty;
            if (folderType == FolderType.Elementy)
                folder = ElementyFolder;
            else
                folder = StanowiskaFolder;
            path = Path.Combine(Path.GetFullPath(DataDir), folder);
            return Path.Combine(path, DetalName); 
        }

       
        //private string[] GetFiles(string folderName)
        //{
        //    string dir = Path.Combine(Path.GetFullPath(DataDir), folderName);
        //    return Directory.GetFiles(dir);
        //}

        //private List<MyFileInfo> _FileList = new List<MyFileInfo>();

        //private void ZaładujPliki(FolderType folderType, string detalName)
        //{
        //    string folderName = GetFullPath(folderType, detalName);
        //    //MessageBox.Show(GetFullPath(folderType, detalName));
        //    listView1.Items.Clear();
        //    string[] data = GetFiles(folderName);
        //    foreach (var item in data)
        //    {
        //        var d = new MyFileInfo { FileName = Path.GetFileName(item), FullFileName = item };
        //        var i=listView1.Items.Add(d.FullFileName, d.FileName, d.ExtensionIndex);
        //        i.Tag = d;
        //    }
        //}


        private void ZaładujPliki(Resource res)
        {
            listView1.Items.Clear();
            var IP = res.InformationPlan;
            foreach (var item in IP)
            {
                if (item.Dokument != null)
                {
                    var d = new MyFileInfo { FileName = item.Dokument.FileName, FullFileName = db.CreateLocalFileName(item.Dokument), Tag=item.Dokument };
                    var i = listView1.Items.Add(d.FullFileName, d.FileName, d.ExtensionIndex);
                    i.Tag = d;
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var senderList = (ListView)sender;
                var clickedItem = senderList.HitTest(e.Location).Item;
                if (clickedItem != null)
                {
                    var mfi = (MyFileInfo)clickedItem.Tag;
                    if (mfi != null)
                    {
                        if (File.Exists(mfi.FullFileName))
                        {
                            mediaViewerControl1.ShowDokument(mfi.FullFileName);
                            KomunikatLabel.Text = mfi.FullFileName;
                            //Process.Start(mfi.FullFileName);
                        }
                        
                        else
                            MessageBox.Show("Nie odnaleziono pliku." + mfi.FileName);
                    }
                    //do coś 
                }        

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


             

       
    }
}
