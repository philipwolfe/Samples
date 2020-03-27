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
			System.Windows.Forms.TreeNode treeNode91 = new System.Windows.Forms.TreeNode("Bob");
			System.Windows.Forms.TreeNode treeNode92 = new System.Windows.Forms.TreeNode("Sue");
			System.Windows.Forms.TreeNode treeNode93 = new System.Windows.Forms.TreeNode("Northwest", new System.Windows.Forms.TreeNode[] {
            treeNode91,
            treeNode92});
			System.Windows.Forms.TreeNode treeNode94 = new System.Windows.Forms.TreeNode("Frank");
			System.Windows.Forms.TreeNode treeNode95 = new System.Windows.Forms.TreeNode("Southwest", new System.Windows.Forms.TreeNode[] {
            treeNode94});
			System.Windows.Forms.TreeNode treeNode96 = new System.Windows.Forms.TreeNode("Jane");
			System.Windows.Forms.TreeNode treeNode97 = new System.Windows.Forms.TreeNode("Central", new System.Windows.Forms.TreeNode[] {
            treeNode96});
			System.Windows.Forms.TreeNode treeNode98 = new System.Windows.Forms.TreeNode("Mark");
			System.Windows.Forms.TreeNode treeNode99 = new System.Windows.Forms.TreeNode("Bill");
			System.Windows.Forms.TreeNode treeNode100 = new System.Windows.Forms.TreeNode("Francis");
			System.Windows.Forms.TreeNode treeNode101 = new System.Windows.Forms.TreeNode("Northeast", new System.Windows.Forms.TreeNode[] {
            treeNode98,
            treeNode99,
            treeNode100});
			System.Windows.Forms.TreeNode treeNode102 = new System.Windows.Forms.TreeNode("Mary");
			System.Windows.Forms.TreeNode treeNode103 = new System.Windows.Forms.TreeNode("Joe");
			System.Windows.Forms.TreeNode treeNode104 = new System.Windows.Forms.TreeNode("Southeast", new System.Windows.Forms.TreeNode[] {
            treeNode102,
            treeNode103});
			System.Windows.Forms.TreeNode treeNode105 = new System.Windows.Forms.TreeNode("Sales By Region", new System.Windows.Forms.TreeNode[] {
            treeNode93,
            treeNode95,
            treeNode97,
            treeNode101,
            treeNode104});
			this.SalesTreeView = new System.Windows.Forms.TreeView();
			this.DetailsGroupBox = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
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
			treeNode91.Name = "Node6";
			treeNode91.Text = "Bob";
			treeNode92.Name = "Node7";
			treeNode92.Text = "Sue";
			treeNode93.Name = "Node1";
			treeNode93.Text = "Northwest";
			treeNode94.Name = "Node8";
			treeNode94.Text = "Frank";
			treeNode95.Name = "Node2";
			treeNode95.Text = "Southwest";
			treeNode96.Name = "Node10";
			treeNode96.Text = "Jane";
			treeNode97.Name = "Node3";
			treeNode97.Text = "Central";
			treeNode98.Name = "Node11";
			treeNode98.Text = "Mark";
			treeNode99.Name = "Node12";
			treeNode99.Text = "Bill";
			treeNode100.Name = "Node13";
			treeNode100.Text = "Francis";
			treeNode101.Name = "Node4";
			treeNode101.Text = "Northeast";
			treeNode102.Name = "Node14";
			treeNode102.Text = "Mary";
			treeNode103.Name = "Node15";
			treeNode103.Text = "Joe";
			treeNode104.Name = "Node5";
			treeNode104.Text = "Southeast";
			treeNode105.Name = "Node0";
			treeNode105.Text = "Sales By Region";
			this.SalesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode105});
			this.SalesTreeView.Size = new System.Drawing.Size(162, 332);
			this.SalesTreeView.TabIndex = 0;
			// 
			// DetailsGroupBox
			// 
			this.DetailsGroupBox.Controls.Add(this.label3);
			this.DetailsGroupBox.Controls.Add(this.textBox3);
			this.DetailsGroupBox.Controls.Add(this.label2);
			this.DetailsGroupBox.Controls.Add(this.textBox2);
			this.DetailsGroupBox.Controls.Add(this.label1);
			this.DetailsGroupBox.Controls.Add(this.textBox1);
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
			this.label3.Size = new System.Drawing.Size(61, 14);
			this.label3.TabIndex = 5;
			this.label3.Text = "YTD Sales:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(94, 73);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 4;
			this.textBox3.Text = "67000";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 14);
			this.label2.TabIndex = 3;
			this.label2.Text = "Phone:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(94, 46);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "555-1212";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "Employee:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(94, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "Bob";
			// 
			// SalesGroupBox
			// 
			this.SalesGroupBox.Controls.Add(this.SalesDataGridView);
			this.SalesGroupBox.Location = new System.Drawing.Point(13, 148);
			this.SalesGroupBox.Name = "SalesGroupBox";
			this.SalesGroupBox.TabIndex = 2;
			this.SalesGroupBox.TabStop = false;
			this.SalesGroupBox.Text = "Sales";
			// 
			// SalesDataGridView
			// 
			this.SalesDataGridView.Columns.Add(this.dataGridViewTextBoxColumn1);
			this.SalesDataGridView.Columns.Add(this.dataGridViewTextBoxColumn2);
			this.SalesDataGridView.Columns.Add(this.dataGridViewTextBoxColumn3);
			this.SalesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SalesDataGridView.Location = new System.Drawing.Point(3, 16);
			this.SalesDataGridView.Name = "SalesDataGridView";
			this.SalesDataGridView.Size = new System.Drawing.Size(194, 81);
			this.SalesDataGridView.TabIndex = 0;
			this.SalesDataGridView.Text = "dataGridView1";
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Date";
			this.dataGridViewTextBoxColumn1.Name = "Date";
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Customer";
			this.dataGridViewTextBoxColumn2.Name = "Column1";
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn3.Name = "Column2";
			// 
			// VerticalSplitContainer
			// 
			this.VerticalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VerticalSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.VerticalSplitContainer.Name = "VerticalSplitContainer";
			// 
			// Panel1
			// 
			this.VerticalSplitContainer.Panel1.Controls.Add(this.SalesTreeView);
			// 
			// Panel2
			// 
			this.VerticalSplitContainer.Panel2.Controls.Add(this.SalesGroupBox);
			this.VerticalSplitContainer.Panel2.Controls.Add(this.DetailsGroupBox);
			this.VerticalSplitContainer.Size = new System.Drawing.Size(510, 354);
			this.VerticalSplitContainer.SplitterDistance = 170;
			this.VerticalSplitContainer.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 354);
			this.Controls.Add(this.VerticalSplitContainer);
			this.Name = "Form1";
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
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox SalesGroupBox;
        private System.Windows.Forms.DataGridView SalesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.SplitContainer VerticalSplitContainer;

    }
}

