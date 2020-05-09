//=============================================================================
//	The Remoting Management Console.
//	(C) Copyright 2003, Roman Kiss (rkiss@pathcom.com)
//	All rights reserved.
//	The code and information is provided "as-is" without waranty of any kind,
//	either expresed or implied.
//
//  Note:	
//	This software using the 3rd party library for MMC (www.ironringsoftware.com)
//-----------------------------------------------------------------------------
//	History:
//		03/31/2003	Roman Kiss				Initial Revision
//=============================================================================
//

#region references
using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;
//
using Ironring.Management.MMC;
#endregion


namespace RKiss.RemotingManagement
{
	public class ConfigSectionControl : System.Windows.Forms.UserControl, ISnapinLink
	{	
		#region private members
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.StatusBar statusBarConfigFile;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonUndo;
		private System.Windows.Forms.TreeView treeViewSection;
		private System.Windows.Forms.ContextMenu contextMenuSection;
		private System.Windows.Forms.MenuItem menuItemAddAttribute;
		private System.Windows.Forms.MenuItem menuItemAddElement;
		private System.Windows.Forms.MenuItem menuItemDuplicate;
		private System.Windows.Forms.MenuItem menuItemRemove;
		private System.Windows.Forms.MenuItem menuItemClear;
		private System.Windows.Forms.MenuItem menuItemAddSection;
		private System.Windows.Forms.ToolTip toolTipSection;
		private System.Windows.Forms.MenuItem menuItemToolTip;
		private System.Windows.Forms.MenuItem menuItemSeparator;
		//
		private BaseNode mobjContextNode = null;
		private string mstrSectionName = null;
		private string mstrSectionOuterXml = null;
		private System.Windows.Forms.Panel panel;
		private string mstrConfigFilePath = null;
		#endregion

		#region constructor
		public ConfigSectionControl()
		{
			InitializeComponent();
		}
		#endregion

		#region Clean up any resources being used.
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.statusBarConfigFile = new System.Windows.Forms.StatusBar();
			this.label = new System.Windows.Forms.Label();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonUndo = new System.Windows.Forms.Button();
			this.treeViewSection = new System.Windows.Forms.TreeView();
			this.contextMenuSection = new System.Windows.Forms.ContextMenu();
			this.menuItemAddAttribute = new System.Windows.Forms.MenuItem();
			this.menuItemAddElement = new System.Windows.Forms.MenuItem();
			this.menuItemAddSection = new System.Windows.Forms.MenuItem();
			this.menuItemDuplicate = new System.Windows.Forms.MenuItem();
			this.menuItemRemove = new System.Windows.Forms.MenuItem();
			this.menuItemClear = new System.Windows.Forms.MenuItem();
			this.menuItemSeparator = new System.Windows.Forms.MenuItem();
			this.menuItemToolTip = new System.Windows.Forms.MenuItem();
			this.toolTipSection = new System.Windows.Forms.ToolTip(this.components);
			this.panel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(564, 40);
			this.splitter1.TabIndex = 18;
			this.splitter1.TabStop = false;
			// 
			// statusBarConfigFile
			// 
			this.statusBarConfigFile.Location = new System.Drawing.Point(0, 232);
			this.statusBarConfigFile.Name = "statusBarConfigFile";
			this.statusBarConfigFile.Size = new System.Drawing.Size(564, 28);
			this.statusBarConfigFile.TabIndex = 20;
			this.statusBarConfigFile.Visible = false;
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label.Location = new System.Drawing.Point(10, 8);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(420, 20);
			this.label.TabIndex = 34;
			this.label.Text = "Config Section";
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Location = new System.Drawing.Point(8, 236);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(62, 20);
			this.buttonApply.TabIndex = 35;
			this.buttonApply.Text = "APPLY";
			this.buttonApply.Visible = false;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonUndo
			// 
			this.buttonUndo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonUndo.Location = new System.Drawing.Point(74, 236);
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(62, 20);
			this.buttonUndo.TabIndex = 36;
			this.buttonUndo.Text = "UNDO";
			this.buttonUndo.Visible = false;
			this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
			// 
			// treeViewSection
			// 
			this.treeViewSection.AllowDrop = true;
			this.treeViewSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeViewSection.ContextMenu = this.contextMenuSection;
			this.treeViewSection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewSection.ImageIndex = -1;
			this.treeViewSection.LabelEdit = true;
			this.treeViewSection.Location = new System.Drawing.Point(0, 40);
			this.treeViewSection.Name = "treeViewSection";
			this.treeViewSection.SelectedImageIndex = -1;
			this.treeViewSection.Size = new System.Drawing.Size(564, 192);
			this.treeViewSection.TabIndex = 37;
			this.treeViewSection.Click += new System.EventHandler(this.treeViewSection_Click);
			this.treeViewSection.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewSection_DragOver);
			this.treeViewSection.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewSection_AfterLabelEdit);
			this.treeViewSection.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewSection_DragEnter);
			this.treeViewSection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeViewSection_MouseMove);
			this.treeViewSection.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewSection_ItemDrag);
			this.treeViewSection.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewSection_BeforeLabelEdit);
			this.treeViewSection.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewSection_DragDrop);
			// 
			// contextMenuSection
			// 
			this.contextMenuSection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																											 this.menuItemAddAttribute,
																																											 this.menuItemAddElement,
																																											 this.menuItemAddSection,
																																											 this.menuItemDuplicate,
																																											 this.menuItemRemove,
																																											 this.menuItemClear,
																																											 this.menuItemSeparator,
																																											 this.menuItemToolTip});
			// 
			// menuItemAddAttribute
			// 
			this.menuItemAddAttribute.Index = 0;
			this.menuItemAddAttribute.Text = "[Attribute]";
			this.menuItemAddAttribute.Click += new System.EventHandler(this.menuItemAddAttribute_Click);
			// 
			// menuItemAddElement
			// 
			this.menuItemAddElement.Index = 1;
			this.menuItemAddElement.Text = "[Element]";
			this.menuItemAddElement.Click += new System.EventHandler(this.menuItemAddElement_Click);
			// 
			// menuItemAddSection
			// 
			this.menuItemAddSection.Index = 2;
			this.menuItemAddSection.Text = "[Section]";
			this.menuItemAddSection.Click += new System.EventHandler(this.menuItemAddSection_Click);
			// 
			// menuItemDuplicate
			// 
			this.menuItemDuplicate.Index = 3;
			this.menuItemDuplicate.Text = "Duplicate";
			this.menuItemDuplicate.Click += new System.EventHandler(this.menuItemDuplicate_Click);
			// 
			// menuItemRemove
			// 
			this.menuItemRemove.Index = 4;
			this.menuItemRemove.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuItemRemove.Text = "Remove";
			this.menuItemRemove.Click += new System.EventHandler(this.menuItemRemove_Click);
			// 
			// menuItemClear
			// 
			this.menuItemClear.Index = 5;
			this.menuItemClear.Text = "Clear";
			this.menuItemClear.Click += new System.EventHandler(this.menuItemClear_Click);
			// 
			// menuItemSeparator
			// 
			this.menuItemSeparator.Index = 6;
			this.menuItemSeparator.Text = "-";
			// 
			// menuItemToolTip
			// 
			this.menuItemToolTip.Index = 7;
			this.menuItemToolTip.Text = "ToolTip";
			this.menuItemToolTip.Click += new System.EventHandler(this.menuItemToolTip_Click);
			// 
			// toolTipSection
			// 
			this.toolTipSection.AutoPopDelay = 3000;
			this.toolTipSection.InitialDelay = 500;
			this.toolTipSection.ReshowDelay = 100;
			// 
			// panel
			// 
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 40);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(564, 192);
			this.panel.TabIndex = 38;
			// 
			// ConfigSectionControl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.treeViewSection,
																																	this.panel,
																																	this.buttonUndo,
																																	this.buttonApply,
																																	this.label,
																																	this.statusBarConfigFile,
																																	this.splitter1});
			this.Name = "ConfigSectionControl";
			this.Size = new System.Drawing.Size(564, 260);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConfigSectionControl_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		#region ISnapinLink
		public BaseNode ContextNode
		{
			get { return mobjContextNode;  }
			set 
			{ 
				//---parent
				mobjContextNode = value; 

				//---section name
				mstrSectionName = mobjContextNode.DisplayName;

				//---the host process config file
				mstrConfigFilePath = Convert.ToString(mobjContextNode.Tag) + ".config";

				//---label 
				BaseNode parent = mobjContextNode.Snapin.FindNodeByHScope(mobjContextNode.ParentHScopeItem);
				label.Text = parent.DisplayName + ": " + mstrSectionName;

				//---action
				ConfigFileToTreeView();
			}
		}
		#endregion

		#region ConfigFileToTreeView
		public void ConfigFileToTreeView()
		{
			try 
			{
				//---get section outerxml 
				ConfigFileAgent cfa = new ConfigFileAgent();
				mstrSectionOuterXml = cfa.GetRemotingConfigSection(mstrSectionName, mstrConfigFilePath);

				if(mstrSectionOuterXml != null) 
				{
					//---start updateing
					treeViewSection.BeginUpdate();

					TreeNode root = new TreeNode();
					OuterXmlToTreeView(root, "<root>" + mstrSectionOuterXml + "</root>");
					root.Nodes[0].Tag = "root";
					treeViewSection.Nodes.Add(root.Nodes[0]);

					//---expand root
					root.Nodes[0].Expand();

					//---end of the update
					treeViewSection.EndUpdate();
				}	
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(ex.Message);
			}
		}
		#endregion

		#region OuterXmlToTreeView
		private void OuterXmlToTreeView(TreeNode parent, string strSectionOuterXml)
		{
			Trace.WriteLine(strSectionOuterXml);

			XmlDocument doc = new XmlDocument();
			doc.Load(new StringReader(strSectionOuterXml));

			XmlNode node = doc.DocumentElement;

			if(node != null) 
			{
				XmlNodeToTreeNode(node, parent);
			}
		}

		private void XmlNodeToTreeNode(XmlNode parentXN, TreeNode parentTN) 
		{	
			if(parentXN.Attributes.Count > 0) 
			{
				foreach(XmlAttribute attr in parentXN.Attributes) 
				{
					string tnname = string.Format("{0} = \"{1}\"", attr.Name, attr.Value);
					TreeNode tnattr = new TreeNode(tnname);
					tnattr.Tag = "attribute";
					parentTN.Nodes.Add(tnattr);
				}
			}
			if(parentXN.HasChildNodes) 
			{
				foreach(XmlNode n in parentXN.ChildNodes)
				{
					TreeNode tn = new TreeNode(n.Name);
					tn.Tag = "element";
					XmlNodeToTreeNode(n, tn);
					parentTN.Nodes.Add(tn);
				}			
			}
		}
		#endregion

		#region TreeViewToInnerXml
		private string TreeViewToOuterXml(TreeNode parent)
		{
			XmlDocument doc = new XmlDocument();
			XmlElement root = doc.CreateElement("configuration");
			XmlElement section = doc.CreateElement(parent.Text);	
			root.AppendChild(section);	
			TreeNodeToXmlNode(parent, section, doc);		
			mstrSectionOuterXml = root.InnerXml;	
			
			//---checkpoint
			Trace.WriteLine(mstrSectionOuterXml);

			return mstrSectionOuterXml;
		}

		private void TreeNodeToXmlNode(TreeNode parentTN, XmlElement parentXN, XmlDocument doc) 
		{
			foreach(TreeNode tn in parentTN.Nodes) 
			{
				if(tn.Nodes.Count > 0) 
				{
					XmlElement elem = doc.CreateElement(tn.Text);
					TreeNodeToXmlNode(tn, elem, doc);
					parentXN.AppendChild(elem);
				}
				else 
				{
					string[] label = tn.Text.Split(new char[]{'='}, 2);
					string name = label[0].Trim();
					string val = label[1].Trim().Trim('\"');
					parentXN.SetAttribute(name, val);
				}
			}
		}
		#endregion

		#region Events
		private void treeViewSection_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			string tooltiptext = "";

			try 
			{
				TreeNode tnSel = treeViewSection.SelectedNode;
				TreeNode currentNode = treeViewSection.GetNodeAt(treeViewSection.PointToClient(Cursor.Position));
	
				if(currentNode != null && menuItemToolTip.Checked) 					
				{
					//make the tooltip text
					StringBuilder sb = new StringBuilder();
					if("element" == (string)currentNode.Tag && currentNode.Nodes.Count > 0 && currentNode.IsExpanded == false) 
					{
						int numberOfTexts = 0;
						foreach(TreeNode tn in currentNode.Nodes) 
						{	
							sb.AppendFormat("{0}{1}", numberOfTexts++ == 0 ? "" : "\r\n", tn.Text);
						}
						tooltiptext = sb.ToString();
					}
				}
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(ex.Message);
				tooltiptext = string.Format("Internal error exception: {0}", ex.Message);
			}
			finally 
			{
				//show
				if(toolTipSection.GetToolTip(treeViewSection) == tooltiptext)
					tooltiptext = "";
				else
					toolTipSection.SetToolTip(treeViewSection, tooltiptext);
			}
		}
	

		private void treeViewSection_BeforeLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			/*
			if("root" == (string)e.Node.Tag) 
			{
				e.CancelEdit = true;
			}
			*/
		}

		private void treeViewSection_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			//---validation
			if(e.Label != null) 
			{
				string nodename = Convert.ToString(e.Node.Tag);
				string[] cond1 = e.Label.Split(new char[]{'='}, 2);
				string[] cond2 = cond1[0].TrimEnd(' ').Split(' ');
			
				if(nodename == "attribute" && cond1.Length == 2 && cond2.Length == 1) 			
					e.CancelEdit = false;
				else if((nodename == "element" ||  nodename == "root") && cond2.Length == 1) 			
					e.CancelEdit = false;
				else
					e.CancelEdit = true;			
			}
			else 
				e.CancelEdit = true;
		
			//---setup state
			if(e.CancelEdit == false && e.Label != e.Node.Text) 
			{	
				e.Node.Text = e.Label;
				statusBarConfigFile.Visible = true;
				buttonApply.Visible = true;
				buttonUndo.Visible = true;		
			}
		}

		private void treeViewSection_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void treeViewSection_DragEnter(object sender,	System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void treeViewSection_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
			{
				Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
				TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
				TreeNode NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
				if(DestinationNode != null && DestinationNode != NewNode && Convert.ToString(NewNode.Tag) != "root")
				{ 
					string strNodeTag = Convert.ToString(DestinationNode.Tag);

					if(strNodeTag == "attribute")
						DestinationNode.Parent.Nodes.Insert(DestinationNode.Index, (TreeNode)NewNode.Clone());
					else 
						DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
					
					//---scope and check the CTRL key
					DestinationNode.Expand();
					if((e.KeyState & 8) == 0)
						NewNode.Remove();

					//---state
					statusBarConfigFile.Visible = true;
					buttonApply.Visible = true;
					buttonUndo.Visible = true;
				}
			}
		}

		private void treeViewSection_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//---scroll bar	moving (thanks to http://www.syncfusion.com/FAQ/WinForms/FAQ_c91c.asp#q906q )
			TreeView tv = sender as TreeView; 
			Point pt = tv.PointToClient(new Point(e.X,e.Y));            
			int delta = tv.Height - pt.Y; 
			if((delta < tv.Height / 2) && (delta > 0)) 
			{ 
				TreeNode tn = tv.GetNodeAt(pt.X, pt.Y); 
				if (tn.NextVisibleNode != null) 
					tn.NextVisibleNode.EnsureVisible(); 
			} 
 
			if((delta > tv.Height / 2) && (delta < tv.Height)) 
			{ 
				TreeNode tn = tv.GetNodeAt(pt.X, pt.Y); 
				if (tn.PrevVisibleNode != null) 
					tn.PrevVisibleNode.EnsureVisible(); 
			} 
			//---end of the scroll bar moving

			//---highlight the node
			TreeNode MovedNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

			if(MovedNode != null) 
			{
				//---select the destination node
				TreeNode currentNode = treeViewSection.GetNodeAt(treeViewSection.PointToClient(Cursor.Position));
				if(currentNode != null) 
				{
					currentNode.TreeView.SelectedNode = currentNode;	
					currentNode.TreeView.SelectedNode.Expand();
				}
			}
		}

		private void ConfigSectionControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			treeViewSection.Refresh();
		}

		#endregion

		#region helpers
		private void SetNodeMenu()
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			string strTag = Convert.ToString(tnSel.Tag);

			if(strTag == "root") 
			{
				menuItemAddAttribute.Visible = true;
				menuItemAddElement.Visible = true;
				menuItemAddSection.Visible = true;
				menuItemDuplicate.Visible = false;
				menuItemRemove.Visible = false;
				menuItemClear.Visible = true;
				menuItemToolTip.Visible = true;
				menuItemSeparator.Visible = true;
			}
			else if(strTag == "attribute") 
			{
				menuItemAddAttribute.Visible = false;
				menuItemAddElement.Visible = false;
				menuItemAddSection.Visible = false;
				menuItemDuplicate.Visible = true;
				menuItemRemove.Visible = true;
				menuItemClear.Visible = false;
				menuItemToolTip.Visible = false;
				menuItemSeparator.Visible = false;
			}
			else if(strTag == "element") 
			{
				menuItemAddAttribute.Visible = true;
				menuItemAddElement.Visible = false;
				menuItemAddSection.Visible = true;
				menuItemDuplicate.Visible = true;
				menuItemRemove.Visible = true;
				menuItemClear.Visible = false;
				menuItemToolTip.Visible = false;
				menuItemSeparator.Visible = false;
			}
			else 
			{
				menuItemAddAttribute.Visible = false;
				menuItemAddElement.Visible = false;
				menuItemAddSection.Visible = false;
				menuItemDuplicate.Visible = false;
				menuItemRemove.Visible = false;
				menuItemClear.Visible = false;
				menuItemToolTip.Visible = false;
				menuItemSeparator.Visible = false;
			}
		}
		#endregion

		#region buttons
		private void treeViewSection_Click(object sender, System.EventArgs e)
		{
			treeViewSection.SelectedNode = treeViewSection.GetNodeAt(treeViewSection.PointToClient(Cursor.Position));
			SetNodeMenu();
			treeViewSection.Refresh();
		}

		private void menuItemAddAttribute_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			string strTag = Convert.ToString(tnSel.Tag);

			TreeNode tn = new TreeNode("attribute = \"\"");
			tn.Tag = "attribute";

			if(strTag == "root")
				tnSel.Nodes.Insert(0, tn);	
			else if(strTag == "element")
				tnSel.Nodes.Add(tn);	
			else
				tnSel.Parent.Nodes.Add(tn);	

			//---setup state
			treeViewSection.SelectedNode = tn;
			treeViewSection.SelectedNode.BeginEdit();
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}

		private void menuItemAddElement_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			string strTag = Convert.ToString(tnSel.Tag);

			TreeNode tn = new TreeNode("element");
			tn.Tag = "element";

			if(strTag == "root" || strTag == "element")
				tnSel.Nodes.Add(tn);	
			else
				tnSel.Parent.Nodes.Add(tn);	

			treeViewSection.SelectedNode = tn;
			menuItemAddAttribute_Click(sender, e);
		}

		private void menuItemAddSection_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			string strTag = Convert.ToString(tnSel.Tag);

			TreeNode tn = new TreeNode("section");
			tn.Tag = "element";

			if(strTag == "root" || strTag == "element")
				tnSel.Nodes.Add(tn);	
			else
				tnSel.Parent.Nodes.Add(tn);	

			treeViewSection.SelectedNode = tn;
			menuItemAddElement_Click(sender, e);	
		}

		private void menuItemDuplicate_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			string strTag = Convert.ToString(tnSel.Tag);

			TreeNode tn = new TreeNode(tnSel.Text);
			tn.Tag = tnSel.Tag;
			tnSel.Parent.Nodes.Insert(tnSel.Index, tn);
			
			treeViewSection.SelectedNode = tn;
			if(strTag == "element") 
				menuItemAddAttribute_Click(sender, e);
			else 
				treeViewSection.SelectedNode.BeginEdit();

			//---setup state
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}

		private void menuItemRemove_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			tnSel.Remove();

			//---state
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}

		private void menuItemClear_Click(object sender, System.EventArgs e)
		{
			treeViewSection.BeginUpdate();
			treeViewSection.Nodes[0].Nodes.Clear();
			treeViewSection.EndUpdate();

			//---state
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}

		private void menuItemToolTip_Click(object sender, System.EventArgs e)
		{
			menuItemToolTip.Checked = !menuItemToolTip.Checked;
		}

		private void buttonApply_Click(object sender, System.EventArgs e)
		{
			try 
			{
				//---root (config section/group)
				TreeNode root = treeViewSection.Nodes[0];

				//---create outerxml
				TreeViewToOuterXml(root);
		
				//---update config section  
				ConfigFileAgent cfa = new ConfigFileAgent();
				cfa.UpdateRemotingConfigSection(mstrSectionName, mstrSectionOuterXml, mstrConfigFilePath);

				if(root.Text != mstrSectionName) 
				{
					//---notify snapin to refresh nodes
					mobjContextNode.OnUser("APPLY_done", root.Text);
				}

				//---state
				statusBarConfigFile.Visible = false;
				buttonApply.Visible = false;
				buttonUndo.Visible = false;

			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, mstrSectionName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonUndo_Click(object sender, System.EventArgs e)
		{
			treeViewSection.BeginUpdate();
			treeViewSection.Nodes[0].Remove();
			ConfigFileToTreeView();
			treeViewSection.EndUpdate();

			//---state
			statusBarConfigFile.Visible = false;
			buttonApply.Visible = false;
			buttonUndo.Visible = false;	
		}
		#endregion

	
	
	}
}

/*
 * //---split and format the text on the tooltip
							if(tn.Text.Length > 10)
							{
								int comma = tn.Text.IndexOf(',', 0);
								if(comma > 0) 
								{
									sb.AppendFormat("{0}\r\n", tn.Text.Substring(0, comma + 1));
									int equale = tn.Text.IndexOf('=', 0);
									if(equale < 0)
										equale = 10;
									sb.AppendFormat("{0}\r\n", tn.Text.Substring(comma + 1).PadLeft(equale + 4 + tn.Text.Length - comma));
								}
								else
									sb.AppendFormat("{0}\r\n", tn.Text);
							}
							else
 * 
 */
