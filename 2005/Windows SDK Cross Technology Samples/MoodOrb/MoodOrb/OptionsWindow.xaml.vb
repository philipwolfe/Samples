' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

Option Strict On
Option Explicit On

' Interaction logic for OptionsWindow.xaml
Partial Public Class OptionsWindow
    Inherits Window

    Private m_Handler As OrbHandler

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal currentHandler As OrbHandler)

        m_Handler = currentHandler

        InitializeComponent()

	'Set the data context to the current handler so the options list can be data-bound
        Me.DataContext = currentHandler

    End Sub

    Private Sub CancelSelect(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

        Dim listOptionBox As ListBox = CType(sender, ListBox)

        'Highlighting can be canceled here if need be
    End Sub


    Private Sub DoneClicked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.DataContext = Nothing
        Me.Close()
    End Sub
End Class