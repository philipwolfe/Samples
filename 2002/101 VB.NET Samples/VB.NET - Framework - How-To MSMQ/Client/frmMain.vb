'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Messaging

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
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents txtOrderNumber As System.Windows.Forms.TextBox
	Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
	Friend WithEvents txtReqDate As System.Windows.Forms.TextBox
	Friend WithEvents qOrders As System.Messaging.MessageQueue
	Friend WithEvents cmdSend As System.Windows.Forms.Button
	Friend WithEvents cmdScanQ As System.Windows.Forms.Button
	Friend WithEvents lstMessages As System.Windows.Forms.ListBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtOrderNumber = New System.Windows.Forms.TextBox()
		Me.txtCustomer = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtReqDate = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cmdSend = New System.Windows.Forms.Button()
		Me.qOrders = New System.Messaging.MessageQueue()
		Me.cmdScanQ = New System.Windows.Forms.Button()
		Me.lstMessages = New System.Windows.Forms.ListBox()
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
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(8, 8)
		Me.Label1.Name = "Label1"
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "&Order Number"
		'
		'txtOrderNumber
		'
		Me.txtOrderNumber.Location = New System.Drawing.Point(112, 8)
		Me.txtOrderNumber.Name = "txtOrderNumber"
		Me.txtOrderNumber.TabIndex = 1
		Me.txtOrderNumber.Text = "100"
		Me.txtOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtCustomer
		'
		Me.txtCustomer.Location = New System.Drawing.Point(112, 48)
		Me.txtCustomer.Name = "txtCustomer"
		Me.txtCustomer.TabIndex = 3
		Me.txtCustomer.Text = "Super Customer"
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(8, 48)
		Me.Label2.Name = "Label2"
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "&Customer"
		'
		'txtReqDate
		'
		Me.txtReqDate.Location = New System.Drawing.Point(112, 88)
		Me.txtReqDate.Name = "txtReqDate"
		Me.txtReqDate.TabIndex = 5
		Me.txtReqDate.Text = ""
		Me.txtReqDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(8, 96)
		Me.Label3.Name = "Label3"
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "&Required Date"
		'
		'cmdSend
		'
		Me.cmdSend.Location = New System.Drawing.Point(8, 128)
		Me.cmdSend.Name = "cmdSend"
		Me.cmdSend.TabIndex = 6
		Me.cmdSend.Text = "&Send Order"
		'
		'qOrders
		'
		Me.qOrders.Formatter = New System.Messaging.XmlMessageFormatter(New String(-1) {})
		Me.qOrders.Path = CType(configurationAppSettings.GetValue("qOrders.Path", GetType(System.String)), String)
		Me.qOrders.SynchronizingObject = Me
		'
		'cmdScanQ
		'
		Me.cmdScanQ.Location = New System.Drawing.Point(232, 128)
		Me.cmdScanQ.Name = "cmdScanQ"
		Me.cmdScanQ.Size = New System.Drawing.Size(216, 23)
		Me.cmdScanQ.TabIndex = 8
		Me.cmdScanQ.Text = "&List Messages in Queue"
		'
		'lstMessages
		'
		Me.lstMessages.Location = New System.Drawing.Point(232, 8)
		Me.lstMessages.Name = "lstMessages"
		Me.lstMessages.Size = New System.Drawing.Size(216, 108)
		Me.lstMessages.TabIndex = 7
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(458, 163)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstMessages, Me.cmdScanQ, Me.cmdSend, Me.txtReqDate, Me.Label3, Me.txtCustomer, Me.Label2, Me.txtOrderNumber, Me.Label1})
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

	Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
		' We create a message and then
		' post it to the Orders queue.
		' The path to the queue is stored as 
		' a dynamic property that can be changed
		' by modifying the value in the program's
		' .config file.
		Try
			' Create an object instance like normal
			Dim o As New Server.MSMQOrders()
			' Set some properties
			o.Number = CInt(Me.txtOrderNumber.Text)
			o.Customer = Me.txtCustomer.Text
			o.RequiredBy = CDate(Me.txtReqDate.Text)

			' send it to the queue
			Me.qOrders.Send(o, "New Order: " & o.Number)

			' Up our order number (not necessary, just for show)
			Me.txtOrderNumber.Text = (o.Number + 1).ToString()
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Set our Required Date to a data 5 days from today's date
		Dim d As Date = Date.Today.AddDays(5)
		Me.txtReqDate.Text = d.ToShortDateString
	End Sub

	Private Sub cmdScanQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScanQ.Click
		' Scan the queue for messages that
		' have not been received.
		' This is scan does not remove messages.
		Try
			Me.lstMessages.Items.Clear()

			Dim m As Message
			For Each m In Me.qOrders
				Me.lstMessages.Items.Add(m.Label)
			Next

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub txtOrderNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOrderNumber.Validating
		Dim txt As TextBox = CType(sender, TextBox)
		If Not IsNumeric(txt.Text) Then
			txt.Text = "1"
			MessageBox.Show("Only numbers are allowed for an Order Number. Setting value to 1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
	End Sub

	Private Sub txtReqDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtReqDate.Validating
		Dim txt As TextBox = CType(sender, TextBox)
		If Not IsDate(txt.Text) Then
			txt.Text = Date.Today.AddDays(5).ToShortDateString()
			MessageBox.Show("Only numbers are allowed for an Order Number. Setting value to : " & Me.txtReqDate.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If

	End Sub
End Class