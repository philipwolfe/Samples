//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET SDK Code Samples.
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
using System.Globalization;

namespace Microsoft.Samples.Globalization.Culture
{
	/// <summary>
	/// Form for Mixing cultures.
	/// </summary>
	public class MixCultures : System.Windows.Forms.Form
	{
		#region Windows Form Designer declarations
		private System.Windows.Forms.Label labelHeading;
		private System.Windows.Forms.Label labelLocale1;
		private System.Windows.Forms.ComboBox comboBoxLocale1;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Label labelLocale2;
		private System.Windows.Forms.ComboBox comboBoxLocale2;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelHyphen;
		private System.Windows.Forms.TextBox textBoxRegion;
		private System.Windows.Forms.TextBox textBoxLang;
		private System.Windows.Forms.Button buttonClose;
		#endregion

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		//private CultureInfoHelper to be passed on to the child form
		private CultureInfoHelper helper;
		
		public MixCultures(CultureInfoHelper thisHelper)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			helper = thisHelper;
			object[] arrayItems = helper.GetCultures(CultureTypes.InstalledWin32Cultures);
			comboBoxLocale1.Items.AddRange(arrayItems);
			comboBoxLocale2.Items.AddRange(arrayItems);

			Reset();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
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
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelLocale1 = new System.Windows.Forms.Label();
			this.comboBoxLocale1 = new System.Windows.Forms.ComboBox();
			this.buttonNext = new System.Windows.Forms.Button();
			this.labelHeading = new System.Windows.Forms.Label();
			this.labelLocale2 = new System.Windows.Forms.Label();
			this.comboBoxLocale2 = new System.Windows.Forms.ComboBox();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxRegion = new System.Windows.Forms.TextBox();
			this.textBoxLang = new System.Windows.Forms.TextBox();
			this.labelHyphen = new System.Windows.Forms.Label();
			this.SuspendLayout();
// 
// buttonClose
// 
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.Location = new System.Drawing.Point(151, 213);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.TabIndex = 24;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
// 
// labelLocale1
// 
			this.labelLocale1.Location = new System.Drawing.Point(36, 83);
			this.labelLocale1.Name = "labelLocale1";
			this.labelLocale1.Size = new System.Drawing.Size(57, 23);
			this.labelLocale1.TabIndex = 17;
			this.labelLocale1.Text = "Locale 1:";
// 
// comboBoxLocale1
// 
			this.comboBoxLocale1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLocale1.Location = new System.Drawing.Point(115, 83);
			this.comboBoxLocale1.Name = "comboBoxLocale1";
			this.comboBoxLocale1.Size = new System.Drawing.Size(142, 21);
			this.comboBoxLocale1.TabIndex = 19;
// 
// buttonNext
// 
			this.buttonNext.Location = new System.Drawing.Point(65, 213);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.TabIndex = 23;
			this.buttonNext.Text = "Next >>";
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
// 
// labelHeading
// 
			this.labelHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHeading.Location = new System.Drawing.Point(99, 37);
			this.labelHeading.Name = "labelHeading";
			this.labelHeading.Size = new System.Drawing.Size(94, 23);
			this.labelHeading.TabIndex = 22;
			this.labelHeading.Text = "Mix two cultures";
// 
// labelLocale2
// 
			this.labelLocale2.Location = new System.Drawing.Point(36, 125);
			this.labelLocale2.Name = "labelLocale2";
			this.labelLocale2.Size = new System.Drawing.Size(57, 23);
			this.labelLocale2.TabIndex = 23;
			this.labelLocale2.Text = "Locale 2:";
// 
// comboBoxLocale2
// 
			this.comboBoxLocale2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLocale2.Location = new System.Drawing.Point(115, 125);
			this.comboBoxLocale2.Name = "comboBoxLocale2";
			this.comboBoxLocale2.Size = new System.Drawing.Size(142, 21);
			this.comboBoxLocale2.TabIndex = 20;
// 
// labelName
// 
			this.labelName.Location = new System.Drawing.Point(36, 172);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(69, 23);
			this.labelName.TabIndex = 25;
			this.labelName.Text = "Name";
// 
// textBoxRegion
// 
			this.textBoxRegion.Location = new System.Drawing.Point(173, 175);
			this.textBoxRegion.Name = "textBoxRegion";
			this.textBoxRegion.Size = new System.Drawing.Size(37, 20);
			this.textBoxRegion.TabIndex = 22;
// 
// textBoxLang
// 
			this.textBoxLang.Location = new System.Drawing.Point(115, 175);
			this.textBoxLang.Name = "textBoxLang";
			this.textBoxLang.Size = new System.Drawing.Size(35, 20);
			this.textBoxLang.TabIndex = 21;
// 
// labelHyphen
// 
			this.labelHyphen.Location = new System.Drawing.Point(159, 175);
			this.labelHyphen.Name = "labelHyphen";
			this.labelHyphen.Size = new System.Drawing.Size(39, 23);
			this.labelHyphen.TabIndex = 28;
			this.labelHyphen.Text = "-";
// 
// MixCultures
// 
			this.AcceptButton = this.buttonNext;
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(292, 272);
			this.Controls.Add(this.textBoxRegion);
			this.Controls.Add(this.textBoxLang);
			this.Controls.Add(this.labelHyphen);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.comboBoxLocale2);
			this.Controls.Add(this.labelLocale2);
			this.Controls.Add(this.labelHeading);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.comboBoxLocale1);
			this.Controls.Add(this.labelLocale1);
			this.Name = "MixCultures";
			this.Text = "Mix Cultures";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Reset()
		{
			comboBoxLocale2.SelectedIndex = 0;
			comboBoxLocale1.SelectedIndex = 0;
			textBoxLang.Clear();
			textBoxRegion.Clear();
		}

		private void buttonNext_Click(object sender, System.EventArgs e)
		{
			if (textBoxLang.Text.Length == 0 || textBoxRegion.Text.Length == 0)
			{
				Reset();
				return;
			}
			if (textBoxLang.Text.Contains(Constants.Space) || 
					textBoxRegion.Text.Contains(Constants.Space))
			{
				MessageBox.Show(Constants.ErrorInvalidName);
				Reset();
				return;
			}
			string locale1 = (string)comboBoxLocale1.SelectedItem;
			string locale2 = (string)comboBoxLocale2.SelectedItem;
		
			// Initialise the CultureOptions on the new cultures selected and show
			// the form
			CultureOptions options = new CultureOptions(helper, textBoxLang.Text, 
				textBoxRegion.Text);
			options.SetFields(locale1, locale2);
			options.Show();
			this.Close();
		}
	}
}
