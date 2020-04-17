' <Snippet2>
Imports System
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     

Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1.xaml
    '@ </summary>

    Partial Public Class Window1
        Inherits Window

        Dim rowDef1 As New RowDefinition
        Dim colDef1 As New ColumnDefinition

        Public Sub addCol(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim colDef1 As New ColumnDefinition
            grid1.ColumnDefinitions.Add(colDef1)
        End Sub

        Public Sub addRow(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim rowDef1 As New RowDefinition()
            grid1.RowDefinitions.Add(rowDef1)
        End Sub

        Public Sub clearCol(ByVal sender As Object, ByVal e As RoutedEventArgs)
            grid1.ColumnDefinitions.Clear()
        End Sub

        Public Sub clearRow(ByVal sender As Object, ByVal e As RoutedEventArgs)
            grid1.RowDefinitions.Clear()
        End Sub

        Public Sub removeCol(ByVal sender As Object, ByVal e As RoutedEventArgs)

            If (grid1.ColumnDefinitions.Count <= 0) Then
                tp1.Text = "No More Columns to Remove!"
            Else
                grid1.ColumnDefinitions.RemoveAt(0)
            End If
        End Sub

        Public Sub removeRow(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If (grid1.RowDefinitions.Count <= 0) Then
                tp1.Text = "No More Rows to Remove!"
            Else
                grid1.RowDefinitions.RemoveAt(0)
            End If
        End Sub

        Public Sub colCount(ByVal sender As Object, ByVal e As RoutedEventArgs)
            tp2.Text = "The current number of Columns is: " + grid1.ColumnDefinitions.Count.ToString()
        End Sub

        Public Sub rowCount(ByVal sender As Object, ByVal e As RoutedEventArgs)
            tp2.Text = "The current number of Rows is: " + grid1.RowDefinitions.Count.ToString()
        End Sub

        Public Sub rem5Col(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If (grid1.ColumnDefinitions.Count < 5) Then
                tp1.Text = "There aren't five Columns to Remove!"
            Else
                grid1.ColumnDefinitions.RemoveRange(0, 5)
            End If
        End Sub

        Public Sub rem5Row(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If (grid1.RowDefinitions.Count < 5) Then
                tp1.Text = "There aren't five Rows to Remove!"
            Else
                grid1.RowDefinitions.RemoveRange(0, 5)
            End If
        End Sub

        Public Sub containsRow(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If (grid1.RowDefinitions.Contains(rowDef1)) Then
                tp2.Text = "Grid Contains RowDefinition rowDef1"
            Else
                tp2.Text = "Grid Does Not Contain RowDefinition rowDef1"
            End If
        End Sub

        Public Sub containsCol(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If (grid1.ColumnDefinitions.Contains(colDef1)) Then
                tp3.Text = "Grid Contains ColumnDefinition colDef1"
            Else
                tp3.Text = "Grid Does Not Contain ColumnDefinition colDef1"
            End If
        End Sub

        Public Sub colReadOnly(ByVal sender As Object, ByVal e As RoutedEventArgs)
            tp4.Text = "RowDefinitionsCollection IsReadOnly?: " + grid1.RowDefinitions.IsReadOnly.ToString()
            tp5.Text = "ColumnDefinitionsCollection IsReadOnly?: " + grid1.ColumnDefinitions.IsReadOnly.ToString()
        End Sub

        Public Sub insertRowAt(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim rowDef1 As New RowDefinition
            grid1.RowDefinitions.Insert(grid1.RowDefinitions.Count, rowDef1)
            tp1.Text = "RowDefinition added at index position " + grid1.RowDefinitions.IndexOf(rowDef1).ToString()
        End Sub

        Public Sub insertColAt(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim colDef1 As New ColumnDefinition()
            grid1.ColumnDefinitions.Insert(grid1.ColumnDefinitions.Count, colDef1)
            tp2.Text = "ColumnDefinition added at index position " + grid1.ColumnDefinitions.IndexOf(colDef1).ToString()
        End Sub


    End Class
End Namespace
' </Snippet2>