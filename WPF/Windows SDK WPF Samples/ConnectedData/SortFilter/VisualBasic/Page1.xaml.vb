Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Markup

Public Class SortFilter
    Inherits DockPanel

    Public Function Contains(ByVal de As Object) As Boolean
        Dim order1 As Order = TryCast(de, Order)
        Return (order1.Filled Is "No")
    End Function

    Public myCollectionView As ListCollectionView
    Public o As Order

    Public Sub StartHere(ByVal sender As Object, ByVal args As DependencyPropertyChangedEventArgs)
        Me.myCollectionView = DirectCast(CollectionViewSource.GetDefaultView(Me.rootElement.DataContext), ListCollectionView)
    End Sub

    Public Sub OnClick(ByVal sender As Object, ByVal args As RoutedEventArgs)
        Dim button1 As Button = TryCast(sender, Button)
        Me.myCollectionView.SortDescriptions.Clear()
        Select Case button1.Name.ToString
            Case "orderButton"
                Me.myCollectionView.SortDescriptions.Add(New SortDescription("OrderItem", ListSortDirection.Ascending))
            Case "customerButton"
                Me.myCollectionView.SortDescriptions.Add(New SortDescription("Customer", ListSortDirection.Ascending))
            Case "nameButton"
                Me.myCollectionView.SortDescriptions.Add(New SortDescription("Name", ListSortDirection.Ascending))
            Case "idButton"
                Me.myCollectionView.SortDescriptions.Add(New SortDescription("Id", ListSortDirection.Ascending))
            Case "filledButton"
                Me.myCollectionView.SortDescriptions.Add(New SortDescription("Filled", ListSortDirection.Ascending))
        End Select
    End Sub


    Public Sub OnBrowse(ByVal sender As Object, ByVal args As RoutedEventArgs)
        Dim button1 As Button = TryCast(sender, Button)
        Select Case button1.Name
            Case "Previous"
                If Me.myCollectionView.MoveCurrentToPrevious Then
                    Me.feedbackText.Text = ""
                    Me.o = TryCast(Me.myCollectionView.CurrentItem, Order)
                Else
                    Me.myCollectionView.MoveCurrentToFirst()
                    Me.feedbackText.Text = "At first record"
                End If
            Case "Next"
                If Me.myCollectionView.MoveCurrentToNext Then
                    Me.feedbackText.Text = ""
                    Me.o = TryCast(Me.myCollectionView.CurrentItem, Order)
                Else
                    Me.myCollectionView.MoveCurrentToLast()
                    Me.feedbackText.Text = "At last record"
                End If
        End Select
    End Sub

    Public Sub OnFilter(ByVal sender As Object, ByVal args As RoutedEventArgs)
        Dim button1 As Button = TryCast(sender, Button)
        Select Case button1.Name
            Case "Filter"
                Me.myCollectionView.Filter = New Predicate(Of Object)(AddressOf Me.Contains)
            Case "Unfilter"
                Me.myCollectionView.Filter = Nothing
        End Select
    End Sub

End Class
