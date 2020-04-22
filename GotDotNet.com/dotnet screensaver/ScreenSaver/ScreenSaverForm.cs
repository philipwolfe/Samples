using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenSaver
{
	public class ScreenSaverForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private Point MouseXY;
		private System.Windows.Forms.Timer timer;
		private Rectangle VisibleRect;
		private System.Windows.Forms.PictureBox pictureBox;
		private Random rand;

		public ScreenSaverForm()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		private void ScreenSaverForm_Load(object sender, System.EventArgs e)
		{
			this.Bounds = Screen.PrimaryScreen.Bounds;
			VisibleRect = new Rectangle(0, 0, Bounds.Width-pictureBox.Width, Bounds.Height-pictureBox.Height);
			Cursor.Hide();
			TopMost = true;
		}

		private void timer_Tick(object sender, System.EventArgs e)
		{
			rand = new Random();
			pictureBox.Location = new Point(rand.Next(VisibleRect.Width), rand.Next(VisibleRect.Height));
		}

		private void OnMouseEvent(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!MouseXY.IsEmpty)
			{
				if (MouseXY != new Point(e.X, e.Y))
					Close();
				if (e.Clicks > 0)
					Close();
			}
			MouseXY = new Point(e.X, e.Y);
		}
		
		private void ScreenSaverForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			Close();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ScreenSaverForm));
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 10000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// pictureBox
			// 
			this.pictureBox.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox.Image")));
			this.pictureBox.Location = new System.Drawing.Point(46, 86);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(200, 100);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ScreenSaverForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ScreenSaverForm";
			this.Text = "ScreenSaver";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenSaverForm_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseEvent);
			this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseEvent);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
