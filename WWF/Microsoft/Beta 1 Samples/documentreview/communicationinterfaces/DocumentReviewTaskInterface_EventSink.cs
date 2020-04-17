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
    using System.ComponentModel;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.Runtime;
    using System.Workflow.ComponentModel.Compiler;
    
    /// <summary>
    /// Summary description for DocumentReviewCompleted.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public sealed class DocumentReviewTaskCompleted : EventSinkActivity
    {
        public DocumentReviewTaskCompleted()
        {
            this.InterfaceType = typeof(IDocumentReviewTask);
            this.EventName = "DocumentReviewTaskCompleted";
        }

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public override ActivityBind CorrelationReference
        {
            get
            {
                return base.CorrelationReference;
            }
            set
            {
                base.CorrelationReference = value;
            }
        }

        public static DependencyProperty OwnerProperty = DependencyProperty.Register("Owner", typeof(string), typeof(DocumentReviewTaskCompleted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public string Owner
        {
            get
            {
                return (string)base.GetValue(OwnerProperty);
            }
            set
            {
                base.SetValue(OwnerProperty, value);
            }
        }

        public static DependencyProperty DocumentUrlProperty = DependencyProperty.Register("DocumentUrl", typeof(string), typeof(DocumentReviewTaskCompleted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public string DocumentUrl
        {
            get
            {
                return (string)base.GetValue(DocumentUrlProperty);
            }
            set
            {
                base.SetValue(DocumentUrlProperty, value);
            }
        }

        public static DependencyProperty ReviewerProperty = DependencyProperty.Register("Reviewer", typeof(string), typeof(DocumentReviewTaskCompleted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public string Reviewer
        {
            get
            {
                return (string)base.GetValue(ReviewerProperty);
            }
            set
            {
                base.SetValue(ReviewerProperty, value);
            }
        }

        public static DependencyProperty ReviewOutcomeProperty = DependencyProperty.Register("ReviewOutcome", typeof(string), typeof(DocumentReviewTaskCompleted));
        
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public string ReviewOutcome
        {
            get
            {
                return (string)base.GetValue(ReviewOutcomeProperty);
            }
            set
            {
                base.SetValue(ReviewOutcomeProperty, value);
            }
        }

        protected override void Initialize(IServiceProvider provider)
        {
            IDocumentReviewTask hostInterface = provider.GetService(typeof(IDocumentReviewTask)) as IDocumentReviewTask;
            if ((hostInterface == null))
            {
                throw new System.InvalidOperationException();
            }
            hostInterface.DocumentReviewTaskCompleted += new EventHandler<DocumentReviewInfoArgs>(this.OnDocumentReviewTaskCompleted);
        }
        
        private void OnDocumentReviewTaskCompleted(object sender, DocumentReviewInfoArgs documentReviewInfoArgs)
        {
            this.Owner = documentReviewInfoArgs.DocumentReviewInfo.Owner;
            this.DocumentUrl = documentReviewInfoArgs.DocumentReviewInfo.DocumentUrl;
            this.Reviewer = documentReviewInfoArgs.DocumentReviewInfo.Reviewer;
            this.ReviewOutcome = documentReviewInfoArgs.ReviewOutcome;
        }
    }
}
