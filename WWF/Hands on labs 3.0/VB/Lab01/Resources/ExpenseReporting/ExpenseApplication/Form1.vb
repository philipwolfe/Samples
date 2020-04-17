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
        RemotingConfiguration.Configure("ExpenseApplication.exe.config")
    End Sub


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        ' Create a new Expense Report record using some static data
        Dim report As ExpenseLocalServices.ExpenseReport = New ExpenseLocalServices.ExpenseReport
        report.Amount = System.Convert.ToInt32(Me.txtAmount.Text)
        report.EmployeeId = "1"
        report.ExpenseReportId = System.Guid.NewGuid
        report.SubmittedBy = Me.txtSubmittedBy.Text
        report.SubmittedTime = System.DateTime.Now

        ' Get the URL for the ExpenseRemoteService
        Dim strExpenseRemoteServiceUrl As String = ConfigurationManager.AppSettings("ExpenseRemoteServiceUrl").ToString

        ' Get a reference to the Expense Service through .NET Remoting
        Dim svcExpenseService As ExpenseLocalServices.ExpenseRemoteService = CType(Activator.GetObject(GetType(ExpenseLocalServices.ExpenseRemoteService), strExpenseRemoteServiceUrl), ExpenseLocalServices.ExpenseRemoteService)

        ' Submit the Expense Report for approval
        svcExpenseService.SubmitExpenseReport(report)

        ' Add a new item to the Expense Reports list view
        Me.CreateListViewItem(report)

        ' Clear the values in the data entry fields
        Me.txtAmount.Text = ""
        Me.txtSubmittedBy.Text = ""

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefresh.Click
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
        lvitemExpenseReport.SubItems.Add(report.SubmittedBy.ToString)

        ' Add the status
        lvitemExpenseReport.SubItems.Add(report.Status.ToString)
    End Sub
End Class
