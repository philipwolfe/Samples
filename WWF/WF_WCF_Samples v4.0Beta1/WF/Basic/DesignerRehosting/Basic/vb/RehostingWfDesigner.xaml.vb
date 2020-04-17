'-------------------------------------------------------------------
' Copyright (c) Microsoft Corporation. All rights reserved
'-------------------------------------------------------------------

Imports System
Imports System.Windows
Imports System.Activities.Design
Imports System.Activities.Statements
Imports System.Activities.Core.Design


    Class RehostingWfDesigner
        Protected Overrides Sub OnInitialized(ByVal e As EventArgs)
            MyBase.OnInitialized(e)
            ' register metadata
            Dim metadata = New DesignerMetadata()
            metadata.Register()

            ' create the workflow designer
            Dim wd = New WorkflowDesigner()
            wd.Load(New Sequence())
            DesignerBorder.Child = wd.View
            PropertyBorder.Child = wd.PropertyInspectorView


        End Sub

    End Class


