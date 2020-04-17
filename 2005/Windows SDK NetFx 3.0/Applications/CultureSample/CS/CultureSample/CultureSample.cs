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
	/// Main window for the application.
	/// </summary>
	public class CultureBuilder : System.Windows.Forms.Form
	{
		#region Windows Form Designer declarations
		private System.Windows.Forms.ToolStrip toolStripTop;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton mixToolStripButton;
		private System.Windows.Forms.ToolStripButton instanceToolStripButton;
		private System.Windows.Forms.Panel panelDisplayCulture;
		#endregion

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		//Helper to pass on to the children windows
		private CultureInfoHelper helper;

		public CultureBuilder()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DisplayCulture display = new DisplayCulture();
			helper = new CultureInfoHelper(display);
			display.LoadComboBox(helper.GetCultures(CultureTypes.AllCultures));
			panelDisplayCulture.Controls.Add(display);	
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
			this.toolStripTop = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.mixToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.instanceToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.panelDisplayCulture = new System.Windows.Forms.Panel();
			this.toolStripTop.SuspendLayout();
			this.SuspendLayout();
// 
// toolStripTop
// 
			this.toolStripTop.Cursor = System.Windows.Forms.Cursors.Default;
			this.toolStripTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.newToolStripButton, this.mixToolStripButton, this.instanceToolStripButton
			});
			this.toolStripTop.Location = new System.Drawing.Point(0, 0);
			this.toolStripTop.Name = "toolStripTop";
			this.toolStripTop.Size = new System.Drawing.Size(377, 25);
			this.toolStripTop.TabIndex = 15;
			this.toolStripTop.Visible = true;
// 
// newToolStripButton
// 
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Text = "New culture";
			this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
// 
// mixToolStripButton
// 
			this.mixToolStripButton.Name = "mixToolStripButton";
			this.mixToolStripButton.Text = "Mix cultures";
			this.mixToolStripButton.Click += new System.EventHandler(this.mixToolStripButton_Click);
// 
// instanceToolStripButton
// 
			this.instanceToolStripButton.Name = "instanceToolStripButton";
			this.instanceToolStripButton.Text = "New instance";
			this.instanceToolStripButton.Click += new System.EventHandler(this.instanceToolStripButton_Click);
// 
// panelDisplayCulture
// 
			this.panelDisplayCulture.Location = new System.Drawing.Point(4, 26);
			this.panelDisplayCulture.Name = "panelDisplayCulture";
			this.panelDisplayCulture.Size = new System.Drawing.Size(369, 374);
			this.panelDisplayCulture.TabIndex = 16;
// 
// CultureBuilder
// 
			this.ClientSize = new System.Drawing.Size(377, 403);
			this.Controls.Add(this.panelDisplayCulture);
			this.Controls.Add(this.toolStripTop);
			this.Name = "CultureBuilder";
			this.Text = "Culture Builder";
			this.toolStripTop.ResumeLayout(false);
			this.toolStripTop.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		private void newToolStripButton_Click(object sender, System.EventArgs e)
		{
			new NewCulture(helper).Show();
		}

		private void mixToolStripButton_Click(object sender, System.EventArgs e)
		{
			new MixCultures(helper).Show();
		}

		private void instanceToolStripButton_Click(object sender, System.EventArgs e)
		{
			new NewInstance(helper).Show();
		}
	}
}
