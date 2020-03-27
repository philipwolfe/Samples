<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.columnPublicKeyToken = New System.Windows.Forms.ColumnHeader
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.btnInstall = New System.Windows.Forms.Button
        Me.chkConfirm = New System.Windows.Forms.CheckBox
        Me.label1 = New System.Windows.Forms.Label
        Me.columnCulture = New System.Windows.Forms.ColumnHeader
        Me.btnViewCache = New System.Windows.Forms.Button
        Me.label5 = New System.Windows.Forms.Label
        Me.btnUninstall = New System.Windows.Forms.Button
        Me.columnVersion = New System.Windows.Forms.ColumnHeader
        Me.columnBaseName = New System.Windows.Forms.ColumnHeader
        Me.lvNativeImageCache = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'columnPublicKeyToken
        '
        Me.columnPublicKeyToken.Text = "Public Key Token"
        Me.columnPublicKeyToken.Width = 241
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(12, 165)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(126, 13)
        Me.label2.TabIndex = 25
        Me.label2.Text = "Native Image Cache:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(12, 48)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(269, 13)
        Me.label3.TabIndex = 24
        Me.label3.Text = "View the contents of the Native Image Cache."
        '
        'btnInstall
        '
        Me.btnInstall.Location = New System.Drawing.Point(409, 10)
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.Size = New System.Drawing.Size(153, 23)
        Me.btnInstall.TabIndex = 17
        Me.btnInstall.Text = "Install"
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'chkConfirm
        '
        Me.chkConfirm.AutoSize = True
        Me.chkConfirm.Checked = True
        Me.chkConfirm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConfirm.Location = New System.Drawing.Point(15, 125)
        Me.chkConfirm.Name = "chkConfirm"
        Me.chkConfirm.Size = New System.Drawing.Size(177, 17)
        Me.chkConfirm.TabIndex = 23
        Me.chkConfirm.Text = "Prompt for Uninstall confirmation"
        Me.chkConfirm.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(12, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(380, 30)
        Me.label1.TabIndex = 18
        Me.label1.Text = "Install: Browse for an assembly file to install into the .NET Native Image Cache." & _
            " "
        '
        'columnCulture
        '
        Me.columnCulture.Text = "Culture"
        Me.columnCulture.Width = 72
        '
        'btnViewCache
        '
        Me.btnViewCache.Location = New System.Drawing.Point(409, 48)
        Me.btnViewCache.Name = "btnViewCache"
        Me.btnViewCache.Size = New System.Drawing.Size(153, 23)
        Me.btnViewCache.TabIndex = 21
        Me.btnViewCache.Text = "View Native Image Cache"
        Me.btnViewCache.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(12, 89)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(368, 23)
        Me.label5.TabIndex = 20
        Me.label5.Text = "Uninstall: Removes the selected assemblies from the Native Image Cache."
        '
        'btnUninstall
        '
        Me.btnUninstall.Enabled = False
        Me.btnUninstall.Location = New System.Drawing.Point(409, 89)
        Me.btnUninstall.Name = "btnUninstall"
        Me.btnUninstall.Size = New System.Drawing.Size(153, 23)
        Me.btnUninstall.TabIndex = 19
        Me.btnUninstall.Text = "Uninstall"
        Me.btnUninstall.UseVisualStyleBackColor = True
        '
        'columnVersion
        '
        Me.columnVersion.Text = "Version"
        Me.columnVersion.Width = 77
        '
        'columnBaseName
        '
        Me.columnBaseName.Text = "Assembly Name"
        Me.columnBaseName.Width = 209
        '
        'lvNativeImageCache
        '
        Me.lvNativeImageCache.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnBaseName, Me.columnVersion, Me.columnCulture, Me.columnPublicKeyToken})
        Me.lvNativeImageCache.Location = New System.Drawing.Point(15, 191)
        Me.lvNativeImageCache.Name = "lvNativeImageCache"
        Me.lvNativeImageCache.Size = New System.Drawing.Size(604, 233)
        Me.lvNativeImageCache.TabIndex = 22
        Me.lvNativeImageCache.UseCompatibleStateImageBehavior = False
        Me.lvNativeImageCache.View = System.Windows.Forms.View.Details
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 436)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.btnInstall)
        Me.Controls.Add(Me.chkConfirm)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnViewCache)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.btnUninstall)
        Me.Controls.Add(Me.lvNativeImageCache)
        Me.Name = "Form1"
        Me.Text = "Using NGEN Launch Program"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents columnPublicKeyToken As System.Windows.Forms.ColumnHeader
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents btnInstall As System.Windows.Forms.Button
    Private WithEvents chkConfirm As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents columnCulture As System.Windows.Forms.ColumnHeader
    Private WithEvents btnViewCache As System.Windows.Forms.Button
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents btnUninstall As System.Windows.Forms.Button
    Private WithEvents columnVersion As System.Windows.Forms.ColumnHeader
    Private WithEvents columnBaseName As System.Windows.Forms.ColumnHeader
    Private WithEvents lvNativeImageCache As System.Windows.Forms.ListView

End Class
