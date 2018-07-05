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
        
        [TestMethod]
        public void getAllEntriesTestOne()
        {
            //Test to get all entries and see if list length is valid.
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, null, null);
            Assert.AreEqual(testing.Count, 3);
            Assert.AreEqual(testing.ElementAt(2).EventType, "Event Type");
            Assert.AreEqual(testing.ElementAt(2).UserID, "User ID");
            Assert.AreEqual(testing.ElementAt(2).DeviceID, "Device ID");
            Assert.AreEqual(testing.ElementAt(2).TimeOfEvent, new DateTime());
            Assert.IsFalse(testing.ElementAt(2).AutomaticLock);
            Assert.IsFalse(testing.ElementAt(2).RemoteAccess);
            Assert.AreEqual(testing.ElementAt(2).ETA, new TimeSpan(1, 20, 50));

        }

        
        [TestMethod]
        public void getAllEntriesTestTwo()
        {
            //Test to get all entries and see if list length is valid.

            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);
            Proxy.ClearAllDatabases();

            Device devSuc = new Device("Device ID", "Device Name", "User ID", "UserName", false);
            Proxy.AddDevice(devSuc);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("Event Type", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            dataTest.Add(dbTest);
            Proxy.AddAppletEntry(dbTest);
            dbTest = new DataBaseEntry("Event Type", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            dataTest.Add(dbTest);
            Proxy.AddAppletEntry(dbTest);
            DateTime tst = DateTime.Now;
            dbTest = new DataBaseEntry("Event Type1", "User ID", "Device ID", tst, false, false, new TimeSpan(1, 20, 50));
            dataTest.Add(dbTest);
            Proxy.AddAppletEntry(dbTest);

            List<DataBaseEntry> dataTest2 = dataTest;
            List<DataBaseEntry> testing = Proxy.GetAllEntries(0, "Event Type", "Ascending");
            dataTest = dataTest.OrderBy(o => o.EventType).ToList();
            CollectionAssert.AreEqual(dataTest2, dataTest);

        }

        [TestMethod]
        public void getAllEntriesForUserTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void getAllEntriesBetweenTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void getAllEntriesForUserBetweenTest()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void getEntriesForAliceTest()
        {
            Assert.IsTrue(false);
        }

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
