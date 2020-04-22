Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

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
        Me.availabilityLabel = New System.Windows.Forms.Label
        Me.usedPriceLabel = New System.Windows.Forms.Label
        Me.itemPicture = New System.Windows.Forms.PictureBox
        Me.searchResults = New System.Windows.Forms.ListBox
        Me.listPriceLabel = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.dvdOption = New System.Windows.Forms.RadioButton
        Me.musicOption = New System.Windows.Forms.RadioButton
        Me.booksOption = New System.Windows.Forms.RadioButton
        Me.goButton = New System.Windows.Forms.Button
        Me.searchText = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        CType(Me.itemPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'availabilityLabel
        '
        Me.availabilityLabel.AutoSize = True
        Me.availabilityLabel.Location = New System.Drawing.Point(12, 235)
        Me.availabilityLabel.Name = "availabilityLabel"
        Me.availabilityLabel.Size = New System.Drawing.Size(58, 14)
        Me.availabilityLabel.TabIndex = 24
        Me.availabilityLabel.Text = "Availability"
        Me.availabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'usedPriceLabel
        '
        Me.usedPriceLabel.AutoSize = True
        Me.usedPriceLabel.Location = New System.Drawing.Point(12, 214)
        Me.usedPriceLabel.Name = "usedPriceLabel"
        Me.usedPriceLabel.Size = New System.Drawing.Size(61, 14)
        Me.usedPriceLabel.TabIndex = 23
        Me.usedPriceLabel.Text = "Used price:"
        Me.usedPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'itemPicture
        '
        Me.itemPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.itemPicture.Location = New System.Drawing.Point(279, 193)
        Me.itemPicture.Name = "itemPicture"
        Me.itemPicture.Size = New System.Drawing.Size(150, 189)
        Me.itemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.itemPicture.TabIndex = 22
        Me.itemPicture.TabStop = False
        Me.itemPicture.UseWaitCursor = True
        '
        'searchResults
        '
        Me.searchResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchResults.FormattingEnabled = True
        Me.searchResults.Location = New System.Drawing.Point(12, 104)
        Me.searchResults.Name = "searchResults"
        Me.searchResults.Size = New System.Drawing.Size(417, 82)
        Me.searchResults.TabIndex = 21
        '
        'listPriceLabel
        '
        Me.listPriceLabel.AutoSize = True
        Me.listPriceLabel.Location = New System.Drawing.Point(12, 193)
        Me.listPriceLabel.Name = "listPriceLabel"
        Me.listPriceLabel.Size = New System.Drawing.Size(53, 14)
        Me.listPriceLabel.TabIndex = 20
        Me.listPriceLabel.Text = "List price:"
        Me.listPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 83)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(81, 14)
        Me.label2.TabIndex = 19
        Me.label2.Text = "Search Results"
        '
        'dvdOption
        '
        Me.dvdOption.AutoSize = True
        Me.dvdOption.Location = New System.Drawing.Point(279, 48)
        Me.dvdOption.Name = "dvdOption"
        Me.dvdOption.Size = New System.Drawing.Size(49, 17)
        Me.dvdOption.TabIndex = 18
        Me.dvdOption.Tag = "dvd"
        Me.dvdOption.Text = "DVDs"
        '
        'musicOption
        '
        Me.musicOption.AutoSize = True
        Me.musicOption.Location = New System.Drawing.Point(170, 48)
        Me.musicOption.Name = "musicOption"
        Me.musicOption.Size = New System.Drawing.Size(49, 17)
        Me.musicOption.TabIndex = 17
        Me.musicOption.Tag = "music"
        Me.musicOption.Text = "Music"
        '
        'booksOption
        '
        Me.booksOption.AutoSize = True
        Me.booksOption.Checked = True
        Me.booksOption.Location = New System.Drawing.Point(59, 48)
        Me.booksOption.Name = "booksOption"
        Me.booksOption.Size = New System.Drawing.Size(51, 17)
        Me.booksOption.TabIndex = 16
        Me.booksOption.TabStop = True
        Me.booksOption.Tag = "books"
        Me.booksOption.Text = "Books"
        '
        'goButton
        '
        Me.goButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.goButton.Location = New System.Drawing.Point(355, 17)
        Me.goButton.Name = "goButton"
        Me.goButton.TabIndex = 15
        Me.goButton.Text = "Go!"
        '
        'searchText
        '
        Me.searchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchText.AutoSize = False
        Me.searchText.Location = New System.Drawing.Point(59, 16)
        Me.searchText.Multiline = True
        Me.searchText.Name = "searchText"
        Me.searchText.Size = New System.Drawing.Size(271, 22)
        Me.searchText.TabIndex = 14
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 19)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 14)
        Me.label1.TabIndex = 13
        Me.label1.Text = "Search"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(442, 399)
        Me.Controls.Add(Me.availabilityLabel)
        Me.Controls.Add(Me.usedPriceLabel)
        Me.Controls.Add(Me.itemPicture)
        Me.Controls.Add(Me.searchResults)
        Me.Controls.Add(Me.listPriceLabel)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.dvdOption)
        Me.Controls.Add(Me.musicOption)
        Me.Controls.Add(Me.booksOption)
        Me.Controls.Add(Me.goButton)
        Me.Controls.Add(Me.searchText)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.itemPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents availabilityLabel As System.Windows.Forms.Label
    Private WithEvents usedPriceLabel As System.Windows.Forms.Label
    Private WithEvents itemPicture As System.Windows.Forms.PictureBox
    Private WithEvents searchResults As System.Windows.Forms.ListBox
    Private WithEvents listPriceLabel As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents dvdOption As System.Windows.Forms.RadioButton
    Private WithEvents musicOption As System.Windows.Forms.RadioButton
    Private WithEvents booksOption As System.Windows.Forms.RadioButton
    Private WithEvents goButton As System.Windows.Forms.Button
    Private WithEvents searchText As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
