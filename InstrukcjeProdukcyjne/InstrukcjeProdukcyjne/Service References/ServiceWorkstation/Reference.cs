﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InstrukcjeProdukcyjne.ServiceWorkstation {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DokumentIdentity", Namespace="http://schemas.datacontract.org/2004/07/ITechService")]
    [System.SerializableAttribute()]
    public partial class DokumentIdentity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastWriteTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocalFileNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long SizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodeName {
            get {
                return this.CodeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeNameField, value) != true)) {
                    this.CodeNameField = value;
                    this.RaisePropertyChanged("CodeName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastWriteTime {
            get {
                return this.LastWriteTimeField;
            }
            set {
                if ((this.LastWriteTimeField.Equals(value) != true)) {
                    this.LastWriteTimeField = value;
                    this.RaisePropertyChanged("LastWriteTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LocalFileName {
            get {
                return this.LocalFileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LocalFileNameField, value) != true)) {
                    this.LocalFileNameField = value;
                    this.RaisePropertyChanged("LocalFileName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Size {
            get {
                return this.SizeField;
            }
            set {
                if ((this.SizeField.Equals(value) != true)) {
                    this.SizeField = value;
                    this.RaisePropertyChanged("Size");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ModelWorkstationInfo", Namespace="http://schemas.datacontract.org/2004/07/ITechService")]
    [System.SerializableAttribute()]
    public partial class ModelWorkstationInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModelNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SterownikIndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WorkstationNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> idWField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ModelName {
            get {
                return this.ModelNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelNameField, value) != true)) {
                    this.ModelNameField = value;
                    this.RaisePropertyChanged("ModelName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SterownikIndex {
            get {
                return this.SterownikIndexField;
            }
            set {
                if ((object.ReferenceEquals(this.SterownikIndexField, value) != true)) {
                    this.SterownikIndexField = value;
                    this.RaisePropertyChanged("SterownikIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WorkstationName {
            get {
                return this.WorkstationNameField;
            }
            set {
                if ((object.ReferenceEquals(this.WorkstationNameField, value) != true)) {
                    this.WorkstationNameField = value;
                    this.RaisePropertyChanged("WorkstationName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idM {
            get {
                return this.idMField;
            }
            set {
                if ((this.idMField.Equals(value) != true)) {
                    this.idMField = value;
                    this.RaisePropertyChanged("idM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idW {
            get {
                return this.idWField;
            }
            set {
                if ((this.idWField.Equals(value) != true)) {
                    this.idWField = value;
                    this.RaisePropertyChanged("idW");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetNewsUser", ReplyAction="http://tempuri.org/IServiceWorkstation/GetNewsUserResponse")]
        ITechInstrukcjeModel.News GetNewsUser(int idR, int IUserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetNewsUser", ReplyAction="http://tempuri.org/IServiceWorkstation/GetNewsUserResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.News> GetNewsUserAsync(int idR, int IUserId);
        
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
        ITechInstrukcjeModel.Resource[] GetInformationPlainsList(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetInformationPlainsList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetInformationPlainsListResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource[]> GetInformationPlainsListAsync(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetDokumentsList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetDokumentsListResponse")]
        InstrukcjeProdukcyjne.ServiceWorkstation.DokumentIdentity[] GetDokumentsList(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetDokumentsList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetDokumentsListResponse")]
        System.Threading.Tasks.Task<InstrukcjeProdukcyjne.ServiceWorkstation.DokumentIdentity[]> GetDokumentsListAsync(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetITechUserList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetITechUserListResponse")]
        ITechInstrukcjeModel.ItechUsers[] GetITechUserList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetITechUserList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetITechUserListResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.ItechUsers[]> GetITechUserListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UpdateWorkstation", ReplyAction="http://tempuri.org/IServiceWorkstation/UpdateWorkstationResponse")]
        void UpdateWorkstation(ITechInstrukcjeModel.Workstation idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UpdateWorkstation", ReplyAction="http://tempuri.org/IServiceWorkstation/UpdateWorkstationResponse")]
        System.Threading.Tasks.Task UpdateWorkstationAsync(ITechInstrukcjeModel.Workstation idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetModelWorkstationInfo", ReplyAction="http://tempuri.org/IServiceWorkstation/GetModelWorkstationInfoResponse")]
        InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo[] GetModelWorkstationInfo(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetModelWorkstationInfo", ReplyAction="http://tempuri.org/IServiceWorkstation/GetModelWorkstationInfoResponse")]
        System.Threading.Tasks.Task<InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo[]> GetModelWorkstationInfoAsync(int idR);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetModels", ReplyAction="http://tempuri.org/IServiceWorkstation/GetModelsResponse")]
        ITechInstrukcjeModel.Resource[] GetModels();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetModels", ReplyAction="http://tempuri.org/IServiceWorkstation/GetModelsResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource[]> GetModelsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UpdateModelWorkstationInfo", ReplyAction="http://tempuri.org/IServiceWorkstation/UpdateModelWorkstationInfoResponse")]
        void UpdateModelWorkstationInfo(InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo modelWorkstationInfo, bool Remove);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UpdateModelWorkstationInfo", ReplyAction="http://tempuri.org/IServiceWorkstation/UpdateModelWorkstationInfoResponse")]
        System.Threading.Tasks.Task UpdateModelWorkstationInfoAsync(InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo modelWorkstationInfo, bool Remove);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/RunTestKompetencji", ReplyAction="http://tempuri.org/IServiceWorkstation/RunTestKompetencjiResponse")]
        bool RunTestKompetencji(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/RunTestKompetencji", ReplyAction="http://tempuri.org/IServiceWorkstation/RunTestKompetencjiResponse")]
        System.Threading.Tasks.Task<bool> RunTestKompetencjiAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UpdateTestKompetencji", ReplyAction="http://tempuri.org/IServiceWorkstation/UpdateTestKompetencjiResponse")]
        void UpdateTestKompetencji(int UserId, System.Nullable<int> TestResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UpdateTestKompetencji", ReplyAction="http://tempuri.org/IServiceWorkstation/UpdateTestKompetencjiResponse")]
        System.Threading.Tasks.Task UpdateTestKompetencjiAsync(int UserId, System.Nullable<int> TestResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetUserReadDokList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetUserReadDokListResponse")]
        ITechInstrukcjeModel.ItechUsersDokumentRead[] GetUserReadDokList(int IUserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetUserReadDokList", ReplyAction="http://tempuri.org/IServiceWorkstation/GetUserReadDokListResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.ItechUsersDokumentRead[]> GetUserReadDokListAsync(int IUserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UserReadDok", ReplyAction="http://tempuri.org/IServiceWorkstation/UserReadDokResponse")]
        void UserReadDok(int IUserId, int DokId, int DokVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UserReadDok", ReplyAction="http://tempuri.org/IServiceWorkstation/UserReadDokResponse")]
        System.Threading.Tasks.Task UserReadDokAsync(int IUserId, int DokId, int DokVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UserReadMessage", ReplyAction="http://tempuri.org/IServiceWorkstation/UserReadMessageResponse")]
        void UserReadMessage(int IUserId, int NewsItemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/UserReadMessage", ReplyAction="http://tempuri.org/IServiceWorkstation/UserReadMessageResponse")]
        System.Threading.Tasks.Task UserReadMessageAsync(int IUserId, int NewsItemId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetLoginUser", ReplyAction="http://tempuri.org/IServiceWorkstation/GetLoginUserResponse")]
        ITechInstrukcjeModel.ItechUsers GetLoginUser(string cardno, string passowrd, bool OnlyCardNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceWorkstation/GetLoginUser", ReplyAction="http://tempuri.org/IServiceWorkstation/GetLoginUserResponse")]
        System.Threading.Tasks.Task<ITechInstrukcjeModel.ItechUsers> GetLoginUserAsync(string cardno, string passowrd, bool OnlyCardNo);
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
        
        public ITechInstrukcjeModel.News GetNewsUser(int idR, int IUserId) {
            return base.Channel.GetNewsUser(idR, IUserId);
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.News> GetNewsUserAsync(int idR, int IUserId) {
            return base.Channel.GetNewsUserAsync(idR, IUserId);
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
        
        public ITechInstrukcjeModel.Resource[] GetInformationPlainsList(int idR) {
            return base.Channel.GetInformationPlainsList(idR);
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource[]> GetInformationPlainsListAsync(int idR) {
            return base.Channel.GetInformationPlainsListAsync(idR);
        }
        
        public InstrukcjeProdukcyjne.ServiceWorkstation.DokumentIdentity[] GetDokumentsList(int idR) {
            return base.Channel.GetDokumentsList(idR);
        }
        
        public System.Threading.Tasks.Task<InstrukcjeProdukcyjne.ServiceWorkstation.DokumentIdentity[]> GetDokumentsListAsync(int idR) {
            return base.Channel.GetDokumentsListAsync(idR);
        }
        
        public ITechInstrukcjeModel.ItechUsers[] GetITechUserList() {
            return base.Channel.GetITechUserList();
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.ItechUsers[]> GetITechUserListAsync() {
            return base.Channel.GetITechUserListAsync();
        }
        
        public void UpdateWorkstation(ITechInstrukcjeModel.Workstation idR) {
            base.Channel.UpdateWorkstation(idR);
        }
        
        public System.Threading.Tasks.Task UpdateWorkstationAsync(ITechInstrukcjeModel.Workstation idR) {
            return base.Channel.UpdateWorkstationAsync(idR);
        }
        
        public InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo[] GetModelWorkstationInfo(int idR) {
            return base.Channel.GetModelWorkstationInfo(idR);
        }
        
        public System.Threading.Tasks.Task<InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo[]> GetModelWorkstationInfoAsync(int idR) {
            return base.Channel.GetModelWorkstationInfoAsync(idR);
        }
        
        public ITechInstrukcjeModel.Resource[] GetModels() {
            return base.Channel.GetModels();
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.Resource[]> GetModelsAsync() {
            return base.Channel.GetModelsAsync();
        }
        
        public void UpdateModelWorkstationInfo(InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo modelWorkstationInfo, bool Remove) {
            base.Channel.UpdateModelWorkstationInfo(modelWorkstationInfo, Remove);
        }
        
        public System.Threading.Tasks.Task UpdateModelWorkstationInfoAsync(InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo modelWorkstationInfo, bool Remove) {
            return base.Channel.UpdateModelWorkstationInfoAsync(modelWorkstationInfo, Remove);
        }
        
        public bool RunTestKompetencji(int UserId) {
            return base.Channel.RunTestKompetencji(UserId);
        }
        
        public System.Threading.Tasks.Task<bool> RunTestKompetencjiAsync(int UserId) {
            return base.Channel.RunTestKompetencjiAsync(UserId);
        }
        
        public void UpdateTestKompetencji(int UserId, System.Nullable<int> TestResult) {
            base.Channel.UpdateTestKompetencji(UserId, TestResult);
        }
        
        public System.Threading.Tasks.Task UpdateTestKompetencjiAsync(int UserId, System.Nullable<int> TestResult) {
            return base.Channel.UpdateTestKompetencjiAsync(UserId, TestResult);
        }
        
        public ITechInstrukcjeModel.ItechUsersDokumentRead[] GetUserReadDokList(int IUserId) {
            return base.Channel.GetUserReadDokList(IUserId);
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.ItechUsersDokumentRead[]> GetUserReadDokListAsync(int IUserId) {
            return base.Channel.GetUserReadDokListAsync(IUserId);
        }
        
        public void UserReadDok(int IUserId, int DokId, int DokVersion) {
            base.Channel.UserReadDok(IUserId, DokId, DokVersion);
        }
        
        public System.Threading.Tasks.Task UserReadDokAsync(int IUserId, int DokId, int DokVersion) {
            return base.Channel.UserReadDokAsync(IUserId, DokId, DokVersion);
        }
        
        public void UserReadMessage(int IUserId, int NewsItemId) {
            base.Channel.UserReadMessage(IUserId, NewsItemId);
        }
        
        public System.Threading.Tasks.Task UserReadMessageAsync(int IUserId, int NewsItemId) {
            return base.Channel.UserReadMessageAsync(IUserId, NewsItemId);
        }
        
        public ITechInstrukcjeModel.ItechUsers GetLoginUser(string cardno, string passowrd, bool OnlyCardNo) {
            return base.Channel.GetLoginUser(cardno, passowrd, OnlyCardNo);
        }
        
        public System.Threading.Tasks.Task<ITechInstrukcjeModel.ItechUsers> GetLoginUserAsync(string cardno, string passowrd, bool OnlyCardNo) {
            return base.Channel.GetLoginUserAsync(cardno, passowrd, OnlyCardNo);
        }
    }
}
