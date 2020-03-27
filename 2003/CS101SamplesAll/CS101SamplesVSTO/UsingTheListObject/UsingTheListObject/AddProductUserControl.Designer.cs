namespace UsingTheListObject
{
    partial class AddProductUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.itemNumberTextBox = new System.Windows.Forms.TextBox();
            this.lookupButton = new System.Windows.Forms.Button();
            this.insertItemButton = new System.Windows.Forms.Button();
            this.itemNameTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item #";
            // 
            // itemNumberTextBox
            // 
            this.itemNumberTextBox.Location = new System.Drawing.Point(48, 0);
            this.itemNumberTextBox.Name = "itemNumberTextBox";
            this.itemNumberTextBox.Size = new System.Drawing.Size(118, 20);
            this.itemNumberTextBox.TabIndex = 1;
            this.itemNumberTextBox.TextChanged += new System.EventHandler(this.itemNumberTextbox_TextChanged);
            // 
            // lookupButton
            // 
            this.lookupButton.Enabled = false;
            this.lookupButton.Location = new System.Drawing.Point(48, 28);
            this.lookupButton.Name = "lookupButton";
            this.lookupButton.Size = new System.Drawing.Size(118, 23);
            this.lookupButton.TabIndex = 2;
            this.lookupButton.Text = "Lookup Item";
            this.lookupButton.UseVisualStyleBackColor = true;
            this.lookupButton.Click += new System.EventHandler(this.lookupButton_Click);
            // 
            // insertItemButton
            // 
            this.insertItemButton.Enabled = false;
            this.insertItemButton.Location = new System.Drawing.Point(48, 83);
            this.insertItemButton.Name = "insertItemButton";
            this.insertItemButton.Size = new System.Drawing.Size(118, 23);
            this.insertItemButton.TabIndex = 4;
            this.insertItemButton.Text = "Insert Item";
            this.insertItemButton.UseVisualStyleBackColor = true;
            this.insertItemButton.Click += new System.EventHandler(this.insertItemButton_Click);
            // 
            // itemNameTextbox
            // 
            this.itemNameTextbox.Location = new System.Drawing.Point(48, 57);
            this.itemNameTextbox.Name = "itemNameTextbox";
            this.itemNameTextbox.ReadOnly = true;
            this.itemNameTextbox.Size = new System.Drawing.Size(118, 20);
            this.itemNameTextbox.TabIndex = 5;
            // 
            // AddProductUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemNameTextbox);
            this.Controls.Add(this.insertItemButton);
            this.Controls.Add(this.lookupButton);
            this.Controls.Add(this.itemNumberTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddProductUserControl";
            this.Size = new System.Drawing.Size(169, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemNumberTextBox;
        private System.Windows.Forms.Button lookupButton;
        private System.Windows.Forms.Button insertItemButton;
        private System.Windows.Forms.TextBox itemNameTextbox;
    }
}
