'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'-----------------------------------------------------------------------

Public Class EditorOptions

    Private Sub EditorOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Load settings
        Me.checkWordWrap.Checked = ClientSettings.Settings.Default.WordWrapSetting
        Me.checkDetectURLs.Checked = ClientSettings.Settings.Default.DetectURLsSetting

    End Sub


    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click

        ' Save settings
        ClientSettings.Settings.Default.WordWrapSetting = Me.checkWordWrap.Checked
        ClientSettings.Settings.Default.DetectURLsSetting = Me.checkDetectURLs.Checked
        ClientSettings.Settings.Default.Save()

        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub

End Class