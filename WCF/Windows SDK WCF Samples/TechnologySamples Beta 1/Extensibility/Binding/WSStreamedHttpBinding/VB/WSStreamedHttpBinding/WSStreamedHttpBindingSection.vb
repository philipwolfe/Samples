
' Copyright (c) Microsoft Corporation.  All rights reserved.

Imports System.Configuration
Imports System.Globalization
Imports System.ServiceModel.Configuration

Namespace Microsoft.ServiceModel.Samples
    Partial Public Class WSStreamedHttpBindingCollectionElement
        Inherits StandardBindingCollectionElement(Of WSStreamedHttpBinding, WSStreamedHttpBindingConfigurationElement)

        Friend Shared Function GetCollectionElement() As WSStreamedHttpBindingCollectionElement
            Dim bindingsSection As BindingsSection = ConfigurationManager.GetSection("system.serviceModel/bindings")
            Return bindingsSection.Item(WSStreamedHttpBindingConstants.WSStreamedHttpBindingCollectionElementName)
        End Function

    End Class
End Namespace