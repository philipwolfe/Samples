using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace LineAndCirclePainting
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.PictureBox PictureBox1;
		private System.Windows.Forms.Button Button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		private Bitmap backingBmp;
		
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//TODO: Add any initialization after the InitializeComponent() call
			backingBmp = new Bitmap(200, 200);
			PictureBox1.Image = backingBmp;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Panel1 = new System.Windows.Forms.Panel();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Panel1.Location = new System.Drawing.Point(216, 24);
			this.Panel1.Size = new System.Drawing.Size(152, 128);
			this.Panel1.TabIndex = 0;
			this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
			this.PictureBox1.Location = new System.Drawing.Point(152, 176);
			this.PictureBox1.Size = new System.Drawing.Size(224, 80);
			this.PictureBox1.TabIndex = 1;
			this.PictureBox1.TabStop = false;
			this.Button1.Location = new System.Drawing.Point(8, 192);
			this.Button1.Size = new System.Drawing.Size(88, 32);
			this.Button1.TabIndex = 2;
			this.Button1.Text = "Paint";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Panel1,
																		  this.PictureBox1,
																		  this.Button1});
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Graphics g = Graphics.FromImage(backingBmp);
			Pen p = new Pen(Color.Red, 5);

			try
			{
				//Draw to the bitmap in the PictureBox								
				p.DashStyle = DashStyle.Dot;
				g.FillRectangle(Brushes.BlueViolet, this.ClientRectangle);
				g.DrawString("Hello", this.Font, Brushes.BlanchedAlmond, 10, 10);
				g.DrawLine(p, 30, 10, 50, 50);
				p.Color = Color.Blue;
				p.DashStyle = DashStyle.Solid;
				g.DrawEllipse(p, 50, 30, 60, 30);
				g.FillEllipse(Brushes.CornflowerBlue, 150, 10, 30, 50);

				//Tell PictureBox to redraw
				PictureBox1.Refresh();
			}
			finally
			{
				if (g != null)
				{
					g.Dispose();
				}
				if (p != null)
				{
					p.Dispose();
				}
			}
		}

		private void Panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.Yellow, Panel1.ClientRectangle);
			e.Graphics.DrawString("Hello", this.Font, Brushes.BlueViolet, 10, 10);
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawLine(Pens.Red, 10, 10, 100, 100);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

		}
	}
}
