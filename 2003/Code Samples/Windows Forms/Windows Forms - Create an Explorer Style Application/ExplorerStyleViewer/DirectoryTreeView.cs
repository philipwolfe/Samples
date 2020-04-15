//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.IO;
using System.Windows.Forms;
using System.Drawing;

class DirectoryTreeView: TreeView
{

    // This is the class constructor.

    public DirectoryTreeView () {

        // Make a little more room for long directory names.

        this.Width *= 2;

        // Get images for tree.

        this.ImageList = new ImageList();

            this.ImageList.Images.Add(new Bitmap(@"..\..\ExplorerStyleViewer\35FLOPPY.BMP"));
            this.ImageList.Images.Add(new Bitmap(@"..\..\ExplorerStyleViewer\CLSDFOLD.BMP"));
            this.ImageList.Images.Add(new Bitmap(@"..\..\ExplorerStyleViewer\OPENFOLD.BMP"));
		// Construct tree.
        RefreshTree();
    }

    // the BeforeExpand event for the subclassed TreeView. See further 
    // comments about the Before_____ and After_______ TreeView event pairs in 
    // /DirectoryScanner/DirectoryScanner.cs.

    protected override void OnBeforeExpand(TreeViewCancelEventArgs tvcea)
	{

        base.OnBeforeExpand(tvcea);

        // For performance reasons and to avoid TreeView "flickering" during an 
        // large node update, it is best to wrap the update code in BeginUpdate...
        // EndUpdate statements.

        this.BeginUpdate();

        // Add child nodes for each child node in the node clicked by the user. 
        // For performance reasons each node in the DirectoryTreeView 
        // contains only the next level of child nodes in order to display the + sign 
        // to indicate whether the user can expand the node. So when the user expands
        // a node, in order for the + sign to be appropriately displayed for the next
        // level of child nodes, *their* child nodes have to be added.

		foreach(TreeNode tn in tvcea.Node.Nodes)
		{
			AddDirectories(tn);
		}
        
        this.EndUpdate();

    }

    // This subroutine is used to add a child node for every directory under its
    // parent node, which is passed an argument. See further comments in the
    // OnBeforeExpand event handler.

    void AddDirectories(TreeNode tn)
	{

        tn.Nodes.Clear();

        string strPath = tn.FullPath;

        DirectoryInfo diDirectory = new DirectoryInfo(strPath);
		DirectoryInfo[] adiDirectories;

        try {

            // Get an array of all sub-directories DirectoryInfo objects.

            adiDirectories = diDirectory.GetDirectories();

       } catch
		{
            return;
        }

        foreach(DirectoryInfo di in adiDirectories)
		{

            // Create a child node for every sub-directory, passing in the directory
            // name and the images its node will use.

            TreeNode tnDir = new TreeNode(di.Name, 1, 2);

            // Add the new child node to the parent node.

            tn.Nodes.Add(tnDir);

            // We could now fill up the whole tree by recursively calling 
            // AddDirectories():
            //
            //   AddDirectories(tnDir)
            //
            // This is way too slow, however. Give it a try!
        }

    }

    // This subroutine clears out the existing TreeNode objects and rebuilds the 
    // DirectoryTreeView, showing the logical drives.

    public void RefreshTree()
	{

        // For performance reasons and to avoid TreeView "flickering" during an 
        // large node update, it is best to wrap the update code in BeginUpdate...
        // EndUpdate statements.

        BeginUpdate();
        Nodes.Clear();

        // Make disk drives the root nodes. 

        string[] astrDrives = Directory.GetLogicalDrives();

        foreach(string strDrive in astrDrives)
		{
			TreeNode tnDrive = new TreeNode(strDrive, 0, 0);
            Nodes.Add(tnDrive);
            AddDirectories(tnDrive);

            // Set the C drive the default selection.
            if (strDrive == @"C:\") 
			{
                this.SelectedNode = tnDrive;
            }

        }

        EndUpdate();

    }

}

