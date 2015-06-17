using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    public class MyFileInfo
    {
        public string FileName { get; set; }
        public string FullFileName { get; set; }
        public object Tag { get; set; }
        
        public string Extension
        {
            get
            {
                return Path.GetExtension(FullFileName);
            }
        }
        
        public int ExtensionIndex
        {
            get
            {
                string[] extab =  new string[] {".txt", ".mp4",".avi", ".jpg", ".pdf",".wmv"};
                string ex = Path.GetExtension(FullFileName).ToLower();

                return Math.Max(0, Array.IndexOf(extab, ex));
                //
            }
        }
    }
}
