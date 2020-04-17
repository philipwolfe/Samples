' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Windows.Forms

Namespace Microsoft.ServiceModel.Samples

    Public Class Form1

        ' keep the client around for the lifetime of the form
        Private client As New WeatherServiceClient()

        Private Sub GetWeatherComplete(ByVal ar As IAsyncResult)

            If Me.InvokeRequired Then

                Me.Invoke(New AsyncCallback(AddressOf GetWeatherComplete), ar)
                Return

            End If
            Dim myData As WeatherData() = client.EndGetWeatherData(ar)
            Dim bSource As New BindingSource()
            bSource.DataSource = myData
            dataGridView1.DataSource = bSource

        End Sub

        Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()

        End Sub

        Private Sub button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click

            Dim localities As String() = {"Los Angeles", "Rio de Janeiro", "New York", "London", "Paris", "Rome", _
                        "Cairo", "Beijing"}

            client.BeginGetWeatherData(localities, New AsyncCallback(AddressOf GetWeatherComplete), Nothing)

        End Sub

    End Class

End Namespace