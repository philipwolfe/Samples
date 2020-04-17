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
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace LeaveWorkflows
{
	public sealed partial class LeaveWorkflow
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken3 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken4 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken5 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken6 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind23 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind24 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind25 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind26 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind27 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind28 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind29 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind30 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind31 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind32 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind33 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind34 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind35 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind36 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind37 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind38 = new System.Workflow.ComponentModel.ActivityBind();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.grandManagerEmailReceived = new SMTPMailActivityLibrary.SmtpMailReceived();
            this.eventDrivenActivity4 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity3 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.sendEmail1 = new SMTPMailActivityLibrary.SendEmail();
            this.lookupGrandManagerDetails = new DirectoryLookupActivityLibrary.UserDetailsLookupActivity();
            this.managerEmailDelay = new System.Workflow.Activities.DelayActivity();
            this.setManagerEmailReceived = new System.Workflow.Activities.CodeActivity();
            this.managerEmailReceived = new SMTPMailActivityLibrary.SmtpMailReceived();
            this.managerRtcDelay = new System.Workflow.Activities.DelayActivity();
            this.setManagerRtcReceived = new System.Workflow.Activities.CodeActivity();
            this.managerRtcReceived = new RtcActivityLibrary.RtcMessageReceived();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventManagerRtcTimeout = new System.Workflow.Activities.EventDrivenActivity();
            this.eventManagerRtcReply = new System.Workflow.Activities.EventDrivenActivity();
            this.sendTimeoutEmail = new SMTPMailActivityLibrary.SendEmail();
            this.sendDeclinedEmail = new SMTPMailActivityLibrary.SendEmail();
            this.sendApprovedEmail = new SMTPMailActivityLibrary.SendEmail();
            this.listenForManagerEmailReply = new System.Workflow.Activities.ListenActivity();
            this.emailManager = new SMTPMailActivityLibrary.SendEmail();
            this.listenForManagerRtcReply = new System.Workflow.Activities.ListenActivity();
            this.rtcMessageManager = new RtcActivityLibrary.SendMessage();
            this.elseTimedOutBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.isDeclinedBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.isApprovedBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.elseManagerNoRtcReply = new System.Workflow.Activities.IfElseBranchActivity();
            this.isManagerRtcReplied = new System.Workflow.Activities.IfElseBranchActivity();
            this.elseNotManagerOnline = new System.Workflow.Activities.IfElseBranchActivity();
            this.isManagerOnline = new System.Workflow.Activities.IfElseBranchActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.ifApproved = new System.Workflow.Activities.IfElseActivity();
            this.ifManagerRtcReplied = new System.Workflow.Activities.IfElseActivity();
            this.ifManagerOnline = new System.Workflow.Activities.IfElseActivity();
            this.checkManagerStatus = new RtcActivityLibrary.GetStatus();
            this.lookupManagerDetails = new DirectoryLookupActivityLibrary.UserDetailsLookupActivity();
            this.lookupManager = new DirectoryLookupActivityLibrary.DirectoryLookupActivity();
            this.setAgentStatus = new RtcActivityLibrary.SetStatus();
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:05:00");
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.setGrandManagerEmailReceived_ExecuteCode);
            // 
            // grandManagerEmailReceived
            // 
            this.grandManagerEmailReceived.Body = null;
            correlationtoken1.Name = "grandManagerToken";
            correlationtoken1.OwnerActivityName = "eventDrivenActivity2";
            this.grandManagerEmailReceived.CorrelationToken = correlationtoken1;
            this.grandManagerEmailReceived.From = null;
            this.grandManagerEmailReceived.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            activitybind1.Name = "LeaveWorkflow";
            activitybind1.Path = "grandManagerEmailId";
            this.grandManagerEmailReceived.Name = "grandManagerEmailReceived";
            activitybind2.Name = "LeaveWorkflow";
            activitybind2.Path = "approvedRegex";
            this.grandManagerEmailReceived.Subject = null;
            this.grandManagerEmailReceived.To = null;
            this.grandManagerEmailReceived.SetBinding(SMTPMailActivityLibrary.SmtpMailReceived.RegexProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.grandManagerEmailReceived.SetBinding(SMTPMailActivityLibrary.SmtpMailReceived.MessageIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // eventDrivenActivity4
            // 
            this.eventDrivenActivity4.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity4.Name = "eventDrivenActivity4";
            // 
            // eventDrivenActivity3
            // 
            this.eventDrivenActivity3.Activities.Add(this.grandManagerEmailReceived);
            this.eventDrivenActivity3.Activities.Add(this.codeActivity1);
            this.eventDrivenActivity3.Name = "eventDrivenActivity3";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity3);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity4);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // sendEmail1
            // 
            activitybind3.Name = "LeaveWorkflow";
            activitybind3.Path = "mailToGrandManagerBody";
            this.sendEmail1.CorrelationToken = correlationtoken1;
            activitybind4.Name = "LeaveWorkflow";
            activitybind4.Path = "CoordinatingEmailAddress";
            this.sendEmail1.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            activitybind5.Name = "LeaveWorkflow";
            activitybind5.Path = "grandManagerEmailId";
            this.sendEmail1.Name = "sendEmail1";
            this.sendEmail1.Subject = "Leave Request";
            activitybind6.Name = "lookupGrandManagerDetails";
            activitybind6.Path = "RetrievedUserData.Mail";
            activitybind7.Name = "LeaveWorkflow";
            activitybind7.Path = "leaveXmlData";
            this.sendEmail1.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.sendEmail1.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.sendEmail1.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.sendEmail1.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.sendEmail1.SetBinding(SMTPMailActivityLibrary.SendEmail.MessageIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // lookupGrandManagerDetails
            // 
            activitybind8.Name = "LeaveWorkflow";
            activitybind8.Path = "LdapUri";
            this.lookupGrandManagerDetails.Name = "lookupGrandManagerDetails";
            activitybind9.Name = "lookupManagerDetails";
            activitybind9.Path = "RetrievedUserData.Manager";
            this.lookupGrandManagerDetails.QuerySource = DirectoryLookupActivityLibrary.ADActivityLookupSource.XmlFile;
            this.lookupGrandManagerDetails.RetrievedUserData = null;
            this.lookupGrandManagerDetails.SetBinding(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.DirectoryUriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.lookupGrandManagerDetails.SetBinding(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.QueryProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            // 
            // managerEmailDelay
            // 
            this.managerEmailDelay.Name = "managerEmailDelay";
            this.managerEmailDelay.TimeoutDuration = System.TimeSpan.Parse("00:05:00");
            // 
            // setManagerEmailReceived
            // 
            this.setManagerEmailReceived.Name = "setManagerEmailReceived";
            this.setManagerEmailReceived.ExecuteCode += new System.EventHandler(this.setManagerEmailReceived_ExecuteCode);
            // 
            // managerEmailReceived
            // 
            this.managerEmailReceived.Body = null;
            correlationtoken2.Name = "managerEmailToken";
            correlationtoken2.OwnerActivityName = "elseManagerNoRtcReply";
            this.managerEmailReceived.CorrelationToken = correlationtoken2;
            this.managerEmailReceived.From = null;
            this.managerEmailReceived.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            activitybind10.Name = "LeaveWorkflow";
            activitybind10.Path = "managerEmailId";
            this.managerEmailReceived.Name = "managerEmailReceived";
            activitybind11.Name = "LeaveWorkflow";
            activitybind11.Path = "approvedRegex";
            this.managerEmailReceived.Subject = null;
            this.managerEmailReceived.To = null;
            this.managerEmailReceived.SetBinding(SMTPMailActivityLibrary.SmtpMailReceived.MessageIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.managerEmailReceived.SetBinding(SMTPMailActivityLibrary.SmtpMailReceived.RegexProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // managerRtcDelay
            // 
            this.managerRtcDelay.Name = "managerRtcDelay";
            this.managerRtcDelay.TimeoutDuration = System.TimeSpan.Parse("00:01:00");
            // 
            // setManagerRtcReceived
            // 
            this.setManagerRtcReceived.Name = "setManagerRtcReceived";
            this.setManagerRtcReceived.ExecuteCode += new System.EventHandler(this.setManagerRtcReceived_ExecuteCode);
            // 
            // managerRtcReceived
            // 
            correlationtoken3.Name = "managerRtcToken";
            correlationtoken3.OwnerActivityName = "isManagerOnline";
            this.managerRtcReceived.CorrelationToken = correlationtoken3;
            this.managerRtcReceived.Message = null;
            this.managerRtcReceived.Name = "managerRtcReceived";
            activitybind12.Name = "LeaveWorkflow";
            activitybind12.Path = "approvedRegex";
            activitybind13.Name = "lookupManagerDetails";
            activitybind13.Path = "RetrievedUserData.RtcSipAddress";
            this.managerRtcReceived.SetBinding(RtcActivityLibrary.RtcMessageReceived.UriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.managerRtcReceived.SetBinding(RtcActivityLibrary.RtcMessageReceived.RegexProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.managerEmailDelay);
            this.eventDrivenActivity2.Activities.Add(this.lookupGrandManagerDetails);
            this.eventDrivenActivity2.Activities.Add(this.sendEmail1);
            this.eventDrivenActivity2.Activities.Add(this.listenActivity1);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.managerEmailReceived);
            this.eventDrivenActivity1.Activities.Add(this.setManagerEmailReceived);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // eventManagerRtcTimeout
            // 
            this.eventManagerRtcTimeout.Activities.Add(this.managerRtcDelay);
            this.eventManagerRtcTimeout.Name = "eventManagerRtcTimeout";
            // 
            // eventManagerRtcReply
            // 
            this.eventManagerRtcReply.Activities.Add(this.managerRtcReceived);
            this.eventManagerRtcReply.Activities.Add(this.setManagerRtcReceived);
            this.eventManagerRtcReply.Name = "eventManagerRtcReply";
            // 
            // sendTimeoutEmail
            // 
            activitybind14.Name = "LeaveWorkflow";
            activitybind14.Path = "ManagerTimeoutBody";
            correlationtoken4.Name = "resultToken";
            correlationtoken4.OwnerActivityName = "elseTimedOutBranch";
            this.sendTimeoutEmail.CorrelationToken = correlationtoken4;
            activitybind15.Name = "LeaveWorkflow";
            activitybind15.Path = "CoordinatingEmailAddress";
            this.sendTimeoutEmail.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            this.sendTimeoutEmail.MessageId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.sendTimeoutEmail.Name = "sendTimeoutEmail";
            this.sendTimeoutEmail.Subject = "Leave Declined";
            activitybind16.Name = "LeaveWorkflow";
            activitybind16.Path = "ApplicantEMail";
            activitybind17.Name = "LeaveWorkflow";
            activitybind17.Path = "leaveXmlData";
            this.sendTimeoutEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.sendTimeoutEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.sendTimeoutEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.sendTimeoutEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // sendDeclinedEmail
            // 
            activitybind18.Name = "LeaveWorkflow";
            activitybind18.Path = "declineBody";
            correlationtoken5.Name = "resultDeclinedToken";
            correlationtoken5.OwnerActivityName = "isDeclinedBranch";
            this.sendDeclinedEmail.CorrelationToken = correlationtoken5;
            activitybind19.Name = "LeaveWorkflow";
            activitybind19.Path = "CoordinatingEmailAddress";
            this.sendDeclinedEmail.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            this.sendDeclinedEmail.MessageId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.sendDeclinedEmail.Name = "sendDeclinedEmail";
            this.sendDeclinedEmail.Subject = "Leave Declined";
            activitybind20.Name = "LeaveWorkflow";
            activitybind20.Path = "ApplicantEMail";
            activitybind21.Name = "LeaveWorkflow";
            activitybind21.Path = "leaveXmlData";
            this.sendDeclinedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            this.sendDeclinedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            this.sendDeclinedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.sendDeclinedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            // 
            // sendApprovedEmail
            // 
            activitybind22.Name = "LeaveWorkflow";
            activitybind22.Path = "acceptBody";
            correlationtoken6.Name = "resultApprovedToken";
            correlationtoken6.OwnerActivityName = "isApprovedBranch";
            this.sendApprovedEmail.CorrelationToken = correlationtoken6;
            activitybind23.Name = "LeaveWorkflow";
            activitybind23.Path = "CoordinatingEmailAddress";
            this.sendApprovedEmail.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            this.sendApprovedEmail.MessageId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.sendApprovedEmail.Name = "sendApprovedEmail";
            this.sendApprovedEmail.Subject = "Leave Approved";
            activitybind24.Name = "LeaveWorkflow";
            activitybind24.Path = "ApplicantEMail";
            activitybind25.Name = "LeaveWorkflow";
            activitybind25.Path = "leaveXmlData";
            this.sendApprovedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            this.sendApprovedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            this.sendApprovedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            this.sendApprovedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            // 
            // listenForManagerEmailReply
            // 
            this.listenForManagerEmailReply.Activities.Add(this.eventDrivenActivity1);
            this.listenForManagerEmailReply.Activities.Add(this.eventDrivenActivity2);
            this.listenForManagerEmailReply.Name = "listenForManagerEmailReply";
            // 
            // emailManager
            // 
            activitybind26.Name = "LeaveWorkflow";
            activitybind26.Path = "mailToManagerBody";
            this.emailManager.CorrelationToken = correlationtoken2;
            activitybind27.Name = "LeaveWorkflow";
            activitybind27.Path = "CoordinatingEmailAddress";
            this.emailManager.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            activitybind28.Name = "LeaveWorkflow";
            activitybind28.Path = "managerEmailId";
            this.emailManager.Name = "emailManager";
            this.emailManager.Subject = "Leave Request";
            activitybind29.Name = "lookupManagerDetails";
            activitybind29.Path = "RetrievedUserData.Mail";
            activitybind30.Name = "LeaveWorkflow";
            activitybind30.Path = "leaveXmlData";
            this.emailManager.SetBinding(SMTPMailActivityLibrary.SendEmail.MessageIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind28)));
            this.emailManager.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind27)));
            this.emailManager.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind29)));
            this.emailManager.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind26)));
            this.emailManager.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind30)));
            // 
            // listenForManagerRtcReply
            // 
            this.listenForManagerRtcReply.Activities.Add(this.eventManagerRtcReply);
            this.listenForManagerRtcReply.Activities.Add(this.eventManagerRtcTimeout);
            this.listenForManagerRtcReply.Name = "listenForManagerRtcReply";
            // 
            // rtcMessageManager
            // 
            this.rtcMessageManager.CorrelationToken = correlationtoken3;
            activitybind31.Name = "LeaveWorkflow";
            activitybind31.Path = "mailToManagerBody";
            this.rtcMessageManager.Name = "rtcMessageManager";
            activitybind32.Name = "lookupManagerDetails";
            activitybind32.Path = "RetrievedUserData.RtcSipAddress";
            activitybind33.Name = "LeaveWorkflow";
            activitybind33.Path = "leaveXmlData";
            this.rtcMessageManager.SetBinding(RtcActivityLibrary.SendMessage.MessageProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind31)));
            this.rtcMessageManager.SetBinding(RtcActivityLibrary.SendMessage.UriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind32)));
            this.rtcMessageManager.SetBinding(RtcActivityLibrary.SendMessage.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind33)));
            // 
            // elseTimedOutBranch
            // 
            this.elseTimedOutBranch.Activities.Add(this.sendTimeoutEmail);
            this.elseTimedOutBranch.Name = "elseTimedOutBranch";
            // 
            // isDeclinedBranch
            // 
            this.isDeclinedBranch.Activities.Add(this.sendDeclinedEmail);
            ruleconditionreference1.ConditionName = "isNotApproved";
            this.isDeclinedBranch.Condition = ruleconditionreference1;
            this.isDeclinedBranch.Name = "isDeclinedBranch";
            // 
            // isApprovedBranch
            // 
            this.isApprovedBranch.Activities.Add(this.sendApprovedEmail);
            ruleconditionreference2.ConditionName = "isApproved";
            this.isApprovedBranch.Condition = ruleconditionreference2;
            this.isApprovedBranch.Name = "isApprovedBranch";
            // 
            // elseManagerNoRtcReply
            // 
            this.elseManagerNoRtcReply.Activities.Add(this.emailManager);
            this.elseManagerNoRtcReply.Activities.Add(this.listenForManagerEmailReply);
            this.elseManagerNoRtcReply.Name = "elseManagerNoRtcReply";
            // 
            // isManagerRtcReplied
            // 
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.isManagerRtcReceived);
            this.isManagerRtcReplied.Condition = codecondition1;
            this.isManagerRtcReplied.Name = "isManagerRtcReplied";
            // 
            // elseNotManagerOnline
            // 
            this.elseNotManagerOnline.Name = "elseNotManagerOnline";
            // 
            // isManagerOnline
            // 
            this.isManagerOnline.Activities.Add(this.rtcMessageManager);
            this.isManagerOnline.Activities.Add(this.listenForManagerRtcReply);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IsManagerOnline);
            this.isManagerOnline.Condition = codecondition2;
            this.isManagerOnline.Name = "isManagerOnline";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // ifApproved
            // 
            this.ifApproved.Activities.Add(this.isApprovedBranch);
            this.ifApproved.Activities.Add(this.isDeclinedBranch);
            this.ifApproved.Activities.Add(this.elseTimedOutBranch);
            this.ifApproved.Name = "ifApproved";
            // 
            // ifManagerRtcReplied
            // 
            this.ifManagerRtcReplied.Activities.Add(this.isManagerRtcReplied);
            this.ifManagerRtcReplied.Activities.Add(this.elseManagerNoRtcReply);
            this.ifManagerRtcReplied.Name = "ifManagerRtcReplied";
            // 
            // ifManagerOnline
            // 
            this.ifManagerOnline.Activities.Add(this.isManagerOnline);
            this.ifManagerOnline.Activities.Add(this.elseNotManagerOnline);
            this.ifManagerOnline.Name = "ifManagerOnline";
            // 
            // checkManagerStatus
            // 
            this.checkManagerStatus.Name = "checkManagerStatus";
            this.checkManagerStatus.ReturnValue = RTCCORELib.RTC_PRESENCE_STATUS.RTCXS_PRESENCE_OFFLINE;
            activitybind34.Name = "lookupManagerDetails";
            activitybind34.Path = "RetrievedUserData.RtcSipAddress";
            this.checkManagerStatus.SetBinding(RtcActivityLibrary.GetStatus.UriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind34)));
            // 
            // lookupManagerDetails
            // 
            activitybind35.Name = "LeaveWorkflow";
            activitybind35.Path = "LdapUri";
            this.lookupManagerDetails.Name = "lookupManagerDetails";
            activitybind36.Name = "lookupManager";
            activitybind36.Path = "QueryResults[0]";
            this.lookupManagerDetails.QuerySource = DirectoryLookupActivityLibrary.ADActivityLookupSource.XmlFile;
            this.lookupManagerDetails.RetrievedUserData = null;
            this.lookupManagerDetails.SetBinding(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.DirectoryUriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind35)));
            this.lookupManagerDetails.SetBinding(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.QueryProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind36)));
            // 
            // lookupManager
            // 
            activitybind37.Name = "LeaveWorkflow";
            activitybind37.Path = "LdapUri";
            this.lookupManager.Name = "lookupManager";
            activitybind38.Name = "LeaveWorkflow";
            activitybind38.Path = "ApplicantAccount";
            this.lookupManager.QuerySource = DirectoryLookupActivityLibrary.ADActivityLookupSource.XmlFile;
            this.lookupManager.SetBinding(DirectoryLookupActivityLibrary.DirectoryLookupActivity.DirectoryUriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind37)));
            this.lookupManager.SetBinding(DirectoryLookupActivityLibrary.DirectoryLookupActivity.QueryProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind38)));
            // 
            // setAgentStatus
            // 
            this.setAgentStatus.Name = "setAgentStatus";
            this.setAgentStatus.Status = RTCCORELib.RTC_PRESENCE_STATUS.RTCXS_PRESENCE_ONLINE;
            // 
            // LeaveWorkflow
            // 
            this.Activities.Add(this.setAgentStatus);
            this.Activities.Add(this.lookupManager);
            this.Activities.Add(this.lookupManagerDetails);
            this.Activities.Add(this.checkManagerStatus);
            this.Activities.Add(this.ifManagerOnline);
            this.Activities.Add(this.ifManagerRtcReplied);
            this.Activities.Add(this.ifApproved);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Name = "LeaveWorkflow";
            this.Initialized += new System.EventHandler(this.LeaveWorkflow_Initialized);
            this.CanModifyActivities = false;

		}

		#endregion

        private DirectoryLookupActivityLibrary.UserDetailsLookupActivity lookupGrandManagerDetails;
        private SMTPMailActivityLibrary.SendEmail sendEmail1;
        private ListenActivity listenActivity1;
        private EventDrivenActivity eventDrivenActivity3;
        private SMTPMailActivityLibrary.SmtpMailReceived grandManagerEmailReceived;
        private CodeActivity codeActivity1;
        private EventDrivenActivity eventDrivenActivity4;
        private DelayActivity delayActivity1;
        private IfElseActivity ifApproved;
        private IfElseBranchActivity isApprovedBranch;
        private IfElseBranchActivity isDeclinedBranch;
        private SMTPMailActivityLibrary.SendEmail sendApprovedEmail;
        private SMTPMailActivityLibrary.SendEmail sendDeclinedEmail;
        private IfElseBranchActivity elseTimedOutBranch;
        private SMTPMailActivityLibrary.SendEmail sendTimeoutEmail;
        private CodeActivity setManagerEmailReceived;
        private SMTPMailActivityLibrary.SendEmail emailManager;
        private ListenActivity listenForManagerEmailReply;
        private EventDrivenActivity eventDrivenActivity1;
        private SMTPMailActivityLibrary.SmtpMailReceived managerEmailReceived;
        private EventDrivenActivity eventDrivenActivity2;
        private DelayActivity managerEmailDelay;
        private IfElseActivity ifManagerRtcReplied;
        private IfElseBranchActivity isManagerRtcReplied;
        private IfElseBranchActivity elseManagerNoRtcReply;
        private CodeActivity setManagerRtcReceived;
        private RtcActivityLibrary.SendMessage rtcMessageManager;
        private ListenActivity listenForManagerRtcReply;
        private EventDrivenActivity eventManagerRtcReply;
        private EventDrivenActivity eventManagerRtcTimeout;
        private RtcActivityLibrary.RtcMessageReceived managerRtcReceived;
        private DelayActivity managerRtcDelay;
        private IfElseActivity ifManagerOnline;
        private IfElseBranchActivity isManagerOnline;
        private IfElseBranchActivity elseNotManagerOnline;
        private RtcActivityLibrary.GetStatus checkManagerStatus;
        private DirectoryLookupActivityLibrary.UserDetailsLookupActivity lookupManagerDetails;
        private RtcActivityLibrary.SetStatus setAgentStatus;
        private DirectoryLookupActivityLibrary.DirectoryLookupActivity lookupManager;
        private FaultHandlersActivity faultHandlersActivity1;



































































































































    }
}
