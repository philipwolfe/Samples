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
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SwitchSampleApplication
{
	partial class SwitchSampleWorkflow
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            this.switch3_defaultcase = new System.Workflow.Activities.CodeActivity();
            this.switch3_case3 = new System.Workflow.Activities.CodeActivity();
            this.switch3_case2 = new System.Workflow.Activities.CodeActivity();
            this.switch3_case1 = new System.Workflow.Activities.CodeActivity();
            this.switch2_defaultcase = new System.Workflow.Activities.CodeActivity();
            this.switch2_case3 = new System.Workflow.Activities.CodeActivity();
            this.switch2_case2 = new System.Workflow.Activities.CodeActivity();
            this.switch2_case1 = new System.Workflow.Activities.CodeActivity();
            this.switch1_defaultcase = new System.Workflow.Activities.CodeActivity();
            this.switch1_case3 = new System.Workflow.Activities.CodeActivity();
            this.switch1_case2 = new System.Workflow.Activities.CodeActivity();
            this.switch1_case1 = new System.Workflow.Activities.CodeActivity();
            this.switch3 = new SwitchActivity.Switch();
            this.switch2 = new SwitchActivity.Switch();
            this.switch1 = new SwitchActivity.Switch();
            // 
            // switch3_defaultcase
            // 
            this.switch3_defaultcase.Name = "switch3_defaultcase";
            this.switch3_defaultcase.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            activitybind1.Name = "SwitchSampleWorkflow";
            activitybind1.Path = "case3";
            // 
            // switch3_case3
            // 
            this.switch3_case3.Name = "switch3_case3";
            this.switch3_case3.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch3_case3.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "SwitchSampleWorkflow";
            activitybind2.Path = "case2";
            // 
            // switch3_case2
            // 
            this.switch3_case2.Name = "switch3_case2";
            this.switch3_case2.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch3_case2.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "SwitchSampleWorkflow";
            activitybind3.Path = "case1";
            // 
            // switch3_case1
            // 
            this.switch3_case1.Name = "switch3_case1";
            this.switch3_case1.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch3_case1.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // switch2_defaultcase
            // 
            this.switch2_defaultcase.Name = "switch2_defaultcase";
            this.switch2_defaultcase.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            activitybind4.Name = "SwitchSampleWorkflow";
            activitybind4.Path = "case3";
            // 
            // switch2_case3
            // 
            this.switch2_case3.Name = "switch2_case3";
            this.switch2_case3.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch2_case3.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            activitybind5.Name = "SwitchSampleWorkflow";
            activitybind5.Path = "case2";
            // 
            // switch2_case2
            // 
            this.switch2_case2.Name = "switch2_case2";
            this.switch2_case2.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch2_case2.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            activitybind6.Name = "SwitchSampleWorkflow";
            activitybind6.Path = "case1";
            // 
            // switch2_case1
            // 
            this.switch2_case1.Name = "switch2_case1";
            this.switch2_case1.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch2_case1.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            // 
            // switch1_defaultcase
            // 
            this.switch1_defaultcase.Name = "switch1_defaultcase";
            this.switch1_defaultcase.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            activitybind7.Name = "SwitchSampleWorkflow";
            activitybind7.Path = "case3";
            // 
            // switch1_case3
            // 
            this.switch1_case3.Name = "switch1_case3";
            this.switch1_case3.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch1_case3.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            activitybind8.Name = "SwitchSampleWorkflow";
            activitybind8.Path = "case2";
            // 
            // switch1_case2
            // 
            this.switch1_case2.Name = "switch1_case2";
            this.switch1_case2.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch1_case2.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            activitybind9.Name = "SwitchSampleWorkflow";
            activitybind9.Path = "case1";
            // 
            // switch1_case1
            // 
            this.switch1_case1.Name = "switch1_case1";
            this.switch1_case1.ExecuteCode += new System.EventHandler(this.ExecuteIt);
            this.switch1_case1.SetBinding(SwitchActivity.Switch.CasesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            // 
            // switch3
            // 
            this.switch3.Activities.Add(this.switch3_case1);
            this.switch3.Activities.Add(this.switch3_case2);
            this.switch3.Activities.Add(this.switch3_case3);
            this.switch3.Activities.Add(this.switch3_defaultcase);
            activitybind10.Name = "SwitchSampleWorkflow";
            activitybind10.Path = "expression3";
            this.switch3.Name = "switch3";
            this.switch3.SetBinding(SwitchActivity.Switch.ExpressionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // switch2
            // 
            this.switch2.Activities.Add(this.switch2_case1);
            this.switch2.Activities.Add(this.switch2_case2);
            this.switch2.Activities.Add(this.switch2_case3);
            this.switch2.Activities.Add(this.switch2_defaultcase);
            activitybind11.Name = "SwitchSampleWorkflow";
            activitybind11.Path = "expression2";
            this.switch2.Name = "switch2";
            this.switch2.SetBinding(SwitchActivity.Switch.ExpressionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // switch1
            // 
            this.switch1.Activities.Add(this.switch1_case1);
            this.switch1.Activities.Add(this.switch1_case2);
            this.switch1.Activities.Add(this.switch1_case3);
            this.switch1.Activities.Add(this.switch1_defaultcase);
            activitybind12.Name = "SwitchSampleWorkflow";
            activitybind12.Path = "expression1";
            this.switch1.Name = "switch1";
            this.switch1.SetBinding(SwitchActivity.Switch.ExpressionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // SwitchSampleWorkflow
            // 
            this.Activities.Add(this.switch1);
            this.Activities.Add(this.switch2);
            this.Activities.Add(this.switch3);
            this.Name = "SwitchSampleWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity switch3_defaultcase;
        private CodeActivity switch3_case3;
        private CodeActivity switch3_case2;
        private CodeActivity switch3_case1;
        private SwitchActivity.Switch switch3;
        private CodeActivity switch2_defaultcase;
        private CodeActivity switch2_case3;
        private CodeActivity switch2_case2;
        private CodeActivity switch2_case1;
        private SwitchActivity.Switch switch2;
        private CodeActivity switch1_case3;
        private CodeActivity switch1_defaultcase;
        private CodeActivity switch1_case1;
        private SwitchActivity.Switch switch1;
        private CodeActivity switch1_case2;






























    }
}
