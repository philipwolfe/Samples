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
    public sealed partial class DocumentReviewWorkflow : SequentialWorkflow
    {
        #region Designer generated code
        
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
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            this.onReviewStarted = new Microsoft.Samples.Workflow.Applications.DocumentReview.ReviewStarted();
            this.documentReviewReplicator = new System.Workflow.Activities.Replicator();
            this.reviewCompleted = new Microsoft.Samples.Workflow.Applications.DocumentReview.ReviewCompleted();
            this.eventHandlers = new System.Workflow.Activities.EventHandlers();
            this.taskActivity = new Microsoft.Samples.Workflow.Applications.DocumentReview.TaskActivity();
            this.addParticipantsEventDriven = new System.Workflow.Activities.EventDriven();
            this.participantsAdded = new Microsoft.Samples.Workflow.Applications.DocumentReview.ParticipantsAdded();
            this.compensationHandler1 = new System.Workflow.Activities.CompensationHandler();
            // 
            // onReviewStarted
            // 
            activitybind1.ID = "/Workflow";
            activitybind1.Path = "correlationReference";
            this.onReviewStarted.CorrelationReference = activitybind1;
            activitybind2.ID = "/Workflow";
            activitybind2.Path = "documentUrl";
            this.onReviewStarted.ID = "onReviewStarted";
            activitybind3.ID = "/Workflow";
            activitybind3.Path = "ownerName";
            activitybind4.ID = "/Workflow";
            activitybind4.Path = "reviewParticipants";
            this.onReviewStarted.Roles = null;
            this.onReviewStarted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ReviewStarted.ParticipantsProperty, ((System.Workflow.ComponentModel.Bind)(activitybind4)));
            this.onReviewStarted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ReviewStarted.DocumentUrlProperty, ((System.Workflow.ComponentModel.Bind)(activitybind2)));
            this.onReviewStarted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ReviewStarted.OwnerNameProperty, ((System.Workflow.ComponentModel.Bind)(activitybind3)));
            // 
            // documentReviewReplicator
            // 
            this.documentReviewReplicator.Activities.Add(this.taskActivity);
            this.documentReviewReplicator.ID = "documentReviewReplicator";
            this.documentReviewReplicator.UntilCondition = null;
            this.documentReviewReplicator.ChildInitialized += new System.Workflow.Activities.ReplicatorChildEventHandler(this.OnReplicatorChildInitialized);
            this.documentReviewReplicator.ChildCompleted += new System.Workflow.Activities.ReplicatorChildEventHandler(this.OnReplicatorChildCompleted);
            this.documentReviewReplicator.Initialized += new System.Workflow.Activities.ReplicatorInitializedEventHandler(this.OnReplicatorInitialized);
            // 
            // reviewCompleted
            // 
            activitybind5.ID = "/Workflow";
            activitybind5.Path = "correlationReference";
            this.reviewCompleted.CorrelationReference = activitybind5;
            activitybind6.ID = "/Workflow";
            activitybind6.Path = "documentUrl";
            this.reviewCompleted.ID = "reviewCompleted";
            activitybind7.ID = "/Workflow";
            activitybind7.Path = "ownerName";
            activitybind8.ID = "/Workflow";
            activitybind8.Path = "reviewResults";
            this.reviewCompleted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ReviewCompleted.DocumentUrlProperty, ((System.Workflow.ComponentModel.Bind)(activitybind6)));
            this.reviewCompleted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ReviewCompleted.OwnerNameProperty, ((System.Workflow.ComponentModel.Bind)(activitybind7)));
            this.reviewCompleted.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ReviewCompleted.ReviewResultsProperty, ((System.Workflow.ComponentModel.Bind)(activitybind8)));
            // 
            // eventHandlers
            // 
            this.eventHandlers.Activities.Add(this.addParticipantsEventDriven);
            this.eventHandlers.ID = "eventHandlers";
            // 
            // taskActivity
            // 
            this.taskActivity.DocumentUrl = null;
            this.taskActivity.ID = "taskActivity";
            this.taskActivity.Owner = null;
            this.taskActivity.Reviewer = null;
            this.taskActivity.ReviewOutcome = null;
            // 
            // addParticipantsEventDriven
            // 
            this.addParticipantsEventDriven.Activities.Add(this.participantsAdded);
            this.addParticipantsEventDriven.ID = "addParticipantsEventDriven";
            // 
            // taskActivity_listen1
            // 
            // 
            // participantsAdded
            // 
            activitybind9.ID = "/Workflow";
            activitybind9.Path = "correlationReference";
            this.participantsAdded.CorrelationReference = activitybind9;
            activitybind10.ID = "/Workflow";
            activitybind10.Path = "documentUrl";
            this.participantsAdded.ID = "participantsAdded";
            activitybind11.ID = "/Workflow";
            activitybind11.Path = "ownerName";
            activitybind12.ID = "/Workflow";
            activitybind12.Path = "addedReviewParticipants";
            this.participantsAdded.Roles = null;
            this.participantsAdded.Invoked += new System.EventHandler(this.OnParticipantsAdded);
            this.participantsAdded.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ParticipantsAdded.DocumentUrlProperty, ((System.Workflow.ComponentModel.Bind)(activitybind10)));
            this.participantsAdded.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ParticipantsAdded.OwnerNameProperty, ((System.Workflow.ComponentModel.Bind)(activitybind11)));
            this.participantsAdded.SetBinding(Microsoft.Samples.Workflow.Applications.DocumentReview.ParticipantsAdded.ParticipantsProperty, ((System.Workflow.ComponentModel.Bind)(activitybind12)));
            // 
            // taskActivity_eventDriven1
            // 
            // 
            // taskActivity_eventDriven2
            // 
            // 
            // compensationHandler1
            // 
            this.compensationHandler1.ID = "compensationHandler1";
            // 
            // DocumentReviewWorkflow
            // 
            this.Activities.Add(this.onReviewStarted);
            this.Activities.Add(this.documentReviewReplicator);
            this.Activities.Add(this.reviewCompleted);
            this.Activities.Add(this.eventHandlers);
            this.Activities.Add(this.compensationHandler1);
            this.DynamicUpdateCondition = null;
            this.ID = "DocumentReviewWorkflow";

        }

        #endregion

        private CompensationHandler compensationHandler1;
        private ReviewCompleted reviewCompleted;
        private ReviewStarted onReviewStarted;
        private Replicator documentReviewReplicator;
        private TaskActivity taskActivity;
        private EventHandlers eventHandlers;
        private EventDriven addParticipantsEventDriven;
        private ParticipantsAdded participantsAdded;
    }
}
