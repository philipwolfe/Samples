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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using SMTPMailActivityLibrary;
using DirectoryLookupActivityLibrary;
using System.Xml;
using System.Configuration;

namespace LeaveWorkflows
{
	public sealed partial class LeaveWorkflow: SequentialWorkflowActivity
	{



        public string leaveServiceEmailAddress = "chris@fabrikam.com";

        public string declineBody = "Your leave request for the period <%/leaveRequest/startDate%> to <%/leaveRequest/endDate%> has been declined by <%/leaveRequest/responseFrom%>.";
        public string acceptBody = "Your leave request for the period <%/leaveRequest/startDate%> to <%/leaveRequest/endDate%> has been approved by <%/leaveRequest/responseFrom%>.";

        public string mailToManagerBody = "<%/leaveRequest/applicantAccount%> has requested leave for the period <%/leaveRequest/startDate%> to <%/leaveRequest/endDate%>." + Environment.NewLine + "Comment attached to the request:" + Environment.NewLine + "<%/leaveRequest/leaveComment%>" + Environment.NewLine + Environment.NewLine + "To approve this request reply with 'Approved', to decline this request reply with 'Declined'.";
        public string mailToGrandManagerBody = "<%/leaveRequest/applicantAccount%> has requested leave for the period <%/leaveRequest/startDate%> to <%/leaveRequest/endDate%>. This request has been escalated to you because it timed out while waiting for their manager, <%/leaveRequest/responseFrom%>." + Environment.NewLine + "Comment attached to the request:" + Environment.NewLine + "<%/leaveRequest/leaveComment%>" + Environment.NewLine + Environment.NewLine + "To approve this request reply with 'Approved', to decline this request reply with 'Declined'.";
        public string ManagerTimeoutBody = "Your leave request for the period <%/leaveRequest/startDate%> to <%/leaveRequest/endDate%> has timed out while waiting for a reply.";

        public string notifyPeersBody = "This email is to let you know that your colleague, <%/leaveRequest/applicantAccount%>, is taking leave for the period <%/leaveRequest/startDate%> to <%/leaveRequest/endDate%>.";

        public string approvedRegex = "(^|[^'])Approved($|[^'])";

        public XmlDocument leaveXmlData;

        private string ldapUri = "";
        public string LdapUri
        {
            get { return ldapUri; }
            set { ldapUri = value; }
        }

        string applicantAccount;
        public string ApplicantAccount
        {
            get { return applicantAccount; }
            set { applicantAccount = value; }
        }

        private string applicantEMail;
        public string ApplicantEMail
        {
            get { return applicantEMail; }
            set { applicantEMail = value; }
        }

        private string leaveComment;
        public string LeaveComment
        {
            get { return leaveComment; }
            set { leaveComment = value; }
        }

        private bool approved;
        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private string coordinatingEmailAddress;
        public string CoordinatingEmailAddress
        {
            get { return coordinatingEmailAddress; }
            set { coordinatingEmailAddress = value; }
        }


        public LeaveWorkflow()
        {
            InitializeComponent();

        }

        private void IsManagerOnline(object sender, ConditionalEventArgs e)
        {
            e.Result = checkManagerStatus.ReturnValue == RTCCORELib.RTC_PRESENCE_STATUS.RTCXS_PRESENCE_ONLINE;
        }


        private void setManagerRtcReceived_ExecuteCode(object sender, EventArgs e)
        {
            this.Approved = managerRtcReceived.RegexMatched;
            SetResponseFrom(lookupManagerDetails.RetrievedUserData.AccountName);
        }

        private bool replied = false;
        private void isManagerRtcReceived(object sender, ConditionalEventArgs e)
        {
            e.Result = managerRtcReceived.Message != null && managerRtcReceived.Message.Length > 0;
            replied = e.Result;
        }

        public Guid managerEmailId = Guid.NewGuid();

        private void setManagerEmailReceived_ExecuteCode(object sender, EventArgs e)
        {
            this.Approved = managerEmailReceived.RegexMatched;
            SetResponseFrom(lookupManagerDetails.RetrievedUserData.AccountName);
        }

        private void IsManagerReplied(object sender, ConditionalEventArgs e)
        {
            e.Result = (managerRtcReceived.Message != null && managerRtcReceived.Message.Length > 0) || (e.Result = managerEmailReceived.Body != null && managerEmailReceived.Body.Length > 0) ;
            replied = e.Result;
        }

        private void notifyPeersReplicator_ChildInitialized(object sender, ReplicatorChildEventArgs e)
        {
            SequenceActivity childSequence = e.Activity as SequenceActivity;
            UserDetailsLookupActivity lookupActivity = childSequence.Activities["lookupPeerDetails"] as UserDetailsLookupActivity;
            lookupActivity.Query = e.InstanceData.ToString();
        }

        private void SetResponseFrom(string responder)
        {
            leaveXmlData.SelectSingleNode("/leaveRequest/responseFrom").InnerText = responder;
        }

        private void LeaveWorkflow_Initialized(object sender, EventArgs e)
        {
            //Build the XmlData document.
            leaveXmlData = new XmlDocument();
            leaveXmlData.LoadXml(
                "<leaveRequest>" +
                    "<applicantAccount>" +
                        applicantAccount +
                    "</applicantAccount>" +
                    "<applicantEMail>" +
                        applicantEMail +
                    "</applicantEMail>" +
                    "<leaveComment>" +
                        leaveComment +
                    "</leaveComment>" +
                    "<startDate>" +
                        startDate.ToShortDateString() +
                    "</startDate>" +
                    "<endDate>" +
                        endDate.ToShortDateString() +
                    "</endDate>" +
                    "<responseFrom/>" +
                "</leaveRequest>"
                );  
        }

        public Guid grandManagerEmailId = Guid.NewGuid();

        private void setGrandManagerEmailReceived_ExecuteCode(object sender, EventArgs e)
        {
            this.Approved = grandManagerEmailReceived.RegexMatched;
            SetResponseFrom(lookupGrandManagerDetails.RetrievedUserData.AccountName);
        }

	}

}
