namespace HardwareButtonScreenOrientation
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.CounterClockwiseButton = new System.Windows.Forms.Button();
            this.ClockwiseButton = new System.Windows.Forms.Button();
            this.InstructionsLabel = new System.Windows.Forms.Label();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.CounterClockwiseButton);
            this.Panel1.Controls.Add(this.ClockwiseButton);
            this.Panel1.Location = new System.Drawing.Point(0, 240);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(240, 24);
            // 
            // CounterClockwiseButton
            // 
            this.CounterClockwiseButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CounterClockwiseButton.Location = new System.Drawing.Point(0, 0);
            this.CounterClockwiseButton.Name = "CounterClockwiseButton";
            this.CounterClockwiseButton.Size = new System.Drawing.Size(120, 24);
            this.CounterClockwiseButton.TabIndex = 0;
            this.CounterClockwiseButton.Text = "CounterClockwise";
            this.CounterClockwiseButton.Click += new System.EventHandler(this.CounterClockwiseButton_Click);
            // 
            // ClockwiseButton
            // 
            this.ClockwiseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClockwiseButton.Location = new System.Drawing.Point(120, 0);
            this.ClockwiseButton.Name = "ClockwiseButton";
            this.ClockwiseButton.Size = new System.Drawing.Size(120, 24);
            this.ClockwiseButton.TabIndex = 2;
            this.ClockwiseButton.Text = "Clockwise";
            this.ClockwiseButton.Click += new System.EventHandler(this.ClockwiseButton_Click);
            // 
            // InstructionsLabel
            // 
            this.InstructionsLabel.Location = new System.Drawing.Point(0, 0);
            this.InstructionsLabel.Name = "InstructionsLabel";
            this.InstructionsLabel.Size = new System.Drawing.Size(240, 148);
            this.InstructionsLabel.Text = "Click the buttons to rotate the screen orientation";
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 272);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 22);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.InstructionsLabel);
            this.Controls.Add(this.StatusBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.Button CounterClockwiseButton;
		private System.Windows.Forms.Button ClockwiseButton;
		private System.Windows.Forms.Label InstructionsLabel;
		private System.Windows.Forms.StatusBar StatusBar1;
	}
}

