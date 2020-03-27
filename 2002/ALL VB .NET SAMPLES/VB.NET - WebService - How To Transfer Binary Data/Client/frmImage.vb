'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmImage
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents picImage As System.Windows.Forms.PictureBox
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
	Friend WithEvents mnuView As System.Windows.Forms.MenuItem
	Friend WithEvents mnuZoom50 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuZoom100 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuZoom200 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuStretch As System.Windows.Forms.MenuItem
	Friend WithEvents sdlgImage As System.Windows.Forms.SaveFileDialog
	Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmImage))
		Me.picImage = New System.Windows.Forms.PictureBox()
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuClose = New System.Windows.Forms.MenuItem()
		Me.mnuView = New System.Windows.Forms.MenuItem()
		Me.mnuZoom50 = New System.Windows.Forms.MenuItem()
		Me.mnuZoom100 = New System.Windows.Forms.MenuItem()
		Me.mnuZoom200 = New System.Windows.Forms.MenuItem()
		Me.mnuStretch = New System.Windows.Forms.MenuItem()
		Me.sdlgImage = New System.Windows.Forms.SaveFileDialog()
		Me.mnuSave = New System.Windows.Forms.MenuItem()
		Me.SuspendLayout()
		'
		'picImage
		'
		Me.picImage.Dock = System.Windows.Forms.DockStyle.Fill
		Me.picImage.Name = "picImage"
		Me.picImage.Size = New System.Drawing.Size(224, 197)
		Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picImage.TabIndex = 0
		Me.picImage.TabStop = False
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuView})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSave, Me.mnuClose})
		Me.mnuFile.Text = "&File"
		'
		'mnuClose
		'
		Me.mnuClose.Index = 1
		Me.mnuClose.Text = "&Close"
		'
		'mnuView
		'
		Me.mnuView.Index = 1
		Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuZoom50, Me.mnuZoom100, Me.mnuZoom200, Me.mnuStretch})
		Me.mnuView.Text = "&View"
		'
		'mnuZoom50
		'
		Me.mnuZoom50.Index = 0
		Me.mnuZoom50.RadioCheck = True
		Me.mnuZoom50.Text = "50%"
		'
		'mnuZoom100
		'
		Me.mnuZoom100.Index = 1
		Me.mnuZoom100.RadioCheck = True
		Me.mnuZoom100.Text = "100%"
		'
		'mnuZoom200
		'
		Me.mnuZoom200.Index = 2
		Me.mnuZoom200.RadioCheck = True
		Me.mnuZoom200.Text = "200%"
		'
		'mnuStretch
		'
		Me.mnuStretch.Index = 3
		Me.mnuStretch.RadioCheck = True
		Me.mnuStretch.Text = "Stretch"
		'
		'sdlgImage
		'
		Me.sdlgImage.FileName = "doc1"
		Me.sdlgImage.Title = "Save Image"
		'
		'mnuSave
		'
		Me.mnuSave.Index = 0
		Me.mnuSave.Text = "&Save As..."
		'
		'frmImage
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(224, 197)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.picImage})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Menu = Me.mnuMain
		Me.Name = "frmImage"
		Me.Text = "Image"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private ClientSizeOriginal As Size

	Public WriteOnly Property Image() As Image
		' Public write-only property
		' allows parent form to set the 
		' image for this form without knowing
		' anything about the layout of the form.
		Set(ByVal Value As Image)
			Try
				picImage.Image = Value
			Catch exp As Exception
				MessageBox.Show(exp.Message, Me.Text)
			End Try
		End Set
	End Property

	Private Sub frmImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Store away the original client size, for later use.
		ClientSizeOriginal = Me.ClientSize
	End Sub

	Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
		Me.Close()
	End Sub

	Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
		' Save the image in one of the available image formats.
		Try
			With sdlgImage
				.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|GIF (*.gif)|*.gif|TIFF (*.tif, *.tiff)|*.tif;*.tiff|PNG (*.png)|*.png"
				.AddExtension = True
				.OverwritePrompt = True
				.CheckPathExists = True
				.ValidateNames = True
				.Title = "Save Image"
				If .ShowDialog() = DialogResult.OK Then
					Dim bmp As New Bitmap(picImage.Image)
					Dim fmt As Imaging.ImageFormat
					Select Case .FilterIndex
						Case 1
							fmt = Imaging.ImageFormat.Bmp
						Case 2
							fmt = Imaging.ImageFormat.Jpeg
						Case 3
							fmt = Imaging.ImageFormat.Gif
						Case 4
							fmt = Imaging.ImageFormat.Tiff
						Case 5
							fmt = Imaging.ImageFormat.Png
					End Select
					bmp.Save(.FileName, fmt)
				End If
			End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, "Saving Image")
		End Try
	End Sub

	Private Sub mnuStretch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStretch.Click
		Me.FormBorderStyle = FormBorderStyle.Sizable
	End Sub

	Private Sub mnuZoom50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuZoom50.Click
		SetClientSize(50)
	End Sub

	Private Sub mnuZoom100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuZoom100.Click
		SetClientSize(100)
	End Sub

	Private Sub mnuZoom200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuZoom200.Click
		SetClientSize(200)
	End Sub

	Private Sub HandleZoom(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuZoom100.Click, mnuZoom200.Click, mnuZoom50.Click, mnuStretch.Click
		' Handle the checks on the menu items.

		' Turn off all checks.
		mnuZoom50.Checked = False
		mnuZoom100.Checked = False
		mnuZoom200.Checked = False
		mnuStretch.Checked = False

		' Turn on the one check that's required.
		CType(sender, MenuItem).Checked = True
	End Sub

	Private Sub SetClientSize(ByVal intPercent As Integer)
		' Given a percentage (50, 100, or 200, in this example)
		' set the size of the form based on its original size.

		Me.FormBorderStyle = FormBorderStyle.FixedSingle
		Me.ClientSize = New Size(CInt(intPercent / 100 * ClientSizeOriginal.Width), CInt(intPercent / 100 * ClientSizeOriginal.Height))
	End Sub

End Class
