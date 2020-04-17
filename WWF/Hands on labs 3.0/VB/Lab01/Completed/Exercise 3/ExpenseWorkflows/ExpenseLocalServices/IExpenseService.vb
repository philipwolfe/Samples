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

Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities

<ExternalDataExchangeAttribute()> _
Public Interface IExpenseService
    Sub ApproveExpenseReport(ByVal report As ExpenseReport)

    Sub RejectExpenseReport(ByVal report As ExpenseReport)

    Sub RequestManagerApproval(ByVal report As Global.ExpenseLocalServices.ExpenseReport, ByVal ManagerEmplyeeId As String)

    Event ExpenseReportSubmitted As EventHandler(Of ExpenseReportSubmittedEventArgs)

    Event ExpenseReportReviewed As EventHandler(Of ExpenseReportReviewedEventArgs)

End Interface

<Serializable()> _
Public Class ExpenseReportSubmittedEventArgs
    Inherits ExternalDataEventArgs

    Public Sub New(ByVal InstanceId As System.Guid)
        MyBase.New(instanceId)
    End Sub


    Private myReport As ExpenseReport
    Public Property Report() As ExpenseReport
        Get
            Return myReport
        End Get
        Set(ByVal value As ExpenseReport)
            myReport = value
        End Set
    End Property

End Class

<Serializable()> _
Public Class ExpenseReportReviewedEventArgs
    Inherits ExternalDataEventArgs

    Public Sub New(ByVal InstanceId As Guid, ByVal report As ExpenseReport, ByVal review As ExpenseReportReview)
        MyBase.New(InstanceId)

        Me.Report = report
        Me.Review = review
    End Sub


    Private myReport As ExpenseReport
    Public Property Report() As ExpenseReport
        Get
            Return myReport
        End Get
        Set(ByVal value As ExpenseReport)
            myReport = value
        End Set
    End Property


    Private myReview As ExpenseReportReview
    Public Property Review() As ExpenseReportReview
        Get
            Return myReview
        End Get
        Set(ByVal value As ExpenseReportReview)
            myReview = value
        End Set
    End Property

End Class
