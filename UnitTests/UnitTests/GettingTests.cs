using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFKHostedService;
using UnitTests.ServiceReference1;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class GettingTests : IServiceCallback
    {
        /*
        [TestMethod]
        public void getAllEntriesTestOne()
        {
            //Test to get all entries with sorted on Event Type
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("b", "b", "b", new DateTime(50000), true, false, new TimeSpan(1, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("c", "c", "c", new DateTime(55000), false, true, new TimeSpan(8, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            dataTest.Add(dbTest);

            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, "EventType", "Ascending");
            dataTest = dataTest.OrderBy(o => o.EventType).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);
            
            testing = Proxy.GetAllEntries(0, "EventType", "Descending");
            dataTest = dataTest.OrderByDescending(o => o.EventType).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
           Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);

        }

        [TestMethod]
        public void getAllEntriesTestTwo()
        {
            //Test to get all entries with sorted on Event Type
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("b", "b", "b", new DateTime(50000), true, false, new TimeSpan(1, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("c", "c", "c", new DateTime(55000), false, true, new TimeSpan(8,50,20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            dataTest.Add(dbTest);
            
            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, "UserID", "Ascending");
            dataTest = dataTest.OrderBy(o => o.UserID).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);

            testing = Proxy.GetAllEntries(0, "UserID", "Descending");
            dataTest = dataTest.OrderByDescending(o => o.UserID).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
           Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);
        }

        [TestMethod]
        public void getAllEntriesTestThree()
        {
            //Test to get all entries with sorted on Event Type
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("b", "b", "b", new DateTime(50000), true, false, new TimeSpan(1, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("c", "c", "c", new DateTime(55000), false, true, new TimeSpan(8, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            dataTest.Add(dbTest);

            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, "DeviceID", "Ascending");
            dataTest = dataTest.OrderBy(o => o.DeviceID).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);

            testing = Proxy.GetAllEntries(0, "DeviceID", "Descending");
            dataTest = dataTest.OrderByDescending(o => o.DeviceID).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);
        }

        [TestMethod]
        public void getAllEntriesTestFour()
        {
            //Test to get all entries with sorted on Event Type
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("b", "b", "b", new DateTime(50000), true, false, new TimeSpan(1, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("c", "c", "c", new DateTime(55000), false, true, new TimeSpan(8, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            dataTest.Add(dbTest);

            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, "TimeOfEvent", "Ascending");
            dataTest = dataTest.OrderBy(o => o.TimeOfEvent).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);

            testing = Proxy.GetAllEntries(0, "TimeOfEvent", "Descending");
            dataTest = dataTest.OrderByDescending(o => o.TimeOfEvent).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);
        }

        [TestMethod]
        public void getAllEntriesTestFive()
        {
            //Test to get all entries with sorted on Event Type
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("b", "b", "b", new DateTime(50000), true, false, new TimeSpan(1, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("c", "c", "c", new DateTime(55000), false, true, new TimeSpan(8, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            dataTest.Add(dbTest);

            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, "AutomaticLock", "Ascending");
            dataTest = dataTest.OrderBy(o => o.AutomaticLock).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);

            testing = Proxy.GetAllEntries(0, "AutomaticLock", "Descending");
            dataTest = dataTest.OrderByDescending(o => o.AutomaticLock).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);
        }

        [TestMethod]
        public void getAllEntriesTestSix()
        {
            //Test to get all entries with sorted on Event Type
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("b", "b", "b", new DateTime(50000), true, false, new TimeSpan(1, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("c", "c", "c", new DateTime(55000), false, true, new TimeSpan(8, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            dataTest.Add(dbTest);

            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, "RemoteAccess", "Ascending");
            dataTest = dataTest.OrderBy(o => o.RemoteAccess).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);

            testing = Proxy.GetAllEntries(0, "RemoteAccess", "Descending");
            dataTest = dataTest.OrderByDescending(o => o.RemoteAccess).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);
        }

        [TestMethod]
        public void getAllEntriesTestSeven()
        {
            //Test to get all entries with sorted on Event Type
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("b", "b", "b", new DateTime(50000), true, false, new TimeSpan(1, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("c", "c", "c", new DateTime(55000), false, true, new TimeSpan(8, 50, 20));
            dataTest.Add(dbTest);
            dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            dataTest.Add(dbTest);

            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, "ETA", "Ascending");
            dataTest = dataTest.OrderBy(o => o.ETA).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);

            testing = Proxy.GetAllEntries(0, "ETA", "Descending");
            dataTest = dataTest.OrderByDescending(o => o.ETA).ToList();
            Assert.AreEqual(testing.ElementAt(0).EventType, dataTest.ElementAt(0).EventType);
            Assert.AreEqual(testing.ElementAt(1).EventType, dataTest.ElementAt(1).EventType);
            Assert.AreEqual(testing.ElementAt(2).EventType, dataTest.ElementAt(2).EventType);
        }

        [TestMethod]
        public void getAllEntriesForUserTest()
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);
            
            DataBaseEntry dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            List<DataBaseEntry> testing = Proxy.GetEntriesOfUser("a", 0, "TimeOfEvent", "Ascending");
            DataBaseEntry test = testing.ElementAt(0);

            Assert.AreEqual(test.EventType, dbTest.EventType);
        }

        [TestMethod]
        public void getAllEntriesBetweenTest()
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            DataBaseEntry dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            List<DataBaseEntry> testing = Proxy.GetEntriesBetween(new DateTime(2018, 7, 5, 11, 58, 0), new DateTime(2018, 7, 8, 11, 58, 0), 0, "TimeOfEvent", "Ascending");
            DataBaseEntry test = testing.ElementAt(0);

            Assert.AreEqual(test.EventType, dbTest.EventType);

            List<DataBaseEntry>  testing2 = Proxy.GetEntriesBetween(new DateTime(2018, 7, 8, 11, 58, 0), new DateTime(2018, 7, 9, 11, 58, 0), 0, "TimeOfEvent", "Ascending");
           // DataBaseEntry test2 = testing2.ElementAt(0);

          Assert.AreEqual(testing2.Count, 0);
        }
        
        [TestMethod]
        public void getAllEntriesForUserBetweenTest()
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            DataBaseEntry dbTest = new DataBaseEntry("a", "a", "a", new DateTime(60000), false, false, new TimeSpan(1, 20, 50));
            List<DataBaseEntry> testing = Proxy.GetEntriesBetweenForUser("a", new DateTime(2018, 7, 5, 11, 58, 0), new DateTime(2018, 7, 8, 11, 58, 0), 0, "TimeOfEvent", "Ascending");
            DataBaseEntry test = testing.ElementAt(0);

            Assert.AreEqual(test.EventType, dbTest.EventType);

            //testing = Proxy.GetEntriesBetweenForUser("b", new DateTime(56000), new DateTime(62000), 0, "TimeOfEvent", "Ascending");
            //test = testing.ElementAt(0);

           //Assert.AreEqual(test, null);

        }

        [TestMethod]
        public void getEntriesForAliceTest()
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<Employee> test = Proxy.GetEntriesForAlice();
            DataBaseEntry dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            Employee testing = new Employee(dbTest);
            testing.Name = "a";
            Assert.AreEqual(test.ElementAt(0).Time, testing.Time);
        
            //Assert.IsTrue(false);
        }
        */
        public void SendResult(string test)
        {
           // throw new NotImplementedException();
        }

        public void FinishDataBaseEntry(DataBaseEntry entry)
        {
            //throw new NotImplementedException();
        }
    }
}
