Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data

	public partial class Window1 
    Inherits Window


    Sub GetIndex0(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        Dim cbi As ComboBoxItem = CType( _
                cb.ItemContainerGenerator.ContainerFromIndex(0), ComboBoxItem)

        Item.Content = "The contents of the item at index 0 are: " + _
                (cbi.Content.ToString()) + "."
    End Sub
    Sub GetIndex1(ByVal Sender As Object, ByVal e As RoutedEventArgs)
        Dim cbi As ComboBoxItem = CType( _
                cb.ItemContainerGenerator.ContainerFromIndex(1), ComboBoxItem)
        Item.Content = "The contents of the item at index 1 are: " + _
                (cbi.Content.ToString()) + "."
    End Sub
    Sub GetIndex2(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        Dim cbi As ComboBoxItem = CType( _
                cb.ItemContainerGenerator.ContainerFromIndex(2), ComboBoxItem)
        Item.Content = "The contents of the item at index 2 are: " + _
                (cbi.Content.ToString()) + "."
    End Sub
    Sub GetIndex3(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        Dim cbi As ComboBoxItem = CType( _
                cb.ItemContainerGenerator.ContainerFromIndex(3), ComboBoxItem)
        Item.Content = "The contents of the item at index 3 are: " + _
                (cbi.Content.ToString()) + "."
    End Sub


End Class