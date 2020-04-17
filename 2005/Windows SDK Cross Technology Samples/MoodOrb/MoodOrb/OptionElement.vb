' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

Option Strict On
Option Explicit On

'Class to display an option in list
Public Class OptionElement
    Inherits ItemsControl

    Private m_OptionName As String
    Public m_OptionValue As Object

    Public Sub New(ByVal optionName As String, ByVal optionValue As OrbOption)

        If optionName Is Nothing Then
            Throw New ArgumentNullException("optionName")
        End If

        If optionValue Is Nothing Then
            Throw New ArgumentNullException("optionValue")
        End If

	'Save references for later use
        m_OptionName = optionName
        m_OptionValue = optionValue

        'Create the layout elements
        Dim layoutPanel As New StackPanel
        layoutPanel.Orientation = Orientation.Horizontal
        layoutPanel.VerticalAlignment = Windows.VerticalAlignment.Center

        Dim titleBlock As New TextBlock
        titleBlock.Text = optionName + ":"
        titleBlock.Height = 14
        titleBlock.Width = 120
        titleBlock.Margin = New Thickness(4)
        titleBlock.Foreground = Brushes.White

        layoutPanel.Children.Add(titleBlock)

        'Get the specific UI for this option type
        layoutPanel.Children.Add(optionValue.GetOptionUI())

        'Add the elements to the layout of this element
        Me.AddChild(layoutPanel)
    End Sub

End Class
