namespace NetworkSample
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
			this.label1 = new System.Windows.Forms.Label();
			this.DoPing = new System.Windows.Forms.Button();
			this.doPingAsynch = new System.Windows.Forms.Button();
			this.infoTree = new System.Windows.Forms.TreeView();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pingIPAddress = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ShowInterfaceDetails = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Network Interface List";
			// 
			// DoPing
			// 
			this.DoPing.Location = new System.Drawing.Point(74, 74);
			this.DoPing.Name = "DoPing";
			this.DoPing.Size = new System.Drawing.Size(134, 25);
			this.DoPing.TabIndex = 3;
			this.DoPing.Text = "Ping Synch";
			this.DoPing.Click += new System.EventHandler(this.DoPing_Click);
			// 
			// doPingAsynch
			// 
			this.doPingAsynch.Location = new System.Drawing.Point(238, 74);
			this.doPingAsynch.Name = "doPingAsynch";
			this.doPingAsynch.Size = new System.Drawing.Size(134, 25);
			this.doPingAsynch.TabIndex = 4;
			this.doPingAsynch.Text = "Ping Asynch";
			this.doPingAsynch.Click += new System.EventHandler(this.doPingAsynch_Click);
			// 
			// infoTree
			// 
			this.infoTree.Location = new System.Drawing.Point(16, 38);
			this.infoTree.Name = "infoTree";
			this.infoTree.ShowNodeToolTips = true;
			this.infoTree.Size = new System.Drawing.Size(388, 227);
			this.infoTree.TabIndex = 5;
			this.infoTree.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.infoTree_NodeMouseHover);
			this.infoTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.infoTree_AfterSelect);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pingIPAddress);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.DoPing);
			this.groupBox1.Controls.Add(this.doPingAsynch);
			this.groupBox1.Location = new System.Drawing.Point(16, 307);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(388, 116);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ping";
			// 
			// pingIPAddress
			// 
			this.pingIPAddress.Location = new System.Drawing.Point(74, 29);
			this.pingIPAddress.Name = "pingIPAddress";
			this.pingIPAddress.Size = new System.Drawing.Size(298, 22);
			this.pingIPAddress.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 14);
			this.label2.TabIndex = 5;
			this.label2.Text = "Address:";
			// 
			// ShowInterfaceDetails
			// 
			this.ShowInterfaceDetails.Location = new System.Drawing.Point(254, 7);
			this.ShowInterfaceDetails.Name = "ShowInterfaceDetails";
			this.ShowInterfaceDetails.Size = new System.Drawing.Size(150, 23);
			this.ShowInterfaceDetails.TabIndex = 10;
			this.ShowInterfaceDetails.Text = "Show Interface Details";
			this.ShowInterfaceDetails.Click += new System.EventHandler(this.ShowInterfaceDetails_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 268);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(247, 14);
			this.label3.TabIndex = 11;
			this.label3.Text = "Hover over a interface to see its description.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 284);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(345, 14);
			this.label4.TabIndex = 12;
			this.label4.Text = "Double-click an interface to see its IP Statistics and Properties.";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(16, 430);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(388, 62);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Network Change";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(215, 14);
			this.label6.TabIndex = 1;
			this.label6.Text = "and NetworkAvailabilityChanged raised.";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 18);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(350, 14);
			this.label5.TabIndex = 0;
			this.label5.Text = "Unplug the network cable to see the NetworkAddressChanged";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 508);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ShowInterfaceDetails);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.infoTree);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Network Sample";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button DoPing;
		private System.Windows.Forms.Button doPingAsynch;
		private System.Windows.Forms.TreeView infoTree;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox pingIPAddress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button ShowInterfaceDetails;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
	}
}

