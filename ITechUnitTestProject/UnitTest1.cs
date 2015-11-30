using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace ITechUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
       
        
        public string Size2(long? i)
        {
                if (!i.HasValue)
                    return "-";
                var units = new[] { "B", "KB", "MB", "GB", "TB" };
                var index = 0;
                double size = i.Value;
                while (size > 1024 && index + 1 < units.Length)
                {
                    size /= 1024;
                    index++;
                }
                var s =string.Format("{0:N2} {1}", size, units[index]);
                return s;
        }

        [TestMethod]
        public void Dokument_Size2_test()
        {
            // arrange
            var d = new ITechSite.Models.Dokument();
            //d.Size = 7;
           // Debug.WriteLine(d.Size2);
            long? x = 7;
            StringAssert.Contains(Size2(x), "7,00 B");
            StringAssert.Contains(Size2(x * 1024), "7,00 KB");
            StringAssert.Contains(Size2(x * 1024 + 200), "7,20 KB");
            StringAssert.Contains(Size2(x * 1024 * 1024), "7,00 MB");
            StringAssert.Contains(Size2(x * 1024 * 1024 * 1024), "7,00 GB");
        }


        [TestMethod]
        public void Dokument_List_test()
        {
            var d = new ITechService.ServiceWorkstation();
            //d.GetDokumentsList(10);
        }

        [TestMethod]
        public void Dokument_DownloadDokument()
        {
            var d = new ITechService.ServiceDokument();
            var FileServer = d.DownloadDokument2(26);
            using (var fileOut = File.Create(@"d:\26.mp4"))
            {
                FileServer.CopyTo(fileOut);
            }

        }

        [TestMethod]
        public void Dokument_DownloadServiceDokument()
        {
            var d = new ServiceDokument.ServiceDokumentClient("webHttpBinding_IServiceDokument");
            string filename = @"d:\2014-12-15 161703.jpeg";
            filename = @"d:\26.mp4";
            var FileServer = d.DownloadDokument3(filename);
            using (var fileOut = File.Create(filename.Replace(".","_l.")))
            {
                FileServer.CopyTo(fileOut);
            }

        }


        [TestMethod]
        public void Testlast()
        {
            string i = "alamakota";
            string s= i.Substring(i.Length - 6, 6);
            Assert.AreEqual(s,"makota");
        }
    }
}
