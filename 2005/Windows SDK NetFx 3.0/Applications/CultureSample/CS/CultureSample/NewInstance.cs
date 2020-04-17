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
using System.Data;

using System.Globalization;
namespace Microsoft.Samples.Globalization.Culture
{
	/// <summary>
	/// Summary description for form.
	/// </summary>
	public class NewInstance : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label labelHeading;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.ComboBox comboBoxLocale;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelLocale;
		private System.Windows.Forms.Button buttonNext;

		//private CultureInfoHelper to be passed on to the child form
		private CultureInfoHelper helper;

		public NewInstance(CultureInfoHelper thisHelper)
		{
			InitializeComponent();
			helper = thisHelper;
			comboBoxLocale.Items.AddRange(helper.GetCultures(
				CultureTypes.InstalledWin32Cultures));
			comboBoxLocale.SelectedIndex = 0;
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void buttonNext_Click_1(object sender, System.EventArgs e)
		{
			if (textBoxName.Text.Length == 0)
				return;
			if (textBoxName.Text.Contains(Constants.Space))
			{
				MessageBox.Show(Constants.ErrorInvalidName);
				textBoxName.Clear();
				return;
			}
			//Using the helper register the new instance
			helper.NewCultureInstance((string)comboBoxLocale.SelectedItem, textBoxName.Text);
			this.Close();
		}
		
		#region Windows designer code
		private void InitializeComponent()
		{
			this.labelHeading = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelName = new System.Windows.Forms.Label();
			this.comboBoxLocale = new System.Windows.Forms.ComboBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelLocale = new System.Windows.Forms.Label();
			this.buttonNext = new System.Windows.Forms.Button();
			this.SuspendLayout();
// 
// labelHeading
// 
			this.labelHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHeading.Location = new System.Drawing.Point(84, 34);
			this.labelHeading.Name = "labelHeading";
			this.labelHeading.Size = new System.Drawing.Size(142, 23);
			this.labelHeading.TabIndex = 22;
			this.labelHeading.Text = "Create a new instance";
// 
// buttonCancel
// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(151, 210);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 29;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
// 
// labelName
// 
			this.labelName.Location = new System.Drawing.Point(36, 140);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(63, 23);
			this.labelName.TabIndex = 23;
			this.labelName.Text = "Name:";
// 
// comboBoxLocale
// 
			this.comboBoxLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLocale.Location = new System.Drawing.Point(115, 104);
			this.comboBoxLocale.Name = "comboBoxLocale";
			this.comboBoxLocale.Size = new System.Drawing.Size(142, 21);
			this.comboBoxLocale.TabIndex = 26;
// 
// textBoxName
// 
			this.textBoxName.Location = new System.Drawing.Point(115, 140);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(142, 20);
			this.textBoxName.TabIndex = 27;
// 
// labelLocale
// 
			this.labelLocale.Location = new System.Drawing.Point(36, 104);
			this.labelLocale.Name = "labelLocale";
			this.labelLocale.Size = new System.Drawing.Size(57, 23);
			this.labelLocale.TabIndex = 24;
			this.labelLocale.Text = "Locale:";
// 
// buttonNext
// 
			this.buttonNext.Location = new System.Drawing.Point(52, 210);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.TabIndex = 28;
			this.buttonNext.Text = "OK";
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click_1);
// 
// NewInstance
// 
			this.AcceptButton = this.buttonNext;
			this.AutoSize = true;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.comboBoxLocale);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelLocale);
			this.Controls.Add(this.labelHeading);
			this.Controls.Add(this.buttonCancel);
			this.Name = "NewInstance";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.Text = "New Instance";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


	}
}
