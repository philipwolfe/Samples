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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Runtime;
using SmtpMailActivityLibrary.Interfaces;
using System.Configuration;
using RtcActivityLibrary.Services;
using System.Workflow.Activities;
using System.Workflow.Runtime.Tracking;
using SmtpMailActivityLibrary.Services;
using LeaveWorkflows;

namespace HumanWorkflowWinformDemo
{
    public partial class LeaveForm : Form
    {

        WorkflowRuntime workflowRuntime;
        
        string directoryUri;

        public LeaveForm()
        {
            InitializeComponent();

            //Get the coordinating and default user email addresses.
            AppSettingsReader asr = new AppSettingsReader();
            this.txtCoordEmail.Text = (string)asr.GetValue("CoordinatingEmailAddress", typeof(string));
            this.txtEMail.Text = (string)asr.GetValue("DefaultUserEMailAddress", typeof(string));
            directoryUri = (string)asr.GetValue("DirectoryUri", typeof(string));

            workflowRuntime = new WorkflowRuntime();

            ExternalDataExchangeService dataExchangeService = new ExternalDataExchangeService();
            workflowRuntime.AddService(dataExchangeService);

            SubscriptionService.SubscriptionService subscriptionService = new SubscriptionService.SubscriptionService();
            workflowRuntime.AddService(subscriptionService);

            //********RTC Service*******
            //Uncomment this if you have Live COmmunications Server that you want to use
            //RtcService rtcService;
            //rtcService = new RtcService("sip:administrator@fabrikam.com", @"fabrikam\administrator", "pass@word1", "localhost", RTCConstants.RTCTR_TCP, subscriptionService);
            //dataExchangeService.AddService(rtcService);

            SmtpMailService smtpService;

            //*****Service type #1*****
            //Demonstrates using the SmtpDropMailService
            //This service watches the Windows Smtp Server drop box.
            //Change 'mail.fabrikam.com' to your smtp mail server
            //You may, depending on configuration need to change the drop box location too
            //Also need to uncomment the call to StartSmtpTracking below

            //smtpService = new SmtpDropMailService("mail.fabrikam.com", @"C:\Inetpub\mailroot\Drop\",subscriptionService);

            //*****Service type #2*****
            //Demonstrates using the Outlook mail service.
            //This is really designed for demo purposes only.
            //It is not envisaged that Outlook be used on a production system.
            //Should work out of the box as long as you have Outlook on your machine.
            //Will throw security warning messages as Outlook is accessed

            smtpService = new SmtpOutlookMailService(subscriptionService);

            //*****Service type #3*****
            //Demonstrates using the ExchangeWebDavMailService
            //Change 'mail.fabrikam.com' to your smtp mail server
            //You'll also need to change the user details in the Uri and the username and password to
            //point to a valid email account.
            //Also need to uncomment the call to StartSmtpTracking below

            //smtpService = new ExchangeWebDavMailService
            //                ("localhost", "http://localhost/exchange/administrator/inbox/",
            //                 "administrator", "pass@word1", 5000, subscriptionService);
            
            
            dataExchangeService.AddService(smtpService);

            workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(OnWorkflowCompleted);

            workflowRuntime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(workflowRuntime_WorkflowTerminated);

            smtpService.StartSmtpTracking();

            
        }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            MessageBox.Show("Workflow for " + e.OutputParameters["ApplicantAccount"].ToString() + " finished. Approved result:" + e.OutputParameters["Approved"].ToString());            
        }

        void workflowRuntime_WorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine("Workflow Terminated:");
            Console.WriteLine(e.Exception.Message);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Build the parameters dictionary
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("ApplicantAccount", txtUserName.Text);
            parms.Add("ApplicantEMail", txtEMail.Text);
            parms.Add("LeaveComment", txtComments.Text);
            parms.Add("StartDate", dtStart.Value);
            parms.Add("EndDate", dtEnd.Value);
            parms.Add("CoordinatingEmailAddress", txtCoordEmail.Text);
            parms.Add("LdapUri", directoryUri);
            
            WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(EmailWorkflow),parms);
            instance.Start();
            
        }

    }
}