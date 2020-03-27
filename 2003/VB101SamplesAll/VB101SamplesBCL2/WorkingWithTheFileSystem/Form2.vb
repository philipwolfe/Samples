Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Partial Public Class Form2
    Inherits Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
End Class
