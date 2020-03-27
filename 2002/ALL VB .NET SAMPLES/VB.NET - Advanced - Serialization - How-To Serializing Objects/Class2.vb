'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

'This class is marked as Serializable. Additionally, this class implements
'ISerializable, which allows for custom Serialization. ISerializable requires
'implementation of the GetObjectData method, as well as an additional constructor
'that will be called on Deserialization.

'In this example, it will be serialized and deserialized to and from a file. 
'If using the Soap formatter, the file will be called Class1File.xml. If using 
'the Binary formatter, the file will be called Class1File.dat.
'See the Form_Load event of frmMain to change the file names.

Imports System.Runtime.Serialization 'Namespace for ISerializable

'This attribute makes the class serializable
<Serializable()> Public Class Class2
    Implements ISerializable

	'Because custom serialization is being used in this example, the NonSerialized
    'attribute is not enforced. Instead, the writer of the class determines what is
    'and isn't serialized, based on the GetObjectData method below. Note that in this
    'class, even though z is marked as NonSerialized, the field is serialized anyway.

    Public x As Integer
    Private y As Integer
    <NonSerialized()> Public z As Integer


    'Simple constructor to load in values for the fields.
	Public Sub New(ByVal argx As Integer, ByVal argy As Integer, ByVal argz As Integer)
		Me.x = argx
		Me.y = argy
		Me.z = argz
	End Sub

	'This is the special constructor called during 
	'deserialization. Note that both fields and custom
	'information (like a time stamp) can be serialized.
	Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)

		Me.x = info.GetInt32("x")
		Me.y = info.GetInt32("y")
		Me.z = info.GetInt32("z")
		Dim d As Date = info.GetDateTime("TimeStamp")
	End Sub

	'Property to view the value of the private field y
	Public ReadOnly Property GetY() As Integer
		Get
			Return y
		End Get
	End Property

	'This method controls how the fields will be serialized
	'You can pass in current values (like x & z) or some other value 
	'(like y). You can also serialize other items, even if there are 
	'no fields that they represent (like 'TimeStamp').
	Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
		With info
			.AddValue("x", Me.x)
			.AddValue("y", -1)
			.AddValue("z", Me.z)
			.AddValue("TimeStamp", Date.Now)
		End With
	End Sub
End Class