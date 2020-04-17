' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Channels
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ILoadBalancedEchoContract

        <OperationContract()> _
        Function Echo(ByVal message As String) As String

    End Interface

    Public Class LoadBalancedEchoService
        Implements ILoadBalancedEchoContract

        Public Function Echo(ByVal message As String) As String Implements ILoadBalancedEchoContract.Echo

            Console.WriteLine("Echo method of LoadBalancedEchoService class is invoked")
            Return message

        End Function

    End Class

    Public Class Service2

        Public Shared Sub Main(ByVal args As String())

            ' Get base address from app settings in configuration
            Dim baseAddress As New Uri("http://localhost:9000/servicemodelsamples/echoService/")

            ' Create a ServiceHost for the LoadBalancedEchoService type and provide the base address.
            Using serviceHost As New ServiceHost(GetType(LoadBalancedEchoService), baseAddress)

                serviceHost.AddServiceEndpoint(GetType(ILoadBalancedEchoContract), New WSHttpBinding(), "")

                ' Add the LoadBalancedBehavior in code to register with the load balancer
                Dim loadBalancerAddress As New EndpointAddress("net.tcp://localhost/servicemodelsamples/loadBalancerService/")
                Dim behavior As New LoadBalancerBehavior(loadBalancerAddress, New NetTcpBinding(SecurityMode.None))
                serviceHost.Description.Endpoints(0).Behaviors.Add(behavior)

                ' Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                serviceHost.Close()
                Console.WriteLine("The service has shutdown.")

            End Using

        End Sub

    End Class

End Namespace
