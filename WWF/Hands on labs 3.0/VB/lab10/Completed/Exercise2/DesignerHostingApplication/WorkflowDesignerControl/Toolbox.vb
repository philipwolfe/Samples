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

Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Collections
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.Diagnostics
Imports System.Drawing.Design
Imports System.Drawing.Text
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting
Imports System.Runtime.Serialization.Formatters
Imports System.Text
Imports System.Windows.Forms.ComponentModel
Imports System.Windows.Forms.Design
Imports System.Windows.Forms
Imports System
Imports System.Workflow.Activities
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design

<ToolboxItem(False)> _
Public Class Toolbox
    Inherits Panel
    Implements IToolboxService


    Public Sub AddCreator(ByVal creator As ToolboxItemCreatorCallback, ByVal format As String) Implements System.Drawing.Design.IToolboxService.AddCreator
        Me.AddCreator(creator, format, Nothing)
    End Sub

    Public Sub AddCreator(ByVal creator As ToolboxItemCreatorCallback, ByVal format As String, ByVal host As IDesignerHost) Implements System.Drawing.Design.IToolboxService.AddCreator

        If ((creator Is Nothing) OrElse (format Is Nothing)) Then
            Throw New ArgumentNullException(CStr(IIf((creator Is Nothing), "creator", "format")))
        End If
        If (Me.customCreators Is Nothing) Then
            Me.customCreators = New Hashtable
        Else
            Dim key As String = format
            If (Not host Is Nothing) Then
                key = (key & ", " & CType(host, Object).GetHashCode.ToString)
            End If
            If Me.customCreators.ContainsKey(key) Then
                Throw New Exception(("There is already a creator registered for the format '" & format & "'."))
            End If
        End If
        Me.customCreators.Item(format) = creator
    End Sub


    Private Sub OnListBoxClick(ByVal sender As Object, ByVal eevent As EventArgs)

        Dim toolboxItem As SelfHostToolboxItem = TryCast(Me.listBox.SelectedItem, SelfHostToolboxItem)
        If (Not toolboxItem Is Nothing) Then
            Me.currentSelection = toolboxItem.ComponentClass
        ElseIf (Not Me.currentSelection Is Nothing) Then
            Dim index As Integer = Me.listBox.Items.IndexOf(Me.currentSelection)
            If (index >= 0) Then
                Me.listBox.SelectedIndex = index
            End If
        End If

    End Sub



    Public Overridable Sub SetSelectedToolboxItem(ByVal selectedToolClass As ToolboxItem) Implements System.Drawing.Design.IToolboxService.SetSelectedToolboxItem
        If (selectedToolClass Is Nothing) Then
            Me.listBox.SelectedIndex = 0
            Me.OnListBoxClick(Nothing, EventArgs.Empty)
        End If
    End Sub

    Public Function GetEnabledAttributes() As Attribute()
        Return Nothing
    End Function

    Public Sub SetEnabledAttributes(ByVal attrs As Attribute())
    End Sub


    Public Property SelectedCategory() As String
        Get
            Return "Workflow"
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public ReadOnly Property CategoryNames() As CategoryNameCollection Implements IToolboxService.CategoryNames
        Get
            Return New CategoryNameCollection(New String() {"Workflow"})
        End Get
    End Property


    Private Const CF_DESIGNER As String = "CF_WINOEDESIGNERCOMPONENTS"
    Private currentSelection As Type
    Private customCreators As Hashtable
    Private listBox As ListBox
    Private provider As IServiceProvider



    Public Sub New(ByVal provider As IServiceProvider)

        Me.listBox = New ListBox
        Me.provider = provider
        Me.Text = "Toolbox"
        MyBase.Size = New Size(&HE0, 350)
        Me.listBox.Dock = DockStyle.Fill
        Me.listBox.IntegralHeight = False
        Me.listBox.ItemHeight = 20
        Me.listBox.DrawMode = DrawMode.OwnerDrawFixed
        Me.listBox.BorderStyle = BorderStyle.None
        Me.listBox.BackColor = SystemColors.Window
        Me.listBox.ForeColor = SystemColors.ControlText
        AddHandler Me.listBox.MouseMove, New MouseEventHandler(AddressOf Me.OnListBoxMouseMove)
        MyBase.Controls.Add(Me.listBox)
        AddHandler Me.listBox.DrawItem, New DrawItemEventHandler(AddressOf Me.OnDrawItem)
        AddHandler Me.listBox.SelectedIndexChanged, New EventHandler(AddressOf Me.OnListBoxClick)
        Me.AddToolboxEntries(Me.listBox)

    End Sub

    Private Sub AddToolboxEntries(ByVal lb As ListBox)

        Dim selfTools As Stream = MyBase.GetType.Module.Assembly.GetManifestResourceStream(MyBase.GetType, "ToolboxItems.txt")
        Debug.Assert((Not selfTools Is Nothing), ("Unable to load toollist.txt for type '" & MyBase.GetType.FullName & "'"))
        Dim len As Integer = CInt(selfTools.Length)
        Dim bytes As Byte() = New Byte(len - 1) {}
        selfTools.Read(bytes, 0, len)
        Dim entries As String = Encoding.Default.GetString(bytes)
        Dim start As Integer = 0
        Dim [end] As Integer = 0
        Do While ([end] < entries.Length)
            [end] = entries.IndexOf(ChrW(13), start)
            If ([end] = -1) Then
                [end] = entries.Length
            End If
            Dim entry As String = entries.Substring(start, ([end] - start))
            If Not ((entry.Length = 0) OrElse entry.StartsWith(";")) Then
                lb.Items.Add(New SelfHostToolboxItem(entry))
            End If
            start = ([end] + 2)
        Loop

    End Sub


    Private Sub OnDrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)

        Dim g As Graphics = e.Graphics
        Dim listBox As ListBox = DirectCast(sender, ListBox)
        Dim objItem As Object = listBox.Items.Item(e.Index)
        Dim item As SelfHostToolboxItem = Nothing
        Dim bitmap As Bitmap = Nothing
        Dim text As String = Nothing
        If TypeOf objItem Is String Then
            bitmap = Nothing
            [text] = CStr(objItem)
        Else
            Try
                item = DirectCast(objItem, SelfHostToolboxItem)
                bitmap = DirectCast(item.Glyph, Bitmap)
                [text] = item.Name
            Catch obj1 As Exception
            End Try
        End If
        Dim selected As Boolean = False
        Dim disabled As Boolean = False
        If ((e.State And DrawItemState.Selected) = DrawItemState.Selected) Then
            selected = True
        End If
        If ((e.State And (DrawItemState.Inactive Or (DrawItemState.Disabled Or DrawItemState.Grayed))) <> DrawItemState.None) Then
            disabled = True
        End If
        Dim format As New StringFormat
        format.HotkeyPrefix = HotkeyPrefix.Show
        Dim x As Integer = (e.Bounds.X + 4)
        x = (x + 20)
        If selected Then
            Dim r As Rectangle = e.Bounds
            r.Width -= 1
            r.Height -= 1
            g.DrawRectangle(SystemPens.ActiveCaption, r)
        Else
            g.FillRectangle(SystemBrushes.Menu, e.Bounds)
            Using border As Brush = New SolidBrush(Color.FromArgb(Math.Min((SystemColors.Menu.R + 15), &HFF), Math.Min((SystemColors.Menu.G + 15), &HFF), Math.Min((SystemColors.Menu.B + 15), &HFF)))
                g.FillRectangle(border, New Rectangle(e.Bounds.X, e.Bounds.Y, 20, e.Bounds.Height))
            End Using
        End If
        If (Not bitmap Is Nothing) Then
            g.DrawImage(bitmap, (e.Bounds.X + 2), (e.Bounds.Y + 2), bitmap.Width, bitmap.Height)
        End If
        Dim textBrush As Brush = CType(IIf(disabled, New SolidBrush(Color.FromArgb(120, SystemColors.MenuText)), SystemBrushes.FromSystemColor(SystemColors.MenuText)), Brush)
        g.DrawString([text], Me.Font, textBrush, CSng(x), CSng((e.Bounds.Y + 2)), format)
        If disabled Then
            textBrush.Dispose()
        End If
        format.Dispose()

    End Sub



    Friend Shared Function GetToolboxItem(ByVal toolType As Type) As ToolboxItem

        If (toolType Is Nothing) Then
            Throw New ArgumentNullException("toolType")
        End If
        Dim item As ToolboxItem = Nothing
        If (((toolType.IsPublic OrElse toolType.IsNestedPublic) AndAlso GetType(IComponent).IsAssignableFrom(toolType)) AndAlso Not toolType.IsAbstract) Then
            Dim toolboxItemAttribute As ToolboxItemAttribute = DirectCast(TypeDescriptor.GetAttributes(toolType).Item(GetType(ToolboxItemAttribute)), ToolboxItemAttribute)
            If ((Not toolboxItemAttribute Is Nothing) AndAlso Not toolboxItemAttribute.IsDefaultAttribute) Then
                Dim itemType As Type = toolboxItemAttribute.ToolboxItemType
                If (Not itemType Is Nothing) Then
                    Dim ctor As ConstructorInfo = itemType.GetConstructor(New Type() {GetType(Type)})
                    If (Not ctor Is Nothing) Then
                        Return DirectCast(ctor.Invoke(New Object() {toolType}), ToolboxItem)
                    End If
                    ctor = itemType.GetConstructor(New Type(0 - 1) {})
                    If (Not ctor Is Nothing) Then
                        item = DirectCast(ctor.Invoke(New Object(0 - 1) {}), ToolboxItem)
                        item.Initialize(toolType)
                    End If
                End If
                Return item
            End If
            If Not toolboxItemAttribute.Equals(toolboxItemAttribute.None) Then
                item = New ToolboxItem(toolType)
            End If
            Return item
        End If
        If Not GetType(ToolboxItem).IsAssignableFrom(toolType) Then
            Return item
        End If
        Try
            Return DirectCast(Activator.CreateInstance(toolType, True), ToolboxItem)
        Catch obj1 As Exception
        End Try
        Return item

    End Function





    Private Sub OnListBoxMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)

        If ((e.Button = MouseButtons.Left) AndAlso (Not Me.listBox.SelectedItem Is Nothing)) Then
            Dim selectedItem As SelfHostToolboxItem = TryCast(Me.listBox.SelectedItem, SelfHostToolboxItem)
            If ((Not selectedItem Is Nothing) AndAlso (Not selectedItem.ComponentClass Is Nothing)) Then
                Dim toolboxItem As ToolboxItem = Toolbox.GetToolboxItem(selectedItem.ComponentClass)
                Dim dataObject As IDataObject = TryCast(Me.SerializeToolboxItem(toolboxItem), IDataObject)
                Dim effects As DragDropEffects = MyBase.DoDragDrop(dataObject, (DragDropEffects.Move Or DragDropEffects.Copy))
            End If
        End If
    End Sub







    Public Sub AddLinkedToolboxItem(ByVal toolboxItem As System.Drawing.Design.ToolboxItem, ByVal category As String, ByVal host As System.ComponentModel.Design.IDesignerHost) Implements System.Drawing.Design.IToolboxService.AddLinkedToolboxItem

    End Sub

    Public Sub AddLinkedToolboxItem(ByVal toolboxItem As System.Drawing.Design.ToolboxItem, ByVal host As System.ComponentModel.Design.IDesignerHost) Implements System.Drawing.Design.IToolboxService.AddLinkedToolboxItem

    End Sub

    Public Sub AddToolboxItem(ByVal toolboxItem As System.Drawing.Design.ToolboxItem) Implements System.Drawing.Design.IToolboxService.AddToolboxItem

    End Sub

    Public Sub AddToolboxItem(ByVal toolboxItem As System.Drawing.Design.ToolboxItem, ByVal category As String) Implements System.Drawing.Design.IToolboxService.AddToolboxItem

    End Sub

    Public Sub AddType(ByVal t As Type)
        Me.listBox.Items.Add(New SelfHostToolboxItem(t.AssemblyQualifiedName))
    End Sub



    Public Function DeserializeToolboxItem(ByVal serializedObject As Object) As System.Drawing.Design.ToolboxItem Implements System.Drawing.Design.IToolboxService.DeserializeToolboxItem
        Return DeserializeToolboxItem(serializedObject, Nothing)
    End Function

    Private Function FindToolboxItemCreator(ByVal dataObj As IDataObject, ByVal host As IDesignerHost, <Out()> ByRef foundFormat As String) As ToolboxItemCreatorCallback
        foundFormat = String.Empty
        Dim creator As ToolboxItemCreatorCallback = Nothing
        If (Not Me.customCreators Is Nothing) Then
            Dim key As String
            For Each key In Me.customCreators.Keys
                Dim keyParts As String() = key.Split(New Char() {","c})
                Dim format As String = keyParts(0)
                If (dataObj.GetDataPresent(format) AndAlso ((keyParts.Length = 1) OrElse ((Not host Is Nothing) AndAlso CType(host, Object).GetHashCode.ToString.Equals(keyParts(1))))) Then
                    creator = DirectCast(Me.customCreators.Item(format), ToolboxItemCreatorCallback)
                    foundFormat = format
                    Return creator
                End If
            Next
        End If
        Return creator
    End Function


    Public Function DeserializeToolboxItem(ByVal serializedObject As Object, ByVal host As System.ComponentModel.Design.IDesignerHost) As System.Drawing.Design.ToolboxItem Implements System.Drawing.Design.IToolboxService.DeserializeToolboxItem

        Dim dataObject As IDataObject = TryCast(serializedObject, IDataObject)
        If (dataObject Is Nothing) Then
            Return Nothing
        End If
        Dim t As ToolboxItem = DirectCast(dataObject.GetData(GetType(ToolboxItem)), ToolboxItem)
        If (t Is Nothing) Then
            Dim format As String
            Dim creator As ToolboxItemCreatorCallback = Me.FindToolboxItemCreator(dataObject, host, format)
            If (Not creator Is Nothing) Then
                Return creator(dataObject, format)
            End If
        End If
        Return t

    End Function

    Public Function GetSelectedToolboxItem() As System.Drawing.Design.ToolboxItem Implements System.Drawing.Design.IToolboxService.GetSelectedToolboxItem

        If (Me.currentSelection Is Nothing) Then
            Return Nothing
        End If
        Try
            Return Toolbox.GetToolboxItem(Me.currentSelection)
        Catch exception1 As TypeLoadException
        End Try
        Return Toolbox.GetToolboxItem(Me.currentSelection)
    End Function

    Public Function GetSelectedToolboxItem(ByVal host As System.ComponentModel.Design.IDesignerHost) As System.Drawing.Design.ToolboxItem Implements System.Drawing.Design.IToolboxService.GetSelectedToolboxItem
        Return Me.GetSelectedToolboxItem()
    End Function

    Public Function GetToolboxItems() As System.Drawing.Design.ToolboxItemCollection Implements System.Drawing.Design.IToolboxService.GetToolboxItems

        Return New ToolboxItemCollection(New ToolboxItem(0 - 1) {})

    End Function

    Public Function GetToolboxItems(ByVal category As String) As System.Drawing.Design.ToolboxItemCollection Implements System.Drawing.Design.IToolboxService.GetToolboxItems
        Return New ToolboxItemCollection(New ToolboxItem(0 - 1) {})
    End Function

    Public Function GetToolboxItems(ByVal category As String, ByVal host As System.ComponentModel.Design.IDesignerHost) As System.Drawing.Design.ToolboxItemCollection Implements System.Drawing.Design.IToolboxService.GetToolboxItems
        Return New ToolboxItemCollection(New ToolboxItem(0 - 1) {})
    End Function

    Public Function GetToolboxItems(ByVal host As System.ComponentModel.Design.IDesignerHost) As System.Drawing.Design.ToolboxItemCollection Implements System.Drawing.Design.IToolboxService.GetToolboxItems
        Return New ToolboxItemCollection(New ToolboxItem(0 - 1) {})

    End Function

    Public Function IsSupported(ByVal serializedObject As Object, ByVal filterAttributes As System.Collections.ICollection) As Boolean Implements System.Drawing.Design.IToolboxService.IsSupported
        Return True

    End Function

    Public Function IsSupported(ByVal serializedObject As Object, ByVal host As System.ComponentModel.Design.IDesignerHost) As Boolean Implements System.Drawing.Design.IToolboxService.IsSupported
        Return True

    End Function

    Public Function IsToolboxItem(ByVal serializedObject As Object) As Boolean Implements System.Drawing.Design.IToolboxService.IsToolboxItem
        Return Me.IsToolboxItem(serializedObject, Nothing)

    End Function

    Public Function IsToolboxItem(ByVal serializedObject As Object, ByVal host As System.ComponentModel.Design.IDesignerHost) As Boolean Implements System.Drawing.Design.IToolboxService.IsToolboxItem

        Dim format As String
        Dim dataObject As IDataObject = TryCast(serializedObject, IDataObject)
        If (dataObject Is Nothing) Then
            Return False
        End If
        Return (dataObject.GetDataPresent(GetType(ToolboxItem)) OrElse (Not Me.FindToolboxItemCreator(dataObject, host, format) Is Nothing))

    End Function

    Public Sub Refresh1() Implements System.Drawing.Design.IToolboxService.Refresh

    End Sub

    Public Sub RemoveCreator(ByVal format As String) Implements System.Drawing.Design.IToolboxService.RemoveCreator
        RemoveCreator(format, Nothing)
    End Sub

    Public Sub RemoveCreator(ByVal format As String, ByVal host As System.ComponentModel.Design.IDesignerHost) Implements System.Drawing.Design.IToolboxService.RemoveCreator

        If (format Is Nothing) Then
            Throw New ArgumentNullException("format")
        End If
        If (Not Me.customCreators Is Nothing) Then
            Dim key As String = format
            If (Not host Is Nothing) Then
                key = (key & ", " & (CType(host, Object)).GetHashCode.ToString)
            End If
            Me.customCreators.Remove(key)
        End If

    End Sub

    Public Sub RemoveToolboxItem(ByVal toolboxItem As System.Drawing.Design.ToolboxItem) Implements System.Drawing.Design.IToolboxService.RemoveToolboxItem

    End Sub

    Public Sub RemoveToolboxItem(ByVal toolboxItem As System.Drawing.Design.ToolboxItem, ByVal category As String) Implements System.Drawing.Design.IToolboxService.RemoveToolboxItem

    End Sub

    Public Property SelectedCategory1() As String Implements System.Drawing.Design.IToolboxService.SelectedCategory
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Sub SelectedToolboxItemUsed() Implements System.Drawing.Design.IToolboxService.SelectedToolboxItemUsed
        SetSelectedToolboxItem(Nothing)
    End Sub

    Public Function SerializeToolboxItem(ByVal toolboxItem As System.Drawing.Design.ToolboxItem) As Object Implements System.Drawing.Design.IToolboxService.SerializeToolboxItem

        Dim dataObject As New DataObject
        dataObject.SetData(GetType(ToolboxItem), toolboxItem)
        Return dataObject

    End Function

    Public Function SetCursor() As Boolean Implements System.Drawing.Design.IToolboxService.SetCursor

        If (Not Me.currentSelection Is Nothing) Then
            Cursor.Current = Cursors.Cross
            Return True
        End If
        Return False

    End Function


End Class
Friend Class SelfHostToolboxItem
    ' Methods
    Public Sub New(ByVal componentClassName As String)
        Me.m_name = Nothing
        Me.m_className = Nothing
        Me.m_glyph = Nothing
        Me.m_componentClassName = componentClassName
    End Sub


    ' Properties
    Public ReadOnly Property ClassName() As String
        Get
            If (Me.m_className Is Nothing) Then
                Me.m_className = Me.ComponentClass.FullName
            End If
            Return Me.m_className
        End Get
    End Property

    Public ReadOnly Property ComponentClass() As Type
        Get
            If (Me.m_componentClass Is Nothing) Then
                Me.m_componentClass = Type.GetType(Me.m_componentClassName)
                If (Me.m_componentClass Is Nothing) Then
                    Dim index As Integer = Me.m_componentClassName.IndexOf(",")
                    If (index >= 0) Then
                        Me.m_componentClassName = Me.m_componentClassName.Substring(0, index)
                    End If
                    Dim referencedAssemblyName As AssemblyName
                    For Each referencedAssemblyName In assembly.GetExecutingAssembly.GetReferencedAssemblies
                        Dim assembly As Assembly = assembly.Load(referencedAssemblyName)
                        If (Not [assembly] Is Nothing) Then
                            Me.m_componentClass = [assembly].GetType(Me.m_componentClassName)
                            If (Not Me.m_componentClass Is Nothing) Then
                                Exit For
                            End If
                        End If
                    Next
                    Me.m_componentClass = GetType(SequentialWorkflowActivity).Assembly.GetType(Me.m_componentClassName)
                End If
            End If
            Return Me.m_componentClass
        End Get
    End Property

    Public Overridable ReadOnly Property Glyph() As Image
        Get
            If (Me.m_glyph Is Nothing) Then
                Dim t As Type = Me.ComponentClass
                If (t Is Nothing) Then
                    t = GetType(Component)
                End If
                Dim attr As ToolboxBitmapAttribute = DirectCast(TypeDescriptor.GetAttributes(t).Item(GetType(ToolboxBitmapAttribute)), ToolboxBitmapAttribute)
                If (Not attr Is Nothing) Then
                    Me.m_glyph = attr.GetImage(t, False)
                End If
            End If
            Return Me.m_glyph
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            If (Me.m_name Is Nothing) Then
                If (Not Me.ComponentClass Is Nothing) Then
                    Me.m_name = Me.ComponentClass.Name
                Else
                    Me.m_name = "Unknown Item"
                End If
            End If
            Return Me.m_name
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Me.m_componentClassName
    End Function



    ' Fields
    Private m_className As String
    Private m_componentClass As Type
    Private m_componentClassName As String
    Private m_glyph As Image
    Private m_name As String
End Class

