using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFKHostedService;

namespace UnitTests
{
    [TestClass]
    public class ClassTests
    {
        /*
        [TestMethod]
        public void DataBaseEntryTest()
        {
            DataBaseEntry db = new DataBaseEntry("Event Type", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            Assert.AreEqual(db.EventType, "Event Type");
            Assert.AreNotEqual(db.EventType, "esgsedg");
            Assert.AreEqual(db.UserID, "User ID");
            Assert.AreNotEqual(db.UserID, "esgsedg");
            Assert.AreEqual(db.DeviceID, "Device ID");
            Assert.AreNotEqual(db.DeviceID, "esgsedg");
            Assert.AreEqual(db.TimeOfEvent, new DateTime());
            Assert.AreNotEqual(db.TimeOfEvent, new DateTime(2018, 10, 10, 10, 10, 10));
            Assert.AreEqual(db.AutomaticLock, false);
            Assert.AreNotEqual(db.AutomaticLock, true);
            Assert.AreEqual(db.RemoteAccess, false);
            Assert.AreNotEqual(db.AutomaticLock, true);
            Assert.AreEqual(db.ETA, new TimeSpan());
            Assert.AreNotEqual(db.ETA, new TimeSpan(2, 2, 2));
        }

        [TestMethod]
        public void EmployeeEntryTest()
        {
            DataBaseEntry era = new DataBaseEntry("SessionUnlocked", "User ID", "Device ID", new DateTime(), false, true, new TimeSpan(1, 50, 20));
            Employee entryRemoteAccess = new Employee(era);
            DataBaseEntry el = new DataBaseEntry("SessionLock", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            Employee entryLocked = new Employee(el);
            DataBaseEntry elo = new DataBaseEntry("SessionUnlocked", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            Employee entryUnlocked = new Employee(elo);
            Assert.IsFalse(entryRemoteAccess.AtDesk);
            Assert.AreEqual(entryRemoteAccess.Eta, new TimeSpan(1, 50, 20));
            Assert.AreEqual(entryRemoteAccess.Time, new DateTime());
            Assert.AreEqual(entryRemoteAccess.Name, "");
            Assert.AreNotEqual(entryRemoteAccess.Name, "agsdgsad");
            Assert.IsFalse(entryLocked.AtDesk);
            Assert.IsTrue(entryUnlocked.AtDesk);
        }
        */
        [TestMethod]
        public void DeviceEntryTest()
        {
            Device db = new Device("Device ID", "Device Name", "User ID", "UserName", false);
            Assert.AreEqual(db.DeviceName, "Device Name");
            Assert.AreEqual(db.UserID, "User ID");
            Assert.AreEqual(db.DeviceID, "Device ID");
            Assert.AreEqual(db.UserName, "UserName");
            Assert.AreEqual(db.VM, false);
        }

        [TestMethod]
        public void UserEntryTest()
        {
            User db = new User();

            Assert.AreEqual(db.UserID, null);
            Assert.AreEqual(db.UserName, null);
            Assert.AreNotEqual(db.UserName, "Hi There");
            Assert.AreNotEqual(db.UserName, "Hi There");

            db.UserName = "Hi There";
            db.UserID = "Sup";

            Assert.AreEqual(db.UserID, "Sup");
            Assert.AreEqual(db.UserName, "Hi There");
            Assert.AreNotEqual(db.UserID, null);
            Assert.AreNotEqual(db.UserName, null);
        }
    }
}
