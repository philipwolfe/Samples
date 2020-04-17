<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class EditorOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.checkWordWrap = New System.Windows.Forms.CheckBox
        Me.checkDetectURLs = New System.Windows.Forms.CheckBox
        Me.ButtonOK = New System.Windows.Forms.Button
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.checkWordWrap)
        Me.GroupBox1.Controls.Add(Me.checkDetectURLs)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General Settings"
        '
        'checkWordWrap
        '
        Me.checkWordWrap.AutoSize = True
        Me.checkWordWrap.Checked = True
        Me.checkWordWrap.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkWordWrap.Location = New System.Drawing.Point(16, 19)
        Me.checkWordWrap.Name = "checkWordWrap"
        Me.checkWordWrap.Size = New System.Drawing.Size(81, 17)
        Me.checkWordWrap.TabIndex = 0
        Me.checkWordWrap.Text = "&Word Wrap"
        Me.checkWordWrap.UseVisualStyleBackColor = True
        '
        'checkDetectURLs
        '
        Me.checkDetectURLs.AutoSize = True
        Me.checkDetectURLs.Checked = True
        Me.checkDetectURLs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkDetectURLs.Location = New System.Drawing.Point(16, 42)
        Me.checkDetectURLs.Name = "checkDetectURLs"
        Me.checkDetectURLs.Size = New System.Drawing.Size(88, 17)
        Me.checkDetectURLs.TabIndex = 1
        Me.checkDetectURLs.Text = "&Detect URLs"
        Me.checkDetectURLs.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(110, 89)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "&OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(200, 89)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "&Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'EditorOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 121)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "EditorOptions"
        Me.Text = "EditorOptions"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents checkDetectURLs As System.Windows.Forms.CheckBox
    Friend WithEvents checkWordWrap As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
End Class
