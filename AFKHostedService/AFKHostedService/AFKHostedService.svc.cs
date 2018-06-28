using Raven.Client.Documents;
using Raven.Client.Documents.Session;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AFKHostedService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AFKHostedService.svc or AFKHostedService.svc.cs at the Solution Explorer and start debugging.
    public class AFKHostedService : IService
    {
        IDocumentStore ds = new DocumentStore() { Urls = new[] { "http://192.168.10.153:8080" }, Database = "TestDB", Conventions = { } };

        public AFKHostedService()
        {
            ds.Initialize();
        }

        public async Task<List<DataBaseEntry>> GetAllEntries()
        {
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            //Connect to database
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                //Get all entries
                ret = await s.Query<DataBaseEntry>("DataEntry_Searching").ToListAsync();    
            }
            return ret;
        }

        public async Task<List<DataBaseEntry>> GetEntriesOfUser(string UserID)
        {
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            //Connect to database
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                //Return entries of a specific user
                ret = await s.Query<DataBaseEntry>("DataEntry_Searching").Where(x => x.UserID == UserID).ToListAsync();
            }

            return ret;
        }

        public async Task<List<DataBaseEntry>> GetEntriesBetween(DateTime start, DateTime end)
        {
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            //Connect to database
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                ret = await s.Query<DataBaseEntry>("DataEntry_Searching").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).ToListAsync();
            }
            //Return all entries between a specific time period
            return ret;

        }

        public async Task<List<DataBaseEntry>> GetEntriesBetweenForUser(string UserID, DateTime start, DateTime end)
        {
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            //Connect to database
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                ret = await s.Query<DataBaseEntry>("DataEntry_Searching").Where(x => x.UserID == UserID && x.TimeOfEvent >= start && x.TimeOfEvent <= end).ToListAsync();
            }
            //Return all entries between a specific time period for a specific user
            return ret;
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

        public async Task<List<Employee>> GetEntriesForAlice()
        {
            List<Employee> ret = new List<Employee>();
            // Connect To db
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                List<Device> devices = await s.Query<Device>("Devices_Search").ToListAsync();
                
            }
            return ret;
            // Get entries of device belonging database

            // First get latest entry of each userID

            // For each entry
            //if userID on device matches up with their device
            //Instantiate object of Employee with DatabaseEntry
            //Add object to employee list that will be returned
            //Else
            //Check for earlier entry of userID and add that to entries

        }

        public string EntryOutput(DataBaseEntry str)
        {
            return str.EventType + ", " + str.UserID + ", " + str.DeviceID + ", " + str.AutomaticLock + ", " + str.ETA.ToString() + ", " + str.TimeOfEvent.ToString();
        }

        public void AddEntry(DataBaseEntry entry)
        {
            //Connect to database
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                //Add to db and save
                s.StoreAsync(entry);
                s.SaveChangesAsync();
            }

            Employee emp = new Employee(entry);
        }

        public string DBTest()
        {
            Device d = new Device();
            d.DeviceID = "TestDeviceID";
            d.DeviceName = "InternBox4";
            d.UserID = "TestUserID";
            d.VM = false;
            string str = "Error";
            using (IDocumentStore store = new Raven.Client.Documents.DocumentStore
            {
                Urls = new[]
                {
                    "http://192.168.10.153:8080"
                },
                Database = "TestDB",
                Conventions = { }
            })
            {
                try
                { 
                    store.Initialize();
                    using (IDocumentSession session = store.OpenSession())
                    {
                        session.Store(d);
                        session.SaveChanges();

                        DataBaseEntry loadedEnt = session.Load<DataBaseEntry>("DataBaseEntries/2-A");
                        str = loadedEnt.DeviceID;
                        
                    }
                    return str;
                }
                catch(Exception e)
                {
                    return e.Message;
                }
            }
        }
    }
}
