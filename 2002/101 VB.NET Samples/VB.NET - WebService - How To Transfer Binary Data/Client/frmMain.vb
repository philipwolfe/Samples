'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.IO

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

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
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPixelFormat As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblImageSize As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents lstImages As System.Windows.Forms.ListBox
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents btnRetrieve As System.Windows.Forms.Button
	Friend WithEvents mnuAboutWS As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.btnRetrieve = New System.Windows.Forms.Button()
		Me.lstImages = New System.Windows.Forms.ListBox()
		Me.lblSize = New System.Windows.Forms.Label()
		Me.picImage = New System.Windows.Forms.PictureBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblPixelFormat = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lblImageSize = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.lblResolution = New System.Windows.Forms.Label()
		Me.btnDisplay = New System.Windows.Forms.Button()
		Me.mnuAboutWS = New System.Windows.Forms.MenuItem()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
		Me.mnuFile.Text = "&File"
		'
		'mnuExit
		'
		Me.mnuExit.Index = 0
		Me.mnuExit.Text = "E&xit"
		'
		'mnuHelp
		'
		Me.mnuHelp.Index = 1
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout, Me.mnuAboutWS})
		Me.mnuHelp.Text = "&Help"
		'
		'mnuAbout
		'
		Me.mnuAbout.Index = 0
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		'
		'btnRetrieve
		'
		Me.btnRetrieve.Location = New System.Drawing.Point(8, 8)
		Me.btnRetrieve.Name = "btnRetrieve"
		Me.btnRetrieve.Size = New System.Drawing.Size(112, 24)
		Me.btnRetrieve.TabIndex = 0
		Me.btnRetrieve.Text = "Retrieve Images"
		'
		'lstImages
		'
		Me.lstImages.Location = New System.Drawing.Point(8, 40)
		Me.lstImages.Name = "lstImages"
		Me.lstImages.Size = New System.Drawing.Size(112, 160)
		Me.lstImages.TabIndex = 1
		'
		'lblSize
		'
		Me.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblSize.Location = New System.Drawing.Point(264, 112)
		Me.lblSize.Name = "lblSize"
		Me.lblSize.Size = New System.Drawing.Size(104, 24)
		Me.lblSize.TabIndex = 2
		Me.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'picImage
		'
		Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.picImage.Location = New System.Drawing.Point(128, 40)
		Me.picImage.Name = "picImage"
		Me.picImage.Size = New System.Drawing.Size(96, 64)
		Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
		Me.picImage.TabIndex = 3
		Me.picImage.TabStop = False
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(128, 112)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(136, 23)
		Me.Label1.TabIndex = 4
		Me.Label1.Text = "Size (bytes)"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(128, 136)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(136, 23)
		Me.Label2.TabIndex = 6
		Me.Label2.Text = "Pixel Format"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblPixelFormat
		'
		Me.lblPixelFormat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPixelFormat.Location = New System.Drawing.Point(264, 136)
		Me.lblPixelFormat.Name = "lblPixelFormat"
		Me.lblPixelFormat.Size = New System.Drawing.Size(104, 24)
		Me.lblPixelFormat.TabIndex = 5
		Me.lblPixelFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(128, 160)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(136, 23)
		Me.Label3.TabIndex = 8
		Me.Label3.Text = "Size (pixels)"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblImageSize
		'
		Me.lblImageSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblImageSize.Location = New System.Drawing.Point(264, 160)
		Me.lblImageSize.Name = "lblImageSize"
		Me.lblImageSize.Size = New System.Drawing.Size(104, 24)
		Me.lblImageSize.TabIndex = 7
		Me.lblImageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(128, 184)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(136, 23)
		Me.Label4.TabIndex = 10
		Me.Label4.Text = "Resolution (pixels/inch)"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblResolution
		'
		Me.lblResolution.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblResolution.Location = New System.Drawing.Point(264, 184)
		Me.lblResolution.Name = "lblResolution"
		Me.lblResolution.Size = New System.Drawing.Size(104, 24)
		Me.lblResolution.TabIndex = 9
		Me.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnDisplay
		'
		Me.btnDisplay.Enabled = False
		Me.btnDisplay.Location = New System.Drawing.Point(128, 8)
		Me.btnDisplay.Name = "btnDisplay"
		Me.btnDisplay.Size = New System.Drawing.Size(96, 24)
		Me.btnDisplay.TabIndex = 11
		Me.btnDisplay.Text = "Display Image"
		'
		'mnuAboutWS
		'
		Me.mnuAboutWS.Index = 1
		Me.mnuAboutWS.Text = "About &Web Service . . ."
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(370, 211)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDisplay, Me.Label4, Me.lblResolution, Me.Label3, Me.lblImageSize, Me.Label2, Me.lblPixelFormat, Me.Label1, Me.picImage, Me.lblSize, Me.lstImages, Me.btnRetrieve})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Close the current form
		Me.Close()
	End Sub

	' This code will get the About string from the Web Service
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAboutWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAboutWS.Click
		Try
			Dim imgsvc As New GraphicsServer.ImageService()
			MsgBox(imgsvc.About(), MsgBoxStyle.Information, Me.Text)
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

#End Region

	Private maInfo As GraphicsServer.ImageInfo()

	Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
		DisplayImage()
	End Sub

	Private Sub btnRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve.Click
		Dim imgsvc As GraphicsServer.ImageService
		Dim info As GraphicsServer.ImageInfo

		Try
			' Turn on the hourglass cursor. 
			Me.Cursor.Current = Cursors.WaitCursor

			' Retrieve array of information
			' about available images.
			imgsvc = New GraphicsServer.ImageService()
			maInfo = imgsvc.Browse()

			' Clear the list, then fill it in.
			lstImages.Items.Clear()

			' Because the Web Service proxy class defines
			' the elements of the ImageInfo structure as simple
			' fields, you can't simply bind the ListBox to 
			' the array, supplying the DisplayMember property.
			For Each info In maInfo
				lstImages.Items.Add(info.Name)
			Next

		Catch Exp As Exception
			MessageBox.Show(Exp.Message, Me.Text)

		Finally
			' Turn off the hourglass cursor.
			' Apparently, this isn't required -- when
			' you leave the procedure, it goes back to
			' normal. But it's a good idea to put it back 
			' when you're done.
			Me.Cursor.Current = Cursors.Default
			imgsvc.Dispose()
		End Try
	End Sub

	Private Sub lstImages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstImages.SelectedIndexChanged
		Dim imgsvc As GraphicsServer.ImageService
		Dim Info As GraphicsServer.ImageInfo

		' Display information about the selected image.

		Try
			imgsvc = New GraphicsServer.ImageService()
			Info = maInfo(lstImages.SelectedIndex)
			lblSize.Text = Info.Size.ToString
			lblPixelFormat.Text = Info.PixelFormat.ToString
			lblResolution.Text = String.Format("{0} x {1}", Info.HorizontalResolution, Info.VerticalResolution)
			lblImageSize.Text = String.Format("{0} x {1}", Info.Width, Info.Height)
			picImage.Image = GetImage(Info.Thumbnail)
			btnDisplay.Enabled = True

		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)

		Finally
			imgsvc.Dispose()
		End Try
	End Sub

	Private Sub picImage_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picImage.DoubleClick
		DisplayImage()
	End Sub

	Private Sub DisplayImage()
		Dim frm As frmImage
		Dim imgsvc As GraphicsServer.ImageService
		Dim Info As GraphicsServer.ImageInfo
		Dim bmp As Bitmap
		Dim strName As String

		' Display information about the selected image.

		Try
			imgsvc = New GraphicsServer.ImageService()
			strName = maInfo(lstImages.SelectedIndex).Name
			bmp = GetImage(imgsvc.GetImage(strName))

			' Create a new image form instance.
			frm = New frmImage()
			frm.Text = strName
			frm.Image = bmp
			frm.ClientSize = New Size(bmp.Width, bmp.Height)
			frm.Show()

		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)

		Finally
			imgsvc.Dispose()
		End Try
	End Sub

	Private Function GetImage(ByVal abyt() As Byte) As Bitmap
		' Given an array of bytes, return an actual Bitmap
		' object. This requires creating a new MemoryStream
		' object based on the array of bytes, and then 
		' creating a new bitmap based on the memory stream.
		Try
			Return New Bitmap(New MemoryStream(abyt))
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Function

End Class