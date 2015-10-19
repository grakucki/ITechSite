using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ITechSite.Models.Repository.ItechUsersImport
{
    public static class StreamEx
    {
        public static Stream ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static StreamReader ToStreamReader(this string str)
        {
            var mem = new MemoryStream(Encoding.UTF8.GetBytes(str));
            return new StreamReader(mem);
        }
    }
}