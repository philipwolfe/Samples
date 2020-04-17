//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
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

using System.Net.Mail;
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

namespace SendMailActivityLibrary
{
	[Designer(typeof(SendMailDesigner), typeof(IDesigner))]
	[ActivityValidator(typeof(ParametersValidator))]
	public partial class SendMailActivity : System.Workflow.ComponentModel.Activity
	{
		public SendMailActivity()
		{
			InitializeComponent();
		}
		public static DependencyProperty ToProperty = System.Workflow.ComponentModel.DependencyProperty.Register("To", typeof(string), typeof(SendMailActivity));

		[Description("To Email Address")]
		[Category("EmailActivity")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string To
		{
			get
			{
				return ((string)(base.GetValue(SendMailActivity.ToProperty)));
			}
			set
			{
				base.SetValue(SendMailActivity.ToProperty, value);
			}
		}

		public static DependencyProperty FromProperty = System.Workflow.ComponentModel.DependencyProperty.Register("From", typeof(string), typeof(SendMailActivity));

		[Description("From Email Address")]
		[Category("EmailActivity")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string From
		{
			get
			{
				return ((string)(base.GetValue(SendMailActivity.FromProperty)));
			}
			set
			{
				base.SetValue(SendMailActivity.FromProperty, value);
			}
		}

		public static DependencyProperty SubjectProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Subject", typeof(string), typeof(SendMailActivity));

		[Description("Subject of Email")]
		[Category("EmailActivity")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Subject
		{
			get
			{
				return ((string)(base.GetValue(SendMailActivity.SubjectProperty)));
			}
			set
			{
				base.SetValue(SendMailActivity.SubjectProperty, value);
			}
		}

		public static DependencyProperty BodyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Body", typeof(string), typeof(SendMailActivity));

		[Description("Body of Email")]
		[Category("EmailActivity")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Body
		{
			get
			{
				return ((string)(base.GetValue(SendMailActivity.BodyProperty)));
			}
			set
			{
				base.SetValue(SendMailActivity.BodyProperty, value);
			}
		}

		protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
		{

			MailAddress toAddress = new MailAddress(To);
			MailAddress fromAddress = new MailAddress(From);

			MailAddressCollection addresses = new MailAddressCollection();
			addresses.Add(toAddress);

			MailMessage msg = new MailMessage(fromAddress, toAddress);

			msg.Subject = Subject;
			msg.Body = Body;

			SmtpClient mail = new SmtpClient("localhost");

			mail.Send(msg);
			return ActivityExecutionStatus.Closed;

		}

	}
}
