using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Forms.Reports.View
{
	#region Progress
	public class Progress : System.Windows.Forms.Form
	{
		#region class variables
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.ProgressBar progressBar1;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public Progress()
		{
			InitializeComponent();
		}
		#endregion

		#region destructor
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
		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			this.label1.Location = new System.Drawing.Point(88, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Generating...";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(16, 48);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(264, 16);
			this.progressBar1.TabIndex = 1;
			// 
			// Progress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 78);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.progressBar1,
																		  this.label1});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Progress";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Progress";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Transparent;
			this.ResumeLayout(false);

		}
		#endregion

	}
	#endregion
}
