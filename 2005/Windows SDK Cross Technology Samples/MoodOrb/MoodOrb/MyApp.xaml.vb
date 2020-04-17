' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

Option Strict On
Option Explicit On


' Interaction logic for MyApp.xaml
Partial Public Class MyApp
    Inherits Application
    Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs) Handles Me.Startup

        

    End Sub

    Private Sub CloseHandler(ByVal sender As Object, ByVal e As EventArgs)
        Application.Current.Shutdown(0)
    End Sub

End Class

