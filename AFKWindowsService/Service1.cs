using AFKWindowsService.ServiceReference1;
using System;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceProcess;
using System.Windows.Forms;

namespace AFKWindowsService
{
    public partial class AFKLogger : ServiceBase, ServiceReference1.IServiceCallback
    {
        String deviceID;
        string machineName;
        EventLog eL;

        public AFKLogger()
        {
            CanHandleSessionChangeEvent = true;
            InitializeComponent();

            //Get unique device ID, the windows SID
            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            machineName = Environment.MachineName;

            #region Test Methods
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
            #endregion

        }
        protected override void OnStart(string[] args)
        {
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            try
            {
                InstanceContext iC = new InstanceContext(this);
                using (ServiceClient c = new ServiceClient(iC))
                {
                    DataBaseEntry dBE = new DataBaseEntry();
                    dBE.EventType = changeDescription.Reason.ToString();
                    dBE.DeviceID = deviceID;
                    dBE.MachineName = machineName;
                    dBE.SessionID = changeDescription.SessionId.ToString();
                    dBE.TimeOfEvent = DateTime.Now;
                    dBE.AutomaticLock = true;
                    dBE.RemoteAccess = true;
                    dBE.ETA = new TimeSpan(0,20,0);
                    if(changeDescription.Reason == SessionChangeReason.ConsoleConnect || changeDescription.Reason == SessionChangeReason.ConsoleDisconnect) { dBE.RemoteAccess = false; }

                    c.AddServiceEntry(dBE);
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

        void IServiceCallback.FinishDataBaseEntry(DataBaseEntry entry)
        {
            //Ignore
        }
    }
}
;