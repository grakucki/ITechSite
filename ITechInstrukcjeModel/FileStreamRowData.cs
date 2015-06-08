using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITechInstrukcjeModel
{
    class FileStreamRowData
    {
        public string  FilePath { get; set; }
        public byte[] Context { get; set; }
        public long Size { get; set; }
    }
}
