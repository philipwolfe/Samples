namespace ExplorerTreeViewTest
{
    #region Using directives

    using System;
    using System.IO;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    #endregion Using directives

    public class ExplorerTreeView : TreeView
    {
        private ImageList imageList = new ImageList();
        private Hashtable systemIcons = new Hashtable();

        private bool showFiles = false;
        private ShellIcon.IconSize iconSize;
        private Environment.SpecialFolder specialFolder;
        private ShellIcon.CSIDL pidl;
        private string root;

        public ExplorerTreeView()
        {
            // to enable transparent support in the treeview, make sure that you have
            // Application.EnableVisualStyles();
            // in your Main() function.

            this.ImageList = imageList;
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconSize = ShellIcon.IconSize.Small;

            this.ShowLines = true;
            this.ShowRootLines = false;

            this.MouseDown += new MouseEventHandler(mouseDown);
            this.BeforeExpand += new TreeViewCancelEventHandler(beforeExpand);
        }

        void mouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = this.GetNodeAt(e.X, e.Y);
            if (node == null)
                return;
            this.SelectedNode = node;
        }

        void beforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)e.Node;
                if (!node.Loaded)
                {
                    node.Nodes[0].Remove();
                    node.LoadDirectory();
                    if (this.showFiles == true)
                        node.LoadFiles();
                }
            }
        }

        internal int GetIconImageIndex(string path, ref string name)
        {
            return ShellIcon.GetIconImageIndex(
                path,
                iconSize,
                ref name,
                ref imageList,
                ref systemIcons);
        }

        internal int GetIconImageIndex(ShellIcon.CSIDL path, ref string name)
        {
            return ShellIcon.GetIconImageIndex(
                path,
                iconSize,
                ref name,
                ref imageList,
                ref systemIcons);
        }

        internal int GetIconImageIndex(Environment.SpecialFolder path, ref string name)
        {
            return ShellIcon.GetIconImageIndex(
                path,
                iconSize,
                ref name,
                ref imageList,
                ref systemIcons);
        }

        public void Clear()
        {
            systemIcons.Clear();
            imageList.Images.Clear();
            ImageList.Images.Clear();
            Nodes.Clear();
        }

        private void FillWithDesktop()
        {
            /* add the Desktop icon */
            ClassIdNode cn = new ClassIdNode(this, Environment.SpecialFolder.Desktop);

            // add the "My Documents" folder
            DirectoryNode node = new DirectoryNode(cn, Environment.SpecialFolder.Personal);

            // make it visable
            cn.Expand();

            // add all the drives
            cn = new ClassIdNode(cn, ShellIcon.CSIDL.CSIDL_DRIVES);
            string[] drives = System.IO.Directory.GetLogicalDrives();
            foreach (string drive in drives)
                node = new DirectoryNode(cn, new DirectoryInfo(drive));

            // make these nodes visable
            cn.Expand();
        }

        #region Attributes

        public string Root
        {
            get { return this.root; }
            set
            {
                // clear the treeview
                Clear();
                
                // search to see if this equates to a SpecialFolder
                foreach (Environment.SpecialFolder folder in Enum.GetValues(typeof(Environment.SpecialFolder)))
                {
                    string path = Environment.GetFolderPath(folder);
                    if (path == value)
                    {
                        SpecialFolder = folder;
                        return;
                    }
                }

                // search to see if this equates to a CSIDL
                foreach (ShellIcon.CSIDL pidl in Enum.GetValues(typeof(ShellIcon.CSIDL)))
                {
                    string path = ShellIcon.GetSpecialFolderPath(pidl);
                    if (path == value)
                    {
                        Pidl = pidl;
                        return;
                    }
                }

                // nope, it's just a path... so establish root
                this.root = value;
                this.pidl = 0;
                this.specialFolder = 0;

                // create the root node
                DirectoryNode node = new DirectoryNode(this, new DirectoryInfo(this.root));
                node.Expand();
            }
        }

        public Environment.SpecialFolder SpecialFolder
        {
            get { return this.specialFolder; }
            set
            {
                // clear the treeview
                Clear();

                // establish root
                this.root = Environment.GetFolderPath(value);
                this.pidl = 0;
                this.specialFolder = value;

                if (this.specialFolder == Environment.SpecialFolder.Desktop)
                {
                    FillWithDesktop();
                }
                else
                {
                    // create the root node
                    DirectoryNode node = new DirectoryNode(this, value);
                    node.Expand();
                }
            }
        }

        public ShellIcon.CSIDL Pidl
        {
            get { return this.pidl; }
            set
            {
                // clear the treeview
                Clear();

                // establish root
                this.root = ShellIcon.GetSpecialFolderPath(value);
                this.pidl = value;
                this.specialFolder = 0;

                // create the root node
                ClassIdNode node = new ClassIdNode(this, value);
                node.Expand();
            }
        }

        [CategoryAttribute("Behavior")]
        [Description("Add files to the tree.")]
        [DefaultValue(false)]
        public bool ShowFiles
        {
            get { return this.showFiles; }
            set { this.showFiles = value; }
        }

        [CategoryAttribute("Appearance")]
        [Description("The size of the icons.")]
        [DefaultValue(ShellIcon.IconSize.Small)]
        public ShellIcon.IconSize IconSize
        {
            get { return iconSize; }
            set
            {
                if (iconSize != value)
                {
                    iconSize = value;

                    Clear();

                    int s = (value==ShellIcon.IconSize.Small) ? 16 : 32;
                    this.ImageList.ImageSize = new System.Drawing.Size(s, s);
                }
            }
        }

        #endregion Attributes
    }

    #region TreeNode Classes

    #region ClassIdNode Class

    public class ClassIdNode : TreeNode
    {
        public ClassIdNode(TreeNode parent, ShellIcon.CSIDL id)
        {
            string name = String.Empty;
            this.SelectedImageIndex = this.ImageIndex = ((ExplorerTreeView)parent.TreeView).GetIconImageIndex(id, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
        }

        public ClassIdNode(TreeNode parent, Environment.SpecialFolder path)
        {
            string name = String.Empty;
            this.SelectedImageIndex = this.ImageIndex = ((ExplorerTreeView)parent.TreeView).GetIconImageIndex(path, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
        }

        public ClassIdNode(ExplorerTreeView parent, ShellIcon.CSIDL id)
        {
            string name = String.Empty;
            this.SelectedImageIndex = this.ImageIndex = parent.GetIconImageIndex(id, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
        }

        public ClassIdNode(ExplorerTreeView parent, Environment.SpecialFolder path)
        {
            string name = String.Empty;
            this.SelectedImageIndex = this.ImageIndex = parent.GetIconImageIndex(path, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
        }

        public bool Loaded
        {
            get
            {
                if (this.Nodes.Count != 0)
                {
                    if (this.Nodes[0] is FakeChildNode)
                        return false;
                }
                return true;
            }
        }

        public new ExplorerTreeView TreeView
        {
            get { return (ExplorerTreeView)base.TreeView; }
        }
    }

    #endregion ClassIdNode Class

    #region DirectoryNode Class
    
    public class DirectoryNode : TreeNode
    {
        private DirectoryInfo directoryInfo;

        public DirectoryNode(TreeNode parent, DirectoryInfo directoryInfo)
        {
            string name = String.Empty;
            this.directoryInfo = directoryInfo;
            this.SelectedImageIndex = this.ImageIndex = ((ExplorerTreeView)parent.TreeView).GetIconImageIndex(directoryInfo.FullName, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
            Virtualize();
        }

        public DirectoryNode(TreeNode parent, Environment.SpecialFolder path)
        {
            string name = String.Empty;
            this.directoryInfo = new DirectoryInfo(Environment.GetFolderPath(path));
            this.SelectedImageIndex = this.ImageIndex = ((ExplorerTreeView)parent.TreeView).GetIconImageIndex(path, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
            Virtualize();
        }

        public DirectoryNode(TreeNode parent, DirectoryInfo directoryInfo, ShellIcon.CSIDL id)
        {
            string name = String.Empty;
            this.directoryInfo = directoryInfo;
            this.SelectedImageIndex = this.ImageIndex = ((ExplorerTreeView)parent.TreeView).GetIconImageIndex(id, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
            Virtualize();
        }

        public DirectoryNode(ExplorerTreeView parent, DirectoryInfo directoryInfo)
        {
            string name = String.Empty;
            this.directoryInfo = directoryInfo;
            this.SelectedImageIndex = this.ImageIndex = parent.GetIconImageIndex(directoryInfo.FullName, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
            Virtualize();
        }

        public DirectoryNode(ExplorerTreeView parent, Environment.SpecialFolder path)
        {
            string name = String.Empty;
            this.directoryInfo = new DirectoryInfo(Environment.GetFolderPath(path));
            this.SelectedImageIndex = this.ImageIndex = parent.GetIconImageIndex(path, ref name);
            this.Text = name;
            parent.Nodes.Add(this);
            Virtualize();
        }

        void Virtualize()
        {
            int fileCount = 0;
            try
            {
                if (Directory.Exists(this.directoryInfo.FullName))
                {
                    if (this.TreeView.ShowFiles == true)
                        fileCount = this.directoryInfo.GetFiles().Length;

                    if ((fileCount + this.directoryInfo.GetDirectories().Length) > 0)
                        new FakeChildNode(this);
                }
            }
            catch
            {
            }
        }

        public void LoadDirectory()
        {
            foreach (DirectoryInfo di in directoryInfo.GetDirectories())
            {
                new DirectoryNode(this, di);
            }
        }

        public void LoadFiles()
        {
            foreach (FileInfo fi in directoryInfo.GetFiles())
            {
                new FileNode(this, fi);
            }
        }

        public bool Loaded
        {
            get
            {
                if (this.Nodes.Count != 0)
                {
                    if (this.Nodes[0] is FakeChildNode)
                        return false;
                }
                return true;
            }
        }

        public string FullName
        {
            get { return directoryInfo.FullName; }
        }

        public new ExplorerTreeView TreeView
        {
            get { return (ExplorerTreeView)base.TreeView; }
        }
    }

    #endregion DirectoryNode Class

    #region FileNode Class

    public class FileNode : TreeNode
    {
        private FileInfo fileInfo;
        private DirectoryNode directoryNode;

        public FileNode(DirectoryNode directoryNode, FileInfo fileInfo)
        {
            string name = String.Empty;
            this.directoryNode = directoryNode;
            this.fileInfo = fileInfo;
            this.SelectedImageIndex = this.ImageIndex = ((ExplorerTreeView)directoryNode.TreeView).GetIconImageIndex(fileInfo.FullName, ref name);
            this.Text = name;
            directoryNode.Nodes.Add(this);
        }
    }

    #endregion FileNode Class

    #region FakeChildNode Class

    public class FakeChildNode : TreeNode
    {
        public FakeChildNode(TreeNode parent)
        {
            parent.Nodes.Add(this);
        }
    }

    #endregion FakeChildNode Class

    #endregion TreeNode Classes

}