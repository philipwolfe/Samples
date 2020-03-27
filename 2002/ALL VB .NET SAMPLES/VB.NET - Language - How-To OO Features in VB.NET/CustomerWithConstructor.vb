'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class CustomerWithConstructor

	Private custAccount As String
	Private custFirstName As String
	Private custLastName As String

	Sub New(ByVal AccountNumber As String, ByVal FirstName As String, ByVal LastName As String)

		' This is the Constructor for this class.

		Me.AccountNumber = AccountNumber
		Me.FirstName = FirstName
		Me.LastName = LastName

	End Sub

#Region "Customer Properties"
	Public Property AccountNumber() As String
		Get
			Return custAccount
		End Get
		Set(ByVal Value As String)
			custAccount = Value
		End Set
	End Property

	Public Property FirstName() As String
		Get
			Return custFirstName
		End Get
		Set(ByVal Value As String)
			custFirstName = Value
		End Set
	End Property

	Public Property LastName() As String
		Get
			Return custLastName
		End Get
		Set(ByVal Value As String)
			custLastName = Value
		End Set
	End Property
#End Region


End Class
