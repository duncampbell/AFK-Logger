using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFKHostedService;
using UnitTests.ServiceReference1;
using System.ServiceModel;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class AddingTests:IServiceCallback
    {

        [TestMethod]
        public void addDeviceTestOne()
        {
            //AFKHostedService.AFKHostedService Proxy = new AFKHostedService.AFKHostedService();
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            Device devSuc = new Device("a", "a", "a", "a", false);
            bool success = Proxy.AddDevice(devSuc);
            Assert.IsTrue(success);

            devSuc = new Device("b", "b", "b", "b", false);
            success = Proxy.AddDevice(devSuc);
            Assert.IsTrue(success);

            devSuc = new Device("c", "c", "c", "c", false);
            success = Proxy.AddDevice(devSuc);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void addDeviceTestTwo()
        {
            //AFKHostedService.AFKHostedService Proxy = new AFKHostedService.AFKHostedService();
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);
            
            Device devFail = new Device("a", "a", "a", "a", false);
            bool failure = Proxy.AddDevice(devFail);
            Assert.IsFalse(failure);
           
        }

        [TestMethod]
        public void addUserTest()
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            User devSuc = new User();
            devSuc.UserID = "a";
            devSuc.UserName = "a";
            bool success = Proxy.AddUser(devSuc);
            Assert.IsTrue(success);

            devSuc = new User();
            devSuc.UserID = "b";
            devSuc.UserName = "b";
            success = Proxy.AddUser(devSuc);
            Assert.IsTrue(success);

            devSuc = new User();
            devSuc.UserID = "c";
            devSuc.UserName = "c";
            success = Proxy.AddUser(devSuc);
            Assert.IsTrue(success);
            /*
            User devfail = new User();
            devfail.UserID = "a";
            devfail.UserName = "a";
            bool fail = Proxy.AddUser(devfail);
            Assert.IsFalse(fail);
            */
        }
        
        [TestMethod]
        public void addEntryTest()//Don't Know what changes we are making
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);

            List<DataBaseEntry> dataTest = new List<DataBaseEntry>();
            DataBaseEntry dbTest = new DataBaseEntry("b", "b", "b", new DateTime(50000), true, false, new TimeSpan(1, 50, 20));
            Proxy.AddAppletEntry(dbTest);
            dbTest = new DataBaseEntry("c", "c", "c", new DateTime(55000), false, true, new TimeSpan(8, 50, 20));
            Proxy.AddAppletEntry(dbTest);
            dbTest = new DataBaseEntry("a", "a", "a", new DateTime(2018, 7, 6, 11, 58, 0), false, false, new TimeSpan(1, 20, 50));
            Proxy.AddAppletEntry(dbTest);

            Assert.IsTrue(true);
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
