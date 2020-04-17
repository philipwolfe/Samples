//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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

namespace CustomActivityLibrary
{
	public partial class CustomActivityWithCustomActivityCondition: SequenceActivity
	{
		public CustomActivityWithCustomActivityCondition()
		{
			InitializeComponent();
		}

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            ActivityExecutionStatus status = ActivityExecutionStatus.Closed;
            if (MyCustomCondition.Evaluate(executionContext.Activity, executionContext))
                status = base.Execute(executionContext);
            return status;
        }

        public static DependencyProperty MyCustomConditionProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MyCustomCondition", typeof(ActivityCondition), typeof(CustomActivityWithCustomActivityCondition));

        [Description("Description here")]
        [Category("Activity")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [TypeConverter(typeof(CustomActivityConditionTypeConverter))]
        public ActivityCondition MyCustomCondition
        {
            get
            {
                return ((ActivityCondition)(base.GetValue(CustomActivityWithCustomActivityCondition.MyCustomConditionProperty)));
            }
            set
            {
                base.SetValue(CustomActivityWithCustomActivityCondition.MyCustomConditionProperty, value);
            }
        }
	}
}
