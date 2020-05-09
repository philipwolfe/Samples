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
	/// <summary>
	/// Summary description for SettingsControl.
	/// </summary>
	public class AppSettingsControl : System.Windows.Forms.UserControl, ISnapinLink
	{
		private System.ComponentModel.IContainer components;
		#region private members

		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.StatusBar statusBarConfigFile;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonUndo;
		private System.Windows.Forms.TreeView treeViewSection;
		private System.Windows.Forms.ContextMenu contextMenuSection;
		private System.Windows.Forms.MenuItem menuItemAddElement;
		private System.Windows.Forms.MenuItem menuItemRemoveElement;
		private System.Windows.Forms.MenuItem menuItemClearElement;
		private System.Windows.Forms.MenuItem menuItemRemoveNode;
		private System.Windows.Forms.MenuItem menuItemRemoveAllNodes;
		private System.Windows.Forms.ToolTip toolTipSection;
		//
		private BaseNode mobjContextNode = null;
		private string mstrSectionOuterXml = null;
		string mstrSectionName = "appSettings";
		#endregion

		#region constructor
		public AppSettingsControl()
		{
			InitializeComponent();

			//---root
			TreeNode root = new TreeNode("appSettings");
			root.Tag = "root";
			treeViewSection.Nodes.Add(root);
			treeViewSection.SelectedNode = root;
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
			this.menuItemAddElement = new System.Windows.Forms.MenuItem();
			this.menuItemRemoveElement = new System.Windows.Forms.MenuItem();
			this.menuItemClearElement = new System.Windows.Forms.MenuItem();
			this.menuItemRemoveNode = new System.Windows.Forms.MenuItem();
			this.menuItemRemoveAllNodes = new System.Windows.Forms.MenuItem();
			this.toolTipSection = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(550, 40);
			this.splitter1.TabIndex = 18;
			this.splitter1.TabStop = false;
			// 
			// statusBarConfigFile
			// 
			this.statusBarConfigFile.Location = new System.Drawing.Point(0, 232);
			this.statusBarConfigFile.Name = "statusBarConfigFile";
			this.statusBarConfigFile.Size = new System.Drawing.Size(550, 28);
			this.statusBarConfigFile.TabIndex = 20;
			this.statusBarConfigFile.Visible = false;
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label.Location = new System.Drawing.Point(10, 8);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(266, 20);
			this.label.TabIndex = 34;
			this.label.Text = "appSettings";
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
			this.treeViewSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeViewSection.ContextMenu = this.contextMenuSection;
			this.treeViewSection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewSection.ImageIndex = -1;
			this.treeViewSection.LabelEdit = true;
			this.treeViewSection.Location = new System.Drawing.Point(0, 40);
			this.treeViewSection.Name = "treeViewSection";
			this.treeViewSection.SelectedImageIndex = -1;
			this.treeViewSection.Size = new System.Drawing.Size(550, 192);
			this.treeViewSection.TabIndex = 37;
			this.treeViewSection.Click += new System.EventHandler(this.treeViewSection_Click);
			this.treeViewSection.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewSection_AfterLabelEdit);
			this.treeViewSection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeViewSection_MouseMove);
			this.treeViewSection.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewSection_BeforeLabelEdit);
			// 
			// contextMenuSection
			// 
			this.contextMenuSection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																											 this.menuItemAddElement,
																																											 this.menuItemRemoveElement,
																																											 this.menuItemClearElement,
																																											 this.menuItemRemoveNode,
																																											 this.menuItemRemoveAllNodes});
			// 
			// menuItemAddElement
			// 
			this.menuItemAddElement.Index = 0;
			this.menuItemAddElement.Text = "<Add>";
			this.menuItemAddElement.Click += new System.EventHandler(this.menuItemAddElement_Click);
			// 
			// menuItemRemoveElement
			// 
			this.menuItemRemoveElement.Index = 1;
			this.menuItemRemoveElement.Text = "<Remove>";
			this.menuItemRemoveElement.Click += new System.EventHandler(this.menuItemRemoveElement_Click);
			// 
			// menuItemClearElement
			// 
			this.menuItemClearElement.Index = 2;
			this.menuItemClearElement.Text = "<Clear>";
			this.menuItemClearElement.Click += new System.EventHandler(this.menuItemClearElement_Click);
			// 
			// menuItemRemoveNode
			// 
			this.menuItemRemoveNode.Index = 3;
			this.menuItemRemoveNode.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuItemRemoveNode.Text = "Remove";
			this.menuItemRemoveNode.Click += new System.EventHandler(this.menuItemRemoveNode_Click);
			// 
			// menuItemRemoveAllNodes
			// 
			this.menuItemRemoveAllNodes.Index = 4;
			this.menuItemRemoveAllNodes.Text = "Remove All";
			this.menuItemRemoveAllNodes.Click += new System.EventHandler(this.menuItemRemoveAllNodes_Click);
			// 
			// toolTipSection
			// 
			this.toolTipSection.AutoPopDelay = 3000;
			this.toolTipSection.InitialDelay = 500;
			this.toolTipSection.ReshowDelay = 100;
			// 
			// AppSettingsControl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.buttonUndo,
																																	this.buttonApply,
																																	this.treeViewSection,
																																	this.label,
																																	this.statusBarConfigFile,
																																	this.splitter1});
			this.Name = "AppSettingsControl";
			this.Size = new System.Drawing.Size(550, 260);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.AppSettingsControl_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		#region ISnapinLink
		public BaseNode ContextNode
		{
			get { return mobjContextNode;  }
			set 
			{ 
				//---initialize data grid
				mobjContextNode = value; 
			
				//---label 
				BaseNode parent = mobjContextNode.Snapin.FindNodeByHScope(mobjContextNode.ParentHScopeItem);
				label.Text = parent.DisplayName + ": " + mstrSectionName;

				//---appSettings treeview
				TreeNode root = treeViewSection.SelectedNode;

				//---action
				ConfigFileToTreeView(root);
			}
		}
		#endregion

		#region ConfigFileToTreeView
		public void ConfigFileToTreeView(TreeNode root)
		{
			try 
			{				
				//---the host process config file
				string strConfigFilePath = Convert.ToString(mobjContextNode.Tag) + ".config";

				//---get section outerxml 
				ConfigFileAgent cfa = new ConfigFileAgent();
				mstrSectionOuterXml = cfa.GetRemotingConfigSection(mstrSectionName, strConfigFilePath);

				if(mstrSectionOuterXml != null) 
				{
					//---children
					OuterXmlToTreeView(root, mstrSectionOuterXml);

					//---expand root
					root.Expand();
				}	
			}
			catch(Exception ex) 
			{
				Trace.WriteLine("ConfigFileToTreeView failed, error= " + ex.Message);
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
				treeViewSection.BeginUpdate();
				//---the parent's attributes
				foreach(XmlAttribute a in node.Attributes)
				{
					string tnname = string.Format("{0} = \"{1}\"", a.Name, a.Value);
					TreeNode tnattr = new TreeNode(tnname);
					tnattr.Tag = "attribute";
					parent.Nodes.Add(tnattr);
				}

				//---the parent's elements
				foreach(XmlNode n in node.ChildNodes) 
				{	
					TreeNode tn = new TreeNode(n.Name);
					tn.Tag = "element";
					foreach(XmlAttribute a in n.Attributes)
					{
						string tnname = string.Format("{0} = \"{1}\"", a.Name, a.Value);
						TreeNode tnattr = new TreeNode(tnname);
						tnattr.Tag = "attribute";
						tn.Nodes.Add(tnattr);
					}
					parent.Nodes.Add(tn);			
				}	
				treeViewSection.EndUpdate();
			}
		}
		#endregion

		#region TreeViewToInnerXml
		private string TreeViewToOuterXml(TreeNode parent)
		{
			XmlDocument doc = new XmlDocument();
			XmlElement root = doc.CreateElement("root");
			XmlElement section = doc.CreateElement(parent.Text);	
			root.AppendChild(section);	
			TreeNodeToXmlNode(parent, section, doc);		
			string strSectionOuterXml = root.InnerXml;	
			
			//---checkpoint
			Trace.WriteLine(strSectionOuterXml);

			return strSectionOuterXml;
		}

		private void TreeNodeToXmlNode(TreeNode parentTN, XmlElement parentXN, XmlDocument doc) 
		{
			foreach(TreeNode tn in parentTN.Nodes) 
			{
				if(tn.Nodes.Count == 0 && "element" == (string)tn.Tag) 
				{
					XmlElement elem = doc.CreateElement(tn.Text);
					parentXN.AppendChild(elem);
				}
				else if(tn.Nodes.Count > 0) 
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
		private void treeViewSection_BeforeLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			string nodename = e.Node.Text;

			if(nodename == "appSettings" || nodename == "add" || nodename == "remove" || nodename == "clear") 
			{
				e.CancelEdit = true;
			}
		}

		private void treeViewSection_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			//---validation
			if(e.Label != null) 
			{
				string[] strLabel = e.Label.Split(new char[]{'='}, 2);
				string[] strKeyOrVal = strLabel[0].TrimEnd(' ').Split(' ');
			
				if((strKeyOrVal[0] == "key" || strKeyOrVal[0] == "value") && strLabel.Length == 2) 			
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

		private void treeViewSection_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			string tooltiptext = "";

			try 
			{
				TreeNode tnSel = treeViewSection.SelectedNode;
				TreeNode currentNode = treeViewSection.GetNodeAt(treeViewSection.PointToClient(Cursor.Position));
	
				if(currentNode != null) 					
				{
					//make the tooltip text
					StringBuilder sb = new StringBuilder();
					if(currentNode.Text == "add" && currentNode.IsExpanded == false) 
					{						
						sb.AppendFormat("{0}\n", currentNode.Nodes[0].Text);
						sb.Append(currentNode.Nodes[1].Text);
						tooltiptext = sb.ToString();						
					}
					else if(currentNode.Text == "remove" && currentNode.IsExpanded == false) 
					{
						sb.Append(currentNode.Nodes[0].Text);
						tooltiptext = sb.ToString();
					}
					else if(currentNode.Text == "appSettings") 
					{
						DataSet ds = new DataSet();
						ds.ReadXml(new StringReader(mstrSectionOuterXml));
						tooltiptext = ds.GetXml();
						ds.Dispose();
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

		private void AppSettingsControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			treeViewSection.Refresh();
		}
		#endregion

		#region helpers
		private void SetNodeMenu()
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			
			if(tnSel != null) 
			{
				string strTag = Convert.ToString(tnSel.Tag);

				Trace.WriteLine(strTag);

				if(strTag == "root") 
				{
					menuItemAddElement.Visible = true;
					menuItemRemoveElement.Visible = true;
					menuItemClearElement.Visible = true;
					menuItemRemoveNode.Visible = false;
					menuItemRemoveAllNodes.Visible = true;
				}
				else if(strTag == "element") 
				{
					menuItemAddElement.Visible = false;
					menuItemRemoveElement.Visible = false;
					menuItemClearElement.Visible = false;
					menuItemRemoveNode.Visible = true;
					menuItemRemoveAllNodes.Visible = false;
				}
				else 
				{
					menuItemAddElement.Visible = false;
					menuItemRemoveElement.Visible = false;
					menuItemClearElement.Visible = false;
					menuItemRemoveNode.Visible = false;
					menuItemRemoveAllNodes.Visible = false;
				}
			}
		}
		#endregion

		#region buttons
		private void treeViewSection_Click(object sender, System.EventArgs e)
		{
			treeViewSection.SelectedNode = treeViewSection.GetNodeAt(treeViewSection.PointToClient(Cursor.Position));
			SetNodeMenu();
		}


		private void menuItemAddElement_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;

			//---create nodes
			treeViewSection.BeginUpdate();
			TreeNode tnAdd = new TreeNode("add");
			tnAdd.Tag = "element";
			TreeNode tnKey = new TreeNode("key = \"\"");
			tnKey.Tag = "attribute";
			tnAdd.Nodes.Add(tnKey);
			TreeNode tnVal = new TreeNode("value = \"\"");
			tnVal.Tag = "attribute";
			tnAdd.Nodes.Add(tnVal);

			//---add to the parent
			tnSel.Nodes.Add(tnAdd);	
						
			//---scope
			treeViewSection.SelectedNode = tnKey;	
			treeViewSection.EndUpdate();

			//---edit
			tnKey.BeginEdit(); 

			//---state
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
			
		}

		private void menuItemRemoveElement_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;

			//---create nodes
			treeViewSection.BeginUpdate();
			TreeNode tnRemove = new TreeNode("remove");
			tnRemove.Tag = "element";
			TreeNode tnKey = new TreeNode("key = \"\"");
			tnKey.Tag = "attribute";
			tnRemove.Nodes.Add(tnKey);

			//---add to the parent
			tnSel.Nodes.Add(tnRemove);
			treeViewSection.EndUpdate();
			
			//---scope and edit
			treeViewSection.SelectedNode = tnKey;
			tnKey.BeginEdit(); 	
			treeViewSection.Update();

			//---state
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;			
		}

		private void menuItemClearElement_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;

			//---create nodes
			treeViewSection.BeginUpdate();
			TreeNode tnClear = new TreeNode("clear");
			tnClear.Tag = "element";

			//---add to the parent
			tnSel.Nodes.Add(tnClear);
			treeViewSection.EndUpdate();
			treeViewSection.Update();
		
			//---scope and edit
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}

		private void menuItemRemoveNode_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			treeViewSection.BeginUpdate();
			tnSel.Remove();
			treeViewSection.EndUpdate();
			treeViewSection.Update();

			//---state
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}

		private void menuItemRemoveAllNodes_Click(object sender, System.EventArgs e)
		{
			treeViewSection.BeginUpdate();
			treeViewSection.Nodes[0].Nodes.Clear();
			treeViewSection.EndUpdate();
			treeViewSection.Update();

			//---state
			statusBarConfigFile.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}

		private void buttonApply_Click(object sender, System.EventArgs e)
		{
			try 
			{
				//---create innerxml
				string strSectionInnerXml = TreeViewToOuterXml(treeViewSection.Nodes[0]);

				//---the host process config file
				string strConfigFilePath = Convert.ToString(mobjContextNode.Tag) + ".config";

				//---update config section  
				ConfigFileAgent cfa = new ConfigFileAgent();
				cfa.UpdateRemotingConfigSection(mstrSectionName, strSectionInnerXml, strConfigFilePath);

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
			treeViewSection.Nodes[0].Nodes.Clear();
			ConfigFileToTreeView(treeViewSection.Nodes[0]);
			treeViewSection.EndUpdate();

			//---state
			statusBarConfigFile.Visible = false;
			buttonApply.Visible = false;
			buttonUndo.Visible = false;	
		}
		#endregion

		
	}
}
