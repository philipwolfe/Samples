'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) 2005 Microsoft Corporation.  All rights reserved.
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

Imports System.Collections
Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection

Public Class BindingNavigatorSample

    Private Const FlagsPrefix As String = "BindingNavigatorSample."
    Private flagsMapping As New Hashtable()

    Public Sub New()
        ' Call Base
        MyBase.New()

        ' Initialize
        InitializeComponent()

        ' Set the informational text
        SetInfoMessage(Nothing)

    End Sub 'New

    Private Sub SetInfoMessage(ByVal Sender As Object)
        If Nothing Is Sender Then
            ' Default message
            Me.info.Text = "This sample demonstrates a BindingNavigator bound to a BindingSource.  The BindingNavigator is a subclass of ToolStrip that contains a pre-populated set of buttons for navigating through data in a BindingSource.  The functionality behind these buttons is extensible.  In this sample, the New button behavior is overridden.  Click on the New button to add a row to the BindingSource."
        ElseIf Me.bindingNavigatorMoveFirstItem Is Sender Then
            Me.info.Text = "Click on this Button to navigate to the first item in the BindingSource.  This calls BindingSource.MoveFirst()."
        ElseIf Me.bindingNavigatorMovePreviousItem Is Sender Then
            Me.info.Text = "Click on this Button to navigate to the previous item in the BindingSource.  This calls BindingSource.MovePrevious()."
        ElseIf Me.bindingNavigatorMoveNextItem Is Sender Then
            Me.info.Text = "Click on this Button to navigate to the next item in the BindingSource.  This calls BindingSource.MoveNext()."
        ElseIf Me.bindingNavigatorMoveLastItem Is Sender Then
            Me.info.Text = "Click on this Button to navigate to the last item in the BindingSource.  This calls BindingSource.MoveLast()."
        ElseIf Me.bindingNavigatorPositionItem Is Sender Then
            Me.info.Text = "This shows the BindingSource's current position.  This calls BindingSource.Position."
        ElseIf Me.bindingNavigatorCountItem Is Sender Then
            Me.info.Text = "This shows the BindingSource's item Count.  This calls BindingSource.Count."
        ElseIf Me.flagName Is Sender Then
            Me.info.Text = "This shows the value of the Name property for the current item in the BindingSource.  This Control is bound to the 'Flag.Name' property through the BindingSource.  A default message is displayed if there are no items in the BindingSource."
        ElseIf Me.flagPicture Is Sender Then
            Me.info.Text = "This shows the value of the Image property for the current item in the BindingSource.  This Control is bound to the 'Flag.Image' property through the BindingSource.  Nothing is displayed if there are no items in the BindingSource."
        ElseIf Me.addComboBox Is Sender Then
            Me.info.Text = "Shows a list of Flags.  Select a Flag and then select the Add button to create a 'Flag' instance and add it to the BindingSource."
        ElseIf Me.flagsNavigator Is Sender Then
            Me.info.Text = "This is the BindingNavigator Control.  It provides a set of buttons for performing standard actions on the data in a BindingSource."
        ElseIf Me.bindingNavigatorAddNewItem Is Sender Then
            Me.info.Text = "Creates and instance of the 'Flag' Type and adds it to the BindingSource."
        End If

    End Sub 'SetInfoMessage

    Private Sub BindingSourceSample_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim MyAssembly As Assembly = Me.GetType().Assembly

        ' Fill Combo Box with images from the manifest
        Dim resources As String() = MyAssembly.GetManifestResourceNames()
        Dim pos As Integer
        Dim shortName As String

        Dim resource As String
        For Each resource In resources
            ' Look for manifest resources that start with Flags
            ' These should be the flag images we've embedded in the
            ' Assembly.
            pos = resource.IndexOf(FlagsPrefix)
            If pos >= 0 Then
                ' Get a short name (the filename of the embedded image)
                shortName = resource.Substring(pos + FlagsPrefix.Length)

                ' Only add images
                If (shortName.Contains(".gif")) Then
                    ' Add to a hashtable to map shortName to the full resource name
                    Me.flagsMapping.Add(shortName, resource)

                    ' Add to the combo box
                    ' Note - not using data binding so we can use the ComboBox to sort.
                    Me.addComboBox.Items.Add(shortName)
                End If
            End If
        Next resource

        ' Set the first item as the selected item
        Me.addComboBox.SelectedIndex = 0

        ' Fix TextBox Size
        Me.bindingNavigatorPositionItem.Width = 50

    End Sub 'BindingSourceSample_Load

    Private Sub bindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bindingNavigatorAddNewItem.Click
        Dim MyAssembly As Assembly = Me.GetType().Assembly
        Dim imageName As String = CStr(Me.addComboBox.SelectedItem)
        Dim resource As String = CStr(Me.flagsMapping(imageName))

        ' Get the image from the manifest
        Dim resimage As Image = Image.FromStream(MyAssembly.GetManifestResourceStream(resource))

        ' Create a Flag instance and add it to the BindingSource
        Me.flagsBindingSource.Add(New Flag(imageName, resimage))

        ' Set position
        Me.flagsBindingSource.Position = Me.flagsBindingSource.Count - 1

        ' Remove from the ComboBox (don't allow adding the same item twice)
        Me.addComboBox.Items.Remove(imageName)

        ' Select the first item
        If Me.addComboBox.Items.Count > 0 Then
            Me.addComboBox.SelectedIndex = 0
        Else
            Me.bindingNavigatorAddNewItem.Enabled = False
        End If
    End Sub

    Private Sub Mouse_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bindingNavigatorMoveFirstItem.MouseLeave, bindingNavigatorMovePreviousItem.MouseLeave, bindingNavigatorPositionItem.MouseLeave, bindingNavigatorCountItem.MouseLeave, bindingNavigatorMoveNextItem.MouseLeave, bindingNavigatorMoveLastItem.MouseLeave, flagName.MouseEnter, flagPicture.MouseEnter, bindingNavigatorCountItem.MouseEnter, bindingNavigatorMoveFirstItem.MouseEnter, bindingNavigatorMovePreviousItem.MouseEnter, bindingNavigatorSeparator3.MouseEnter, bindingNavigatorSeparator3.MouseLeave, bindingNavigatorPositionItem.MouseEnter, bindingNavigatorSeparator4.MouseEnter, bindingNavigatorSeparator4.MouseLeave, bindingNavigatorMoveNextItem.MouseEnter, bindingNavigatorMoveLastItem.MouseEnter, addComboBox.MouseEnter, bindingNavigatorAddNewItem.MouseEnter
        SetInfoMessage(sender)
    End Sub

    Private Sub Mouse_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flagName.MouseLeave, flagPicture.MouseLeave, bindingNavigatorCountItem.MouseLeave, bindingNavigatorMoveFirstItem.MouseLeave, bindingNavigatorMovePreviousItem.MouseLeave, bindingNavigatorPositionItem.MouseLeave, bindingNavigatorMoveNextItem.MouseLeave, bindingNavigatorMoveLastItem.MouseLeave, addComboBox.MouseLeave, bindingNavigatorAddNewItem.MouseLeave
        SetInfoMessage(Nothing)
    End Sub

End Class
