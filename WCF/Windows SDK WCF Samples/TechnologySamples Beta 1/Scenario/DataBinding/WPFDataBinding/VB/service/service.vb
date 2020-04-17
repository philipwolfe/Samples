' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.IO
Imports System.Net
Imports System.ServiceModel
Imports System.Collections

Namespace Microsoft.ServiceModel.Samples

    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.[Single])> _
    Class AlbumService
        Implements IAlbumService

        Private Sub New()

            albums = CreateList(5)
            Console.WriteLine("new session, created {0} albums", albums.Count)

        End Sub

        Public Function GetAlbumList() As Album() Implements IAlbumService.GetAlbumList

            Dim arr As Album() = New Album(albums.Count) {}
            albums.CopyTo(arr)
            Console.WriteLine("GetAlbumList(): Returned {0} albums", albums.Count)
            Return arr

        End Function

        Public Sub AddAlbum(ByVal title As String) Implements IAlbumService.AddAlbum

            Dim a As Album = CreateAlbum(title)
            albums.Add(a)
            Console.WriteLine("AddAlbum(): add album {0}", title)

        End Sub

        Private Function CreateList(ByVal numOfAlbums As Integer) As ArrayList

            Dim list As New ArrayList()
            For i As Integer = 0 To numOfAlbums - 1

                Dim a As Album = CreateAlbum("Title" + i.ToString())
                list.Add(a)

            Next
            Return list

        End Function

        Private Function CreateAlbum(ByVal title As String) As Album

            Dim a As New Album()
            a.Title = title
            a.Price = 12 + rnd.[Next](-4, +6)
            Dim tracks As New ArrayList()
            Dim maxTrack As Integer = 4 + rnd.[Next](-2, +2)
            For i As Integer = 0 To maxTrack - 1

                Dim t As New Track()
                t.Name = "Track-" + title + "-" + i.ToString()
                t.Duration = 100 + rnd.[Next](-50, +100)
                tracks.Add(t)

            Next
            Dim arr As Track() = New Track(tracks.Count) {}
            tracks.CopyTo(arr)
            a.Tracks = arr

            Return a

        End Function

        Private albums As ArrayList
        Private rnd As New Random()

    End Class

End Namespace
