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

Imports System.Runtime.Remoting
Imports System.Configuration

Public Class Form1

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        ' Initialize .NET Remoting
        RemotingConfiguration.Configure("ManagerApplication.exe.config")
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefresh.Click
        RefreshExpenseReports()
    End Sub

    Private Sub RefreshExpenseReports()
        ' Clear the current list
        Me.lstvwExpenseReports.Items.Clear()
        ' Get the URL for the ExpenseRemoteService
        Dim strExpenseRemoteServiceUrl As String = ConfigurationManager.AppSettings("ExpenseRemoteServiceUrl").ToString
        ' Get a reference to the Expense Service through .NET Remoting
        Dim svcExpenseService As ExpenseLocalServices.ExpenseRemoteService = CType(Activator.GetObject(GetType(ExpenseLocalServices.ExpenseRemoteService), strExpenseRemoteServiceUrl), ExpenseLocalServices.ExpenseRemoteService)
        ' Get the list of current Expense Reports
        Dim reports As List(Of ExpenseLocalServices.ExpenseReport) = svcExpenseService.GetExpenseReportsList
        ' Add each Expense Report back into the list with the updated status
        For Each report As ExpenseLocalServices.ExpenseReport In reports
            Me.CreateListViewItem(report)
        Next
    End Sub

    Private Sub CreateListViewItem(ByVal report As ExpenseLocalServices.ExpenseReport)
        ' Create a new item for the ExpenseReport
        Dim lvitemExpenseReport As ListViewItem = Me.lstvwExpenseReports.Items.Add(report.ExpenseReportId.ToString, report.ExpenseReportId.ToString, "")
        ' Use the ExpenseReportId as the key & text for the new list item
        lvitemExpenseReport.Text = report.ExpenseReportId.ToString
        ' Add the value for the Amount column
        lvitemExpenseReport.SubItems.Add(report.Amount.ToString)
        ' Add the submitted time 
        lvitemExpenseReport.SubItems.Add(report.SubmittedTime.ToString)
        ' Add the Submitted By
        lvitemExpenseReport.SubItems.Add(report.SubmittedBy)
        ' Add the status
        lvitemExpenseReport.SubItems.Add(report.Status.ToString)
    End Sub

    Private Sub btnApprove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApprove.Click
        SubmitExpenseReportReview(True)
    End Sub

    Private Sub btnReject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReject.Click
        SubmitExpenseReportReview(False)
    End Sub

    Private Sub SubmitExpenseReportReview(ByVal Approved As Boolean)
        For Each lstvwitemExpenseReport As ListViewItem In Me.lstvwExpenseReports.SelectedItems
            ' Get the ExpenseReportId from the selected item in the Listview
            Dim strExpenseReportId As String = lstvwitemExpenseReport.Text
            Dim ExpenseReportId As System.Guid = New Guid(strExpenseReportId)
            ' Construct the Review for the expense report
            Dim review As ExpenseLocalServices.ExpenseReportReview = New ExpenseLocalServices.ExpenseReportReview
            review.Approved = Approved
            review.ExpenseReportId = ExpenseReportId
            review.ReviewedBy = "neilhut"
            ' Get the URL for the ExpenseRemoteService
            Dim strExpenseRemoteServiceUrl As String = ConfigurationManager.AppSettings("ExpenseRemoteServiceUrl").ToString
            ' Get a reference to the Expense Service through .NET Remoting
            Dim svcExpenseService As ExpenseLocalServices.ExpenseRemoteService = CType(Activator.GetObject(GetType(ExpenseLocalServices.ExpenseRemoteService), strExpenseRemoteServiceUrl), ExpenseLocalServices.ExpenseRemoteService)
            ' Get the specific Expense Report
            Dim report As ExpenseLocalServices.ExpenseReport = svcExpenseService.GetExpenseReport(ExpenseReportId)
            ' Submit the review for the Expense Report
            svcExpenseService.ExpenseReportReviewed(report, review)
        Next
        ' Refresh the list of Expense Reports
        Me.RefreshExpenseReports()
    End Sub
End Class


