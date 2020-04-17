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
            Dim toolbox As New Toolbox(Me)
            Me.propertyGridSplitter.Panel1.Controls.Add(toolbox)
            toolbox.Dock = DockStyle.Fill
            toolbox.BackColor = Me.BackColor
            toolbox.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font
            WorkflowTheme.CurrentTheme.ReadOnly = False
            WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = False
            WorkflowTheme.CurrentTheme.ReadOnly = True
            Me.PropertyGrid.BackColor = Me.BackColor
            Me.propertyGrid.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, New ResolveEventHandler(AddressOf WorkflowDesignerControl.CurrentDomain_AssemblyResolve)

        End Sub


        Public ReadOnly Property WorkflowName() As String

            Get
                Return CStr(IIf((Me.workflow Is Nothing), String.Empty, Me.workflow.Name))
            End Get

        End Property

        Public Sub ProcessZoom(ByVal zoomFactor As Int32)

            Me.workflowView.Zoom = zoomFactor
            Me.workflowView.Update()

        End Sub





        Public Sub DeleteSelected()
            Dim selectionService As ISelectionService = DirectCast(Me.GetService(GetType(ISelectionService)), ISelectionService)
            If ((Not selectionService Is Nothing) AndAlso TypeOf selectionService.PrimarySelection Is Activity) Then
                Dim activity As Activity = DirectCast(selectionService.PrimarySelection, Activity)
                If (Not activity.Name Is Me.WorkflowName) Then
                    activity.Parent.Activities.Remove(activity)
                    Me.workflowView.Update()
                End If
            End If
        End Sub



        Public Sub LoadExistingWorkflow()
            Dim openFileDialog As New OpenFileDialog
            openFileDialog.Filter = "xoml files (*.xoml)|*.xoml|All files (*.*)|*.*"
            openFileDialog.FilterIndex = 1
            openFileDialog.RestoreDirectory = True
            If (openFileDialog.ShowDialog = DialogResult.OK) Then
                Using xmlReader As XmlReader = XmlReader.Create(openFileDialog.FileName)
                    Dim serializer As New WorkflowMarkupSerializer
                    Me.workflow = DirectCast(serializer.Deserialize(xmlReader), SequentialWorkflowActivity)
                    Me.LoadWorkflow()
                    Me.XomlFile = openFileDialog.FileName
                    Me.Text = ("Designer Hosting Sample -- [" & openFileDialog.FileName & "]")
                End Using
            End If
        End Sub





        Private Sub SaveFile()

            If (Me.XomlFile.Length <> 0) Then
                Me.SaveExistingWorkflow(Me.XomlFile)
            Else
                Dim saveFileDialog As New SaveFileDialog
                saveFileDialog.Filter = "xoml files (*.xoml)|*.xoml|All files (*.*)|*.*"
                saveFileDialog.FilterIndex = 1
                saveFileDialog.RestoreDirectory = True
                If (saveFileDialog.ShowDialog = DialogResult.OK) Then
                    Me.SaveExistingWorkflow(saveFileDialog.FileName)
                    Me.Text = ("Designer Hosting Sample -- [" & saveFileDialog.FileName & "]")
                End If
            End If

        End Sub

        Friend Sub SaveExistingWorkflow(ByVal filePath As String)
            If ((Not Me.designSurface Is Nothing) AndAlso (Not Me.loader Is Nothing)) Then
                Me.XomlFile = filePath
                Me.loader.PerformFlush()
            End If
        End Sub

        Public Function Save() As Boolean
            Return Me.Save(True)
        End Function


        Public Function Save(ByVal showMessage As Boolean) As Boolean
            Dim cursor As Cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            Dim saveOK As Boolean = True
            Try
                Try
                    Me.SaveFile()
                    Dim doc As New XmlDocument
                    doc.Load(Me.XomlFile)
                    Dim attrib As XmlAttribute = doc.CreateAttribute("x", "Class", "http://schemas.microsoft.com/winfx/2006/xaml")
                    attrib.Value = String.Format("{0}.{1}", MyBase.GetType.Namespace, Me.WorkflowName)
                    doc.DocumentElement.Attributes.Append(attrib)
                    doc.Save(Me.XomlFile)
                    If showMessage Then
                        MessageBox.Show(Me, ("Workflow generated successfully. Generated xoml file:" & ChrW(10) & Path.Combine(Path.GetDirectoryName(MyBase.GetType.Assembly.Location), Me.XomlFile)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    saveOK = False
                End Try
            Finally
                Me.Cursor = cursor
            End Try
            Return saveOK
        End Function















        Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim selectionService As ISelectionService = TryCast(Me.GetService(GetType(ISelectionService)), ISelectionService)
            If (Not selectionService Is Nothing) Then
                Me.PropertyGrid.SelectedObjects = New ArrayList(selectionService.GetSelectedComponents).ToArray
            End If
        End Sub






        Private Sub LoadWorkflow()

            Using stringWriter As StringWriter = New StringWriter
                Using xmlWriter As XmlWriter = xmlWriter.Create(stringWriter)
                    Dim aWorkflowMarkupSerializer As WorkflowMarkupSerializer = New WorkflowMarkupSerializer()
                    aWorkflowMarkupSerializer.Serialize(xmlWriter, Me.workflow)
                    Me.Xoml = stringWriter.ToString
                End Using
            End Using

        End Sub


        Public Function Compile() As Boolean
            Return Me.Compile(True)
        End Function

        Public Function Compile(ByVal showMessage As Boolean) As Boolean
            If Not Me.Save(False) Then
                Return False
            End If
            If Not File.Exists(Me.XomlFile) Then
                MessageBox.Show(Me, ("Cannot locate xoml file: " & Path.Combine(Path.GetDirectoryName(MyBase.GetType.Assembly.Location), Me.XomlFile)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return False
            End If
            Dim compileOK As Boolean = True
            Dim cursor As Cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            Try
                Dim assemblyNames As String() = New String() {"ActivityLibrary.dll"}
                Dim compiler As New WorkflowCompiler
                Dim parameters As New WorkflowCompilerParameters(assemblyNames)
                parameters.LibraryPaths.Add(Path.GetDirectoryName(GetType(ActivityLibrary.MessageActivity).Assembly.Location))
                parameters.GenerateInMemory = True
                Dim compilerResults As WorkflowCompilerResults = compiler.Compile(parameters, New String() {Me.XomlFile})
                WorkflowDesignerControl.inMemoryAssembly = compilerResults.CompiledAssembly
                Dim errors As New StringBuilder
                Dim compilerError As CompilerError
                For Each compilerError In compilerResults.Errors
                    errors.Append((compilerError.ToString & ChrW(10)))
                Next
                If (errors.Length <> 0) Then
                    MessageBox.Show(Me, errors.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    compileOK = False
                ElseIf showMessage Then
                    MessageBox.Show(Me, ("Workflow compiled successfully. Compiled assembly:" & ChrW(10) & compilerResults.CompiledAssembly.GetName.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
            Finally
                Me.Cursor = cursor
            End Try
            Return compileOK
        End Function






        Public Function Run() As Boolean

            If ((WorkflowDesignerControl.inMemoryAssembly Is Nothing) AndAlso Not Me.Compile(False)) Then
                Return False
            End If
            If (Me.workflowRuntime Is Nothing) Then
                Me.workflowRuntime = New WorkflowRuntime
                Me.workflowRuntime.StartRuntime()
            End If
            AddHandler Me.workflowRuntime.WorkflowCompleted, New EventHandler(Of WorkflowCompletedEventArgs)(AddressOf Me.workflowRuntime_WorkflowCompleted)
            Dim typeName As String = String.Format("{0}.{1}", MyBase.GetType.Namespace, Me.WorkflowName)
            Me.workflowRuntime.CreateWorkflow(AppDomain.CurrentDomain.CreateInstanceAndUnwrap(WorkflowDesignerControl.inMemoryAssembly.FullName, typeName).GetType).Start()
            Return True
        End Function

        Private Sub workflowRuntime_WorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            MessageBox.Show("Workflow complete")
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
                    Me.PropertyGrid.Site = designerHost.RootComponent.Site
                    Me.workflowView = TryCast(rootDesigner.GetView(ViewTechnology.Default), WorkflowView)
                    Me.workflowViewSplitter.Panel1.Controls.Add(Me.workflowView)
                    Me.workflowView.Dock = DockStyle.Fill
                    Me.workflowView.TabIndex = 1
                    Me.workflowView.TabStop = True
                    Me.workflowView.HScrollBar.TabStop = False
                    Me.workflowView.VScrollBar.TabStop = False
                    Me.workflowView.Focus()


                    Dim selectionService As ISelectionService = TryCast(Me.GetService(GetType(ISelectionService)), ISelectionService)
                    If (Not selectionService Is Nothing) Then
                        AddHandler selectionService.SelectionChanged, New EventHandler(AddressOf Me.OnSelectionChanged)
                    End If



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