using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFKHostedService;
using UnitTests.ServiceReference1;
using System.ServiceModel;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class AddingTests
    {

        [TestMethod]
        public void addDeviceTest()
        {
            //AFKHostedService.AFKHostedService Proxy = new AFKHostedService.AFKHostedService();
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            Device devSuc = new Device("Device ID", "Device Name", "User ID", "UserName", false);
            bool success = Proxy.AddDevice(devSuc);
            Assert.IsTrue(success);

            Device devFail = new Device("Device ID", "Device Name", "User ID", "UserName", false);
            bool failure = Proxy.AddDevice(devFail);
            Assert.IsFalse(failure);
        }

        [TestMethod]
        public void addUserTest()
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            User devSuc = new User();
            devSuc.UserID = "User ID";
            devSuc.UserName = "User Name";
            bool success = Proxy.AddUser(devSuc);
            Assert.IsTrue(success);

            User devfail = new User();
            devfail.UserID = "User ID";
            devfail.UserName = "User Name";
            bool fail = Proxy.AddUser(devfail);
            Assert.IsFalse(fail);
        }
        
        [TestMethod]
        public void addEntryTest()//Don't Know what changes we are making
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);
            Proxy.ClearAllDatabases();

            DataBaseEntry dbTest = new DataBaseEntry("Event Type", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            Proxy.AddAppletEntry(dbTest);
            dbTest = new DataBaseEntry("Event Type", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan());
            Proxy.AddAppletEntry(dbTest);
            dbTest = new DataBaseEntry("Event Type1", "User ID", "Device ID", new DateTime(), false, false, new TimeSpan(1, 20, 50));
            Proxy.AddAppletEntry(dbTest);

            Assert.IsTrue(true);
        }
    }
}
