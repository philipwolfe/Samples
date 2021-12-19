//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.

//THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.

namespace Scribble
{
using System;
using System.Drawing;
using System.Drawing.Printing;

using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


/// <summary>
///    Summary description for Form1.
/// </summary>
public class MainWindow : System.Windows.Forms.Form
{
    /// <summary> 
    ///    Required designer variable
    /// </summary>
    /// 

	public static MainWindow parentWindow;

	private System.ComponentModel.Container components;
	private System.Windows.Forms.HelpProvider helpProvider1;
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ToolBarButton helpButton;
    private System.Windows.Forms.ToolBarButton printButton;
    private System.Windows.Forms.ToolBarButton previewButton;
    private System.Windows.Forms.ToolBarButton saveButton;
    private System.Windows.Forms.ToolBarButton openButton;
    private System.Windows.Forms.ToolBarButton newButton;
    private System.Windows.Forms.ToolBar toolBar1;
	private System.Drawing.Printing.PrintDocument printDoc;
		
	private System.Windows.Forms.MenuItem menuItemAbout;
	
	private System.Windows.Forms.MenuItem menuItem37;
	private System.Windows.Forms.MenuItem menuItemHelpTopics;
	private System.Windows.Forms.MenuItem menuItemTile;
	private System.Windows.Forms.MenuItem menuItemCascade;
	private System.Windows.Forms.MenuItem menuItemNewWindow;
	private System.Windows.Forms.MenuItem menuItemStatusbar;
	private System.Windows.Forms.MenuItem menuItemToolbar;
	private System.Windows.Forms.MenuItem menuItemPenWidths;
	private System.Windows.Forms.MenuItem menuItemThickLine;
	private System.Windows.Forms.MenuItem menuItemClearAll;
	private System.Windows.Forms.MenuItem menuItemExit;
	private System.Windows.Forms.MenuItem menuItem16;
	private System.Windows.Forms.MenuItem menuItemPreview;
	private System.Windows.Forms.MenuItem menuItemPrint;
	private System.Windows.Forms.MenuItem menuItem12;
	private System.Windows.Forms.MenuItem menuItemSaveAs;
	private System.Windows.Forms.MenuItem menuItemSave;
	private System.Windows.Forms.MenuItem menuItemClose;
	private System.Windows.Forms.MenuItem menuItemOpen;
	private System.Windows.Forms.MenuItem menuItemNew;
	private System.Windows.Forms.MenuItem menuItemHelp;
	private System.Windows.Forms.MenuItem menuItemWindow;
	private System.Windows.Forms.MenuItem menuItemView;
	private System.Windows.Forms.MenuItem menuItemPen;
	private System.Windows.Forms.MenuItem menuItemEdit;
	private System.Windows.Forms.MenuItem menuItemFile;
	private System.Windows.Forms.MdiClient mdiClient1;
	private System.Windows.Forms.MainMenu mainMenu1;
	public static int documentCount; // static var which keeps track of the document count
								// This is used in the display of the form views

	/// <summary>
    ///   Constructor
    /// </summary>
    public MainWindow()
    {        
		parentWindow = this;
		//
        // Required for Win Form Designer support
        //
        InitializeComponent();	
	    documentCount=0;    
		CreateDocument();
	 }

    /// <summary>
    ///    Clean up any resources being used
    /// </summary>
    public override void Dispose()
    {		
		if (components != null) 
		{
			components.Dispose();
		}
        base.Dispose();
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor
    /// </summary>
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainWindow));
		this.openButton = new System.Windows.Forms.ToolBarButton();
		this.printDoc = new System.Drawing.Printing.PrintDocument();
		this.menuItemOpen = new System.Windows.Forms.MenuItem();
		this.menuItemClose = new System.Windows.Forms.MenuItem();
		this.menuItemView = new System.Windows.Forms.MenuItem();
		this.menuItemToolbar = new System.Windows.Forms.MenuItem();
		this.menuItemStatusbar = new System.Windows.Forms.MenuItem();
		this.saveButton = new System.Windows.Forms.ToolBarButton();
		this.menuItemHelp = new System.Windows.Forms.MenuItem();
		this.menuItemHelpTopics = new System.Windows.Forms.MenuItem();
		this.menuItem37 = new System.Windows.Forms.MenuItem();
		this.menuItemAbout = new System.Windows.Forms.MenuItem();
		this.menuItemNew = new System.Windows.Forms.MenuItem();
		this.menuItemFile = new System.Windows.Forms.MenuItem();
		this.menuItemSave = new System.Windows.Forms.MenuItem();
		this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
		this.menuItem12 = new System.Windows.Forms.MenuItem();
		this.menuItemPrint = new System.Windows.Forms.MenuItem();
		this.menuItemPreview = new System.Windows.Forms.MenuItem();
		this.menuItem16 = new System.Windows.Forms.MenuItem();
		this.menuItemExit = new System.Windows.Forms.MenuItem();
		this.menuItemEdit = new System.Windows.Forms.MenuItem();
		this.menuItemClearAll = new System.Windows.Forms.MenuItem();
		this.menuItemPen = new System.Windows.Forms.MenuItem();
		this.menuItemThickLine = new System.Windows.Forms.MenuItem();
		this.menuItemPenWidths = new System.Windows.Forms.MenuItem();
		this.printButton = new System.Windows.Forms.ToolBarButton();
		this.toolBar1 = new System.Windows.Forms.ToolBar();
		this.newButton = new System.Windows.Forms.ToolBarButton();
		this.previewButton = new System.Windows.Forms.ToolBarButton();
		this.helpButton = new System.Windows.Forms.ToolBarButton();
		this.imageList1 = new System.Windows.Forms.ImageList();
		this.helpProvider1 = new System.Windows.Forms.HelpProvider();
		this.mainMenu1 = new System.Windows.Forms.MainMenu();
		this.menuItemWindow = new System.Windows.Forms.MenuItem();
		this.menuItemNewWindow = new System.Windows.Forms.MenuItem();
		this.menuItemCascade = new System.Windows.Forms.MenuItem();
		this.menuItemTile = new System.Windows.Forms.MenuItem();
		this.statusBar1 = new System.Windows.Forms.StatusBar();
		this.mdiClient1 = new System.Windows.Forms.MdiClient();
		this.SuspendLayout();
		// 
		// openButton
		// 
		this.openButton.ImageIndex = 1;
		this.openButton.ToolTipText = "Open";
		// 
		// printDoc
		// 
		this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ScribblePrintPage);
		// 
		// menuItemOpen
		// 
		this.menuItemOpen.Index = 1;
		this.menuItemOpen.Text = "Open...";
		this.menuItemOpen.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemClose
		// 
		this.menuItemClose.Index = 2;
		this.menuItemClose.Text = "Close";
		this.menuItemClose.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemView
		// 
		this.menuItemView.Index = 3;
		this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItemToolbar,
																				  this.menuItemStatusbar});
		this.menuItemView.Text = "View";
		// 
		// menuItemToolbar
		// 
		this.menuItemToolbar.Checked = true;
		this.menuItemToolbar.Index = 0;
		this.menuItemToolbar.Text = "Toolbar";
		this.menuItemToolbar.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemStatusbar
		// 
		this.menuItemStatusbar.Checked = true;
		this.menuItemStatusbar.Index = 1;
		this.menuItemStatusbar.Text = "Status Bar";
		this.menuItemStatusbar.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// saveButton
		// 
		this.saveButton.ImageIndex = 2;
		this.saveButton.ToolTipText = "Save";
		// 
		// menuItemHelp
		// 
		this.menuItemHelp.Index = 5;
		this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItemHelpTopics,
																				  this.menuItem37,
																				  this.menuItemAbout});
		this.menuItemHelp.Text = "Help";
		// 
		// menuItemHelpTopics
		// 
		this.menuItemHelpTopics.Index = 0;
		this.menuItemHelpTopics.Text = "Help Topics";
		this.menuItemHelpTopics.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItem37
		// 
		this.menuItem37.Index = 1;
		this.menuItem37.Text = "-";
		// 
		// menuItemAbout
		// 
		this.menuItemAbout.Index = 2;
		this.menuItemAbout.Text = "About Scribble";
		this.menuItemAbout.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemNew
		// 
		this.menuItemNew.Index = 0;
		this.menuItemNew.Text = "New";
		this.menuItemNew.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemFile
		// 
		this.menuItemFile.Index = 0;
		this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItemNew,
																				  this.menuItemOpen,
																				  this.menuItemClose,
																				  this.menuItemSave,
																				  this.menuItemSaveAs,
																				  this.menuItem12,
																				  this.menuItemPrint,
																				  this.menuItemPreview,
																				  this.menuItem16,
																				  this.menuItemExit});
		this.menuItemFile.Text = "File";
		// 
		// menuItemSave
		// 
		this.menuItemSave.Index = 3;
		this.menuItemSave.Text = "Save";
		this.menuItemSave.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemSaveAs
		// 
		this.menuItemSaveAs.Index = 4;
		this.menuItemSaveAs.Text = "Save As...";
		this.menuItemSaveAs.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItem12
		// 
		this.menuItem12.Index = 5;
		this.menuItem12.Text = "-";
		// 
		// menuItemPrint
		// 
		this.menuItemPrint.Index = 6;
		this.menuItemPrint.Text = "Print...";
		this.menuItemPrint.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemPreview
		// 
		this.menuItemPreview.Index = 7;
		this.menuItemPreview.Text = "Print Preview";
		this.menuItemPreview.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItem16
		// 
		this.menuItem16.Index = 8;
		this.menuItem16.Text = "-";
		// 
		// menuItemExit
		// 
		this.menuItemExit.Index = 9;
		this.menuItemExit.Text = "Exit";
		this.menuItemExit.Click += new System.EventHandler(this.MenuItemHandler);
	
		// 
		// menuItemEdit
		// 
		this.menuItemEdit.Index = 0;
		this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItemClearAll,this.menuItem16 });
		this.menuItemEdit.Text = "Edit";		
		// 
		// menuItemClearAll
		// 
		this.menuItemClearAll.Index = 1;
		this.menuItemClearAll.Text = "Clear All";
		this.menuItemClearAll.Click += new System.EventHandler(this.MenuItemHandler);
	// 
		// menuItemPen
		// 
		this.menuItemPen.Index = 2;
		this.menuItemPen.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItemThickLine,
																				  this.menuItemPenWidths});
		this.menuItemPen.Text = "Pen";
		// 
		// menuItemThickLine
		// 
		this.menuItemThickLine.Index = 0;
		this.menuItemThickLine.Text = "Thick Line";
		this.menuItemThickLine.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemPenWidths
		// 
		this.menuItemPenWidths.Index = 1;
		this.menuItemPenWidths.Text = "Pen Widths...";
		this.menuItemPenWidths.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// printButton
		// 
		this.printButton.ImageIndex = 4;
		this.printButton.ToolTipText = "Print";
		// 
		// toolBar1
		// 
		this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {this.newButton,
																					this.openButton,
																					this.saveButton,
																					this.previewButton,
																					this.printButton,
																					this.helpButton});
		this.toolBar1.DropDownArrows = true;
		this.toolBar1.ImageList = this.imageList1;
		this.toolBar1.Name = "toolBar1";
		this.toolBar1.ShowToolTips = true;
		this.toolBar1.Size = new System.Drawing.Size(586, 22);
		this.toolBar1.TabIndex = 1;
		this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
		// 
		// newButton
		// 
		this.newButton.ImageIndex = 0;
		this.newButton.ToolTipText = "New";
		// 
		// previewButton
		// 
		this.previewButton.ImageIndex = 3;
		this.previewButton.ToolTipText = "Print Preview";
		// 
		// helpButton
		// 
		this.helpButton.ImageIndex = 5;
		this.helpButton.ToolTipText = "Help";
		// 
		// imageList1
		// 
		this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
		this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
		this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		// 
		// helpProvider1
		// 
		this.helpProvider1.HelpNamespace = "..\\..\\Help\\scribble.chm";
		// 
		// mainMenu1
		// 
		this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItemFile,
																				  this.menuItemEdit,
																				  this.menuItemPen,
																				  this.menuItemView,
																				  this.menuItemWindow,
																				  this.menuItemHelp});
		// 
		// menuItemWindow
		// 
		this.menuItemWindow.Index = 4;
		this.menuItemWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItemNewWindow,
																				  this.menuItemCascade,
																				  this.menuItemTile});
		this.menuItemWindow.Text = "Window";
		// 
		// menuItemNewWindow
		// 
		this.menuItemNewWindow.Index = 0;
		this.menuItemNewWindow.Text = "New Window";
		this.menuItemNewWindow.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemCascade
		// 
		this.menuItemCascade.Index = 1;
		this.menuItemCascade.Text = "Cascade";
		this.menuItemCascade.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// menuItemTile
		// 
		this.menuItemTile.Index = 2;
		this.menuItemTile.Text = "Tile";
		this.menuItemTile.Click += new System.EventHandler(this.MenuItemHandler);
		// 
		// statusBar1
		// 
		this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
		this.statusBar1.Font = new System.Drawing.Font("Arial", 8F);
		this.statusBar1.Location = new System.Drawing.Point(0, 319);
		this.statusBar1.Name = "statusBar1";
		this.statusBar1.Size = new System.Drawing.Size(586, 16);
		this.statusBar1.TabIndex = 2;
		this.statusBar1.Text = "For Help,  press F1";
		// 
		// mdiClient1
		// 
		this.mdiClient1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.mdiClient1.Name = "mdiClient1";
		this.mdiClient1.TabIndex = 0;
		// 
		// MainWindow
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(588, 400);
		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.mdiClient1,this.toolBar1,this.statusBar1 });
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.IsMdiContainer = true;
		this.Menu = this.mainMenu1;
		this.Name = "MainWindow";
		this.helpProvider1.SetShowHelp(this, true);
		this.Text = "Scribble";
		this.Closing += new System.ComponentModel.CancelEventHandler(this.ClosingMainAppHander);
		this.ResumeLayout(false);

	}

	//Handle the Menu Item clicks
	private void MenuItemHandler(object sender, System.EventArgs e)
	{
		if(sender==menuItemNew)	
		{
			New();
		}
		else if(sender==menuItemOpen)
		{
			Open();
		}
		else if(sender==menuItemSave)
		{
			Save();
		}
		else if(sender == menuItemPreview)
		{
			PrintPreview();
		}
		else if(sender == menuItemPrint)
		{
			Print();
		}
		else if(sender == menuItemAbout)
		{
			AboutHelp();
		}
		else if(sender == menuItemExit)
		{
			Exit();
		}
		else if(sender == menuItemClose)
		{
			CloseView();
		}
		else if(sender == menuItemTile)
		{
			Tile();
		}
		else if(sender == menuItemCascade)
		{
			Cascade();
		}
		else if(sender == menuItemClearAll)
		{
			Clear();
		}
		else if(sender == menuItemSaveAs)
		{
			Save();
		}
		else if(sender == menuItemNewWindow)
		{
			NewWindow();
		}
		else if(sender == menuItemPenWidths)
		{
			PenWidthsDlg();
		}
		else if(sender == menuItemThickLine)
		{
			ThickPen();			
		}
		else if(sender == menuItemHelpTopics)
		{
			ShowHelpTopics();			
		}
		else if(sender == menuItemToolbar)
		{
			toolBar1.Visible  = menuItemToolbar.Checked  = !toolBar1.Visible ;
		}
		else if(sender == menuItemStatusbar)
		{
			statusBar1.Visible = menuItemStatusbar.Checked = !statusBar1.Visible;			
		}
	}
	//Handle the Toolbar button clicks
    private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
	{
		if(e.Button == newButton)	
		{
			New();
		}
		else if(e.Button==openButton)
		{
			Open();
		}
		else if(e.Button==saveButton)
		{
			Save();
		}
		else if(e.Button == previewButton)
		{
			PrintPreview();
		}
		else if(e.Button == printButton)
		{
			Print();
		}
		else if(e.Button == helpButton)
		{
			ShowHelpTopics();
		}
	}
	//About Help
	private void AboutHelp()
	{
		MessageBox.Show("Scribble Version 1.0", "About Scribble");
	}

	//Help Topics
	private void ShowHelpTopics()
	{		
		Help.ShowHelp(this,"..\\..\\help\\scribble.chm");
	}
	
	//Print
	private void Print()
	{
		try 
		{			
			printDoc.Print();
		} 
		catch(Exception e)
		{
			MessageBox.Show(e.ToString());
		}
        
	}

	//PrintPage event handler
	private void ScribblePrintPage(object sender,PrintPageEventArgs ev)
	{
		try{
		ScribbleView activeView = (ScribbleView)this.ActiveMdiChild;
		ScribbleDoc activeDoc = activeView.GetDocument();		

		for(int i=0; i < activeDoc.strokeList.Count; i++)
		{
			Stroke st = (Stroke)activeDoc.strokeList[i];
			st.DrawStroke(ev.Graphics) ;
		}
			ev.HasMorePages = false;
	}

		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}


	//PrintPreview
	private void PrintPreview()
	{
		try
		{		
			PrintPreviewDialog prevDlg = new PrintPreviewDialog();
			prevDlg.Document = printDoc;
			prevDlg.Size = new System.Drawing.Size(600, 329);
			prevDlg.ShowDialog();
		}
		catch(Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
		
	}
	//Exit
	private void Exit()
	{
		Form[] childForm = this.MdiChildren ;
		//Make sure to ask for saving the doc before exiting the app
		for(int i=0; i < childForm.Length ; i++)
			childForm[i].Close();

		Application.Exit();
		
	}
	//Close the View
	private  void CloseView()
	{
		ScribbleView activeView = (ScribbleView)this.ActiveMdiChild;
		activeView.Close();		
	}
	//Tile
	private void Tile()
	{
		this.LayoutMdi(MdiLayout.TileHorizontal);
		
	}
	//Cascade
	private void Cascade()
	{
		this.LayoutMdi(MdiLayout.Cascade);
		
	}
	//Clear the contents of the active document
	private void Clear()
	{
		ScribbleView activeView = (ScribbleView)this.ActiveMdiChild;
		if(activeView != null)
		{
			ScribbleDoc activeDoc = activeView.GetDocument();
			activeDoc.DeleteContents();
		}
	}
	
//Open an existing document
	private void Open()
	{
		OpenFileDialog openDlg = new OpenFileDialog();
		openDlg.Filter  = "Scribble Files (*.scb)|*.scb|All Files (*.*)|*.*";
		openDlg.FileName = "" ;
		openDlg.DefaultExt = ".scb";
		openDlg.CheckFileExists = true;
		openDlg.CheckPathExists = true;
		
		DialogResult res = openDlg.ShowDialog ();
		
		if(res == DialogResult.OK)
		{
			if( !(openDlg.FileName).EndsWith(".scb") && !(openDlg.FileName).EndsWith(".SCB")) 
				MessageBox.Show("Unexpected file format","Scribble",MessageBoxButtons.OK );
			else
			{
				if(this.ActiveMdiChild == null)			
					EnableItems();		
			
				ScribbleDoc newDoc = CreateDocument();
				newDoc.OpenDocument(openDlg.FileName);
			}
		}		
		
	}

	//Save the document
	private void Save()
	{
		ScribbleView selectedView = (ScribbleView)this.ActiveMdiChild ;
		SaveFileDialog saveDlg = new SaveFileDialog();
		saveDlg.Filter = "Scribble Files (*.scb)|*.scb|All Files (*.*)|*.*";
		saveDlg.DefaultExt = ".scb";
		saveDlg.FileName = "Scribb1.scb";
		DialogResult res = saveDlg.ShowDialog ();
		
		if(res == DialogResult.OK)
			selectedView.GetDocument().SaveDocument(saveDlg.FileName);		

	}

	//Open new document
	private void New()
	{		
		//If this is the first child window, enable the Menu and Toolbar items
		if(this.ActiveMdiChild == null)
			EnableItems();
		CreateDocument();						
	}
    
	//NewWindow
	private void NewWindow()
	{
		ScribbleView activeView = (ScribbleView)this.ActiveMdiChild;
		ScribbleView newView = new ScribbleView(activeView.GetDocument(),parentWindow);
		newView.GetDocument().viewList.Add(newView);
		newView.Show();	
	}

	//Creates a new document
	private ScribbleDoc CreateDocument()
	{
		ScribbleDoc newDoc = new ScribbleDoc (parentWindow);
		documentCount++;
		return newDoc;
	}

	private void PenWidthsDlg()
	{
		Form f = new Form();

		//Get the document of active view
		ScribbleView activeView = (ScribbleView)this.ActiveMdiChild;
		ScribbleDoc activeDoc = activeView.GetDocument();

		f.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		f.Text = "Pen Widths";
		
		f.ClientSize = new System.Drawing.Size(352, 125);
		
		Button button1 = new Button();
		button1.Location = new System.Drawing.Point(264, 20);
		button1.Size = new System.Drawing.Size(75, 23);
		button1.TabIndex = 1;
		button1.Text = "OK";
		button1.DialogResult = System.Windows.Forms.DialogResult.OK ;//Make this "OK" button

		Button button2 = new Button();
		button2.Location = new System.Drawing.Point(264, 52);
		button2.Size = new System.Drawing.Size(75, 23);
		button2.TabIndex = 6;
		button2.Text = "Cancel";
		
		TextBox textBox1 = new TextBox();		
		textBox1.Location = new System.Drawing.Point(120, 36);
		textBox1.Text = activeDoc.thinWidth.ToString();
		textBox1.TabIndex = 1;
		textBox1.Size = new System.Drawing.Size(64, 20);

		TextBox textBox2 = new TextBox();		
		textBox2.Location = new System.Drawing.Point(120, 76);
		textBox2.Text = activeDoc.thickWidth.ToString();
		textBox2.TabIndex = 2;
		textBox2.Size = new System.Drawing.Size(64, 20);
		
		
		Label label1 = new Label();
		label1.Location = new System.Drawing.Point(16, 36);
		label1.Text = "Thin Pen Width:";
		label1.Size = new System.Drawing.Size(88, 16);
		label1.TabIndex = 3;
		
		Label label2 = new Label();
		label2.Location = new System.Drawing.Point(16, 76);
		label2.Text = "Thick Pen Width:";
		label2.Size = new System.Drawing.Size(88, 16);
		label2.TabIndex = 4;		
		

		f.FormBorderStyle = FormBorderStyle.FixedDialog;
		// Set the MaximizeBox to false to remove the maximize box.
		f.MaximizeBox = false;
		// Set the MinimizeBox to false to remove the minimize box.
		f.MinimizeBox = false;
		// Set the accept button of the form to button1.
		f.AcceptButton = button1;
		// Set the cancel button of the form to button2.
		f.CancelButton = button2;
		
		f.StartPosition = FormStartPosition.CenterScreen;		
		
		f.Controls.Add(button1);
		f.Controls.Add(button2);
		f.Controls.Add(label1);
		f.Controls.Add(label2);
		f.Controls.Add(textBox1);  
		f.Controls.Add(textBox2);			
			
		DialogResult res = f.ShowDialog();
				
		if(res == System.Windows.Forms.DialogResult.OK )
		{			
			activeDoc.thinWidth = UInt32.Parse(textBox1.Text);
			activeDoc.thickWidth = UInt32.Parse(textBox2.Text);
			activeDoc.ReplacePen();
			f.Close();
		}			
	}

	private void ThickPen()
	{
		ScribbleView activeView = (ScribbleView)this.ActiveMdiChild;
		ScribbleDoc activeDoc = activeView.GetDocument();
		activeDoc.thickPen = !activeDoc.thickPen;
		activeDoc.ReplacePen();
		this.menuItemThickLine.Checked = activeDoc.thickPen;
	}

	//Disable the menu and toolbar items when there is no active child form
	public void DisableItems()
	{
		this.menuItemEdit.Visible=false;
		this.menuItemPen.Visible=false;
		this.menuItemWindow.Visible=false;
		this.menuItemClose.Visible=false;
		this.menuItemSave.Visible=false;
		this.menuItemSaveAs.Visible=false;
		this.menuItemPrint.Visible=false;
		this.menuItemPreview.Visible=false;
		this.saveButton.Enabled= false;
		this.previewButton.Enabled=false;
		this.printButton.Enabled=false;
					
	}

	//Enable the menu and toolbar items when the first child form is created
	public void EnableItems()
	{
		this.menuItemEdit.Visible=true;
		this.menuItemPen.Visible=true;
		this.menuItemWindow.Visible=true;
		this.menuItemClose.Visible=true;
		this.menuItemSave.Visible=true;
		this.menuItemSaveAs.Visible=true;
		this.menuItemPrint.Visible=true;
		this.menuItemPreview.Visible=true;
		this.saveButton.Enabled= true;
		this.previewButton.Enabled=true;
		this.printButton.Enabled=true;
					
	}

	//App closing handler
	public void ClosingMainAppHander(Object sender,CancelEventArgs e)
	{
		this.Exit();		
	}
	/*
     * The main entry point for the application.
     *
     */
    public static void Main(string[] args) 
    {
        Application.Run(new MainWindow());
    }
}
}
