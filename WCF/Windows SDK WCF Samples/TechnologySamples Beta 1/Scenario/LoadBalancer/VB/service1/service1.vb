' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Xml
Imports System.ServiceModel
Imports System.Configuration

Namespace Microsoft.ServiceModel.Samples

    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ILoadBalancedEchoContract

        <OperationContract()> _
        Function Echo(ByVal message As String) As String

    End Interface

    Public Class LoadBalancedEchoService
        Implements ILoadBalancedEchoContract

        Public Function Echo(ByVal message As String) As String Implements ILoadBalancedEchoContract.Echo

            Return message

        End Function

    End Class

End Namespace
