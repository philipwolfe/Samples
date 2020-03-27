Partial Public Class RssNavActionsPane
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
        Me.blogEntryCountLabel = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.nextEntryButton = New System.Windows.Forms.Button
        Me.previousEntryButton = New System.Windows.Forms.Button
        Me.goButton = New System.Windows.Forms.Button
        Me.uRLTextBox = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'blogEntryCountLabel
        '
        Me.blogEntryCountLabel.AutoSize = True
        Me.blogEntryCountLabel.Location = New System.Drawing.Point(64, 74)
        Me.blogEntryCountLabel.Name = "blogEntryCountLabel"
        Me.blogEntryCountLabel.Size = New System.Drawing.Size(0, 0)
        Me.blogEntryCountLabel.TabIndex = 13
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(4, 74)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(54, 13)
        Me.label2.TabIndex = 12
        Me.label2.Text = "Blog Entry:"
        '
        'nextEntryButton
        '
        Me.nextEntryButton.Enabled = False
        Me.nextEntryButton.Location = New System.Drawing.Point(95, 93)
        Me.nextEntryButton.Name = "nextEntryButton"
        Me.nextEntryButton.Size = New System.Drawing.Size(75, 23)
        Me.nextEntryButton.TabIndex = 11
        Me.nextEntryButton.Text = "Next >>"
        '
        'previousEntryButton
        '
        Me.previousEntryButton.Enabled = False
        Me.previousEntryButton.Location = New System.Drawing.Point(14, 93)
        Me.previousEntryButton.Name = "previousEntryButton"
        Me.previousEntryButton.Size = New System.Drawing.Size(75, 23)
        Me.previousEntryButton.TabIndex = 10
        Me.previousEntryButton.Text = "<< Previous"
        '
        'goButton
        '
        Me.goButton.Location = New System.Drawing.Point(145, 37)
        Me.goButton.Name = "goButton"
        Me.goButton.Size = New System.Drawing.Size(38, 23)
        Me.goButton.TabIndex = 9
        Me.goButton.Text = "Go!"
        '
        'uRLTextBox
        '
        Me.uRLTextBox.Location = New System.Drawing.Point(4, 39)
        Me.uRLTextBox.Name = "uRLTextBox"
        Me.uRLTextBox.Size = New System.Drawing.Size(136, 20)
        Me.uRLTextBox.TabIndex = 8
        Me.uRLTextBox.Text = "http://msdn.microsoft.com/office/rss.xml"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(5, 23)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(52, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Blog URL:"
        '
        'RssNavActionsPane
        '
        Me.Controls.Add(Me.blogEntryCountLabel)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.nextEntryButton)
        Me.Controls.Add(Me.previousEntryButton)
        Me.Controls.Add(Me.goButton)
        Me.Controls.Add(Me.uRLTextBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "RssNavActionsPane"
        Me.Size = New System.Drawing.Size(186, 138)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents blogEntryCountLabel As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents nextEntryButton As System.Windows.Forms.Button
    Friend WithEvents previousEntryButton As System.Windows.Forms.Button
    Friend WithEvents goButton As System.Windows.Forms.Button
    Friend WithEvents uRLTextBox As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label

End Class
