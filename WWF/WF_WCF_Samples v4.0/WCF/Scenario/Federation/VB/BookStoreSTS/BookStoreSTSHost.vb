﻿' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System

Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Security

Namespace Microsoft.Samples.Federation

    Public Class BookStoreSTSHostFactory
        Inherits ServiceHostFactoryBase

        Public Overloads Overrides Function CreateServiceHost(ByVal constructorString As String, ByVal baseAddresses() As Uri) As ServiceHostBase

            Return New BookStoreSTSHost(baseAddresses)

        End Function

    End Class

    Class BookStoreSTSHost
        Inherits ServiceHost

        Public Sub New(ByVal ParamArray addresses() As Uri)

            MyBase.New(GetType(BookStoreSTS), addresses)
            ServiceConstants.LoadAppSettings()
            ' Setting the certificateValidationMode to PeerOrChainTrust means that if the certificate 
            ' is in the Trusted People store, then it will be trusted without performing a
            ' validation of the certificate's issuer chain. This setting is used here for convenience 
            ' so that the sample can be run without having to have certificates issued by a certificate 
            ' authority (CA). This setting is less secure than the default, ChainTrust. The security 
            ' implications of this setting should be carefully considered before using PeerOrChainTrust 
            ' in production code. 
            Me.Credentials.IssuedTokenAuthentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust

        End Sub

    End Class

End Namespace

