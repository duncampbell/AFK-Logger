using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Security.Permissions;
using System.Diagnostics;

namespace AFKHostedService
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode = System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Required)]
    public class AFKHostedService : IService
    {
        #region Variable Declaration
        private static Dictionary<string, IMyContractCallback> clients = new Dictionary<string, IMyContractCallback>();
        private static object locker = new object();
        IDocumentStore ds = new DocumentStore() { Urls = new[] { "http://192.168.10.153:8080" }, Database = "TestDB", Conventions = { } };
        bool recentEntry = false;
        #endregion

        public AFKHostedService()
        {
            ds.Initialize();
            Trace.WriteLine("STARTING TRACE");
        }

        #region Get Methods
        [PrincipalPermission(SecurityAction.Demand, Role = "FOFX\\AFKLogAdmin")]
        public async Task<Tuple<List<DataBaseEntry>, int>> GetAllEntries(int indexStart, string sortField, string sortDirection)
        {
            try
            {
                Trace.WriteLine("USER: " + OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name);
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error " + e.Message);
            }
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
                                case "MachineName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderBy(x => x.MachineName).Skip(indexStart).Take(20).ToListAsync();
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
                                case "MachineName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").OrderByDescending(x => x.MachineName).Skip(indexStart).Take(20).ToListAsync();
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

        [PrincipalPermission(SecurityAction.Demand, Role = "FOFX\\AFKLogAdmin")]
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
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderBy(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderBy(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderBy(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "MachineName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderBy(x => x.MachineName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderBy(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderBy(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderBy(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderBy(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderBy(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                        case "Descending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderByDescending(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderByDescending(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderByDescending(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "MachineName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName).OrderByDescending(x => x.MachineName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderByDescending(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*"+UserName+"*").OrderByDescending(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderByDescending(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderByDescending(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").OrderByDescending(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                    }
                    await s.Query<DataBaseEntry>("DataBaseEntry_Search").Statistics(out stats).Search(x => x.UserName, "*" + UserName + "*").ToListAsync();
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

        [PrincipalPermission(SecurityAction.Demand, Role = "FOFX\\AFKLogAdmin")]
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
                                case "MachineName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.MachineName).Skip(indexStart).Take(20).ToListAsync();
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
                                case "MachineName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.MachineName).Skip(indexStart).Take(20).ToListAsync();
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

        [PrincipalPermission(SecurityAction.Demand, Role = "FOFX\\AFKLogAdmin")]
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
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "MachineName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.MachineName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderBy(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                        case "Descending":
                            switch (sortField)
                            {
                                case "UserName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.UserName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "EventType":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.EventType).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "UserID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.UserID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "MachineName":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserName == UserName && x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.MachineName).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "DeviceID":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.DeviceID).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "TimeOfEvent":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.TimeOfEvent).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "AutomaticLock":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.AutomaticLock).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "ETA":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.ETA).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                                case "RemoteAccess":
                                    ret = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).OrderByDescending(x => x.RemoteAccess).Skip(indexStart).Take(20).ToListAsync();
                                    break;
                            }
                            break;
                    }
                    await s.Query<DataBaseEntry>("DataBaseEntry_Search").Statistics(out stats).Search(x => x.UserName, "*" + UserName + "*").Where(x => x.TimeOfEvent >= start && x.TimeOfEvent <= end).ToListAsync();
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
                    s.Advanced.MaxNumberOfRequestsPerSession=200;
                    //List of devices
                    List<Device> devices = await s.Query<Device>("Device_Search").ToListAsync();
                    //List of userIDs 
                    List<string> userIDs = devices.Select(x => x.UserID).Distinct().ToList();
                    //Iterate through list of users, select latest DataBaseEntry, create employee object, and add UserName to Employee
                    foreach (var u in userIDs)
                    {
                        //Try create an employee object. If no DataBase Entry is found for the user, skip
                        try
                        {
                            //Fetch latest 20 DataBaseEntries from user
                            List<DataBaseEntry> entries = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x=>x.UserID == u).OrderByDescending(x => x.TimeOfEvent).Take(20).ToListAsync();
                            //Find latest non-VPN login on non-VM machine 
                            bool validEntry = false;
                            int index = 0;
                            for (int i = 0; i < entries.Count; i++)
                            {
                                if (!entries[i].RemoteAccess && !devices.Find(x => x.DeviceID == entries[i].DeviceID).VM)
                                {
                                    index = i;
                                    validEntry = true;
                                    break;
                                }
                            }
                            DataBaseEntry entry = validEntry? entries[index]:null;
                            //Create Employee from Entry
                            Employee emp = new Employee(entry);
                            try
                            {
                                emp.ProfilePic = await s.Query<User>("User_Search").Where(x => x.UserID == emp.UserID).Select(y=>y.ProfilePic).FirstOrDefaultAsync();
                            }
                            catch (Exception e)
                            {

                                emp.ProfilePic = e.Message;
                                //No profile pic for you
                            }
                            //Add to list
                            ret.Add(emp);
                            
                        }
                        catch
                        {
                            //If the user hasn't signed in physically (ie non-VPN) on a non-WM machine in their last 20 entries, find there last logged action
                            DataBaseEntry dBE = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.UserID == u).OrderByDescending(y => y.TimeOfEvent).FirstOrDefaultAsync();
                            if (dBE != null)
                            {
                                dBE.EventType = "AssumedAway";
                                Employee awayEmployee = new Employee(dBE);
                                ret.Add(awayEmployee); 
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Error Message as DataBaseEntry
                Employee error = new Employee(new DataBaseEntry(e.Message, "Error", e.Message, "NoDeviceID", "NoMachineName", "NoSessionID", DateTime.Now, false, false, TimeSpan.Zero));
                error.Name = e.Message;
                ret.Add(error);
            }

            return ret.OrderBy(x=>x.Name).ToList();

        }

        #endregion

        #region Add Methods

        public async void AddServiceEntry(DataBaseEntry entry)
        {
            Trace.WriteLine("ADD SERVICE ENTRY START RECENTENTRY: " + recentEntry);
            if (!recentEntry) //Prevets double recording of lock events
            {

                Trace.WriteLine("ADD SERVICE ENTRY ENTERED");
                Trace.WriteLine("EVENT TYPE: " + entry.EventType);

                if (entry.EventType == "SessionLock" || entry.EventType == "SessionUnlock")
                {

                    var inactiveClients = new List<string>();
                    foreach (var client in clients)
                    {
                        Trace.Write(client.Value);

                        if (client.Key.Substring(client.Key.Length - 7) != "-Service")//stops services being called
                        {

                            try//Tries to connect to client, if it fails it adds to inactiveClients to be removed
                            {
                                //The applet then calls the AddAppletEntry method to complete the record
                                Trace.WriteLine("ATTEMPTING FINISHDATABASEENTRY");

                                client.Value.FinishDataBaseEntry(entry);
                            }
                            catch
                            {
                                Trace.WriteLine("CLIENT CAUGHT");

                                inactiveClients.Add(client.Key);
                            }
                        }
                    }
                    //removes inactive clients from client list
                    if (inactiveClients.Count > 0)
                    {
                        foreach (var client in inactiveClients)
                        {
                            clients.Remove(client);
                        }
                    }
                }
                //Record log-off events immediately
                else
                {
                    Trace.WriteLine("ATTEMPTING IMMEDIATE ADD");
                    using (IAsyncDocumentSession s = ds.OpenAsyncSession())
                    {
                        try
                        {
                            Trace.WriteLine("NEW ENTRY DEVICE ID: " + entry.DeviceID);
                            //Find last entry for device
                            DataBaseEntry dBE = await s.Query<DataBaseEntry>("DataBaseEntry_Search").Where(x => x.DeviceID == entry.DeviceID).OrderByDescending(y => y.TimeOfEvent).FirstAsync();
                            entry.UserID = dBE.UserID;
                            entry.UserName = dBE.UserName;
                            Trace.WriteLine("Last entry UserID: " + dBE.UserID + "\nLast entry UserName: " + dBE.UserName);
                        }
                        catch
                        {

                            //Must be the device's first entry or something
                        }
                    }
                    AddAppletEntry(entry);
                } 
            }
            recentEntry = false;
        }

        public async void AddAppletEntry(DataBaseEntry entry)
        {
            //Prevent double-adding lock event
            recentEntry = entry.AutomaticLock ? false:true;
            Trace.WriteLine("ADD APPLET ENTRY ENTERED TRACE");
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                //Load DeviceIDs from db
                IList<string> deviceIDs = await s.Query<Device>("Device_Search").Select(x => x.DeviceID).ToListAsync();
                //Check that device and user exist
                if (deviceIDs.Contains(entry.DeviceID))
                {
                    //Add to db and save
                    await s.StoreAsync(entry);
                    await s.SaveChangesAsync();
                }
            }
        }

        public bool AddDevice(Device device)
        {
            Trace.WriteLine("ADD DEVICE ENTERED TRACE");
            User user = new User();
            user.UserID  =device.UserID;
            user.UserName =device.UserName;
            user.ProfilePic = "Folder/Profile.png";

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
                        s.Store(user);
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
            var x = System.Threading.Thread.CurrentPrincipal.Identity;
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
                            Trace.WriteLine("Missed User: " + d.UserName + " " + d.UserID);
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
        public void UpdateUser(Employee emp)
        {
            try
            {
                using (IDocumentSession s = ds.OpenSession())
                {
                    //Loads user from db
                    User user = s.Query<User>("User_Search").Where(u => u.UserID == emp.UserID).FirstOrDefault();
                    //Sets user profile pic url to employee profile pic url
                    user.ProfilePic = emp.ProfilePic;
                    //Save to db
                    s.SaveChanges();
                }
            }
            catch
            {

            }


        }
        #endregion
    }
}
