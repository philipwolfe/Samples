//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;

public class frmMain : System.Windows.Forms.Form
{
    // Employee variables for Inheritance tab
    private FullTimeEmployee c_empFull;
    private PartTimeEmployee c_empPart;
	private System.Windows.Forms.Button btnFileFunction;
	private System.Windows.Forms.ListBox lstFileFunction;
	private System.Windows.Forms.Button btnDebugFunction;
	private System.Windows.Forms.ListBox lstDebugFunction;
	private System.Windows.Forms.Button btnExceptionHandlingFunction;
	private System.Windows.Forms.Button btnThreadFunction;
	private System.Windows.Forms.Button btnStringBuilderFunction;
    private TempEmployee c_empTemp;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}


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

    private System.Windows.Forms.StatusBar sbrStatus;

    private System.Windows.Forms.TabControl TabControl1;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.TabPage pgeFiles;

    private System.Windows.Forms.TabPage pgeDebugging;

    private System.Windows.Forms.TabPage pgeInheritance;

    private System.Windows.Forms.TabPage pgeThreading;

    private System.Windows.Forms.StatusBarPanel sbrPanel1;

    private System.Windows.Forms.StatusBarPanel sbrPanel2;

    private System.Windows.Forms.TabPage pgestringBuilder;

    private System.Windows.Forms.TabPage pgeTips;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.ListBox lstDebug;

    private System.Windows.Forms.TextBox txtDebugInfo;

    private System.Windows.Forms.Label Label11;

    private System.Windows.Forms.Button btnDebug;

    private System.Windows.Forms.TextBox txtTips;

    private System.Windows.Forms.TabPage pgeForms;

    private System.Windows.Forms.Button btnOpenDemoForm;

    private System.Windows.Forms.Button btnThread;

    private System.Windows.Forms.TextBox txtThreadResult;

    private System.Windows.Forms.Button btnstringBuilder;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label12;

    private System.Windows.Forms.Label Label14;

    private System.Windows.Forms.Label Label15;

    private System.Windows.Forms.Label Label16;

    private System.Windows.Forms.TextBox txtStrResults;

    private System.Windows.Forms.TextBox txtSBResults;

    private System.Windows.Forms.TextBox txtStrIterations;

    private System.Windows.Forms.TextBox txtSBIterations;

    private System.Windows.Forms.TextBox txtSBAppend;

    private System.Windows.Forms.TextBox txtSBOrig;

    private System.Windows.Forms.Label lblSBAppend;

    private System.Windows.Forms.TextBox txtFileResult;

    private System.Windows.Forms.Button btnFile;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.ListBox lstFile;

    private System.Windows.Forms.TextBox txtExceptionHandlingResult;

    private System.Windows.Forms.Label Label23;

    private System.Windows.Forms.TabPage pgeExceptionHandling;

    private System.Windows.Forms.ListBox lstExceptionHandling;

    private System.Windows.Forms.Button btnExceptionHandling;

    private System.Windows.Forms.Button btnSave;

    private System.Windows.Forms.Button btnClear;

    private System.Windows.Forms.TextBox txtResults;

    private System.Windows.Forms.Button btnHire;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label Label17;

    private System.Windows.Forms.Label Label18;

    private System.Windows.Forms.Label Label19;

    private System.Windows.Forms.TextBox txtExpectedTermDate;

    private System.Windows.Forms.TextBox txtSocialServicesID;

    private System.Windows.Forms.TextBox txtSalary;

    private System.Windows.Forms.TextBox txtHireDate;

    private System.Windows.Forms.TextBox txtName;

    private System.Windows.Forms.Label Label20;

    private System.Windows.Forms.ComboBox cboEmployeeType;

    private System.Windows.Forms.Label Label21;

    private System.Windows.Forms.ToolTip ToolTip1;

    private System.Windows.Forms.Button btnShowGraphics;

    private void InitializeComponent() {
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.sbrStatus = new System.Windows.Forms.StatusBar();
		this.sbrPanel1 = new System.Windows.Forms.StatusBarPanel();
		this.sbrPanel2 = new System.Windows.Forms.StatusBarPanel();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.pgeFiles = new System.Windows.Forms.TabPage();
		this.lstFileFunction = new System.Windows.Forms.ListBox();
		this.btnFileFunction = new System.Windows.Forms.Button();
		this.txtFileResult = new System.Windows.Forms.TextBox();
		this.Label9 = new System.Windows.Forms.Label();
		this.pgeExceptionHandling = new System.Windows.Forms.TabPage();
		this.btnExceptionHandlingFunction = new System.Windows.Forms.Button();
		this.txtExceptionHandlingResult = new System.Windows.Forms.TextBox();
		this.Label23 = new System.Windows.Forms.Label();
		this.lstExceptionHandling = new System.Windows.Forms.ListBox();
		this.pgeDebugging = new System.Windows.Forms.TabPage();
		this.btnDebugFunction = new System.Windows.Forms.Button();
		this.lstDebugFunction = new System.Windows.Forms.ListBox();
		this.Label11 = new System.Windows.Forms.Label();
		this.txtDebugInfo = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.pgestringBuilder = new System.Windows.Forms.TabPage();
		this.Label16 = new System.Windows.Forms.Label();
		this.txtSBIterations = new System.Windows.Forms.TextBox();
		this.txtStrIterations = new System.Windows.Forms.TextBox();
		this.Label15 = new System.Windows.Forms.Label();
		this.Label14 = new System.Windows.Forms.Label();
		this.txtSBResults = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.lblSBAppend = new System.Windows.Forms.Label();
		this.Label12 = new System.Windows.Forms.Label();
		this.txtSBAppend = new System.Windows.Forms.TextBox();
		this.txtStrResults = new System.Windows.Forms.TextBox();
		this.txtSBOrig = new System.Windows.Forms.TextBox();
		this.pgeForms = new System.Windows.Forms.TabPage();
		this.btnShowGraphics = new System.Windows.Forms.Button();
		this.btnOpenDemoForm = new System.Windows.Forms.Button();
		this.pgeThreading = new System.Windows.Forms.TabPage();
		this.btnThreadFunction = new System.Windows.Forms.Button();
		this.txtThreadResult = new System.Windows.Forms.TextBox();
		this.pgeInheritance = new System.Windows.Forms.TabPage();
		this.Label21 = new System.Windows.Forms.Label();
		this.btnSave = new System.Windows.Forms.Button();
		this.btnClear = new System.Windows.Forms.Button();
		this.txtResults = new System.Windows.Forms.TextBox();
		this.btnHire = new System.Windows.Forms.Button();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label17 = new System.Windows.Forms.Label();
		this.Label18 = new System.Windows.Forms.Label();
		this.Label19 = new System.Windows.Forms.Label();
		this.txtExpectedTermDate = new System.Windows.Forms.TextBox();
		this.txtSocialServicesID = new System.Windows.Forms.TextBox();
		this.txtSalary = new System.Windows.Forms.TextBox();
		this.txtHireDate = new System.Windows.Forms.TextBox();
		this.txtName = new System.Windows.Forms.TextBox();
		this.Label20 = new System.Windows.Forms.Label();
		this.cboEmployeeType = new System.Windows.Forms.ComboBox();
		this.pgeTips = new System.Windows.Forms.TabPage();
		this.txtTips = new System.Windows.Forms.TextBox();
		this.btnFile = new System.Windows.Forms.Button();
		this.lstFile = new System.Windows.Forms.ListBox();
		this.btnExceptionHandling = new System.Windows.Forms.Button();
		this.btnDebug = new System.Windows.Forms.Button();
		this.lstDebug = new System.Windows.Forms.ListBox();
		this.btnstringBuilder = new System.Windows.Forms.Button();
		this.btnThread = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.btnStringBuilderFunction = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)(this.sbrPanel1)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.sbrPanel2)).BeginInit();
		this.TabControl1.SuspendLayout();
		this.pgeFiles.SuspendLayout();
		this.pgeExceptionHandling.SuspendLayout();
		this.pgeDebugging.SuspendLayout();
		this.pgestringBuilder.SuspendLayout();
		this.pgeForms.SuspendLayout();
		this.pgeThreading.SuspendLayout();
		this.pgeInheritance.SuspendLayout();
		this.pgeTips.SuspendLayout();
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
																				this.mnuAbout});
		this.mnuHelp.Text = "&Help";
		// 
		// mnuAbout
		// 
		this.mnuAbout.Index = 0;
		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
		// 
		// sbrStatus
		// 
		this.sbrStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.sbrStatus.Location = new System.Drawing.Point(0, 363);
		this.sbrStatus.Name = "sbrStatus";
		this.sbrStatus.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																					 this.sbrPanel1,
																					 this.sbrPanel2});
		this.sbrStatus.ShowPanels = true;
		this.sbrStatus.Size = new System.Drawing.Size(634, 24);
		this.sbrStatus.SizingGrip = false;
		this.sbrStatus.TabIndex = 2;
		// 
		// sbrPanel1
		// 
		this.sbrPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
		this.sbrPanel1.Width = 15;
		// 
		// sbrPanel2
		// 
		this.sbrPanel2.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
		this.sbrPanel2.MinWidth = 10000;
		this.sbrPanel2.Width = 10000;
		// 
		// TabControl1
		// 
		this.TabControl1.Controls.Add(this.pgeFiles);
		this.TabControl1.Controls.Add(this.pgestringBuilder);
		this.TabControl1.Controls.Add(this.pgeExceptionHandling);
		this.TabControl1.Controls.Add(this.pgeDebugging);
		this.TabControl1.Controls.Add(this.pgeForms);
		this.TabControl1.Controls.Add(this.pgeThreading);
		this.TabControl1.Controls.Add(this.pgeInheritance);
		this.TabControl1.Controls.Add(this.pgeTips);
		this.TabControl1.Location = new System.Drawing.Point(16, 48);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.Size = new System.Drawing.Size(600, 312);
		this.TabControl1.TabIndex = 0;
		// 
		// pgeFiles
		// 
		this.pgeFiles.Controls.Add(this.lstFileFunction);
		this.pgeFiles.Controls.Add(this.btnFileFunction);
		this.pgeFiles.Controls.Add(this.txtFileResult);
		this.pgeFiles.Controls.Add(this.Label9);
		this.pgeFiles.Location = new System.Drawing.Point(4, 22);
		this.pgeFiles.Name = "pgeFiles";
		this.pgeFiles.Size = new System.Drawing.Size(592, 286);
		this.pgeFiles.TabIndex = 1;
		this.pgeFiles.Text = "Files";
		// 
		// lstFileFunction
		// 
		this.lstFileFunction.Items.AddRange(new object[] {
															 "Reading a file: StreamReader object",
															 "Writing a file: StreamWriter object",
															 "File Size: FileInfo object",
															 "File version info: FileVersionInfo object",
															 "Temp file name: GetTempFileName function"});
		this.lstFileFunction.Location = new System.Drawing.Point(80, 16);
		this.lstFileFunction.Name = "lstFileFunction";
		this.lstFileFunction.Size = new System.Drawing.Size(224, 212);
		this.lstFileFunction.TabIndex = 5;
		this.lstFileFunction.SelectedIndexChanged += new System.EventHandler(this.lstFileFunction_SelectedIndexChanged);
		// 
		// btnFileFunction
		// 
		this.btnFileFunction.Location = new System.Drawing.Point(472, 200);
		this.btnFileFunction.Name = "btnFileFunction";
		this.btnFileFunction.Size = new System.Drawing.Size(112, 23);
		this.btnFileFunction.TabIndex = 4;
		this.btnFileFunction.Text = "&Do File Function";
		this.btnFileFunction.Click += new System.EventHandler(this.btnFileFunction_Click);
		// 
		// txtFileResult
		// 
		this.txtFileResult.Location = new System.Drawing.Point(312, 16);
		this.txtFileResult.Multiline = true;
		this.txtFileResult.Name = "txtFileResult";
		this.txtFileResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtFileResult.Size = new System.Drawing.Size(272, 176);
		this.txtFileResult.TabIndex = 2;
		this.txtFileResult.Text = "";
		// 
		// Label9
		// 
		this.Label9.AutoSize = true;
		this.Label9.Location = new System.Drawing.Point(8, 16);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(65, 16);
		this.Label9.TabIndex = 0;
		this.Label9.Text = "Choose one";
		// 
		// pgeExceptionHandling
		// 
		this.pgeExceptionHandling.Controls.Add(this.btnExceptionHandlingFunction);
		this.pgeExceptionHandling.Controls.Add(this.txtExceptionHandlingResult);
		this.pgeExceptionHandling.Controls.Add(this.Label23);
		this.pgeExceptionHandling.Controls.Add(this.lstExceptionHandling);
		this.pgeExceptionHandling.Location = new System.Drawing.Point(4, 22);
		this.pgeExceptionHandling.Name = "pgeExceptionHandling";
		this.pgeExceptionHandling.Size = new System.Drawing.Size(592, 286);
		this.pgeExceptionHandling.TabIndex = 3;
		this.pgeExceptionHandling.Text = "Exception Handling";
		this.pgeExceptionHandling.Click += new System.EventHandler(this.pgeExceptionHandling_Click);
		// 
		// btnExceptionHandlingFunction
		// 
		this.btnExceptionHandlingFunction.Location = new System.Drawing.Point(408, 200);
		this.btnExceptionHandlingFunction.Name = "btnExceptionHandlingFunction";
		this.btnExceptionHandlingFunction.Size = new System.Drawing.Size(176, 23);
		this.btnExceptionHandlingFunction.TabIndex = 4;
		this.btnExceptionHandlingFunction.Text = "&Do Exception Handling Function";
		this.btnExceptionHandlingFunction.Click += new System.EventHandler(this.btnExceptionHandlingFunction_Click);
		// 
		// txtExceptionHandlingResult
		// 
		this.txtExceptionHandlingResult.Location = new System.Drawing.Point(312, 16);
		this.txtExceptionHandlingResult.Multiline = true;
		this.txtExceptionHandlingResult.Name = "txtExceptionHandlingResult";
		this.txtExceptionHandlingResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtExceptionHandlingResult.Size = new System.Drawing.Size(272, 176);
		this.txtExceptionHandlingResult.TabIndex = 2;
		this.txtExceptionHandlingResult.Text = "";
		// 
		// Label23
		// 
		this.Label23.AutoSize = true;
		this.Label23.Location = new System.Drawing.Point(8, 16);
		this.Label23.Name = "Label23";
		this.Label23.Size = new System.Drawing.Size(65, 16);
		this.Label23.TabIndex = 0;
		this.Label23.Text = "Choose one";
		// 
		// lstExceptionHandling
		// 
		this.lstExceptionHandling.Items.AddRange(new object[] {
																  "Basic exception handling",
																  "Focused exception handling"});
		this.lstExceptionHandling.Location = new System.Drawing.Point(80, 16);
		this.lstExceptionHandling.Name = "lstExceptionHandling";
		this.lstExceptionHandling.Size = new System.Drawing.Size(224, 212);
		this.lstExceptionHandling.TabIndex = 1;
		this.lstExceptionHandling.SelectedIndexChanged += new System.EventHandler(this.lstExceptionHandling_SelectedIndexChanged);
		// 
		// pgeDebugging
		// 
		this.pgeDebugging.Controls.Add(this.btnDebugFunction);
		this.pgeDebugging.Controls.Add(this.lstDebugFunction);
		this.pgeDebugging.Controls.Add(this.Label11);
		this.pgeDebugging.Controls.Add(this.txtDebugInfo);
		this.pgeDebugging.Controls.Add(this.Label4);
		this.pgeDebugging.Location = new System.Drawing.Point(4, 22);
		this.pgeDebugging.Name = "pgeDebugging";
		this.pgeDebugging.Size = new System.Drawing.Size(592, 286);
		this.pgeDebugging.TabIndex = 2;
		this.pgeDebugging.Text = "Tracing/Debugging";
		// 
		// btnDebugFunction
		// 
		this.btnDebugFunction.Location = new System.Drawing.Point(340, 64);
		this.btnDebugFunction.Name = "btnDebugFunction";
		this.btnDebugFunction.Size = new System.Drawing.Size(168, 23);
		this.btnDebugFunction.TabIndex = 6;
		this.btnDebugFunction.Text = "Do Debug Function";
		this.btnDebugFunction.Click += new System.EventHandler(this.btnDebugFunction_Click);
		// 
		// lstDebugFunction
		// 
		this.lstDebugFunction.Items.AddRange(new object[] {
															  "Debug",
															  "    Write to Console",
															  "    Write to File",
															  "    Write to Event Log",
															  "Trace",
															  "    Write to Console",
															  "    Write to File",
															  "    Write to Event Log"});
		this.lstDebugFunction.Location = new System.Drawing.Point(84, 64);
		this.lstDebugFunction.Name = "lstDebugFunction";
		this.lstDebugFunction.Size = new System.Drawing.Size(248, 212);
		this.lstDebugFunction.TabIndex = 5;
		this.lstDebugFunction.SelectedIndexChanged += new System.EventHandler(this.lstDebugFunction_SelectedIndexChanged);
		// 
		// Label11
		// 
		this.Label11.AutoSize = true;
		this.Label11.Location = new System.Drawing.Point(8, 16);
		this.Label11.Name = "Label11";
		this.Label11.Size = new System.Drawing.Size(64, 16);
		this.Label11.TabIndex = 0;
		this.Label11.Text = "Trace string";
		// 
		// txtDebugInfo
		// 
		this.txtDebugInfo.Location = new System.Drawing.Point(80, 16);
		this.txtDebugInfo.Name = "txtDebugInfo";
		this.txtDebugInfo.Size = new System.Drawing.Size(480, 20);
		this.txtDebugInfo.TabIndex = 1;
		this.txtDebugInfo.Text = "My trace string";
		// 
		// Label4
		// 
		this.Label4.AutoSize = true;
		this.Label4.Location = new System.Drawing.Point(8, 64);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(65, 16);
		this.Label4.TabIndex = 2;
		this.Label4.Text = "Choose one";
		// 
		// pgestringBuilder
		// 
		this.pgestringBuilder.Controls.Add(this.btnStringBuilderFunction);
		this.pgestringBuilder.Controls.Add(this.Label16);
		this.pgestringBuilder.Controls.Add(this.txtSBIterations);
		this.pgestringBuilder.Controls.Add(this.txtStrIterations);
		this.pgestringBuilder.Controls.Add(this.Label15);
		this.pgestringBuilder.Controls.Add(this.Label14);
		this.pgestringBuilder.Controls.Add(this.txtSBResults);
		this.pgestringBuilder.Controls.Add(this.Label3);
		this.pgestringBuilder.Controls.Add(this.lblSBAppend);
		this.pgestringBuilder.Controls.Add(this.Label12);
		this.pgestringBuilder.Controls.Add(this.txtSBAppend);
		this.pgestringBuilder.Controls.Add(this.txtStrResults);
		this.pgestringBuilder.Controls.Add(this.txtSBOrig);
		this.pgestringBuilder.Location = new System.Drawing.Point(4, 22);
		this.pgestringBuilder.Name = "pgestringBuilder";
		this.pgestringBuilder.Size = new System.Drawing.Size(592, 286);
		this.pgestringBuilder.TabIndex = 6;
		this.pgestringBuilder.Text = "stringBuilder";
		// 
		// Label16
		// 
		this.Label16.AutoSize = true;
		this.Label16.Location = new System.Drawing.Point(144, 64);
		this.Label16.Name = "Label16";
		this.Label16.Size = new System.Drawing.Size(69, 16);
		this.Label16.TabIndex = 24;
		this.Label16.Text = "SB Iterations";
		// 
		// txtSBIterations
		// 
		this.txtSBIterations.Location = new System.Drawing.Point(216, 64);
		this.txtSBIterations.Name = "txtSBIterations";
		this.txtSBIterations.ReadOnly = true;
		this.txtSBIterations.Size = new System.Drawing.Size(72, 20);
		this.txtSBIterations.TabIndex = 23;
		this.txtSBIterations.Text = "200000";
		// 
		// txtStrIterations
		// 
		this.txtStrIterations.Location = new System.Drawing.Point(88, 64);
		this.txtStrIterations.Name = "txtStrIterations";
		this.txtStrIterations.ReadOnly = true;
		this.txtStrIterations.Size = new System.Drawing.Size(52, 20);
		this.txtStrIterations.TabIndex = 22;
		this.txtStrIterations.Text = "10000";
		this.txtStrIterations.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStrIterations_KeyPress);
		// 
		// Label15
		// 
		this.Label15.AutoSize = true;
		this.Label15.Location = new System.Drawing.Point(296, 64);
		this.Label15.Name = "Label15";
		this.Label15.Size = new System.Drawing.Size(42, 16);
		this.Label15.TabIndex = 21;
		this.Label15.Text = "Mill. Str";
		this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// Label14
		// 
		this.Label14.AutoSize = true;
		this.Label14.Location = new System.Drawing.Point(440, 64);
		this.Label14.Name = "Label14";
		this.Label14.Size = new System.Drawing.Size(43, 16);
		this.Label14.TabIndex = 20;
		this.Label14.Text = "Mill SB.";
		// 
		// txtSBResults
		// 
		this.txtSBResults.Location = new System.Drawing.Point(504, 64);
		this.txtSBResults.Name = "txtSBResults";
		this.txtSBResults.ReadOnly = true;
		this.txtSBResults.Size = new System.Drawing.Size(72, 20);
		this.txtSBResults.TabIndex = 19;
		this.txtSBResults.Text = "";
		// 
		// Label3
		// 
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(8, 64);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(68, 16);
		this.Label3.TabIndex = 17;
		this.Label3.Text = "Str Iterations";
		// 
		// lblSBAppend
		// 
		this.lblSBAppend.AutoSize = true;
		this.lblSBAppend.Location = new System.Drawing.Point(8, 40);
		this.lblSBAppend.Name = "lblSBAppend";
		this.lblSBAppend.Size = new System.Drawing.Size(43, 16);
		this.lblSBAppend.TabIndex = 2;
		this.lblSBAppend.Text = "Append";
		// 
		// Label12
		// 
		this.Label12.AutoSize = true;
		this.Label12.Location = new System.Drawing.Point(8, 16);
		this.Label12.Name = "Label12";
		this.Label12.Size = new System.Drawing.Size(74, 16);
		this.Label12.TabIndex = 0;
		this.Label12.Text = "Original string";
		// 
		// txtSBAppend
		// 
		this.txtSBAppend.Location = new System.Drawing.Point(88, 40);
		this.txtSBAppend.Name = "txtSBAppend";
		this.txtSBAppend.Size = new System.Drawing.Size(200, 20);
		this.txtSBAppend.TabIndex = 3;
		this.txtSBAppend.Text = "";
		// 
		// txtStrResults
		// 
		this.txtStrResults.Location = new System.Drawing.Point(360, 64);
		this.txtStrResults.Name = "txtStrResults";
		this.txtStrResults.ReadOnly = true;
		this.txtStrResults.Size = new System.Drawing.Size(72, 20);
		this.txtStrResults.TabIndex = 15;
		this.txtStrResults.Text = "";
		// 
		// txtSBOrig
		// 
		this.txtSBOrig.Location = new System.Drawing.Point(88, 16);
		this.txtSBOrig.Name = "txtSBOrig";
		this.txtSBOrig.Size = new System.Drawing.Size(488, 20);
		this.txtSBOrig.TabIndex = 1;
		this.txtSBOrig.Text = "";
		// 
		// pgeForms
		// 
		this.pgeForms.Controls.Add(this.btnShowGraphics);
		this.pgeForms.Controls.Add(this.btnOpenDemoForm);
		this.pgeForms.Location = new System.Drawing.Point(4, 22);
		this.pgeForms.Name = "pgeForms";
		this.pgeForms.Size = new System.Drawing.Size(592, 286);
		this.pgeForms.TabIndex = 8;
		this.pgeForms.Text = "Forms and Graphics";
		// 
		// btnShowGraphics
		// 
		this.btnShowGraphics.Location = new System.Drawing.Point(16, 64);
		this.btnShowGraphics.Name = "btnShowGraphics";
		this.btnShowGraphics.Size = new System.Drawing.Size(176, 23);
		this.btnShowGraphics.TabIndex = 1;
		this.btnShowGraphics.Text = "Graphics Support";
		this.btnShowGraphics.Click += new System.EventHandler(this.btnShowGraphics_Click);
		// 
		// btnOpenDemoForm
		// 
		this.btnOpenDemoForm.Location = new System.Drawing.Point(16, 24);
		this.btnOpenDemoForm.Name = "btnOpenDemoForm";
		this.btnOpenDemoForm.Size = new System.Drawing.Size(176, 23);
		this.btnOpenDemoForm.TabIndex = 0;
		this.btnOpenDemoForm.Text = "Show Anchoring and Docking";
		this.btnOpenDemoForm.Click += new System.EventHandler(this.btnOpenDemoForm_Click);
		// 
		// pgeThreading
		// 
		this.pgeThreading.Controls.Add(this.btnThreadFunction);
		this.pgeThreading.Controls.Add(this.txtThreadResult);
		this.pgeThreading.Location = new System.Drawing.Point(4, 22);
		this.pgeThreading.Name = "pgeThreading";
		this.pgeThreading.Size = new System.Drawing.Size(592, 286);
		this.pgeThreading.TabIndex = 5;
		this.pgeThreading.Text = "Threading";
		// 
		// btnThreadFunction
		// 
		this.btnThreadFunction.Location = new System.Drawing.Point(408, 32);
		this.btnThreadFunction.Name = "btnThreadFunction";
		this.btnThreadFunction.Size = new System.Drawing.Size(168, 23);
		this.btnThreadFunction.TabIndex = 2;
		this.btnThreadFunction.Text = "Start Thread";
		this.btnThreadFunction.Click += new System.EventHandler(this.btnThreadFunction_Click);
		// 
		// txtThreadResult
		// 
		this.txtThreadResult.Location = new System.Drawing.Point(16, 32);
		this.txtThreadResult.Multiline = true;
		this.txtThreadResult.Name = "txtThreadResult";
		this.txtThreadResult.Size = new System.Drawing.Size(376, 224);
		this.txtThreadResult.TabIndex = 0;
		this.txtThreadResult.Text = "";
		// 
		// pgeInheritance
		// 
		this.pgeInheritance.Controls.Add(this.Label21);
		this.pgeInheritance.Controls.Add(this.btnSave);
		this.pgeInheritance.Controls.Add(this.btnClear);
		this.pgeInheritance.Controls.Add(this.txtResults);
		this.pgeInheritance.Controls.Add(this.btnHire);
		this.pgeInheritance.Controls.Add(this.Label6);
		this.pgeInheritance.Controls.Add(this.Label5);
		this.pgeInheritance.Controls.Add(this.Label17);
		this.pgeInheritance.Controls.Add(this.Label18);
		this.pgeInheritance.Controls.Add(this.Label19);
		this.pgeInheritance.Controls.Add(this.txtExpectedTermDate);
		this.pgeInheritance.Controls.Add(this.txtSocialServicesID);
		this.pgeInheritance.Controls.Add(this.txtSalary);
		this.pgeInheritance.Controls.Add(this.txtHireDate);
		this.pgeInheritance.Controls.Add(this.txtName);
		this.pgeInheritance.Controls.Add(this.Label20);
		this.pgeInheritance.Controls.Add(this.cboEmployeeType);
		this.pgeInheritance.Location = new System.Drawing.Point(4, 22);
		this.pgeInheritance.Name = "pgeInheritance";
		this.pgeInheritance.Size = new System.Drawing.Size(592, 286);
		this.pgeInheritance.TabIndex = 4;
		this.pgeInheritance.Text = "Inheritance";
		// 
		// Label21
		// 
		this.Label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.Label21.Location = new System.Drawing.Point(51, 24);
		this.Label21.Name = "Label21";
		this.Label21.Size = new System.Drawing.Size(264, 23);
		this.Label21.TabIndex = 32;
		this.Label21.Text = "Employee Management";
		// 
		// btnSave
		// 
		this.btnSave.AccessibleDescription = "btnSave";
		this.btnSave.AccessibleName = "Save data button";
		this.btnSave.Enabled = false;
		this.btnSave.Location = new System.Drawing.Point(408, 240);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(72, 23);
		this.btnSave.TabIndex = 29;
		this.btnSave.Text = "&Save";
		this.btnSave.Click += new EventHandler(btnSave_Click);
		// 
		// btnClear
		// 
		this.btnClear.AccessibleDescription = "Clear data";
		this.btnClear.AccessibleName = "btnClear";
		this.btnClear.Location = new System.Drawing.Point(488, 240);
		this.btnClear.Name = "btnClear";
		this.btnClear.Size = new System.Drawing.Size(72, 23);
		this.btnClear.TabIndex = 30;
		this.btnClear.Text = "&Clear";
		this.btnClear.Click += new EventHandler(btnClear_Click);
		// 
		// txtResults
		// 
		this.txtResults.AccessibleDescription = "Results";
		this.txtResults.AccessibleName = "txtResults";
		this.txtResults.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.txtResults.BackColor = System.Drawing.SystemColors.Menu;
		this.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtResults.Location = new System.Drawing.Point(331, 64);
		this.txtResults.Multiline = true;
		this.txtResults.Name = "txtResults";
		this.txtResults.ReadOnly = true;
		this.txtResults.Size = new System.Drawing.Size(229, 165);
		this.txtResults.TabIndex = 31;
		this.txtResults.Text = "";
		// 
		// btnHire
		// 
		this.btnHire.AccessibleDescription = "Hire button";
		this.btnHire.AccessibleName = "btnHire";
		this.btnHire.Enabled = false;
		this.btnHire.Location = new System.Drawing.Point(328, 240);
		this.btnHire.Name = "btnHire";
		this.btnHire.Size = new System.Drawing.Size(72, 23);
		this.btnHire.TabIndex = 28;
		this.btnHire.Text = "H&ire";
		this.btnHire.Click += new EventHandler(btnHire_Click);
		// 
		// Label6
		// 
		this.Label6.AutoSize = true;
		this.Label6.Location = new System.Drawing.Point(51, 208);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(111, 16);
		this.Label6.TabIndex = 26;
		this.Label6.Text = "Expected Term. Date";
		// 
		// Label5
		// 
		this.Label5.AutoSize = true;
		this.Label5.Location = new System.Drawing.Point(51, 176);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(96, 16);
		this.Label5.TabIndex = 24;
		this.Label5.Text = "Social Services ID";
		// 
		// Label17
		// 
		this.Label17.AutoSize = true;
		this.Label17.Location = new System.Drawing.Point(51, 152);
		this.Label17.Name = "Label17";
		this.Label17.Size = new System.Drawing.Size(36, 16);
		this.Label17.TabIndex = 22;
		this.Label17.Text = "Salary";
		// 
		// Label18
		// 
		this.Label18.AutoSize = true;
		this.Label18.Location = new System.Drawing.Point(51, 120);
		this.Label18.Name = "Label18";
		this.Label18.Size = new System.Drawing.Size(52, 16);
		this.Label18.TabIndex = 20;
		this.Label18.Text = "Hire Date";
		// 
		// Label19
		// 
		this.Label19.AutoSize = true;
		this.Label19.Location = new System.Drawing.Point(51, 96);
		this.Label19.Name = "Label19";
		this.Label19.Size = new System.Drawing.Size(34, 16);
		this.Label19.TabIndex = 18;
		this.Label19.Text = "Name";
		// 
		// txtExpectedTermDate
		// 
		this.txtExpectedTermDate.AccessibleDescription = "Expected Termination Date";
		this.txtExpectedTermDate.AccessibleName = "txtExpectedTermDate";
		this.txtExpectedTermDate.Enabled = false;
		this.txtExpectedTermDate.Location = new System.Drawing.Point(163, 208);
		this.txtExpectedTermDate.Name = "txtExpectedTermDate";
		this.txtExpectedTermDate.Size = new System.Drawing.Size(160, 20);
		this.txtExpectedTermDate.TabIndex = 27;
		this.txtExpectedTermDate.Text = "";
		this.txtExpectedTermDate.TextChanged += new EventHandler(TextBoxes_TextChanged);
		// 
		// txtSocialServicesID
		// 
		this.txtSocialServicesID.AccessibleDescription = "Social Services ID";
		this.txtSocialServicesID.AccessibleName = "txtSocialServicesID";
		this.txtSocialServicesID.Enabled = false;
		this.txtSocialServicesID.Location = new System.Drawing.Point(163, 176);
		this.txtSocialServicesID.Name = "txtSocialServicesID";
		this.txtSocialServicesID.Size = new System.Drawing.Size(160, 20);
		this.txtSocialServicesID.TabIndex = 25;
		this.txtSocialServicesID.Text = "";
		this.txtSocialServicesID.TextChanged += new EventHandler(TextBoxes_TextChanged);
		// 
		// txtSalary
		// 
		this.txtSalary.AccessibleDescription = "Salary";
		this.txtSalary.AccessibleName = "txtSalary";
		this.txtSalary.Enabled = false;
		this.txtSalary.Location = new System.Drawing.Point(163, 152);
		this.txtSalary.Name = "txtSalary";
		this.txtSalary.Size = new System.Drawing.Size(160, 20);
		this.txtSalary.TabIndex = 23;
		this.txtSalary.Text = "";
		this.txtSalary.TextChanged += new EventHandler(TextBoxes_TextChanged);
		// 
		// txtHireDate
		// 
		this.txtHireDate.AccessibleDescription = "Hire date";
		this.txtHireDate.AccessibleName = "txtHireDate";
		this.txtHireDate.Enabled = false;
		this.txtHireDate.Location = new System.Drawing.Point(163, 120);
		this.txtHireDate.Name = "txtHireDate";
		this.txtHireDate.Size = new System.Drawing.Size(160, 20);
		this.txtHireDate.TabIndex = 21;
		this.txtHireDate.Text = "";
		this.txtHireDate.TextChanged += new EventHandler(TextBoxes_TextChanged);
		// 
		// txtName
		// 
		this.txtName.AccessibleDescription = "Employee name";
		this.txtName.Enabled = false;
		this.txtName.Location = new System.Drawing.Point(163, 96);
		this.txtName.Name = "txtName";
		this.txtName.Size = new System.Drawing.Size(160, 20);
		this.txtName.TabIndex = 19;
		this.txtName.Text = "";
		this.txtName.TextChanged += new EventHandler(TextBoxes_TextChanged);
		// 
		// Label20
		// 
		this.Label20.AutoSize = true;
		this.Label20.Location = new System.Drawing.Point(51, 64);
		this.Label20.Name = "Label20";
		this.Label20.Size = new System.Drawing.Size(79, 16);
		this.Label20.TabIndex = 16;
		this.Label20.Text = "Employee &type";
		// 
		// cboEmployeeType
		// 
		this.cboEmployeeType.AccessibleDescription = "Employee type combo box";
		this.cboEmployeeType.AccessibleName = "cboEmployeeType";
		this.cboEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboEmployeeType.Items.AddRange(new object[] {
															 "Full-time",
															 "Part-time",
															 "Temporary"});
		this.cboEmployeeType.Location = new System.Drawing.Point(163, 64);
		this.cboEmployeeType.Name = "cboEmployeeType";
		this.cboEmployeeType.Size = new System.Drawing.Size(160, 21);
		this.cboEmployeeType.TabIndex = 17;
		this.cboEmployeeType.SelectedIndexChanged += new EventHandler(TextBoxes_TextChanged);
		// 
		// pgeTips
		// 
		this.pgeTips.Controls.Add(this.txtTips);
		this.pgeTips.Location = new System.Drawing.Point(4, 22);
		this.pgeTips.Name = "pgeTips";
		this.pgeTips.Size = new System.Drawing.Size(592, 286);
		this.pgeTips.TabIndex = 7;
		this.pgeTips.Text = "Tips";
		// 
		// txtTips
		// 
		this.txtTips.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtTips.Location = new System.Drawing.Point(0, 0);
		this.txtTips.Multiline = true;
		this.txtTips.Name = "txtTips";
		this.txtTips.Size = new System.Drawing.Size(592, 286);
		this.txtTips.TabIndex = 0;
		this.txtTips.Text = "";
		// 
		// btnFile
		// 
		this.btnFile.Location = new System.Drawing.Point(0, 0);
		this.btnFile.Name = "btnFile";
		this.btnFile.TabIndex = 0;
		// 
		// lstFile
		// 
		this.lstFile.Location = new System.Drawing.Point(0, 0);
		this.lstFile.Name = "lstFile";
		this.lstFile.TabIndex = 0;
		// 
		// btnExceptionHandling
		// 
		this.btnExceptionHandling.Location = new System.Drawing.Point(0, 0);
		this.btnExceptionHandling.Name = "btnExceptionHandling";
		this.btnExceptionHandling.TabIndex = 0;
		// 
		// btnDebug
		// 
		this.btnDebug.Location = new System.Drawing.Point(0, 0);
		this.btnDebug.Name = "btnDebug";
		this.btnDebug.TabIndex = 0;
		// 
		// lstDebug
		// 
		this.lstDebug.Location = new System.Drawing.Point(0, 0);
		this.lstDebug.Name = "lstDebug";
		this.lstDebug.TabIndex = 0;
		// 
		// btnstringBuilder
		// 
		this.btnstringBuilder.Location = new System.Drawing.Point(0, 0);
		this.btnstringBuilder.Name = "btnstringBuilder";
		this.btnstringBuilder.TabIndex = 0;
		// 
		// btnThread
		// 
		this.btnThread.Location = new System.Drawing.Point(0, 0);
		this.btnThread.Name = "btnThread";
		this.btnThread.TabIndex = 0;
		// 
		// Label1
		// 
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.Label1.Location = new System.Drawing.Point(16, 16);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(94, 22);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "C# Benefits";
		// 
		// btnStringBuilderFunction
		// 
		this.btnStringBuilderFunction.Location = new System.Drawing.Point(360, 112);
		this.btnStringBuilderFunction.Name = "btnStringBuilderFunction";
		this.btnStringBuilderFunction.Size = new System.Drawing.Size(216, 23);
		this.btnStringBuilderFunction.TabIndex = 25;
		this.btnStringBuilderFunction.Text = "Concatenate";
		this.btnStringBuilderFunction.Click += new EventHandler(btnStringBuilderFunction_Click);
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(634, 387);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.TabControl1);
		this.Controls.Add(this.sbrStatus);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		((System.ComponentModel.ISupportInitialize)(this.sbrPanel1)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.sbrPanel2)).EndInit();
		this.TabControl1.ResumeLayout(false);
		this.pgeFiles.ResumeLayout(false);
		this.pgeExceptionHandling.ResumeLayout(false);
		this.pgeDebugging.ResumeLayout(false);
		this.pgestringBuilder.ResumeLayout(false);
		this.pgeForms.ResumeLayout(false);
		this.pgeThreading.ResumeLayout(false);
		this.pgeInheritance.ResumeLayout(false);
		this.pgeTips.ResumeLayout(false);
		this.ResumeLayout(false);
		this.Load+=new EventHandler(frmMain_Load);

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

#region " Form_load ";

    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        SetupTips();
        lstFileFunction.SelectedIndex = 0;
        lstDebugFunction.SelectedIndex = 0;
        txtSBAppend.Text = "My string";
        lstExceptionHandling.SelectedIndex = 0;
    }

#endregion

#region " Utility functions ";

    private void AddTip(string strTip)
	{
        txtTips.Text += strTip + Environment.NewLine;
    }

    private void AddTip2(string strTip)
	{
        txtTips.Text += strTip + Environment.NewLine + Environment.NewLine;
    }

    private void SetupTips()
	{
        txtTips.Clear();
        AddTip2("strings: Whenever you expect to make multiple adjustments to a string, use the stringBuilder. It is orders of magnitude faster than traditional string manipulation.");
        AddTip("Debugging: Use the Debug class if you only want output in the Debug version of your program. Use the Trace class if you want output in both the Debug and Release versions.");
        AddTip2("try { setting your project to Release mode and see the difference.");
        AddTip2("Inheritance: See the classes named Employee, EmployeeDataManager, FullTimeEmployee, PartTimeEmployee, and TempEmployee for extensive comments on inheritance, overloading, overriding and scoping.");
    }

#endregion

    private void btnOpenDemoForm_Click(object sender, System.EventArgs e) 
	{
        // Open a new instance of the form
        frmControls frm = new frmControls();
        // Show it in dialog mode
        frm.ShowDialog();
    }

    private void btnShowGraphics_Click(object sender, System.EventArgs e) 
	{
        frmGraphics frmG = new frmGraphics();
        frmG.ShowDialog();
    }

    private void btnStringBuilderFunction_Click(object sender, System.EventArgs e) 
	{
       string strSBOrig  = txtSBOrig.Text.Trim();
       string strConcatenated ;
       string strSBAppend  = txtSBAppend.Text.Trim();
       int intStrIterations  = Convert.ToInt32(txtStrIterations.Text);
       int intSBIterations  = Convert.ToInt32(txtSBIterations.Text);
       StringBuilder sb = new StringBuilder(strSBAppend.Length * intSBIterations);
       TimeCheck tmr = new TimeCheck();
       int i ;

		try 
		{
			txtStrResults.Text = string.Empty;
			txtSBResults.Text = string.Empty;
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			// Concatenate the VB6 way
			tmr.Begin();
			strConcatenated = strSBOrig;

			for (i = 1; i == intStrIterations; i++)
			{
				strConcatenated = strConcatenated + strSBAppend;
			}
			tmr.End();
			txtStrResults.Text = tmr.Milliseconds.ToString();

			// Now use the stringBuilder
			tmr.Begin();

			for (i = 1; i == intSBIterations; i++)
			{
				sb.Append(strSBAppend);
			}
			tmr.End();
			txtSBResults.Text = tmr.Milliseconds.ToString();

		} 
		catch(Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    // Accept only numbers in textbox
    private void txtStrIterations_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) 
	{
        char KeyStroke ;
        char chrNullCharacter = '0';
        KeyStroke = e.KeyChar;
		
		if((KeyStroke == '/') || (KeyStroke == '\r') || ((KeyStroke >= '0') && (KeyStroke <= '9')))
		{

		}
		else
		{
			KeyStroke = chrNullCharacter;
		}

        //switch( KeyStroke)
		//{
         //   case '0' To "9"c, '/', '\r'    // digits 0-9, backspace, return;

                // These keys are fine, don't do anything

			//default: 
			//{
				// throw everything else away
			//	KeyStroke = chrNullCharacter;
			//}
       // }

		if (KeyStroke == chrNullCharacter)
		{
			e.Handled = true;
		}
		else 
		{
			e.Handled = false;
		}
    }

    private void lstFileFunction_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        switch(lstFileFunction.SelectedIndex)
		{
            case 0: // Reading a file;
                btnFileFunction.Text = "&Read file";
				break;
            case 1: //' Writing a file;
                btnFileFunction.Text = "&Write file";
				break;
            case 2: //' File Size;
                btnFileFunction.Text = "&get {file size";
				break;
            case 3: //' File version info;
                btnFileFunction.Text = "&get {file version";
				break;
            case 4: //' Temporary file name;
                btnFileFunction.Text = "&get {temp file name";
				break;
        }
    }

    private void btnFileFunction_Click(object sender, System.EventArgs e) 
	{
        // File IO is now handled by the classes in the System.IO namespace.
        // Classes here allow for the reading and writing of files well
        // other streams such memory streams, network streams etc.

        string strFile  = "../../DemoText.txt";
        string strFileWrite  = "../../DemoText_Write.txt";

        switch( lstFileFunction.SelectedIndex)
		{
            case 0: //' Reading a file;
                StreamReader srFile = new StreamReader(strFile);
                txtFileResult.Text = srFile.ReadToEnd();
                srFile.Close();
				break;
            case 1: //' Writing a file;
                StreamWriter swFile = File.CreateText(strFileWrite);
                swFile.WriteLine("The quick brown fox jumped over the lazy dogs.");
                swFile.Flush();
                swFile.Close();
                StreamReader sr = new StreamReader(strFileWrite);
                txtFileResult.Text = sr.ReadToEnd();
                sr.Close();
				break;
            case 2: //' File Size;
                FileInfo fiFile = new FileInfo(strFileWrite);
                txtFileResult.Text = "Size of " + strFileWrite.Substring(strFileWrite.IndexOf("/")) + ": " +
                    Convert.ToString(fiFile.Length) + " bytes.";
				break;
            case 3: //' File version info;
                // The environment class contains many useful functions that previously were API calls.
                //Environment env;
                strFile = Environment.SystemDirectory + "/Notepad.exe";
                FileVersionInfo viVersionInfo = FileVersionInfo.GetVersionInfo(strFile);
                txtFileResult.Text = "Version of " + strFile + ": " + viVersionInfo.FileVersion + Environment.NewLine;
                txtFileResult.Text += "Description of " + strFile + ": " + viVersionInfo.FileDescription;
				break;
            case 4: //' Temporary file name;
                txtFileResult.Text = "Temp file name: " + Path.GetTempFileName();
				break;
        }
    }

    private void lstExceptionHandling_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        switch( lstExceptionHandling.SelectedIndex)
		{
            case 0:
                btnExceptionHandlingFunction.Text = "&Basic Exception Handling";
				break;
            case 1:
                btnExceptionHandlingFunction.Text = "&Focused Exception Handling";
				break;
        }
    }

    private void btnExceptionHandlingFunction_Click(object sender, System.EventArgs e) 
	{
        switch( lstExceptionHandling.SelectedIndex)
		{
            case 0: //' Basic;
                BasicException();
				break;
            case 1: //' Focused;
                ExceptionReadingFromFile();
				break;
        }
    }

    private void BasicException()
	{
        // Exception Handling takes the place of On Error.  Exception handling is
        // much more robust and extensible.
        double dblNum1  = 5;
        double dblNum2  = 0;
        int intResult ;

		try 
		{
			intResult = Convert.ToInt32(dblNum1 / dblNum2);
		}
        catch(Exception exp)
		{
            // Report just the exception message.
            // exp could be any valid name you choose.
            txtExceptionHandlingResult.Text = exp.Message;
        }
    }

    private void ExceptionReadingFromFile()
	{
        try {
            // try { to open the file.
            // Bad Directory name. 
            StreamWriter sw = new StreamWriter("c:/12345678asdf/baddirectory.txt");
       } 
		catch(DirectoryNotFoundException dirNotFoundEX )
		{
            //  You can easily target specific exceptions found in the framework or even
            //  create your own derived from ApplicationException
            //  exp.ToString() provides not only the error message, but much more detail on the exception, including exactly where it occurred.
            txtExceptionHandlingResult.Text = "Message: " + dirNotFoundEX.Message + Environment.NewLine + Environment.NewLine;
            txtExceptionHandlingResult.Text += "Stack Trace: " + dirNotFoundEX.StackTrace;
       } 
		catch(Exception exp )
		{
            //} catch( any other kind of error.
            MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // Use the Debug class if you only want output in the Debug version of your program. 
    // Use the Trace class if you want output in both the Debug and Release versions."
    private void lstDebugFunction_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        switch( lstDebugFunction.SelectedIndex)
		{
            case 0: //' Debug:;
                lstDebugFunction.SelectedIndex = 1;
				break;
            case 1: //' Debug: Write to Console;
                btnDebugFunction.Text = "&Debug: Write to Console";
				break;
            case 2: //' Debug: Write to File;
                btnDebugFunction.Text = "&Debug: Write to File";
				break;
            case 3: //' Debug: Write to event Log;
                btnDebugFunction.Text = "&Debug: Write to event Log";
				break;
            case 4: //' Trace:;
                lstDebugFunction.SelectedIndex = 5;
				break;
            case 5: //' Trace: Write to Console;
                btnDebugFunction.Text = "&Trace: Write to Console";
				break;
            case 6: //' Trace: Write to File;
                btnDebugFunction.Text = "&Trace: Write to File";
				break;
            case 7: //' Trace: Write to event Log;
                btnDebugFunction.Text = "&Trace: Write to event Log";
				break;
        }
    }

    private void btnDebugFunction_Click(object sender, System.EventArgs e) 
	{
        string strDebug  = txtDebugInfo.Text;
        Debug.Indent();

        switch( lstDebugFunction.SelectedIndex)
		{
            case 0: //' Debug:;

            case 1: //' Debug: Write to Console;
                // Use the default Listener: to Console
                Debug.WriteLine(strDebug);
                Debug.Flush();
                sbrPanel2.Text = "Wrote debug output to console";
				break;
            case 2: //' Debug: Write to File;
                // Create a file for output
                string strFile  = "C:/DebugOutput.txt";
                Stream stmFile  = File.Create(strFile);
                // Create a new text writer using the output stream, and add it to
                // the debug listeners. 
                // For demo purposes, we'll first clear all listeners.
                TextWriterTraceListener twTextListener = new TextWriterTraceListener(stmFile);
                Debug.Listeners.Clear();
                Debug.Listeners.Add(twTextListener);
                // Write output to the file.
                Debug.Write(strDebug);
                Debug.Flush();
                sbrPanel2.Text = "Wrote debug output to " + strFile;
				break;
            case 3: //' Debug: Write to event Log;
                // Create a debug listener for the event log.
                EventLogTraceListener logdebugListener = new EventLogTraceListener("C# How-To:ContrastVBNETwithVB6");
                // Add the debug listener to the collection.
                // For demo purposes, we'll first clear all listeners.
                Debug.Listeners.Clear();
                Debug.Listeners.Add(logdebugListener);
                Debug.Write(strDebug);
                Debug.Flush();
                sbrPanel2.Text = "Wrote debug output to event Log";
				break;
            case 4: //' Trace:;

            case 5: //' Trace: Write to Console;
                // Create a custom listener, point it to the Console,
                // and add it to the listeners collection.
                // For demo purposes, we'll first clear all listeners.
                Trace.Listeners.Clear();
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.WriteLine("Testing Trace to Console.");
                Console.WriteLine(strDebug);
                Console.WriteLine("Note that the debug/trace strings are indented for ease of reading.");
                Console.WriteLine("Option: Debug.Indent()");
                Trace.WriteLine("Done testing Trace to Console.");
                Trace.Flush();
                sbrPanel2.Text = "Wrote trace output to console";
				break;
            case 6: //' Trace: Write to File;
                // Create a file for output
				strFile  = "C:/TraceOutput.txt";
                stmFile  = File.Create(strFile);
                // Create a new text writer using the output stream, and add it to
                // the trace listeners. 
                twTextListener = new TextWriterTraceListener(stmFile);
                // For demo purposes, we'll first clear all listeners.
                Trace.Listeners.Clear();
                Trace.Listeners.Add(twTextListener);
                // Write output to the file.
                Trace.Write(strDebug);
                Trace.Flush();
                sbrPanel2.Text = "Wrote trace output to " + strFile;
				break;
            case 7: //' Trace: Write to event Log;
                // Create a trace listener for the event log.
                EventLogTraceListener logTraceListener = new EventLogTraceListener("C# How-To:ContrastVBNETwithVB6");
                // Add the trace listener to the collection.
                // For demo purposes, we'll first clear all listeners.
                Trace.Listeners.Clear();
                Trace.Listeners.Add(logTraceListener);
                Trace.Write(strDebug);
                Trace.Flush();
                sbrPanel2.Text = "Wrote trace output to event Log";
				break;
        }
        Debug.Unindent();
    }

#region " Threading tab ";

    private void btnThreadFunction_Click(object sender, System.EventArgs e) 
	{
        // Create a thread and send it off to run a particular procedure.
        // Meanwhile the cuyrrent thread continues its work.
        Thread newThread = new Thread(new ThreadStart(CalledByThread));
        newThread.Start();
    }

    // The procedure called by the new thread.
    private void CalledByThread()
	{
        txtThreadResult.Text = "This method is running on another thread, started at " + DateTime.Now.ToShortTimeString() + Environment.NewLine;
        txtThreadResult.Text += "Gone to sleep for 5 seconds." + Environment.NewLine;
        Thread.Sleep(5000);
        txtThreadResult.Text += "Now resuming." + Environment.NewLine;
        txtThreadResult.Text += "Method called by thread now ended.";
    }

#endregion

    // See extensive notes on Inheritance, overriding, overloading and scoping 
    // in the Employee class and related classes.
    // Clear the summary textbox.
    private void btnClear_Click(object sender, System.EventArgs e) 
	{
        //ctl Control;
        cboEmployeeType.SelectedIndex = -1;

        foreach(Control ctl in this.Controls)
		{
            if (ctl.GetType() == typeof(TextBox)) 
			{
                ctl.Text = string.Empty;
            }
        }
    }

    // Hire an employee.
    private void btnHire_Click(object sender, System.EventArgs e) 
	{
        if (! ValidateData())
		{
            return;
        }
        switch( cboEmployeeType.SelectedIndex)
		{
            case -1:
                return;
            case 0:
                HireFullTimeEmployee();
				break;
            case 1:
                HirePartTimeEmployee();
				break;
            case 2:
                HireTempEmployee();
				break;
        }
    }

    // Save employee info to disk.

    private void btnSave_Click(object sender, System.EventArgs e) 
	{
        string strResult = null;
        // These simulated save-to-database actions use a shared method
        // of the EmployeeDataManager class.

        switch( cboEmployeeType.SelectedIndex)
		{
            case -1:
                return;
            case 0:
                strResult = EmployeeDataManager.WriteEmployeeData(c_empFull);
				break;
            case 1:
                strResult = EmployeeDataManager.WriteEmployeeData(c_empPart);
				break;
            case 2:
                strResult = EmployeeDataManager.WriteEmployeeData(c_empTemp);
				break;
        }
        MessageBox.Show(strResult, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // This procedure watches for changes in the textboxes and the
    // combobox, and enables the Hire button only when the textboxes all
    // have data.
    private void TextBoxes_TextChanged(object sender, System.EventArgs e) //txtName.TextChanged, txtHireDate.TextChanged, txtSalary.TextChanged, txtSocialServicesID.TextChanged, txtExpectedTermDate.TextChanged, cboEmployeeType.SelectedIndexChanged;
	{
        // Create an instance of the PartTimeEmployee class which is derived from
        // Employee.

        switch( cboEmployeeType.SelectedIndex)
		{
            case -1:
                txtName.Enabled = false;
                txtHireDate.Enabled = false;
                txtSalary.Enabled = false;
                txtSocialServicesID.Enabled = false;
                txtExpectedTermDate.Enabled = false;
				break;
            case 0:
                txtName.Enabled = true;
                txtHireDate.Enabled = true;
                txtSalary.Enabled = true;
                txtSocialServicesID.Enabled = true;
                txtExpectedTermDate.Enabled = false;
				break;
			case 1:
				txtName.Enabled = true;
				txtHireDate.Enabled = true;
				txtSalary.Enabled = true;
				txtSocialServicesID.Enabled = true;
				txtExpectedTermDate.Enabled = false;
				break;
            case 2:
                txtName.Enabled = true;
                txtHireDate.Enabled = true;
                txtSalary.Enabled = true;
                txtSocialServicesID.Enabled = true;
                txtExpectedTermDate.Enabled = true;
				break;
        }

        btnHire.Enabled = txtName.Text.Trim().Length != 0 && 
            txtHireDate.Text.Trim().Length != 0 && 
            txtSalary.Text.Trim().Length != 0 && 
            txtSocialServicesID.Text.Trim().Length != 0 &&
            cboEmployeeType.SelectedIndex >= 0;

        // if Temp Employee is chosen, test for text in the ExpectedTermDate text box.
        if (cboEmployeeType.SelectedIndex == 2) {
            btnHire.Enabled = btnHire.Enabled && txtExpectedTermDate.Text.Trim().Length != 0;
        }
        btnSave.Enabled = false;
    }

    private void HireFullTimeEmployee()
	{
        // Create an instance of the HireFullTimeEmployee class which is derived from
        // Employee.
        c_empFull = new FullTimeEmployee();
        try {
                c_empFull.Hire(txtName.Text.Trim(), (Convert.ToDateTime(txtHireDate.Text.Trim())),
                    (Convert.ToDecimal(txtSalary.Text.Trim())));
                c_empFull.SocialServicesID = txtSocialServicesID.Text.Trim();
                txtResults.Clear();
                txtResults.Text += "Name: " + c_empFull.Name + Environment.NewLine + 
                    "Hire date: " + c_empFull.HireDate + Environment.NewLine + 
                    "Salary: " + c_empFull.Salary + Environment.NewLine + 
                    "Social Services ID: " + c_empFull.SocialServicesID + Environment.NewLine + 
                    "Bonus: " + c_empFull.Bonus + Environment.NewLine + 
                    "Annual Leave: " + c_empFull.AnnualLeave + " days";
            btnSave.Enabled = true;

       }
		catch(Exception exp)
		{
            MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void HirePartTimeEmployee()
	{
        // Create an instance of the PartTimeEmployee class which is derived from
        // Employee.
        c_empPart = new PartTimeEmployee();
        try {
                c_empPart.Hire(txtName.Text.Trim(), (Convert.ToDateTime(txtHireDate.Text.Trim())), 
                   (Convert.ToDecimal(txtSalary.Text.Trim())), 20);
                c_empPart.SocialServicesID = txtSocialServicesID.Text.Trim();
                txtResults.Clear();
                txtResults.Text += "Name: " + c_empPart.Name + Environment.NewLine + 
                    "Hire date: " + c_empPart.HireDate + Environment.NewLine + 
                    "Salary: " + c_empPart.Salary + Environment.NewLine + 
                    "Social Services ID: " + c_empPart.SocialServicesID + Environment.NewLine + 
                    "Bonus: " + c_empPart.Bonus + Environment.NewLine + 
                    "Min hrs. per week: " + c_empPart.MinHoursPerWeek;
            btnSave.Enabled = true;
       } 
		catch(Exception exp )
		{
            MessageBox.Show(exp.Message,this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void HireTempEmployee()
	{
        // Create an instance of the TempEmployee class which is derived from
        // Employee.
        c_empTemp = new TempEmployee();
        try {
                c_empTemp.Hire(txtName.Text.Trim(), (Convert.ToDateTime(txtHireDate.Text.Trim())),
                    (Convert.ToDecimal(txtSalary.Text.Trim())), (Convert.ToDateTime(txtExpectedTermDate.Text.Trim())));
                c_empTemp.SocialServicesID = txtSocialServicesID.Text.Trim();
                txtResults.Clear();
                txtResults.Text += "Name: " + c_empTemp.Name + Environment.NewLine + 
                    "Hire date: " + c_empTemp.HireDate + Environment.NewLine + 
                    "Salary: " + c_empTemp.Salary + Environment.NewLine + 
                    "Social Services ID: " + c_empTemp.SocialServicesID + Environment.NewLine + 
                    "Bonus: " + c_empTemp.Bonus + Environment.NewLine +
                    "Expected termination date: " + c_empTemp.ExpectedTermDate.ToShortDateString();
            btnSave.Enabled = true;

       } catch(Exception exp )
		{
            MessageBox.Show(exp.Message,this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

	public static bool IsDate(string date) 
	{
		DateTime dt;
		bool isDate = true;
		try 
		{
			dt = DateTime.Parse(date);  
			//If this cannot parse, the format is incorrect
		}
		catch (FormatException e) 
		{
			//date string cannot be converted to a date.
			isDate = false;
		} 
		return isDate;
	} 

    private bool ValidateData()
	{
        // Called by the Hire event handler.  Simply checks to make sure that 
        // two values HireDate and SocialServicesID are in the correct format.
		bool dataInValid  = true;

		if (! IsDate(txtHireDate.Text))
		{
            MessageBox.Show("Hire Date must be a date in the format MM/DD/YY.", 
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            dataInValid = false;
        }
        if (txtSocialServicesID.Text.Length != 11)
		{
            MessageBox.Show("Social Services ID must be 11 characters in length", 
             this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            dataInValid = false;
        }
        return (dataInValid);
    }

	private void pgeExceptionHandling_Click(object sender, System.EventArgs e)
	{
	
	}
}

