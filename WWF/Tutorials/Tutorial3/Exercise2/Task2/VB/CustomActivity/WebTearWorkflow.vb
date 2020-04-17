'---------------------------------------------------------------------
'  This file is part of the Windows Workflow Foundation SDK Code Samples.
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
Imports System.Workflow.ComponentModel
Imports System.Workflow.Activities

Namespace Microsoft.Samples.Workflow.Tutorials.CustomActivity
    Public NotInheritable Class WebTearWorkflow _
         : Inherits SequentialWorkflowActivity
        Private pageUrl As String
        Private pageData As String

        Private webTearActivity As WebTearActivity

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Property Url() As String
            Get
                Return pageUrl
            End Get
            Set(ByVal value As String)
                pageUrl = value
            End Set
        End Property

        Public Property Data() As String
            Get
                Return pageData
            End Get
            Set(ByVal value As String)
                pageData = Value
            End Set
        End Property

        Private Sub InitializeComponent()
            Me.CanModifyActivities = True
            Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = _
                New System.Workflow.ComponentModel.ActivityBind()
            Me.webTearActivity = New WebTearActivity()
            ' 
            ' webTearActivity1
            ' 
            Me.webTearActivity.Name = "webTearActivity"
            activitybind1.Name = "WebTearWorkflow"
            activitybind1.Path = "Url"
            AddHandler Me.webTearActivity.PageFinished, AddressOf Me.webTearActivity_PageFinished
            Me.webTearActivity.SetBinding(WebTearActivity.UrlProperty, _
                (CType(activitybind1, System.Workflow.ComponentModel.ActivityBind)))
            ' 
            ' WebTearWorkflow
            ' 
            Me.Activities.Add(Me.webTearActivity)
            Me.Name = "WebTearWorkflow"
            Me.CanModifyActivities = False
        End Sub

        Private Sub webTearActivity_PageFinished(ByVal sender As Object, _
            ByVal e As CustomActivity.PageFinishedEventArgs)
            Me.pageData = e.Data
        End Sub
    End Class
End Namespace
