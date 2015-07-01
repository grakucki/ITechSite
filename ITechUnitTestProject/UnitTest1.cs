using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

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
    }
}
