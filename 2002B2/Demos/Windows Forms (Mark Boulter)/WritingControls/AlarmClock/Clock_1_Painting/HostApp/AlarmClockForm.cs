using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HostApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class AlarmClockForm : System.Windows.Forms.Form
	{
        private MyCompany.Controls.AlarmClock alarmClock1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AlarmClockForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			if (components != null) 
			{
				components.Dispose();
			}
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.alarmClock1 = new MyCompany.Controls.AlarmClock();
            this.SuspendLayout();
            // 
            // alarmClock1
            // 
            this.alarmClock1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.alarmClock1.ForeColor = System.Drawing.Color.Red;
            this.alarmClock1.Location = new System.Drawing.Point(16, 16);
            this.alarmClock1.Name = "alarmClock1";
            this.alarmClock1.Size = new System.Drawing.Size(248, 248);
            this.alarmClock1.TabIndex = 0;
            this.alarmClock1.Text = "alarmClock1";
            this.alarmClock1.DoubleClick += new System.EventHandler(this.alarmClock1_DoubleClick);
            // 
            // AlarmClockForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.alarmClock1});
            this.Name = "AlarmClockForm";
            this.Text = "AlarmClockForm";
            this.DoubleClick += new System.EventHandler(this.AlarmClockForm_DoubleClick);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new AlarmClockForm());
		}

        private void alarmClock1_DoubleClick(object sender, System.EventArgs e) {
            MessageBox.Show("Alarm Double Clicked");
        }

        private void AlarmClockForm_DoubleClick(object sender, System.EventArgs e) {
            MessageBox.Show("Form Double Clicked");
        }
	}
}
