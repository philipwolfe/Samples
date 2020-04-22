namespace EventViewer
{
	partial class FormEventViewer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEventViewer));
			this.eventLog1 = new System.Diagnostics.EventLog();
			this.dataGridViewEventViewer = new System.Windows.Forms.DataGridView();
			this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Computer = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventViewer)).BeginInit();
			this.SuspendLayout();
			// 
			// eventLog1
			// 
			this.eventLog1.EnableRaisingEvents = true;
			this.eventLog1.Log = "Application";
			this.eventLog1.SynchronizingObject = this;
			this.eventLog1.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.eventLog1_EntryWritten);
			// 
			// dataGridViewEventViewer
			// 
			this.dataGridViewEventViewer.AllowUserToAddRows = false;
			this.dataGridViewEventViewer.AllowUserToDeleteRows = false;
			this.dataGridViewEventViewer.AllowUserToOrderColumns = true;
			this.dataGridViewEventViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewEventViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateTime,
            this.Computer,
            this.Type,
            this.Source,
            this.Message});
			this.dataGridViewEventViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewEventViewer.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewEventViewer.Name = "dataGridViewEventViewer";
			this.dataGridViewEventViewer.ReadOnly = true;
			this.dataGridViewEventViewer.Size = new System.Drawing.Size(994, 277);
			this.dataGridViewEventViewer.TabIndex = 0;
			this.dataGridViewEventViewer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEventViewer_CellContentClick);
			// 
			// DateTime
			// 
			this.DateTime.HeaderText = "Date Time";
			this.DateTime.Name = "DateTime";
			this.DateTime.ReadOnly = true;
			this.DateTime.Width = 125;
			// 
			// Computer
			// 
			this.Computer.FillWeight = 75F;
			this.Computer.HeaderText = "Computer";
			this.Computer.Name = "Computer";
			this.Computer.ReadOnly = true;
			// 
			// Type
			// 
			this.Type.FillWeight = 95F;
			this.Type.HeaderText = "Type";
			this.Type.Name = "Type";
			this.Type.ReadOnly = true;
			this.Type.Width = 65;
			// 
			// Source
			// 
			this.Source.HeaderText = "Source";
			this.Source.Name = "Source";
			this.Source.ReadOnly = true;
			this.Source.Width = 120;
			// 
			// Message
			// 
			this.Message.HeaderText = "Message";
			this.Message.Name = "Message";
			this.Message.ReadOnly = true;
			this.Message.Width = 900;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "Event Viewer";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// FormEventViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(994, 277);
			this.Controls.Add(this.dataGridViewEventViewer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "FormEventViewer";
			this.ShowInTaskbar = false;
			this.Text = "Event Viewer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEventViewer_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventViewer)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Diagnostics.EventLog eventLog1;
		private System.Windows.Forms.DataGridView dataGridViewEventViewer;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn Computer;
		private System.Windows.Forms.DataGridViewTextBoxColumn Type;
		private System.Windows.Forms.DataGridViewTextBoxColumn Source;
		private System.Windows.Forms.DataGridViewTextBoxColumn Message;
	}
}

