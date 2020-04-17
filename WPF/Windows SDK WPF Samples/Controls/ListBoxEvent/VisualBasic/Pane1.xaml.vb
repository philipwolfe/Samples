Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Collections.ObjectModel

Namespace ListBox_vb

    Public Class myColors
        Inherits ObservableCollection(Of String)

        Public Sub New()

            Add("LightBlue")
            Add("Pink")
            Add("Red")
            Add("Purple")
            Add("Blue")
            Add("Green")

        End Sub
    End Class

    Partial Class Pane1
        Sub PrintText(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

            Dim lbsender As ListBox
            Dim li As ListBoxItem

            lbsender = CType(sender, ListBox)
            li = CType(lbsender.SelectedItem, ListBoxItem)
            tb.Text = "   You selected " & li.Content.ToString & "."
        End Sub
    End Class

End Namespace