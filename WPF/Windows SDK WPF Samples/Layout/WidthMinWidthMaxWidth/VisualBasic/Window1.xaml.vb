Imports System     
Imports System.Windows     
Imports System.Windows.Media     
Imports System.Windows.Controls     
Imports System.Windows.Documents     

namespace Width_MinWidth_MaxWidth

	'@ <summary>
	'@ Interaction logic for Window1.xaml
	'@ </summary>

    Partial Public Class Window1
        Inherits Window

        Public Sub changeWidth(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)
            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim sz1 As Double = Double.Parse(li.Content.ToString())
            rect1.Width = sz1
            rect1.UpdateLayout()
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth.ToString
            txt2.Text = "Width is set to " + rect1.Width.ToString
            txt3.Text = "MinWidth is set to " + rect1.MinWidth.ToString
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth.ToString
        End Sub
        Public Sub changeMinWidth(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim sz1 As Double = Double.Parse(li.Content.ToString())
            rect1.MinWidth = sz1
            rect1.UpdateLayout()
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth.ToString
            txt2.Text = "Width is set to " + rect1.Width.ToString
            txt3.Text = "MinWidth is set to " + rect1.MinWidth.ToString
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth.ToString
        End Sub
        Public Sub changeMaxWidth(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim sz1 As Double = Double.Parse(li.Content.ToString())
            rect1.MaxWidth = sz1
            rect1.UpdateLayout()
            txt1.Text = "ActualWidth is set to " + rect1.ActualWidth.ToString
            txt2.Text = "Width is set to " + rect1.Width.ToString
            txt3.Text = "MinWidth is set to " + rect1.MinWidth.ToString
            txt4.Text = "MaxWidth is set to " + rect1.MaxWidth.ToString
        End Sub
        Public Sub clipRect(ByVal sender As Object, ByVal args As RoutedEventArgs)

            myCanvas.ClipToBounds = True
            txt5.Text = "Canvas.ClipToBounds is set to " + myCanvas.ClipToBounds.ToString

        End Sub
        Public Sub unclipRect(ByVal sender As Object, ByVal args As RoutedEventArgs)

            myCanvas.ClipToBounds = False
            txt5.Text = "Canvas.ClipToBounds is set to " + myCanvas.ClipToBounds.ToString
        End Sub
    End Class
    End Namespace
