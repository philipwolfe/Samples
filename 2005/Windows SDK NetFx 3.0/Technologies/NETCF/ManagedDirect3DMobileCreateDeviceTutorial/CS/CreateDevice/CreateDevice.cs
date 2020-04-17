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

//----------------------------------------------------------------------------
// File: CreateDevice.cs
//
// Desc: This is the first tutorial for using Direct3D. In this tutorial, all
//       we are doing is creating a Direct3D device and using it to clear the
//       window.
//
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;
using System.Runtime.InteropServices;

namespace Microsoft.Samples.MD3DM
{
    // The main class for this sample
    public class CreateDevice : Form
    {
        // Our global variables for this project
        Device device = null;

        public CreateDevice()
        {
            // Set the caption
            this.Text = "D3D Tutorial 01: CreateDevice";
            this.MinimizeBox = false;
        }
        
        // Prepare the rendering device
        public bool InitializeGraphics()
        {
            try
            {
                // Now let's setup our D3D parameters
                PresentParameters presentParams = new PresentParameters();
                
                // Causes the display to appear in a window rather than
                // full screen
                presentParams.Windowed = true;

                // When a new frame is swapped to the front buffer
                // the old frame will be discarded
                presentParams.SwapEffect = SwapEffect.Discard;
                
                // 0 gives us the first monitor adapter on the system
                // for md3dm you must use the default device type
                // this refers to the form which will provide the rendering
                // area createflags allows various options to be set
                // present parameters set various details of how the image 
                // will be displayed within render area and what buffers and
                // formats it will have
                device = new Device(0, DeviceType.Default, this,
                    CreateFlags.None, presentParams);
            }
            catch (DirectXException)
            { 
                return false; 
            }
            return true;
        }

        // All rendering for each frame occurs here
        private void Render()
        {
            if (device != null) 
            {
                //Clear the backbuffer to a blue color 
                device.Clear(ClearFlags.Target, System.Drawing.Color.Blue,
                    1.0f, 0);
                //Begin the scene
                device.BeginScene();
            
                // Rendering of scene objects can happen here
    
                //End the scene
                device.EndScene();
                device.Present();
            }
        }

        // Called to repaint the window
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
             // Render on painting
            this.Render();
            
            // Render again
            this.Invalidate(); 
        }
        
        // Called to repaint the window background
        protected override void OnPaintBackground(
            System.Windows.Forms.PaintEventArgs e)
        {
            // Do nothing to ensure that the rendering area is not overdrawn
        }

        // Close the window when Esc is pressed
        protected override void OnKeyPress(
            System.Windows.Forms.KeyPressEventArgs e)
        {
             // Esc was pressed
            if ((int)(byte)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
                this.Close();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() 
        {
            CreateDevice frm = new CreateDevice();
            
             // Initialize Direct3D
            if (!frm.InitializeGraphics())
            {
                MessageBox.Show("Could not initialize Direct3D. " + 
                    "This tutorial will exit.");
                return;
            }

            Application.Run(frm);
        }
    }
}
