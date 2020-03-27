namespace PlayingSounds
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
            this.wavFilesGroupBox = new System.Windows.Forms.GroupBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.loopCheckBox = new System.Windows.Forms.CheckBox();
            this.stopAsyncPlayButton = new System.Windows.Forms.Button();
            this.playAsyncButton = new System.Windows.Forms.Button();
            this.playSyncButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.soundFileNameTextBox = new System.Windows.Forms.TextBox();
            this.systemSoundsGroupBox = new System.Windows.Forms.GroupBox();
            this.playSystemSoundButton = new System.Windows.Forms.Button();
            this.systemSoundsComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.wavFilesGroupBox.SuspendLayout();
            this.systemSoundsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // wavFilesGroupBox
            // 
            this.wavFilesGroupBox.Controls.Add(this.instructionsLabel);
            this.wavFilesGroupBox.Controls.Add(this.loopCheckBox);
            this.wavFilesGroupBox.Controls.Add(this.stopAsyncPlayButton);
            this.wavFilesGroupBox.Controls.Add(this.playAsyncButton);
            this.wavFilesGroupBox.Controls.Add(this.playSyncButton);
            this.wavFilesGroupBox.Controls.Add(this.browseButton);
            this.wavFilesGroupBox.Controls.Add(this.soundFileNameTextBox);
            this.wavFilesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.wavFilesGroupBox.Name = "wavFilesGroupBox";
            this.wavFilesGroupBox.Size = new System.Drawing.Size(518, 153);
            this.wavFilesGroupBox.TabIndex = 8;
            this.wavFilesGroupBox.TabStop = false;
            this.wavFilesGroupBox.Text = "WAV files";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.Location = new System.Drawing.Point(6, 19);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(419, 26);
            this.instructionsLabel.TabIndex = 13;
            this.instructionsLabel.Text = "Enter the path to a sound file or click Browse and navigate to a file.  Then clic" +
                "k one of the Play buttons.";
            // 
            // loopCheckBox
            // 
            this.loopCheckBox.AutoSize = true;
            this.loopCheckBox.Location = new System.Drawing.Point(16, 105);
            this.loopCheckBox.Name = "loopCheckBox";
            this.loopCheckBox.Size = new System.Drawing.Size(112, 17);
            this.loopCheckBox.TabIndex = 11;
            this.loopCheckBox.Text = "Loop (Async Only)";
            // 
            // stopAsyncPlayButton
            // 
            this.stopAsyncPlayButton.AutoSize = true;
            this.stopAsyncPlayButton.Location = new System.Drawing.Point(178, 76);
            this.stopAsyncPlayButton.Name = "stopAsyncPlayButton";
            this.stopAsyncPlayButton.Size = new System.Drawing.Size(68, 23);
            this.stopAsyncPlayButton.TabIndex = 10;
            this.stopAsyncPlayButton.Text = "Stop";
            this.stopAsyncPlayButton.Click += new System.EventHandler(this.stopAsyncPlayButton_Click);
            // 
            // playAsyncButton
            // 
            this.playAsyncButton.Location = new System.Drawing.Point(16, 76);
            this.playAsyncButton.Name = "playAsyncButton";
            this.playAsyncButton.Size = new System.Drawing.Size(75, 23);
            this.playAsyncButton.TabIndex = 9;
            this.playAsyncButton.Text = "Play Async";
            this.playAsyncButton.Click += new System.EventHandler(this.playAsyncButton_Click);
            // 
            // playSyncButton
            // 
            this.playSyncButton.Location = new System.Drawing.Point(97, 76);
            this.playSyncButton.Name = "playSyncButton";
            this.playSyncButton.Size = new System.Drawing.Size(75, 23);
            this.playSyncButton.TabIndex = 8;
            this.playSyncButton.Text = "Play Sync";
            this.playSyncButton.Click += new System.EventHandler(this.playSyncButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(340, 48);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "Browse...";
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // soundFileNameTextBox
            // 
            this.soundFileNameTextBox.Location = new System.Drawing.Point(16, 50);
            this.soundFileNameTextBox.Name = "soundFileNameTextBox";
            this.soundFileNameTextBox.Size = new System.Drawing.Size(318, 20);
            this.soundFileNameTextBox.TabIndex = 6;
            // 
            // systemSoundsGroupBox
            // 
            this.systemSoundsGroupBox.Controls.Add(this.playSystemSoundButton);
            this.systemSoundsGroupBox.Controls.Add(this.systemSoundsComboBox);
            this.systemSoundsGroupBox.Location = new System.Drawing.Point(12, 171);
            this.systemSoundsGroupBox.Name = "systemSoundsGroupBox";
            this.systemSoundsGroupBox.Size = new System.Drawing.Size(518, 47);
            this.systemSoundsGroupBox.TabIndex = 9;
            this.systemSoundsGroupBox.TabStop = false;
            this.systemSoundsGroupBox.Text = "System Sounds";
            // 
            // playSystemSoundButton
            // 
            this.playSystemSoundButton.Location = new System.Drawing.Point(340, 17);
            this.playSystemSoundButton.Name = "playSystemSoundButton";
            this.playSystemSoundButton.Size = new System.Drawing.Size(75, 23);
            this.playSystemSoundButton.TabIndex = 9;
            this.playSystemSoundButton.Text = "Play";
            this.playSystemSoundButton.Click += new System.EventHandler(this.playSystemSoundButton_Click);
            // 
            // systemSoundsComboBox
            // 
            this.systemSoundsComboBox.FormattingEnabled = true;
            this.systemSoundsComboBox.Location = new System.Drawing.Point(16, 19);
            this.systemSoundsComboBox.Name = "systemSoundsComboBox";
            this.systemSoundsComboBox.Size = new System.Drawing.Size(318, 21);
            this.systemSoundsComboBox.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 394);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(542, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 416);
            this.Controls.Add(this.systemSoundsGroupBox);
            this.Controls.Add(this.wavFilesGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playing Sounds";
            this.wavFilesGroupBox.ResumeLayout(false);
            this.wavFilesGroupBox.PerformLayout();
            this.systemSoundsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox wavFilesGroupBox;
		private System.Windows.Forms.CheckBox loopCheckBox;
		private System.Windows.Forms.Button stopAsyncPlayButton;
		private System.Windows.Forms.Button playAsyncButton;
		private System.Windows.Forms.Button playSyncButton;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.TextBox soundFileNameTextBox;
		private System.Windows.Forms.GroupBox systemSoundsGroupBox;
		private System.Windows.Forms.Button playSystemSoundButton;
		private System.Windows.Forms.ComboBox systemSoundsComboBox;
		private System.Windows.Forms.Label instructionsLabel;
		private System.Windows.Forms.StatusStrip statusStrip1;

	}
}

