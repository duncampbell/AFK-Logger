using AFKWindowsService.ServiceReference1;
using System;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceProcess;

namespace AFKWindowsService
{
    public partial class AFKLogger : ServiceBase, ServiceReference1.IServiceCallback
    {
        String deviceID;

        EventLog eL;

        public AFKLogger()
        {
            CanHandleSessionChangeEvent = true;
            InitializeComponent();

            //Get unique device ID, the windows SID
            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();

            //TESTING: creates device
            InstanceContext iC = new System.ServiceModel.InstanceContext(this);
            using (ServiceClient c = new ServiceClient(iC))
            {
                Device device = new Device();
                device.DeviceID = deviceID;
                device.DeviceName = Environment.MachineName;
                device.UserName = Environment.UserName;
                device.VM = false;

                //c.AddDevice(device);
            }


            //TESTING: event log serves as console output
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
            try
            {
                InstanceContext iC = new InstanceContext(this);
                using (ServiceClient c = new ServiceClient(iC))
                {
                    DataBaseEntry dBE = new DataBaseEntry();
                    dBE.EventType = changeDescription.Reason.ToString();
                    dBE.DeviceID = deviceID;
                    dBE.TimeOfEvent = DateTime.Now;
                    dBE.AutomaticLock = true;
                    dBE.RemoteAccess = true;
                    if(changeDescription.Reason == SessionChangeReason.ConsoleConnect || changeDescription.Reason == SessionChangeReason.ConsoleDisconnect) { dBE.RemoteAccess = false; }

                    await c.AddEntryAsync(dBE);
                    eL.WriteEntry("SessionChangeDescription.Reason: " + changeDescription.Reason);
                }
            }
            catch (Exception e)
            {
                eL.WriteEntry(e.Message);
            }

        }

        protected override void OnStop()
        {
        }

        public void SendResult(string test)
        {
            //throw new NotImplementedException();
        }

        public DataBaseEntry FinishDataBaseEntry(DataBaseEntry entry)
        {
            eL.WriteEntry("Callback Method Triggered");
            return new DataBaseEntry();
        }
    }
}
