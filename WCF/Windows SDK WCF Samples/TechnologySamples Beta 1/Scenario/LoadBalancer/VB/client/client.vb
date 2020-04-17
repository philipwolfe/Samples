' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Channels
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    '[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    'public interface ILoadBalancedEchoContract
    '{
    '    [OperationContract]
    '    string Echo(string message);
    '}

    Class client

        Public Shared Sub Main(ByVal args As String())

            Dim loadBalancerAddress As New EndpointAddress("net.tcp://localhost/servicemodelsamples/loadBalancerService/")
            Dim tcpBinding As New NetTcpBinding(SecurityMode.None)
            Dim httpBinding As New WSHttpBinding()

            ' Use the utility resolver class to obtain endpoint address of a service
            Dim resolver As New LoadBalancerResolver(loadBalancerAddress, tcpBinding)

            Dim remoteAddress As EndpointAddress = resolver.GetEndpointAddress(Of ILoadBalancedEchoContract)(httpBinding).ToEndpointAddress()
            ' Alternatively, one can get back a ChannelFactory from the resolver:
            ' ChannelFactory<ILoadBalancedEchoContract> channelFactory = resolver.GetChannelFactory<ILoadBalancedEchoContract>(httpBinding);

            Dim client As New LoadBalancedEchoContractClient(httpBinding, remoteAddress)
            ' If using ChannelFactory returned by resolver:
            ' ILoadBalancedEchoContract client = channelFactory.CreateChannel();

            Console.WriteLine("calling service at {0}", remoteAddress.ToString())

            Console.WriteLine(client.Echo("Hello!"))
            client.Close()
            Console.ReadLine()

        End Sub

    End Class

End Namespace
