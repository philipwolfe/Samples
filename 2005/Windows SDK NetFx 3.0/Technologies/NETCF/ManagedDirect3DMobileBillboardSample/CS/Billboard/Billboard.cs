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


//---------------------------------------------------------------------------
// File: Billboard.cs
//
// Desc: Example code showing how to do billboarding. The sample uses
//       billboarding to draw some trees.
//
//       Note: This implementation is for billboards that are fixed to rotate
//       about the Y-axis, which is good for things like trees. For
//       unconstrained billboards, like explosions in a flight sim, the
//       technique is the same, but the the billboards are positioned 
//       slightly differently. Try using the inverse of the view matrix,
//       TL-vertices, or some other technique.
//
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;



namespace Microsoft.Samples.MD3DM
{
    /// <summary>
    /// Simple class to hold data for rendering a tree
    /// </summary>
    ///
    public class Tree
    {
        // Four corners of billboard quad
        CustomVertex.PositionColoredTextured[] corners = 
            new CustomVertex.PositionColoredTextured[4];
        public CustomVertex.PositionColoredTextured V0
        {
            get { return corners[0]; }
            set { corners[0] = value; }
        }

        public CustomVertex.PositionColoredTextured V1
        {
            get { return corners[1]; }
            set { corners[1] = value; }
        }

        public CustomVertex.PositionColoredTextured V2
        {
            get { return corners[2]; }
            set { corners[2] = value; }
        }

        public CustomVertex.PositionColoredTextured V3
        {
            get { return corners[3]; }
            set { corners[3] = value; }
        }
 
        // Origin of tree
        Vector3 positionValue;
        public Vector3 Position
        {
            get { return positionValue; }
            set { positionValue = value; }
        }

        // Which texture map to use
        int treeTextureIndexValue;
        public int TreeTextureIndex
        {
            get { return treeTextureIndexValue; }
            set { treeTextureIndexValue = value; }
        }

        // Offset into vertex buffer of tree's vertices
        int offsetIndexValue;
        public int OffsetIndex
        {
            get { return offsetIndexValue; }
            set { offsetIndexValue = value; }
        }
    }


    /// <summary>
    /// The main class of this sample. It does all the rendering
    /// </summary>
    /// 
    public class BillboardForm : System.Windows.Forms.Form
    {
        // the number of trees distributed on the terrain
        private const int numberTrees = 75;

        // the direction the camera is facing
        public static Vector3 GlobalDirection;

        // Tree textures to use
        static readonly string[] treeTextureFileNames = new string[]
        {
            "tree01S.dds"
        };

        // mesh objects for terrain and skybox
        private GraphicsMesh terrainMesh = null;
        private GraphicsMesh skyBoxMesh = null;

        // Vertex buffer for rendering a tree
        private VertexBuffer treeVertexBuffer = null;  
        // Tree images
        private Texture[] treeTextures = 
            new Texture[treeTextureFileNames.Length]; 
        // Used for billboard orientation
        Matrix billboardMatrix; 

        // Array of Tree objects holds the render data for all trees
        // in the scene
        System.Collections.ArrayList trees = 
            new System.Collections.ArrayList(); 

        // Vectors defining the position and orientation of the camera
        private Vector3 cameraEyePoint = new Vector3(0.0f, 2.0f, -6.5f);
        private Vector3 cameraLookAtPoint = new Vector3(0.0f, 0.0f, 0.0f);
        private Vector3 cameraUpVector = new Vector3(0.0f, 1.0f, 0.0f);

        // The value of the system tick count when the app is started
        private int tickCount = 0;
        // The number of seconds that the app has been running
        private float appTime;

        // helper used to track fps statistics
        FpsTimerTool fpsTimer;

        // the d3d rendering device and device state
        private Device device;
        private RenderStateManager renderState;

        /// <summary>
        /// Application constructor
        /// </summary>
        public BillboardForm()
        {
            // Set the window text
            this.Text = "Billboard: D3D Billboarding Example";

			this.MinimizeBox = false;

            skyBoxMesh = new GraphicsMesh();
            terrainMesh = new GraphicsMesh();

            OnetimeSceneInitialization();
            // Now let's setup our D3D parameters
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.AutoDepthStencilFormat = DepthFormat.D16;
            presentParams.EnableAutoDepthStencil = true;

            // create the device
            device = new Device(0, DeviceType.Default, this,
                CreateFlags.None, presentParams);
            // store the render state
            renderState = device.RenderState;
            // initialize any device resources that aren't lost on reset
            InitializeDeviceObjects();
            // attach the reset callback
            device.DeviceReset += new EventHandler(RestoreDeviceObjects);
            // initialize any device resources that are lost on reset
            RestoreDeviceObjects(device, EventArgs.Empty);
        }


        /// <summary>
        /// Verifies that the tree at the given position is sufficiently 
        /// spaced from the other trees. If trees are placed too closely,
        /// one tree can quickly pop in front of the other as the camera
        /// angle changes.
        /// </summary>
        /// <returns>true if valid, false otherwise</returns>
        bool IsTreePositionValid(Vector3 pos)
        {
            if (trees.Count < 1)
                return true;

            float x = pos.X;
            float z = pos.Z;

            for (int i=0; i < trees.Count; i++)
            {
                double fDeltaX = Math.Abs(x - ((Tree)trees[i]).Position.X);
                double fDeltaZ = Math.Abs(z - ((Tree)trees[i]).Position.Z);

                // Make sure each tree is at least sqrt(3) units of distance
                // away from any other tree (arbitrary choice based roughly
                // on the size of the tree model)
                if (3.0 > Math.Pow(fDeltaX, 2) + Math.Pow(fDeltaZ, 2))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// The window has been created, but the device has not been created
        /// yet. Here you can perform application-related initialization and
        /// cleanup that does not depend on a device.
        /// </summary>
        public void OnetimeSceneInitialization()
        {
            System.Random rand = new System.Random();
            // Initialize the tree data
            for (int i = 0; i < numberTrees; i++)
            {
                Tree t = new Tree();
                // Position the trees randomly
                do
                {
                    // random orientation between 0 and 2Pi
                    float fTheta  = 2.0f * (float)Math.PI *
                        (float)rand.NextDouble();
                    // Random distance between 25 and 80 units from center
                    // (mostly arbitrary choice based on the size of our
                    // scene)
                    float fRadius = 25.0f + 55.0f * (float)rand.NextDouble();
                    Vector3 position;
                    position.X  = fRadius * (float)Math.Sin(fTheta);
                    position.Z  = fRadius * (float)Math.Cos(fTheta);
                    position.Y  = HeightField(position.X, position.Z);
                    t.Position = position;
                }
                while (!IsTreePositionValid(t.Position));
                

                // Size the trees randomly
                // A random width between 0.8 and 1.2 (size chosen just to
                // scale appropriately with other elements of the scene)
                float fWidth  = 1.0f + 0.2f * 
                    (float)(rand.NextDouble() - rand.NextDouble());
                // A random height between 1 and 1.8 units (size again chosen
                // just to scale appropriately with other elements of the
                // scene)
                float fHeight = 1.4f + 0.4f * 
                    (float)(rand.NextDouble() - rand.NextDouble());

                // Each tree is a random color between an arbitrarily chosen
                // range of red and green
                // Choose an amount of red between 65 and 255
                // (on an absolute scale of 0-255)
                int r = (255 - 190) + (int)(190 * (float)(rand.NextDouble()));
                // Choose an amount of green between 65 and 255
                // (on an absolute scale of 0-255)
                int g = (255 - 190) + (int)(190 * (float)(rand.NextDouble()));
                int b = 0;
                int color = (int)((0xff << 24) + (r << 16) + (g << 8) +
                    (b << 0));


                // set all the render data for this tree
                // Each vertex has its position set, then its color,
                // then texture coordinates
                CustomVertex.PositionColoredTextured v0, v1, v2, v3;
                v0.X = -fWidth;
                v0.Y = 0 * fHeight;
                v0.Z = 0.0f;
                v0.Color = color;
                v0.Tu = 0.0f;
                v0.Tv = 1.0f;
                t.V0 = v0;
                v1.X = -fWidth;
                v1.Y = 2 * fHeight;
                v1.Z = 0.0f;
                v1.Color = color;
                v1.Tu = 0.0f;
                v1.Tv = 0.0f;
                t.V1 = v1;
                v2.X = fWidth;
                v2.Y = 0 * fHeight;
                v2.Z = 0.0f;
                v2.Color = color;
                v2.Tu = 1.0f;
                v2.Tv = 1.0f;
                t.V2 = v2;
                v3.X = fWidth;
                v3.Y = 2 * fHeight;
                v3.Z = 0.0f;
                v3.Color = color;
                v3.Tu = 1.0f;
                v3.Tv = 0.0f;
                t.V3 = v3;

                // Pick a random texture for the tree
                t.TreeTextureIndex = 
                    (int)(treeTextureFileNames.Length * rand.NextDouble());
                trees.Add(t);
            }
        }
        
        /// <summary>
        /// Called once per frame, the call is the entry point for animating
        /// the scene.
        /// </summary>
        public void FrameMove()
        {
            // Get the eye and lookat points from the camera's path
            Vector3 vUpVec = new Vector3(0.0f, 1.0f, 0.0f);
            Vector3 vEyePt = new Vector3();
            Vector3 vLookatPt = new Vector3();

            // orbit a circle 30 units in radius at a speed of 0.8/2Pi
            // revolutions/sec
            vEyePt.X = 30.0f * (float)Math.Cos(0.8f * (appTime));
            vEyePt.Z = 30.0f * (float)Math.Sin(0.8f * (appTime));
            // the camera should remain 4 units above the terrain
            vEyePt.Y = 4 + HeightField(vEyePt.X, vEyePt.Z);

            // the target point should also orbit a 30 unit circle 1/2
            // second in advance of the camera position and 1 unit lower
            vLookatPt.X = 30.0f * (float)Math.Cos(0.8f * (appTime + 0.5f));
            vLookatPt.Z = 30.0f * (float)Math.Sin(0.8f * (appTime + 0.5f));
            vLookatPt.Y = vEyePt.Y - 1.0f;

            // Set the app view matrix appropriately for these view vectors
            device.Transform.View = 
                Matrix.LookAtLH(vEyePt, vLookatPt, vUpVec);

            // Set up a rotation matrix to orient the billboard
            // towards the camera.
            // since we are orbiting in a circle the angle of the camera as
            // compared to world space is atan(z/x). Then we need to rotate
            // the trees 1/4 rotation so that they are perpendicular. Since
            // atan only gives results for -Pi/2 to Pi/2 we have to manually
            // adjust by a factor of Pi depending on which half of the circle
            // the camera is on
            Vector3 vDir = Vector3.Subtract(vLookatPt, vEyePt);
            if (vDir.X > 0.0f)
                billboardMatrix = Matrix.RotationY(
                    (float)(-Math.Atan(vDir.Z / vDir.X) + Math.PI / 2));
            else
                billboardMatrix = Matrix.RotationY(
                    (float)(-Math.Atan(vDir.Z / vDir.X) - Math.PI / 2));
            GlobalDirection = vDir;

            // Sort trees in back-to-front order
            trees.Sort(new TreeSortClass());

            // Store vectors
            cameraEyePoint = vEyePt;
        }

        /// <summary>
        /// Called once per frame, the call is the entry point for 3d
        /// rendering. This function sets up render states, clears the
        /// viewport, and renders the scene.
        /// </summary>
        public void Render()
        {
            fpsTimer.StartFrame();
            device.BeginScene();

            // Clear the viewport to black and set the zbuffer to contain 1.0
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer,
                System.Drawing.Color.Black, 1.0f, 0);

            // Center view matrix for skybox and disable zbuffer
            // the zbuffer is not needed now because the skybox is a large
            // box that will overwrite all of the window
            Matrix matView, matViewSave;
            matViewSave = device.Transform.View;
            matView = matViewSave;

            // This translates the camera down 0.3 units to make sure the
            // sky box is under the terrain
            matView.M41 = 0.0f;
            matView.M42 = -0.3f;
            matView.M43 = 0.0f;
            device.Transform.View = matView;
            device.RenderState.ZBufferEnable = false;
            // Some cards do not disable writing to Z when 
            // D3DRS_ZENABLE is FALSE. So do it explicitly
            device.RenderState.ZBufferWriteEnable = false;

            // Render the skybox
            skyBoxMesh.Render();

            // Restore the render states
            device.Transform.View = matViewSave;
            device.RenderState.ZBufferEnable = true;
            device.RenderState.ZBufferWriteEnable = true;

            // Draw the terrain
            terrainMesh.Render();

            // Draw the trees
            DrawTrees();
            
            // Output statistics
            fpsTimer.Render();

            // End drawing for this scene and flush the frame
            device.EndScene();
            device.Present();

            // stop timing this frame
            fpsTimer.StopFrame();
        }

        /// <summary>
        /// Render the trees in the sample
        /// </summary>
        protected void DrawTrees()
        {
            // Set diffuse blending for alpha set in vertices.
            renderState.AlphaBlendEnable = true;
            renderState.SourceBlend = Blend.SourceAlpha;
            renderState.DestinationBlend = Blend.InvSourceAlpha;

            // Enable alpha testing (skips pixels with less than a certain
            // alpha.) This allows textures which have an alpha component
            // to specify portions of the tree which will be transparent
            if (device.DeviceCaps.AlphaCompareCaps.SupportsGreaterEqual)
            {
                device.RenderState.AlphaTestEnable = true;
                // An arbitrary alpha value between 0 and 255 to use as the
                // translucency cut-off
                device.RenderState.ReferenceAlpha = 0x08;
                device.RenderState.AlphaFunction = Compare.GreaterEqual;
            }

            // set the treeVertexData as the active buffer to draw from
            device.SetStreamSource(0, treeVertexBuffer, 0);

            // Loop through and render all trees
            foreach(Tree t in trees)
            {
                // Quick culling for trees behind the camera
                // This calculates the tree position relative to the camera,
                // and projects that vector against the camera's direction
                // vector. A negative dot product indicates a non-visible
                // tree.

                if ((t.Position.X - cameraEyePoint.X) * GlobalDirection.X + 
                    (t.Position.Z - cameraEyePoint.Z) * GlobalDirection.Z < 0)
                    break;

                // Set the tree texture
                device.SetTexture(0, treeTextures[t.TreeTextureIndex]);

                // Translate the billboard into place
                billboardMatrix.M41 = t.Position.X;
                billboardMatrix.M42 = t.Position.Y;
                billboardMatrix.M43 = t.Position.Z;
                device.Transform.World = billboardMatrix;

                // Render the billboard
                // Each tree consists of 2 triangles
                device.DrawPrimitives(PrimitiveType.TriangleStrip,
                    t.OffsetIndex, 2);
            }

            // Restore to previous state
            device.Transform.World = Matrix.Identity;
            device.RenderState.AlphaTestEnable = false;
            device.RenderState.AlphaBlendEnable = false;
        }
        
        /// <summary>
        /// The device has been created.  Resources that are not lost on
        /// Reset() can be created here.
        /// </summary>
        public void InitializeDeviceObjects()
        {
            // Load the skybox        
            skyBoxMesh.Create(device, "Billboard.Content.", "skybox2.md3dm",
                System.Reflection.Assembly.GetExecutingAssembly());

            // Load the terrain
            terrainMesh.Create(device, "Billboard.Content.", "seafloor.md3dm",
                System.Reflection.Assembly.GetExecutingAssembly());

            // create the timer
            fpsTimer = new FpsTimerTool(device);
        }
        
        /// <summary>
        /// Fill the trees vertex buffer
        /// </summary>
        void CreateTreeData(object sender, EventArgs e)
        {
            VertexBuffer vb = (VertexBuffer)sender;
    
            //Each tree has 4 vertices
            CustomVertex.PositionColoredTextured[] v = 
                new CustomVertex.PositionColoredTextured[numberTrees * 4];

            // Load the vertex data for each tree into a large vertex buffer
            int iTree;
            int offsetIndex = 0;
            for (iTree = 0; iTree < numberTrees; iTree++)
            {
                v[offsetIndex+0] = ((Tree)trees[iTree]).V0;
                v[offsetIndex+1] = ((Tree)trees[iTree]).V1;
                v[offsetIndex+2] = ((Tree)trees[iTree]).V2;
                v[offsetIndex+3] = ((Tree)trees[iTree]).V3;
                Tree t = (Tree)trees[iTree];
                t.OffsetIndex = offsetIndex;
                trees[iTree] = t;
                offsetIndex += 4;
            }
            vb.SetData(v, 0, 0);
        }

        /// <summary>
        /// The device exists, but may have just been Reset().  Resources
        /// and any other device state that persists during
        /// rendering should be set here.  Render states, matrices, textures,
        /// etc., that don't change during rendering can be set once here to
        /// avoid redundant state setting during Render() or FrameMove().
        /// </summary>
        void RestoreDeviceObjects(
            System.Object sender, System.EventArgs e)
        {
            // Create the tree textures
            Assembly asm = Assembly.GetExecutingAssembly();
            for (int i=0; i<treeTextureFileNames.Length; i++)
            {
                treeTextures[i] = TextureLoader.FromStream(device, 
                    asm.GetManifestResourceStream(
					"Billboard.Content." + treeTextureFileNames[i])); 
            }

            // This function could be called before the buffer is created
            // or after it is destroyed... check for that
            if ((treeVertexBuffer == null) || (treeVertexBuffer.Disposed))
            {
                Pool vertexBufferPool;
                Caps caps;

                // Get the device capabilities

                caps = device.DeviceCaps;

                if (caps.SurfaceCaps.SupportsVidVertexBuffer)
                    vertexBufferPool = Pool.VideoMemory;
                else
                    vertexBufferPool = Pool.SystemMemory;

                // Create a quad for rendering each tree
                treeVertexBuffer = new VertexBuffer(
                    typeof(CustomVertex.PositionColoredTextured),
                    numberTrees*4, device, Usage.WriteOnly,
                    CustomVertex.PositionColoredTextured.Format,
                    vertexBufferPool);

                treeVertexBuffer.Created += 
                    new System.EventHandler(this.CreateTreeData);
                this.CreateTreeData(treeVertexBuffer, null);
            }

            // Restore the device objects for the meshes and fonts
            terrainMesh.RestoreDeviceObjects(device, null);
            skyBoxMesh.RestoreDeviceObjects(device, null);

            // Add some "hilliness" to the terrain
            VertexBuffer tempVertexBuffer;
            tempVertexBuffer = terrainMesh.Mesh.VertexBuffer;
            CustomVertex.PositionTextured[] pVertices;
            int numberVertices = terrainMesh.Mesh.NumberVertices;
            pVertices = (CustomVertex.PositionTextured[])
                tempVertexBuffer.Lock(0, 
                typeof(CustomVertex.PositionTextured), 0, numberVertices);
            for (int i=0; i<numberVertices; i++)
                pVertices[i].Y = HeightField(pVertices[i].X, pVertices[i].Z);
            tempVertexBuffer.Unlock();


            // Set the transform matrices (view and world are updated per
            // frame)

            Matrix matProj;
            // create a perspective view with aspect ratio 1:1,
            // field of view as Pi/4 and near/far clipping planes at 1 and 100
            float fAspect = 1.0f;
            matProj = Matrix.PerspectiveFovLH((float)Math.PI / 4,
                fAspect, 1.0f, 100.0f);
            device.Transform.Projection = matProj;

            // Set up the default texture states
            device.TextureState[0].ColorOperation =
                TextureOperation.Modulate;
            device.TextureState[0].ColorArgument1 =
                TextureArgument.TextureColor;
            device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
            device.TextureState[0].AlphaOperation =
                TextureOperation.SelectArg1;
            device.TextureState[0].AlphaArgument1 =
                TextureArgument.TextureColor;
            device.TextureState[0].MinFilter = TextureFilter.Linear;
            device.TextureState[0].MagFilter = TextureFilter.Linear;
            device.TextureState[0].MipFilter = TextureFilter.Linear;
            device.TextureState[0].AddressU = TextureAddress.Clamp;
            device.TextureState[0].AddressV = TextureAddress.Clamp;

            device.RenderState.DitherEnable = true;
            device.RenderState.ZBufferEnable = true;
            device.RenderState.Lighting = false;

            // Turn on perspective correction for textures
            // This provides a more accurate visual at the cost
            // of a small performance overhead
            device.RenderState.TexturePerspective = true;
        }

        /// <summary>
        /// Simple function to define "hilliness" for terrain
        /// </summary>
        float HeightField(float x, float y)
        {
            // This is a 2 dimensional function that describes a
            // surface which looks like hills.
            return 9 * ((float)Math.Cos(x / 20+0.2f) * 
                (float)Math.Cos(y / 15 - 0.2f) + 1.0f);
        }

        /// <summary>
        /// Called when the window needs to repaint itself
        /// </summary>
        /// <param name="e">Ignored</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (tickCount == 0)
                tickCount = Environment.TickCount - 1;

            appTime = ((float)(Environment.TickCount - tickCount)) / 1000.0f;
            this.FrameMove();

             // Render on painting
            this.Render();

             // Render again
            this.Invalidate();
        }

        /// <summary>
        /// Called when the window needs to repaint the background
        /// </summary>
        /// <param name="e">Ignored</param>
        protected override void OnPaintBackground(
            System.Windows.Forms.PaintEventArgs e)
        {
            // Do nothing so that the rendered area is not overdrawn
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main() 
        {
            try
            {
                BillboardForm d3dApp = new BillboardForm();
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
                MessageBox.Show("The sample has run into an error and " +
                    "needs to close: " + e.Message);
            }
        }
    }

    /// <summary>
    /// A class to sort our trees in back-to-front order
    /// </summary>
    public class TreeSortClass : System.Collections.IComparer
    {
        /// <summary>
        /// Compare two trees
        /// </summary>
        public int Compare(object left, object right)
        {
            Tree l = (Tree)left;
            Tree r = (Tree)right;

            float d1 = l.Position.X * BillboardForm.GlobalDirection.X + 
                l.Position.Z * BillboardForm.GlobalDirection.Z;
            float d2 = r.Position.X * BillboardForm.GlobalDirection.X + 
                r.Position.Z * BillboardForm.GlobalDirection.Z;

            if (d1 == d2)
                return 0;

            if (d1 < d2)
                return +1;

            return -1;
        }
    }
}
