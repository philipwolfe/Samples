'==========================================================================
'  File:      SendEdit.vb
'
'  Summary:   Extends the default functionality of the DataEdit control
'             by forwarding characters typed by the user to a Socket.
' 
'  Classes:   SendEdit
'
'  Functions: SetClientConnection, WndProc, OnChar
'             
'----------------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 Samples.
'
'  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
'==========================================================================+*/

Imports System
Imports System.Core
Imports System.WinForms
Imports System.Net
Imports System.Net.Sockets

Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars

Option Explicit
Option Strict Off

Public Class SendEdit
Inherits DataEdit

	Protected ClientConnection As Socket = Nothing
	
'*****************************************************************************
' Function:     SetClientConnection
'
' Abstract:     Sets the socket used for sending keystroke information to.
'			
' Input Parameters: s(Socket)
'
' Returns: void
'******************************************************************************/
	Public Sub SetClientConnection(s As Socket)	
		ClientConnection = s
	End Sub
	
'*****************************************************************************
' Function:     WndProc
'
' Abstract:     Override of the WndProc for this Edit control.  Used to 
'               process the WM_CHAR event.
'			
' Input Parameters: m(Message)
'
' Returns: void
'******************************************************************************/
	Overrides Protected Sub WndProc(ByRef m As Message)	
		Select Case m.msg
			case Microsoft.Win32.Interop.win.WM_CHAR
				If (OnChar(m.wParam, m.lParam BitAnd &HFFFF, CInt(m.lParam/&HFFFF) BitAnd &HFFFF)) Then
					Exit Sub
				End If
		End Select
		MyBase.WndProc(m)
	End Sub

'*****************************************************************************
' Function:     OnChar
'
' Abstract:     Called by the WndProc whenever a character is typed.  The
'               character is sent to the Socket hosted by this control.
'			
' Input Parameters: nChar(int), nRepCnt(int), nFlags(int)
'
' Returns: bool
'******************************************************************************/
	Protected Function OnChar(nChar As Integer, nRepCnt As Integer, nFlags As Integer) As Boolean
		OnChar = False
		Try 
			If (ClientConnection = Nothing) Then
				MessageBox.Show("No connection present.  Please click " & _
						"'Connect' button to make a connection","WinTalk")
				Exit Function
			End If
			
			Dim c As Char = Convert.ToChar(nChar)
			Dim b() As Byte = { Convert.ToByte(nChar) }

			' create a String for appending to edit control
			Dim str As String = Nothing

			If (Convert.ToInt32(c) >= asc(" ") OR c = Tab) Then
				Dim wt() As char = new char() { c }
				str = new String(wt)
			elseif (c = Cr) Then
				str = Convert.ToString(CrLf)
			elseif (c <> Back) Then ' throw out control characters
				Exit Function
			End If


			Dim i As Integer
			For i = 0 To nRepCnt-1
				ClientConnection.Send(b, b.Length, 0)
				If (c = Back) Then
					TruncateOneCharFromEnd()
				Else 
					Append(str)
				End If

			Next	
		
		catch e As Exception
		
			Console.WriteLine("Error Occured!!!")
			Console.WriteLine(e.Message)
		End Try
		
		'return false: we want the default handler to be called
	End Function
			
End Class

