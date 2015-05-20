using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITechSite
{
    public class SqlFileStreamResult : FileStreamResult
    {
        public string FileName { get; set; }

        public SqlFileStreamResult(Stream stream, string fileName, string contentType)
            : base(stream, contentType)
        {
            FileName = fileName;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            try
            {
                response.BufferOutput = false;
                response.AddHeader("Content-Length", FileStream.Length.ToString());
                if (!string.IsNullOrEmpty(FileName))
                    response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", FileName));

                base.WriteFile(response);
            }
            catch (Exception)
            {
            }
        }
    }
}