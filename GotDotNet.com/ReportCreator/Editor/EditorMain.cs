using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.IO;
using System.Drawing.Printing;
using Windows.Forms.Reports.ReportLibrary;
using System.Xml;

namespace Windows.Forms.Reports.Editor
{
	#region EditorDlg
	public class EditorDlg : System.Windows.Forms.Form
	{
		#region class variables
		string[] MainArray;
		CommonFileSystem FFileSystem;
		string RegRoot="Software\\"+Application.ProductName;
		protected RulerBar HRB;
		protected RulerBar VRB;
		StringList TemplateList;
		bool FSetUndo;
		protected EditRep FRep;
		Units Units;
		TextBox CellEditor;
		TextBox BandEditor;
		bool fEnableUpdateEditText;
		double FGridX;
		double FGridY;
		string OldEditValue;
		StringList RecentFiles;
		int Bandidx;
		int Cellidx;
		bool ftoprint;
		bool ftoview;
		Zoom FZoom;
		#endregion
		
		#region Windows Form Designer generated code

		private System.Windows.Forms.ContextMenu RepPopupmenu;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.Windows.Forms.MenuItem menuItem34;
		private System.Windows.Forms.MenuItem menuItem35;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem41;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem43;
		private System.Windows.Forms.MenuItem menuItem46;
		private System.Windows.Forms.MenuItem menuItem47;
		private System.Windows.Forms.MenuItem menuItem48;
		private System.Windows.Forms.MenuItem menuItem49;
		private System.Windows.Forms.MenuItem menuItem50;
		private System.Windows.Forms.MenuItem menuItem51;
		private System.Windows.Forms.MenuItem menuItem52;
		private System.Windows.Forms.MenuItem menuItem53;
		private System.Windows.Forms.MenuItem menuItem54;
		private System.Windows.Forms.MenuItem menuItem55;
		private System.Windows.Forms.MenuItem menuItem56;
		private System.Windows.Forms.MenuItem menuItem57;
		private System.Windows.Forms.MenuItem menuItem58;
		private System.Windows.Forms.MenuItem menuItem59;
		private System.Windows.Forms.MenuItem menuItem60;
		private System.Windows.Forms.MenuItem menuItem61;
		private System.Windows.Forms.MenuItem menuItem62;
		private System.Windows.Forms.MenuItem menuItem63;
		private System.Windows.Forms.MenuItem menuItem64;
		private System.Windows.Forms.MenuItem menuItem65;
		private System.Windows.Forms.MenuItem menuItem66;
		private System.Windows.Forms.MenuItem menuItem67;
		private System.Windows.Forms.MenuItem menuItem68;
		private System.Windows.Forms.MenuItem menuItem69;
		private System.Windows.Forms.MenuItem menuItem70;
		private System.Windows.Forms.MenuItem menuItem71;
		private System.Windows.Forms.MenuItem menuItem72;
		private System.Windows.Forms.MenuItem menuItem73;
		private System.Windows.Forms.MenuItem menuItem74;
		private System.Windows.Forms.MenuItem menuItem75;
		private System.Windows.Forms.MenuItem menuItem76;
		private System.Windows.Forms.MenuItem menuItem78;
		private System.Windows.Forms.MenuItem menuItem80;
		private System.Windows.Forms.MenuItem menuItem82;
		private System.Windows.Forms.MenuItem menuItem84;
		private System.Windows.Forms.MenuItem menuItem86;
		private System.Windows.Forms.MenuItem menuItem87;
		private System.Windows.Forms.MenuItem menuItem88;
		private System.Windows.Forms.MenuItem menuItem89;
		private System.Windows.Forms.MenuItem menuItem90;
		private System.Windows.Forms.MenuItem menuItem91;
		private System.Windows.Forms.MenuItem menuItem92;
		private System.Windows.Forms.MenuItem menuItem93;
		private System.Windows.Forms.MenuItem menuItem94;
		private System.Windows.Forms.MenuItem menuItem95;
		private System.Windows.Forms.MenuItem menuItem96;
		private System.Windows.Forms.TabControl pc;
		private System.Windows.Forms.MenuItem menuItem99;
		private System.Windows.Forms.MenuItem menuItem100;
		private System.Windows.Forms.MenuItem menuItem101;
		private System.Windows.Forms.MenuItem menuItem102;
		private System.Windows.Forms.MenuItem menuItem103;
		private System.Windows.Forms.MenuItem menuItem104;
		private System.Windows.Forms.MenuItem menuItem105;
		private System.Windows.Forms.MenuItem menuItem106;
		private System.Windows.Forms.MenuItem menuItem107;
		private System.Windows.Forms.MenuItem menuItem108;
		private System.Windows.Forms.MenuItem menuItem109;
		private System.Windows.Forms.MenuItem menuItem110;
		private System.Windows.Forms.MenuItem menuItem111;
		private System.Windows.Forms.MenuItem menuItem77;
		private System.Windows.Forms.MenuItem menuItem79;
		private System.Windows.Forms.MenuItem menuItem83;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuItem81;
		private System.Windows.Forms.MenuItem menuItem112;
		private System.Windows.Forms.MenuItem menuItem113;
		private System.Windows.Forms.MenuItem menuItem114;
		private System.Windows.Forms.MenuItem menuItem115;
		private System.Windows.Forms.MenuItem menuItem116;
		private System.Windows.Forms.MenuItem menuItem117;
		private System.Windows.Forms.MenuItem menuItem118;
		private System.Windows.Forms.MenuItem menuItem119;
		private System.Windows.Forms.MenuItem menuItem120;
		private System.Windows.Forms.MenuItem menuItem121;
		private System.Windows.Forms.MenuItem menuItem122;
		private System.Windows.Forms.MenuItem menuItem123;
		private System.Windows.Forms.MenuItem menuItem45;
		private System.Windows.Forms.MenuItem menuItem124;
		private System.Windows.Forms.MenuItem menuItem85;
		private System.Windows.Forms.MenuItem menuItem97;
		private System.Windows.Forms.MenuItem menuItem98;
		private System.Windows.Forms.MenuItem menuItem125;
		private System.Windows.Forms.MenuItem menuItem126;
		private System.Windows.Forms.MenuItem menuItem127;
		private System.Windows.Forms.MenuItem menuItem128;
		
		
		private System.ComponentModel.Container components = null;

		public EditorDlg()
		{
			InitializeComponent();
		}

		
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

		private void InitializeComponent()
		{
			this.RepPopupmenu = new System.Windows.Forms.ContextMenu();
			this.menuItem99 = new System.Windows.Forms.MenuItem();
			this.menuItem100 = new System.Windows.Forms.MenuItem();
			this.menuItem101 = new System.Windows.Forms.MenuItem();
			this.menuItem102 = new System.Windows.Forms.MenuItem();
			this.menuItem103 = new System.Windows.Forms.MenuItem();
			this.menuItem104 = new System.Windows.Forms.MenuItem();
			this.menuItem105 = new System.Windows.Forms.MenuItem();
			this.menuItem106 = new System.Windows.Forms.MenuItem();
			this.menuItem107 = new System.Windows.Forms.MenuItem();
			this.menuItem108 = new System.Windows.Forms.MenuItem();
			this.menuItem109 = new System.Windows.Forms.MenuItem();
			this.menuItem110 = new System.Windows.Forms.MenuItem();
			this.menuItem111 = new System.Windows.Forms.MenuItem();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem44 = new System.Windows.Forms.MenuItem();
			this.menuItem81 = new System.Windows.Forms.MenuItem();
			this.menuItem112 = new System.Windows.Forms.MenuItem();
			this.menuItem113 = new System.Windows.Forms.MenuItem();
			this.menuItem114 = new System.Windows.Forms.MenuItem();
			this.menuItem115 = new System.Windows.Forms.MenuItem();
			this.menuItem116 = new System.Windows.Forms.MenuItem();
			this.menuItem117 = new System.Windows.Forms.MenuItem();
			this.menuItem121 = new System.Windows.Forms.MenuItem();
			this.menuItem122 = new System.Windows.Forms.MenuItem();
			this.menuItem118 = new System.Windows.Forms.MenuItem();
			this.menuItem119 = new System.Windows.Forms.MenuItem();
			this.menuItem120 = new System.Windows.Forms.MenuItem();
			this.menuItem123 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem85 = new System.Windows.Forms.MenuItem();
			this.menuItem97 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			this.menuItem34 = new System.Windows.Forms.MenuItem();
			this.menuItem35 = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.menuItem38 = new System.Windows.Forms.MenuItem();
			this.menuItem39 = new System.Windows.Forms.MenuItem();
			this.menuItem40 = new System.Windows.Forms.MenuItem();
			this.menuItem41 = new System.Windows.Forms.MenuItem();
			this.menuItem42 = new System.Windows.Forms.MenuItem();
			this.menuItem43 = new System.Windows.Forms.MenuItem();
			this.menuItem83 = new System.Windows.Forms.MenuItem();
			this.menuItem46 = new System.Windows.Forms.MenuItem();
			this.menuItem47 = new System.Windows.Forms.MenuItem();
			this.menuItem48 = new System.Windows.Forms.MenuItem();
			this.menuItem49 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem98 = new System.Windows.Forms.MenuItem();
			this.menuItem125 = new System.Windows.Forms.MenuItem();
			this.menuItem50 = new System.Windows.Forms.MenuItem();
			this.menuItem51 = new System.Windows.Forms.MenuItem();
			this.menuItem52 = new System.Windows.Forms.MenuItem();
			this.menuItem53 = new System.Windows.Forms.MenuItem();
			this.menuItem54 = new System.Windows.Forms.MenuItem();
			this.menuItem55 = new System.Windows.Forms.MenuItem();
			this.menuItem56 = new System.Windows.Forms.MenuItem();
			this.menuItem57 = new System.Windows.Forms.MenuItem();
			this.menuItem58 = new System.Windows.Forms.MenuItem();
			this.menuItem59 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem45 = new System.Windows.Forms.MenuItem();
			this.menuItem124 = new System.Windows.Forms.MenuItem();
			this.menuItem60 = new System.Windows.Forms.MenuItem();
			this.menuItem61 = new System.Windows.Forms.MenuItem();
			this.menuItem62 = new System.Windows.Forms.MenuItem();
			this.menuItem63 = new System.Windows.Forms.MenuItem();
			this.menuItem64 = new System.Windows.Forms.MenuItem();
			this.menuItem65 = new System.Windows.Forms.MenuItem();
			this.menuItem66 = new System.Windows.Forms.MenuItem();
			this.menuItem67 = new System.Windows.Forms.MenuItem();
			this.menuItem68 = new System.Windows.Forms.MenuItem();
			this.menuItem69 = new System.Windows.Forms.MenuItem();
			this.menuItem70 = new System.Windows.Forms.MenuItem();
			this.menuItem71 = new System.Windows.Forms.MenuItem();
			this.menuItem72 = new System.Windows.Forms.MenuItem();
			this.menuItem73 = new System.Windows.Forms.MenuItem();
			this.menuItem74 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem75 = new System.Windows.Forms.MenuItem();
			this.menuItem76 = new System.Windows.Forms.MenuItem();
			this.menuItem78 = new System.Windows.Forms.MenuItem();
			this.menuItem80 = new System.Windows.Forms.MenuItem();
			this.menuItem82 = new System.Windows.Forms.MenuItem();
			this.menuItem77 = new System.Windows.Forms.MenuItem();
			this.menuItem79 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem84 = new System.Windows.Forms.MenuItem();
			this.menuItem86 = new System.Windows.Forms.MenuItem();
			this.menuItem87 = new System.Windows.Forms.MenuItem();
			this.menuItem88 = new System.Windows.Forms.MenuItem();
			this.menuItem89 = new System.Windows.Forms.MenuItem();
			this.menuItem90 = new System.Windows.Forms.MenuItem();
			this.menuItem91 = new System.Windows.Forms.MenuItem();
			this.menuItem92 = new System.Windows.Forms.MenuItem();
			this.menuItem93 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem94 = new System.Windows.Forms.MenuItem();
			this.menuItem96 = new System.Windows.Forms.MenuItem();
			this.menuItem95 = new System.Windows.Forms.MenuItem();
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			this.pc = new System.Windows.Forms.TabControl();
			this.menuItem126 = new System.Windows.Forms.MenuItem();
			this.menuItem127 = new System.Windows.Forms.MenuItem();
			this.menuItem128 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			this.SuspendLayout();
			// 
			// RepPopupmenu
			// 
			this.RepPopupmenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem99,
																						 this.menuItem100,
																						 this.menuItem101,
																						 this.menuItem102,
																						 this.menuItem103,
																						 this.menuItem104,
																						 this.menuItem127,
																						 this.menuItem128,
																						 this.menuItem126,
																						 this.menuItem105,
																						 this.menuItem106,
																						 this.menuItem107,
																						 this.menuItem108,
																						 this.menuItem109,
																						 this.menuItem110,
																						 this.menuItem111});
			this.RepPopupmenu.Popup += new System.EventHandler(this.RepPopupmenu_Popup);
			// 
			// menuItem99
			// 
			this.menuItem99.Index = 0;
			this.menuItem99.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
			this.menuItem99.Text = "Close page";
			this.menuItem99.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem100
			// 
			this.menuItem100.Index = 1;
			this.menuItem100.Text = "-";
			// 
			// menuItem101
			// 
			this.menuItem101.Index = 2;
			this.menuItem101.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.menuItem101.Text = "Copy cells";
			this.menuItem101.Click += new System.EventHandler(this.menuItem36_Click);
			// 
			// menuItem102
			// 
			this.menuItem102.Index = 3;
			this.menuItem102.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuItem102.Text = "Cut cells";
			this.menuItem102.Click += new System.EventHandler(this.menuItem37_Click);
			// 
			// menuItem103
			// 
			this.menuItem103.Index = 4;
			this.menuItem103.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.menuItem103.Text = "Paste cells";
			this.menuItem103.Click += new System.EventHandler(this.menuItem38_Click);
			// 
			// menuItem104
			// 
			this.menuItem104.Index = 5;
			this.menuItem104.Text = "Cell text";
			this.menuItem104.Click += new System.EventHandler(this.menuItem48_Click);
			// 
			// menuItem105
			// 
			this.menuItem105.Index = 9;
			this.menuItem105.Text = "-";
			// 
			// menuItem106
			// 
			this.menuItem106.Index = 10;
			this.menuItem106.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftC;
			this.menuItem106.Text = "Copy bands";
			this.menuItem106.Click += new System.EventHandler(this.menuItem55_Click);
			// 
			// menuItem107
			// 
			this.menuItem107.Index = 11;
			this.menuItem107.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftX;
			this.menuItem107.Text = "Cut bands";
			this.menuItem107.Click += new System.EventHandler(this.menuItem56_Click);
			// 
			// menuItem108
			// 
			this.menuItem108.Index = 12;
			this.menuItem108.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftV;
			this.menuItem108.Text = "Paste bands";
			this.menuItem108.Click += new System.EventHandler(this.menuItem57_Click);
			// 
			// menuItem109
			// 
			this.menuItem109.Index = 13;
			this.menuItem109.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem109.Text = "Band Name";
			this.menuItem109.Click += new System.EventHandler(this.menuItem59_Click);
			// 
			// menuItem110
			// 
			this.menuItem110.Index = 14;
			this.menuItem110.Text = "-";
			// 
			// menuItem111
			// 
			this.menuItem111.Index = 15;
			this.menuItem111.Text = "Cell properties";
			this.menuItem111.Click += new System.EventHandler(this.menuItem49_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1,
																					 this.menuItem2,
																					 this.menuItem44,
																					 this.menuItem3,
																					 this.menuItem4,
																					 this.menuItem5,
																					 this.menuItem6,
																					 this.menuItem7,
																					 this.menuItem9});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem13,
																					  this.menuItem14,
																					  this.menuItem15,
																					  this.menuItem16,
																					  this.menuItem17,
																					  this.menuItem18,
																					  this.menuItem19,
																					  this.menuItem20,
																					  this.menuItem21,
																					  this.menuItem22});
			this.menuItem1.Text = "&File";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.menuItem10.Text = "&New";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 1;
			this.menuItem11.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItem11.Text = "&Open";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItem12.Text = "&Save";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 3;
			this.menuItem13.Text = "Save &as";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 4;
			this.menuItem14.Text = "Sa&ve all";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 5;
			this.menuItem15.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
			this.menuItem15.Text = "&Close Page";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 6;
			this.menuItem16.Text = "-";
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 7;
			this.menuItem17.Text = "Pa&ge Setup";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 8;
			this.menuItem18.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.menuItem18.Text = "&Print";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 9;
			this.menuItem19.Text = "P&review";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 10;
			this.menuItem20.Text = "-";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 11;
			this.menuItem21.Text = "-";
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 12;
			this.menuItem22.Text = "E&xit";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem23,
																					  this.menuItem24,
																					  this.menuItem25,
																					  this.menuItem26,
																					  this.menuItem29,
																					  this.menuItem27,
																					  this.menuItem28,
																					  this.menuItem30});
			this.menuItem2.Text = "&Edit";
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 0;
			this.menuItem23.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
			this.menuItem23.Text = "&Undo";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 1;
			this.menuItem24.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftZ;
			this.menuItem24.Text = "&Redo";
			this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 2;
			this.menuItem25.Text = "-";
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 3;
			this.menuItem26.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.menuItem26.Text = "Select &all";
			this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 4;
			this.menuItem29.Text = "-";
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 5;
			this.menuItem27.Text = "&Insert Picture";
			this.menuItem27.Click += new System.EventHandler(this.menuItem27_Click);
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 6;
			this.menuItem28.Text = "&Fit to cell";
			this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 7;
			this.menuItem30.Text = "&Tiles Picture";
			this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
			// 
			// menuItem44
			// 
			this.menuItem44.Index = 2;
			this.menuItem44.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem81,
																					   this.menuItem112,
																					   this.menuItem113,
																					   this.menuItem114,
																					   this.menuItem123});
			this.menuItem44.Text = "&View";
			// 
			// menuItem81
			// 
			this.menuItem81.Index = 0;
			this.menuItem81.Text = "Page &color";
			this.menuItem81.Click += new System.EventHandler(this.menuItem81_Click);
			// 
			// menuItem112
			// 
			this.menuItem112.Index = 1;
			this.menuItem112.Text = "Page &background";
			this.menuItem112.Click += new System.EventHandler(this.menuItem112_Click);
			// 
			// menuItem113
			// 
			this.menuItem113.Index = 2;
			this.menuItem113.Text = "-";
			// 
			// menuItem114
			// 
			this.menuItem114.Index = 3;
			this.menuItem114.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuItem115,
																						this.menuItem116,
																						this.menuItem117,
																						this.menuItem121,
																						this.menuItem122,
																						this.menuItem118,
																						this.menuItem119,
																						this.menuItem120});
			this.menuItem114.Text = "&Zoom";
			// 
			// menuItem115
			// 
			this.menuItem115.Index = 0;
			this.menuItem115.Text = "50";
			this.menuItem115.Click += new System.EventHandler(this.menuItem115_Click);
			// 
			// menuItem116
			// 
			this.menuItem116.Index = 1;
			this.menuItem116.Text = "75";
			this.menuItem116.Click += new System.EventHandler(this.menuItem116_Click);
			// 
			// menuItem117
			// 
			this.menuItem117.Index = 2;
			this.menuItem117.Text = "100";
			this.menuItem117.Click += new System.EventHandler(this.menuItem117_Click);
			// 
			// menuItem121
			// 
			this.menuItem121.Index = 3;
			this.menuItem121.Text = "150";
			this.menuItem121.Click += new System.EventHandler(this.menuItem121_Click);
			// 
			// menuItem122
			// 
			this.menuItem122.Index = 4;
			this.menuItem122.Text = "200";
			this.menuItem122.Click += new System.EventHandler(this.menuItem122_Click);
			// 
			// menuItem118
			// 
			this.menuItem118.Index = 5;
			this.menuItem118.Text = "-";
			// 
			// menuItem119
			// 
			this.menuItem119.Index = 6;
			this.menuItem119.Text = "Whole page";
			this.menuItem119.Click += new System.EventHandler(this.menuItem119_Click);
			// 
			// menuItem120
			// 
			this.menuItem120.Index = 7;
			this.menuItem120.Text = "Page width";
			this.menuItem120.Click += new System.EventHandler(this.menuItem120_Click);
			// 
			// menuItem123
			// 
			this.menuItem123.Index = 4;
			this.menuItem123.Text = "Show &margins";
			this.menuItem123.Click += new System.EventHandler(this.menuItem123_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem85,
																					  this.menuItem97,
																					  this.menuItem31,
																					  this.menuItem32,
																					  this.menuItem33,
																					  this.menuItem34,
																					  this.menuItem35,
																					  this.menuItem36,
																					  this.menuItem37,
																					  this.menuItem38,
																					  this.menuItem39,
																					  this.menuItem40,
																					  this.menuItem41,
																					  this.menuItem42,
																					  this.menuItem43,
																					  this.menuItem83,
																					  this.menuItem46,
																					  this.menuItem47,
																					  this.menuItem48,
																					  this.menuItem49});
			this.menuItem3.Text = "&Cells";
			// 
			// menuItem85
			// 
			this.menuItem85.Index = 0;
			this.menuItem85.Text = "&Lock cell width";
			this.menuItem85.Click += new System.EventHandler(this.menuItem85_Click);
			// 
			// menuItem97
			// 
			this.menuItem97.Index = 1;
			this.menuItem97.Text = "-";
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 2;
			this.menuItem31.Shortcut = System.Windows.Forms.Shortcut.Ins;
			this.menuItem31.Text = "&Add Cell";
			this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 3;
			this.menuItem32.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuItem32.Text = "&Delete Cell";
			this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click);
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 4;
			this.menuItem33.Text = "Cell move &left";
			this.menuItem33.Click += new System.EventHandler(this.menuItem33_Click);
			// 
			// menuItem34
			// 
			this.menuItem34.Index = 5;
			this.menuItem34.Text = "Cell move &right";
			this.menuItem34.Click += new System.EventHandler(this.menuItem34_Click);
			// 
			// menuItem35
			// 
			this.menuItem35.Index = 6;
			this.menuItem35.Text = "-";
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 7;
			this.menuItem36.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.menuItem36.Text = "&Copy cells";
			this.menuItem36.Click += new System.EventHandler(this.menuItem36_Click);
			// 
			// menuItem37
			// 
			this.menuItem37.Index = 8;
			this.menuItem37.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuItem37.Text = "C&ut cells";
			this.menuItem37.Click += new System.EventHandler(this.menuItem37_Click);
			// 
			// menuItem38
			// 
			this.menuItem38.Index = 9;
			this.menuItem38.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.menuItem38.Text = "&Paste cells";
			this.menuItem38.Click += new System.EventHandler(this.menuItem38_Click);
			// 
			// menuItem39
			// 
			this.menuItem39.Index = 10;
			this.menuItem39.Text = "-";
			// 
			// menuItem40
			// 
			this.menuItem40.Index = 11;
			this.menuItem40.Shortcut = System.Windows.Forms.Shortcut.CtrlIns;
			this.menuItem40.Text = "&Split cell";
			this.menuItem40.Click += new System.EventHandler(this.menuItem40_Click);
			// 
			// menuItem41
			// 
			this.menuItem41.Index = 12;
			this.menuItem41.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
			this.menuItem41.Text = "Merge cells by &horizantally";
			this.menuItem41.Click += new System.EventHandler(this.menuItem41_Click);
			// 
			// menuItem42
			// 
			this.menuItem42.Index = 13;
			this.menuItem42.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.menuItem42.Text = "Merge cells by &vertically";
			this.menuItem42.Click += new System.EventHandler(this.menuItem42_Click);
			// 
			// menuItem43
			// 
			this.menuItem43.Index = 14;
			this.menuItem43.Text = "-";
			// 
			// menuItem83
			// 
			this.menuItem83.Index = 15;
			this.menuItem83.Text = "Sha&pe";
			this.menuItem83.Click += new System.EventHandler(this.menuItem83_Click);
			// 
			// menuItem46
			// 
			this.menuItem46.Index = 16;
			this.menuItem46.Text = "&Word wrap";
			this.menuItem46.Click += new System.EventHandler(this.menuItem46_Click);
			// 
			// menuItem47
			// 
			this.menuItem47.Index = 17;
			this.menuItem47.Text = "-";
			// 
			// menuItem48
			// 
			this.menuItem48.Index = 18;
			this.menuItem48.Text = "Cell &text";
			this.menuItem48.Click += new System.EventHandler(this.menuItem48_Click);
			// 
			// menuItem49
			// 
			this.menuItem49.Index = 19;
			this.menuItem49.Text = "C&ell properties";
			this.menuItem49.Click += new System.EventHandler(this.menuItem49_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem98,
																					  this.menuItem125,
																					  this.menuItem50,
																					  this.menuItem51,
																					  this.menuItem52,
																					  this.menuItem53,
																					  this.menuItem54,
																					  this.menuItem55,
																					  this.menuItem56,
																					  this.menuItem57,
																					  this.menuItem58,
																					  this.menuItem59});
			this.menuItem4.Text = "&Bands";
			// 
			// menuItem98
			// 
			this.menuItem98.Index = 0;
			this.menuItem98.Text = "&Lock band height";
			this.menuItem98.Click += new System.EventHandler(this.menuItem98_Click);
			// 
			// menuItem125
			// 
			this.menuItem125.Index = 1;
			this.menuItem125.Text = "-";
			// 
			// menuItem50
			// 
			this.menuItem50.Index = 2;
			this.menuItem50.Text = "&Add band";
			this.menuItem50.Click += new System.EventHandler(this.menuItem50_Click);
			// 
			// menuItem51
			// 
			this.menuItem51.Index = 3;
			this.menuItem51.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.menuItem51.Text = "&Delete band";
			this.menuItem51.Click += new System.EventHandler(this.menuItem51_Click);
			// 
			// menuItem52
			// 
			this.menuItem52.Index = 4;
			this.menuItem52.Text = "Band move &up";
			this.menuItem52.Click += new System.EventHandler(this.menuItem52_Click);
			// 
			// menuItem53
			// 
			this.menuItem53.Index = 5;
			this.menuItem53.Text = "&Band move down";
			this.menuItem53.Click += new System.EventHandler(this.menuItem53_Click);
			// 
			// menuItem54
			// 
			this.menuItem54.Index = 6;
			this.menuItem54.Text = "-";
			// 
			// menuItem55
			// 
			this.menuItem55.Index = 7;
			this.menuItem55.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftC;
			this.menuItem55.Text = "&Copy bands";
			this.menuItem55.Click += new System.EventHandler(this.menuItem55_Click);
			// 
			// menuItem56
			// 
			this.menuItem56.Index = 8;
			this.menuItem56.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftX;
			this.menuItem56.Text = "Cu&t bands";
			this.menuItem56.Click += new System.EventHandler(this.menuItem56_Click);
			// 
			// menuItem57
			// 
			this.menuItem57.Index = 9;
			this.menuItem57.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftV;
			this.menuItem57.Text = "&Paste bands";
			this.menuItem57.Click += new System.EventHandler(this.menuItem57_Click);
			// 
			// menuItem58
			// 
			this.menuItem58.Index = 10;
			this.menuItem58.Text = "-";
			// 
			// menuItem59
			// 
			this.menuItem59.Index = 11;
			this.menuItem59.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem59.Text = "Band &name";
			this.menuItem59.Click += new System.EventHandler(this.menuItem59_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 5;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem45,
																					  this.menuItem124,
																					  this.menuItem60,
																					  this.menuItem61,
																					  this.menuItem62,
																					  this.menuItem63,
																					  this.menuItem64,
																					  this.menuItem65,
																					  this.menuItem66,
																					  this.menuItem67,
																					  this.menuItem68,
																					  this.menuItem69,
																					  this.menuItem70,
																					  this.menuItem71,
																					  this.menuItem72,
																					  this.menuItem73,
																					  this.menuItem74});
			this.menuItem5.Text = "For&mat";
			// 
			// menuItem45
			// 
			this.menuItem45.Index = 0;
			this.menuItem45.Text = "&Styles";
			this.menuItem45.Click += new System.EventHandler(this.menuItem45_Click);
			// 
			// menuItem124
			// 
			this.menuItem124.Index = 1;
			this.menuItem124.Text = "-";
			// 
			// menuItem60
			// 
			this.menuItem60.Index = 2;
			this.menuItem60.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.menuItem60.Text = "&Font";
			this.menuItem60.Click += new System.EventHandler(this.menuItem60_Click);
			// 
			// menuItem61
			// 
			this.menuItem61.Index = 3;
			this.menuItem61.Text = "Font &color";
			this.menuItem61.Click += new System.EventHandler(this.menuItem61_Click);
			// 
			// menuItem62
			// 
			this.menuItem62.Index = 4;
			this.menuItem62.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
			this.menuItem62.Text = "&Bold";
			this.menuItem62.Click += new System.EventHandler(this.menuItem62_Click);
			// 
			// menuItem63
			// 
			this.menuItem63.Index = 5;
			this.menuItem63.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
			this.menuItem63.Text = "&Italic";
			this.menuItem63.Click += new System.EventHandler(this.menuItem63_Click);
			// 
			// menuItem64
			// 
			this.menuItem64.Index = 6;
			this.menuItem64.Shortcut = System.Windows.Forms.Shortcut.CtrlU;
			this.menuItem64.Text = "&Underline";
			this.menuItem64.Click += new System.EventHandler(this.menuItem64_Click);
			// 
			// menuItem65
			// 
			this.menuItem65.Index = 7;
			this.menuItem65.Text = "I&ncrease font";
			this.menuItem65.Click += new System.EventHandler(this.menuItem65_Click);
			// 
			// menuItem66
			// 
			this.menuItem66.Index = 8;
			this.menuItem66.Text = "&Decrease font";
			this.menuItem66.Click += new System.EventHandler(this.menuItem66_Click);
			// 
			// menuItem67
			// 
			this.menuItem67.Index = 9;
			this.menuItem67.Text = "-";
			// 
			// menuItem68
			// 
			this.menuItem68.Index = 10;
			this.menuItem68.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
			this.menuItem68.Text = "&Left align";
			this.menuItem68.Click += new System.EventHandler(this.menuItem68_Click);
			// 
			// menuItem69
			// 
			this.menuItem69.Index = 11;
			this.menuItem69.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
			this.menuItem69.Text = "C&enter align";
			this.menuItem69.Click += new System.EventHandler(this.menuItem69_Click);
			// 
			// menuItem70
			// 
			this.menuItem70.Index = 12;
			this.menuItem70.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
			this.menuItem70.Text = "&Right align";
			this.menuItem70.Click += new System.EventHandler(this.menuItem70_Click);
			// 
			// menuItem71
			// 
			this.menuItem71.Index = 13;
			this.menuItem71.Text = "-";
			// 
			// menuItem72
			// 
			this.menuItem72.Index = 14;
			this.menuItem72.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
			this.menuItem72.Text = "&Top layout";
			this.menuItem72.Click += new System.EventHandler(this.menuItem72_Click);
			// 
			// menuItem73
			// 
			this.menuItem73.Index = 15;
			this.menuItem73.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.menuItem73.Text = "Center l&ayout";
			this.menuItem73.Click += new System.EventHandler(this.menuItem73_Click);
			// 
			// menuItem74
			// 
			this.menuItem74.Index = 16;
			this.menuItem74.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
			this.menuItem74.Text = "B&ottom layout";
			this.menuItem74.Click += new System.EventHandler(this.menuItem74_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 6;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem75,
																					  this.menuItem76,
																					  this.menuItem78,
																					  this.menuItem80,
																					  this.menuItem82,
																					  this.menuItem77,
																					  this.menuItem79});
			this.menuItem6.Text = "F&rame";
			// 
			// menuItem75
			// 
			this.menuItem75.Index = 0;
			this.menuItem75.Shortcut = System.Windows.Forms.Shortcut.Ctrl0;
			this.menuItem75.Text = "&Not frame";
			this.menuItem75.Click += new System.EventHandler(this.menuItem75_Click);
			// 
			// menuItem76
			// 
			this.menuItem76.Index = 1;
			this.menuItem76.Shortcut = System.Windows.Forms.Shortcut.Ctrl1;
			this.menuItem76.Text = "&Left border";
			this.menuItem76.Click += new System.EventHandler(this.menuItem76_Click);
			// 
			// menuItem78
			// 
			this.menuItem78.Index = 2;
			this.menuItem78.Shortcut = System.Windows.Forms.Shortcut.Ctrl2;
			this.menuItem78.Text = "&Right border";
			this.menuItem78.Click += new System.EventHandler(this.menuItem78_Click);
			// 
			// menuItem80
			// 
			this.menuItem80.Index = 3;
			this.menuItem80.Shortcut = System.Windows.Forms.Shortcut.Ctrl3;
			this.menuItem80.Text = "&Top border";
			this.menuItem80.Click += new System.EventHandler(this.menuItem80_Click);
			// 
			// menuItem82
			// 
			this.menuItem82.Index = 4;
			this.menuItem82.Shortcut = System.Windows.Forms.Shortcut.Ctrl4;
			this.menuItem82.Text = "&Bottom border";
			this.menuItem82.Click += new System.EventHandler(this.menuItem82_Click);
			// 
			// menuItem77
			// 
			this.menuItem77.Index = 5;
			this.menuItem77.Text = "-";
			// 
			// menuItem79
			// 
			this.menuItem79.Index = 6;
			this.menuItem79.Text = "&All border";
			this.menuItem79.Click += new System.EventHandler(this.menuItem79_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 7;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem8,
																					  this.menuItem84,
																					  this.menuItem86,
																					  this.menuItem91,
																					  this.menuItem92,
																					  this.menuItem93});
			this.menuItem7.Text = "&Options";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 0;
			this.menuItem8.Text = "P&references";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem84
			// 
			this.menuItem84.Index = 1;
			this.menuItem84.Text = "Default &font";
			this.menuItem84.Click += new System.EventHandler(this.menuItem84_Click);
			// 
			// menuItem86
			// 
			this.menuItem86.Index = 2;
			this.menuItem86.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem87,
																					   this.menuItem88,
																					   this.menuItem89,
																					   this.menuItem90});
			this.menuItem86.Text = "&Units";
			// 
			// menuItem87
			// 
			this.menuItem87.Index = 0;
			this.menuItem87.Text = "&inches";
			this.menuItem87.Click += new System.EventHandler(this.menuItem87_Click);
			// 
			// menuItem88
			// 
			this.menuItem88.Index = 1;
			this.menuItem88.Text = "&milimeters";
			this.menuItem88.Click += new System.EventHandler(this.menuItem88_Click);
			// 
			// menuItem89
			// 
			this.menuItem89.Index = 2;
			this.menuItem89.Text = "&centimeters";
			this.menuItem89.Click += new System.EventHandler(this.menuItem89_Click);
			// 
			// menuItem90
			// 
			this.menuItem90.Index = 3;
			this.menuItem90.Text = "&pixels";
			this.menuItem90.Click += new System.EventHandler(this.menuItem90_Click);
			// 
			// menuItem91
			// 
			this.menuItem91.Index = 3;
			this.menuItem91.Text = "&Show all";
			this.menuItem91.Click += new System.EventHandler(this.menuItem91_Click);
			// 
			// menuItem92
			// 
			this.menuItem92.Index = 4;
			this.menuItem92.Text = "-";
			// 
			// menuItem93
			// 
			this.menuItem93.Index = 5;
			this.menuItem93.Text = "F&ile System";
			this.menuItem93.Click += new System.EventHandler(this.menuItem93_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 8;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem94,
																					  this.menuItem96,
																					  this.menuItem95});
			this.menuItem9.Text = "&Help";
			// 
			// menuItem94
			// 
			this.menuItem94.Index = 0;
			this.menuItem94.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuItem94.Text = "&Contents";
			this.menuItem94.Click += new System.EventHandler(this.menuItem94_Click);
			// 
			// menuItem96
			// 
			this.menuItem96.Index = 1;
			this.menuItem96.Text = "-";
			// 
			// menuItem95
			// 
			this.menuItem95.Index = 2;
			this.menuItem95.Text = "&About";
			this.menuItem95.Click += new System.EventHandler(this.menuItem95_Click);
			// 
			// colorDialog
			// 
			this.colorDialog.AnyColor = true;
			this.colorDialog.FullOpen = true;
			this.colorDialog.ShowHelp = true;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 165);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2,
																						  this.statusBarPanel3});
			this.statusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(504, 20);
			this.statusBar1.TabIndex = 0;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Width = 200;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Width = 200;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.Width = 300;
			// 
			// pc
			// 
			this.pc.ContextMenu = this.RepPopupmenu;
			this.pc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pc.Location = new System.Drawing.Point(0, 0);
			this.pc.Multiline = true;
			this.pc.Name = "pc";
			this.pc.SelectedIndex = 0;
			this.pc.Size = new System.Drawing.Size(504, 165);
			this.pc.TabIndex = 1;
			this.pc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pc_MouseDown);
			this.pc.SelectedIndexChanged += new System.EventHandler(this.pc_SelectedIndexChanged);
			// 
			// menuItem126
			// 
			this.menuItem126.Index = 8;
			this.menuItem126.Text = "Lock band height";
			this.menuItem126.Click += new System.EventHandler(this.menuItem98_Click);
			// 
			// menuItem127
			// 
			this.menuItem127.Index = 6;
			this.menuItem127.Text = "-";
			// 
			// menuItem128
			// 
			this.menuItem128.Index = 7;
			this.menuItem128.Text = "Lock cell width";
			this.menuItem128.Click += new System.EventHandler(this.menuItem85_Click);
			// 
			// EditorDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(504, 185);
			this.Controls.Add(this.pc);
			this.Controls.Add(this.statusBar1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.Menu = this.mainMenu;
			this.Name = "EditorDlg";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.EditorDlg_Closing);
			this.SizeChanged += new System.EventHandler(this.EditorDlg_SizeChanged);
			this.Load += new System.EventHandler(this.EditorDlg_Load);
			this.Closed += new System.EventHandler(this.EditorDlg_Closed);
			this.Activated += new System.EventHandler(this.EditorDlg_Activated);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Main
		[STAThread]
		static int Main(string[] arg) 
		{	
			EditorDlg d=new EditorDlg();
			d.MainArray=arg;
			Application.Run(d);			
			return 0;
		}
		#endregion
		
		#region class methods
		protected void UpdateCaption()
		{
			if(FileSystem!=null)
				pc.SelectedTab.Text=FileSystem.ExtractFileNameOnly(FileName);
			Text=FileName;
		}

		void LoadRecentFiles()
		{
			string s=RegRoot+"\\Setup\\RecentFiles";
			RegistryKey reg=Registry.CurrentUser.OpenSubKey(s,true);
			if(reg==null)
				reg=Registry.CurrentUser.CreateSubKey(s);
			string[] ss=reg.GetValueNames();
			RecentFiles.AddRange(ss);
			for(int i=RecentFiles.Count-1;i>-1;i--)
				if(Generic.CT(RecentFiles.GetString(i),"Untitled")||(!FileSystem.FileExists(RecentFiles.GetString(i))))
				{
					RecentFiles.RemoveAt(i);
				}
			RecentFiles.IgnoreDuplicate();
			while(RecentFiles.Count>9)
				RecentFiles.RemoveAt(9);
			ShowRecentFiles();
		}

		void ShowRecentFiles()
		{
			int idx;
			MenuItem mi, begmi, endmi, filemenu;

			begmi=menuItem20;
			endmi=menuItem21;
			filemenu=menuItem1;

			for(int i=0;i<filemenu.MenuItems.Count;i++)
			{
				if(filemenu.MenuItems[i]==begmi)
				{
					idx=i+1;
					while(filemenu.MenuItems[idx]!=endmi)
					{
						mi=filemenu.MenuItems[idx];
						filemenu.MenuItems.RemoveAt(idx);
						mi.Dispose();
					}
					for(int j=0;j<RecentFiles.Count;j++)
					{
						mi=new MenuItem();
						mi.Text="&"+Convert.ToString(j+1)+" "+RecentFiles.GetString(j);
						mi.Click+=new EventHandler(RecentFilesMenuClick);
						menuItem1.MenuItems.Add(idx+j,mi);
					}
					break;
				}
			}
		}

		void RecentFilesMenuClick(object sender,EventArgs arg)
		{
			string s=((MenuItem)sender).Text;
			int y=s.IndexOf(" ");
			s=s.Substring(y+1,s.Length-y-1);
			int i=RecentFiles.IndexOf(s);
			LoadReport(RecentFiles.GetString(i));
		}

		void LoadReport(string AFileName)
		{
			string s=AFileName.Trim();
			if(!ShowPage(s))
			{
				pc.SelectedIndexChanged-=new EventHandler(pc_SelectedIndexChanged);
				NewReport(s);
				Rep.Units=Units;
				Rep.GridX=GridX;
				Rep.GridY=GridY;
			
				if(FileSystem.FileExists(s))
				{
					Rep.FileSystem=FileSystem;
					Rep.Load(s);
					Rep.Visible=true;			
					RepSetFocus();
					Text=Rep.FileName;
				}
				pc.SelectedIndexChanged+=new EventHandler(pc_SelectedIndexChanged);
				Undo.Clear();
				Undo.Add(Rep.Template.GetText());
				AddToRecentFiles(s);							
				Rep.Zoom=Zoom;
				Rep.Refresh();
				UpdateRulerBars();	
				UpdateButtons();
			}
		}

		void AddToRecentFiles(string AFileName)
		{
			if(AFileName!="")
			{
				int idx=RecentFiles.IndexOf(AFileName);
				if(idx!=-1)
					RecentFiles.RemoveAt(idx);
				RecentFiles.InsertString(0,AFileName);
				while(RecentFiles.Count>10)
					RecentFiles.RemoveAt(10);
				ShowRecentFiles();
			}
		}

		protected bool ShowPage(string AFileName)
		{
			int idx=TemplateList.IndexOf(AFileName);
			if(idx!=-1)
			{
				pc.SelectedTab=(TabPage)TemplateList.GetObject(idx);
			}
			return idx!=-1;
		}

		private void EditorDlg_Activated(object sender, System.EventArgs e)
		{
			RepSetFocus();
			Generic.CloseupAllPopupForms();			
		}

		private void EditorDlg_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(TemplateList.Count>0)
			{
				SaveLastEditedFiles();
			}
			e.Cancel=!CloseAllPages();
		}

		void SaveLastEditedFiles()
		{
			if(TemplateList.Count==0)
				return;
			string s=RegRoot+"\\Setup\\LastEditedFiles";
			RegistryKey reg=Registry.CurrentUser.OpenSubKey(s,true);			
			try
			{
				string[] ss=reg.GetValueNames();
				for(int i=0;i<ss.Length;i++)
					reg.DeleteValue(ss[i]);
			}
			catch
			{}
			if(reg==null)
				reg=Registry.CurrentUser.CreateSubKey(s);
			for(int i=0;i<TemplateList.Count;i++)
			{
				if(!(Generic.CT(TemplateList.GetString(i),"Untitled")))
				{
					reg.SetValue(TemplateList.GetString(i),"");
				}
			}
		}

		protected bool CloseAllPages()
		{
			string message = "Save Changes?";
			string caption = "Confirm";
			MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
			DialogResult result;
			bool freturn=true;
			bool QueryToSave=true;

			while(TemplateList.Count>0)
			{
				ShowPage(TemplateList.GetString(0));
				if(Modified)
				{
					if(QueryToSave)
					{
						result = MessageBox.Show(this, message, caption, buttons);
						if(result == DialogResult.Yes)
						{
							ClosePage(true,false);
						}
						if(result==DialogResult.No)
						{
							ClosePage(false,false);
						}
						if(result==DialogResult.Cancel)
						{
							return false;
						}
					}
					else
					{
						ClosePage(true,false);
					}
				}
				else
				{
					ClosePage(true,false);
				}
			}
			while(pc.TabCount>0)
			{
				ClosePage(true,QueryToSave);
			}
			return freturn;
		}

		protected bool ClosePage(bool SaveChanges,bool QueryToSave)
		{
			bool freturn=true;
			TabPage ps=pc.SelectedTab;
			string message = "Save Changes?";
			string caption = "Confirm";
			MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
			DialogResult result;
			int idx;

			if(((PageType)ps.Tag==PageType.Template)||((PageType)ps.Tag==PageType.Script))
			{
				if((SaveChanges)&&(Modified))
				{
					if(QueryToSave)
					{
						result = MessageBox.Show(this, message, caption, buttons);
						if(result==DialogResult.Yes)
						{
							if(!SaveReport())
							{
								return false;
							}
						}
						if(result==DialogResult.Cancel)
						{
							return false;
						}
						if(result==DialogResult.No)
						{
							freturn=false;
						}
					}
					else
					{
						if(!SaveReport())
						{
							return false;
						}
					}
				}
				idx=TemplateList.IndexOfObject(ps);
				if(idx>=0)
				{
					TemplateList.RemoveAt(idx);
				}
			}
			if(TemplateList.Count!=0)
				pc.SelectedTab=(TabPage)TemplateList.GetObject(TemplateList.Count-1);
			pc.Controls.Remove(ps);
		
			menuItem15.Enabled=pc.TabCount>1;
			menuItem99.Enabled=pc.TabCount>1;
			return freturn;
		}

		bool SaveReport()
		{
			if(!Modified)
				return true;
			bool freturn=false;
			
			if((FileName!="")&&(FileName!="Untitled"))
			{
				Rep.FileSystem=FileSystem;
				Rep.Save(FileName);
				UpdateCaption();
				Modified=false;
				freturn=true;
			}
			else
			{
				FileSystem.FileName=FileName;
				if(FileSystem.SaveDialogExecute())
				{
					FileName=FileSystem.FileName;
					Rep.FileSystem=FileSystem;
					Rep.Save(FileSystem.FileName);
					Text=FileSystem.Caption();
					Modified=false;
					freturn=true;
				}
			}			
			if(freturn)
				AddToRecentFiles(FileName);
			return freturn;
		}

		private void EditorDlg_Closed(object sender, System.EventArgs e)
		{
			SaveRecentFiles();
			string s=RegRoot+"\\Setup";
			RegistryKey reg=Registry.CurrentUser.OpenSubKey(s,true);
			if(reg==null)
				reg=Registry.CurrentUser.CreateSubKey(s);
			
			reg.SetValue("Left",Left);
			reg.SetValue("Width",Width);
			reg.SetValue("Top",Top);
			reg.SetValue("Height",Height);
			reg.SetValue("FirstTime",1);

			reg.SetValue("UnitsIndex",(int)Units);
			byte[] bytearray=BitConverter.GetBytes(GridX);
			reg.SetValue("GridX",bytearray);
			bytearray=BitConverter.GetBytes(GridY);
			reg.SetValue("GridY",bytearray);
			reg.SetValue("LastEditedFile",FileSystem.FileName);
			reg.SetValue("FileSystem",FileSystem.DisplayName);
			
			s=s+"\\"+FileSystem.DisplayName;
			reg=Registry.CurrentUser.OpenSubKey(s,true);
			if(reg==null)
				reg=Registry.CurrentUser.CreateSubKey(s);
			reg.SetValue("Params",FileSystem.Params);

			s=RegRoot+"\\Setup\\Objects";
			reg=Registry.CurrentUser.OpenSubKey(s,true);
			if(reg==null)
				reg=Registry.CurrentUser.CreateSubKey(s);
		}

		private void SaveRecentFiles()
		{
			string s=RegRoot+"\\Setup\\RecentFiles";
			RegistryKey reg=Registry.CurrentUser.OpenSubKey(s,true);			
			try
			{
				string[] ss=reg.GetValueNames();
				for(int i=0;i<ss.Length;i++)
					reg.DeleteValue(ss[i]);
			}
			catch
			{}
			if(reg==null)
				reg=Registry.CurrentUser.CreateSubKey(s);
			for(int i=0;i<Math.Min(RecentFiles.Count,8);i++)
			{
				if(!Generic.CT(RecentFiles.GetString(i),"Untitled"))
					reg.SetValue(RecentFiles.GetString(i),"");
			}
		}

		private void pc_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Generic.CloseupAllPopupForms();
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			NewReport("Untitled");
			System.GC.Collect();
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			if(FileSystem.OpenDialogExecute())
			{
				for(int i=0;i<FileSystem.Files.Count;i++)
				{
					LoadReport(FileSystem.Files.GetString(i));
				}
			}
			System.GC.Collect();
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			SaveReport();
			System.GC.Collect();
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			FileSystem.FileName=FileName;
			if(FileSystem.SaveDialogExecute())
			{
				FileName=FileSystem.FileName;
				Rep.FileSystem=FileSystem;
				Rep.Save(FileName);
				UpdateCaption();
				Modified=false;
			}
			System.GC.Collect();
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			SaveAll();
			System.GC.Collect();
		}

		bool SaveAll()
		{
			TabPage ps=pc.SelectedTab;
			try
			{
				for(int i=0;i<TemplateList.Count;i++)
				{
					ShowPage(TemplateList.GetString(i));
					if(!SaveReport())
					{
						return false;
					}
				}
			}
			finally
			{
				pc.SelectedTab=ps;
			}
			return true;
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			if(pc.TabCount>1)
				ClosePage(true,true);
			System.GC.Collect();
		}

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			if(Rep.PageSettings())
			{
				Rep.Invalidate();
				Modified=true;
			}
			System.GC.Collect();
		}

		private void menuItem88_Click(object sender, System.EventArgs e)
		{
			SetUnits(Units.MM);
		}

		private void menuItem87_Click(object sender, System.EventArgs e)
		{
			SetUnits(Units.In);
		}

		private void menuItem89_Click(object sender, System.EventArgs e)
		{
			SetUnits(Units.Cm);
		}

		private void menuItem90_Click(object sender, System.EventArgs e)
		{
			SetUnits(Units.Pix);
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
			Rep.Preview();
			System.GC.Collect();
		}

		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			Rep.Print();
			System.GC.Collect();
		}

		private void menuItem22_Click(object sender, System.EventArgs e)
		{
			RepSetFocus();
			Close();
		}

		private void menuItem23_Click(object sender, System.EventArgs e)
		{
			try
			{
				FSetUndo=false;
				if(Undo.CanUndo())
				{
					StringList sl=new StringList("");
					sl.SetText(Undo.GetUndo());
					Rep.Template=sl;
					Rep.ClearSel();

					Rep.CurrBandIdx=Math.Min(Rep.CurrBandIdx,Rep.SrcRep.BandCount-1);
					Rep.CurrCellIdx=Math.Min(Rep.CurrCellIdx,Rep.CurrBand.CellCount-1);
					Rep.SelAdd(Rep.CurrBandIdx,Rep.CurrCellIdx);

					Modified=true;
				}
			}
			finally
			{
				Rep.Invalidate();
				FSetUndo=true;
			}
		}

		private void menuItem24_Click(object sender, System.EventArgs e)
		{
			try
			{
				FSetUndo=false;
				if(Undo.CanRedo())
				{
					StringList sl=new StringList("");
					sl.SetText(Undo.GetRedo());
					Rep.Template=sl;
					Rep.ClearSel();

					Rep.CurrBandIdx=Math.Min(Rep.CurrBandIdx,Rep.SrcRep.BandCount-1);
					Rep.CurrCellIdx=Math.Min(Rep.CurrCellIdx,Rep.CurrBand.CellCount-1);
					Rep.SelAdd(Rep.CurrBandIdx,Rep.CurrCellIdx);

					Modified=true;
					UpdateButtons();
				}
			}
			finally
			{
				Rep.Invalidate();
				FSetUndo=true;
			}
		}

		private void menuItem26_Click(object sender, System.EventArgs e)
		{
			Rep.SelAll();
		}

		private void menuItem27_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg=new OpenFileDialog();
			dlg.Filter="All (*.bmp;*.jpeg;*.jpg*.ico)|*.bmp;*.jpeg;*.jpg*;.ico|Bitmaps (*.bmp)|*.bmp|Jpeg (*.jpeg;*.jpg*)|*.jpeg;*.jpg*;|Icons (*.ico)|*.ico";
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					Rep.GetSel(i).PictureFileName=dlg.FileName;
				}
				Invalidate();
				Modified=true;
			}
		}

		private void menuItem28_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).AutoSize=!Rep.GetSel(i).AutoSize;
				if(Rep.GetSel(i).Picture!=null)
					Rep.Invalidate();
			}
			Modified=true;
		}

		private void menuItem30_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).Tile=!Rep.GetSel(i).Tile;
				if(Rep.GetSel(i).Picture!=null)
					Rep.Invalidate();
			}
			Modified=true;
		}

		private void menuItem31_Click(object sender, System.EventArgs e)
		{
			if(Rep.CurrBand!=null)
			{
				Rep.CurrBand.sender=true;
				Rep.CurrBand.NewCell();
				Rep.CurrCellIdx=Rep.CurrBand.CellCount-1;
				Rep.ClearSel();
				Rep.SelAdd(Rep.CurrBandIdx,Rep.CurrCellIdx);
				Modified=true;
				Rep.Invalidate();
			}
		}

		private void menuItem32_Click(object sender, System.EventArgs e)
		{
			if((Rep.Focus())&&(Rep.SelCount>0))
			{
				Rep.DeleteSelCells();
				Rep.SelAdd(Rep.CurrBandIdx,Rep.CurrCellIdx);
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem33_Click(object sender, System.EventArgs e)
		{
			bool ismodified=false;

			if(Rep.SelCount>0)
			{
				for(int idxband=0;idxband<Rep.SrcRep.BandCount;idxband++)
				{
					for(int idxcell=1;idxcell<Rep.SrcRep.GetBand(idxband).CellCount;idxcell++)
					{
						if(Rep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
						{
							Rep.SrcRep.GetBand(idxband).MoveCell(idxcell,idxcell-1);
							ismodified=true;
						}
					}
				}
			}
			else
			{
				if(Rep.CurrCellIdx>0)
				{
					Rep.SrcRep.GetBand(Rep.CurrBandIdx).MoveCell(Rep.CurrCellIdx,Rep.CurrCellIdx-1);
					ismodified=true;
				}
			}
			if(ismodified)
			{
				Rep.CurrCellIdx=Rep.CurrCellIdx-1;
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem34_Click(object sender, System.EventArgs e)
		{
			bool ismodified=false;

			if(Rep.SelCount>0)
			{
				for(int idxband=0;idxband<Rep.SrcRep.BandCount;idxband++)
				{
					for(int idxcell=Rep.SrcRep.GetBand(idxband).CellCount-2;idxcell>-1;idxcell--)
					{
						if(Rep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
						{
							Rep.SrcRep.GetBand(idxband).MoveCell(idxcell,idxcell+1);
							ismodified=true;
						}
					}
				}
			}
			else
			{
				if(Rep.CurrCellIdx<Rep.SrcRep.GetBand(Rep.CurrBandIdx).CellCount-1)
				{
					Rep.SrcRep.GetBand(Rep.CurrBandIdx).MoveCell(Rep.CurrCellIdx,Rep.CurrCellIdx+1);
					ismodified=true;
				}
			}
			if(ismodified)
			{
				Rep.CurrCellIdx=Rep.CurrCellIdx+1;
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem36_Click(object sender, System.EventArgs e)
		{
			StringList sl=new StringList("EditorMain sl");
			for(int i=0;i<Rep.SelCount;i++)
			{
				sl.AddStrings(Rep.GetSel(i).Template);
			}
			Clipboard.SetDataObject(sl.GetText(),false);
		}

		private void menuItem37_Click(object sender, System.EventArgs e)
		{
			menuItem36_Click(sender,e);
			menuItem32_Click(sender,e);
		}

		private void menuItem38_Click(object sender, System.EventArgs e)
		{
			StringList sl=new StringList("EditorMain sl");
			int idxcell;
			
			if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
				sl.SetText((string)Clipboard.GetDataObject().GetData(DataFormats.Text));
			if((sl.Count>0)&&(Generic.CT(sl.GetString(0).Trim(),"<CELL>")))
			{
				sl.InsertString(0,"<BAND>");
				sl.Add("</BAND>");
				XmlNodeList nodelist;
				StringReader reader=new StringReader(sl.GetText());
				XmlDocument doc=new XmlDocument();
				doc.Load(reader);
				nodelist=doc.SelectNodes("BAND/CELL");
				idxcell=Rep.CurrCellIdx;
				for(int i=0;i<nodelist.Count;i++)
				{					
					Rep.CurrBand.NewCell();
					Rep.CurrBand.MoveCell(Rep.CurrBand.CellCount-1,idxcell);
					Rep.CurrCellIdx=idxcell;
					Rep.CurrCell.ApplyCell(nodelist[i]);
					idxcell++;
					Rep.CurrCell.Width=(int)(Rep.CurrCell.Width*Generic.ZoomFactor);
				}
				float widthcount=0;
				for(int i=0;i<Rep.CurrBand.CellCount;i++)
				{
					widthcount=widthcount+Rep.CurrBand.GetCell(i).Width;
				}
				float WidthCount;
				for(int i=0;i<Rep.CurrBand.CellCount;i++)
				{
					if(i==Rep.CurrBand.CellCount-1)
					{
						WidthCount=0;
						for(int idxcell2=0;idxcell2<Rep.CurrBand.CellCount-1;idxcell2++)
						{
							WidthCount=WidthCount+Rep.CurrBand.GetCell(idxcell2).Width;
						}
						Rep.CurrBand.GetCell(i).Width=Rep.SrcRep.NewWidth-WidthCount-Generic.ToPix(Rep.SrcRep.LeftMargin)-Generic.ToPix(Rep.SrcRep.RightMargin)-1;
					}
					else
					{
						double WidthRatio=(double)(widthcount)/(double)Rep.CurrBand.GetCell(i).Width;
						Rep.CurrBand.GetCell(i).Width=(int)Math.Round((double)(Rep.SrcRep.NewWidth-Generic.ToPix(Rep.SrcRep.LeftMargin)-Generic.ToPix(Rep.SrcRep.RightMargin))/WidthRatio,0);
					}
				}
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem40_Click(object sender, System.EventArgs e)
		{
			if((Rep.CurrBand!=null)&&(Rep.CurrCell!=null))
			{
				Rep.CurrBand.Split(Rep.CurrCell);
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem41_Click(object sender, System.EventArgs e)
		{
			if(Rep.MergeSelectedCells())
			{
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem42_Click(object sender, System.EventArgs e)
		{
			int idxband, idxcell, idxband2, idxcell2;
			float l,r;
			Cell cell;

			try
			{
				for(idxband=0;idxband<Rep.SrcRep.BandCount;idxband++)
				{
					if(Rep.SrcRep.GetBand(idxband).Selected)
					{
						for(idxcell=0;idxcell<Rep.SrcRep.GetBand(idxband).CellCount;idxcell++)
						{
							if(Rep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
							{
								cell=Rep.SrcRep.GetBand(idxband).GetCell(idxcell);
								l=Rep.SrcRep.GetBand(idxband).GetLefts(idxcell);
								r=Rep.SrcRep.GetBand(idxband).GetRights(idxcell);

								for(idxband2=idxband+1;idxband2<Rep.SrcRep.BandCount;idxband2++)
								{
									if(!(Rep.SrcRep.GetBand(idxband2).Selected))
									{
										cell.Focused=true;
										return;
									}
									for(idxcell2=0;idxcell2<Rep.SrcRep.GetBand(idxband2).CellCount;idxcell2++)
									{
										if((Rep.SrcRep.GetBand(idxband2).GetCell(idxcell2).Selected)&&
											(Rep.SrcRep.GetBand(idxband2).GetLefts(idxcell2)==l)&&
											(Rep.SrcRep.GetBand(idxband2).GetRights(idxcell2)==r))
										{
											Rep.SrcRep.GetBand(idxband2).GetCell(idxcell2).Shared=true;
											Rep.SrcRep.GetBand(idxband2).BandChange(this,EventArgs.Empty);
											break;
										}
									}
								}
							}
						}
					}
				}
			}
			finally
			{
				Modified=true;
				RepSetFocus();
				Rep.Refresh();
			}
		}

		private void UpdateButtons()
		{
			bool bold,italic,underline;
			bool toplayout,centerlayout,bottomlayout;
			bool leftalign,centeralign,rightalign;
			bool notframe;
			bool tile,wordwrap,fittocell;
			bool LockCell,LockBand;

			if(Rep.CurrCell!=null)
			{
				if(Rep.SelCount>0)
				{
					bold=Rep.GetSel(0).FontStyle.ToString().IndexOf("Bold")!=-1;
					italic=Rep.GetSel(0).FontStyle.ToString().IndexOf("Italic")!=-1;
					underline=Rep.GetSel(0).FontStyle.ToString().IndexOf("Underline")!=-1;

					LockBand=Rep.CurrBand.LockHeight;
					LockCell=Rep.GetSel(0).LockWidth;
					
					toplayout=Rep.GetSel(0).VAlign==VAlign.Top;
					centerlayout=Rep.GetSel(0).VAlign==VAlign.Center;
					bottomlayout=Rep.GetSel(0).VAlign==VAlign.Bottom;

					leftalign=Rep.GetSel(0).HAlign==HAlign.Left;
					centeralign=Rep.GetSel(0).HAlign==HAlign.Center;
					rightalign=Rep.GetSel(0).HAlign==HAlign.Right;

					notframe=Rep.GetSel(0).FrameStyle==(FrameStyles)0;

					tile=Rep.GetSel(0).Tile;
					wordwrap=Rep.GetSel(0).WordWrap;
					fittocell=Rep.GetSel(0).AutoSize;

					for(int i=0;i<Rep.SelCount;i++)
					{
						bold=(bold &&(Rep.GetSel(i).FontStyle.ToString().IndexOf("Bold")!=-1));
						italic=(italic &&(Rep.GetSel(i).FontStyle.ToString().IndexOf("Italic")!=-1));
						underline=(underline &&(Rep.GetSel(i).FontStyle.ToString().IndexOf("Underline")!=-1));

						LockCell=LockCell && Rep.GetSel(i).LockWidth;

						notframe=(notframe &&(Rep.GetSel(i).FrameStyle==(FrameStyles)0));

						toplayout=(toplayout && (Rep.GetSel(i).VAlign==VAlign.Top));
						centerlayout=(centerlayout && (Rep.GetSel(i).VAlign==VAlign.Center));
						bottomlayout=(bottomlayout && (Rep.GetSel(i).VAlign==VAlign.Bottom));

						leftalign=(leftalign && (Rep.GetSel(i).HAlign==HAlign.Left));
						centeralign=(centeralign && (Rep.GetSel(i).HAlign==HAlign.Center));
						rightalign=(rightalign && (Rep.GetSel(i).HAlign==HAlign.Right));

						tile=(tile && (Rep.GetSel(i).Tile));
						wordwrap=(wordwrap && (Rep.GetSel(i).WordWrap));
						fittocell=(fittocell && (Rep.GetSel(i).AutoSize));
					}
					menuItem75.Checked=notframe;

					statusBar1.Panels[1].Text=String.Format("{0:F2}-{1:F2} {2}",Generic.ConvertUnits(Rep.CurrCell.Width/Generic.ZoomFactor,Units.Pix,Units),Generic.ConvertUnits(Rep.CurrBand.Height/Generic.ZoomFactor,Units.Pix,Units),Generic.UnitsShortName(Units));

					menuItem62.Checked=bold;
					menuItem63.Checked=italic;
					menuItem64.Checked=underline;

					if(LockCell)
						menuItem85.Text="Un&lock cell width";
					else
						menuItem85.Text="&Lock cell width";
					if(LockBand)
						menuItem98.Text="Un&lock band height";
					else
						menuItem98.Text="&Lock band height";

					menuItem72.Checked=toplayout;
					menuItem73.Checked=centerlayout;
					menuItem74.Checked=bottomlayout;

					menuItem68.Checked=leftalign;
					menuItem69.Checked=centeralign;
					menuItem70.Checked=rightalign;

					menuItem30.Checked=tile;
					menuItem46.Checked=wordwrap;
					menuItem28.Checked=fittocell;
				}
			}
			else
				statusBar1.Panels[1].Text="";
			
			menuItem115.Checked=Rep.Zoom==Zoom.fifty;				
			menuItem117.Checked=Rep.Zoom==Zoom.hundred;			
			menuItem121.Checked=Rep.Zoom==Zoom.hundredfifty;				
			menuItem120.Checked=Rep.Zoom==Zoom.pagewidth;				
			menuItem116.Checked=Rep.Zoom==Zoom.seventyfive;				
			menuItem122.Checked=Rep.Zoom==Zoom.twohundred;				
			menuItem119.Checked=Rep.Zoom==Zoom.wholepage;

			Generic.CloseupAllPopupForms();
		}

		private void menuItem46_Click(object sender, System.EventArgs e)
		{
			menuItem46.Checked=!menuItem46.Checked;
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).WordWrap=menuItem46.Checked;
			}
			Modified=true;
			Rep.Invalidate();
		}

		private void menuItem48_Click(object sender, System.EventArgs e)
		{
			if(Rep.Focused)
			{
				ShowCellEditor(Rep.CurrBandIdx,Rep.CurrCellIdx,(char)0);
			}
			else
			{
				if(CellEditor.Focused)
					RepSetFocus();
			}
		}

		private void menuItem50_Click(object sender, System.EventArgs e)
		{
			Rep.sender=true;
			Rep.NewBand();
			Rep.ClearSel();
			Rep.CurrBandIdx=Rep.SrcRep.BandCount-1;
			Rep.SelAdd(Rep.CurrBandIdx,Rep.CurrCellIdx);
			Modified=true;
			Invalidate();
		}

		private void menuItem51_Click(object sender, System.EventArgs e)
		{
			for(int idxband=Rep.SrcRep.BandCount-1;idxband>-1;idxband--)
			{
				if(Rep.SrcRep.GetBand(idxband).Selected)
				{
					Rep.DeleteBand(idxband);
				}
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem52_Click(object sender, System.EventArgs e)
		{
			bool IsModified=false;

			for(int idxband=0;idxband<Rep.SrcRep.BandCount;idxband++)
			{
				if(Rep.SrcRep.GetBand(idxband).Selected)
				{
					if(!Rep.SrcRep.MoveBand(idxband,idxband-1))
						break;
					IsModified=true;
				}
			}
			if(IsModified)
			{
				Rep.CurrBandIdx=Rep.CurrBandIdx-1;
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem53_Click(object sender, System.EventArgs e)
		{
			bool IsModified=false;

			for(int idxband=Rep.SrcRep.BandCount-1;idxband>-1;idxband--)
			{
				if(Rep.SrcRep.GetBand(idxband).Selected)
				{
					if(!Rep.SrcRep.MoveBand(idxband,idxband+1))
						break;
					IsModified=true;
				}
			}
			if(IsModified)
			{
				Rep.CurrBandIdx=Rep.CurrBandIdx+1;
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem55_Click(object sender, System.EventArgs e)
		{
			StringList sl=new StringList("EditorDlg sl");
			for(int idxband=0;idxband<Rep.SrcRep.BandCount;idxband++)
			{
				if(Rep.SrcRep.GetBand(idxband).Selected)
				{
					sl.AddStrings(Rep.SrcRep.GetBand(idxband).Template);
				}
			}
			Clipboard.SetDataObject(sl.GetText(),false);
		}

		private void menuItem56_Click(object sender, System.EventArgs e)
		{
			menuItem55_Click(sender,e);
			menuItem51_Click(sender,e);
		}

		private void menuItem57_Click(object sender, System.EventArgs e)
		{
			StringList sl=new StringList("EditorDlg sl");
			int idxband;

			if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
				sl.SetText((string)Clipboard.GetDataObject().GetData(DataFormats.Text));
			if((sl.Count>0)&&(Generic.CT(sl.GetString(0).Trim(),"<BAND>")))
			{
				sl.InsertString(0,"<REP>");
				sl.Add("</REP>");
				XmlNodeList nodelist;
				StringReader reader=new StringReader(sl.GetText());
				XmlDocument doc=new XmlDocument();
				doc.Load(reader);
				nodelist=doc.SelectNodes("REP/BAND");
				idxband=Rep.CurrBandIdx;
				for(int m=0;m<nodelist.Count;m++)
				{
					Rep.NewBand();
					Rep.SrcRep.MoveBand(Rep.SrcRep.BandCount-1,idxband);
					Rep.CurrBandIdx=idxband;
					Rep.CurrBand.ApplyBand(nodelist[m]);
					idxband++;
					Rep.CurrBand.Height=(int)(Rep.CurrBand.Height*Generic.ZoomFactor);
					float WidthCount;
					float widthcount=0;
					for(int i=0;i<Rep.CurrBand.CellCount;i++)
					{
						widthcount=widthcount+Rep.CurrBand.GetCell(i).Width;
					}
					for(int i=0;i<Rep.CurrBand.CellCount;i++)
					{
						if(i==Rep.CurrBand.CellCount-1)
						{
							WidthCount=0;
							for(int idxcell2=0;idxcell2<Rep.CurrBand.CellCount-1;idxcell2++)
							{
								WidthCount=WidthCount+Rep.CurrBand.GetCell(idxcell2).Width;
							}
							Rep.CurrBand.GetCell(i).Width=Rep.SrcRep.NewWidth-WidthCount-Generic.ToPix(Rep.SrcRep.LeftMargin)-Generic.ToPix(Rep.SrcRep.RightMargin)-1;
						}
						else
						{
							double WidthRatio=(double)(widthcount)/(double)Rep.CurrBand.GetCell(i).Width;
							Rep.CurrBand.GetCell(i).Width=(int)Math.Round((double)(Rep.SrcRep.NewWidth-Generic.ToPix(Rep.SrcRep.LeftMargin)-Generic.ToPix(Rep.SrcRep.RightMargin))/WidthRatio,0);
						}
					}
				}
				float heigthcount=0;
				for(int i=0;i<Rep.SrcRep.BandCount;i++)
				{
					heigthcount=heigthcount+Rep.SrcRep.GetBand(i).Height;
				}
				float HeightCount=0;				
				for(int i=0;i<Rep.SrcRep.BandCount;i++)
				{
					if(i==Rep.SrcRep.BandCount-1)
					{
						for(int idxband2=0;idxband2<Rep.SrcRep.BandCount-1;idxband2++)
						{
							HeightCount=HeightCount+Rep.SrcRep.GetBand(idxband2).Height;
						}
						Rep.SrcRep.GetBand(i).Height=Rep.SrcRep.NewHeight-HeightCount-Generic.ToPix(Rep.SrcRep.TopMargin)-Generic.ToPix(Rep.SrcRep.BottomMargin)-1;							
					}
					else
					{
						double HeightRatio=(double)(heigthcount)/(double)Rep.SrcRep.GetBand(i).Height;
						Rep.SrcRep.GetBand(i).Height=(int)Math.Round((double)(Rep.SrcRep.NewHeight-Generic.ToPix(Rep.SrcRep.TopMargin)-Generic.ToPix(Rep.SrcRep.BottomMargin))/HeightRatio,0);
					}
				}
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem59_Click(object sender, System.EventArgs e)
		{
			if(Rep.Focused)
			{
				ShowBandEditor(Rep.CurrBandIdx);
			}
			else
			{
				if(CellEditor.Focused)
				{
					RepSetFocus();
				}
			}
		}

		private void menuItem60_Click(object sender, System.EventArgs e)
		{
			if(Rep.SelCount>0)
			{
				fontDialog.Font=new Font(Rep.CurrCell.FontName,
					Rep.CurrCell.FontSize,Rep.CurrCell.FontStyle);
				fontDialog.ShowColor=true;
				fontDialog.Color=Rep.CurrCell.FontColor;
				if(fontDialog.ShowDialog()==DialogResult.OK)
				{
					for(int i=0;i<Rep.SelCount;i++)
					{
						Rep.GetSel(i).FontName=fontDialog.Font.Name;
						Rep.GetSel(i).FontSize=fontDialog.Font.Size;
						Rep.GetSel(i).FontStyle=fontDialog.Font.Style;
						Rep.GetSel(i).FontColor=fontDialog.Color;
					}
				}
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem61_Click(object sender, System.EventArgs e)
		{
			colorDialog.Color=Rep.CurrCell.FontColor;
			if(colorDialog.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					Rep.GetSel(i).FontColor=colorDialog.Color;
				}
				Rep.Invalidate();
				Modified=true;
				RepSetFocus();
			}
		}

		private void menuItem62_Click(object sender, System.EventArgs e)
		{
			menuItem62.Checked=!menuItem62.Checked;
			for(int i=0;i<Rep.SelCount;i++)
			{
				if(menuItem62.Checked)
					Rep.GetSel(i).FontStyle|=FontStyle.Bold;
				else
					Rep.GetSel(i).FontStyle=Rep.GetSel(i).FontStyle-(int)FontStyle.Bold;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem63_Click(object sender, System.EventArgs e)
		{
			menuItem63.Checked=!menuItem63.Checked;
			for(int i=0;i<Rep.SelCount;i++)
			{
				if(menuItem63.Checked)
					Rep.GetSel(i).FontStyle|=FontStyle.Italic;
				else
					Rep.GetSel(i).FontStyle=Rep.GetSel(i).FontStyle-(int)FontStyle.Italic;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem64_Click(object sender, System.EventArgs e)
		{
			menuItem64.Checked=!menuItem64.Checked;
			for(int i=0;i<Rep.SelCount;i++)
			{
				if(menuItem64.Checked)
					Rep.GetSel(i).FontStyle|=FontStyle.Underline;
				else
					Rep.GetSel(i).FontStyle=Rep.GetSel(i).FontStyle-(int)FontStyle.Underline;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem65_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).FontSize=Rep.GetSel(i).FontSize+1;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem66_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).FontSize=Math.Max(1,Rep.GetSel(i).FontSize-1);
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem68_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).HAlign=HAlign.Left;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem69_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).HAlign=HAlign.Center;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem70_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).HAlign=HAlign.Right;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem72_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).VAlign=VAlign.Top;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem73_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).VAlign=VAlign.Center;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem74_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).VAlign=VAlign.Bottom;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem75_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<Rep.SelCount;i++)
			{
				Rep.GetSel(i).FrameStyle=(FrameStyles)0;
			}
			Rep.Invalidate();
			Modified=true;
		}

		private void menuItem76_Click(object sender, System.EventArgs e)
		{
			Borderdlg d=new Borderdlg();
			d.Text="Left border";			
			d.comboBox3.SelectedItem=Rep.CurrCell.GetFrameWidths(0).ToString();
			d.Color=Rep.CurrCell.GetFrameColors(0);
			d.comboBox2.SelectedItem=Rep.CurrCell.GetBorderStyles(0);

			if(d.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					Rep.GetSel(i).SetFrameColors(0,d.Color);
					Rep.GetSel(i).SetFrameWidths(0,Convert.ToInt32(d.comboBox3.SelectedItem.ToString()));
					Rep.GetSel(i).SetBorderStyles(0,(LineStyle)d.comboBox2.SelectedItem);					
				}
				Modified=true;
			}
			Rep.Refresh();
			d.Dispose();			
		}

		private void menuItem78_Click(object sender, System.EventArgs e)
		{
			Borderdlg d=new Borderdlg();
			d.Text="Right border";			
			d.comboBox3.SelectedItem=Rep.CurrCell.GetFrameWidths(2).ToString();
			d.Color=Rep.CurrCell.GetFrameColors(2);
			d.comboBox2.SelectedItem=Rep.CurrCell.GetBorderStyles(2);

			if(d.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					Rep.GetSel(i).SetFrameColors(2,d.Color);
					Rep.GetSel(i).SetFrameWidths(2,Convert.ToInt32(d.comboBox3.SelectedItem.ToString()));
					Rep.GetSel(i).SetBorderStyles(2,(LineStyle)d.comboBox2.SelectedItem);
				}
				Modified=true;
			}
			Rep.Refresh();
			d.Dispose();	
		}

		private void menuItem80_Click(object sender, System.EventArgs e)
		{
			Borderdlg d=new Borderdlg();
			d.Text="Top border";			
			d.comboBox3.SelectedItem=Rep.CurrCell.GetFrameWidths(1).ToString();
			d.Color=Rep.CurrCell.GetFrameColors(1);
			d.comboBox2.SelectedItem=Rep.CurrCell.GetBorderStyles(1);

			if(d.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					Rep.GetSel(i).SetFrameColors(1,d.Color);
					Rep.GetSel(i).SetFrameWidths(1,Convert.ToInt32(d.comboBox3.SelectedItem.ToString()));
					Rep.GetSel(i).SetBorderStyles(1,(LineStyle)d.comboBox2.SelectedItem);
				}
				Modified=true;
			}
			Rep.Refresh();
			d.Dispose();	
		}

		private void menuItem82_Click(object sender, System.EventArgs e)
		{
			Borderdlg d=new Borderdlg();
			d.Text="Bottom border";			
			d.comboBox3.SelectedItem=Rep.CurrCell.GetFrameWidths(3).ToString();
			d.Color=Rep.CurrCell.GetFrameColors(3);
			d.comboBox2.SelectedItem=Rep.CurrCell.GetBorderStyles(3);

			if(d.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					Rep.GetSel(i).SetFrameColors(3,d.Color);
					Rep.GetSel(i).SetFrameWidths(3,Convert.ToInt32(d.comboBox3.SelectedItem.ToString()));
					Rep.GetSel(i).SetBorderStyles(3,(LineStyle)d.comboBox2.SelectedItem);
				}
				Modified=true;
			}
			Rep.Refresh();
			d.Dispose();	
		}

		private void menuItem79_Click(object sender, System.EventArgs e)
		{
			Borderdlg d=new Borderdlg();
			d.Text="All border";			
			d.comboBox3.SelectedItem=Rep.CurrCell.FrameWidth.ToString();
			d.Color=Rep.CurrCell.FrameColor;
			d.comboBox2.SelectedItem=Rep.CurrCell.BorderStyle;

			if(d.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					for(int y=0;y<4;y++)
					{
						Rep.GetSel(i).SetFrameColors(y,d.Color);
						Rep.GetSel(i).SetFrameWidths(y,Convert.ToInt32(d.comboBox3.SelectedItem.ToString()));
						Rep.GetSel(i).SetBorderStyles(y,(LineStyle)d.comboBox2.SelectedItem);
					}
				}
				Modified=true;
			}
			Rep.Refresh();
			d.Dispose();	
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			Preferences d=new Preferences();
			d.Units=Units;
			d.GridX=GridX;
			d.GridY=GridY;
			if(d.ShowDialog()==DialogResult.OK)
			{
				GridX=d.GridX;
				GridY=d.GridX;
			}
		}

		private void menuItem84_Click(object sender, System.EventArgs e)
		{
			fontDialog.Font=Rep.SrcRep.Font;
			if(fontDialog.ShowDialog()==DialogResult.OK)
			{
				Rep.SrcRep.Font=fontDialog.Font;
				Rep.Invalidate();
				Modified=true;
			}
		}

		private void menuItem91_Click(object sender, System.EventArgs e)
		{
			Generic.ShowHiddenItems=!Generic.ShowHiddenItems;
			Generic.NonPrinting=true;
			menuItem91.Checked=Generic.ShowHiddenItems;
			Rep.Invalidate();
		}

		private void menuItem93_Click(object sender, System.EventArgs e)
		{
			FFileSystem.ExecuteSetup();
		}

		private void menuItem94_Click(object sender, System.EventArgs e)
		{
			ShowHelpPage();
		}

		void ShowHelpPage()
		{
			AxSHDocVw.AxWebBrowser WB;
			TabPage ps;
			object arg1 = 0; object arg2 = ""; object arg3 = ""; object arg4 = "";

			for(int i=0;i<pc.TabCount;i++)
			{
				ps=pc.TabPages[i];
				if((int)ps.Tag==(int)PageType.Help)
				{
					pc.SelectedTab=ps;
					for(int j=0;j<ps.Controls.Count;j++)
					{
						if(ps.Controls[j] is AxSHDocVw.AxWebBrowser)
						{
							((AxSHDocVw.AxWebBrowser)ps.Controls[j]).Navigate(@"file:///"+Application.StartupPath+@"/Help/Reference.htm",ref arg1,ref arg2, ref arg3, ref arg4);
							Text=((AxSHDocVw.AxWebBrowser)ps.Controls[j]).LocationURL;
							return;
						}
					}
				}
			}
			ps=NewPage(PageType.Help);
			WB=new AxSHDocVw.AxWebBrowser();
			WB.Parent=ps;
			WB.Dock=DockStyle.Fill;
			
			WB.Navigate(@"file:///"+Application.StartupPath+@"/Help/Reference.htm",ref arg1,ref arg2, ref arg3, ref arg4);
			Text=WB.LocationURL;

		}

		private void menuItem95_Click(object sender, System.EventArgs e)
		{
			About d=new About();
			d.ShowDialog();
		}

		private void menuItem83_Click(object sender, System.EventArgs e)
		{
			ShapeDialog d=new ShapeDialog();	
			if(Rep.CurrCell.Shape==false)
			{
				d.comboBox2.SelectedIndex=0;
				d.comboBox1.SelectedIndex=0;
				d.comboBox3.SelectedIndex=0;
			}
			else
			{
				d.comboBox2.SelectedItem=Rep.CurrCell.ShapeType;
				d.BackgroundColor=Rep.CurrCell.ShapeColor;
				d.BorderColor=Rep.CurrCell.ShapeBorderColor;
				d.textBox1.Text=Rep.CurrCell.ShapeBorderWidth.ToString();
				d.comboBox3.SelectedItem=Rep.CurrCell.ShapeBorderStyle;
				if(Rep.CurrCell.ShapeGraident==false)
					d.comboBox1.SelectedIndex=0;
				else
				{
					d.comboBox1.SelectedItem=Rep.CurrCell.ShapeFillDirection;
					d.GraidentColor=Rep.CurrCell.ShapeGraidentColor;
				}
			}

			if(d.ShowDialog()==DialogResult.OK)
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					if(d.comboBox2.SelectedIndex==0)
						Rep.GetSel(i).Shape=false;
					else
					{
						Rep.GetSel(i).Shape=true;
						Rep.GetSel(i).ShapeColor=d.BackgroundColor;
						Rep.GetSel(i).ShapeType=((ShapeType)d.comboBox2.SelectedItem);
						Rep.GetSel(i).ShapeBorderColor=d.BorderColor;
						Rep.GetSel(i).ShapeBorderStyle=((System.Drawing.Drawing2D.DashStyle)d.comboBox3.SelectedItem);
						try
						{
							Rep.GetSel(i).ShapeBorderWidth=Convert.ToInt32(d.textBox1.Text);
						}
						catch
						{
							Rep.GetSel(i).ShapeBorderWidth=0;
						}
						if(d.comboBox1.SelectedIndex==0)
							Rep.GetSel(i).ShapeGraident=false;
						else
						{
							Rep.GetSel(i).ShapeGraident=true;
							Rep.GetSel(i).ShapeGraidentColor=d.GraidentColor;
							Rep.GetSel(i).ShapeFillDirection=((FillDirection)d.comboBox1.SelectedItem);
						}
					}
				}
				Modified=true;
			}
			Rep.Refresh();
			d.Dispose();
		}

		private void menuItem81_Click(object sender, System.EventArgs e)
		{
			GraidentDialog d=new GraidentDialog();
			if(!Rep.SrcRep.PageGraident)
			{
				d.comboBox1.SelectedIndex=0;
				d.BackgroundColor=Rep.SrcRep.PageColor;
			}
			else
			{
				d.comboBox1.SelectedItem=Rep.SrcRep.PageFillDirection;
				d.BackgroundColor=Rep.SrcRep.PageColor;
				d.GraidentColor=Rep.SrcRep.PageGraidentColor;
			}

			if(d.ShowDialog()==DialogResult.OK)
			{
				if(d.comboBox1.SelectedIndex==0)
					Rep.SrcRep.PageGraident=false;
				else
				{
					Rep.SrcRep.PageGraident=true;
					Rep.SrcRep.PageGraidentColor=d.GraidentColor;
					Rep.SrcRep.PageFillDirection=((FillDirection)d.comboBox1.SelectedItem);
				}
				Rep.SrcRep.PageColor=d.BackgroundColor;
				Modified=true;
				Refresh();
			}
		}

		private void menuItem112_Click(object sender, System.EventArgs e)
		{
			PageBackground d=new PageBackground();
			d.textBox4.Text=Rep.SrcRep.PagePictureFileName;
			d.checkBox1.Checked=Rep.SrcRep.PageLinkPictureToFile;
			d.comboBox1.SelectedIndex=(int)Rep.SrcRep.PageImagePosition;
			if(d.ShowDialog()==DialogResult.OK)
			{
				if(d.checkBox1.Checked)
				{
					Rep.SrcRep.PageLinkPictureToFile=true;
					Rep.SrcRep.PagePictureFileName=d.textBox4.Text;
				}
				else
				{
					Rep.SrcRep.PageLinkPictureToFile=false;
					try
					{
						Rep.SrcRep.PagePicture=new Bitmap(d.textBox4.Text);
					}
					catch
					{
						d.textBox4.Text="";
					}
					Rep.SrcRep.PagePictureFileName="";
				}
				
				Rep.SrcRep.PageImagePosition=(ImagePosition)d.comboBox1.SelectedItem;
				if(d.textBox4.Text!="")
					Rep.SrcRep.PageImage=true;
				else
				{
					Rep.SrcRep.PageImage=false;
				}
				Modified=true;
				Refresh();
			}
		}

		private void menuItem115_Click(object sender, System.EventArgs e)
		{
			Rep.Zoom=Zoom.fifty;
			Zoom=Zoom.fifty;
			UpdateRulerBars();
			UpdateButtons();
			Refresh();
		}

		private void menuItem117_Click(object sender, System.EventArgs e)
		{
			Rep.Zoom=Zoom.hundred;
			Zoom=Zoom.hundred;
			UpdateRulerBars();
			UpdateButtons();
			Refresh();
		}

		private void menuItem119_Click(object sender, System.EventArgs e)
		{
			Rep.Zoom=Zoom.wholepage;
			Zoom=Zoom.wholepage;
			UpdateRulerBars();
			UpdateButtons();
			Refresh();
		}

		private void menuItem120_Click(object sender, System.EventArgs e)
		{
			Rep.Zoom=Zoom.pagewidth;
			Zoom=Zoom.pagewidth;
			UpdateRulerBars();
			UpdateButtons();
			Refresh();
		}

		private void menuItem116_Click(object sender, System.EventArgs e)
		{
			Rep.Zoom=Zoom.seventyfive;
			Zoom=Zoom.seventyfive;
			UpdateRulerBars();
			UpdateButtons();
			Refresh();		
		}

		private void menuItem121_Click(object sender, System.EventArgs e)
		{
			Rep.Zoom=Zoom.hundredfifty;
			Zoom=Zoom.hundredfifty;
			UpdateRulerBars();
			UpdateButtons();
			Refresh();
		}

		private void menuItem122_Click(object sender, System.EventArgs e)
		{
			Rep.Zoom=Zoom.twohundred;
			Zoom=Zoom.twohundred;
			UpdateRulerBars();
			UpdateButtons();
			Refresh();
		}

		private void menuItem123_Click(object sender, System.EventArgs e)
		{
			menuItem123.Checked=!menuItem123.Checked;
			Rep.ShowMargins=menuItem123.Checked;
			Refresh();
		}

		bool NewReport(string AFileName)
		{
			string s=AFileName.Trim();
			if(Rep!=null && Rep.Zoom!=Zoom.hundred)
				Rep.Zoom=Zoom.hundred;
			TemplateList.AddObject(s,NewPage(PageType.Template));
			
			FileName=s;
			if(s=="Untitled")
			{
				Rep.Visible=true;
				Rep.Zoom=Zoom;
				Rep.Refresh();
				UpdateButtons();
			}
			Modified=false;
			return true;
		}

		protected TabPage NewPage(PageType value)
		{
			TabPage freturn;
			switch(value)
			{
				case PageType.Template:
					freturn=NewTemplatePage();
					break;
				case PageType.Help:
					freturn=NewHelpPage();
					break;
				case PageType.Preview:
					freturn=null;
					break;
				case PageType.Script:
					freturn=null;
					break;
				default:
					freturn=null;
					break;
			}
			menuItem15.Enabled=pc.TabCount>1;
			menuItem99.Enabled=pc.TabCount>1;
			return freturn;
		}

		protected TabPage NewTemplatePage()
		{
			TabPage Freturn=new TabPage();
			pc.Controls.Add(Freturn);
			Freturn.Tag=(int)PageType.Template;
			pc.SelectedTab=Freturn;			

			FRep=new EditRep();
			FRep.Visible=false;
			FRep.Dock=DockStyle.Fill;

			FRep.Parent=Freturn;
			VRB.Parent=Freturn;
			HRB.Parent=Freturn;

			FRep.SelectedCellStyle=SelectedCellStyle.Gray;
			FRep.FocusedCellStyle=FocusedCellStyle.Rect;

			FRep.TabStop=true;
			FRep.TabIndex=3;
			FRep.ContextMenu=RepPopupmenu;
			FRep.Options=RepOptions.Editing;
			FRep.BackColor=SystemColors.Control;

			FRep.HScroll+=new EventHandler(RepScroll);
			FRep.VScroll+=new EventHandler(RepScroll);
			FRep.KeyPress+=new KeyPressEventHandler(RepKeyPress);
			FRep.MouseMove+=new MouseEventHandler(RepMouseMove);
			FRep.ResizeBant+=new ResizeBantEventHandler(RepResizeBant);
			FRep.ResizeCell+=new ResizeCellEventHandler(RepResizeCell);
			FRep.ResizeGutter+=new EventHandler(RepResizeGutter);
			FRep.SelectBand+=new SelectBandEventHandler(RepSelectBand);
			FRep.SelectCell+=new SelectCellEventHandler(RepSelectCell);
			FRep.GridSelectCell+=new SelectCellEventHandler(RepSelectCell);
			FRep.DoubleClick+=new EventHandler(menuItem49_Click);
			FRep.Enter+=new EventHandler(EditorDlg_SizeChanged);

			FRep.Undo=new Undo(128);

			Undo.Clear();
			Undo.Add(Rep.Template.GetText());
			return Freturn;
		}

		public void RepScroll(object sender,EventArgs arg)
		{
			UpdateRulerBars();
			RepSetFocus();
		}

		public void RepKeyPress(object sender,KeyPressEventArgs arg)
		{
			if(arg.KeyChar==(char)13)
				ShowCellEditor(Rep.CurrBandIdx,Rep.CurrCellIdx,(char)0);
			else if(Convert.ToInt32(arg.KeyChar)>=(char)32)
				ShowCellEditor(Rep.CurrBandIdx,Rep.CurrCellIdx,arg.KeyChar);	
		}

		void ShowCellEditor(int idxband,int idxcell,char Key)
		{
			RepSetFocus();

			menuItem32.Enabled=false;
			menuItem36.Enabled=false;
			menuItem37.Enabled=false;
			menuItem38.Enabled=false;

			menuItem101.Enabled=false;
			menuItem102.Enabled=false;
			menuItem103.Enabled=false;
			
			Rectangle r=Rectangle.Round(Rep.CellRect(idxband,idxcell));
			Cell cell=Rep.SrcRep.GetCell(idxband,idxcell);
            
			CellEditor.Parent=Rep;			

			CellEditor.Location=new Point(r.Left,r.Top);
			CellEditor.Size=new Size(r.Width,r.Height);
			CellEditor.LostFocus+=new EventHandler(CellEditorChange);
			Cellidx=idxcell;
			Bandidx=idxband;
			CellEditor.BorderStyle=BorderStyle.None;
			switch(cell.HAlign)
			{
				case HAlign.Center:
					CellEditor.TextAlign=HorizontalAlignment.Center;
					break;
				case HAlign.Left:
					CellEditor.TextAlign=HorizontalAlignment.Left;
					break;
				case HAlign.Right:
					CellEditor.TextAlign=HorizontalAlignment.Right;
					break;
			}
			CellEditor.BackColor=Color.White;
			CellEditor.ForeColor=cell.FontColor;
			CellEditor.Font=new Font(cell.FontName,cell.FontSize,cell.FontStyle);
			
			fEnableUpdateEditText=false;
			OldEditValue=cell.Value;
			
			fEnableUpdateEditText=true;
			CellEditor.Visible=true;
			
			if(Key!=(char)0)
			{
				CellEditor.Text="";
				CellEditor.AppendText(Key.ToString());
			}				
			else
			{
				CellEditor.Text=cell.Value;
				CellEditor.SelectAll();
			}
			
			CellEditor.Focus();
			Rep.InEditing=true;
		}

		void CellEditorKeyPress(object sender,KeyPressEventArgs arg)
		{
			if(arg.KeyChar==(char)27)
			{
				CancelEdit();
				RepSetFocus();
			}
			if(arg.KeyChar==(char)13)
			{
				RepSetFocus();
			}
		}

		void BandEditorKeyPress(object sender,KeyPressEventArgs arg)
		{
			if(arg.KeyChar==(char)13)
			{
				RepSetFocus();
			}
		}

		void CancelEdit()
		{
			CellEditor.Text=OldEditValue;
		}

		public void RepMouseMove(object sender,MouseEventArgs arg)
		{
			HRB.Cur=Rep.Left+arg.X+3;
			VRB.Cur=arg.Y+3;
		}

		public void RepResizeBant(object sender,ResizeBantEventArgs arg)
		{
			Rep.Refresh();
			Modified=true;
		}

		public void RepResizeCell(object sender,ResizeCellEventArgs arg)
		{
			Rep.Refresh();
			Modified=true;
		}

		public void RepResizeGutter(object sender,EventArgs arg)
		{
			UpdateRulerBars();
		}

		public void RepSelectBand(object sender,SelectBandEventArgs arg)
		{
			ShowBandEditor(Rep.CurrBandIdx);
			UpdateButtons();
		}

		void ShowBandEditor(int idxband)
		{
			RepSetFocus();

			menuItem32.Enabled=false;
			menuItem36.Enabled=false;
			menuItem37.Enabled=false;
			menuItem38.Enabled=false;

			menuItem101.Enabled=false;
			menuItem102.Enabled=false;
			menuItem103.Enabled=false;

			Rep.CurrBandIdx=idxband;
			Band band=Rep.SrcRep.GetBand(idxband);

			Rectangle r=Rectangle.Round(Rep.CellRect(idxband,0));
			int FLeft=5;
			int FRight=Rep.Gutter-5;
			int FTop=(int)Rep.SrcRep.GetTops(idxband)-Rep.TopY+(idxband)+((int)band.Height-Math.Abs(Rep.SrcRep.Font.Height)-3)/2-2+Generic.ToPix(Rep.SrcRep.TopMargin);
			int FBottom=FTop+Math.Abs(Rep.SrcRep.Font.Height)+3;
            
			BandEditor.Parent=Rep;			

			BandEditor.Location=new Point(FLeft-1,FTop+2);
			BandEditor.Size=new Size(FRight-FLeft+1,FBottom-FTop+1);
			BandEditor.BorderStyle=BorderStyle.None;
			BandEditor.TextAlign=HorizontalAlignment.Left;
			BandEditor.BackColor=Color.White;
			BandEditor.Font=Rep.SrcRep.Font;
			
			fEnableUpdateEditText=false;
			OldEditValue=band.Name;
			BandEditor.Text=band.Name;
			fEnableUpdateEditText=true;
			BandEditor.Visible=true;
			BandEditor.SelectAll();			
			BandEditor.Focus();
			Bandidx=idxband;
		}

		public void BandEditorChange(object sender,EventArgs arg)
		{
			if(fEnableUpdateEditText)
			{
				Rep src=Rep.SrcRep;				
				if(src.GetBand(Bandidx).Name!=BandEditor.Text)
				{
					Rep.SrcRep.BeginUpdate();												
					src.GetBand(Bandidx).Name=BandEditor.Text;
					Modified=true;
					src.EndUpdate();
					Rep.Invalidate();
				}				
			}			
		}

		public void RepSelectCell(object sender,SelectCellEventArgs arg)
		{
			if((arg.idxband<Rep.SrcRep.BandCount)&&(arg.idxcell<Rep.SrcRep.GetBand(arg.idxband).CellCount))
			{
				UpdateRulerBars();
				UpdateButtons();
			}
		}

		private void menuItem49_Click(object sender, System.EventArgs e)
		{
			CellPropDlg d=new CellPropDlg();
			d.Rep=Rep;
			if(d.ShowDialog()==DialogResult.OK)
			{
				Modified=Modified||d.Modified;
			}
			Rep.Refresh();
			d.Dispose();
		}

		private void EditorDlg_SizeChanged(object sender, System.EventArgs e)
		{
			Generic.CloseupAllPopupForms();
		}

		private void pc_SelectedIndexChanged(object sender,EventArgs e)
		{
			Rep.Visible=false;
			TabPage ps=pc.SelectedTab;
			if(ps!=null)
			{
				switch((PageType)ps.Tag)
				{
					case PageType.Template:
					{
						for(int i=0;i<ps.Controls.Count;i++)
						{
							if(ps.Controls[i] is EditRep)
							{
								FRep=(EditRep)ps.Controls[i];
								Rep.Visible=false;
								ps.Controls.Clear();
								FRep.Parent=ps;
								VRB.Parent=ps;
								HRB.Parent=ps;
								Rep.Visible=true;								
								
								FRep.BringToFront();
								FRep.Zoom=Zoom;
								FRep.Units=Units;
								FRep.GridX=GridX;
								FRep.GridY=GridY;								
								
								UpdateRulerBars();
								UpdateButtons();
								Refresh();								

								Modified=Modified;
								RepSetFocus();
								Text=FRep.FileName;
								break;
							}
						}
						break;
					}
					case PageType.Help:
					{
						for(int i=0;i<ps.Controls.Count;i++)
						{
							if(ps.Controls[i] is AxSHDocVw.AxWebBrowser)
							{
								Text=((AxSHDocVw.AxWebBrowser)(ps.Controls[i])).LocationURL;
								break;
							}
						}
						break;
					}
				}
			}
		}
		
		protected TabPage NewHelpPage()
		{
			TabPage freturn=new TabPage();
			pc.Controls.Add(freturn);
			freturn.Tag=(int)PageType.Help;
			freturn.Text="";

			pc.SelectedTab=freturn;
			return freturn;
		}

		void RepSetFocus()
		{
			if(Rep!=null)
			{
				pc.SelectedTab=(TabPage)Rep.Parent;
				if((Visible)&&(Rep.Parent!=null))
					Rep.Focus();
			}
			Generic.CloseupAllPopupForms();
		}

		void SetUnits(Units Value)
		{
			Units=Value;
			menuItem87.Checked=false;
			menuItem88.Checked=false;
			menuItem89.Checked=false;
			menuItem90.Checked=false;

			switch(Value)
			{
				case Units.In:
					menuItem87.Checked=true;
					break;
				case Units.MM:
					menuItem88.Checked=true;
					break;
				case Units.Cm:
					menuItem89.Checked=true;
					break;
				case Units.Pix:
					menuItem90.Checked=true;
					break;
			}
			if(Rep!=null)
			{
				Rep.Units=Units;
				GridX=Rep.GridX;
				GridY=Rep.GridY;
				UpdateRulerBars();
				UpdateButtons();
			}
		}

		public void UpdateRulerBars()
		{
			int idxband, idxcell;
			float hselbegin, hselend, vselbegin, vselend;

			hselbegin=1000000;
			hselend=-1;
			vselbegin=1000000;
			vselend=-1;

			for(idxband=0;idxband<Rep.SrcRep.BandCount;idxband++)
			{
				for(idxcell=0;idxcell<Rep.SrcRep.GetBand(idxband).CellCount;idxcell++)
				{
					if(Rep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected)
					{
						hselbegin=Math.Min(hselbegin,Rep.SrcRep.GetBand(idxband).GetLefts(idxcell));
						hselend=Math.Max(hselend,Rep.SrcRep.GetBand(idxband).GetRights(idxcell));

						vselbegin=Math.Min(vselbegin,Rep.SrcRep.GetTops(idxband));
						vselend=Math.Max(Math.Abs(vselend),Rep.SrcRep.GetTops(idxband)+Rep.SrcRep.GetBand(idxband).Height);
					}
				}
			}
			HRB.BeginUpdate();
			HRB.Units=Units;
			HRB.Gutter=Rep.Left+Rep.Gutter-Rep.LeftX+3;
			if(Rep.SrcRep.Orientation==PrinterOrientation.Portrait)
				HRB.PageWidth=Rep.SrcRep.PageSize.FWidth*Generic.ZoomFactor;
			else
				HRB.PageWidth=Rep.SrcRep.PageSize.FHeight*Generic.ZoomFactor;
			HRB.LeftMargin=Rep.SrcRep.LeftMargin;
			HRB.RightMargin=Rep.SrcRep.RightMargin;
			HRB.SelBegin=Generic.FromPix(hselbegin);
			HRB.SelEnd=Generic.FromPix(hselend);
			HRB.EndUpdate();

			VRB.BeginUpdate();
			VRB.Units=Units;
			VRB.Gutter=1-Rep.TopY;
			if(Rep.SrcRep.Orientation==PrinterOrientation.Portrait)
				VRB.PageWidth=Rep.SrcRep.PageSize.FHeight*Generic.ZoomFactor;
			else
				VRB.PageWidth=Rep.SrcRep.PageSize.FWidth*Generic.ZoomFactor;
			VRB.LeftMargin=Rep.SrcRep.TopMargin;
			VRB.RightMargin=Rep.SrcRep.BottomMargin;
			VRB.SelBegin=Generic.FromPix(vselbegin);
			VRB.SelEnd=Generic.FromPix(vselend);
			VRB.EndUpdate();

		}

		private void CellEditorExit(object sender, System.EventArgs e)
		{
			menuItem32.Enabled=true;
			menuItem36.Enabled=true;
			menuItem37.Enabled=true;
			menuItem38.Enabled=true;

			menuItem101.Enabled=true;
			menuItem102.Enabled=true;
			menuItem103.Enabled=true;

			CellEditor.Visible=false;
			Rep.InEditing=false;
		}

		private void BandEditorExit(object sender, System.EventArgs e)
		{
			menuItem32.Enabled=true;
			menuItem36.Enabled=true;
			menuItem37.Enabled=true;
			menuItem38.Enabled=true;

			menuItem101.Enabled=true;
			menuItem102.Enabled=true;
			menuItem103.Enabled=true;

			BandEditor.Visible=false;
			Rep.InEditing=false;
		}

		private void CellEditorChange(object sender,EventArgs arg)
		{
			if(fEnableUpdateEditText)
			{
				Cell cel=Rep.SrcRep.GetBand(Bandidx).GetCell(Cellidx);
				if(cel.Value!=CellEditor.Text)
				{
					cel.Value=CellEditor.Text;
					Modified=true;
				}				
			}
		}

		private void EditorDlg_Load(object sender, System.EventArgs e)
		{
			if(MainArray.Length>0)
				if(MainArray[0]=="/v"||MainArray[0]=="/p")
					Visible=false;
			RegistryKey reg;
			string s;
			string filename;

			s=RegRoot+"\\Setup";
			reg=Registry.CurrentUser.OpenSubKey(s,true);
			if(reg==null)
				reg=Registry.CurrentUser.CreateSubKey(s);
			try
			{
				SetBounds((int)reg.GetValue("Left"),
					(int)reg.GetValue("Top"),
					(int)reg.GetValue("Width"),
					(int)reg.GetValue("Height"));
			}
			catch
			{}

			FFileSystem=new CommonFileSystem(RegRoot);
			try
			{
				if(reg.GetValue("FirstTime")==null)
				{
					reg=Registry.ClassesRoot.OpenSubKey("."+"SD",true);
					if(reg==null)
						reg=Registry.ClassesRoot.CreateSubKey("."+"SD");
					reg.SetValue("","EditorTemplate");

					reg=Registry.ClassesRoot.OpenSubKey("."+"SDT",true);
					if(reg==null)
						reg=Registry.ClassesRoot.CreateSubKey("."+"SDT");
					reg.SetValue("","EditorTemplate");

					reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate",true);
					if(reg==null)
						reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate");
					reg.SetValue("","Report Template");

					reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\DefaultIcon",true);
					if(reg==null)
						reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\DefaultIcon");
					reg.SetValue("","\""+Application.ExecutablePath+"\""+",0");

					reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\DefaultIcon",true);
					if(reg==null)
						reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\DefaultIcon");
					reg.SetValue("","\""+Application.ExecutablePath+"\""+",0");

					reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\Shell\\Open\\Command",true);
					if(reg==null)
						reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\Shell\\Open\\Command");
					reg.SetValue("","\""+Application.ExecutablePath+"\""+" %1");

					reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\Shell\\Print\\Command",true);
					if(reg==null)
						reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\Shell\\Print\\Command");
					reg.SetValue("","\""+Application.ExecutablePath+"\""+" /p %1");

					reg=Registry.ClassesRoot.OpenSubKey("EditorTemplate\\Shell\\View\\Command",true);
					if(reg==null)
						reg=Registry.ClassesRoot.CreateSubKey("EditorTemplate\\Shell\\View\\Command");
					reg.SetValue("","\""+Application.ExecutablePath+"\""+" /v %1");
				}
			}
			catch
			{}

			CreateRulers();
			TemplateList=new StringList("EditorDlg.TemplateList");
			RecentFiles=new StringList("EditorDlg.RecentFiles");
			
			FSetUndo=true;

			CellEditor=new TextBox();
			CellEditor.Multiline=true;
			CellEditor.WordWrap=true;
			CellEditor.Leave+=new EventHandler(CellEditorExit);			
			CellEditor.KeyPress+=new KeyPressEventHandler(CellEditorKeyPress);
			
			BandEditor=new TextBox();
			BandEditor.Leave+=new EventHandler(BandEditorExit);
			BandEditor.KeyPress+=new KeyPressEventHandler(BandEditorKeyPress);
			BandEditor.LostFocus+=new EventHandler(BandEditorChange);

			s=RegRoot+"\\Setup";
			reg=Registry.CurrentUser.OpenSubKey(s,true);
			if(reg==null)
				reg=Registry.CurrentUser.CreateSubKey(s);

			
			ftoprint=false;
			ftoview=false;
			if(MainArray.Length>0)
			{
				filename="";
				for(int i=0;i<MainArray.Length;i++)
				{
					if(Generic.CT(MainArray[i],"/p"))
					{
						ftoprint=true;
					}
					else if(Generic.CT(MainArray[i],"/v"))
					{
						ftoview=true;
					}
					else
					{
						filename=filename+MainArray[i]+" ";
					}
				}
				try
				{
					if(FileSystem.OpenFile(filename))
						LoadReport(FileSystem.Files.GetString(0));
				}
				catch
				{
					ftoprint=false;
					ftoview=false;
				}
				if(ftoprint)
				{
					menuItem18_Click(this,EventArgs.Empty);
					Close();
				}
				if(ftoview)
				{
					menuItem19_Click(this,EventArgs.Empty);
					Close();
				}
			}
			else
			{
				if(Rep==null)
					NewReport("Untitled");
			}
			try
			{
				GridX=BitConverter.ToDouble((byte[])reg.GetValue("GridX"),0);
				GridY=BitConverter.ToDouble((byte[])reg.GetValue("GridY"),0);		
				Rep.Units=(Units)reg.GetValue("UnitsIndex");
				Rep.GridX=GridX;
				Rep.GridY=GridY;
				SetUnits((Units)reg.GetValue("UnitsIndex"));				
				if((GridX==0)||(GridY==0))
				{
					SetUnits((Units)0);
					GridX=4;
					GridY=4;
				}
			}
			catch
			{
				SetUnits((Units)0);
				GridX=4;
				GridY=4;
			}			
			RepSetFocus();
			menuItem123.Checked=true;
			Zoom=Zoom.hundred;
			LoadRecentFiles();
			Rep.SrcRep.RenderingMode=RenderingMode.Normal;
			System.GC.Collect();
		}

		void CreateRulers()
		{
			HRB=new RulerBar();
			HRB.Orientation=RulerBarOrientation.Horizontal;
			HRB.Location=new Point(0,20);
			HRB.Size=new Size(702,35);
			
			HRB.Gutter=100;
			HRB.PageWidth=1500;
			HRB.LeftMargin=100;
			HRB.RightMargin=100;
			HRB.Units=Units.Cm;
			HRB.SelBegin=100;
			HRB.SelEnd=300;
			HRB.Cur=0;
			HRB.SelColor=Color.Aqua;
			HRB.RulerColor=SystemColors.Info;
			HRB.Font=new Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
			HRB.ForeColor=SystemColors.ControlText;
			HRB.Change+=new EventHandler(HRBChange);
			
			VRB=new RulerBar();
			VRB.Location=new Point(0,55);
			VRB.Size=new Size(35,417);
			VRB.Orientation=RulerBarOrientation.Vertical;
			VRB.Gutter=0;
			VRB.PageWidth=1500;
			VRB.LeftMargin=100;
			VRB.RightMargin=100;
			VRB.Units=Units.Cm;
			VRB.SelBegin=100;
			VRB.SelEnd=300;
			VRB.Cur=0;
			VRB.SelColor=Color.Aqua;
			VRB.RulerColor=SystemColors.Info;
			VRB.Font=new Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
			VRB.ForeColor=SystemColors.ControlText;
			VRB.Change+=new EventHandler(HRBChange);
		}

		public void HRBChange(object source,EventArgs arg)
		{
			if(((RulerBar)source).Orientation==RulerBarOrientation.Horizontal)
			{
				Rep.SrcRep.LeftMargin=HRB.LeftMargin;
				Rep.SrcRep.RightMargin=HRB.RightMargin;
			}
			else
			{
				Rep.SrcRep.TopMargin=VRB.LeftMargin;
				Rep.SrcRep.BottomMargin=VRB.RightMargin;
			}
			Modified=true;
			Refresh();
		}

		private void menuItem45_Click(object sender, System.EventArgs e)
		{
			StyleDlg dlg=new StyleDlg();
			dlg.StyleList.AddRange(Rep.SrcRep.StyleList);
			dlg.Rep=Rep;
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				Rep.SrcRep.StyleList.Clear();
				Rep.SrcRep.StyleList.AddRange(dlg.StyleList);
				Modified=true;
				Refresh();
			}
		}

		private void menuItem85_Click(object sender, System.EventArgs e)
		{
			if(menuItem85.Text=="&Lock cell width")
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					Rep.GetSel(i).LockWidth=true;
				}
				menuItem85.Text="Un&lock cell width";
			}
			else if(menuItem85.Text=="Un&lock cell width")
			{
				for(int i=0;i<Rep.SelCount;i++)
				{
					Rep.GetSel(i).LockWidth=false;
				}
				menuItem85.Text="&Lock cell width";
			}
			Modified=true;
		}

		private void menuItem98_Click(object sender, System.EventArgs e)
		{
			if(menuItem98.Text=="&Lock band height")
			{
				Rep.CurrBand.LockHeight=true;				
				menuItem98.Text="Un&lock band height";
			}
			else if(menuItem98.Text=="Un&lock band height")
			{
				Rep.CurrBand.LockHeight=false;				
				menuItem98.Text="&Lock band height";
			}
			Modified=true;
		}
		private void RepPopupmenu_Popup(object sender, System.EventArgs e)
		{
			menuItem128.Text=menuItem85.Text.Replace("&","");
			menuItem126.Text=menuItem98.Text.Replace("&","");
		}
		#endregion	

		#region class properties
		Zoom Zoom
		{
			get
			{
				return FZoom;
			}
			set
			{
				FZoom=value;
			}
		}

		protected string FileName
		{
			get
			{
				return FRep.FileName;
			}
			set
			{
				FRep.FileName=value;
				FileSystem.FileName=FileName;
				UpdateCaption();
			}
		}

		public CommonFileSystem FileSystem
		{
			get
			{
				return FFileSystem;
			}
		}

		public double GridX
		{
			get
			{
				return FGridX;
			}
			set
			{
				FGridX=value;
				if(Rep!=null)
					Rep.GridX=value;
			}
		}

		public double GridY
		{
			get
			{
				return FGridY;
			}
			set
			{
				FGridY=value;
				if(Rep!=null)
					Rep.GridY=value;
			}
		}

		protected Undo Undo
		{
			get
			{
				return FRep.Undo;
			}
		}

		public EditRep Rep
		{
			get
			{
				return FRep;
			}
		}

		protected bool Modified
		{
			get
			{
				return FRep.Modified;
			}
			set
			{
				FRep.Modified=value;
				if(value)
				{
					if(FSetUndo)
					{
						Undo.Add(Rep.Template.GetText());
					}
					statusBar1.Panels[0].Text="Modified";
				}
				else
					statusBar1.Panels[0].Text="";
				Generic.CloseupAllPopupForms();
				UpdateButtons();
				if(Undo.CanUndo())
					menuItem23.Enabled=true;
				else
					menuItem23.Enabled=false;
				if(Undo.CanRedo())
					menuItem24.Enabled=true;
				else
					menuItem24.Enabled=false;
				UpdateRulerBars();
			}
		}
		#endregion		
	}
	#endregion

	#region enums
	public enum PageType
	{
		None,Template,Script,Help,Preview
	}
	#endregion
}