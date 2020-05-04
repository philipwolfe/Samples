using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Ink;
using Leszynski.SampleInkControls;

namespace InkAPic
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class InkAPic : System.Windows.Forms.Form
	{
		private Microsoft.Ink.InkPicture inkPicture1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button load;
		private System.Windows.Forms.Button create;
		private System.Windows.Forms.Button exit;
		private Bitmap MyImage;
		private System.Windows.Forms.Button buttonsave;
		private Sample.Windows.InkToolBar myinkToolBar;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InkAPic()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			myinkToolBar.SettingsChanged += new System.EventHandler(OnInkToolBar_SettingsChanged);
			myinkToolBar.ModeChanged     += new System.EventHandler(OnInkToolBar_ModeChanged);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(InkAPic));
			this.inkPicture1 = new Microsoft.Ink.InkPicture();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.load = new System.Windows.Forms.Button();
			this.create = new System.Windows.Forms.Button();
			this.buttonsave = new System.Windows.Forms.Button();
			this.exit = new System.Windows.Forms.Button();
			this.myinkToolBar = new Sample.Windows.InkToolBar();
			this.SuspendLayout();
			// 
			// inkPicture1
			// 
			this.inkPicture1.Image = ((System.Drawing.Bitmap)(resources.GetObject("inkPicture1.Image")));
			this.inkPicture1.Location = new System.Drawing.Point(32, 64);
			this.inkPicture1.MarginX = -2147483648;
			this.inkPicture1.MarginY = -2147483648;
			this.inkPicture1.Name = "inkPicture1";
			this.inkPicture1.Size = new System.Drawing.Size(320, 240);
			this.inkPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.inkPicture1.TabIndex = 3;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "Annotated";
			this.saveFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*\"";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF,*.PNG,*.TIF)|*.BMP;*.JPG;*.GIF,*.PNG,*.TIF|All file" +
				"s (*.*)|*.*\"";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(368, 64);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(320, 240);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// load
			// 
			this.load.Location = new System.Drawing.Point(128, 320);
			this.load.Name = "load";
			this.load.Size = new System.Drawing.Size(120, 24);
			this.load.TabIndex = 5;
			this.load.Text = "&Load Picture";
			this.load.Click += new System.EventHandler(this.load_Click);
			// 
			// create
			// 
			this.create.Location = new System.Drawing.Point(288, 320);
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(112, 24);
			this.create.TabIndex = 6;
			this.create.Text = "&Create Picture";
			this.create.Click += new System.EventHandler(this.create_Click);
			// 
			// buttonsave
			// 
			this.buttonsave.Enabled = false;
			this.buttonsave.Location = new System.Drawing.Point(432, 320);
			this.buttonsave.Name = "buttonsave";
			this.buttonsave.Size = new System.Drawing.Size(128, 24);
			this.buttonsave.TabIndex = 7;
			this.buttonsave.Text = "&Save Picture";
			this.buttonsave.Click += new System.EventHandler(this.buttonsave_Click);
			// 
			// exit
			// 
			this.exit.Location = new System.Drawing.Point(608, 320);
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(56, 24);
			this.exit.TabIndex = 8;
			this.exit.Text = "&Exit";
			this.exit.Click += new System.EventHandler(this.exit_Click);
			// 
			// myinkToolBar
			// 
			this.myinkToolBar.ButtonSize = new System.Drawing.Size(31, 30);
			this.myinkToolBar.Name = "myinkToolBar";
			this.myinkToolBar.Size = new System.Drawing.Size(696, 31);
			this.myinkToolBar.TabIndex = 9;
			this.myinkToolBar.SettingsChanged += new System.EventHandler(this.OnInkToolBar_SettingsChanged);
			// 
			// InkAPic
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 366);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.myinkToolBar,
																		  this.exit,
																		  this.buttonsave,
																		  this.create,
																		  this.load,
																		  this.pictureBox1,
																		  this.inkPicture1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "InkAPic";
			this.Text = "Ink-A-Pic";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new InkAPic());
		}
		private void InkAPic_Load(object sender, System.EventArgs e)
		{
			//Use event handlers to initialize
			OnInkToolBar_SettingsChanged(sender, e);
			OnInkToolBar_ModeChanged(sender, e);

		}
			

		private void load_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string filename = openFileDialog1.FileName;
					filename = filename.Trim();
					string compareFilename = filename.ToLower();
					MyImage = new Bitmap(filename);
					inkPicture1.Image = (Image) MyImage ;
	
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error opening the image: \n\n" + ex.ToString());
				}

			}

		}

		private void create_Click(object sender, System.EventArgs e)
		{
				
			// 
			//      dispose of the existing pictureBox image 
			// 
			if(pictureBox1.Image != null) 
			{ 
				pictureBox1.Image.Dispose(); 
			} 

			// 
			//      create a new image 
			// 
			Bitmap image = (Bitmap)inkPicture1.Image.Clone(); 
			// 
			// update the picture box with the new image 
			// 
			pictureBox1.Image = image; 
			// 
			//      Create a new Graphics instance to draw on the new image 
			// 
			using (Graphics g = Graphics.FromImage(image)) 
			{ 
				long sx;
				long sy;
				sx = inkPicture1.Image.Width;
				sy = inkPicture1.Image.Height;
				float sx2 = sx / 320.0F;
				float sy2 = sy / 240.0F;
				inkPicture1.Renderer.Scale(sx2, sy2);
				inkPicture1.Renderer.Draw(g, inkPicture1.Ink.Strokes); 
			} 
			// 
			// enable the saveas button 
			// 
			buttonsave.Enabled = true; 
		}

		private void buttonsave_Click(object sender, System.EventArgs e)
		{
			saveFileDialog1.FileName = "InkAPic";
			if(DialogResult.OK == saveFileDialog1.ShowDialog(this))
			{
				try
				{
					string filename = saveFileDialog1.FileName;
					filename = filename.Trim();
					string compareFilename = filename.ToLower();
					if(compareFilename.EndsWith(".gif"))
					{
						pictureBox1.Image.Save(filename, ImageFormat.Gif);
					}					
					else if(compareFilename.EndsWith(".bmp"))
					{
						pictureBox1.Image.Save(filename, ImageFormat.Bmp);
					}
					else if(compareFilename.EndsWith(".jpg"))
					{
						pictureBox1.Image.Save(filename, ImageFormat.Jpeg);
					}
					else if(compareFilename.EndsWith(".png"))
					{
						pictureBox1.Image.Save(filename, ImageFormat.Png);
					}
					else if(compareFilename.EndsWith(".tif"))
					{
						pictureBox1.Image.Save(filename, ImageFormat.Tiff);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error saving the image: \n\n" + ex.ToString());
				}
			}

		}

		private void exit_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void OnInkToolBar_SettingsChanged(object sender, System.EventArgs e)
		{
			switch (myinkToolBar.Mode)
			{
				case Sample.Windows.InkToolBarMode.Pen:
				case Sample.Windows.InkToolBarMode.Highlighter:
					inkPicture1.DefaultDrawingAttributes = myinkToolBar.InkDrawingAttributes;
					break;
				case Sample.Windows.InkToolBarMode.Eraser:
					inkPicture1.EraserMode  = myinkToolBar.EraserAttributes.Mode;
					inkPicture1.EraserWidth = myinkToolBar.EraserAttributes.Size;
					break;
				default:
					break;
			}
		}
		private void OnInkToolBar_ModeChanged(object source, EventArgs e)
		{
			switch (myinkToolBar.Mode)
			{
				case Sample.Windows.InkToolBarMode.Pen:
				case Sample.Windows.InkToolBarMode.Highlighter:
					inkPicture1.Selection	 = inkPicture1.Ink.CreateStrokes();
					inkPicture1.EditingMode = Microsoft.Ink.InkOverlayEditingMode.Ink;
					break;
				case Sample.Windows.InkToolBarMode.Eraser:
					inkPicture1.Selection	 = inkPicture1.Ink.CreateStrokes();
					inkPicture1.EditingMode = Microsoft.Ink.InkOverlayEditingMode.Delete;
					break;
				case Sample.Windows.InkToolBarMode.Lasso:
					inkPicture1.EditingMode = Microsoft.Ink.InkOverlayEditingMode.Select;
					break;
				default:
					break;					
			}
		}

	}

}


