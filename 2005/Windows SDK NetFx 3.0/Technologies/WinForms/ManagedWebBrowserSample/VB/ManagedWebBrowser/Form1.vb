 '---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.IO


'/ <summary>
'/ Summary description for form.
'/ </summary>
'/ 
<ComVisible(True)> Partial Public Class Form1
    Inherits System.Windows.Forms.Form '
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    Private fs As FileStream


    Public Sub New()
        InitializeComponent()

    End Sub 'New



    Public Sub Welcome(ByVal userName As String)
        ' Simply echo out the name that the user typed in the input box of the HTML page
        If System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft = True Then
            MessageBox.Show("Hello " + userName, "Managed Web Browser Sample", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign Or MessageBoxOptions.RtlReading)
        Else
            MessageBox.Show("Hello " + userName, "Managed Web Browser Sample", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub 'Welcome

    Private Sub backButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles backButton.Click
        ' Navigate the Web Browser control backward
        webBrowser1.GoBack()

    End Sub

    Private Sub forwardButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles forwardButton.Click
        ' Navigate the Web Browser control forward
        webBrowser1.GoForward()

    End Sub

    Private Sub stopButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles stopButton.Click
        ' Send the stop command to the Web Browser control
        webBrowser1.Stop()

    End Sub

    Private Sub refreshButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles refreshButton.Click
        ' Refresh the page currently loaded in the Web Browser control
        webBrowser1.Refresh()

    End Sub

    Private Sub homeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles homeButton.Click
        ' Navigate home
        webBrowser1.GoHome()

    End Sub

    Private Sub goButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles goButton.Click
        ' Navigate the Web Browser control to the URL indicated in the toolStripTextBox
        If urlAddress.Text.Length <> 0 Then
            webBrowser1.Navigate(urlAddress.Text)
        End If

    End Sub

    Private Sub loadScriptButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loadScriptButton.Click
        ' This is the handler for loading the script into the Web Browser control and allowing us to interact
        ' between the script in the browser control and this form class

        ' Set the ObjectForScripting property of the Web Browser control to point to this form class
        ' This will allow us to interact with methods in this form class via the window.external property 
        webBrowser1.ObjectForScripting = Me

        ' Load the script into the Web Browser by setting the DocumentText property
        ' Note that we will pass the userName value in the input box to the underlying form class method by hooking
        ' the OnClick event and pointing to the Welcome() method via the window.external property
        webBrowser1.DocumentText = "<html><body>" + "Please enter your name:<br/>" + "<input type='text' name='Name'/><br/>" + "<a href='http://www.microsoft.com' " + "onClick='window.external.Welcome(Name.value)'>" + "Send input to method of Form class</a></body></html>"

    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles browseButton.Click

        ' Set up the properties for the OpenFile dialog.  Restrict to HTM and HTML files
        openFileDialog1.Filter = "HTML Files (*.html) | *.html|HTM Files (*.htm) | *.htm"

        ' Prompt the user to choose an HTML file
        openFileDialog1.ShowDialog()

        ' Poke the chosen filename into the TextBox on the form
        htmlFileName.Text = Me.openFileDialog1.FileName

        If (htmlFileName.Text <> String.Empty) Then
            ' Open the file that the user selected
            fs = New FileStream(htmlFileName.Text, FileMode.Open)

            ' Load the HTML file stream into the Web Browser control
            webBrowser1.DocumentStream = fs
            Me.openFileDialog1.Reset()
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, MyBase.Load, MyBase.Load, MyBase.Load

        ' Navigate to our home page by default on startup
        webBrowser1.GoHome()

    End Sub

    Private Sub webBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles webBrowser1.DocumentCompleted
        If Not (Me.fs Is Nothing) Then
            Me.fs.Close()
        End If
    End Sub
End Class 'Form1 
