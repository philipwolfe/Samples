//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;


namespace Microsoft.Samples.MD3DM
{
	/// <summary>
	/// Main sample class that displays the demo
	/// </summary>
	public class TextSampleForm : Form
	{
		// Fonts for drawing text
		private Microsoft.WindowsMobile.DirectX.Direct3D.Font font1 = null;
		private Microsoft.WindowsMobile.DirectX.Direct3D.Font font2 = null;

		// The d3d device
		private Device device = null;

		// A sprite object for batching text draw calls
        private Sprite textDrawerSprite = null;

		// the name and sizes of the fonts we will be drawing
		private string fontName = "Arial";
		private const int fontSize1 = 15;
		private const int fontSize2 = 11;

        // A big string of text to test with
		private const string bigText = 
            "This is a single call to Font.DrawText() with a large text " +
			"buffer. It shows that Font supports word wrapping. If " +
            "you resize the window, the words will automatically wrap " + 
            "to the next line.  It also supports\r\nhard line breaks. " + 
            "Font also supports Unicode text with correct word wrapping " +
            "for right-to-left languages.";

		// a helper to track and display fps information
		FpsTimerTool fpsTimer;

        /// <summary>
		/// Application constructor.
		/// </summary>
		public TextSampleForm()
		{
			// Set the window text
			this.Text = "Text 3D";

			// Now let's setup our D3D parameters
			PresentParameters presentParams = new PresentParameters();
			presentParams.Windowed = true;
			presentParams.SwapEffect = SwapEffect.Discard;
			presentParams.AutoDepthStencilFormat = DepthFormat.D16;
			presentParams.EnableAutoDepthStencil = true;
			// create the device
			device = new Device(0, DeviceType.Default, this,
                CreateFlags.None, presentParams);	


			// setup objects that can persist through device reset
			InitializeDeviceObjects();
			// attach the the device reset handler
			device.DeviceReset += new EventHandler(RestoreDeviceObjects);
			// setup objects that won't persist through device reset
			RestoreDeviceObjects(device, EventArgs.Empty);
		}

		/// <summary>
		/// Called once per frame, the call is the entry point for 3d
		/// rendering. This function sets up render states, clears the 
		/// viewport, and renders the scene.
		/// </summary>
		public void Render()
		{
            fpsTimer.StartFrame();

			// clears the frame
			device.Clear(ClearFlags.Target, 0, 1.0f, 0);
			try
			{
				// start drawing commands
				device.BeginScene();

				int height = ClientRectangle.Height;
				int width = ClientRectangle.Width;
				System.Drawing.Rectangle rect;
				// Demonstration 1
				// Draw a simple line using DrawText
				// Pass in DrawTextFormat.NoClip so we don't have to calc
                // the bottom/right of the rect
				font1.DrawText(null, 
                    "This is a trivial call to Font.DrawText",
                    new System.Drawing.Rectangle(5,150, 0, 0), 
					DrawTextFormat.NoClip, System.Drawing.Color.Red);

    
				// Demonstration 2
				// Allow multiple draw calls to sort by texture changes
                // by Sprite When drawing 2D text use flags: 
                // SpriteFlags.AlphaBlend | SpriteFlags.SortTexture. 
				textDrawerSprite.Begin(SpriteFlags.AlphaBlend |
                    SpriteFlags.SortTexture);
				rect = new System.Drawing.Rectangle(5, height - 15 * 6, 0, 0);
				font2.DrawText(textDrawerSprite, 
                    "These are multiple calls to Font.DrawText()", 
					rect, DrawTextFormat.NoClip, Color.White);
				rect = new System.Drawing.Rectangle(5, height - 15 * 5, 0, 0);
				font2.DrawText(textDrawerSprite, 
                    "using the same Sprite. The font now caches", 
					rect, DrawTextFormat.NoClip, Color.White);
				rect = new System.Drawing.Rectangle(5, height - 15 * 4, 0, 0);
				font2.DrawText(textDrawerSprite, 
                    "letters on one or more textures. In order", 
					rect, DrawTextFormat.NoClip, Color.White);
				rect = new System.Drawing.Rectangle(5, height - 15 * 3, 0, 0);
				font2.DrawText(textDrawerSprite, 
                    "to sort by texturestate changes on multiple", 
					rect, DrawTextFormat.NoClip, Color.White);
				rect = new System.Drawing.Rectangle(5, height - 15 * 2, 0, 0);
				font2.DrawText(textDrawerSprite, 
                    "calls to DrawText() pass a Sprite and use flags", 
					rect, DrawTextFormat.NoClip, Color.White);
				rect = new System.Drawing.Rectangle(5, height - 15 * 1, 0, 0);
				font2.DrawText(textDrawerSprite, 
                    "SpriteFlags.AlphaBlend | SpriteFlags.SortTexture", 
					rect, DrawTextFormat.NoClip, Color.White);
				
				textDrawerSprite.End();
    
				// Demonstration 3:
				// Word wrapping and unicode text.  
				// Note that not all fonts support dynamic font linking. 
				System.Drawing.Rectangle rc = 
                    new System.Drawing.Rectangle(10, 35, 
					width - 30, height - 10);

				font2.DrawText(null, bigText, rc, 
					DrawTextFormat.Left | DrawTextFormat.WordBreak | 
                    DrawTextFormat.ExpandTabs,
					System.Drawing.Color.CornflowerBlue);

				// write the fps
				fpsTimer.Render();
			}
			finally
			{
				// end the drawing commands and copy to screen
			    device.EndScene();
				device.Present();
				fpsTimer.StopFrame();
			}
		}

		/// <summary>
        /// The device has been created.  Resources that are not lost on
        /// Reset() can be created here.
		/// </summary>
		public void InitializeDeviceObjects()
		{
			// a little different than desktop, on device we make use of a
            // FontDescription structure to hold all the font parameters
			FontDescription fontDesc = new FontDescription();
			fontDesc.CharSet = CharacterSet.Default;
			fontDesc.FaceName = fontName;
			fontDesc.Height = fontSize1;
			fontDesc.OutputPrecision = Precision.Default;
			fontDesc.PitchAndFamily = PitchAndFamily.DefaultPitch | 
                PitchAndFamily.FamilyDoNotCare;
            fontDesc.Quality = FontQuality.Default;
			fontDesc.Weight = FontWeight.Bold;
			fontDesc.Width = 0;

            // initialize our sample fonts
			font1 = new Microsoft.WindowsMobile.DirectX.Direct3D.Font(
                device, fontDesc);

			fontDesc.Height = fontSize2;
			font2 = new Microsoft.WindowsMobile.DirectX.Direct3D.Font(
                device, fontDesc);

			// make the sprite object which can batch and sort multiple
			// DrawText() calls
			textDrawerSprite = new Sprite(device);

			fpsTimer = new FpsTimerTool(device);
		}

		/// <summary>
        /// The device exists, but may have just been Reset().  Resources
        /// and any other device state that persists during
        /// rendering should be set here.  Render states, matrices, textures,
        /// etc., that don't change during rendering can be set once here to
        /// avoid redundant state setting during Render() or FrameMove().
		/// </summary>
		void RestoreDeviceObjects(System.Object sender,
            System.EventArgs e)
		{
			// restore our fonts and sprite object
 			font1.OnResetDevice();
			font2.OnResetDevice();
			textDrawerSprite.OnResetDevice();
		}

        /// <summary>
        /// Called when the window needs to be repainted
        /// </summary>
        /// <param name="e">Unused</param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
             // Render on painting
			this.Render();
             // Render again
			this.Invalidate();
		}

		/// <summary>
		/// Called when the window needs to repaint the background
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(
            System.Windows.Forms.PaintEventArgs e)
		{
		}
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() 
        {
			try
			{
				TextSampleForm d3dApp = new TextSampleForm();
				Application.Run(d3dApp);
			}
            catch(NotSupportedException)
            {
                MessageBox.Show("Your device does not have the needed 3d " + 
                    "support to run this sample");
            }
            catch(DriverUnsupportedException)
            {
                MessageBox.Show("Your device does not have the needed 3d " + 
                    "support to run this sample");
            }
			catch(Exception e)
			{
				MessageBox.Show("The sample has run into an error " +
                    "and needs to close: " + e.Message);
			}
        }
    }
}
