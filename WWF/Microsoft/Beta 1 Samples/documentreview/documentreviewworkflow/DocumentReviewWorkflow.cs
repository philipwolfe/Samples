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
namespace Microsoft.Samples.Workflow.Applications.DocumentReview
{
    using System;
    using System.Collections.Generic;
    using System.Workflow.Runtime.Messaging;
    using System.Workflow.Activities;

    public sealed partial class DocumentReviewWorkflow : SequentialWorkflow
    {
        private CorrelationReference correlationReference = new CorrelationReference();
        private string documentUrl = null;
        private string ownerName = null;
        private string[] reviewParticipants = null;
        private string[] addedReviewParticipants = null;
        private Dictionary<string, string> reviewResults = new Dictionary<string, string>();

        public DocumentReviewWorkflow()
        {
            InitializeComponent();
        }

        private void OnReplicatorInitialized(object sender, ReplicatorEventArgs e)
        {
            e.ExecutionType = ExecutionType.Parallel;
            e.Children = this.reviewParticipants;
        }

        private void OnReplicatorChildInitialized(object sender, ReplicatorChildEventArgs e)
        {
            TaskActivity taskActivity = (TaskActivity)e.Activity;

            taskActivity.DocumentUrl = this.documentUrl;
            taskActivity.Owner = this.ownerName;

            taskActivity.Reviewer = (string)e.InstanceData;
        }

        private void OnReplicatorChildCompleted(object sender, ReplicatorChildEventArgs e)
        {
            TaskActivity taskActivity = (TaskActivity)e.Activity;

            this.reviewResults.Add(taskActivity.Reviewer, taskActivity.ReviewOutcome);
        }

        private void OnParticipantsAdded(object sender, EventArgs e)
        {
            Replicator replicator = (Replicator)this.GetActivityByName("documentReviewReplicator");

            foreach (string participant in this.addedReviewParticipants)
            {
                replicator.AddChild(participant);
            }
        }
    }
}
