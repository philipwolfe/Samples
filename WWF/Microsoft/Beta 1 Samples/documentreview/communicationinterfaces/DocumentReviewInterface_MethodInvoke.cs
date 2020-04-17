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
    using System.Collections;
    using System.ComponentModel;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.Runtime;
    using System.Collections.Generic;
    
    /// <summary>
    /// Summary description for ReviewCompleted.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public sealed class ReviewCompleted : InvokeMethodActivity
    {
        public ReviewCompleted()
        {
            this.InterfaceType = typeof(IDocumentReview);
            this.MethodName = "ReviewCompleted";
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

        public static DependencyProperty OwnerNameProperty = DependencyProperty.Register("OwnerName", typeof(string), typeof(ReviewCompleted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public string OwnerName
        {
            get
            {
                return (string)base.GetValue(ReviewCompleted.OwnerNameProperty);
            }
            set
            {
                base.SetValue(ReviewCompleted.OwnerNameProperty, value);
            }
        }

        public static DependencyProperty DocumentUrlProperty = DependencyProperty.Register("DocumentUrl", typeof(string), typeof(ReviewCompleted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public string DocumentUrl
        {
            get
            {
                return (string)base.GetValue(ReviewCompleted.DocumentUrlProperty);
            }
            set
            {
                base.SetValue(ReviewCompleted.DocumentUrlProperty, value);
            }
        }

        public static DependencyProperty ReviewResultsProperty = DependencyProperty.Register("ReviewResults", typeof(Dictionary<string, string>), typeof(ReviewCompleted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public Dictionary<string, string> ReviewResults
        {
            get
            {
                return (Dictionary<string, string>)base.GetValue(ReviewCompleted.ReviewResultsProperty);
            }
            set
            {
                base.SetValue(ReviewCompleted.ReviewResultsProperty, value);
            }
        }

        protected override Status Execute(ActivityExecutionContext provider)
        {
            IDocumentReview hostInterface = provider.GetService(typeof(IDocumentReview)) as IDocumentReview;
            if ((hostInterface == null))
            {
                throw new System.InvalidOperationException();
            }
            hostInterface.ReviewCompleted(
                new DocumentInfo(
                    (string)OwnerName,
                    (string)DocumentUrl),
                ReviewResults);
            return Status.Closed;
        }
    }
}
