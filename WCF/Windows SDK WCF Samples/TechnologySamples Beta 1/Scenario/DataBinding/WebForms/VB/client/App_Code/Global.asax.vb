' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports Microsoft.ServiceModel.Samples
Imports System.ServiceModel

Public Class [Global]
    Inherits HttpApplication

    Protected Shared m_client As WeatherServiceClient
    Private Shared thisLock As New Object()

    ' We only want one client per instance of the app because it is innefficient 
    ' to create a new client for every request.
    Public Shared ReadOnly Property Client() As WeatherServiceClient

        Get

            ' lazy init the client
            SyncLock thisLock

                If m_client Is Nothing OrElse m_client.State = (CommunicationState.Faulted Or CommunicationState.Closed) Then

                    m_client = New WeatherServiceClient()

                End If

            End SyncLock
            Return m_client

        End Get

    End Property

    ' Our client is scoped to the lifetime of the HttpAcpplication so
    ' when the Application_End method is invoked, we should call Close on the client
    Public Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

        If m_client IsNot Nothing AndAlso m_client.State = System.ServiceModel.CommunicationState.Opened Then

            m_client.Close()

        End If

    End Sub

End Class
