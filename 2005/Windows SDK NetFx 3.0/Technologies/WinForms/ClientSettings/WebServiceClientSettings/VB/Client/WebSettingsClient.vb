'---------------------------------------------------------------------
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
'---------------------------------------------------------------------

' Demonstrate a common usage pattern for managing user settings

Public Class WebSettingsClient

    Private webSettings As MyWebSettings

    Private Sub buttonSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSaveSettings.Click

        webSettings.TextSetting = textSetting.Text
        webSettings.ComboSetting = comboSetting.SelectedIndex
        webSettings.CheckSetting1 = checkSetting1.Checked
        webSettings.CheckSetting2 = checkSetting2.Checked
        webSettings.Save()

    End Sub


    Private Sub SettingsTestForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        webSettings = New MyWebSettings

        comboSetting.SelectedIndex = webSettings.ComboSetting
        checkSetting1.Checked = webSettings.CheckSetting1
        checkSetting2.Checked = webSettings.CheckSetting2
        textSetting.Text = webSettings.TextSetting

    End Sub

End Class
