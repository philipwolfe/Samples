'==========================================================================
'  File:      DataEdit.vb
'
'  Summary:   Extends the default functionality of the WFC Edit control
'             by providing two extra methods.
' 
'  Classes:   DataEdit
'
'  Functions: Append, TruncateOneCharFromEnd
'             
'----------------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 Samples.
'
'  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
'==========================================================================+*/



Imports System
Imports System.WinForms
Imports System.WinForms.Design


Option Explicit
Option Strict Off


Public class DataEdit
Inherits TextBox
	
	
'*****************************************************************************
' Function :    Append
'
' Abstract:     Appends a string to the end of the edit control
'			
' Input Parameters: str(String)
'
' Returns: void
'******************************************************************************/
	Public Sub Append(str As String)

		Dim len As Integer = Me.Text.Length
		SelectionStart = len
		SelectionLength = len
		SelectedText = str
	End Sub

'*****************************************************************************
' Function:     TruncateOneCharFromEnd
'
' Abstract:     Truncates one character from the end of the text in the edit
'               control.
'			
' Input Parameters: (none)
'
' Returns: void
'******************************************************************************/
	Public Sub TruncateOneCharFromEnd
	
		Dim len As Integer = Me.Text.Length
		if (len = 1) Then 
			Me.Text = ""
		elseif (len > 1) Then
			SelectionStart = len-1
			SelectionLength = len
			Dim s As String = SelectedText
			if (s.Equals("\n")) Then
				SelectionStart = len-2
				SelectionLength = len
			End If
			SelectedText = ""
		End If
	End Sub
		
End Class

