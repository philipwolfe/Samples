namespace UsingSplitContainer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Bob Franklin");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sue Wilson");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Northwest", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Frank Roberts");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Southwest", new System.Windows.Forms.TreeNode[] {
            treeNode4});
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Sales By Region", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5});
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.SalesTreeView = new System.Windows.Forms.TreeView();
			this.DetailsGroupBox = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.YTDSalesTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.PhoneTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.EmployeeTextBox = new System.Windows.Forms.TextBox();
			this.SalesGroupBox = new System.Windows.Forms.GroupBox();
			this.SalesDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VerticalSplitContainer = new System.Windows.Forms.SplitContainer();
			this.DetailsGroupBox.SuspendLayout();
			this.SalesGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).BeginInit();
			this.VerticalSplitContainer.Panel1.SuspendLayout();
			this.VerticalSplitContainer.Panel2.SuspendLayout();
			this.VerticalSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// SalesTreeView
			// 
			this.SalesTreeView.Location = new System.Drawing.Point(5, 10);
			this.SalesTreeView.Name = "SalesTreeView";
			treeNode1.Name = "Node6";
			treeNode1.Text = "Bob Franklin";
			treeNode2.Name = "Node7";
			treeNode2.Text = "Sue Wilson";
			treeNode3.Name = "Node1";
			treeNode3.Text = "Northwest";
			treeNode4.Name = "Node8";
			treeNode4.Text = "Frank Roberts";
			treeNode5.Name = "Node2";
			treeNode5.Text = "Southwest";
			treeNode6.Name = "Node0";
			treeNode6.Text = "Sales By Region";
			this.SalesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
			this.SalesTreeView.Size = new System.Drawing.Size(162, 332);
			this.SalesTreeView.TabIndex = 0;
			this.SalesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SalesTreeView_AfterSelect);
			// 
			// DetailsGroupBox
			// 
			this.DetailsGroupBox.Controls.Add(this.label3);
			this.DetailsGroupBox.Controls.Add(this.YTDSalesTextBox);
			this.DetailsGroupBox.Controls.Add(this.label2);
			this.DetailsGroupBox.Controls.Add(this.PhoneTextBox);
			this.DetailsGroupBox.Controls.Add(this.label1);
			this.DetailsGroupBox.Controls.Add(this.EmployeeTextBox);
			this.DetailsGroupBox.Location = new System.Drawing.Point(13, 10);
			this.DetailsGroupBox.MinimumSize = new System.Drawing.Size(200, 100);
			this.DetailsGroupBox.Name = "DetailsGroupBox";
			this.DetailsGroupBox.Size = new System.Drawing.Size(201, 102);
			this.DetailsGroupBox.TabIndex = 1;
			this.DetailsGroupBox.TabStop = false;
			this.DetailsGroupBox.Text = "Details";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "YTD Sales:";
			// 
			// YTDSalesTextBox
			// 
			this.YTDSalesTextBox.Enabled = false;
			this.YTDSalesTextBox.Location = new System.Drawing.Point(94, 73);
			this.YTDSalesTextBox.Name = "YTDSalesTextBox";
			this.YTDSalesTextBox.Size = new System.Drawing.Size(100, 20);
			this.YTDSalesTextBox.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Phone:";
			// 
			// PhoneTextBox
			// 
			this.PhoneTextBox.Enabled = false;
			this.PhoneTextBox.Location = new System.Drawing.Point(94, 46);
			this.PhoneTextBox.Name = "PhoneTextBox";
			this.PhoneTextBox.Size = new System.Drawing.Size(100, 20);
			this.PhoneTextBox.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Employee:";
			// 
			// EmployeeTextBox
			// 
			this.EmployeeTextBox.Enabled = false;
			this.EmployeeTextBox.Location = new System.Drawing.Point(94, 19);
			this.EmployeeTextBox.Name = "EmployeeTextBox";
			this.EmployeeTextBox.Size = new System.Drawing.Size(100, 20);
			this.EmployeeTextBox.TabIndex = 0;
			// 
			// SalesGroupBox
			// 
			this.SalesGroupBox.Controls.Add(this.SalesDataGridView);
			this.SalesGroupBox.Location = new System.Drawing.Point(13, 148);
			this.SalesGroupBox.Name = "SalesGroupBox";
			this.SalesGroupBox.Size = new System.Drawing.Size(200, 100);
			this.SalesGroupBox.TabIndex = 2;
			this.SalesGroupBox.TabStop = false;
			this.SalesGroupBox.Text = "Sales";
			// 
			// SalesDataGridView
			// 
			this.SalesDataGridView.AllowUserToAddRows = false;
			this.SalesDataGridView.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.FormatProvider = new System.Globalization.CultureInfo("en-US");
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.SalesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.SalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.SalesDataGridView.Columns.Add(this.dataGridViewTextBoxColumn1);
			this.SalesDataGridView.Columns.Add(this.dataGridViewTextBoxColumn2);
			this.SalesDataGridView.Columns.Add(this.dataGridViewTextBoxColumn3);
			this.SalesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SalesDataGridView.Enabled = false;
			this.SalesDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.SalesDataGridView.Location = new System.Drawing.Point(3, 16);
			this.SalesDataGridView.Name = "SalesDataGridView";
			this.SalesDataGridView.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.FormatProvider = new System.Globalization.CultureInfo("en-US");
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.SalesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.SalesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle3.FormatProvider = new System.Globalization.CultureInfo("en-US");
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
			this.SalesDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.SalesDataGridView.Size = new System.Drawing.Size(194, 81);
			this.SalesDataGridView.TabIndex = 0;
			this.SalesDataGridView.Text = "dataGridView1";
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Date";
			this.dataGridViewTextBoxColumn1.Name = "Date";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Customer ID";
			this.dataGridViewTextBoxColumn2.Name = "Column1";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn3.Name = "Column2";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// VerticalSplitContainer
			// 
			this.VerticalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VerticalSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.VerticalSplitContainer.Name = "VerticalSplitContainer";
			// 
			// VerticalSplitContainer.Panel1
			// 
			this.VerticalSplitContainer.Panel1.Controls.Add(this.SalesTreeView);
			// 
			// VerticalSplitContainer.Panel2
			// 
			this.VerticalSplitContainer.Panel2.Controls.Add(this.SalesGroupBox);
			this.VerticalSplitContainer.Panel2.Controls.Add(this.DetailsGroupBox);
			this.VerticalSplitContainer.Size = new System.Drawing.Size(542, 416);
			this.VerticalSplitContainer.SplitterDistance = 181;
			this.VerticalSplitContainer.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 416);
			this.Controls.Add(this.VerticalSplitContainer);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Using SplitContainer";
			this.DetailsGroupBox.ResumeLayout(false);
			this.DetailsGroupBox.PerformLayout();
			this.SalesGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).EndInit();
			this.VerticalSplitContainer.Panel1.ResumeLayout(false);
			this.VerticalSplitContainer.Panel2.ResumeLayout(false);
			this.VerticalSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TreeView SalesTreeView;
        private System.Windows.Forms.GroupBox DetailsGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox YTDSalesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EmployeeTextBox;
        private System.Windows.Forms.GroupBox SalesGroupBox;
		private System.Windows.Forms.DataGridView SalesDataGridView;
		private System.Windows.Forms.SplitContainer VerticalSplitContainer;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

    }
}

