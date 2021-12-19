Option Strict On
Option Explicit On 

'The following Imports statements were auto-generated
Imports System
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState

'The following Imports statements were manually added
Imports System.IO               'Added for filestream objects
Imports System.Web.HttpRuntime  'Added for use of the ASP.NET cache

Public Class Global
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal Sender As Object, ByVal e As EventArgs)
        'On application startup, store a DataSet of states in the ASP.NET cache
        Call CacheStatesDataset()
    End Sub

    Sub Session_Start(ByVal Sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_BeginRequest(ByVal Sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_EndRequest(ByVal Sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Session_End(ByVal Sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Application_End(ByVal Sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub CacheStatesDataset()
        'Stores a DataSet of state names and abbreviations in the ASP.NET cache
        'This is cached because the list of valid states will be used on many web forms
        'and it does not change frequently.  The list of valid states are read in from
        'the XML document States.xml
        Dim dsStates As New DataSet()
        Dim fs As FileStream
        Dim xmlStream As StreamReader

        'Open the XML file
        fs = New FileStream(Server.MapPath("States.xml"), FileMode.Open, FileAccess.Read)

        'Read the XML document into a DataSet
        xmlStream = New StreamReader(fs)
        dsStates.ReadXml(xmlStream)

        'Close the XML file        
        fs.Close()

        'Save the DataSet in the ASP.NET cache with the key "dsStates"
        Cache.Insert("dsStates", dsStates)
    End Sub

End Class
