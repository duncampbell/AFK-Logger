using AFKWindowsService.ServiceReference1;
using System;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;

namespace AFKWindowsService
{
    public partial class AFKLogger : ServiceBase
    {
        String deviceID;

        System.Diagnostics.EventLog eL;

        public AFKLogger()
        {
            CanHandleSessionChangeEvent = true;
            InitializeComponent();

            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            

            using (ServiceClient c = new ServiceClient())
            {
                Device device = new Device();
                device.DeviceID = deviceID;
                device.DeviceName = Environment.MachineName;
                device.UserName = Environment.UserName;
                device.VM = false;

                c.AddDevice(device);
            }



            eL = new EventLog();
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
            }

            eL.Source = "MySource";
            eL.Log = "MyNewLog";


        }

        protected override void OnStart(string[] args)
        {
            eL.WriteEntry("Started at " + DateTime.Now.ToShortTimeString());
        }

        protected async override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            using(ServiceClient c = new ServiceClient())
            {
                DataBaseEntry dBE = new DataBaseEntry();
                dBE.EventType = changeDescription.Reason.ToString();
                dBE.DeviceID = deviceID;
                dBE.TimeOfEvent = DateTime.Now;
                dBE.AutomaticLock = true;
                dBE.RemoteAccess = System.Windows.Forms.SystemInformation.TerminalServerSession;

                await c.AddEntryAsync(dBE);
                eL.WriteEntry("SessionChangeDescription.Reason: " + changeDescription.Reason);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
