' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Channels
Imports System.Configuration
Imports System.Globalization
Imports System.ServiceModel
Imports System.ServiceModel.Configuration

Namespace Microsoft.ServiceModel.Samples

    Public Class LoadBalancerBehaviorElement
        Inherits BehaviorExtensionElement

        Const AddressString As String = "address"
        Const BindingConfigurationString As String = "bindingConfiguration"
        Const BindingString As String = "binding"
        Const BindingsSectionGroupPath As String = "system.serviceModel/bindings"

        <ConfigurationProperty(LoadBalancerBehaviorElement.AddressString, DefaultValue:="")> _
        Public Property Address() As Uri

            Get

                Return DirectCast(MyBase.Item(LoadBalancerBehaviorElement.AddressString), Uri)

            End Get
            Set(ByVal value As Uri)

                MyBase.Item(LoadBalancerBehaviorElement.AddressString) = value

            End Set

        End Property

        <ConfigurationProperty(LoadBalancerBehaviorElement.BindingConfigurationString, DefaultValue:="")> _
        <StringValidator(MinLength:=0)> _
        Public Property BindingConfiguration() As String

            Get

                Return DirectCast(MyBase.Item(LoadBalancerBehaviorElement.BindingConfigurationString), String)

            End Get
            Set(ByVal value As String)

                If String.IsNullOrEmpty(value) Then

                    value = String.Empty

                End If
                MyBase.Item(LoadBalancerBehaviorElement.BindingConfigurationString) = value

            End Set

        End Property

        <ConfigurationProperty(LoadBalancerBehaviorElement.BindingString, Options:=ConfigurationPropertyOptions.IsRequired)> _
        <StringValidator(MinLength:=0)> _
        Public Property Binding() As String

            Get

                Return DirectCast(MyBase.Item(LoadBalancerBehaviorElement.BindingString), String)

            End Get
            Set(ByVal value As String)

                If String.IsNullOrEmpty(value) Then

                    value = String.Empty

                End If
                MyBase.Item(LoadBalancerBehaviorElement.BindingString) = value

            End Set

        End Property

        Private Shared Function GetSection(ByVal sectionPath As String) As Object

            Dim retval As Object = ConfigurationManager.GetSection(sectionPath)
            If retval Is Nothing Then

                Throw New ConfigurationErrorsException("Configuration section not found")

            End If
            Return retval

        End Function

        Private Shared Function LookupBinding(ByVal binding As String, ByVal configurationName As String) As Binding

            If String.IsNullOrEmpty(binding) Then

                Throw New ConfigurationErrorsException("Binding type cannot be null or empty.")

            End If

            Dim bindingsSection As BindingsSection = DirectCast(ConfigurationManager.GetSection(LoadBalancerBehaviorElement.BindingsSectionGroupPath), BindingsSection)
            Dim bindingCollectionElement As BindingCollectionElement = bindingsSection(binding)

            Dim retval As Binding = DirectCast(System.Activator.CreateInstance(bindingCollectionElement.BindingType), Binding)
            If Not String.IsNullOrEmpty(configurationName) Then

                ' We are looking for a specific instance, not the default. 
                Dim configuredBindingFound As Boolean = False

                ' The Bindings property is always public
                For Each configElement As Object In bindingCollectionElement.ConfiguredBindings

                    Dim bindingElement As IBindingConfigurationElement = TryCast(configElement, IBindingConfigurationElement)
                    If bindingElement IsNot Nothing Then

                        If bindingElement.Name.Equals(configurationName, StringComparison.CurrentCulture) Then

                            bindingElement.ApplyConfiguration(retval)
                            configuredBindingFound = True

                        End If

                    End If

                Next
                If Not configuredBindingFound Then

                    ' We expected to find an instance, but didn't.
                    ' Return null. 
                    retval = Nothing

                End If

            End If
            Return retval

        End Function

        Protected Overloads Overrides Function CreateBehavior() As Object

            Dim loadBalancerAddress As New EndpointAddress(DirectCast(MyBase.Item(LoadBalancerBehaviorElement.AddressString), Uri))

            Dim bindingType As String = DirectCast(MyBase.Item(LoadBalancerBehaviorElement.BindingString), String)
            Dim configName As String = DirectCast(MyBase.Item(LoadBalancerBehaviorElement.BindingConfigurationString), String)
            Dim binding As Binding = LookupBinding(bindingType, configName)

            If binding Is Nothing Then
                Throw New ConfigurationErrorsException("Could not find specified binding.")
            End If

            Return New LoadBalancerBehavior(loadBalancerAddress, binding)

        End Function

        Public Overloads Overrides ReadOnly Property BehaviorType() As Type

            Get

                Return GetType(LoadBalancerBehavior)

            End Get

        End Property

    End Class

End Namespace
