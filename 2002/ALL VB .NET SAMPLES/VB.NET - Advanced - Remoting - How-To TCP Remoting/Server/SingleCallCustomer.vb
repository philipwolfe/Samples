'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Namespace RemotingSample
	Public Class SingleCallCustomer
		Inherits MarshalByRefObject

		'Private fields for storage of property values of customer
		Private m_Age As Byte = 0
		Private m_Name As String = "<<Uninitialized>>"

		' Private field to store time object instance was created.
		Private ReadOnly mdteCreationTime As DateTime = Date.Now

		'Default no argument constructor
		Public Sub New()
			MyBase.New()
		End Sub

		'Property implementation for Age
		Public Property Age() As Byte
			Get
				Return m_Age
			End Get

			Set(ByVal Value As Byte)
				If Value > 0 Then
					m_Age = Value
				Else
					m_Age = 0
				End If
			End Set
		End Property

		'Property implementation for Name
		Public Property Name() As String
			Get
				Return m_Name
			End Get
			Set(ByVal Value As String)
				m_Name = Value
			End Set
		End Property

		' Accept changes to the Name & Age and return the values as a string
		Public Function UpdateCustomerInfo(ByVal NewName As String, ByVal NewAge As Byte) As String
			' Update local properties
			Me.Name = NewName
			Me.Age = NewAge

			' Do some work here like update a database (an exercise for the reader).

			Return String.Format("Customer Name is {0}. Customer Age is {1}", Me.Name, Me.Age)
		End Function

		' The following properties are for getting information about the component
		' for testing purposes only. Some information is retrieved using the
		' AssemblyInfo class (defined in the AssemblyInfo.vb file).
		' All the members are decorated with the Debug keyword to designate their
		' testing status and to make them easy to find in IntelliSense.

		' The CodeBase will return the physical path from which the 
		' component is running.
		Public ReadOnly Property DebugCodeBase() As String
			Get
				Dim ainfo As New AssemblyInfo()
				Return ainfo.CodeBase
			End Get
		End Property

		' Returns the assembly's fully qualified name
		Public ReadOnly Property DebugFQName() As String
			Get
				Dim ainfo As New AssemblyInfo()
				Return ainfo.AsmFQName
			End Get
		End Property

		' Returns the date & time the current object instance was created.
		Public ReadOnly Property DebugCreationTime() As DateTime
			Get
				Return mdteCreationTime
			End Get
		End Property

		' Returns the name of the machine that the object is running on.
		Public ReadOnly Property DebugHostName() As String
			Get
				Return System.Environment.MachineName
			End Get
		End Property
	End Class
End Namespace
