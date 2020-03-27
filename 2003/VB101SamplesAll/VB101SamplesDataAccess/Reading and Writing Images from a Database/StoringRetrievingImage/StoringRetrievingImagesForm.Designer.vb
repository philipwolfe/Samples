<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class StoringRetrievingImagesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoringRetrievingImagesForm))
        Me.enterPhotographyNameLabel = New System.Windows.Forms.Label
        Me.photographNameTextBoxTextBox = New System.Windows.Forms.TextBox
        Me.nextLinkLabel = New System.Windows.Forms.LinkLabel
        Me.insertImageButton = New System.Windows.Forms.Button
        Me.browseImageButton = New System.Windows.Forms.Button
        Me.imageNameTextBox = New System.Windows.Forms.TextBox
        Me.orLabel = New System.Windows.Forms.Label
        Me.getCategoryImagesLabel = New System.Windows.Forms.Label
        Me.getImagesButton = New System.Windows.Forms.Button
        Me.addNewImagesTextLabel = New System.Windows.Forms.Label
        Me.chooseCategoryLabel = New System.Windows.Forms.Label
        Me.categoriesComboBox = New System.Windows.Forms.ComboBox
        Me.browseImageOpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.photographNameLabel = New System.Windows.Forms.Label
        Me.photographPictureBox = New System.Windows.Forms.PictureBox
        Me.descriptionGroupBox = New System.Windows.Forms.GroupBox
        Me.previousLinkLabel = New System.Windows.Forms.LinkLabel
        Me.descriptionLine1Label = New System.Windows.Forms.Label
        CType(Me.photographPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.descriptionGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'enterPhotographyNameLabel
        '
        Me.enterPhotographyNameLabel.AutoSize = True
        Me.enterPhotographyNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.enterPhotographyNameLabel.Location = New System.Drawing.Point(34, 327)
        Me.enterPhotographyNameLabel.Name = "enterPhotographyNameLabel"
        Me.enterPhotographyNameLabel.Size = New System.Drawing.Size(164, 13)
        Me.enterPhotographyNameLabel.TabIndex = 45
        Me.enterPhotographyNameLabel.Text = "Enter the Photograph Name:"
        '
        'photographNameTextBoxTextBox
        '
        Me.photographNameTextBoxTextBox.Location = New System.Drawing.Point(32, 344)
        Me.photographNameTextBoxTextBox.Name = "photographNameTextBoxTextBox"
        Me.photographNameTextBoxTextBox.Size = New System.Drawing.Size(287, 20)
        Me.photographNameTextBoxTextBox.TabIndex = 44
        '
        'nextLinkLabel
        '
        Me.nextLinkLabel.AutoSize = True
        Me.nextLinkLabel.Location = New System.Drawing.Point(561, 140)
        Me.nextLinkLabel.Name = "nextLinkLabel"
        Me.nextLinkLabel.Size = New System.Drawing.Size(72, 13)
        Me.nextLinkLabel.TabIndex = 42
        Me.nextLinkLabel.TabStop = True
        Me.nextLinkLabel.Text = "Next Image >>"
        '
        'insertImageButton
        '
        Me.insertImageButton.Location = New System.Drawing.Point(31, 370)
        Me.insertImageButton.Name = "insertImageButton"
        Me.insertImageButton.Size = New System.Drawing.Size(114, 23)
        Me.insertImageButton.TabIndex = 41
        Me.insertImageButton.Text = "Insert New Image"
        '
        'browseImageButton
        '
        Me.browseImageButton.Location = New System.Drawing.Point(204, 304)
        Me.browseImageButton.Name = "browseImageButton"
        Me.browseImageButton.Size = New System.Drawing.Size(115, 23)
        Me.browseImageButton.TabIndex = 40
        Me.browseImageButton.Text = "Browse for Image..."
        '
        'imageNameTextBox
        '
        Me.imageNameTextBox.Location = New System.Drawing.Point(32, 304)
        Me.imageNameTextBox.Name = "imageNameTextBox"
        Me.imageNameTextBox.Size = New System.Drawing.Size(166, 20)
        Me.imageNameTextBox.TabIndex = 39
        '
        'orLabel
        '
        Me.orLabel.AutoSize = True
        Me.orLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.orLabel.Location = New System.Drawing.Point(67, 256)
        Me.orLabel.Name = "orLabel"
        Me.orLabel.Size = New System.Drawing.Size(21, 13)
        Me.orLabel.TabIndex = 38
        Me.orLabel.Text = "OR"
        '
        'getCategoryImagesLabel
        '
        Me.getCategoryImagesLabel.AutoSize = True
        Me.getCategoryImagesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.getCategoryImagesLabel.Location = New System.Drawing.Point(32, 200)
        Me.getCategoryImagesLabel.Name = "getCategoryImagesLabel"
        Me.getCategoryImagesLabel.Size = New System.Drawing.Size(136, 13)
        Me.getCategoryImagesLabel.TabIndex = 37
        Me.getCategoryImagesLabel.Text = "2. Get Category Images"
        '
        'getImagesButton
        '
        Me.getImagesButton.Location = New System.Drawing.Point(44, 220)
        Me.getImagesButton.Name = "getImagesButton"
        Me.getImagesButton.Size = New System.Drawing.Size(75, 23)
        Me.getImagesButton.TabIndex = 36
        Me.getImagesButton.Text = "Get Images"
        '
        'addNewImagesTextLabel
        '
        Me.addNewImagesTextLabel.AutoSize = True
        Me.addNewImagesTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addNewImagesTextLabel.Location = New System.Drawing.Point(33, 277)
        Me.addNewImagesTextLabel.Name = "addNewImagesTextLabel"
        Me.addNewImagesTextLabel.Size = New System.Drawing.Size(118, 13)
        Me.addNewImagesTextLabel.TabIndex = 35
        Me.addNewImagesTextLabel.Text = "3. Add a New Image"
        '
        'chooseCategoryLabel
        '
        Me.chooseCategoryLabel.AutoSize = True
        Me.chooseCategoryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chooseCategoryLabel.Location = New System.Drawing.Point(32, 140)
        Me.chooseCategoryLabel.Name = "chooseCategoryLabel"
        Me.chooseCategoryLabel.Size = New System.Drawing.Size(129, 13)
        Me.chooseCategoryLabel.TabIndex = 34
        Me.chooseCategoryLabel.Text = "1. Choose a Category:"
        '
        'categoriesComboBox
        '
        Me.categoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.categoriesComboBox.FormattingEnabled = True
        Me.categoriesComboBox.Location = New System.Drawing.Point(33, 164)
        Me.categoriesComboBox.Name = "categoriesComboBox"
        Me.categoriesComboBox.Size = New System.Drawing.Size(121, 21)
        Me.categoriesComboBox.TabIndex = 33
        '
        'browseImageOpenFileDialog
        '
        Me.browseImageOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'photographNameLabel
        '
        Me.photographNameLabel.AutoSize = True
        Me.photographNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.photographNameLabel.Location = New System.Drawing.Point(504, 327)
        Me.photographNameLabel.Name = "photographNameLabel"
        Me.photographNameLabel.Size = New System.Drawing.Size(104, 13)
        Me.photographNameLabel.TabIndex = 32
        Me.photographNameLabel.Text = "Photograph Name"
        '
        'photographPictureBox
        '
        Me.photographPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.photographPictureBox.Location = New System.Drawing.Point(416, 164)
        Me.photographPictureBox.Name = "photographPictureBox"
        Me.photographPictureBox.Size = New System.Drawing.Size(217, 151)
        Me.photographPictureBox.TabIndex = 31
        Me.photographPictureBox.TabStop = False
        '
        'descriptionGroupBox
        '
        Me.descriptionGroupBox.Controls.Add(Me.descriptionLine1Label)
        Me.descriptionGroupBox.Location = New System.Drawing.Point(33, 20)
        Me.descriptionGroupBox.Name = "descriptionGroupBox"
        Me.descriptionGroupBox.Size = New System.Drawing.Size(608, 103)
        Me.descriptionGroupBox.TabIndex = 30
        Me.descriptionGroupBox.TabStop = False
        Me.descriptionGroupBox.Text = "Description"
        '
        'previousLinkLabel
        '
        Me.previousLinkLabel.AutoSize = True
        Me.previousLinkLabel.Location = New System.Drawing.Point(417, 140)
        Me.previousLinkLabel.Name = "previousLinkLabel"
        Me.previousLinkLabel.Size = New System.Drawing.Size(91, 13)
        Me.previousLinkLabel.TabIndex = 43
        Me.previousLinkLabel.TabStop = True
        Me.previousLinkLabel.Text = "<< Previous Image"
        '
        'descriptionLine1Label
        '
        Me.descriptionLine1Label.AutoSize = True
        Me.descriptionLine1Label.Location = New System.Drawing.Point(17, 25)
        Me.descriptionLine1Label.Name = "descriptionLine1Label"
        Me.descriptionLine1Label.Size = New System.Drawing.Size(575, 52)
        Me.descriptionLine1Label.TabIndex = 1
        Me.descriptionLine1Label.Text = resources.GetString("descriptionLine1Label.Text")
        '
        'StoringRetrievingImagesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 413)
        Me.Controls.Add(Me.photographNameTextBoxTextBox)
        Me.Controls.Add(Me.nextLinkLabel)
        Me.Controls.Add(Me.insertImageButton)
        Me.Controls.Add(Me.browseImageButton)
        Me.Controls.Add(Me.imageNameTextBox)
        Me.Controls.Add(Me.orLabel)
        Me.Controls.Add(Me.getCategoryImagesLabel)
        Me.Controls.Add(Me.getImagesButton)
        Me.Controls.Add(Me.addNewImagesTextLabel)
        Me.Controls.Add(Me.chooseCategoryLabel)
        Me.Controls.Add(Me.categoriesComboBox)
        Me.Controls.Add(Me.photographNameLabel)
        Me.Controls.Add(Me.photographPictureBox)
        Me.Controls.Add(Me.descriptionGroupBox)
        Me.Controls.Add(Me.previousLinkLabel)
        Me.Controls.Add(Me.enterPhotographyNameLabel)
        Me.Name = "StoringRetrievingImagesForm"
        Me.Text = "Storing and Retrieving Images Example"
        CType(Me.photographPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.descriptionGroupBox.ResumeLayout(False)
        Me.descriptionGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents enterPhotographyNameLabel As System.Windows.Forms.Label
    Friend WithEvents photographNameTextBoxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents nextLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents insertImageButton As System.Windows.Forms.Button
    Friend WithEvents browseImageButton As System.Windows.Forms.Button
    Friend WithEvents imageNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents orLabel As System.Windows.Forms.Label
    Friend WithEvents getCategoryImagesLabel As System.Windows.Forms.Label
    Friend WithEvents getImagesButton As System.Windows.Forms.Button
    Friend WithEvents addNewImagesTextLabel As System.Windows.Forms.Label
    Friend WithEvents chooseCategoryLabel As System.Windows.Forms.Label
    Friend WithEvents categoriesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents browseImageOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents photographNameLabel As System.Windows.Forms.Label
    Friend WithEvents photographPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents descriptionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents previousLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents descriptionLine1Label As System.Windows.Forms.Label

End Class
