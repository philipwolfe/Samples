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

'NOTE: When changing the namespace; please update XmlnsDefinitionAttribute in AssemblyInfo.vb
Public Class Workflow1
    Inherits SequentialWorkflowActivity


    Public reportArgs As ExpenseLocalServices.ExpenseReportSubmittedEventArgs
    Public Amount As Integer

    Public ReportEmployeeId As String
    Public ManagerEmployeeId As String
    Public reviewArgs As ExpenseLocalServices.ExpenseReportReviewedEventArgs

    Private Sub ReportSubmitted_Invoked(ByVal sender As System.Object, _
                            ByVal e As System.Workflow.Activities.ExternalDataEventArgs)
        Console.WriteLine("ReportSubmitted_Invoked")
        Me.Amount = Me.reportArgs.Report.Amount
        Me.ReportEmployeeId = Me.reportArgs.Report.EmployeeId
    End Sub

    Private Sub IfReportApproved_Condition(ByVal sender As System.Object, _
                        ByVal e As System.Workflow.Activities.ConditionalEventArgs)
        e.Result = Me.reviewArgs.Review.Approved
    End Sub
End Class
