namespace MdlView
{
	using System;
	using System.Windows.Forms;
	using DxVBLib;

	/// <summary>
	/// Panel class that encapsulates a directDraw surface
	/// </summary>
	internal class SurfacePanel: System.Windows.Forms.Panel
	{
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

		/// <summary>
		/// Clears the panel, fills it in with the current background color
		/// </summary>
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


		/// <summary>
		/// Override the OnPaint event and draw to the DirectDraw surfaces.
		/// </summary>
		/// <param name="e"> The paint arguments </param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			DDSURFACEDESC2 DDsd = new DDSURFACEDESC2();
			RECT DestRect = new RECT();
			RECT SkinRect = new RECT();
			System.Drawing.Point P;

			while(MainFrm.BufferedSurface.BltColorFill(ref DestRect, MainFrm.backgroundColor) != 0);

			DDsd.lSize = System.Runtime.InteropServices.Marshal.SizeOf(DDsd);

			MainFrm.BufferedSurface.Lock(ref DestRect, ref DDsd, CONST_DDLOCKFLAGS.DDLOCK_WAIT, 0);

			switch(MainFrm.renderType)
			{
				case enumRenderingMode.TextureMap:
				case enumRenderingMode.WireFrame:
				{
					// The pitch of a directDraw surface can be different then the screen width (for optimization purposes)
					// So we make sure the graphicsObject knows that when it draws it's lines and triangles
					MainFrm.graphicsObject.SetSWidth(DDsd.lPitch);

					// Render the entire world!
					MainFrm.WorldList.DisplayAll(DDsd.lpSurface);

					MainFrm.BufferedSurface.Unlock(ref DestRect);

					P = MainFrm.SkinPanel.PointToScreen(new System.Drawing.Point(0,0));
					DestRect.Left = P.X;
					DestRect.Top = P.Y;
					DestRect.Right = P.X + MainFrm.SkinPanel.Width;
					DestRect.Bottom = P.Y + MainFrm.SkinPanel.Height;
				}
				break;
			}

			SkinRect.Left = 0; 
			SkinRect.Top = 0;
			SkinRect.Right = MainFrm.SkinPanel.Width;
			SkinRect.Bottom = MainFrm.SkinPanel.Height;

			// Blt the buffered surface onto the screen
			while(MainFrm.PrimarySurface.Blt(ref DestRect, MainFrm.BufferedSurface, ref SkinRect, CONST_DDBLTFLAGS.DDBLT_WAIT) != 0);
		}
	}
}
