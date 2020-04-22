namespace SpaceWar
{
	using System;
	using System.Windows.Forms;
	using System.Drawing;
	using DxVBLib;

	/// <summary>
	/// Panel class that encapsulates a directDraw surface
	/// </summary>
	internal class SurfacePanel: System.Windows.Forms.Panel
	{
		Rectangle bounds;
		//Form mainForm;
		DirectDrawSurface7 primarySurface;
		DirectDrawSurface7 bufferedSurface;


		/// <summary>
		/// Constructor for the panel
		/// </summary>
		/// <remarks>
		/// Turns off the styles that would do automatic repaint.  This way we can blt to the surface with 
		/// directDraw with no worries.  Lets us keep the event structure for the panel without the graphics.
		/// </remarks>
		public SurfacePanel()
		{
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.Opaque, true);
		}

		public DirectDrawSurface7 PrimarySurface
		{
			get
			{
				return primarySurface;
			}
			set
			{
				primarySurface = value;
			}
		}

		public DirectDrawSurface7 BufferedSurface
		{
			get
			{
				return bufferedSurface;
			}
			set
			{
				bufferedSurface = value;
			}
		}


		public void SetBounds(Rectangle bounds)
		{
			this.bounds = bounds;
		}

		/// <summary>
		/// Clears the panel, fills it in with the current background color
		/// </summary>
		///

#if fred
		public void clear()
		{
			RECT DestRect = new RECT();
			System.Drawing.Point P;

			P = MainFrm.SkinPanel.PointToScreen(new System.Drawing.Point(0,0));
			DestRect.Left = P.X;
			DestRect.Top = P.Y;
			DestRect.Right = P.X + MainFrm.SkinPanel.Width;
			DestRect.Bottom = P.Y + MainFrm.SkinPanel.Height;

			// Fill the panel with the current background color
			while(MainFrm.PrimarySurface.BltColorFill(ref DestRect, MainFrm.backgroundColor) != 0);
		}
#endif

		public void TestPaint()
		{
			OnPaint(null);
		}

		/// <summary>
		/// Override the OnPaint event and draw to the DirectDraw surfaces.
		/// </summary>
		/// <param name="e"> The paint arguments </param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			DDSURFACEDESC2 DDsd = new DDSURFACEDESC2();
			RECT DestRect = new RECT();
			RECT SkinRect = new RECT();
			//System.Drawing.Point P;

			while(bufferedSurface.BltColorFill(ref DestRect, 0) != 0);

			DDsd.lSize = System.Runtime.InteropServices.Marshal.SizeOf(DDsd);

			bufferedSurface.Lock(ref DestRect, ref DDsd, CONST_DDLOCKFLAGS.DDLOCK_WAIT, 0);

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
	}
}
