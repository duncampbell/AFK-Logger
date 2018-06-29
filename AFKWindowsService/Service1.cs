using AFKWindowsService.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
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

            deviceID = System.Environment.MachineName;
            userID = System.Environment.UserName;




            eL = new EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "AFKServiceLog");
            }
            eL.Source = "MySource";
            eL.Log = "AFKServiceLog";


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
                eL.WriteEntry(c.GetAllEntries().First().EventType);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
