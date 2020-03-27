namespace DateTimePickerMonthCalendarCS
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu1;

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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.Label3 = new System.Windows.Forms.Label();
			this.DateTimeLabel = new System.Windows.Forms.Label();
			this.timeDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.Panel3 = new System.Windows.Forms.Panel();
			this.Label6 = new System.Windows.Forms.Label();
			this.FirstDayOfWeekComboBox = new System.Windows.Forms.ComboBox();
			this.ShowTodayCircleCheckBox = new System.Windows.Forms.CheckBox();
			this.ShowTodayCheckBox = new System.Windows.Forms.CheckBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.MonthDateLabel = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.MonthPicker = new System.Windows.Forms.MonthCalendar();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.Panel1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.Panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl1
			// 
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl1.Location = new System.Drawing.Point(0, 0);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(240, 268);
			this.TabControl1.TabIndex = 3;
			// 
			// TabPage1
			// 
			this.TabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.TabPage1.Controls.Add(this.Panel1);
			this.TabPage1.Controls.Add(this.timeDateTimePicker);
			this.TabPage1.Controls.Add(this.Label2);
			this.TabPage1.Controls.Add(this.Label1);
			this.TabPage1.Controls.Add(this.dateDateTimePicker);
			this.TabPage1.Location = new System.Drawing.Point(0, 0);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Size = new System.Drawing.Size(240, 245);
			this.TabPage1.Text = "DateTimePicker";
			// 
			// Panel1
			// 
			this.Panel1.Controls.Add(this.Label3);
			this.Panel1.Controls.Add(this.DateTimeLabel);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel1.Location = new System.Drawing.Point(0, 104);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(240, 141);
			// 
			// Label3
			// 
			this.Label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label3.Location = new System.Drawing.Point(7, 11);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(200, 20);
			this.Label3.Text = "Selected Date and Time is:";
			// 
			// DateTimeLabel
			// 
			this.DateTimeLabel.Location = new System.Drawing.Point(7, 31);
			this.DateTimeLabel.Name = "DateTimeLabel";
			this.DateTimeLabel.Size = new System.Drawing.Size(220, 20);
			this.DateTimeLabel.Text = "Selected Date Time";
			// 
			// timeDateTimePicker
			// 
			this.timeDateTimePicker.CustomFormat = "h:mm tt";
			this.timeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.timeDateTimePicker.Location = new System.Drawing.Point(7, 75);
			this.timeDateTimePicker.Name = "timeDateTimePicker";
			this.timeDateTimePicker.ShowUpDown = true;
			this.timeDateTimePicker.Size = new System.Drawing.Size(220, 22);
			this.timeDateTimePicker.TabIndex = 3;
			this.timeDateTimePicker.TabStop = false;
			this.timeDateTimePicker.ValueChanged += new System.EventHandler(this.TimePicker_ValudChanged);
			// 
			// Label2
			// 
			this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label2.Location = new System.Drawing.Point(7, 52);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(100, 20);
			this.Label2.Text = "Select Time";
			// 
			// Label1
			// 
			this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label1.Location = new System.Drawing.Point(7, 4);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(100, 20);
			this.Label1.Text = "Select Date";
			// 
			// dateDateTimePicker
			// 
			this.dateDateTimePicker.Location = new System.Drawing.Point(7, 27);
			this.dateDateTimePicker.Name = "dateDateTimePicker";
			this.dateDateTimePicker.Size = new System.Drawing.Size(220, 22);
			this.dateDateTimePicker.TabIndex = 0;
			this.dateDateTimePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
			// 
			// TabPage2
			// 
			this.TabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.TabPage2.Controls.Add(this.Panel2);
			this.TabPage2.Controls.Add(this.MonthDateLabel);
			this.TabPage2.Controls.Add(this.Label4);
			this.TabPage2.Controls.Add(this.MonthPicker);
			this.TabPage2.Location = new System.Drawing.Point(0, 0);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Size = new System.Drawing.Size(232, 242);
			this.TabPage2.Text = "MonthCalendar";
			// 
			// Panel2
			// 
			this.Panel2.Controls.Add(this.Panel3);
			this.Panel2.Controls.Add(this.ShowTodayCircleCheckBox);
			this.Panel2.Controls.Add(this.ShowTodayCheckBox);
			this.Panel2.Controls.Add(this.Label5);
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel2.Location = new System.Drawing.Point(163, 0);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(69, 242);
			// 
			// Panel3
			// 
			this.Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Panel3.Controls.Add(this.Label6);
			this.Panel3.Controls.Add(this.FirstDayOfWeekComboBox);
			this.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel3.Location = new System.Drawing.Point(0, 89);
			this.Panel3.Name = "Panel3";
			this.Panel3.Size = new System.Drawing.Size(69, 153);
			// 
			// Label6
			// 
			this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label6.Location = new System.Drawing.Point(0, 0);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(69, 35);
			this.Label6.Text = "First Day of Week";
			// 
			// FirstDayOfWeekComboBox
			// 
			this.FirstDayOfWeekComboBox.Items.Add("SU");
			this.FirstDayOfWeekComboBox.Items.Add("MO");
			this.FirstDayOfWeekComboBox.Items.Add("TU");
			this.FirstDayOfWeekComboBox.Items.Add("WE");
			this.FirstDayOfWeekComboBox.Items.Add("TH");
			this.FirstDayOfWeekComboBox.Items.Add("FR");
			this.FirstDayOfWeekComboBox.Items.Add("SA");
			this.FirstDayOfWeekComboBox.Location = new System.Drawing.Point(0, 38);
			this.FirstDayOfWeekComboBox.Name = "FirstDayOfWeekComboBox";
			this.FirstDayOfWeekComboBox.Size = new System.Drawing.Size(77, 22);
			this.FirstDayOfWeekComboBox.TabIndex = 3;
			this.FirstDayOfWeekComboBox.SelectedIndexChanged += new System.EventHandler(this.FirstDayOfWeekComboBox_SelectedIndexChanged);
			// 
			// ShowTodayCircleCheckBox
			// 
			this.ShowTodayCircleCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.ShowTodayCircleCheckBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.ShowTodayCircleCheckBox.Location = new System.Drawing.Point(0, 65);
			this.ShowTodayCircleCheckBox.Name = "ShowTodayCircleCheckBox";
			this.ShowTodayCircleCheckBox.Size = new System.Drawing.Size(69, 20);
			this.ShowTodayCircleCheckBox.TabIndex = 2;
			this.ShowTodayCircleCheckBox.Text = "Circle";
			this.ShowTodayCircleCheckBox.CheckStateChanged += new System.EventHandler(this.ShowTodayCircleCheckBox_CheckStateChanged);
			// 
			// ShowTodayCheckBox
			// 
			this.ShowTodayCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.ShowTodayCheckBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.ShowTodayCheckBox.Location = new System.Drawing.Point(0, 45);
			this.ShowTodayCheckBox.Name = "ShowTodayCheckBox";
			this.ShowTodayCheckBox.Size = new System.Drawing.Size(69, 20);
			this.ShowTodayCheckBox.TabIndex = 1;
			this.ShowTodayCheckBox.Text = "Show";
			this.ShowTodayCheckBox.CheckStateChanged += new System.EventHandler(this.ShowTodayCheckBox_CheckStateChanged);
			// 
			// Label5
			// 
			this.Label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label5.Location = new System.Drawing.Point(0, 0);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(69, 45);
			this.Label5.Text = "Show Today Settings";
			// 
			// MonthDateLabel
			// 
			this.MonthDateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.MonthDateLabel.Location = new System.Drawing.Point(3, 183);
			this.MonthDateLabel.Name = "MonthDateLabel";
			this.MonthDateLabel.Size = new System.Drawing.Size(154, 62);
			this.MonthDateLabel.Text = "Selected Date Range";
			// 
			// Label4
			// 
			this.Label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
			this.Label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.Label4.Location = new System.Drawing.Point(3, 163);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(160, 20);
			this.Label4.Text = "Selected Date Range:";
			// 
			// MonthPicker
			// 
			this.MonthPicker.Dock = System.Windows.Forms.DockStyle.Left;
			this.MonthPicker.Location = new System.Drawing.Point(0, 0);
			this.MonthPicker.Name = "MonthPicker";
			this.MonthPicker.Size = new System.Drawing.Size(163, 149);
			this.MonthPicker.TabIndex = 0;
			this.MonthPicker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthPicker_DateChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.TabControl1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Sample";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.Panel1.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.Panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl TabControl1;
		private System.Windows.Forms.TabPage TabPage1;
		private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Label DateTimeLabel;
		private System.Windows.Forms.DateTimePicker timeDateTimePicker;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.DateTimePicker dateDateTimePicker;
		private System.Windows.Forms.TabPage TabPage2;
		private System.Windows.Forms.Panel Panel2;
		private System.Windows.Forms.Panel Panel3;
		private System.Windows.Forms.Label Label6;
		private System.Windows.Forms.ComboBox FirstDayOfWeekComboBox;
		private System.Windows.Forms.CheckBox ShowTodayCircleCheckBox;
		private System.Windows.Forms.CheckBox ShowTodayCheckBox;
		private System.Windows.Forms.Label Label5;
		private System.Windows.Forms.Label MonthDateLabel;
		private System.Windows.Forms.Label Label4;
		private System.Windows.Forms.MonthCalendar MonthPicker;
	}
}

