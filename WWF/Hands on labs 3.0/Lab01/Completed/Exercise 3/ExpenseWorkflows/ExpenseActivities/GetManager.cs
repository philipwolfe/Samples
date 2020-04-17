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
using System.Drawing.Drawing2D;

namespace ExpenseActivities
{

    [ActivityDesignerThemeAttribute(typeof(CustomActivityDesignerTheme))]
    public class CustomActivityDesigner : ActivityDesigner
    {
        
    }

    internal sealed class CustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public CustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.GreenYellow;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.Green;
            this.BackColorEnd = Color.Yellow;
            this.BackgroundStyle = LinearGradientMode.Vertical;
        }
    }

    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(CustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(GetManager), "Resources.FindManager.bmp")]
    public partial class GetManager : System.Workflow.ComponentModel.Activity
    {
        public static DependencyProperty ReportEmployeeIdProperty = DependencyProperty.Register("ReportEmployeeId", typeof(System.String), typeof(ExpenseActivities.GetManager));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        public string ReportEmployeeId
        {
            get
            {
                return ((string)(base.GetValue(ExpenseActivities.GetManager.ReportEmployeeIdProperty)));
            }
            set
            {
                base.SetValue(ExpenseActivities.GetManager.ReportEmployeeIdProperty, value);
            }
        }

        public static DependencyProperty ManagerEmployeeIdProperty = DependencyProperty.Register("ManagerEmployeeId", typeof(System.String), typeof(ExpenseActivities.GetManager));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        public String ManagerEmployeeId
        {
            get
            {
                return ((string)(base.GetValue(ExpenseActivities.GetManager.ManagerEmployeeIdProperty)));
            }
            set
            {
                base.SetValue(ExpenseActivities.GetManager.ManagerEmployeeIdProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            base.Execute(executionContext);
            ((GetManager)executionContext.Activity).ManagerEmployeeId = "neilhut";
            return ActivityExecutionStatus.Closed;
        }
    }
}
