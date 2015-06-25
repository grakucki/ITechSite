using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Serialization;

using System.Data.Entity;
using System.Net;
using System.Data.Entity.Validation;
using System.IO;
using ItechGeneratorInstrukcji.Properties;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ItechGeneratorInstrukcji
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

              


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new ITechInstrukcjeModel.ITechEntities();
                db.WorkDir=Settings.Default.WorkDir;
                db.ExportResources(null);
                db.ExportDokuments();


                MessageBox.Show("Zapis ok " + db.WorkDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         ITechInstrukcjeModel.ITechEntities db = new ITechInstrukcjeModel.ITechEntities();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var r = db.ImportResource(null);
                resourceBindingSource.DataSource = r;
                informationPlanBindingSource.DataSource = r.FirstOrDefault().InformationPlan;


                MessageBox.Show("ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ITechInstrukcjeModel.InformationPlan Dok = (ITechInstrukcjeModel.InformationPlan)informationPlanBindingSource.Current;
            MessageBox.Show(db.GetFileDocName(Dok.IdD));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db.WorkDir = Settings.Default.WorkDir;
        }
    }
}
