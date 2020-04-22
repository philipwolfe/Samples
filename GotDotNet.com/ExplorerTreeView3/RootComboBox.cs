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
    
    public class RootComboBox : System.Windows.Forms.ComboBox
	{
        private ArrayList nodes = new ArrayList();
        private ImageList imageList = new ImageList();
        private Hashtable systemIcons = new Hashtable();
        private ShellIcon.IconSize iconSize;
        private int iconWidth;

        public RootComboBox()
		{
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.drawItem);

            // to enable transparent support in the treeview, make sure that you have
            // Application.EnableVisualStyles();
            // in your Main() function.

            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconSize = ShellIcon.IconSize.Small;

            FillWithDesktop();
        }

        public void Clear()
        {
            systemIcons.Clear();
            imageList.Images.Clear();
            nodes.Clear();
        }

        public void FillWithDesktop()
        {
            Clear();

            base.Refresh();

            /* add the Desktop icon */
            nodes.Add(new SpecialFolderNode(this, Environment.SpecialFolder.Desktop));

            // add the "My Documents" folder
            nodes.Add(new SpecialFolderNode(this, Environment.SpecialFolder.Personal));

            // add all the drives
            string[] drives = System.IO.Directory.GetLogicalDrives();
            foreach (string drive in drives)
                nodes.Add(new PathNode(this, drive));

            this.DataSource = nodes;
        }

        public void AddNode(string path)
        {
            nodes.Add(new PathNode(this, path));
        }

        public void AddNode(ShellIcon.CSIDL path)
        {
            nodes.Add(new PidlNode(this, path));
        }

        public void AddNode(Environment.SpecialFolder path)
        {
            nodes.Add(new SpecialFolderNode(this, path));
        }

        private void drawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        { 
            if (e.Index < 0 || e.Index > nodes.Count)
                return;
            Node node = (Node)nodes[e.Index];
            if (node == null)
                return;

            Color fore = this.ForeColor;
            Color back = this.BackColor;
            if ((e.State & DrawItemState.Focus) != 0)
            {                                                    
                back = SystemColors.Highlight;
                fore = SystemColors.HighlightText;
            }

            e.Graphics.FillRectangle(new SolidBrush(back), e.Bounds); 

            imageList.Draw(e.Graphics, e.Bounds.X+1, e.Bounds.Y+1, iconWidth, iconWidth, node.index);
 
            e.Graphics.DrawString(
                node.label,
                this.Font,
                new SolidBrush(fore), 
                new Point(e.Bounds.X + iconWidth + 2, e.Bounds.Y+1));       
        }                                                                

        #region Attributes
        
        public RootComboBox.Node SelectedNode
        {
            get
            {
                return (Node)this.SelectedItem;
            }
        }

        [CategoryAttribute("Appearance")]
        [Description("The size of the icons.")]
        [DefaultValue(ShellIcon.IconSize.Small)]
        public ShellIcon.IconSize IconSize
        {
            get { return iconSize; }
            set
            {
                iconSize = value;

                Clear();

                iconWidth = (value==ShellIcon.IconSize.Small) ? 16 : 32;
                this.imageList.ImageSize = new System.Drawing.Size(iconWidth, iconWidth);
                this.ItemHeight = iconWidth + 2;
            }
        }

        #endregion Attributes

        #region GetIconImage

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

        #endregion GetIconImage

        #region Nodes

        public class Node
        {
            public int id;
            public string path;
            public string label;
            public int index;
        }

        public class PathNode : Node
        {
            public PathNode(RootComboBox parent, string _path)
            {
                string name = String.Empty;
                this.path = _path;
                this.index = parent.GetIconImageIndex(_path, ref name);
                this.label = name;
            }
        }

        public class PidlNode : Node
        {
            public PidlNode(RootComboBox parent, ShellIcon.CSIDL _path)
            {
                this.id = (int)_path;
                string name = String.Empty;
                this.path = ShellIcon.GetSpecialFolderPath(_path);
                this.index = parent.GetIconImageIndex(_path, ref name);
                this.label = name;
            }
        }

        public class SpecialFolderNode : Node
        {
            public SpecialFolderNode(RootComboBox parent, Environment.SpecialFolder _path)
            {
                this.id = (int)_path;
                string name = String.Empty;
                this.path = Environment.GetFolderPath(_path);
                this.index = parent.GetIconImageIndex(_path, ref name);
                this.label = name;
            }
        }

        #endregion Nodes
    }
}
