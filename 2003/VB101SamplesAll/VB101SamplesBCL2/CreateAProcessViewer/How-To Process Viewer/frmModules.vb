'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio 2005.


Public Class frmModules
    Private m_ParentProcess As Process = Nothing

    Private mits As ListView.ListViewItemCollection
    Private mcolModules As New Collection()

    Friend Property ParentProcess() As Process
        Get
            Return m_ParentProcess
        End Get
        Set(ByVal Value As Process)
            m_ParentProcess = Value
            If m_ParentProcess Is Nothing Then
                mcolModules = Nothing
            End If
        End Set
    End Property

    Private Sub EnumModules()
        Try
            Me.lvModules.Items.Clear()
            If Not mcolModules Is Nothing Then
                mcolModules = New Collection()
            End If
            Dim m As ProcessModule
            For Each m In m_ParentProcess.Modules
                Me.lvModules.Items.Add(m.ModuleName)

                Try
                    mcolModules.Add(m, m.ModuleName)
                Catch exp As ArgumentException
                    ' This means the item was duplicated.
                    ' Eat error and continue.
                Catch exp As Exception
                    MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Next
        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Friend Sub RefreshModules()
        Me.sbInfo.Text = "Process = " & m_ParentProcess.ProcessName
        Me.lvModDetail.Items.Clear()
        EnumModules()
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Hide()
    End Sub

    Private Sub EnumModule(ByVal m As ProcessModule)

        Me.lvModDetail.Items.Clear()

        mits = Me.lvModDetail.Items

        Try
            AddNameValuePair("Base Address", Hex(m.BaseAddress.ToInt32).ToLower())
            AddNameValuePair("Entry Point Address", Hex(m.EntryPointAddress.ToInt32).ToLower())
            AddNameValuePair("File Name", m.FileName)
            AddNameValuePair("File Version", m.FileVersionInfo.FileVersion.ToString())
            AddNameValuePair("File Description", m.FileVersionInfo.FileDescription)
            AddNameValuePair("Memory Size", m.ModuleMemorySize.ToString("N0"))

        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddNameValuePair(ByVal Item As String, ByVal SubItem As String)
        With mits.Add(Item)
            .SubItems.Add(SubItem)
        End With
    End Sub

    Private Sub lvModules_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvModules.SelectedIndexChanged, lvModules.Click
        Try
            Dim lv As ListView = CType(sender, ListView)

            If lv.SelectedItems.Count = 1 Then
                Dim strMod As String = lv.SelectedItems(0).Text

                Dim m As ProcessModule = CType(mcolModules.Item(strMod), ProcessModule)
                EnumModule(m)
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class