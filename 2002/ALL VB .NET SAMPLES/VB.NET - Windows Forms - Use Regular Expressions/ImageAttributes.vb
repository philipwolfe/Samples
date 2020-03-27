'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class ImageAttributes
    Public Src As String
    Public Alt As String
    Public Height As String
    Public Width As String

    Sub New(ByVal strSrc As String, ByVal strAlt As String, ByVal strHeight As String, ByVal strWidth As String)
        Src = strSrc
        Width = strWidth
        Height = strHeight
        Alt = strAlt
    End Sub
End Class