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
    public sealed partial class EmailWorkflow
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
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken3 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken4 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken5 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken6 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind23 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind24 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken7 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind25 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind26 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind27 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind28 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind29 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind30 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind31 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind32 = new System.Workflow.ComponentModel.ActivityBind();
            this.delayForGrandManager = new System.Workflow.Activities.DelayActivity();
            this.setGrandManagerEmailReceived = new System.Workflow.Activities.CodeActivity();
            this.grandManagerEmailReceived = new SMTPMailActivityLibrary.SmtpMailReceived();
            this.eventGrandManagerTimeout = new System.Workflow.Activities.EventDrivenActivity();
            this.eventGrandManagerMailReceived = new System.Workflow.Activities.EventDrivenActivity();
            this.sendTimeoutEmail = new SMTPMailActivityLibrary.SendEmail();
            this.sendDeclinedEmail = new SMTPMailActivityLibrary.SendEmail();
            this.sendApprovedEmail = new SMTPMailActivityLibrary.SendEmail();
            this.listenForGrandManagerReply = new System.Workflow.Activities.ListenActivity();
            this.emailToGrandManager = new SMTPMailActivityLibrary.SendEmail();
            this.lookupGrandManagerDetails = new DirectoryLookupActivityLibrary.UserDetailsLookupActivity();
            this.delayForManagerReply = new System.Workflow.Activities.DelayActivity();
            this.setManagerEmailReceived = new System.Workflow.Activities.CodeActivity();
            this.managerEmailReceived = new SMTPMailActivityLibrary.SmtpMailReceived();
            this.elseTimedOutBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.isDeclinedBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.isApprovedBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.eventManagerTimeout = new System.Workflow.Activities.EventDrivenActivity();
            this.eventManagerMailReceived = new System.Workflow.Activities.EventDrivenActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.ifApproved = new System.Workflow.Activities.IfElseActivity();
            this.listenForManagerReply = new System.Workflow.Activities.ListenActivity();
            this.emailToManager = new SMTPMailActivityLibrary.SendEmail();
            this.lookupManagerDetails = new DirectoryLookupActivityLibrary.UserDetailsLookupActivity();
            this.lookupManager = new DirectoryLookupActivityLibrary.DirectoryLookupActivity();
            // 
            // delayForGrandManager
            // 
            this.delayForGrandManager.Name = "delayForGrandManager";
            this.delayForGrandManager.TimeoutDuration = System.TimeSpan.Parse("00:05:00");
            // 
            // setGrandManagerEmailReceived
            // 
            this.setGrandManagerEmailReceived.Name = "setGrandManagerEmailReceived";
            this.setGrandManagerEmailReceived.ExecuteCode += new System.EventHandler(this.setGrandManagerEmailReceived_ExecuteCode);
            // 
            // grandManagerEmailReceived
            // 
            this.grandManagerEmailReceived.Body = null;
            correlationtoken1.Name = "grandManagerToken";
            correlationtoken1.OwnerActivityName = "eventManagerTimeout";
            this.grandManagerEmailReceived.CorrelationToken = correlationtoken1;
            this.grandManagerEmailReceived.From = null;
            this.grandManagerEmailReceived.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            activitybind1.Name = "EmailWorkflow";
            activitybind1.Path = "grandManagerEmailId";
            this.grandManagerEmailReceived.Name = "grandManagerEmailReceived";
            activitybind2.Name = "EmailWorkflow";
            activitybind2.Path = "approvedRegex";
            this.grandManagerEmailReceived.Subject = null;
            this.grandManagerEmailReceived.To = null;
            this.grandManagerEmailReceived.SetBinding(SMTPMailActivityLibrary.SmtpMailReceived.RegexProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.grandManagerEmailReceived.SetBinding(SMTPMailActivityLibrary.SmtpMailReceived.MessageIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // eventGrandManagerTimeout
            // 
            this.eventGrandManagerTimeout.Activities.Add(this.delayForGrandManager);
            this.eventGrandManagerTimeout.Name = "eventGrandManagerTimeout";
            // 
            // eventGrandManagerMailReceived
            // 
            this.eventGrandManagerMailReceived.Activities.Add(this.grandManagerEmailReceived);
            this.eventGrandManagerMailReceived.Activities.Add(this.setGrandManagerEmailReceived);
            this.eventGrandManagerMailReceived.Name = "eventGrandManagerMailReceived";
            // 
            // sendTimeoutEmail
            // 
            activitybind3.Name = "EmailWorkflow";
            activitybind3.Path = "ManagerTimeoutBody";
            correlationtoken2.Name = "resultToken";
            correlationtoken2.OwnerActivityName = "elseTimedOutBranch";
            this.sendTimeoutEmail.CorrelationToken = correlationtoken2;
            activitybind4.Name = "EmailWorkflow";
            activitybind4.Path = "CoordinatingEmailAddress";
            this.sendTimeoutEmail.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            this.sendTimeoutEmail.MessageId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.sendTimeoutEmail.Name = "sendTimeoutEmail";
            this.sendTimeoutEmail.Subject = "Leave Declined";
            activitybind5.Name = "EmailWorkflow";
            activitybind5.Path = "ApplicantEMail";
            activitybind6.Name = "EmailWorkflow";
            activitybind6.Path = "leaveXmlData";
            this.sendTimeoutEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.sendTimeoutEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.sendTimeoutEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.sendTimeoutEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            // 
            // sendDeclinedEmail
            // 
            activitybind7.Name = "EmailWorkflow";
            activitybind7.Path = "declineBody";
            correlationtoken3.Name = "resultDeclinedToken";
            correlationtoken3.OwnerActivityName = "isDeclinedBranch";
            this.sendDeclinedEmail.CorrelationToken = correlationtoken3;
            activitybind8.Name = "EmailWorkflow";
            activitybind8.Path = "CoordinatingEmailAddress";
            this.sendDeclinedEmail.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            this.sendDeclinedEmail.MessageId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.sendDeclinedEmail.Name = "sendDeclinedEmail";
            this.sendDeclinedEmail.Subject = "Leave Declined";
            activitybind9.Name = "EmailWorkflow";
            activitybind9.Path = "ApplicantEMail";
            activitybind10.Name = "EmailWorkflow";
            activitybind10.Path = "leaveXmlData";
            this.sendDeclinedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.sendDeclinedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.sendDeclinedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.sendDeclinedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // sendApprovedEmail
            // 
            activitybind11.Name = "EmailWorkflow";
            activitybind11.Path = "acceptBody";
            correlationtoken4.Name = "resultApprovedToken";
            correlationtoken4.OwnerActivityName = "isApprovedBranch";
            this.sendApprovedEmail.CorrelationToken = correlationtoken4;
            activitybind12.Name = "EmailWorkflow";
            activitybind12.Path = "CoordinatingEmailAddress";
            this.sendApprovedEmail.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            this.sendApprovedEmail.MessageId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.sendApprovedEmail.Name = "sendApprovedEmail";
            this.sendApprovedEmail.Subject = "Leave Approved";
            activitybind13.Name = "EmailWorkflow";
            activitybind13.Path = "ApplicantEMail";
            activitybind14.Name = "EmailWorkflow";
            activitybind14.Path = "leaveXmlData";
            this.sendApprovedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.sendApprovedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.sendApprovedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            this.sendApprovedEmail.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            // 
            // listenForGrandManagerReply
            // 
            this.listenForGrandManagerReply.Activities.Add(this.eventGrandManagerMailReceived);
            this.listenForGrandManagerReply.Activities.Add(this.eventGrandManagerTimeout);
            this.listenForGrandManagerReply.Name = "listenForGrandManagerReply";
            // 
            // emailToGrandManager
            // 
            activitybind15.Name = "EmailWorkflow";
            activitybind15.Path = "mailToGrandManagerBody";
            correlationtoken5.Name = "grandManagerToken";
            correlationtoken5.OwnerActivityName = "eventManagerTimeout";
            this.emailToGrandManager.CorrelationToken = correlationtoken5;
            activitybind16.Name = "EmailWorkflow";
            activitybind16.Path = "CoordinatingEmailAddress";
            this.emailToGrandManager.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            activitybind17.Name = "EmailWorkflow";
            activitybind17.Path = "grandManagerEmailId";
            this.emailToGrandManager.Name = "emailToGrandManager";
            this.emailToGrandManager.Subject = "Leave Request";
            activitybind18.Name = "lookupGrandManagerDetails";
            activitybind18.Path = "RetrievedUserData.Mail";
            activitybind19.Name = "EmailWorkflow";
            activitybind19.Path = "leaveXmlData";
            this.emailToGrandManager.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.emailToGrandManager.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.emailToGrandManager.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.emailToGrandManager.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            this.emailToGrandManager.SetBinding(SMTPMailActivityLibrary.SendEmail.MessageIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // lookupGrandManagerDetails
            // 
            activitybind20.Name = "EmailWorkflow";
            activitybind20.Path = "LdapUri";
            this.lookupGrandManagerDetails.Name = "lookupGrandManagerDetails";
            activitybind21.Name = "lookupManagerDetails";
            activitybind21.Path = "RetrievedUserData.Manager";
            this.lookupGrandManagerDetails.QuerySource = DirectoryLookupActivityLibrary.ADActivityLookupSource.XmlFile;
            this.lookupGrandManagerDetails.RetrievedUserData = null;
            this.lookupGrandManagerDetails.SetBinding(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.QueryProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            this.lookupGrandManagerDetails.SetBinding(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.DirectoryUriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            // 
            // delayForManagerReply
            // 
            this.delayForManagerReply.Name = "delayForManagerReply";
            this.delayForManagerReply.TimeoutDuration = System.TimeSpan.Parse("00:05:00");
            // 
            // setManagerEmailReceived
            // 
            this.setManagerEmailReceived.Name = "setManagerEmailReceived";
            this.setManagerEmailReceived.ExecuteCode += new System.EventHandler(this.setManagerEmailReceived_ExecuteCode);
            // 
            // managerEmailReceived
            // 
            this.managerEmailReceived.Body = null;
            correlationtoken6.Name = "managerEmailToken";
            correlationtoken6.OwnerActivityName = "EmailWorkflow";
            this.managerEmailReceived.CorrelationToken = correlationtoken6;
            this.managerEmailReceived.From = null;
            this.managerEmailReceived.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            activitybind22.Name = "EmailWorkflow";
            activitybind22.Path = "managerEmailId";
            this.managerEmailReceived.Name = "managerEmailReceived";
            activitybind23.Name = "EmailWorkflow";
            activitybind23.Path = "approvedRegex";
            this.managerEmailReceived.Subject = null;
            this.managerEmailReceived.To = null;
            this.managerEmailReceived.SetBinding(SMTPMailActivityLibrary.SmtpMailReceived.RegexProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            this.managerEmailReceived.SetBinding(SMTPMailActivityLibrary.SmtpMailReceived.MessageIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            // 
            // elseTimedOutBranch
            // 
            this.elseTimedOutBranch.Activities.Add(this.sendTimeoutEmail);
            this.elseTimedOutBranch.Name = "elseTimedOutBranch";
            // 
            // isDeclinedBranch
            // 
            this.isDeclinedBranch.Activities.Add(this.sendDeclinedEmail);
            ruleconditionreference1.ConditionName = "IsNotApproved";
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
            // eventManagerTimeout
            // 
            this.eventManagerTimeout.Activities.Add(this.delayForManagerReply);
            this.eventManagerTimeout.Activities.Add(this.lookupGrandManagerDetails);
            this.eventManagerTimeout.Activities.Add(this.emailToGrandManager);
            this.eventManagerTimeout.Activities.Add(this.listenForGrandManagerReply);
            this.eventManagerTimeout.Name = "eventManagerTimeout";
            // 
            // eventManagerMailReceived
            // 
            this.eventManagerMailReceived.Activities.Add(this.managerEmailReceived);
            this.eventManagerMailReceived.Activities.Add(this.setManagerEmailReceived);
            this.eventManagerMailReceived.Name = "eventManagerMailReceived";
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
            // listenForManagerReply
            // 
            this.listenForManagerReply.Activities.Add(this.eventManagerMailReceived);
            this.listenForManagerReply.Activities.Add(this.eventManagerTimeout);
            this.listenForManagerReply.Name = "listenForManagerReply";
            // 
            // emailToManager
            // 
            activitybind24.Name = "EmailWorkflow";
            activitybind24.Path = "mailToManagerBody";
            correlationtoken7.Name = "managerEmailToken";
            correlationtoken7.OwnerActivityName = "EmailWorkflow";
            this.emailToManager.CorrelationToken = correlationtoken7;
            activitybind25.Name = "EmailWorkflow";
            activitybind25.Path = "CoordinatingEmailAddress";
            this.emailToManager.MailType = SmtpMailActivityLibrary.Interfaces.SmtpEMailType.PlainText;
            activitybind26.Name = "EmailWorkflow";
            activitybind26.Path = "managerEmailId";
            this.emailToManager.Name = "emailToManager";
            this.emailToManager.Subject = "Leave Request";
            activitybind27.Name = "lookupManagerDetails";
            activitybind27.Path = "RetrievedUserData.Mail";
            activitybind28.Name = "EmailWorkflow";
            activitybind28.Path = "leaveXmlData";
            this.emailToManager.SetBinding(SMTPMailActivityLibrary.SendEmail.FromProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            this.emailToManager.SetBinding(SMTPMailActivityLibrary.SendEmail.ToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind27)));
            this.emailToManager.SetBinding(SMTPMailActivityLibrary.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            this.emailToManager.SetBinding(SMTPMailActivityLibrary.SendEmail.XmlDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind28)));
            this.emailToManager.SetBinding(SMTPMailActivityLibrary.SendEmail.MessageIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind26)));
            // 
            // lookupManagerDetails
            // 
            activitybind29.Name = "EmailWorkflow";
            activitybind29.Path = "LdapUri";
            this.lookupManagerDetails.Name = "lookupManagerDetails";
            activitybind30.Name = "lookupManager";
            activitybind30.Path = "QueryResults[0]";
            this.lookupManagerDetails.QuerySource = DirectoryLookupActivityLibrary.ADActivityLookupSource.XmlFile;
            this.lookupManagerDetails.RetrievedUserData = null;
            this.lookupManagerDetails.SetBinding(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.DirectoryUriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind29)));
            this.lookupManagerDetails.SetBinding(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.QueryProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind30)));
            // 
            // lookupManager
            // 
            activitybind31.Name = "EmailWorkflow";
            activitybind31.Path = "LdapUri";
            this.lookupManager.Name = "lookupManager";
            activitybind32.Name = "EmailWorkflow";
            activitybind32.Path = "ApplicantAccount";
            this.lookupManager.QuerySource = DirectoryLookupActivityLibrary.ADActivityLookupSource.XmlFile;
            this.lookupManager.SetBinding(DirectoryLookupActivityLibrary.DirectoryLookupActivity.DirectoryUriProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind31)));
            this.lookupManager.SetBinding(DirectoryLookupActivityLibrary.DirectoryLookupActivity.QueryProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind32)));
            // 
            // EmailWorkflow
            // 
            this.Activities.Add(this.lookupManager);
            this.Activities.Add(this.lookupManagerDetails);
            this.Activities.Add(this.emailToManager);
            this.Activities.Add(this.listenForManagerReply);
            this.Activities.Add(this.ifApproved);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Name = "EmailWorkflow";
            this.Initialized += new System.EventHandler(this.EmailWorkflow_Initialized);
            this.CanModifyActivities = false;

        }

        #endregion

        private SMTPMailActivityLibrary.SendEmail emailToManager;
        private ListenActivity listenForManagerReply;
        private EventDrivenActivity eventManagerMailReceived;
        private SMTPMailActivityLibrary.SmtpMailReceived managerEmailReceived;
        private CodeActivity setManagerEmailReceived;
        private EventDrivenActivity eventManagerTimeout;
        private DelayActivity delayForManagerReply;
        private DirectoryLookupActivityLibrary.UserDetailsLookupActivity lookupGrandManagerDetails;
        private SMTPMailActivityLibrary.SendEmail emailToGrandManager;
        private ListenActivity listenForGrandManagerReply;
        private EventDrivenActivity eventGrandManagerMailReceived;
        private SMTPMailActivityLibrary.SmtpMailReceived grandManagerEmailReceived;
        private CodeActivity setGrandManagerEmailReceived;
        private EventDrivenActivity eventGrandManagerTimeout;
        private DelayActivity delayForGrandManager;
        private IfElseActivity ifApproved;
        private IfElseBranchActivity isApprovedBranch;
        private IfElseBranchActivity isDeclinedBranch;
        private SMTPMailActivityLibrary.SendEmail sendApprovedEmail;
        private SMTPMailActivityLibrary.SendEmail sendDeclinedEmail;
        private IfElseBranchActivity elseTimedOutBranch;
        private SMTPMailActivityLibrary.SendEmail sendTimeoutEmail;
        private DirectoryLookupActivityLibrary.UserDetailsLookupActivity lookupManagerDetails;
        private DirectoryLookupActivityLibrary.DirectoryLookupActivity lookupManager;
        private FaultHandlersActivity faultHandlersActivity1;















































































































































    }
}
