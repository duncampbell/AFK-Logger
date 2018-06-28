﻿using Raven.Client.Documents;
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

        public List<DataBaseEntry> GetEntries()
        {
            //Connect to database
            using (IAsyncDocumentSession s = ds.OpenAsyncSession())
            {
                //Get all entries
            }



            //Testing
            /*
            DataBaseEntry x = new DataBaseEntry("Locked", "first", "DeviceID", new DateTime(2018, 6, 27, 15, 30, 50), true, false, new TimeSpan(7, 45, 50));
            DataBaseEntry y = new DataBaseEntry("Unlocked", "second", "DeviceID", new DateTime(2018, 7, 27, 15, 30, 50), true, false, new TimeSpan(0, 45, 50));
            DataBaseEntry z = new DataBaseEntry("Locked", "third", "DeviceID", new DateTime(2018, 6, 29, 15, 30, 50), true, false, new TimeSpan(3, 45, 50));

            List<DataBaseEntry> test = new List<DataBaseEntry>();
            test.Add(x);
            test.Add(y);
            test.Add(z);
            return test;
            */

            throw new NotImplementedException();
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

        public List<Employee> GetEntriesForAlice()
        {
           // Connect To both tables

           // Get entries of device belonging database

           // First get latest entry of each userID

           // For each entry
                //if userID on device matches up with their device
                    //Instantiate object of Employee with DatabaseEntry
                    //Add object to employee list that will be returned
                //Else
                    //Check for earlier entry of userID and add that to entries
            
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

        public string DBTest()
        {
            string entID;
            DataBaseEntry ent = new DataBaseEntry("Test","Test","TestID",DateTime.Now,true,false, TimeSpan.Zero) { };
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
                        session.Store(ent);
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
