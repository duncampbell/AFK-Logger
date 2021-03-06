﻿using AFKWindowsService.ServiceReference1;
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
        ServiceClient c;

        public AFKLogger()
        {
            CanHandleSessionChangeEvent = true;
            InitializeComponent();

            //Get unique device ID, the windows SID
            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            machineName = Environment.MachineName;

        }
        protected override void OnStart(string[] args)
        {
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            try
            {
                Trace.WriteLine("Session Changed. Details: " + changeDescription.Reason);

                InstanceContext iC = new InstanceContext(this);
                c = new ServiceClient(iC);
                c.ChannelFactory.Faulted += new EventHandler(ChannelFactory_Faulted);

                DataBaseEntry dBE = new DataBaseEntry();
                dBE.EventType = changeDescription.Reason.ToString();
                dBE.DeviceID = deviceID;
                dBE.MachineName = machineName;
                dBE.SessionID = changeDescription.SessionId.ToString();
                dBE.TimeOfEvent = DateTime.Now;
                dBE.AutomaticLock = (changeDescription.Reason == SessionChangeReason.SessionUnlock|| changeDescription.Reason == SessionChangeReason.SessionLogon) ? false:true;
                dBE.RemoteAccess = (changeDescription.Reason == SessionChangeReason.RemoteConnect || changeDescription.Reason == SessionChangeReason.RemoteDisconnect);
                dBE.ETA = new TimeSpan(0,20,0);

                try
                {
                    c.AddServiceEntry(dBE);
                }
                catch(CommunicationException cError)
                {
                    if (c.State == CommunicationState.Faulted)
                    {
                        ChannelFactory_Faulted(this, new EventArgs());
                    }
                }
                
            }
            catch (Exception e)
            {
            }

        }

        private void ChannelFactory_Faulted(object sender, EventArgs e)
        {
            c.ChannelFactory.CreateChannel();
            c.ChannelFactory.Faulted += ChannelFactory_Faulted;
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