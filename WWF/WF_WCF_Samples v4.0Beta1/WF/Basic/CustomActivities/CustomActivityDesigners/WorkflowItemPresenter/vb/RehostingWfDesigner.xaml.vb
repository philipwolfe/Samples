'-------------------------------------------------------------------
' Copyright (c) Microsoft Corporation. All rights reserved
'-------------------------------------------------------------------

Imports System
Imports System.Windows
Imports System.Activities.Design
Imports System.Activities.Statements
Imports System.Activities.Core.Design
Imports System.Activities.Design.Metadata
Imports System.ComponentModel


Class RehostingWfDesigner
    Protected Overrides Sub OnInitialized(ByVal e As EventArgs)
        MyBase.OnInitialized(e)
        ' register metadata
        Dim metadata = New DesignerMetadata()
        metadata.Register()
        ' register custom metdata
        RegisterCustomMetadata()
        ' Add to Toolbox
        Toolbox.Categories.Add(New ToolboxCategoryItemsCollection("Custom Activities"))
        Toolbox.Categories(1).Add(new ToolboxItemWrapper(GetType(SimpleNativeActivity)))
        ' create the workflow designer
        Dim wd = New WorkflowDesigner()
        wd.Load(New Sequence())
        DesignerBorder.Child = wd.View
        PropertyBorder.Child = wd.PropertyInspectorView
    End Sub

    Sub RegisterCustomMetadata()
        Dim builder As New AttributeTableBuilder()
        builder.AddCustomAttributes(GetType(SimpleNativeActivity), New DesignerAttribute(GetType(SimpleNativeDesigner)))
        MetadataStore.AddAttributeTable(builder.CreateTable())
    End Sub



End Class


