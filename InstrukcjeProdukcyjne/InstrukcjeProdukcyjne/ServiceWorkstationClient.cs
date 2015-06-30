using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne.ServiceWorkstation
{
    public class ServiceWorkstationClientEx : ServiceWorkstationClient
    {
        public static ServiceWorkstationClientEx WorkstationClient()
        {
            return WorkstationClient(Properties.Settings.Default.App.ServerDoc);
        }

        public static ServiceWorkstationClientEx WorkstationClient(string remoteAddress)
        {
            if (remoteAddress.IndexOf("http")<0)
                remoteAddress= "http://"+ remoteAddress;
            

            if (remoteAddress.LastIndexOf(".svc") < 0)
                remoteAddress = UrlPathCombine(remoteAddress, "ServiceWorkstation.svc");

            return new ServiceWorkstationClientEx("BasicHttpBinding_IServiceWorkstation", remoteAddress);

            //var x = new System.ServiceModel.WebHttpBinding( System.ServiceModel.WebHttpSecurityMode.None);
            //var adr = new EndpointAddress(remoteAddress);
            //return new ServiceWorkstationClientEx(x, adr);
            //return new ServiceWorkstationClientEx("webHttpBinding_IServiceWorkstation", remoteAddress);
        }

        public ServiceWorkstationClientEx(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }


        public ServiceWorkstationClientEx(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {

        }

        public bool IsOnLine()
        {
            
            if (this.State != System.ServiceModel.CommunicationState.Opened)
            {
                try
                {
                    this.Ping();
                    return true;
                }
                catch (Exception) {}
            }
            return false;
        }

        public static string UrlPathCombine(string path1, string path2)
        {
            path1 = path1.TrimEnd('/') + "/";
            path2 = path2.TrimStart('/');

            return Path.Combine(path1, path2)
                .Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

    }
}
