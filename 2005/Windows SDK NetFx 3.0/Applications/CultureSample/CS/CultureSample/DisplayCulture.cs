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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Globalization;


namespace Microsoft.Samples.Globalization.Culture
{
	/// <summary>
	/// Form to display a culture
	/// </summary>
	public class DisplayCulture : System.Windows.Forms.UserControl
	{
		#region Windows Form Designer declarations
		private System.Windows.Forms.GroupBox groupBoxRegion;
		private System.Windows.Forms.TextBox textBoxLanguage;
		private System.Windows.Forms.TextBox textBoxCountryRegion;
		private System.Windows.Forms.Label labelCountryRegion;
		private System.Windows.Forms.Label labelLanguage;
		private System.Windows.Forms.GroupBox groupBoxSample;
		private System.Windows.Forms.TextBox textBoxPositiveCurrency;
		private System.Windows.Forms.TextBox textBoxNegativeCurrency;
		private System.Windows.Forms.Label labelNegativeCurrency;
		private System.Windows.Forms.Label labelPositiveCurrency;
		private System.Windows.Forms.TextBox textBoxPositiveNumber;
		private System.Windows.Forms.TextBox textBoxNegativeNumber;
		private System.Windows.Forms.Label labelNegativeNumber;
		private System.Windows.Forms.Label labelPositiveNumber;
		private System.Windows.Forms.GroupBox groupBoxDateTime;
		private System.Windows.Forms.TextBox textBoxTime;
		private System.Windows.Forms.TextBox textBoxLongDate;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Label labelLongDate;
		private System.Windows.Forms.TextBox textBoxShortDate;
		private System.Windows.Forms.Label labelShortDate;
		private System.Windows.Forms.ComboBox comboBoxLocale;
		private System.Windows.Forms.Label labelLocale;
		#endregion

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public DisplayCulture()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBoxRegion = new System.Windows.Forms.GroupBox();
			this.textBoxLanguage = new System.Windows.Forms.TextBox();
			this.textBoxCountryRegion = new System.Windows.Forms.TextBox();
			this.labelCountryRegion = new System.Windows.Forms.Label();
			this.labelLanguage = new System.Windows.Forms.Label();
			this.labelLocale = new System.Windows.Forms.Label();
			this.comboBoxLocale = new System.Windows.Forms.ComboBox();
			this.groupBoxSample = new System.Windows.Forms.GroupBox();
			this.textBoxPositiveCurrency = new System.Windows.Forms.TextBox();
			this.textBoxNegativeCurrency = new System.Windows.Forms.TextBox();
			this.labelNegativeCurrency = new System.Windows.Forms.Label();
			this.labelPositiveCurrency = new System.Windows.Forms.Label();
			this.textBoxPositiveNumber = new System.Windows.Forms.TextBox();
			this.textBoxNegativeNumber = new System.Windows.Forms.TextBox();
			this.labelNegativeNumber = new System.Windows.Forms.Label();
			this.labelPositiveNumber = new System.Windows.Forms.Label();
			this.groupBoxDateTime = new System.Windows.Forms.GroupBox();
			this.textBoxTime = new System.Windows.Forms.TextBox();
			this.textBoxLongDate = new System.Windows.Forms.TextBox();
			this.labelTime = new System.Windows.Forms.Label();
			this.labelLongDate = new System.Windows.Forms.Label();
			this.textBoxShortDate = new System.Windows.Forms.TextBox();
			this.labelShortDate = new System.Windows.Forms.Label();
			this.groupBoxRegion.SuspendLayout();
			this.groupBoxSample.SuspendLayout();
			this.groupBoxDateTime.SuspendLayout();
			this.SuspendLayout();
// 
// groupBoxRegion
// 
			this.groupBoxRegion.Controls.Add(this.textBoxLanguage);
			this.groupBoxRegion.Controls.Add(this.textBoxCountryRegion);
			this.groupBoxRegion.Controls.Add(this.labelCountryRegion);
			this.groupBoxRegion.Controls.Add(this.labelLanguage);
			this.groupBoxRegion.Location = new System.Drawing.Point(4, 45);
			this.groupBoxRegion.Name = "groupBoxRegion";
			this.groupBoxRegion.Size = new System.Drawing.Size(358, 69);
			this.groupBoxRegion.TabIndex = 9;
			this.groupBoxRegion.TabStop = false;
			this.groupBoxRegion.Text = "Region";
// 
// textBoxLanguage
// 
			this.textBoxLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBoxLanguage.Location = new System.Drawing.Point(181, 14);
			this.textBoxLanguage.Name = "textBoxLanguage";
			this.textBoxLanguage.ReadOnly = true;
			this.textBoxLanguage.Size = new System.Drawing.Size(159, 20);
			this.textBoxLanguage.TabIndex = 3;
// 
// textBoxCountryRegion
// 
			this.textBoxCountryRegion.Location = new System.Drawing.Point(181, 39);
			this.textBoxCountryRegion.Name = "textBoxCountryRegion";
			this.textBoxCountryRegion.ReadOnly = true;
			this.textBoxCountryRegion.Size = new System.Drawing.Size(159, 20);
			this.textBoxCountryRegion.TabIndex = 4;
// 
// labelCountryRegion
// 
			this.labelCountryRegion.Location = new System.Drawing.Point(49, 39);
			this.labelCountryRegion.Name = "labelCountryRegion";
			this.labelCountryRegion.Size = new System.Drawing.Size(119, 23);
			this.labelCountryRegion.TabIndex = 1;
			this.labelCountryRegion.Text = "Country/Region code";
// 
// labelLanguage
// 
			this.labelLanguage.Location = new System.Drawing.Point(49, 14);
			this.labelLanguage.Name = "labelLanguage";
			this.labelLanguage.Size = new System.Drawing.Size(160, 23);
			this.labelLanguage.TabIndex = 0;
			this.labelLanguage.Text = "Name:";
// 
// labelLocale
// 
			this.labelLocale.Location = new System.Drawing.Point(6, 13);
			this.labelLocale.Name = "labelLocale";
			this.labelLocale.Size = new System.Drawing.Size(57, 23);
			this.labelLocale.TabIndex = 13;
			this.labelLocale.Text = "Locale:";
// 
// comboBoxLocale
// 
			this.comboBoxLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLocale.Location = new System.Drawing.Point(70, 13);
			this.comboBoxLocale.Name = "comboBoxLocale";
			this.comboBoxLocale.Size = new System.Drawing.Size(292, 21);
			this.comboBoxLocale.TabIndex = 1;
			this.comboBoxLocale.SelectedIndexChanged += new System.EventHandler(this.comboBoxLocale_SelectedIndexChanged);
// 
// groupBoxSample
// 
			this.groupBoxSample.Controls.Add(this.textBoxPositiveCurrency);
			this.groupBoxSample.Controls.Add(this.textBoxNegativeCurrency);
			this.groupBoxSample.Controls.Add(this.labelNegativeCurrency);
			this.groupBoxSample.Controls.Add(this.labelPositiveCurrency);
			this.groupBoxSample.Controls.Add(this.textBoxPositiveNumber);
			this.groupBoxSample.Controls.Add(this.textBoxNegativeNumber);
			this.groupBoxSample.Controls.Add(this.labelNegativeNumber);
			this.groupBoxSample.Controls.Add(this.labelPositiveNumber);
			this.groupBoxSample.Location = new System.Drawing.Point(4, 118);
			this.groupBoxSample.Name = "groupBoxSample";
			this.groupBoxSample.Size = new System.Drawing.Size(358, 126);
			this.groupBoxSample.TabIndex = 8;
			this.groupBoxSample.TabStop = false;
			this.groupBoxSample.Text = "Number and Currency";
// 
// textBoxPositiveCurrency
// 
			this.textBoxPositiveCurrency.Location = new System.Drawing.Point(182, 67);
			this.textBoxPositiveCurrency.Name = "textBoxPositiveCurrency";
			this.textBoxPositiveCurrency.ReadOnly = true;
			this.textBoxPositiveCurrency.Size = new System.Drawing.Size(158, 20);
			this.textBoxPositiveCurrency.TabIndex = 7;
// 
// textBoxNegativeCurrency
// 
			this.textBoxNegativeCurrency.Location = new System.Drawing.Point(182, 96);
			this.textBoxNegativeCurrency.Name = "textBoxNegativeCurrency";
			this.textBoxNegativeCurrency.ReadOnly = true;
			this.textBoxNegativeCurrency.Size = new System.Drawing.Size(158, 20);
			this.textBoxNegativeCurrency.TabIndex = 8;
// 
// labelNegativeCurrency
// 
			this.labelNegativeCurrency.Location = new System.Drawing.Point(48, 92);
			this.labelNegativeCurrency.Name = "labelNegativeCurrency";
			this.labelNegativeCurrency.TabIndex = 5;
			this.labelNegativeCurrency.Text = "Negative currency:";
// 
// labelPositiveCurrency
// 
			this.labelPositiveCurrency.Location = new System.Drawing.Point(48, 67);
			this.labelPositiveCurrency.Name = "labelPositiveCurrency";
			this.labelPositiveCurrency.TabIndex = 4;
			this.labelPositiveCurrency.Text = "Positive currency:";
// 
// textBoxPositiveNumber
// 
			this.textBoxPositiveNumber.Location = new System.Drawing.Point(182, 11);
			this.textBoxPositiveNumber.Name = "textBoxPositiveNumber";
			this.textBoxPositiveNumber.ReadOnly = true;
			this.textBoxPositiveNumber.Size = new System.Drawing.Size(158, 20);
			this.textBoxPositiveNumber.TabIndex = 5;
// 
// textBoxNegativeNumber
// 
			this.textBoxNegativeNumber.Location = new System.Drawing.Point(182, 37);
			this.textBoxNegativeNumber.Name = "textBoxNegativeNumber";
			this.textBoxNegativeNumber.ReadOnly = true;
			this.textBoxNegativeNumber.Size = new System.Drawing.Size(158, 20);
			this.textBoxNegativeNumber.TabIndex = 6;
// 
// labelNegativeNumber
// 
			this.labelNegativeNumber.Location = new System.Drawing.Point(48, 42);
			this.labelNegativeNumber.Name = "labelNegativeNumber";
			this.labelNegativeNumber.TabIndex = 1;
			this.labelNegativeNumber.Text = "Negative number:";
// 
// labelPositiveNumber
// 
			this.labelPositiveNumber.Location = new System.Drawing.Point(48, 17);
			this.labelPositiveNumber.Name = "labelPositiveNumber";
			this.labelPositiveNumber.TabIndex = 0;
			this.labelPositiveNumber.Text = "Positive number:";
// 
// groupBoxDateTime
// 
			this.groupBoxDateTime.Controls.Add(this.textBoxTime);
			this.groupBoxDateTime.Controls.Add(this.textBoxLongDate);
			this.groupBoxDateTime.Controls.Add(this.labelTime);
			this.groupBoxDateTime.Controls.Add(this.labelLongDate);
			this.groupBoxDateTime.Controls.Add(this.textBoxShortDate);
			this.groupBoxDateTime.Controls.Add(this.labelShortDate);
			this.groupBoxDateTime.Location = new System.Drawing.Point(4, 249);
			this.groupBoxDateTime.Name = "groupBoxDateTime";
			this.groupBoxDateTime.Size = new System.Drawing.Size(358, 113);
			this.groupBoxDateTime.TabIndex = 7;
			this.groupBoxDateTime.TabStop = false;
			this.groupBoxDateTime.Text = "Date and Time";
// 
// textBoxTime
// 
			this.textBoxTime.Location = new System.Drawing.Point(184, 75);
			this.textBoxTime.Name = "textBoxTime";
			this.textBoxTime.ReadOnly = true;
			this.textBoxTime.Size = new System.Drawing.Size(156, 20);
			this.textBoxTime.TabIndex = 15;
// 
// textBoxLongDate
// 
			this.textBoxLongDate.Location = new System.Drawing.Point(184, 45);
			this.textBoxLongDate.Name = "textBoxLongDate";
			this.textBoxLongDate.ReadOnly = true;
			this.textBoxLongDate.Size = new System.Drawing.Size(156, 20);
			this.textBoxLongDate.TabIndex = 10;
// 
// labelTime
// 
			this.labelTime.Location = new System.Drawing.Point(44, 72);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(80, 23);
			this.labelTime.TabIndex = 13;
			this.labelTime.Text = "Time:";
// 
// labelLongDate
// 
			this.labelLongDate.Location = new System.Drawing.Point(44, 46);
			this.labelLongDate.Name = "labelLongDate";
			this.labelLongDate.Size = new System.Drawing.Size(80, 23);
			this.labelLongDate.TabIndex = 12;
			this.labelLongDate.Text = "Long date:";
// 
// textBoxShortDate
// 
			this.textBoxShortDate.Location = new System.Drawing.Point(184, 17);
			this.textBoxShortDate.Name = "textBoxShortDate";
			this.textBoxShortDate.ReadOnly = true;
			this.textBoxShortDate.Size = new System.Drawing.Size(156, 20);
			this.textBoxShortDate.TabIndex = 9;
// 
// labelShortDate
// 
			this.labelShortDate.Location = new System.Drawing.Point(44, 19);
			this.labelShortDate.Name = "labelShortDate";
			this.labelShortDate.TabIndex = 0;
			this.labelShortDate.Text = "Short date :";
// 
// DisplayCulture
// 
			this.Controls.Add(this.groupBoxRegion);
			this.Controls.Add(this.groupBoxSample);
			this.Controls.Add(this.groupBoxDateTime);
			this.Controls.Add(this.comboBoxLocale);
			this.Controls.Add(this.labelLocale);
			this.Name = "DisplayCulture";
			this.Size = new System.Drawing.Size(369, 374);
			this.groupBoxRegion.ResumeLayout(false);
			this.groupBoxRegion.PerformLayout();
			this.groupBoxSample.ResumeLayout(false);
			this.groupBoxSample.PerformLayout();
			this.groupBoxDateTime.ResumeLayout(false);
			this.groupBoxDateTime.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		/**
		 * Method to display formats of a culture
		 */
		public void Print(CultureInfo ci)
		{
			textBoxLanguage.Text = ci.Name;
			textBoxCountryRegion.Text = ci.EnglishName;

			Int64 posInt = Constants.LongNumber;
			textBoxPositiveNumber.Text = posInt.ToString(Constants.NumberFormat, 
						ci.NumberFormat);
			textBoxPositiveCurrency.Text = posInt.ToString(Constants.CurrencyFormat, 
						ci.NumberFormat);
			posInt = -posInt;
			textBoxNegativeNumber.Text = posInt.ToString(Constants.NumberFormat, 
						ci.NumberFormat);
			textBoxNegativeCurrency.Text = posInt.ToString(Constants.CurrencyFormat, 
						ci.NumberFormat);

			DateTime dt = DateTime.Now;
			textBoxShortDate.Text = dt.ToString(Constants.ShortDateFormat, 
						ci.DateTimeFormat);
			textBoxLongDate.Text = dt.ToString(Constants.LongDateFormat, 
						ci.DateTimeFormat); 
			textBoxTime.Text = dt.ToString(Constants.TimeFormat, ci.DateTimeFormat);
		}

		/**
		 * Method to populate the list initially
		 */
		public void LoadComboBox(object[] values)
		{
			comboBoxLocale.Items.AddRange(values);
		}
		
		private void comboBoxLocale_SelectedIndexChanged(object sender, 
					System.EventArgs e)
		{
			//Override the default values
			CultureInfo ci = new CultureInfo((string)comboBoxLocale.SelectedItem, true);

			//Neutral cultures cannot be parsed
			if (ci.IsNeutralCulture)
			{
				MessageBox.Show(Constants.ErrorNeutralCulture);
                ClearForm();
				return;
			}

			Print(ci);
		}

        private void ClearForm()
        {
            textBoxCountryRegion.Text = "";
            textBoxLanguage.Text = "";
            textBoxPositiveNumber.Text = "";
            textBoxPositiveCurrency.Text = "";
            textBoxNegativeNumber.Text = "";
            textBoxNegativeCurrency.Text = "";

            textBoxShortDate.Text = "";
            textBoxLongDate.Text = "";
            textBoxTime.Text = "";

        }

		/**
		 * Method to add a new Item to the list once a new culture is created
		 */
		public void AddSelectItem(string itemName)
		{
			//Insert the new item ont he top of the list and select it
			comboBoxLocale.Items.Insert(0, itemName);
			comboBoxLocale.SelectedIndex = 0;
		}
	}
}
