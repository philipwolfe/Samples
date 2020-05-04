using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TZ4Net;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for ConverterForm.
	/// </summary>
	public class ConverterForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.DateTimePicker datePicker1;
		private System.Windows.Forms.DateTimePicker timePicker1;
		private System.Windows.Forms.DateTimePicker datePicker2;
		private System.Windows.Forms.DateTimePicker timePicker2;
		private TZ4NetDemo.TimeZonePicker zonePicker1;
		private TZ4NetDemo.TimeZonePicker zonePicker2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConverterForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			datePicker1.Value = DateTime.Now;
			timePicker1.Value = datePicker1.Value;

			zonePicker1.ValueChanged += new EventHandler(zonePicker1_ValueChanged);
			datePicker1.ValueChanged += new EventHandler(datePicker1_ValueChanged);
			timePicker1.ValueChanged += new EventHandler(timePicker1_ValueChanged);
			zonePicker2.ValueChanged += new EventHandler(zonePicker2_ValueChanged);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.datePicker1 = new System.Windows.Forms.DateTimePicker();
			this.timePicker1 = new System.Windows.Forms.DateTimePicker();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.zonePicker1 = new TZ4NetDemo.TimeZonePicker();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.datePicker2 = new System.Windows.Forms.DateTimePicker();
			this.timePicker2 = new System.Windows.Forms.DateTimePicker();
			this.zonePicker2 = new TZ4NetDemo.TimeZonePicker();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// datePicker1
			// 
			this.datePicker1.CustomFormat = "";
			this.datePicker1.Location = new System.Drawing.Point(32, 184);
			this.datePicker1.Name = "datePicker1";
			this.datePicker1.TabIndex = 1;
			this.datePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// timePicker1
			// 
			this.timePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.timePicker1.Location = new System.Drawing.Point(32, 224);
			this.timePicker1.Name = "timePicker1";
			this.timePicker1.ShowUpDown = true;
			this.timePicker1.TabIndex = 2;
			this.timePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// checkBox1
			// 
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(32, 256);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Is in  DST";
			this.checkBox1.ThreeState = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.zonePicker1);
			this.groupBox1.Location = new System.Drawing.Point(16, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 192);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Local Time";
			// 
			// zonePicker1
			// 
			this.zonePicker1.BackColor = System.Drawing.Color.Silver;
			this.zonePicker1.Location = new System.Drawing.Point(16, 32);
			this.zonePicker1.Name = "zonePicker1";
			this.zonePicker1.Size = new System.Drawing.Size(200, 21);
			this.zonePicker1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox2);
			this.groupBox2.Controls.Add(this.datePicker2);
			this.groupBox2.Location = new System.Drawing.Point(264, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 192);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Destintation Time";
			// 
			// checkBox2
			// 
			this.checkBox2.Enabled = false;
			this.checkBox2.Location = new System.Drawing.Point(16, 144);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "Is in  DST";
			this.checkBox2.ThreeState = true;
			// 
			// datePicker2
			// 
			this.datePicker2.Enabled = false;
			this.datePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.datePicker2.Location = new System.Drawing.Point(16, 72);
			this.datePicker2.Name = "datePicker2";
			this.datePicker2.TabIndex = 9;
			this.datePicker2.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// timePicker2
			// 
			this.timePicker2.Enabled = false;
			this.timePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.timePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.timePicker2.Location = new System.Drawing.Point(280, 224);
			this.timePicker2.Name = "timePicker2";
			this.timePicker2.ShowUpDown = true;
			this.timePicker2.TabIndex = 10;
			this.timePicker2.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// zonePicker2
			// 
			this.zonePicker2.BackColor = System.Drawing.Color.Silver;
			this.zonePicker2.Location = new System.Drawing.Point(280, 144);
			this.zonePicker2.Name = "zonePicker2";
			this.zonePicker2.Size = new System.Drawing.Size(200, 21);
			this.zonePicker2.TabIndex = 8;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Location = new System.Drawing.Point(16, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(480, 72);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Note:";
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(24, 24);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(424, 40);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "You could compare the conversion results with the zoneinfo based service availabl" +
				"e at http://www.timezoneconverter.com/cgi-bin/tzc.tzc";
			// 
			// ConverterForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 437);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.zonePicker2);
			this.Controls.Add(this.timePicker2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.timePicker1);
			this.Controls.Add(this.datePicker1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "ConverterForm";
			this.ShowInTaskbar = false;
			this.Text = "ConverterForm";
			this.Load += new System.EventHandler(this.ConverterForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void OnValueChanged(object sender, EventArgs e) 
		{
			ZoneInfo fromZone = new ZoneInfo(zonePicker1.Value);
			ZoneInfo toZone = new ZoneInfo(zonePicker2.Value);
			Text = string.Format("'{0}' to '{1}' time converter", fromZone.Name, toZone.Name);
			DateTime fromDate = datePicker1.Value;
			DateTime fromTime = timePicker1.Value;
			DateTime fromDateTime = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);
			DateTime toDateTime = toZone.ToLocal(fromZone.ToUtc(fromDateTime));
			datePicker2.Value = toDateTime;
			timePicker2.Value = toDateTime;
			checkBox1.Checked = fromZone.InDaylightTime(fromDateTime);
			checkBox2.Checked = toZone.InDaylightTime(toDateTime);
		}

		private void zonePicker1_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(sender, e);
		}

		private void datePicker1_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(sender, e);
		}

		private void timePicker1_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(sender, e);
		}

		private void zonePicker2_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(sender, e);
		}

		private void ConverterForm_Load(object sender, System.EventArgs e)
		{
			OnValueChanged(sender, e);
		}
	}
}
