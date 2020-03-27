'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class Customers

	' The first thing to do when building a CollectionBase class is
	' to inherit from System.Collections.CollectionBase
	Inherits System.Collections.CollectionBase

	Public Overloads Function Add(ByVal Value As Customer) As Customer

		' After you inherit the CollectionBase class, 
		' you can access an intrinsic object
		' called InnerList that represents your 
		' collection. InnerList is of type ArrayList.
		Me.InnerList.Add(Value)
		Return Value

	End Function

	Public Overloads Function Add(ByVal FirstName As String, ByVal LastName As String, ByVal AccountNum As String) As Customer
		Dim cust As New Customer()

		cust.FirstName = FirstName
		cust.LastName = LastName
		cust.AccountNumber = AccountNum

		' When you use the InnerList.Add method, you must
		' pass it an object to add to the collection. In this
		' case we've created a new Customer object based on
		' passed parameters, and now we're adding it to the
		' InnerList.
		Me.InnerList.Add(cust)

		Return cust

	End Function

	Public Overloads Function Item(ByVal Index As Integer) As Customer

		' To retrieve an item from the InnerList, pass
		' the index of that item to the .Item property.

		Return CType(Me.InnerList.Item(Index), Customer)
	End Function

	Public Overloads Function Item(ByVal cust As Customer) As Customer

		' To retrieve an item from the InnerList, pass
		' the index of that item to the .Item property.

		Dim myIndex As Integer

		myIndex = Me.InnerList.IndexOf(cust)
		Return CType(Me.InnerList.Item(myIndex), Customer)

	End Function

	Public Overloads Sub Remove(ByVal cust As Customer)

		' To remove an item from the collection, you must
		' pass in a reference to that item (in this case, the
		' Customer object we want to remove).

		' However, it is often more convenient to create a
		' Remove method that allows the calling code to pass in 
		' only the index of the item instead of an object reference.
		' So we've overloaded the Remove method to use either one.
		Me.InnerList.Remove(cust)
	End Sub

	Public Overloads Sub Remove(ByVal Index As Integer)

		' This is the second Remove method. Instead of passing
		' in an object reference, this Remove expects an index.

		' The calling code can decide which one to call.

		' If the calling code passes an index, you can simply
		' look up that item by using the InnerList.Item method,
		' then remove the item.

		Dim cust As Customer

		cust = CType(Me.InnerList.Item(Index), Customer)
		If Not cust Is Nothing Then
			Me.InnerList.Remove(cust)
		End If
	End Sub

End Class
