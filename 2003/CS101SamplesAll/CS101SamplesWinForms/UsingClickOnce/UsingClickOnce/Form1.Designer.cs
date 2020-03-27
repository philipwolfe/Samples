namespace UsingClickOnce
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
			this.asyncUpdateStatusLabel = new System.Windows.Forms.Label();
			this.stopAsyncUpdateLinkLabel = new System.Windows.Forms.LinkLabel();
			this.updateAsyncLinkLabel = new System.Windows.Forms.LinkLabel();
			this.asyncCheckStatusLabel = new System.Windows.Forms.Label();
			this.stopAsyncCheckLinkLabel = new System.Windows.Forms.LinkLabel();
			this.asyncCheckForUpdatesLinkLabel = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.checkForUpdatesLinkLabel = new System.Windows.Forms.LinkLabel();
			this.versionLabel = new System.Windows.Forms.Label();
			this.timeOfLastCheckLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.updateLinkLabel = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// asyncUpdateStatusLabel
			// 
			this.asyncUpdateStatusLabel.AutoSize = true;
			this.asyncUpdateStatusLabel.Location = new System.Drawing.Point(65, 224);
			this.asyncUpdateStatusLabel.Name = "asyncUpdateStatusLabel";
			this.asyncUpdateStatusLabel.Size = new System.Drawing.Size(33, 13);
			this.asyncUpdateStatusLabel.TabIndex = 17;
			this.asyncUpdateStatusLabel.Text = "Status";
			// 
			// stopAsyncUpdateLinkLabel
			// 
			this.stopAsyncUpdateLinkLabel.AutoSize = true;
			this.stopAsyncUpdateLinkLabel.Location = new System.Drawing.Point(32, 224);
			this.stopAsyncUpdateLinkLabel.Name = "stopAsyncUpdateLinkLabel";
			this.stopAsyncUpdateLinkLabel.Size = new System.Drawing.Size(25, 13);
			this.stopAsyncUpdateLinkLabel.TabIndex = 16;
			this.stopAsyncUpdateLinkLabel.TabStop = true;
			this.stopAsyncUpdateLinkLabel.Text = "Stop";
			this.stopAsyncUpdateLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.stopAsyncUpdateLinkLabel_LinkClicked);
			// 
			// updateAsyncLinkLabel
			// 
			this.updateAsyncLinkLabel.AutoSize = true;
			this.updateAsyncLinkLabel.Location = new System.Drawing.Point(12, 204);
			this.updateAsyncLinkLabel.Name = "updateAsyncLinkLabel";
			this.updateAsyncLinkLabel.Size = new System.Drawing.Size(76, 13);
			this.updateAsyncLinkLabel.TabIndex = 15;
			this.updateAsyncLinkLabel.TabStop = true;
			this.updateAsyncLinkLabel.Text = "Update (Async)";
			this.updateAsyncLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateAsyncLinkLabel_LinkClicked);
			// 
			// asyncCheckStatusLabel
			// 
			this.asyncCheckStatusLabel.AutoSize = true;
			this.asyncCheckStatusLabel.Location = new System.Drawing.Point(65, 130);
			this.asyncCheckStatusLabel.Name = "asyncCheckStatusLabel";
			this.asyncCheckStatusLabel.Size = new System.Drawing.Size(33, 13);
			this.asyncCheckStatusLabel.TabIndex = 13;
			this.asyncCheckStatusLabel.Text = "Status";
			// 
			// stopAsyncCheckLinkLabel
			// 
			this.stopAsyncCheckLinkLabel.AutoSize = true;
			this.stopAsyncCheckLinkLabel.Location = new System.Drawing.Point(32, 130);
			this.stopAsyncCheckLinkLabel.Name = "stopAsyncCheckLinkLabel";
			this.stopAsyncCheckLinkLabel.Size = new System.Drawing.Size(25, 13);
			this.stopAsyncCheckLinkLabel.TabIndex = 12;
			this.stopAsyncCheckLinkLabel.TabStop = true;
			this.stopAsyncCheckLinkLabel.Text = "Stop";
			this.stopAsyncCheckLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.stopAsyncCheckLinkLabel_LinkClicked);
			// 
			// asyncCheckForUpdatesLinkLabel
			// 
			this.asyncCheckForUpdatesLinkLabel.AutoSize = true;
			this.asyncCheckForUpdatesLinkLabel.Location = new System.Drawing.Point(12, 110);
			this.asyncCheckForUpdatesLinkLabel.Name = "asyncCheckForUpdatesLinkLabel";
			this.asyncCheckForUpdatesLinkLabel.Size = new System.Drawing.Size(130, 13);
			this.asyncCheckForUpdatesLinkLabel.TabIndex = 11;
			this.asyncCheckForUpdatesLinkLabel.TabStop = true;
			this.asyncCheckForUpdatesLinkLabel.Text = "Check for Updates (Async)";
			this.asyncCheckForUpdatesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.asyncCheckForUpdatesLinkLabel_LinkClicked);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(168, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(352, 30);
			this.label1.TabIndex = 10;
			this.label1.Text = "Synchronously check for updates.  The application will be frozen during this oper" +
				"ation.";
			// 
			// checkForUpdatesLinkLabel
			// 
			this.checkForUpdatesLinkLabel.AutoSize = true;
			this.checkForUpdatesLinkLabel.Location = new System.Drawing.Point(12, 62);
			this.checkForUpdatesLinkLabel.Name = "checkForUpdatesLinkLabel";
			this.checkForUpdatesLinkLabel.Size = new System.Drawing.Size(92, 13);
			this.checkForUpdatesLinkLabel.TabIndex = 9;
			this.checkForUpdatesLinkLabel.TabStop = true;
			this.checkForUpdatesLinkLabel.Text = "Check for Updates";
			this.checkForUpdatesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.checkForUpdatesLinkLabel_LinkClicked);
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Location = new System.Drawing.Point(13, 13);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(41, 13);
			this.versionLabel.TabIndex = 18;
			this.versionLabel.Text = "Version:";
			// 
			// timeOfLastCheckLabel
			// 
			this.timeOfLastCheckLabel.AutoSize = true;
			this.timeOfLastCheckLabel.Location = new System.Drawing.Point(13, 34);
			this.timeOfLastCheckLabel.Name = "timeOfLastCheckLabel";
			this.timeOfLastCheckLabel.Size = new System.Drawing.Size(125, 13);
			this.timeOfLastCheckLabel.TabIndex = 19;
			this.timeOfLastCheckLabel.Text = "Last checked for update: ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(168, 110);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(352, 34);
			this.label2.TabIndex = 20;
			this.label2.Text = "Check for updates in the background.  Click the Stop button to stop the check.";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(168, 163);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(352, 29);
			this.label3.TabIndex = 21;
			this.label3.Text = "Stop application use and update the application.  Application will require restar" +
				"t to see the new version.";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(168, 204);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(352, 39);
			this.label4.TabIndex = 22;
			this.label4.Text = "Update the application in the background.  Click the Stop button to stop the upda" +
				"te.  Application will require restart to see the new version.";
			// 
			// updateLinkLabel
			// 
			this.updateLinkLabel.AutoSize = true;
			this.updateLinkLabel.Location = new System.Drawing.Point(13, 163);
			this.updateLinkLabel.Name = "updateLinkLabel";
			this.updateLinkLabel.Size = new System.Drawing.Size(63, 13);
			this.updateLinkLabel.TabIndex = 23;
			this.updateLinkLabel.TabStop = true;
			this.updateLinkLabel.Text = "Update Now";
			this.updateLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateLinkLabel_LinkClicked);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 416);
			this.Controls.Add(this.updateLinkLabel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.timeOfLastCheckLabel);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.checkForUpdatesLinkLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.asyncCheckForUpdatesLinkLabel);
			this.Controls.Add(this.stopAsyncCheckLinkLabel);
			this.Controls.Add(this.asyncCheckStatusLabel);
			this.Controls.Add(this.updateAsyncLinkLabel);
			this.Controls.Add(this.stopAsyncUpdateLinkLabel);
			this.Controls.Add(this.asyncUpdateStatusLabel);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Using ClickOnce";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label asyncUpdateStatusLabel;
		private System.Windows.Forms.LinkLabel stopAsyncUpdateLinkLabel;
		private System.Windows.Forms.LinkLabel updateAsyncLinkLabel;
		private System.Windows.Forms.Label asyncCheckStatusLabel;
		private System.Windows.Forms.LinkLabel stopAsyncCheckLinkLabel;
		private System.Windows.Forms.LinkLabel asyncCheckForUpdatesLinkLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel checkForUpdatesLinkLabel;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Label timeOfLastCheckLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel updateLinkLabel;
	}
}

