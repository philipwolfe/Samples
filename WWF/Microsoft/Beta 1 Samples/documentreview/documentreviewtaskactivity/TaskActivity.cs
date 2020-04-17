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
    using System.Workflow.ComponentModel.Compiler;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.Runtime.Messaging;
    using System.Workflow.Activities;
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public partial class TaskActivity : Sequence
    {
        private CorrelationReference correlationReference = new CorrelationReference();

        public TaskActivity()
        {
            InitializeComponent();
        }

        #region TaskActivity properties
        public static DependencyProperty DocumentUrlProperty = DependencyProperty.Register("DocumentUrl", typeof(System.String), typeof(TaskActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public string DocumentUrl
        {
            get
            {
                return ((string)(base.GetValue(TaskActivity.DocumentUrlProperty)));
            }
            set
            {
                base.SetValue(TaskActivity.DocumentUrlProperty, value);
            }
        }

        public static DependencyProperty OwnerProperty = DependencyProperty.Register("Owner", typeof(System.String), typeof(TaskActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public string Owner
        {
            get
            {
                return ((string)(base.GetValue(TaskActivity.OwnerProperty)));
            }
            set
            {
                base.SetValue(TaskActivity.OwnerProperty, value);
            }
        }

        public static DependencyProperty ReviewerProperty = DependencyProperty.Register("Reviewer", typeof(System.String), typeof(TaskActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public string Reviewer
        {
            get
            {
                return ((string)(base.GetValue(TaskActivity.ReviewerProperty)));
            }
            set
            {
                base.SetValue(TaskActivity.ReviewerProperty, value);
            }
        }

        public static DependencyProperty ReviewOutcomeProperty = DependencyProperty.Register("ReviewOutcome", typeof(System.String), typeof(TaskActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public string ReviewOutcome
        {
            get
            {
                return ((string)(base.GetValue(TaskActivity.ReviewOutcomeProperty)));
            }
            set
            {
                base.SetValue(TaskActivity.ReviewOutcomeProperty, value);
            }
        }
        #endregion TaskActivity properties

        private void ReviewTimeoutOccured(object sender, EventArgs e)
        {
            this.ReviewOutcome = "No response received";
        }
    }
}
