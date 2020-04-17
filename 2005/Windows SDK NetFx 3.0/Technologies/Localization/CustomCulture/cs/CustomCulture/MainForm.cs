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
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Reflection;
using System.Resources;

namespace Microsoft.Samples.Localization.CustomCulture
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label labelDate;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton radioENUS;
    private System.Windows.Forms.RadioButton radioCUSTOM;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label labelCulture;
    private System.Windows.Forms.Button buttonClose;
    private System.Windows.Forms.PictureBox imageBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			InitializeComponent();

      // set culture to en-US
      radioENUS.Checked = true;
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
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.labelCulture = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.labelDate = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.imageBox = new System.Windows.Forms.PictureBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.radioCUSTOM = new System.Windows.Forms.RadioButton();
      this.radioENUS = new System.Windows.Forms.RadioButton();
      this.buttonClose = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(9, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(353, 43);
      this.label1.TabIndex = 0;
      this.label1.Text = "This application shows how to create and use a custom culture to both display a r" +
        "esource and  format a numeric value using a currency format";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.labelCulture,
                                                                            this.label3,
                                                                            this.labelDate,
                                                                            this.label2,
                                                                            this.imageBox});
      this.groupBox1.Location = new System.Drawing.Point(9, 61);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(361, 122);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Culture related information";
      // 
      // labelCulture
      // 
      this.labelCulture.Location = new System.Drawing.Point(107, 97);
      this.labelCulture.Name = "labelCulture";
      this.labelCulture.Size = new System.Drawing.Size(242, 15);
      this.labelCulture.TabIndex = 4;
      this.labelCulture.Text = "[culture goes here]";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(17, 97);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(68, 15);
      this.label3.TabIndex = 3;
      this.label3.Text = "Culture: ";
      // 
      // labelDate
      // 
      this.labelDate.BackColor = System.Drawing.SystemColors.Highlight;
      this.labelDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labelDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.labelDate.ForeColor = System.Drawing.SystemColors.HighlightText;
      this.labelDate.Location = new System.Drawing.Point(129, 48);
      this.labelDate.Name = "labelDate";
      this.labelDate.Size = new System.Drawing.Size(224, 23);
      this.labelDate.TabIndex = 2;
      this.labelDate.Text = "[amount goes here]";
      this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(129, 24);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(184, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "Amount";
      // 
      // imageBox
      // 
      this.imageBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.imageBox.Location = new System.Drawing.Point(17, 25);
      this.imageBox.Name = "imageBox";
      this.imageBox.Size = new System.Drawing.Size(90, 60);
      this.imageBox.TabIndex = 0;
      this.imageBox.TabStop = false;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.radioCUSTOM,
                                                                            this.radioENUS});
      this.groupBox2.Location = new System.Drawing.Point(9, 191);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(194, 81);
      this.groupBox2.TabIndex = 2;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Select culture:";
      // 
      // radioCUSTOM
      // 
      this.radioCUSTOM.Location = new System.Drawing.Point(17, 50);
      this.radioCUSTOM.Name = "radioCUSTOM";
      this.radioCUSTOM.Size = new System.Drawing.Size(161, 19);
      this.radioCUSTOM.TabIndex = 1;
      this.radioCUSTOM.Text = "Custom-culture";
      this.radioCUSTOM.CheckedChanged += new System.EventHandler(this.radioCUSTOM_CheckedChanged);
      // 
      // radioENUS
      // 
      this.radioENUS.Location = new System.Drawing.Point(17, 24);
      this.radioENUS.Name = "radioENUS";
      this.radioENUS.Size = new System.Drawing.Size(161, 19);
      this.radioENUS.TabIndex = 0;
      this.radioENUS.Text = "English (United States)";
      this.radioENUS.CheckedChanged += new System.EventHandler(this.radioENUS_CheckedChanged);
      // 
      // buttonClose
      // 
      this.buttonClose.Location = new System.Drawing.Point(295, 240);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new System.Drawing.Size(75, 32);
      this.buttonClose.TabIndex = 3;
      this.buttonClose.Text = "Close";
      this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(376, 280);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.buttonClose,
                                                                  this.groupBox2,
                                                                  this.groupBox1,
                                                                  this.label1});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "MainForm";
      this.Text = "CustomCulture Demo";
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

    private void radioENUS_CheckedChanged(object sender, System.EventArgs e)
    {
      SetCulture(new CultureInfo("en-US"));
    }

    private void radioCUSTOM_CheckedChanged(object sender, System.EventArgs e)
    {
      SetCulture(new customCultureInfo("en-US", "xyz"));
    }

    private void buttonClose_Click(object sender, System.EventArgs e)
    {
      Close();
    }

    // the SetCulture method is the one responsible for setting the culture
    // and updating the resource and the date information on the form
    private void SetCulture(CultureInfo ci)
    {
      // set the current thread culture, which is used for date formatting
      Thread.CurrentThread.CurrentCulture = ci;
      labelDate.Text = 123456789.ToString("C");      

      // set the current thread UI culture and retrieve resource based on that
      Thread.CurrentThread.CurrentUICulture = ci;

      // in order to retrieve appropriate resource, we need to provide
      // fully qualified path to the logo satellite
      String AssemblyPath = Application.StartupPath + "\\logo.dll";
      Assembly a = Assembly.LoadFrom(AssemblyPath);
      ResourceManager rm = new ResourceManager("logo", a);
      imageBox.Image = (System.Drawing.Image)rm.GetObject("logo");

      // finally update culture information on the form
      labelCulture.Text = ci.DisplayName;
    }
  }
}
