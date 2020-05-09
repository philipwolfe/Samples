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
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Ironring.Management.MMC;
#endregion


namespace RKiss.RemotingManagement
{
	public class ChannelsControl : System.Windows.Forms.UserControl, ISnapinLink
	{
		#region private members

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TextBox textBoxMachineConfigFile;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.TabPage tabPagePrivateChannels;
		private System.Windows.Forms.TabPage tabPageDeclare;
		private System.Windows.Forms.TreeView treeViewSection;
		private System.Windows.Forms.Button buttonUndo;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.TabControl tabControlPrivateChannels;
		private System.Windows.Forms.TextBox textBoxExecConfigFile;
		private System.Windows.Forms.ContextMenu contextMenuSection;
		private System.Windows.Forms.MenuItem menuItemNew;
		private System.Windows.Forms.MenuItem menuItemRemove;
		private System.Windows.Forms.MenuItem menuItemRemoveAll;
		private System.Windows.Forms.MenuItem menuItemDuplicate;
		private System.Windows.Forms.MenuItem menuItemRefresh;
		private System.Windows.Forms.MenuItem menuItemExpandAll;
		//
		BaseNode mobjContextNode = null;
		string mstrSectionOuterXml = null;
		private System.Windows.Forms.StatusBar statusBarDeclare;
		private System.Windows.Forms.Label label;
		string mstrSectionName = "channels";
		#endregion

		#region constructor
		public ChannelsControl()
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
			this.label = new System.Windows.Forms.Label();
			this.textBoxExecConfigFile = new System.Windows.Forms.TextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.textBoxMachineConfigFile = new System.Windows.Forms.TextBox();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.tabControlPrivateChannels = new System.Windows.Forms.TabControl();
			this.tabPagePrivateChannels = new System.Windows.Forms.TabPage();
			this.tabPageDeclare = new System.Windows.Forms.TabPage();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonUndo = new System.Windows.Forms.Button();
			this.treeViewSection = new System.Windows.Forms.TreeView();
			this.contextMenuSection = new System.Windows.Forms.ContextMenu();
			this.menuItemNew = new System.Windows.Forms.MenuItem();
			this.menuItemDuplicate = new System.Windows.Forms.MenuItem();
			this.menuItemRemove = new System.Windows.Forms.MenuItem();
			this.menuItemRemoveAll = new System.Windows.Forms.MenuItem();
			this.menuItemExpandAll = new System.Windows.Forms.MenuItem();
			this.menuItemRefresh = new System.Windows.Forms.MenuItem();
			this.statusBarDeclare = new System.Windows.Forms.StatusBar();
			this.tabControlPrivateChannels.SuspendLayout();
			this.tabPagePrivateChannels.SuspendLayout();
			this.tabPageDeclare.SuspendLayout();
			this.SuspendLayout();
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label.Location = new System.Drawing.Point(12, 10);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(492, 20);
			this.label.TabIndex = 22;
			this.label.Text = "Public and Private Channels";
			// 
			// textBoxExecConfigFile
			// 
			this.textBoxExecConfigFile.AcceptsReturn = true;
			this.textBoxExecConfigFile.BackColor = System.Drawing.Color.Gainsboro;
			this.textBoxExecConfigFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxExecConfigFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxExecConfigFile.Multiline = true;
			this.textBoxExecConfigFile.Name = "textBoxExecConfigFile";
			this.textBoxExecConfigFile.ReadOnly = true;
			this.textBoxExecConfigFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxExecConfigFile.Size = new System.Drawing.Size(506, 226);
			this.textBoxExecConfigFile.TabIndex = 26;
			this.textBoxExecConfigFile.Text = "exe.config file";
			this.textBoxExecConfigFile.WordWrap = false;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(514, 40);
			this.splitter1.TabIndex = 18;
			this.splitter1.TabStop = false;
			// 
			// textBoxMachineConfigFile
			// 
			this.textBoxMachineConfigFile.AcceptsReturn = true;
			this.textBoxMachineConfigFile.BackColor = System.Drawing.Color.Gainsboro;
			this.textBoxMachineConfigFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxMachineConfigFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBoxMachineConfigFile.Location = new System.Drawing.Point(0, 40);
			this.textBoxMachineConfigFile.Multiline = true;
			this.textBoxMachineConfigFile.Name = "textBoxMachineConfigFile";
			this.textBoxMachineConfigFile.ReadOnly = true;
			this.textBoxMachineConfigFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxMachineConfigFile.Size = new System.Drawing.Size(514, 300);
			this.textBoxMachineConfigFile.TabIndex = 20;
			this.textBoxMachineConfigFile.Text = "machine.config file";
			this.textBoxMachineConfigFile.WordWrap = false;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(0, 340);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(514, 6);
			this.splitter2.TabIndex = 27;
			this.splitter2.TabStop = false;
			// 
			// tabControlPrivateChannels
			// 
			this.tabControlPrivateChannels.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabControlPrivateChannels.Controls.AddRange(new System.Windows.Forms.Control[] {
																																														this.tabPagePrivateChannels,
																																														this.tabPageDeclare});
			this.tabControlPrivateChannels.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPrivateChannels.Location = new System.Drawing.Point(0, 346);
			this.tabControlPrivateChannels.Multiline = true;
			this.tabControlPrivateChannels.Name = "tabControlPrivateChannels";
			this.tabControlPrivateChannels.SelectedIndex = 0;
			this.tabControlPrivateChannels.Size = new System.Drawing.Size(514, 252);
			this.tabControlPrivateChannels.TabIndex = 28;
			this.tabControlPrivateChannels.SelectedIndexChanged += new System.EventHandler(this.tabControlPrivateChannels_SelectedIndexChanged);
			// 
			// tabPagePrivateChannels
			// 
			this.tabPagePrivateChannels.Controls.AddRange(new System.Windows.Forms.Control[] {
																																												 this.textBoxExecConfigFile});
			this.tabPagePrivateChannels.Location = new System.Drawing.Point(4, 4);
			this.tabPagePrivateChannels.Name = "tabPagePrivateChannels";
			this.tabPagePrivateChannels.Size = new System.Drawing.Size(506, 226);
			this.tabPagePrivateChannels.TabIndex = 0;
			this.tabPagePrivateChannels.Text = "Private Channels";
			// 
			// tabPageDeclare
			// 
			this.tabPageDeclare.Controls.AddRange(new System.Windows.Forms.Control[] {
																																								 this.buttonApply,
																																								 this.buttonUndo,
																																								 this.treeViewSection,
																																								 this.statusBarDeclare});
			this.tabPageDeclare.Location = new System.Drawing.Point(4, 4);
			this.tabPageDeclare.Name = "tabPageDeclare";
			this.tabPageDeclare.Size = new System.Drawing.Size(506, 226);
			this.tabPageDeclare.TabIndex = 1;
			this.tabPageDeclare.Text = "Declare Channels";
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Location = new System.Drawing.Point(2, 206);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(62, 20);
			this.buttonApply.TabIndex = 37;
			this.buttonApply.Text = "APPLY";
			this.buttonApply.Visible = false;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonUndo
			// 
			this.buttonUndo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonUndo.Location = new System.Drawing.Point(68, 206);
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(62, 20);
			this.buttonUndo.TabIndex = 38;
			this.buttonUndo.Text = "UNDO";
			this.buttonUndo.Visible = false;
			this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
			// 
			// treeViewSection
			// 
			this.treeViewSection.BackColor = System.Drawing.Color.White;
			this.treeViewSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeViewSection.ContextMenu = this.contextMenuSection;
			this.treeViewSection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewSection.ImageIndex = -1;
			this.treeViewSection.LabelEdit = true;
			this.treeViewSection.Name = "treeViewSection";
			this.treeViewSection.SelectedImageIndex = -1;
			this.treeViewSection.Size = new System.Drawing.Size(506, 202);
			this.treeViewSection.TabIndex = 38;
			this.treeViewSection.Click += new System.EventHandler(this.treeViewSection_Click);
			this.treeViewSection.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewSection_AfterLabelEdit);
			this.treeViewSection.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewSection_BeforeLabelEdit);
			// 
			// contextMenuSection
			// 
			this.contextMenuSection.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																											 this.menuItemNew,
																																											 this.menuItemDuplicate,
																																											 this.menuItemRemove,
																																											 this.menuItemRemoveAll,
																																											 this.menuItemExpandAll,
																																											 this.menuItemRefresh});
			// 
			// menuItemNew
			// 
			this.menuItemNew.Index = 0;
			this.menuItemNew.Text = "<channel>";
			this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
			// 
			// menuItemDuplicate
			// 
			this.menuItemDuplicate.Index = 1;
			this.menuItemDuplicate.Text = "Duplicate";
			this.menuItemDuplicate.Click += new System.EventHandler(this.menuItemDuplicate_Click);
			// 
			// menuItemRemove
			// 
			this.menuItemRemove.Index = 2;
			this.menuItemRemove.Text = "Remove";
			this.menuItemRemove.Click += new System.EventHandler(this.menuItemRemove_Click);
			// 
			// menuItemRemoveAll
			// 
			this.menuItemRemoveAll.Index = 3;
			this.menuItemRemoveAll.Text = "Remove All";
			this.menuItemRemoveAll.Click += new System.EventHandler(this.menuItemRemoveAll_Click);
			// 
			// menuItemExpandAll
			// 
			this.menuItemExpandAll.Index = 4;
			this.menuItemExpandAll.Text = "ExpandAll";
			this.menuItemExpandAll.Click += new System.EventHandler(this.menuItemExpandAll_Click);
			// 
			// menuItemRefresh
			// 
			this.menuItemRefresh.Index = 5;
			this.menuItemRefresh.Text = "Refresh";
			this.menuItemRefresh.Visible = false;
			this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
			// 
			// statusBarDeclare
			// 
			this.statusBarDeclare.Location = new System.Drawing.Point(0, 202);
			this.statusBarDeclare.Name = "statusBarDeclare";
			this.statusBarDeclare.Size = new System.Drawing.Size(506, 24);
			this.statusBarDeclare.TabIndex = 39;
			this.statusBarDeclare.Visible = false;
			// 
			// ChannelsControl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.tabControlPrivateChannels,
																																	this.splitter2,
																																	this.label,
																																	this.textBoxMachineConfigFile,
																																	this.splitter1});
			this.Name = "ChannelsControl";
			this.Size = new System.Drawing.Size(514, 598);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChannelsControl_Paint);
			this.tabControlPrivateChannels.ResumeLayout(false);
			this.tabPagePrivateChannels.ResumeLayout(false);
			this.tabPageDeclare.ResumeLayout(false);
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
				label.Text = parent.DisplayName + ": " + "Public and Private Channels";

				//---public 
				ShowPublicChannels();

				//---private
				ShowPrivateChannels();

				//---tab control
				tabControlPrivateChannels.SelectedIndex = 0;
			}
		}		
		#endregion

		#region public channels
		private void ShowPublicChannels() 
		{
			ConfigFileAgent cfa = new ConfigFileAgent();
			string strMachineConfigFile = cfa.GetPathToMachineConfigFile();
			ShowChannels("machine.config", textBoxMachineConfigFile, strMachineConfigFile);
		}
		#endregion

		#region private channels
		private void ShowPrivateChannels() 
		{		
			//---path to the exec config file
			string strExecConfigFile = Convert.ToString(mobjContextNode.Tag) + ".config";
			
			ShowChannels("exe.config", textBoxExecConfigFile, strExecConfigFile);
		}
		#endregion

		#region Declare Private Channels
		#region ConfigFileToTreeView
		public void ConfigFileToTreeView()
		{
			try 
			{				
				//---the host process config file
				string strConfigFilePath = Convert.ToString(mobjContextNode.Tag) + ".config";

				//---get section outerxml 
				ConfigFileAgent cfa = new ConfigFileAgent();
				mstrSectionOuterXml = cfa.GetApplicationChannels(strConfigFilePath);

				treeViewSection.BeginUpdate();
				treeViewSection.Nodes.Clear();
				TreeNode root = new TreeNode();

				if(mstrSectionOuterXml != null) 
				{
					
					OuterXmlToTreeView(root, "<root>" + mstrSectionOuterXml + "</root>");
					root.Nodes[0].Tag = "root";
					treeViewSection.Nodes.Add(root.Nodes[0]);

					//---expand root
					root.Nodes[0].Expand();				
				}	
				else 
				{
					root.Text = mstrSectionName;
					root.Tag = "root";
					treeViewSection.Nodes.Add(root);
				}

				treeViewSection.EndUpdate();
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

			if(nodename == "channels" || nodename == "channel") 
			{
				e.CancelEdit = true;
			}
		}

		private void treeViewSection_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			//---validation
			if(e.Label != null) 
			{
				string[] strLabel = e.Label.Split('=');
				string[] strAttrName = strLabel[0].TrimEnd(' ').Split(' ');
			
				if(strAttrName[0] == "id" && strLabel.Length == 2) 			
					e.CancelEdit = false;
				else if(strAttrName[0] == "type" && strLabel.Length > 1) 			
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
				statusBarDeclare.Visible = true;
				buttonApply.Visible = true;
				buttonUndo.Visible = true;		
			}
		}

		private void treeViewSection_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//treeViewSection.SelectedNode = treeViewSection.GetNodeAt(treeViewSection.PointToClient(Cursor.Position));
		}

		private void tabControlPrivateChannels_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int intPage = tabControlPrivateChannels.SelectedIndex;

			Trace.WriteLine(tabControlPrivateChannels.SelectedTab.Name);

			if(intPage == 0) 
			{
				ShowPrivateChannels(); 
			}
			else if(intPage == 1)
			{
				menuItemRefresh_Click(sender, e);
			}
		}
		#endregion

		#region buttons
		private void treeViewSection_Click(object sender, System.EventArgs e)
		{
			treeViewSection.SelectedNode = treeViewSection.GetNodeAt(treeViewSection.PointToClient(Cursor.Position));
			SetNodeMenu();
		}

		private void menuItemNew_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;

			//---create nodes
			treeViewSection.BeginUpdate();
			TreeNode tnChannel = new TreeNode("channel");
			tnChannel.Tag = "element";
			TreeNode tnId = new TreeNode("id = \"\"");
			tnId.Tag = "attribute";
			tnChannel.Nodes.Add(tnId);
			TreeNode tnType = new TreeNode("type = \"\"");
			tnType.Tag = "attribute";
			tnChannel.Nodes.Add(tnType);

			//---add to the parent
			tnSel.Nodes.Add(tnChannel);	
						
			//---scope
			treeViewSection.SelectedNode = tnId;	
			treeViewSection.EndUpdate();

			//---edit
			tnId.BeginEdit(); 

			//---state
			statusBarDeclare.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
			
		}

		private void menuItemDuplicate_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			
			treeViewSection.SelectedNode = tnSel.Parent;
			menuItemNew_Click(sender, e);
		}

		private void menuItemRemove_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			treeViewSection.BeginUpdate();
			tnSel.Remove();
			treeViewSection.EndUpdate();
			treeViewSection.Update();

			//---state
			statusBarDeclare.Visible = true;
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}

		private void menuItemRemoveAll_Click(object sender, System.EventArgs e)
		{
			treeViewSection.BeginUpdate();
			treeViewSection.Nodes[0].Nodes.Clear();
			treeViewSection.EndUpdate();
			treeViewSection.Update();

			//---state
			statusBarDeclare.Visible = true;
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
				cfa.UpdateApplicationChannels(strSectionInnerXml, strConfigFilePath);

				//---state
				treeViewSection.Focus();
				statusBarDeclare.Visible = false;
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
			menuItemRefresh_Click(sender, e);
		}

		private void menuItemRefresh_Click(object sender, System.EventArgs e)
		{
			ConfigFileToTreeView();

			//---state
			treeViewSection.Focus();
			statusBarDeclare.Visible = false;
			buttonApply.Visible = false;
			buttonUndo.Visible = false;	
		}

		private void menuItemExpandAll_Click(object sender, System.EventArgs e)
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			tnSel.ExpandAll();
		}
		#endregion

		#endregion

		#region helpers
		private void ShowChannels(string strChannelsType, TextBox objTextBox, string strConfigFilePath) 
		{
			//---xpath
			string xpath = "/configuration/system.runtime.remoting/channels";

			Trace.WriteLine(strConfigFilePath);

			//---show contents of the config file
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFilePath);
	
			//---find 
			XmlNode channels = doc.DocumentElement.SelectSingleNode(xpath);
			
			//---show contents of the config file
			if(channels != null) 
			{
				ConfigFileAgent cfa = new ConfigFileAgent();
				string strXml = cfa.OutputXmlLayout(channels.OuterXml);
				objTextBox.Text = string.Format("path = {0}\r\n\r\n{1}", strConfigFilePath, strXml);
			}
			else 
			{
				objTextBox.Text = string.Format("path = {0}\r\n\r\n<channels>\r\n</channels>", strConfigFilePath);
			}
		}

		private void SetNodeMenu()
		{
			TreeNode tnSel = treeViewSection.SelectedNode;
			
			if(tnSel != null) 
			{
				string strTag = Convert.ToString(tnSel.Tag);

				Trace.WriteLine(strTag);

				if(strTag == "root") 
				{
					menuItemNew.Visible = true;
					menuItemDuplicate.Visible = false;
					menuItemRemove.Visible = false;
					menuItemRemoveAll.Visible = true;
					menuItemExpandAll.Visible = !tnSel.IsExpanded;;
					menuItemRefresh.Visible = true;
				}
				else if(strTag == "element") 
				{
					menuItemNew.Visible = false;
					menuItemDuplicate.Visible = true;
					menuItemRemove.Visible = true;
					menuItemRemoveAll.Visible = false;
					menuItemExpandAll.Visible = false;
					menuItemRefresh.Visible = false;
				}
				else 
				{
					menuItemNew.Visible = false;
					menuItemDuplicate.Visible = false;
					menuItemRemove.Visible = false;
					menuItemRemoveAll.Visible = false;
					menuItemExpandAll.Visible = false;
					menuItemRefresh.Visible = false;
				}
			}
		}
		#endregion

		#region Events
		private void ChannelsControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			tabControlPrivateChannels.Refresh();
		}
		#endregion
	}
}
