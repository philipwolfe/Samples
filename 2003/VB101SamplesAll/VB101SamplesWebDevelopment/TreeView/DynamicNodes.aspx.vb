Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class DynamicNodes_aspx
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(ByVal e As EventArgs) '
        If Not IsPostBack Then
            BuildTreeView()
        End If
    End Sub 'OnLoad


    Private Sub BuildTreeView()
        ' For this part of the sample, the tree view will look like the following hierarchy:

        'Music()
        '|  |
        '|  |__ Soundtracks
        '|  |
        '|  |__ Rock
        '| 
        'Movies()

        'The nodes of the tree will be added in the order shown above in the hierarchy.

        Dim soundtrackTitles As String() = {"Gladiator", "Harry Potter and the Sorcerer's Stone", "Star Wars: The Empire Strikes Back", "The Lord of the Rings: The Two Towers"}

        Dim rockTitles As String() = {"Chevelle: Wonder What's Next", "Foo Fighters: The Colour and the Shape", "Stone Temple Pilots: Core"}

        Dim movieTitles As String() = {"2001: A Space Odyssey", "The Godfather", "Casablanca", "Ctizien Kane"}

        ' First add the Music node to the root of the tree
        Dim musicNode As New TreeNode("Music")
        TreeView1.Nodes.Add(musicNode)

        ' Now let's add the Soundtracks node onto the Music node
        Dim soundtracksNode As New TreeNode("Soundtracks")
        musicNode.ChildNodes.Add(soundtracksNode)

        ' Now loop through the soundtrack titles array to add each one to the Soundtracks node
        Dim i As Integer
        For i = 0 To soundtrackTitles.Length - 1
            Dim node As New TreeNode(soundtrackTitles(i))
            soundtracksNode.ChildNodes.Add(node)
        Next i

        ' Now add the Rock node to the Music node
        Dim rockNode As New TreeNode("Rock")
        musicNode.ChildNodes.Add(rockNode)

        ' And then loop through the rock titles array to add each one to the Rock node
        For i = 0 To rockTitles.Length - 1
            Dim node As New TreeNode(rockTitles(i))
            rockNode.ChildNodes.Add(node)
        Next i

        ' From here, go back and add the Movies node onto the root of the tree
        Dim moviesNode As New TreeNode("Movies")
        TreeView1.Nodes.Add(moviesNode)

        ' Now loop through the movie titles array to add each one to the Movies node
        For i = 0 To movieTitles.Length - 1
            Dim node As New TreeNode(movieTitles(i))
            moviesNode.ChildNodes.Add(node)
        Next i
    End Sub 'BuildTreeView
End Class 'DynamicNodes_aspx