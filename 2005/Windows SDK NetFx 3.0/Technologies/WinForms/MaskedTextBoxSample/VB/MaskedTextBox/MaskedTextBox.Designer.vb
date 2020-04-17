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

Partial Class MaskedTextBox
    Inherits System.Windows.Forms.Form

    '<summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    '</summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MaskedTextBox))
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip
        Me.maskCompletedStatusStripPanel = New System.Windows.Forms.ToolStripStatusLabel
        Me.maskFullStatusStripPanel = New System.Windows.Forms.ToolStripStatusLabel
        Me.propertiesGroupBox = New System.Windows.Forms.GroupBox
        Me.copyMaskFormatComboBox = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        Me.textMaskFormatComboBox = New System.Windows.Forms.ComboBox
        Me.label3 = New System.Windows.Forms.Label
        Me.insertKeyModeCheckBox = New System.Windows.Forms.CheckBox
        Me.beepOnErrorCheckBox = New System.Windows.Forms.CheckBox
        Me.hidePromptOnLeaveCheckBox = New System.Windows.Forms.CheckBox
        Me.promptCharComboBox = New System.Windows.Forms.ComboBox
        Me.promptCharLabel = New System.Windows.Forms.Label
        Me.useSystemPasswordCharCheckBox = New System.Windows.Forms.CheckBox
        Me.eventLogTextBox = New System.Windows.Forms.TextBox
        Me.eventLogLabel = New System.Windows.Forms.Label
        Me.passwordCharLabel = New System.Windows.Forms.Label
        Me.passwordCharCombo = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.maskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.outputTextBox = New System.Windows.Forms.TextBox
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.button1 = New System.Windows.Forms.Button
        Me.statusStrip1.SuspendLayout()
        Me.propertiesGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.maskCompletedStatusStripPanel, Me.maskFullStatusStripPanel})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 442)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(522, 22)
        Me.statusStrip1.TabIndex = 0
        Me.statusStrip1.Text = "statusStrip1"
        '
        'maskCompletedStatusStripPanel
        '
        Me.maskCompletedStatusStripPanel.Name = "maskCompletedStatusStripPanel"
        Me.maskCompletedStatusStripPanel.Size = New System.Drawing.Size(85, 17)
        Me.maskCompletedStatusStripPanel.Text = "Mask Completed"
        '
        'maskFullStatusStripPanel
        '
        Me.maskFullStatusStripPanel.Name = "maskFullStatusStripPanel"
        Me.maskFullStatusStripPanel.Size = New System.Drawing.Size(50, 17)
        Me.maskFullStatusStripPanel.Text = "Mask Full"
        '
        'propertiesGroupBox
        '
        Me.propertiesGroupBox.Controls.Add(Me.copyMaskFormatComboBox)
        Me.propertiesGroupBox.Controls.Add(Me.label4)
        Me.propertiesGroupBox.Controls.Add(Me.textMaskFormatComboBox)
        Me.propertiesGroupBox.Controls.Add(Me.label3)
        Me.propertiesGroupBox.Controls.Add(Me.insertKeyModeCheckBox)
        Me.propertiesGroupBox.Controls.Add(Me.beepOnErrorCheckBox)
        Me.propertiesGroupBox.Controls.Add(Me.hidePromptOnLeaveCheckBox)
        Me.propertiesGroupBox.Controls.Add(Me.promptCharComboBox)
        Me.propertiesGroupBox.Controls.Add(Me.promptCharLabel)
        Me.propertiesGroupBox.Controls.Add(Me.useSystemPasswordCharCheckBox)
        Me.propertiesGroupBox.Controls.Add(Me.eventLogTextBox)
        Me.propertiesGroupBox.Controls.Add(Me.eventLogLabel)
        Me.propertiesGroupBox.Controls.Add(Me.passwordCharLabel)
        Me.propertiesGroupBox.Controls.Add(Me.passwordCharCombo)
        Me.propertiesGroupBox.Location = New System.Drawing.Point(11, 66)
        Me.propertiesGroupBox.Name = "propertiesGroupBox"
        Me.propertiesGroupBox.Size = New System.Drawing.Size(499, 310)
        Me.propertiesGroupBox.TabIndex = 1
        Me.propertiesGroupBox.TabStop = False
        Me.propertiesGroupBox.Text = "Properties"
        '
        'copyMaskFormatComboBox
        '
        Me.copyMaskFormatComboBox.DropDownWidth = 150
        Me.copyMaskFormatComboBox.FormattingEnabled = True
        Me.copyMaskFormatComboBox.Location = New System.Drawing.Point(373, 111)
        Me.copyMaskFormatComboBox.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.copyMaskFormatComboBox.Name = "copyMaskFormatComboBox"
        Me.copyMaskFormatComboBox.Size = New System.Drawing.Size(116, 21)
        Me.copyMaskFormatComboBox.TabIndex = 7
        Me.toolTip1.SetToolTip(Me.copyMaskFormatComboBox, "Setting the CutCopyMaskFormat property changes whether " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prompt and / or literal " & _
                "characters are included in the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "string captured on cut and copy operations.")
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(258, 114)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(106, 13)
        Me.label4.TabIndex = 15
        Me.label4.Text = "Mask Format in Copy"
        Me.toolTip1.SetToolTip(Me.label4, "Setting the CutCopyMaskFormat property changes whether " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prompt and / or literal " & _
                "characters are included in the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "string captured on cut and copy operations.")
        '
        'textMaskFormatComboBox
        '
        Me.textMaskFormatComboBox.DropDownWidth = 150
        Me.textMaskFormatComboBox.FormattingEnabled = True
        Me.textMaskFormatComboBox.Location = New System.Drawing.Point(373, 80)
        Me.textMaskFormatComboBox.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.textMaskFormatComboBox.Name = "textMaskFormatComboBox"
        Me.textMaskFormatComboBox.Size = New System.Drawing.Size(116, 21)
        Me.textMaskFormatComboBox.TabIndex = 6
        Me.toolTip1.SetToolTip(Me.textMaskFormatComboBox, "Setting the TextMaskFormat property changes whether " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prompt and / or literal cha" & _
                "racters are included in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the Text property.")
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(258, 83)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(103, 13)
        Me.label3.TabIndex = 13
        Me.label3.Text = "Mask Format in Text"
        Me.toolTip1.SetToolTip(Me.label3, "Setting the TextMaskFormat property changes whether " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prompt and / or literal cha" & _
                "racters are included in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the Text property.")
        '
        'insertKeyModeCheckBox
        '
        Me.insertKeyModeCheckBox.Location = New System.Drawing.Point(7, 108)
        Me.insertKeyModeCheckBox.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.insertKeyModeCheckBox.Name = "insertKeyModeCheckBox"
        Me.insertKeyModeCheckBox.Size = New System.Drawing.Size(157, 24)
        Me.insertKeyModeCheckBox.TabIndex = 3
        Me.insertKeyModeCheckBox.Text = "Insert key mode"
        Me.toolTip1.SetToolTip(Me.insertKeyModeCheckBox, resources.GetString("insertKeyModeCheckBox.ToolTip"))
        '
        'beepOnErrorCheckBox
        '
        Me.beepOnErrorCheckBox.Location = New System.Drawing.Point(7, 76)
        Me.beepOnErrorCheckBox.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.beepOnErrorCheckBox.Name = "beepOnErrorCheckBox"
        Me.beepOnErrorCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.beepOnErrorCheckBox.TabIndex = 2
        Me.beepOnErrorCheckBox.Text = "Beep on error"
        Me.toolTip1.SetToolTip(Me.beepOnErrorCheckBox, "Setting the BeepOnError property to true causes the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MaskedTextBox to play a beep" & _
                " when a character is " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "entered that does not conform to the the mask.")
        '
        'hidePromptOnLeaveCheckBox
        '
        Me.hidePromptOnLeaveCheckBox.Location = New System.Drawing.Point(7, 46)
        Me.hidePromptOnLeaveCheckBox.Name = "hidePromptOnLeaveCheckBox"
        Me.hidePromptOnLeaveCheckBox.Size = New System.Drawing.Size(157, 24)
        Me.hidePromptOnLeaveCheckBox.TabIndex = 1
        Me.hidePromptOnLeaveCheckBox.Text = "Hide prompt on leave"
        Me.toolTip1.SetToolTip(Me.hidePromptOnLeaveCheckBox, "Setting the HidePromptOnLeave property causes the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prompt characters to be hidde" & _
                "n when the MaskedTextBox " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "loses focus.")
        '
        'promptCharComboBox
        '
        Me.promptCharComboBox.FormattingEnabled = True
        Me.promptCharComboBox.Location = New System.Drawing.Point(373, 49)
        Me.promptCharComboBox.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.promptCharComboBox.Name = "promptCharComboBox"
        Me.promptCharComboBox.Size = New System.Drawing.Size(116, 21)
        Me.promptCharComboBox.TabIndex = 5
        Me.toolTip1.SetToolTip(Me.promptCharComboBox, "Setting the PromptChar property changes all the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prompt characters in the Masked" & _
                "TextBox to the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "specified character.")
        '
        'promptCharLabel
        '
        Me.promptCharLabel.AutoSize = True
        Me.promptCharLabel.Location = New System.Drawing.Point(258, 52)
        Me.promptCharLabel.Name = "promptCharLabel"
        Me.promptCharLabel.Size = New System.Drawing.Size(89, 13)
        Me.promptCharLabel.TabIndex = 11
        Me.promptCharLabel.Text = "Prompt Character"
        Me.toolTip1.SetToolTip(Me.promptCharLabel, "Setting the PromptChar property changes all the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prompt characters in the Masked" & _
                "TextBox to the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "specified character.")
        '
        'useSystemPasswordCharCheckBox
        '
        Me.useSystemPasswordCharCheckBox.Location = New System.Drawing.Point(7, 16)
        Me.useSystemPasswordCharCheckBox.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.useSystemPasswordCharCheckBox.Name = "useSystemPasswordCharCheckBox"
        Me.useSystemPasswordCharCheckBox.Size = New System.Drawing.Size(202, 24)
        Me.useSystemPasswordCharCheckBox.TabIndex = 0
        Me.useSystemPasswordCharCheckBox.Text = "Use system password character"
        Me.toolTip1.SetToolTip(Me.useSystemPasswordCharCheckBox, resources.GetString("useSystemPasswordCharCheckBox.ToolTip"))
        '
        'eventLogTextBox
        '
        Me.eventLogTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.eventLogTextBox.Location = New System.Drawing.Point(6, 153)
        Me.eventLogTextBox.Multiline = True
        Me.eventLogTextBox.Name = "eventLogTextBox"
        Me.eventLogTextBox.ReadOnly = True
        Me.eventLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.eventLogTextBox.Size = New System.Drawing.Size(487, 151)
        Me.eventLogTextBox.TabIndex = 8
        Me.toolTip1.SetToolTip(Me.eventLogTextBox, "The TextBox below will echo the MaskInputRejected and " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TypeValidationFailed even" & _
                "ts.")
        '
        'eventLogLabel
        '
        Me.eventLogLabel.AutoSize = True
        Me.eventLogLabel.Location = New System.Drawing.Point(4, 136)
        Me.eventLogLabel.Name = "eventLogLabel"
        Me.eventLogLabel.Size = New System.Drawing.Size(59, 13)
        Me.eventLogLabel.TabIndex = 3
        Me.eventLogLabel.Text = "Event Log:"
        Me.toolTip1.SetToolTip(Me.eventLogLabel, "The TextBox below will echo the MaskInputRejected and " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TypeValidationFailed even" & _
                "ts.")
        '
        'passwordCharLabel
        '
        Me.passwordCharLabel.AutoSize = True
        Me.passwordCharLabel.Location = New System.Drawing.Point(258, 22)
        Me.passwordCharLabel.Name = "passwordCharLabel"
        Me.passwordCharLabel.Size = New System.Drawing.Size(102, 13)
        Me.passwordCharLabel.TabIndex = 3
        Me.passwordCharLabel.Text = "Password Character"
        Me.toolTip1.SetToolTip(Me.passwordCharLabel, resources.GetString("passwordCharLabel.ToolTip"))
        '
        'passwordCharCombo
        '
        Me.passwordCharCombo.FormattingEnabled = True
        Me.passwordCharCombo.Location = New System.Drawing.Point(373, 19)
        Me.passwordCharCombo.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.passwordCharCombo.Name = "passwordCharCombo"
        Me.passwordCharCombo.Size = New System.Drawing.Size(116, 21)
        Me.passwordCharCombo.TabIndex = 4
        Me.toolTip1.SetToolTip(Me.passwordCharCombo, resources.GetString("passwordCharCombo.ToolTip"))
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(131, 29)
        Me.label1.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(89, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Enter IP Address:"
        Me.toolTip1.SetToolTip(Me.label1, resources.GetString("label1.ToolTip"))
        '
        'maskedTextBox1
        '
        Me.maskedTextBox1.Location = New System.Drawing.Point(225, 26)
        Me.maskedTextBox1.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.maskedTextBox1.Mask = "099.099.099.099"
        Me.maskedTextBox1.Name = "maskedTextBox1"
        Me.maskedTextBox1.Size = New System.Drawing.Size(137, 20)
        Me.maskedTextBox1.TabIndex = 0
        Me.toolTip1.SetToolTip(Me.maskedTextBox1, resources.GetString("maskedTextBox1.ToolTip"))
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(131, 404)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(73, 13)
        Me.label2.TabIndex = 9
        Me.label2.Text = "Text Property:"
        Me.toolTip1.SetToolTip(Me.label2, "The Text property of the TextBox is set to the Text " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "property of the MaskedTextB" & _
                "ox above.")
        '
        'outputTextBox
        '
        Me.outputTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.outputTextBox.Location = New System.Drawing.Point(224, 401)
        Me.outputTextBox.Name = "outputTextBox"
        Me.outputTextBox.ReadOnly = True
        Me.outputTextBox.Size = New System.Drawing.Size(138, 20)
        Me.outputTextBox.TabIndex = 2
        Me.toolTip1.SetToolTip(Me.outputTextBox, "The Text property of the TextBox is set to the Text " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "property of the MaskedTextB" & _
                "ox above.")
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(399, 399)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(111, 23)
        Me.button1.TabIndex = 3
        Me.button1.Text = "Create IP Object"
        '
        'MaskedTextBox
        '
        Me.ClientSize = New System.Drawing.Size(522, 464)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.outputTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.maskedTextBox1)
        Me.Controls.Add(Me.propertiesGroupBox)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "MaskedTextBox"
        Me.Text = "MaskedTextBox Sample"
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.propertiesGroupBox.ResumeLayout(False)
        Me.propertiesGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub 'InitializeComponent


    '<summary>
    ' Clean up any resources being used.
    '</summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub 'Dispose

    Private statusStrip1 As System.Windows.Forms.StatusStrip
    Private maskCompletedStatusStripPanel As System.Windows.Forms.ToolStripStatusLabel
    Private maskFullStatusStripPanel As System.Windows.Forms.ToolStripStatusLabel
    Private propertiesGroupBox As System.Windows.Forms.GroupBox
    Private passwordCharLabel As System.Windows.Forms.Label
    Private WithEvents passwordCharCombo As System.Windows.Forms.ComboBox
    Private eventLogTextBox As System.Windows.Forms.TextBox
    Private eventLogLabel As System.Windows.Forms.Label
    Private WithEvents useSystemPasswordCharCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents hidePromptOnLeaveCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents beepOnErrorCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents insertKeyModeCheckBox As System.Windows.Forms.CheckBox
    Private label1 As System.Windows.Forms.Label
    Private WithEvents maskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Private promptCharLabel As System.Windows.Forms.Label
    Private WithEvents promptCharComboBox As System.Windows.Forms.ComboBox
    Private label2 As System.Windows.Forms.Label
    Private outputTextBox As System.Windows.Forms.TextBox
    Private toolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents copyMaskFormatComboBox As System.Windows.Forms.ComboBox
    Private label4 As System.Windows.Forms.Label
    Private WithEvents textMaskFormatComboBox As System.Windows.Forms.ComboBox
    Private label3 As System.Windows.Forms.Label

End Class 'Form1
