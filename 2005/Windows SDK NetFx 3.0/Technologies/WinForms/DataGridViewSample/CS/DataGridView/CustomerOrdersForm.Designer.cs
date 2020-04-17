namespace Microsoft.Samples.Windows.Forms.DataGridViewSample
{
    partial class CustomerOrdersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerOrdersForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.processToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipVia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipPostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(618, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // processToolStripButton
            // 
            this.processToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("processToolStripButton.Image")));
            this.processToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.processToolStripButton.Name = "processToolStripButton";
            this.processToolStripButton.Size = new System.Drawing.Size(112, 22);
            this.processToolStripButton.Text = "&Process Orders...";
            this.processToolStripButton.Click += new System.EventHandler(this.processToolStripButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderID,
            this.EmployeeID,
            this.OrderDate,
            this.RequiredDate,
            this.ShippedDate,
            this.ShipVia,
            this.Freight,
            this.ShipName,
            this.ShipAddress,
            this.ShipCity,
            this.ShipRegion,
            this.ShipPostalCode,
            this.ShipCountry});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(618, 251);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValuePushed);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // OrderID
            // 
            this.OrderID.DataPropertyName = "OrderID";
            this.OrderID.HeaderText = "OrderID";
            this.OrderID.Name = "OrderID";
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "OrderDate";
            this.OrderDate.HeaderText = "OrderDate";
            this.OrderDate.Name = "OrderDate";
            // 
            // RequiredDate
            // 
            this.RequiredDate.DataPropertyName = "RequiredDate";
            dataGridViewCellStyle1.NullValue = "[Unknown]";
            this.RequiredDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.RequiredDate.HeaderText = "RequiredDate";
            this.RequiredDate.Name = "RequiredDate";
            // 
            // ShippedDate
            // 
            this.ShippedDate.DataPropertyName = "ShippedDate";
            dataGridViewCellStyle2.NullValue = "[Unknown]";
            this.ShippedDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ShippedDate.HeaderText = "ShippedDate";
            this.ShippedDate.Name = "ShippedDate";
            // 
            // ShipVia
            // 
            this.ShipVia.DataPropertyName = "ShipVia";
            this.ShipVia.HeaderText = "ShipVia";
            this.ShipVia.Name = "ShipVia";
            // 
            // Freight
            // 
            this.Freight.DataPropertyName = "Freight";
            this.Freight.HeaderText = "Freight";
            this.Freight.Name = "Freight";
            // 
            // ShipName
            // 
            this.ShipName.DataPropertyName = "ShipName";
            this.ShipName.HeaderText = "ShipName";
            this.ShipName.Name = "ShipName";
            // 
            // ShipAddress
            // 
            this.ShipAddress.DataPropertyName = "ShipAddress";
            this.ShipAddress.HeaderText = "ShipAddress";
            this.ShipAddress.Name = "ShipAddress";
            // 
            // ShipCity
            // 
            this.ShipCity.DataPropertyName = "ShipCity";
            this.ShipCity.HeaderText = "ShipCity";
            this.ShipCity.Name = "ShipCity";
            // 
            // ShipRegion
            // 
            this.ShipRegion.DataPropertyName = "ShipRegion";
            dataGridViewCellStyle3.NullValue = "[Unknown]";
            this.ShipRegion.DefaultCellStyle = dataGridViewCellStyle3;
            this.ShipRegion.HeaderText = "ShipRegion";
            this.ShipRegion.Name = "ShipRegion";
            // 
            // ShipPostalCode
            // 
            this.ShipPostalCode.DataPropertyName = "ShipPostalCode";
            this.ShipPostalCode.HeaderText = "ShipPostalCode";
            this.ShipPostalCode.Name = "ShipPostalCode";
            // 
            // ShipCountry
            // 
            this.ShipCountry.DataPropertyName = "ShipCountry";
            this.ShipCountry.HeaderText = "ShipCountry";
            this.ShipCountry.Name = "ShipCountry";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.statusStrip1.Location = new System.Drawing.Point(0, 276);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(618, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel1.Text = "Number of orders selected: 0";
            // 
            // CustomerOrdersForm
            // 
            this.ClientSize = new System.Drawing.Size(618, 298);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "CustomerOrdersForm";
            this.Text = "CustomerOrdersForm";
            this.Shown += new System.EventHandler(this.CustomerOrdersForm_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CustomerOrdersForm_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton processToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipVia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipPostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipCountry;

    }
}
