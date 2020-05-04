namespace teststub
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.signatureInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lastModifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastAuthorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatureCommentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternativeManagedAPIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatureInfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureInfoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastModifiedDataGridViewTextBoxColumn,
            this.signatureDataGridViewTextBoxColumn,
            this.languageDataGridViewTextBoxColumn,
            this.lastAuthorDataGridViewTextBoxColumn,
            this.signatureCommentsDataGridViewTextBoxColumn,
            this.alternativeManagedAPIDataGridViewTextBoxColumn,
            this.summaryDataGridViewTextBoxColumn,
            this.moduleDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.signatureInfoBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(819, 594);
            this.dataGridView1.TabIndex = 0;
            // 
            // signatureInfoBindingSource
            // 
            this.signatureInfoBindingSource.DataSource = typeof(teststub.WebService.PInvokeService.SignatureInfo);
            // 
            // lastModifiedDataGridViewTextBoxColumn
            // 
            this.lastModifiedDataGridViewTextBoxColumn.DataPropertyName = "LastModified";
            this.lastModifiedDataGridViewTextBoxColumn.HeaderText = "LastModified";
            this.lastModifiedDataGridViewTextBoxColumn.Name = "lastModifiedDataGridViewTextBoxColumn";
            this.lastModifiedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // signatureDataGridViewTextBoxColumn
            // 
            this.signatureDataGridViewTextBoxColumn.DataPropertyName = "Signature";
            this.signatureDataGridViewTextBoxColumn.HeaderText = "Signature";
            this.signatureDataGridViewTextBoxColumn.Name = "signatureDataGridViewTextBoxColumn";
            this.signatureDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // languageDataGridViewTextBoxColumn
            // 
            this.languageDataGridViewTextBoxColumn.DataPropertyName = "Language";
            this.languageDataGridViewTextBoxColumn.HeaderText = "Language";
            this.languageDataGridViewTextBoxColumn.Name = "languageDataGridViewTextBoxColumn";
            this.languageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastAuthorDataGridViewTextBoxColumn
            // 
            this.lastAuthorDataGridViewTextBoxColumn.DataPropertyName = "LastAuthor";
            this.lastAuthorDataGridViewTextBoxColumn.HeaderText = "LastAuthor";
            this.lastAuthorDataGridViewTextBoxColumn.Name = "lastAuthorDataGridViewTextBoxColumn";
            this.lastAuthorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // signatureCommentsDataGridViewTextBoxColumn
            // 
            this.signatureCommentsDataGridViewTextBoxColumn.DataPropertyName = "SignatureComments";
            this.signatureCommentsDataGridViewTextBoxColumn.HeaderText = "SignatureComments";
            this.signatureCommentsDataGridViewTextBoxColumn.Name = "signatureCommentsDataGridViewTextBoxColumn";
            this.signatureCommentsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alternativeManagedAPIDataGridViewTextBoxColumn
            // 
            this.alternativeManagedAPIDataGridViewTextBoxColumn.DataPropertyName = "AlternativeManagedAPI";
            this.alternativeManagedAPIDataGridViewTextBoxColumn.HeaderText = "AlternativeManagedAPI";
            this.alternativeManagedAPIDataGridViewTextBoxColumn.Name = "alternativeManagedAPIDataGridViewTextBoxColumn";
            this.alternativeManagedAPIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // summaryDataGridViewTextBoxColumn
            // 
            this.summaryDataGridViewTextBoxColumn.DataPropertyName = "Summary";
            this.summaryDataGridViewTextBoxColumn.HeaderText = "Summary";
            this.summaryDataGridViewTextBoxColumn.Name = "summaryDataGridViewTextBoxColumn";
            this.summaryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // moduleDataGridViewTextBoxColumn
            // 
            this.moduleDataGridViewTextBoxColumn.DataPropertyName = "Module";
            this.moduleDataGridViewTextBoxColumn.HeaderText = "Module";
            this.moduleDataGridViewTextBoxColumn.Name = "moduleDataGridViewTextBoxColumn";
            this.moduleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // signatureInfoBindingSource1
            // 
            this.signatureInfoBindingSource1.DataSource = typeof(teststub.WebService.PInvokeService.SignatureInfo);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 633);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureInfoBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn languageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastAuthorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signatureCommentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternativeManagedAPIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource signatureInfoBindingSource;
        private System.Windows.Forms.BindingSource signatureInfoBindingSource1;
    }
}