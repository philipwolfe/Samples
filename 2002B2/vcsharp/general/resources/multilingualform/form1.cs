//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.

//THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.

namespace Multi_lingual_Form
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;

    /// <summary>
    ///    Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.TextBox CultureEdit;
		private System.Windows.Forms.Button SwitchButton;
        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;

        public Form1()
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
			if(components != null)
				components.Dispose();
        }

		#region Windows Form Designer generated code
        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.SwitchButton = new System.Windows.Forms.Button();
			this.CultureEdit = new System.Windows.Forms.TextBox();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.SwitchButton.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom);
			this.SwitchButton.Location = ((System.Drawing.Point)(resources.GetObject("SwitchButton.Location")));
			this.SwitchButton.Size = ((System.Drawing.Size)(resources.GetObject("SwitchButton.Size")));
			this.SwitchButton.TabIndex = ((int)(resources.GetObject("SwitchButton.TabIndex")));
			this.SwitchButton.Text = resources.GetString("SwitchButton.Text");
			this.SwitchButton.Click += new System.EventHandler(this.SwitchButton_Click);
			this.CultureEdit.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom);
			this.CultureEdit.Location = ((System.Drawing.Point)(resources.GetObject("CultureEdit.Location")));
			this.CultureEdit.Size = ((System.Drawing.Size)(resources.GetObject("CultureEdit.Size")));
			this.CultureEdit.TabIndex = ((int)(resources.GetObject("CultureEdit.TabIndex")));
			this.CultureEdit.WordWrap = false;
			this.TitleLabel.Anchor = (System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom);
			this.TitleLabel.Location = ((System.Drawing.Point)(resources.GetObject("TitleLabel.Location")));
			this.TitleLabel.Size = ((System.Drawing.Size)(resources.GetObject("TitleLabel.Size")));
			this.TitleLabel.TabIndex = ((int)(resources.GetObject("TitleLabel.TabIndex")));
			this.TitleLabel.Text = resources.GetString("TitleLabel.Text");
			this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.AcceptButton = this.SwitchButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.SwitchButton,
																		  this.CultureEdit,
																		  this.TitleLabel});
			this.MaximizeBox = ((bool)(resources.GetObject("$this.MaximizeBox")));
			this.MinimizeBox = ((bool)(resources.GetObject("$this.MinimizeBox")));
			this.Text = resources.GetString("$this.Text");

		}
		#endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args) 
        {
			// Start off in the default culture
			System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("", false); 
			Application.Run(new Form1());
        }

		// Handles the Click event for the SwitchButton
		private void SwitchButton_Click(object sender, System.EventArgs e)
		{
			// Switch to the new culture and display a new form
			System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(CultureEdit.Text, false); 
			(new Form1()).Show();
		}
    }
}
