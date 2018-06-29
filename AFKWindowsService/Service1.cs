using AFKWindowsService.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AFKWindowsService
{
    public partial class AFKLogger : ServiceBase
    {
        String deviceID;
        String userID;

        System.Diagnostics.EventLog eL;

        public AFKLogger()
        {
            CanHandleSessionChangeEvent = true;
            InitializeComponent();

            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            userID = WindowsIdentity.GetCurrent().User.AccountDomainSid.ToString();

            using (ServiceClient c = new ServiceClient())
            {
                Device device = new Device();
                device.DeviceID = deviceID;
                device.DeviceName = Environment.MachineName;
                device.UserID = userID;
                device.UserName = Environment.UserName;
                device.VM = false;

                c.AddDevice(device);
            }



            eL = new EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "MyNewLog");
            }
            eL.Source = "MySource";
            eL.Log = "MyNewLog";


        }

        protected override void OnStart(string[] args)
        {
            eL.WriteEntry("Started at " + DateTime.Now.ToShortTimeString() + "\n UserID: " + userID + "\n DeviceID: " + deviceID);
        }

        protected async override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            using(ServiceClient c = new ServiceClient())
            {
                DataBaseEntry dBE = new DataBaseEntry();
                dBE.EventType = changeDescription.Reason.ToString();
                dBE.DeviceID = deviceID;
                dBE.UserID = userID;
                dBE.TimeOfEvent = DateTime.Now;
                dBE.AutomaticLock = true;
                dBE.RemoteAccess = System.Windows.Forms.SystemInformation.TerminalServerSession;

                await c.AddEntryAsync(dBE);
                //eL.WriteEntry(c.GetAllEntries().First().EventType);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
