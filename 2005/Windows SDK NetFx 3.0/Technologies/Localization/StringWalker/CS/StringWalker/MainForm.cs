//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//-----------------------------------------------------------------------
// --------------------------------------------------------------------------
//  MainForm class is just a driver that exercises the StringWalker class
// --------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Globalization;
using System.Reflection;

namespace Microsoft.Samples.StringWalker
{
	public class MainForm : System.Windows.Forms.Form
	{
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox gbInsert;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox BaseString;
    private System.Windows.Forms.TextBox InsertString;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button buttonInsert;
    private System.Windows.Forms.Button buttonWalk;
    private System.Windows.Forms.TextBox InsertPos;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox RemoveCount;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox RemovePos;
    private System.Windows.Forms.Button buttonRemove;
    private System.Windows.Forms.ListBox listBoxWalk;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox FindString;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox FindPos;
    private System.Windows.Forms.Button buttonFind;
    private System.Windows.Forms.Label labelFind;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label labelTEL;
    private System.Windows.Forms.Label labelCL;
		private System.ComponentModel.Container components = null;

    private System.Resources.ResourceManager rm;

		public MainForm()
		{
			InitializeComponent();

      // string initialization:
      BaseString.Text = "abc\uD841\uDC0F\u0061\u030A\u00E5\u017F\u05E9\u05b1\u05d3";

      // initialize resource manager for localizable strings
      rm = new System.Resources.ResourceManager("StringWalker.strings", Assembly.GetExecutingAssembly());
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.labelCL = new System.Windows.Forms.Label();
      this.labelTEL = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.BaseString = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.listBoxWalk = new System.Windows.Forms.ListBox();
      this.buttonWalk = new System.Windows.Forms.Button();
      this.gbInsert = new System.Windows.Forms.GroupBox();
      this.buttonInsert = new System.Windows.Forms.Button();
      this.InsertPos = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.InsertString = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.buttonRemove = new System.Windows.Forms.Button();
      this.RemovePos = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.RemoveCount = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.labelFind = new System.Windows.Forms.Label();
      this.buttonFind = new System.Windows.Forms.Button();
      this.FindPos = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.FindString = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.gbInsert.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.AccessibleDescription = ((string)(resources.GetObject("groupBox1.AccessibleDescription")));
      this.groupBox1.AccessibleName = ((string)(resources.GetObject("groupBox1.AccessibleName")));
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
      this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.labelCL,
                                                                            this.labelTEL,
                                                                            this.label8,
                                                                            this.label7,
                                                                            this.BaseString});
      this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
      this.groupBox1.Enabled = ((bool)(resources.GetObject("groupBox1.Enabled")));
      this.groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("groupBox1.Font")));
      this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
      this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
      this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
      this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = resources.GetString("groupBox1.Text", CultureInfo.CurrentCulture);
      this.groupBox1.Visible = ((bool)(resources.GetObject("groupBox1.Visible")));
      // 
      // labelCL
      // 
      this.labelCL.AccessibleDescription = ((string)(resources.GetObject("labelCL.AccessibleDescription")));
      this.labelCL.AccessibleName = ((string)(resources.GetObject("labelCL.AccessibleName")));
      this.labelCL.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("labelCL.Anchor")));
      this.labelCL.AutoSize = ((bool)(resources.GetObject("labelCL.AutoSize")));
      this.labelCL.BackColor = System.Drawing.SystemColors.Highlight;
      this.labelCL.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("labelCL.Dock")));
      this.labelCL.Enabled = ((bool)(resources.GetObject("labelCL.Enabled")));
      this.labelCL.Font = ((System.Drawing.Font)(resources.GetObject("labelCL.Font")));
      this.labelCL.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.labelCL.Image = ((System.Drawing.Image)(resources.GetObject("labelCL.Image")));
      this.labelCL.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelCL.ImageAlign")));
      this.labelCL.ImageIndex = ((int)(resources.GetObject("labelCL.ImageIndex")));
      this.labelCL.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("labelCL.ImeMode")));
      this.labelCL.Location = ((System.Drawing.Point)(resources.GetObject("labelCL.Location")));
      this.labelCL.Name = "labelCL";
      this.labelCL.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("labelCL.RightToLeft")));
      this.labelCL.Size = ((System.Drawing.Size)(resources.GetObject("labelCL.Size")));
      this.labelCL.TabIndex = ((int)(resources.GetObject("labelCL.TabIndex")));
      this.labelCL.Text = resources.GetString("labelCL.Text");
      this.labelCL.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelCL.TextAlign")));
      this.labelCL.UseMnemonic = false;
      this.labelCL.Visible = ((bool)(resources.GetObject("labelCL.Visible")));
      // 
      // labelTEL
      // 
      this.labelTEL.AccessibleDescription = ((string)(resources.GetObject("labelTEL.AccessibleDescription")));
      this.labelTEL.AccessibleName = ((string)(resources.GetObject("labelTEL.AccessibleName")));
      this.labelTEL.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("labelTEL.Anchor")));
      this.labelTEL.AutoSize = ((bool)(resources.GetObject("labelTEL.AutoSize")));
      this.labelTEL.BackColor = System.Drawing.SystemColors.Highlight;
      this.labelTEL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labelTEL.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("labelTEL.Dock")));
      this.labelTEL.Enabled = ((bool)(resources.GetObject("labelTEL.Enabled")));
      this.labelTEL.Font = ((System.Drawing.Font)(resources.GetObject("labelTEL.Font")));
      this.labelTEL.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.labelTEL.Image = ((System.Drawing.Image)(resources.GetObject("labelTEL.Image")));
      this.labelTEL.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelTEL.ImageAlign")));
      this.labelTEL.ImageIndex = ((int)(resources.GetObject("labelTEL.ImageIndex")));
      this.labelTEL.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("labelTEL.ImeMode")));
      this.labelTEL.Location = ((System.Drawing.Point)(resources.GetObject("labelTEL.Location")));
      this.labelTEL.Name = "labelTEL";
      this.labelTEL.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("labelTEL.RightToLeft")));
      this.labelTEL.Size = ((System.Drawing.Size)(resources.GetObject("labelTEL.Size")));
      this.labelTEL.TabIndex = ((int)(resources.GetObject("labelTEL.TabIndex")));
      this.labelTEL.Text = resources.GetString("labelTEL.Text");
      this.labelTEL.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelTEL.TextAlign")));
      this.labelTEL.UseMnemonic = false;
      this.labelTEL.Visible = ((bool)(resources.GetObject("labelTEL.Visible")));
      // 
      // label8
      // 
      this.label8.AccessibleDescription = ((string)(resources.GetObject("label8.AccessibleDescription")));
      this.label8.AccessibleName = ((string)(resources.GetObject("label8.AccessibleName")));
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label8.Anchor")));
      this.label8.AutoSize = ((bool)(resources.GetObject("label8.AutoSize")));
      this.label8.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label8.Dock")));
      this.label8.Enabled = ((bool)(resources.GetObject("label8.Enabled")));
      this.label8.Font = ((System.Drawing.Font)(resources.GetObject("label8.Font")));
      this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
      this.label8.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label8.ImageAlign")));
      this.label8.ImageIndex = ((int)(resources.GetObject("label8.ImageIndex")));
      this.label8.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label8.ImeMode")));
      this.label8.Location = ((System.Drawing.Point)(resources.GetObject("label8.Location")));
      this.label8.Name = "label8";
      this.label8.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label8.RightToLeft")));
      this.label8.Size = ((System.Drawing.Size)(resources.GetObject("label8.Size")));
      this.label8.TabIndex = ((int)(resources.GetObject("label8.TabIndex")));
      this.label8.Text = resources.GetString("label8.Text");
      this.label8.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label8.TextAlign")));
      this.label8.Visible = ((bool)(resources.GetObject("label8.Visible")));
      // 
      // label7
      // 
      this.label7.AccessibleDescription = ((string)(resources.GetObject("label7.AccessibleDescription")));
      this.label7.AccessibleName = ((string)(resources.GetObject("label7.AccessibleName")));
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label7.Anchor")));
      this.label7.AutoSize = ((bool)(resources.GetObject("label7.AutoSize")));
      this.label7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label7.Dock")));
      this.label7.Enabled = ((bool)(resources.GetObject("label7.Enabled")));
      this.label7.Font = ((System.Drawing.Font)(resources.GetObject("label7.Font")));
      this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
      this.label7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.ImageAlign")));
      this.label7.ImageIndex = ((int)(resources.GetObject("label7.ImageIndex")));
      this.label7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label7.ImeMode")));
      this.label7.Location = ((System.Drawing.Point)(resources.GetObject("label7.Location")));
      this.label7.Name = "label7";
      this.label7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label7.RightToLeft")));
      this.label7.Size = ((System.Drawing.Size)(resources.GetObject("label7.Size")));
      this.label7.TabIndex = ((int)(resources.GetObject("label7.TabIndex")));
      this.label7.Text = resources.GetString("label7.Text");
      this.label7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.TextAlign")));
      this.label7.Visible = ((bool)(resources.GetObject("label7.Visible")));
      // 
      // BaseString
      // 
      this.BaseString.AccessibleDescription = ((string)(resources.GetObject("BaseString.AccessibleDescription")));
      this.BaseString.AccessibleName = ((string)(resources.GetObject("BaseString.AccessibleName")));
      this.BaseString.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BaseString.Anchor")));
      this.BaseString.AutoSize = ((bool)(resources.GetObject("BaseString.AutoSize")));
      this.BaseString.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BaseString.BackgroundImage")));
      this.BaseString.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BaseString.Dock")));
      this.BaseString.Enabled = ((bool)(resources.GetObject("BaseString.Enabled")));
      this.BaseString.Font = ((System.Drawing.Font)(resources.GetObject("BaseString.Font")));
      this.BaseString.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BaseString.ImeMode")));
      this.BaseString.Location = ((System.Drawing.Point)(resources.GetObject("BaseString.Location")));
      this.BaseString.MaxLength = ((int)(resources.GetObject("BaseString.MaxLength")));
      this.BaseString.Multiline = ((bool)(resources.GetObject("BaseString.Multiline")));
      this.BaseString.Name = "BaseString";
      this.BaseString.PasswordChar = ((char)(resources.GetObject("BaseString.PasswordChar")));
      this.BaseString.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BaseString.RightToLeft")));
      this.BaseString.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("BaseString.ScrollBars")));
      this.BaseString.Size = ((System.Drawing.Size)(resources.GetObject("BaseString.Size")));
      this.BaseString.TabIndex = ((int)(resources.GetObject("BaseString.TabIndex")));
      this.BaseString.Text = resources.GetString("BaseString.Text");
      this.BaseString.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("BaseString.TextAlign")));
      this.BaseString.Visible = ((bool)(resources.GetObject("BaseString.Visible")));
      this.BaseString.WordWrap = ((bool)(resources.GetObject("BaseString.WordWrap")));
      this.BaseString.TextChanged += new System.EventHandler(this.onTextChange);
      // 
      // groupBox2
      // 
      this.groupBox2.AccessibleDescription = ((string)(resources.GetObject("groupBox2.AccessibleDescription")));
      this.groupBox2.AccessibleName = ((string)(resources.GetObject("groupBox2.AccessibleName")));
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox2.Anchor")));
      this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
      this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.listBoxWalk,
                                                                            this.buttonWalk});
      this.groupBox2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox2.Dock")));
      this.groupBox2.Enabled = ((bool)(resources.GetObject("groupBox2.Enabled")));
      this.groupBox2.Font = ((System.Drawing.Font)(resources.GetObject("groupBox2.Font")));
      this.groupBox2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox2.ImeMode")));
      this.groupBox2.Location = ((System.Drawing.Point)(resources.GetObject("groupBox2.Location")));
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox2.RightToLeft")));
      this.groupBox2.Size = ((System.Drawing.Size)(resources.GetObject("groupBox2.Size")));
      this.groupBox2.TabIndex = ((int)(resources.GetObject("groupBox2.TabIndex")));
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = resources.GetString("groupBox2.Text");
      this.groupBox2.Visible = ((bool)(resources.GetObject("groupBox2.Visible")));
      // 
      // listBoxWalk
      // 
      this.listBoxWalk.AccessibleDescription = ((string)(resources.GetObject("listBoxWalk.AccessibleDescription")));
      this.listBoxWalk.AccessibleName = ((string)(resources.GetObject("listBoxWalk.AccessibleName")));
      this.listBoxWalk.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("listBoxWalk.Anchor")));
      this.listBoxWalk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listBoxWalk.BackgroundImage")));
      this.listBoxWalk.ColumnWidth = ((int)(resources.GetObject("listBoxWalk.ColumnWidth")));
      this.listBoxWalk.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("listBoxWalk.Dock")));
      this.listBoxWalk.Enabled = ((bool)(resources.GetObject("listBoxWalk.Enabled")));
      this.listBoxWalk.Font = ((System.Drawing.Font)(resources.GetObject("listBoxWalk.Font")));
      this.listBoxWalk.HorizontalExtent = ((int)(resources.GetObject("listBoxWalk.HorizontalExtent")));
      this.listBoxWalk.HorizontalScrollbar = ((bool)(resources.GetObject("listBoxWalk.HorizontalScrollbar")));
      this.listBoxWalk.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("listBoxWalk.ImeMode")));
      this.listBoxWalk.IntegralHeight = ((bool)(resources.GetObject("listBoxWalk.IntegralHeight")));
      this.listBoxWalk.ItemHeight = ((int)(resources.GetObject("listBoxWalk.ItemHeight")));
      this.listBoxWalk.Location = ((System.Drawing.Point)(resources.GetObject("listBoxWalk.Location")));
      this.listBoxWalk.Name = "listBoxWalk";
      this.listBoxWalk.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("listBoxWalk.RightToLeft")));
      this.listBoxWalk.ScrollAlwaysVisible = ((bool)(resources.GetObject("listBoxWalk.ScrollAlwaysVisible")));
      this.listBoxWalk.Size = ((System.Drawing.Size)(resources.GetObject("listBoxWalk.Size")));
      this.listBoxWalk.TabIndex = ((int)(resources.GetObject("listBoxWalk.TabIndex")));
      this.listBoxWalk.Visible = ((bool)(resources.GetObject("listBoxWalk.Visible")));
      // 
      // buttonWalk
      // 
      this.buttonWalk.AccessibleDescription = ((string)(resources.GetObject("buttonWalk.AccessibleDescription")));
      this.buttonWalk.AccessibleName = ((string)(resources.GetObject("buttonWalk.AccessibleName")));
      this.buttonWalk.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonWalk.Anchor")));
      this.buttonWalk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonWalk.BackgroundImage")));
      this.buttonWalk.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonWalk.Dock")));
      this.buttonWalk.Enabled = ((bool)(resources.GetObject("buttonWalk.Enabled")));
      this.buttonWalk.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonWalk.FlatStyle")));
      this.buttonWalk.Font = ((System.Drawing.Font)(resources.GetObject("buttonWalk.Font")));
      this.buttonWalk.Image = ((System.Drawing.Image)(resources.GetObject("buttonWalk.Image")));
      this.buttonWalk.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonWalk.ImageAlign")));
      this.buttonWalk.ImageIndex = ((int)(resources.GetObject("buttonWalk.ImageIndex")));
      this.buttonWalk.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonWalk.ImeMode")));
      this.buttonWalk.Location = ((System.Drawing.Point)(resources.GetObject("buttonWalk.Location")));
      this.buttonWalk.Name = "buttonWalk";
      this.buttonWalk.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonWalk.RightToLeft")));
      this.buttonWalk.Size = ((System.Drawing.Size)(resources.GetObject("buttonWalk.Size")));
      this.buttonWalk.TabIndex = ((int)(resources.GetObject("buttonWalk.TabIndex")));
      this.buttonWalk.Text = resources.GetString("buttonWalk.Text");
      this.buttonWalk.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonWalk.TextAlign")));
      this.buttonWalk.Visible = ((bool)(resources.GetObject("buttonWalk.Visible")));
      this.buttonWalk.Click += new System.EventHandler(this.buttonWalk_Click);
      // 
      // gbInsert
      // 
      this.gbInsert.AccessibleDescription = ((string)(resources.GetObject("gbInsert.AccessibleDescription")));
      this.gbInsert.AccessibleName = ((string)(resources.GetObject("gbInsert.AccessibleName")));
      this.gbInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gbInsert.Anchor")));
      this.gbInsert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbInsert.BackgroundImage")));
      this.gbInsert.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.buttonInsert,
                                                                           this.InsertPos,
                                                                           this.label2,
                                                                           this.InsertString,
                                                                           this.label1});
      this.gbInsert.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("gbInsert.Dock")));
      this.gbInsert.Enabled = ((bool)(resources.GetObject("gbInsert.Enabled")));
      this.gbInsert.Font = ((System.Drawing.Font)(resources.GetObject("gbInsert.Font")));
      this.gbInsert.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gbInsert.ImeMode")));
      this.gbInsert.Location = ((System.Drawing.Point)(resources.GetObject("gbInsert.Location")));
      this.gbInsert.Name = "gbInsert";
      this.gbInsert.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("gbInsert.RightToLeft")));
      this.gbInsert.Size = ((System.Drawing.Size)(resources.GetObject("gbInsert.Size")));
      this.gbInsert.TabIndex = ((int)(resources.GetObject("gbInsert.TabIndex")));
      this.gbInsert.TabStop = false;
      this.gbInsert.Text = resources.GetString("gbInsert.Text");
      this.gbInsert.Visible = ((bool)(resources.GetObject("gbInsert.Visible")));
      // 
      // buttonInsert
      // 
      this.buttonInsert.AccessibleDescription = ((string)(resources.GetObject("buttonInsert.AccessibleDescription")));
      this.buttonInsert.AccessibleName = ((string)(resources.GetObject("buttonInsert.AccessibleName")));
      this.buttonInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonInsert.Anchor")));
      this.buttonInsert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInsert.BackgroundImage")));
      this.buttonInsert.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonInsert.Dock")));
      this.buttonInsert.Enabled = ((bool)(resources.GetObject("buttonInsert.Enabled")));
      this.buttonInsert.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonInsert.FlatStyle")));
      this.buttonInsert.Font = ((System.Drawing.Font)(resources.GetObject("buttonInsert.Font")));
      this.buttonInsert.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsert.Image")));
      this.buttonInsert.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonInsert.ImageAlign")));
      this.buttonInsert.ImageIndex = ((int)(resources.GetObject("buttonInsert.ImageIndex")));
      this.buttonInsert.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonInsert.ImeMode")));
      this.buttonInsert.Location = ((System.Drawing.Point)(resources.GetObject("buttonInsert.Location")));
      this.buttonInsert.Name = "buttonInsert";
      this.buttonInsert.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonInsert.RightToLeft")));
      this.buttonInsert.Size = ((System.Drawing.Size)(resources.GetObject("buttonInsert.Size")));
      this.buttonInsert.TabIndex = ((int)(resources.GetObject("buttonInsert.TabIndex")));
      this.buttonInsert.Text = resources.GetString("buttonInsert.Text");
      this.buttonInsert.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonInsert.TextAlign")));
      this.buttonInsert.Visible = ((bool)(resources.GetObject("buttonInsert.Visible")));
      this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
      // 
      // InsertPos
      // 
      this.InsertPos.AccessibleDescription = ((string)(resources.GetObject("InsertPos.AccessibleDescription")));
      this.InsertPos.AccessibleName = ((string)(resources.GetObject("InsertPos.AccessibleName")));
      this.InsertPos.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("InsertPos.Anchor")));
      this.InsertPos.AutoSize = ((bool)(resources.GetObject("InsertPos.AutoSize")));
      this.InsertPos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InsertPos.BackgroundImage")));
      this.InsertPos.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("InsertPos.Dock")));
      this.InsertPos.Enabled = ((bool)(resources.GetObject("InsertPos.Enabled")));
      this.InsertPos.Font = ((System.Drawing.Font)(resources.GetObject("InsertPos.Font")));
      this.InsertPos.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("InsertPos.ImeMode")));
      this.InsertPos.Location = ((System.Drawing.Point)(resources.GetObject("InsertPos.Location")));
      this.InsertPos.MaxLength = ((int)(resources.GetObject("InsertPos.MaxLength")));
      this.InsertPos.Multiline = ((bool)(resources.GetObject("InsertPos.Multiline")));
      this.InsertPos.Name = "InsertPos";
      this.InsertPos.PasswordChar = ((char)(resources.GetObject("InsertPos.PasswordChar")));
      this.InsertPos.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("InsertPos.RightToLeft")));
      this.InsertPos.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("InsertPos.ScrollBars")));
      this.InsertPos.Size = ((System.Drawing.Size)(resources.GetObject("InsertPos.Size")));
      this.InsertPos.TabIndex = ((int)(resources.GetObject("InsertPos.TabIndex")));
      this.InsertPos.Text = resources.GetString("InsertPos.Text");
      this.InsertPos.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("InsertPos.TextAlign")));
      this.InsertPos.Visible = ((bool)(resources.GetObject("InsertPos.Visible")));
      this.InsertPos.WordWrap = ((bool)(resources.GetObject("InsertPos.WordWrap")));
      // 
      // label2
      // 
      this.label2.AccessibleDescription = ((string)(resources.GetObject("label2.AccessibleDescription")));
      this.label2.AccessibleName = ((string)(resources.GetObject("label2.AccessibleName")));
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
      this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
      this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
      this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
      this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
      this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
      this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
      this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
      this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
      this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
      this.label2.Name = "label2";
      this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
      this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
      this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
      this.label2.Text = resources.GetString("label2.Text");
      this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
      this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
      // 
      // InsertString
      // 
      this.InsertString.AccessibleDescription = ((string)(resources.GetObject("InsertString.AccessibleDescription")));
      this.InsertString.AccessibleName = ((string)(resources.GetObject("InsertString.AccessibleName")));
      this.InsertString.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("InsertString.Anchor")));
      this.InsertString.AutoSize = ((bool)(resources.GetObject("InsertString.AutoSize")));
      this.InsertString.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InsertString.BackgroundImage")));
      this.InsertString.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("InsertString.Dock")));
      this.InsertString.Enabled = ((bool)(resources.GetObject("InsertString.Enabled")));
      this.InsertString.Font = ((System.Drawing.Font)(resources.GetObject("InsertString.Font")));
      this.InsertString.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("InsertString.ImeMode")));
      this.InsertString.Location = ((System.Drawing.Point)(resources.GetObject("InsertString.Location")));
      this.InsertString.MaxLength = ((int)(resources.GetObject("InsertString.MaxLength")));
      this.InsertString.Multiline = ((bool)(resources.GetObject("InsertString.Multiline")));
      this.InsertString.Name = "InsertString";
      this.InsertString.PasswordChar = ((char)(resources.GetObject("InsertString.PasswordChar")));
      this.InsertString.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("InsertString.RightToLeft")));
      this.InsertString.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("InsertString.ScrollBars")));
      this.InsertString.Size = ((System.Drawing.Size)(resources.GetObject("InsertString.Size")));
      this.InsertString.TabIndex = ((int)(resources.GetObject("InsertString.TabIndex")));
      this.InsertString.Text = resources.GetString("InsertString.Text");
      this.InsertString.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("InsertString.TextAlign")));
      this.InsertString.Visible = ((bool)(resources.GetObject("InsertString.Visible")));
      this.InsertString.WordWrap = ((bool)(resources.GetObject("InsertString.WordWrap")));
      // 
      // label1
      // 
      this.label1.AccessibleDescription = ((string)(resources.GetObject("label1.AccessibleDescription")));
      this.label1.AccessibleName = ((string)(resources.GetObject("label1.AccessibleName")));
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
      this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
      this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
      this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
      this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
      this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
      this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
      this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
      this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
      this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
      this.label1.Name = "label1";
      this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
      this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
      this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
      this.label1.Text = resources.GetString("label1.Text");
      this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
      this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
      // 
      // groupBox3
      // 
      this.groupBox3.AccessibleDescription = ((string)(resources.GetObject("groupBox3.AccessibleDescription")));
      this.groupBox3.AccessibleName = ((string)(resources.GetObject("groupBox3.AccessibleName")));
      this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox3.Anchor")));
      this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
      this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.buttonRemove,
                                                                            this.RemovePos,
                                                                            this.label4,
                                                                            this.RemoveCount,
                                                                            this.label3});
      this.groupBox3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox3.Dock")));
      this.groupBox3.Enabled = ((bool)(resources.GetObject("groupBox3.Enabled")));
      this.groupBox3.Font = ((System.Drawing.Font)(resources.GetObject("groupBox3.Font")));
      this.groupBox3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox3.ImeMode")));
      this.groupBox3.Location = ((System.Drawing.Point)(resources.GetObject("groupBox3.Location")));
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox3.RightToLeft")));
      this.groupBox3.Size = ((System.Drawing.Size)(resources.GetObject("groupBox3.Size")));
      this.groupBox3.TabIndex = ((int)(resources.GetObject("groupBox3.TabIndex")));
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = resources.GetString("groupBox3.Text");
      this.groupBox3.Visible = ((bool)(resources.GetObject("groupBox3.Visible")));
      // 
      // buttonRemove
      // 
      this.buttonRemove.AccessibleDescription = ((string)(resources.GetObject("buttonRemove.AccessibleDescription")));
      this.buttonRemove.AccessibleName = ((string)(resources.GetObject("buttonRemove.AccessibleName")));
      this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonRemove.Anchor")));
      this.buttonRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRemove.BackgroundImage")));
      this.buttonRemove.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonRemove.Dock")));
      this.buttonRemove.Enabled = ((bool)(resources.GetObject("buttonRemove.Enabled")));
      this.buttonRemove.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonRemove.FlatStyle")));
      this.buttonRemove.Font = ((System.Drawing.Font)(resources.GetObject("buttonRemove.Font")));
      this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
      this.buttonRemove.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonRemove.ImageAlign")));
      this.buttonRemove.ImageIndex = ((int)(resources.GetObject("buttonRemove.ImageIndex")));
      this.buttonRemove.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonRemove.ImeMode")));
      this.buttonRemove.Location = ((System.Drawing.Point)(resources.GetObject("buttonRemove.Location")));
      this.buttonRemove.Name = "buttonRemove";
      this.buttonRemove.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonRemove.RightToLeft")));
      this.buttonRemove.Size = ((System.Drawing.Size)(resources.GetObject("buttonRemove.Size")));
      this.buttonRemove.TabIndex = ((int)(resources.GetObject("buttonRemove.TabIndex")));
      this.buttonRemove.Text = resources.GetString("buttonRemove.Text");
      this.buttonRemove.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonRemove.TextAlign")));
      this.buttonRemove.Visible = ((bool)(resources.GetObject("buttonRemove.Visible")));
      this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
      // 
      // RemovePos
      // 
      this.RemovePos.AccessibleDescription = ((string)(resources.GetObject("RemovePos.AccessibleDescription")));
      this.RemovePos.AccessibleName = ((string)(resources.GetObject("RemovePos.AccessibleName")));
      this.RemovePos.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("RemovePos.Anchor")));
      this.RemovePos.AutoSize = ((bool)(resources.GetObject("RemovePos.AutoSize")));
      this.RemovePos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemovePos.BackgroundImage")));
      this.RemovePos.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("RemovePos.Dock")));
      this.RemovePos.Enabled = ((bool)(resources.GetObject("RemovePos.Enabled")));
      this.RemovePos.Font = ((System.Drawing.Font)(resources.GetObject("RemovePos.Font")));
      this.RemovePos.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("RemovePos.ImeMode")));
      this.RemovePos.Location = ((System.Drawing.Point)(resources.GetObject("RemovePos.Location")));
      this.RemovePos.MaxLength = ((int)(resources.GetObject("RemovePos.MaxLength")));
      this.RemovePos.Multiline = ((bool)(resources.GetObject("RemovePos.Multiline")));
      this.RemovePos.Name = "RemovePos";
      this.RemovePos.PasswordChar = ((char)(resources.GetObject("RemovePos.PasswordChar")));
      this.RemovePos.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("RemovePos.RightToLeft")));
      this.RemovePos.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("RemovePos.ScrollBars")));
      this.RemovePos.Size = ((System.Drawing.Size)(resources.GetObject("RemovePos.Size")));
      this.RemovePos.TabIndex = ((int)(resources.GetObject("RemovePos.TabIndex")));
      this.RemovePos.Text = resources.GetString("RemovePos.Text");
      this.RemovePos.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("RemovePos.TextAlign")));
      this.RemovePos.Visible = ((bool)(resources.GetObject("RemovePos.Visible")));
      this.RemovePos.WordWrap = ((bool)(resources.GetObject("RemovePos.WordWrap")));
      // 
      // label4
      // 
      this.label4.AccessibleDescription = ((string)(resources.GetObject("label4.AccessibleDescription")));
      this.label4.AccessibleName = ((string)(resources.GetObject("label4.AccessibleName")));
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
      this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
      this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
      this.label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
      this.label4.Font = ((System.Drawing.Font)(resources.GetObject("label4.Font")));
      this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
      this.label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.ImageAlign")));
      this.label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
      this.label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode")));
      this.label4.Location = ((System.Drawing.Point)(resources.GetObject("label4.Location")));
      this.label4.Name = "label4";
      this.label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label4.RightToLeft")));
      this.label4.Size = ((System.Drawing.Size)(resources.GetObject("label4.Size")));
      this.label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
      this.label4.Text = resources.GetString("label4.Text");
      this.label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.TextAlign")));
      this.label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
      // 
      // RemoveCount
      // 
      this.RemoveCount.AccessibleDescription = ((string)(resources.GetObject("RemoveCount.AccessibleDescription")));
      this.RemoveCount.AccessibleName = ((string)(resources.GetObject("RemoveCount.AccessibleName")));
      this.RemoveCount.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("RemoveCount.Anchor")));
      this.RemoveCount.AutoSize = ((bool)(resources.GetObject("RemoveCount.AutoSize")));
      this.RemoveCount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveCount.BackgroundImage")));
      this.RemoveCount.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("RemoveCount.Dock")));
      this.RemoveCount.Enabled = ((bool)(resources.GetObject("RemoveCount.Enabled")));
      this.RemoveCount.Font = ((System.Drawing.Font)(resources.GetObject("RemoveCount.Font")));
      this.RemoveCount.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("RemoveCount.ImeMode")));
      this.RemoveCount.Location = ((System.Drawing.Point)(resources.GetObject("RemoveCount.Location")));
      this.RemoveCount.MaxLength = ((int)(resources.GetObject("RemoveCount.MaxLength")));
      this.RemoveCount.Multiline = ((bool)(resources.GetObject("RemoveCount.Multiline")));
      this.RemoveCount.Name = "RemoveCount";
      this.RemoveCount.PasswordChar = ((char)(resources.GetObject("RemoveCount.PasswordChar")));
      this.RemoveCount.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("RemoveCount.RightToLeft")));
      this.RemoveCount.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("RemoveCount.ScrollBars")));
      this.RemoveCount.Size = ((System.Drawing.Size)(resources.GetObject("RemoveCount.Size")));
      this.RemoveCount.TabIndex = ((int)(resources.GetObject("RemoveCount.TabIndex")));
      this.RemoveCount.Text = resources.GetString("RemoveCount.Text");
      this.RemoveCount.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("RemoveCount.TextAlign")));
      this.RemoveCount.Visible = ((bool)(resources.GetObject("RemoveCount.Visible")));
      this.RemoveCount.WordWrap = ((bool)(resources.GetObject("RemoveCount.WordWrap")));
      // 
      // label3
      // 
      this.label3.AccessibleDescription = ((string)(resources.GetObject("label3.AccessibleDescription")));
      this.label3.AccessibleName = ((string)(resources.GetObject("label3.AccessibleName")));
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
      this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
      this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
      this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
      this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
      this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
      this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
      this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
      this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
      this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
      this.label3.Name = "label3";
      this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
      this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
      this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
      this.label3.Text = resources.GetString("label3.Text");
      this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
      this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
      // 
      // groupBox4
      // 
      this.groupBox4.AccessibleDescription = ((string)(resources.GetObject("groupBox4.AccessibleDescription")));
      this.groupBox4.AccessibleName = ((string)(resources.GetObject("groupBox4.AccessibleName")));
      this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox4.Anchor")));
      this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
      this.groupBox4.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.labelFind,
                                                                            this.buttonFind,
                                                                            this.FindPos,
                                                                            this.label6,
                                                                            this.FindString,
                                                                            this.label5});
      this.groupBox4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox4.Dock")));
      this.groupBox4.Enabled = ((bool)(resources.GetObject("groupBox4.Enabled")));
      this.groupBox4.Font = ((System.Drawing.Font)(resources.GetObject("groupBox4.Font")));
      this.groupBox4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox4.ImeMode")));
      this.groupBox4.Location = ((System.Drawing.Point)(resources.GetObject("groupBox4.Location")));
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox4.RightToLeft")));
      this.groupBox4.Size = ((System.Drawing.Size)(resources.GetObject("groupBox4.Size")));
      this.groupBox4.TabIndex = ((int)(resources.GetObject("groupBox4.TabIndex")));
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = resources.GetString("groupBox4.Text");
      this.groupBox4.Visible = ((bool)(resources.GetObject("groupBox4.Visible")));
      // 
      // labelFind
      // 
      this.labelFind.AccessibleDescription = ((string)(resources.GetObject("labelFind.AccessibleDescription")));
      this.labelFind.AccessibleName = ((string)(resources.GetObject("labelFind.AccessibleName")));
      this.labelFind.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("labelFind.Anchor")));
      this.labelFind.AutoSize = ((bool)(resources.GetObject("labelFind.AutoSize")));
      this.labelFind.BackColor = System.Drawing.SystemColors.Highlight;
      this.labelFind.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labelFind.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("labelFind.Dock")));
      this.labelFind.Enabled = ((bool)(resources.GetObject("labelFind.Enabled")));
      this.labelFind.Font = ((System.Drawing.Font)(resources.GetObject("labelFind.Font")));
      this.labelFind.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.labelFind.Image = ((System.Drawing.Image)(resources.GetObject("labelFind.Image")));
      this.labelFind.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelFind.ImageAlign")));
      this.labelFind.ImageIndex = ((int)(resources.GetObject("labelFind.ImageIndex")));
      this.labelFind.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("labelFind.ImeMode")));
      this.labelFind.Location = ((System.Drawing.Point)(resources.GetObject("labelFind.Location")));
      this.labelFind.Name = "labelFind";
      this.labelFind.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("labelFind.RightToLeft")));
      this.labelFind.Size = ((System.Drawing.Size)(resources.GetObject("labelFind.Size")));
      this.labelFind.TabIndex = ((int)(resources.GetObject("labelFind.TabIndex")));
      this.labelFind.Text = resources.GetString("labelFind.Text");
      this.labelFind.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelFind.TextAlign")));
      this.labelFind.Visible = ((bool)(resources.GetObject("labelFind.Visible")));
      // 
      // buttonFind
      // 
      this.buttonFind.AccessibleDescription = ((string)(resources.GetObject("buttonFind.AccessibleDescription")));
      this.buttonFind.AccessibleName = ((string)(resources.GetObject("buttonFind.AccessibleName")));
      this.buttonFind.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonFind.Anchor")));
      this.buttonFind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonFind.BackgroundImage")));
      this.buttonFind.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonFind.Dock")));
      this.buttonFind.Enabled = ((bool)(resources.GetObject("buttonFind.Enabled")));
      this.buttonFind.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonFind.FlatStyle")));
      this.buttonFind.Font = ((System.Drawing.Font)(resources.GetObject("buttonFind.Font")));
      this.buttonFind.Image = ((System.Drawing.Image)(resources.GetObject("buttonFind.Image")));
      this.buttonFind.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonFind.ImageAlign")));
      this.buttonFind.ImageIndex = ((int)(resources.GetObject("buttonFind.ImageIndex")));
      this.buttonFind.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonFind.ImeMode")));
      this.buttonFind.Location = ((System.Drawing.Point)(resources.GetObject("buttonFind.Location")));
      this.buttonFind.Name = "buttonFind";
      this.buttonFind.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonFind.RightToLeft")));
      this.buttonFind.Size = ((System.Drawing.Size)(resources.GetObject("buttonFind.Size")));
      this.buttonFind.TabIndex = ((int)(resources.GetObject("buttonFind.TabIndex")));
      this.buttonFind.Text = resources.GetString("buttonFind.Text");
      this.buttonFind.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonFind.TextAlign")));
      this.buttonFind.Visible = ((bool)(resources.GetObject("buttonFind.Visible")));
      this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
      // 
      // FindPos
      // 
      this.FindPos.AccessibleDescription = ((string)(resources.GetObject("FindPos.AccessibleDescription")));
      this.FindPos.AccessibleName = ((string)(resources.GetObject("FindPos.AccessibleName")));
      this.FindPos.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("FindPos.Anchor")));
      this.FindPos.AutoSize = ((bool)(resources.GetObject("FindPos.AutoSize")));
      this.FindPos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FindPos.BackgroundImage")));
      this.FindPos.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("FindPos.Dock")));
      this.FindPos.Enabled = ((bool)(resources.GetObject("FindPos.Enabled")));
      this.FindPos.Font = ((System.Drawing.Font)(resources.GetObject("FindPos.Font")));
      this.FindPos.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("FindPos.ImeMode")));
      this.FindPos.Location = ((System.Drawing.Point)(resources.GetObject("FindPos.Location")));
      this.FindPos.MaxLength = ((int)(resources.GetObject("FindPos.MaxLength")));
      this.FindPos.Multiline = ((bool)(resources.GetObject("FindPos.Multiline")));
      this.FindPos.Name = "FindPos";
      this.FindPos.PasswordChar = ((char)(resources.GetObject("FindPos.PasswordChar")));
      this.FindPos.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("FindPos.RightToLeft")));
      this.FindPos.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("FindPos.ScrollBars")));
      this.FindPos.Size = ((System.Drawing.Size)(resources.GetObject("FindPos.Size")));
      this.FindPos.TabIndex = ((int)(resources.GetObject("FindPos.TabIndex")));
      this.FindPos.Text = resources.GetString("FindPos.Text");
      this.FindPos.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("FindPos.TextAlign")));
      this.FindPos.Visible = ((bool)(resources.GetObject("FindPos.Visible")));
      this.FindPos.WordWrap = ((bool)(resources.GetObject("FindPos.WordWrap")));
      // 
      // label6
      // 
      this.label6.AccessibleDescription = ((string)(resources.GetObject("label6.AccessibleDescription")));
      this.label6.AccessibleName = ((string)(resources.GetObject("label6.AccessibleName")));
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label6.Anchor")));
      this.label6.AutoSize = ((bool)(resources.GetObject("label6.AutoSize")));
      this.label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label6.Dock")));
      this.label6.Enabled = ((bool)(resources.GetObject("label6.Enabled")));
      this.label6.Font = ((System.Drawing.Font)(resources.GetObject("label6.Font")));
      this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
      this.label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.ImageAlign")));
      this.label6.ImageIndex = ((int)(resources.GetObject("label6.ImageIndex")));
      this.label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label6.ImeMode")));
      this.label6.Location = ((System.Drawing.Point)(resources.GetObject("label6.Location")));
      this.label6.Name = "label6";
      this.label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label6.RightToLeft")));
      this.label6.Size = ((System.Drawing.Size)(resources.GetObject("label6.Size")));
      this.label6.TabIndex = ((int)(resources.GetObject("label6.TabIndex")));
      this.label6.Text = resources.GetString("label6.Text");
      this.label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.TextAlign")));
      this.label6.Visible = ((bool)(resources.GetObject("label6.Visible")));
      // 
      // FindString
      // 
      this.FindString.AccessibleDescription = ((string)(resources.GetObject("FindString.AccessibleDescription")));
      this.FindString.AccessibleName = ((string)(resources.GetObject("FindString.AccessibleName")));
      this.FindString.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("FindString.Anchor")));
      this.FindString.AutoSize = ((bool)(resources.GetObject("FindString.AutoSize")));
      this.FindString.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FindString.BackgroundImage")));
      this.FindString.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("FindString.Dock")));
      this.FindString.Enabled = ((bool)(resources.GetObject("FindString.Enabled")));
      this.FindString.Font = ((System.Drawing.Font)(resources.GetObject("FindString.Font")));
      this.FindString.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("FindString.ImeMode")));
      this.FindString.Location = ((System.Drawing.Point)(resources.GetObject("FindString.Location")));
      this.FindString.MaxLength = ((int)(resources.GetObject("FindString.MaxLength")));
      this.FindString.Multiline = ((bool)(resources.GetObject("FindString.Multiline")));
      this.FindString.Name = "FindString";
      this.FindString.PasswordChar = ((char)(resources.GetObject("FindString.PasswordChar")));
      this.FindString.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("FindString.RightToLeft")));
      this.FindString.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("FindString.ScrollBars")));
      this.FindString.Size = ((System.Drawing.Size)(resources.GetObject("FindString.Size")));
      this.FindString.TabIndex = ((int)(resources.GetObject("FindString.TabIndex")));
      this.FindString.Text = resources.GetString("FindString.Text");
      this.FindString.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("FindString.TextAlign")));
      this.FindString.Visible = ((bool)(resources.GetObject("FindString.Visible")));
      this.FindString.WordWrap = ((bool)(resources.GetObject("FindString.WordWrap")));
      // 
      // label5
      // 
      this.label5.AccessibleDescription = ((string)(resources.GetObject("label5.AccessibleDescription")));
      this.label5.AccessibleName = ((string)(resources.GetObject("label5.AccessibleName")));
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label5.Anchor")));
      this.label5.AutoSize = ((bool)(resources.GetObject("label5.AutoSize")));
      this.label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label5.Dock")));
      this.label5.Enabled = ((bool)(resources.GetObject("label5.Enabled")));
      this.label5.Font = ((System.Drawing.Font)(resources.GetObject("label5.Font")));
      this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
      this.label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.ImageAlign")));
      this.label5.ImageIndex = ((int)(resources.GetObject("label5.ImageIndex")));
      this.label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label5.ImeMode")));
      this.label5.Location = ((System.Drawing.Point)(resources.GetObject("label5.Location")));
      this.label5.Name = "label5";
      this.label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label5.RightToLeft")));
      this.label5.Size = ((System.Drawing.Size)(resources.GetObject("label5.Size")));
      this.label5.TabIndex = ((int)(resources.GetObject("label5.TabIndex")));
      this.label5.Text = resources.GetString("label5.Text");
      this.label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.TextAlign")));
      this.label5.Visible = ((bool)(resources.GetObject("label5.Visible")));
      // 
      // MainForm
      // 
      this.AccessibleDescription = ((string)(resources.GetObject("$this.AccessibleDescription")));
      this.AccessibleName = ((string)(resources.GetObject("$this.AccessibleName")));
      this.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("$this.Anchor")));
      this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
      this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
      this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
      this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
      this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.groupBox4,
                                                                  this.groupBox3,
                                                                  this.gbInsert,
                                                                  this.groupBox2,
                                                                  this.groupBox1});
      this.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("$this.Dock")));
      this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
      this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
      this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
      this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
      this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
      this.Name = "MainForm";
      this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
      this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
      this.Text = resources.GetString("$this.Text");
      this.Visible = ((bool)(resources.GetObject("$this.Visible")));
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.gbInsert.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

		/// The main entry point for the application.
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

    private void buttonWalk_Click(object sender, System.EventArgs e)
    {
      StringWalker sw = new StringWalker(BaseString.Text);
      String input = String.Empty;
      listBoxWalk.Items.Clear();

      // get the first text element
	  bool fcontinue = sw.GetFirst(out input);

	  while(fcontinue)
      {
        StringBuilder sb = new StringBuilder();

		sb.AppendFormat("{0}\t", input);
		foreach (char c in input)
		{
          UnicodeCategory uc = Char.GetUnicodeCategory(c);
          switch(uc)
          {
            case UnicodeCategory.Surrogate:
              sb.AppendFormat(rm.GetString("surrogate", CultureInfo.CurrentCulture));
              break;

            case UnicodeCategory.NonSpacingMark:
              sb.AppendFormat(rm.GetString("nonspacingmark", CultureInfo.CurrentCulture));
              break;

            default:
              break;
          }
        }

        listBoxWalk.Items.Add(sb.ToString());

        // get the next text element
        fcontinue = sw.GetNext(out input);
      }
    }

    private void buttonInsert_Click(object sender, System.EventArgs e)
    {
      try
      {
		  int pos = Int32.Parse(InsertPos.Text, CultureInfo.CurrentCulture);
		  StringWalker sw = new StringWalker(BaseString.Text);

        if(sw.Insert(pos, InsertString.Text))
          BaseString.Text = sw.ToString();
        else
		  MessageBox.Show(this, rm.GetString("err-insert1", CultureInfo.CurrentCulture));
  }
      catch
      {
		  MessageBox.Show(this, rm.GetString("err-insert2", CultureInfo.CurrentCulture));
	  }
    }

    private void buttonRemove_Click(object sender, System.EventArgs e)
    {
      try
      {
		  int pos = Int32.Parse(RemovePos.Text, CultureInfo.CurrentCulture);
		  int count = Int32.Parse(RemoveCount.Text, CultureInfo.CurrentCulture);
		  StringWalker sw = new StringWalker(BaseString.Text);

        if(sw.Remove(pos, count))
          BaseString.Text = sw.ToString();
        else
		  MessageBox.Show(this, rm.GetString("err-remove1", CultureInfo.CurrentCulture));
  }
      catch
      {
		  MessageBox.Show(this, rm.GetString("err-remove2", CultureInfo.CurrentCulture));
	  }
    }

    private void buttonFind_Click(object sender, System.EventArgs e)
    {
      try
      {
		  int pos = Int32.Parse(FindPos.Text, CultureInfo.CurrentCulture);
		  StringWalker sw = new StringWalker(BaseString.Text);

        int foundPos = sw.IndexOf(FindString.Text, pos);
        if(-1 == foundPos)
			labelFind.Text = rm.GetString("notfound", CultureInfo.CurrentCulture);
		else
			labelFind.Text = String.Format(rm.GetString("foundformat", CultureInfo.CurrentCulture), FindString.Text, foundPos);
	}
      catch
      {
		  MessageBox.Show(this, rm.GetString("err-find", CultureInfo.CurrentCulture));
	  }
    }

    private void onTextChange(object sender, System.EventArgs e)
    {
      StringWalker sw = new StringWalker(BaseString.Text);
      labelTEL.Text = sw.Length.ToString(CultureInfo.CurrentCulture);
      labelCL.Text  = BaseString.Text.Length.ToString(CultureInfo.CurrentCulture);
    }
	}
}
