<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
    Private closeButton As System.Windows.Forms.Button
    Public contentTextBox As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.contentTextBox = New System.Windows.Forms.TextBox
        Me.closeButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        ' 
        ' contentTextBox
        ' 
        Me.contentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contentTextBox.Location = New System.Drawing.Point(15, 15)
        Me.contentTextBox.Multiline = True
        Me.contentTextBox.Name = "contentTextBox"
        Me.contentTextBox.ReadOnly = True
        Me.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.contentTextBox.Size = New System.Drawing.Size(431, 208)
        Me.contentTextBox.TabIndex = 1
        ' 
        ' closeButton
        ' 
        Me.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.closeButton.Location = New System.Drawing.Point(194, 238)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 0
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        AddHandler closeButton.Click, AddressOf Me.closeButton_Click
        ' 
        ' Form2
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 273)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.contentTextBox)
        Me.Name = "Form2"
        Me.Padding = New System.Windows.Forms.Padding(15, 15, 15, 50)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
