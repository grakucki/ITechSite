using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    [DataContract]
    public class ITechSettings
    {
        public ITechSettings()
        {
            ApplyDefault();
        }
        [DataMember]
        public string ServerDoc { get; set; }
        [DataMember]
        public string LocalDoc { get; set; }

        [DataMember]
        public int? Stanowisko { get; set; }


        public void ApplyDefaultIfEmpty()
        {
            ApplyDefault(true);
        }


        public string ServerTestKompetencjiAddress
        {
            get
            {
                var s = ServerDoc.ToLower().Replace("/itechservice", "/Testy/test/Test");
                return s;
            }
        }

        public void ApplyDefault(bool IfEmpty)
        {
            if (!IfEmpty || String.IsNullOrEmpty(ServerDoc))
                ServerDoc = @"10.48.120.49/ITechService";
            //ServerDoc = @"www.insofter.pl/itech/ITechService";

            if (!IfEmpty || String.IsNullOrEmpty(LocalDoc))
                LocalDoc = @"c:\ProgramData\Itech\Instrukcje";

            if (!IfEmpty || (Stanowisko == null))
                Stanowisko = 0;
        }

        public void ApplyDefault()
        {
            ApplyDefault(false);
        }

        public static string GetFileConfigPath(string path)
        {
            return Path.Combine(path, "configs", "settings.xml");
        }
    }


}
