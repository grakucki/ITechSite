using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ITechService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceDokument" in both code and config file together.
    [ServiceContract]
    public interface IServiceDokument
    {

        [OperationContract]
        //[WebGet(UriTemplate = "DownloadFile")]
        [WebInvoke(Method = "POST", UriTemplate = "DownloadFile", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
        Stream DownloadFile();


        [OperationContract]
        //[WebGet(UriTemplate = "DownloadFile")]
        [WebInvoke(Method = "POST", UriTemplate = "DownloadDokument", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
        System.IO.Stream DownloadDokument(int idd);

        [OperationContract]
        System.IO.Stream DownloadDokument2(int idd);

        [OperationContract]
        System.IO.Stream DownloadDokument3(string filename);


    }
}
