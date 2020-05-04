using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace XPathTester
{
	/// <summary>
	/// Summary description for the form.
	/// </summary>
	public class PathTester : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView documentTree;
		private System.Windows.Forms.TextBox xPathExpression;

		private System.Xml.XmlDocument sourceXmlDocument;
		private System.Collections.Hashtable xmlNodeTreeNodeMapper;
		private System.Windows.Forms.Button testExpression;
		private System.Drawing.Color nodeBackColour;
		private userPreferences _userPreferences;
		private DotNetWidgets.DotNetToolbar mainToolBar;
		private System.Windows.Forms.StatusBar mainStatusBar;
		private DotNetWidgets.DotNetToolbarButtonItem openFileButton;
		private DotNetWidgets.DotNetToolbarButtonItem preferencesButton;
		private DotNetWidgets.DotNetToolbarButtonItem helpButton;
		private DotNetWidgets.FlatComboBox matchList;
		private System.Windows.Forms.Label matchesLabel;
		private const string HELP_URL = "help.mht";
		private System.Windows.Forms.StatusBarPanel documentNamePanel;
		private System.Windows.Forms.StatusBarPanel matchCountPanel;
		private System.Windows.Forms.Label headingLabel;
		private System.Windows.Forms.PictureBox errorPicture;
		private System.Xml.XPath.XPathException _mostRecentException;
		private int _nodesLoaded;
		private System.Windows.Forms.ImageList toolbarImages;
		private System.Windows.Forms.PictureBox titlePicture;
		private System.ComponentModel.IContainer components;

		public PathTester()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			_userPreferences = new userPreferences();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PathTester));
			this.documentTree = new System.Windows.Forms.TreeView();
			this.xPathExpression = new System.Windows.Forms.TextBox();
			this.testExpression = new System.Windows.Forms.Button();
			this.mainToolBar = new DotNetWidgets.DotNetToolbar();
			this.openFileButton = new DotNetWidgets.DotNetToolbarButtonItem();
			this.preferencesButton = new DotNetWidgets.DotNetToolbarButtonItem();
			this.helpButton = new DotNetWidgets.DotNetToolbarButtonItem();
			this.toolbarImages = new System.Windows.Forms.ImageList(this.components);
			this.mainStatusBar = new System.Windows.Forms.StatusBar();
			this.documentNamePanel = new System.Windows.Forms.StatusBarPanel();
			this.matchCountPanel = new System.Windows.Forms.StatusBarPanel();
			this.matchList = new DotNetWidgets.FlatComboBox();
			this.matchesLabel = new System.Windows.Forms.Label();
			this.headingLabel = new System.Windows.Forms.Label();
			this.errorPicture = new System.Windows.Forms.PictureBox();
			this.titlePicture = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.documentNamePanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.matchCountPanel)).BeginInit();
			this.SuspendLayout();
			// 
			// documentTree
			// 
			this.documentTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.documentTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.documentTree.ImageIndex = -1;
			this.documentTree.Location = new System.Drawing.Point(56, 88);
			this.documentTree.Name = "documentTree";
			this.documentTree.SelectedImageIndex = -1;
			this.documentTree.Size = new System.Drawing.Size(552, 320);
			this.documentTree.TabIndex = 0;
			this.documentTree.Leave += new System.EventHandler(this.documentTree_Leave);
			// 
			// xPathExpression
			// 
			this.xPathExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.xPathExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.xPathExpression.Location = new System.Drawing.Point(56, 56);
			this.xPathExpression.Name = "xPathExpression";
			this.xPathExpression.Size = new System.Drawing.Size(496, 20);
			this.xPathExpression.TabIndex = 4;
			this.xPathExpression.Text = "";
			this.xPathExpression.TextChanged += new System.EventHandler(this.xPathExpression_TextChanged);
			// 
			// testExpression
			// 
			this.testExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.testExpression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.testExpression.Location = new System.Drawing.Point(560, 56);
			this.testExpression.Name = "testExpression";
			this.testExpression.Size = new System.Drawing.Size(48, 20);
			this.testExpression.TabIndex = 5;
			this.testExpression.Text = "Test";
			this.testExpression.Click += new System.EventHandler(this.testExpression_Click);
			// 
			// mainToolBar
			// 
			this.mainToolBar.Buttons.Add(this.openFileButton);
			this.mainToolBar.Buttons.Add(this.preferencesButton);
			this.mainToolBar.Buttons.Add(this.helpButton);
			this.mainToolBar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.mainToolBar.ImageList = this.toolbarImages;
			this.mainToolBar.Location = new System.Drawing.Point(0, 0);
			this.mainToolBar.Name = "mainToolBar";
			this.mainToolBar.Size = new System.Drawing.Size(616, 26);
			this.mainToolBar.TabIndex = 7;
			this.mainToolBar.ButtonClick += new DotNetWidgets.DotNetToolbar.ButtonClickEventHandler(this.mainToolBar_ButtonClick);
			// 
			// openFileButton
			// 
			this.openFileButton.ImageIndex = 0;
			this.openFileButton.ToolTipText = "Open XML File";
			// 
			// preferencesButton
			// 
			this.preferencesButton.ImageIndex = 1;
			this.preferencesButton.ToolTipText = "Properties";
			// 
			// helpButton
			// 
			this.helpButton.ImageIndex = 2;
			// 
			// toolbarImages
			// 
			this.toolbarImages.ImageSize = new System.Drawing.Size(16, 16);
			this.toolbarImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolbarImages.ImageStream")));
			this.toolbarImages.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// mainStatusBar
			// 
			this.mainStatusBar.Location = new System.Drawing.Point(0, 424);
			this.mainStatusBar.Name = "mainStatusBar";
			this.mainStatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																							 this.documentNamePanel,
																							 this.matchCountPanel});
			this.mainStatusBar.ShowPanels = true;
			this.mainStatusBar.Size = new System.Drawing.Size(616, 22);
			this.mainStatusBar.TabIndex = 8;
			this.mainStatusBar.Text = "statusBar1";
			// 
			// documentNamePanel
			// 
			this.documentNamePanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.documentNamePanel.Width = 500;
			// 
			// matchList
			// 
			this.matchList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.matchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.matchList.InitialText = "";
			this.matchList.Location = new System.Drawing.Point(221, 4);
			this.matchList.Name = "matchList";
			this.matchList.Size = new System.Drawing.Size(387, 21);
			this.matchList.TabIndex = 9;
			this.matchList.SelectedIndexChanged += new System.EventHandler(this.matchList_SelectedIndexChanged);
			// 
			// matchesLabel
			// 
			this.matchesLabel.Location = new System.Drawing.Point(144, 8);
			this.matchesLabel.Name = "matchesLabel";
			this.matchesLabel.Size = new System.Drawing.Size(72, 16);
			this.matchesLabel.TabIndex = 10;
			this.matchesLabel.Text = "Go To Match";
			// 
			// headingLabel
			// 
			this.headingLabel.Location = new System.Drawing.Point(56, 32);
			this.headingLabel.Name = "headingLabel";
			this.headingLabel.Size = new System.Drawing.Size(136, 16);
			this.headingLabel.TabIndex = 11;
			this.headingLabel.Text = "XPath Expression To Test";
			// 
			// errorPicture
			// 
			this.errorPicture.Cursor = System.Windows.Forms.Cursors.Hand;
			this.errorPicture.Image = ((System.Drawing.Image)(resources.GetObject("errorPicture.Image")));
			this.errorPicture.Location = new System.Drawing.Point(192, 32);
			this.errorPicture.Name = "errorPicture";
			this.errorPicture.Size = new System.Drawing.Size(16, 16);
			this.errorPicture.TabIndex = 12;
			this.errorPicture.TabStop = false;
			this.errorPicture.Visible = false;
			this.errorPicture.Click += new System.EventHandler(this.errorPicture_Click);
			// 
			// titlePicture
			// 
			this.titlePicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.titlePicture.BackColor = System.Drawing.Color.White;
			this.titlePicture.Image = ((System.Drawing.Image)(resources.GetObject("titlePicture.Image")));
			this.titlePicture.Location = new System.Drawing.Point(0, 32);
			this.titlePicture.Name = "titlePicture";
			this.titlePicture.Size = new System.Drawing.Size(48, 392);
			this.titlePicture.TabIndex = 13;
			this.titlePicture.TabStop = false;
			// 
			// PathTester
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 446);
			this.Controls.Add(this.titlePicture);
			this.Controls.Add(this.errorPicture);
			this.Controls.Add(this.headingLabel);
			this.Controls.Add(this.matchesLabel);
			this.Controls.Add(this.matchList);
			this.Controls.Add(this.mainStatusBar);
			this.Controls.Add(this.mainToolBar);
			this.Controls.Add(this.testExpression);
			this.Controls.Add(this.xPathExpression);
			this.Controls.Add(this.documentTree);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PathTester";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XPath Xpress - XPath/Expression/Tester";
			((System.ComponentModel.ISupportInitialize)(this.documentNamePanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.matchCountPanel)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PathTester());
		}
		
		// load the document
		protected void LoadDocument(string documentPath)
		{
			try
			{
				// load the document into a new XmlDocument class.
				documentNamePanel.Text = "Loading XML Document";
				sourceXmlDocument = new System.Xml.XmlDocument();
				sourceXmlDocument.Load(documentPath);
			}
			catch (Exception Ex)
			{
				// display an error message if there was a problem loading the document.
				System.Windows.Forms.MessageBox.Show("There was an error loading the Xml Document " + documentPath + ". " + Ex.Message, "Error Loading Document", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
			}
		}
		
		// populate the tree view with nodes from the Xml Document
		protected void PopulateTreeView()
		{
			// clear the tree view nodes
			documentTree.Nodes.Clear();
			documentTree.Visible = false;
			documentNamePanel.Text = "Populating Tree View";
			_nodesLoaded = 0;
			try
			{
				if (sourceXmlDocument != null)
				{
					
					System.Windows.Forms.TreeNode rootNode = new TreeNode("Document Root");
					xmlNodeTreeNodeMapper.Add(sourceXmlDocument, rootNode);				
					documentTree.Nodes.Add(rootNode);
					nodeBackColour = rootNode.BackColor; // get the default node back colour, for use later when re-setting nodes	
					
					// add the root element
					System.Windows.Forms.TreeNode rootElement = new TreeNode(GetNonLeafNodeText(sourceXmlDocument.DocumentElement));
					xmlNodeTreeNodeMapper.Add(sourceXmlDocument.DocumentElement, rootElement);				
					rootNode.Nodes.Add(rootElement);
				
					// recursively add the child nodes
					AddChildNodes(sourceXmlDocument.DocumentElement, rootElement); 
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error Loading XML Document: " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally 
			{
				documentTree.Visible = true;
				documentNamePanel.Text = "";
			}
		}

		// walk the document tree, recursively adding treeview nodes
		protected void AddChildNodes(System.Xml.XmlNode parentXmlNode, TreeNode parentTreeNode)
		{
			_nodesLoaded += 1;
			documentNamePanel.Text = "Populating Tree View (Nodes Loaded: " + _nodesLoaded.ToString() + ")";
			if (parentXmlNode.HasChildNodes)
			{
				foreach (System.Xml.XmlNode childNode in parentXmlNode.ChildNodes)
				{
					if (typeof(System.Xml.XmlCharacterData) != childNode.GetType())
					{
						TreeNode childTreeNode = new TreeNode(GetNonLeafNodeText(childNode));
						xmlNodeTreeNodeMapper.Add(childNode, childTreeNode);
						parentTreeNode.Nodes.Add(childTreeNode);
						AddChildNodes(childNode, childTreeNode); // recursively add children
					}
				}
			}
			else 
			{
				// set the text for the node
				parentTreeNode.Text = parentXmlNode.OuterXml.Trim();
			}
		}

		// get a text string for a non-leaf node (iterate over all the attributes
		protected string GetNonLeafNodeText(System.Xml.XmlNode sourceNode)
		{
			string elementText = "<";
			if (sourceNode.Prefix.Length > 0)
			{
				elementText += sourceNode.Prefix + ":" + sourceNode.Name;
			}
			else 
			{
				elementText += sourceNode.Name;
			}

			if (sourceNode.Attributes != null)
			{
				foreach (System.Xml.XmlAttribute attribute in sourceNode.Attributes)
				{
					elementText += " " + attribute.Name + "=\"" + attribute.Value + "\"";
				}
			}
			elementText += ">";	
			return elementText;
		}

		private void testExpression_Click(object sender, System.EventArgs e)
		{
				TestXPathExpression(xPathExpression.Text);
		}

		// test the expression
		protected void TestXPathExpression(string expression)
		{
			if (sourceXmlDocument != null)
			{	
				// clear the existing nodes if there are any
				if (documentTree.Nodes.Count > 0)
				{
					ClearNodeSelection(documentTree.Nodes[0]);
				}

				// clear the match items
				matchList.Items.Clear();

				// get the context node for the expression
				System.Xml.XmlNode relativeNodeForExpression = GetRelativeNodeForExpression();
				
				// get the tree node for the context node
				System.Windows.Forms.TreeNode selectedNode = (System.Windows.Forms.TreeNode) xmlNodeTreeNodeMapper[relativeNodeForExpression];
				
				// if the tree node is not null then set the background colour
				if (selectedNode != null)
				{
					selectedNode.BackColor = _userPreferences.ContextNodeColor;
				}
				
				// if the expression is something then test it
				if (expression.Length > 0)
				{
					try 
					{
						System.Xml.XmlNodeList matches = relativeNodeForExpression.SelectNodes(expression);
						matchCountPanel.Text = "Matches: " + matches.Count.ToString();
						HilightMatchingNodes(matches);
						matchList.DisplayMember = "Text";
						xPathExpression.ForeColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.WindowText);
						errorPicture.Visible = false;
					}
					catch (System.Xml.XPath.XPathException xpathEx)
					{
						xPathExpression.ForeColor = System.Drawing.Color.Red;
						_mostRecentException = xpathEx;
						errorPicture.Visible = true;
						matchCountPanel.Text = "";
					}
				}
			}
		
		}
		
		// get the context node for the xpath expression
		protected System.Xml.XmlNode GetRelativeNodeForExpression()
		{
			// if no tree node is selected assume the root node for the XML document
			if (documentTree.SelectedNode == null)
			{
				return sourceXmlDocument.DocumentElement;
			}
			else 
			{
				foreach (System.Collections.DictionaryEntry mappingItem in xmlNodeTreeNodeMapper)
				{
					if ((System.Windows.Forms.TreeNode) mappingItem.Value == documentTree.SelectedNode)
					{
						return (System.Xml.XmlNode) mappingItem.Key;
					}
				}
				// this should never happen
				System.Diagnostics.Debug.Assert(false);
				return null;
			}
		}

	
		// hilight the matching nodes
		protected void HilightMatchingNodes(System.Xml.XmlNodeList matchingNodes)
		{
			foreach (System.Xml.XmlNode match in matchingNodes)
			{
				System.Windows.Forms.TreeNode matchTreeNode = (System.Windows.Forms.TreeNode) xmlNodeTreeNodeMapper[match];
				if (matchTreeNode != null)
				{
					// set the back colour for the matching node
					matchTreeNode.BackColor = _userPreferences.MatchNodeColor;
					matchList.Items.Add(matchTreeNode);
				}
				else 
				{
					// a matching DOM object had no coresponding representation in the tree
					// this should never happen
					System.Diagnostics.Debug.Assert(false);
				}
			}
		}

		// clear the formatting on this node and it's children
		protected void ClearNodeSelection(System.Windows.Forms.TreeNode nodeToClear)
		{
			nodeToClear.BackColor = nodeBackColour;
			foreach (System.Windows.Forms.TreeNode child in nodeToClear.Nodes)
			{
				ClearNodeSelection(child);
			}
		}
		
		// show the preferences
		private void ShowPreferences()
		{
			preferences preferencesWindow = new preferences(_userPreferences);
			preferencesWindow.ShowDialog();
		}

		// show the help
		private void ShowHelp()
		{
			try 
			{
				System.Windows.Forms.Help.ShowHelp(this, HELP_URL);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("There was an unexpected error showing the help file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// show the file open dialog - if the user selects OK then open the file
		private void OpenFile()
		{
			System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();
			openFile.Filter = "XML Files (*.XML)|*.xml|All Files (*.*)|*.*";
			System.Windows.Forms.DialogResult result = openFile.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
			{
				Cursor oldCursor = this.Cursor;
				this.Cursor = Cursors.WaitCursor;
				try
				{
					LoadDocument(openFile.FileName);
					xmlNodeTreeNodeMapper = new System.Collections.Hashtable();
					PopulateTreeView();
					documentNamePanel.Text = openFile.FileName;
				}
				finally 
				{
					this.Cursor = oldCursor;
				}
			}
		}

		// handle toolbar button click events
		private void mainToolBar_ButtonClick(object sender, DotNetWidgets.DotNetToolbarItemClickEventArgs e)
		{
			if (e.Button == openFileButton)
			{
				// open file
				OpenFile();
			}

			if (e.Button == preferencesButton)
			{
				// show the preferences
				ShowPreferences();
			}

			if (e.Button == helpButton)
			{
				// show the help
				ShowHelp();
			}
		}

		// expand the tree node that corresponds to the item selected in the matchList
		private void matchList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			System.Windows.Forms.TreeNode matchNode = (System.Windows.Forms.TreeNode) matchList.SelectedItem;
			matchNode.Expand();
			matchNode.EnsureVisible();
		}

		private void xPathExpression_TextChanged(object sender, System.EventArgs e)
		{
			if (_userPreferences.EvaluateExpressionsInteractively)
			{
				TestXPathExpression(xPathExpression.Text);
			}
		}

		private void errorPicture_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.MessageBox.Show("There was an error evaluating the expression " + xPathExpression.Text + "." + Environment.NewLine + Environment.NewLine + _mostRecentException.Message + Environment.NewLine + Environment.NewLine + _mostRecentException.ToString(), "Error Evaluating Expression", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
		}

		private void documentTree_Leave(object sender, System.EventArgs e)
		{
			TestXPathExpression(xPathExpression.Text);
		}

	}
}
