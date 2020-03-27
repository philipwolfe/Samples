<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CounterClockwiseButton = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.ClockwiseButton = New System.Windows.Forms.Button
        Me.InstructionsLabel = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CounterClockwiseButton
        '
        Me.CounterClockwiseButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.CounterClockwiseButton.Location = New System.Drawing.Point(0, 0)
        Me.CounterClockwiseButton.Name = "CounterClockwiseButton"
        Me.CounterClockwiseButton.Size = New System.Drawing.Size(120, 24)
        Me.CounterClockwiseButton.TabIndex = 0
        Me.CounterClockwiseButton.Text = "CounterClockwise"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 272)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(240, 22)
        '
        'ClockwiseButton
        '
        Me.ClockwiseButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.ClockwiseButton.Location = New System.Drawing.Point(120, 0)
        Me.ClockwiseButton.Name = "ClockwiseButton"
        Me.ClockwiseButton.Size = New System.Drawing.Size(120, 24)
        Me.ClockwiseButton.TabIndex = 2
        Me.ClockwiseButton.Text = "Clockwise"
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.Location = New System.Drawing.Point(0, 0)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.InstructionsLabel.Size = New System.Drawing.Size(240, 148)
        Me.InstructionsLabel.Text = "Click the buttons to rotate the screen orientation"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CounterClockwiseButton)
        Me.Panel1.Controls.Add(Me.ClockwiseButton)
        Me.Panel1.Location = New System.Drawing.Point(0, 240)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 24)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.InstructionsLabel)
        Me.Controls.Add(Me.StatusBar1)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CounterClockwiseButton As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents ClockwiseButton As System.Windows.Forms.Button
    Friend WithEvents InstructionsLabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
