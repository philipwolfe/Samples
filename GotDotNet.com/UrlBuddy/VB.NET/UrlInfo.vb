Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class UrlInfo

    Public Url As String
    Public Title As String
    
    Public Sub New()
    End Sub

    Public Sub New(url As String)
        MyClass.New(url, url)
    End Sub

    Public Sub New(ByVal aUrl As String, ByVal aTitle As String)
        Url = aUrl
        Title = aTitle
    End Sub

End Class