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

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports System.Reflection
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Globalization

Partial Class MaskedTextBox
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer = Nothing
    Private ip As IPv5
    Private Shared logCount As Integer = 1

    Public Sub New()

        InitializeComponent()

    End Sub 'New

    ' Event handlers

    Private Sub MaskedTextBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Add items to the ComboBoxes
        Me.promptCharComboBox.Items.AddRange(New Object() {"_", " ", "$", "#", "N", "A"})

        Me.passwordCharCombo.Items.AddRange(New Object() {" ", "*", "#", "^", "P", "O"})

        Me.textMaskFormatComboBox.Items.AddRange([Enum].GetNames(GetType(MaskFormat)))
        Me.copyMaskFormatComboBox.Items.AddRange([Enum].GetNames(GetType(MaskFormat)))

        ' Sync up properties UI to MaskedTextBox
        SyncUIToControl()

        ' Setup MaskedTextBox validating type
        Me.maskedTextBox1.ValidatingType = GetType(IPv5)

        ' Bind outPutTextBox.Text to MaskedTextBox.Text
        Me.outputTextBox.DataBindings.Add(New Binding("Text", Me.maskedTextBox1, "Text", False, DataSourceUpdateMode.OnPropertyChanged, CultureInfo.CurrentCulture))

    End Sub

    Private Sub maskedTextBox1_MaskInputRejected(ByVal sender As Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles maskedTextBox1.MaskInputRejected

        AppendLog(("Mask input rejected at position: " + e.Position.ToString(CultureInfo.CurrentCulture)))
        Me.eventLogTextBox.ScrollToCaret()

    End Sub 'maskedTextBox1_MaskInputRejected

    Private Sub maskedTextBox1_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles maskedTextBox1.TypeValidationCompleted

        If e.IsValidInput Then
            AppendLog(("Type validation succeeded.  Message: " + e.Message))
            ip = e.ReturnValue
        Else
            ip = IPv5.InvalidIPv5

            AppendLog(("Type validation failed.  Message: " + e.Message))
            Me.eventLogTextBox.ScrollToCaret()
        End If

    End Sub 'maskedTextBox1_TypeValidationCompleted

    ' Methods
    Private Sub SyncUIToControl()

        Me.hidePromptOnLeaveCheckBox.Checked = Me.maskedTextBox1.HidePromptOnLeave
        Me.useSystemPasswordCharCheckBox.Checked = Me.maskedTextBox1.UseSystemPasswordChar
        Me.beepOnErrorCheckBox.Checked = Me.maskedTextBox1.BeepOnError

        Me.passwordCharCombo.SelectedIndex = 0
        Me.promptCharComboBox.SelectedIndex = 0
        Me.textMaskFormatComboBox.SelectedIndex = 3
        Me.copyMaskFormatComboBox.SelectedIndex = 3

        ' Set the insert mode checkbox
        Me.maskedTextBox1.InsertKeyMode = InsertKeyMode.Insert
        Me.insertKeyModeCheckBox.Checked = True

        ' Set read only properties 
        Me.maskCompletedStatusStripPanel.Text = "Mask Completed: " + Me.maskedTextBox1.MaskCompleted.ToString()
        Me.maskFullStatusStripPanel.Text = "Mask Full: " + Me.maskedTextBox1.MaskFull.ToString()

    End Sub 'SyncUIToControl

    Private Sub maskedTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskedTextBox1.TextChanged

        Me.maskCompletedStatusStripPanel.Text = "Mask Completed: " + Me.maskedTextBox1.MaskCompleted.ToString()
        Me.maskFullStatusStripPanel.Text = "Mask Full: " + Me.maskedTextBox1.MaskFull.ToString()

    End Sub 'maskedTextBox1_TextChanged

    Private Sub propertyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles beepOnErrorCheckBox.CheckedChanged, useSystemPasswordCharCheckBox.CheckedChanged, insertKeyModeCheckBox.CheckedChanged, hidePromptOnLeaveCheckBox.CheckedChanged

        ' Cast the sender to a CheckBox
        Dim cb As CheckBox = sender

        ' Make sure we don't have a null ref
        If Not (cb Is Nothing) Then
            ' Switch on the CheckBoxes name and 
            ' set the corresponding property value

            Select Case cb.Name
                Case "hidePromptOnLeaveCheckBox"
                    Me.maskedTextBox1.HidePromptOnLeave = cb.Checked
                Case "includeLiteralsCheckBox"
                    Me.maskedTextBox1.SkipLiterals = cb.Checked
                Case "includePromptCheckBox"
                    Me.maskedTextBox1.AllowPromptAsInput = cb.Checked
                Case "useSystemPasswordCharCheckBox"
                    Me.maskedTextBox1.UseSystemPasswordChar = cb.Checked
                Case "beepOnErrorCheckBox"
                    Me.maskedTextBox1.BeepOnError = cb.Checked
                Case "insertKeyModeCheckBox"
                    If cb.Checked Then
                        Me.maskedTextBox1.InsertKeyMode = InsertKeyMode.Insert
                    Else
                        Me.maskedTextBox1.InsertKeyMode = InsertKeyMode.Overwrite
                    End If

            End Select
        End If

    End Sub 'propertyCheckBox_CheckedChanged

    Private Sub passwordCharCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles passwordCharCombo.SelectedIndexChanged

        Try
            ' Set the PasswordChar
            Dim pwdChar As Char = Me.passwordCharCombo.SelectedItem.ToString().ToCharArray()(0)

            ' Special case a space as the null char
            If pwdChar = " "c Then
                pwdChar = vbNullChar
            End If

            Me.maskedTextBox1.PasswordChar = pwdChar

        Catch ex As InvalidOperationException

            MessageBox.Show(ex.Message)
            Me.passwordCharCombo.SelectedIndex = 0

        End Try

    End Sub 'passwordCharCombo_SelectedIndexChanged

    Private Sub promptCharComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles promptCharComboBox.SelectedIndexChanged
        Try
            ' Set the PromptChar 
            Me.maskedTextBox1.PromptChar = Me.promptCharComboBox.SelectedItem.ToString().ToCharArray()(0)
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message)
            Me.promptCharComboBox.SelectedIndex = 0
        End Try

    End Sub 'prompCharComboBox_SelectedIndexChanged

    Private Sub textMaskFormatComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textMaskFormatComboBox.SelectedIndexChanged
        Me.maskedTextBox1.TextMaskFormat = CType([Enum].Parse(GetType(MaskFormat), Me.textMaskFormatComboBox.SelectedItem.ToString()), MaskFormat)

    End Sub 'textMaskFormatComboBox_SelectedIndexChanged

    Private Sub copyMaskFormatComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles copyMaskFormatComboBox.SelectedIndexChanged
        Me.maskedTextBox1.CutCopyMaskFormat = CType([Enum].Parse(GetType(MaskFormat), Me.textMaskFormatComboBox.SelectedItem.ToString()), MaskFormat)

    End Sub 'copyMaskFormatComboBox_SelectedIndexChanged

    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click

        MessageBox.Show("IP Address: " + ip.ToString, "MaskedTextBox.Value", MessageBoxButtons.OK)

    End Sub 'button1_Click

    Private Sub AppendLog(ByVal msg As String)

        Me.eventLogTextBox.AppendText((logCount.ToString + ". " + msg + vbCr + vbLf))
        logCount += 1

    End Sub 'AppendLog

End Class 'Form1
