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

namespace Microsoft.Samples.Workflow.Applications.DocumentReview
{
    public partial class TaskActivity
    {
        #region Activity Designer generated code
        
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            this.createDocumentReviewTask = new Microsoft.Samples.Workflow.Applications.DocumentReview.CreateDocumentReviewTask();
            this.listenForReviewResponse = new System.Workflow.Activities.Listen();
            this.responseReceivedEventDriven = new System.Workflow.Activities.EventDriven();
            this.reviewTimeoutEventDriven = new System.Workflow.Activities.EventDriven();
            this.documentReviewCompleted = new Microsoft.Samples.Workflow.Applications.DocumentReview.DocumentReviewTaskCompleted();
            this.reviewTimeout = new System.Workflow.Activities.Delay();
            this.reviewTimeoutOccured = new System.Workflow.Activities.Code();
            // 
            // createDocumentReviewTask
            // 
            activitybind1.ID = "/Parent";
            activitybind1.Path = "correlationReference";
            this.createDocumentReviewTask.CorrelationReference = activitybind1;
            activitybind2.ID = "/Parent";
            activitybind2.Path = "DocumentUrl";
            this.createDocumentReviewTask.ID = "createDocumentReviewTask";
            activitybind3.ID = "/Parent";
            activitybind3.Path = "Owner";
            activitybind4.ID = "/Parent";
            activitybind4.Path = "Reviewer";
            this.createDocumentReviewTask.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.CreateDocumentReviewTask.DocumentUrlProperty, ((System.Workflow.ComponentModel.Bind)(activitybind2)));
            this.createDocumentReviewTask.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.CreateDocumentReviewTask.OwnerProperty, ((System.Workflow.ComponentModel.Bind)(activitybind3)));
            this.createDocumentReviewTask.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.CreateDocumentReviewTask.ReviewerProperty, ((System.Workflow.ComponentModel.Bind)(activitybind4)));
            // 
            // listenForReviewResponse
            // 
            this.listenForReviewResponse.Activities.Add(this.responseReceivedEventDriven);
            this.listenForReviewResponse.Activities.Add(this.reviewTimeoutEventDriven);
            this.listenForReviewResponse.ID = "listenForReviewResponse";
            // 
            // responseReceivedEventDriven
            // 
            this.responseReceivedEventDriven.Activities.Add(this.documentReviewCompleted);
            this.responseReceivedEventDriven.ID = "responseReceivedEventDriven";
            // 
            // reviewTimeoutEventDriven
            // 
            this.reviewTimeoutEventDriven.Activities.Add(this.reviewTimeout);
            this.reviewTimeoutEventDriven.Activities.Add(this.reviewTimeoutOccured);
            this.reviewTimeoutEventDriven.ID = "reviewTimeoutEventDriven";
            // 
            // documentReviewCompleted
            // 
            activitybind5.ID = "/Parent/Parent/Parent";
            activitybind5.Path = "correlationReference";
            this.documentReviewCompleted.CorrelationReference = activitybind5;
            activitybind6.ID = "/Parent/Parent/Parent";
            activitybind6.Path = "DocumentUrl";
            this.documentReviewCompleted.ID = "documentReviewCompleted";
            activitybind7.ID = "/Parent/Parent/Parent";
            activitybind7.Path = "Owner";
            activitybind8.ID = "/Parent/Parent/Parent";
            activitybind8.Path = "Reviewer";
            activitybind9.ID = "/Parent/Parent/Parent";
            activitybind9.Path = "ReviewOutcome";
            this.documentReviewCompleted.Roles = null;
            this.documentReviewCompleted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.DocumentReviewTaskCompleted.DocumentUrlProperty, ((System.Workflow.ComponentModel.Bind)(activitybind6)));
            this.documentReviewCompleted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.DocumentReviewTaskCompleted.OwnerProperty, ((System.Workflow.ComponentModel.Bind)(activitybind7)));
            this.documentReviewCompleted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.DocumentReviewTaskCompleted.ReviewerProperty, ((System.Workflow.ComponentModel.Bind)(activitybind8)));
            this.documentReviewCompleted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.DocumentReviewTaskCompleted.ReviewOutcomeProperty, ((System.Workflow.ComponentModel.Bind)(activitybind9)));
            // 
            // reviewTimeout
            // 
            this.reviewTimeout.ID = "reviewTimeout";
            this.reviewTimeout.TimeoutDuration = System.TimeSpan.Parse("00:01:00");
            // 
            // reviewTimeoutOccured
            // 
            this.reviewTimeoutOccured.ID = "reviewTimeoutOccured";
            this.reviewTimeoutOccured.ExecuteCode += new System.EventHandler(this.ReviewTimeoutOccured);
            // 
            // TaskActivity
            // 
            this.Activities.Add(this.createDocumentReviewTask);
            this.Activities.Add(this.listenForReviewResponse);

        }

        #endregion

        [LockedActivityAttribute(true, true)]
        private Listen listenForReviewResponse;
        [LockedActivityAttribute(true, true)]
        private EventDriven responseReceivedEventDriven;
        [LockedActivityAttribute(true, false)]
        private DocumentReviewTaskCompleted documentReviewCompleted;
        [LockedActivityAttribute(true, true)]
        private EventDriven reviewTimeoutEventDriven;
        [LockedActivityAttribute(true, false)]
        private Delay reviewTimeout;
        [LockedActivityAttribute(true, false)]
        private Code reviewTimeoutOccured;
        [LockedActivityAttribute(true, false)]
        private CreateDocumentReviewTask createDocumentReviewTask;
    }
}
