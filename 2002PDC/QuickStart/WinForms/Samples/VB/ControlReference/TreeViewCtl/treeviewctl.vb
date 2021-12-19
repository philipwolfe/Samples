'------------------------------------------------------------------------------
' <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'       
'    This source code is intended only as a supplement to Microsoft
'    Development Tools and/or on-line documentation.  See these other
'    materials for detailed information regarding Microsoft code samples.
'
' </copyright>                                                                
'------------------------------------------------------------------------------

Imports System
Imports System.IO
Imports System.Resources   
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms
Imports Microsoft.Win32.Interop

Option Explicit
Option Strict Off

Namespace Microsoft.Samples.WinForms.Vb.TreeViewCtl 
    				

    ' <doc>
    ' <desc>
    '     This sample demonstrates how to use the Treeview control
    ' </desc>
    ' </doc>
    '
    public class TreeViewCtl
    Inherits System.WinForms.Form 

        public Sub New() 
	    MyBase.New()
            
            ' This call is required for support of the WinForms Form Designer
            InitializeComponent()		

            'BUG BUG: 31070
            'imageList1.Images.Add((Bitmap)resources.GetObject("ClosedFolder"))
            'imageList1.Images.Add((Bitmap)resources.GetObject("OpenFolder"))
            'imageList2.Images.Add((Bitmap)resources.GetObject("club"))
            'imageList2.Images.Add((Bitmap)resources.GetObject("diamond"))

            imageList1.Images.Add(System.Drawing.Image.FromFile("clsdfold.bmp"))
            imageList1.Images.Add(System.Drawing.Image.FromFile("openfold.bmp"))
            imageList2.Images.Add(System.Drawing.Image.FromFile("club.bmp"))
            imageList2.Images.Add(System.Drawing.Image.FromFile("diamond.bmp"))

            FillDirectoryTree()
            imageListComboBox.SelectedIndex = 1
            indentUpDown.Value = directoryTree.Indent


        End Sub

        ' <doc>
        ' <desc>
        '     TreeViewCtl overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        overrides public Sub Dispose() 
            MyBase.Dispose()
            components.Dispose()
        End Sub


        ' <doc>
        ' <desc>
        '     For a given root directory (or drive), add the directories to the
        '     directoryTree.
        ' </desc>
        ' </doc>
        '
        private Sub AddDirectories(node As TreeNode) 
            try 
		Dim dir As new Directory(GetPathFromNode(node))
		Dim e() As Directory = dir.GetDirectories()
		Dim i As Integer

		for i = 0  to e.Length-1
                    Dim name As string = e(i).Name	
                    if (Not name.Equals(".")) AND (Not name.Equals("..")) Then
	                    node.Nodes.Add(new DirectoryNode(name))
		    end if
                next
            
            catch ex As IOException
            
	    end try

        end sub

        ' <doc>
        ' <desc>
        '     For a given node, add the sub-directories for node's children in the
        '     directoryTree.
        ' </desc>
        ' </doc>
        '
        private Sub AddSubDirectories(node As DirectoryNode) 
	    Dim i As integer
            for i = 0 To node.Nodes.Count-1
                AddDirectories(node.Nodes(i))
            next
            node.SubDirectoriesAdded = true
        end sub


        ' <doc>
        ' <desc>
        '     Event handler for the afterSelect event on the directoryTree. Change the
        '     title bar to show the path of the selected directoryNode.
        ' </desc>
        ' </doc>
        '
        private Sub directoryTree_AfterSelect(source As object, e As TreeViewEventArgs) 
            Me.Text = "WinForms File Explorer - " & e.node.Text
        end sub

        ' <doc>
        ' <desc>
        '     Event handler for the beforeExpand event on the directoryTree. If the
        '     node is not already expanded, expand it.
        ' </desc>
        ' </doc>
        '
        private Sub directoryTree_BeforeExpand(source As Object, e As TreeViewCancelEventArgs) 
            Dim nodeExpanding As DirectoryNode = e.node
            if Not nodeExpanding.SubDirectoriesAdded Then AddSubDirectories(nodeExpanding)
        end sub


        ' <doc>
        ' <desc>
        '      For initializing the directoryTree upon creation of the TreeViewCtl form.
        ' </desc>
        ' </doc>
        '
        private Sub FillDirectoryTree() 
'            Dim drives() As String = File.GetLogicalDrives()
            Dim drives() As String = Environment.GetLogicalDrives()
	    Dim i As Integer
            for i = 0 to drives.Length-1
                if (PlatformInvokeKernel32.GetDriveType(drives(i)) = win.DRIVE_FIXED) Then 
                    Dim cRoot As new DirectoryNode(drives(i))
                    directoryTree.Nodes.Add(cRoot)
                    AddDirectories(cRoot)
                end if
            next
        end sub

        ' <doc>
        ' <desc>
        '        Returns the directory path of the node.
        ' </desc>
        ' <retvalue>
        '        Directory path of node.
        ' </retvalue>
        ' </doc>
        '
        private function GetPathFromNode(node As TreeNode) As String 
            if (node.Parent = Nothing) Then return node.Text
            
            return Directory.Combine(GetPathFromNode(node.Parent), node.Text)
        end function


        ' <doc>
        ' <desc>
        '        Refresh helper functions to get all expanded nodes under the given
        '        node. 
        ' </desc>
        ' <param term='expandedNodes'>
        '        Reference to an array of paths containing all nodes which were in the 
        '        expanded state when Refresh was requested.
        ' </param>
        ' <param term='startIndex'>
        '        Array index of ExpandedNodes to start adding entries to.
        ' </param>
        ' <retvalue>
        '        New StartIndex, i.e. given value of StartIndex + number of entries 
        '        added to ExpandedNodes.
        ' </retvalue>
        ' </doc>
        '
        private function Refresh_GetExpanded(node As TreeNode, ExpandedNodes() As String, StartIndex As Integer) As integer
            
            if (StartIndex < ExpandedNodes.Length) Then
                if (Node.IsExpanded) Then
                    ExpandedNodes(StartIndex) = Node.Text
                    StartIndex += 1
		    Dim i As Integer
                    for i = 0 to Node.Nodes.Count-1 
                        StartIndex = Refresh_GetExpanded(Node.Nodes(i), ExpandedNodes, StartIndex)
                    next
                end if
                return StartIndex
            end if
            return -1
        end function

        ' <doc>
        ' <desc>
        '        Refresh helper function to expand all nodes whose paths are in parameter
        '        ExpandedNodes.
        ' </desc>
        ' <param term='node'>
        '        Node from which to start expanding.
        ' </param>
        ' <param term='expandedNodes'>
        '        Array of strings with the path names of all nodes to expand.
        ' </param>
        ' </doc>
        '
        private Sub Refresh_Expand(Node As TreeNode, ExpandedNodes() As String) 
            Dim i As Integer = ExpandedNodes.Length - 1
            While i >= 0 
                if (ExpandedNodes(i) = Node.Text) then
                    '
                    ' For the expand button to show properly, one level of 
                    ' invisible children have to be added to the tree. 
                    '
                    AddSubDirectories(Node)
                    Node.Expand()

                    ' If the node is expanded, expand any children that were 
                    ' expanded before the refresh. 
                    '
		    Dim j As Integer
                    for j = 0 to Node.Nodes.Count-1 
                        Refresh_Expand(Node.Nodes(j), ExpandedNodes)
                    next

                    Exit Sub
                end  if
		i -= 1
            end while
        end sub

        ' <doc>
        ' <desc>
        '     Refreshes the view by deleting all the nodes and restoring them by
        '     reading the disk(s). Any expanded nodes in the directoryView will be
        '     expanded after the refresh.
        ' </desc>
        ' <param term='node'>
        '     - Node from which the refresh begins. Generally, this is
        '     the root.
        ' </param>
        ' </doc>
        '
        overloads private Sub Refresh(node As TreeNode) 
            ' Update the directoryTree
            if (node.Nodes.Count > 0) Then
                if (node.IsExpanded) Then
                    ' Save all expanded nodes rooted at node, even those that are
                    ' indirectly rooted.
                    Dim tooBigExpandedNodes(node.GetNodeCount(true)) As String
                    Dim iExpandedNodes As Integer = Refresh_GetExpanded(node, tooBigExpandedNodes, 0)
                    Dim expandedNodes(iExpandedNodes) As String
                    Array.Copy(tooBigExpandedNodes, 0, expandedNodes, 0, iExpandedNodes)

                    node.Nodes.Clear()
                    AddDirectories(node)

                    ' so children with subdirectories show up with expand/collapse
                    ' button.
                    AddSubDirectories(node)
                    node.Expand()

                    '
                    ' check all children. Some might have had sub-directories added
                    ' from an external application so previous childless nodes
                    ' might now have children.
                    '
		    Dim j As Integer
                    for j = 0 to node.Nodes.Count-1
                        if (node.Nodes(j).Nodes.Count > 0) Then
                            ' If the child has subdirectories. If it was expanded
                            ' before the refresh, then expand after the refresh.
                            Refresh_Expand(node.Nodes(j), expandedNodes)
                        end if
                    next
                else 
                    '
                    ' If the node is not expanded, then there is no need to check
                    ' if any of the children were expanded. However, we should
                    ' update the tree by reading the drive in case an external
                    ' application add/removed any directories.
                    '
                    node.Nodes.Clear()
                    AddDirectories(node)
                end if
            else 
                '
                ' Again, if there are no children, then there is no need to
                ' worry about expanded nodes but if an external application
                ' add/removed any directories we should reflect that.
                '
                node.Nodes.Clear()
                AddDirectories(node)
            end if
        end sub

        private Sub checkBox1_Click(source As Object, e As EventArgs)
            Me.directoryTree.Sorted = checkBox1.Checked
	    Dim i As Integer
            for i = 0 to directoryTree.Nodes.Count-1 
                Refresh(directoryTree.Nodes(i))
            next

        end sub

        private Sub imageListComboBox_SelectedIndexChanged(source As Object, e As EventArgs) 
            Dim index As Integer = imageListComboBox.SelectedIndex
            if (index = 0) Then
                directoryTree.ImageList = Nothing
            elseif (index = 1) 
                directoryTree.ImageList = imageList1
            else 
                directoryTree.ImageList = imageList2
            end if
        end sub

        private Sub indentUpDown_ValueChanged(source As Object, e As EventArgs)
            directoryTree.Indent = indentUpDown.Value
        end sub

        private Sub CheckBox2_click(source As Object, e As EventArgs)
            Me.directoryTree.HotTracking = checkBox2.Checked
        end sub

        private Sub CheckBox3_click(source As Object, e As EventArgs)
            Me.directoryTree.ShowLines = checkBox3.Checked
        end sub

        private Sub CheckBox4_click(source As Object, e As EventArgs)
            Me.directoryTree.ShowRootLines = checkBox4.Checked
        end sub
        
        private Sub CheckBox5_click(source As Object, e As EventArgs)
            Me.directoryTree.ShowPlusMinus = checkBox5.Checked
        end sub


        private Sub CheckBox6_click(source As Object, e As EventArgs)
            Me.directoryTree.CheckBoxes = checkBox6.Checked
        end sub

        private Sub CheckBox7_click(source As Object, e As EventArgs)
            Me.directoryTree.HideSelection = checkBox7.Checked
        end sub

        ' NOTE: The following code is required by the WFC Form Designer
        ' It can be modified using the WinForms Designer.  
        ' Do not modify it using the code editor.
    	private components As System.ComponentModel.Container 
    	private directoryTree As System.WinForms.TreeView 
    	private imageList1 As System.WinForms.ImageList 
    	private imageList2 As System.WinForms.ImageList 
    	private grpTreeView As System.WinForms.GroupBox 
    	private checkBox1 As System.WinForms.CheckBox 
    	private imageListComboBox As System.WinForms.ComboBox 
    	private label1 As System.WinForms.Label 
    	private indentUpDown As System.WinForms.NumericUpDown 
    	private label4 As System.WinForms.Label 
    	private checkBox2 As System.WinForms.CheckBox 
    	private checkBox3 As System.WinForms.CheckBox 
    	private checkBox4 As System.WinForms.CheckBox 
    	private checkBox5 As System.WinForms.CheckBox 
    	private checkBox6 As System.WinForms.CheckBox 
    	private checkBox7 As System.WinForms.CheckBox 
    	private toolTip1 As System.WinForms.ToolTip 
        private resources As System.Resources.ResourceManager 

    	private Sub InitializeComponent() 

        	'resources = new System.Resources.ResourceManager("TreeViewCtl", typeof(TreeViewCtl), null, true);
		'this doesn't work ?????
		'resources = new System.Resources.ResourceManager("TreeViewCtl", Me.GetType, Nothing, true)

		try 
			resources = new System.Resources.ResourceManager("TreeViewCtl", Me.GetType, Nothing, True)

		catch Ex As Exception
			
			MessageBox.Show(Me,"Exception: " & Ex.Message)

		end try

		
		Me.components = new System.ComponentModel.Container()
		Me.checkBox7 = new System.WinForms.CheckBox()
		Me.directoryTree = new System.WinForms.TreeView()
		Me.checkBox5 = new System.WinForms.CheckBox()
		Me.label4 = new System.WinForms.Label()
		Me.indentUpDown = new System.WinForms.NumericUpDown()
		Me.imageList2 = new System.WinForms.ImageList()
		Me.toolTip1 = new System.WinForms.ToolTip(components)
		Me.checkBox6 = new System.WinForms.CheckBox()
		Me.checkBox1 = new System.WinForms.CheckBox()
		Me.checkBox3 = new System.WinForms.CheckBox()
		Me.imageList1 = new System.WinForms.ImageList()
		Me.imageListComboBox = new System.WinForms.ComboBox()
		Me.checkBox4 = new System.WinForms.CheckBox()
		Me.grpTreeView = new System.WinForms.GroupBox()
		Me.checkBox2 = new System.WinForms.CheckBox()
		Me.label1 = new System.WinForms.Label()
		
		checkBox7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox7.Location = new System.Drawing.Point(16, 160)
		checkBox7.TabIndex = 6
		checkBox7.CheckState = System.WinForms.CheckState.Checked
		checkBox7.Text = "hideSelected"
		checkBox7.Size = new System.Drawing.Size(100, 23)
		checkBox7.Checked = true
		toolTip1.SetToolTip(checkBox7, "Removes highlight from selected node when the control doesn't have focus.")
		checkBox7.AddOnClick(new EventHandler(AddressOf CheckBox7_click))
		
		directoryTree.ImageList = imageList1
		directoryTree.ForeColor = System.Drawing.SystemColors.WindowText
		directoryTree.Location = new System.Drawing.Point(24, 16)
		directoryTree.AllowDrop = true
		directoryTree.TabIndex = 0
		directoryTree.Indent = 19
		directoryTree.Text = "treeView1"
		directoryTree.SelectedImageIndex = 1
		directoryTree.Size = new System.Drawing.Size(200, 264)
		toolTip1.SetToolTip(directoryTree, "Indicates whether lines are shown between sibling nodes and b etween parent and children nodes")
		directoryTree.AddOnAfterSelect(new TreeViewEventHandler(AddressOf directoryTree_AfterSelect))
		directoryTree.AddOnBeforeExpand(new TreeViewCancelEventHandler(AddressOf directoryTree_BeforeExpand))
		
		checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox5.Location = new System.Drawing.Point(16, 112)
		checkBox5.TabIndex = 4
		checkBox5.CheckState = System.WinForms.CheckState.Checked
		checkBox5.Text = "showPlusMinus"
		checkBox5.Size = new System.Drawing.Size(110, 23)
		checkBox5.Checked = true
		toolTip1.SetToolTip(checkBox5, "Indicates if plus/minus button are shown next to parents.")
		checkBox5.AddOnClick(new EventHandler(AddressOf CheckBox5_click))
		
		label4.Location = new System.Drawing.Point(16, 224)
		label4.TabIndex = 9
		label4.TabStop = false
		label4.Text = "indent:"
		label4.Size = new System.Drawing.Size(48, 16)
		
		indentUpDown.Location = new System.Drawing.Point(88, 224)
		indentUpDown.Maximum = new System.Decimal(150d)
		indentUpDown.Minimum = new System.Decimal(18d)
		indentUpDown.TabIndex = 10
		indentUpDown.Text = "18"
	        indentUpDown.DecimalPlaces = 0
		indentUpDown.Size = new System.Drawing.Size(120, 20)
		toolTip1.SetToolTip(indentUpDown, "The indentation width of a child node in pixels.")
		indentUpDown.AddOnValueChanged(new EventHandler(AddressOf indentUpDown_ValueChanged))
		
		'imageList2.ImageStream = resources.GetObject("imageList2.ImageStream")
		imageList2.TransparentColor = System.Drawing.Color.Transparent
		'@design imageList2.SetLocation(new System.Drawing.Point(20, 40))
		
		Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
		Me.ClientSize = new System.Drawing.Size(502, 293)
		Me.Text = "TreeView"
		
		toolTip1.Active = true
		'@design toolTip1.SetLocation(new System.Drawing.Point(20, 70))
		
		checkBox6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox6.Location = new System.Drawing.Point(16, 136)
		checkBox6.TabIndex = 5
		checkBox6.Text = "checkBoxes"
		checkBox6.Size = new System.Drawing.Size(100, 23)
		toolTip1.SetToolTip(checkBox6, "Indicates wheter checkboxes are displayed beside nodes")
		checkBox6.AddOnClick(new EventHandler(AddressOf CheckBox6_click))
		
		checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox1.Location = new System.Drawing.Point(16, 16)
		checkBox1.TabIndex = 0
		checkBox1.Text = "sorted"
		checkBox1.Size = new System.Drawing.Size(100, 23)
		toolTip1.SetToolTip(checkBox1, "Indicates whether nodes are sorted.")
		checkBox1.AddOnClick(new EventHandler(AddressOf checkBox1_Click))
		
		checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox3.Location = new System.Drawing.Point(16, 64)
		checkBox3.TabIndex = 2
		checkBox3.CheckState = System.WinForms.CheckState.Checked
		checkBox3.Text = "showLines"
		checkBox3.Size = new System.Drawing.Size(100, 23)
		checkBox3.Checked = true
		toolTip1.SetToolTip(checkBox3, "Indicates whether lines are displayed between sibling nodes and between parent and children nodes.")
		checkBox3.AddOnClick(new EventHandler(AddressOf CheckBox3_click))
		
		'imageList1.ImageStream = resources.GetObject("imageList1.ImageStream")
		imageList1.TransparentColor = System.Drawing.Color.Transparent
		'@design imageList1.SetLocation(new System.Drawing.Point(20, 10))
		
		imageListComboBox.ForeColor = System.Drawing.SystemColors.WindowText
		imageListComboBox.Location = new System.Drawing.Point(88, 192)
		imageListComboBox.TabIndex = 8
		imageListComboBox.Text = ""
		imageListComboBox.Size = new System.Drawing.Size(120, 21)
		imageListComboBox.AddOnSelectedIndexChanged(new EventHandler(AddressOf imageListComboBox_SelectedIndexChanged))
		imageListComboBox.Items.All = new object() {"(none)", "system images", "bitmaps"}
		
		checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox4.Location = new System.Drawing.Point(16, 88)
		checkBox4.TabIndex = 3
		checkBox4.CheckState = System.WinForms.CheckState.Checked
		checkBox4.Text = "showRootLines"
		checkBox4.Size = new System.Drawing.Size(110, 23)
		checkBox4.Checked = true
		toolTip1.SetToolTip(checkBox4, "Indicates whether lines are displayed between root nodes.")
		checkBox4.AddOnClick(new EventHandler(AddressOf CheckBox4_click))
		
		grpTreeView.Location = new System.Drawing.Point(248, 16)
		grpTreeView.TabIndex = 1
		grpTreeView.TabStop = false
		grpTreeView.Text = "TreeView"
		grpTreeView.Size = new System.Drawing.Size(248, 264)
		
		checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox2.Location = new System.Drawing.Point(16, 40)
		checkBox2.TabIndex = 1
		checkBox2.Text = "hotTracking"
		checkBox2.Size = new System.Drawing.Size(100, 23)
		toolTip1.SetToolTip(checkBox2, "Indicates whether nodes give feedback when the mouse is moved over them.")
		checkBox2.AddOnClick(new EventHandler(AddressOf CheckBox2_click))
		
		label1.Location = new System.Drawing.Point(16, 194)
		label1.TabIndex = 7
		label1.TabStop = false
		label1.Text = "imageList:"
		label1.Size = new System.Drawing.Size(56, 16)
		
		grpTreeView.Controls.Add(checkBox7)
		grpTreeView.Controls.Add(checkBox6)
		grpTreeView.Controls.Add(checkBox5)
		grpTreeView.Controls.Add(checkBox4)
		grpTreeView.Controls.Add(checkBox3)
		grpTreeView.Controls.Add(checkBox2)
		grpTreeView.Controls.Add(label4)
		grpTreeView.Controls.Add(indentUpDown)
		grpTreeView.Controls.Add(label1)
		grpTreeView.Controls.Add(imageListComboBox)
		grpTreeView.Controls.Add(checkBox1)
		Me.Controls.Add(grpTreeView)
		Me.Controls.Add(directoryTree)		
        end sub

        ' <doc>
        ' <desc>
        '        The main entry point for the application. 
        ' </desc>
        ' <param term='args'>
        '        Array of parameters passed to the application via the command line.
        ' </param>
        ' </doc>
        '
        public shared Sub Main() 
            Application.Run(new TreeViewCtl())
        end sub


        ' <doc>
        ' <desc>
        '        Declare native function to determine drive type
        ' </desc>
        ' </doc>
        '
	public class PlatformInvokeKernel32 	
		Public Declare Function GetDriveType Lib "kernel32.dll" Alias "GetDriveTypeA" (ByVal lpRootName As String) As Integer
	end class
    end class
End Namespace


