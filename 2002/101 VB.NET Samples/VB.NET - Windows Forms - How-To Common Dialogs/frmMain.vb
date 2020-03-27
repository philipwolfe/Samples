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
	Friend WithEvents btnSelectFont As System.Windows.Forms.Button
	Friend WithEvents btnSelectColor As System.Windows.Forms.Button
	Friend WithEvents txtFileContents As System.Windows.Forms.TextBox
	Friend WithEvents lstFiles As System.Windows.Forms.ListBox
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
	Friend WithEvents odlgTextFile As System.Windows.Forms.OpenFileDialog
	Friend WithEvents sdlgTextFile As System.Windows.Forms.SaveFileDialog
	Friend WithEvents btnSaveTextFile As System.Windows.Forms.Button
	Friend WithEvents btnOpenTextFile As System.Windows.Forms.Button
	Friend WithEvents fdlgText As System.Windows.Forms.FontDialog
	Friend WithEvents tabOptions As System.Windows.Forms.TabControl
	Friend WithEvents pgeOpenSaveFile As System.Windows.Forms.TabPage
	Friend WithEvents pgeOpenMultipleFiles As System.Windows.Forms.TabPage
	Friend WithEvents cdlgText As System.Windows.Forms.ColorDialog
	Friend WithEvents btnRetriveFileNames As System.Windows.Forms.Button
	Friend WithEvents odlgFileNames As System.Windows.Forms.OpenFileDialog
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.sdlgTextFile = New System.Windows.Forms.SaveFileDialog()
		Me.fdlgText = New System.Windows.Forms.FontDialog()
		Me.odlgFileNames = New System.Windows.Forms.OpenFileDialog()
		Me.cdlgText = New System.Windows.Forms.ColorDialog()
		Me.odlgTextFile = New System.Windows.Forms.OpenFileDialog()
		Me.tabOptions = New System.Windows.Forms.TabControl()
		Me.pgeOpenSaveFile = New System.Windows.Forms.TabPage()
		Me.btnSelectFont = New System.Windows.Forms.Button()
		Me.btnSelectColor = New System.Windows.Forms.Button()
		Me.btnSaveTextFile = New System.Windows.Forms.Button()
		Me.txtFileContents = New System.Windows.Forms.TextBox()
		Me.btnOpenTextFile = New System.Windows.Forms.Button()
		Me.pgeOpenMultipleFiles = New System.Windows.Forms.TabPage()
		Me.lstFiles = New System.Windows.Forms.ListBox()
		Me.btnRetriveFileNames = New System.Windows.Forms.Button()
		Me.tabOptions.SuspendLayout()
		Me.pgeOpenSaveFile.SuspendLayout()
		Me.pgeOpenMultipleFiles.SuspendLayout()
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
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
		Me.mnuHelp.Text = "&Help"
		'
		'mnuAbout
		'
		Me.mnuAbout.Index = 0
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		'
		'sdlgTextFile
		'
		Me.sdlgTextFile.FileName = "doc1"
		'
		'fdlgText
		'
		'
		'odlgTextFile
		'
		'
		'tabOptions
		'
		Me.tabOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeOpenSaveFile, Me.pgeOpenMultipleFiles})
		Me.tabOptions.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tabOptions.ItemSize = New System.Drawing.Size(84, 18)
		Me.tabOptions.Name = "tabOptions"
		Me.tabOptions.SelectedIndex = 0
		Me.tabOptions.Size = New System.Drawing.Size(562, 292)
		Me.tabOptions.TabIndex = 1
		'
		'pgeOpenSaveFile
		'
		Me.pgeOpenSaveFile.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSelectFont, Me.btnSelectColor, Me.btnSaveTextFile, Me.txtFileContents, Me.btnOpenTextFile})
		Me.pgeOpenSaveFile.Location = New System.Drawing.Point(4, 22)
		Me.pgeOpenSaveFile.Name = "pgeOpenSaveFile"
		Me.pgeOpenSaveFile.Size = New System.Drawing.Size(554, 266)
		Me.pgeOpenSaveFile.TabIndex = 4
		Me.pgeOpenSaveFile.Text = "Open/SaveFileDialog"
		'
		'btnSelectFont
		'
		Me.btnSelectFont.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnSelectFont.Location = New System.Drawing.Point(8, 104)
		Me.btnSelectFont.Name = "btnSelectFont"
		Me.btnSelectFont.Size = New System.Drawing.Size(168, 23)
		Me.btnSelectFont.TabIndex = 5
		Me.btnSelectFont.Text = "S&elect a Font"
		'
		'btnSelectColor
		'
		Me.btnSelectColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnSelectColor.Location = New System.Drawing.Point(8, 72)
		Me.btnSelectColor.Name = "btnSelectColor"
		Me.btnSelectColor.Size = New System.Drawing.Size(168, 23)
		Me.btnSelectColor.TabIndex = 4
		Me.btnSelectColor.Text = "Select a &Color"
		'
		'btnSaveTextFile
		'
		Me.btnSaveTextFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnSaveTextFile.Location = New System.Drawing.Point(8, 40)
		Me.btnSaveTextFile.Name = "btnSaveTextFile"
		Me.btnSaveTextFile.Size = New System.Drawing.Size(168, 23)
		Me.btnSaveTextFile.TabIndex = 3
		Me.btnSaveTextFile.Text = "&Save a File"
		'
		'txtFileContents
		'
		Me.txtFileContents.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.txtFileContents.Location = New System.Drawing.Point(184, 8)
		Me.txtFileContents.Multiline = True
		Me.txtFileContents.Name = "txtFileContents"
		Me.txtFileContents.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtFileContents.Size = New System.Drawing.Size(362, 252)
		Me.txtFileContents.TabIndex = 2
		Me.txtFileContents.Text = ""
		'
		'btnOpenTextFile
		'
		Me.btnOpenTextFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnOpenTextFile.Location = New System.Drawing.Point(8, 8)
		Me.btnOpenTextFile.Name = "btnOpenTextFile"
		Me.btnOpenTextFile.Size = New System.Drawing.Size(168, 23)
		Me.btnOpenTextFile.TabIndex = 1
		Me.btnOpenTextFile.Text = "&Open a File"
		'
		'pgeOpenMultipleFiles
		'
		Me.pgeOpenMultipleFiles.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstFiles, Me.btnRetriveFileNames})
		Me.pgeOpenMultipleFiles.Location = New System.Drawing.Point(4, 22)
		Me.pgeOpenMultipleFiles.Name = "pgeOpenMultipleFiles"
		Me.pgeOpenMultipleFiles.Size = New System.Drawing.Size(554, 266)
		Me.pgeOpenMultipleFiles.TabIndex = 0
		Me.pgeOpenMultipleFiles.Text = "Select Multiple Files"
		Me.pgeOpenMultipleFiles.Visible = False
		'
		'lstFiles
		'
		Me.lstFiles.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.lstFiles.Location = New System.Drawing.Point(184, 8)
		Me.lstFiles.Name = "lstFiles"
		Me.lstFiles.Size = New System.Drawing.Size(362, 238)
		Me.lstFiles.TabIndex = 1
		'
		'btnRetriveFileNames
		'
		Me.btnRetriveFileNames.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnRetriveFileNames.Location = New System.Drawing.Point(8, 8)
		Me.btnRetriveFileNames.Name = "btnRetriveFileNames"
		Me.btnRetriveFileNames.Size = New System.Drawing.Size(168, 23)
		Me.btnRetriveFileNames.TabIndex = 0
		Me.btnRetriveFileNames.Text = "&Retrieve File Names"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(562, 292)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabOptions})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.tabOptions.ResumeLayout(False)
		Me.pgeOpenSaveFile.ResumeLayout(False)
		Me.pgeOpenMultipleFiles.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
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
#End Region

	Private FileName As String

	Private Sub btnRetriveFileNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetriveFileNames.Click
		Try
			With odlgFileNames
				' You may not always want to do this, 
				' but you can set the initial directory.
				' In this example, the code only 
				' sets this property if you've 
				' set the DefaultFolder value
				' since the last time opening 
				' the dialog box. If you don't 
				' call the Reset method, your
				' initial directory won't affect
				' the dialog box, if you've already
				' selected a file using it.
				.Reset()
				.InitialDirectory = "C:\"

				' Add default extension to file name if the user
				' doesn't type it.
				' The default is True.
				.AddExtension = True

				' Check to ensure that the selected
				' file exists.  Dialog box displays 
				' a warning otherwise.
				' The default is True.
				.CheckFileExists = True

				' Check to ensure that the selected
				' path exists.  Dialog box displays 
				' a warning otherwise.
				' The default is True.
				.CheckPathExists = True

				' Get or set default extension. Doesn't 
				' include the leading ".".
				' The default is "".
				.DefaultExt = "txt"

				' Return the file referenced by a link? If 
				' False, simply returns the selected link
				' file. If True, returns the file linked to 
				' the LNK file.
				' The default is True.
				.DereferenceLinks = True

				' Just as in VB6, use a set of pairs
				' of filters, separated with "|". Each 
				' pair consists of a description|file spec.
				' Use a "|" between pairs. No need to put a
				' trailing "|". You can set the FilterIndex
				' property as well, to select the default
				' filter. Amazingly, the first filter is 
				' numbered 1 (not 0). The default is 1. 
				' The default is "".
				.Filter = _
				"Text files (*.txt)|*.txt|" & _
				"All files|*.*"

				' If you want to allow users to select
				' more than one file, set this to True. 
				' If you set this to True, retrieve
				' the selected files using the FileNames
				' property of the dialog box.
				' The default is False.
				.Multiselect = True

				' Restore the original directory when done selecting
				' a file? If False, the current directory changes
				' to the directory in which you selected the file.
				' Set this to True to put the current folder back
				' where it was when you started.
				' The default is False.
				.RestoreDirectory = True

				' Show the Help button and Read-Only checkbox?
				' The Default for each is False.
				.ShowHelp = True
				.ShowReadOnly = False

				' Start out with the read-only check box checked?
				' This only make sense if ShowReadOnly is True.
				' The default is False.
				' .ReadOnlyChecked = False

				' The default is "".
				.Title = "Select a file"

				' Only accept valid Win32 file names?
				' The default is True.
				.ValidateNames = True

				If .ShowDialog() = DialogResult.OK Then
					' You have a choice here. You can either
					' use the FileName or FileNames properties to get the name 
					' you selected, or you can use the OpenFile
					' method to open the file as a read-only Stream.
					lstFiles.DataSource = .FileNames

					' You could also write code like this, 
					' to loop through the selected file names:
					'Dim strName As String
					'For Each strName In .FileNames
					'    lstFiles.Items.Add(strName)
					'Next
				End If
			End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub btnOpenTextFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenTextFile.Click
		Dim ts As StreamReader

		Try
			With odlgTextFile
				' See btnRetriveFileNames_Click for explanations of default values 
				' for the properties.

				' Check to ensure that the selected
				' file exists.  Dialog box displays 
				' a warning otherwise.
				.CheckFileExists = True

				' Check to ensure that the selected
				' path exists.  Dialog box displays 
				' a warning otherwise.
				.CheckPathExists = True

				' Get or set default extension. Doesn't 
				' include the leading ".".
				.DefaultExt = "txt"

				' Return the file referenced by a link? If 
				' False, simply returns the selected link
				' file. If True, returns the file linked to 
				' the LNK file.
				.DereferenceLinks = True

				' Just as in VB6, use a set of pairs
				' of filters, separated with "|". Each 
				' pair consists of a description|file spec.
				' Use a "|" between pairs. No need to put a
				' trailing "|". You can set the FilterIndex
				' property as well, to select the default
				' filter. Amazingly, the first filter is 
				' numbered 1 (not 0). The default is 1. 
				.Filter = _
				"Text files (*.txt)|*.txt|" & _
				"All files|*.*"

				.Multiselect = False

				' Restore the original directory when done selecting
				' a file? If False, the current directory changes
				' to the directory in which you selected the file.
				' Set this to True to put the current folder back
				' where it was when you started.
				' The default is False.
				.RestoreDirectory = True

				' Show the Help button and Read-Only checkbox?
				.ShowHelp = True
				.ShowReadOnly = False

				' Start out with the read-only check box checked?
				' This only make sense if ShowReadOnly is True.
				' .ReadOnlyChecked = False

				.Title = "Select a file to open"

				' Only accept valid Win32 file names?
				.ValidateNames = True

				If .ShowDialog() = DialogResult.OK Then
					FileName = .FileName
					ts = New StreamReader(.OpenFile)
					txtFileContents.Text = ts.ReadToEnd()
				End If
			End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		Finally
			If Not (ts Is Nothing) Then
				ts.Close()
			End If
		End Try
	End Sub

	Private Sub btnSaveTextFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveTextFile.Click
		Dim sw As StreamWriter

		Try
			With sdlgTextFile
				' See the code demonstrating
				' the OpenFileDialog control
				' for examples using most 
				' properties, which are the same
				' for both controls, for the most part.

				' Add the default extension, if the user
				' neglects to add an extension.
				' The default is True.
				.AddExtension = True

				' Check to verify that the output path
				' actually exists. Prompt before
				' creating a new file? Prompt before
				' overwriting? 
				' The default is True.
				.CheckPathExists = True
				' The default is False.
				.CreatePrompt = False
				' The default is True.
				.OverwritePrompt = True
				' The default is True.
				.ValidateNames = True
				' The default is False.
				.ShowHelp = True

				' If the user doesn't supply an extension,
				' and if the AddExtension property is
				' True, use this extension.
				' The default is "".
				.DefaultExt = "txt"

				' Prompt with the current file name
				' if you've specified it.
				' The default is "".
				.FileName = FileName

				' The default is "".
				.Filter = _
				"Text files (*.txt)|*.txt|" & _
				"All files|*.*"
				.FilterIndex = 1

				If .ShowDialog() = DialogResult.OK Then
					FileName = .FileName
					sw = New StreamWriter(FileName)
					sw.Write(txtFileContents.Text)
				End If
			End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		Finally
			If Not (sw Is Nothing) Then
				sw.Close()
			End If
		End Try
	End Sub

	Private Sub odlgTextFile_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles odlgTextFile.FileOk
		' This event occurs after you select a file, but 
		' before the dialog box is dismissed. If you set the 
		' Cancel property of the CancelEventArgs property to True, 
		' you'll be sent back to the dialog box.

		' Obviously, using this event in the manner shown 
		' here would be vaguely annoying.

		' The default value of e.Cancel is False.
		If MessageBox.Show( _
		 "Do you want to open a new file?", _
		 Me.Text, MessageBoxButtons.YesNo, _
		 MessageBoxIcon.Question) <> DialogResult.Yes Then

			e.Cancel = True
		End If
	End Sub

	Private Sub odlgTextFile_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles odlgTextFile.HelpRequest
		' If the OpenFileDialog control displays its Help button
		' (see the ShowHelp property of the OpenFileDialog control), 
		' this code runs.
		MessageBox.Show("Display your own help for the OpenFileDialog control here.", Me.Text)
	End Sub

	Private Sub sdlgTextFile_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sdlgTextFile.HelpRequest
		' If the SaveFileDialog control displays its Help button
		' (see the ShowHelp property of the SaveFileDialog control), 
		' this code runs.
		MessageBox.Show("Display your own help for the SaveFileDialog control here.", Me.Text)
	End Sub

	Private Sub btnSelectColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectColor.Click

		' Initialize CustomColors with an array of integers.
		' Note that these colors aren't in the same format 
		' as .NET colors -- these are the old VB6-type
		' color values. For example, 0 is Black, 255 is Red, 
		' and so on. You can use the VB6 RGB function to create 
		' these values.

		' For this example, put Red, Green, and Blue in the custom 
		' colors section.
		Static CustomColors() As Integer = _
		 {RGB(255, 0, 0), RGB(0, 255, 0), RGB(0, 0, 255)}

		Try
			With cdlgText
				' Initialize the selected color
				' to match the color currently used
				' by the TextBox's foreground color.
				' The default is Black.
				.Color = txtFileContents.ForeColor

				' Fill the custom colors on the dialog box
				' with the array you've supplied. This is, 
				' of course, totally optional.
				.CustomColors = CustomColors

				' Allow the user to create custom colors?
				' The default is True.
				.AllowFullOpen = True

				' Display all of the basic colors?
				' The default is False.
				.AnyColor = True

				' If True, dialog box displays with the custom 
				' color settings side open, as well.
				' The default is False.
				.FullOpen = False

				' Restrict users to solid colors only.
				' The default is False.
				.SolidColorOnly = True

				' If ShowHelp is true, the control will display its Help
				' button, and you can react to the control's 
				' HelpRequest event. 
				' The default is False.
				.ShowHelp = True

				If .ShowDialog() = DialogResult.OK Then
					txtFileContents.ForeColor = .Color

					' Store the custom colors for future
					' use. 
					CustomColors = .CustomColors
				End If

				' Reset all the colors in the dialog box.
				' This isn't necessary, but it does
				' make sure the dialog box is in a 
				' known state for its next use.
				cdlgText.Reset()
			End With

			' You can get away with much less code. 
			' Minimally, this will set the color
			' for you -- just won't give you any options:
			'With cdlgText
			'  .Color = txtFileContents.ForeColor
			'  If .ShowDialog() = DialogResult.OK Then
			'    txtFileContents.ForeColor = .Color
			'  End If
			'End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub btnSelectFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFont.Click
		Try
			With fdlgText
				' Initialize the dialog box to match
				' the font used in the text box.

				.Font = txtFileContents.Font
				' The default is Black.
				.Color = txtFileContents.ForeColor

				' Allow the users to select colors.
				' The default is False.
				.ShowColor = True

				' Show the Apply button on the dialog box.
				' The default is False.
				.ShowApply = True

				' Allow users to select effects.
				' The default is True.
				.ShowEffects = True

				' Show the Help button.
				' The default is False.
				.ShowHelp = True

				' Let the user change the character set, 
				' but don't allow simulations, vector fonts, 
				' or vertical fonts.
				' The default is True.
				.AllowScriptChange = True
				' The default is True.
				.AllowSimulations = False
				' The default is True.
				.AllowVectorFonts = False
				' The default is True.
				.AllowVerticalFonts = False

				' Allow fixed and proportional fonts, 
				' and only allow fonts that exist.
				' Set the minimum and maximum selectable
				' font sizes, as well. These are arbitrary
				' values, in this example.

				' The default is False.
				.FixedPitchOnly = False
				' The default is False.
				.FontMustExist = True

				' The default for both these is 0.
				.MaxSize = 48
				.MinSize = 8

				' Display the dialog box, and then
				' fix up the font as requested.
				If .ShowDialog = DialogResult.OK Then
					ApplyFontAndColor()

				End If
			End With

			' Minimally, you would need code like this:
			'With fdlgText
			'  .Font = txtFileContents.Font
			'  If .ShowDialog() = DialogResult.OK Then
			'    txtFileContents.Font = .Font
			'  End If
			'End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub ApplyFontAndColor()
		Try
			With fdlgText
				' Set the TextBox's font to the selected font, 
				' including the size, weight, and so on.
				txtFileContents.Font = .Font
				' If the user selected a color
				' at the same time, set the 
				' selected color.
				If .ShowColor Then
					txtFileContents.ForeColor = .Color
				End If
			End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub fdlgText_Apply(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fdlgText.Apply
		' Handle the Apply event of the Font dialog.
		ApplyFontAndColor()
	End Sub
End Class