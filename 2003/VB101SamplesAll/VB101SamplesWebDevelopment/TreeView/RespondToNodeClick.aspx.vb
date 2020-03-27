Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class RespondToNodeClick_aspx
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        If Not IsPostBack Then
            BuildTreeView()
        End If
    End Sub 'OnLoad


    Private Sub BuildTreeView()
        Dim searchSitesTitles As String() = {"Google", "Yahoo", "MSN Search"}

        Dim searchSitesValues As String() = {"www.google.com", "www.yahoo.com", "search.msn.com"}

        Dim newsSitesTitles As String() = {"CNN", "MSNBC"}

        Dim newsSitesValues As String() = {"www.cnn.com", "www.msnbc.com"}

        ' First add the Search Sites node to the root of the tree
        Dim searchSitesNode As New TreeNode("Search Sites")
        TreeView1.Nodes.Add(searchSitesNode)

        ' Now loop through the search sites titles array to add each one to the Search Sites node
        Dim i As Integer
        For i = 0 To searchSitesTitles.Length - 1
            Dim node As New TreeNode()
            node.Text = searchSitesTitles(i)
            node.Value = searchSitesValues(i)
            searchSitesNode.ChildNodes.Add(node)
        Next i

        ' Now add the News Sites node onto the root of the tree
        Dim newsSitesNode As New TreeNode("News Sites")
        TreeView1.Nodes.Add(newsSitesNode)

        ' Now loop through the news sites titles array to add each one to the News Sites node
        For i = 0 To newsSitesTitles.Length - 1
            Dim node As New TreeNode()
            node.Text = newsSitesTitles(i)
            node.Value = newsSitesValues(i)
            newsSitesNode.ChildNodes.Add(node)
        Next i
    End Sub 'BuildTreeView


    ' This is the event that fires when a node in the tree is selected. Use it for things like
    ' performing custom actions for the node or for processing data for a call to another method.
    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As EventArgs)
        NodeText.Text = TreeView1.SelectedNode.Text
        NodeUrl.Text = TreeView1.SelectedNode.Value
    End Sub 'TreeView1_SelectedNodeChanged
End Class 'RespondToNodeClick_aspx