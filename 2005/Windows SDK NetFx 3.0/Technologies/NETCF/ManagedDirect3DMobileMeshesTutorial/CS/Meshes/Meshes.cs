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
// File: Meshes.cs
//
// Desc: For advanced geometry, most apps will prefer to load pre-authored
//       meshes from a file. Unlike desktop there is no support for loading
//       a mesh from the .x file format. To deal with this, this sample
//       uses a custom mesh file format and a MeshLoader class to read and
//       write this format. An app can still use .x meshes by converting them
//       to this unofficial format with the MeshConverter utility, then
//       loading the mesh from the converted file at runtime.
//
//----------------------------------------------------------------------------


using System;
using System.IO;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;


namespace Microsoft.Samples.MD3DM
{
    public class Meshes : Form
    {
        // The d3d rendering device
        Device device = null; 
        
        // The mesh object in sysmem
        Mesh mesh = null; 
        
        // Materials for the mesh
        Material[] meshMaterials; 

        // Textures for the mesh
        Texture[] meshTextures; 

        // the display parameters for drawing a d3d window
        PresentParameters presentParams = new PresentParameters();

        public Meshes()
        {
            // Set the caption
            this.Text = "Direct3D Tutorial 6 - Meshes";
            this.MinimizeBox = false;
        }

        /// <summary>
        /// Prepares the d3d system for display
        /// </summary>
        /// <returns> True on success and false otherwise</returns>
        bool InitializeGraphics()
        {
            try
            {
                // draw the graphics inside a standard window
                presentParams.Windowed = true;
            
                // discard the current frame when drawing a new one
                presentParams.SwapEffect = SwapEffect.Discard;
            
                // create a 16 bit depth buffer 
                presentParams.EnableAutoDepthStencil = true;
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;

                // Create the D3DDevice
                device = new Device(0, DeviceType.Default, this,
                    CreateFlags.None, presentParams);
                device.DeviceReset += new System.EventHandler(
                    this.OnResetDevice);
                this.OnResetDevice(device, null);
            }
            catch (Exception)
            {
              return false;
            }

            return true;
        }


        /// <summary>
        /// Handles device reset events
        /// </summary>
        /// <param name="sender">The device which sent the event</param>
        /// <param name="e">Ignored</param>
        void OnResetDevice(object sender, EventArgs e)
        {
            string[] textureFilenames = null;

            Device dev = (Device)sender;

            // Turn on the zbuffer
            dev.RenderState.ZBufferEnable = true;

            // Turn on ambient lighting 
            dev.RenderState.Ambient = System.Drawing.Color.White;

            // Turn on perspective correction for textures
            // This provides a more accurate visual at the cost
            // of a small performance overhead
            dev.RenderState.TexturePerspective = true;

            // Load the mesh from the specified file
            mesh = MeshLoader.LoadMesh(device,
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                "Meshes.Content.tiger.md3dm"), MeshFlags.SystemMemory,
				out meshMaterials, out textureFilenames);
            

            // Extract the material properties and texture names
            meshTextures = new Texture[meshMaterials.Length];
            for( int i=0; i<meshMaterials.Length; i++ )
            {

                // Set the ambient color for the material
                // (D3DX does not do this)
                meshMaterials[i].Ambient = meshMaterials[i].Diffuse;
     
                // Create the texture
                meshTextures[i] = TextureLoader.FromStream(dev, 
                    Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    "Meshes.Content." + textureFilenames[i]));
            }
        }

        /// <summary>
        /// Loads the matrices with appropriate transformations
        /// </summary>
        void SetupMatrices()
        {
            // For our world matrix, we will just leave it as the identity
            device.Transform.World = 
                Matrix.RotationY(Environment.TickCount/1000.0f );

            // Set up our view matrix. A view matrix can be defined given
            // an eye point, a point to lookat, and a direction for which
            // way is up. Here, we set the eye five units back along the
            // z-axis and up three units, look at the origin, and define
            // "up" to be in the y-direction.
            device.Transform.View = Matrix.LookAtLH(
                new Vector3( 0.0f, 2.0f,-3.0f ), 
                new Vector3( 0.0f, 0.0f, 0.0f ), 
                new Vector3( 0.0f, 1.0f, 0.0f ) );

            // For the projection matrix, we set up a perspective
            // transform (which transforms geometry from 3D view space to 2D
            // viewport space, with a perspective divide making objects 
            // smaller in the distance). To build a perpsective transform,
            // we need the field of view (1/4 pi is common), the aspect
            // ratio, and the near and far clipping planes (which define at
            // what distances geometry should be no longer be rendered).
            device.Transform.Projection =
                Matrix.PerspectiveFovLH( (float)(Math.PI / 4), 1.0f, 1.0f,
                100.0f );
        }

        /// <summary>
        /// Draws the mesh to the screen
        /// </summary>
        private void Render()
        {
            if (device == null) 
                return;

            //Clear the backbuffer to a blue color 
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer,
                System.Drawing.Color.Blue, 1.0f, 0);
            //Begin the scene
            device.BeginScene();
            // Setup the world, view, and projection matrices
            SetupMatrices();
            
            // Meshes are divided into subsets, one for each material.
            // Render them in a loop
            for( int i=0; i < meshMaterials.Length; i++ )
            {
                // Set the material and texture for this subset
                device.Material = meshMaterials[i];
                device.SetTexture(0, meshTextures[i]);
        
                // Draw the mesh subset
                mesh.DrawSubset(i);
            }

            //End the scene
            device.EndScene();
            device.Present();
        }

        /// <summary>
        /// Called whenever the window needs to be repainted
        /// </summary>
        /// <param name="e">Ignored</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Render the mesh to the screen
            Render(); 
            
            // Invalidating the window will cause it to be redrawn in
            // the future
            Invalidate();
        }

        /// <summary>
        /// Called whenever the background of the window needs to be repainted
        /// </summary>
        /// <param name="e">Ignored</param>
        protected override void OnPaintBackground(
            System.Windows.Forms.PaintEventArgs e)
        {
            // Doing nothing ensures the background will never overdraw
            // the previous rendering
        }

        /// <summary>
        /// Called whenever a keystroke is made
        /// </summary>
        /// <param name="e">Additional information about the keystroke</param>
        protected override void OnKeyPress(
            System.Windows.Forms.KeyPressEventArgs e)
        {
            // if Escape was pressed then shutdown
            if ((int)e.KeyChar == (int)System.Windows.Forms.Keys.Escape)
                this.Close(); 
        }

        /// <summary>
        /// Called whenever the window is being resized
        /// </summary>
        /// <param name="e">Ignored</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() 
        {
            Meshes meshForm = new Meshes();
                
            // Initialize Direct3D
            if (!meshForm.InitializeGraphics()) 
            {
                MessageBox.Show("Could not initialize Direct3D. " +
                    "This tutorial will exit.");
                return;
            }

            // Run the form
            try
            {
                Application.Run(meshForm);
            }
            catch(Exception e)
            {
                MessageBox.Show("An error occured and this sample needs " +
                    " to  close:" + e.Message);
            }
        }
    }
}