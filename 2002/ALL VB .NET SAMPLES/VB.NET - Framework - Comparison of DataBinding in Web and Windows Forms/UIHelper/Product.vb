'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' The Product class is a custom type that is used for databinding to a ComboBox.
' Notice the use of public properties instead of merely public fields. You might
' think you could use the following construct:
'
'   Public Class Product
'       Public ID As Integer
'       Public Name As String

'       Sub New(ByVal intID As Integer, ByVal strName As String)
'           ID = intID
'           Name = strName
'       End Sub
'   End Class
'
' This will, however, throw a runtime InvalidArgumentException stating that it 
' cannot bind to the new DisplayMember. The Property does not have to be 
' ReadOnly.
Public Class Product
    Dim _ID As Integer
    Dim _Name As String

    Sub New(ByVal intID As Integer, ByVal strName As String)
        _ID = intID
        _Name = strName
    End Sub

    Public ReadOnly Property ID() As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property
End Class