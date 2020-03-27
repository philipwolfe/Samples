'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Diagnostics
Imports System.Reflection
Imports System.Text
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
    Friend WithEvents lstStackItems As System.Windows.Forms.ListBox
    Friend WithEvents btnException As System.Windows.Forms.Button
    Friend WithEvents btnStackTrace As System.Windows.Forms.Button
    Friend WithEvents chkIncludeSource As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.lstStackItems = New System.Windows.Forms.ListBox()
        Me.btnException = New System.Windows.Forms.Button()
        Me.btnStackTrace = New System.Windows.Forms.Button()
        Me.chkIncludeSource = New System.Windows.Forms.CheckBox()
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
        'lstStackItems
        '
        Me.lstStackItems.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lstStackItems.IntegralHeight = False
        Me.lstStackItems.Location = New System.Drawing.Point(184, 8)
        Me.lstStackItems.Name = "lstStackItems"
        Me.lstStackItems.Size = New System.Drawing.Size(344, 160)
        Me.lstStackItems.TabIndex = 5
        '
        'btnException
        '
        Me.btnException.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnException.Location = New System.Drawing.Point(8, 48)
        Me.btnException.Name = "btnException"
        Me.btnException.Size = New System.Drawing.Size(160, 32)
        Me.btnException.TabIndex = 4
        Me.btnException.Text = "Test Exception Handling"
        '
        'btnStackTrace
        '
        Me.btnStackTrace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnStackTrace.Location = New System.Drawing.Point(8, 8)
        Me.btnStackTrace.Name = "btnStackTrace"
        Me.btnStackTrace.Size = New System.Drawing.Size(160, 32)
        Me.btnStackTrace.TabIndex = 3
        Me.btnStackTrace.Text = "Test Procedure Stack"
        '
        'chkIncludeSource
        '
        Me.chkIncludeSource.Location = New System.Drawing.Point(8, 88)
        Me.chkIncludeSource.Name = "chkIncludeSource"
        Me.chkIncludeSource.Size = New System.Drawing.Size(160, 24)
        Me.chkIncludeSource.TabIndex = 6
        Me.chkIncludeSource.Text = "Include Source Info?"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(530, 198)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkIncludeSource, Me.lstStackItems, Me.btnException, Me.btnStackTrace})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.MinimumSize = New System.Drawing.Size(536, 232)
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

	Private Sub btnException_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnException.Click

		' You can pass an Exception object to the 
		' constructor of the StackTrace class. In that
		' case, you get information about the stack 
		' only within your code, leading up to the
		' exception. This example uses this particular
		' constructor to demonstrate using the StackTrace
		' class with an Exception object.

		Try
			ProcException1(1, 2)
		Catch exp As Exception
			GetFullStackFrameInfo(New StackTrace(exp))
		End Try
	End Sub

	' This Click event handler, along with ProcA and ProcB, 
	' allow the sample to demonstrate how you can work through
	' the stack frames at any point. In this case, the 
	' code uses the MethodInfo type to display information
	' about the current stack frame.

	Private Sub btnStackTrace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStackTrace.Click

		ProcA(1, 2, "Hello")
	End Sub

	Private Function GetFullStackFrameInfo(ByVal st As StackTrace) As String
		Dim fc As Integer = st.FrameCount
		Dim i As Integer

		' Loop through the stack frame count, 
		' starting at the current
		' procedure. You must retrieve 
		' the frames by number, using the GetFrame
		' method.
		lstStackItems.Items.Clear()
		For i = 0 To fc - 1
			lstStackItems.Items.Add( _
			 GetStackFrameInfo(st.GetFrame(i)))
		Next i
	End Function

	Private Function GetStackFrameInfo(ByVal sf As StackFrame) As String
		' Return a string containing information about a single stack frame.
		Dim pi As ParameterInfo

		Dim strParams As String
		Dim strFileName As String
		Dim i As Integer
		Dim mi As MethodInfo
		Dim typ As Type
		Dim strOut As String

		mi = CType(sf.GetMethod(), MethodInfo)

		' The following blocks don't trap all of 
		' the possible attributes you can retrieve
		' about a procedure. See the documentation
		' for the MethodInfo class for more info.
		If mi.IsPrivate Then
			strOut &= "Private "
		ElseIf mi.IsPublic Then
			strOut &= "Public "
		ElseIf mi.IsFamily Then
			strOut &= "Protected "
		ElseIf mi.IsAssembly Then
			strOut &= "Friend "
		End If

		If mi.IsStatic Then
			strOut &= "Shared "
		End If

		strOut &= mi.Name & "("

		Dim piList() As ParameterInfo = _
		 sf.GetMethod.GetParameters()

		strParams = String.Empty
		For Each pi In piList
			strParams &= String.Format(", {0} {1} As {2}", _
			 IIf(pi.ParameterType.IsByRef, "ByRef", "ByVal"), _
			 pi.Name, pi.ParameterType.Name)
		Next pi
		' Get rid of the first ", " if it exists.
		If strParams.Length > 2 Then
			strOut &= strParams.Substring(2)
		End If
		' Get the procedure's return type, and append
		' it to the output string.
		typ = mi.ReturnType
		strOut &= ") As " & typ.ToString
		Return strOut
	End Function

	' ProcException1 through 4 allow the code to demonstrate
	' the stack trace when handling an exception.

	Private Sub ProcException1(ByVal x As Integer, ByVal y As Integer)
		ProcException2("Mike", 12)
	End Sub

	Private Sub ProcException2(ByVal Name As String, ByVal Size As Long)
		ProcException3()
	End Sub

	Private Function ProcException3() As String
		Return ProcException4("mike@microsoft.com")
	End Function

	Private Function ProcException4(ByVal EmailAddress As String) As String
		Throw New ArgumentException("This is a fake exception!")
	End Function

	Private Sub ProcA(ByVal Item1 As Integer, ByRef Item2 As Integer, ByVal Item3 As String)
		Dim strResults As String = ProcB(String.Concat(Item1, Item2, Item3))
	End Sub

	Private Function ProcB(ByVal Name As String) As String
		GetFullStackFrameInfo(New StackTrace())
	End Function

End Class