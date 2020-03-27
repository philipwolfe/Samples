'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO
Imports System.Runtime.Remoting

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
	Friend WithEvents lstOutput As System.Windows.Forms.ListBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.lstOutput = New System.Windows.Forms.ListBox()
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
		'lstOutput
		'
		Me.lstOutput.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstOutput.Name = "lstOutput"
		Me.lstOutput.ScrollAlwaysVisible = True
		Me.lstOutput.Size = New System.Drawing.Size(480, 225)
		Me.lstOutput.TabIndex = 2
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(480, 233)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstOutput})
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
#End Region

	' This function iterates through all the ClientActivatedService types
	' that were loaded via the RemotingConfiguration.Configure(Remoting.config)
	' file.
	Private Sub ListClientActivatedServiceTypes()
		Dim entry As ActivatedServiceTypeEntry
		For Each entry In RemotingConfiguration.GetRegisteredActivatedServiceTypes()
			Me.lstOutput.Items.Add("Registered ActivatedServiceType: " & entry.TypeName)
		Next
	End Sub

	' This function iterates through all the WellKnownService types
	' that were loaded via the RemotingConfiguration.Configure(Remoting.config)
	' file.
	Private Sub ListWellKnownServiceTypes()
		Dim entry As WellKnownServiceTypeEntry
		For Each entry In RemotingConfiguration.GetRegisteredWellKnownServiceTypes()
			Me.lstOutput.Items.Add(entry.TypeName & " is available at " & entry.ObjectUri)
		Next
	End Sub

	Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Try
			'Read in Host.exe.config file
			'The call to RemotingConfiguration.Configure loads in the xml configuration file
			'and lets the remoting architecture know what types to make available via remoting
			Me.lstOutput.Items.Add("Loading Activated Configuration File")

			RemotingConfiguration.Configure("Host.exe.config")

			'After loading the remoting.config file enumerate the list of ClientActivated
			'types and WellKnown types and list them in the list box on the form.
			Me.ListClientActivatedServiceTypes()
			Me.ListWellKnownServiceTypes()

		Catch exp As Exception
			' Will catch any generic exception
			Dim txt As String
			txt = "I was unable to load the file remoting.config or it is not in the correct format." & vbCrLf & _
			 "Please make sure it is located in the same directory as this exe " & _
			 " and that it is in the correct format." & vbCrLf & _
			 "Please see the Help, About box for the location of this exe." & vbCrLf & vbCrLf & _
			 "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			 "  Message: " & exp.Message & vbCrLf & _
			 "  Source: " & exp.Source & vbCrLf & vbCrLf & _
			 "  Stack Trace:" & vbCrLf & _
			 exp.StackTrace

			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

			Me.lstOutput.Items.Add("Unabled to load objects.")
		End Try

	End Sub

End Class