<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
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
    private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_CURRENT_USER")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("SOFTWARE")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("RegistrySample")
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.Label1 = New System.Windows.Forms.Label
        Me.KeyTextBox = New System.Windows.Forms.TextBox
        Me.ValueTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.RegTreeView = New System.Windows.Forms.TreeView
        Me.CreateButton = New System.Windows.Forms.Button
        Me.DeleteButton = New System.Windows.Forms.Button
        Me.UpdateButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 20)
        Me.Label1.Text = "Key"
        '
        'KeyTextBox
        '
        Me.KeyTextBox.Location = New System.Drawing.Point(38, 171)
        Me.KeyTextBox.Name = "KeyTextBox"
        Me.KeyTextBox.Size = New System.Drawing.Size(202, 21)
        Me.KeyTextBox.TabIndex = 2
        '
        'ValueTextBox
        '
        Me.ValueTextBox.Location = New System.Drawing.Point(118, 218)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.Size = New System.Drawing.Size(122, 21)
        Me.ValueTextBox.TabIndex = 4
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(0, 218)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(112, 21)
        Me.NameTextBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 19)
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(118, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 19)
        Me.Label3.Text = "Value"
        '
        'RegTreeView
        '
        Me.RegTreeView.Dock = System.Windows.Forms.DockStyle.Top
        Me.RegTreeView.Location = New System.Drawing.Point(0, 0)
        Me.RegTreeView.Name = "RegTreeView"
        TreeNode3.Text = "RegistrySample"
        TreeNode2.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3})
        TreeNode2.Text = "SOFTWARE"
        TreeNode1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        TreeNode1.Text = "HKEY_CURRENT_USER"
        Me.RegTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.RegTreeView.Size = New System.Drawing.Size(240, 165)
        Me.RegTreeView.TabIndex = 1
        '
        'CreateButton
        '
        Me.CreateButton.Location = New System.Drawing.Point(0, 245)
        Me.CreateButton.Name = "CreateButton"
        Me.CreateButton.Size = New System.Drawing.Size(72, 20)
        Me.CreateButton.TabIndex = 6
        Me.CreateButton.Text = "Create"
        '
        'DeleteButton
        '
        Me.DeleteButton.Location = New System.Drawing.Point(78, 245)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(84, 20)
        Me.DeleteButton.TabIndex = 7
        Me.DeleteButton.Text = "Delete"
        '
        'UpdateButton
        '
        Me.UpdateButton.Location = New System.Drawing.Point(168, 245)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(72, 20)
        Me.UpdateButton.TabIndex = 8
        Me.UpdateButton.Text = "Update"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.UpdateButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.CreateButton)
        Me.Controls.Add(Me.RegTreeView)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.ValueTextBox)
        Me.Controls.Add(Me.KeyTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KeyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RegTreeView As System.Windows.Forms.TreeView
    Friend WithEvents CreateButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents UpdateButton As System.Windows.Forms.Button

End Class
