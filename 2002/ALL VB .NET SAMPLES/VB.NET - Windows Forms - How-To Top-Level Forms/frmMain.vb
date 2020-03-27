'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
	Inherits System.Windows.Forms.Form

	' These Custom events ared used to notify the Forms class
	' when the user cancels a Save during the Form_Closing event or
	' when they chose Exit from the File menu.
	Public Event SaveWhileClosingCancelled As System.EventHandler
	Public Event ExitApplication As System.EventHandler

	Private m_Dirty As Boolean = False
	Private m_ClosingComplete As Boolean = False
	Private m_DocumentName As String
	Private m_FileName As String

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

		' The title for the Form will be set differenly in this
		' How-to than others you might look at.

		' Me.Text = ainfo.Title
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
	Friend WithEvents sbDocInfo As System.Windows.Forms.StatusBar
	Friend WithEvents txtData As System.Windows.Forms.TextBox
	Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
	Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
	Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
	Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.sbDocInfo = New System.Windows.Forms.StatusBar()
		Me.txtData = New System.Windows.Forms.TextBox()
		Me.mnuNew = New System.Windows.Forms.MenuItem()
		Me.mnuSave = New System.Windows.Forms.MenuItem()
		Me.MenuItem2 = New System.Windows.Forms.MenuItem()
		Me.mnuClose = New System.Windows.Forms.MenuItem()
		Me.MenuItem1 = New System.Windows.Forms.MenuItem()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuClose, Me.MenuItem1, Me.mnuSave, Me.MenuItem2, Me.mnuExit})
		Me.mnuFile.Text = "&File"
		'
		'mnuExit
		'
		Me.mnuExit.Index = 5
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
		'sbDocInfo
		'
		Me.sbDocInfo.Location = New System.Drawing.Point(0, 213)
		Me.sbDocInfo.Name = "sbDocInfo"
		Me.sbDocInfo.Size = New System.Drawing.Size(458, 22)
		Me.sbDocInfo.TabIndex = 0
		Me.sbDocInfo.Text = "Ready"
		'
		'txtData
		'
		Me.txtData.Dock = System.Windows.Forms.DockStyle.Fill
		Me.txtData.Multiline = True
		Me.txtData.Name = "txtData"
		Me.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtData.Size = New System.Drawing.Size(458, 213)
		Me.txtData.TabIndex = 1
		Me.txtData.Text = ""
		'
		'mnuNew
		'
		Me.mnuNew.Index = 0
		Me.mnuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
		Me.mnuNew.Text = "&New"
		'
		'mnuSave
		'
		Me.mnuSave.Index = 3
		Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
		Me.mnuSave.Text = "&Save"
		'
		'MenuItem2
		'
		Me.MenuItem2.Index = 4
		Me.MenuItem2.Text = "-"
		'
		'mnuClose
		'
		Me.mnuClose.Index = 1
		Me.mnuClose.Text = "&Close"
		'
		'MenuItem1
		'
		Me.MenuItem1.Index = 2
		Me.MenuItem1.Text = "-"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(458, 235)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtData, Me.sbDocInfo})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title is set a load time"
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
#End Region


	Public ReadOnly Property ClosingComplete() As Boolean
		Get
			Return m_ClosingComplete
		End Get
	End Property

	Public ReadOnly Property DocumentName() As String
		Get
			Return m_DocumentName
		End Get
	End Property

	Public Property Dirty() As Boolean
		' This property is used in order to determine if
		' we need to save our data before we close the form.
		Get
			Return m_Dirty
		End Get
		Set(ByVal Value As Boolean)
			If Value Then
				If Not Me.Text.EndsWith("*") Then
					Me.Text = Me.Text & "*"

					Me.sbDocInfo.Text = "Changes need to be saved."
				End If
			Else
				Me.sbDocInfo.Text = "Ready"
				' Remove the *
				Me.Text = Me.Text.Substring(0, (Me.Text.Length - 1))
			End If

			m_Dirty = Value
		End Set
	End Property

	Public Property FileName() As String
		Get
			Return m_FileName
		End Get
		Set(ByVal Value As String)
			m_FileName = Value
			m_DocumentName = System.IO.Path.GetFileNameWithoutExtension(m_FileName)
			Me.Text = Me.DocumentName
		End Set
	End Property

	Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		Try
			' Set our ClosingComplete Property to true
			' to let the Forms class know it can remove 
			' us from its collection
			m_ClosingComplete = True

			If Me.Dirty Then
				' Ask the use to Save (Yes), Not Save (No), or Stop the closing (Cancel)
				Dim strDocTitle As String
				If Me.Text.EndsWith("*") Then
					strDocTitle = Me.Text.Substring(0, (Me.Text.Length - 1))
				Else
					strDocTitle = Me.Text
				End If

				Dim strMsg As String = String.Format("Do you want to save {0}?", strDocTitle)

				Select Case MessageBox.Show(strMsg, "Closing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
					Case DialogResult.Yes
						' Save the document
						Me.SaveDocument()

					Case DialogResult.No
						' Don't save the document just exit
						' Put your code here

					Case DialogResult.Cancel
						' Stop the form from closing.
						e.Cancel = True
						' If the user cancel's the close, we need to keep
						' our form in the main Forms collection
						m_ClosingComplete = False
						' Raise an event to stop the application 
						' from closing any other open documents
						RaiseEvent SaveWhileClosingCancelled(Me, Nothing)

				End Select
			End If
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Exit the application
		RaiseEvent ExitApplication(Me, Nothing)
	End Sub

	Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
		' Create a new document instnace
		Forms.NewForm()
	End Sub

	Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
		Me.SaveDocument()
	End Sub

	Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
		Me.Close()
	End Sub

	Private Sub txtData_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtData.TextChanged
		' If the data is changed, set the form's dirty property to true
		Me.Dirty = True
	End Sub

	Private Sub SaveDocument()
		' This code DOES NOT perform any file I/O. 
		Try
			' Check to see if the document is dirty
			If Me.Dirty Then
				' Check to see if we have a file (document) name already
				If Not Me.FileName Is Nothing Then
					' Save the existing document to the file
				Else
					' We don't have a file name, ask for one.
					' See the Common Dialog How-to for an example of
					' Use the Save Common Dialog

					' We're going to create a file name based upon the document
					' title and the current application's directory
					Me.FileName = AppDomain.CurrentDomain.BaseDirectory & "Saved" & Me.Text
				End If

				' Once the document has been saved, reset the dirty bit
				Me.Dirty = False
			End If
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

End Class

Public Class Forms
	' Internal Collection to manage list of document forms.
	' Other forms such as the About form will not be in 
	' this list, only frmMain which is our 'document' screen.
	Private Shared m_Forms As New Collection()
	' Internal counter for use in creating a default title
	' for each new form
	Private Shared m_FormsCreated As Integer = 0
	' This property is used in order to determine if
	' we need to stop application shutdown if the user
	' clicks the cancel button on the Save document
	' dialog displayed by forms that have dirty content.
	Private Shared m_CancelExit As Boolean = False
	' Used to check if a shutdown is in progress
	Private Shared m_ShutdownInProgress As Boolean = False

	' Number of forms currently loaded
	Public Shared ReadOnly Property Count() As Integer
		Get
			Return m_Forms.Count
		End Get
	End Property

	Public Shared Sub Main()
		' Open the first document window
		Try
			Forms.NewForm()
		Catch exp As Exception
			' if we get here, we're in trouble.
			MessageBox.Show("Sorry, we were unable to load a document. Good Bye.", "Application Main", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Application.Exit()
		End Try

		' Set the main thread to run outside the control
		' of a particular form so that closing one document
		' does not terminate the whole process.
		Application.Run()
	End Sub

	Public Shared Sub NewForm()
		Try
			Forms.m_FormsCreated += 1
			Dim frm As New frmMain()
			frm.Text = "Document" & Forms.m_FormsCreated.ToString()
			m_Forms.Add(frm, frm.GetHashCode.ToString())
			' Hook the new form's Closed event so that we know when
			' the they close the document window
			AddHandler frm.Closed, AddressOf Forms.frmMain_Closed
			' Hook the custom SaveWhileClosingCancelled so that we know if the
			' use clicks the Cancel button when prompted to save a dirty document.
			AddHandler frm.SaveWhileClosingCancelled, AddressOf Forms.frmMain_SaveWhileClosingCancelled
			' Hook the custom ExitApplicaiton so that we know if a user wants to 
			' shut down the application by selecting the Exit menu item from a document form.
			AddHandler frm.ExitApplication, AddressOf Forms.frmMain_ExitApplication

			' Make the form visible
			frm.Show()

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
			If Forms.Count = 0 Then
				' Rethrow the error to Main so
				' we can shut down the process
				Throw exp
			End If
		End Try
	End Sub

	Private Shared Sub FormClosed(ByVal frm As frmMain)
		' Remove the form that has closed from the internal collection.
		m_Forms.Remove(frm.GetHashCode.ToString())

		' If we have no more forms, shut down the process.
		If m_Forms.Count = 0 Then
			Application.Exit()
		End If
	End Sub

	Public Shared Sub ExitApp()
		Try
			m_ShutdownInProgress = True

			' Shutdown once all the forms have been closed.
			Dim frm As frmMain
			Dim i As Integer

			' Loop through the collection stepping backwards
			' one form at a time, asking each form to close
			' itself. Only ask form's that are dirty that way
			' if the user says Cancel, we won't close open forms.
			For i = m_Forms.Count To 1 Step -1
				frm = CType(m_Forms(i), frmMain)
				If frm.Dirty Then
					frm.Close()
				End If

				' Check our internal flag in case
				' the user wants to stop the shutdown.
				If m_CancelExit = True Then
					m_CancelExit = False
					Exit Sub
				End If
			Next

			' Now close any of documents that aren't dirty.
			' At this point no other windows will cancel
			' the shutdown.
			If m_Forms.Count > 0 Then
				For i = m_Forms.Count To 1 Step -1
					frm = CType(m_Forms(i), frmMain)
					frm.Close()
				Next
			End If
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
			' Bug out if we get an error here
			Application.Exit()
		Finally
			m_ShutdownInProgress = False
		End Try
	End Sub

	Private Shared Sub frmMain_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
		Try
			' We catch this event when a form has finished closing.
			Dim frm As frmMain = CType(sender, frmMain)

			' Remove our event handlers we added when the form was created.
			RemoveHandler frm.Closed, AddressOf Forms.frmMain_Closed
			RemoveHandler frm.SaveWhileClosingCancelled, AddressOf Forms.frmMain_SaveWhileClosingCancelled
			RemoveHandler frm.ExitApplication, AddressOf Forms.frmMain_ExitApplication

			' Call our function to clean up
			Forms.FormClosed(frm)
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

	End Sub

	Private Shared Sub frmMain_SaveWhileClosingCancelled(ByVal sender As Object, ByVal e As System.EventArgs)
		' This event will be caught if the user clicks cancel
		' when asked to save a dirty document.
		If m_ShutdownInProgress Then
			' Only change our internal value if
			' we're actually in the process of shutting down.
			Forms.m_CancelExit = True
		End If

	End Sub

	Private Shared Sub frmMain_ExitApplication(ByVal sender As Object, ByVal e As System.EventArgs)
		' This event will be caught if the user clicks the
		' Exit menu command.
		Forms.ExitApp()
	End Sub

End Class