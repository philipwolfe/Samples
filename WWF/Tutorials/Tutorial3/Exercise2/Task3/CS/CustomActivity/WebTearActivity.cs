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
using System.ComponentModel;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;

namespace Microsoft.Samples.Workflow.Tutorials.CustomActivity
{
    public class WebTearActivity : System.Workflow.ComponentModel.Activity
    {
        public delegate void PageFinishedEventHandler(object sender, 
            PageFinishedEventArgs e);
        private event PageFinishedEventHandler pageFinishedEvent;
        public event PageFinishedEventHandler PageFinished
        {
            add
            {
                pageFinishedEvent += value;
            }
            remove
            {
                pageFinishedEvent -= value;
            }
        }

        protected override ActivityExecutionStatus Execute
            (ActivityExecutionContext context)
        {
            string pageData;
            System.Net.WebClient client = new System.Net.WebClient();

            try
            {
                // Download the web page data
                pageData = client.DownloadString(this.Url);
            }
            catch (Exception e)
            {
                pageData = e.Message;
            }

            // Raise the PageFinished event back to the host
            pageFinishedEvent(null, new PageFinishedEventArgs(pageData));

            // Notifiy the runtime that the activity has finished
            return ActivityExecutionStatus.Closed;
        }

        public static DependencyProperty UrlProperty =
                    DependencyProperty.Register("Url", 
                    typeof(System.String), 
                    typeof(WebTearActivity));

        [DesignerSerializationVisibilityAttribute
            (DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("Url to download")]
        [CategoryAttribute("WebTearActivity Property")]
        public string Url
        {
            get
            {
                return ((string)(base.GetValue(WebTearActivity.UrlProperty)));
            }
            set
            {
                base.SetValue(WebTearActivity.UrlProperty, value);
            }
        }
    }
    
    public class PageFinishedEventArgs
    {
        private string pageData;

        public PageFinishedEventArgs(string data)
        {
            this.pageData = data;
        }

        public string Data
        {
            get { return this.pageData; }
        }
    }
}
