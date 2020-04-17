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

Imports System.Workflow.Activities
Imports System.Workflow.ComponentModel
Imports System.Workflow.Runtime

Public Class ExpenseLocalService
    Implements IExpenseService

    Private _wfruntime As WorkflowRuntime
    Private _ActivatingWorkflow As Type
    Private _ExpenseReports As List(Of ExpenseReport)

    Public Sub New(ByVal workflowRuntime As WorkflowRuntime, ByVal activatingWorkflow As Type)

        ' Store references to both the WorkflowServiceContainer and the Activating Workflow type
        ' ...in member variables so we can use them later in this Local Service.  
        _wfruntime = WorkflowRuntime
        _ActivatingWorkflow = activatingWorkflow

        ' Create a new List for storing the Expense Reports in memory
        _ExpenseReports = New List(Of ExpenseReport)()
    End Sub

#Region "IExpenseService Members"

    Public Sub ApproveExpenseReport(ByVal report As ExpenseReport) Implements IExpenseService.ApproveExpenseReport
        ' Update the status for the specified report
        UpdateReportStatus(report, StatusEnum.Approved)
    End Sub

    Public Event ExpenseReportSubmitted As EventHandler(Of ExpenseReportSubmittedEventArgs) Implements IExpenseService.ExpenseReportSubmitted

    Public Event ExpenseReportReviewed As EventHandler(Of ExpenseReportReviewedEventArgs) Implements IExpenseService.ExpenseReportReviewed

    Public Sub RejectExpenseReport(ByVal report As ExpenseReport) Implements IExpenseService.RejectExpenseReport
        ' Update the status for the specified report
        UpdateReportStatus(report, StatusEnum.Rejected)
    End Sub

    Public Sub RequestManagerApproval(ByVal report As ExpenseReport, ByVal ManagerEmplyeeId As String) Implements IExpenseService.RequestManagerApproval
        ' Update the status for the specified report
        UpdateReportStatus(report, StatusEnum.InReview)
    End Sub

#End Region

    Private Sub UpdateReportStatus(ByVal report As ExpenseReport, ByVal status As StatusEnum)

        ' Find the report specified in our local data cache
        Dim foundReport As ExpenseReport = Me.GetExpenseReport(report.ExpenseReportId)

        ' If we can't find the report, then throw an exception
        If (foundReport Is Nothing) Then
            Throw New System.ApplicationException("Unable to find the specified Expense Report")
        End If

        ' Update the status for the found report
        foundReport.Status = status
    End Sub

    Public Function GetExpenseReport(ByVal ExpenseReportId As System.Guid) As ExpenseReport
        For Each report As ExpenseReport In _ExpenseReports
            If report.ExpenseReportId.Equals(ExpenseReportId) Then
                Return report
            End If
        Next
        Return Nothing
    End Function

    Public Sub RaiseExpenseReportSubmittedEvent(ByVal InstanceId As System.Guid, ByVal report As ExpenseReport)
        ' Start the Expense Reporting workflow
        _wfruntime.CreateWorkflow(Me._ActivatingWorkflow, New Dictionary(Of String, Object), InstanceId).Start()

        ' Create the EventArgs for this event
        Dim e As ExpenseReportSubmittedEventArgs = New ExpenseReportSubmittedEventArgs(InstanceId)
        e.Report = report

        ' Raise the ExpenseReportSubmitted event
        RaiseEvent ExpenseReportSubmitted(Nothing, e)

        ' Add the Expense Report to the List
        _ExpenseReports.Add(report)
    End Sub


    Public Sub RaiseExpenseReportReviewedEvent(ByVal InstanceId As System.Guid, ByVal report As ExpenseReport, ByVal review As ExpenseReportReview)
        ' Determine the new status for the reviewed report
        Dim status As StatusEnum = StatusEnum.InReview

        If review.Approved Then
            status = StatusEnum.Approved
        Else
            status = StatusEnum.Rejected
        End If

        ' Update the status of the report 
        Me.UpdateReportStatus(report, status)

        ' Create the EventArgs for this event
        Dim e As ExpenseReportReviewedEventArgs = New ExpenseReportReviewedEventArgs(InstanceId, report, review)

        ' Raise the ExpenseReportReviewed event
        RaiseEvent ExpenseReportReviewed(Nothing, e)
    End Sub

    Public Function GetExpenseReportsList() As List(Of ExpenseReport)
        ' Return the list of ExpenseReports we've been maintaining in memory
        Return _ExpenseReports
    End Function


End Class
