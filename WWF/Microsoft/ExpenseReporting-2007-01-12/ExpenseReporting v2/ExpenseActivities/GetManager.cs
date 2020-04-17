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
using System.ComponentModel.Design;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;

namespace ExpenseActivities
{
    [ToolboxBitmap(typeof (GetManager), "Resources.FindManager.png")]
    [Designer(typeof (GetManagerDesigner), typeof (IDesigner))]
    public partial class GetManager : Activity
    {
        public GetManager()
        {
            InitializeComponent();
        }

        public static DependencyProperty ReportEmployeeIdProperty =
            DependencyProperty.Register("ReportEmployeeId", typeof (String), typeof (GetManager));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Required)]
        [BrowsableAttribute(true)]
        public string ReportEmployeeId
        {
            get { return ((string) (base.GetValue(ReportEmployeeIdProperty))); }
            set { base.SetValue(ReportEmployeeIdProperty, value); }
        }

        public static DependencyProperty ManagerEmployeeIdProperty =
            DependencyProperty.Register("ManagerEmployeeId", typeof (String), typeof (GetManager));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOptionAttribute(ValidationOption.Required)]
        [BrowsableAttribute(true)]
        public String ManagerEmployeeId
        {
            get { return ((string) (base.GetValue(ManagerEmployeeIdProperty))); }
            set { base.SetValue(ManagerEmployeeIdProperty, value); }
        }

        public static DependencyProperty ManagerEmailProperty =
            DependencyProperty.Register("ManagerEmail", typeof (string), typeof (GetManager));

        [ValidationOption(ValidationOption.Optional)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ManagerEmail
        {
            get { return ((string) (base.GetValue(ManagerEmailProperty))); }
            set { base.SetValue(ManagerEmailProperty, value); }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            // For this example, let's just return a static sample data  
            ManagerEmployeeId = "manager1";
            ManagerEmail = "manager@localhost";

            return ActivityExecutionStatus.Closed;
        }
    }
}