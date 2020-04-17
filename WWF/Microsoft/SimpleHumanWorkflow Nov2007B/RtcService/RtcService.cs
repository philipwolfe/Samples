//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using RtcActivityLibrary.Interfaces;
using RTCCORELib;
using RtcActivityLibrary.Services;
using SubscriptionService;

namespace RtcActivityLibrary.Services
{
    [Serializable]
    public class RtcService : IRtcCommunication,IRtcGetStatus,IRtcSetStatus, IDisposable
    {
        #region Fields

        private RTCClientClass client;
        private IRTCProfile2 profile;
        private IRTCSession session;
        private IRTCParticipant participant;
        private string uri;
        private string account;
        private string server;
        private string password;
        private int transport;
        private SubscriptionService.SubscriptionService subscriptionService;

        #endregion

        #region Constructors / Initialisers

        public RtcService(string uri, string account, string password, string server, int transport, SubscriptionService.SubscriptionService subscriptionService)
        {
            this.uri = uri;
            this.account = account;
            this.password = password;
            this.server = server;
            this.transport = transport;

            this.subscriptionService = subscriptionService;

            this.InitialiseRtcClient();
        }

        /// <summary>
        /// Initialises the RTC Client
        /// </summary>
        private void InitialiseRtcClient()
        {
            //Initialise the rtc client class
            this.client = new RTCCORELib.RTCClientClass();
            this.client.Initialize();

            //Set the event filter
            this.client.EventFilter = RTCConstants.RTCEF_REGISTRATION_STATE_CHANGE |
                RTCConstants.RTCEF_CLIENT |
                RTCConstants.RTCEF_PROFILE |
                RTCConstants.RTCEF_PRESENCE_PROPERTY |
                RTCConstants.RTCEF_PRESENCE_DATA |
                RTCConstants.RTCEF_MESSAGING;

            this.client.ListenForIncomingSessions = RTCCORELib.RTC_LISTEN_MODE.RTCLM_BOTH;

            this.client.Event += new IRTCDispatchEventNotification_EventEventHandler(client_Event);

            this.client.GetProfile(this.account, this.password, this.uri, this.server, this.transport, 0);
        }

        #endregion

        #region IRtcCommunication Members

        public void SetStatus(RTCCORELib.RTC_PRESENCE_STATUS Status)
        {
            this.client.SetLocalPresenceInfo(Status, string.Empty);
        }

        public RTCCORELib.RTC_PRESENCE_STATUS GetStatus(string Uri)
        {
            return this.client.get_Buddy(Uri).Status;
        }

        public void SendMessage(string Uri, string Message)
        {
            this.session = this.client.CreateSession(RTC_SESSION_TYPE.RTCST_IM, null, null, 0);
            this.participant = this.session.AddParticipant(Uri, string.Empty);
            this.session.SendMessage(string.Empty, Message, 0);
        }

        private event EventHandler<RtcActivityLibrary.Interfaces.RtcMessageEventArgs> rtcMessageReceived;
        public event EventHandler<RtcActivityLibrary.Interfaces.RtcMessageEventArgs> RtcMessageReceived
        {
            add
            {
                rtcMessageReceived += value;
            }
            remove
            {
                rtcMessageReceived -= value;
            }
        }
        private void FireMessageRecieved(RtcActivityLibrary.Interfaces.RtcMessageEventArgs e)
        {
            if (this.rtcMessageReceived != null)
            {
                //We pass null as the sender becasue we cannot serialize the Rtc COM interop stuff.
                this.rtcMessageReceived(null, e);
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (this.session != null)
            {
                this.session.Terminate(RTCCORELib.RTC_TERMINATE_REASON.RTCTR_SHUTDOWN);
            }

            if (this.client != null)
            {
                this.client.PrepareForShutdown();
                this.client.Shutdown();
            }

            this.session = null;
            this.client = null;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handles all events from the client, it is up to us to call the correct methods
        /// </summary>
        private void client_Event(RTCCORELib.RTC_EVENT RTCEvent, object pEvent)
        {
            Console.WriteLine(RTCEvent.ToString());
            switch (RTCEvent)
            {
                case RTCCORELib.RTC_EVENT.RTCE_PROFILE:
                    this.OnProfileEvent(pEvent);
                    break;
                case RTCCORELib.RTC_EVENT.RTCE_MESSAGING:
                    this.OnMessageEvent(pEvent);
                    break;
            }
        }

        /// <summary>
        /// Handles messaging events
        /// </summary>
        private void OnMessageEvent(object pEvent)
        {
            RTCCORELib.IRTCMessagingEvent messagingEvent = (RTCCORELib.IRTCMessagingEvent)pEvent;

            if (messagingEvent.EventType.Equals(RTC_MESSAGING_EVENT_TYPE.RTCMSET_MESSAGE))
            {
                Guid workflowInstanceId = this.subscriptionService.FindInstanceIdBySubscription(
                        typeof(IRtcCommunication),
                        "RtcMessageReceived",
                        new string[] { "Uri" },
                        new object[] { messagingEvent.Participant.UserURI });

                RtcActivityLibrary.Interfaces.RtcMessageEventArgs e = new RtcMessageEventArgs(workflowInstanceId, messagingEvent.Participant.UserURI, messagingEvent.Message);
                            

                this.FireMessageRecieved(e);
            }
        }

        /// <summary>
        /// Handles profile events
        /// </summary>
        private void OnProfileEvent(object pEvent)
        {
            RTCCORELib.IRTCProfileEvent2 profileEvent = (RTCCORELib.IRTCProfileEvent2)pEvent;

            switch (profileEvent.EventType)
            {
                case RTCCORELib.RTC_PROFILE_EVENT_TYPE.RTCPFET_PROFILE_GET:

                    if (profileEvent.StatusCode == 0)
                    {
                        this.profile = (IRTCProfile2)profileEvent.Profile;

                        this.profile.AllowedAuth =
                            RTCConstants.RTCAU_USE_LOGON_CRED |
                            RTCConstants.RTCAU_NTLM |
                            RTCConstants.RTCAU_KERBEROS;

                        // Build the filename for presence storage
                        // Replace all non-alphanumeric characters
                        // in the URI with underscore
                        string uri = Regex.Replace(profile.UserURI, @"\W", "_");
                        StringBuilder sb = new StringBuilder();
                        sb.Append("rtcpresence_").Append(uri).Append(".xml");

                        // Enable presence
                        this.client.EnablePresenceEx(this.profile, sb.ToString(), 0);

                        // Set a presence property
                        string name = "http://schemas.microsoft.com/rtc/rtcpresence";
                        string val = "<name> rtcpresence </rtcpresence>";
                        this.client.SetPresenceData(name, val);

                        string deviceName = System.Environment.MachineName + " (RTCPresence)";
                        this.client.set_PresenceProperty(RTC_PRESENCE_PROPERTY.RTCPP_DEVICE_NAME, deviceName);

                        this.client.OfferWatcherMode = RTC_OFFER_WATCHER_MODE.RTCOWM_AUTOMATICALLY_ADD_WATCHER;

                        this.client.EnableProfileEx(profile,
                           RTCConstants.RTCRF_REGISTER_ALL,
                           RTCConstants.RTCRMF_BUDDY_ROAMING |
                           RTCConstants.RTCRMF_WATCHER_ROAMING |
                           RTCConstants.RTCRMF_PRESENCE_ROAMING |
                           RTCConstants.RTCRMF_PROFILE_ROAMING
                           );
                    }

                    break;
            }
        }

        #endregion
    }
}
