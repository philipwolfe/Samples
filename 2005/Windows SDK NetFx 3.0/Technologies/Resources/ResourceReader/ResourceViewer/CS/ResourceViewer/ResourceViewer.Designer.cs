//---------------------------------------------------------------------
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
//---------------------------------------------------------------------

namespace Microsoft.Samples.ResourceViewer
{
	partial class ResourceViewer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gridResources = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.txtBytes = new System.Windows.Forms.TextBox();
			this.lblBytes = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtType = new System.Windows.Forms.TextBox();
			this.image = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridResources)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
			this.SuspendLayout();
// 
// menuStrip1
// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.fileToolStripMenuItem
			});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(701, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
// 
// fileToolStripMenuItem
// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Text = "File";
// 
// openToolStripMenuItem
// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Text = "Open Resource File";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
// 
// toolStripSeparator1
// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
//			
// exitToolStripMenuItem
// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
// 
// gridResources
// 
			this.gridResources.AllowUserToAddRows = false;
			this.gridResources.AllowUserToDeleteRows = false;
			this.gridResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.gridResources.Columns.Add(this.dataGridViewTextBoxColumn1);
			this.gridResources.Columns.Add(this.dataGridViewTextBoxColumn2);
			this.gridResources.Columns.Add(this.dataGridViewTextBoxColumn3);
			this.gridResources.Location = new System.Drawing.Point(13, 28);
			this.gridResources.Margin = new System.Windows.Forms.Padding(3, 2, 2, 3);
			this.gridResources.Name = "gridResources";
			this.gridResources.RowHeadersVisible = false;
			this.gridResources.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.gridResources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridResources.Size = new System.Drawing.Size(303, 499);
			this.gridResources.TabIndex = 6;
			this.gridResources.SelectionChanged += new System.EventHandler(this.gridResources_SelectionChanged);
// 
// dataGridViewTextBoxColumn1
// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Name";
			this.dataGridViewTextBoxColumn1.Name = "Name";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
// 
// dataGridViewTextBoxColumn2
// 
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewTextBoxColumn2.HeaderText = "Type";
			this.dataGridViewTextBoxColumn2.Name = "Type";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 75;
// 
// dataGridViewTextBoxColumn3
// 
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewTextBoxColumn3.HeaderText = "Value";
			this.dataGridViewTextBoxColumn3.Name = "Value";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 125;
// 
// openFileDialog1
// 
			this.openFileDialog1.Filter = "Resource Files (*.resources)|*.resources|All Files (*.*)|*.*";
			this.openFileDialog1.Title = "Select Resource File to View";
// 
// txtBytes
// 
			this.txtBytes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtBytes.AutoSize = false;
			this.txtBytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.txtBytes.Location = new System.Drawing.Point(323, 394);
			this.txtBytes.Multiline = true;
			this.txtBytes.Name = "txtBytes";
			this.txtBytes.ReadOnly = true;
			this.txtBytes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBytes.Size = new System.Drawing.Size(366, 133);
			this.txtBytes.TabIndex = 7;
// 
// lblBytes
// 
			this.lblBytes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblBytes.AutoSize = true;
			this.lblBytes.Location = new System.Drawing.Point(319, 373);
			this.lblBytes.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.lblBytes.Name = "lblBytes";
			this.lblBytes.Size = new System.Drawing.Size(33, 14);
			this.lblBytes.TabIndex = 8;
			this.lblBytes.Text = "Bytes";
// 
// label3
// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(323, 27);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 14);
			this.label3.TabIndex = 9;
			this.label3.Text = "Name";
// 
// label4
// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(323, 70);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "Type";
// 
// lblName
// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(368, 29);
			this.lblName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(0, 0);
			this.lblName.TabIndex = 17;
// 
// lblType
// 
			this.lblType.AutoSize = true;
			this.lblType.Location = new System.Drawing.Point(368, 49);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(0, 0);
			this.lblType.TabIndex = 18;
// 
// txtName
// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(323, 44);
			this.txtName.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(366, 20);
			this.txtName.TabIndex = 23;
// 
// txtType
// 
			this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtType.Location = new System.Drawing.Point(323, 91);
			this.txtType.Multiline = true;
			this.txtType.Name = "txtType";
			this.txtType.ReadOnly = true;
			this.txtType.Size = new System.Drawing.Size(366, 37);
			this.txtType.TabIndex = 24;
// 
// image
// 
			this.image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.image.Location = new System.Drawing.Point(323, 156);
			this.image.Name = "image";
			this.image.Size = new System.Drawing.Size(366, 198);
			this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.image.TabIndex = 25;
			this.image.TabStop = false;
// 
// label2
// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(323, 135);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 14);
			this.label2.TabIndex = 30;
			this.label2.Text = "Value";
// 
// txtValue
// 
			this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtValue.AutoSize = false;
			this.txtValue.Location = new System.Drawing.Point(323, 156);
			this.txtValue.Multiline = true;
			this.txtValue.Name = "txtValue";
			this.txtValue.ReadOnly = true;
			this.txtValue.Size = new System.Drawing.Size(366, 210);
			this.txtValue.TabIndex = 31;
			this.txtValue.Visible = false;
// 
// ResourceViewer
// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(701, 539);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtType);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblBytes);
			this.Controls.Add(this.txtBytes);
			this.Controls.Add(this.gridResources);
			this.Controls.Add(this.image);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.menuStrip1);
			this.Name = "ResourceViewer";
			this.Text = "Resource Viewer";
			this.menuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridResources)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.DataGridView gridResources;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.TextBox txtBytes;
		private System.Windows.Forms.Label lblBytes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtType;
		private System.Windows.Forms.PictureBox image;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtValue;
	}
}

