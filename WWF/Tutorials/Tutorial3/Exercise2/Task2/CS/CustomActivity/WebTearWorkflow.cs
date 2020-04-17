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
using System.Workflow.Activities;
using System.Workflow.ComponentModel;

namespace Microsoft.Samples.Workflow.Tutorials.CustomActivity
{
    public sealed class WebTearWorkflow : SequentialWorkflowActivity
    {
        private string pageUrl;
        private string pageData;

        private WebTearActivity webTearActivity;

        public WebTearWorkflow()
        {
            InitializeComponent();
        }

        public string Url
        {
            get { return pageUrl; }
            set { pageUrl = value; }
        }

        public string Data
        {
            get { return pageData; }
            set { pageData = value; }
        }

        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            ActivityBind activitybind1 = new ActivityBind();
            this.webTearActivity = new WebTearActivity();
            // 
            // webTearActivity1
            // 
            this.webTearActivity.Name = "webTearActivity";
            activitybind1.Name = "WebTearWorkflow";
            activitybind1.Path = "Url";
            this.webTearActivity.PageFinished += 
                new WebTearActivity.PageFinishedEventHandler
                (this.webTearActivity_PageFinished);
            this.webTearActivity.SetBinding(WebTearActivity.UrlProperty, 
                ((ActivityBind)(activitybind1)));
            // 
            // WebTearWorkflow
            // 
            this.Activities.Add(this.webTearActivity);
            this.Name = "WebTearWorkflow";
            this.CanModifyActivities = false;
        }

        private void webTearActivity_PageFinished(object sender, PageFinishedEventArgs e)
        {
            this.pageData = e.Data;
        }
    }
}
