using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CodeRunner
{
	/// <summary>
	/// Summary description for GoToLevel.
	/// </summary>
	public class GoToLevel : System.Windows.Forms.Form
	{
		private int m_nLevel;
		
		public int LevelNum
		{
			get { return m_nLevel; }
			set { m_nLevel = value; }
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.NumericUpDown numLevel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GoToLevel()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private void GoToLevel_Load(object sender, System.EventArgs e)
		{
			numLevel.Maximum = Game.Level.GetLevelCount();
			numLevel.Value = m_nLevel;
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

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			m_nLevel = 0;
			this.Close();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			m_nLevel = Decimal.ToInt32( numLevel.Value );
			this.Close();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.numLevel = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
			this.SuspendLayout();
			// 
			// numLevel
			// 
			this.numLevel.Location = new System.Drawing.Point(136, 24);
			this.numLevel.Maximum = new System.Decimal(new int[] {
																	 150,
																	 0,
																	 0,
																	 0});
			this.numLevel.Name = "numLevel";
			this.numLevel.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Go to Level:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(168, 80);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 2;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(248, 80);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// GoToLevel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 117);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdCancel,
																		  this.cmdOK,
																		  this.label1,
																		  this.numLevel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GoToLevel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Go To Level";
			this.Load += new System.EventHandler(this.GoToLevel_Load);
			((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

	}
}
