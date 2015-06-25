using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ITechService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceDokument" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceDokument.svc or ServiceDokument.svc.cs at the Solution Explorer and start debugging.
    public class ServiceDokument : IServiceDokument
    {

        public System.IO.Stream DownloadFile()
        {
            int width = 200;
            int height = 200;
            Bitmap bitmap = new Bitmap(width, height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, (Math.Abs(i - j) < 2) ? Color.Blue : Color.Yellow);
                }
            }
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0;
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            //WebOperationContext.Current.OutgoingResponse.ContentType= "application/octet-stream";
            WebOperationContext.Current.OutgoingResponse.Headers.Add("content-disposition", "inline; filename=" + "out.jpg");
            return ms;
        }

        public System.IO.Stream DownloadDokument(int idd)
        {
            ITechInstrukcjeModel.DBFile f = new ITechInstrukcjeModel.DBFile();

            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            //WebOperationContext.Current.OutgoingResponse.ContentType= "application/octet-stream";
            WebOperationContext.Current.OutgoingResponse.Headers.Add("content-disposition", "inline; filename=" + "out.jpg");
            return f.Get(idd);
        }
       
    }
}
