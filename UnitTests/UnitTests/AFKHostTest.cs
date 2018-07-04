using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFKHostedService;
namespace UnitTests
{
    [TestClass]
    public class AFKHostTest
    {
        [TestMethod]
        public void DataBaseEntryTest()
        {
            DataBaseEntry db = new DataBaseEntry("Event Type", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            Assert.AreEqual(db.EventType, "Event Type");
            Assert.AreEqual(db.UserID, "User ID");
            Assert.AreEqual(db.DeviceID, "Device ID");
            Assert.AreEqual(db.TimeOfEvent, new DateTime());
            Assert.AreEqual(db.AutomaticLock, false);
            Assert.AreEqual(db.RemoteAccess, false);
            Assert.AreEqual(db.ETA, new TimeSpan());
        }

        [TestMethod]
        public void EmployeeEntryTest()
        {
            DataBaseEntry era = new DataBaseEntry("Event Type", "User ID", "Device ID", new DateTime(), false, true, new TimeSpan(1,50,20));
            Employee entryRemoteAccess = new Employee(era);
            DataBaseEntry el = new DataBaseEntry("SessionLocked", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            Employee entryLocked = new Employee(el);
            DataBaseEntry elo = new DataBaseEntry("SessionUnlocked", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            Employee entryUnlocked = new Employee(elo);
            Assert.AreEqual(entryRemoteAccess.AtDesk, false);
            Assert.AreEqual(entryRemoteAccess.Eta, new TimeSpan(1,50,20));
            Assert.AreEqual(entryRemoteAccess.Time, new DateTime());
            Assert.AreEqual(entryRemoteAccess.Name, "");
            Assert.AreEqual(entryLocked.AtDesk, false);
            Assert.AreEqual(entryUnlocked.AtDesk, true);

        }
    }
}
