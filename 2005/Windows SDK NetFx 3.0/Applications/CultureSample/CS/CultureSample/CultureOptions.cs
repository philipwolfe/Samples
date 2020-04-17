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
	/// Form to dispaly the properties of a culture for editing 
	/// </summary>
	public class CultureOptions : System.Windows.Forms.Form
	{
		#region Windows Form Designer declarations
		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageTime;
		private System.Windows.Forms.TabPage tabPageDate;
		private System.Windows.Forms.GroupBox groupBoxSample;
		private System.Windows.Forms.Label labelPositive;
		private System.Windows.Forms.TextBox textBoxPositive;
		private System.Windows.Forms.Label labelNegative;
		private System.Windows.Forms.TextBox textBoxNegative;
		private System.Windows.Forms.Label labelSymbol;
		private System.Windows.Forms.Label labelDigits;
		private System.Windows.Forms.Label labelGrouping;
		private System.Windows.Forms.Label labelNegativeSign;
		private System.Windows.Forms.Label labelNegativeNumber;
		private System.Windows.Forms.Label labelSeparator;
		private System.Windows.Forms.ComboBox comboBoxSymbol;
		private System.Windows.Forms.ComboBox comboBoxGrouping;
		private System.Windows.Forms.ComboBox comboBoxNegativeSign;
		private System.Windows.Forms.ComboBox comboBoxNegativeNumber;
		private System.Windows.Forms.ComboBox comboBoxDigits;
		private System.Windows.Forms.ComboBox comboBoxSeparator;
		private System.Windows.Forms.TextBox textBoxNegativeCurrency;
		private System.Windows.Forms.GroupBox groupBoxCurrencySample;
		private System.Windows.Forms.TextBox textBoxPositiveCurrency;
		private System.Windows.Forms.Label labelNegativeCurrency;
		private System.Windows.Forms.Label labelPositiveCurrency;
		private System.Windows.Forms.Label labelSymbolCurrency;
		private System.Windows.Forms.Label labelNegCurrency;
		private System.Windows.Forms.Label labelPosCurrency;
		private System.Windows.Forms.Label labelDecimal;
		private System.Windows.Forms.Label labelDecimalDigits;
		private System.Windows.Forms.Label labelGroupingCurrency;
		private System.Windows.Forms.ComboBox comboBoxDecimal;
		private System.Windows.Forms.ComboBox comboBoxGroupingCurrency;
		private System.Windows.Forms.ComboBox comboBoxNegative;
		private System.Windows.Forms.ComboBox comboBoxCurrencySymbol;
		private System.Windows.Forms.ComboBox comboBoxPositive;
		private System.Windows.Forms.ComboBox comboBoxDecimalDigits;
		private System.Windows.Forms.GroupBox groupBoxSampleTime;
		private System.Windows.Forms.Label labelSample;
		private System.Windows.Forms.ComboBox comboBoxAM;
		private System.Windows.Forms.ComboBox comboBoxPM;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelPM;
		private System.Windows.Forms.Label labelAM;
		private System.Windows.Forms.ComboBox comboBoxFormat;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelShortDate;
		private System.Windows.Forms.GroupBox groupBoxShortDate;
		private System.Windows.Forms.TextBox textBoxShortDate;
		private System.Windows.Forms.Label labelShortDateFormat;
		private System.Windows.Forms.ComboBox comboBoxShortDateFormat;
		private System.Windows.Forms.ComboBox comboBoxDateSeparator;
		private System.Windows.Forms.Label labelDateSeparator;
		private System.Windows.Forms.GroupBox groupBoxLongDate;
		private System.Windows.Forms.Label labelLongDate;
		private System.Windows.Forms.ComboBox comboBoxLongDateFormat;
		private System.Windows.Forms.Label labelLongDateFormat;
		private System.Windows.Forms.TextBox textBoxLongDate;
		private System.Windows.Forms.TextBox textBoxSample;
		private System.Windows.Forms.TabPage tabPageNumber;
		private System.Windows.Forms.TabPage tabPageCurrency;
		#endregion

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private CultureInfoHelper helper;

		//Locale names in case the form is used for mixing cultures
		//The names are null otherwise
		private string locale1, locale2;
		private string language, region;

		public CultureOptions(CultureInfoHelper thisHelper, string lang, string reg)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			helper = thisHelper;
			language = lang;
			region = reg;
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
this.tabControlMain = new System.Windows.Forms.TabControl();
this.tabPageNumber = new System.Windows.Forms.TabPage();
this.comboBoxSeparator = new System.Windows.Forms.ComboBox();
this.comboBoxNegativeNumber = new System.Windows.Forms.ComboBox();
this.comboBoxDigits = new System.Windows.Forms.ComboBox();
this.comboBoxNegativeSign = new System.Windows.Forms.ComboBox();
this.comboBoxGrouping = new System.Windows.Forms.ComboBox();
this.comboBoxSymbol = new System.Windows.Forms.ComboBox();
this.labelSeparator = new System.Windows.Forms.Label();
this.labelNegativeNumber = new System.Windows.Forms.Label();
this.labelNegativeSign = new System.Windows.Forms.Label();
this.labelGrouping = new System.Windows.Forms.Label();
this.labelDigits = new System.Windows.Forms.Label();
this.labelSymbol = new System.Windows.Forms.Label();
this.groupBoxSample = new System.Windows.Forms.GroupBox();
this.textBoxPositive = new System.Windows.Forms.TextBox();
this.textBoxNegative = new System.Windows.Forms.TextBox();
this.labelNegative = new System.Windows.Forms.Label();
this.labelPositive = new System.Windows.Forms.Label();
this.tabPageCurrency = new System.Windows.Forms.TabPage();
this.comboBoxGroupingCurrency = new System.Windows.Forms.ComboBox();
this.comboBoxDecimalDigits = new System.Windows.Forms.ComboBox();
this.comboBoxPositive = new System.Windows.Forms.ComboBox();
this.comboBoxDecimal = new System.Windows.Forms.ComboBox();
this.comboBoxNegative = new System.Windows.Forms.ComboBox();
this.comboBoxCurrencySymbol = new System.Windows.Forms.ComboBox();
this.labelGroupingCurrency = new System.Windows.Forms.Label();
this.labelDecimalDigits = new System.Windows.Forms.Label();
this.labelDecimal = new System.Windows.Forms.Label();
this.labelNegCurrency = new System.Windows.Forms.Label();
this.labelPosCurrency = new System.Windows.Forms.Label();
this.labelSymbolCurrency = new System.Windows.Forms.Label();
this.groupBoxCurrencySample = new System.Windows.Forms.GroupBox();
this.textBoxPositiveCurrency = new System.Windows.Forms.TextBox();
this.textBoxNegativeCurrency = new System.Windows.Forms.TextBox();
this.labelNegativeCurrency = new System.Windows.Forms.Label();
this.labelPositiveCurrency = new System.Windows.Forms.Label();
this.tabPageTime = new System.Windows.Forms.TabPage();
this.comboBoxAM = new System.Windows.Forms.ComboBox();
this.comboBoxPM = new System.Windows.Forms.ComboBox();
this.comboBoxFormat = new System.Windows.Forms.ComboBox();
this.labelPM = new System.Windows.Forms.Label();
this.labelAM = new System.Windows.Forms.Label();
this.label1 = new System.Windows.Forms.Label();
this.groupBoxSampleTime = new System.Windows.Forms.GroupBox();
this.textBoxSample = new System.Windows.Forms.TextBox();
this.labelSample = new System.Windows.Forms.Label();
this.tabPageDate = new System.Windows.Forms.TabPage();
this.groupBoxLongDate = new System.Windows.Forms.GroupBox();
this.comboBoxLongDateFormat = new System.Windows.Forms.ComboBox();
this.labelLongDateFormat = new System.Windows.Forms.Label();
this.textBoxLongDate = new System.Windows.Forms.TextBox();
this.labelLongDate = new System.Windows.Forms.Label();
this.groupBoxShortDate = new System.Windows.Forms.GroupBox();
this.comboBoxDateSeparator = new System.Windows.Forms.ComboBox();
this.comboBoxShortDateFormat = new System.Windows.Forms.ComboBox();
this.labelDateSeparator = new System.Windows.Forms.Label();
this.labelShortDateFormat = new System.Windows.Forms.Label();
this.textBoxShortDate = new System.Windows.Forms.TextBox();
this.labelShortDate = new System.Windows.Forms.Label();
this.buttonOk = new System.Windows.Forms.Button();
this.buttonCancel = new System.Windows.Forms.Button();
this.tabControlMain.SuspendLayout();
this.tabPageNumber.SuspendLayout();
this.groupBoxSample.SuspendLayout();
this.tabPageCurrency.SuspendLayout();
this.groupBoxCurrencySample.SuspendLayout();
this.tabPageTime.SuspendLayout();
this.groupBoxSampleTime.SuspendLayout();
this.tabPageDate.SuspendLayout();
this.groupBoxLongDate.SuspendLayout();
this.groupBoxShortDate.SuspendLayout();
this.SuspendLayout();
// 
// tabControlMain
// 
this.tabControlMain.Controls.Add(this.tabPageNumber);
this.tabControlMain.Controls.Add(this.tabPageCurrency);
this.tabControlMain.Controls.Add(this.tabPageTime);
this.tabControlMain.Controls.Add(this.tabPageDate);
this.tabControlMain.Location = new System.Drawing.Point(7, 14);
this.tabControlMain.Name = "tabControlMain";
this.tabControlMain.SelectedIndex = 0;
this.tabControlMain.Size = new System.Drawing.Size(402, 346);
this.tabControlMain.TabIndex = 0;
// 
// tabPageNumber
// 
this.tabPageNumber.BackColor = System.Drawing.SystemColors.Window;
this.tabPageNumber.Controls.Add(this.comboBoxSeparator);
this.tabPageNumber.Controls.Add(this.comboBoxNegativeNumber);
this.tabPageNumber.Controls.Add(this.comboBoxDigits);
this.tabPageNumber.Controls.Add(this.comboBoxNegativeSign);
this.tabPageNumber.Controls.Add(this.comboBoxGrouping);
this.tabPageNumber.Controls.Add(this.comboBoxSymbol);
this.tabPageNumber.Controls.Add(this.labelSeparator);
this.tabPageNumber.Controls.Add(this.labelNegativeNumber);
this.tabPageNumber.Controls.Add(this.labelNegativeSign);
this.tabPageNumber.Controls.Add(this.labelGrouping);
this.tabPageNumber.Controls.Add(this.labelDigits);
this.tabPageNumber.Controls.Add(this.labelSymbol);
this.tabPageNumber.Controls.Add(this.groupBoxSample);
this.tabPageNumber.Location = new System.Drawing.Point(4, 22);
this.tabPageNumber.Name = "tabPageNumber";
this.tabPageNumber.Size = new System.Drawing.Size(394, 320);
this.tabPageNumber.TabIndex = 0;
this.tabPageNumber.Text = "Number";
// 
// comboBoxSeparator
// 
this.comboBoxSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxSeparator.Location = new System.Drawing.Point(201, 248);
this.comboBoxSeparator.Name = "comboBoxSeparator";
this.comboBoxSeparator.Size = new System.Drawing.Size(144, 21);
this.comboBoxSeparator.TabIndex = 13;
// 
// comboBoxNegativeNumber
// 
this.comboBoxNegativeNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxNegativeNumber.Location = new System.Drawing.Point(201, 196);
this.comboBoxNegativeNumber.Name = "comboBoxNegativeNumber";
this.comboBoxNegativeNumber.Size = new System.Drawing.Size(144, 21);
this.comboBoxNegativeNumber.TabIndex = 12;
// 
// comboBoxDigits
// 
this.comboBoxDigits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxDigits.Location = new System.Drawing.Point(201, 118);
this.comboBoxDigits.Name = "comboBoxDigits";
this.comboBoxDigits.Size = new System.Drawing.Size(144, 21);
this.comboBoxDigits.TabIndex = 9;
// 
// comboBoxNegativeSign
// 
this.comboBoxNegativeSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxNegativeSign.Location = new System.Drawing.Point(201, 170);
this.comboBoxNegativeSign.Name = "comboBoxNegativeSign";
this.comboBoxNegativeSign.Size = new System.Drawing.Size(144, 21);
this.comboBoxNegativeSign.TabIndex = 11;
// 
// comboBoxGrouping
// 
this.comboBoxGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxGrouping.Location = new System.Drawing.Point(201, 144);
this.comboBoxGrouping.Name = "comboBoxGrouping";
this.comboBoxGrouping.Size = new System.Drawing.Size(144, 21);
this.comboBoxGrouping.TabIndex = 10;
// 
// comboBoxSymbol
// 
this.comboBoxSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxSymbol.Location = new System.Drawing.Point(201, 92);
this.comboBoxSymbol.Name = "comboBoxSymbol";
this.comboBoxSymbol.Size = new System.Drawing.Size(144, 21);
this.comboBoxSymbol.TabIndex = 8;
// 
// labelSeparator
// 
this.labelSeparator.Location = new System.Drawing.Point(36, 248);
this.labelSeparator.Name = "labelSeparator";
this.labelSeparator.Size = new System.Drawing.Size(136, 23);
this.labelSeparator.TabIndex = 7;
this.labelSeparator.Text = "List separator:";
// 
// labelNegativeNumber
// 
this.labelNegativeNumber.Location = new System.Drawing.Point(36, 196);
this.labelNegativeNumber.Name = "labelNegativeNumber";
this.labelNegativeNumber.Size = new System.Drawing.Size(136, 23);
this.labelNegativeNumber.TabIndex = 5;
this.labelNegativeNumber.Text = "Negative number format:";
// 
// labelNegativeSign
// 
this.labelNegativeSign.Location = new System.Drawing.Point(36, 170);
this.labelNegativeSign.Name = "labelNegativeSign";
this.labelNegativeSign.Size = new System.Drawing.Size(136, 23);
this.labelNegativeSign.TabIndex = 4;
this.labelNegativeSign.Text = "Negative sign symbol:";
// 
// labelGrouping
// 
this.labelGrouping.Location = new System.Drawing.Point(36, 144);
this.labelGrouping.Name = "labelGrouping";
this.labelGrouping.Size = new System.Drawing.Size(136, 23);
this.labelGrouping.TabIndex = 3;
this.labelGrouping.Text = "Digit grouping:";
// 
// labelDigits
// 
this.labelDigits.Location = new System.Drawing.Point(36, 118);
this.labelDigits.Name = "labelDigits";
this.labelDigits.Size = new System.Drawing.Size(136, 23);
this.labelDigits.TabIndex = 2;
this.labelDigits.Text = "No. of digits after decimal:";
// 
// labelSymbol
// 
this.labelSymbol.Location = new System.Drawing.Point(36, 92);
this.labelSymbol.Name = "labelSymbol";
this.labelSymbol.Size = new System.Drawing.Size(136, 23);
this.labelSymbol.TabIndex = 1;
this.labelSymbol.Text = "Decimal symbol:";
// 
// groupBoxSample
// 
this.groupBoxSample.Controls.Add(this.textBoxPositive);
this.groupBoxSample.Controls.Add(this.textBoxNegative);
this.groupBoxSample.Controls.Add(this.labelNegative);
this.groupBoxSample.Controls.Add(this.labelPositive);
this.groupBoxSample.Location = new System.Drawing.Point(11, 4);
this.groupBoxSample.Name = "groupBoxSample";
this.groupBoxSample.Size = new System.Drawing.Size(370, 71);
this.groupBoxSample.TabIndex = 0;
this.groupBoxSample.TabStop = false;
this.groupBoxSample.Text = "Sample";
// 
// textBoxPositive
// 
this.textBoxPositive.Location = new System.Drawing.Point(53, 28);
this.textBoxPositive.Name = "textBoxPositive";
this.textBoxPositive.ReadOnly = true;
this.textBoxPositive.Size = new System.Drawing.Size(123, 20);
this.textBoxPositive.TabIndex = 3;
// 
// textBoxNegative
// 
this.textBoxNegative.Location = new System.Drawing.Point(239, 28);
this.textBoxNegative.Name = "textBoxNegative";
this.textBoxNegative.ReadOnly = true;
this.textBoxNegative.Size = new System.Drawing.Size(123, 20);
this.textBoxNegative.TabIndex = 4;
// 
// labelNegative
// 
this.labelNegative.Location = new System.Drawing.Point(188, 28);
this.labelNegative.Name = "labelNegative";
this.labelNegative.TabIndex = 1;
this.labelNegative.Text = "Negative:";
// 
// labelPositive
// 
this.labelPositive.Location = new System.Drawing.Point(4, 28);
this.labelPositive.Name = "labelPositive";
this.labelPositive.TabIndex = 0;
this.labelPositive.Text = "Positive:";
// 
// tabPageCurrency
// 
this.tabPageCurrency.BackColor = System.Drawing.SystemColors.Window;
this.tabPageCurrency.Controls.Add(this.comboBoxGroupingCurrency);
this.tabPageCurrency.Controls.Add(this.comboBoxDecimalDigits);
this.tabPageCurrency.Controls.Add(this.comboBoxPositive);
this.tabPageCurrency.Controls.Add(this.comboBoxDecimal);
this.tabPageCurrency.Controls.Add(this.comboBoxNegative);
this.tabPageCurrency.Controls.Add(this.comboBoxCurrencySymbol);
this.tabPageCurrency.Controls.Add(this.labelGroupingCurrency);
this.tabPageCurrency.Controls.Add(this.labelDecimalDigits);
this.tabPageCurrency.Controls.Add(this.labelDecimal);
this.tabPageCurrency.Controls.Add(this.labelNegCurrency);
this.tabPageCurrency.Controls.Add(this.labelPosCurrency);
this.tabPageCurrency.Controls.Add(this.labelSymbolCurrency);
this.tabPageCurrency.Controls.Add(this.groupBoxCurrencySample);
this.tabPageCurrency.Location = new System.Drawing.Point(4, 22);
this.tabPageCurrency.Name = "tabPageCurrency";
this.tabPageCurrency.Size = new System.Drawing.Size(394, 320);
this.tabPageCurrency.TabIndex = 1;
this.tabPageCurrency.Text = "Currency";
// 
// comboBoxGroupingCurrency
// 
this.comboBoxGroupingCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxGroupingCurrency.Location = new System.Drawing.Point(201, 247);
this.comboBoxGroupingCurrency.Name = "comboBoxGroupingCurrency";
this.comboBoxGroupingCurrency.Size = new System.Drawing.Size(144, 21);
this.comboBoxGroupingCurrency.TabIndex = 28;
// 
// comboBoxDecimalDigits
// 
this.comboBoxDecimalDigits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxDecimalDigits.Location = new System.Drawing.Point(201, 206);
this.comboBoxDecimalDigits.Name = "comboBoxDecimalDigits";
this.comboBoxDecimalDigits.Size = new System.Drawing.Size(144, 21);
this.comboBoxDecimalDigits.TabIndex = 26;
// 
// comboBoxPositive
// 
this.comboBoxPositive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxPositive.Location = new System.Drawing.Point(201, 116);
this.comboBoxPositive.Name = "comboBoxPositive";
this.comboBoxPositive.Size = new System.Drawing.Size(144, 21);
this.comboBoxPositive.TabIndex = 23;
// 
// comboBoxDecimal
// 
this.comboBoxDecimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxDecimal.Location = new System.Drawing.Point(201, 180);
this.comboBoxDecimal.Name = "comboBoxDecimal";
this.comboBoxDecimal.Size = new System.Drawing.Size(144, 21);
this.comboBoxDecimal.TabIndex = 25;
// 
// comboBoxNegative
// 
this.comboBoxNegative.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxNegative.Location = new System.Drawing.Point(201, 142);
this.comboBoxNegative.Name = "comboBoxNegative";
this.comboBoxNegative.Size = new System.Drawing.Size(144, 21);
this.comboBoxNegative.TabIndex = 24;
// 
// comboBoxCurrencySymbol
// 
this.comboBoxCurrencySymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxCurrencySymbol.Location = new System.Drawing.Point(201, 90);
this.comboBoxCurrencySymbol.Name = "comboBoxCurrencySymbol";
this.comboBoxCurrencySymbol.Size = new System.Drawing.Size(144, 21);
this.comboBoxCurrencySymbol.TabIndex = 22;
// 
// labelGroupingCurrency
// 
this.labelGroupingCurrency.Location = new System.Drawing.Point(36, 247);
this.labelGroupingCurrency.Name = "labelGroupingCurrency";
this.labelGroupingCurrency.Size = new System.Drawing.Size(136, 23);
this.labelGroupingCurrency.TabIndex = 21;
this.labelGroupingCurrency.Text = "Digit grouping: ";
// 
// labelDecimalDigits
// 
this.labelDecimalDigits.Location = new System.Drawing.Point(36, 206);
this.labelDecimalDigits.Name = "labelDecimalDigits";
this.labelDecimalDigits.Size = new System.Drawing.Size(136, 23);
this.labelDecimalDigits.TabIndex = 19;
this.labelDecimalDigits.Text = "No. of digits after decimal:";
// 
// labelDecimal
// 
this.labelDecimal.Location = new System.Drawing.Point(36, 180);
this.labelDecimal.Name = "labelDecimal";
this.labelDecimal.Size = new System.Drawing.Size(136, 23);
this.labelDecimal.TabIndex = 18;
this.labelDecimal.Text = "Decimal symbol:";
// 
// labelNegCurrency
// 
this.labelNegCurrency.Location = new System.Drawing.Point(36, 142);
this.labelNegCurrency.Name = "labelNegCurrency";
this.labelNegCurrency.Size = new System.Drawing.Size(136, 23);
this.labelNegCurrency.TabIndex = 17;
this.labelNegCurrency.Text = "Negative currency:";
// 
// labelPosCurrency
// 
this.labelPosCurrency.Location = new System.Drawing.Point(36, 116);
this.labelPosCurrency.Name = "labelPosCurrency";
this.labelPosCurrency.Size = new System.Drawing.Size(136, 23);
this.labelPosCurrency.TabIndex = 16;
this.labelPosCurrency.Text = "Positive currency:";
// 
// labelSymbolCurrency
// 
this.labelSymbolCurrency.Location = new System.Drawing.Point(36, 90);
this.labelSymbolCurrency.Name = "labelSymbolCurrency";
this.labelSymbolCurrency.Size = new System.Drawing.Size(136, 23);
this.labelSymbolCurrency.TabIndex = 15;
this.labelSymbolCurrency.Text = "Currency symbol:";
// 
// groupBoxCurrencySample
// 
this.groupBoxCurrencySample.Controls.Add(this.textBoxPositiveCurrency);
this.groupBoxCurrencySample.Controls.Add(this.textBoxNegativeCurrency);
this.groupBoxCurrencySample.Controls.Add(this.labelNegativeCurrency);
this.groupBoxCurrencySample.Controls.Add(this.labelPositiveCurrency);
this.groupBoxCurrencySample.Location = new System.Drawing.Point(11, 4);
this.groupBoxCurrencySample.Name = "groupBoxCurrencySample";
this.groupBoxCurrencySample.Size = new System.Drawing.Size(370, 71);
this.groupBoxCurrencySample.TabIndex = 1;
this.groupBoxCurrencySample.TabStop = false;
this.groupBoxCurrencySample.Text = "Sample";
// 
// textBoxPositiveCurrency
// 
this.textBoxPositiveCurrency.Location = new System.Drawing.Point(53, 28);
this.textBoxPositiveCurrency.Name = "textBoxPositiveCurrency";
this.textBoxPositiveCurrency.ReadOnly = true;
this.textBoxPositiveCurrency.Size = new System.Drawing.Size(123, 20);
this.textBoxPositiveCurrency.TabIndex = 3;
// 
// textBoxNegativeCurrency
// 
this.textBoxNegativeCurrency.Location = new System.Drawing.Point(239, 28);
this.textBoxNegativeCurrency.Name = "textBoxNegativeCurrency";
this.textBoxNegativeCurrency.ReadOnly = true;
this.textBoxNegativeCurrency.Size = new System.Drawing.Size(123, 20);
this.textBoxNegativeCurrency.TabIndex = 4;
// 
// labelNegativeCurrency
// 
this.labelNegativeCurrency.Location = new System.Drawing.Point(188, 28);
this.labelNegativeCurrency.Name = "labelNegativeCurrency";
this.labelNegativeCurrency.TabIndex = 1;
this.labelNegativeCurrency.Text = "Negative:";
// 
// labelPositiveCurrency
// 
this.labelPositiveCurrency.Location = new System.Drawing.Point(4, 28);
this.labelPositiveCurrency.Name = "labelPositiveCurrency";
this.labelPositiveCurrency.TabIndex = 0;
this.labelPositiveCurrency.Text = "Positive:";
// 
// tabPageTime
// 
this.tabPageTime.BackColor = System.Drawing.SystemColors.Window;
this.tabPageTime.Controls.Add(this.comboBoxAM);
this.tabPageTime.Controls.Add(this.comboBoxPM);
this.tabPageTime.Controls.Add(this.comboBoxFormat);
this.tabPageTime.Controls.Add(this.labelPM);
this.tabPageTime.Controls.Add(this.labelAM);
this.tabPageTime.Controls.Add(this.label1);
this.tabPageTime.Controls.Add(this.groupBoxSampleTime);
this.tabPageTime.Location = new System.Drawing.Point(4, 22);
this.tabPageTime.Name = "tabPageTime";
this.tabPageTime.Size = new System.Drawing.Size(394, 320);
this.tabPageTime.TabIndex = 2;
this.tabPageTime.Text = "Time";
// 
// comboBoxAM
// 
this.comboBoxAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxAM.Location = new System.Drawing.Point(104, 142);
this.comboBoxAM.Name = "comboBoxAM";
this.comboBoxAM.Size = new System.Drawing.Size(144, 21);
this.comboBoxAM.TabIndex = 31;
// 
// comboBoxPM
// 
this.comboBoxPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxPM.Location = new System.Drawing.Point(104, 186);
this.comboBoxPM.Name = "comboBoxPM";
this.comboBoxPM.Size = new System.Drawing.Size(144, 21);
this.comboBoxPM.TabIndex = 32;
// 
// comboBoxFormat
// 
this.comboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxFormat.Location = new System.Drawing.Point(104, 98);
this.comboBoxFormat.Name = "comboBoxFormat";
this.comboBoxFormat.Size = new System.Drawing.Size(144, 21);
this.comboBoxFormat.TabIndex = 29;
// 
// labelPM
// 
this.labelPM.Location = new System.Drawing.Point(22, 181);
this.labelPM.Name = "labelPM";
this.labelPM.Size = new System.Drawing.Size(136, 23);
this.labelPM.TabIndex = 28;
this.labelPM.Text = "PM:";
// 
// labelAM
// 
this.labelAM.Location = new System.Drawing.Point(22, 141);
this.labelAM.Name = "labelAM";
this.labelAM.Size = new System.Drawing.Size(136, 23);
this.labelAM.TabIndex = 27;
this.labelAM.Text = "AM:";
// 
// label1
// 
this.label1.Location = new System.Drawing.Point(22, 101);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(136, 23);
this.label1.TabIndex = 26;
this.label1.Text = "Time format:";
// 
// groupBoxSampleTime
// 
this.groupBoxSampleTime.Controls.Add(this.textBoxSample);
this.groupBoxSampleTime.Controls.Add(this.labelSample);
this.groupBoxSampleTime.Location = new System.Drawing.Point(11, 4);
this.groupBoxSampleTime.Name = "groupBoxSampleTime";
this.groupBoxSampleTime.Size = new System.Drawing.Size(370, 71);
this.groupBoxSampleTime.TabIndex = 2;
this.groupBoxSampleTime.TabStop = false;
this.groupBoxSampleTime.Text = "Sample";
// 
// textBoxSample
// 
this.textBoxSample.Location = new System.Drawing.Point(97, 28);
this.textBoxSample.Name = "textBoxSample";
this.textBoxSample.ReadOnly = true;
this.textBoxSample.Size = new System.Drawing.Size(123, 20);
this.textBoxSample.TabIndex = 3;
// 
// labelSample
// 
this.labelSample.Location = new System.Drawing.Point(4, 28);
this.labelSample.Name = "labelSample";
this.labelSample.TabIndex = 0;
this.labelSample.Text = "Time sample:";
// 
// tabPageDate
// 
this.tabPageDate.BackColor = System.Drawing.SystemColors.Window;
this.tabPageDate.Controls.Add(this.groupBoxLongDate);
this.tabPageDate.Controls.Add(this.groupBoxShortDate);
this.tabPageDate.Location = new System.Drawing.Point(4, 22);
this.tabPageDate.Name = "tabPageDate";
this.tabPageDate.Size = new System.Drawing.Size(394, 320);
this.tabPageDate.TabIndex = 3;
this.tabPageDate.Text = "Date";
// 
// groupBoxLongDate
// 
this.groupBoxLongDate.Controls.Add(this.comboBoxLongDateFormat);
this.groupBoxLongDate.Controls.Add(this.labelLongDateFormat);
this.groupBoxLongDate.Controls.Add(this.textBoxLongDate);
this.groupBoxLongDate.Controls.Add(this.labelLongDate);
this.groupBoxLongDate.Location = new System.Drawing.Point(12, 158);
this.groupBoxLongDate.Name = "groupBoxLongDate";
this.groupBoxLongDate.Size = new System.Drawing.Size(370, 97);
this.groupBoxLongDate.TabIndex = 4;
this.groupBoxLongDate.TabStop = false;
this.groupBoxLongDate.Text = "Long Date";
// 
// comboBoxLongDateFormat
// 
this.comboBoxLongDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxLongDateFormat.Location = new System.Drawing.Point(140, 50);
this.comboBoxLongDateFormat.Name = "comboBoxLongDateFormat";
this.comboBoxLongDateFormat.Size = new System.Drawing.Size(170, 21);
this.comboBoxLongDateFormat.TabIndex = 18;
// 
// labelLongDateFormat
// 
this.labelLongDateFormat.Location = new System.Drawing.Point(9, 52);
this.labelLongDateFormat.Name = "labelLongDateFormat";
this.labelLongDateFormat.Size = new System.Drawing.Size(136, 23);
this.labelLongDateFormat.TabIndex = 17;
this.labelLongDateFormat.Text = "Long date format";
// 
// textBoxLongDate
// 
this.textBoxLongDate.Location = new System.Drawing.Point(140, 19);
this.textBoxLongDate.Name = "textBoxLongDate";
this.textBoxLongDate.ReadOnly = true;
this.textBoxLongDate.Size = new System.Drawing.Size(170, 20);
this.textBoxLongDate.TabIndex = 16;
// 
// labelLongDate
// 
this.labelLongDate.Location = new System.Drawing.Point(9, 25);
this.labelLongDate.Name = "labelLongDate";
this.labelLongDate.TabIndex = 15;
this.labelLongDate.Text = "Long date sample:";
// 
// groupBoxShortDate
// 
this.groupBoxShortDate.Controls.Add(this.comboBoxDateSeparator);
this.groupBoxShortDate.Controls.Add(this.comboBoxShortDateFormat);
this.groupBoxShortDate.Controls.Add(this.labelDateSeparator);
this.groupBoxShortDate.Controls.Add(this.labelShortDateFormat);
this.groupBoxShortDate.Controls.Add(this.textBoxShortDate);
this.groupBoxShortDate.Controls.Add(this.labelShortDate);
this.groupBoxShortDate.Location = new System.Drawing.Point(11, 4);
this.groupBoxShortDate.Name = "groupBoxShortDate";
this.groupBoxShortDate.Size = new System.Drawing.Size(370, 132);
this.groupBoxShortDate.TabIndex = 3;
this.groupBoxShortDate.TabStop = false;
this.groupBoxShortDate.Text = "Short date";
// 
// comboBoxDateSeparator
// 
this.comboBoxDateSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxDateSeparator.Location = new System.Drawing.Point(142, 84);
this.comboBoxDateSeparator.Name = "comboBoxDateSeparator";
this.comboBoxDateSeparator.Size = new System.Drawing.Size(77, 21);
this.comboBoxDateSeparator.TabIndex = 15;
// 
// comboBoxShortDateFormat
// 
this.comboBoxShortDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.comboBoxShortDateFormat.Location = new System.Drawing.Point(142, 53);
this.comboBoxShortDateFormat.Name = "comboBoxShortDateFormat";
this.comboBoxShortDateFormat.Size = new System.Drawing.Size(170, 21);
this.comboBoxShortDateFormat.TabIndex = 14;
// 
// labelDateSeparator
// 
this.labelDateSeparator.Location = new System.Drawing.Point(4, 84);
this.labelDateSeparator.Name = "labelDateSeparator";
this.labelDateSeparator.Size = new System.Drawing.Size(136, 23);
this.labelDateSeparator.TabIndex = 13;
this.labelDateSeparator.Text = "Date separator:";
// 
// labelShortDateFormat
// 
this.labelShortDateFormat.Location = new System.Drawing.Point(4, 56);
this.labelShortDateFormat.Name = "labelShortDateFormat";
this.labelShortDateFormat.Size = new System.Drawing.Size(136, 23);
this.labelShortDateFormat.TabIndex = 12;
this.labelShortDateFormat.Text = "Short date format";
// 
// textBoxShortDate
// 
this.textBoxShortDate.Location = new System.Drawing.Point(142, 24);
this.textBoxShortDate.Name = "textBoxShortDate";
this.textBoxShortDate.ReadOnly = true;
this.textBoxShortDate.Size = new System.Drawing.Size(170, 20);
this.textBoxShortDate.TabIndex = 3;
// 
// labelShortDate
// 
this.labelShortDate.Location = new System.Drawing.Point(4, 28);
this.labelShortDate.Name = "labelShortDate";
this.labelShortDate.TabIndex = 0;
this.labelShortDate.Text = "Short date sample:";
// 
// buttonOk
// 
this.buttonOk.Location = new System.Drawing.Point(248, 374);
this.buttonOk.Name = "buttonOk";
this.buttonOk.TabIndex = 40;
this.buttonOk.Text = "OK";
this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
// 
// buttonCancel
// 
this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.buttonCancel.Location = new System.Drawing.Point(334, 374);
this.buttonCancel.Name = "buttonCancel";
this.buttonCancel.TabIndex = 42;
this.buttonCancel.Text = "Cancel";
this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
// 
// CultureOptions
// 
this.AcceptButton = this.buttonOk;
this.CancelButton = this.buttonCancel;
this.ClientSize = new System.Drawing.Size(415, 406);
this.Controls.Add(this.buttonCancel);
this.Controls.Add(this.buttonOk);
this.Controls.Add(this.tabControlMain);
this.Name = "CultureOptions";
this.Text = "Culture Options";
this.tabControlMain.ResumeLayout(false);
this.tabPageNumber.ResumeLayout(false);
this.groupBoxSample.ResumeLayout(false);
this.groupBoxSample.PerformLayout();
this.tabPageCurrency.ResumeLayout(false);
this.groupBoxCurrencySample.ResumeLayout(false);
this.groupBoxCurrencySample.PerformLayout();
this.tabPageTime.ResumeLayout(false);
this.groupBoxSampleTime.ResumeLayout(false);
this.groupBoxSampleTime.PerformLayout();
this.tabPageDate.ResumeLayout(false);
this.groupBoxLongDate.ResumeLayout(false);
this.groupBoxLongDate.PerformLayout();
this.groupBoxShortDate.ResumeLayout(false);
this.groupBoxShortDate.PerformLayout();
this.ResumeLayout(false);

		}
		#endregion

		private void buttonOk_Click(object sender, System.EventArgs e) 
		{
			SaveCulture();
			this.Close();
		}
		
		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/**
		 * Method to fill the fields appropriately for a new Culture
		 */
		public void SetFields()
		{
			comboBoxSymbol.Items.AddRange(new string[]{Constants.Dot, Constants.Comma});

			//Adding all the digits
			for (int i = 0; i <= 9; ++i)
			{
				comboBoxDigits.Items.Add(i.ToString(CultureInfo.CurrentUICulture));
				comboBoxDecimalDigits.Items.Add(i.ToString(CultureInfo.CurrentUICulture));
			}

			//Number tab
			comboBoxGrouping.Items.AddRange(new string[] { Constants.Comma, Constants.Space });
			comboBoxNegativeSign.Items.AddRange(new string[] { Constants.Hyphen});
			comboBoxNegativeNumber.Items.Add(Constants.GetNumberFormat(false, Constants.Minus, 
							Constants.SampleNumber)[0]);
			comboBoxNegativeNumber.Items.AddRange(Constants.GetNumberFormat(true, Constants.Minus, 
							Constants.SampleNumber));
			comboBoxSeparator.Items.AddRange(new string[] { Constants.Comma, Constants.SemiColon });

			//Currency tab
			comboBoxCurrencySymbol.Items.AddRange(new string[] { Constants.Dollar, "", "z" });
			comboBoxPositive.Items.AddRange(Constants.GetNumberFormat(true, Constants.Dollar, 
							Constants.SampleNumber));
			comboBoxNegative.Items.AddRange(Constants.GetNumberFormat(false, Constants.Dollar, 
							Constants.SampleNumber));
			comboBoxDecimal.Items.AddRange(new string[] { Constants.Dot, Constants.Comma });
			comboBoxGroupingCurrency.Items.AddRange(Constants.NumberGroupFormats);

			//Date tab
			comboBoxFormat.Items.AddRange(Constants.TimeFormats);
			comboBoxAM.Items.AddRange(new string[] { "AM", Constants.Space });
			comboBoxPM.Items.AddRange(new string[] { "PM", Constants.Space });

			//Time tab
			comboBoxShortDateFormat.Items.AddRange(Constants.ShortDateFormats);
			comboBoxDateSeparator.Items.AddRange(new string[] { Constants.Slash, Constants.Hyphen, 
							Constants.Dot });
			comboBoxLongDateFormat.Items.AddRange(Constants.LongDateFormats);

			SetSamples(CultureInfo.CurrentCulture);
			SelectItems();
		}

		/**
		 * Method to fill the fields appropriately for a mixed Culture
		 */
		public void SetFields(string loc1, string loc2)
		{
			locale1 = loc1;
			locale2 = loc2;
			SetSamples(CultureInfo.CurrentCulture);

			CultureInfo ci1 = new CultureInfo(locale1, false);
			CultureInfo ci2 = new CultureInfo(locale2, false);
			
			NumberFormatInfo nfi1 = ci1.NumberFormat;
			NumberFormatInfo nfi2 = ci2.NumberFormat;
			Int64 posInt = Constants.LongNumber;

			//Number tab
			comboBoxSymbol.Items.Add(nfi1.NumberDecimalSeparator);
			comboBoxSymbol.Items.Add(nfi2.NumberDecimalSeparator);
			comboBoxDigits.Items.Add(nfi1.NumberDecimalDigits);
			comboBoxDigits.Items.Add(nfi2.NumberDecimalDigits);
			comboBoxGrouping.Items.Add(posInt.ToString(Constants.NumberFormat, nfi1));
			comboBoxGrouping.Items.Add(posInt.ToString(Constants.NumberFormat, nfi2));
			comboBoxNegativeSign.Items.Add(nfi1.NegativeSign);
			comboBoxNegativeSign.Items.Add(nfi2.NegativeSign);
			posInt = -posInt;
			comboBoxNegativeNumber.Items.Add(posInt.ToString(Constants.NumberFormat, 
						nfi1));
			comboBoxNegativeNumber.Items.Add(posInt.ToString(Constants.NumberFormat, 
						nfi2));
			comboBoxSeparator.Items.Add(nfi1.NumberGroupSeparator);
			comboBoxSeparator.Items.Add(nfi2.NumberGroupSeparator);

			//Currency tab
			comboBoxCurrencySymbol.Items.Add(nfi1.CurrencySymbol);
			comboBoxCurrencySymbol.Items.Add(nfi2.CurrencySymbol);
			Double curr = 1.1;
			comboBoxPositive.Items.Add(curr.ToString(Constants.CurrencyFormat, nfi1));
			comboBoxPositive.Items.Add(curr.ToString(Constants.CurrencyFormat, nfi2));
			curr = -curr;
			comboBoxNegative.Items.Add(curr.ToString(Constants.CurrencyFormat, nfi1));
			comboBoxNegative.Items.Add(curr.ToString(Constants.CurrencyFormat, nfi2));

			comboBoxDecimal.Items.Add(nfi1.CurrencyDecimalSeparator.ToString(CultureInfo.CurrentUICulture));
			comboBoxDecimal.Items.Add(nfi2.CurrencyDecimalSeparator.ToString(CultureInfo.CurrentUICulture));
			comboBoxDecimalDigits.Items.Add(nfi1.CurrencyDecimalDigits.ToString(CultureInfo.CurrentUICulture));
			comboBoxDecimalDigits.Items.Add(nfi2.CurrencyDecimalDigits.ToString(CultureInfo.CurrentUICulture));
			posInt = -posInt;
			comboBoxGroupingCurrency.Items.Add(posInt.ToString(Constants.CurrencyFormat, 
						nfi1));
			comboBoxGroupingCurrency.Items.Add(posInt.ToString(Constants.CurrencyFormat, 
						nfi2));

			//Time tab
			DateTimeFormatInfo dfi1 = ci1.DateTimeFormat;
			DateTimeFormatInfo dfi2 = ci2.DateTimeFormat;
			
			comboBoxFormat.Items.Add(dfi1.LongTimePattern);
			comboBoxFormat.Items.Add(dfi2.LongTimePattern);
			comboBoxAM.Items.Add(dfi1.AMDesignator);
			comboBoxAM.Items.Add(dfi2.AMDesignator);
			comboBoxPM.Items.Add(dfi1.PMDesignator);
			comboBoxPM.Items.Add(dfi2.PMDesignator);

			//Date tab
			comboBoxShortDateFormat.Items.Add(dfi1.ShortDatePattern);
			comboBoxShortDateFormat.Items.Add(dfi2.ShortDatePattern);
			comboBoxDateSeparator.Items.Add(dfi1.DateSeparator);
			comboBoxDateSeparator.Items.Add(dfi2.DateSeparator);
			comboBoxLongDateFormat.Items.Add(dfi1.LongDatePattern);
			comboBoxLongDateFormat.Items.Add(dfi2.LongDatePattern);

			SelectItems();
		}

		private void SelectItems()
		{
			int i = 0;
			comboBoxAM.SelectedIndex = i;
			comboBoxCurrencySymbol.SelectedIndex = i;
			comboBoxDateSeparator.SelectedIndex = i;
			comboBoxDecimal.SelectedIndex = i;
			comboBoxDecimalDigits.SelectedIndex = i;
			comboBoxDigits.SelectedIndex = i;
			comboBoxFormat.SelectedIndex = i;
			comboBoxGrouping.SelectedIndex = i;
			comboBoxGroupingCurrency.SelectedIndex = i;
			comboBoxLongDateFormat.SelectedIndex = i;
			comboBoxNegative.SelectedIndex = i;
			comboBoxNegativeNumber.SelectedIndex = i;
			comboBoxNegativeSign.SelectedIndex = i;
			comboBoxPM.SelectedIndex = i;
			comboBoxPositive.SelectedIndex = i;
			comboBoxSeparator.SelectedIndex = i;
			comboBoxShortDateFormat.SelectedIndex = i;
			comboBoxSymbol.SelectedIndex = i;
		}
		
		/**
		 * Method to set samples for the current UICulture
		 */
		private void SetSamples(CultureInfo ci)
		{
			Int64 posInt = Constants.LongNumber;

			textBoxPositive.Text = posInt.ToString(Constants.NumberFormat, ci);
			textBoxPositiveCurrency.Text = posInt.ToString(Constants.CurrencyFormat, ci);
			posInt = -posInt;
			textBoxNegative.Text = posInt.ToString(Constants.NumberFormat, ci);
			textBoxNegativeCurrency.Text = posInt.ToString(Constants.CurrencyFormat, ci);

			DateTime dt = DateTime.Now;
			textBoxShortDate.Text = dt.ToString(Constants.ShortDateFormat, ci);
			textBoxLongDate.Text = dt.ToString(Constants.LongDateFormat, ci);
			textBoxSample.Text = dt.ToString(Constants.TimeFormat, ci);
		}
		
		/**
		 * Save the newly created culture
		 */
		private void SaveCulture()
		{
			NumberFormatInfo nfi = new NumberFormatInfo();
			DateTimeFormatInfo dfi = new DateTimeFormatInfo();

			nfi.NumberDecimalSeparator = comboBoxSymbol.SelectedItem.ToString();
			nfi.NumberDecimalDigits = Int32.Parse(comboBoxDigits.SelectedItem.ToString(), 
					CultureInfo.CurrentUICulture);
			nfi.NegativeSign = comboBoxNegativeSign.SelectedItem.ToString();
			nfi.NumberGroupSeparator = comboBoxSeparator.SelectedItem.ToString();

			nfi.CurrencySymbol = comboBoxCurrencySymbol.SelectedItem.ToString();
			nfi.CurrencyDecimalSeparator = comboBoxDecimal.SelectedItem.ToString();
			nfi.CurrencyDecimalDigits = Int32.Parse(
				comboBoxDecimalDigits.SelectedItem.ToString(), CultureInfo.CurrentUICulture);


			dfi.LongTimePattern = comboBoxFormat.SelectedItem.ToString();
			dfi.AMDesignator = comboBoxAM.SelectedItem.ToString();
			dfi.PMDesignator = comboBoxPM.SelectedItem.ToString();

			dfi.ShortDatePattern = comboBoxShortDateFormat.SelectedItem.ToString();
			dfi.DateSeparator = comboBoxDateSeparator.SelectedItem.ToString();
			dfi.LongDatePattern = comboBoxLongDateFormat.SelectedItem.ToString();

			//Save fields specific to particular mixed cultures and new cultures
			string name = language + Constants.Hyphen + region;
			if (locale1 != null)	//Mix culture
			{
				SaveForMixCulture(nfi);
				helper.GetNewCultureInfo(nfi, dfi, locale1, name);
			}
			else					//New culture
			{
				SaveForNewCulture(nfi); 
				helper.GetNewCultureInfo(nfi, dfi, CultureInfo.InvariantCulture.Name, name);
			}
		}

		private void SaveForMixCulture(NumberFormatInfo nfi)	
		{
			CultureInfo ci1 = new CultureInfo(locale1);
			CultureInfo ci2 = new CultureInfo(locale2);

			//Select the index and set from the corresponding culture
			nfi.CurrencyPositivePattern = (comboBoxPositive.SelectedIndex == 0) ?
					ci1.NumberFormat.CurrencyPositivePattern : 
					ci2.NumberFormat.CurrencyPositivePattern;

			nfi.CurrencyNegativePattern = (comboBoxNegative.SelectedIndex ==0) ?
					ci1.NumberFormat.CurrencyNegativePattern : 
					ci2.NumberFormat.CurrencyNegativePattern;

			nfi.NumberNegativePattern = (comboBoxNegativeNumber.SelectedIndex == 0)?
					ci1.NumberFormat.NumberNegativePattern : 
					ci2.NumberFormat.NumberNegativePattern;
		}

		private void SaveForNewCulture(NumberFormatInfo nfi)
		{	
			//Hard coded group sizes and Patterns
			nfi.NumberNegativePattern = comboBoxNegativeNumber.SelectedIndex;
			nfi.NumberGroupSizes = ParseGroupString(comboBoxGrouping.SelectedIndex);

			nfi.CurrencyPositivePattern = comboBoxPositive.SelectedIndex;
			nfi.CurrencyNegativePattern = comboBoxNegative.SelectedIndex;
			nfi.CurrencyGroupSizes = ParseGroupString(
					comboBoxGroupingCurrency.SelectedIndex);

		}

		/**
		 * Method to get array sizes
		 */
		private int[] ParseGroupString(int index)
		{
			int[][] NumberGroupSizes = { new int[] { 0 }, new int[] { 3 }, new int[] { 3, 2 } };
			return NumberGroupSizes[index];
		}
	}
}
