<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProductUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.itemNameTextbox = New System.Windows.Forms.TextBox
        Me.insertItemButton = New System.Windows.Forms.Button
        Me.lookupButton = New System.Windows.Forms.Button
        Me.itemNumberTextBox = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'itemNameTextbox
        '
        Me.itemNameTextbox.Location = New System.Drawing.Point(43, 60)
        Me.itemNameTextbox.Name = "itemNameTextbox"
        Me.itemNameTextbox.ReadOnly = True
        Me.itemNameTextbox.Size = New System.Drawing.Size(118, 20)
        Me.itemNameTextbox.TabIndex = 10
        '
        'insertItemButton
        '
        Me.insertItemButton.Enabled = False
        Me.insertItemButton.Location = New System.Drawing.Point(43, 86)
        Me.insertItemButton.Name = "insertItemButton"
        Me.insertItemButton.Size = New System.Drawing.Size(118, 23)
        Me.insertItemButton.TabIndex = 9
        Me.insertItemButton.Text = "Insert Item"
        Me.insertItemButton.UseVisualStyleBackColor = True
        '
        'lookupButton
        '
        Me.lookupButton.Enabled = False
        Me.lookupButton.Location = New System.Drawing.Point(43, 31)
        Me.lookupButton.Name = "lookupButton"
        Me.lookupButton.Size = New System.Drawing.Size(118, 23)
        Me.lookupButton.TabIndex = 8
        Me.lookupButton.Text = "Lookup Item"
        Me.lookupButton.UseVisualStyleBackColor = True
        '
        'itemNumberTextBox
        '
        Me.itemNumberTextBox.Location = New System.Drawing.Point(43, 3)
        Me.itemNumberTextBox.Name = "itemNumberTextBox"
        Me.itemNumberTextBox.Size = New System.Drawing.Size(118, 20)
        Me.itemNumberTextBox.TabIndex = 7
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(-1, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(37, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Item #"
        '
        'AddProductUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.itemNameTextbox)
        Me.Controls.Add(Me.insertItemButton)
        Me.Controls.Add(Me.lookupButton)
        Me.Controls.Add(Me.itemNumberTextBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "AddProductUserControl"
        Me.Size = New System.Drawing.Size(169, 110)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents itemNameTextbox As System.Windows.Forms.TextBox
    Private WithEvents insertItemButton As System.Windows.Forms.Button
    Private WithEvents lookupButton As System.Windows.Forms.Button
    Private WithEvents itemNumberTextBox As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
