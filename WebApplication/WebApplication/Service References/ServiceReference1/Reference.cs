﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataBaseEntry", Namespace="http://schemas.datacontract.org/2004/07/AFKHostedService")]
    [System.SerializableAttribute()]
    public partial class DataBaseEntry : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AutomaticLockField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeviceIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.TimeSpan ETAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EventTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool RemoteAccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeOfEventField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIDField;
        
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
        public bool AutomaticLock {
            get {
                return this.AutomaticLockField;
            }
            set {
                if ((this.AutomaticLockField.Equals(value) != true)) {
                    this.AutomaticLockField = value;
                    this.RaisePropertyChanged("AutomaticLock");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeviceID {
            get {
                return this.DeviceIDField;
            }
            set {
                if ((object.ReferenceEquals(this.DeviceIDField, value) != true)) {
                    this.DeviceIDField = value;
                    this.RaisePropertyChanged("DeviceID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan ETA {
            get {
                return this.ETAField;
            }
            set {
                if ((this.ETAField.Equals(value) != true)) {
                    this.ETAField = value;
                    this.RaisePropertyChanged("ETA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EventType {
            get {
                return this.EventTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.EventTypeField, value) != true)) {
                    this.EventTypeField = value;
                    this.RaisePropertyChanged("EventType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool RemoteAccess {
            get {
                return this.RemoteAccessField;
            }
            set {
                if ((this.RemoteAccessField.Equals(value) != true)) {
                    this.RemoteAccessField = value;
                    this.RaisePropertyChanged("RemoteAccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimeOfEvent {
            get {
                return this.TimeOfEventField;
            }
            set {
                if ((this.TimeOfEventField.Equals(value) != true)) {
                    this.TimeOfEventField = value;
                    this.RaisePropertyChanged("TimeOfEvent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserID {
            get {
                return this.UserIDField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIDField, value) != true)) {
                    this.UserIDField = value;
                    this.RaisePropertyChanged("UserID");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/AFKHostedService")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Device", Namespace="http://schemas.datacontract.org/2004/07/AFKHostedService")]
    [System.SerializableAttribute()]
    public partial class Device : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeviceIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeviceNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool VMField;
        
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
        public string DeviceID {
            get {
                return this.DeviceIDField;
            }
            set {
                if ((object.ReferenceEquals(this.DeviceIDField, value) != true)) {
                    this.DeviceIDField = value;
                    this.RaisePropertyChanged("DeviceID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeviceName {
            get {
                return this.DeviceNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DeviceNameField, value) != true)) {
                    this.DeviceNameField = value;
                    this.RaisePropertyChanged("DeviceName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserID {
            get {
                return this.UserIDField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIDField, value) != true)) {
                    this.UserIDField = value;
                    this.RaisePropertyChanged("UserID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool VM {
            get {
                return this.VMField;
            }
            set {
                if ((this.VMField.Equals(value) != true)) {
                    this.VMField = value;
                    this.RaisePropertyChanged("VM");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/AFKHostedService")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
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
        public string UserID {
            get {
                return this.UserIDField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIDField, value) != true)) {
                    this.UserIDField = value;
                    this.RaisePropertyChanged("UserID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService", CallbackContract=typeof(WebApplication.ServiceReference1.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllEntries", ReplyAction="http://tempuri.org/IService/GetAllEntriesResponse")]
        System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry> GetAllEntries();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllEntries", ReplyAction="http://tempuri.org/IService/GetAllEntriesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry>> GetAllEntriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesOfUser", ReplyAction="http://tempuri.org/IService/GetEntriesOfUserResponse")]
        System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry> GetEntriesOfUser(string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesOfUser", ReplyAction="http://tempuri.org/IService/GetEntriesOfUserResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry>> GetEntriesOfUserAsync(string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesBetween", ReplyAction="http://tempuri.org/IService/GetEntriesBetweenResponse")]
        System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry> GetEntriesBetween(System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesBetween", ReplyAction="http://tempuri.org/IService/GetEntriesBetweenResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry>> GetEntriesBetweenAsync(System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesBetweenForUser", ReplyAction="http://tempuri.org/IService/GetEntriesBetweenForUserResponse")]
        System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry> GetEntriesBetweenForUser(string UserID, System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesBetweenForUser", ReplyAction="http://tempuri.org/IService/GetEntriesBetweenForUserResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry>> GetEntriesBetweenForUserAsync(string UserID, System.DateTime start, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemainingTime", ReplyAction="http://tempuri.org/IService/RemainingTimeResponse")]
        System.TimeSpan RemainingTime(WebApplication.ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemainingTime", ReplyAction="http://tempuri.org/IService/RemainingTimeResponse")]
        System.Threading.Tasks.Task<System.TimeSpan> RemainingTimeAsync(WebApplication.ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesForAlice", ReplyAction="http://tempuri.org/IService/GetEntriesForAliceResponse")]
        System.Collections.Generic.List<WebApplication.ServiceReference1.Employee> GetEntriesForAlice();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesForAlice", ReplyAction="http://tempuri.org/IService/GetEntriesForAliceResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.Employee>> GetEntriesForAliceAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EntryOutput", ReplyAction="http://tempuri.org/IService/EntryOutputResponse")]
        string EntryOutput(WebApplication.ServiceReference1.DataBaseEntry str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EntryOutput", ReplyAction="http://tempuri.org/IService/EntryOutputResponse")]
        System.Threading.Tasks.Task<string> EntryOutputAsync(WebApplication.ServiceReference1.DataBaseEntry str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddEntry", ReplyAction="http://tempuri.org/IService/AddEntryResponse")]
        bool AddEntry(WebApplication.ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddEntry", ReplyAction="http://tempuri.org/IService/AddEntryResponse")]
        System.Threading.Tasks.Task<bool> AddEntryAsync(WebApplication.ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddHistoricalLoggingEntry", ReplyAction="http://tempuri.org/IService/AddHistoricalLoggingEntryResponse")]
        bool AddHistoricalLoggingEntry(WebApplication.ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddHistoricalLoggingEntry", ReplyAction="http://tempuri.org/IService/AddHistoricalLoggingEntryResponse")]
        System.Threading.Tasks.Task<bool> AddHistoricalLoggingEntryAsync(WebApplication.ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddDevice", ReplyAction="http://tempuri.org/IService/AddDeviceResponse")]
        bool AddDevice(WebApplication.ServiceReference1.Device device);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddDevice", ReplyAction="http://tempuri.org/IService/AddDeviceResponse")]
        System.Threading.Tasks.Task<bool> AddDeviceAsync(WebApplication.ServiceReference1.Device device);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddUser", ReplyAction="http://tempuri.org/IService/AddUserResponse")]
        bool AddUser(WebApplication.ServiceReference1.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddUser", ReplyAction="http://tempuri.org/IService/AddUserResponse")]
        System.Threading.Tasks.Task<bool> AddUserAsync(WebApplication.ServiceReference1.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DBTest", ReplyAction="http://tempuri.org/IService/DBTestResponse")]
        string DBTest();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DBTest", ReplyAction="http://tempuri.org/IService/DBTestResponse")]
        System.Threading.Tasks.Task<string> DBTestAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendResult", ReplyAction="http://tempuri.org/IService/SendResultResponse")]
        void SendResult(string test);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WebApplication.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<WebApplication.ServiceReference1.IService>, WebApplication.ServiceReference1.IService {
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry> GetAllEntries() {
            return base.Channel.GetAllEntries();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry>> GetAllEntriesAsync() {
            return base.Channel.GetAllEntriesAsync();
        }
        
        public System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry> GetEntriesOfUser(string UserID) {
            return base.Channel.GetEntriesOfUser(UserID);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry>> GetEntriesOfUserAsync(string UserID) {
            return base.Channel.GetEntriesOfUserAsync(UserID);
        }
        
        public System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry> GetEntriesBetween(System.DateTime start, System.DateTime end) {
            return base.Channel.GetEntriesBetween(start, end);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry>> GetEntriesBetweenAsync(System.DateTime start, System.DateTime end) {
            return base.Channel.GetEntriesBetweenAsync(start, end);
        }
        
        public System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry> GetEntriesBetweenForUser(string UserID, System.DateTime start, System.DateTime end) {
            return base.Channel.GetEntriesBetweenForUser(UserID, start, end);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.DataBaseEntry>> GetEntriesBetweenForUserAsync(string UserID, System.DateTime start, System.DateTime end) {
            return base.Channel.GetEntriesBetweenForUserAsync(UserID, start, end);
        }
        
        public System.TimeSpan RemainingTime(WebApplication.ServiceReference1.DataBaseEntry entry) {
            return base.Channel.RemainingTime(entry);
        }
        
        public System.Threading.Tasks.Task<System.TimeSpan> RemainingTimeAsync(WebApplication.ServiceReference1.DataBaseEntry entry) {
            return base.Channel.RemainingTimeAsync(entry);
        }
        
        public System.Collections.Generic.List<WebApplication.ServiceReference1.Employee> GetEntriesForAlice() {
            return base.Channel.GetEntriesForAlice();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WebApplication.ServiceReference1.Employee>> GetEntriesForAliceAsync() {
            return base.Channel.GetEntriesForAliceAsync();
        }
        
        public string EntryOutput(WebApplication.ServiceReference1.DataBaseEntry str) {
            return base.Channel.EntryOutput(str);
        }
        
        public System.Threading.Tasks.Task<string> EntryOutputAsync(WebApplication.ServiceReference1.DataBaseEntry str) {
            return base.Channel.EntryOutputAsync(str);
        }
        
        public bool AddEntry(WebApplication.ServiceReference1.DataBaseEntry entry) {
            return base.Channel.AddEntry(entry);
        }
        
        public System.Threading.Tasks.Task<bool> AddEntryAsync(WebApplication.ServiceReference1.DataBaseEntry entry) {
            return base.Channel.AddEntryAsync(entry);
        }
        
        public bool AddHistoricalLoggingEntry(WebApplication.ServiceReference1.DataBaseEntry entry) {
            return base.Channel.AddHistoricalLoggingEntry(entry);
        }
        
        public System.Threading.Tasks.Task<bool> AddHistoricalLoggingEntryAsync(WebApplication.ServiceReference1.DataBaseEntry entry) {
            return base.Channel.AddHistoricalLoggingEntryAsync(entry);
        }
        
        public bool AddDevice(WebApplication.ServiceReference1.Device device) {
            return base.Channel.AddDevice(device);
        }
        
        public System.Threading.Tasks.Task<bool> AddDeviceAsync(WebApplication.ServiceReference1.Device device) {
            return base.Channel.AddDeviceAsync(device);
        }
        
        public bool AddUser(WebApplication.ServiceReference1.User user) {
            return base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task<bool> AddUserAsync(WebApplication.ServiceReference1.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public string DBTest() {
            return base.Channel.DBTest();
        }
        
        public System.Threading.Tasks.Task<string> DBTestAsync() {
            return base.Channel.DBTestAsync();
        }
    }
}
