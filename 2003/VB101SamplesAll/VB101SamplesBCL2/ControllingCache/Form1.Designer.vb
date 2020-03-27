<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.UrlTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PolicyComboBox = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GoButton = New System.Windows.Forms.Button
        Me.PolicyDescTextBox = New System.Windows.Forms.TextBox
        Me.StatusLabel = New System.Windows.Forms.Label
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'UrlTextBox
        '
        Me.UrlTextBox.Location = New System.Drawing.Point(89, 6)
        Me.UrlTextBox.Name = "UrlTextBox"
        Me.UrlTextBox.Size = New System.Drawing.Size(660, 20)
        Me.UrlTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "URL:"
        '
        'PolicyComboBox
        '
        Me.PolicyComboBox.DropDownHeight = 130
        Me.PolicyComboBox.FormattingEnabled = True
        Me.PolicyComboBox.IntegralHeight = False
        Me.PolicyComboBox.Items.AddRange(New Object() {"BypassCache", "CacheIfAvailable", "CacheOnly", "CacheOrNextCacheOnly", "Default", "NoCacheNoStore", "Refresh", "Reload", "Revalidate"})
        Me.PolicyComboBox.Location = New System.Drawing.Point(89, 35)
        Me.PolicyComboBox.Name = "PolicyComboBox"
        Me.PolicyComboBox.Size = New System.Drawing.Size(141, 21)
        Me.PolicyComboBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cache Policy:"
        '
        'GoButton
        '
        Me.GoButton.Location = New System.Drawing.Point(755, 4)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(30, 23)
        Me.GoButton.TabIndex = 2
        Me.GoButton.Text = "GO"
        Me.GoButton.UseVisualStyleBackColor = True
        '
        'PolicyDescTextBox
        '
        Me.PolicyDescTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.PolicyDescTextBox.Location = New System.Drawing.Point(236, 35)
        Me.PolicyDescTextBox.Multiline = True
        Me.PolicyDescTextBox.Name = "PolicyDescTextBox"
        Me.PolicyDescTextBox.ReadOnly = True
        Me.PolicyDescTextBox.Size = New System.Drawing.Size(549, 56)
        Me.PolicyDescTextBox.TabIndex = 4
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(48, 68)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(37, 13)
        Me.StatusLabel.TabIndex = 7
        Me.StatusLabel.Text = "Status"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(5, 97)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(780, 307)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Status:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 416)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.PolicyDescTextBox)
        Me.Controls.Add(Me.GoButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PolicyComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UrlTextBox)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UrlTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PolicyComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GoButton As System.Windows.Forms.Button
    Friend WithEvents PolicyDescTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
