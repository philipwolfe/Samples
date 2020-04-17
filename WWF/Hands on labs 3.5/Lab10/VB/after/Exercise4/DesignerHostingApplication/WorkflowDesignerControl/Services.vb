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
Imports System.Text
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Drawing

Namespace WorkflowDesignerControl
   
    Public NotInheritable Class WorkflowMenuCommandService
        Inherits MenuCommandService
        Public Sub New(ByVal serviceProvider As IServiceProvider)
            MyBase.New(serviceProvider)
        End Sub

        Public Overrides Sub ShowContextMenu(ByVal menuID As CommandID, ByVal x As Integer, ByVal y As Integer)

            If menuID Is WorkflowMenuCommands.SelectionMenu Then

                Dim contextMenu As New ContextMenu()

                For Each verb As DesignerVerb In Verbs

                    Dim menuItem As New MenuItem(verb.Text, New EventHandler(AddressOf OnMenuClicked))
                    menuItem.Tag = verb
                    contextMenu.MenuItems.Add(menuItem)

                Next
                Dim items() As MenuItem = GetSelectionMenuItems()
                If items.Length > 0 Then

                    contextMenu.MenuItems.Add(New MenuItem("-"))
                    For Each item As MenuItem In items
                        contextMenu.MenuItems.Add(item)
                    Next
                End If

                Dim workflowView As WorkflowView = CType(GetService(GetType(WorkflowView)), WorkflowView)
                If (Not workflowView Is Nothing) Then
                    contextMenu.Show(workflowView, workflowView.PointToClient(New Point(x, y)))
                End If
            End If
        End Sub

        Private Function GetSelectionMenuItems() As MenuItem()

            Dim menuItems As List(Of MenuItem) = New List(Of MenuItem)()

            Dim addMenuItems As Boolean = True
            Dim selectionService As ISelectionService = TryCast(MyBase.GetService(GetType(ISelectionService)), ISelectionService)

            If Not selectionService Is Nothing Then
                Dim obj As Object
                For Each obj In selectionService.GetSelectedComponents()

                    If Not TypeOf obj Is Activity Then
                        addMenuItems = False
                        Exit For

                    End If
                Next
            End If

            If addMenuItems Then

                Dim selectionCommands As Dictionary(Of CommandID, String) = New Dictionary(Of CommandID, String)
                selectionCommands.Add(WorkflowMenuCommands.Cut, "Cut")
                selectionCommands.Add(WorkflowMenuCommands.Copy, "Copy")
                selectionCommands.Add(WorkflowMenuCommands.Paste, "Paste")
                selectionCommands.Add(WorkflowMenuCommands.Delete, "Delete")
                Dim id As CommandID
                For Each id In selectionCommands.Keys

                    Dim command As MenuCommand = FindCommand(id)
                    If (Not command Is Nothing) Then

                        Dim menuItem As MenuItem = New MenuItem(selectionCommands(id), New EventHandler(AddressOf OnMenuClicked))
                        menuItem.Tag = command
                        menuItems.Add(menuItem)

                    End If
                Next
            End If
            Return menuItems.ToArray()
        End Function


        Private Sub OnMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
            Dim item As MenuItem = TryCast(sender, MenuItem)
            If ((Not item Is Nothing) AndAlso TypeOf item.Tag Is MenuCommand) Then
                TryCast(item.Tag, MenuCommand).Invoke()
            End If
        End Sub


    End Class
End Namespace