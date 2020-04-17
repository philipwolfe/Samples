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
using System.Windows.Forms;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;




namespace Microsoft.Samples.MD3DM
{
    // Custom D3D vertex format used by the vertex buffer
    struct MyVertex
    {
        public Vector3 p;       // vertex position
        public Vector3 n;       // vertex normal

        public static readonly VertexFormats Format = 
            VertexFormats.Position | VertexFormats.Normal;
    };

    

    
    /// <summary>
    /// Main form that renders this sample
    /// </summary>
    public class LightingForm : System.Windows.Forms.Form
    {
        private Microsoft.WindowsMobile.DirectX.Direct3D.Device device = null;
        // Tessellated plane to serve as the walls and floor
        private Mesh wallMesh = null;
        // Representation of point light
        private Mesh sphereMesh = null;  
        // Representation of dir/spot light
        private Mesh coneMesh = null;                 
        // Description of the D3D light
        private Light lightData;           
        // Number of vertices in the wall mesh along X
        private uint numberVertsX = 16;         
        // Number of vertices in the wall mesh along Z         
        private uint numberVertsZ = 16;
        // Number of triangles in the wall mesh                  
        private int numberTriangles = 0;         

        // the tick count when the app started rendering
        private int tickStart = 0;

        // the number of seconds since rendering started
        private float appTime;

        // a helper to record and render fps statistics
        private FpsTimerTool fpsTimer;

        /// <summary>
        /// Application constructor. Sets attributes for the app.
        /// </summary>
        public LightingForm()
        {
            // the number of traingles in the wall mesh
            numberTriangles = (int)((numberVertsX - 1) *
                (numberVertsZ - 1) * 2);

            // Set the window text
            this.Text = "Lighting";

            // Now let's setup our D3D stuff
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.AutoDepthStencilFormat = DepthFormat.D16;
            presentParams.EnableAutoDepthStencil = true;
            device = new Device(0, DeviceType.Default, this, CreateFlags.None,
                presentParams);

            // setup those objects which persist through reset
            InitializeDeviceObjects();
            // attach the device reset handler
            device.DeviceReset += new EventHandler(RestoreDeviceObjects);
            // setup any device resources that will not persist through reset
            RestoreDeviceObjects(device, EventArgs.Empty);
        }

        /// <summary>
        /// Called once per frame, the call is the entry point for animating
        /// the scene.
        /// </summary>
        public void FrameMove()
        {
            lightData = device.Lights[2];
            // Rotate through the various light types
            if (((int)appTime % 20) < 10)
                device.Lights[2].Type = LightType.Point;
            else
                device.Lights[2].Type = LightType.Directional;

            // Make sure the light type is supported by the device.  If 
            // VertexProcessingCaps.PositionAllLights is not set, the device
            // does not support point or spot lights, so change light #2's
            // type to a directional light.
            if 
            (!device.DeviceCaps.VertexProcessingCaps.SupportsPositionalLights)
            {
                if (device.Lights[2].Type == LightType.Point)
                    device.Lights[2].Type = LightType.Directional;
            }

            // Values for the light position, direction, and color
            float x = (float)Math.Sin(appTime * 2.000f);
            float y = (float)Math.Sin(appTime * 2.246f);
            float z = (float)Math.Sin(appTime * 2.640f);

            byte r = (byte)((0.5f + 0.5f * x) * 0xff);
            byte g = (byte)((0.5f + 0.5f * y) * 0xff);
            byte b = (byte)((0.5f + 0.5f * z) * 0xff);
            device.Lights[2].Diffuse = System.Drawing.Color.FromArgb(r, g, b);
            device.Lights[2].Range = 100.0f;
    
            switch(device.Lights[2].Type)
            {
                case LightType.Point:
                    device.Lights[2].Position = new Vector3(4.5f * x,
                        4.5f * y, 4.5f * z);
                    device.Lights[2].Attenuation1 = 0.4f;
                    break;
                case LightType.Directional:
                    device.Lights[2].Direction = new Vector3(x, y, z);
                    break;
            }
            device.Lights[2].Update();
        }

        /// <summary>
        /// Called once per frame, the call is the entry point for 3d
        /// rendering. This function sets up render states, clears the
        /// viewport, and renders the scene.
        /// </summary>
        public void Render()
        {
            Matrix matWorld;
            Matrix matTrans;
            Matrix matRotate;

            fpsTimer.StartFrame();

            // Clear the viewport
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, 0x000000ff,
                1.0f, 0);

            device.BeginScene();

            // Turn on light #0 and #2, and turn off light #1
            device.Lights[0].Enabled = true;
            device.Lights[1].Enabled = false;
            device.Lights[2].Enabled = true;

            // Draw the floor
            matTrans = Matrix.Translation(-5.0f, -5.0f, -5.0f);
            matRotate = Matrix.RotationZ(0.0f);
            matWorld = matRotate * matTrans;
            device.SetTransform(TransformType.World, matWorld);
            wallMesh.DrawSubset(0);

            // Draw the back wall
            matTrans = Matrix.Translation(5.0f, -5.0f, -5.0f);
            matRotate = Matrix.RotationZ((float)Math.PI / 2);
            matWorld = matRotate * matTrans;
            device.SetTransform(TransformType.World, matWorld);
            wallMesh.DrawSubset(0);

            // Draw the side wall
            matTrans = Matrix.Translation(-5.0f, -5.0f, 5.0f);
            matRotate = Matrix.RotationX((float)-Math.PI / 2);
            matWorld = matRotate * matTrans;
            device.SetTransform(TransformType.World, matWorld);
            wallMesh.DrawSubset(0);

            // Turn on light #1, and turn off light #0 and #2
            device.Lights[0].Enabled = false;
            device.Lights[1].Enabled = true;
            device.Lights[2].Enabled = false;

            // Draw the mesh representing the light
            if (lightData.Type == LightType.Point)
            {
                // Just position the point light -- no need to orient it
                matWorld = Matrix.Translation(lightData.Position.X, 
                    lightData.Position.Y, lightData.Position.Z);
                device.SetTransform(TransformType.World, matWorld);
                sphereMesh.DrawSubset(0);
            }
            else
            {
                // Position the light and point it in the light's direction
                Vector3 vecFrom = new Vector3(lightData.Position.X,
                    lightData.Position.Y, lightData.Position.Z);
                Vector3 vecAt = new Vector3(
                    lightData.Position.X + lightData.Direction.X, 
                    lightData.Position.Y + lightData.Direction.Y,
                    lightData.Position.Z + lightData.Direction.Z);
                Vector3 vecUp = new Vector3(0, 1, 0);
                Matrix matWorldInv;
                matWorldInv = Matrix.LookAtLH(vecFrom, vecAt, vecUp);
                matWorld = Matrix.Invert(matWorldInv);
                device.SetTransform(TransformType.World, matWorld);
                coneMesh.DrawSubset(0);
            }

            // Output statistics
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
            // initializes the fps timer
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
            MyVertex[] v;
            Mesh pWallMeshTemp;

            // Create a square grid numberVertsX*numberVertsZ for rendering
            // the wall
            pWallMeshTemp = new Mesh(numberTriangles, numberTriangles * 3, 
                0, MyVertex.Format, device);

            // Fill in the grid vertex data
            v = (MyVertex[])pWallMeshTemp.VertexBuffer.Lock(0,
                typeof(MyVertex), 0, numberTriangles * 3);
            float dX = 1.0f / (numberVertsX - 1);
            float dZ = 1.0f / (numberVertsZ - 1);
            uint k = 0;
            for (uint z = 0; z < (numberVertsZ - 1); z++)
            {
                for (uint x = 0; x < (numberVertsX - 1); x++)
                {
                    v[k].p  = new Vector3(10 * x * dX, 0.0f, 10 * z * dZ);
                    v[k].n  = new Vector3(0.0f, 1.0f, 0.0f);
                    k++;
                    v[k].p  = new Vector3(10 * x * dX, 0.0f, 10 * (z+1) * dZ);
                    v[k].n  = new Vector3(0.0f, 1.0f, 0.0f);
                    k++;
                    v[k].p  = 
                        new Vector3(10 * (x+1) * dX, 0.0f, 10 * (z+1) * dZ);
                    v[k].n  = new Vector3(0.0f, 1.0f, 0.0f);
                    k++;
                    v[k].p  = new Vector3(10 * x * dX, 0.0f, 10 * z * dZ);
                    v[k].n  = new Vector3(0.0f, 1.0f, 0.0f);
                    k++;
                    v[k].p  = 
                        new Vector3(10 * (x+1) * dX, 0.0f, 10 * (z+1) * dZ);
                    v[k].n  = new Vector3(0.0f, 1.0f, 0.0f);
                    k++;
                    v[k].p  = new Vector3(10 * (x+1) * dX, 0.0f, 10 * z * dZ);
                    v[k].n  = new Vector3(0.0f, 1.0f, 0.0f);
                    k++;
                }
            }
            pWallMeshTemp.VertexBuffer.Unlock();

            // Fill in index data
            ushort[] pIndex;
            pIndex = (ushort[])pWallMeshTemp.IndexBuffer.Lock(0, 
                typeof(ushort), 0, numberTriangles * 3);
            for (ushort iIndex = 0; iIndex < numberTriangles * 3; iIndex++)
                pIndex[iIndex] = iIndex;

            pWallMeshTemp.IndexBuffer.Unlock();

            // Eliminate redundant vertices
            int[] pdwAdjacency = new int[3 * numberTriangles];
            pWallMeshTemp.GenerateAdjacency(0.01f, pdwAdjacency);

            // Optimize the mesh
            wallMesh = pWallMeshTemp.Optimize(MeshFlags.OptimizeCompact |
                MeshFlags.OptimizeVertexCache | MeshFlags.VbDynamic |
                MeshFlags.VbWriteOnly, pdwAdjacency);

            pWallMeshTemp = null;
            pdwAdjacency = null;

            // Create sphere and cone meshes to represent the lights
            sphereMesh = Mesh.Sphere(device, 0.25f, 8, 8);
            coneMesh = Mesh.Cylinder(device, 0.0f, 0.25f, 0.5f, 8, 8);

            // Set up a material
            Microsoft.WindowsMobile.DirectX.Direct3D.Material mtrl = 
                new Material();
            mtrl.Ambient = mtrl.Diffuse = System.Drawing.Color.White;
            device.Material = mtrl;

            // Set miscellaneous render states
            device.RenderState.DitherEnable = false;
            device.RenderState.SpecularEnable = false;

            device.TextureState[0].ColorOperation = TextureOperation.Disable;
            device.TextureState[0].AlphaOperation = TextureOperation.Disable;

            // Set the world matrix
            Matrix matIdentity = Matrix.Identity;
            device.SetTransform(TransformType.World, matIdentity);

            // Set the view matrix.
            Matrix matView;
            Vector3 vFromPt = new Vector3(-10, 10, -10);
            Vector3 vLookatPt = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 vUpVec = new Vector3(0.0f, 1.0f, 0.0f);
            matView = Matrix.LookAtLH(vFromPt, vLookatPt, vUpVec);
            device.SetTransform(TransformType.View, matView);

            // Set the projection matrix
            Matrix matProj;
            float fAspect = 
                ((float)device.PresentationParameters.BackBufferWidth) /
                device.PresentationParameters.BackBufferHeight;
            matProj = Matrix.PerspectiveFovLH((float)Math.PI/4,
                fAspect, 1.0f, 100.0f);
            device.SetTransform(TransformType.Projection, matProj);

            // Turn on lighting.
            device.RenderState.Lighting = true;

            // Enable ambient lighting to a dim, grey light, so objects that
            // are not lit by the other lights are not completely black
            device.RenderState.Ambient = System.Drawing.Color.Gray;

            // Set light #0 to be a simple, faint grey directional light so 
            // the walls and floor are slightly different shades of grey
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Direction = new Vector3(0.3f, -0.5f, 0.2f);
            device.Lights[0].Diffuse = 
                System.Drawing.Color.FromArgb(64, 64, 64);
            device.Lights[0].Update();

            // Set light #1 to be a simple, bright directional light to use 
            // on the mesh representing light #2
            device.Lights[1].Type = LightType.Directional;
            device.Lights[1].Direction = new Vector3(0.5f, -0.5f, 0.5f);
            device.Lights[1].Diffuse = System.Drawing.Color.Blue;
            device.Lights[1].Update();

            // Light #2 will be the light used to light the floor and walls. 
            // It will be set up in FrameMove() since it changes every frame.

        }
        
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (tickStart == 0)
                tickStart = Environment.TickCount - 1;

            appTime = ((float)(Environment.TickCount - tickStart)) / 1000.0f;
            this.FrameMove();
            this.Render(); // Render on painting
            this.Invalidate(); // Render again
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
                LightingForm d3dApp = new LightingForm();
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
                MessageBox.Show("The sample has run into an error and needs" +
                    "to close: " + e.Message);
            }
        }
    }
}
