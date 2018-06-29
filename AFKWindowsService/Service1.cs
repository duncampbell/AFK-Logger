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
        public AFKLogger()
        {
            CanHandleSessionChangeEvent = true;
            InitializeComponent();

            deviceID = System.Environment.MachineName;
            userID = System.Environment.UserName;
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
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

                c.AddEntry(dBE);
                c.GetAllEntries();
            }
        }

        protected override void OnStop()
        {
        }
    }
}
