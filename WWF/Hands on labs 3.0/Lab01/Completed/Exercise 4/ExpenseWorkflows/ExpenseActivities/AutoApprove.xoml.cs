//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Drawing.Design;

namespace ExpenseActivities
{
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(CustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(GetManager), "Resources.Approved.bmp")]
    public partial class AutoApprove : SequenceActivity
	{
        public static DependencyProperty AmountProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Amount", typeof(int), typeof(AutoApprove));

        [Description("The amount of the expense report.")]
        [Category("Some Category")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Amount
        {
            get
            {
                return ((int)(base.GetValue(AutoApprove.AmountProperty)));
            }
            set
            {
                base.SetValue(AutoApprove.AmountProperty, value);
            }
        }

        public static DependencyProperty ApprovedProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Approved", typeof(bool), typeof(AutoApprove));

        [Description("Determines whether an expense report can be automatically approved.")]
        [Category("Some Category")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Approved
        {
            get
            {
                return ((bool)(base.GetValue(AutoApprove.ApprovedProperty)));
            }
            set
            {
                base.SetValue(AutoApprove.ApprovedProperty, value);
            }
        }
	}
}
