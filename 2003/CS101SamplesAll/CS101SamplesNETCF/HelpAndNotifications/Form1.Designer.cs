namespace HelpAndNotifications
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
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.Label2 = new System.Windows.Forms.Label();
			this.StartTimerButton = new System.Windows.Forms.Button();
			this.TimerIntervalTrackBar = new System.Windows.Forms.TrackBar();
			this.Label1 = new System.Windows.Forms.Label();
			this.SecondsLabel = new System.Windows.Forms.Label();
			this.StatusBar1 = new System.Windows.Forms.StatusBar();
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this.NotificationTimer = new System.Windows.Forms.Timer();
			this.HelpContextMenu = new System.Windows.Forms.ContextMenu();
			this.HelpMenuItem = new System.Windows.Forms.MenuItem();
			this.HelpNotification = new Microsoft.WindowsCE.Forms.Notification();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DescriptionLabel.Location = new System.Drawing.Point(0, 0);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(240, 195);
			this.DescriptionLabel.Text = "This sample demonstrates both Help features and Notification features.";
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Panel1.Controls.Add(this.Label2);
			this.Panel1.Controls.Add(this.StartTimerButton);
			this.Panel1.Controls.Add(this.TimerIntervalTrackBar);
			this.Panel1.Controls.Add(this.Label1);
			this.Panel1.Controls.Add(this.SecondsLabel);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel1.Location = new System.Drawing.Point(0, 195);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(240, 57);
			// 
			// Label2
			// 
			this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label2.Location = new System.Drawing.Point(3, 5);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(172, 20);
			this.Label2.Text = "Notification Timer Interval";
			// 
			// StartTimerButton
			// 
			this.StartTimerButton.Location = new System.Drawing.Point(191, 24);
			this.StartTimerButton.Name = "StartTimerButton";
			this.StartTimerButton.Size = new System.Drawing.Size(46, 20);
			this.StartTimerButton.TabIndex = 2;
			this.StartTimerButton.Text = "Start";
			this.StartTimerButton.Click += new System.EventHandler(this.StartTimerButton_Click);
			// 
			// TimerIntervalTrackBar
			// 
			this.TimerIntervalTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.TimerIntervalTrackBar.ContextMenu = this.HelpContextMenu;
			this.TimerIntervalTrackBar.LargeChange = 1;
			this.TimerIntervalTrackBar.Location = new System.Drawing.Point(43, 23);
			this.TimerIntervalTrackBar.Maximum = 5;
			this.TimerIntervalTrackBar.Minimum = 1;
			this.TimerIntervalTrackBar.Name = "TimerIntervalTrackBar";
			this.TimerIntervalTrackBar.Size = new System.Drawing.Size(111, 21);
			this.TimerIntervalTrackBar.TabIndex = 1;
			this.TimerIntervalTrackBar.Value = 1;
			this.TimerIntervalTrackBar.ValueChanged += new System.EventHandler(this.TimerIntervalTrackBar_ValueChanged);
			// 
			// Label1
			// 
			this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Label1.Location = new System.Drawing.Point(3, 25);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(45, 20);
			this.Label1.Text = "Timer:";
			// 
			// SecondsLabel
			// 
			this.SecondsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.SecondsLabel.Location = new System.Drawing.Point(160, 25);
			this.SecondsLabel.Name = "SecondsLabel";
			this.SecondsLabel.Size = new System.Drawing.Size(25, 20);
			this.SecondsLabel.Text = "1 s";
			// 
			// StatusBar1
			// 
			this.StatusBar1.Location = new System.Drawing.Point(0, 252);
			this.StatusBar1.Name = "StatusBar1";
			this.StatusBar1.Size = new System.Drawing.Size(240, 22);
			this.StatusBar1.Text = "StatusBar1";
			// 
			// ProgressBar1
			// 
			this.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ProgressBar1.Location = new System.Drawing.Point(0, 274);
			this.ProgressBar1.Maximum = 10;
			this.ProgressBar1.Name = "ProgressBar1";
			this.ProgressBar1.Size = new System.Drawing.Size(240, 20);
			// 
			// NotificationTimer
			// 
			this.NotificationTimer.Tick += new System.EventHandler(this.NotificationTimer_Tick);
			// 
			// HelpContextMenu
			// 
			this.HelpContextMenu.MenuItems.Add(this.HelpMenuItem);
			// 
			// HelpMenuItem
			// 
			this.HelpMenuItem.Text = "Help";
			this.HelpMenuItem.Click += new System.EventHandler(this.HelpMenuItem_Click);
			// 
			// HelpNotification
			// 
			this.HelpNotification.Text = "Help";
			this.HelpNotification.BalloonChanged += new Microsoft.WindowsCE.Forms.BalloonChangedEventHandler(this.HelpNotification_BalloonChanged);
			this.HelpNotification.ResponseSubmitted += new Microsoft.WindowsCE.Forms.ResponseSubmittedEventHandler(this.HelpNotification_ResponseSubmitted);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(240, 294);
			this.Controls.Add(this.DescriptionLabel);
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.StatusBar1);
			this.Controls.Add(this.ProgressBar1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form1_HelpRequested);
			this.Panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label DescriptionLabel;
		private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button StartTimerButton;
		private System.Windows.Forms.TrackBar TimerIntervalTrackBar;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label SecondsLabel;
		private System.Windows.Forms.StatusBar StatusBar1;
		private System.Windows.Forms.ProgressBar ProgressBar1;
		private System.Windows.Forms.Timer NotificationTimer;
		private System.Windows.Forms.ContextMenu HelpContextMenu;
		private System.Windows.Forms.MenuItem HelpMenuItem;
		private Microsoft.WindowsCE.Forms.Notification HelpNotification;
	}
}

