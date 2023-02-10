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
        public string CardReaderFileDat { get; set; }


        [DataMember]
        public int? Stanowisko { get; set; }

        [DataMember]
        public bool? PozwalajNaBlokowanieStanowiska { get; set; }

        
        public void ApplyDefaultIfEmpty()
        {
            ApplyDefault(true);
        }


        public string ServerTestKompetencjiAddress
        {
            get
            {
                var testuri = "";
                if (ServerDoc.ToLower().IndexOf("/itechservice") >= 0)
                    testuri = ServerDoc.ToLower().Replace("/itechservice", "/Testy/test/Test");
                else
                    testuri = ServerDoc.ToLower() + "/Testy/test/Test";
                testuri = testuri.Replace("53854", "49429");
                return testuri;
            }
        }

        public void ApplyDefault(bool IfEmpty)
        {
            if (!IfEmpty || String.IsNullOrEmpty(ServerDoc))
                ServerDoc = @"10.28.61.82/ITechService";
            //ServerDoc = @"10.48.120.49/ITechService";
            //ServerDoc = @"www.insofter.pl/itech/ITechService";

            if (!IfEmpty || String.IsNullOrEmpty(LocalDoc))
                LocalDoc = @"c:\ProgramData\Itech\Instrukcje";

            if (!IfEmpty || String.IsNullOrEmpty(CardReaderFileDat))
                CardReaderFileDat = @"C:\Programs\ReaderControl\interfaces\reader1.dat";

            if (!IfEmpty || (Stanowisko == null))
                Stanowisko = 0;

            if (!IfEmpty || (PozwalajNaBlokowanieStanowiska == null))
                PozwalajNaBlokowanieStanowiska = false;
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
