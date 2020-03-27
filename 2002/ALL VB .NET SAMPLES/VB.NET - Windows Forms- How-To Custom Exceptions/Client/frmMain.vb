'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' Imports for external assembly that defines
' a Customer class, and three custom exception classes.
' Note the reference required via the References folder.
Imports SomeCompany.CRMSystem

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
	Friend WithEvents cmdDelete As System.Windows.Forms.Button
	Friend WithEvents cmdUntrapped As System.Windows.Forms.Button
	Friend WithEvents cmdEdit As System.Windows.Forms.Button
	Friend WithEvents chkGET As System.Windows.Forms.CheckBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.cmdEdit = New System.Windows.Forms.Button()
		Me.cmdDelete = New System.Windows.Forms.Button()
		Me.cmdUntrapped = New System.Windows.Forms.Button()
		Me.chkGET = New System.Windows.Forms.CheckBox()
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
		'cmdEdit
		'
		Me.cmdEdit.Location = New System.Drawing.Point(8, 8)
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdEdit.Size = New System.Drawing.Size(150, 23)
		Me.cmdEdit.TabIndex = 0
		Me.cmdEdit.Text = "&Edit Customer"
		'
		'cmdDelete
		'
		Me.cmdDelete.Location = New System.Drawing.Point(8, 40)
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdDelete.Size = New System.Drawing.Size(150, 23)
		Me.cmdDelete.TabIndex = 1
		Me.cmdDelete.Text = "&Delete Customer"
		'
		'cmdUntrapped
		'
		Me.cmdUntrapped.Location = New System.Drawing.Point(8, 72)
		Me.cmdUntrapped.Name = "cmdUntrapped"
		Me.cmdUntrapped.Size = New System.Drawing.Size(150, 23)
		Me.cmdUntrapped.TabIndex = 2
		Me.cmdUntrapped.Text = "&Untrapped Local Error"
		'
		'chkGET
		'
		Me.chkGET.Location = New System.Drawing.Point(8, 104)
		Me.chkGET.Name = "chkGET"
		Me.chkGET.Size = New System.Drawing.Size(208, 24)
		Me.chkGET.TabIndex = 3
		Me.chkGET.Text = "&Turn on Global Exception Trap"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(394, 131)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkGET, Me.cmdUntrapped, Me.cmdDelete, Me.cmdEdit})
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

	Private Sub chkGET_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGET.CheckedChanged
		Dim ctl As CheckBox = CType(sender, CheckBox)

		If ctl.CheckState = CheckState.Checked Then
			' Turn on our own global exception handler.
			' Note just like the Windows Forms handler, we won't
			' see ours in the debugger by default.
			AddHandler Application.ThreadException, AddressOf Me.OnThreadException
		Else
			' Turn our handler off and revert back to the Windows Forms default.
			RemoveHandler Application.ThreadException, AddressOf Me.OnThreadException
		End If
	End Sub

	Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
		Dim c As Customer
		Try
			Dim i As Integer = 14213
			c = Customer.EditCustomer(i)

			' do work if we get a valid customer back
		Catch exp As CustomerNotFoundException
			MessageBox.Show(exp.Message, exp.AppSource, MessageBoxButtons.OK, MessageBoxIcon.Error)

		Catch exp As CustomerException
			MessageBox.Show(exp.Message, exp.AppSource, MessageBoxButtons.OK, MessageBoxIcon.Error)

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try
	End Sub

	Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

		Try
			Dim i As Integer = 14213
			Customer.DeleteCustomer(i)

			' We'll never see this, but just for completeness.
			MessageBox.Show(String.Format("Customer Id {0} was deleted.", i), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch exp As CustomerNotDeletedException
			Dim c As Customer
			c = exp.CustomerInfo
			' We can now do something more interesting with
			' the customer if we wanted to.
			MessageBox.Show(exp.Message, exp.AppSource, MessageBoxButtons.OK, MessageBoxIcon.Error)

		Catch exp As CustomerException
			MessageBox.Show(exp.Message, exp.AppSource, MessageBoxButtons.OK, MessageBoxIcon.Error)

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	Private Sub cmdUntrapped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUntrapped.Click
		' Normally an untrapped error in Visual Basic 6.0
		' and earlier would result in a quick MessageBox and then
		' our process shutting down.
		' Windows Forms however have injected a top-level error 
		' catch between the CLR and our code.
		' Whether or not you see their dialog depends upon three things:
		' 1) Is there an active debugger?
		' 2) Do you have your own exception handler in place?
		' 3) Have you turned JIT debugging on (set to true) in your App's config file.?

		' If an untrapped error occurs and you answered no to the
		' above questions, then you will see the Windows Forms dialgo
		' which gives the user a chance to Continue or Quit.
		' To see thier handler, you need to run the compiled code.

		Dim i As Short = 1234
		Dim j As Short = 0
		Dim k As Short = -1

		k = CShort(i / j)

		' Note that you will never see the MsgBox statement below
		MessageBox.Show("Your reults are: " & k.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
	End Sub

	Friend Sub OnThreadException(ByVal sender As Object, ByVal t As System.Threading.ThreadExceptionEventArgs)
		' At this point you should be able to figure out what to do.
		' You could log the error, show a messagebox, send an e-mail.
		' The real key is to evaluate the exception you received
		' using code like below.

		' Note you should be careful. If you have an untrapped exception here,
		' you will see the JIT debugging dialog, NOT the Windows Forms handler.
		' Uncomment the line below to see.
		' Throw New ArgumentException("Oopss! I did it again!")

		Dim exp As Exception = t.Exception

		If TypeOf exp Is CustomerException Then
			' Check for any CustomerExceptions

		ElseIf TypeOf exp Is ApplicationException Then
			' Check for any possible application exception

		ElseIf TypeOf exp Is ArithmeticException Then
			' You should see this dialog if you ran the
			' code in cmdUntrapped_Click.
			' Uncomment this line to verify.
			' MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		ElseIf TypeOf exp Is SystemException Then
			' Check for any possible system exception
		Else
			' Finally just plain old System.Exception
		End If

		Dim strMsg As String
		strMsg = String.Format("We're sorry, an untrapped error occurred.{0}The error message was:{0}{1}", vbCrLf, exp.Message)

		MessageBox.Show(strMsg, "Global Exception Trap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	End Sub

End Class