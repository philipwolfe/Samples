Option Strict On

Imports Microsoft.Win32
Imports System.Security

Public Class Form1

    Private Const regPath As String = "SOFTWARE\RegistrySample"

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create the root key in the registry
        Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey(regPath)
        key.Close() ' flush to file

        ' Set Form to close instead of minimize
        MinimizeBox = False

        ' Show current state of registry at our regPath
        UpdateTreeView()
    End Sub

    Private Function GetRegKey(ByVal keyName As String) As RegistryKey
        ' If the KeyName is empty, then want the parent key only
        Dim subKeyName As String = regPath
        If keyName <> String.Empty Then
            subKeyName = regPath & "\" & keyName
        End If

        ' Get key from registry based on subKeyName
        Dim key As RegistryKey = Nothing
        Try
            key = Registry.CurrentUser.OpenSubKey(subKeyName, True) ' Open with write access
            If key Is Nothing Then
                Throw New Exception("Registry Sub Key '" & subKeyName & " does not exist.  Please create first before performing this task.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        Return key
    End Function

    ' Create Registry Key
    Private Sub CreateRegKey(ByVal subKeyName As String, ByVal name As String, ByVal value As String)
        Dim key As RegistryKey = Nothing
        Dim subKey As RegistryKey = Nothing
        Try
            key = Registry.CurrentUser.OpenSubKey(regPath, True)
            subKey = key.OpenSubKey(subKeyName, True) ' Get SubKey if it exists

            ' Create SubKey if it does not exist
            If subKey Is Nothing Then
                subKey = key.CreateSubKey(subKeyName)
            End If

            ' Only create value if there is a name
            If name <> String.Empty Then
                subKey.SetValue(name, value)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If Not key Is Nothing Then
                key.Close() ' flush to file
            End If
            If Not subKey Is Nothing Then
                subKey.Close() ' flush to file
            End If
        End Try
    End Sub

    ' Change or create a value for this name under this subKeyName 
    Private Sub UpdateRegKey(ByVal subKeyName As String, ByVal name As String, ByVal value As String)
        Dim regKey As RegistryKey = GetRegKey(subKeyName)

        If Not regKey Is Nothing Then
            regKey.SetValue(name, value)
            regKey.Close() ' flush to file
        End If
    End Sub

    ' Display the current state of the registry in the format of the TreeView
    Private Sub UpdateTreeView()
        ' Get the RegistrySample Node (virtual rootNode as all nodes above are fixed and will not change)
        Dim rootNode As TreeNode = RegTreeView.Nodes(0).Nodes(0).Nodes(0)

        ' Remove everything under the RegistrySample Node
        rootNode.Nodes.Clear()

        ' Get root key from registry
        Dim rootKey As RegistryKey = Registry.CurrentUser.OpenSubKey(regPath, False)

        ' Loop through subkeys and their values and place in the treeview
        For Each subKeyName As String In rootKey.GetSubKeyNames()
            Dim subKey As RegistryKey = rootKey.OpenSubKey(subKeyName)
            Dim subKeyNode As TreeNode = rootNode.Nodes.Add(subKeyName)

            ' Loop through values for a subkey
            For Each valueName As String In subKey.GetValueNames()
                Dim nameValue As String = valueName & ": " & subKey.GetValue(valueName).ToString()
                subKeyNode.Nodes.Add(nameValue)
            Next valueName
        Next subKeyName

        RegTreeView.ExpandAll() ' Expand treeview automatically
    End Sub

    Private Sub CreateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateButton.Click
        CreateRegKey(KeyTextBox.Text, NameTextBox.Text, ValueTextBox.Text)
        UpdateTreeView()
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim regKey As RegistryKey = GetRegKey(String.Empty) ' Get parent key of key that will be deleted
        If Not regKey Is Nothing Then
            Try
                ' Delete the selected name / value if it exists
                If NameTextBox.Text <> String.Empty Then
                    Dim subKey As RegistryKey = GetRegKey(KeyTextBox.Text)
                    subKey.DeleteValue(NameTextBox.Text)
                End If
                regKey.DeleteSubKey(KeyTextBox.Text) ' Delete desired key
                regKey.Close() ' flush to file
            Catch ex As UnauthorizedAccessException
                ' Catch here so program can run gracefully
                ' According to current documentation DeleteSubKey should delete keys without
                ' throwing an exception.  Catch this specific exception here and hope by release time
                ' the OpenSubKey(string, boolean) and DeleteSubKey(string) methods will work correctly.
                MessageBox.Show("Error: " & ex.Message & ControlChars.CrLf & "Delete and specifically RegistryKey.OpenSubKey(string, boolean) may not be supported until final release")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
            UpdateTreeView()
        End If
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        UpdateRegKey(KeyTextBox.Text, NameTextBox.Text, ValueTextBox.Text)
        UpdateTreeView()
    End Sub

    Private Sub RegTreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles RegTreeView.AfterSelect
        Dim node As TreeNode = RegTreeView.SelectedNode

        ' The name value pair were written by this application as "name: value" so we
        ' should be able to split this string appropriately
        Dim nameValuePair As String() = Split(node.Text, ": ")

        If node.Nodes.Count = 0 And UBound(nameValuePair) > 0 Then
            ' handle case where name / value is selected
            KeyTextBox.Text = node.Parent.Text
            NameTextBox.Text = nameValuePair(0)
            ValueTextBox.Text = nameValuePair(1)
        Else
            ' SubKey was selected
            KeyTextBox.Text = node.Text
            NameTextBox.Text = String.Empty
            ValueTextBox.Text = String.Empty
        End If
    End Sub
End Class
