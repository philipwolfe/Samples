namespace MdlView
{
	using System;
	using System.IO;
	using System.Drawing;
	using System.Collections;
	using System.ComponentModel;
	using System.WinForms;
	using System.Data;
	using System.Runtime.InteropServices;
	using Microsoft.Win32.Interop;
	using DxVBLib;

	/// <summary>
	/// Main form that exposes the Winform 'window' that contains the toolbar and surface panel
	/// </summary>
	/// <remarks>
	/// The frames per second up down control is a little misleading.  If mdlview can render 
	/// the selected # of frames per second then it will, otherwise it renders as many
	/// as it can.
	/// </remarks>
	public class MainFrm : System.WinForms.Form
	{
	    /// <summary> 
	    /// Variables used in the form
	    /// </summary>
	    private System.ComponentModel.Container components;
		private System.WinForms.MainMenu mainMenu;
		private System.WinForms.MenuItem fileMenuItem;
		private System.WinForms.MenuItem openMenuItem;
		private System.WinForms.MenuItem exitMenuItem;
		private System.WinForms.MenuItem viewMenuItem;
		private System.WinForms.MenuItem wireframeMenuItem;
		private System.WinForms.MenuItem mappedMenuItem;
		private System.WinForms.MenuItem helpMenuItem;
		private System.WinForms.MenuItem aboutMenuItem;
		private System.WinForms.Button openBtn;
		private System.WinForms.Button exitBtn;
		private System.WinForms.Button playBtn;
		private System.WinForms.Button stopBtn;
		private System.WinForms.RadioButton blackBackgroundRadio;
		private System.WinForms.RadioButton whiteBackgroundRadio;
		private System.WinForms.ComboBox sequenceList;
		private System.WinForms.Panel toolBarPanel;
		private System.WinForms.StatusBarPanel Panel1;
		private System.WinForms.StatusBar statusBar1;
		private System.WinForms.Timer Timer1;
		
		private System.WinForms.OpenFileDialog openDlg;
		private System.WinForms.NumericUpDown framerateUpDown;
		private System.WinForms.Label sequencesLabel;
		private System.WinForms.Label fpsLabel;
		private System.WinForms.Label backcolorLabel;

		private int	BitsPerPixel;
		private long oldTickCount;
		private double numMilliSecsPerFrame;

		internal DirectX7 DirectXObject;

		internal static SurfacePanel SkinPanel;

		internal static int	ScreenWidth;
		internal static int	ScreenHeight;
		internal static DirectDrawClipper Clipper;
		internal static IDirectDrawSurface7 PrimarySurface;
		internal static IDirectDrawSurface7 BufferedSurface;
		internal static DirectDraw7	DirectDrawObject;
		internal static GrLib16	graphicsObject;
		internal static Model model;
		internal static RenderList WorldList;
		internal static enumRenderingMode renderType;
		internal static bool MdlLoaded;
		internal static int TransX, TransY;
		internal static int	StartX, StartY;
		internal static int	RotateX, RotateY;
		internal static bool AnimationRunning;
		internal static int	currentSkin;
		internal static string AppPath;
		internal static string palPath;
		internal static int backgroundColor;
		internal static short wireframeColor;

		/// <summary>
		/// Constructor for form class, inits variables and controls
		/// </summary>
		public MainFrm()
	    {	
			//
	        // Required for Win Form Designer support
	        //
	        InitializeComponent();
			
			// Creates an open file dialog for selection of models (used from file|open)
			openDlg = new System.WinForms.OpenFileDialog();
			openDlg.Multiselect = false;
			openDlg.CheckFileExists = true;
			openDlg.CheckPathExists = true;
			openDlg.Title = "Open .mdl file";
			openDlg.Filter = "Mdl files|*.md*|All files|*.*";
			openDlg.DefaultExt = ".mdl";
			openDlg.InitialDirectory = Application.StartupPath;

			// Create the 'SurfacePanel' -> the panel that contains the directDraw drawing surface
			SkinPanel = new SurfacePanel();
			SkinPanel.Parent = MainFrm.ActiveForm;
			SkinPanel.Size = new System.Drawing.Size(528, 307);
			SkinPanel.Location = new System.Drawing.Point(0, 0);
			SkinPanel.Dock = System.WinForms.DockStyle.Fill;
			SkinPanel.TabIndex = 0;
			SkinPanel.TabStop = true;
			
			this.Controls.Add(SkinPanel);
			
			// Create the graphics lib, *only* works in 16-bit color modes
			graphicsObject = new GrLib16();

			// Initialize directDraw
			DirectDrawInit();

			// Create the polygon sort list (holds all polygons in 'world')
			WorldList = new RenderList();
			// These values are arbitrary, play around with them to see what looks good
			WorldList.ViewerPos.X = 0;
			WorldList.ViewerPos.Y = -400;
			WorldList.ViewerPos.Z = 0;
			WorldList.ViewerAngle.X = 0;
			WorldList.ViewerAngle.Y = 0;
			WorldList.ViewerAngle.Z = 0;
			WorldList.ViewingDistance = 450;
			
			// Start of rendering wireframe
			renderType = enumRenderingMode.WireFrame;
			wireframeMenuItem.Checked = true;
			AnimationRunning = false;

			// Create a timer that is used when 'playing' sequences
			Timer1 = new System.WinForms.Timer();
			Timer1.Interval = 10;

			// Add mouse handlers
			SkinPanel.MouseDown += new System.WinForms.MouseEventHandler(this.Panel_MouseDown);
			SkinPanel.MouseUp += new System.WinForms.MouseEventHandler(this.Panel_MouseUp);
			SkinPanel.MouseMove += new System.WinForms.MouseEventHandler(this.Panel_MouseMove);
			this.MouseWheel += new System.WinForms.MouseEventHandler(this.MainFrm_MouseWheel);
			Timer1.Tick += new System.EventHandler(this.MainFrm_Timer1);
			
			// Sets the clipping plane on the graphics object so that lines and polygons stay within the region
			graphicsObject.SetClipPlane(0, 0, SkinPanel.Width - 1, SkinPanel.Height - 1);
			// Capture the resize event, so that we can keep our clipping plane correct
			this.Resize += new System.EventHandler(this.MainFrm_Resize);

			AppPath = System.IO.File.GetDirectoryNameFromPath(Application.StartupPath);
			// The external palette used for Quake I models
			palPath = "pal.bin";

			backgroundColor = 0x0;
			unchecked
			{
				wireframeColor = (short)0xFFFF;
			}
			oldTickCount = 0;

			int Angle;
			float Rad;

			Model.Cos_Look = new float[512];
			Model.Sin_Look = new float[512];

			// Set up cosine and sine tables for fast lookup of angles.  (Use 512 degrees for a circle)
			for (Angle = 0; Angle < 512; Angle++)
			{
				Rad = (float)(Math.PI * Angle / 256);
				Model.Cos_Look[Angle] = (float)Math.Cos(Rad);
				Model.Sin_Look[Angle] = (float)Math.Sin(Rad);
			}
		}

		/// <summary>
		/// Opens a file dialog that allows the user to select an model file
		/// </summary>
		private void openFile()
		{
			string[] sequenceItems;
			if (openDlg.ShowDialog() == System.WinForms.DialogResult.OK)
			{
				Timer1.Stop();
				
				System.Drawing.Cursor tempCursor = MainFrm.ActiveForm.Cursor;
				MainFrm.ActiveForm.Cursor = System.Drawing.Cursors.WaitCursor;

				// Create a new Model object (note, one Model object can have multiple .mdls in it)
				model = new Model();

				if(model.LoadFromFile(openDlg.FileName))
				{
					MdlLoaded = true;
								    
					// Version 8 (Quake II models) have 2 associated models, tris.md2 & weapon.md2
					// This tries to do the intelligent thing.  Of course, if the .md2s are named
					// differently, this won't work (no weapon will be associated with the loaded model).
					if (model.Version == 8) 
					{
						if (File.GetFileNameFromPath(openDlg.FileName) == "tris.md2")
							model.LoadFromFile(File.GetDirectoryNameFromPath(openDlg.FileName) + "\\weapon.md2");
						else
							model.LoadFromFile(File.GetDirectoryNameFromPath(openDlg.FileName) + "\\tris.md2");
					}
					
					
					Mesh.HalfScreenX = SkinPanel.Width / 2;
					Mesh.HalfScreenY = SkinPanel.Height / 2;
					// Do some default transformations
					model.Translate(0, 0, 0);
					model.Rotate(0, 0, 0);
					model.Scale = 5;
					
					RotateX = 0;
					RotateY = 0;
					TransX = 0; 
					TransY = 0;
					currentSkin = 0;

					framerateUpDown.Value = model.FramesPerSecond;
					numMilliSecsPerFrame = 1000 / model.FramesPerSecond;

					WorldList.Empty();
					model.AddToList(ref WorldList, renderType, TransX, TransY);

					if (AnimationRunning)
						Timer1.Start();

					// Populate the sequenceList combobox so that we can play the frames
					sequenceItems = model.sequenceList;
					sequenceList.Items.Clear();
					// Add an 'All' sequence, to loop through every frame in every sequence
					sequenceList.Items.Add("All");
					for (int count = 0; count < sequenceItems.Length; count++)
						this.sequenceList.Items.Add(sequenceItems[count]);
					sequenceList.SelectedIndex = 0;
					this.Panel1.Text = openDlg.FileName + " successfully loaded";
					this.Text = "Mdl Viewer [" + openDlg.FileName + "]";
				}
				else
				{
					// Ooops, can't load it.  Could be wrong version.
					AnimationRunning = false;
					MdlLoaded = false;
					this.Panel1.Text = "Unable to load " + openDlg.FileName;
				}
								
				
				MainFrm.ActiveForm.Cursor = tempCursor;
			}
		}

		/// <summary>
		/// Sets rendering type to wireframe
		/// </summary>
		/// <param name="sender">The sender of the event (a menuitem)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void menuWireframe_Click(object sender, System.EventArgs e)
		{
			if (MdlLoaded)
				if (renderType != enumRenderingMode.WireFrame) 
				{
					// Set the render type
					renderType = enumRenderingMode.WireFrame;
					wireframeMenuItem.Checked = true;
					mappedMenuItem.Checked = false;
					WorldList.Empty();
					model.AddToList(ref WorldList, renderType, TransX, TransY);
					// Invalidate the surface so that it knows it needs to be repainted
					SkinPanel.Invalidate(SkinPanel.ClientRectangle);
				}
		}

		/// <summary>
		/// Sets rendering type to texturemapped
		/// </summary>
		/// <param name="sender">The sender of the event (a menuitem)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void menuMapped_Click(object sender, System.EventArgs e)
		{
			if (MdlLoaded)
				if (renderType != enumRenderingMode.TextureMap) 
				{
					// Set the render type
					renderType = enumRenderingMode.TextureMap;
					wireframeMenuItem.Checked = false;
					mappedMenuItem.Checked = true;
					WorldList.Empty();
					model.AddToList(ref WorldList, renderType, TransX, TransY);
					// Invalidate the surface so that it knows it needs to be repainted
					SkinPanel.Invalidate(SkinPanel.ClientRectangle);
				}
		}

		/// <summary>
		/// Closes mdlview
		/// </summary>
		/// <param name="sender">The sender of the event (a menuitem)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Opens a file
		/// </summary>
		/// <param name="sender">The sender of the event (a menuitem)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void menuOpen_Click(object sender, System.EventArgs e)
		{
			openFile();
		}

		/// <summary>
		/// Responds to a change in the list of sequences
		/// </summary>
		/// <param name="Sender">The sender of the event (a combobox)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void sequenceList_Change(object Sender, System.EventArgs e)
		{
			if (sequenceList.SelectedIndex == 0)
				model.FrameSequencePlaying = 0;					
			else
				model.FrameSequencePlaying = sequenceList.SelectedIndex - 1;
			
			// Each frame sequence has it's own framerate (good if you want to do quake III); however,
			// this is hard to expose in the UI.  Therefore, we make it look like all sequences have
			// one framerate.
			model.FramesPerSecond = (int)framerateUpDown.Value;
			numMilliSecsPerFrame = 1000 / model.FramesPerSecond;
			oldTickCount = System.Environment.TickCount;
			
			WorldList.Empty();
			model.AddToList(ref WorldList, renderType, TransX, TransY);
			SkinPanel.Invalidate(SkinPanel.ClientRectangle);
		}

		/// <summary>
		/// Responds to an open button click on the toolbar
		/// </summary>
		/// <param name="sender">The sender of the event (a button)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void openBtn_Click(object sender, System.EventArgs e)
		{
			openFile();
		}

		/// <summary>
		/// Responds to an exit button click on the toolbar
		/// </summary>
		/// <param name="sender">The sender of the event (a button)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void exitBtn_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Responds to a play button click on the toolbar
		/// </summary>
		/// <param name="sender">The sender of the event (a button)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void playBtn_Click(object sender, System.EventArgs e)
		{
			if (MdlLoaded)
			{
				Timer1.Start();
				AnimationRunning = true;
			}
		}

		/// <summary>
		/// Responds to a stop button click on the toolbar
		/// </summary>
		/// <param name="sender">The sender of the event (a button)</param>
		/// <param name="e">The arguments that are passed to the event</param>
		private void stopBtn_Click(object sender, System.EventArgs e)
		{
			if (MdlLoaded)
			{
				Timer1.Stop();
				AnimationRunning = false;
			}
		}

		/// <summary>
		/// Responds to a resize event
		/// </summary>
		/// <param name="sender">The sender of the event (the main form)</param>
		/// <param name="e">The arguemnts that are passed to the event</param>
		/// <remarks>
		/// This event allows us to keep our clip plane (for lines and triangles) in sync with the panel size
		/// </remarks>
		private void MainFrm_Resize(object sender, System.EventArgs e)
		{
			graphicsObject.SetClipPlane(0, 0, SkinPanel.Width - 1, SkinPanel.Height - 1);
		}

		/// <summary>
		/// Responds to the Timer event.
		/// </summary>
		/// <param name="sender"> The sender of the event</param>
		/// <param name="e"> The arguments </param>
		private void MainFrm_Timer1(object sender, System.EventArgs e)
		{
			if (MdlLoaded)
			{
				// Empty the world of current polygons
				WorldList.Empty();

				// We'll advance the frame if we've waited enough milliseconds to keep in synch with
				// the frames per second combobox select (1-40)
				if ((System.Environment.TickCount - oldTickCount) > numMilliSecsPerFrame)
				{
					model.currentFrameInSequence++;

					if ((sequenceList.SelectedIndex == 0) && (model.currentFrameInSequence == 0))
					{
						model.FrameSequencePlaying++;
						model.FramesPerSecond = (int)framerateUpDown.Value;
						numMilliSecsPerFrame = 1000 / model.FramesPerSecond;
					}
					
					oldTickCount = System.Environment.TickCount;

					// Load the current model into the world list.
					model.AddToList(ref WorldList, renderType, TransX, TransY);
		
					SkinPanel.Invalidate(SkinPanel.ClientRectangle);
				}

			}
		}

		/// <summary>
		/// Responds to movement of the mousewheel
		/// </summary>
		/// <param name="sender">The sender of the event (the main form)</param>
		/// <param name="e">The arguments passed to the event</param>
		private void MainFrm_MouseWheel(object sender, System.WinForms.MouseEventArgs e)
		{
			if (MdlLoaded) 
			{
				switch(renderType)
				{
					case enumRenderingMode.TextureMap:
					case enumRenderingMode.WireFrame:
						// Currently UI doesn't allow scaling of separate meshes
						WorldList.Empty();
						if (e.Delta > 0) 
						{
							// There is no particular reason to limit this to 8
							if (model.Scale < 8) 
								model.Scale += 0.1f;

							model.AddToList(ref WorldList, renderType, TransX, TransY);
						}
						else
						{
							if (model.Scale > 1) 
								model.Scale -= 0.1f;
							model.AddToList(ref WorldList, renderType, TransX, TransY);
						}
						SkinPanel.Invalidate(SkinPanel.ClientRectangle);
						break;
				}
			}
		}

		/// <summary>
		/// Responds to a left button click of the mouse on the way down (before the user releases the button)
		/// </summary>
		/// <param name="sender">The sender of the event (the directDraw surface panel)</param>
		/// <param name="e">The mouse arguments passed to the event</param>
		/// <remarks>
		/// If the user clicks the left mouse button we change the cursor to a hand for translation.  If the
		/// user clicks the right mouse button we change the cursor to a cross for rotation.  We don't actually
		/// do the rotation or translation in this function, that comes in the mousemove event.
		/// </remarks>
		private void Panel_MouseDown(object sender, System.WinForms.MouseEventArgs e)
		{
			if (MdlLoaded)
			{
				StartX = e.X;
				StartY = e.Y;
				switch(renderType)
				{
					case enumRenderingMode.TextureMap:
					case enumRenderingMode.WireFrame:
						switch(e.Button)
						{
							// Set up for translation
							case System.WinForms.MouseButtons.Left:
								// During rotation or translation we suspend animation 
								if (AnimationRunning)
									Timer1.Stop();
								SkinPanel.Cursor = System.Drawing.Cursors.Hand;
								break;
							// Set up for rotation
							case System.WinForms.MouseButtons.Right:
								// During rotation or translation we suspend animation 
								if (AnimationRunning)
									Timer1.Stop();
								SkinPanel.Cursor = System.Drawing.Cursors.Cross;
								break;
						}
						break;
				}
			}
		}

		/// <summary>
		/// Responds to the release of a mouse button
		/// </summary>
		/// <param name="sender">The sender of the event (the directDraw surface panel)</param>
		/// <param name="e">The mouse arguments passed to the event</param>
		private void Panel_MouseUp(object sender, System.WinForms.MouseEventArgs e)
		{
			if (MdlLoaded)
			{
				switch(renderType)
				{
					case enumRenderingMode.TextureMap:
					case enumRenderingMode.WireFrame:
						if (SkinPanel.Cursor == System.Drawing.Cursors.Hand)
						{
							// Translation - This is where we make it final (store in global vars)
							TransX += (e.X - StartX);
							TransY += (e.Y - StartY);
						}
						else
							if (SkinPanel.Cursor == System.Drawing.Cursors.Cross)
							{
								// Rotation - This is where we make it final (store in global vars)
								RotateX = ((e.X - StartX) + RotateX) & 511;
								RotateY = ((e.Y - StartY) + RotateY) & 511;
							}
						SkinPanel.Invalidate(SkinPanel.ClientRectangle);
						SkinPanel.Cursor = System.Drawing.Cursors.Default;
						// During rotation or translation we suspend animation, this restarts it
						if (AnimationRunning)
							Timer1.Start();
						break;
				}
			}
		}

		/// <summary>
		/// Responds to the mouse move event
		/// </summary>
		/// <param name="sender">The sender of the event (the directDraw surface panel)</param>
		/// <param name="e">The mouse arguments passed to the event</param>
		private void Panel_MouseMove(object sender, System.WinForms.MouseEventArgs e)
		{
			int TempX, TempY;

			if (MdlLoaded)
			{
				switch(renderType)
				{
					case enumRenderingMode.TextureMap:
					case enumRenderingMode.WireFrame:
						if (SkinPanel.Cursor == System.Drawing.Cursors.Hand)
						{
							// Adjust the Translation Points
							TempX = TransX;
							TempY = TransY;
							TransX += (e.X - StartX);
							TransY += (e.Y - StartY);

							// Adjust the models to be at this temporary position (we don't make it final until they release the mouse button)
							WorldList.Empty();
							model.AddToList(ref WorldList, renderType, TransX, TransY);

							SkinPanel.Invalidate(SkinPanel.ClientRectangle);
							
							TransX = TempX;
							TransY = TempY;
						}
						else
							if (SkinPanel.Cursor == System.Drawing.Cursors.Cross)
							{
								WorldList.Empty();
								// Show what the model would look like if they commit to the changes (release the button)
								model.Rotate((RotateY + (e.Y - StartY)) & 511, 0, (RotateX + (e.X - StartX)) & 511);
								model.AddToList(ref WorldList, renderType, TransX, TransY);
								SkinPanel.Invalidate(SkinPanel.ClientRectangle);
							}
				}
			}
		}

		/// <summary>
		/// Responds to the UpDown change event
		/// </summary>
		/// <param name="sender">The sender of the event (the framerate UpDown control)</param>
		/// <param name="e">The arguments passed to the event</param>
		private void framerateUpDown_Valuechanged(object sender, System.EventArgs e)
		{
			if (MdlLoaded)
			{
				// This property is a little odd in that it will change depending on the current sequence
				model.FramesPerSecond = (int)framerateUpDown.Value;
				// Milliseconds are 1000th of a second
				numMilliSecsPerFrame = 1000 / model.FramesPerSecond;
			}
		}
		
		/// <summary>
	    /// Clean up any resources being used
	    /// </summary>
	    public override void Dispose()
	    {
	        base.Dispose();
	        components.Dispose();
	    }

	    /// <summary>
	    /// Required method for Designer support - do not modify
	    /// the contents of this method with the code editor
	    /// </summary>
	    private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof(MainFrm));
			this.components = new System.ComponentModel.Container ();
			this.fileMenuItem = new System.WinForms.MenuItem ();
			this.helpMenuItem = new System.WinForms.MenuItem ();
			this.backcolorLabel = new System.WinForms.Label ();
			this.mainMenu = new System.WinForms.MainMenu ();
			this.sequenceList = new System.WinForms.ComboBox ();
			this.exitMenuItem = new System.WinForms.MenuItem ();
			this.openBtn = new System.WinForms.Button ();
			this.statusBar1 = new System.WinForms.StatusBar ();
			this.toolBarPanel = new System.WinForms.Panel ();
			this.framerateUpDown = new System.WinForms.NumericUpDown ();
			this.sequencesLabel = new System.WinForms.Label ();
			this.wireframeMenuItem = new System.WinForms.MenuItem ();
			this.Panel1 = new System.WinForms.StatusBarPanel ();
			this.fpsLabel = new System.WinForms.Label ();
			this.openMenuItem = new System.WinForms.MenuItem ();
			this.stopBtn = new System.WinForms.Button ();
			this.whiteBackgroundRadio = new System.WinForms.RadioButton ();
			this.mappedMenuItem = new System.WinForms.MenuItem ();
			this.blackBackgroundRadio = new System.WinForms.RadioButton ();
			this.viewMenuItem = new System.WinForms.MenuItem ();
			this.playBtn = new System.WinForms.Button ();
			this.exitBtn = new System.WinForms.Button ();
			this.aboutMenuItem = new System.WinForms.MenuItem ();
			framerateUpDown.BeginInit ();
			Panel1.BeginInit ();
			//@this.TrayHeight = 90;
			//@this.TrayLargeIcon = false;
			//@this.TrayAutoArrange = true;
			this.Text = "Mdl Viewer";
			this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
			this.WindowState = System.WinForms.FormWindowState.Maximized;
			this.Menu = this.mainMenu;
			this.ClientSize = new System.Drawing.Size (640, 400);
			fileMenuItem.Text = "&File";
			fileMenuItem.Index = 0;
			fileMenuItem.MenuItems.All = new System.WinForms.MenuItem[2] {this.openMenuItem, this.exitMenuItem};
			helpMenuItem.Text = "&Help";
			helpMenuItem.Index = 2;
			helpMenuItem.MenuItems.All = new System.WinForms.MenuItem[1] {this.aboutMenuItem};
			backcolorLabel.Location = new System.Drawing.Point (408, 8);
			backcolorLabel.Text = "Back color:";
			backcolorLabel.Size = new System.Drawing.Size (64, 15);
			backcolorLabel.Font = new System.Drawing.Font ("Comic Sans MS", 7.5f);
			backcolorLabel.TabIndex = 6;
			//@mainMenu.SetLocation (new System.Drawing.Point (7, 7));
			mainMenu.MenuItems.All = new System.WinForms.MenuItem[3] {this.fileMenuItem, this.viewMenuItem, this.helpMenuItem};
			sequenceList.Location = new System.Drawing.Point (174, 4);
			sequenceList.Size = new System.Drawing.Size (80, 21);
			sequenceList.Style = System.WinForms.ComboBoxStyle.DropDownList;
			sequenceList.TabIndex = 0;
			sequenceList.TabStop = false;
			sequenceList.SelectionChangeCommitted += new System.EventHandler (this.sequenceList_Change);
			exitMenuItem.Text = "E&xit";
			exitMenuItem.Index = 1;
			exitMenuItem.Click += new System.EventHandler (this.menuExit_Click);
			openBtn.Location = new System.Drawing.Point (4, 4);
			openBtn.FlatStyle = System.WinForms.FlatStyle.Flat;
			openBtn.Size = new System.Drawing.Size (23, 22);
			openBtn.TabIndex = 7;
			openBtn.TabStop = false;
			openBtn.Image = (System.Drawing.Image) resources.GetObject ("openBtn.Image");
			openBtn.Click += new System.EventHandler (this.openBtn_Click);
			statusBar1.BackColor = System.Drawing.SystemColors.Control;
			statusBar1.Location = new System.Drawing.Point (0, 384);
			statusBar1.Size = new System.Drawing.Size (640, 16);
			statusBar1.TabIndex = 12;
			statusBar1.Font = new System.Drawing.Font ("Comic Sans MS", 8);
			statusBar1.ShowPanels = true;
			statusBar1.Panels.All = new System.WinForms.StatusBarPanel[1] {this.Panel1};
			toolBarPanel.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
			toolBarPanel.Dock = System.WinForms.DockStyle.Top;
			toolBarPanel.Size = new System.Drawing.Size (640, 28);
			toolBarPanel.TabIndex = 11;
			framerateUpDown.Value = new decimal (1);
			framerateUpDown.Location = new System.Drawing.Point (330, 4);
			framerateUpDown.ReadOnly = true;
			framerateUpDown.Maximum = new decimal (40);
			framerateUpDown.TextAlign = System.WinForms.HorizontalAlignment.Center;
			framerateUpDown.Size = new System.Drawing.Size (64, 21);
			framerateUpDown.Minimum = new decimal (1);
			framerateUpDown.Font = new System.Drawing.Font ("Comic Sans MS", 7.5f);
			framerateUpDown.TabStop = false;
			framerateUpDown.TabIndex = 2;
			framerateUpDown.ValueChanged += new System.EventHandler (this.framerateUpDown_Valuechanged);
			sequencesLabel.Location = new System.Drawing.Point (118, 8);
			sequencesLabel.Text = "Sequences:";
			sequencesLabel.Size = new System.Drawing.Size (58, 15);
			sequencesLabel.Font = new System.Drawing.Font ("Comic Sans MS", 7.5f);
			sequencesLabel.TabIndex = 1;
			wireframeMenuItem.Text = "&Wireframe";
			wireframeMenuItem.Index = 1;
			wireframeMenuItem.Click += new System.EventHandler (this.menuWireframe_Click);
			//@Panel1.SetLocation (new System.Drawing.Point (98, 7));
			Panel1.Text = "WAITING FOR .MDL TO BE OPENED";
			Panel1.ToolTipText = "Displays status of viewer";
			Panel1.Width = 624;
			Panel1.AutoSize = System.WinForms.StatusBarPanelAutoSize.Spring;
			fpsLabel.Location = new System.Drawing.Point (268, 8);
			fpsLabel.Text = "Frame rate:";
			fpsLabel.Size = new System.Drawing.Size (64, 15);
			fpsLabel.Font = new System.Drawing.Font ("Comic Sans MS", 7.5f);
			fpsLabel.TabIndex = 3;
			openMenuItem.Text = "&Open";
			openMenuItem.Index = 0;
			openMenuItem.Click += new System.EventHandler (this.menuOpen_Click);
			stopBtn.Location = new System.Drawing.Point (82, 4);
			stopBtn.FlatStyle = System.WinForms.FlatStyle.Flat;
			stopBtn.Size = new System.Drawing.Size (23, 22);
			stopBtn.TabIndex = 10;
			stopBtn.TabStop = false;
			stopBtn.Image = (System.Drawing.Image) resources.GetObject ("stopBtn.Image");
			stopBtn.Click += new System.EventHandler (this.stopBtn_Click);
			whiteBackgroundRadio.Location = new System.Drawing.Point (521, 4);
			whiteBackgroundRadio.Text = "white";
			whiteBackgroundRadio.Size = new System.Drawing.Size (56, 20);
			whiteBackgroundRadio.ForeColor = System.Drawing.Color.Black;
			whiteBackgroundRadio.Font = new System.Drawing.Font ("Comic Sans MS", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			whiteBackgroundRadio.TabIndex = 5;
			whiteBackgroundRadio.BackColor = System.Drawing.Color.White;
			whiteBackgroundRadio.CheckedChanged += new System.EventHandler (this.whiteBackgroundRadio_CheckedChanged);
			mappedMenuItem.Text = "&Mapped";
			mappedMenuItem.Index = 0;
			mappedMenuItem.Click += new System.EventHandler (this.menuMapped_Click);
			blackBackgroundRadio.Checked = true;
			blackBackgroundRadio.Location = new System.Drawing.Point (465, 4);
			blackBackgroundRadio.Text = "black";
			blackBackgroundRadio.Size = new System.Drawing.Size (56, 20);
			blackBackgroundRadio.ForeColor = System.Drawing.Color.White;
			blackBackgroundRadio.Font = new System.Drawing.Font ("Comic Sans MS", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			blackBackgroundRadio.TabIndex = 4;
			blackBackgroundRadio.TabStop = true;
			blackBackgroundRadio.BackColor = System.Drawing.Color.Black;
			blackBackgroundRadio.CheckedChanged += new System.EventHandler (this.blackBackgroundRadio_CheckedChanged);
			viewMenuItem.Text = "&View";
			viewMenuItem.Index = 1;
			viewMenuItem.MenuItems.All = new System.WinForms.MenuItem[2] {this.mappedMenuItem, this.wireframeMenuItem};
			playBtn.Location = new System.Drawing.Point (56, 4);
			playBtn.FlatStyle = System.WinForms.FlatStyle.Flat;
			playBtn.Size = new System.Drawing.Size (23, 22);
			playBtn.TabIndex = 9;
			playBtn.TabStop = false;
			playBtn.Image = (System.Drawing.Image) resources.GetObject ("playBtn.Image");
			playBtn.Click += new System.EventHandler (this.playBtn_Click);
			exitBtn.Location = new System.Drawing.Point (30, 4);
			exitBtn.FlatStyle = System.WinForms.FlatStyle.Flat;
			exitBtn.Size = new System.Drawing.Size (23, 22);
			exitBtn.TabIndex = 8;
			exitBtn.TabStop = false;
			exitBtn.Image = (System.Drawing.Image) resources.GetObject ("exitBtn.Image");
			exitBtn.Click += new System.EventHandler (this.exitBtn_Click);
			aboutMenuItem.Text = "&About";
			aboutMenuItem.Index = 0;
			this.Controls.Add (this.sequenceList);
			this.Controls.Add (this.sequencesLabel);
			this.Controls.Add (this.framerateUpDown);
			this.Controls.Add (this.fpsLabel);
			this.Controls.Add (this.blackBackgroundRadio);
			this.Controls.Add (this.whiteBackgroundRadio);
			this.Controls.Add (this.backcolorLabel);
			this.Controls.Add (this.openBtn);
			this.Controls.Add (this.exitBtn);
			this.Controls.Add (this.playBtn);
			this.Controls.Add (this.stopBtn);
			this.Controls.Add (this.toolBarPanel);
			this.Controls.Add (this.statusBar1);
			framerateUpDown.EndInit ();
			Panel1.EndInit ();
		}

		/// <summary>
		/// Responds to the white background radio button change event
		/// </summary>
		/// <param name="sender">The sender of the event (the white background radio button)</param>
		/// <param name="e">The arguments passed to the event</param>
		protected void whiteBackgroundRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			// Unchecked allows us to assign a value outside of an int's range to that int (it is stored as it's 
			// signed equivelent).
			unchecked 
			{
				// Make the background white and the wireframe black
				backgroundColor = (int)0xFFFFFFFF; 
				wireframeColor = 0x0;
			}
			if (MdlLoaded)
			{
				WorldList.Empty();
				model.AddToList(ref WorldList, renderType, TransX, TransY);
			}
			SkinPanel.Invalidate(SkinPanel.ClientRectangle);
		}
		
		/// <summary>
		/// Responds to black white background radio button change event
		/// </summary>
		/// <param name="sender">The sender of the event (the black background radio button)</param>
		/// <param name="e">The arguments passed to the event</param>
		protected void blackBackgroundRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			// Unchecked allows us to assign a value outside of an short's range to that short (it is stored as it's 
			// signed equivelent).
			unchecked
			{
				// Make the background black and the wireframe white
				backgroundColor = 0x0;
				wireframeColor = (short)0xFFFF;
			}
			if (MdlLoaded)
			{
				WorldList.Empty();
				model.AddToList(ref WorldList, renderType, TransX, TransY);
			}
			SkinPanel.Invalidate(SkinPanel.ClientRectangle);
		}

		/// <summary>
		/// Initialize the DrawDirect objects and the double buffers
		/// </summary>
		private bool DirectDrawInit() 
		{
			int ScreenDC;

			DirectXObject = new DirectX7();			
			DirectDrawObject = DirectXObject.DirectDrawCreate("");

			DDSURFACEDESC2 surfaceDesc = new DDSURFACEDESC2();

			DirectDrawSurface7 MainBufferTemp;
			DirectDrawSurface7 PrimaryTemp;

			ScreenDC = Windows.CreateIC("Display", null, null, 0);
			BitsPerPixel = Windows.GetDeviceCaps(ScreenDC, win.BITSPIXEL);
			Windows.DeleteDC(ScreenDC);

			// GrLib16 only supports 16-bit color modes.  We fail if the bits per pixels are anything else.
			if (BitsPerPixel != 16)
			{
				MessageBox.Show("Currently not supported, switch color depth to 16-bit (high-color)");
				return false;
			}

			ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
			ScreenWidth = Screen.PrimaryScreen.Bounds.Width;

			// Pass the handle of the surface panel to the Direct Draw Object
			DirectDrawObject.SetCooperativeLevel(SkinPanel.Handle, CONST_DDSCLFLAGS.DDSCL_NORMAL);

			// Create the primary drawing surface
			surfaceDesc.lSize  = System.Runtime.InteropServices.Marshal.SizeOf(surfaceDesc);
			surfaceDesc.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS;
			surfaceDesc.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_PRIMARYSURFACE;

			PrimaryTemp = DirectDrawObject.CreateSurface(ref surfaceDesc);
			PrimarySurface = (IDirectDrawSurface7)PrimaryTemp;

			// Create a clipper for the main surface and apply to primary surface
			Clipper = DirectDrawObject.CreateClipper(0);
			Clipper.SetHWnd(SkinPanel.Handle);
			PrimarySurface.SetClipper(Clipper);

			// Now lets create the background buffer
			surfaceDesc.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS | 
				CONST_DDSURFACEDESCFLAGS.DDSD_HEIGHT | 
				CONST_DDSURFACEDESCFLAGS.DDSD_WIDTH;
			surfaceDesc.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_OFFSCREENPLAIN |
				CONST_DDSURFACECAPSFLAGS.DDSCAPS_SYSTEMMEMORY;
			surfaceDesc.lHeight = ScreenHeight;
			surfaceDesc.lWidth = ScreenWidth;

			MainBufferTemp = DirectDrawObject.CreateSurface(ref surfaceDesc);
			// This cast calls queryinterface on MainBufferTemp to return buffered surface, which is are slightly
			// redefined interface that supports the marshaling between com+ and classic com.
			BufferedSurface = (IDirectDrawSurface7)MainBufferTemp;

			return true;
		}

		/// <summary>
		/// Entry point to application
		/// </summary>
		/// <param name="args">Command line paramaters passed to the application</param>
	    public static void Main(string[] args) 
	    {
	        Application.Run(new MainFrm());
	    }
	}
}