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
    public partial class Service1 : ServiceBase
    {
        String deviceID;
        String userID;
        public Service1()
        {
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

            }
        }

        protected override void OnStop()
        {
        }
    }
}
