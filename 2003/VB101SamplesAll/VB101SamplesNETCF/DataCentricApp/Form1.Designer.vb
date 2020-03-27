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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.LoadButton = New System.Windows.Forms.Button
        Me.PrevNextButton = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.FilesMenuItem = New System.Windows.Forms.MenuItem
        Me.DeleteMenuItem = New System.Windows.Forms.MenuItem
        Me.CreateMenuItem = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.Text = "First"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 20)
        Me.Label2.Text = "Last"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 20)
        Me.Label3.Text = "Phone"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(54, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(122, 21)
        Me.TextBox1.TabIndex = 3
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(54, 59)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(122, 21)
        Me.TextBox2.TabIndex = 4
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(54, 106)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(122, 21)
        Me.TextBox3.TabIndex = 5
        '
        'LoadButton
        '
        Me.LoadButton.Location = New System.Drawing.Point(3, 143)
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Size = New System.Drawing.Size(72, 20)
        Me.LoadButton.TabIndex = 6
        Me.LoadButton.Text = "Load"
        '
        'PrevNextButton
        '
        Me.PrevNextButton.Location = New System.Drawing.Point(81, 143)
        Me.PrevNextButton.Name = "PrevNextButton"
        Me.PrevNextButton.Size = New System.Drawing.Size(72, 20)
        Me.PrevNextButton.TabIndex = 10
        Me.PrevNextButton.Text = "Next"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 246)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(240, 22)
        Me.StatusBar1.Text = "StatusBar1"
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
        Me.DeleteMenuItem.Text = "Delete Sample Xml File"
        '
        'CreateMenuItem
        '
        Me.CreateMenuItem.Text = "Create Sample Xml File"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.PrevNextButton)
        Me.Controls.Add(Me.LoadButton)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents LoadButton As System.Windows.Forms.Button
    Friend WithEvents PrevNextButton As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents FilesMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents DeleteMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents CreateMenuItem As System.Windows.Forms.MenuItem

End Class
