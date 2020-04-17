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
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace AtomicTransactionWorkflow
{
	public sealed partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.WorkflowExceptionHandler = new System.Workflow.Activities.CodeActivity();
            this.faultHandlerActivity1 = new System.Workflow.ComponentModel.FaultHandlerActivity();
            this.throwActivity1 = new System.Workflow.ComponentModel.ThrowActivity();
            this.Credit = new System.Workflow.Activities.CodeActivity();
            this.Debit = new System.Workflow.Activities.CodeActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.FinishWorkflow = new System.Workflow.Activities.CodeActivity();
            this.transactionScopeActivity1 = new System.Workflow.ComponentModel.TransactionScopeActivity();
            // 
            // WorkflowExceptionHandler
            // 
            this.WorkflowExceptionHandler.Name = "WorkflowExceptionHandler";
            this.WorkflowExceptionHandler.ExecuteCode += new System.EventHandler(this.OnException);
            // 
            // faultHandlerActivity1
            // 
            this.faultHandlerActivity1.Activities.Add(this.WorkflowExceptionHandler);
            this.faultHandlerActivity1.FaultType = typeof(System.Exception);
            this.faultHandlerActivity1.Name = "faultHandlerActivity1";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "exception";
            // 
            // throwActivity1
            // 
            this.throwActivity1.FaultType = typeof(System.Exception);
            this.throwActivity1.Name = "throwActivity1";
            this.throwActivity1.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // Credit
            // 
            this.Credit.Name = "Credit";
            this.Credit.ExecuteCode += new System.EventHandler(this.CreditCodeHandler);
            // 
            // Debit
            // 
            this.Debit.Name = "Debit";
            this.Debit.ExecuteCode += new System.EventHandler(this.DebitCodeHandler);
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Activities.Add(this.faultHandlerActivity1);
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // FinishWorkflow
            // 
            this.FinishWorkflow.Name = "FinishWorkflow";
            this.FinishWorkflow.ExecuteCode += new System.EventHandler(this.OnFinishWorkflow);
            // 
            // transactionScopeActivity1
            // 
            this.transactionScopeActivity1.Activities.Add(this.Debit);
            this.transactionScopeActivity1.Activities.Add(this.Credit);
            this.transactionScopeActivity1.Activities.Add(this.throwActivity1);
            this.transactionScopeActivity1.Name = "transactionScopeActivity1";
            this.transactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            // 
            // Workflow1
            // 
            this.Activities.Add(this.transactionScopeActivity1);
            this.Activities.Add(this.FinishWorkflow);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Activities.Add(this.cancellationHandlerActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity WorkflowExceptionHandler;
        private FaultHandlerActivity faultHandlerActivity1;
        private CodeActivity FinishWorkflow;
        private CancellationHandlerActivity cancellationHandlerActivity1;
        private CodeActivity Debit;
        private TransactionScopeActivity transactionScopeActivity1;
        private ThrowActivity throwActivity1;
        private CodeActivity Credit;
        private FaultHandlersActivity faultHandlersActivity1;























    }
}
