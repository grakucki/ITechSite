using ITechInstrukcjeModel;
using ItechSimatic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    public class SitechSimaticDeviceEx
    {

        private static S7.Net.CpuType GetSimaticType(string type)
        {
            S7.Net.CpuType ret = S7.Net.CpuType.S7300;
            try
            {
                ret = (S7.Net.CpuType)Enum.Parse(typeof(S7.Net.CpuType), type);
            }
            catch (Exception)
            {

            }
            return ret;
        }
        public static SitechSimaticDevice CreateFromWorkstation(Workstation w)
        {
            ushort db = 0;
            if (w.Setrownik_DB.HasValue)
                db = (ushort) w.Setrownik_DB.Value;

            var d = new SitechSimaticDevice(GetSimaticType(w.Sterownik_Model), w.Sterownik_Ip, db, w.AllowIp);
            d.FileName = Path.Combine( Properties.Settings.Default.App.LocalDoc ,@"simatic.xml");
            return d;
		}
    }
}
