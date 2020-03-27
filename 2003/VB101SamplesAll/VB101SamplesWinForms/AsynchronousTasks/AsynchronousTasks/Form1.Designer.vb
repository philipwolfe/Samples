<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm
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
        Me.calcStatusStrip = New System.Windows.Forms.StatusStrip
        Me.calcStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.calcProgress = New System.Windows.Forms.ToolStripProgressBar
        Me.MessageLabel = New System.Windows.Forms.Label
        Me.cancelPrimeButton = New System.Windows.Forms.Button
        Me.InputString = New System.Windows.Forms.TextBox
        Me.nextPrimeAsyncButton = New System.Windows.Forms.Button
        Me.nextPrimeButton = New System.Windows.Forms.Button
        Me.PrimeNumberLabel = New System.Windows.Forms.Label
        Me.textBoxPrime = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.calcStatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'calcStatusStrip
        '
        Me.calcStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.calcStatus, Me.calcProgress})
        Me.calcStatusStrip.Location = New System.Drawing.Point(0, 393)
        Me.calcStatusStrip.Name = "calcStatusStrip"
        Me.calcStatusStrip.Size = New System.Drawing.Size(542, 23)
        Me.calcStatusStrip.TabIndex = 14
        Me.calcStatusStrip.Text = "statusStrip1"
        '
        'calcStatus
        '
        Me.calcStatus.AutoSize = False
        Me.calcStatus.Name = "calcStatus"
        Me.calcStatus.Size = New System.Drawing.Size(75, 18)
        Me.calcStatus.Text = "Status"
        Me.calcStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'calcProgress
        '
        Me.calcProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.calcProgress.AutoSize = False
        Me.calcProgress.Name = "calcProgress"
        Me.calcProgress.Size = New System.Drawing.Size(100, 17)
        '
        'MessageLabel
        '
        Me.MessageLabel.AutoSize = True
        Me.MessageLabel.Location = New System.Drawing.Point(12, 103)
        Me.MessageLabel.Name = "MessageLabel"
        Me.MessageLabel.Size = New System.Drawing.Size(206, 13)
        Me.MessageLabel.TabIndex = 13
        Me.MessageLabel.Text = "Try typing here while a prime is calculated:"
        '
        'cancelPrimeButton
        '
        Me.cancelPrimeButton.Enabled = False
        Me.cancelPrimeButton.Location = New System.Drawing.Point(321, 56)
        Me.cancelPrimeButton.Name = "cancelPrimeButton"
        Me.cancelPrimeButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelPrimeButton.TabIndex = 15
        Me.cancelPrimeButton.Text = "Cancel"
        '
        'InputString
        '
        Me.InputString.Location = New System.Drawing.Point(13, 128)
        Me.InputString.Multiline = True
        Me.InputString.Name = "InputString"
        Me.InputString.Size = New System.Drawing.Size(369, 58)
        Me.InputString.TabIndex = 12
        '
        'nextPrimeAsyncButton
        '
        Me.nextPrimeAsyncButton.Location = New System.Drawing.Point(173, 56)
        Me.nextPrimeAsyncButton.Name = "nextPrimeAsyncButton"
        Me.nextPrimeAsyncButton.Size = New System.Drawing.Size(142, 23)
        Me.nextPrimeAsyncButton.TabIndex = 11
        Me.nextPrimeAsyncButton.Text = "Asynchronous"
        '
        'nextPrimeButton
        '
        Me.nextPrimeButton.Location = New System.Drawing.Point(27, 56)
        Me.nextPrimeButton.Name = "nextPrimeButton"
        Me.nextPrimeButton.Size = New System.Drawing.Size(140, 23)
        Me.nextPrimeButton.TabIndex = 10
        Me.nextPrimeButton.Text = "Synchronous"
        '
        'PrimeNumberLabel
        '
        Me.PrimeNumberLabel.AutoSize = True
        Me.PrimeNumberLabel.Location = New System.Drawing.Point(12, 9)
        Me.PrimeNumberLabel.Name = "PrimeNumberLabel"
        Me.PrimeNumberLabel.Size = New System.Drawing.Size(76, 13)
        Me.PrimeNumberLabel.TabIndex = 9
        Me.PrimeNumberLabel.Text = "Prime Number:"
        '
        'textBoxPrime
        '
        Me.textBoxPrime.Location = New System.Drawing.Point(90, 6)
        Me.textBoxPrime.Name = "textBoxPrime"
        Me.textBoxPrime.Size = New System.Drawing.Size(138, 20)
        Me.textBoxPrime.TabIndex = 8
        Me.textBoxPrime.Text = "100000000"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(13, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 56)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generate next prime number"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.calcStatusStrip)
        Me.Controls.Add(Me.MessageLabel)
        Me.Controls.Add(Me.cancelPrimeButton)
        Me.Controls.Add(Me.InputString)
        Me.Controls.Add(Me.nextPrimeAsyncButton)
        Me.Controls.Add(Me.nextPrimeButton)
        Me.Controls.Add(Me.PrimeNumberLabel)
        Me.Controls.Add(Me.textBoxPrime)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Performing Tasks Asynchronously"
        Me.calcStatusStrip.ResumeLayout(False)
        Me.calcStatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents calcStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents calcStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents calcProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents MessageLabel As System.Windows.Forms.Label
    Friend WithEvents cancelPrimeButton As System.Windows.Forms.Button
    Friend WithEvents InputString As System.Windows.Forms.TextBox
    Friend WithEvents nextPrimeAsyncButton As System.Windows.Forms.Button
    Friend WithEvents nextPrimeButton As System.Windows.Forms.Button
    Friend WithEvents PrimeNumberLabel As System.Windows.Forms.Label
    Friend WithEvents textBoxPrime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
