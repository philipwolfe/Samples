' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Xml

Namespace Microsoft.ServiceModel.Samples

    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.[Single], ConcurrencyMode:=ConcurrencyMode.Multiple)> _
    Public Class LoadBalancerService
        Implements ILoadBalancer

        Shared registrationTable As New Dictionary(Of String, String)()
        Shared serviceTable As New Dictionary(Of String, Dictionary(Of String, EndpointAddress))()

        Public Function Register(ByVal contractQName As String, ByVal bindingQName As String, ByVal serviceAddress As EndpointAddress10) As String Implements ILoadBalancer.Register

            Dim guid As String

            If contractQName Is Nothing OrElse bindingQName Is Nothing OrElse serviceAddress.ToEndpointAddress() Is Nothing Then

                Return Nothing

            End If

            SyncLock registrationTable

                SyncLock serviceTable

                    Dim key As String = contractQName + ":" + bindingQName

                    If Not serviceTable.ContainsKey(key) Then

                        serviceTable.Add(key, New Dictionary(Of String, EndpointAddress)())

                    End If

                    guid = System.Guid.NewGuid().ToString()

                    serviceTable(key)(guid) = serviceAddress.ToEndpointAddress()
                    registrationTable(guid) = key

                End SyncLock

            End SyncLock
            Return guid

        End Function

        Public Sub Unregister(ByVal registrationId As String) Implements ILoadBalancer.Unregister

            If registrationId Is Nothing Then

                Return

            End If

            SyncLock registrationTable

                If Not registrationTable.ContainsKey(registrationId) Then

                    Return

                End If

                Dim key As String = registrationTable(registrationId)

                If key IsNot Nothing Then

                    SyncLock serviceTable

                        serviceTable(key).Remove(registrationId)
                        If serviceTable(key).Count = 0 Then

                            serviceTable.Remove(key)

                        End If

                    End SyncLock

                    registrationTable.Remove(registrationId)

                End If

            End SyncLock

        End Sub

        Public Function GetServiceAddress(ByVal contractQName As String, ByVal bindingQName As String) As EndpointAddress10 Implements ILoadBalancer.GetServiceAddress

            If contractQName Is Nothing OrElse bindingQName Is Nothing Then

                Return Nothing

            End If

            Dim key As String = contractQName + ":" + bindingQName

            SyncLock serviceTable

                If serviceTable.ContainsKey(key) Then

                    For Each address As EndpointAddress In serviceTable(key).Values

                        ' Current implementation simply returns the first service's address.
                        ' More complicated algorithm can be used to determine which service's address should be returned.
                        Return EndpointAddress10.FromEndpointAddress(address)

                    Next

                End If

            End SyncLock

            Return Nothing

        End Function

    End Class

    Public Class App

        ' Host the service within this EXE console application.
        Public Shared Sub Main()

            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As New ServiceHost(GetType(LoadBalancerService))

                ' Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The load balancer is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHostBase to shutdown the service.
                serviceHost.Close()
                Console.WriteLine("The load balancer has shutdown.")

            End Using

        End Sub

    End Class

End Namespace
