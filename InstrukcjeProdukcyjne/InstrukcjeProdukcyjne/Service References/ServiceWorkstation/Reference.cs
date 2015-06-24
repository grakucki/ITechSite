﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InstrukcjeProdukcyjne.ServiceWorkstation {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceWorkstation.IServiceWorkstation")]
    public interface IServiceWorkstation {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/Ping", ReplyAction="http://tempuri.org/IServiceWorkstation/PingResponse")]
        System.DateTime Ping();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/Ping", ReplyAction="http://tempuri.org/IServiceWorkstation/PingResponse")]
        System.Threading.Tasks.Task<System.DateTime> PingAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/TestConnection", ReplyAction="http://tempuri.org/IServiceWorkstation/TestConnectionResponse")]
        string TestConnection(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/TestConnection", ReplyAction="http://tempuri.org/IServiceWorkstation/TestConnectionResponse")]
        System.Threading.Tasks.Task<string> TestConnectionAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetNews", ReplyAction="http://tempuri.org/IServiceWorkstation/GetNewsResponse")]
        ITechInstrukcjeModel.News GetNews(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetNews", ReplyAction="http://tempuri.org/IServiceWorkstation/GetNewsResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.News> GetNewsAsync(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetSimaticCpuType", ReplyAction="http://tempuri.org/IServiceWorkstation/GetSimaticCpuTypeResponse")]
        string[] GetSimaticCpuType();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetSimaticCpuType", ReplyAction="http://tempuri.org/IServiceWorkstation/GetSimaticCpuTypeResponse")]
        System.Threading.Tasks.Task<string[]> GetSimaticCpuTypeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetWorkstationList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetWorkstationListResponse")]
        ITechInstrukcjeModel.Resource[] GetWorkstationList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetWorkstationList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetWorkstationListResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource[]> GetWorkstationListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetInformationPlain", ReplyAction="http://tempuri.org/IServiceWorkstation/GetInformationPlainResponse")]
        ITechInstrukcjeModel.Resource GetInformationPlain(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetInformationPlain", ReplyAction="http://tempuri.org/IServiceWorkstation/GetInformationPlainResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource> GetInformationPlainAsync(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetInformationPlainsList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetInformationPlainsListResponse")]
        ITechInstrukcjeModel.Resource[] GetInformationPlainsList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetInformationPlainsList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetInformationPlainsListResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource[]> GetInformationPlainsListAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceWorkstationChannel : InstrukcjeProdukcyjne.ServiceWorkstation.IServiceWorkstation, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceWorkstationClient : System.ServiceModel.ClientBase<InstrukcjeProdukcyjne.ServiceWorkstation.IServiceWorkstation>, InstrukcjeProdukcyjne.ServiceWorkstation.IServiceWorkstation {
        
        public ServiceWorkstationClient() {
        }
        
        public ServiceWorkstationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceWorkstationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWorkstationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceWorkstationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.DateTime Ping() {
            return base.Channel.Ping();
        }
        
        public System.Threading.Tasks.Task<System.DateTime> PingAsync() {
            return base.Channel.PingAsync();
        }
        
        public string TestConnection(int value) {
            return base.Channel.TestConnection(value);
        }
        
        public System.Threading.Tasks.Task<string> TestConnectionAsync(int value) {
            return base.Channel.TestConnectionAsync(value);
        }
        
        public ITechInstrukcjeModel.News GetNews(int idR) {
            return base.Channel.GetNews(idR);
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.News> GetNewsAsync(int idR) {
            return base.Channel.GetNewsAsync(idR);
        }
        
        public string[] GetSimaticCpuType() {
            return base.Channel.GetSimaticCpuType();
        }
        
        public System.Threading.Tasks.Task<string[]> GetSimaticCpuTypeAsync() {
            return base.Channel.GetSimaticCpuTypeAsync();
        }
        
        public ITechInstrukcjeModel.Resource[] GetWorkstationList() {
            return base.Channel.GetWorkstationList();
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource[]> GetWorkstationListAsync() {
            return base.Channel.GetWorkstationListAsync();
        }
        
        public ITechInstrukcjeModel.Resource GetInformationPlain(int idR) {
            return base.Channel.GetInformationPlain(idR);
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource> GetInformationPlainAsync(int idR) {
            return base.Channel.GetInformationPlainAsync(idR);
        }
        
        public ITechInstrukcjeModel.Resource[] GetInformationPlainsList() {
            return base.Channel.GetInformationPlainsList();
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource[]> GetInformationPlainsListAsync() {
            return base.Channel.GetInformationPlainsListAsync();
        }
    }
}
