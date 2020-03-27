<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.lblCodebase = New System.Windows.Forms.Label
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.pbIcon = New System.Windows.Forms.PictureBox
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCodebase
        '
        Me.lblCodebase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCodebase.Location = New System.Drawing.Point(67, 125)
        Me.lblCodebase.Name = "lblCodebase"
        Me.lblCodebase.Size = New System.Drawing.Size(360, 64)
        Me.lblCodebase.TabIndex = 13
        Me.lblCodebase.Text = "Application Codebase"
        '
        'lblCopyright
        '
        Me.lblCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCopyright.Location = New System.Drawing.Point(67, 53)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(360, 23)
        Me.lblCopyright.TabIndex = 12
        Me.lblCopyright.Text = "Application Copyright"
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(347, 197)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "OK"
        '
        'lblDescription
        '
        Me.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDescription.Location = New System.Drawing.Point(67, 77)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(360, 46)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Text = "Application Description"
        '
        'lblVersion
        '
        Me.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVersion.Location = New System.Drawing.Point(67, 37)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(360, 23)
        Me.lblVersion.TabIndex = 9
        Me.lblVersion.Text = "Application Version"
        '
        'lblTitle
        '
        Me.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitle.Location = New System.Drawing.Point(67, 13)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(360, 23)
        Me.lblTitle.TabIndex = 8
        Me.lblTitle.Text = "Application Title"
        '
        'pbIcon
        '
        Me.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbIcon.Location = New System.Drawing.Point(11, 13)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(32, 32)
        Me.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIcon.TabIndex = 7
        Me.pbIcon.TabStop = False
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 234)
        Me.Controls.Add(Me.lblCodebase)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pbIcon)
        Me.Name = "frmAbout"
        Me.Text = "About..."
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCodebase As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
End Class
