'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class CustomerWithParameterizedProperty

	Private custAccount As String
	Private custFirstName As String
	Private custLastName As String
	Private custDefaultQuantity As Integer = 12

	' To create a parameterized property, simply add a parameter to the
	' property statement, in this case it is "Multiplier":
	Public Property DefaultQuantity(ByVal Multiplier As Integer) As Integer
		Get
			' Normally a Property Get procedure doesn't use incoming
			' parameters, but in the case of a parameterized property
			' it does. The parameter is treated just like a normal
			' passed parameter:
			Return custDefaultQuantity * Multiplier
		End Get
		Set(ByVal Value As Integer)
			custDefaultQuantity = Value
		End Set
	End Property

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
