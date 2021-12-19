'==========================================================================
'  File:      ConnectDialog.vb
'
'  Summary:   WFC Dialog (implementation through the Form class).  This 
'             window displays two edit boxes (host and port), and OK and 
'             Cancel buttons.  OnCommand is overrided to correctly handle 
'             events when the respective buttons are clicked.
' 
'  Classes:   ConnectDialog
'
'  Functions: Dispose, button1_click, ConnectDialog_closing, InitForm
'             
'----------------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 Samples.
'
'  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
'==========================================================================+*/

Imports System
Imports System.WinForms
Imports System.ComponentModel
Imports System.Drawing

Option Explicit
Option Strict Off


Public Class ConnectDialog
Inherits Form

	Public host As String = Nothing
	Public port As Integer = 0
	
	Public AllowClose As Boolean = True
						 
'*****************************************************************************
' Constructor : ConnectDialog
'
' Abstract:     Constructs an instance of ConnectDialog
'			
' Input Parameters: (none)
'
'******************************************************************************/
	Public Sub New
		MyBase.New
		InitForm		
	End Sub

'*****************************************************************************
' Function :    Dispose
'
' Abstract:     Overrides Form.Dispose, cleans up the component list.
'			
' Input Parameters: (None)
'
' Returns: void
'******************************************************************************/
	Overrides Public Sub Dispose
	
		MyBase.Dispose
		components.Dispose
	End Sub

'*****************************************************************************
' Function :    button1_click
'
' Abstract:     Invoked when the "Connect" button is clicked.  Validates input
'               and stores the host and port information into member 
'               variables.
'			
' Input Parameters: source(Object), e(EventArgs)
'
' Returns: Void
'******************************************************************************/
	Private Sub button1_click(source As object, e As EventArgs)
	
		host = edit1.Text.Trim()
		if (host.Equals("")) Then
			AllowClose = false
			MessageBox.Show(Me,"Please enter a valid host","Wintalk")
			Exit Sub
		End If
		Console.WriteLine("host = " & host)
		Try 
			port = Convert.ToInt32(edit2.Text)
		
		catch Ex As Exception
			AllowClose = false
			MessageBox.Show(Me,"Please enter a valid port number","Wintalk")
			Exit Sub
		End Try
		Console.WriteLine("port = " & port.ToString())
	End Sub

'*****************************************************************************
' Function:     ConnectDialog_closing
'
' Abstract:     Invoked when the ConnectDialog is closing.  
'			
' Input Parameters: source(Object), e(EventArgs)
'
' Returns: Void
'******************************************************************************/
	Private Sub ConnectDialog_closing(source As Object, e As CancelEventArgs)
	
		if (Not AllowClose) Then
			e.Cancel = true
			AllowClose = true
		End If
	End Sub
	
	Dim components As new Container
	Dim label1 As new Label
	Dim edit1 As new TextBox
	Dim label2 As new Label
	Dim edit2 As new TextBox
	Dim button1 As new Button
	Dim button2 As new Button

'*****************************************************************************
' Function :    InitForm
'
' Abstract:     Creates UI elements (buttons, edit controls, ...) on the 
'               ConnectDialog WFC form.
'			
' Input Parameters: None
'
' Returns: Void
'******************************************************************************/
	Private Sub InitForm
	
		label1.Location = new Point(11, 12)
		label1.Size =  new Size(30, 13)
		label1.TabIndex = 4
		label1.TabStop = false
		label1.Text = "Host:"

		edit1.Location = new Point(46, 8)
		edit1.Size = new Size(245, 20)
		edit1.TabIndex = 0
		edit1.Text = "localhost"

		label2.Location = new Point(11, 38)
		label2.Size = new Size(30, 13)
		label2.TabIndex = 5
		label2.TabStop = false
		label2.Text = "Port:"

		edit2.Location = new Point(46, 34)
		edit2.Size = new Size(71, 20)
		edit2.TabIndex = 1
		edit2.Text = "5000"

		button1.Location = new Point(56, 67)
		button1.Size = new Size(81, 22)
		button1.TabIndex = 2
		button1.Text = "Connect"
		button1.DialogResult = System.WinForms.DialogResult.OK
		button1.AddOnClick(new EventHandler(AddressOf Me.button1_click))

		button2.Location = new Point(164, 67)
		button2.Size = new Size(81, 22)
		button2.TabIndex = 3
		button2.Text = "Cancel"
		button2.DialogResult = System.WinForms.DialogResult.Cancel

		Me.Text = "Connect"
		Me.AcceptButton = button1
		Me.AutoScaleBaseSize = new Size(5, 13)
		Me.BorderStyle = FormBorderStyle.FixedSingle
		Me.CancelButton = button2
		Me.ClientSize =  new Size(300, 95)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.ShowInTaskbar = false
		Me.StartPosition = FormStartPosition.CenterParent
		Me.AddOnClosing(new CancelEventHandler(AddressOf Me.ConnectDialog_closing))

		Me.Controls.All = new Control() { button2, button1, edit2, label2, edit1, label1}
	End Sub

End Class

