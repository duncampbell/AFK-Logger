﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomActions.ServiceReference1 {
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
        private string MachineNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool RemoteAccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SessionIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeOfEventField;
        
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
        public string MachineName {
            get {
                return this.MachineNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MachineNameField, value) != true)) {
                    this.MachineNameField = value;
                    this.RaisePropertyChanged("MachineName");
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
        public string SessionID {
            get {
                return this.SessionIDField;
            }
            set {
                if ((object.ReferenceEquals(this.SessionIDField, value) != true)) {
                    this.SessionIDField = value;
                    this.RaisePropertyChanged("SessionID");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/AFKHostedService")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AtDeskField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.TimeSpan EtaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProfilePicField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
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
        public bool AtDesk {
            get {
                return this.AtDeskField;
            }
            set {
                if ((this.AtDeskField.Equals(value) != true)) {
                    this.AtDeskField = value;
                    this.RaisePropertyChanged("AtDesk");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan Eta {
            get {
                return this.EtaField;
            }
            set {
                if ((this.EtaField.Equals(value) != true)) {
                    this.EtaField = value;
                    this.RaisePropertyChanged("Eta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProfilePic {
            get {
                return this.ProfilePicField;
            }
            set {
                if ((object.ReferenceEquals(this.ProfilePicField, value) != true)) {
                    this.ProfilePicField = value;
                    this.RaisePropertyChanged("ProfilePic");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
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
        private string ProfilePicField;
        
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
        public string ProfilePic {
            get {
                return this.ProfilePicField;
            }
            set {
                if ((object.ReferenceEquals(this.ProfilePicField, value) != true)) {
                    this.ProfilePicField = value;
                    this.RaisePropertyChanged("ProfilePic");
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService", CallbackContract=typeof(ServiceReference1.IServiceCallback))]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllEntries", ReplyAction="http://tempuri.org/IService/GetAllEntriesResponse")]
        System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int> GetAllEntries(int indexStart, string sortField, string sortDirection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllEntries", ReplyAction="http://tempuri.org/IService/GetAllEntriesResponse")]
        System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int>> GetAllEntriesAsync(int indexStart, string sortField, string sortDirection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesOfUser", ReplyAction="http://tempuri.org/IService/GetEntriesOfUserResponse")]
        System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int> GetEntriesOfUser(string UserID, int indexStart, string sortField, string sortDirection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesOfUser", ReplyAction="http://tempuri.org/IService/GetEntriesOfUserResponse")]
        System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int>> GetEntriesOfUserAsync(string UserID, int indexStart, string sortField, string sortDirection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesBetween", ReplyAction="http://tempuri.org/IService/GetEntriesBetweenResponse")]
        System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int> GetEntriesBetween(System.DateTime start, System.DateTime end, int indexStart, string sortField, string sortDirection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesBetween", ReplyAction="http://tempuri.org/IService/GetEntriesBetweenResponse")]
        System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int>> GetEntriesBetweenAsync(System.DateTime start, System.DateTime end, int indexStart, string sortField, string sortDirection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesBetweenForUser", ReplyAction="http://tempuri.org/IService/GetEntriesBetweenForUserResponse")]
        System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int> GetEntriesBetweenForUser(string UserID, System.DateTime start, System.DateTime end, int indexStart, string sortField, string sortDirection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesBetweenForUser", ReplyAction="http://tempuri.org/IService/GetEntriesBetweenForUserResponse")]
        System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int>> GetEntriesBetweenForUserAsync(string UserID, System.DateTime start, System.DateTime end, int indexStart, string sortField, string sortDirection);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesForAlice", ReplyAction="http://tempuri.org/IService/GetEntriesForAliceResponse")]
        System.Collections.Generic.List<ServiceReference1.Employee> GetEntriesForAlice();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetEntriesForAlice", ReplyAction="http://tempuri.org/IService/GetEntriesForAliceResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<ServiceReference1.Employee>> GetEntriesForAliceAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/AddServiceEntry")]
        void AddServiceEntry(ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/AddServiceEntry")]
        System.Threading.Tasks.Task AddServiceEntryAsync(ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/AddAppletEntry")]
        void AddAppletEntry(ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService/AddAppletEntry")]
        System.Threading.Tasks.Task AddAppletEntryAsync(ServiceReference1.DataBaseEntry entry);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddDevice", ReplyAction="http://tempuri.org/IService/AddDeviceResponse")]
        bool AddDevice(ServiceReference1.Device device);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddDevice", ReplyAction="http://tempuri.org/IService/AddDeviceResponse")]
        System.Threading.Tasks.Task<bool> AddDeviceAsync(ServiceReference1.Device device);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddUser", ReplyAction="http://tempuri.org/IService/AddUserResponse")]
        bool AddUser(ServiceReference1.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AddUser", ReplyAction="http://tempuri.org/IService/AddUserResponse")]
        System.Threading.Tasks.Task<bool> AddUserAsync(ServiceReference1.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RegisterClient", ReplyAction="http://tempuri.org/IService/RegisterClientResponse")]
        bool RegisterClient(string deviceID, bool service);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RegisterClient", ReplyAction="http://tempuri.org/IService/RegisterClientResponse")]
        System.Threading.Tasks.Task<bool> RegisterClientAsync(string deviceID, bool service);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EntryOutput", ReplyAction="http://tempuri.org/IService/EntryOutputResponse")]
        string EntryOutput(ServiceReference1.DataBaseEntry str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/EntryOutput", ReplyAction="http://tempuri.org/IService/EntryOutputResponse")]
        System.Threading.Tasks.Task<string> EntryOutputAsync(ServiceReference1.DataBaseEntry str);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DBTest", ReplyAction="http://tempuri.org/IService/DBTestResponse")]
        string DBTest();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DBTest", ReplyAction="http://tempuri.org/IService/DBTestResponse")]
        System.Threading.Tasks.Task<string> DBTestAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ClearAllDatabases", ReplyAction="http://tempuri.org/IService/ClearAllDatabasesResponse")]
        void ClearAllDatabases();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ClearAllDatabases", ReplyAction="http://tempuri.org/IService/ClearAllDatabasesResponse")]
        System.Threading.Tasks.Task ClearAllDatabasesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateData", ReplyAction="http://tempuri.org/IService/UpdateDataResponse")]
        void UpdateData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateData", ReplyAction="http://tempuri.org/IService/UpdateDataResponse")]
        System.Threading.Tasks.Task UpdateDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateADUsernames", ReplyAction="http://tempuri.org/IService/UpdateADUsernamesResponse")]
        bool UpdateADUsernames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateADUsernames", ReplyAction="http://tempuri.org/IService/UpdateADUsernamesResponse")]
        System.Threading.Tasks.Task<bool> UpdateADUsernamesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateUser", ReplyAction="http://tempuri.org/IService/UpdateUserResponse")]
        void UpdateUser(ServiceReference1.Employee emp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateUser", ReplyAction="http://tempuri.org/IService/UpdateUserResponse")]
        System.Threading.Tasks.Task UpdateUserAsync(ServiceReference1.Employee emp);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SendResult", ReplyAction="http://tempuri.org/IService/SendResultResponse")]
        void SendResult(string test);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/FinishDataBaseEntry", ReplyAction="http://tempuri.org/IService/FinishDataBaseEntryResponse")]
        void FinishDataBaseEntry(ServiceReference1.DataBaseEntry entry);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.DuplexClientBase<ServiceReference1.IService>, ServiceReference1.IService {
        
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
        
        public System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int> GetAllEntries(int indexStart, string sortField, string sortDirection) {
            return base.Channel.GetAllEntries(indexStart, sortField, sortDirection);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int>> GetAllEntriesAsync(int indexStart, string sortField, string sortDirection) {
            return base.Channel.GetAllEntriesAsync(indexStart, sortField, sortDirection);
        }
        
        public System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int> GetEntriesOfUser(string UserID, int indexStart, string sortField, string sortDirection) {
            return base.Channel.GetEntriesOfUser(UserID, indexStart, sortField, sortDirection);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int>> GetEntriesOfUserAsync(string UserID, int indexStart, string sortField, string sortDirection) {
            return base.Channel.GetEntriesOfUserAsync(UserID, indexStart, sortField, sortDirection);
        }
        
        public System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int> GetEntriesBetween(System.DateTime start, System.DateTime end, int indexStart, string sortField, string sortDirection) {
            return base.Channel.GetEntriesBetween(start, end, indexStart, sortField, sortDirection);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int>> GetEntriesBetweenAsync(System.DateTime start, System.DateTime end, int indexStart, string sortField, string sortDirection) {
            return base.Channel.GetEntriesBetweenAsync(start, end, indexStart, sortField, sortDirection);
        }
        
        public System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int> GetEntriesBetweenForUser(string UserID, System.DateTime start, System.DateTime end, int indexStart, string sortField, string sortDirection) {
            return base.Channel.GetEntriesBetweenForUser(UserID, start, end, indexStart, sortField, sortDirection);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<System.Collections.Generic.List<ServiceReference1.DataBaseEntry>, int>> GetEntriesBetweenForUserAsync(string UserID, System.DateTime start, System.DateTime end, int indexStart, string sortField, string sortDirection) {
            return base.Channel.GetEntriesBetweenForUserAsync(UserID, start, end, indexStart, sortField, sortDirection);
        }
        
        public System.Collections.Generic.List<ServiceReference1.Employee> GetEntriesForAlice() {
            return base.Channel.GetEntriesForAlice();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<ServiceReference1.Employee>> GetEntriesForAliceAsync() {
            return base.Channel.GetEntriesForAliceAsync();
        }
        
        public void AddServiceEntry(ServiceReference1.DataBaseEntry entry) {
            base.Channel.AddServiceEntry(entry);
        }
        
        public System.Threading.Tasks.Task AddServiceEntryAsync(ServiceReference1.DataBaseEntry entry) {
            return base.Channel.AddServiceEntryAsync(entry);
        }
        
        public void AddAppletEntry(ServiceReference1.DataBaseEntry entry) {
            base.Channel.AddAppletEntry(entry);
        }
        
        public System.Threading.Tasks.Task AddAppletEntryAsync(ServiceReference1.DataBaseEntry entry) {
            return base.Channel.AddAppletEntryAsync(entry);
        }
        
        public bool AddDevice(ServiceReference1.Device device) {
            return base.Channel.AddDevice(device);
        }
        
        public System.Threading.Tasks.Task<bool> AddDeviceAsync(ServiceReference1.Device device) {
            return base.Channel.AddDeviceAsync(device);
        }
        
        public bool AddUser(ServiceReference1.User user) {
            return base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task<bool> AddUserAsync(ServiceReference1.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public bool RegisterClient(string deviceID, bool service) {
            return base.Channel.RegisterClient(deviceID, service);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterClientAsync(string deviceID, bool service) {
            return base.Channel.RegisterClientAsync(deviceID, service);
        }
        
        public string EntryOutput(ServiceReference1.DataBaseEntry str) {
            return base.Channel.EntryOutput(str);
        }
        
        public System.Threading.Tasks.Task<string> EntryOutputAsync(ServiceReference1.DataBaseEntry str) {
            return base.Channel.EntryOutputAsync(str);
        }
        
        public string DBTest() {
            return base.Channel.DBTest();
        }
        
        public System.Threading.Tasks.Task<string> DBTestAsync() {
            return base.Channel.DBTestAsync();
        }
        
        public void ClearAllDatabases() {
            base.Channel.ClearAllDatabases();
        }
        
        public System.Threading.Tasks.Task ClearAllDatabasesAsync() {
            return base.Channel.ClearAllDatabasesAsync();
        }
        
        public void UpdateData() {
            base.Channel.UpdateData();
        }
        
        public System.Threading.Tasks.Task UpdateDataAsync() {
            return base.Channel.UpdateDataAsync();
        }
        
        public bool UpdateADUsernames() {
            return base.Channel.UpdateADUsernames();
        }
        
        public System.Threading.Tasks.Task<bool> UpdateADUsernamesAsync() {
            return base.Channel.UpdateADUsernamesAsync();
        }
        
        public void UpdateUser(ServiceReference1.Employee emp) {
            base.Channel.UpdateUser(emp);
        }
        
        public System.Threading.Tasks.Task UpdateUserAsync(ServiceReference1.Employee emp) {
            return base.Channel.UpdateUserAsync(emp);
        }
    }
}