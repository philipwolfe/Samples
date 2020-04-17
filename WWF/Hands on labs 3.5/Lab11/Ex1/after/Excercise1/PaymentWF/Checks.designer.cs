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

namespace PaymentWF
{
	partial class Checks
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
            System.Workflow.Activities.OperationInfo operationinfo1 = new System.Workflow.Activities.OperationInfo();
            System.Workflow.Activities.OperationParameterInfo operationparameterinfo1 = new System.Workflow.Activities.OperationParameterInfo();
            System.Workflow.Activities.OperationParameterInfo operationparameterinfo2 = new System.Workflow.Activities.OperationParameterInfo();
            System.Workflow.Activities.WorkflowServiceAttributes workflowserviceattributes1 = new System.Workflow.Activities.WorkflowServiceAttributes();
            this.CheckLogic = new System.Workflow.Activities.CodeActivity();
            this.receiveActivity1 = new System.Workflow.Activities.ReceiveActivity();
            // 
            // CheckLogic
            // 
            this.CheckLogic.Name = "CheckLogic";
            this.CheckLogic.ExecuteCode += new System.EventHandler(this.CheckLogic_ExecuteCode);
            // 
            // receiveActivity1
            // 
            this.receiveActivity1.Activities.Add(this.CheckLogic);
            this.receiveActivity1.CanCreateInstance = true;
            this.receiveActivity1.Name = "receiveActivity1";
            activitybind1.Name = "Checks";
            activitybind1.Path = "checkText";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "Checks";
            activitybind2.Path = "checkAmount";
            workflowparameterbinding2.ParameterName = "Amount";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding1);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding2);
            operationinfo1.ContractName = "ICheckOperations";
            operationinfo1.Name = "Write";
            operationparameterinfo1.Attributes = ((System.Reflection.ParameterAttributes)((System.Reflection.ParameterAttributes.Out | System.Reflection.ParameterAttributes.Retval)));
            operationparameterinfo1.Name = "(ReturnValue)";
            operationparameterinfo1.ParameterType = typeof(string);
            operationparameterinfo1.Position = -1;
            operationparameterinfo2.Attributes = System.Reflection.ParameterAttributes.In;
            operationparameterinfo2.Name = "Amount";
            operationparameterinfo2.ParameterType = typeof(decimal);
            operationparameterinfo2.Position = 0;
            operationinfo1.Parameters.Add(operationparameterinfo1);
            operationinfo1.Parameters.Add(operationparameterinfo2);
            this.receiveActivity1.ServiceOperationInfo = operationinfo1;
            workflowserviceattributes1.ConfigurationName = "PaymentWF.Checks";
            workflowserviceattributes1.Name = "Checks";
            // 
            // Checks
            // 
            this.Activities.Add(this.receiveActivity1);
            this.Name = "Checks";
            this.SetValue(System.Workflow.Activities.ReceiveActivity.WorkflowServiceAttributesProperty, workflowserviceattributes1);
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity CheckLogic;
        private ReceiveActivity receiveActivity1;






    }
}
