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
// File: Vertices.cs
//
// Desc: In this tutorial, we are rendering some vertices. This introduces the
//       concept of the vertex buffer, a Direct3D object used to store
//       vertices. Vertices can be defined any way we want by defining a
//       custom structure and a custom FVF (flexible vertex format). In this
//       tutorial, we are using vertices that are transformed (meaning they
//       are already in 2D window coordinates) and lit (meaning we are not
//       using Direct3D lighting, but are supplying our own colors).
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
    // The main class for this samples
    public class Vertices : Form
    {
        // Our global variables for this project
        Device device = null;
        VertexBuffer vertexBuffer = null;

        public Vertices()
        {
            // Set the caption of the form
            this.Text = "Direct3D Tutorial 2 - Vertices";

            // We want an OK Button.
            this.MinimizeBox = false;
        }
        
        // Prepare the rendering device
        public bool InitializeGraphics()
        {
            try
            {
                // Now let's setup our D3D parameters
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                device = new Device(0, DeviceType.Default, this,
                    CreateFlags.None, presentParams);
                this.OnCreateDevice(device, null);
            }
            catch (DirectXException)
            { 
                return false; 
            }
            return true;
        }

        // Called whenever the device is created
        void OnCreateDevice(object sender, EventArgs e)
        {
            Pool vertexBufferPool;
            Caps caps;
            Device dev = (Device)sender;

            // Get the device capabilities

            caps = dev.DeviceCaps;

            if (caps.SurfaceCaps.SupportsVidVertexBuffer)
                vertexBufferPool = Pool.VideoMemory;
            else
                vertexBufferPool = Pool.SystemMemory;

            // Now Create the VB
            vertexBuffer = new VertexBuffer(
                typeof(CustomVertex.TransformedColored), 3, dev, 0, 
                CustomVertex.TransformedColored.Format, vertexBufferPool);
            vertexBuffer.Created += new System.EventHandler(
                this.OnCreateVertexBuffer);
            this.OnCreateVertexBuffer(vertexBuffer, null);
        }

        // Called whenever the vertex buffer is created (or recreated)
        void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            // retrieve the vertex buffer
            VertexBuffer vb = (VertexBuffer)sender;
            // get a graphics stream for writing to the buffer
            GraphicsStream stm = vb.Lock(0, 0, 0);
            // create an array of vertices which can be written into the
            // stream
            CustomVertex.TransformedColored[] verts = 
                new CustomVertex.TransformedColored[3];

            // initialize the vertex array with position and color data
            verts[0].X=150;
            verts[0].Y=50;
            verts[0].Z=0.5f;
            verts[0].Rhw=1;
            verts[0].Color = System.Drawing.Color.Aqua.ToArgb();

            verts[1].X=250;
            verts[1].Y=250;
            verts[1].Z=0.5f;
            verts[1].Rhw=1;
            verts[1].Color = System.Drawing.Color.Brown.ToArgb();
            
            verts[2].X=50;
            verts[2].Y=250;
            verts[2].Z=0.5f;
            verts[2].Rhw=1;
            verts[2].Color = System.Drawing.Color.LightPink.ToArgb();
            
            // write the vertices to the buffer
            stm.Write(verts);
            // unlock the vertex buffer
            vb.Unlock();
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
            
                device.SetStreamSource(0, vertexBuffer, 0);
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
                //End the scene
                device.EndScene();
                device.Present();
            }
        }

        // Called when the window needs to be repainted
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
             // Render on painting
            this.Render();

             // Render again
            this.Invalidate();
        }

        // Called when the window background needs to be repainted
        protected override void OnPaintBackground(
            System.Windows.Forms.PaintEventArgs e)
        {
            // Do nothing so that the rendered area is not overdrawn
        }

        // Handles any keyboard keys which have been pressed
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
            Vertices frm = new Vertices();

            if (!frm.InitializeGraphics()) // Initialize Direct3D
            {
                MessageBox.Show("Could not initialize Direct3D. This " +
                    "tutorial will exit.");
                return;
            }

            Application.Run(frm);
        }

    }
}
