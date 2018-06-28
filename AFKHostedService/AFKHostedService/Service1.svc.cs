using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AFKHostedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AFKHostedService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AFKHostedService.svc or AFKHostedService.svc.cs at the Solution Explorer and start debugging.
    public class AFKHostedService : IService
    {
        public List<DataBaseEntry> GetEntries()
        {
            //Connect to database
            //Get all entries

            //Testing
            DataBaseEntry x = new DataBaseEntry("EventType", "UserID", "DeviceID", new DateTime(2018, 6, 27, 15, 30, 50), true, new TimeSpan(15, 45, 50));
            List<DataBaseEntry> test = new List<DataBaseEntry>();
            test.Add(x);
            return test;
        }

        public List<DataBaseEntry> GetEntriesOfUser(string UserID)
        {
            throw new NotImplementedException();
        }

        public List<DataBaseEntry> GetEntriesBetween(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public List<DataBaseEntry> GetEntriesBetweenForUser(string UserID, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public TimeSpan RemainingTime(DataBaseEntry entry)
        {
            TimeSpan remaining = entry.ETA - (DateTime.Now.Subtract(entry.TimeOfEvent));
            if (remaining < new TimeSpan(0, 0, 0))
            {
                return new TimeSpan(0, 0, 0);
            }
            else
            {
                return remaining;
            }
        }

        public List<Employee> GetEntriesForAlice()
        {
            throw new NotImplementedException();
        }

        public string EntryOutput(DataBaseEntry str)
        {
            return str.EventType + ", " + str.UserID + ", " + str.DeviceID + ", " + str.AutomaticLock + ", " + str.ETA.ToString() + ", " + str.TimeOfEvent.ToString();
        }

        public void AddEntry(DataBaseEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
