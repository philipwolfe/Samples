using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DynamicNodes_aspx : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
		if (!IsPostBack)
		{
			BuildTreeView();
		}
    }

    private void BuildTreeView()
    {
        /*
        For this part of the sample, the tree view will look like the following hierarchy:

        Music
        |  |
        |  |__ Soundtracks
        |  |
        |  |__ Rock
        | 
        Movies

        The nodes of the tree will be added in the order shown above in the hierarchy.
        */

        string[] soundtrackTitles = new string[4] {"Gladiator", 
                                                   "Harry Potter and the Sorcerer's Stone",
                                                   "Star Wars: The Empire Strikes Back",
                                                   "The Lord of the Rings: The Two Towers"};

        string[] rockTitles = new string[3] {"Chevelle: Wonder What's Next",
                                             "Foo Fighters: The Colour and the Shape",
                                             "Stone Temple Pilots: Core"};

        string[] movieTitles = new string[4] {"2001: A Space Odyssey",
                                              "The Godfather",
                                              "Casablanca",
                                              "Ctizien Kane"};

		// First add the Music node to the root of the tree
        TreeNode musicNode = new TreeNode("Music");
        TreeView1.Nodes.Add(musicNode);

        // Now let's add the Soundtracks node onto the Music node
        TreeNode soundtracksNode = new TreeNode("Soundtracks");
        musicNode.ChildNodes.Add(soundtracksNode);

        // Now loop through the soundtrack titles array to add each one to the Soundtracks node
        for (int i = 0; i < soundtrackTitles.Length; i++)
        {
            TreeNode node = new TreeNode(soundtrackTitles[i]);
            soundtracksNode.ChildNodes.Add(node);
        }

        // Now add the Rock node to the Music node
        TreeNode rockNode = new TreeNode("Rock");
        musicNode.ChildNodes.Add(rockNode);

        // And then loop through the rock titles array to add each one to the Rock node
        for (int i = 0; i < rockTitles.Length; i++)
        {
            TreeNode node = new TreeNode(rockTitles[i]);
            rockNode.ChildNodes.Add(node);
        }

        // From here, go back and add the Movies node onto the root of the tree
        TreeNode moviesNode = new TreeNode("Movies");
        TreeView1.Nodes.Add(moviesNode);

        // Now loop through the movie titles array to add each one to the Movies node
        for (int i = 0; i < movieTitles.Length; i++)
        {
            TreeNode node = new TreeNode(movieTitles[i]);
            moviesNode.ChildNodes.Add(node);
        }
    }
}
