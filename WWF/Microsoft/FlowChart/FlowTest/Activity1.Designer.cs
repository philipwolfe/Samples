//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace FlowTest
{
	public partial class Activity1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.action4 = new FlowChart.Action();
            this.action3 = new FlowChart.Action();
            this.action2 = new FlowChart.Action();
            this.action1 = new FlowChart.Action();
            this.decision1 = new FlowChart.Decision();
            // 
            // action4
            // 
            this.action4.Name = "action4";
            this.action4.NextActivityName = null;
            // 
            // action3
            // 
            this.action3.Name = "action3";
            this.action3.NextActivityName = "action4";
            // 
            // action2
            // 
            this.action2.Name = "action2";
            this.action2.NextActivityName = "";
            // 
            // action1
            // 
            this.action1.Name = "action1";
            this.action1.NextActivityName = "action3";
            // 
            // decision1
            // 
            ruleconditionreference1.ConditionName = "Condition1";
            this.decision1.Condition = ruleconditionreference1;
            this.decision1.FalseActivityName = "action2";
            this.decision1.Name = "decision1";
            this.decision1.TrueActivityName = "action1";
            // 
            // Activity1
            // 
            this.Activities.Add(this.decision1);
            this.Activities.Add(this.action1);
            this.Activities.Add(this.action2);
            this.Activities.Add(this.action3);
            this.Activities.Add(this.action4);
            this.Name = "Activity1";
            this.CanModifyActivities = false;

		}

		#endregion

        private FlowChart.Decision decision1;
        private FlowChart.Action action1;
        private FlowChart.Action action3;
        private FlowChart.Action action4;
        private FlowChart.Action action2;



















































































































































































































    }
}
