using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AFKHostedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<DataBaseEntry> GetEntries();

        [OperationContract]
        List<DataBaseEntry> GetEntriesOfUser(string UserID);

        [OperationContract]
        List<DataBaseEntry> GetEntriesBetween(DateTime start, DateTime end);

        [OperationContract]
        List<DataBaseEntry> GetEntriesBetweenForUser(string UserID, DateTime start, DateTime end);

        [OperationContract]
        TimeSpan RemainingTime(DataBaseEntry entry);

        [OperationContract]
        List<Employee> GetEntriesForAlice();

        [OperationContract]
        string EntryOutput(DataBaseEntry str);

        [OperationContract]
        void AddEntry(DataBaseEntry entry);

        // TODO: Add your service operations here
    }
    [DataContract]
    public class Employee
    {
        string name;
        bool locked;
        TimeSpan eta;
        DateTime time;

        public Employee(DataBaseEntry x)
        {
            name = getName(x.UserID);
            if (x.EventType.Equals("Locked"))
            {
                locked = true;
            }
            else
            {
                locked = false;
            }
            eta = x.ETA;
            time = x.TimeOfEvent;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
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

        public string getName(string UserID)
        {
            //Connect To Database and get the name of person connected to this user name.
            return "";
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
        TimeSpan eta;


        public DataBaseEntry(string EventType, string UserID, string DeviceID, DateTime TimeofEvent, bool AutomaticLock, TimeSpan ETA)
        {
            eventType = EventType;
            userID = UserID;
            deviceID = DeviceID;
            timeOfEvent = TimeofEvent;
            automaticLock = AutomaticLock;
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

    }
    // TODO: Add your service operations here
}

