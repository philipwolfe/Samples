'---------------------------------------------------------------------
'  This file is part of the  BPEL for Windows Workflow Foundation Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Imports System
Imports System.Web.Services
Imports System.IO
Imports System.Workflow.Runtime
Imports System.Workflow.ComponentModel.Compiler
Imports Microsoft.Workflow.Bpel.Activities

Public Class SalutationService
    Inherits System.Web.Services.WebService

    Public Sub New()

        If Application("WorkflowRuntime") Is Nothing Then
            Dim workflowRuntime As WorkflowRuntime = New WorkflowRuntime()

            Application("WorkflowRuntime") = workflowRuntime

            Dim workflowType As Type = GetType(HelloWorldSample.HelloWorldWorkflow)

            Dim typeProvider As TypeProvider = New TypeProvider(workflowRuntime)
            typeProvider.AddAssembly(workflowType.Assembly)
            workflowRuntime.AddService(typeProvider)

            Dim messagingService As BpelInMemoryMessagingService = New BpelInMemoryMessagingService()
            messagingService.Runtime = workflowRuntime
            workflowRuntime.AddService(messagingService)

            Dim deploymentService As WorkflowDeploymentService = New WorkflowDeploymentService(workflowType, workflowRuntime)
            deploymentService.Deploy()

            messagingService.RegisterProxy("FileServiceSoap", workflowType.Assembly.Location)

            workflowRuntime.StartRuntime()
        End If
    End Sub

    <WebMethod()> _
    Public Sub SendSalutation(ByVal message As String)
        Dim workflowRuntime As WorkflowRuntime = Application("WorkflowRuntime")
        Dim messagingService As BpelMessagingService = workflowRuntime.GetService(Of BpelMessagingService)()

        Dim parameters As Object = BpelInMemoryMessagingService.PackParameters(New Object() {message}, GetType(ns0.SendSalutationSoapIn))
        Dim retVal As Object = messagingService.InvokeWorkflow("SalutationLinkType", "SalutationServiceSoap", "SendSalutation", GetType(HelloWorldSample.HelloWorldWorkflow).FullName, parameters)

        If retVal Is GetType(Exception) Then
            Throw CType(retVal, Exception)
        End If
    End Sub

End Class
