'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmAbout
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
	Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
	Friend WithEvents lblTitle As System.Windows.Forms.Label
	Friend WithEvents lblVersion As System.Windows.Forms.Label
	Friend WithEvents lblDescription As System.Windows.Forms.Label
	Friend WithEvents cmdOK As System.Windows.Forms.Button
	Friend WithEvents lblCopyright As System.Windows.Forms.Label
	Friend WithEvents lblCodebase As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.pbIcon = New System.Windows.Forms.PictureBox()
		Me.lblTitle = New System.Windows.Forms.Label()
		Me.lblVersion = New System.Windows.Forms.Label()
		Me.lblDescription = New System.Windows.Forms.Label()
		Me.cmdOK = New System.Windows.Forms.Button()
		Me.lblCopyright = New System.Windows.Forms.Label()
		Me.lblCodebase = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'pbIcon
		'
		Me.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.pbIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.pbIcon.Location = New System.Drawing.Point(16, 16)
		Me.pbIcon.Name = "pbIcon"
		Me.pbIcon.Size = New System.Drawing.Size(32, 32)
		Me.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.pbIcon.TabIndex = 0
		Me.pbIcon.TabStop = False
		'
		'lblTitle
		'
		Me.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblTitle.Location = New System.Drawing.Point(72, 16)
		Me.lblTitle.Name = "lblTitle"
		Me.lblTitle.Size = New System.Drawing.Size(360, 23)
		Me.lblTitle.TabIndex = 1
		Me.lblTitle.Text = "Application Title"
		'
		'lblVersion
		'
		Me.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblVersion.Location = New System.Drawing.Point(72, 40)
		Me.lblVersion.Name = "lblVersion"
		Me.lblVersion.Size = New System.Drawing.Size(360, 23)
		Me.lblVersion.TabIndex = 2
		Me.lblVersion.Text = "Application Version"
		'
		'lblDescription
		'
		Me.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblDescription.Location = New System.Drawing.Point(72, 80)
		Me.lblDescription.Name = "lblDescription"
		Me.lblDescription.Size = New System.Drawing.Size(360, 46)
		Me.lblDescription.TabIndex = 3
		Me.lblDescription.Text = "Application Description"
		'
		'cmdOK
		'
		Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdOK.Location = New System.Drawing.Point(352, 200)
		Me.cmdOK.Name = "cmdOK"
		Me.cmdOK.TabIndex = 4
		Me.cmdOK.Text = "OK"
		'
		'lblCopyright
		'
		Me.lblCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblCopyright.Location = New System.Drawing.Point(72, 56)
		Me.lblCopyright.Name = "lblCopyright"
		Me.lblCopyright.Size = New System.Drawing.Size(360, 23)
		Me.lblCopyright.TabIndex = 5
		Me.lblCopyright.Text = "Application Copyright"
		'
		'lblCodebase
		'
		Me.lblCodebase.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblCodebase.Location = New System.Drawing.Point(72, 128)
		Me.lblCodebase.Name = "lblCodebase"
		Me.lblCodebase.Size = New System.Drawing.Size(360, 64)
		Me.lblCodebase.TabIndex = 6
		Me.lblCodebase.Text = "Application Codebase"
		'
		'frmAbout
		'
		Me.AcceptButton = Me.cmdOK
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.CancelButton = Me.cmdOK
		Me.ClientSize = New System.Drawing.Size(440, 232)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCodebase, Me.lblCopyright, Me.cmdOK, Me.lblDescription, Me.lblVersion, Me.lblTitle, Me.pbIcon})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmAbout"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "About ..."
		Me.ResumeLayout(False)

	End Sub

#End Region

	' Note: Because this form is opened by frmMain using the ShowDialog command, we simply set the
	' DialogResult property of cmdOK to OK which causes the form to close when clicked.
	Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Try
			' Set this Form's Text & Icon properties by using values from the parent form
			Me.Text = "About " & Me.Owner.Text
			Me.Icon = Me.Owner.Icon

			' Set this Form's Picture Box's image using the parent's icon 
			' However, we need to convert it to a Bitmap since the Picture Box Control
			' will not accept a raw Icon.
			Me.pbIcon.Image = Me.Owner.Icon.ToBitmap()

			' Set the labels identitying the Title, Version, and Description by
			' reading Assembly meta-data originally entered in the AssemblyInfo.vb file
			' using the AssemblyInfo class defined in the same file
			Dim ainfo As New AssemblyInfo()

			Me.lblTitle.Text = ainfo.Title
			Me.lblVersion.Text = String.Format("Version {0}", ainfo.Version)
			Me.lblCopyright.Text = ainfo.Copyright
			Me.lblDescription.Text = ainfo.Description
			Me.lblCodebase.Text = ainfo.CodeBase

		Catch exp As System.Exception
			' This catch will trap any unexpected error.
			MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		End Try
	End Sub


End Class
