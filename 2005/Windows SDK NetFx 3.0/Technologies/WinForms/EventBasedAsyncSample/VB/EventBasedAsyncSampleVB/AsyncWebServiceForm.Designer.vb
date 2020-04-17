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
Partial Public Class AsyncWebServiceForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsyncWebServiceForm))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.WebServiceOperationToolStripTextProgressPanel = New System.Windows.Forms.ToolStripStatusLabel
        Me.WebServiceOperationToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.GroupBoxWebServiceCall = New System.Windows.Forms.GroupBox
        Me.lblAnswer = New System.Windows.Forms.Label
        Me.txtAnswer = New System.Windows.Forms.TextBox
        Me.cmbQuestion = New System.Windows.Forms.ComboBox
        Me.lblQuestion = New System.Windows.Forms.Label
        Me.btnAskTheQuestion = New System.Windows.Forms.Button
        Me.lblUrl = New System.Windows.Forms.Label
        Me.txtWebServiceUrl = New System.Windows.Forms.TextBox
        Me.GroupBoxInstructions = New System.Windows.Forms.GroupBox
        Me.ViewWebServiceSourceLinkLabel = New System.Windows.Forms.LinkLabel
        Me.SimulateProgressTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SimpleWebService1 = New Microsoft.Samples.WinForms.EventBasedAsync.SimpleWebServices.SimpleWebService
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBoxWebServiceCall.SuspendLayout()
        Me.GroupBoxInstructions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(350, 129)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WebServiceOperationToolStripTextProgressPanel, Me.WebServiceOperationToolStripProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 266)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(455, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'WebServiceOperationToolStripTextProgressPanel
        '
        Me.WebServiceOperationToolStripTextProgressPanel.Name = "WebServiceOperationToolStripTextProgressPanel"
        Me.WebServiceOperationToolStripTextProgressPanel.Size = New System.Drawing.Size(38, 17)
        Me.WebServiceOperationToolStripTextProgressPanel.Text = "Ready"
        '
        'WebServiceOperationToolStripProgressBar
        '
        Me.WebServiceOperationToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.WebServiceOperationToolStripProgressBar.Name = "WebServiceOperationToolStripProgressBar"
        Me.WebServiceOperationToolStripProgressBar.Size = New System.Drawing.Size(100, 15)
        Me.WebServiceOperationToolStripProgressBar.Step = 1
        Me.WebServiceOperationToolStripProgressBar.Visible = False
        '
        'GroupBoxWebServiceCall
        '
        Me.GroupBoxWebServiceCall.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxWebServiceCall.Controls.Add(Me.lblAnswer)
        Me.GroupBoxWebServiceCall.Controls.Add(Me.txtAnswer)
        Me.GroupBoxWebServiceCall.Controls.Add(Me.cmbQuestion)
        Me.GroupBoxWebServiceCall.Controls.Add(Me.lblQuestion)
        Me.GroupBoxWebServiceCall.Controls.Add(Me.btnCancel)
        Me.GroupBoxWebServiceCall.Controls.Add(Me.btnAskTheQuestion)
        Me.GroupBoxWebServiceCall.Controls.Add(Me.lblUrl)
        Me.GroupBoxWebServiceCall.Controls.Add(Me.txtWebServiceUrl)
        Me.GroupBoxWebServiceCall.Location = New System.Drawing.Point(10, 94)
        Me.GroupBoxWebServiceCall.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.GroupBoxWebServiceCall.Name = "GroupBoxWebServiceCall"
        Me.GroupBoxWebServiceCall.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBoxWebServiceCall.Size = New System.Drawing.Size(435, 160)
        Me.GroupBoxWebServiceCall.TabIndex = 0
        Me.GroupBoxWebServiceCall.TabStop = False
        Me.GroupBoxWebServiceCall.Text = "Web Service"
        '
        'lblAnswer
        '
        Me.lblAnswer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Location = New System.Drawing.Point(7, 107)
        Me.lblAnswer.Margin = New System.Windows.Forms.Padding(2, 3, 1, 3)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(45, 13)
        Me.lblAnswer.TabIndex = 14
        Me.lblAnswer.Text = "Answer:"
        '
        'txtAnswer
        '
        Me.txtAnswer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAnswer.Location = New System.Drawing.Point(60, 104)
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.ReadOnly = True
        Me.txtAnswer.Size = New System.Drawing.Size(365, 20)
        Me.txtAnswer.TabIndex = 3
        '
        'cmbQuestion
        '
        Me.cmbQuestion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQuestion.FormattingEnabled = True
        Me.cmbQuestion.Items.AddRange(New Object() {"What is the answer?", "Who am I?", "What am I doing here?", "Is it better to ask for too much?"})
        Me.cmbQuestion.Location = New System.Drawing.Point(61, 46)
        Me.cmbQuestion.Margin = New System.Windows.Forms.Padding(0, 2, 3, 3)
        Me.cmbQuestion.Name = "cmbQuestion"
        Me.cmbQuestion.Size = New System.Drawing.Size(364, 21)
        Me.cmbQuestion.TabIndex = 1
        '
        'lblQuestion
        '
        Me.lblQuestion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Location = New System.Drawing.Point(7, 49)
        Me.lblQuestion.Margin = New System.Windows.Forms.Padding(2, 3, 1, 3)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(52, 13)
        Me.lblQuestion.TabIndex = 11
        Me.lblQuestion.Text = "Question:"
        '
        'btnAskTheQuestion
        '
        Me.btnAskTheQuestion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAskTheQuestion.Location = New System.Drawing.Point(295, 74)
        Me.btnAskTheQuestion.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnAskTheQuestion.Name = "btnAskTheQuestion"
        Me.btnAskTheQuestion.Size = New System.Drawing.Size(130, 23)
        Me.btnAskTheQuestion.TabIndex = 2
        Me.btnAskTheQuestion.Text = "&Ask the Question"
        '
        'lblUrl
        '
        Me.lblUrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUrl.AutoSize = True
        Me.lblUrl.Location = New System.Drawing.Point(7, 25)
        Me.lblUrl.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lblUrl.Name = "lblUrl"
        Me.lblUrl.Size = New System.Drawing.Size(23, 13)
        Me.lblUrl.TabIndex = 3
        Me.lblUrl.Text = "Url:"
        '
        'txtWebServiceUrl
        '
        Me.txtWebServiceUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWebServiceUrl.Location = New System.Drawing.Point(61, 22)
        Me.txtWebServiceUrl.Margin = New System.Windows.Forms.Padding(2, 2, 3, 2)
        Me.txtWebServiceUrl.Name = "txtWebServiceUrl"
        Me.txtWebServiceUrl.Size = New System.Drawing.Size(364, 20)
        Me.txtWebServiceUrl.TabIndex = 0
        Me.txtWebServiceUrl.Text = "http://localhost/samplewebservices/simplewebservice.asmx"
        '
        'GroupBoxInstructions
        '
        Me.GroupBoxInstructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxInstructions.Controls.Add(Me.ViewWebServiceSourceLinkLabel)
        Me.GroupBoxInstructions.Location = New System.Drawing.Point(8, 13)
        Me.GroupBoxInstructions.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.GroupBoxInstructions.Name = "GroupBoxInstructions"
        Me.GroupBoxInstructions.Padding = New System.Windows.Forms.Padding(9)
        Me.GroupBoxInstructions.Size = New System.Drawing.Size(437, 75)
        Me.GroupBoxInstructions.TabIndex = 2
        Me.GroupBoxInstructions.TabStop = False
        Me.GroupBoxInstructions.Text = "Instructions"
        '
        'ViewWebServiceSourceLinkLabel
        '
        Me.ViewWebServiceSourceLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewWebServiceSourceLinkLabel.Location = New System.Drawing.Point(9, 22)
        Me.ViewWebServiceSourceLinkLabel.Name = "ViewWebServiceSourceLinkLabel"
        Me.ViewWebServiceSourceLinkLabel.Size = New System.Drawing.Size(419, 44)
        Me.ViewWebServiceSourceLinkLabel.TabIndex = 1
        Me.ViewWebServiceSourceLinkLabel.TabStop = True
        Me.ViewWebServiceSourceLinkLabel.Text = resources.GetString("ViewWebServiceSourceLinkLabel.Text")
        '
        'SimulateProgressTimer
        '
        Me.SimulateProgressTimer.Interval = 120
        '
        'SimpleWebService1
        '
        Me.SimpleWebService1.Credentials = Nothing
        Me.SimpleWebService1.Url = "http://localhost/samplewebservices/SimpleWebService.asmx"
        Me.SimpleWebService1.UseDefaultCredentials = False
        '
        'AsyncWebServiceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 288)
        Me.Controls.Add(Me.GroupBoxInstructions)
        Me.Controls.Add(Me.GroupBoxWebServiceCall)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MinimumSize = New System.Drawing.Size(463, 301)
        Me.Name = "AsyncWebServiceForm"
        Me.Text = "Async WebService Sample"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBoxWebServiceCall.ResumeLayout(False)
        Me.GroupBoxWebServiceCall.PerformLayout()
        Me.GroupBoxInstructions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents WebServiceOperationToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents GroupBoxWebServiceCall As System.Windows.Forms.GroupBox
    Friend WithEvents btnAskTheQuestion As System.Windows.Forms.Button
    Friend WithEvents lblUrl As System.Windows.Forms.Label
    Friend WithEvents txtWebServiceUrl As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxInstructions As System.Windows.Forms.GroupBox
    Friend WithEvents WorkaroundPanel As System.Windows.Forms.Panel
    Friend WithEvents ViewWebServiceSourceLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents lblQuestion As System.Windows.Forms.Label
    Friend WithEvents WebServiceOperationToolStripTextProgressPanel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbQuestion As System.Windows.Forms.ComboBox
    Friend WithEvents lblAnswer As System.Windows.Forms.Label
    Friend WithEvents txtAnswer As System.Windows.Forms.TextBox
    Friend WithEvents SimulateProgressTimer As System.Windows.Forms.Timer
    Friend WithEvents SimpleWebService1 As Microsoft.Samples.WinForms.EventBasedAsync.SimpleWebServices.SimpleWebService
End Class
