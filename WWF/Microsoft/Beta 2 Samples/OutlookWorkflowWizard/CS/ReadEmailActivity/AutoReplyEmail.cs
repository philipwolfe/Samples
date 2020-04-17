//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Workflow.ComponentModel;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

//NOTE: When changing the namespace; please update XmlnsDefinitionAttribute in AssemblyInfo.cs
namespace Microsoft.Samples.Workflow.OutlookWorkflowWizard
{
	public partial class AutoReplyEmail: Activity
	{
		public AutoReplyEmail()
		{
			InitializeComponent();
		}

        private String smtpHost;
        public string SmtpHost
        {
            get { return smtpHost; }
            set { smtpHost = value; }
        }

        private String from;
        public string From
        {
            get { return from; }
            set { from = value; }
        }


        private String to;
        public string To
        {
            get { return to; }
            set { to = value; }
        }

        private String subject;
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            MessageBox.Show("Process Auto-Reply for Email");
            // Create an Outlook Application object. 
            Outlook.Application outlookApp = new Outlook.Application();

            Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            oMailItem.To = outlookApp.Session.CurrentUser.Address;
            //oMailItem.To = "email@microsoft.com";
            oMailItem.Subject = "Auto-Reply";
            oMailItem.Body = "Out of Office";

            //adds it to the outbox      
            oMailItem.Send();

            return ActivityExecutionStatus.Closed;
        }
    }
}
