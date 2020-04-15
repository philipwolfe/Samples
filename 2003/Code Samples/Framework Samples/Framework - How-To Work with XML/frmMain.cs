//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// Used to access various XML classes

using System;
using System.Windows.Forms;
using System.Xml;
// Used to access the File class
// which is used to check for file existance.
using System.IO;
using System.Collections;

public class frmMain : System.Windows.Forms.Form 
{
	// Variables to contain the three
	// file names used in this sample.

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}


	private string mstrModifyFile;
	private string mstrSimpleFile;
	private string mstrBadFile;

	// For seperating headers in text output. Search for examples.
	private string mstrLine = new string(System.Convert.ToChar("="), 35);

	// Module level variables for working with the DOM
	private XmlDocument mxDoc;
	private XmlNode mxNode;
	private XmlNodeList mxNodeList;

	// stringWriter for building text blocks with carriage returns
	// and line feeds.

	StringWriter msw = new StringWriter();

	// Commands to run. Text is loaded at Form_Load into listbox control
	private const string CMD_LOAD_XML_FILE = "Load XML File";
	private const string CMD_LOAD_XML_STRING = "Load XML from string";
	private const string CMD_TEST_FOR_CHILD_NODES = "Tell if a node has children";
	private const  string CMD_ITERATE_ALL_NODES = "Iterate through all nodes";
	private const  string CMD_DETERMINE_NODE_TYPE = "Determine a Node's Type";
	private const  string CMD_LIST_ALL_ELEMENT_NODES = "Retrieve a list of all element nodes";
	private const  string CMD_LIST_ELEMENTS_BY_TAG = "Build a list of all nodes that match a specific tag";
	private const  string CMD_SELECT_NODES = "get {nodes by XPath Expression (selectNodes)";
	private const  string CMD_SELECT_NODE = "get {a node by XPath Expression (selectSingleNode)";
	private const  string CMD_NAVIGATE_RELATED_NODES = "Navigate to Related Nodes, Once I've Found a Node?";
	private const  string CMD_RETRIEVE_ATTRIBUTES = "Retrieve Attributes of a Node?";
	private const  string CMD_CREATE_XML = "Create XML Programmatically?";
	private const  string CMD_ADD_OR_DELETE_ELEMENTS = "Add or Delete Elements?";
	private const  string CMD_ADD_OR_DELETE_ATTRIBUTES = "Add or Delete Attributes?";
	private const  string CMD_MODIFY_ELEMENT = "Modify the Value of an Element Node?";
	private const  string CMD_MODIFY_ATTRIBUTE = "Modify the Value of an Attribute?";
	private const  string CMD_VALID_XML = "Tell if I've Loaded Valid XML?";
	private const  string CMD_PARSE_ERRORS = "Determine What Went Wrong if My XML Won't Load?";

	// Some expressions are hard-coded. Here's a method that lets you enter
	// the text only once.

	private const  string DEF_XPATH_EXP_FIND_NODES = "//Item[new]";
	private const  string DEF_XPATH_EXP_FIND_NODE = "//Department[@Name='Fruits']";

	// TODO: Clean up text and match to correct procs

#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>

	public frmMain() 
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.

		AssemblyInfo ainfo = new AssemblyInfo();
		this.Text = ainfo.Title;
		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing) {
		if (disposing) {
			if (components != null) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	private System.Windows.Forms.MainMenu mnuMain;

	private System.Windows.Forms.MenuItem mnuFile;

	private System.Windows.Forms.MenuItem mnuExit;

	private System.Windows.Forms.MenuItem mnuHelp;

	private System.Windows.Forms.MenuItem mnuAbout;

	private System.Windows.Forms.Panel pnlText;

	private System.Windows.Forms.Splitter splHorText;

	private System.Windows.Forms.TextBox txtXMLDisplay;

	private System.Windows.Forms.TextBox txtXMLEdits;

	private System.Windows.Forms.StatusBar sbInfo;

	private System.Windows.Forms.Splitter splVert;

	private System.Windows.Forms.CheckedListBox lstCommands;

	private System.Windows.Forms.Panel pnlLB;

	private System.Windows.Forms.MenuItem MenuItem1;

	private System.Windows.Forms.MenuItem mnuResetCheckBoxes;

	private System.Windows.Forms.Label lblHowDoI;

	private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuResetCheckBoxes = new System.Windows.Forms.MenuItem();
		this.MenuItem1 = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.sbInfo = new System.Windows.Forms.StatusBar();
		this.pnlLB = new System.Windows.Forms.Panel();
		this.lblHowDoI = new System.Windows.Forms.Label();
		this.lstCommands = new System.Windows.Forms.CheckedListBox();
		this.splVert = new System.Windows.Forms.Splitter();
		this.pnlText = new System.Windows.Forms.Panel();
		this.splHorText = new System.Windows.Forms.Splitter();
		this.txtXMLDisplay = new System.Windows.Forms.TextBox();
		this.txtXMLEdits = new System.Windows.Forms.TextBox();
		this.pnlLB.SuspendLayout();
		this.pnlText.SuspendLayout();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuHelp});
		// 
		// mnuFile
		// 
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuExit});
		this.mnuFile.Text = "&File";
		// 
		// mnuExit
		// 
		this.mnuExit.Index = 0;
		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuResetCheckBoxes,
																				this.MenuItem1,
																				this.mnuAbout});
		this.mnuHelp.Text = "&Help";
		// 
		// mnuResetCheckBoxes
		// 
		this.mnuResetCheckBoxes.Index = 0;
		this.mnuResetCheckBoxes.Text = "&Reset Check Boxes";
		this.mnuResetCheckBoxes.Click += new EventHandler(mnuResetCheckBoxes_Click);
		// 
		// MenuItem1
		// 
		this.MenuItem1.Index = 1;
		this.MenuItem1.Text = "-";
		// 
		// mnuAbout
		// 
		this.mnuAbout.Index = 2;
		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
		// 
		// sbInfo
		// 
		this.sbInfo.Location = new System.Drawing.Point(0, 469);
		this.sbInfo.Name = "sbInfo";
		this.sbInfo.Size = new System.Drawing.Size(802, 22);
		this.sbInfo.TabIndex = 4;
		this.sbInfo.Text = "Ready";
		// 
		// pnlLB
		// 
		this.pnlLB.Controls.Add(this.lblHowDoI);
		this.pnlLB.Controls.Add(this.lstCommands);
		this.pnlLB.Dock = System.Windows.Forms.DockStyle.Left;
		this.pnlLB.Location = new System.Drawing.Point(0, 0);
		this.pnlLB.Name = "pnlLB";
		this.pnlLB.Size = new System.Drawing.Size(344, 469);
		this.pnlLB.TabIndex = 9;
		// 
		// lblHowDoI
		// 
		this.lblHowDoI.BackColor = System.Drawing.SystemColors.ControlDark;
		this.lblHowDoI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblHowDoI.Dock = System.Windows.Forms.DockStyle.Top;
		this.lblHowDoI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.lblHowDoI.ForeColor = System.Drawing.SystemColors.ControlLight;
		this.lblHowDoI.Location = new System.Drawing.Point(0, 0);
		this.lblHowDoI.Name = "lblHowDoI";
		this.lblHowDoI.Size = new System.Drawing.Size(344, 32);
		this.lblHowDoI.TabIndex = 8;
		this.lblHowDoI.Text = "How do I . . .";
		// 
		// lstCommands
		// 
		this.lstCommands.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lstCommands.Location = new System.Drawing.Point(0, 0);
		this.lstCommands.Name = "lstCommands";
		this.lstCommands.Size = new System.Drawing.Size(344, 469);
		this.lstCommands.TabIndex = 7;
		this.lstCommands.ItemCheck += new ItemCheckEventHandler(lstCommands_ItemCheck);
		// 
		// splVert
		// 
		this.splVert.Location = new System.Drawing.Point(344, 0);
		this.splVert.Name = "splVert";
		this.splVert.Size = new System.Drawing.Size(3, 469);
		this.splVert.TabIndex = 10;
		this.splVert.TabStop = false;
		// 
		// pnlText
		// 
		this.pnlText.Controls.Add(this.splHorText);
		this.pnlText.Controls.Add(this.txtXMLDisplay);
		this.pnlText.Controls.Add(this.txtXMLEdits);
		this.pnlText.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pnlText.Location = new System.Drawing.Point(347, 0);
		this.pnlText.Name = "pnlText";
		this.pnlText.Size = new System.Drawing.Size(455, 469);
		this.pnlText.TabIndex = 11;
		// 
		// splHorText
		// 
		this.splHorText.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.splHorText.Location = new System.Drawing.Point(0, 242);
		this.splHorText.Name = "splHorText";
		this.splHorText.Size = new System.Drawing.Size(455, 3);
		this.splHorText.TabIndex = 5;
		this.splHorText.TabStop = false;
		// 
		// txtXMLDisplay
		// 
		this.txtXMLDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtXMLDisplay.Location = new System.Drawing.Point(0, 0);
		this.txtXMLDisplay.Multiline = true;
		this.txtXMLDisplay.Name = "txtXMLDisplay";
		this.txtXMLDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtXMLDisplay.Size = new System.Drawing.Size(455, 245);
		this.txtXMLDisplay.TabIndex = 4;
		this.txtXMLDisplay.Text = "";
		// 
		// txtXMLEdits
		// 
		this.txtXMLEdits.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.txtXMLEdits.Location = new System.Drawing.Point(0, 245);
		this.txtXMLEdits.Multiline = true;
		this.txtXMLEdits.Name = "txtXMLEdits";
		this.txtXMLEdits.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtXMLEdits.Size = new System.Drawing.Size(455, 224);
		this.txtXMLEdits.TabIndex = 3;
		this.txtXMLEdits.Text = "";
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(802, 491);
		this.Controls.Add(this.pnlText);
		this.Controls.Add(this.splVert);
		this.Controls.Add(this.pnlLB);
		this.Controls.Add(this.sbInfo);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.Load += new System.EventHandler(this.frmMain_Load);
		this.pnlLB.ResumeLayout(false);
		this.pnlText.ResumeLayout(false);
		this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

	

	

	// This code simply shows the About form.

	private void mnuAbout_Click(object sender, System.EventArgs e) {

		// Open the About form in Dialog Mode

		frmAbout frm = new frmAbout();

		frm.ShowDialog(this);

		frm.Dispose();

	}

	// This code will close the form.

	private void mnuExit_Click(object sender, System.EventArgs e) {

		// Close the current form

		this.Close();

	}

#endregion

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		string strPath ;
		// Find our where we're running from
		strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
		// Add path to file names
		mstrSimpleFile = strPath + "Simple.xml";
		mstrModifyFile = strPath + "New.xml";
		mstrBadFile = strPath + "Bad.xml";

		bool blnFileNotFound  = false;

		// Check to make sure files exists
		string strMsg  = "The file '{0}' was not found. Please place it in the same directory the application EXE and restart the application.";

		// test to see if files exist
		if (!(File.Exists(mstrSimpleFile)))
		{
			MessageBox.Show(string.Format(strMsg, mstrSimpleFile), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			blnFileNotFound = true;
		}

		if (!(File.Exists(mstrModifyFile)))
		{
			MessageBox.Show(string.Format(strMsg, mstrModifyFile), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			blnFileNotFound = true;
		}

		if (!(File.Exists(mstrBadFile)))
		{
			MessageBox.Show(string.Format(strMsg, mstrModifyFile), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			blnFileNotFound = true;
		}

		// Load the command text which are defined constants in the 
		// module declaration section.
			this.lstCommands.Items.Add(CMD_LOAD_XML_FILE, false);
			this.lstCommands.Items.Add(CMD_LOAD_XML_STRING, false);
			this.lstCommands.Items.Add(CMD_TEST_FOR_CHILD_NODES, false);
			this.lstCommands.Items.Add(CMD_ITERATE_ALL_NODES, false);
			this.lstCommands.Items.Add(CMD_DETERMINE_NODE_TYPE, false);
			this.lstCommands.Items.Add(CMD_LIST_ALL_ELEMENT_NODES, false);
			this.lstCommands.Items.Add(CMD_LIST_ELEMENTS_BY_TAG, false);
			this.lstCommands.Items.Add(CMD_SELECT_NODES, false);
			this.lstCommands.Items.Add(CMD_SELECT_NODE, false);
			this.lstCommands.Items.Add(CMD_NAVIGATE_RELATED_NODES, false);
			this.lstCommands.Items.Add(CMD_RETRIEVE_ATTRIBUTES, false);
			this.lstCommands.Items.Add(CMD_CREATE_XML, false);
			this.lstCommands.Items.Add(CMD_ADD_OR_DELETE_ELEMENTS, false);
			this.lstCommands.Items.Add(CMD_MODIFY_ELEMENT, false);
			this.lstCommands.Items.Add(CMD_ADD_OR_DELETE_ATTRIBUTES, false);
			this.lstCommands.Items.Add(CMD_MODIFY_ATTRIBUTE, false);
			this.lstCommands.Items.Add(CMD_VALID_XML, false);
			this.lstCommands.Items.Add(CMD_PARSE_ERRORS, false);

		// Enable the listbox only if all 3 files were found.
		this.lstCommands.Enabled = (!(blnFileNotFound));
	}

	private void lstCommands_ItemCheck(object sender,System.Windows.Forms.ItemCheckEventArgs e) 
	{
		// The check box next to a command has been
		// changed to checked, run the command.

		if (e.NewValue == CheckState.Checked )
		{
			this.txtXMLDisplay.Text = string.Empty;
			this.txtXMLEdits.Text = string.Empty;

			// Reinitialize the stringWriter which is used
			// to build strings for display in the text boxes
			// on the form.
			msw = new StringWriter();

			switch( this.lstCommands.Items[e.Index].ToString())
			{
				case CMD_LOAD_XML_FILE:
					this.LoadAndDisplayXML();
					break;
				case CMD_LOAD_XML_STRING:
					this.LoadXMLFromstring();
					break;
				case CMD_TEST_FOR_CHILD_NODES:
					this.HasAnyChildren();
					break;
				case CMD_ITERATE_ALL_NODES:
					this.IterateThroughNodes();
					break;
				case CMD_DETERMINE_NODE_TYPE:
					this.DetermineNodeType();
					break;
				case CMD_LIST_ALL_ELEMENT_NODES:
					this.ListElementNodes();
					break;
				case CMD_LIST_ELEMENTS_BY_TAG:
					this.ListSpecificTag();
					break;
				case CMD_SELECT_NODES:
					this.CreateNodeList();
					break;
				case CMD_SELECT_NODE:
					this.ReferToNode();
					break;
				case CMD_NAVIGATE_RELATED_NODES:
					this.NavigateToNodes();
					break;
				case CMD_RETRIEVE_ATTRIBUTES:
					this.RetrieveAttributes();
					break;
				case CMD_CREATE_XML:
					this.CreateXML();
					break;
				case CMD_ADD_OR_DELETE_ELEMENTS:
					this.AddDeleteNode();
					break;
				case CMD_ADD_OR_DELETE_ATTRIBUTES:
					this.AddDeleteAttribute();
					break;
				case CMD_MODIFY_ELEMENT:
					this.ModifyElementValue();
					break;
				case CMD_MODIFY_ATTRIBUTE:
					ModifyAttributeValue();
					break;
				case CMD_VALID_XML:
					this.CheckifXMLValid();
					break;
				case CMD_PARSE_ERRORS:
					this.GetXMLErrorDetail();
					break;
			}
			// Update the status bar with the last run command
			this.sbInfo.Text = "Last run command: " + this.lstCommands.Items[e.Index].ToString();
			// Clean up the stringWriter
			msw.Flush();
			msw.Close();
		}
	}

	private void mnuResetCheckBoxes_Click(object sender, System.EventArgs e)
	{
		// Reset the check boxes that are checked to be 
		// not checked.
		if (this.lstCommands.CheckedItems.Count > 0) 
		{
			this.txtXMLDisplay.Text = string.Empty;
			this.txtXMLEdits.Text = string.Empty;

			int i;
			IEnumerator enumRef;
			enumRef = this.lstCommands.CheckedIndices.GetEnumerator();

			while (!(enumRef.MoveNext() == false))
			{
				i = Convert.ToInt32(enumRef.Current);
				this.lstCommands.SetItemChecked(i, false);
			}
		}
	}

	private void AddDeleteNode()
	{
		// This method will remove a node
		// and then add four new nodes.
		XmlDocument xDoc = new XmlDocument();
		xDoc.Load(mstrModifyFile);
		this.txtXMLDisplay.Text = xDoc.OuterXml;
		XmlNode xNode;
		XmlElement xElmntFamily;

		// Search for a particular node
		xNode = xDoc.SelectSingleNode("//Family");

		if (!(xNode == null))
		{
			//if (xNode.GetType() == typeof(XmlElement)) 
			//{
				xElmntFamily = (XmlElement) (xNode);
			//}
			
				xElmntFamily.RemoveChild(xElmntFamily.SelectSingleNode("Father"));
				// Insert node for each family member:
				InsertTextNode(xDoc, xElmntFamily, "Person", "Gerald L. Smith");
				// Here's what InsertTextNode does:
				//set {xNode = xDoc.createElement("father")
				//xNode.appendChild xDoc.createTextNode("Gerald L. Smith")
				//xElmntFamily.appendChild xNode

				InsertTextNode(xDoc, xElmntFamily, "Person", "Sara Ann Smith");
				InsertTextNode(xDoc, xElmntFamily, "Person", "Richard Andrew Smith");
				InsertTextNode(xDoc, xElmntFamily, "Person", "Emily Jean Smith");
				xDoc.Save(mstrModifyFile);
				this.txtXMLEdits.Text = xDoc.OuterXml;
			
		}
		else 
		{
			this.txtXMLEdits.Text = string.Format("Family Node was not found. Please try the '{0}' option first.", CMD_CREATE_XML);
		}
	}

	private void AddDeleteAttribute()
	{
		// This method will remove
		// all child nodes of the Family 
		// node and then re-add them with 
		// some attributes.
		// It also shows how to manipulate
		// existing attributes.

		XmlDocument xDoc = new XmlDocument();
		xDoc.Load(mstrModifyFile);
		this.txtXMLDisplay.Text = xDoc.OuterXml;
		XmlNode xNode;
		XmlElement xElem;
		XmlElement xElmntFamily;
		// Search for a particular node.
		xNode = xDoc.SelectSingleNode("//Family");

		if (!(xNode == null))
		{
			//if (xNode.GetType() == typeof(XmlElement)) 
			//{
			xElmntFamily = (XmlElement) (xNode);
			//}
			// Delete all the nodes created in the previous answer.
			foreach(XmlNode xxNode in xElmntFamily)
			{
				xElmntFamily.RemoveChild(xxNode);
			}

			// Insert node for each family member:
			xElem = InsertTextNode(xDoc, xElmntFamily, "Person", "Gerald L. Smith");
			xElem.SetAttribute("type", "parent");
			xElem.SetAttribute("age", "70");
			xElem = InsertTextNode(xDoc, xElmntFamily, "Person", "Sara Ann Smith");
			xElem.SetAttribute("type", "mother");
			xElem = InsertTextNode(xDoc, xElmntFamily, "Person", "Richard Andrew Smith");
			xElem.SetAttribute("type", "son");
			xElem = InsertTextNode(xDoc, xElmntFamily, "Person", "Emily Jean Smith");
			xElem.SetAttribute("type", "daughter");

			// Attributes aren't quite right. Fix up father's.
			xNode = xDoc.SelectSingleNode("//Person[@type='parent']");

			if (!(xNode == null))
			{
				// Remove "age" attribute, and change "type" attribute
				// to "father".
				xElem = (XmlElement) (xNode);
				xElem.Attributes.RemoveNamedItem("age");
				xElem.SetAttribute("type", "father");
			}
			xDoc.Save(mstrModifyFile);
			this.txtXMLEdits.Text = xDoc.OuterXml;
		}
		else 
		{
			this.txtXMLEdits.Text = string.Format("Family Node was not found. Please try the '{0}' option first.", CMD_CREATE_XML);
		}
	}

	private void CheckifXMLValid()
	{
		XmlDocument xDoc = new XmlDocument();

		try 
		{
			// if the XML file (or string for that matter)
			// is invalid, an exception of the type
			// XmlException will be thrown
			xDoc.Load(mstrBadFile);
			// You should not see this if using our 'bad' file.
			this.txtXMLDisplay.Text = "Valid XML File: " + mstrBadFile;
		}
		catch (XmlException exp)
		{
			this.txtXMLDisplay.Text = "Invalid XML File: " + mstrBadFile;
		}
		catch (Exception exp) 
		{
			// Just in case
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void CreateNodeList()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		//XmlElement xElem;
		string strTag;
		strTag = InputDialog.ShowInputBox("Enter an XPath expression to find:", "Enter Search Expression", DEF_XPATH_EXP_FIND_NODES);

		if (strTag.Length > 0)
		{
			// Find a group of nodes based upon the enterd XPath expression.
			mxNodeList = mxDoc.SelectNodes(strTag);
			msw.WriteLine("All text elements matching '{0}':", strTag);
			msw.WriteLine(mstrLine);
			if (!(mxNodeList == null))
				{
				foreach(XmlElement xElem in mxNodeList)
				{
					msw.WriteLine("Name: " + xElem.Name);
					msw.WriteLine("InnerText: " + xElem.InnerText);
					msw.WriteLine("InnerXml: " + xElem.InnerXml);
				}
				}
				this.txtXMLDisplay.Text = msw.ToString();
		}
	}

	private void CreateXML()
	{
		// This method shows how to build
		// an XML file all from code.
		XmlDocument xDoc = new XmlDocument();
		XmlProcessingInstruction xPI;
		XmlComment xComment;
		XmlElement xElmntRoot;
		XmlElement xElmntFamily;

		xPI = xDoc.CreateProcessingInstruction("xml", "version='1.0'");
		xDoc.AppendChild(xPI);
		xComment = xDoc.CreateComment("Family Information");
		xDoc.AppendChild(xComment);
		xElmntRoot = xDoc.CreateElement("xml");
		xDoc.AppendChild(xElmntRoot);

		// Rather than creating new nodes individually,
		// count on the fact that AppendChild returns a reference
		// to the newly added node.
		xElmntFamily = (XmlElement) (xElmntRoot.AppendChild(xDoc.CreateElement("Family")));
		xElmntFamily.AppendChild(xDoc.CreateElement("Father"));

		// Obviously this could fail if we don't have permission.
		// Note that if the file exists, Save just overwrites.
		// You might want to check for its existance like this:
		//if File.Exists(mstrModifyFile) {
		//	if MessageBox.Show(string.Format("Do you want to overwrite the file {0}?", mstrModifyFile), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes {
		//		xDoc.Save(mstrModifyFile)
		//	}
		//}
		xDoc.Save(mstrModifyFile);
		// Note that the XML that is output is not 'pretty'.
		// The parser doesn't introduce whitespace like 
		// carriage returns, etc.
		this.txtXMLDisplay.Text = xDoc.OuterXml;
	}

	private void DetermineNodeType()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		// Use a recursive function to visit all nodes
		TraverseTreeType(msw, mxDoc, 0);
		this.txtXMLDisplay.Text = msw.ToString();
	}

	private void GetXMLErrorDetail()
	{
		XmlDocument xDoc = new XmlDocument();
		try 
		{
			// if the XML file (or string for that matter)
			// is invalid, an exception of the type
			// XmlException will be thrown
			xDoc.Load(mstrBadFile);
			// You should not see this if using our 'bad' file.
			this.txtXMLDisplay.Text = "Valid XML File: " + mstrBadFile;
		}
		catch (XmlException exp)
		{
			msw.WriteLine(exp.Message);
			// You can get these items individually.
			//.WriteLine(exp.LineNumber)
			//.WriteLine(exp.LinePosition)
			// Other items are buried in the args array
			// Take a look in break mode.
			this.txtXMLDisplay.Text = msw.ToString();
		}
		catch (Exception exp) 
		{
			// Just in case
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void HasAnyChildren()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		string tab2x  = "\t" + "\t";
		// if the document has children, 
		// look at them all.
		if (mxDoc.HasChildNodes) 
		{
			foreach(XmlNode mxNode in mxDoc.ChildNodes)
			{
				msw.WriteLine(mstrLine);
				msw.WriteLine("Name: {0}{1}", tab2x, mxNode.Name);
				msw.WriteLine("Type: {0}{1}", tab2x, mxNode.NodeType);
				msw.WriteLine("Type (string): {0}{1}", "\t", mxNode.NodeType.ToString());
				msw.WriteLine("Value: {0}{1}", tab2x, mxNode.Value);
				msw.WriteLine("Outer XML: {0}{1}", "\t", mxNode.OuterXml);
			}
			this.txtXMLDisplay.Text = msw.ToString();
		}
	}

	private XmlElement InsertTextNode(XmlDocument xDoc,XmlNode xNode ,string strTag, string strText) 
	{
		// Insert a text node a child of xNode.
		// Set the tag to be strTag, and the
		// text to be strText. return a pointer
		// to the new node.
		XmlNode xNodeTemp;
		xNodeTemp = xDoc.CreateElement(strTag);
		xNodeTemp.AppendChild(xDoc.CreateTextNode(strText));
		xNode.AppendChild(xNodeTemp);
		return (XmlElement) (xNodeTemp);
	}

	private void IterateThroughNodes()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		// Use a recursive function to visit all nodes
		TraverseTree(msw, mxDoc, 0);
		this.txtXMLDisplay.Text = msw.ToString();
	}

	private void ListElementNodes()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		// Search for elements by tag name.
		// This example is hard-coded to find ALL (*) elements
		mxNodeList = mxDoc.GetElementsByTagName("*");
		msw.WriteLine("Elements matching '*':");
		msw.WriteLine(mstrLine);

		foreach(XmlNode mxNode in mxNodeList)
		{
			msw.WriteLine(mxNode.Name);
		}
		this.txtXMLDisplay.Text = msw.ToString();
	}

	private void ListSpecificTag()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		string strTag;
		//XmlNode xnt;
		// This function allows you to search for specific elements by tag name.
		strTag = InputDialog.ShowInputBox("Enter a Tag to find:", "Enter Tag", "*");

		if (strTag.Length > 0) 
		{
			mxNodeList = mxDoc.GetElementsByTagName(strTag);
			msw.WriteLine("All text elements matching '{0}':", strTag);
			msw.WriteLine(mstrLine);

			foreach(XmlNode mxNode in mxNodeList)
			{
				foreach(XmlNode xnt in mxNode.ChildNodes)
				{
				if (xnt.NodeType == XmlNodeType.Text) 
					{
					msw.WriteLine(mxNode.Name + ": " + xnt.Value);
					}
				}
				
			}
			this.txtXMLDisplay.Text = msw.ToString();
		}
	}

	private void LoadXMLFromFile()
	{
		// Defer to more complex version
		this.LoadXMLFromFile(false);
	}

	private void LoadXMLFromFile(bool ForceReload)
	{
		// intialize XML Document
		// Only re-load if ForceReload is true or
		// the document is uninitialized.
		// Orelse { performs short-circut evaluation
		// unlike || which will execute both tests
		// even if ForceReload is true

		if ((ForceReload) || (mxDoc == null))
		{
			mxDoc = new XmlDocument();
			mxDoc.Load(mstrSimpleFile);
		}
	}

	private void LoadAndDisplayXML()
	{
		this.LoadXMLFromFile();
		this.txtXMLDisplay.Text = mxDoc.OuterXml;
	}

	private void LoadXMLFromstring()
	{
		// Build an arbitrary string with XML Markup.
		// Note that the carriage returns are for humans.
		// The XML processor doesn't need them.
		// You can adjust whether or not the parser 'respects'
		// whitespace by adjusting the PreserveWhitespace
		// property of the XmlDocument class shown below.
		// Use the stringWriter class

			msw.WriteLine("<xml>");
			msw.WriteLine("<Family>");
			msw.WriteLine("    <Person type='father'>Gerald L. Smith</Person>");
			msw.WriteLine("    <Person type='mother'>Sara Ann Smith</Person>");
			msw.WriteLine("    <Person type='child' gender='male'>Richard Andrew Smith</Person>");
			msw.WriteLine("    <Person type='child' gender='female'>Emily Jean Smith</Person>");
			msw.WriteLine("</Family>");
			msw.WriteLine("</xml>");

		// intialize a new local XML Document instance
		XmlDocument xDoc = new XmlDocument();

		// Tell the parser to leave CRLFs in the document.
		xDoc.PreserveWhitespace = true;
		xDoc.LoadXml(msw.ToString());
		this.txtXMLDisplay.Text = xDoc.OuterXml;
	}

	private void ModifyElementValue()
	{
		// Shows how to modify an element's text value
		XmlDocument xDoc = new XmlDocument();
		xDoc.Load(mstrModifyFile);
		this.txtXMLDisplay.Text = xDoc.OuterXml;
		XmlNode xNode;
		XmlElement xElem;
		XmlElement xElmntFamily;
		xNode = xDoc.SelectSingleNode("//Person");

		if (! (xNode == null)) 
		{
			xElem = (XmlElement) (xNode);
			// Change "Gerald L. Smith" to "Jerry Smith"
			xElem.InnerText = "Jerry Smith";
			this.txtXMLEdits.Text = xDoc.OuterXml;
		}
		else 
		{
			this.txtXMLEdits.Text = string.Format("Family Node was not found. Please try the '{0}' option first.", CMD_CREATE_XML);
		}
	}

	private void ModifyAttributeValue()
	{
		// Shows how to modify existing attribute values
		XmlDocument xDoc = new XmlDocument();
		xDoc.Load(mstrModifyFile);
		this.txtXMLDisplay.Text = xDoc.OuterXml;
		//XmlNode xNode;
		XmlElement xElem;

		foreach(XmlNode xNode in xDoc.SelectNodes("//Person"))
		{
			xElem = (XmlElement) (xNode);

			switch( xElem.GetAttribute("type"))
			{
				case "father":
					xElem.SetAttribute("type", "parent");
					xElem.SetAttribute("gender", "male");
					break;
				case "mother":
					xElem.SetAttribute("type", "parent");
					xElem.SetAttribute("gender", "female");
					break;
				case "son":
					xElem.SetAttribute("type", "child");
					xElem.SetAttribute("gender", "male");
					break;
				case "daughter":
					xElem.SetAttribute("type", "child");
					xElem.SetAttribute("gender", "female");
					break;
			}
		}
		this.txtXMLEdits.Text = xDoc.OuterXml;
	}

	private void NavigateToNodes()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		XmlElement xElem;
		XmlNode xnodTemp;
		// Print out the name of each new item:
		mxNodeList = mxDoc.SelectNodes("//new");

		if (!(mxNodeList == null))
		{
			msw.WriteLine("All new Items:");
			msw.WriteLine(mstrLine);

			foreach(XmlNode mxNode in mxNodeList)
			{
				xnodTemp = mxNode.ParentNode.SelectSingleNode("Name");

				if (!(xnodTemp == null))
				{
					if (xnodTemp.GetType() == typeof(XmlElement)) 
					{
						xElem = (XmlElement) (xnodTemp);
						msw.WriteLine(xElem.InnerText);
					}
				}
			}
			this.txtXMLDisplay.Text = msw.ToString();
		}
	}

	private void ReferToNode()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		XmlElement xElem;
		string strTag = "";
		strTag = InputDialog.ShowInputBox("Enter an XPath expression to find:", "Enter Search Expression", DEF_XPATH_EXP_FIND_NODE);

		if (strTag.Length > 0)
		{
			msw.WriteLine("All elements matching '{0}':", strTag);
			msw.WriteLine(mstrLine);
			mxNode = mxDoc.SelectSingleNode(strTag);

			if (! (mxNode == null))
			{
				if (mxNode.GetType() == typeof(XmlElement)) 
				{
					xElem = (XmlElement) (mxNode);
					msw.WriteLine(xElem.InnerText);
				}
			}
			this.txtXMLDisplay.Text = msw.ToString();
		}
	}

	private void RetrieveAttributes()
	{
		// intialize XML Document
		this.LoadXMLFromFile();
		XmlAttribute xAttr;
		XmlNode xTmpNode;
		mxNodeList = mxDoc.SelectNodes("//Item");

		if (! (mxNodeList == null)) 
		{
			msw.WriteLine("All Item Attributes:");
			msw.WriteLine(mstrLine);
			
			foreach(XmlNode mxNode in mxNodeList)
			{
				msw.WriteLine("{0} ({1})", mxNode.Name, mxNode.InnerText);

				foreach(XmlAttribute xxAttr in mxNode.Attributes)
				{
					msw.WriteLine("   {0}: {1}", xxAttr.Name, xxAttr.Value);
				}
			}
		}
		msw.WriteLine();
		msw.WriteLine();

		mxNodeList = mxDoc.SelectNodes("//Department");

		if (! (mxNodeList == null)) 
		{
			msw.WriteLine("Departments:");
			msw.WriteLine(mstrLine);

			foreach(XmlNode mxNode in mxNodeList)
			{
				xTmpNode = mxNode.Attributes.GetNamedItem("Name");

				if (! (xTmpNode == null)) 
				{
					xAttr = (XmlAttribute) (xTmpNode);
					msw.WriteLine(xAttr.Value);
				}				
			}
		}
		this.txtXMLDisplay.Text = msw.ToString();
	}

	private void TraverseTree(StringWriter sw ,XmlNode xNode, int intLevel)
	{
		//XmlNode xNodeLoop;
		// Print out the node name for the
		// current node.
		
		
		string s = "\t";
		
		sw.WriteLine(s + xNode.Name);
		// if the current node has children, call this
		// same procedure, passing in that node. Increase
		// the lngLevel value, so the output can be indented.

		if (xNode.HasChildNodes) 
		{
			foreach(XmlNode xNodeLoop in xNode.ChildNodes)
			{
				TraverseTree(sw, xNodeLoop, intLevel + 1);
			}
		}
	}

	private void TraverseTreeType(StringWriter sw ,XmlNode xNode, int intLevel)
	{
		//XmlNode xNodeLoop;
		// Print out the node name for the
		// current node.

		string s = "\t";
		string[] strValues  = {s, xNode.Name, xNode.NodeType.ToString()};
		sw.WriteLine("{0}{1} ({2})", strValues);

		// if the current node has children, call this
		// same procedure, passing in that node. Increase
		// the lngLevel value, so the output can be indented.

		if (xNode.HasChildNodes) 
		{
			foreach(XmlNode xNodeLoop in xNode.ChildNodes)
			{
				TraverseTreeType(sw, xNodeLoop, intLevel + 1);
			}
		}
	}

		//string strTag = InputDialog.ShowInputBox("This is my title", "This is my label", "my Text");
		
}

