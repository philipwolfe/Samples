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
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design

Namespace Microsoft.Samples.Workflow.Tutorials.CustomActivity
    Public Class WebTearActivity : Inherits System.Workflow.ComponentModel.Activity

        Public Delegate Sub PageFinishedEventHandler(ByVal sender As Object, _
            ByVal e As PageFinishedEventArgs)
        Private Event pageFinishedEvent As PageFinishedEventHandler
        Public Custom Event PageFinished As PageFinishedEventHandler
            AddHandler(ByVal value As PageFinishedEventHandler)
                AddHandler pageFinishedEvent, value
            End AddHandler
            RemoveHandler(ByVal value As PageFinishedEventHandler)
                RemoveHandler pageFinishedEvent, value
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal e As PageFinishedEventArgs)
                RaiseEvent pageFinishedEvent(sender, e)
            End RaiseEvent
        End Event

        Protected Overrides Function Execute(ByVal context As ActivityExecutionContext) _
            As ActivityExecutionStatus
            Dim pageData As String
            Dim client As System.Net.WebClient = New System.Net.WebClient()

            Try
                ' Download the web page data
                pageData = client.DownloadString(Me.Url)
            Catch e As Exception
                pageData = e.Message
            End Try

            ' Raise the PageFinished event back to the host
            RaiseEvent PageFinished(Nothing, New PageFinishedEventArgs(pageData))

            ' Notifiy the runtime that the activity has finished
            Return ActivityExecutionStatus.Closed
        End Function

        Public Shared UrlProperty As DependencyProperty = _
            DependencyProperty.Register("Url", GetType(System.String), _
            GetType(WebTearActivity))

        <DesignerSerializationVisibilityAttribute _
        (DesignerSerializationVisibility.Visible), _
        BrowsableAttribute(True), _
        DescriptionAttribute("Url to download"), _
        CategoryAttribute("WebTearActivity Property")> _
        Public Property Url() As String
            Get
                Return (CStr(MyBase.GetValue(WebTearActivity.UrlProperty)))
            End Get
            Set(ByVal value As String)
                MyBase.SetValue(WebTearActivity.UrlProperty, value)
            End Set
        End Property
    End Class
    
    Public Class PageFinishedEventArgs
        Private pageData As String

        Public Sub New(ByVal data As String)
            Me.pageData = data
        End Sub

        Public ReadOnly Property Data() As String
            Get
                Return Me.pageData
            End Get
        End Property
    End Class
End Namespace
