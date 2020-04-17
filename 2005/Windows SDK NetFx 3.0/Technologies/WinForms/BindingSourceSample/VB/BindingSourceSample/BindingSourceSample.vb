'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
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

Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection

Public Class BindingSourceSample

    Private Const FlagsPrefix As String = "BindingSourceSample."
    Private flagsMapping As New Hashtable()

    Public Sub New()
        InitializeComponent()

        ' Set Initial State of Buttons and Position Indicator
        SetButtonState()

        ' Set the informational text
        SetInfoMessage(Nothing)
    End Sub

    Private Sub SetButtonState()
        ' Sets the "enabled" state of the previous and back buttons
        ' If the position is at the beginning then "previous" is greyed out.
        ' If the position is at the end then "next" is greyed out.
        Dim count As Integer = Me.flagsBindingSource.Count
        Dim pos As Integer = Me.flagsBindingSource.Position

        Me.movePrevious.Enabled = pos > 0
        Me.moveNext.Enabled = pos < count - 1

        ' Set the position indicator
        ' If there are no items in the list, then show -1
        If Me.flagsBindingSource.Position < 0 Then
            Me.positionIndicator.Text = Me.flagsBindingSource.Position.ToString(CultureInfo.CurrentUICulture)
        Else
            Me.positionIndicator.Text = (Me.flagsBindingSource.Position + 1).ToString(CultureInfo.CurrentUICulture) + " / " + Me.flagsBindingSource.Count.ToString(CultureInfo.CurrentUICulture)
        End If

    End Sub 'SetButtonState

    Private Sub SetInfoMessage(ByVal Sender As Control)
        If Sender Is Nothing Then
            ' Default message
            Me.info.Text = "This sample demonstrates binding BindingSource to a Type.  At design time, the BindingSource is bound to the Flag type and the flagName and flagImage Controls are bound to Flag properties through the BindingSource.  Click on the Add button to create a Flag instance and add it to the BindingSource.  Click on the < and > buttons to use the BindingSource API to navigate through the BindingSource items.  The positionIndicator TextBox shows the position of the current BindingSource item as well as the BindingSource item count."
        ElseIf Me.movePrevious Is Sender Then
            Me.info.Text = "Click on this Button to navigate to the previous item in the BindingSource.  This calls BindingSource.MovePrevious()."
        ElseIf Me.moveNext Is Sender Then
            Me.info.Text = "Click on this Button to navigate to the next item in the BindingSource.  This calls BindingSource.MoveNext()."
        ElseIf Me.positionIndicator Is Sender Then
            Me.info.Text = "This shows the BindingSource's current position and the BindingSource's item Count.  This calls BindingSource.Position and BindingSource.Count."
        ElseIf Me.flagName Is Sender Then
            Me.info.Text = "This shows the value of the Name property for the current item in the BindingSource.  This Control is bound to the 'Flag.Name' property through the BindingSource.  A default message is displayed if there are no items in the BindingSource."
        ElseIf Me.flagPicture Is Sender Then
            Me.info.Text = "This shows the value of the Image property for the current item in the BindingSource.  This Control is bound to the 'Flag.Image' property through the BindingSource.  Nothing is displayed if there are no items in the BindingSource."
        ElseIf Me.flagsCombo Is Sender Then
            Me.info.Text = "Shows a list of Flags.  Select a Flag and then select the Add button to create a 'Flag' instance and add it to the BindingSource."
        ElseIf Me.addButton Is Sender Then
            Me.info.Text = "Creates an instance of the 'Flag' Type and adds it to the BindingSource."
        End If

    End Sub 'SetInfoMessage

    Private Sub flagsBindingSource_ListChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles flagsBindingSource.ListChanged
        ' Set previous and next button state
        SetButtonState()
    End Sub
    Private Sub flagsBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flagsBindingSource.PositionChanged
        ' Set previous and next button state
        SetButtonState()
    End Sub

    Private Sub moveNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveNext.Click
        ' Move to (display) to the next item in the list
        Me.flagsBindingSource.MoveNext()
    End Sub

    Private Sub movePrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movePrevious.Click
        ' Move to (display) to the previous item in the list
        Me.flagsBindingSource.MovePrevious()
    End Sub

    Private Sub addButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addButton.Click
        Dim myAssembly As Assembly = Me.GetType().Assembly

        Dim imageName As String = CStr(Me.flagsCombo.SelectedItem)
        Dim resource As String = CStr(Me.flagsMapping(imageName))

        ' Get the image from the manifest
        Dim resimage As Image = Image.FromStream(myAssembly.GetManifestResourceStream(resource))

        ' Create a Flag instance and add it to the BindingSource
        Me.flagsBindingSource.Add(New Flag(imageName, resimage))

        ' Set Position
        Me.flagsBindingSource.Position = Me.flagsBindingSource.Count - 1

        ' Remove from the ComboBox (don't allow adding the same item twice)
        Me.flagsCombo.Items.Remove(imageName)

        ' Select the first item
        If Me.flagsCombo.Items.Count > 0 Then
            Me.flagsCombo.SelectedIndex = 0
        Else
            Me.addButton.Enabled = False
        End If
    End Sub

    Private Sub Mouse_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flagsCombo.MouseLeave, flagName.MouseLeave, flagPicture.MouseLeave, addButton.MouseLeave, movePrevious.MouseLeave, moveNext.MouseLeave
        SetInfoMessage(Nothing)
    End Sub

    Private Sub Mouse_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flagsCombo.MouseEnter, flagName.MouseEnter, flagPicture.MouseEnter, addButton.MouseEnter, positionIndicator.MouseLeave, positionIndicator.MouseEnter, movePrevious.MouseEnter, moveNext.MouseEnter
        SetInfoMessage(CType(sender, Control))
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myAssembly As Assembly = Me.GetType().Assembly

        ' Fill Combo Box with images from the manifest
        Dim resources As String() = myAssembly.GetManifestResourceNames()
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

                ' Get if the resource is an image
                If (shortName.IndexOf(".gif") > 0) Then
                    ' Add to a hashtable to map shortName to the full resource name
                    Me.flagsMapping.Add(shortName, resource)

                    ' Add to the combo box
                    ' Note - not using data binding so we can use the ComboBox to sort.
                    Me.flagsCombo.Items.Add(shortName)
                End If
            End If
        Next resource

        ' Set the first item as the selected item
        Me.flagsCombo.SelectedIndex = 0
    End Sub

End Class
