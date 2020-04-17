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

//---------------------------------------------------------------------
// File: StencilBufferStencilDepth.cs
//
// Desc: Example code showing how to use stencil buffers to show the
//       depth complexity of a scene.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//---------------------------------------------------------------------

using System;
using System.Windows.Forms;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;


namespace Microsoft.Samples.MD3DM
{

    public class StencilDepthSample : Form
    {
        // Should we show the depth complexity?
        private bool showDepthComplexity = true; 

        // Should we draw the helicopter or airplane?
        private bool drawHelicopter = false; 

        // The graphical object we'll be rendering
        private GraphicsMesh[] fileObject = new GraphicsMesh[2];

        // The vertex buffer we'll use to draw
        private VertexBuffer squareVertexBuffer = null; 

        // World matrix
        private Matrix worldMatrix = Matrix.Identity;  

        // Main options window
        private System.Windows.Forms.MenuItem menuOptions = null; 

        // Show Depth
        private System.Windows.Forms.MenuItem menuShowDepth = null; 

        // Pick object to draw
        private System.Windows.Forms.MenuItem menuPick = null; 

        // The value of the system tick counter when we started tracking time
        private int tickStart = 0;

        // The number of seconds the app has been running
        private float appTime;

        // The rendering device
        private Device device;

        /// <summary>
        /// Application constructor.
        /// </summary>
        public StencilDepthSample()
        {
            // Set the window text
            this.Text = "StencilDepth: Displaying Depth Complexity";

            menuShowDepth = new MenuItem();
            menuShowDepth.Text = "Show Depth Complexity";
            menuShowDepth.Checked = showDepthComplexity;
            menuShowDepth.Click += new System.EventHandler(this.DepthClicked);

            menuPick = new MenuItem();
            menuPick.Text = 
                drawHelicopter ? "Show Airplane" : "Show Helicopter";
            menuPick.Click += new System.EventHandler(this.PickClicked);

            menuOptions = new MenuItem();
            menuOptions.Text = "Options";
            menuOptions.MenuItems.Add(menuShowDepth);
            menuOptions.MenuItems.Add(menuPick);
            MainMenu menuMain = new MainMenu();
            menuMain.MenuItems.Add(menuOptions);
            this.Menu = menuMain;
        }

        /// <summary>
        /// Called once per frame, the call is the entry point for
        /// animating the scene.
        /// </summary>
        public void FrameMove()
        {
            // Setup the world spin matrix
            worldMatrix = Matrix.RotationAxis(
                new Vector3(1.0f, 1.0f, 0.0f), appTime / 2);
        }

        /// <summary>
        /// Turns on stencil and other states for recording the depth 
        /// complexity during the rendering of a scene.
        /// </summary>
        void SetStatesForRecordingDepthComplexity()
        {
            // Clear the stencil buffer
            device.Clear(ClearFlags.Stencil, 
                System.Drawing.Color.Black.ToArgb(), 1.0f, 0);

            // Turn stenciling
            device.RenderState.StencilEnable = true;
            device.RenderState.StencilFunction = Compare.Always;
            device.RenderState.ReferenceStencil = 0;
            device.RenderState.StencilMask = 0x00000000;
            device.RenderState.StencilWriteMask = unchecked((int)0xffffffff);

            // Increment the stencil buffer for each pixel drawn
            device.RenderState.StencilZBufferFail = 
                StencilOperation.IncrementSaturation;
            device.RenderState.StencilFail = StencilOperation.Keep;
            device.RenderState.StencilPass = 
                StencilOperation.IncrementSaturation;
        }

        /// <summary>
        /// Draws the contents of the stencil buffer in false color.
        /// Use alpha blending of one red, one green, and one blue
        /// rectangle to do false coloring of bits 1, 2, and 4 in the
        /// stencil buffer.
        /// </summary>
        void ShowDepthComplexity()
        {
            // Turn off the buffer, and enable alpha blending
            device.RenderState.ZBufferEnable  = false;
            device.RenderState.AlphaBlendEnable = true;
            device.RenderState.SourceBlend =  Blend.SourceColor;
            device.RenderState.DestinationBlend = Blend.InvSourceColor;

            // Set up the stencil states
            device.RenderState.StencilZBufferFail = StencilOperation.Keep;
            device.RenderState.StencilFail = StencilOperation.Keep;
            device.RenderState.StencilPass = StencilOperation.Keep;
            device.RenderState.StencilFunction = Compare.NotEqual;
            device.RenderState.ReferenceStencil = 0;

            // Set the background to black
            device.Clear(ClearFlags.Target, 
                System.Drawing.Color.Black.ToArgb(), 1.0f, 0);

            // Set render states for drawing a rectangle that
            // covers the viewport. The color of the rectangle
            // will be passed in D3DRS_TEXTUREFACTOR
            device.SetStreamSource(0, squareVertexBuffer, 0);
            device.TextureState[0].ColorArgument1 = TextureArgument.TFactor;
            device.TextureState[0].ColorOperation =
                TextureOperation.SelectArg1;

            // Draw a red rectangle wherever the 1st stencil bit is set
            device.RenderState.StencilMask = 0x01;
            device.RenderState.TextureFactor = 
                System.Drawing.Color.Red.ToArgb();
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);

            // Draw a green rectangle wherever the 2nd stencil bit is set
            device.RenderState.StencilMask = 0x02;
            device.RenderState.TextureFactor = 
                System.Drawing.Color.LightGreen.ToArgb();
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);

            // Draw a blue rectangle wherever the 3rd stencil bit is set
            device.RenderState.StencilMask = 0x04;
            device.RenderState.TextureFactor =
                System.Drawing.Color.Blue.ToArgb();
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);

            // Restore states
            device.TextureState[0].ColorArgument1 =
                TextureArgument.TextureColor;
            device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
            device.TextureState[0].ColorOperation = TextureOperation.Modulate;
            device.RenderState.ZBufferEnable = true;
            device.RenderState.AlphaBlendEnable = false;
        }

        /// <summary>
        /// Called once per frame, the call is the entry point for
        /// 3d rendering. This function sets up render states, clears the
        /// viewport, and renders the scene.
        /// </summary>
        public void Render()
        {
            // Clear the viewport
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer,
                System.Drawing.Color.Blue.ToArgb(), 1.0f, 0);

            device.BeginScene();

            if (showDepthComplexity)
                SetStatesForRecordingDepthComplexity();

            device.Transform.World = worldMatrix;
            if (drawHelicopter)
                fileObject[0].Render();
            else
                fileObject[1].Render();

            // Show the depth complexity of the scene
            if (showDepthComplexity)
                ShowDepthComplexity();

            device.EndScene();
            device.Present();
        }

        /// <summary>
        /// The device has been created.  Resources that are not lost on
        /// Reset() can be created here.
        /// </summary>
        public void InitializeDeviceObjects()
        {
            // Load the main file object
            for (int i = 0; i < 2; i++)
                if (fileObject[i] == null)
                    fileObject[i] = new GraphicsMesh();

            // Load a .md3dm file
            fileObject[0].Create(device, 
				"StencilBufferStencilDepth.Content.", "heli.md3dm",
                System.Reflection.Assembly.GetExecutingAssembly());
            fileObject[1].Create(device,
				"StencilBufferStencilDepth.Content.", "air2.md3dm", 
                System.Reflection.Assembly.GetExecutingAssembly());
            if ((squareVertexBuffer == null) || (squareVertexBuffer.Disposed))
            {
                Pool vertexBufferPool;
                Caps caps;

                // Get the device capabilities

                caps = device.DeviceCaps;

                if (caps.SurfaceCaps.SupportsVidVertexBuffer)
                    vertexBufferPool = Pool.VideoMemory;
                else
                    vertexBufferPool = Pool.SystemMemory;

                // Create a big square for rendering the stencilbuffer 
                // contents
                squareVertexBuffer = new VertexBuffer(typeof(Vector4), 4,
                    device, Usage.WriteOnly, VertexFormats.Transformed,
                    vertexBufferPool);
                squareVertexBuffer.Created += new System.EventHandler(
                    this.SquareVBCreated);
                this.SquareVBCreated(squareVertexBuffer, null);
            }
        }

        /// <summary>
        /// Called when the vertex buffer has been created
        /// </summary>
        private void SquareVBCreated(object sender, EventArgs e)
        {
            VertexBuffer vb = (VertexBuffer)sender;
            float xpos = (float)device.PresentationParameters.BackBufferWidth;
            float ypos = 
                (float)device.PresentationParameters.BackBufferHeight;
            Vector4[] v = (Vector4[])vb.Lock(0, 0);
            v[0] = new Vector4(0, ypos, 0.0f, 1.0f);
            v[1] = new Vector4(0,  0, 0.0f, 1.0f);
            v[2] = new Vector4(xpos, ypos, 0.0f, 1.0f);
            v[3] = new Vector4(xpos,  0, 0.0f, 1.0f);
            vb.Unlock();
        }

        /// <summary>
        /// The ShowDepthComplexity menu item has been clicked, switch
        /// modes
        /// </summary>
        private void DepthClicked(object sender, EventArgs e)
        {
            showDepthComplexity = !showDepthComplexity;
            ((MenuItem)sender).Checked = showDepthComplexity;
        }

        /// <summary>
        /// The user wants to see the other object
        /// </summary>
        private void PickClicked(object sender, EventArgs e)
        {
            drawHelicopter = !drawHelicopter;
            ((MenuItem)sender).Text =
                drawHelicopter ? "&Show Airplane" : "&Show Helicopter";
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
            // Build the device objects for the file-based objecs
            for (int i = 0; i<2; i++)
                fileObject[i].RestoreDeviceObjects(device , null);

            // Setup textures (the .X file may have textures)
            device.TextureState[0].ColorArgument1 =
                TextureArgument.TextureColor;
            device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
            device.TextureState[0].ColorOperation = TextureOperation.Modulate;
            device.TextureState[0].MinFilter = TextureFilter.Linear;
            device.TextureState[0].MagFilter = TextureFilter.Linear;

            // Set up misc render states
            device.RenderState.ZBufferEnable = true;
            device.RenderState.SpecularEnable = false;
            device.RenderState.ColorVertex = true;
            device.RenderState.Ambient = System.Drawing.Color.Black;
            
            // Set the transform matrices
            Vector3 vEyePt    = new Vector3(0.0f, 0.0f, -15.0f);
            Vector3 vLookatPt = new Vector3(0.0f, 0.0f,   0.0f);
            Vector3 vUpVec    = new Vector3(0.0f, 1.0f,   0.0f);
            Matrix matWorld, matView, matProj;

            matWorld = Matrix.Identity;
            matView = Matrix.LookAtLH(vEyePt, vLookatPt, vUpVec);
            float fAspect = 1.0f;
            matProj = Matrix.PerspectiveFovLH((float)Math.PI/4, fAspect,
                1.0f, 1000.0f);

            device.Transform.World = matWorld;
            device.Transform.View = matView;
            device.Transform.Projection = matProj;

            // Set up a material
            Material mtrl = new Material();
            mtrl.Ambient = mtrl.Diffuse = System.Drawing.Color.White;

            // Set up the light
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = System.Drawing.Color.White;
            device.Lights[0].Position = new Vector3(0.0f, -1.0f, 0.0f);
            device.Lights[0].Direction = new Vector3(0.0f, -1.0f, 0.0f);
            device.Lights[0].Range = 1000.0f;
            device.Lights[0].Update();
            device.Lights[0].Enabled = true;
            device.RenderState.Lighting = true; 

            // Turn on perspective correction for textures
            // This provides a more accurate visual at the cost
            // of a small performance overhead
            device.RenderState.TexturePerspective = true;
        }

        /// <summary>
        /// Called when the window is repainted
        /// </summary>
        /// <param name="e">Unused</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (tickStart == 0)
            {
                tickStart = Environment.TickCount - 1;

                // Now let's setup our D3D parameters
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.AutoDepthStencilFormat = DepthFormat.D24S8;
                presentParams.EnableAutoDepthStencil = true;
                device = new Device(0, DeviceType.Default, this,
                    CreateFlags.None, presentParams);

                InitializeDeviceObjects();
                device.DeviceReset += new EventHandler(RestoreDeviceObjects);
                RestoreDeviceObjects(device, EventArgs.Empty);
            }

            appTime = ((float)(Environment.TickCount - tickStart)) / 1000.0f;
            this.FrameMove();

             // Render on painting
            this.Render();

             // Render again
            this.Invalidate();
        }

        /// <summary>
        /// Called to redraw the window background
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(
            System.Windows.Forms.PaintEventArgs e)
        {
            // Do nothing so that the rendered view is not overdrawn
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() 
        {
            try
            {
                StencilDepthSample d3dApp = new StencilDepthSample();
                System.Windows.Forms.Application.Run(d3dApp);
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
