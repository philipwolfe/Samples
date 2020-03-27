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
        Me.FileDocumentList = New Microsoft.WindowsCE.Forms.DocumentList
        Me.ActionStatusBar = New System.Windows.Forms.StatusBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.FilterComboBox = New System.Windows.Forms.ComboBox
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.FilesMenuItem = New System.Windows.Forms.MenuItem
        Me.DeleteMenuItem = New System.Windows.Forms.MenuItem
        Me.CreateMenuItem = New System.Windows.Forms.MenuItem
        Me.FileContentsTextBox = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FileDocumentList
        '
        Me.FileDocumentList.Dock = System.Windows.Forms.DockStyle.Top
        Me.FileDocumentList.Location = New System.Drawing.Point(0, 25)
        Me.FileDocumentList.Name = "FileDocumentList"
        Me.FileDocumentList.Size = New System.Drawing.Size(240, 111)
        Me.FileDocumentList.TabIndex = 5
        '
        'ActionStatusBar
        '
        Me.ActionStatusBar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.ActionStatusBar.Location = New System.Drawing.Point(0, 134)
        Me.ActionStatusBar.Name = "ActionStatusBar"
        Me.ActionStatusBar.Size = New System.Drawing.Size(240, 20)
        Me.ActionStatusBar.Text = "Status"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 19)
        Me.Label1.Text = "Filter:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.FilterComboBox)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(240, 25)
        '
        'FilterComboBox
        '
        Me.FilterComboBox.Location = New System.Drawing.Point(48, 1)
        Me.FilterComboBox.Name = "FilterComboBox"
        Me.FilterComboBox.Size = New System.Drawing.Size(192, 22)
        Me.FilterComboBox.TabIndex = 3
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.FilesMenuItem)
        '
        'FilesMenuItem
        '
        Me.FilesMenuItem.MenuItems.Add(Me.DeleteMenuItem)
        Me.FilesMenuItem.MenuItems.Add(Me.CreateMenuItem)
        Me.FilesMenuItem.Text = "Files"
        '
        'DeleteMenuItem
        '
        Me.DeleteMenuItem.Text = "Delete Sample Files"
        '
        'CreateMenuItem
        '
        Me.CreateMenuItem.Text = "Create Sample Files"
        '
        'FileContentsTextBox
        '
        Me.FileContentsTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileContentsTextBox.Enabled = False
        Me.FileContentsTextBox.Location = New System.Drawing.Point(0, 0)
        Me.FileContentsTextBox.Multiline = True
        Me.FileContentsTextBox.Name = "FileContentsTextBox"
        Me.FileContentsTextBox.Size = New System.Drawing.Size(240, 114)
        Me.FileContentsTextBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FileContentsTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 154)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 114)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.ActionStatusBar)
        Me.Controls.Add(Me.FileDocumentList)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FileDocumentList As Microsoft.WindowsCE.Forms.DocumentList
    Friend WithEvents ActionStatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents FilterComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents FilesMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents DeleteMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents CreateMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileContentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
