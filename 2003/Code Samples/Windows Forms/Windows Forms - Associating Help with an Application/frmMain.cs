//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

public class frmMain : System.Windows.Forms.Form
{

#region " Windows Form Designer generated code "

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
	protected override void Dispose(bool disposing) 
	{
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

    private System.Windows.Forms.TabControl tcMain;

    private System.Windows.Forms.TabPage tpToolTip;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.TextBox txtProductName;

    private System.Windows.Forms.TextBox txtPrice;

    private System.Windows.Forms.Button btnExecute;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.ToolTip ToolTip1;

    private System.Windows.Forms.TabPage tpPopUpHelp;

    private System.Windows.Forms.Button btnSave;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.Button btnClear;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.TabPage tpHTMLHelp;

    private System.Windows.Forms.MenuItem mnuContentsHelp;

    private System.Windows.Forms.MenuItem mnuIndexHelp;

    private System.Windows.Forms.MenuItem mnuSearchHelp;

    private System.Windows.Forms.MenuItem MenuItem4;

    private System.Windows.Forms.TabPage tpErrorHelp;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.TextBox txtNumberValue;

    private System.Windows.Forms.Button btnSubmit;

    private System.Windows.Forms.TextBox txtTextValue;

    private System.Windows.Forms.ErrorProvider ErrorProvider1;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.Button btnLink2;

    private System.Windows.Forms.Button btnLink1;

    private System.Windows.Forms.HelpProvider hpAdvancedCHM;

    private System.Windows.Forms.Button btnLink3;

    private System.Windows.Forms.HelpProvider hpPlainHTML;

    private System.Windows.Forms.Label Label10;

    private System.Windows.Forms.RichTextBox rtbTextEntry;

    private void InitializeComponent() 
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuContentsHelp = new System.Windows.Forms.MenuItem();
		this.mnuIndexHelp = new System.Windows.Forms.MenuItem();
		this.mnuSearchHelp = new System.Windows.Forms.MenuItem();
		this.MenuItem4 = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.tcMain = new System.Windows.Forms.TabControl();
		this.tpToolTip = new System.Windows.Forms.TabPage();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.btnExecute = new System.Windows.Forms.Button();
		this.txtPrice = new System.Windows.Forms.TextBox();
		this.txtProductName = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.tpPopUpHelp = new System.Windows.Forms.TabPage();
		this.Label5 = new System.Windows.Forms.Label();
		this.btnClear = new System.Windows.Forms.Button();
		this.Label4 = new System.Windows.Forms.Label();
		this.btnSave = new System.Windows.Forms.Button();
		this.rtbTextEntry = new System.Windows.Forms.RichTextBox();
		this.tpHTMLHelp = new System.Windows.Forms.TabPage();
		this.Label10 = new System.Windows.Forms.Label();
		this.btnLink3 = new System.Windows.Forms.Button();
		this.Label9 = new System.Windows.Forms.Label();
		this.btnLink2 = new System.Windows.Forms.Button();
		this.btnLink1 = new System.Windows.Forms.Button();
		this.tpErrorHelp = new System.Windows.Forms.TabPage();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.txtNumberValue = new System.Windows.Forms.TextBox();
		this.btnSubmit = new System.Windows.Forms.Button();
		this.txtTextValue = new System.Windows.Forms.TextBox();
		this.hpAdvancedCHM = new System.Windows.Forms.HelpProvider();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.ErrorProvider1 = new System.Windows.Forms.ErrorProvider();
		this.hpPlainHTML = new System.Windows.Forms.HelpProvider();
		this.tcMain.SuspendLayout();
		this.tpToolTip.SuspendLayout();
		this.tpPopUpHelp.SuspendLayout();
		this.tpHTMLHelp.SuspendLayout();
		this.tpErrorHelp.SuspendLayout();
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
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuContentsHelp,
																				this.mnuIndexHelp,
																				this.mnuSearchHelp,
																				this.MenuItem4,
																				this.mnuAbout});
		this.mnuHelp.Text = "&Help";
		// 
		// mnuContentsHelp
		// 
		this.mnuContentsHelp.Index = 0;
		this.mnuContentsHelp.Text = "Contents...";
		this.mnuContentsHelp.Click += new System.EventHandler(this.mnuContentsHelp_Click);
		// 
		// mnuIndexHelp
		// 
		this.mnuIndexHelp.Index = 1;
		this.mnuIndexHelp.Text = "Index...";
		this.mnuIndexHelp.Click += new System.EventHandler(this.mnuIndexHelp_Click);
		// 
		// mnuSearchHelp
		// 
		this.mnuSearchHelp.Index = 2;
		this.mnuSearchHelp.Text = "Search...";
		this.mnuSearchHelp.Click += new System.EventHandler(this.mnuSearchHelp_Click);
		// 
		// MenuItem4
		// 
		this.MenuItem4.Index = 3;
		this.MenuItem4.Text = "-";
		// 
		// mnuAbout
		// 
		this.mnuAbout.Index = 4;
		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		// 
		// tcMain
		// 
		this.tcMain.AccessibleDescription = "Tab Control";
		this.tcMain.AccessibleName = "Tab Control";
		this.tcMain.Controls.Add(this.tpToolTip);
		this.tcMain.Controls.Add(this.tpPopUpHelp);
		this.tcMain.Controls.Add(this.tpHTMLHelp);
		this.tcMain.Controls.Add(this.tpErrorHelp);
		this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tcMain.ItemSize = new System.Drawing.Size(76, 18);
		this.tcMain.Location = new System.Drawing.Point(0, 0);
		this.tcMain.Name = "tcMain";
		this.tcMain.SelectedIndex = 0;
		this.hpAdvancedCHM.SetShowHelp(this.tcMain, false);
		this.hpPlainHTML.SetShowHelp(this.tcMain, false);
		this.tcMain.ShowToolTips = true;
		this.tcMain.Size = new System.Drawing.Size(418, 267);
		this.tcMain.TabIndex = 0;
		// 
		// tpToolTip
		// 
		this.tpToolTip.AccessibleDescription = "Tab Page Tool Tip";
		this.tpToolTip.AccessibleName = "Tab Page Tool Tip";
		this.tpToolTip.Controls.Add(this.Label3);
		this.tpToolTip.Controls.Add(this.Label2);
		this.tpToolTip.Controls.Add(this.btnExecute);
		this.tpToolTip.Controls.Add(this.txtPrice);
		this.tpToolTip.Controls.Add(this.txtProductName);
		this.tpToolTip.Controls.Add(this.Label1);
		this.tpToolTip.Location = new System.Drawing.Point(4, 22);
		this.tpToolTip.Name = "tpToolTip";
		this.hpAdvancedCHM.SetShowHelp(this.tpToolTip, false);
		this.hpPlainHTML.SetShowHelp(this.tpToolTip, false);
		this.tpToolTip.Size = new System.Drawing.Size(410, 241);
		this.tpToolTip.TabIndex = 0;
		this.tpToolTip.Text = "Tool Tip Help";
		this.tpToolTip.ToolTipText = "Tab One";
		// 
		// Label3
		// 
		this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label3.Location = new System.Drawing.Point(216, 80);
		this.Label3.Name = "Label3";
		this.hpPlainHTML.SetShowHelp(this.Label3, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label3, false);
		this.Label3.Size = new System.Drawing.Size(64, 16);
		this.Label3.TabIndex = 5;
		this.Label3.Text = "Price";
		// 
		// Label2
		// 
		this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label2.Location = new System.Drawing.Point(24, 80);
		this.Label2.Name = "Label2";
		this.hpPlainHTML.SetShowHelp(this.Label2, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label2, false);
		this.Label2.Size = new System.Drawing.Size(168, 16);
		this.Label2.TabIndex = 4;
		this.Label2.Text = "Product Name";
		// 
		// btnExecute
		// 
		this.btnExecute.AccessibleDescription = "Execute button";
		this.btnExecute.AccessibleName = "Execute button";
		this.btnExecute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnExecute.Location = new System.Drawing.Point(24, 120);
		this.btnExecute.Name = "btnExecute";
		this.hpPlainHTML.SetShowHelp(this.btnExecute, false);
		this.hpAdvancedCHM.SetShowHelp(this.btnExecute, false);
		this.btnExecute.TabIndex = 3;
		this.btnExecute.Text = "Execute";
		this.ToolTip1.SetToolTip(this.btnExecute, "Execute the Query");
		// 
		// txtPrice
		// 
		this.txtPrice.AccessibleDescription = "Product Price";
		this.txtPrice.AccessibleName = "Product Price";
		this.txtPrice.Location = new System.Drawing.Point(216, 96);
		this.txtPrice.Name = "txtPrice";
		this.hpAdvancedCHM.SetShowHelp(this.txtPrice, false);
		this.hpPlainHTML.SetShowHelp(this.txtPrice, false);
		this.txtPrice.Size = new System.Drawing.Size(72, 20);
		this.txtPrice.TabIndex = 2;
		this.txtPrice.Text = "";
		this.ToolTip1.SetToolTip(this.txtPrice, "Enter a price.");
		// 
		// txtProductName
		// 
		this.txtProductName.AccessibleDescription = "Product Name";
		this.txtProductName.AccessibleName = "Product Name";
		this.txtProductName.Location = new System.Drawing.Point(24, 96);
		this.txtProductName.Name = "txtProductName";
		this.hpAdvancedCHM.SetShowHelp(this.txtProductName, false);
		this.hpPlainHTML.SetShowHelp(this.txtProductName, false);
		this.txtProductName.Size = new System.Drawing.Size(184, 20);
		this.txtProductName.TabIndex = 1;
		this.txtProductName.Text = "";
		this.ToolTip1.SetToolTip(this.txtProductName, "Enter a product name.");
		// 
		// Label1
		// 
		this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label1.Location = new System.Drawing.Point(16, 16);
		this.Label1.Name = "Label1";
		this.hpAdvancedCHM.SetShowHelp(this.Label1, false);
		this.hpPlainHTML.SetShowHelp(this.Label1, false);
		this.Label1.Size = new System.Drawing.Size(376, 56);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Hover your mouse pointer over the controls to display the tool tip.  The ToolTip " +
			"control is being used to do this. This control gives every control on the form a" +
			" new property called tooltip on tooltip1.  This is where the tool tip message is" +
			" entered.";
		// 
		// tpPopUpHelp
		// 
		this.tpPopUpHelp.Controls.Add(this.Label5);
		this.tpPopUpHelp.Controls.Add(this.btnClear);
		this.tpPopUpHelp.Controls.Add(this.Label4);
		this.tpPopUpHelp.Controls.Add(this.btnSave);
		this.tpPopUpHelp.Controls.Add(this.rtbTextEntry);
		this.tpPopUpHelp.Location = new System.Drawing.Point(4, 22);
		this.tpPopUpHelp.Name = "tpPopUpHelp";
		this.hpAdvancedCHM.SetShowHelp(this.tpPopUpHelp, false);
		this.hpPlainHTML.SetShowHelp(this.tpPopUpHelp, false);
		this.tpPopUpHelp.Size = new System.Drawing.Size(410, 241);
		this.tpPopUpHelp.TabIndex = 1;
		this.tpPopUpHelp.Text = "PopUp Help";
		// 
		// Label5
		// 
		this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label5.Location = new System.Drawing.Point(16, 88);
		this.Label5.Name = "Label5";
		this.hpPlainHTML.SetShowHelp(this.Label5, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label5, false);
		this.Label5.Size = new System.Drawing.Size(100, 16);
		this.Label5.TabIndex = 4;
		this.Label5.Text = "Text Entry";
		// 
		// btnClear
		// 
		this.btnClear.AccessibleDescription = "Clear button";
		this.btnClear.AccessibleName = "Clear button";
		this.hpAdvancedCHM.SetHelpString(this.btnClear, "This is the clear text area button. Press this button to clear the text area.");
		this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnClear.Location = new System.Drawing.Point(96, 208);
		this.btnClear.Name = "btnClear";
		this.hpPlainHTML.SetShowHelp(this.btnClear, false);
		this.hpAdvancedCHM.SetShowHelp(this.btnClear, true);
		this.btnClear.TabIndex = 3;
		this.btnClear.Text = "Clear";
		// 
		// Label4
		// 
		this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label4.Location = new System.Drawing.Point(16, 16);
		this.Label4.Name = "Label4";
		this.hpPlainHTML.SetShowHelp(this.Label4, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label4, false);
		this.Label4.Size = new System.Drawing.Size(384, 72);
		this.Label4.TabIndex = 2;
		this.Label4.Text = @"Left click the question mark icon on the top right of the form and then left click one of the controls to view the pop up help.  The help provider is being used to provide the pop up help for the controls.  The help provider control adds a new property to each control called Helpstring on HelpProvider1.  The text for the popup message is entered for this property.";
		// 
		// btnSave
		// 
		this.btnSave.AccessibleDescription = "Save Button";
		this.btnSave.AccessibleName = "Save Button";
		this.hpAdvancedCHM.SetHelpString(this.btnSave, "This is the save button.  Press this button to save the text in a rtf file.");
		this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnSave.Location = new System.Drawing.Point(16, 208);
		this.btnSave.Name = "btnSave";
		this.hpPlainHTML.SetShowHelp(this.btnSave, false);
		this.hpAdvancedCHM.SetShowHelp(this.btnSave, true);
		this.btnSave.TabIndex = 1;
		this.btnSave.Text = "Save";
		// 
		// rtbTextEntry
		// 
		this.rtbTextEntry.AccessibleDescription = "Test Text Entry form";
		this.rtbTextEntry.AccessibleName = "Test Text Entry form";
		this.hpAdvancedCHM.SetHelpString(this.rtbTextEntry, "This is the text entry area.  Use this area to enter text which can be saved to a" +
			"n rtf file.");
		this.rtbTextEntry.Location = new System.Drawing.Point(16, 104);
		this.rtbTextEntry.Name = "rtbTextEntry";
		this.hpAdvancedCHM.SetShowHelp(this.rtbTextEntry, true);
		this.hpPlainHTML.SetShowHelp(this.rtbTextEntry, false);
		this.rtbTextEntry.Size = new System.Drawing.Size(376, 96);
		this.rtbTextEntry.TabIndex = 0;
		this.rtbTextEntry.Text = "";
		// 
		// tpHTMLHelp
		// 
		this.tpHTMLHelp.Controls.Add(this.Label10);
		this.tpHTMLHelp.Controls.Add(this.btnLink3);
		this.tpHTMLHelp.Controls.Add(this.Label9);
		this.tpHTMLHelp.Controls.Add(this.btnLink2);
		this.tpHTMLHelp.Controls.Add(this.btnLink1);
		this.tpHTMLHelp.Location = new System.Drawing.Point(4, 22);
		this.tpHTMLHelp.Name = "tpHTMLHelp";
		this.hpAdvancedCHM.SetShowHelp(this.tpHTMLHelp, false);
		this.hpPlainHTML.SetShowHelp(this.tpHTMLHelp, false);
		this.tpHTMLHelp.Size = new System.Drawing.Size(410, 241);
		this.tpHTMLHelp.TabIndex = 2;
		this.tpHTMLHelp.Text = "HTML Help";
		// 
		// Label10
		// 
		this.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label10.Location = new System.Drawing.Point(16, 120);
		this.Label10.Name = "Label10";
		this.hpPlainHTML.SetShowHelp(this.Label10, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label10, false);
		this.Label10.Size = new System.Drawing.Size(376, 40);
		this.Label10.TabIndex = 5;
		this.Label10.Text = "Left clicking the button below with the question mark will bring up a basic HTML " +
			"page that could have information about this control and how it is used.";
		// 
		// btnLink3
		// 
		this.btnLink3.AccessibleDescription = "Link to basic HTML help file";
		this.btnLink3.AccessibleName = "Link to basic HTML help file";
		this.hpPlainHTML.SetHelpKeyword(this.btnLink3, "help.htm");
		this.btnLink3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnLink3.Location = new System.Drawing.Point(16, 168);
		this.btnLink3.Name = "btnLink3";
		this.hpPlainHTML.SetShowHelp(this.btnLink3, true);
		this.hpAdvancedCHM.SetShowHelp(this.btnLink3, false);
		this.btnLink3.Size = new System.Drawing.Size(376, 23);
		this.btnLink3.TabIndex = 4;
		this.btnLink3.Text = "Link to Basic &HTML help file";
		// 
		// Label9
		// 
		this.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label9.Location = new System.Drawing.Point(16, 16);
		this.Label9.Name = "Label9";
		this.hpPlainHTML.SetShowHelp(this.Label9, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label9, false);
		this.Label9.Size = new System.Drawing.Size(376, 40);
		this.Label9.TabIndex = 2;
		this.Label9.Text = "Left click the question mark on the top right of the window then left click one o" +
			"f the buttons to just to a help topic in the help file.";
		// 
		// btnLink2
		// 
		this.btnLink2.AccessibleDescription = "Link to compiling keyword indexes";
		this.btnLink2.AccessibleName = "Link to compiling keyword indexes";
		this.hpAdvancedCHM.SetHelpKeyword(this.btnLink2, "compiling keyword indexes");
		this.hpAdvancedCHM.SetHelpNavigator(this.btnLink2, System.Windows.Forms.HelpNavigator.KeywordIndex);
		this.btnLink2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnLink2.Location = new System.Drawing.Point(16, 88);
		this.btnLink2.Name = "btnLink2";
		this.hpPlainHTML.SetShowHelp(this.btnLink2, false);
		this.hpAdvancedCHM.SetShowHelp(this.btnLink2, true);
		this.btnLink2.Size = new System.Drawing.Size(376, 23);
		this.btnLink2.TabIndex = 1;
		this.btnLink2.Text = "Link To \"&compiling keyword indexes\"";
		// 
		// btnLink1
		// 
		this.btnLink1.AccessibleDescription = "Link to Compiling a help project";
		this.btnLink1.AccessibleName = "Link to Compiling a help project";
		this.hpAdvancedCHM.SetHelpKeyword(this.btnLink1, "about compiling a help project");
		this.hpAdvancedCHM.SetHelpNavigator(this.btnLink1, System.Windows.Forms.HelpNavigator.KeywordIndex);
		this.btnLink1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnLink1.Location = new System.Drawing.Point(16, 56);
		this.btnLink1.Name = "btnLink1";
		this.hpPlainHTML.SetShowHelp(this.btnLink1, false);
		this.hpAdvancedCHM.SetShowHelp(this.btnLink1, true);
		this.btnLink1.Size = new System.Drawing.Size(376, 24);
		this.btnLink1.TabIndex = 0;
		this.btnLink1.Text = "Link To \"&about compiling a help project\"";
		this.btnLink1.Click += new System.EventHandler(this.btnLink1_Click);
		// 
		// tpErrorHelp
		// 
		this.tpErrorHelp.Controls.Add(this.Label8);
		this.tpErrorHelp.Controls.Add(this.Label7);
		this.tpErrorHelp.Controls.Add(this.Label6);
		this.tpErrorHelp.Controls.Add(this.txtNumberValue);
		this.tpErrorHelp.Controls.Add(this.btnSubmit);
		this.tpErrorHelp.Controls.Add(this.txtTextValue);
		this.tpErrorHelp.Location = new System.Drawing.Point(4, 22);
		this.tpErrorHelp.Name = "tpErrorHelp";
		this.hpAdvancedCHM.SetShowHelp(this.tpErrorHelp, false);
		this.hpPlainHTML.SetShowHelp(this.tpErrorHelp, false);
		this.tpErrorHelp.Size = new System.Drawing.Size(410, 241);
		this.tpErrorHelp.TabIndex = 3;
		this.tpErrorHelp.Text = "Error Help";
		// 
		// Label8
		// 
		this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label8.Location = new System.Drawing.Point(16, 16);
		this.Label8.Name = "Label8";
		this.hpPlainHTML.SetShowHelp(this.Label8, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label8, false);
		this.Label8.Size = new System.Drawing.Size(368, 56);
		this.Label8.TabIndex = 1;
		this.Label8.Text = "Enter a non numeric value in the number here box and then click on the other text" +
			" box.  A red icon will appear next to the number here box indicating an error.  " +
			"Hover over the icon for a pop up message of the error.";
		// 
		// Label7
		// 
		this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label7.Location = new System.Drawing.Point(16, 120);
		this.Label7.Name = "Label7";
		this.hpPlainHTML.SetShowHelp(this.Label7, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label7, false);
		this.Label7.Size = new System.Drawing.Size(72, 16);
		this.Label7.TabIndex = 4;
		this.Label7.Text = "Number here";
		// 
		// Label6
		// 
		this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label6.Location = new System.Drawing.Point(16, 80);
		this.Label6.Name = "Label6";
		this.hpPlainHTML.SetShowHelp(this.Label6, false);
		this.hpAdvancedCHM.SetShowHelp(this.Label6, false);
		this.Label6.Size = new System.Drawing.Size(56, 16);
		this.Label6.TabIndex = 2;
		this.Label6.Text = "Text here";
		// 
		// txtNumberValue
		// 
		this.txtNumberValue.AccessibleDescription = "Number Input";
		this.txtNumberValue.AccessibleName = "Number Input";
		this.txtNumberValue.Location = new System.Drawing.Point(16, 136);
		this.txtNumberValue.Name = "txtNumberValue";
		this.hpAdvancedCHM.SetShowHelp(this.txtNumberValue, false);
		this.hpPlainHTML.SetShowHelp(this.txtNumberValue, false);
		this.txtNumberValue.Size = new System.Drawing.Size(64, 20);
		this.txtNumberValue.TabIndex = 5;
		this.txtNumberValue.Text = "";
		this.txtNumberValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumberValue_Validating);
		// 
		// btnSubmit
		// 
		this.btnSubmit.AccessibleDescription = "Submit Button for Form";
		this.btnSubmit.AccessibleName = "Submit Button";
		this.btnSubmit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnSubmit.Location = new System.Drawing.Point(16, 160);
		this.btnSubmit.Name = "btnSubmit";
		this.hpPlainHTML.SetShowHelp(this.btnSubmit, false);
		this.hpAdvancedCHM.SetShowHelp(this.btnSubmit, false);
		this.btnSubmit.TabIndex = 5;
		this.btnSubmit.Text = "&Submit";
		// 
		// txtTextValue
		// 
		this.txtTextValue.AccessibleDescription = "Text Input";
		this.txtTextValue.AccessibleName = "Text Input";
		this.txtTextValue.Location = new System.Drawing.Point(16, 96);
		this.txtTextValue.Name = "txtTextValue";
		this.hpAdvancedCHM.SetShowHelp(this.txtTextValue, false);
		this.hpPlainHTML.SetShowHelp(this.txtTextValue, false);
		this.txtTextValue.Size = new System.Drawing.Size(160, 20);
		this.txtTextValue.TabIndex = 3;
		this.txtTextValue.Text = "";
		// 
		// hpAdvancedCHM
		// 
		this.hpAdvancedCHM.HelpNamespace = "..\\htmlhelp.chm";
		// 
		// ErrorProvider1
		// 
		this.ErrorProvider1.ContainerControl = this;
		this.ErrorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrorProvider1.Icon")));
		// 
		// hpPlainHTML
		// 
		this.hpPlainHTML.HelpNamespace = "..\\..\\help.htm";
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(418, 267);
		this.Controls.Add(this.tcMain);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.HelpButton = true;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.MinimizeBox = false;
		this.Name = "frmMain";
		this.hpAdvancedCHM.SetShowHelp(this, false);
		this.hpPlainHTML.SetShowHelp(this, false);
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.tcMain.ResumeLayout(false);
		this.tpToolTip.ResumeLayout(false);
		this.tpPopUpHelp.ResumeLayout(false);
		this.tpHTMLHelp.ResumeLayout(false);
		this.tpErrorHelp.ResumeLayout(false);
		this.ResumeLayout(false);

	}

#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Standard Menu Code "
	// This code simply shows the About form.
	private void mnuAbout_Click(object sender, System.EventArgs e) 
	{
		// Open the About form in Dialog Mode
		frmAbout frm = new frmAbout();
		frm.ShowDialog(this);
		frm.Dispose();
	}

	// This code will close the form.
	private void mnuExit_Click(object sender, System.EventArgs e) 
	{
		// Close the current form
		this.Close();
	}
#endregion

    private void mnuContentsHelp_Click(object sender, System.EventArgs e) 
	{
        // Show the contents of the help file.
        Help.ShowHelp(this, hpAdvancedCHM.HelpNamespace);
    }

    private void mnuIndexHelp_Click(object sender, System.EventArgs e) 
	{
        // Show index of the help file.
        Help.ShowHelpIndex(this, hpAdvancedCHM.HelpNamespace);
    }

    private void mnuSearchHelp_Click(object sender, System.EventArgs e) 
	{
        // Show the search tab of the help file.
        Help.ShowHelp(this, hpAdvancedCHM.HelpNamespace, HelpNavigator.Find, "");
    }

    private void txtNumberValue_Validating(object sender, System.ComponentModel.CancelEventArgs e) 
	{
		if (!IsNumeric(txtNumberValue.Text))
		{
			// Activate the error provider to notify the user of a
			// problem.

			ErrorProvider1.SetError(txtNumberValue, "Not a numeric value.");
		}
		else 
		{
			// Clear the Error
			ErrorProvider1.SetError(txtNumberValue, string.Empty);
		}
    }

	// Simple version of VB's IsNumeric()
	private bool IsNumeric(string val)
	{
		try
		{
			double result = 0;
			return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
		}
		catch
		{
			return false;
		}
	}

	private void btnLink1_Click(object sender, System.EventArgs e)
	{
	
	}
}

