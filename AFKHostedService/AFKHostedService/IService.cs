using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AFKHostedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IMyContractCallback))]
    public interface IService
    {
        [OperationContract]
        Task<List<DataBaseEntry>> GetAllEntries();

        [OperationContract]
        Task<List<DataBaseEntry>> GetEntriesOfUser(string UserID);

        [OperationContract]
        Task<List<DataBaseEntry>> GetEntriesBetween(DateTime start, DateTime end);

        [OperationContract]
        Task<List<DataBaseEntry>> GetEntriesBetweenForUser(string UserID, DateTime start, DateTime end);

        [OperationContract]
        TimeSpan RemainingTime(DataBaseEntry entry);

        [OperationContract]
        Task<List<Employee>> GetEntriesForAlice();

        [OperationContract]
        string EntryOutput(DataBaseEntry str);

        [OperationContract(IsOneWay =true)]
        void AddServiceEntry(DataBaseEntry entry);

        [OperationContract(IsOneWay = true)]
        void AddAppletEntry(DataBaseEntry entry);

        [OperationContract]
        Task<bool> AddDevice(Device device);

        [OperationContract]
        Task<bool> AddUser(User user);

        [OperationContract]
        bool RegisterClient(string deviceID, bool service);

        [OperationContract]
        string DBTest();

    }


    public interface IMyContractCallback
    {
        [OperationContract]
        void SendResult(string test);

        [OperationContract]
        void FinishDataBaseEntry(DataBaseEntry entry);
    }

    [DataContract]
    public class Employee
    {
        string name = "";
        bool atDesk;
        TimeSpan eta;
        DateTime time;

        public Employee(DataBaseEntry x)
        {
            if (x.EventType.Equals("Locked") || x.EventType.Equals("Logged Off") || x.RemoteAccess == true)//Change When We know session names
            {
                atDesk = false;
            }
            else
            {
                atDesk = true;
            }
            eta = x.ETA;
            time = x.TimeOfEvent;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool AtDesk
        {
            get { return atDesk; }
            set { atDesk = value; }
        }

        public TimeSpan Eta
        {
            get { return eta; }
            set { eta = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

    }

    [DataContract]
    public class DataBaseEntry
    {

        string eventType;
        string userID;
        string deviceID;
        DateTime timeOfEvent;
        bool automaticLock;
        bool remoteAccess;
        TimeSpan eta;


        public DataBaseEntry(string EventType, string UserID, string DeviceID, DateTime TimeofEvent, bool AutomaticLock, bool RemoteAccess, TimeSpan ETA)
        {
            eventType = EventType;
            userID = UserID;
            deviceID = DeviceID;
            timeOfEvent = TimeofEvent;
            automaticLock = AutomaticLock;
            remoteAccess = RemoteAccess;
            eta = ETA;
        }

        [DataMember]
        public string EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        [DataMember]
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        [DataMember]
        public string DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }

        [DataMember]
        public DateTime TimeOfEvent
        {
            get { return timeOfEvent; }
            set { timeOfEvent = value; }
        }

        [DataMember]
        public bool AutomaticLock
        {
            get { return automaticLock; }
            set { automaticLock = value; }
        }

        [DataMember]
        public TimeSpan ETA
        {
            get { return eta; }
            set { eta = value; }
        }

        [DataMember]
        public bool RemoteAccess
        {
            get{ return remoteAccess;}
            set{remoteAccess = value;}
        }
    }
    
    [DataContract]
    public class Device
    {
        string deviceID;
        string deviceName;
        string userID;
        string userName;
        bool vM;

        public Device() { }
        public Device(string deviceID, string deviceName, string userID, string userName, bool vM)
        {
            this.DeviceID = deviceID;
            this.DeviceName = deviceName;
            this.UserID = userID;
            this.UserName = userName;
            this.vM = VM;
        }

        [DataMember]
        public string DeviceID
        {
            get
            {
                return deviceID;
            }

            set
            {
                deviceID = value;
            }
        }

        [DataMember]
        public string DeviceName
        {
            get
            {
                return deviceName;
            }

            set
            {
                deviceName = value;
            }
        }

        [DataMember]
        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        [DataMember]
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        [DataMember]
        public bool VM
        {
            get
            {
                return vM;
            }

            set
            {
                vM = value;
            }
        }
    }

    [DataContract]
    public class User
    {
        string userID;
        string userName;

        [DataMember]
        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }
        [DataMember]
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }
    }
}

