Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class UrlMenuItem
    Inherits ToolStripMenuItem

    Private _urlInfo As UrlInfo
    
    Public Sub New(urlInfo As UrlInfo)
        MyBase.New(urlInfo.Title)
        _urlInfo = urlInfo
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        Process.Start(_urlInfo.Url)
    End Sub
    
    Public ReadOnly Property UrlInfo() As UrlInfo
        Get
            Return _urlInfo
        End Get
    End Property

End Class