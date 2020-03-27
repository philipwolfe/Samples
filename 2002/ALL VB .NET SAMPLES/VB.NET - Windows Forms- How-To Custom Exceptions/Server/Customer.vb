'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class Customer
	' In real life we'd use property procedures.
	Public Id As Integer
	Public FirstName As String
	Public LastName As String

	Public Shared Function EditCustomer(ByVal Id As Integer) As Customer
		' Pretend we look for the customer in our database
		' We can't find it, so we notify our caller in a way in 
		' which they can't ignore us.

		Dim strMsg As String
		strMsg = String.Format("The customer you requested by Id {0} could not be found.", Id)

		' Create the exception.
		Dim exp As New CustomerNotFoundException(strMsg)
		' Throw it to our caller
		Throw exp

	End Function

	Public Shared Sub DeleteCustomer(ByVal Id As Integer)
		' Pretend we find the customer in the database
		' but realize we shouldn't delete them, maybe for
		' security reasons.

		Dim c As New Customer()
		With c
			.Id = Id
			.FirstName = "Joe"
			.LastName = "Smith"
		End With

		' This could fail if we don't have rights.
		Dim strUser As String
		Try
			strUser = System.Environment.UserDomainName & "\" & System.Environment.UserName
		Catch pexp As Exception
			strUser = "Unavailable"
		End Try

		Dim strMsg As String
		strMsg = String.Format("The customer you requested {0} {1} could not be deleted. Your account '{2}' does not have permission.", c.FirstName, c.LastName, strUser)

		Dim exp As New CustomerNotDeletedException(strMsg, c, strUser)
		exp.LogError()

		Throw exp

	End Sub
End Class

' This exception provides the base for
' our CRM system. In large projects
' it would be defined in its own assembly for
' ease of versioning and enhancement.
Public Class CRMSystemException
	Inherits System.ApplicationException

	Private m_AppSource As String

	Public Sub New(ByVal Message As String)
		MyBase.New(Message)
		Me.m_AppSource = "SomeCompany CRM System"
	End Sub

	' We only want this method exposed to code
	' in the same assembly. However, we might need to 
	' change the scope if this class were in another
	' assembly.
	Friend Sub LogError()
		Dim e As System.Diagnostics.EventLog
		e = New System.Diagnostics.EventLog("Application")
		e.Source = Me.AppSource
		e.WriteEntry(Me.Message, System.Diagnostics.EventLogEntryType.Error)
		e.Dispose()
	End Sub

	' We're exposing a generic 'company' source
	' that children can override if they want.
	Public Overridable ReadOnly Property AppSource() As String
		Get
			Return m_AppSource
		End Get
	End Property
End Class

' Base exception for our Customer module.
' All Customer exceptions will expose a Customer
' reference via the read only property CustomerInfo.
' Note however in some cases it will be Nothing.
Public Class CustomerException
	Inherits CRMSystemException

	Private m_AppSource As String

	Private m_Customer As Customer

	Public Sub New(ByVal Message As String, ByVal ReqCustomer As Customer)
		MyBase.New(Message)
		Me.m_Customer = ReqCustomer
		Me.m_AppSource = "SomeCompany CRM Customer Module"
	End Sub

	Public ReadOnly Property CustomerInfo() As Customer
		Get
			Return MyClass.m_Customer
		End Get
	End Property

	' We wan't exceptions at this level to use
	' our AppSource, not our parents which becomes
	' important when someone calls LogError.
	Public Overrides ReadOnly Property AppSource() As String
		Get
			Return Me.m_AppSource
		End Get
	End Property
End Class

' Simple exception
Public Class CustomerNotFoundException
	Inherits CustomerException

	Public Sub New(ByVal Message As String)
		' We pass Nothing for the Customer
		' since we couldn't find them.
		MyBase.New(Message, Nothing)
	End Sub
End Class

' This exception exposes a custom user id property
' that is initialized at construction.
Public Class CustomerNotDeletedException
	Inherits CustomerException

	Private m_UserId As String

	Public Sub New(ByVal Message As String, ByVal ReqCustomer As Customer, ByVal UserId As String)
		MyBase.New(Message, ReqCustomer)
		Me.m_UserId = UserId
	End Sub

	Public ReadOnly Property UserId() As String
		Get
			Return MyClass.m_UserId
		End Get
	End Property

End Class

' Custom exceptions don't need to be complicated.
' Note this exeption might be defined in another assembly.
Public Class EmployeeException
	Inherits CRMSystemException
	Public Sub New(ByVal Message As String)
		MyBase.New(Message)
	End Sub
End Class
