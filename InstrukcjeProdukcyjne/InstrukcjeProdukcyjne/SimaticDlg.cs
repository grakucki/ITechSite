using ITechInstrukcjeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrukcjeProdukcyjne
{
    public partial class SimaticDlg : Form
    {
        public SimaticDlg()
        {
            InitializeComponent();
        }

        public Workstation Workstation { get; set; }
        private void SimaticDlg_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Simatic.AvalibleSimaticCpuType);
            bindingSource1.DataSource = Workstation;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            var o = bindingSource1.Current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                ItechSimatic.SitechSimaticDevice sitech = new ItechSimatic.SitechSimaticDevice(GetSimaticType(), GetIpDevice(), GetDb(), Workstation.AllowIp);
                string s;
                if (sitech.IsAvailable())
                    s = "Połączenia poprawne - sterownik: " + sitech.IdSterownika;
                else
                    s = "Brak połączenia!";

                if (!sitech.AllowWrite())
                    s += Environment.NewLine + "Zakaz zapisu. (Zezwolenie wystawiono dla :'" + Workstation.AllowIp + "')";
                else
                    s += Environment.NewLine + "Zapis możliwy.";


                MessageBox.Show(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private bool AllowWrite(string p)
        //{
        //    IPAddress[] localIp = Dns.GetHostAddresses(Dns.GetHostName());
        //    var b = localIp.Any(m => m.ToString() == p);
        //    return b;
        //}





        private ushort GetDb()
        {
            if (Workstation.Setrownik_DB.HasValue)
                return (ushort)Workstation.Setrownik_DB.Value;
           return 0;
        }

        private string GetIpDevice()
        {
               return Workstation.Sterownik_Ip;

        }

        private S7.Net.CpuType GetSimaticType()
        {
            S7.Net.CpuType ret = S7.Net.CpuType.S7300;
            try
            {
                   ret = (S7.Net.CpuType)Enum.Parse(typeof(S7.Net.CpuType), Workstation.Sterownik_Model);
            }
            catch (Exception)
            {
                
            }
            return ret;
        }
    }
}
