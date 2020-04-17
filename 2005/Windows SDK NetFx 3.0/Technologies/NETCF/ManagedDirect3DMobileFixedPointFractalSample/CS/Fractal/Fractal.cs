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
// File: Fractal.cs
//
// Desc: Draw our fractals as a height map
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//----------------------------------------------------------------------------
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
    public class MyGraphicsSample : Form
    {
        // Font for drawing text
        private Microsoft.WindowsMobile.DirectX.Direct3D.Font drawingFont =
            null;                 

        // The d3d device
        private Device device = null;

        //Fractal
        private ElevationPoints fracpatch = null;
        private double shape = .5;
        private int maxLevel = 6;
        private int bufferSize = 0;
        private int vert_size=0;
        private int indexX, indexY;
        private double [,] points;
        private double scale;

        //indices buffer
        IndexBuffer indexBuffer = null;
        short[] indices;
        //Vertexbuffer
        VertexBuffer vertexBuffer = null;


        // A helper tool that tracks and displays fps
        FpsTimerTool fpsTimer = null;
        
        /// <summary>
        /// Application constructor. Sets attributes for the app.
        /// </summary>
        public MyGraphicsSample()
        {
            // Set the window text
            this.Text = "Fractal";

            this.MinimizeBox = false;

            // Now let's setup our D3D parameters
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed=true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.AutoDepthStencilFormat = DepthFormat.D16;
            presentParams.EnableAutoDepthStencil = true;
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
        /// Called once per frame, the call is the entry point for animating
        /// the scene.
        /// </summary>
        public void FrameMove()
        {
            // Setup the lights and materials
            SetupLights();
            // Setup the world, view, and projection matrices
            SetupMatrices();
        }




        /// <summary>
        /// Called once per frame, the call is the entry point for 3d 
        /// rendering. This function sets up render states, clears the
        /// viewport, and renders the scene.
        /// </summary>
        public void Render()
        {
            fpsTimer.StartFrame();

            //Clear the backbuffer to a black color 
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer,
                Color.Black, 1.0f, 0);
            //Begin the scene
            device.BeginScene();

            // set the vertexbuffer stream source
            device.SetStreamSource(0, vertexBuffer, 0);
            // set fill mode
            device.RenderState.FillMode = FillMode.Solid;
            // set the indices          
            device.Indices = indexBuffer;
            //use the indices buffer
            device.DrawIndexedPrimitives(PrimitiveType.TriangleList,
                0, 0, bufferSize*bufferSize, 0, vert_size/3);

            // Write instructions on the screen
            drawingFont.DrawText(null, "Tap screen to generate\n new fractal.",
                new Point(2, 40), System.Drawing.Color.White);

            // output statistics
            fpsTimer.Render();

            device.EndScene();
            device.Present();

            fpsTimer.StopFrame();
        }

        /// <summary>
        /// The device has been created.  Resources that are not lost on
        /// Reset() can be created here.
        /// </summary>
        public void InitializeDeviceObjects()
        {
            Pool indexBufferPool;
            Pool vertexBufferPool;
            Caps caps;

            drawingFont = 
                new Microsoft.WindowsMobile.DirectX.Direct3D.Font(device,
                new System.Drawing.Font("Arial", 12.0f,
                System.Drawing.FontStyle.Bold));

            fpsTimer = new FpsTimerTool(device);
            
            FractSetup();

            // Get the device capabilities

            caps = device.DeviceCaps;

            // create the vertex buffer

            if (caps.SurfaceCaps.SupportsVidVertexBuffer)
                vertexBufferPool = Pool.VideoMemory;
            else
                vertexBufferPool = Pool.SystemMemory;

            vertexBuffer = new VertexBuffer(
                typeof(CustomVertex.PositionNormalColored),
                bufferSize*bufferSize, device, Usage.WriteOnly,
                CustomVertex.PositionNormalColored.Format, vertexBufferPool);
            vertexBuffer.Created += new System.EventHandler(
                this.OnCreateVertexBuffer);
            this.OnCreateVertexBuffer(vertexBuffer, null);

            //create the indices buffer
            
            if (caps.SurfaceCaps.SupportsVidIndexBuffer)
                indexBufferPool = Pool.VideoMemory;
            else
                indexBufferPool = Pool.SystemMemory;

            indexBuffer = new IndexBuffer(typeof(short), vert_size,
                device, Usage.WriteOnly, indexBufferPool);
            indices = new short[(bufferSize*6)*bufferSize];
            indexBuffer.Created += new System.EventHandler(
                this.OnCreateIndexBuffer);
            this.OnCreateIndexBuffer(indexBuffer, null);
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
            // Turn off culling, so we see the front and back of the triangle
            device.RenderState.CullMode = Cull.None;
            // Turn on the ZBuffer
            device.RenderState.ZBufferEnable = true;
            //make sure lighting is turned off
            device.RenderState.Lighting = false;    

        }

        /// <summary>
        /// Event Handler for windows messages
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            FractSetup();
            OnCreateVertexBuffer(vertexBuffer, null);
            OnCreateIndexBuffer(indexBuffer, null);
        }

        /// <summary>
        /// Setup the matrices
        /// </summary>
        private void SetupMatrices()
        {
            // move the object
            MatrixFixed temp = new MatrixFixed(
                Matrix.Translation(-(bufferSize*0.5f), 0,
                -(bufferSize*0.5f)));

            // For our world matrix, we will just rotate the object
            // about the indexY-axis.
            device.Transform.WorldFixed = MatrixFixed.Multiply(temp,
                new MatrixFixed(Matrix.RotationAxis(new Vector3(0,
                (float)Environment.TickCount / 2150.0f, 0), 
                Environment.TickCount / 3000.0f)));

            // Set up our view matrix. A view matrix can be defined given
            // an eye point, a point to lookat, and a direction for which
            // way is up. Here, we set the eye five units back along the
            // z-axis and up three units, look at the origin, and define
            // "up" to be in the indexY-direction.
            device.Transform.ViewFixed = new MatrixFixed(
                Matrix.LookAtLH(new Vector3(0.0f, 25.0f,-30.0f),
                new Vector3(0.0f, 0.0f, 0.0f), 
                new Vector3(0.0f, 1.0f, 0.0f)));

            // For the projection matrix, we set up a perspective
            // transform (which
            // transforms geometry from 3D view space to 2D viewport space,
            // with a perspective divide making objects smaller in the 
            // distance). To build a perpsective transform, we need the
            // field of view (1/4 pi is common), the aspect ratio, and the 
            // near and far clipping planes (which define at what distances
            // geometry should be no longer be rendered).
            device.Transform.ProjectionFixed = new MatrixFixed(
                Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, 1.0f, 1.0f,
                100.0f));
        }

        /// <summary>
        /// Setup the lights
        /// </summary>
        private void SetupLights()
        {
            Color col = Color.White;
            //Set up a material. The material here just has the diffuse
            //and ambient colors set to yellow. Note that only one material
            //can be used at a time.
            Material mtrl = new Material();
            mtrl.Diffuse =  mtrl.Ambient = col;
            device.Material = mtrl;
            
            //Set up a white, directional light, with an oscillating
            //direction. Note that many lights may be active at a time
            //(but each one slows down the rendering of our scene). However,
            //here we are just using one. Also, we need to set the 
            //D3DRS_LIGHTING renderstate to enable lighting
    
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = Color.Purple;
            device.Lights[0].Direction = new Vector3(0, 1.0f,   0);

            device.Lights[0].Update();
            device.Lights[0].Enabled = true;

            //Finally, turn on some ambient light.
            //Ambient light is light that scatters and lights all
            //objects evenly
            device.RenderState.Ambient = Color.Gray;
        }

        
        
        
        /// <summary>
        /// Setup the fractal
        /// </summary>
        public void FractSetup()
        {
            // create the fractal patch
            fracpatch = new ElevationPoints(maxLevel, false, 2.5, shape);
            fracpatch.CalcMidpointFM2D();

            bufferSize = (int)Math.Pow(2, maxLevel)+1;

            double max = 0;
            scale = 1.0;
            points = fracpatch.GetHeights();

            // clip points to >0 and find maximum to use for scaling
            for (indexX = 0; indexX < bufferSize; indexX++)
                for (indexY=0; indexY < bufferSize; indexY++)
                {
                    if (points[indexX, indexY] < 0) 
                        points[indexX, indexY] = 0;
                    if (points[indexX, indexY] > max) 
                        max = points[indexX,indexY];
                }

            // set the scaling factor
            scale = 12.0/max;
            vert_size = (bufferSize*6)*bufferSize;
        }

        /// <summary>
        /// Handle the vertex creation event
        /// </summary>
        void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            VertexBuffer vb = (VertexBuffer)sender;
            // Lock the buffer (which will return our structs)
            CustomVertex.PositionNormalColored[] verts = 
                (CustomVertex.PositionNormalColored[])vb.Lock(0,0); 
    
            for (indexX = 0; indexX<bufferSize; indexX++)
                for (indexY=0; indexY<bufferSize; indexY++)
                {
                    // set the position and normal
                    verts[indexY +( indexX * bufferSize)].X = indexX;
                    verts[indexY + (indexX * bufferSize)].Y = 
                        (float)points[indexX, indexY];
                    verts[indexY + (indexX * bufferSize)].Z = indexY;
                    verts[indexY + (indexX * bufferSize)].Nx = indexX;
                    verts[indexY + (indexX * bufferSize)].Ny =
                        -(float)points[indexX, indexY];
                    verts[indexY + (indexX * bufferSize)].Nz = indexY;
                    
                    // set the color of the vertices
                    if ((points[indexX, indexY] * scale == 0))
                        verts[(indexY + (indexX * bufferSize))].Color =
                            Color.Blue.ToArgb();
                    if ((points[indexX, indexY] * scale > 0) &
                        (points[indexX, indexY] * scale) < 1) 
                        verts[(indexY + (indexX * bufferSize))].Color =
                            Color.MediumBlue.ToArgb();
                    if ((points[indexX, indexY] * scale >= 1) &
                        (points[indexX, indexY] < 3))
                        verts[(indexY + (indexX * bufferSize))].Color =
                            Color.Green.ToArgb();
                    if ((points[indexX, indexY] * scale >= 3) &
                        (points[indexX, indexY] < 5))
                        verts[(indexY + (indexX * bufferSize))].Color =
                            Color.DarkGreen.ToArgb();
                    if ((points[indexX, indexY] * scale >= 5) &
                        (points[indexX, indexY] < 7))
                        verts[(indexY + (indexX * bufferSize))].Color =
                            Color.Gray.ToArgb();
                    if ((points[indexX, indexY] * scale >= 7) &
                        (points[indexX, indexY] < 10))
                        verts[(indexY + (indexX * bufferSize))].Color =
                            Color.DarkGray.ToArgb();
                    if ((points[indexX, indexY] * scale >= 10) &
                        (points[indexX, indexY] < 12))
                        verts[(indexY +( indexX * bufferSize))].Color =
                            Color.White.ToArgb();
                }

            // Unlock (and copy) the data
            vb.Unlock();
        }

        /// <summary>
        /// Handle the index buffer creation event
        /// </summary>
        void OnCreateIndexBuffer(object sender, EventArgs e)
        {
            IndexBuffer g = (IndexBuffer)sender;
            for (indexY = 1; indexY < bufferSize - 1; indexY++)
                for (indexX = 1; indexX < bufferSize - 1; indexX++)
                {
                    // Map each pair of traingles to a quad
                    indices[6 * ((indexX - 1) + ((indexY - 1) * 
                        (bufferSize)))] =
                        (short)((indexY - 1) * bufferSize + (indexX - 1));
                    indices[6 * ((indexX - 1) + ((indexY - 1) *
                        (bufferSize))) + 1] =
                        (short)((indexY - 0) * bufferSize + (indexX - 1));
                    indices[6 * ((indexX - 1) + ((indexY - 1) *
                        (bufferSize))) + 2] =
                        (short)((indexY - 1) * bufferSize + (indexX - 0));
                    indices[6 * ((indexX - 1) + ((indexY - 1) *
                        (bufferSize))) + 3] =
                        (short)((indexY - 1) * bufferSize + (indexX - 0));
                    indices[6 * ((indexX - 1) + ((indexY - 1) *
                        (bufferSize))) + 4] =
                        (short)((indexY - 0) * bufferSize + (indexX - 1));
                    indices[6 * ((indexX - 1) + ((indexY - 1) *
                        (bufferSize))) + 5] =
                        (short)((indexY - 0) * bufferSize + (indexX - 0));
                }
            g.SetData(indices, 0, 0);
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            this.FrameMove();
             // Render on painting
            this.Render();
            // Render again
            this.Invalidate(); 
        }
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
                MyGraphicsSample d3dApp = new MyGraphicsSample();
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
                MessageBox.Show("The sample has run into an error and" +
                    " needs to close: " + e.Message);
            }
        }
    }
}
