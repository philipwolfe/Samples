//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) 2005 Microsoft Corporation.  All rights reserved.
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

namespace Microsoft.Samples.Windows.Forms.BindingNavigatorSample
{
	public partial class BindingNavigatorSample : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindingNavigatorSample));
            this.flagsNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.flagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.addComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.info = new System.Windows.Forms.TextBox();
            this.flagName = new System.Windows.Forms.Label();
            this.flagPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.flagsNavigator)).BeginInit();
            this.flagsNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flagsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flagPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // flagsNavigator
            // 
            this.flagsNavigator.AddNewItem = null;
            this.flagsNavigator.BindingSource = this.flagsBindingSource;
            this.flagsNavigator.CountItem = this.bindingNavigatorCountItem;
            this.flagsNavigator.DeleteItem = null;
            this.flagsNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.flagsNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator5,
            this.addComboBox,
            this.bindingNavigatorAddNewItem});
            this.flagsNavigator.Location = new System.Drawing.Point(0, 0);
            this.flagsNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.flagsNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.flagsNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.flagsNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.flagsNavigator.Name = "flagsNavigator";
            this.flagsNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.flagsNavigator.Size = new System.Drawing.Size(624, 25);
            this.flagsNavigator.TabIndex = 0;
            this.flagsNavigator.TabStop = true;
            this.flagsNavigator.Text = "bindingNavigator1";
            // 
            // flagsBindingSource
            // 
            this.flagsBindingSource.DataSource = typeof(Microsoft.Samples.Windows.Forms.BindingNavigatorSample.Flag);
            this.flagsBindingSource.CurrentChanged += new System.EventHandler(this.flagsBindingSource_CurrentChanged);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            this.bindingNavigatorCountItem.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            this.bindingNavigatorCountItem.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(75, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move &first";
            this.bindingNavigatorMoveFirstItem.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            this.bindingNavigatorMoveFirstItem.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(97, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move &previous";
            this.bindingNavigatorMovePreviousItem.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            this.bindingNavigatorMovePreviousItem.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            this.bindingNavigatorSeparator3.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            this.bindingNavigatorSeparator3.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            this.bindingNavigatorPositionItem.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            this.bindingNavigatorSeparator4.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            this.bindingNavigatorSeparator4.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(78, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move &next";
            this.bindingNavigatorMoveNextItem.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            this.bindingNavigatorMoveNextItem.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(73, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move &last";
            this.bindingNavigatorMoveLastItem.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            this.bindingNavigatorMoveLastItem.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // addComboBox
            // 
            this.addComboBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.addComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addComboBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.addComboBox.Name = "addComboBox";
            this.addComboBox.Size = new System.Drawing.Size(121, 25);
            this.addComboBox.Sorted = true;
            this.addComboBox.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            this.addComboBox.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(69, 22);
            this.bindingNavigatorAddNewItem.Text = "&Add new";
            this.bindingNavigatorAddNewItem.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            this.bindingNavigatorAddNewItem.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // info
            // 
            this.info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.info.Location = new System.Drawing.Point(174, 34);
            this.info.Multiline = true;
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(445, 126);
            this.info.TabIndex = 0;
            this.info.TabStop = false;
            // 
            // flagName
            // 
            this.flagName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flagName.AutoSize = true;
            this.flagName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flagsBindingSource, "Name", true));
            this.flagName.Location = new System.Drawing.Point(5, 34);
            this.flagName.Name = "flagName";
            this.flagName.Size = new System.Drawing.Size(98, 13);
            this.flagName.TabIndex = 9;
            this.flagName.Text = "No Flags to Display";
            this.flagName.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            this.flagName.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            // 
            // flagPicture
            // 
            this.flagPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.flagPicture.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.flagsBindingSource, "Image", true));
            this.flagPicture.Location = new System.Drawing.Point(5, 55);
            this.flagPicture.Name = "flagPicture";
            this.flagPicture.Size = new System.Drawing.Size(163, 105);
            this.flagPicture.TabIndex = 8;
            this.flagPicture.TabStop = false;
            this.flagPicture.MouseLeave += new System.EventHandler(this.Mouse_MouseLeave);
            this.flagPicture.MouseEnter += new System.EventHandler(this.Mouse_MouseEnter);
            // 
            // BindingNavigatorSample
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(624, 166);
            this.Controls.Add(this.flagsNavigator);
            this.Controls.Add(this.info);
            this.Controls.Add(this.flagName);
            this.Controls.Add(this.flagPicture);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BindingNavigatorSample";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Binding Navigator Sample";
            this.Load += new System.EventHandler(this.BindingSourceSample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flagsNavigator)).EndInit();
            this.flagsNavigator.ResumeLayout(false);
            this.flagsNavigator.PerformLayout();
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

		private System.Windows.Forms.BindingNavigator flagsNavigator;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
		private System.Windows.Forms.ToolStripComboBox addComboBox;
		private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
		private System.Windows.Forms.TextBox info;
		private System.Windows.Forms.Label flagName;
		private System.Windows.Forms.PictureBox flagPicture;
		private System.Windows.Forms.BindingSource flagsBindingSource;
	}
}

