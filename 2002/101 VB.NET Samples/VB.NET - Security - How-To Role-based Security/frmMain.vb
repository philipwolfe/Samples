'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Security.Principal
Imports System.Security.Permissions

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
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents pagWindows As System.Windows.Forms.TabPage
	Friend WithEvents txtLogin As System.Windows.Forms.TextBox
	Friend WithEvents ckUsers As System.Windows.Forms.CheckBox
	Friend WithEvents btnLogin As System.Windows.Forms.Button
	Friend WithEvents ckManagers As System.Windows.Forms.CheckBox
	Friend WithEvents ckPowerUsers As System.Windows.Forms.CheckBox
	Friend WithEvents ckAdministrator As System.Windows.Forms.CheckBox
	Friend WithEvents pagDemand As System.Windows.Forms.TabPage
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
	Friend WithEvents btnUnion As System.Windows.Forms.Button
	Friend WithEvents btnManagerRun As System.Windows.Forms.Button
	Friend WithEvents btnPowerRun As System.Windows.Forms.Button
	Friend WithEvents btnAdminRun As System.Windows.Forms.Button
	Friend WithEvents lblProperties As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.pagWindows = New System.Windows.Forms.TabPage()
		Me.lblProperties = New System.Windows.Forms.Label()
		Me.txtLogin = New System.Windows.Forms.TextBox()
		Me.ckUsers = New System.Windows.Forms.CheckBox()
		Me.btnLogin = New System.Windows.Forms.Button()
		Me.ckManagers = New System.Windows.Forms.CheckBox()
		Me.ckPowerUsers = New System.Windows.Forms.CheckBox()
		Me.ckAdministrator = New System.Windows.Forms.CheckBox()
		Me.pagDemand = New System.Windows.Forms.TabPage()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtDisplay = New System.Windows.Forms.TextBox()
		Me.btnUnion = New System.Windows.Forms.Button()
		Me.btnManagerRun = New System.Windows.Forms.Button()
		Me.btnPowerRun = New System.Windows.Forms.Button()
		Me.btnAdminRun = New System.Windows.Forms.Button()
		Me.TabControl1.SuspendLayout()
		Me.pagWindows.SuspendLayout()
		Me.pagDemand.SuspendLayout()
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
		'TabControl1
		'
		Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.pagWindows, Me.pagDemand})
		Me.TabControl1.ItemSize = New System.Drawing.Size(86, 18)
		Me.TabControl1.Location = New System.Drawing.Point(25, 14)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(408, 225)
		Me.TabControl1.TabIndex = 1
		'
		'pagWindows
		'
		Me.pagWindows.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProperties, Me.txtLogin, Me.ckUsers, Me.btnLogin, Me.ckManagers, Me.ckPowerUsers, Me.ckAdministrator})
		Me.pagWindows.Location = New System.Drawing.Point(4, 22)
		Me.pagWindows.Name = "pagWindows"
		Me.pagWindows.Size = New System.Drawing.Size(400, 199)
		Me.pagWindows.TabIndex = 0
		Me.pagWindows.Text = "WindowsIdentity and WindowsPrincipal"
		'
		'lblProperties
		'
		Me.lblProperties.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblProperties.Location = New System.Drawing.Point(192, 17)
		Me.lblProperties.Name = "lblProperties"
		Me.lblProperties.Size = New System.Drawing.Size(192, 23)
		Me.lblProperties.TabIndex = 15
		Me.lblProperties.Text = "WindowsIdentity Properties:"
		Me.lblProperties.Visible = False
		'
		'txtLogin
		'
		Me.txtLogin.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.txtLogin.Location = New System.Drawing.Point(192, 40)
		Me.txtLogin.Multiline = True
		Me.txtLogin.Name = "txtLogin"
		Me.txtLogin.Size = New System.Drawing.Size(200, 144)
		Me.txtLogin.TabIndex = 14
		Me.txtLogin.Text = ""
		'
		'ckUsers
		'
		Me.ckUsers.AutoCheck = False
		Me.ckUsers.CausesValidation = False
		Me.ckUsers.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.ckUsers.Location = New System.Drawing.Point(16, 88)
		Me.ckUsers.Name = "ckUsers"
		Me.ckUsers.Size = New System.Drawing.Size(176, 24)
		Me.ckUsers.TabIndex = 12
		Me.ckUsers.Text = "Is in Users group"
		'
		'btnLogin
		'
		Me.btnLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnLogin.Location = New System.Drawing.Point(16, 8)
		Me.btnLogin.Name = "btnLogin"
		Me.btnLogin.Size = New System.Drawing.Size(160, 23)
		Me.btnLogin.TabIndex = 0
		Me.btnLogin.Text = "Retrieve User Information"
		Me.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ckManagers
		'
		Me.ckManagers.AutoCheck = False
		Me.ckManagers.CausesValidation = False
		Me.ckManagers.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.ckManagers.Location = New System.Drawing.Point(16, 112)
		Me.ckManagers.Name = "ckManagers"
		Me.ckManagers.Size = New System.Drawing.Size(176, 24)
		Me.ckManagers.TabIndex = 13
		Me.ckManagers.Text = "Is in custom Managers group"
		'
		'ckPowerUsers
		'
		Me.ckPowerUsers.AutoCheck = False
		Me.ckPowerUsers.CausesValidation = False
		Me.ckPowerUsers.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.ckPowerUsers.Location = New System.Drawing.Point(16, 64)
		Me.ckPowerUsers.Name = "ckPowerUsers"
		Me.ckPowerUsers.Size = New System.Drawing.Size(176, 24)
		Me.ckPowerUsers.TabIndex = 11
		Me.ckPowerUsers.Text = "Is in Power Users group"
		'
		'ckAdministrator
		'
		Me.ckAdministrator.AutoCheck = False
		Me.ckAdministrator.CausesValidation = False
		Me.ckAdministrator.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.ckAdministrator.Location = New System.Drawing.Point(16, 40)
		Me.ckAdministrator.Name = "ckAdministrator"
		Me.ckAdministrator.Size = New System.Drawing.Size(176, 24)
		Me.ckAdministrator.TabIndex = 10
		Me.ckAdministrator.Text = "Is in Administrators group"
		'
		'pagDemand
		'
		Me.pagDemand.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.txtDisplay, Me.btnUnion, Me.btnManagerRun, Me.btnPowerRun, Me.btnAdminRun})
		Me.pagDemand.Location = New System.Drawing.Point(4, 22)
		Me.pagDemand.Name = "pagDemand"
		Me.pagDemand.Size = New System.Drawing.Size(400, 199)
		Me.pagDemand.TabIndex = 1
		Me.pagDemand.Text = "Role-Based Demands"
		Me.pagDemand.Visible = False
		'
		'Label1
		'
		Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label1.Location = New System.Drawing.Point(16, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(144, 23)
		Me.Label1.TabIndex = 17
		Me.Label1.Text = "Click button to run code"
		'
		'txtDisplay
		'
		Me.txtDisplay.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.txtDisplay.Location = New System.Drawing.Point(184, 40)
		Me.txtDisplay.Multiline = True
		Me.txtDisplay.Name = "txtDisplay"
		Me.txtDisplay.Size = New System.Drawing.Size(208, 144)
		Me.txtDisplay.TabIndex = 16
		Me.txtDisplay.Text = ""
		'
		'btnUnion
		'
		Me.btnUnion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.btnUnion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnUnion.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnUnion.Location = New System.Drawing.Point(16, 112)
		Me.btnUnion.Name = "btnUnion"
		Me.btnUnion.Size = New System.Drawing.Size(152, 23)
		Me.btnUnion.TabIndex = 15
		Me.btnUnion.Text = "Power Users or Managers"
		Me.btnUnion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnManagerRun
		'
		Me.btnManagerRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.btnManagerRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnManagerRun.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnManagerRun.Location = New System.Drawing.Point(16, 88)
		Me.btnManagerRun.Name = "btnManagerRun"
		Me.btnManagerRun.Size = New System.Drawing.Size(152, 23)
		Me.btnManagerRun.TabIndex = 13
		Me.btnManagerRun.Text = "Custom Managers"
		Me.btnManagerRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnPowerRun
		'
		Me.btnPowerRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.btnPowerRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnPowerRun.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnPowerRun.Location = New System.Drawing.Point(16, 64)
		Me.btnPowerRun.Name = "btnPowerRun"
		Me.btnPowerRun.Size = New System.Drawing.Size(152, 23)
		Me.btnPowerRun.TabIndex = 11
		Me.btnPowerRun.Text = "Power Users"
		Me.btnPowerRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnAdminRun
		'
		Me.btnAdminRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.btnAdminRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnAdminRun.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.btnAdminRun.Location = New System.Drawing.Point(16, 40)
		Me.btnAdminRun.Name = "btnAdminRun"
		Me.btnAdminRun.Size = New System.Drawing.Size(152, 23)
		Me.btnAdminRun.TabIndex = 10
		Me.btnAdminRun.Text = "Administrators"
		Me.btnAdminRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(458, 253)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.TabControl1.ResumeLayout(False)
		Me.pagWindows.ResumeLayout(False)
		Me.pagDemand.ResumeLayout(False)
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

	' Declare the WindowsIdentity and WindowsPrincipal objects
	' with class scope so that they can be called by any procedures
	Private idWindows As WindowsIdentity
	Private prinWindows As WindowsPrincipal

	' Retrieve the computer name 
	Private machName As String = System.Environment.MachineName

	Private Sub btnAdminRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminRun.Click
		' Clear Textbox
		Me.txtDisplay.Text = String.Empty

		' The PrincipalPermission object allows security checks against the active
		' principal by passing the user name and the group (or role) name. If you pass
		' Nothing, then all members of the specified role are considered, not individual users.
		' Note that you can't use the WindowsBuiltInRole enumerations here--you must
		' pass a string using the BUILTIN keyword and the Windows group name.
		Dim op As New PrincipalPermission(Nothing, "BUILTIN\Administrators")

		' Placing the security Demand in a Try-Catch block allows you to gracefully
		' handle the security exception that will be thrown if the current user is not
		' a member of the specified group.
		Try
			op.Demand()
			Dim frm As New frmProtected()
			frm.Show()

			frm.txtProtected.Text = String.Format( _
			"Demand succeeded.{0}User is a member of the Administrators group.", _
			ControlChars.CrLf)

		Catch ex As System.Security.SecurityException
			' The Catch block handles the exception thrown if someone who is not a member
			' of the Administrators group tries to run the code. A message is displayed in
			' the TextBox control on the form.
			txtDisplay.Text = String.Format( _
			"Security Exception:{0}{1}{2}Not a member of the Administrators group.", _
			ControlChars.CrLf, ex.Message, ControlChars.CrLf)
		End Try
	End Sub

	Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
		' Create a WindowsIdentity object for the current user 
		' using the GetCurrent method 
		idWindows = WindowsIdentity.GetCurrent()

		' Create a WindowsPrincipal object based
		' on the WindowsIdentity object. The WindowsPrincipal
		' object contains the current user's Group membership.
		prinWindows = New WindowsPrincipal(idWindows)

		' Set the Checked property of each Checkbox control
		' based on whether the user is a member of a specific role. 
		' The WindowsBuiltInRole has enumerations for the built-in roles.
		' Note that these enumerations are not spelled exactly the same as
		' the Windows groups they represent. Instead of using the enumerations,
		' you may use the BUILTIN keyword with the group name, which must
		' be spelled the same way it is in Windows. For example, the
		' enumeration WindowsBuildInRole.Administrator would be passed
		' as "BUILTIN\Administrators":
		'   ckAdministrator.Checked = _
		'    prinWindows.IsInRole("BUILTIN\Administrators")

		ckAdministrator.Checked = _
		 prinWindows.IsInRole(WindowsBuiltInRole.Administrator)

		ckPowerUsers.Checked = _
		 prinWindows.IsInRole(WindowsBuiltInRole.PowerUser)

		ckUsers.Checked = _
		 prinWindows.IsInRole(WindowsBuiltInRole.User)

		' The machine name is needed to work with custom
		' group names. 
		' If a custom Managers group does not exist,
		' the CheckBox will not be checked and no exception
		' will occur.
		ckManagers.Checked = _
		 prinWindows.IsInRole(machName & "\Managers")

		' Display the WindowsIdentity properties 
		txtLogin.AppendText(String.Format("Name:  {0}{1}", _
		 idWindows.Name, ControlChars.CrLf))
		txtLogin.AppendText(String.Format("AuthenticationType:  {0}{1}", _
		 idWindows.AuthenticationType, ControlChars.CrLf))
		txtLogin.AppendText(String.Format("IsAuthenticated:  {0}{1}", _
		 idWindows.IsAuthenticated, ControlChars.CrLf))
		txtLogin.AppendText(String.Format("IsAnonymous:  {0}{1}", _
		 idWindows.IsAnonymous, ControlChars.CrLf))
		txtLogin.AppendText(String.Format("IsGuest:  {0}{1}", _
		 idWindows.IsGuest, ControlChars.CrLf))
		txtLogin.AppendText(String.Format("IsSystem:  {0}{1}", _
		 idWindows.IsSystem, ControlChars.CrLf))
		txtLogin.AppendText(String.Format("Token:  {0}{1}", _
		 idWindows.Token, ControlChars.CrLf))
		lblProperties.Visible = True
	End Sub

	Private Sub btnManagerRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManagerRun.Click
		' Clear Textbox
		txtDisplay.Text = String.Empty

		' The MachineName is required for custom groups. If the user is not a member of the 
		' group, or if the group does not exist, then a security exception will be thrown
		' and the Demand will fail.
		Dim op As New PrincipalPermission(Nothing, machName & "\Managers")

		Try
			op.Demand()
			Dim frm As New frmProtected()
			frm.Show()
			frm.txtProtected.Text = String.Format( _
			"Demand succeeded.{0}User is a member of the Managers group.", _
			ControlChars.CrLf)

		Catch ex As System.Security.SecurityException
			txtDisplay.Text = String.Format( _
			"Security Exception:{0}{1}{2}Not a member of the Managers group.", _
			ControlChars.CrLf, ex.Message, ControlChars.CrLf)
		End Try
	End Sub

	Private Sub btnPowerRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerRun.Click
		' Clear Textbox
		txtDisplay.Text = String.Empty

		' The Power Users group is also a built-in group. 
		Dim op As New PrincipalPermission(Nothing, "BUILTIN\PowerUsers")

		Try
			op.Demand()
			Dim frm As New frmProtected()
			frm.Show()
			frm.txtProtected.Text = String.Format( _
			"Demand succeeded.{0}User is a member of the Power Users group.", _
			ControlChars.CrLf)

		Catch ex As System.Security.SecurityException
			txtDisplay.Text = String.Format( _
			"Security Exception:{0}{1}{2}Not a member of the Power Users group.", _
			ControlChars.CrLf, ex.Message, ControlChars.CrLf)
		End Try
	End Sub

	Private Sub btnUnion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnion.Click
		' Clear Textbox
		txtDisplay.Text = String.Empty

		' You can create a Demand that checks for multiple groups by using the Union method.
		' This example requires that the user be a member of the built-in Power Users group
		' or the custom Managers group. If the user is not a member of either one, a security
		' exception will be thrown.

		' Instantiate PrincipalPermission objects for PowerUsers and Managers
		Dim opPower As New PrincipalPermission(Nothing, "BUILTIN\PowerUsers")
		Dim opMgr As New PrincipalPermission(Nothing, machName & "\Managers")

		' Use the Union operator to combine Managers and Power Users.
		Try
			opPower.Union(opMgr).Demand()
			Dim frm As New frmProtected()
			frm.Show()
			frm.txtProtected.Text = String.Format( _
			"Demand succeeded.{0}User is a member of the Power Users or the Managers group.", _
			ControlChars.CrLf)

			' An exception will be thrown if the user belongs to neither group.
		Catch ex As System.Security.SecurityException
			txtDisplay.Text = String.Format( _
			"Security Exception:{0}{1}{2}Not a member of Managers or Power Users.", _
			ControlChars.CrLf, ex.Message, ControlChars.CrLf)
		End Try
	End Sub

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Setting the PrincipalPolicy to WindowsPrincipal specifies how principal 
		' and identity objects should be attached to a thread if the thread 
		' attempts to bind to a principal. In this case, we set the PrincipalPolicy 
		' enumeration to WindowsPrincipal, which maps operating system groups to roles.
		' This statement is needed for role-based security demands.
		AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)

	End Sub

End Class