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
	public class HostApp : System.Windows.Forms.Form
	{
        private Charting.ChartPanel chartPanel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HostApp()
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
            this.chartPanel1 = new Charting.ChartPanel();
            this.chartPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartPanel1
            // 
            this.chartPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel1.Name = "chartPanel1";
            this.chartPanel1.Size = new System.Drawing.Size(752, 389);
            this.chartPanel1.TabIndex = 0;
            // 
            // HostApp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(9, 20);
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(752, 389);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.chartPanel1});
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.Name = "HostApp";
            this.Text = "Chart Host";
            this.chartPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new HostApp());
		}
	}
}
