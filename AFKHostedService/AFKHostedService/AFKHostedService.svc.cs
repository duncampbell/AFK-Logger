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
            try
            { 
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    //Get all entries
                    ret = await s.Query<DataBaseEntry>("DataEntry_Searching").ToListAsync();    
                }
            }
            catch(Exception e)
            {
                //Error Message as DataBaseEntry
                DataBaseEntry error = new DataBaseEntry("Error", e.Message, "NoDeviceID", DateTime.Now, false, false, TimeSpan.Zero);
                ret.Add(error);
            }

            return ret;
        }

        public async Task<List<DataBaseEntry>> GetEntriesOfUser(string UserID)
        {
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            try
            {
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    //Return entries of a specific user
                    ret = await s.Query<DataBaseEntry>("DataEntry_Searching").Where(x => x.UserID == UserID).ToListAsync();
                }
            }
            catch(Exception e)
            {
                //Error Message as DataBaseEntry
                DataBaseEntry error = new DataBaseEntry("Error", e.Message, "NoDeviceID", DateTime.Now, false, false, TimeSpan.Zero);
                ret.Add(error);
            }
            return ret;
        }

        public async Task<List<DataBaseEntry>> GetEntriesBetween(DateTime start, DateTime end)
        {
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            try
            {
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    ret = await s.Query<DataBaseEntry>("DataEntry_Searching").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).ToListAsync();
                }
            }
            catch (Exception e)
            {
                //Error Message as DataBaseEntry
                DataBaseEntry error = new DataBaseEntry("Error", e.Message, "NoDeviceID", DateTime.Now, false, false, TimeSpan.Zero);
                ret.Add(error);
            }

            //Return all entries between a specific time period
            return ret;

        }

        public async Task<List<DataBaseEntry>> GetEntriesBetweenForUser(string UserID, DateTime start, DateTime end)
        {
            List<DataBaseEntry> ret = new List<DataBaseEntry>();

            try
            {
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    ret = await s.Query<DataBaseEntry>("DataEntry_Searching").Where(x => x.UserID == UserID && x.TimeOfEvent >= start && x.TimeOfEvent <= end).ToListAsync();
                }
            }
            catch (Exception e)
            {
                //Error Message as DataBaseEntry
                DataBaseEntry error = new DataBaseEntry("Error", e.Message, "NoDeviceID", DateTime.Now, false, false, TimeSpan.Zero);
                ret.Add(error);
            }

            //Return all entries between a specific time period for a specific user
            return ret;
        }
        
        //Returns list of all employees constructed from the last DataBaseEntry associated with their UserID
        public async Task<List<Employee>> GetEntriesForAlice()
        {
            List<Employee> ret = new List<Employee>();

            try
            {
                // Connect To db
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    //List of users
                    List<User> users = await s.Query<User>("User_Search").Distinct().ToListAsync();
                    //Iterate through list of users, select latest DataBaseEntry, create employee object, and add UserName to Employee from User object
                    foreach (User u in users)
                    {
                        //Try create an employee object. If no DataBase Entry is found for the user, skip
                        try
                        {
                            //Get latest DataBaseEntries for user
                            DataBaseEntry entry = await s.Query<DataBaseEntry>("DataEntry_Searching").Where(x => x.UserID == u.UserID).OrderByDescending(x => x.TimeOfEvent).FirstOrDefaultAsync();
                            //Create Employee from Entry
                            Employee emp = new Employee(entry);
                            //Get name of user
                            emp.Name = u.UserName;
                            //Add to list
                            ret.Add(emp);
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Error Message as DataBaseEntry
                Employee error = new Employee(new DataBaseEntry("Error", e.Message, "NoDeviceID", DateTime.Now, false, false, TimeSpan.Zero));
                error.Name = "NoUserName";
                ret.Add(error);
            }

            return ret;

        }

        public async Task<bool> AddEntry(DataBaseEntry entry)
        {
            bool success = false;
            try
            {
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    //Add to db and save
                    await s.StoreAsync(entry);
                    await s.SaveChangesAsync();
                }

                Employee emp = new Employee(entry);
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return success;
        }

        public async Task<bool> AddDevice(Device device)
        {
            bool success = false;
            try
            {
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    await s.StoreAsync(device);
                    await s.SaveChangesAsync();
                }
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return success;
        }

        public async Task<bool> AddUser(User user)
        {
            bool success = false;
            try
            {
                //connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    await s.StoreAsync(user);
                    await s.SaveChangesAsync();
                }
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return success;
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

        public string EntryOutput(DataBaseEntry str)
        {
            return str.EventType + ", " + str.UserID + ", " + str.DeviceID + ", " + str.AutomaticLock + ", " + str.ETA.ToString() + ", " + str.TimeOfEvent.ToString();
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
