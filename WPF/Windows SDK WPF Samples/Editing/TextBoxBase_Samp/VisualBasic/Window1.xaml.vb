Imports System     
Imports System.Windows     
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample

    Partial Public Class Window1
        Inherits Window

        Public Sub initValues(ByVal sender As Object, ByVal e As EventArgs)
            myTB1.Text = "ExtentHeight is currently " + myTextBox.ExtentHeight.ToString()
            myTB2.Text = "ExtentWidth is currently " + myTextBox.ExtentWidth.ToString()
            myTB3.Text = "HorizontalOffset is currently " + myTextBox.HorizontalOffset.ToString()
            myTB4.Text = "VerticalOffset is currently " + myTextBox.VerticalOffset.ToString()
            myTB5.Text = "ViewportHeight is currently " + myTextBox.ViewportHeight.ToString()
            myTB6.Text = "ViewportWidth is currently " + myTextBox.ViewportWidth.ToString()
            radiobtn1.IsChecked = True
        End Sub

        Public Sub copyText(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.Copy()
        End Sub

        Public Sub cutText(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.Cut()
        End Sub

        Public Sub pasteSelection(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.Paste()
        End Sub

        Public Sub selectAll(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.SelectAll()
        End Sub

        Public Sub undoAction(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If myTextBox.CanUndo = True Then
                myTextBox.Undo()
            Else : Return
            End If
        End Sub

        Public Sub redoAction(ByVal sender As Object, ByVal e As RoutedEventArgs)

            If myTextBox.CanRedo = True Then
                myTextBox.Redo()
            Else : Return
            End If
        End Sub

        Public Sub selectChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.AppendText("Selection Changed event in myTextBox2 has just occurred.")
        End Sub

        Public Sub tChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
            myTextBox.AppendText("Text content of myTextBox2 has changed.")
        End Sub

        Public Sub wrapOff(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.TextWrapping = TextWrapping.NoWrap
        End Sub

        Public Sub wrapOn(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.TextWrapping = TextWrapping.Wrap
        End Sub

        Public Sub clearTB1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.Clear()
        End Sub

        Public Sub clearTB2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox2.Clear()
        End Sub

        Public Sub lineDown(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.LineDown()
        End Sub

        Public Sub lineLeft(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.LineLeft()
        End Sub

        Public Sub lineRight(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.LineRight()
        End Sub

        Public Sub lineUp(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.LineUp()
        End Sub

        Public Sub pageDown(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.PageDown()
        End Sub

        Public Sub pageLeft(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.PageLeft()
        End Sub

        Public Sub pageRight(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.PageRight()
        End Sub

        Public Sub pageUp(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.PageUp()
        End Sub

        Public Sub scrollHome(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.ScrollToHome()
        End Sub

        Public Sub scrollEnd(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.ScrollToEnd()
        End Sub

    End Class
End Namespace
