using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class RespondToNodeClick_aspx : System.Web.UI.Page
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
        string[] searchSitesTitles = new string[3] {"Google", 
                                                    "Yahoo",
                                                    "MSN Search"};

        string[] searchSitesValues = new string[3] {"www.google.com", 
                                                    "www.yahoo.com",
                                                    "search.msn.com"};

        string[] newsSitesTitles = new string[2] {"CNN", 
                                                  "MSNBC"};

        string[] newsSitesValues = new string[2] {"www.cnn.com", 
                                                  "www.msnbc.com"};

        // First add the Search Sites node to the root of the tree
        TreeNode searchSitesNode = new TreeNode("Search Sites");
        TreeView1.Nodes.Add(searchSitesNode);

        // Now loop through the search sites titles array to add each one to the Search Sites node
        for (int i = 0; i < searchSitesTitles.Length; i++)
        {
            TreeNode node = new TreeNode();
            node.Text = searchSitesTitles[i];
            node.Value = searchSitesValues[i];
            searchSitesNode.ChildNodes.Add(node);
        }

        // Now add the News Sites node onto the root of the tree
        TreeNode newsSitesNode = new TreeNode("News Sites");
        TreeView1.Nodes.Add(newsSitesNode);

        // Now loop through the news sites titles array to add each one to the News Sites node
        for (int i = 0; i < newsSitesTitles.Length; i++)
        {
            TreeNode node = new TreeNode();
            node.Text = newsSitesTitles[i];
            node.Value = newsSitesValues[i];
            newsSitesNode.ChildNodes.Add(node);
        }
    }
    
    // This is the event that fires when a node in the tree is selected. Use it for things like
    // performing custom actions for the node or for processing data for a call to another method.
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        NodeText.Text = TreeView1.SelectedNode.Text;
        NodeUrl.Text = TreeView1.SelectedNode.Value;
    }
}
