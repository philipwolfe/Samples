' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.Net.Security
Imports System.Runtime.Serialization
Imports System.Security.Principal
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Security

Imports System.ServiceModel.Security.Tokens
Imports System.Xml

Namespace Microsoft.ServiceModel.Samples

    Public Class WseHttpBinding
        Inherits Binding

        Public Sub New()

        End Sub

        Public Overloads Overrides Function CreateBindingElements() As BindingElementCollection

            'SecurityBindingElement sbe = bec.Find<SecurityBindingElement>();
            Dim bec As New BindingElementCollection()
            ' By default http transport is used
            Dim securityBinding As SecurityBindingElement
            Dim transport As BindingElement

            Select Case assertion

                Case WseSecurityAssertion.UsernameOverTransport
                    transport = New HttpsTransportBindingElement()
                    securityBinding = DirectCast(SecurityBindingElement.CreateUserNameOverTransportBindingElement(), TransportSecurityBindingElement)
                    If m_establishSecurityContext = True Then
                        Throw New InvalidOperationException("Secure Conversation is not supported for this Security Assertion Type")
                    End If
                    If m_requireSignatureConfirmation = True Then
                        Throw New InvalidOperationException("Signature Confirmation is not supported for this Security Assertion Type")
                    End If
                    Exit Select
                Case WseSecurityAssertion.MutualCertificate10
                    transport = New HttpTransportBindingElement()
                    securityBinding = SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10)
                    If m_requireSignatureConfirmation = True Then
                        Throw New InvalidOperationException("Signature Confirmation is not supported for this Security Assertion Type")
                    End If
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).MessageProtectionOrder = m_messageProtectionOrder
                    Exit Select
                Case WseSecurityAssertion.UsernameForCertificate
                    transport = New HttpTransportBindingElement()
                    securityBinding = DirectCast(SecurityBindingElement.CreateUserNameForCertificateBindingElement(), SymmetricSecurityBindingElement)
                    ' We want signatureconfirmation on the bootstrap process 
                    ' either for the application messages or for the RST/RSTR
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).RequireSignatureConfirmation = m_requireSignatureConfirmation
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).MessageProtectionOrder = m_messageProtectionOrder
                    Exit Select
                Case WseSecurityAssertion.AnonymousForCertificate
                    transport = New HttpTransportBindingElement()
                    securityBinding = DirectCast(SecurityBindingElement.CreateAnonymousForCertificateBindingElement(), SymmetricSecurityBindingElement)
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).RequireSignatureConfirmation = m_requireSignatureConfirmation
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).MessageProtectionOrder = m_messageProtectionOrder
                    Exit Select
                Case WseSecurityAssertion.MutualCertificate11
                    transport = New HttpTransportBindingElement()
                    securityBinding = SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11)
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).RequireSignatureConfirmation = m_requireSignatureConfirmation
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).MessageProtectionOrder = m_messageProtectionOrder
                    Exit Select
                Case WseSecurityAssertion.Kerberos
                    transport = New HttpTransportBindingElement()
                    securityBinding = DirectCast(SecurityBindingElement.CreateKerberosBindingElement(), SymmetricSecurityBindingElement)
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).RequireSignatureConfirmation = m_requireSignatureConfirmation
                    DirectCast(securityBinding, SymmetricSecurityBindingElement).MessageProtectionOrder = m_messageProtectionOrder
                    Exit Select
                Case Else
                    Throw New NotSupportedException("This supplied Wse security assertion is not supported")

            End Select

            'Set defaults for the security binding
            securityBinding.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256
            securityBinding.IncludeTimestamp = True

            'Secure Conversation 
            If m_establishSecurityContext = True Then

                Dim secureconversation As SymmetricSecurityBindingElement = DirectCast(SymmetricSecurityBindingElement.CreateSecureConversationBindingElement(securityBinding, False), SymmetricSecurityBindingElement)
                ' This is the default
                'secureconversation.DefaultProtectionLevel = ProtectionLevel.EncryptAndSign;		

                'Set defaults for the secure conversation binding
                secureconversation.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256
                ' We do not want signature confirmation on the application level messages 
                ' when secure conversation is enabled.
                secureconversation.RequireSignatureConfirmation = False
                secureconversation.MessageProtectionOrder = m_messageProtectionOrder
                securityBinding = secureconversation

            End If

            'Derived Keys
            If m_requireDerivedKeys = True Then
                securityBinding.SetKeyDerivation(True)
            End If

            ' Add the security binding to the binding collection
            bec.Add(securityBinding)

            ' Add the message encoder. 
            Dim textelement As New TextMessageEncodingBindingElement()
            textelement.MessageVersion = MessageVersion.Soap11WSAddressingAugust2004
            'These are the defaults required for WSE
            'textelement.MessageVersion = MessageVersion.Soap11Addressing1;
            'textelement.WriteEncoding = System.Text.Encoding.UTF8;
            bec.Add(textelement)

            ' Add the transport
            bec.Add(transport)

            ' return the binding elements
            Return bec

        End Function

        ' Finds the named WSE 3.0 Policy and initialize the WseHttpBinding;
        Public Sub LoadPolicy(ByVal filename As String, ByVal policyName As String)

            Dim reader As XmlReader = XmlReader.Create(filename)
            While reader.ReadToDescendant("policy", "http://schemas.microsoft.com/wse/2005/06/policy") AndAlso reader("name") = policyName

                ' Move to the
                While reader.Read()

                    If reader.NodeType = XmlNodeType.Element Then

                        Select Case reader.Name

                            Case "usernameForCertificateSecurity"
                                SecurityAssertion = WseSecurityAssertion.UsernameForCertificate
                                PolicyProperties(reader.ReadSubtree())
                                Exit Select
                            Case "usernameOverTransportSecurity"
                                SecurityAssertion = WseSecurityAssertion.UsernameOverTransport
                                PolicyProperties(reader.ReadSubtree())
                                Exit Select
                            Case "mutualCertificate10Security"
                                SecurityAssertion = WseSecurityAssertion.MutualCertificate10
                                PolicyProperties(reader.ReadSubtree())
                                Exit Select
                            Case "mutualCertificate11Security"
                                SecurityAssertion = WseSecurityAssertion.MutualCertificate11
                                PolicyProperties(reader.ReadSubtree())
                                Exit Select
                            Case "anonymousForCertificateSecurity"
                                SecurityAssertion = WseSecurityAssertion.AnonymousForCertificate
                                PolicyProperties(reader.ReadSubtree())
                                Exit Select
                            Case "kerberosSecurity"
                                SecurityAssertion = WseSecurityAssertion.Kerberos
                                PolicyProperties(reader.ReadSubtree())
                                Exit Select
                            Case "authorization", "requireSoapHeader", "requireActionHeader"
                                ' not used.
                                Exit Select

                        End Select

                    End If

                End While

            End While

        End Sub

        Private Sub PolicyProperties(ByVal reader As XmlReader)

            reader.Read()
            'reader.MoveToFirstAttribute
            'if (reader.HasAttributes}
            'Set the Security Assertion XML attributes onto the binding properties
            While reader.MoveToNextAttribute()

                If reader.Name = "establishSecurityContext" Then
                    EstablishSecurityContext = reader.ReadContentAsBoolean()
                End If
                If reader.Name = "requireSignatureConfirmation" Then
                    RequireSignatureConfirmation = reader.ReadContentAsBoolean()
                End If
                If reader.Name = "requireDerivedKeys" Then
                    RequireDerivedKeys = reader.ReadContentAsBoolean()
                End If
                If reader.Name = "messageProtectionOrder" Then

                    Dim protectionOrder As String = reader.Value
                    Select Case protectionOrder

                        Case "SignBeforeEncrypt"
                            MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt
                            Exit Select
                        Case "EncryptBeforeSign"
                            MessageProtectionOrder = MessageProtectionOrder.EncryptBeforeSign
                            Exit Select
                        Case "SignBeforeEncryptAndEncryptSignature"
                            MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature
                            Exit Select

                    End Select

                End If

            End While

        End Sub

        Public Overloads Overrides ReadOnly Property Scheme() As String

            Get

                Return "http"

            End Get

        End Property

        Private assertion As WseSecurityAssertion
        Public Property SecurityAssertion() As WseSecurityAssertion

            Get

                Return assertion

            End Get
            Set(ByVal value As WseSecurityAssertion)

                assertion = value

            End Set

        End Property

        Private m_requireDerivedKeys As Boolean
        Public Property RequireDerivedKeys() As Boolean

            Get

                Return m_requireDerivedKeys

            End Get
            Set(ByVal value As Boolean)

                m_requireDerivedKeys = value

            End Set

        End Property

        Private m_establishSecurityContext As Boolean
        Public Property EstablishSecurityContext() As Boolean

            Get

                Return m_establishSecurityContext

            End Get
            Set(ByVal value As Boolean)

                m_establishSecurityContext = value

            End Set

        End Property

        Private m_requireSignatureConfirmation As Boolean
        Public Property RequireSignatureConfirmation() As Boolean

            Get

                Return m_requireSignatureConfirmation

            End Get
            Set(ByVal value As Boolean)

                m_requireSignatureConfirmation = value

            End Set

        End Property

        Private m_messageProtectionOrder As MessageProtectionOrder
        Public Property MessageProtectionOrder() As MessageProtectionOrder

            Get

                Return m_messageProtectionOrder

            End Get
            Set(ByVal value As MessageProtectionOrder)

                m_messageProtectionOrder = value

            End Set

        End Property

    End Class

End Namespace