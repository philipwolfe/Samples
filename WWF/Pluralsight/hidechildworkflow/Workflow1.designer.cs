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
using CallWorkflowActivityLibrary;

namespace HideChildWorkflow
{
	partial class Workflow1
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.invokeWorkflowActivity1 = new System.Workflow.Activities.InvokeWorkflowActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.callWorkflow1 = new CallWorkflowActivityLibrary.CallWorkflowActivity();
            // 
            // invokeWorkflowActivity1
            // 
            this.invokeWorkflowActivity1.Enabled = false;
            this.invokeWorkflowActivity1.Name = "invokeWorkflowActivity1";
            this.invokeWorkflowActivity1.TargetWorkflow = typeof(CalledWorkflowLibrary.Workflow1);
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // callWorkflow1
            // 
            this.callWorkflow1.Name = "callWorkflow1";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "CalledWorkflowIn";
            workflowparameterbinding1.ParameterName = "MyProperty";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "CalledWorkflowOut";
            workflowparameterbinding2.ParameterName = "OutParameter";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.callWorkflow1.Parameters.Add(workflowparameterbinding1);
            this.callWorkflow1.Parameters.Add(workflowparameterbinding2);
            this.callWorkflow1.Type = typeof(CalledWorkflowLibrary.Workflow1);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.callWorkflow1);
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.invokeWorkflowActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity1;
        private InvokeWorkflowActivity invokeWorkflowActivity1;
        private CallWorkflowActivity callWorkflow1;








    }
}
