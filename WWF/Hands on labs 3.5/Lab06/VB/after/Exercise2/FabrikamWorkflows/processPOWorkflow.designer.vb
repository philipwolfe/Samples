'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class processPOWorkflow

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding1 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind2 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding2 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Me.webServiceResponsePO = New System.Workflow.Activities.WebServiceOutputActivity
        Me.webServiceReceivePO = New System.Workflow.Activities.WebServiceInputActivity
        '
        'webServiceResponsePO
        '
        Me.webServiceResponsePO.InputActivityName = "webServiceReceivePO"
        Me.webServiceResponsePO.Name = "webServiceResponsePO"
        activitybind1.Name = "processPOWorkflow"
        activitybind1.Path = "returnedPO"
        workflowparameterbinding1.ParameterName = "(ReturnValue)"
        workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        Me.webServiceResponsePO.ParameterBindings.Add(workflowparameterbinding1)
        AddHandler Me.webServiceResponsePO.SendingOutput, AddressOf Me.webServiceResponsePO_SendingOutput
        '
        'webServiceReceivePO
        '
        Me.webServiceReceivePO.InterfaceType = GetType(FabrikamWorkflows.processPOWorkflow.IProcessReceivedPO)
        Me.webServiceReceivePO.IsActivating = True
        Me.webServiceReceivePO.MethodName = "ReceiveAndProcessPO"
        Me.webServiceReceivePO.Name = "webServiceReceivePO"
        activitybind2.Name = "processPOWorkflow"
        activitybind2.Path = "receivedPO"
        workflowparameterbinding2.ParameterName = "aPO"
        workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.webServiceReceivePO.ParameterBindings.Add(workflowparameterbinding2)
        '
        'processPOWorkflow
        '
        Me.Activities.Add(Me.webServiceReceivePO)
        Me.Activities.Add(Me.webServiceResponsePO)
        Me.Name = "processPOWorkflow"
        Me.CanModifyActivities = False

    End Sub
    Private webServiceResponsePO As System.Workflow.Activities.WebServiceOutputActivity
    Private webServiceReceivePO As System.Workflow.Activities.WebServiceInputActivity

End Class
