//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.TreeViewCtl {
                    
    using System;
    using System.IO;
    using System.Resources;   
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using Microsoft.Win32.Interop;

    // <doc>
    // <desc>
    //     This sample demonstrates how to use the Treeview control
    // </desc>
    // </doc>
    //
    public class TreeViewCtl : System.WinForms.Form {

        public TreeViewCtl() {
            //
            // Required for Win Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            //BUG BUG: 31070
            imageList1.Images.Add((Bitmap)resources.GetObject("ClosedFolder"));
            imageList1.Images.Add((Bitmap)resources.GetObject("OpenFolder"));
            imageList2.Images.Add((Bitmap)resources.GetObject("club"));
            imageList2.Images.Add((Bitmap)resources.GetObject("diamond"));

            FillDirectoryTree();
            imageListComboBox.SelectedIndex = 1;
            indentUpDown.Value = directoryTree.Indent;
        }

        /// <summary>
        ///    Clean up any resources being used
        /// </summary>
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        // <doc>
        // <desc>
        //     For a given root directory (or drive), add the directories to the
        //     directoryTree.
        // </desc>
        // </doc>
        //
        private void AddDirectories(TreeNode node) {
            try {
                Directory dir = new Directory(GetPathFromNode(node));
                Directory[] e = dir.GetDirectories();

                for (int i = 0; i < e.Length; i++) {
                    string name = e[i].Name;    
                    if (!name.Equals(".") && !name.Equals("..")) {
                        node.Nodes.Add(new DirectoryNode(name));
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        // <doc>
        // <desc>
        //     For a given node, add the sub-directories for node's children in the
        //     directoryTree.
        // </desc>
        // </doc>
        //
        private void AddSubDirectories(DirectoryNode node) {
            for (int i = 0; i < node.Nodes.Count; i++) {
                AddDirectories(node.Nodes[i]);
            }
            node.SubDirectoriesAdded = true;
        }

        // <doc>
        // <desc>
        //     Event handler for the afterSelect event on the directoryTree. Change the
        //     title bar to show the path of the selected directoryNode.
        // </desc>
        // </doc>
        //
        private void directoryTree_AfterSelect(object source, TreeViewEventArgs e) {
            Text = "WinForms File Explorer - " + e.node.Text;
        }

        // <doc>
        // <desc>
        //     Event handler for the beforeExpand event on the directoryTree. If the
        //     node is not already expanded, expand it.
        // </desc>
        // </doc>
        //
        private void directoryTree_BeforeExpand(object source, TreeViewCancelEventArgs e) {
            DirectoryNode nodeExpanding = (DirectoryNode)e.node;
            if (!nodeExpanding.SubDirectoriesAdded)
                AddSubDirectories(nodeExpanding);
        }

        // <doc>
        // <desc>
        //      For initializing the directoryTree upon creation of the TreeViewCtl form.
        // </desc>
        // </doc>
        //
        private void FillDirectoryTree() {
//            string[] drives = File.GetLogicalDrives();
            string[] drives = Environment.GetLogicalDrives();
            for (int i = 0; i < drives.Length; i++) {
                if (PlatformInvokeKernel32.GetDriveType(drives[i]) == win.DRIVE_FIXED) { 
                    DirectoryNode cRoot = new DirectoryNode(drives[i]);
                    directoryTree.Nodes.Add(cRoot);
                    AddDirectories(cRoot);
                }
            }
        }

        // <doc>
        // <desc>
        //        Returns the directory path of the node.
        // </desc>
        // <retvalue>
        //        Directory path of node.
        // </retvalue>
        // </doc>
        //
        private string GetPathFromNode(TreeNode node) {
            if (node.Parent == null) {
                return node.Text;
            }
            return Directory.Combine(GetPathFromNode(node.Parent), node.Text);
        }

        // <doc>
        // <desc>
        //        Refresh helper functions to get all expanded nodes under the given
        //        node. 
        // </desc>
        // <param term='expandedNodes'>
        //        Reference to an array of paths containing all nodes which were in the 
        //        expanded state when Refresh was requested.
        // </param>
        // <param term='startIndex'>
        //        Array index of ExpandedNodes to start adding entries to.
        // </param>
        // <retvalue>
        //        New StartIndex, i.e. given value of StartIndex + number of entries 
        //        added to ExpandedNodes.
        // </retvalue>
        // </doc>
        //
        private int Refresh_GetExpanded(TreeNode Node, string[] ExpandedNodes, int StartIndex) {
            
            if (StartIndex < ExpandedNodes.Length) {
                if (Node.IsExpanded) {
                    ExpandedNodes[StartIndex] = Node.Text;
                    StartIndex++;
                    for (int i = 0; i < Node.Nodes.Count; i++) {
                        StartIndex = Refresh_GetExpanded(Node.Nodes[i], 
                                                         ExpandedNodes,
                                                         StartIndex);
                    }
                }
                return StartIndex;
            } 
            return -1;
        }

        // <doc>
        // <desc>
        //        Refresh helper function to expand all nodes whose paths are in parameter
        //        ExpandedNodes.
        // </desc>
        // <param term='node'>
        //        Node from which to start expanding.
        // </param>
        // <param term='expandedNodes'>
        //        Array of strings with the path names of all nodes to expand.
        // </param>
        // </doc>
        //
        private void Refresh_Expand(TreeNode Node, string[] ExpandedNodes) {
            
            for (int i = ExpandedNodes.Length - 1; i >= 0; i--) {
                if (ExpandedNodes[i] == Node.Text) {
                    /*
                    * For the expand button to show properly, one level of 
                    * invisible children have to be added to the tree. 
                    */
                    AddSubDirectories((DirectoryNode) Node);
                    Node.Expand();

                    /* If the node is expanded, expand any children that were 
                    * expanded before the refresh. 
                    */
                    for (int j = 0; j < Node.Nodes.Count; j++) {
                        Refresh_Expand(Node.Nodes[j], ExpandedNodes);
                    }

                    return;
                }
            }
        }

        // <doc>
        // <desc>
        //     Refreshes the view by deleting all the nodes and restoring them by
        //     reading the disk(s). Any expanded nodes in the directoryView will be
        //     expanded after the refresh.
        // </desc>
        // <param term='node'>
        //     - Node from which the refresh begins. Generally, this is
        //     the root.
        // </param>
        // </doc>
        //
        private void Refresh(TreeNode node) {
            // Update the directoryTree
            if (node.Nodes.Count > 0) {
                if (node.IsExpanded) {
                    // Save all expanded nodes rooted at node, even those that are
                    // indirectly rooted.
                    string[] tooBigExpandedNodes = new string[node.GetNodeCount(true)];
                    int iExpandedNodes = Refresh_GetExpanded(node,
                        tooBigExpandedNodes,
                        0);
                    string[] expandedNodes = new string[iExpandedNodes];
                    Array.Copy(tooBigExpandedNodes, 0, expandedNodes, 0,
                        iExpandedNodes);

                    node.Nodes.Clear();
                    AddDirectories(node);

                    // so children with subdirectories show up with expand/collapse
                    //button.
                    AddSubDirectories((DirectoryNode)node);
                    node.Expand();

                    /*
                     * check all children. Some might have had sub-directories added
                     * from an external application so previous childless nodes
                     * might now have children.
                     */
                    for (int j = 0; j < node.Nodes.Count ; j++) {
                        if (node.Nodes[j].Nodes.Count > 0) {
                            // If the child has subdirectories. If it was expanded
                            // before the refresh, then expand after the refresh.
                            Refresh_Expand(node.Nodes[j], expandedNodes);
                        }
                    }
                } else {
                    /*
                     * If the node is not expanded, then there is no need to check
                     * if any of the children were expanded. However, we should
                     * update the tree by reading the drive in case an external
                     * application add/removed any directories.
                     */
                    node.Nodes.Clear();
                    AddDirectories(node);
                }
            } else {
                /*
                 * Again, if there are no children, then there is no need to
                 * worry about expanded nodes but if an external application
                 * add/removed any directories we should reflect that.
                 */
                node.Nodes.Clear();
                AddDirectories(node);
            }
        }

        private void checkBox1_Click(object source, EventArgs e) {
            this.directoryTree.Sorted = checkBox1.Checked;
            for (int i = 0; i < directoryTree.Nodes.Count; i++) {
                Refresh(directoryTree.Nodes[i]);
            }

        }

        private void imageListComboBox_SelectedIndexChanged(object source, EventArgs e) {
            int index = imageListComboBox.SelectedIndex;
            if (index == 0) {
                directoryTree.ImageList = null;
            } else if (index == 1) {
                directoryTree.ImageList = imageList1;
            } else {
                directoryTree.ImageList = imageList2;
            }

        }

        private void indentUpDown_ValueChanged(Object source, EventArgs e) {
            directoryTree.Indent = (int)indentUpDown.Value;
        }

        private void CheckBox2_click(object source, EventArgs e) {
            this.directoryTree.HotTracking = checkBox2.Checked;
        }

        private void CheckBox3_click(object source, EventArgs e) {
            this.directoryTree.ShowLines = checkBox3.Checked;
        }

        private void CheckBox4_click(object source, EventArgs e) {
            this.directoryTree.ShowRootLines = checkBox4.Checked;

        }
        private void CheckBox5_click(object source, EventArgs e) {
            this.directoryTree.ShowPlusMinus = checkBox5.Checked;
        }


        private void CheckBox6_click(object source, EventArgs e) {
            this.directoryTree.CheckBoxes = checkBox6.Checked;
        }


        private void CheckBox7_click(object source, EventArgs e) {
            this.directoryTree.HideSelection = checkBox7.Checked;
        }

        private System.ComponentModel.Container components;
        private System.WinForms.TreeView directoryTree;
        private System.WinForms.ImageList imageList1;
        private System.WinForms.ImageList imageList2;
        private System.WinForms.GroupBox grpTreeView;
        private System.WinForms.CheckBox checkBox1;
        private System.WinForms.ComboBox imageListComboBox;
        private System.WinForms.Label label1;
        private System.WinForms.NumericUpDown indentUpDown;
        private System.WinForms.Label label4;
        private System.WinForms.CheckBox checkBox2;
        private System.WinForms.CheckBox checkBox3;
        private System.WinForms.CheckBox checkBox4;
        private System.WinForms.CheckBox checkBox5;
        private System.WinForms.CheckBox checkBox6;
        private System.WinForms.CheckBox checkBox7;
        private System.WinForms.ToolTip toolTip1;
        private System.Resources.ResourceManager resources;

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor
        /// </summary>
        private void InitializeComponent() {
            resources = new System.Resources.ResourceManager("TreeViewCtl", typeof(TreeViewCtl), null, true);
        
            this.components = new System.ComponentModel.Container();
            this.checkBox7 = new System.WinForms.CheckBox();
            this.directoryTree = new System.WinForms.TreeView();
            this.checkBox5 = new System.WinForms.CheckBox();
            this.label4 = new System.WinForms.Label();
            this.indentUpDown = new System.WinForms.NumericUpDown();
            this.imageList2 = new System.WinForms.ImageList();
            this.toolTip1 = new System.WinForms.ToolTip(components);
            this.checkBox6 = new System.WinForms.CheckBox();
            this.checkBox1 = new System.WinForms.CheckBox();
            this.checkBox3 = new System.WinForms.CheckBox();
            this.imageList1 = new System.WinForms.ImageList();
            this.imageListComboBox = new System.WinForms.ComboBox();
            this.checkBox4 = new System.WinForms.CheckBox();
            this.grpTreeView = new System.WinForms.GroupBox();
            this.checkBox2 = new System.WinForms.CheckBox();
            this.label1 = new System.WinForms.Label();
        
            checkBox7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            checkBox7.Location = new System.Drawing.Point(16, 160);
            checkBox7.TabIndex = 6;
            checkBox7.CheckState = System.WinForms.CheckState.Checked;
            checkBox7.Text = "hideSelected";
            checkBox7.Size = new System.Drawing.Size(100, 23);
            checkBox7.Checked = true;
            toolTip1.SetToolTip(checkBox7, "Removes highlight from selected node when the control doesn\'t have focus.");
            checkBox7.Click += new EventHandler(CheckBox7_click);
        
            directoryTree.ImageList = (ImageList)imageList1;
            directoryTree.ForeColor = (Color)System.Drawing.SystemColors.WindowText;
            directoryTree.Location = new System.Drawing.Point(24, 16);
            directoryTree.AllowDrop = true;
            directoryTree.TabIndex = 0;
            directoryTree.Indent = 19;
            directoryTree.Text = "treeView1";
            directoryTree.SelectedImageIndex = 1;
            directoryTree.Size = new System.Drawing.Size(200, 264);
            toolTip1.SetToolTip(directoryTree, "Indicates whether lines are shown between sibling nodes and b etween parent and children nodes");
            directoryTree.AfterSelect += new TreeViewEventHandler(directoryTree_AfterSelect);
            directoryTree.BeforeExpand += new TreeViewCancelEventHandler(directoryTree_BeforeExpand);
        
            checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            checkBox5.Location = new System.Drawing.Point(16, 112);
            checkBox5.TabIndex = 4;
            checkBox5.CheckState = System.WinForms.CheckState.Checked;
            checkBox5.Text = "showPlusMinus";
            checkBox5.Size = new System.Drawing.Size(100, 23);
            checkBox5.Checked = true;
            toolTip1.SetToolTip(checkBox5, "Indicates if plus/minus button are shown next to parents.");
            checkBox5.Click += new EventHandler(CheckBox5_click);
        
            label4.Location = new System.Drawing.Point(16, 224);
            label4.TabIndex = 9;
            label4.TabStop = false;
            label4.Text = "indent:";
            label4.Size = new System.Drawing.Size(48, 16);
        
            indentUpDown.Location = new System.Drawing.Point(88, 224);
            indentUpDown.Maximum = new System.Decimal(150d);
            indentUpDown.Minimum = new System.Decimal(18d);
            indentUpDown.TabIndex = 10;
            indentUpDown.Text = "18";
                      indentUpDown.DecimalPlaces = 0;
            indentUpDown.Size = new System.Drawing.Size(120, 20);
            toolTip1.SetToolTip(indentUpDown, "The indentation width of a child node in pixels.");
            indentUpDown.ValueChanged += new EventHandler(indentUpDown_ValueChanged);
        
            //imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = (Color)System.Drawing.Color.Transparent;
            //@design imageList2.SetLocation(new System.Drawing.Point(20, 40));
        
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(502, 293);
            this.Text = "TreeView";
        
            toolTip1.Active = true;
            //@design toolTip1.SetLocation(new System.Drawing.Point(20, 70));
        
            checkBox6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            checkBox6.Location = new System.Drawing.Point(16, 136);
            checkBox6.TabIndex = 5;
            checkBox6.Text = "checkBoxes";
            checkBox6.Size = new System.Drawing.Size(100, 23);
            toolTip1.SetToolTip(checkBox6, "Indicates wheter checkboxes are displayed beside nodes");
            checkBox6.Click += new EventHandler(CheckBox6_click);
        
            checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            checkBox1.Location = new System.Drawing.Point(16, 16);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "sorted";
            checkBox1.Size = new System.Drawing.Size(100, 23);
            toolTip1.SetToolTip(checkBox1, "Indicates whether nodes are sorted.");
            checkBox1.Click += new EventHandler(checkBox1_Click);
        
            checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            checkBox3.Location = new System.Drawing.Point(16, 64);
            checkBox3.TabIndex = 2;
            checkBox3.CheckState = System.WinForms.CheckState.Checked;
            checkBox3.Text = "showLines";
            checkBox3.Size = new System.Drawing.Size(100, 23);
            checkBox3.Checked = true;
            toolTip1.SetToolTip(checkBox3, "Indicates whether lines are displayed between sibling nodes and between parent and children nodes.");
            checkBox3.Click += new EventHandler(CheckBox3_click);
        
            //imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = (Color)System.Drawing.Color.Transparent;
            //@design imageList1.SetLocation(new System.Drawing.Point(20, 10));
        
            imageListComboBox.ForeColor = (Color)System.Drawing.SystemColors.WindowText;
            imageListComboBox.Location = new System.Drawing.Point(88, 192);
            imageListComboBox.TabIndex = 8;
            imageListComboBox.Text = "";
            imageListComboBox.Size = new System.Drawing.Size(120, 21);
            imageListComboBox.SelectedIndexChanged += new EventHandler(imageListComboBox_SelectedIndexChanged);
            imageListComboBox.Items.All = (object[])new object[] {"(none)", "system images", "bitmaps"};
        
            checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            checkBox4.Location = new System.Drawing.Point(16, 88);
            checkBox4.TabIndex = 3;
            checkBox4.CheckState = System.WinForms.CheckState.Checked;
            checkBox4.Text = "showRootLines";
            checkBox4.Size = new System.Drawing.Size(100, 23);
            checkBox4.Checked = true;
            toolTip1.SetToolTip(checkBox4, "Indicates whether lines are displayed between root nodes.");
            checkBox4.Click += new EventHandler(CheckBox4_click);
        
            grpTreeView.Location = new System.Drawing.Point(248, 16);
            grpTreeView.TabIndex = 1;
            grpTreeView.TabStop = false;
            grpTreeView.Text = "TreeView";
            grpTreeView.Size = new System.Drawing.Size(248, 264);
        
            checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            checkBox2.Location = new System.Drawing.Point(16, 40);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "hotTracking";
            checkBox2.Size = new System.Drawing.Size(100, 23);
            toolTip1.SetToolTip(checkBox2, "Indicates whether nodes give feedback when the mouse is moved over them.");
            checkBox2.Click += new EventHandler(CheckBox2_click);
        
            label1.Location = new System.Drawing.Point(16, 194);
            label1.TabIndex = 7;
            label1.TabStop = false;
            label1.Text = "imageList:";
            label1.Size = new System.Drawing.Size(56, 16);
        
            grpTreeView.Controls.Add(checkBox7);
            grpTreeView.Controls.Add(checkBox6);
            grpTreeView.Controls.Add(checkBox5);
            grpTreeView.Controls.Add(checkBox4);
            grpTreeView.Controls.Add(checkBox3);
            grpTreeView.Controls.Add(checkBox2);
            grpTreeView.Controls.Add(label4);
            grpTreeView.Controls.Add(indentUpDown);
            grpTreeView.Controls.Add(label1);
            grpTreeView.Controls.Add(imageListComboBox);
            grpTreeView.Controls.Add(checkBox1);
            this.Controls.Add(grpTreeView);
            this.Controls.Add(directoryTree);
        
        }

        // <doc>
        // <desc>
        //        The main entry point for the application. 
        // </desc>
        // <param term='args'>
        //        Array of parameters passed to the application via the command line.
        // </param>
        // </doc>
        //
        public static void Main(string[] args) { 
            Application.Run(new TreeViewCtl());
        }


        // <doc>
        // <desc>
        //        Declare native function to determine drive type
        // </desc>
        // </doc>
        //
        public class PlatformInvokeKernel32 {   
            [sysimport(dll="kernel32", charset=System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int GetDriveType(string lpRootPathName);  
        }
    }
}


