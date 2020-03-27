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
    private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim PrevButton As System.Windows.Forms.Button
        Dim SaveButton As System.Windows.Forms.Button
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.ContactDataGrid = New System.Windows.Forms.DataGrid
        Me.FirstTextBox = New System.Windows.Forms.TextBox
        Me.LastTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.AddButton = New System.Windows.Forms.Button
        Me.DeleteButton = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.NextButton = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.PhoneTextBox = New System.Windows.Forms.TextBox
        PrevButton = New System.Windows.Forms.Button
        SaveButton = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrevButton
        '
        PrevButton.Location = New System.Drawing.Point(4, 3)
        PrevButton.Name = "PrevButton"
        PrevButton.Size = New System.Drawing.Size(72, 20)
        PrevButton.TabIndex = 7
        PrevButton.Text = "<<"
        AddHandler PrevButton.Click, AddressOf Me.PrevButton_Click
        '
        'SaveButton
        '
        SaveButton.Location = New System.Drawing.Point(28, 95)
        SaveButton.Name = "SaveButton"
        SaveButton.Size = New System.Drawing.Size(192, 20)
        SaveButton.TabIndex = 6
        SaveButton.Text = "Save Changes to Database"
        AddHandler SaveButton.Click, AddressOf Me.SaveButton_Click
        '
        'ContactDataGrid
        '
        Me.ContactDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ContactDataGrid.Location = New System.Drawing.Point(0, 151)
        Me.ContactDataGrid.Name = "ContactDataGrid"
        Me.ContactDataGrid.Size = New System.Drawing.Size(240, 117)
        Me.ContactDataGrid.TabIndex = 0
        '
        'FirstTextBox
        '
        Me.FirstTextBox.Location = New System.Drawing.Point(42, 10)
        Me.FirstTextBox.Name = "FirstTextBox"
        Me.FirstTextBox.Size = New System.Drawing.Size(75, 21)
        Me.FirstTextBox.TabIndex = 1
        '
        'LastTextBox
        '
        Me.LastTextBox.Location = New System.Drawing.Point(158, 10)
        Me.LastTextBox.Name = "LastTextBox"
        Me.LastTextBox.Size = New System.Drawing.Size(79, 21)
        Me.LastTextBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 20)
        Me.Label1.Text = "First"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(123, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 20)
        Me.Label2.Text = "Last"
        '
        'AddButton
        '
        Me.AddButton.Location = New System.Drawing.Point(27, 59)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(72, 20)
        Me.AddButton.TabIndex = 4
        Me.AddButton.Text = "Add"
        '
        'DeleteButton
        '
        Me.DeleteButton.Location = New System.Drawing.Point(148, 59)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(72, 20)
        Me.DeleteButton.TabIndex = 5
        Me.DeleteButton.Text = "Delete"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.NextButton)
        Me.Panel1.Controls.Add(PrevButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 124)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 27)
        '
        'NextButton
        '
        Me.NextButton.Location = New System.Drawing.Point(165, 3)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(72, 20)
        Me.NextButton.TabIndex = 9
        Me.NextButton.Text = ">>"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 20)
        Me.Label3.Text = "Phone"
        '
        'PhoneTextBox
        '
        Me.PhoneTextBox.Location = New System.Drawing.Point(42, 32)
        Me.PhoneTextBox.Name = "PhoneTextBox"
        Me.PhoneTextBox.Size = New System.Drawing.Size(195, 21)
        Me.PhoneTextBox.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(SaveButton)
        Me.Controls.Add(Me.PhoneTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LastTextBox)
        Me.Controls.Add(Me.FirstTextBox)
        Me.Controls.Add(Me.ContactDataGrid)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContactDataGrid As System.Windows.Forms.DataGrid
    Friend WithEvents FirstTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LastTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox

End Class
