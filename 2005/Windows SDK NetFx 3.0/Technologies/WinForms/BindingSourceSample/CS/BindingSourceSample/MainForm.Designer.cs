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

namespace Microsoft.Samples.Windows.Forms.BindingSourceSample
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.positionIndicator = new System.Windows.Forms.TextBox();
			this.movePrevious = new System.Windows.Forms.Button();
			this.moveNext = new System.Windows.Forms.Button();
			this.info = new System.Windows.Forms.TextBox();
			this.flagsCombo = new System.Windows.Forms.ComboBox();
			this.flagName = new System.Windows.Forms.Label();
			this.flagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.flagPicture = new System.Windows.Forms.PictureBox();
			this.addButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.flagsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flagPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// positionIndicator
			// 
			this.positionIndicator.Location = new System.Drawing.Point(38, 13);
			this.positionIndicator.Name = "positionIndicator";
			this.positionIndicator.ReadOnly = true;
			this.positionIndicator.Size = new System.Drawing.Size(44, 21);
			this.positionIndicator.TabIndex = 4;
			this.positionIndicator.TabStop = false;
			this.toolTip1.SetToolTip(this.positionIndicator, "Position / Total Records");
			this.positionIndicator.MouseLeave += new System.EventHandler(this.Mouse_MouseEnter);
			this.positionIndicator.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
			// 
			// movePrevious
			// 
			this.movePrevious.Location = new System.Drawing.Point(12, 11);
			this.movePrevious.Name = "movePrevious";
			this.movePrevious.Size = new System.Drawing.Size(20, 23);
			this.movePrevious.TabIndex = 2;
			this.movePrevious.Text = "<";
			this.toolTip1.SetToolTip(this.movePrevious, "Move Previous");
			this.movePrevious.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
			this.movePrevious.Click += new System.EventHandler(this.movePrevious_Click);
			this.movePrevious.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
			// 
			// moveNext
			// 
			this.moveNext.Location = new System.Drawing.Point(88, 11);
			this.moveNext.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
			this.moveNext.Name = "moveNext";
			this.moveNext.Size = new System.Drawing.Size(20, 23);
			this.moveNext.TabIndex = 3;
			this.moveNext.Text = ">";
			this.toolTip1.SetToolTip(this.moveNext, "Move Next");
			this.moveNext.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
			this.moveNext.Click += new System.EventHandler(this.moveNext_Click);
			this.moveNext.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
			// 
			// info
			// 
			this.info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.info.Location = new System.Drawing.Point(174, 13);
			this.info.Multiline = true;
			this.info.Name = "info";
			this.info.ReadOnly = true;
			this.info.Size = new System.Drawing.Size(254, 184);
			this.info.TabIndex = 24;
			this.info.TabStop = false;
			// 
			// flagsCombo
			// 
			this.flagsCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.flagsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.flagsCombo.FormattingEnabled = true;
			this.flagsCombo.Location = new System.Drawing.Point(5, 176);
			this.flagsCombo.Name = "flagsCombo";
			this.flagsCombo.Size = new System.Drawing.Size(113, 21);
			this.flagsCombo.Sorted = true;
			this.flagsCombo.TabIndex = 1;
			this.flagsCombo.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
			this.flagsCombo.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
			// 
			// flagName
			// 
			this.flagName.AutoSize = true;
			this.flagName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flagsBindingSource, "Name", true));
			this.flagName.Location = new System.Drawing.Point(5, 52);
			this.flagName.Name = "flagName";
			this.flagName.Size = new System.Drawing.Size(95, 15);
			this.flagName.TabIndex = 9;
			this.flagName.Text = "No Flags to Display";
			this.flagName.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
			this.flagName.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
			// 
			// flagsBindingSource
			// 
			this.flagsBindingSource.DataSource = typeof(Microsoft.Samples.Windows.Forms.BindingSourceSample.Flag);
			this.flagsBindingSource.PositionChanged += new System.EventHandler(this.flagsBindingSource_PositionChanged);
			this.flagsBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.flagsBindingSource_ListChanged);
			// 
			// flagPicture
			// 
			this.flagPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.flagPicture.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.flagsBindingSource, "Image", true));
			this.flagPicture.Location = new System.Drawing.Point(5, 73);
			this.flagPicture.Name = "flagPicture";
			this.flagPicture.Size = new System.Drawing.Size(163, 96);
			this.flagPicture.TabIndex = 8;
			this.flagPicture.TabStop = false;
			this.flagPicture.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
			this.flagPicture.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.addButton.Location = new System.Drawing.Point(123, 175);
			this.addButton.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(45, 23);
			this.addButton.TabIndex = 0;
			this.addButton.Text = "&Add";
			this.addButton.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			this.addButton.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
			// 
			// MainForm
			// 
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(433, 205);
			this.Controls.Add(this.info);
			this.Controls.Add(this.flagsCombo);
			this.Controls.Add(this.flagName);
			this.Controls.Add(this.flagPicture);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.positionIndicator);
			this.Controls.Add(this.movePrevious);
			this.Controls.Add(this.moveNext);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximumSize = new System.Drawing.Size(800, 300);
			this.MinimumSize = new System.Drawing.Size(441, 239);
			this.Name = "MainForm";
			this.Text = "BindingSource Type Binding Sample";
			this.Load += new System.EventHandler(this.BindingSourceSample_Load);
			((System.ComponentModel.ISupportInitialize)(this.flagsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flagPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox info;
		private System.Windows.Forms.ComboBox flagsCombo;
		private System.Windows.Forms.Label flagName;
		private System.Windows.Forms.BindingSource flagsBindingSource;
		private System.Windows.Forms.PictureBox flagPicture;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.TextBox positionIndicator;
		private System.Windows.Forms.Button movePrevious;
		private System.Windows.Forms.Button moveNext;
    }
}

