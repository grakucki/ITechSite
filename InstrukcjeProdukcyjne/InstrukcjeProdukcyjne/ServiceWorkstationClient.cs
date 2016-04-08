using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ServiceDokument.ServiceDokumentClient DokumentClient()
        {
            var adr = this.Endpoint.Address.Uri;
            string remoteAddress = adr.ToString().Replace("/ServiceWorkstation.svc", "/ServiceDokument.svc");
            return new ServiceDokument.ServiceDokumentClient("webHttpBinding_IServiceDokument", remoteAddress);
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

        public string IsOnLineMsg = string.Empty;
        public DateTime LastOnLineConnect = DateTime.MinValue;
        public bool LastIsOnLineValue = true;

        public void IsOnLine()
        {
            if ((DateTime.Now - LastOnLineConnect) < new TimeSpan(0, 0, 10))
            {
                if (!LastIsOnLineValue)
                    throw new Exception("Brak połączenia");
                return;
            }
            
            Stopwatch stopWatch  = new Stopwatch();
            stopWatch.Start();
            try
            {
                using (var client = ServiceWorkstationClientEx.WorkstationClient())
                {
                    client.ChannelFactory.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 0, 3);
                    client.ChannelFactory.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 0, 3);
                    client.ChannelFactory.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 3);
                    client.ChannelFactory.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 0, 3);
                    var d = client.Ping();
                    LastIsOnLineValue = true;
                }

            }
            catch (Exception ex)
            {
                LastIsOnLineValue = false;
                throw ex;
            }
            TimeSpan ts = stopWatch.Elapsed;
            Debug.WriteLine("IsOnlineTime : "+ ts.ToString());
        }

        public bool IsOnLineTry()
        {
            try
            {
                IsOnLine();
                IsOnLineMsg = "Ok";
                return true;
            }
            catch (Exception ex) 
            { 
                IsOnLineMsg = ex.Message; 
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
