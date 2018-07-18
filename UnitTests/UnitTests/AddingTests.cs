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
    public class AddingTests:IServiceCallback
    {
        [TestMethod]
        public void addDevices()
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\duncanc\Documents\WriteLines.txt");
            for (int i = 0; i < 80; i++)
            {
                string name = RandomNameGenerator.NameGenerator.Generate(RandomNameGenerator.Gender.Male);
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                Random r = new Random();
                string ID = new string(Enumerable.Repeat(chars, 20).Select(s => s[r.Next(s.Length)]).ToArray());
                string deviceID = new string(Enumerable.Repeat(chars, 20).Select(s => s[r.Next(s.Length)]).ToArray());
                string deviceName = new string(Enumerable.Repeat(chars, 8).Select(s => s[r.Next(s.Length)]).ToArray());
                Device devSuc = new Device(deviceID, deviceName, ID, name, false);
                Proxy.AddDevice(devSuc);
                string sessionID = new string(Enumerable.Repeat(chars, 20).Select(s => s[r.Next(s.Length)]).ToArray());
                DataBaseEntry z = new DataBaseEntry(name, "SessionUnlock", ID, deviceID, deviceName, sessionID, DateTime.Now, false, false, new TimeSpan(0, 0, 0));
                file.WriteLine(z.UserName + ":" + z.EventType + ":" + z.UserID + ":" + z.DeviceID + ":" + z.MachineName + ":" + z.SessionID + ":" + z.TimeOfEvent + ":" + z.AutomaticLock + ":" + z.RemoteAccess + ":" + z.ETA);
            }
        }
        [TestMethod]
        public void addEntries()
        {
            bool yes = true;
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\duncanc\Documents\WriteLines.txt");
            //Proxy.AddAppletEntry(z);
            foreach (string line in lines)
            {
                DataBaseEntry x;
                string[] parts = line.Split(':');
                if (yes)
                {
                   x = new DataBaseEntry(parts[0], "SessionUnlock", parts[2], parts[3], parts[4], parts[5], DateTime.Now, false, false, new TimeSpan(0,0,0));
                }
                else
                {
                    x = new DataBaseEntry(parts[0], "SessionLock", parts[2], parts[3], parts[4], parts[5], DateTime.Now, false, false, new TimeSpan(0,5,0));
                }
                yes = !yes;
                Proxy.AddAppletEntry(x);
            }

        }



        [TestMethod]
        public void addDeviceTestOne()
        {
            string name = RandomNameGenerator.NameGenerator.Generate(RandomNameGenerator.Gender.Male);
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
        /*
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
