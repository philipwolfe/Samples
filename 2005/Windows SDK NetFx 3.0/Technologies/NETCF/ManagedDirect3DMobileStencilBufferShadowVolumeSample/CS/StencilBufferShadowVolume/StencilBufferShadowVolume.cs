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
using System.Diagnostics;


namespace Microsoft.Samples.MD3DM
{
    public class ShadowVolumeSample : Form
    {
        /// <summary>
        /// Custom vertex types
        /// </summary>
        struct MeshVertex
        {
            // vertex location
            Vector3 pointValue;
            public Vector3 Point
            {
                get { return pointValue; }
                set { pointValue = value; }
            }

            // vertex normal
            Vector3 normalValue;
            public Vector3 Normal
            {
                get { return normalValue; }
                set { normalValue = value; }
            }

            // vertex texture coordinates
            float textureUValue, textureVValue;
            public float TextureU
            {
                get { return textureUValue; }
                set { textureUValue = value; }
            }
            public float TextureV
            {
                get { return textureVValue; }
                set { textureVValue = value; }
            }

            public static readonly VertexFormats Format =
                VertexFormats.Position | VertexFormats.Normal |
                VertexFormats.Texture1;
        };

        struct ShadowVertex
        {
            Vector4 pointValue;
            public Vector4 Point
            {
                get { return pointValue; }
                set { pointValue = value; }
            }

            int colorValue;
            public int Color
            {
                get { return colorValue; }
                set { colorValue = value; }
            }

            public static readonly VertexFormats Format =
                VertexFormats.Transformed | VertexFormats.Diffuse;
        };


        // Font for drawing text
        private Font font = null;

        // the airplane mesh
        private GraphicsMesh airplane = new GraphicsMesh();
 
        // The terrain
        private GraphicsMesh terrainObject = new GraphicsMesh();

        // The shadow volume object
        private ShadowVolume shadowVolume = new ShadowVolume(); 

        // The matrices for the objects
        private Matrix objectMatrix; 
        private Matrix terrainMatrix;

        // The vertex buffer
        private VertexBuffer squareVertexBuffer = null; 

        // The color for the fog
        private readonly System.Drawing.Color fogColor =
            System.Drawing.Color.DeepSkyBlue;

        // The rendering device
        private Device device = null;
        

        /// <summary>
        /// Application constructor.
        /// </summary>
        public ShadowVolumeSample()
        {
            // Set the window text
            this.Text = 
                "ShadowVolume: RealTime Shadows Using The StencilBuffer";

            // Now let's setup our D3D parameters
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.AutoDepthStencilFormat = DepthFormat.D24X4S4;
            presentParams.EnableAutoDepthStencil = true;
            device = new Device(0, DeviceType.Default, this,
                CreateFlags.None, presentParams);

            InitializeDeviceObjects();
            device.DeviceReset += new EventHandler(RestoreDeviceObjects);
            RestoreDeviceObjects(device, EventArgs.Empty);
        }

        /// <summary>
        /// Called once per frame, the call is the entry point for
        /// animating the scene.
        /// </summary>
        public void FrameMove()
        {
            // Position the terrain
            terrainMatrix = Matrix.Translation(0.0f, 0.0f, 0.0f);

            objectMatrix = Matrix.Identity;

            // Move the light
            float x = 5;
            float y = 5;
            float z = -5;
            device.Lights[0].Position = new Vector3(x, y, z);
            device.Lights[0].Update();

            // Transform the light vector to be in object space
            Vector3 vLight = new Vector3();
            Matrix m = Matrix.Invert(objectMatrix);
            vLight.X = x*m.M11 + y*m.M21 + z*m.M31 + m.M41;
            vLight.Y = x*m.M12 + y*m.M22 + z*m.M32 + m.M42;
            vLight.Z = x*m.M13 + y*m.M23 + z*m.M33 + m.M43;

            // Build the shadow volume
            shadowVolume.Reset();
            shadowVolume.BuildFromMesh(airplane.Mesh, vLight);
        }

        /// <summary>
        /// Render the shadow
        /// </summary>
        public void RenderShadow()
        {
            // Disable z-buffer writes (note: z-testing still occurs),
            // and enable the stencil-buffer
            device.RenderState.ZBufferWriteEnable = false;
            device.RenderState.StencilEnable = true;

            // Dont bother with interpolating color
            device.RenderState.ShadeMode = ShadeMode.Flat;

            // Set up stencil compare fuction, reference value, and masks.
            // Stencil test passes if ((ref & mask) cmpfn (stencil & mask))
            // is true. Note: since we set up the stencil-test to always
            // pass, the STENCILFAIL renderstate is really not needed.
            device.RenderState.StencilFunction = Compare.Always;
            device.RenderState.StencilZBufferFail = StencilOperation.Keep;
            device.RenderState.StencilFail = StencilOperation.Keep;

            // If ztest passes, inc/decrement stencil buffer value
            device.RenderState.ReferenceStencil = 0x1;
            device.RenderState.StencilMask = unchecked((int)0xffffffff);
            device.RenderState.StencilWriteMask = unchecked((int)0xffffffff);
            device.RenderState.StencilPass = StencilOperation.Increment;

            // Make sure that no pixels get drawn to the frame buffer
            device.RenderState.AlphaBlendEnable = true;
            device.RenderState.SourceBlend = Blend.Zero;
            device.RenderState.DestinationBlend = Blend.One;

            // Draw front-side of shadow volume in stencil/z only
            device.Transform.World = objectMatrix;
            shadowVolume.Render(device);

            // Now reverse cull order so back sides of shadow volume
            // are written.
            device.RenderState.CullMode = Cull.Clockwise;

            // Decrement stencil buffer value
            device.RenderState.StencilPass = StencilOperation.Decrement;

            // Draw back-side of shadow volume in stencil/z only
            device.Transform.World = objectMatrix;
            shadowVolume.Render(device);

            // Restore render states
            device.RenderState.ShadeMode = ShadeMode.Gouraud;
            device.RenderState.CullMode = Cull.CounterClockwise;
            device.RenderState.ZBufferWriteEnable = true;
            device.RenderState.StencilEnable = false;
            device.RenderState.AlphaBlendEnable = false;
        }

        /// <summary>
        /// Draws a big gray polygon over scene according to the mask in the 
        /// stencil buffer. (Any pixel with stencil==1 is in the shadow.)
        /// </summary>
        public void DrawShadow()
        {
            // Set renderstates (disable z-buffering, enable stencil,
            // disable fog, and turn on alphablending)
            device.RenderState.ZBufferEnable = false;
            device.RenderState.StencilEnable = true;
            device.RenderState.FogEnable = false;
            device.RenderState.AlphaBlendEnable = true;
            device.RenderState.SourceBlend = Blend.SourceAlpha;
            device.RenderState.DestinationBlend = Blend.InvSourceAlpha;

            device.TextureState[0].ColorArgument1 =
                TextureArgument.TextureColor;
            device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
            device.TextureState[0].ColorOperation = TextureOperation.Modulate;
            device.TextureState[0].AlphaArgument1 =
                TextureArgument.TextureColor;
            device.TextureState[0].AlphaArgument2 = TextureArgument.Diffuse;
            device.TextureState[0].AlphaOperation = TextureOperation.Modulate;

            // Only write where stencil val >= 1 
            // (count indicates # of shadows that overlap that pixel)
            device.RenderState.ReferenceStencil = 0x1;
            device.RenderState.StencilFunction = Compare.LessEqual;
            device.RenderState.StencilPass = StencilOperation.Keep;

            // Draw a big, gray square
            device.SetStreamSource(0, squareVertexBuffer, 0);
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);

            // Restore render states
            device.RenderState.ZBufferEnable = true;
            device.RenderState.StencilEnable = false;
            device.RenderState.FogEnable = true;
            device.RenderState.AlphaBlendEnable = false;
        }
        
        /// <summary>
        /// Called once per frame, the call is the entry point for 3d
        /// rendering. This function sets up render states, clears the 
        /// viewport, and renders the scene.
        /// </summary>
        public void Render()
        {
            // Clear the viewport
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer |
                ClearFlags.Stencil, fogColor, 1.0f, 0);

            device.BeginScene();

            device.Transform.World = terrainMatrix;
            terrainObject.Render();

            device.Transform.World = objectMatrix;
            airplane.Render(true, false);

            // Render the shadow volume into the stenicl buffer, then add
            // it into the scene
            RenderShadow();
            DrawShadow();

            device.EndScene();
            device.Present();
        }

        /// <summary>
        /// The device has been created.  Resources that are not lost on
        /// Reset() can be created here
        /// </summary>
        public void InitializeDeviceObjects()
        {
            Pool vertexBufferPool;
            Caps caps;

            // Initialize the font's internal textures
            font = new Font(device, new System.Drawing.Font("Arial",
                12.0f, System.Drawing.FontStyle.Bold));

            // Load the main file object
            if (airplane == null)
                airplane = new GraphicsMesh();

			airplane.Create(device, 
				"StencilBufferShadowVolume.Content.", "air2.md3dm",
                System.Reflection.Assembly.GetExecutingAssembly());

            // Load the terrain
            if (terrainObject == null)
                terrainObject = new GraphicsMesh();

            terrainObject.Create(device, 
				"StencilBufferShadowVolume.Content.", "seafloor.md3dm",
                System.Reflection.Assembly.GetExecutingAssembly());

            // Set a reasonable vertex type
            terrainObject.SetVertexFormat(MeshVertex.Format);
            airplane.SetVertexFormat(MeshVertex.Format);

            // Get the device capabilities

            caps = device.DeviceCaps;

            if (caps.SurfaceCaps.SupportsVidVertexBuffer)
                vertexBufferPool = Pool.VideoMemory;
            else
                vertexBufferPool = Pool.SystemMemory;

            // Create a big square for rendering the mirror, we don't
            // need to recreate this every time, if the VertexBuffer
            // is destroyed (by a call to Reset for example), it will
            // automatically be recreated and the 'Created' event fired.
            squareVertexBuffer = new VertexBuffer(typeof(ShadowVertex), 4, 
                device, Usage.WriteOnly, ShadowVertex.Format,
                vertexBufferPool);
            squareVertexBuffer.Created += new System.EventHandler(
                this.ShadowCreated);

            // Manually fire the created event the first time
            this.ShadowCreated(squareVertexBuffer, null);
        }

        /// <summary>
        /// Handles the vertex buffer created for the shadow
        /// </summary>
        private void ShadowCreated(object sender, EventArgs e)
        {
            VertexBuffer vb = (VertexBuffer)sender;
            ShadowVertex[] v = (ShadowVertex[])vb.Lock(0, 0);
            float xpos = (float)device.PresentationParameters.BackBufferWidth;
            float ypos = 
                (float)device.PresentationParameters.BackBufferHeight;
            v[0].Point = new Vector4(0, ypos, 0.0f, 1.0f);
            v[1].Point = new Vector4(0,  0, 0.0f, 1.0f);
            v[2].Point = new Vector4(xpos, ypos, 0.0f, 1.0f);
            v[3].Point = new Vector4(xpos,  0, 0.0f, 1.0f);
            v[0].Color = 0x7f000000;
            v[1].Color = 0x7f000000;
            v[2].Color = 0x7f000000;
            v[3].Color = 0x7f000000;
            vb.Unlock();
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
            airplane.RestoreDeviceObjects(device , null);
            terrainObject.RestoreDeviceObjects(device , null);

            // Tweak the terrain vertices to add some bumpy terrain
            if (terrainObject != null)
            {
                // Get access to the mesh vertices
                VertexBuffer vertBuffer = null;
                MeshVertex[] vertices = null;
                int numVertices = terrainObject.Mesh.NumberVertices;
                vertBuffer  = terrainObject.Mesh.VertexBuffer;
                vertices = (MeshVertex[])vertBuffer.Lock(0,
                    typeof(MeshVertex), 0, numVertices);

                Random r = new Random();
                // Add some more bumpiness to the terrain object
                for (int i=0; i<numVertices; i++)
                {
                    Vector3 p = vertices[i].Point;
                    p.Y += 1*(float)r.NextDouble();
                    p.Y += 2*(float)r.NextDouble();
                    p.Y += 1*(float)r.NextDouble();
                    vertices[i].Point = p;
                }

                vertBuffer.Unlock();
                vertBuffer.Dispose();
            }

            // Create and set up the shine materials w/ textures
            Material mtrl = new Material();
            mtrl.Ambient = mtrl.Diffuse = System.Drawing.Color.White;

            // Set up textures
            device.TextureState[0].ColorArgument1 =
                TextureArgument.TextureColor;
            device.TextureState[0].ColorArgument2 = TextureArgument.Diffuse;
            device.TextureState[0].ColorOperation = TextureOperation.Modulate;
            device.TextureState[0].MinFilter = TextureFilter.Linear;
            device.TextureState[0].MagFilter = TextureFilter.Linear;

            // Set up misc render states
            device.RenderState.ZBufferEnable = true;
            device.RenderState.DitherEnable = true;
            device.RenderState.SpecularEnable = false;

            // Set the transform matrices
            Vector3 vEyePt    = new Vector3(0.0f, 10.0f, -20.0f);
            Vector3 vLookatPt = new Vector3(0.0f, 0.0f,   0.0f);
            Vector3 vUpVec    = new Vector3(0.0f, 1.0f,   0.0f);
            Matrix matWorld, matView, matProj;

            matWorld = Matrix.Identity;
            matView = Matrix.LookAtLH(vEyePt, vLookatPt, vUpVec);
            float fAspect = device.PresentationParameters.BackBufferWidth / 
                (float)device.PresentationParameters.BackBufferHeight;
            matProj = Matrix.PerspectiveFovLH((float)Math.PI/4, fAspect,
                1.0f, 1000.0f);

            device.Transform.World = matWorld;
            device.Transform.View = matView;
            device.Transform.Projection = matProj;

            // Turn on fog
            float fFogStart =  30.0f;
            float fFogEnd   = 80.0f;
            device.RenderState.FogEnable = true ;
            device.RenderState.FogColor = fogColor;
            device.RenderState.FogTableMode = FogMode.None;
            device.RenderState.FogVertexMode = FogMode.Linear;
            device.RenderState.RangeFogEnable = false;
            device.RenderState.FogStart = fFogStart;
            device.RenderState.FogEnd = fFogEnd;

            device.Lights[0].Type = LightType.Point;
            device.Lights[0].Ambient = System.Drawing.Color.White;
            device.Lights[0].Diffuse = System.Drawing.Color.White;
            device.Lights[0].Range = 1000.0f;
            device.Lights[0].Attenuation0 = 0.9f;
            device.Lights[0].Attenuation1 = 0.0f;
            device.Lights[0].Enabled = true;
            device.RenderState.Lighting = true;
            device.RenderState.Ambient = 
                System.Drawing.Color.FromArgb(0x00303030);

            // Turn on perspective correction for textures
            // This provides a more accurate visual at the cost
            // of a small performance overhead
            device.RenderState.TexturePerspective = true;
        }

        /// <summary>
        /// Called when the window is repainted
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            this.FrameMove();

            // Render on painting
            this.Render(); 

            // Render again
            this.Invalidate(); 
        }

        /// <summary>
        /// Called when the window background is repainted
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
                ShadowVolumeSample d3dApp = new ShadowVolumeSample();
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

    /// <summary>
    /// A shadow volume object
    /// </summary>
    public class ShadowVolume
    {
        /// <summary>
        /// Custom vertex types
        /// </summary>
        /// <summary>
        /// Custom vertex types
        /// </summary>
        struct MeshVertex
        {
            // vertex location
            Vector3 pointValue;
            public Vector3 Point
            {
                get { return pointValue; }
                set { pointValue = value; }
            }

            // vertex normal
            Vector3 normalValue;
            public Vector3 Normal
            {
                get { return normalValue; }
                set { normalValue = value; }
            }

            // vertex texture coordinates
            float textureUValue, textureVValue;
            public float TextureU
            {
                get { return textureUValue; }
                set { textureUValue = value; }
            }
            public float TextureV
            {
                get { return textureVValue; }
                set { textureVValue = value; }
            }
        };

        /// <summary>
        /// Class member variables
        /// </summary>
        Vector3[] vertices = new Vector3[32000];
        VertexBuffer vb = null;
        int numVertices = 0;

        /// <summary>
        /// Reset the shadow volume
        /// </summary>
        public void Reset()
        {
            numVertices = 0;
        }

        /// <summary>
        /// Render the shadow volume
        /// </summary>
        public void Render(Device device)
        {
            device.SetStreamSource(0, vb, 0);
            device.DrawPrimitives(PrimitiveType.TriangleList, 0,
                numVertices / 3);
        }

        /// <summary>
        /// Takes a mesh as input, and uses it to build a shadowvolume. The
        //  technique used considers each triangle of the mesh, and adds it's
        //  edges to a temporary list. The edge list is maintained, such that
        //  only silohuette edges are kept. Finally, the silohuette edges are
        //  extruded to make the shadow volume vertex list.
        /// </summary>
        public void BuildFromMesh(Mesh mesh, Vector3 light)
        {
            // Note: the MeshVertex format depends on the FVF of the mesh
    
            MeshVertex[] tempVertices = null;
            short[] indices = null;
            short[] edges = null;

            if (vb == null)
            {
                vb = new VertexBuffer(typeof(Vector3), 32000,
                    mesh.Device, Usage.WriteOnly, VertexFormats.Position,
                    Pool.SystemMemory);
            }

            int numFaces = mesh.NumberFaces;
            int numVerts = mesh.NumberVertices;
            int numberEdges = 0;

            // Allocate a temporary edge list
            edges = new short[numFaces * 6];

            // Lock the geometry buffers
            tempVertices =  (MeshVertex[])mesh.VertexBuffer.Lock(0,
                typeof(MeshVertex), 0, numVerts);
            indices = (short[])mesh.IndexBuffer.Lock(0,
                typeof(short), 0, numFaces * 3);

            // For each face
            for (int i=0; i<numFaces; i++)
            {
                short face0 = indices[3*i+0];
                short face1 = indices[3*i+1];
                short face2 = indices[3*i+2];
                Vector3 v0 = tempVertices[face0].Point;
                Vector3 v1 = tempVertices[face1].Point;
                Vector3 v2 = tempVertices[face2].Point;

                // Transform vertices or transform light?
                Vector3 vCross1 = v2 - v1;
                Vector3 vCross2 = v1 - v0;
                Vector3 vNormal = Vector3.Cross(vCross1, vCross2);

                if (Vector3.Dot(vNormal, light) >= 0.0f)
                {
                    AddEdge(edges, ref numberEdges, face0, face1);
                    AddEdge(edges, ref numberEdges, face1, face2);
                    AddEdge(edges, ref numberEdges, face2, face0);
                }
            }

            for (int i=0; i<numberEdges; i++)
            {
                Vector3 v1 = tempVertices[edges[2*i+0]].Point;
                Vector3 v2 = tempVertices[edges[2*i+1]].Point;
                Vector3 v3 = v1 - light*10;
                Vector3 v4 = v2 - light*10;

                // Add a quad (two triangles) to the vertex list
                vertices[numVertices++] = v1;
                vertices[numVertices++] = v2;
                vertices[numVertices++] = v3;

                vertices[numVertices++] = v2;
                vertices[numVertices++] = v4;
                vertices[numVertices++] = v3;
            }

            // Unlock the geometry buffers
            mesh.VertexBuffer.Unlock();
            mesh.IndexBuffer.Unlock();

            vb.SetData(vertices, 0, LockFlags.None);
        }

        /// <summary>
        /// Adds an edge to a list of silohuette edges of a shadow volume.
        /// </summary>
        public void AddEdge(short[] edges, ref int numberEdges,
            short v0, short v1)
        {
            // Remove interior edges (which appear in the list twice)
            for (int i=0; i < numberEdges; i++)
            {
                if ((edges[2*i+0] == v0 && edges[2*i+1] == v1) ||
                    (edges[2*i+0] == v1 && edges[2*i+1] == v0))
                {
                    if (numberEdges > 1)
                    {
                        edges[2*i+0] = edges[2*(numberEdges-1)+0];
                        edges[2*i+1] = edges[2*(numberEdges-1)+1];
                    }
                    numberEdges--;
                    return;
                }
            }
            edges[2*numberEdges+0] = v0;
            edges[2*numberEdges+1] = v1;
            numberEdges++;
        }
    }
}
