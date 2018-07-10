using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Sparrow.Platform.Posix;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Documents.Queries;
using System.Security.Claims;
using Microsoft.Owin.Security.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace AFKHostedService
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AFKHostedService : IService
    {
        #region Variable Declaration
        private static Dictionary<string, IMyContractCallback> clients = new Dictionary<string, IMyContractCallback>();
        private static object locker = new object();
        IDocumentStore ds = new DocumentStore() { Urls = new[] { "http://192.168.10.153:8080" }, Database = "TestDB", Conventions = { } };
        #endregion

        public AFKHostedService()
        {
            ds.Initialize();
        }

        #region Get Methods
        public async Task<Tuple<List<DataBaseEntry>, int>> GetAllEntries(int indexStart, string sortField, string sortDirection)
        {
            int numResults = 0;
            QueryStatistics stats = new QueryStatistics();
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            try
            { 
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    //Get all entries
                    switch (sortDirection)
                    {
                        case "Ascending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x=>x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                        case "Descending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                    }
                    await s.Query<DataBaseEntry>("DataBaseEntry_Search").Statistics(out stats).ToListAsync();
                    numResults = stats.TotalResults;
                }
            }
            catch(Exception e)
            {
                //Error Message as DataBaseEntry
                DataBaseEntry error = new DataBaseEntry("Error", "Error", e.Message, "NoDeviceID", "NoMachineName","NoSessionID", DateTime.Now, false, false, TimeSpan.Zero);
                ret.Add(error);
            }
            return new Tuple<List<DataBaseEntry>, int>(ret, numResults);
        }

        public async Task<Tuple<List<DataBaseEntry>, int>> GetEntriesOfUser(string UserName, int indexStart, string sortField, string sortDirection)
        {
            int numResults = 0;
            QueryStatistics stats = new QueryStatistics();
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            try
            {
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    var sortProperty = typeof(DataBaseEntry).GetProperty(sortField, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    //Return entries of a specific user
                    switch (sortDirection)
                    {
                        case "Ascending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                        case "Descending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                    }
                    await s.Query<DataBaseEntry>("DataBaseEntry_Search").Statistics(out stats).Where(x => x.UserName == UserName).ToListAsync();
                    numResults = stats.TotalResults;
                }

            }
            catch(Exception e)
            {
                //Error Message as DataBaseEntry
                DataBaseEntry error = new DataBaseEntry("Error","Error", e.Message, "NoDeviceID", "NoMachineName", "NoSessionID", DateTime.Now, false, false, TimeSpan.Zero);
                ret.Add(error);
            }
            return new Tuple<List<DataBaseEntry>, int>(ret, numResults);
        }

        public async Task<Tuple<List<DataBaseEntry>, int>> GetEntriesBetween(DateTime start, DateTime end, int indexStart, string sortField, string sortDirection)
        {
            int numResults = 0;
            QueryStatistics stats = new QueryStatistics();
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            try
            {
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    switch (sortDirection)
                    {
                        case "Ascending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                        case "Descending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                    }
                    await s.Query<DataBaseEntry>("DataBaseEntry_Search").Statistics(out stats).Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).ToListAsync();
                    numResults = stats.TotalResults;
                }
            }
            catch (Exception e)
            {
                //Error Message as DataBaseEntry
                DataBaseEntry error = new DataBaseEntry("Error", "Error", e.Message, "NoDeviceID", "NoMachineName", "NoSessionID", DateTime.Now, false, false, TimeSpan.Zero);
                ret.Add(error);
            }

            //Return all entries between a specific time period
            return new Tuple<List<DataBaseEntry>, int>(ret, numResults);

        }

        public async Task<Tuple<List<DataBaseEntry>, int>> GetEntriesBetweenForUser(string UserName, DateTime start, DateTime end, int indexStart, string sortField, string sortDirection)
        {
            List<DataBaseEntry> ret = new List<DataBaseEntry>();
            int numResults = 0;
            QueryStatistics stats = new QueryStatistics();
            try
            {
                //Connect to database
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    switch (sortDirection)
                    {
                        case "Ascending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                        case "Descending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                    }
                    await s.Query<DataBaseEntry>("DataBaseEntry_Search").Statistics(out stats).Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).ToListAsync();
                    numResults = stats.TotalResults;
                }
            }
            catch (Exception e)
            {
                //Error Message as DataBaseEntry
                DataBaseEntry error = new DataBaseEntry("Error", "Error", e.Message, "NoDeviceID", "NoMachineName", "NoSessionID", DateTime.Now, false, false, TimeSpan.Zero);
                ret.Add(error);
            }

            //Return all entries between a specific time period for a specific user
            return new Tuple<List<DataBaseEntry>, int>(ret, numResults);
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
                    List<User> users = await s.Query<User>("User_Search").ToListAsync();
                    //Get list of devices with users attached
                    List<Device> ownDevices = await s.Query<Device>("Device_Search").Where(x => x.UserID != null).ToListAsync();
                    //Iterate through list of users, select latest DataBaseEntry, create employee object, and add UserName to Employee from User object
                    foreach (User u in users)
                    {
                        //Try create an employee object. If no DataBase Entry is found for the user, skip
                        try
                        {
                            //Check if user has their own device
                            if (ownDevices.Select(y => y.UserID).Contains(u.UserID))
                            {
                                //Find the user's device
                                Device ownDevice = ownDevices.Where(x => x.UserID == u.UserID).FirstOrDefault();
                                //Fetch latest DataBaseEntry from user on their own device
                                DataBaseEntry entry = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x=>x.UserID == u.UserID && x.DeviceID == ownDevice.DeviceID).OrderByDescending(x => x.TimeOfEvent).FirstOrDefaultAsync();
                                //Create Employee from Entry
                                Employee emp = new Employee(entry);
                                //Get name of user
                                emp.Name = u.UserName;
                                //Add to list
                                ret.Add(emp);
                            }
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
                Employee error = new Employee(new DataBaseEntry("Error", "Error", e.Message, "NoDeviceID", "NoMachineName", "NoSessionID", DateTime.Now, false, false, TimeSpan.Zero));
                error.Name = "NoUserName";
                ret.Add(error);
            }

            return ret.OrderBy(x=>x.Name).ToList();

        }

        #endregion

        #region Add Methods

        public void AddServiceEntry(DataBaseEntry entry)
        {
            //Record log-off events immediately
            if(entry.EventType == "SessionLogfOff")
            {
                AddAppletEntry(entry);
            }
            else
            {
                var inactiveClients = new List<string>();
                foreach (var client in clients)
                {
                    if (client.Key.Substring(client.Key.Length-7) !=  "-Service")//stops services being called
                    {   
                        try//Tries to connect to client, if it fails it adds to inactiveClients to be removed
                        {
                            //The applet then calls the AddAppletEntry method to complete the record
                            client.Value.FinishDataBaseEntry(entry);
                        }
                        catch
                        {
                            inactiveClients.Add(client.Key);
                        }
                    }
                }
                //removes inactive clients from client list
                if (inactiveClients.Count > 0)
                {
                    foreach(var client in inactiveClients)
                    {
                        clients.Remove(client);
                    }
                }
            }
        }

        public async void AddAppletEntry(DataBaseEntry entry)
        {
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                //Load UserIDs from db
                IList<string> userIDs = await s.Query<Device>("Device_Search").Select(x => x.UserID).ToListAsync();
                //Load DeviceIDs from db
                IList<string> deviceIDs = await s.Query<Device>("Device_Search").Select(x => x.DeviceID).ToListAsync();
                //Check that device and user exist
                if (userIDs.Contains(entry.UserID) && deviceIDs.Contains(entry.DeviceID))
                {
                    //Add to db and save
                    await s.StoreAsync(entry);
                    await s.SaveChangesAsync();
                }
                Employee emp = new Employee(entry); //TODO: send employee to webpage
            }
        }

        public bool AddDevice(Device device)
        {
            bool success = false;
            //bool flag for the uniqueness of the device to be added
            bool unique = true;
            try
            {
                //Connect to database
                using (IDocumentSession s = ds.OpenSession())
                {
                    //Find identical documents
                     foreach(Device d in s.Query<Device>("Device_Search").ToList())
                    {
                        //Set unique false if identical document is found
                        if( d.DeviceID == device.DeviceID && d.UserID == device.UserID)
                        {
                            unique = false;
                        }
                    }
                     //Add to db if unique
                    if (unique)
                    {
                        s.Store(device);
                        s.SaveChanges();
                    }
                }
                success = unique;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return success;
        }

        public bool AddUser(User user)
        {
            bool success = false;
            try
            {
                //connect to database
                using (IDocumentSession s = ds.OpenSession())
                {
                    s.Store(user);
                    s.SaveChanges();
                }
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return success;
        }

        public bool RegisterClient(string deviceID, bool service)
        {
            bool success = false;
            //Generate unique clientID based on device + whether client is service or applet
            string clientID = deviceID;
            clientID += service ? "-Service" : "-Applet";

            if (clientID != null && clientID != "")
            {
                try
                {
                    IMyContractCallback callback = OperationContext.Current.GetCallbackChannel<IMyContractCallback>();
                    lock (locker)
                    {
                        //remove old client
                        if (clients.Keys.Contains(clientID))
                        {
                            clients.Remove(clientID);
                        }
                        clients.Add(clientID, callback);
                        success = true;
                    }
                }
                catch
                {

                }
            }
            return success;
        }
        #endregion

        #region Testing Methods

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


        public void ClearAllDatabases()
        {
            using (IDocumentSession s = ds.OpenSession())
            {
                //Delete DataBaseEntries
                foreach (var x in s.Query<DataBaseEntry>())
                {
                    s.Delete(x);
                }
                //Delete Devices
                foreach (var x in s.Query<Device>())
                {
                    s.Delete(x);
                }
                //Delete Users
                foreach (var x in s.Query<User>())
                {
                    s.Delete(x);
                }
                s.SaveChanges();
            }
        }

        public void UpdateData()
        {
           
            using (IDocumentSession s = ds.OpenSession())
            {
                foreach(DataBaseEntry d in s.Query<DataBaseEntry>("DataBaseEntry_Search").ToList())
                {
                    d.MachineName = "MachineName";
                }
                s.SaveChanges();
            }
        }

        #endregion

        #region Update Methods
        
        //Updates usernames in database according to active directory names
        public async Task<bool> UpdateADUsernames()
        {
            bool success = false;

            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                {
                    foreach (DataBaseEntry d in await s.Query<DataBaseEntry>("DataBaseEntry_Search").ToListAsync())
                    {try
                        {
                            SecurityIdentifier si = new SecurityIdentifier(d.UserID);
                            //bool test = si.;
                            d.UserName = UserPrincipal.FindByIdentity(ctx,IdentityType.Sid,d.UserID).DisplayName;
                        }
                        catch(Exception e)
                        {
                            //Ignore missed matches for now
                            //TODO: log
                        }

                    }
                    await s.SaveChangesAsync();
                }
            }
            catch
            {
                //Database connection error
            }

            return success;
        }

        #endregion
    }
}
