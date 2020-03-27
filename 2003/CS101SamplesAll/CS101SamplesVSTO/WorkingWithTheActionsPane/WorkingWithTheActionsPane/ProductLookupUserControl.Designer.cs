namespace WorkingWithTheActionsPane
{
    partial class ProductLookupUserControl
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.productsListBox = new System.Windows.Forms.ListBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adventureWorks_DataDataSet = new WorkingWithTheActionsPane.AdventureWorks_DataDataSet();
            this.insertProductInfoButton = new System.Windows.Forms.Button();
            this.productTableAdapter = new WorkingWithTheActionsPane.AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks_DataDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Info Lookup";
            // 
            // productsListBox
            // 
            this.productsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.productsListBox.DataSource = this.productBindingSource;
            this.productsListBox.DisplayMember = "Name";
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.Location = new System.Drawing.Point(4, 21);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.Size = new System.Drawing.Size(202, 134);
            this.productsListBox.TabIndex = 1;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.adventureWorks_DataDataSet;
            // 
            // adventureWorks_DataDataSet
            // 
            this.adventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet";
            this.adventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // insertProductInfoButton
            // 
            this.insertProductInfoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.insertProductInfoButton.Location = new System.Drawing.Point(47, 165);
            this.insertProductInfoButton.Name = "insertProductInfoButton";
            this.insertProductInfoButton.Size = new System.Drawing.Size(115, 23);
            this.insertProductInfoButton.TabIndex = 2;
            this.insertProductInfoButton.Text = "Insert Product Info";
            this.insertProductInfoButton.UseVisualStyleBackColor = true;
            this.insertProductInfoButton.Click += new System.EventHandler(this.insertProductInfoButton_Click);
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // ProductLookupUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.insertProductInfoButton);
            this.Controls.Add(this.productsListBox);
            this.Controls.Add(this.label1);
            this.Name = "ProductLookupUserControl";
            this.Size = new System.Drawing.Size(209, 195);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks_DataDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox productsListBox;
        private System.Windows.Forms.Button insertProductInfoButton;
        private System.Windows.Forms.BindingSource productBindingSource;
        private WorkingWithTheActionsPane.AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        public AdventureWorks_DataDataSet adventureWorks_DataDataSet;
    }
}
