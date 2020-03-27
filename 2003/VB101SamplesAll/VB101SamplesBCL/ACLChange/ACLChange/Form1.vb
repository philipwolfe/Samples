Imports System.Security.Principal
Imports System.Security.AccessControl
Imports System.IO

Public Class Form1

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.OpenFileDialog1.FileName = ""
        Me.FileSystemRightsSelection.DataSource = System.Enum.GetNames(GetType(FileSystemRights))
        Me.AccessControlTypeSelection.DataSource = System.Enum.GetNames(GetType(AccessControlType))

    End Sub


    Private Sub BrowseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseFile.Click
        If Me.OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Me.fileName.Text = Me.OpenFileDialog1.FileName
            m_fileSecurity = File.GetAccessControl(Me.fileName.Text)
            RefreshTreeView()
        End If
    End Sub

    Private Sub AddRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddRule.Click
        If Not (m_fileSecurity Is Nothing) And Me.UserName.Text.Length > 0 Then
            If AddToFileACE(Me.UserName.Text, CType(System.Enum.Parse(GetType(FileSystemRights), Me.FileSystemRightsSelection.SelectedItem.ToString), FileSystemRights), CType(System.Enum.Parse(GetType(AccessControlType), Me.AccessControlTypeSelection.SelectedItem.ToString), AccessControlType)) Then
                RefreshTreeView()

                Dim sSummary As String
                sSummary = """" + Me.UserName.Text + """, " + Me.FileSystemRightsSelection.SelectedItem.ToString() + ", " + Me.AccessControlTypeSelection.SelectedItem.ToString()
                MessageBox.Show("Rule added - " + sSummary, "ACL Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    Private Sub RemoveRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveRule.Click

        If Me.ACEDetails.Nodes.Count = 0 Then
            Exit Sub
        End If

        Dim rule As FileSystemAccessRule = CType(Me.ACEDetails.SelectedNode.Tag, FileSystemAccessRule)

        If Not (rule Is Nothing) Then
            If rule.IsInherited = False Then
                ' before we remove, get the current selection info to show after we delete it
                Dim name As String = rule.IdentityReference.ToString()
                Dim rights As String = rule.FileSystemRights.ToString()
                Dim aclType As String = rule.AccessControlType.ToString()

                RemoveFromFileACE(rule)
                RefreshTreeView()

                Dim sSummary As String
                sSummary = """" + Name + """, " + rights + ", " + aclType
                MessageBox.Show("Rule removed - " + sSummary, "ACL Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Can not remove a rule that is Inherited", "ACL Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
        End If
    End Sub

    Private Sub RefreshTreeView()
        Me.ACEDetails.Nodes.Clear()
        m_accessRules = New TreeNode
        m_accessRules.Text = "Access Rules"
        Me.ACEDetails.Nodes.Add(m_accessRules)
        m_auditRules = New TreeNode
        m_auditRules.Text = "Audit Rules"
        Me.ACEDetails.Nodes.Add(m_auditRules)
        ShowFileAccessRules(Me.fileName.Text)
        ShowFileAuditRules(Me.fileName.Text)
    End Sub

    Private Sub ShowFileAccessRules(ByVal fileName As String)
        If Me.fileName.Text.Length > 0 And File.Exists(Me.fileName.Text) Then
            Dim counter As Integer = 1
            For Each rule As FileSystemAccessRule In m_fileSecurity.GetAccessRules(True, True, GetType(NTAccount))
                Dim ruleNode As TreeNode = New TreeNode
                ruleNode.Text = "Rule " + counter.ToString
                ruleNode.Tag = rule
                Dim ruleDetailsNode As TreeNode = New TreeNode
                ruleDetailsNode.Text = "Access Control Type: " + (Microsoft.VisualBasic.IIf(rule.AccessControlType = AccessControlType.Allow, "grant", "deny"))
                ruleNode.Nodes.Add(ruleDetailsNode)
                ruleDetailsNode = New TreeNode
                ruleDetailsNode.Text = "File System Rights: " + rule.FileSystemRights.ToString
                ruleNode.Nodes.Add(ruleDetailsNode)
                ruleDetailsNode = New TreeNode
                ruleDetailsNode.Text = "Identity Ref: " + rule.IdentityReference.ToString
                ruleNode.Nodes.Add(ruleDetailsNode)
                ruleDetailsNode = New TreeNode
                ruleDetailsNode.Text = "Source: " + (Microsoft.VisualBasic.IIf(rule.IsInherited = True, "inherited", "direct"))
                ruleNode.Nodes.Add(ruleDetailsNode)
                Me.m_accessRules.Nodes.Add(ruleNode)
                System.Math.Min(System.Threading.Interlocked.Increment(counter), counter - 1)
            Next
        End If
    End Sub

    Private Sub ShowFileAuditRules(ByVal fileName As String)
        If Me.fileName.Text.Length > 0 And File.Exists(Me.fileName.Text) Then
            Dim counter As Integer = 1
            For Each rule As FileSystemAccessRule In m_fileSecurity.GetAuditRules(True, True, GetType(NTAccount))
                Dim ruleNode As TreeNode = New TreeNode
                ruleNode.Text = "Rule " + counter.ToString
                ruleNode.Tag = rule
                Dim ruleDetailsNode As TreeNode = New TreeNode
                ruleDetailsNode.Text = "Access Control Type: " + (Microsoft.VisualBasic.IIf(rule.AccessControlType = AccessControlType.Allow, "grant", "deny"))
                ruleNode.Nodes.Add(ruleDetailsNode)
                ruleDetailsNode = New TreeNode
                ruleDetailsNode.Text = "File System Rights: " + rule.FileSystemRights.ToString
                ruleNode.Nodes.Add(ruleDetailsNode)
                ruleDetailsNode = New TreeNode
                ruleDetailsNode.Text = "Identity Ref: " + rule.IdentityReference.ToString
                ruleNode.Nodes.Add(ruleDetailsNode)
                ruleDetailsNode = New TreeNode
                ruleDetailsNode.Text = "Source: " + (Microsoft.VisualBasic.IIf(rule.IsInherited = True, "inherited", "direct"))
                ruleNode.Nodes.Add(ruleDetailsNode)
                Me.m_auditRules.Nodes.Add(ruleNode)
                System.Math.Min(System.Threading.Interlocked.Increment(counter), counter - 1)
            Next
        End If
    End Sub

    Private Function AddToFileACE(ByVal userName As String, ByVal rights As FileSystemRights, ByVal accessControl As AccessControlType)
        Dim bAdded As Boolean
        Try
            Dim ace As FileSystemAccessRule = New FileSystemAccessRule(New NTAccount(userName), rights, accessControl)
            m_fileSecurity.AddAccessRule(ace)
            bAdded = True
        Catch ex As System.Security.Principal.IdentityNotMappedException
            MessageBox.Show("Failed to add rule - does username exist?", "ACL Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return bAdded
    End Function

    Private Sub RemoveFromFileACE(ByVal rule As FileSystemAccessRule)
        m_fileSecurity.RemoveAccessRule(rule)
    End Sub


    Private m_fileSecurity As FileSecurity
    Private m_accessRules As TreeNode
    Private m_auditRules As TreeNode

End Class
