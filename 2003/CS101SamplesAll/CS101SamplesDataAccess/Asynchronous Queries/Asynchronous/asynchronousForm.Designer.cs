namespace Asynchronous
{
	partial class asynchronousForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(asynchronousForm));
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.elapsedTime2 = new System.Windows.Forms.Label();
            this.queryStatusStatusBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.elapsedTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.messageReturned = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pollingAsynchButton = new System.Windows.Forms.Button();
            this.callBackAsynchButton = new System.Windows.Forms.Button();
            this.population1DataGridView = new System.Windows.Forms.DataGridView();
            this.population2DataGridView = new System.Windows.Forms.DataGridView();
            this.waitAsynchButton = new System.Windows.Forms.Button();
            this.county1CensusLabel = new System.Windows.Forms.Label();
            this.county2CensusLabel = new System.Windows.Forms.Label();
            this.fillTablesButton = new System.Windows.Forms.Button();
            this.descriptionGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.population1DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.population2DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(698, 117);
            this.descriptionGroupBox.TabIndex = 0;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(686, 90);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.elapsedTime2);
            this.groupBox2.Controls.Add(this.queryStatusStatusBar);
            this.groupBox2.Controls.Add(this.statusLabel);
            this.groupBox2.Controls.Add(this.elapsedTime);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.messageReturned);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(138, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 235);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Results";
            // 
            // elapsedTime2
            // 
            this.elapsedTime2.AutoSize = true;
            this.elapsedTime2.Location = new System.Drawing.Point(6, 144);
            this.elapsedTime2.Name = "elapsedTime2";
            this.elapsedTime2.Size = new System.Drawing.Size(0, 13);
            this.elapsedTime2.TabIndex = 6;
            // 
            // queryStatusStatusBar
            // 
            this.queryStatusStatusBar.Enabled = false;
            this.queryStatusStatusBar.Location = new System.Drawing.Point(6, 184);
            this.queryStatusStatusBar.Name = "queryStatusStatusBar";
            this.queryStatusStatusBar.Size = new System.Drawing.Size(100, 23);
            this.queryStatusStatusBar.TabIndex = 5;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Enabled = false;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(6, 166);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(43, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status";
            // 
            // elapsedTime
            // 
            this.elapsedTime.AutoSize = true;
            this.elapsedTime.Location = new System.Drawing.Point(6, 122);
            this.elapsedTime.Name = "elapsedTime";
            this.elapsedTime.Size = new System.Drawing.Size(0, 13);
            this.elapsedTime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Elapsed Time:";
            // 
            // messageReturned
            // 
            this.messageReturned.AutoSize = true;
            this.messageReturned.Location = new System.Drawing.Point(6, 59);
            this.messageReturned.Name = "messageReturned";
            this.messageReturned.Size = new System.Drawing.Size(0, 13);
            this.messageReturned.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message:";
            // 
            // pollingAsynchButton
            // 
            this.pollingAsynchButton.Location = new System.Drawing.Point(26, 211);
            this.pollingAsynchButton.Name = "pollingAsynchButton";
            this.pollingAsynchButton.Size = new System.Drawing.Size(75, 23);
            this.pollingAsynchButton.TabIndex = 2;
            this.pollingAsynchButton.Text = "Polling";
            this.pollingAsynchButton.Click += new System.EventHandler(this.pollingAsynchButton_Click);
            // 
            // callBackAsynchButton
            // 
            this.callBackAsynchButton.Location = new System.Drawing.Point(26, 257);
            this.callBackAsynchButton.Name = "callBackAsynchButton";
            this.callBackAsynchButton.Size = new System.Drawing.Size(75, 23);
            this.callBackAsynchButton.TabIndex = 3;
            this.callBackAsynchButton.Text = "Callback";
            this.callBackAsynchButton.Click += new System.EventHandler(this.callBackAsynchButton_Click);
            // 
            // population1DataGridView
            // 
            this.population1DataGridView.Location = new System.Drawing.Point(321, 176);
            this.population1DataGridView.Name = "population1DataGridView";
            this.population1DataGridView.ReadOnly = true;
            this.population1DataGridView.Size = new System.Drawing.Size(197, 194);
            this.population1DataGridView.TabIndex = 4;
            this.population1DataGridView.Text = "dataGridView1";
            // 
            // population2DataGridView
            // 
            this.population2DataGridView.Location = new System.Drawing.Point(524, 176);
            this.population2DataGridView.Name = "population2DataGridView";
            this.population2DataGridView.ReadOnly = true;
            this.population2DataGridView.Size = new System.Drawing.Size(186, 194);
            this.population2DataGridView.TabIndex = 5;
            this.population2DataGridView.Text = "dataGridView2";
            // 
            // waitAsynchButton
            // 
            this.waitAsynchButton.Location = new System.Drawing.Point(26, 301);
            this.waitAsynchButton.Name = "waitAsynchButton";
            this.waitAsynchButton.Size = new System.Drawing.Size(75, 23);
            this.waitAsynchButton.TabIndex = 0;
            this.waitAsynchButton.Text = "Wait";
            this.waitAsynchButton.Click += new System.EventHandler(this.waitAsynchButton_Click);
            // 
            // county1CensusLabel
            // 
            this.county1CensusLabel.AutoSize = true;
            this.county1CensusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.county1CensusLabel.Location = new System.Drawing.Point(320, 154);
            this.county1CensusLabel.Name = "county1CensusLabel";
            this.county1CensusLabel.Size = new System.Drawing.Size(143, 13);
            this.county1CensusLabel.TabIndex = 6;
            this.county1CensusLabel.Text = "Population in County #1";
            // 
            // county2CensusLabel
            // 
            this.county2CensusLabel.AutoSize = true;
            this.county2CensusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.county2CensusLabel.Location = new System.Drawing.Point(523, 154);
            this.county2CensusLabel.Name = "county2CensusLabel";
            this.county2CensusLabel.Size = new System.Drawing.Size(143, 13);
            this.county2CensusLabel.TabIndex = 7;
            this.county2CensusLabel.Text = "Population in County #2";
            // 
            // fillTablesButton
            // 
            this.fillTablesButton.Location = new System.Drawing.Point(26, 164);
            this.fillTablesButton.Name = "fillTablesButton";
            this.fillTablesButton.Size = new System.Drawing.Size(75, 23);
            this.fillTablesButton.TabIndex = 0;
            this.fillTablesButton.Text = "Fill Tables";
            this.fillTablesButton.Click += new System.EventHandler(this.fillTablesButton_Click);
            // 
            // asynchronousForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 382);
            this.Controls.Add(this.fillTablesButton);
            this.Controls.Add(this.county2CensusLabel);
            this.Controls.Add(this.county1CensusLabel);
            this.Controls.Add(this.waitAsynchButton);
            this.Controls.Add(this.population2DataGridView);
            this.Controls.Add(this.population1DataGridView);
            this.Controls.Add(this.callBackAsynchButton);
            this.Controls.Add(this.pollingAsynchButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.descriptionGroupBox);
            this.Name = "asynchronousForm";
            this.Text = "Asynchronous Example";
            this.descriptionGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.population1DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.population2DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button pollingAsynchButton;
		private System.Windows.Forms.Button callBackAsynchButton;
		private System.Windows.Forms.DataGridView population1DataGridView;
		private System.Windows.Forms.DataGridView population2DataGridView;
		private System.Windows.Forms.Label elapsedTime;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label messageReturned;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button waitAsynchButton;
		private System.Windows.Forms.Label county1CensusLabel;
		private System.Windows.Forms.Label county2CensusLabel;
		private System.Windows.Forms.Button fillTablesButton;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.ProgressBar queryStatusStatusBar;
        private System.Windows.Forms.Label elapsedTime2;
        private System.Windows.Forms.Label descriptionLineLabel;
	}
}

