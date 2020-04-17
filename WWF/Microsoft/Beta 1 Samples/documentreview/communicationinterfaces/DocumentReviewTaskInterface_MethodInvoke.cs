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
    /// Summary description for CreateDocumentReviewTask.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public sealed class CreateDocumentReviewTask : InvokeMethodActivity
    {
        public CreateDocumentReviewTask()
        {
            this.InterfaceType = typeof(IDocumentReviewTask);
            this.MethodName = "CreateDocumentReviewTask";
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
        
        public static DependencyProperty OwnerProperty = DependencyProperty.Register("Owner", typeof(string), typeof(CreateDocumentReviewTask));
        
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

        public static DependencyProperty DocumentUrlProperty = DependencyProperty.Register("DocumentUrl", typeof(string), typeof(CreateDocumentReviewTask));
        
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

        public static DependencyProperty ReviewerProperty = DependencyProperty.Register("Reviewer", typeof(string), typeof(CreateDocumentReviewTask));
        
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

        protected override Status Execute(ActivityExecutionContext provider)
        {
            IDocumentReviewTask hostInterface = provider.GetService(typeof(IDocumentReviewTask)) as IDocumentReviewTask;
            if ((hostInterface == null))
            {
                throw new System.InvalidOperationException();
            }

            hostInterface.CreateDocumentReviewTask(
                new DocumentReviewInfo(
                    (string)Owner,
                    (string)DocumentUrl,
                    (string)Reviewer));
            return Status.Closed;
        }
    }
}
