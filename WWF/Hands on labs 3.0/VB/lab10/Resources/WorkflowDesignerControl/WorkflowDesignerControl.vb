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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.Activities
Imports System.Workflow.ComponentModel.Design
Imports System.Runtime.InteropServices
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Workflow.ComponentModel.Serialization
Imports System.Xml
Imports System.CodeDom.Compiler
Imports System.Workflow.Runtime
Imports System.Reflection
Namespace WorkflowDesignerControl
    Partial Public Class WorkflowDesignerControl

        Public Sub New()
            Me.components = Nothing
            Me.InitializeComponent()
            WorkflowTheme.CurrentTheme.ReadOnly = False
            WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = False
            WorkflowTheme.CurrentTheme.ReadOnly = True
            Me.PropertyGrid.BackColor = Me.BackColor
            Me.propertyGrid.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, New ResolveEventHandler(AddressOf WorkflowDesignerControl.CurrentDomain_AssemblyResolve)
        End Sub


        Public ReadOnly Property WorkflowName() As String

            Get

                Return IIf((Me.workflow Is Nothing), String.Empty, Me.workflow.Name)
            End Get

        End Property

        Private Sub LoadWorkflow()

            Using stringWriter As StringWriter = New StringWriter
                Using xmlWriter As XmlWriter = xmlWriter.Create(stringWriter)
                    Dim aWorkflowMarkupSerializer As WorkflowMarkupSerializer = New WorkflowMarkupSerializer()
                    aWorkflowMarkupSerializer.Serialize(xmlWriter, Me.workflow)
                    Me.Xoml = stringWriter.ToString
                End Using
            End Using

        End Sub


        Public Property Xoml() As String

            Get
                Dim axoml As String = String.Empty
                If (Me.loader Is Nothing) Then
                    Return axoml
                End If
                Try
                    Me.loader.Flush()
                    axoml = Me.loader.Xoml
                    Return axoml
                Catch obj1 As Exception
                End Try
                Return axoml
            End Get

            Set(ByVal value As String)
                Try
                    If Not String.IsNullOrEmpty(value) Then
                        Me.LoadWorkflow(value)
                    End If
                Catch obj1 As Exception
                End Try
            End Set

        End Property


        Public Property XomlFile() As String
            Get
                Return Me.loader.XomlFile
            End Get
            Set(ByVal value As String)
                Me.loader.XomlFile = value
            End Set

        End Property

        Private Shared Function CurrentDomain_AssemblyResolve(ByVal sender As Object, ByVal args As ResolveEventArgs) As Assembly

            If (WorkflowDesignerControl.inMemoryAssembly.FullName = args.Name) Then
                Return WorkflowDesignerControl.inMemoryAssembly
            End If
            Return Nothing

        End Function


        Private Sub LoadWorkflow(ByVal xoml As String)

            MyBase.SuspendLayout()
            Dim designSurface As New DesignSurface
            Dim loader As New WorkflowLoader
            loader.Xoml = xoml
            designSurface.BeginLoad(loader)
            Dim designerHost As IDesignerHost = TryCast(designSurface.GetService(GetType(IDesignerHost)), IDesignerHost)
            If ((Not designerHost Is Nothing) AndAlso (Not designerHost.RootComponent Is Nothing)) Then
                Dim rootDesigner As IRootDesigner = TryCast(designerHost.GetDesigner(designerHost.RootComponent), IRootDesigner)
                If (Not rootDesigner Is Nothing) Then
                    Me.UnloadWorkflow()
                    Me.designSurface = designSurface
                    Me.loader = loader
                    Me.workflowView = TryCast(rootDesigner.GetView(ViewTechnology.Default), WorkflowView)
                    Me.workflowViewSplitter.Panel1.Controls.Add(Me.workflowView)
                    Me.workflowView.Dock = DockStyle.Fill
                    Me.workflowView.TabIndex = 1
                    Me.workflowView.TabStop = True
                    Me.workflowView.HScrollBar.TabStop = False
                    Me.workflowView.VScrollBar.TabStop = False
                    Me.workflowView.Focus()
                End If
            End If
            MyBase.ResumeLayout(True)
        End Sub

        Private Sub UnloadWorkflow()

            Dim designerHost As IDesignerHost = TryCast(Me.GetService(GetType(IDesignerHost)), IDesignerHost)

            If ((Not designerHost Is Nothing) AndAlso (designerHost.Container.Components.Count > 0)) Then
                WorkflowLoader.DestroyObjectGraphFromDesignerHost(designerHost, TryCast(designerHost.RootComponent, Activity))
            End If

            If (Not Me.designSurface Is Nothing) Then
                Me.designSurface.Dispose()
                Me.designSurface = Nothing
            End If

            If (Not Me.workflowView Is Nothing) Then
                MyBase.Controls.Remove(Me.workflowView)
                Me.workflowView.Dispose()
                Me.workflowView = Nothing
            End If

        End Sub
        Private Sub ShowDefaultWorkflow()
            Me.workflow = New SequentialWorkflowActivity
            Me.workflow.Name = "CustomWorkflow"
            Me.LoadWorkflow()
        End Sub



        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            Me.ShowDefaultWorkflow()
        End Sub


        Public Shadows Function GetService(ByVal serviceType As Type) As Object Implements System.IServiceProvider.GetService
            If Not (Me.workflowView Is Nothing) Then
                Return DirectCast(Me.workflowView, IServiceProvider).GetService(serviceType)
            End If
            Return Nothing
            'Return IIf((Not Me.workflowView Is Nothing), DirectCast(Me.workflowView, IServiceProvider).GetService(serviceType), Nothing)
        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.UnloadWorkflow()
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub



        ' Fields
        Private Const AdditionalAssembies As String = "ActivityLibrary.dll"
        Private loader As WorkflowLoader
        Private workflow As SequentialWorkflowActivity

        Private designSurface As DesignSurface
        Private Shared inMemoryAssembly As Assembly

        Private workflowRuntime As WorkflowRuntime
        Private workflowView As WorkflowView



    End Class
End Namespace