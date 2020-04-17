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

namespace Microsoft.Samples.Globalization.Culture
{
	/// <summary>
	/// Form for creating new culture.
	/// </summary>
	public class NewCulture : System.Windows.Forms.Form
	{
		#region Windows Form Designer declarations
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelHeading;
		private System.Windows.Forms.TextBox textBoxRegion;
		private System.Windows.Forms.TextBox textBoxLang;
		private System.Windows.Forms.Label labelHyphen;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Button buttonNext;
		#endregion

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		//private CultureInfoHelper to be passed on to the child form
		private CultureInfoHelper helper;

		public NewCulture(CultureInfoHelper thisHelper)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			helper = thisHelper;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelHeading = new System.Windows.Forms.Label();
			this.textBoxRegion = new System.Windows.Forms.TextBox();
			this.textBoxLang = new System.Windows.Forms.TextBox();
			this.labelHyphen = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.buttonNext = new System.Windows.Forms.Button();
			this.SuspendLayout();
// 
// buttonCancel
// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(160, 213);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 34;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
// 
// labelHeading
// 
			this.labelHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHeading.Location = new System.Drawing.Point(83, 38);
			this.labelHeading.Name = "labelHeading";
			this.labelHeading.Size = new System.Drawing.Size(119, 23);
			this.labelHeading.TabIndex = 15;
			this.labelHeading.Text = "Create a new culture";
// 
// textBoxRegion
// 
			this.textBoxRegion.Location = new System.Drawing.Point(165, 114);
			this.textBoxRegion.Name = "textBoxRegion";
			this.textBoxRegion.Size = new System.Drawing.Size(37, 20);
			this.textBoxRegion.TabIndex = 32;
// 
// textBoxLang
// 
			this.textBoxLang.Location = new System.Drawing.Point(112, 114);
			this.textBoxLang.Name = "textBoxLang";
			this.textBoxLang.Size = new System.Drawing.Size(35, 20);
			this.textBoxLang.TabIndex = 31;
// 
// labelHyphen
// 
			this.labelHyphen.Location = new System.Drawing.Point(152, 114);
			this.labelHyphen.Name = "labelHyphen";
			this.labelHyphen.Size = new System.Drawing.Size(39, 23);
			this.labelHyphen.TabIndex = 32;
			this.labelHyphen.Text = "-";
// 
// labelName
// 
			this.labelName.Location = new System.Drawing.Point(64, 117);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(69, 23);
			this.labelName.TabIndex = 29;
			this.labelName.Text = "Name:";
// 
// buttonNext
// 
			this.buttonNext.Location = new System.Drawing.Point(56, 213);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.TabIndex = 33;
			this.buttonNext.Text = "Next >>";
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
// 
// NewCulture
// 
			this.AcceptButton = this.buttonNext;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(290, 270);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.textBoxRegion);
			this.Controls.Add(this.textBoxLang);
			this.Controls.Add(this.labelHyphen);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelHeading);
			this.Controls.Add(this.buttonCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewCulture";
			this.Text = "New Culture";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void buttonNext_Click(object sender, System.EventArgs e)
		{
			if (textBoxRegion.Text.Length == 0 || textBoxLang.Text.Length == 0)
				return;
			if (textBoxRegion.Text.Contains(Constants.Space) || 
					textBoxLang.Text.Contains(Constants.Space))
			{
				MessageBox.Show(Constants.ErrorInvalidName);
				Reset();
				return;
			}
			
			// Initialise the CultureOptions on the new cultures selected and show
			// the form
			CultureOptions options = new CultureOptions(helper, textBoxLang.Text, 
				textBoxRegion.Text);
			options.SetFields();
			options.Show();
			this.Close();
		}

		private void Reset()
		{
			textBoxLang.Clear();
			textBoxRegion.Clear();
		}
	}
}
