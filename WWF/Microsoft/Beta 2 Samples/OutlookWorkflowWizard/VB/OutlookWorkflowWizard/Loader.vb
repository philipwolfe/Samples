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
Imports System.IO
Imports System.Xml
Imports System.ComponentModel.Design
Imports System.Security.Permissions
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.ComponentModel.Serialization

Public Class Loader
    Inherits WorkflowDesignerLoader

    Private xomlFileValue As String = String.Empty

    Friend Property XomlFile() As String
        Get
            Return Me.xomlFileValue
        End Get
        Set(ByVal value As String)
            Me.xomlFileValue = value
        End Set
    End Property

    Friend Overloads Sub PerformFlush(ByVal host As IDesignerHost)
        If host IsNot Nothing AndAlso host.RootComponent IsNot Nothing Then
            Dim service As Activity = CType(host.RootComponent, Activity)

            If service IsNot Nothing Then
                Dim writer As XmlWriter = XmlWriter.Create(Me.XomlFile)
                Try
                    Dim xomlSerializer As WorkflowMarkupSerializer = New WorkflowMarkupSerializer()
                    xomlSerializer.Serialize(writer, service)
                Finally
                    writer.Close()
                End Try
            End If
        End If
    End Sub

    Public Overrides ReadOnly Property FileName() As String
        <PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust")> _
        Get
            Return Me.xomlFileValue
        End Get
    End Property

    <PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust")> _
    Public Overrides Function GetFileReader(ByVal filePath As String) As System.IO.TextReader
        Return Nothing
    End Function

    <PermissionSet(SecurityAction.LinkDemand, Name:="FullTrust")> _
    Public Overrides Function GetFileWriter(ByVal filePath As String) As System.IO.TextWriter
        Return Nothing
    End Function

    Protected Overrides Sub PerformFlush(ByVal serializationManager As System.ComponentModel.Design.Serialization.IDesignerSerializationManager)
    End Sub

    Protected Overrides Sub PerformLoad(ByVal serializationManager As System.ComponentModel.Design.Serialization.IDesignerSerializationManager)
    End Sub
End Class
