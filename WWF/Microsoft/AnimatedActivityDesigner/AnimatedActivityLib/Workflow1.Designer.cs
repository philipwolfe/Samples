//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------
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

namespace AnimatedActivityLib
{
	partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.uploadFileActivity1 = new AnimatedActivityLib.UploadFileActivity();
            this.sendSMSMessageActivity1 = new AnimatedActivityLib.SendSmsMessageActivity();
            this.sendInternetFaxActivity1 = new AnimatedActivityLib.SendInternetFaxActivity();
            this.downloadFileActivity1 = new AnimatedActivityLib.DownloadFileActivity();
            this.moveFilesActivity1 = new AnimatedActivityLib.MoveFilesActivity();
            this.currencyConverterActivity1 = new AnimatedActivityLib.CurrencyConverterActivity();
            // 
            // uploadFileActivity1
            // 
            this.uploadFileActivity1.Name = "uploadFileActivity1";
            // 
            // sendSMSMessageActivity1
            // 
            this.sendSMSMessageActivity1.Name = "sendSMSMessageActivity1";
            // 
            // sendInternetFaxActivity1
            // 
            this.sendInternetFaxActivity1.Name = "sendInternetFaxActivity1";
            // 
            // downloadFileActivity1
            // 
            this.downloadFileActivity1.Name = "downloadFileActivity1";
            // 
            // moveFilesActivity1
            // 
            this.moveFilesActivity1.Name = "moveFilesActivity1";
            // 
            // currencyConverterActivity1
            // 
            this.currencyConverterActivity1.Name = "currencyConverterActivity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.currencyConverterActivity1);
            this.Activities.Add(this.moveFilesActivity1);
            this.Activities.Add(this.downloadFileActivity1);
            this.Activities.Add(this.sendInternetFaxActivity1);
            this.Activities.Add(this.sendSMSMessageActivity1);
            this.Activities.Add(this.uploadFileActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private MoveFilesActivity moveFilesActivity1;
        private UploadFileActivity uploadFileActivity1;
        private SendSmsMessageActivity sendSMSMessageActivity1;
        private SendInternetFaxActivity sendInternetFaxActivity1;
        private DownloadFileActivity downloadFileActivity1;
        private CurrencyConverterActivity currencyConverterActivity1;


    }
}
