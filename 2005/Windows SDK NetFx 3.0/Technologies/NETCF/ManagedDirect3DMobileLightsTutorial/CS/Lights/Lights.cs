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
// File: Lights.cs
//
// Desc: Rendering 3D geometry is much more interesting when dynamic lighting
//       is added to the scene. To use lighting in D3D, you must create one or
//       more lights, setup a material, and make sure your geometry contains
//       surface normals. Lights may have a position, a color, and be of a 
//       certain type such as directional (light comes from one direction), 
//       point (light comes from a specific x,y,z coordinate and radiates in
//       all directions) or spotlight. Materials describe the surface of your
//       geometry, specifically, how it gets lit (diffuse color, ambient
//       color, etc.). Surface normals are part of a vertex, and are needed
//       for the D3D's internal lighting calculations.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;

namespace Microsoft.Samples.MD3DM
{
    // The main class for this sample
    public class Lights : Form
    {
        // Our global variables for this project
        Device device = null;
        VertexBuffer vertexBuffer = null;
        PresentParameters presentParams = new PresentParameters();

        // Class constructor
        public Lights()
        {
            // Set the caption
            this.Text = "Direct3D Tutorial 4 - Lights";

            // We want an OK Button.
            this.MinimizeBox = false;
        }

        // Prepares the rendering device
        public bool InitializeGraphics()
        {
            try
            {
                // We don't want to run fullscreen
                presentParams.Windowed = true; 
                // Discard the frames 
                presentParams.SwapEffect = SwapEffect.Discard; 
                // Turn on a Depth stencil
                presentParams.EnableAutoDepthStencil = true; 
                // And the stencil format
                presentParams.AutoDepthStencilFormat = DepthFormat.D16; 
                //Create a device
                device = new Device(0, DeviceType.Default, this,
                    CreateFlags.None, presentParams);
                device.DeviceReset += 
                    new System.EventHandler(this.OnResetDevice);
                this.OnCreateDevice(device, null);
                this.OnResetDevice(device, null);
            }
            catch (DirectXException)
            {
                // Catch any errors and return a failure
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
                typeof(CustomVertex.PositionNormal), 100, dev,
                Usage.WriteOnly, CustomVertex.PositionNormal.Format,
                vertexBufferPool);
            vertexBuffer.Created += 
                new System.EventHandler(this.OnCreateVertexBuffer);
            this.OnCreateVertexBuffer(vertexBuffer, null);
        }

        // Called whenever the device is reset
        void OnResetDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            // Turn off culling, so we see the front and back of the triangle
            device.RenderState.CullMode = Cull.None;
            // Turn on the ZBuffer
            device.RenderState.ZBufferEnable = true;
            // make sure lighting is enabled
            device.RenderState.Lighting = true;    
        }

        // Fills the vertex buffer to make a cylinder
        void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            VertexBuffer vb = (VertexBuffer)sender;
            // Create a vertex buffer (100 customervertex)
            CustomVertex.PositionNormal[] verts = 
                (CustomVertex.PositionNormal[])vb.Lock(0,0); 
            for (int i = 0; i < 50; i++)
            {
                // Fill up our structs
                float theta = (float)(2 * Math.PI * i) / 49;
                verts[2 * i].X = (float)Math.Sin(theta);
                verts[2 * i].Y = -1;
                verts[2 * i].Z = (float)Math.Cos(theta);
                verts[2 * i].Nx = (float)Math.Sin(theta);
                verts[2 * i].Ny = 0;
                verts[2 * i].Nz = (float)Math.Cos(theta);
                verts[2 * i + 1].X = (float)Math.Sin(theta);
                verts[2 * i + 1].Y = 1;
                verts[2 * i + 1].Z = (float)Math.Cos(theta);
                verts[2 * i + 1].Nx = (float)Math.Sin(theta);
                verts[2 * i + 1].Ny = 0;
                verts[2 * i + 1].Nz = (float)Math.Cos(theta);
            }
            // Unlock (and copy) the data
            vb.Unlock();
        }

        // Sets up the world, view, and projection matrices each frame
        private void SetupMatrices()
        {
            // For our world matrix, we will just rotate the object
            // about the y-axis.
            device.Transform.World = Matrix.RotationAxis(
                new Vector3((float)Math.Cos(Environment.TickCount / 250.0f),
                1, (float)Math.Sin(Environment.TickCount / 250.0f)), 
                Environment.TickCount / 3000.0f );

            // Set up our view matrix. A view matrix can be defined given
            // an eye point, a point to lookat, and a direction for which
            // way is up. Here, we set the eye five units back along the
            // z-axis and up three units, look at the origin, and define
            // "up" to be in the y-direction.
            device.Transform.View = Matrix.LookAtLH(
                new Vector3( 0.0f, 3.0f,-5.0f ),
                new Vector3( 0.0f, 0.0f, 0.0f ),
                new Vector3( 0.0f, 1.0f, 0.0f ) );

            // For the projection matrix, we set up a perspective transform
            // (which transforms geometry from 3D view space to 2D viewport
            // space, with a perspective divide making objects smaller in
            // the distance). To build a perpsective transform, we need the
            // field of view (1/4 pi is common), the aspect ratio, and the 
            // near and far clipping planes (which define at what distances
            // geometry should be no longer be rendered).
            device.Transform.Projection = Matrix.PerspectiveFovLH(
                (float)Math.PI / 4.0f, 1.0f, 1.0f, 100.0f );
        }

        // Sets up the lights for each frame
        private void SetupLights()
        {
            System.Drawing.Color col = System.Drawing.Color.White;
            //Set up a material. The material here just has the diffuse
            //and ambient colors set to yellow. Note that only one material
            //can be used at a time.
            Material mtrl = new Material();
            mtrl.Diffuse = col;
            mtrl.Ambient = col;
            device.Material = mtrl;
            
            //Set up a white, directional light, with an oscillating
            //direction. Note that many lights may be active at a time
            //(but each one slows down the rendering of our scene). However,
            //here we are just using one. Also, we need to set the
            //D3DRS_LIGHTING renderstate to enable lighting
    
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = System.Drawing.Color.DarkTurquoise;
            device.Lights[0].Direction = 
                new Vector3((float)Math.Cos(Environment.TickCount / 250.0f),
                1.0f, (float)Math.Sin(Environment.TickCount / 250.0f));

            //turn it on
            device.Lights[0].Enabled = true;

            //Finally, turn on some ambient light.
            //Ambient light is light that scatters and lights all
            //objects evenly
            device.RenderState.Ambient = 
                System.Drawing.Color.FromArgb(0x202020);
        }

        // All rendering for each frame occurs here
        private void Render()
        {
            //Clear the backbuffer to a blue color 
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer,
                System.Drawing.Color.Blue, 1.0f, 0);
            //Begin the scene
            device.BeginScene();
            // Setup the lights and materials
            SetupLights();
            // Setup the world, view, and projection matrices
            SetupMatrices();
    
            device.SetStreamSource(0, vertexBuffer, 0);
            // the number of triangles in a triangle strip is 
            // numberVertices-2
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 100 - 2);
            //End the scene
            device.EndScene();
            // Update the screen
            device.Present();
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
            // Don't paint the background
        }

        // Handles all keyboard keys which have been pressed
        protected override void OnKeyPress(
            System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
                // Esc was pressed
                this.Close(); 
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() 
        {
            Lights lightForm = new Lights();
                
             // Initialize Direct3D
            if (!lightForm.InitializeGraphics())
            {
                MessageBox.Show("Could not initialize Direct3D. This " +
                    "tutorial will exit.");
                return;
            }

            Application.Run(lightForm);
        }
    }
}
