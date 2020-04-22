using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		Game game = new Game();
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		DirectDraw7	directDrawObject;
		SurfacePanel skinPanel;
		DirectDrawClipper clipper;
		DirectDrawSurface7 primarySurface;
		DirectDrawSurface7 bufferedSurface;
		DirectSound sound;

		//int backgroundColor;
		//internal static enumRenderingMode renderType;

		DirectX7 directXObject;
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//Cursor.Hide();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1;
			this.timer1.Tick += new System.EventHandler(this.TickLoop);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(992, 742);
			this.ControlBox = false;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Move += new System.EventHandler(this.Form1_Move);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);

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

		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			game.KeyboardState.KeyDown(e.KeyCode);
		}

		private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			game.KeyboardState.KeyUp(e.KeyCode);
		}

		private void TickLoop(object sender, System.EventArgs e)
		{
			//game.MainLoop();
			try
			{
				TestPaint();
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc);
			}

			GameKeys gameKeyState = game.KeyboardState.CurrentState;
			if ((gameKeyState & GameKeys.Escape) != 0)
			{
				try
				{
					game.Close();
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception on shutdown: {0}", exc);
				}
				Application.Exit();
			}

			if ((gameKeyState & GameKeys.F1) != 0)
			{
				game.KeyboardState.KeyUp(Keys.F1);
				timer1.Enabled = false;
				SetupMultiplayer();
				timer1.Enabled = true;
			}
		}
		void TestPaint()
		{
			DDSURFACEDESC2 DDsd = new DDSURFACEDESC2();
			RECT DestRect = new RECT();
			RECT SkinRect = new RECT();
			//System.Drawing.Point P;

			while(bufferedSurface.BltColorFill(ref DestRect, 0x000000) != 0);

			DDsd.lSize = System.Runtime.InteropServices.Marshal.SizeOf(DDsd);

			bufferedSurface.Lock(ref DestRect, ref DDsd, CONST_DDLOCKFLAGS.DDLOCK_WAIT, 0);

			game.MainLoop();

			bufferedSurface.Unlock(ref DestRect);
			SkinRect.Left = 0; 
			SkinRect.Top = 0;
			//SkinRect.Right = MainFrm.SkinPanel.Width;
			//SkinRect.Bottom = MainFrm.SkinPanel.Height;

			SkinRect.Right = Screen.PrimaryScreen.Bounds.Width;
			SkinRect.Bottom = Screen.PrimaryScreen.Bounds.Height;

			// Blt the buffered surface onto the screen
			while(primarySurface.Blt(ref DestRect, bufferedSurface, ref SkinRect, CONST_DDBLTFLAGS.DDBLT_WAIT) != 0);
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			game.Initialize(this.DesktopBounds, 
							this.bufferedSurface,
							this.sound);
			if (skinPanel != null)
				skinPanel.SetBounds(this.DesktopBounds);
		}

		private void Form1_Move(object sender, System.EventArgs e)
		{
			game.Initialize(this.DesktopBounds, 
				this.bufferedSurface,
				this.sound);
			if (skinPanel != null)
                skinPanel.SetBounds(this.DesktopBounds);
		}

		private bool DirectDrawInit() 
		{
			directXObject = new DirectX7();			
			directDrawObject = directXObject.DirectDrawCreate("");

			DDSURFACEDESC2 surfaceDesc = new DDSURFACEDESC2();

			DirectDrawSurface7 MainBufferTemp;
			DirectDrawSurface7 PrimaryTemp;

			//BitsPerPixel = Windows.GetBitsPerPixel();
			//ScreenDC = Windows.CreateIC("Display", null, null, 0);
			//BitsPerPixel = Windows.GetDeviceCaps(ScreenDC, win.BITSPIXEL);
			//Windows.DeleteDC(ScreenDC);

			int	ScreenWidth;
			int	ScreenHeight;
			ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
			ScreenWidth = Screen.PrimaryScreen.Bounds.Width;

			// Pass the handle of the surface panel to the Direct Draw Object
			directDrawObject.SetCooperativeLevel((int) skinPanel.Handle, CONST_DDSCLFLAGS.DDSCL_NORMAL);

			// Create the primary drawing surface
			surfaceDesc.lSize  = System.Runtime.InteropServices.Marshal.SizeOf(surfaceDesc);
			surfaceDesc.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_PRIMARYSURFACE;
			surfaceDesc.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS;

			PrimaryTemp = directDrawObject.CreateSurface(ref surfaceDesc);
			primarySurface = (DirectDrawSurface7) PrimaryTemp;

			// Create a clipper for the main surface and apply to primary surface
			clipper = directDrawObject.CreateClipper(0);
			clipper.SetHWnd((int) skinPanel.Handle);
			primarySurface.SetClipper(clipper);

			// Now lets create the background buffer
			surfaceDesc.lFlags = CONST_DDSURFACEDESCFLAGS.DDSD_CAPS | 
				CONST_DDSURFACEDESCFLAGS.DDSD_HEIGHT | 
				CONST_DDSURFACEDESCFLAGS.DDSD_WIDTH;
			surfaceDesc.ddsCaps.lCaps = CONST_DDSURFACECAPSFLAGS.DDSCAPS_OFFSCREENPLAIN |
				CONST_DDSURFACECAPSFLAGS.DDSCAPS_SYSTEMMEMORY;

			//surfaceDesc.lHeight = this.Bounds.Height;
			//rfaceDesc.lWidth = this.Bounds.Width;
			surfaceDesc.lHeight = ScreenHeight;
			surfaceDesc.lWidth = ScreenWidth;

			MainBufferTemp = directDrawObject.CreateSurface(ref surfaceDesc);
			// This cast calls queryinterface on MainBufferTemp to return buffered surface, which is are slightly
			// redefined interface that supports the marshaling between com+ and classic com.
			bufferedSurface = (DirectDrawSurface7)MainBufferTemp;

			DirectSoundEnum soundEnum = directXObject.GetDSEnum();
			int index = 1;
			sound = directXObject.DirectSoundCreate(soundEnum.GetGuid(index));
			DSCAPS caps = new DSCAPS();
			sound.GetCaps(ref caps);
			sound.SetCooperativeLevel(this.Handle.ToInt32(), CONST_DSSCLFLAGS.DSSCL_PRIORITY);

			return true;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			skinPanel = new SurfacePanel();
			skinPanel.Parent = Form1.ActiveForm;
			//SkinPanel.Size = new System.Drawing.Size(528, 307);
			skinPanel.Size = new System.Drawing.Size(this.ClientRectangle.Width, this.ClientRectangle.Height);
			skinPanel.Location = new System.Drawing.Point(0, 0);
			skinPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			skinPanel.TabIndex = 0;
			skinPanel.TabStop = true;

			this.Controls.Add(skinPanel);

			// Initialize directDraw
			DirectDrawInit();
			skinPanel.PrimarySurface = this.primarySurface;
			skinPanel.BufferedSurface = this.bufferedSurface;

			skinPanel.SetBounds(DesktopBounds);

			game.Initialize(this.DesktopBounds, 
							this.bufferedSurface,
							this.sound);
		}

		public void SetupMultiplayer()
		{
			MultiplayerForm dialog = new MultiplayerForm();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				game.MakeRemoteConnection(dialog.hostName.Text);
			}
			dialog.Close();
		}
	}
}
