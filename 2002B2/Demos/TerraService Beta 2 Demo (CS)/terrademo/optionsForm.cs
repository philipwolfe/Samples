// Copyright (C) Microsoft Corporation.  All Rights Reserved.
// optionsForm.cs

namespace terraDemo
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows;
	using System.Windows.Forms;

    /// <summary>
    ///    Summary description for Form2.
    /// </summary>
    public class OptionsForm : System.Windows.Forms.Form
    {
		public Color gridColor, gridTextColor, borderColor;
		public Font gridTextFont;
        /// <summary>
        ///    Required designer variable.
        /// </summary>
		public System.Windows.Forms.CheckBox chkLandmarks;
		public System.Windows.Forms.CheckBox chkLabel;
		private System.Windows.Forms.Button btnGridTextFont;
		private System.Windows.Forms.Button btnGridTextColor;
		private System.Windows.Forms.Button btnBorderColor;
		private System.Windows.Forms.Button btnGridColor;
		public System.Windows.Forms.RadioButton geoButton;
		public System.Windows.Forms.RadioButton utmButton;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.CheckBox chkLogo;
		public System.Windows.Forms.TextBox txtBorderWidth;
		private System.Windows.Forms.Label lblBorderWidth;
		public System.Windows.Forms.TextBox txtGridWidth;
		private System.Windows.Forms.Label lblGridWidth;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;

        public OptionsForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        ///    Clean up any resources being used.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			this.chkLandmarks = new System.Windows.Forms.CheckBox();
			this.txtBorderWidth = new System.Windows.Forms.TextBox();
			this.lblGridWidth = new System.Windows.Forms.Label();
			this.btnBorderColor = new System.Windows.Forms.Button();
			this.txtGridWidth = new System.Windows.Forms.TextBox();
			this.geoButton = new System.Windows.Forms.RadioButton();
			this.btnGridTextColor = new System.Windows.Forms.Button();
			this.chkLabel = new System.Windows.Forms.CheckBox();
			this.btnGridTextFont = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.utmButton = new System.Windows.Forms.RadioButton();
			this.lblBorderWidth = new System.Windows.Forms.Label();
			this.btnGridColor = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.chkLogo = new System.Windows.Forms.CheckBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkLandmarks
			// 
			this.chkLandmarks.Checked = true;
			this.chkLandmarks.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkLandmarks.Location = new System.Drawing.Point(16, 104);
			this.chkLandmarks.Name = "chkLandmarks";
			this.chkLandmarks.Size = new System.Drawing.Size(136, 24);
			this.chkLandmarks.TabIndex = 21;
			this.chkLandmarks.Text = "PreFetch Landmarks";
			// 
			// txtBorderWidth
			// 
			this.txtBorderWidth.Location = new System.Drawing.Point(88, 64);
			this.txtBorderWidth.Name = "txtBorderWidth";
			this.txtBorderWidth.Size = new System.Drawing.Size(104, 20);
			this.txtBorderWidth.TabIndex = 8;
			this.txtBorderWidth.Text = "0";
			// 
			// lblGridWidth
			// 
			this.lblGridWidth.AutoSize = true;
			this.lblGridWidth.Location = new System.Drawing.Point(8, 40);
			this.lblGridWidth.Name = "lblGridWidth";
			this.lblGridWidth.Size = new System.Drawing.Size(61, 13);
			this.lblGridWidth.TabIndex = 2;
			this.lblGridWidth.Text = "Grid Width:";
			// 
			// btnBorderColor
			// 
			this.btnBorderColor.Location = new System.Drawing.Point(180, 184);
			this.btnBorderColor.Name = "btnBorderColor";
			this.btnBorderColor.Size = new System.Drawing.Size(120, 24);
			this.btnBorderColor.TabIndex = 17;
			this.btnBorderColor.Text = "Border Color...";
			this.btnBorderColor.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtGridWidth
			// 
			this.txtGridWidth.Location = new System.Drawing.Point(88, 32);
			this.txtGridWidth.Name = "txtGridWidth";
			this.txtGridWidth.Size = new System.Drawing.Size(104, 20);
			this.txtGridWidth.TabIndex = 3;
			this.txtGridWidth.Text = "0";
			// 
			// geoButton
			// 
			this.geoButton.Location = new System.Drawing.Point(16, 56);
			this.geoButton.Name = "geoButton";
			this.geoButton.Size = new System.Drawing.Size(88, 23);
			this.geoButton.TabIndex = 1;
			this.geoButton.Text = "Geographic";
			// 
			// btnGridTextColor
			// 
			this.btnGridTextColor.Location = new System.Drawing.Point(180, 232);
			this.btnGridTextColor.Name = "btnGridTextColor";
			this.btnGridTextColor.Size = new System.Drawing.Size(120, 24);
			this.btnGridTextColor.TabIndex = 18;
			this.btnGridTextColor.Text = "Grid Text Color...";
			this.btnGridTextColor.Click += new System.EventHandler(this.button3_Click);
			// 
			// chkLabel
			// 
			this.chkLabel.Checked = true;
			this.chkLabel.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkLabel.Location = new System.Drawing.Point(8, 136);
			this.chkLabel.Name = "chkLabel";
			this.chkLabel.Size = new System.Drawing.Size(112, 32);
			this.chkLabel.TabIndex = 20;
			this.chkLabel.Text = "Label Grid Lines";
			this.chkLabel.CheckedChanged += new System.EventHandler(this.chkLabelLineChanged);
			// 
			// btnGridTextFont
			// 
			this.btnGridTextFont.Location = new System.Drawing.Point(44, 232);
			this.btnGridTextFont.Name = "btnGridTextFont";
			this.btnGridTextFont.Size = new System.Drawing.Size(120, 24);
			this.btnGridTextFont.TabIndex = 19;
			this.btnGridTextFont.Text = "Grid Text Font...";
			this.btnGridTextFont.Click += new System.EventHandler(this.btnGridTextFont_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.geoButton,
																					this.utmButton});
			this.groupBox1.Location = new System.Drawing.Point(216, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(112, 88);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Grid Type";
			// 
			// utmButton
			// 
			this.utmButton.Checked = true;
			this.utmButton.Location = new System.Drawing.Point(16, 24);
			this.utmButton.Name = "utmButton";
			this.utmButton.Size = new System.Drawing.Size(88, 16);
			this.utmButton.TabIndex = 0;
			this.utmButton.TabStop = true;
			this.utmButton.Text = "UTM";
			// 
			// lblBorderWidth
			// 
			this.lblBorderWidth.AutoSize = true;
			this.lblBorderWidth.Location = new System.Drawing.Point(8, 72);
			this.lblBorderWidth.Name = "lblBorderWidth";
			this.lblBorderWidth.Size = new System.Drawing.Size(73, 13);
			this.lblBorderWidth.TabIndex = 6;
			this.lblBorderWidth.Text = "Border Width:";
			// 
			// btnGridColor
			// 
			this.btnGridColor.Location = new System.Drawing.Point(44, 184);
			this.btnGridColor.Name = "btnGridColor";
			this.btnGridColor.Size = new System.Drawing.Size(120, 24);
			this.btnGridColor.TabIndex = 16;
			this.btnGridColor.Text = "Grid Color...";
			this.btnGridColor.Click += new System.EventHandler(this.button1_Click);
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(72, 280);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(88, 24);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			// 
			// chkLogo
			// 
			this.chkLogo.Location = new System.Drawing.Point(152, 128);
			this.chkLogo.Name = "chkLogo";
			this.chkLogo.TabIndex = 10;
			this.chkLogo.Text = "USGS Logo";
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(184, 280);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(88, 24);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(344, 333);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkLandmarks,
																		  this.chkLabel,
																		  this.btnGridTextFont,
																		  this.btnGridTextColor,
																		  this.btnBorderColor,
																		  this.btnGridColor,
																		  this.groupBox1,
																		  this.chkLogo,
																		  this.txtBorderWidth,
																		  this.lblBorderWidth,
																		  this.lblGridWidth,
																		  this.txtGridWidth,
																		  this.cancelButton,
																		  this.okButton});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TerraService Options";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		protected void listPushPins_SelectedIndexChanged (object sender, System.EventArgs e)
		{

		}

		protected void chkLabelLineChanged (object sender, System.EventArgs e)
		{
			if (chkLabel.Checked)
			{
				btnGridTextFont.Enabled = true;
				btnGridTextColor.Enabled = true;
			}
			else
			{
				btnGridTextFont.Enabled = false;
				btnGridTextColor.Enabled = false;
			}				
		}

		protected void btnGridTextFont_Click (object sender, System.EventArgs e)
		{
			System.Windows.Forms.FontDialog dlg = new FontDialog();
			dlg.Font = gridTextFont;
			dlg.ShowDialog();
			gridTextFont = dlg.Font;
		}

		protected void button3_Click (object sender, System.EventArgs e)
		{
 			ColorDialog dlg = new ColorDialog();
			dlg.Color = gridTextColor;
			dlg.ShowDialog ();
			gridTextColor = dlg.Color;
		}

		protected void button2_Click (object sender, System.EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			dlg.Color = borderColor;
			dlg.ShowDialog ();
			borderColor = dlg.Color;
		}

		protected void button1_Click (object sender, System.EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			dlg.Color = gridColor;
			dlg.ShowDialog ();
			gridColor = dlg.Color;
		}

		protected void theResize (object sender, System.EventArgs e)
		{

		}
    }
}
