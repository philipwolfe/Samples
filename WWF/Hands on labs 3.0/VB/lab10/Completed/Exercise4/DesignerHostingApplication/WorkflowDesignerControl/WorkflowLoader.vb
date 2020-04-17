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
Imports System.IO
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.ComponentModel.Serialization
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing.Design
Imports System.Xml

Public NotInheritable Class WorkflowLoader
    Inherits WorkflowDesignerLoader

    ' Fields
    Private m_workflowType As Type
    Private m_xoml As String = String.Empty
    Private m_xomlFile As String = String.Empty

    Public Sub New()

    End Sub






    Public Shared Sub DestroyObjectGraphFromDesignerHost(ByVal designerHost As IDesignerHost, ByVal activity As Activity)
        If (designerHost Is Nothing) Then
            Throw New ArgumentNullException("designerHost")
        End If
        If (activity Is Nothing) Then
            Throw New ArgumentNullException("activity")
        End If
        designerHost.DestroyComponent(activity)
        If TypeOf activity Is CompositeActivity Then
            Dim activity2 As Activity
            For Each activity2 In WorkflowLoader.GetNestedActivities(TryCast(activity, CompositeActivity))
                designerHost.DestroyComponent(activity2)
            Next
        End If
    End Sub





    Protected Overrides Sub Initialize()
        MyBase.Initialize()
        Dim host As IDesignerLoaderHost = MyBase.LoaderHost
        If (Not host Is Nothing) Then
            host.AddService(GetType(IMenuCommandService), New WorkflowDesignerControl.WorkflowMenuCommandService(host))
            host.AddService(GetType(IToolboxService), New Toolbox(host))
            Dim provider As New TypeProvider(host)
            provider.AddAssemblyReference(GetType(String).Assembly.Location)
            host.AddService(GetType(ITypeProvider), provider, True)
        End If
    End Sub

    Public Overrides Sub Dispose()
        Dim host As IDesignerLoaderHost = MyBase.LoaderHost
        If (Not host Is Nothing) Then
            host.RemoveService(GetType(IMenuCommandService))
            host.RemoveService(GetType(IToolboxService))
            host.RemoveService(GetType(ITypeProvider), True)
        End If
        MyBase.Dispose()
    End Sub

    Public Overrides Sub ForceReload()
    End Sub
    Public Overrides Function GetFileReader(ByVal filePath As String) As TextReader
        Return New StreamReader(New FileStream(filePath, FileMode.OpenOrCreate))
    End Function

    Public Overrides Function GetFileWriter(ByVal filePath As String) As TextWriter
        Return New StreamWriter(New FileStream(filePath, FileMode.OpenOrCreate))
    End Function

    Private Shared Function GetNestedActivities(ByVal compositeActivity As CompositeActivity) As Activity()

        If (compositeActivity Is Nothing) Then
            Throw New ArgumentNullException("compositeActivity")
        End If

        Dim childActivities As IList(Of Activity) = Nothing
        Dim nestedActivities As New ArrayList
        Dim compositeActivities As New Queue
        compositeActivities.Enqueue(compositeActivity)

        Do While (compositeActivities.Count > 0)

            Dim activity1 As CompositeActivity = DirectCast(compositeActivities.Dequeue, CompositeActivity)
            childActivities = activity1.Activities
            Dim activity2 As Activity

            For Each activity2 In childActivities
                nestedActivities.Add(activity2)
                If TypeOf activity2 Is CompositeActivity Then
                    compositeActivities.Enqueue(activity2)
                End If
            Next
        Loop
        Return DirectCast(nestedActivities.ToArray(GetType(Activity)), Activity())
    End Function

    Protected Overrides Sub PerformFlush(ByVal manager As IDesignerSerializationManager)
    End Sub

    Public Overloads Sub PerformFlush()

        Dim host As IDesignerHost = DirectCast(MyBase.GetService(GetType(IDesignerHost)), IDesignerHost)
        If ((Not host Is Nothing) AndAlso (Not host.RootComponent Is Nothing)) Then
            Dim service As Activity = TryCast(host.RootComponent, Activity)
            If (Not service Is Nothing) Then
                Using writer As XmlWriter = XmlWriter.Create(Me.XomlFile)
                    Dim xomlSerializer As WorkflowMarkupSerializer = New WorkflowMarkupSerializer()
                    xomlSerializer.Serialize(writer, service)
                End Using
            End If
        End If

    End Sub



    Protected Overrides Sub PerformLoad(ByVal serializationManager As IDesignerSerializationManager)

        Dim designerHost As IDesignerHost = DirectCast(MyBase.GetService(GetType(IDesignerHost)), IDesignerHost)
        Dim rootActivity As Activity = Nothing
        If (Not Me.WorkflowType Is Nothing) Then
            rootActivity = DirectCast(Activator.CreateInstance(Me.WorkflowType), Activity)
        Else
            Dim reader As TextReader = New StringReader(Me.Xoml)
            Try
                Using xmlReader As XmlReader = xmlReader.Create(reader)
                    Dim xomlSerializer As New WorkflowMarkupSerializer
                    rootActivity = TryCast(xomlSerializer.Deserialize(xmlReader), Activity)
                End Using
            Finally
                reader.Close()
            End Try
        End If
        If ((Not rootActivity Is Nothing) AndAlso (Not designerHost Is Nothing)) Then
            AddObjectGraphToDesignerHost(designerHost, rootActivity)
        End If
    End Sub

    Private Shared Sub AddObjectGraphToDesignerHost(ByVal designerHost As IDesignerHost, ByVal activity As Activity)

        Dim Definitions_Class As New Guid("3FA84B23-B15B-4161-8EB8-37A54EFEEFC7")
        If (designerHost Is Nothing) Then
            Throw New ArgumentNullException("designerHost")
        End If
        If (activity Is Nothing) Then
            Throw New ArgumentNullException("activity")
        End If
        Dim rootSiteName As String = activity.QualifiedName

        If (activity.Parent Is Nothing) Then
            Dim fullClassName As String = TryCast(activity.UserData.Item(Definitions_Class), String)
            If (fullClassName Is Nothing) Then
                fullClassName = activity.GetType.FullName
            End If
            rootSiteName = CStr(IIf((fullClassName.LastIndexOf("."c) <> -1), fullClassName.Substring((fullClassName.LastIndexOf("."c) + 1)), fullClassName))
            designerHost.Container.Add(activity, rootSiteName)
        Else
            designerHost.Container.Add(activity, activity.QualifiedName)
        End If

        If TypeOf activity Is CompositeActivity Then
            Dim activity1 As Activity
            For Each activity1 In WorkflowLoader.GetNestedActivities(TryCast(activity, CompositeActivity))
                designerHost.Container.Add(activity1, activity1.QualifiedName)
            Next
        End If
    End Sub


    Public ReadOnly Property DefaultNamespace() As String
        Get
            Return "SampleNamespace"
        End Get
    End Property

    Public Overrides ReadOnly Property FileName() As String
        Get
            Return String.Empty
        End Get
    End Property



    Public Property Xoml() As String
        Get
            Return Me.m_xoml
        End Get
        Set(ByVal value As String)
            Me.m_xoml = value
        End Set
    End Property

    Public Property XomlFile() As String
        Get
            Return Me.m_xomlFile
        End Get
        Set(ByVal value As String)
            Me.m_xomlFile = value
        End Set
    End Property

    Public Property WorkflowType() As Type
        Get
            Return Me.m_workflowType
        End Get
        Set(ByVal value As Type)
            Me.m_workflowType = value
        End Set
    End Property


End Class
