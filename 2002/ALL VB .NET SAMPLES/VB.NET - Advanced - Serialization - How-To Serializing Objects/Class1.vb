'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

'This class is marked as Serializable. In this example, it will be
'serialized and deserialized to and from a file. If using the Soap
'formatter, the file will be called Class1File.xml. If using the  
'Binary formatter, the file will be called Class1File.dat.
'See the Form_Load event of frmMain to change the file names.

'This attribute makes the class serializable
<Serializable()> Public Class Class1

	'All fields in this class will be serialized, regardless of scope, 
	'unless they are specifically marked as NonSerialized, like z.

	Public x As Integer
	Private y As Integer
	<NonSerialized()> Public z As Integer

	'Simple constructor to load in values for the fields.
	Public Sub New(ByVal argx As Integer, ByVal argy As Integer, ByVal argz As Integer)
		Me.x = argx
		Me.y = argy
		Me.z = argz
	End Sub

	'Property to view the value of the private field y
	Public ReadOnly Property GetY() As Integer
		Get
			Return y
		End Get
	End Property
End Class
