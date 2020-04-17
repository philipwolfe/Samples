//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;

using ExpenseContracts;
using ExpenseLocalServices;

namespace ExpenseActivities
{
    //[Designer(typeof(ManagerApprovalDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(ManagerApproval), "Resources.AskForManagerApproval.png")]
	public partial class ManagerApproval : SequenceActivity
	{
        public static DependencyProperty ManagerEmployeeIdProperty = DependencyProperty.Register("ManagerEmployeeId", typeof(String), typeof(ManagerApproval));
        public static DependencyProperty reportProperty = DependencyProperty.Register("report", typeof(ExpenseReport), typeof(ManagerApproval));
        public ExpenseReportReviewedEventArgs reviewArgs = default(ExpenseReportReviewedEventArgs);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public string ManagerEmployeeId
        {
            get
            {
                return ((string)(base.GetValue(ManagerEmployeeIdProperty)));
            }
            set
            {
                base.SetValue(ManagerEmployeeIdProperty, value);
            }
        }

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public ExpenseReport report
        {
            get
            {
                return ((ExpenseReport)(base.GetValue(reportProperty)));
            }
            set
            {
                base.SetValue(reportProperty, value);
            }
        }
    }
}
