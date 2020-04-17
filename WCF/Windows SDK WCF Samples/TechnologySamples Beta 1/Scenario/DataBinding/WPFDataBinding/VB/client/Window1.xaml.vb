' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.Windows.Threading
Imports Microsoft.ServiceModel.Samples

Namespace AlbumClient

    Public Class Window1
        Inherits System.Windows.Window

        Private client As New AlbumServiceClient()

        Public Sub New()

            InitializeComponent()

        End Sub

        Protected Overloads Overrides Sub OnInitialized(ByVal e As EventArgs)

            MyBase.OnInitialized(e)

            ' Bind the data returned from the service to the myPanel UI element
            client.BeginGetAlbumList(AddressOf GetAlbumListComplete, Nothing)

        End Sub

        Protected Overloads Overrides Sub OnClosed(ByVal e As EventArgs)

            MyBase.OnClosed(e)

            ' Clean up client when Window closes
            ' Closing the client gracefully closes the connection and cleans up resources
            client.Close()

        End Sub

        Private Sub OnAddNew(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Dim value As String = newAlbumName.Text
            client.BeginAddAlbum(value, AddressOf AddAlbumComplete, Nothing)

            ' Bind the data returned from the service to the myPanel UI element
            myPanel.DataContext = client.BeginGetAlbumList(AddressOf GetAlbumListComplete, Nothing)

        End Sub

        Private Sub AddAlbumComplete(ByVal ar As IAsyncResult)

            client.EndAddAlbum(ar)
            client.BeginGetAlbumList(AddressOf GetAlbumListComplete, Nothing)

        End Sub

        ' Show the result when call to web service completes
        Private Sub GetAlbumListComplete(ByVal ar As IAsyncResult)

            'This call back is not coming on the ui thread, so we must use the
            'Dispatcher to invoke on the ui thread
            Dispatcher.Invoke(DispatcherPriority.Normal, New AsyncCallback(AddressOf BindResults), ar)

        End Sub

        Private Sub BindResults(ByVal ar As IAsyncResult)

            myPanel.DataContext = client.GetAlbumList()

        End Sub

    End Class

    Public Class TextLen2Bool
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert

            Dim text As String = DirectCast(value, String)
            Return (text.Length > 0)

        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack

            Return Nothing

        End Function

    End Class

End Namespace