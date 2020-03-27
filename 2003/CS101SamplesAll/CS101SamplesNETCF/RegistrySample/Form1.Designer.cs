namespace RegistrySample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("HKEY_CURRENT_USER");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("SOFTWARE");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("RegistrySample");
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.Label1 = new System.Windows.Forms.Label();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.RegTreeView = new System.Windows.Forms.TreeView();
            this.CreateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(0, 173);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 20);
            this.Label1.Text = "Key";
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Location = new System.Drawing.Point(38, 173);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(202, 21);
            this.KeyTextBox.TabIndex = 13;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(118, 220);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(122, 21);
            this.ValueTextBox.TabIndex = 15;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(0, 220);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(112, 21);
            this.NameTextBox.TabIndex = 14;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(168, 247);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(72, 20);
            this.UpdateButton.TabIndex = 18;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(0, 197);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 19);
            this.Label2.Text = "Name";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(118, 197);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(81, 19);
            this.Label3.Text = "Value";
            // 
            // RegTreeView
            // 
            this.RegTreeView.Dock = System.Windows.Forms.DockStyle.Top;
            this.RegTreeView.Location = new System.Drawing.Point(0, 0);
            this.RegTreeView.Name = "RegTreeView";
            treeNode3.Text = "RegistrySample";
            treeNode2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            treeNode2.Text = "SOFTWARE";
            treeNode1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            treeNode1.Text = "HKEY_CURRENT_USER";
            this.RegTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.RegTreeView.Size = new System.Drawing.Size(240, 165);
            this.RegTreeView.TabIndex = 12;
            this.RegTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RegTreeView_AfterSelect);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(0, 247);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(72, 20);
            this.CreateButton.TabIndex = 16;
            this.CreateButton.Text = "Create";
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(78, 247);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(84, 20);
            this.DeleteButton.TabIndex = 17;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.RegTreeView);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.Label1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox KeyTextBox;
        internal System.Windows.Forms.TextBox ValueTextBox;
        internal System.Windows.Forms.TextBox NameTextBox;
        internal System.Windows.Forms.Button UpdateButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TreeView RegTreeView;
        internal System.Windows.Forms.Button CreateButton;
        internal System.Windows.Forms.Button DeleteButton;
    }
}

