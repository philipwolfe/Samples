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

Imports System.Workflow.Runtime
Imports System.Workflow.Activities

' Well Known Web Service object
Public Class ExpenseRemoteService
    Inherits MarshalByRefObject

    Private workflowRuntime As WorkflowRuntime

    Private expsvc As ExpenseLocalServices.ExpenseLocalService

    Public Sub New()
        MyBase.New()
        Me.StartWorkflowHost()
    End Sub

    Public Function SubmitExpenseReport(ByVal report As ExpenseLocalServices.ExpenseReport) As System.Guid
        Try
            System.Console.WriteLine("Submit Expense Report")
            ' Create a new GUID for the WorkflowInstanceID
            Dim WorkflowInstanceId As System.Guid = report.ExpenseReportId
            expsvc.RaiseExpenseReportSubmittedEvent(WorkflowInstanceId, report)
            Return WorkflowInstanceId
        Catch excp As Exception
            System.Console.WriteLine(excp.ToString)
            Throw excp
        End Try
    End Function

    Public Function ExpenseReportReviewed(ByVal report As ExpenseLocalServices.ExpenseReport, ByVal review As ExpenseLocalServices.ExpenseReportReview) As System.Guid
        ' Create a new GUID for the WorkflowInstanceID
        Dim WorkflowInstanceId As System.Guid = report.ExpenseReportId

        expsvc.RaiseExpenseReportReviewedEvent(WorkflowInstanceId, report, review)
        Return WorkflowInstanceId
    End Function

    Public Function GetExpenseReportsList() As List(Of ExpenseReport)
        Return expsvc.GetExpenseReportsList
    End Function

    Public Function GetExpenseReport(ByVal ExpenseReportId As System.Guid) As ExpenseReport
        Return expsvc.GetExpenseReport(ExpenseReportId)
    End Function

    Private Sub StartWorkflowHost()

        ' Create a new Workflow Runtime
        workflowRuntime = New WorkflowRuntime

        ' Start the Workflow services
        workflowRuntime.StartRuntime()

        Dim assm As System.Reflection.Assembly = System.Reflection.Assembly.Load("ExpenseWorkflows")
        Dim typRemoteService As System.Type = assm.GetType("ExpenseWorkflows.Workflow1")

        ' Create a new instance of the local service and host it in an ExternalDataExchangeService
        ' ...give it a reference to the container and type of workflow
        Dim exSvc As ExternalDataExchangeService = New ExternalDataExchangeService

        workflowRuntime.AddService(exSvc)
        expsvc = New ExpenseLocalServices.ExpenseLocalService(workflowRuntime, typRemoteService)
        exSvc.AddService(expsvc)
    End Sub


End Class
