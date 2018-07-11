using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AFKHostedService
{
    #region Interfaces
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IMyContractCallback))]
    public interface IService
    {

        #region Get Methods
        [OperationContract]
        Task<Tuple<List<DataBaseEntry>, int>> GetAllEntries(int indexStart, string  sortField, string sortDirection);

        [OperationContract]
        Task<Tuple<List<DataBaseEntry>, int>> GetEntriesOfUser(string UserID, int indexStart, string sortField, string sortDirection);

        [OperationContract]
        Task<Tuple<List<DataBaseEntry>, int>> GetEntriesBetween(DateTime start, DateTime end, int indexStart, string sortField, string sortDirection);

        [OperationContract]
        Task<Tuple<List<DataBaseEntry>, int>> GetEntriesBetweenForUser(string UserID, DateTime start, DateTime end, int indexStart, string sortField, string sortDirection);

        [OperationContract]
        Task<List<Employee>> GetEntriesForAlice();

        #endregion

        #region Add Methods

        [OperationContract(IsOneWay =true)]
        void AddServiceEntry(DataBaseEntry entry);

        [OperationContract(IsOneWay = true)]
        void AddAppletEntry(DataBaseEntry entry);

        [OperationContract]
        bool AddDevice(Device device);

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        bool RegisterClient(string deviceID, bool service);
        #endregion

        #region Test Methods

        [OperationContract]
        string EntryOutput(DataBaseEntry str);

        [OperationContract]
        string DBTest();

        [OperationContract]
        void ClearAllDatabases();

        [OperationContract]
        void PopulateDataBase();

        #endregion

        #region Update Methods
        [OperationContract]
        Task<bool> UpdateADUsernames();
        #endregion
    }

    public interface IMyContractCallback
    {
        [OperationContract]
        void SendResult(string test);

        [OperationContract]
        void FinishDataBaseEntry(DataBaseEntry entry);
    }
    #endregion

    #region DataContracts
    [DataContract]
    public class Employee
    {
        string name = "";
        bool atDesk;
        TimeSpan eta;
        DateTime time;
        Image profilePic;

        public Employee(DataBaseEntry x)
        {
            if (x.EventType.Equals("SessionLock") || x.EventType.Equals("SessionLogOff") || x.RemoteAccess == true)//Change When We know session names
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
        [DataMember]
        public Image ProfilePic
        {
            get { return profilePic; }
            set { profilePic = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public bool AtDesk
        {
            get { return atDesk; }
            set { atDesk = value; }
        }
        [DataMember]
        public TimeSpan Eta
        {
            get { return eta; }
            set { eta = value; }
        }
        [DataMember]
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
        string machineName;
        DateTime timeOfEvent;
        bool automaticLock;
        bool remoteAccess;
        TimeSpan eta;
        string userName;
        string sessionID;


        public DataBaseEntry(string UserName, string EventType, string UserID, string DeviceID,string MachineName, string SessionID, DateTime TimeofEvent, bool AutomaticLock, bool RemoteAccess, TimeSpan ETA)
        {
            userName = UserName;
            eventType = EventType;
            userID = UserID;
            deviceID = DeviceID;
            timeOfEvent = TimeofEvent;
            automaticLock = AutomaticLock;
            remoteAccess = RemoteAccess;
            eta = ETA;
            sessionID = SessionID;
        }

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
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

        [DataMember]
        public string SessionID
        {
            get
            {
                return sessionID;
            }

            set
            {
                sessionID = value;
            }
        }

        [DataMember]
        public string MachineName
        {
            get
            {
                return machineName;
            }

            set
            {
                machineName = value;
            }
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
    #endregion
}

