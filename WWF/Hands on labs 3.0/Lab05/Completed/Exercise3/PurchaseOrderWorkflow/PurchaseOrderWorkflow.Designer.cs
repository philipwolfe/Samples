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
using System.Workflow.Activities;

namespace Microsoft.Samples.Workflow.WebWorkflow
{
    public sealed partial class PurchaseOrderWorkflow 
    {
        #region Designer generated code
        
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.ExceptionHandlerCode = new System.Workflow.Activities.CodeActivity();
            this.faultHandlerActivity1 = new System.Workflow.ComponentModel.FaultHandlerActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.InitiatePO = new System.Workflow.Activities.HandleExternalEventActivity();
            this.SetupRoles = new System.Workflow.Activities.CodeActivity();
            // 
            // ExceptionHandlerCode
            // 
            this.ExceptionHandlerCode.Name = "ExceptionHandlerCode";
            this.ExceptionHandlerCode.ExecuteCode += new System.EventHandler(this.AuthExceptionHandler);
            // 
            // faultHandlerActivity1
            // 
            this.faultHandlerActivity1.Activities.Add(this.ExceptionHandlerCode);
            this.faultHandlerActivity1.FaultType = typeof(System.Workflow.Activities.WorkflowAuthorizationException);
            this.faultHandlerActivity1.Name = "faultHandlerActivity1";
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Activities.Add(this.faultHandlerActivity1);
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            activitybind1.Name = "PurchaseOrderWorkflow";
            activitybind1.Path = "poInitiators";
            // 
            // InitiatePO
            // 
            this.InitiatePO.EventName = "InitiatePurchaseOrder";
            this.InitiatePO.InterfaceType = typeof(Microsoft.Samples.Workflow.WebWorkflow.IStartPurchaseOrder);
            this.InitiatePO.Name = "InitiatePO";
            this.InitiatePO.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnInitiatePO);
            this.InitiatePO.SetBinding(System.Workflow.Activities.HandleExternalEventActivity.RolesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // SetupRoles
            // 
            this.SetupRoles.Name = "SetupRoles";
            this.SetupRoles.ExecuteCode += new System.EventHandler(this.OnSetupRoles);
            // 
            // PurchaseOrderWorkflow
            // 
            this.Activities.Add(this.SetupRoles);
            this.Activities.Add(this.InitiatePO);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Name = "PurchaseOrderWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity ExceptionHandlerCode;
        private System.Workflow.ComponentModel.FaultHandlerActivity faultHandlerActivity1;
        private System.Workflow.ComponentModel.FaultHandlersActivity faultHandlersActivity1;
        private CodeActivity SetupRoles;
        private HandleExternalEventActivity InitiatePO;





    }
}
