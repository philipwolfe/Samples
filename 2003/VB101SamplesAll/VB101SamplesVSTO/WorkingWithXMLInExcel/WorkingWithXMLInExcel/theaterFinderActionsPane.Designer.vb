Partial Public Class theaterFinderActionsPane
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
        Me.label3 = New System.Windows.Forms.Label
        Me.theatersListBox = New System.Windows.Forms.ListBox
        Me.zipCodeTextBox = New System.Windows.Forms.TextBox
        Me.findTheatersButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.radiusComboBox = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(16, 111)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(171, 13)
        Me.label3.TabIndex = 13
        Me.label3.Text = "Select theater to view movie times:"
        '
        'theatersListBox
        '
        Me.theatersListBox.FormattingEnabled = True
        Me.theatersListBox.Location = New System.Drawing.Point(16, 136)
        Me.theatersListBox.Name = "theatersListBox"
        Me.theatersListBox.Size = New System.Drawing.Size(166, 82)
        Me.theatersListBox.TabIndex = 12
        '
        'zipCodeTextBox
        '
        Me.zipCodeTextBox.Location = New System.Drawing.Point(70, 23)
        Me.zipCodeTextBox.Name = "zipCodeTextBox"
        Me.zipCodeTextBox.Size = New System.Drawing.Size(69, 20)
        Me.zipCodeTextBox.TabIndex = 10
        Me.zipCodeTextBox.Text = "98052"
        '
        'findTheatersButton
        '
        Me.findTheatersButton.Location = New System.Drawing.Point(17, 76)
        Me.findTheatersButton.Name = "findTheatersButton"
        Me.findTheatersButton.Size = New System.Drawing.Size(93, 23)
        Me.findTheatersButton.TabIndex = 9
        Me.findTheatersButton.Text = "Find Theaters!"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(16, 49)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(43, 13)
        Me.label2.TabIndex = 8
        Me.label2.Text = "Radius:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(15, 23)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(52, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Zip code:"
        '
        'radiusComboBox
        '
        Me.radiusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.radiusComboBox.FormattingEnabled = True
        Me.radiusComboBox.Items.AddRange(New Object() {"15", "20", "25", "30", "35", "40", "45", "50"})
        Me.radiusComboBox.Location = New System.Drawing.Point(70, 49)
        Me.radiusComboBox.Name = "radiusComboBox"
        Me.radiusComboBox.Size = New System.Drawing.Size(69, 21)
        Me.radiusComboBox.TabIndex = 14
        '
        'theaterFinderActionsPane
        '
        Me.Controls.Add(Me.radiusComboBox)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.theatersListBox)
        Me.Controls.Add(Me.zipCodeTextBox)
        Me.Controls.Add(Me.findTheatersButton)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "theaterFinderActionsPane"
        Me.Size = New System.Drawing.Size(198, 240)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents theatersListBox As System.Windows.Forms.ListBox
    Friend WithEvents zipCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents findTheatersButton As System.Windows.Forms.Button
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents radiusComboBox As System.Windows.Forms.ComboBox

End Class
