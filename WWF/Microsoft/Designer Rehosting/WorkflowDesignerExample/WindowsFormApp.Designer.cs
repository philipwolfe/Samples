//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

namespace WorkflowDesignerExample
{
    partial class WindowsFormApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsFormApp));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenu = new System.Windows.Forms.MenuItem();
            this.NewMenuItem = new System.Windows.Forms.MenuItem();
            this.OpenMenuItem = new System.Windows.Forms.MenuItem();
            this.SaveMenuItem = new System.Windows.Forms.MenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.PageSetupMenuItem = new System.Windows.Forms.MenuItem();
            this.PrintPreviewMenuItem = new System.Windows.Forms.MenuItem();
            this.PrintMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.ExitMenuItem = new System.Windows.Forms.MenuItem();
            this.EditMenuItem = new System.Windows.Forms.MenuItem();
            this.CutMenuItem = new System.Windows.Forms.MenuItem();
            this.CopyMenuItem = new System.Windows.Forms.MenuItem();
            this.PasteMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.MenuItem();
            this.worklfowMenu = new System.Windows.Forms.MenuItem();
            this.expandMenuItem = new System.Windows.Forms.MenuItem();
            this.collapseMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.zoomLevelsMenu = new System.Windows.Forms.MenuItem();
            this.zoom400MenuItem = new System.Windows.Forms.MenuItem();
            this.zoom300MenuItem = new System.Windows.Forms.MenuItem();
            this.zoom200MenuItem = new System.Windows.Forms.MenuItem();
            this.zoom150MenuItem = new System.Windows.Forms.MenuItem();
            this.zoom100MenuItem = new System.Windows.Forms.MenuItem();
            this.zoom75MenuItem = new System.Windows.Forms.MenuItem();
            this.zoom50MenuItem = new System.Windows.Forms.MenuItem();
            this.zoom10MenuItem = new System.Windows.Forms.MenuItem();
            this.zoomShowAllMenuItem = new System.Windows.Forms.MenuItem();
            this.NavigationToolsMenu = new System.Windows.Forms.MenuItem();
            this.zoomInNavigationMenuItem = new System.Windows.Forms.MenuItem();
            this.zoomOutNavigationMenuItem = new System.Windows.Forms.MenuItem();
            this.panNavigationMenuItem = new System.Windows.Forms.MenuItem();
            this.defaultNavigationMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.compileWorkflow = new System.Windows.Forms.MenuItem();
            this.toolBarImages = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomInToolButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOut = new System.Windows.Forms.ToolStripButton();
            this.separatorToolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomLevelToolStripButton = new System.Windows.Forms.ToolStripComboBox();
            this.separatorToolStripButton = new System.Windows.Forms.ToolStripSeparator();
            this.expandToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.collapseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.separatorToolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.topSplitContainer = new System.Windows.Forms.SplitContainer();
            this.toolBoxSplitContainer = new System.Windows.Forms.SplitContainer();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.workflowDesignerControl1 = new WorkflowDesignerControl.WorkflowDesignerControl();
            this.toolStrip1.SuspendLayout();
            this.topSplitContainer.Panel2.SuspendLayout();
            this.topSplitContainer.SuspendLayout();
            this.toolBoxSplitContainer.Panel2.SuspendLayout();
            this.toolBoxSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenu,
            this.EditMenuItem,
            this.worklfowMenu});
            // 
            // FileMenu
            // 
            this.FileMenu.Index = 0;
            this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.NewMenuItem,
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.SaveAsMenuItem,
            this.menuItem1,
            this.PageSetupMenuItem,
            this.PrintPreviewMenuItem,
            this.PrintMenuItem,
            this.menuItem3,
            this.ExitMenuItem});
            this.FileMenu.Text = "&File";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Index = 0;
            this.NewMenuItem.Text = "&New";
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Index = 1;
            this.OpenMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.OpenMenuItem.Text = "&Open";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Index = 2;
            this.SaveMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.SaveMenuItem.Text = "&Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.Index = 3;
            this.SaveAsMenuItem.Text = "Save &As";
            this.SaveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
            // 
            // PageSetupMenuItem
            // 
            this.PageSetupMenuItem.Index = 5;
            this.PageSetupMenuItem.Text = "Page Set&up";
            this.PageSetupMenuItem.Click += new System.EventHandler(this.PageSetupMenuItem_Click);
            // 
            // PrintPreviewMenuItem
            // 
            this.PrintPreviewMenuItem.Index = 6;
            this.PrintPreviewMenuItem.Text = "Print Pre&view";
            this.PrintPreviewMenuItem.Click += new System.EventHandler(this.PrintPreviewMenuItem_Click);
            // 
            // PrintMenuItem
            // 
            this.PrintMenuItem.Index = 7;
            this.PrintMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.PrintMenuItem.Text = "&Print";
            this.PrintMenuItem.Click += new System.EventHandler(this.PrintMenuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 8;
            this.menuItem3.Text = "-";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Index = 9;
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.Index = 1;
            this.EditMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.CutMenuItem,
            this.CopyMenuItem,
            this.PasteMenuItem,
            this.menuItem2,
            this.DeleteMenuItem});
            this.EditMenuItem.Text = "&Edit";
            // 
            // CutMenuItem
            // 
            this.CutMenuItem.Index = 0;
            this.CutMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.CutMenuItem.Text = "Cu&t";
            this.CutMenuItem.Click += new System.EventHandler(this.CutMenuItem_Click);
            // 
            // CopyMenuItem
            // 
            this.CopyMenuItem.Index = 1;
            this.CopyMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.CopyMenuItem.Text = "&Copy";
            this.CopyMenuItem.Click += new System.EventHandler(this.CopyMenuItem_Click);
            // 
            // PasteMenuItem
            // 
            this.PasteMenuItem.Index = 2;
            this.PasteMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.PasteMenuItem.Text = "&Paste";
            this.PasteMenuItem.Click += new System.EventHandler(this.PasteMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "-";
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Index = 4;
            this.DeleteMenuItem.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.DeleteMenuItem.Text = "&Delete";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // worklfowMenu
            // 
            this.worklfowMenu.Index = 2;
            this.worklfowMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.expandMenuItem,
            this.collapseMenuItem,
            this.menuItem9,
            this.zoomLevelsMenu,
            this.NavigationToolsMenu,
            this.menuItem4,
            this.compileWorkflow});
            this.worklfowMenu.Text = "&Workflow";
            // 
            // expandMenuItem
            // 
            this.expandMenuItem.Index = 0;
            this.expandMenuItem.Text = "&Expand";
            this.expandMenuItem.Click += new System.EventHandler(this.expandMenuItem_Click);
            // 
            // collapseMenuItem
            // 
            this.collapseMenuItem.Index = 1;
            this.collapseMenuItem.Text = "&Collapse";
            this.collapseMenuItem.Click += new System.EventHandler(this.collapseMenuItem_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "-";
            // 
            // zoomLevelsMenu
            // 
            this.zoomLevelsMenu.Index = 3;
            this.zoomLevelsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.zoom400MenuItem,
            this.zoom300MenuItem,
            this.zoom200MenuItem,
            this.zoom150MenuItem,
            this.zoom100MenuItem,
            this.zoom75MenuItem,
            this.zoom50MenuItem,
            this.zoom10MenuItem,
            this.zoomShowAllMenuItem});
            this.zoomLevelsMenu.Text = "&Zoom Levels";
            // 
            // zoom400MenuItem
            // 
            this.zoom400MenuItem.Index = 0;
            this.zoom400MenuItem.Text = "&400%";
            this.zoom400MenuItem.Click += new System.EventHandler(this.zoom400MenuItem_Click);
            // 
            // zoom300MenuItem
            // 
            this.zoom300MenuItem.Index = 1;
            this.zoom300MenuItem.Text = "&300%";
            this.zoom300MenuItem.Click += new System.EventHandler(this.zoom300MenuItem_Click);
            // 
            // zoom200MenuItem
            // 
            this.zoom200MenuItem.Index = 2;
            this.zoom200MenuItem.Text = "&200%";
            this.zoom200MenuItem.Click += new System.EventHandler(this.zoom200MenuItem_Click);
            // 
            // zoom150MenuItem
            // 
            this.zoom150MenuItem.Index = 3;
            this.zoom150MenuItem.Text = "&150%";
            this.zoom150MenuItem.Click += new System.EventHandler(this.zoom150MenuItem_Click);
            // 
            // zoom100MenuItem
            // 
            this.zoom100MenuItem.Index = 4;
            this.zoom100MenuItem.Text = "1&00%";
            this.zoom100MenuItem.Click += new System.EventHandler(this.zoom100MenuItem_Click);
            // 
            // zoom75MenuItem
            // 
            this.zoom75MenuItem.Index = 5;
            this.zoom75MenuItem.Text = "&75%";
            this.zoom75MenuItem.Click += new System.EventHandler(this.zoom75MenuItem_Click);
            // 
            // zoom50MenuItem
            // 
            this.zoom50MenuItem.Index = 6;
            this.zoom50MenuItem.Text = "&50%";
            this.zoom50MenuItem.Click += new System.EventHandler(this.zoom50MenuItem_Click);
            // 
            // zoom10MenuItem
            // 
            this.zoom10MenuItem.Index = 7;
            this.zoom10MenuItem.Text = "10%";
            this.zoom10MenuItem.Click += new System.EventHandler(this.zoom10MenuItem_Click);
            // 
            // zoomShowAllMenuItem
            // 
            this.zoomShowAllMenuItem.Index = 8;
            this.zoomShowAllMenuItem.Text = "Show &All";
            this.zoomShowAllMenuItem.Click += new System.EventHandler(this.zoomShowAllMenuItem_Click);
            // 
            // NavigationToolsMenu
            // 
            this.NavigationToolsMenu.Index = 4;
            this.NavigationToolsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.zoomInNavigationMenuItem,
            this.zoomOutNavigationMenuItem,
            this.panNavigationMenuItem,
            this.defaultNavigationMenuItem});
            this.NavigationToolsMenu.Text = "Navigation &Tools";
            // 
            // zoomInNavigationMenuItem
            // 
            this.zoomInNavigationMenuItem.Index = 0;
            this.zoomInNavigationMenuItem.Text = "Zoom In";
            this.zoomInNavigationMenuItem.Click += new System.EventHandler(this.zoomInNavigationMenuItem_Click);
            // 
            // zoomOutNavigationMenuItem
            // 
            this.zoomOutNavigationMenuItem.Index = 1;
            this.zoomOutNavigationMenuItem.Text = "Zoom Out";
            this.zoomOutNavigationMenuItem.Click += new System.EventHandler(this.zoomOutNavigationMenuItem_Click);
            // 
            // panNavigationMenuItem
            // 
            this.panNavigationMenuItem.Index = 2;
            this.panNavigationMenuItem.Text = "Pan";
            this.panNavigationMenuItem.Click += new System.EventHandler(this.panNavigationMenuItem_Click);
            // 
            // defaultNavigationMenuItem
            // 
            this.defaultNavigationMenuItem.Index = 3;
            this.defaultNavigationMenuItem.Text = "Default";
            this.defaultNavigationMenuItem.Click += new System.EventHandler(this.defaultNavigationMenuItem_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            this.menuItem4.Text = "-";
            // 
            // compileWorkflow
            // 
            this.compileWorkflow.Index = 6;
            this.compileWorkflow.Text = "Compile Workflow";
            this.compileWorkflow.Click += new System.EventHandler(this.CompileWorkflow);
            // 
            // toolBarImages
            // 
            this.toolBarImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.toolBarImages.ImageSize = new System.Drawing.Size(16, 16);
            this.toolBarImages.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageList = this.toolBarImages;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.zoomInToolButton,
            this.zoomOut,
            this.separatorToolStripButton2,
            this.zoomLevelToolStripButton,
            this.separatorToolStripButton,
            this.expandToolStripButton,
            this.collapseToolStripButton,
            this.separatorToolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(850, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Click += new System.EventHandler(this.PrintMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton.Text = "Cu&t";
            this.cutToolStripButton.Click += new System.EventHandler(this.CutMenuItem_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.CopyMenuItem_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Lime;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.PasteMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomInToolButton
            // 
            this.zoomInToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInToolButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInToolButton.Image")));
            this.zoomInToolButton.Name = "zoomInToolButton";
            this.zoomInToolButton.Size = new System.Drawing.Size(23, 22);
            this.zoomInToolButton.Text = "Zoom In";
            this.zoomInToolButton.Click += new System.EventHandler(this.zoomInNavigationMenuItem_Click);
            // 
            // zoomOut
            // 
            this.zoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOut.Image = ((System.Drawing.Image)(resources.GetObject("zoomOut.Image")));
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(23, 22);
            this.zoomOut.Text = "Zoom Out";
            this.zoomOut.Click += new System.EventHandler(this.zoomOutNavigationMenuItem_Click);
            // 
            // separatorToolStripButton2
            // 
            this.separatorToolStripButton2.Name = "separatorToolStripButton2";
            this.separatorToolStripButton2.Size = new System.Drawing.Size(6, 25);
            // 
            // zoomLevelToolStripButton
            // 
            this.zoomLevelToolStripButton.Items.AddRange(new object[] {
            "400%",
            "300%",
            "200%",
            "150%",
            "100%",
            "75%",
            "50%"});
            this.zoomLevelToolStripButton.Name = "zoomLevelToolStripButton";
            this.zoomLevelToolStripButton.Size = new System.Drawing.Size(121, 25);
            this.zoomLevelToolStripButton.Leave += new System.EventHandler(this.zoomLevelToolStripButton_Leave);
            this.zoomLevelToolStripButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zoomLevelToolStripButton_KeyDown);
            this.zoomLevelToolStripButton.SelectedIndexChanged += new System.EventHandler(this.zoomLevelToolStripButton_SelectedIndexChanged);
            this.zoomLevelToolStripButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.zoomLevelToolStripButton_KeyUp);
            // 
            // separatorToolStripButton
            // 
            this.separatorToolStripButton.Name = "separatorToolStripButton";
            this.separatorToolStripButton.Size = new System.Drawing.Size(6, 25);
            // 
            // expandToolStripButton
            // 
            this.expandToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.expandToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("expandToolStripButton.Image")));
            this.expandToolStripButton.Name = "expandToolStripButton";
            this.expandToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.expandToolStripButton.Text = "Expand";
            this.expandToolStripButton.Click += new System.EventHandler(this.expandMenuItem_Click);
            // 
            // collapseToolStripButton
            // 
            this.collapseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.collapseToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("collapseToolStripButton.Image")));
            this.collapseToolStripButton.Name = "collapseToolStripButton";
            this.collapseToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.collapseToolStripButton.Text = "Collapse";
            this.collapseToolStripButton.Click += new System.EventHandler(this.collapseMenuItem_Click);
            // 
            // separatorToolStripButton1
            // 
            this.separatorToolStripButton1.Name = "separatorToolStripButton1";
            this.separatorToolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // topSplitContainer
            // 
            this.topSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.topSplitContainer.Name = "topSplitContainer";
            // 
            // topSplitContainer.Panel2
            // 
            this.topSplitContainer.Panel2.Controls.Add(this.toolBoxSplitContainer);
            this.topSplitContainer.Size = new System.Drawing.Size(829, 572);
            this.topSplitContainer.SplitterDistance = 584;
            this.topSplitContainer.TabIndex = 1;
            this.topSplitContainer.Text = "splitContainer1";
            // 
            // toolBoxSplitContainer
            // 
            this.toolBoxSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolBoxSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.toolBoxSplitContainer.Name = "toolBoxSplitContainer";
            this.toolBoxSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // toolBoxSplitContainer.Panel2
            // 
            this.toolBoxSplitContainer.Panel2.Controls.Add(this.propertyGrid);
            this.toolBoxSplitContainer.Size = new System.Drawing.Size(241, 572);
            this.toolBoxSplitContainer.SplitterDistance = 301;
            this.toolBoxSplitContainer.TabIndex = 0;
            this.toolBoxSplitContainer.Text = "splitContainer1";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(241, 267);
            this.propertyGrid.TabIndex = 1;
            // 
            // workflowDesignerControl1
            // 
            this.workflowDesignerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workflowDesignerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workflowDesignerControl1.Location = new System.Drawing.Point(0, 25);
            this.workflowDesignerControl1.Name = "workflowDesignerControl1";
            this.workflowDesignerControl1.NameSpace = "foo";
            this.workflowDesignerControl1.Size = new System.Drawing.Size(850, 536);
            this.workflowDesignerControl1.TabIndex = 0;
            this.workflowDesignerControl1.TypeName = "Workflow1";
            // 
            // WindowsFormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 561);
            this.Controls.Add(this.workflowDesignerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Menu = this.mainMenu1;
            this.Name = "WindowsFormApp";
            this.Text = "Workflow Designer Rehosting Example";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.topSplitContainer.Panel2.ResumeLayout(false);
            this.topSplitContainer.ResumeLayout(false);
            this.toolBoxSplitContainer.Panel2.ResumeLayout(false);
            this.toolBoxSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WorkflowDesignerControl.WorkflowDesignerControl workflowDesignerControl1;
        private System.Windows.Forms.ImageList toolBarImages;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem FileMenu;
        private System.Windows.Forms.MenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripButton zoomInToolButton;
        private System.Windows.Forms.ToolStripButton zoomOut;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator separatorToolStripButton;
        private System.Windows.Forms.ToolStripButton expandToolStripButton;
        private System.Windows.Forms.ToolStripButton collapseToolStripButton;
        private System.Windows.Forms.ToolStripSeparator separatorToolStripButton1;
        private System.Windows.Forms.MenuItem SaveMenuItem;
        private System.Windows.Forms.MenuItem SaveAsMenuItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem PrintPreviewMenuItem;
        private System.Windows.Forms.MenuItem PageSetupMenuItem;
        private System.Windows.Forms.MenuItem PrintMenuItem;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem ExitMenuItem;
        private System.Windows.Forms.MenuItem EditMenuItem;
        private System.Windows.Forms.MenuItem CutMenuItem;
        private System.Windows.Forms.MenuItem CopyMenuItem;
        private System.Windows.Forms.MenuItem PasteMenuItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem DeleteMenuItem;
        private System.Windows.Forms.MenuItem NewMenuItem;
        private System.Windows.Forms.SplitContainer topSplitContainer;
        private System.Windows.Forms.SplitContainer toolBoxSplitContainer;
        private System.Windows.Forms.MenuItem worklfowMenu;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem zoomLevelsMenu;
        private System.Windows.Forms.MenuItem NavigationToolsMenu;
        private System.Windows.Forms.MenuItem zoom400MenuItem;
        private System.Windows.Forms.MenuItem zoom300MenuItem;
        private System.Windows.Forms.MenuItem zoom200MenuItem;
        private System.Windows.Forms.MenuItem zoom150MenuItem;
        private System.Windows.Forms.MenuItem zoom100MenuItem;
        private System.Windows.Forms.MenuItem zoom75MenuItem;
        private System.Windows.Forms.MenuItem zoom50MenuItem;
        private System.Windows.Forms.MenuItem zoom10MenuItem;
        private System.Windows.Forms.MenuItem zoomShowAllMenuItem;
        private System.Windows.Forms.MenuItem zoomInNavigationMenuItem;
        private System.Windows.Forms.MenuItem zoomOutNavigationMenuItem;
        private System.Windows.Forms.MenuItem panNavigationMenuItem;
        private System.Windows.Forms.MenuItem defaultNavigationMenuItem;
        private System.Windows.Forms.MenuItem expandMenuItem;
        private System.Windows.Forms.MenuItem collapseMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ToolStripComboBox zoomLevelToolStripButton;
        private System.Windows.Forms.ToolStripSeparator separatorToolStripButton2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem compileWorkflow;

    }
}

