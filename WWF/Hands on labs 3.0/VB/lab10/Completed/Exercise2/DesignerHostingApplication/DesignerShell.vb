'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

Public Class DesignerShell



    Private Sub zoomDropDownMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mni25PercentZoom.Click, mni200PercentZoom.Click, mni100PercentZoom.Click

        If TypeOf sender Is ToolStripMenuItem Then
            Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
            Dim zoomFactor As Integer = 0
            If Integer.TryParse(menuItem.Tag.ToString, zoomFactor) Then
                Me.workflowDesignerControl.ProcessZoom(zoomFactor)
            End If
        End If
    End Sub






End Class
