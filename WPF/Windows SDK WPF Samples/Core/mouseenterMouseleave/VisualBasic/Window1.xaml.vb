Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Input

Namespace WCSamples
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
        ' raised when mouse cursor enters the are occupied by the element
        Sub OnMouseEnterHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
            border1.Background = Brushes.Red
        End Sub
        ' raised when mouse cursor leaves the are occupied by the element
        Sub OnMouseLeaveHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
            border1.Background = Brushes.White
        End Sub
    End Class
End Namespace

