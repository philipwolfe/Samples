
' Copyright (c) Microsoft Corporation.  All rights reserved.

Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.Text
Imports System.Globalization

Namespace System.ServiceModel.Configuration
    Class TextEncodingConverter
        Inherits TypeConverter

        Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
            If GetType(String) Is sourceType Then
                Return True
            End If

            Return MyBase.CanConvertFrom(context, sourceType)
        End Function

        Public Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
            If GetType(InstanceDescriptor) Is destinationType Then
                Return True
            End If

            Return MyBase.CanConvertTo(context, destinationType)
        End Function

        Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
            If value.GetType() Is GetType(String) Then
                If value Is Nothing Then
                    Throw New ArgumentNullException("value")
                End If

                Dim messageEncoding As String = value
                Dim retval As Encoding = Encoding.GetEncoding(messageEncoding)

                If retval Is Nothing Then
                    Throw New ArgumentException()
                End If

                Return retval
            End If

            Return MyBase.ConvertFrom(context, culture, value)
        End Function

        Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            If GetType(String) Is destinationType And value.GetType() Is GetType(Encoding) Then
                If value Is Nothing Then
                    Throw New ArgumentNullException("value")
                End If

                Dim messageEncoding As Encoding = value
                Return messageEncoding.HeaderName
            End If
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Namespace