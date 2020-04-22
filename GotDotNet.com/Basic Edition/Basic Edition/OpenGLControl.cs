//=============================================================
// C# OpenGL Framework
// Copyright (c) 2005-2006 devDept.com
// All rights reserved.
//
// For more information on this program, please visit: 
// http://www.csharpopenglframework.com
//
// For licensing information, please visit: 
// http://www.csharpopenglframework.com/licensing.html
//=============================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OpenGL;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Collections;
using System.Globalization;
using System.Diagnostics;

namespace openglFramework
{

    public partial class OpenGLControl : UserControl
    {

        protected Context renderingContext;

        public ArrayList entities = new ArrayList();
        public ArrayList labels   = new ArrayList();

        // Focus
        protected bool hasFocus = false;

        // Model extents
        protected float[] globalMin = new float[3];
        protected float[] globalMax = new float[3];

        // Model size
        protected float xSize;
        protected float ySize;
        protected float zSize;

        protected static float openglVersion;
        protected int stencilBits;
        protected bool lighting;

        // bounding rectangle (parallel projection)
        protected float globalLeft;
        protected float globalBottom;
        protected float globalRight;
        protected float globalTop;

        // true zooming TM
        protected RectangleF viewportRect, prevZoomRect, zoomRect;

        // Textures
        protected uint[] textureNames;

        public OpenGLControl()
        {

            InitializeStyles();
            InitializeComponent();


            // Background
            backgroundTopColor      = Color.FromArgb(0xff, 0x9e, 0x9b, 0x92);
            backgroundBottomColor   = Color.FromArgb(0xff, 0xe3, 0xe1, 0xd4);


            #region OpenGL

            renderingContext    = new Context(this, 32, 16, 8);
            
            OpenGLSetup();

            FontMapping(1.0f, this.CreateGraphics().GetHdc());

            int[] stencil = new int[1];
            gl.GetIntegerv(gl.STENCIL_BITS, stencil);

            stencilBits = stencil[0];

            #endregion


            // Cursors
            rotateCursor = new Cursor(GetType(), "Cursors.rotate.cur");


            // Labels
            xUcsLabel           = new Label("X");
            yUcsLabel           = new Label("Y");
            zUcsLabel           = new Label("Z");
            originLabel         = new Label("Origin");
            


            // ZPR
            cameraQuat          = new Quaternion(0, 0, 0, 1.0f);

        }

        #region Properties

        public shadingType ShadingMode
        {
            get { return renderMode; }
            set {

                renderMode = value;

                Invalidate();
            
                }
        }

        public projectionType ProjectionMode
        {
            get { return projectionMode; }
            set {
                projectionMode = value;
                ZoomFit();
            }
        }

        public float ModelWidth
        {
            get { return xSize; }
        }
        public float ModelDepth
        {
            get { return ySize; }
        }
        public float ModelHeight
        {
            get { return zSize; }
        }

        [CategoryAttribute("Lighting")]
        public float[] AmbientLight
        {
            get { return ambientLight; }
            set
            {
                ambientLight = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Lighting")]
        public float[] MainLightDiffuse
        {
            get { return mainLightDiffuse; }
            set
            {
                mainLightDiffuse = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Lighting")]
        public float[] SideLightDiffuse
        {
            get { return sideLightDiffuse; }
            set
            {
                sideLightDiffuse = value;
                Invalidate();

            }
        }

        #endregion

        #region Events

        protected override void OnPaint(PaintEventArgs e)
        {

            if (this.DesignMode)
            {

                e.Graphics.Clear(this.BackColor);

                e.Graphics.Flush();

                return;

            }

            if (renderingContext.DC == 0 || renderingContext.RC == 0)
            {
             
                MessageBox.Show("No device or rendering context available!");
                return;

            }

            base.OnPaint(e);

            int errorCode = gl.NO_ERROR;                             // The GL error code

            errorCode = gl.GetError();

            if (errorCode != gl.NO_ERROR)
            {
                switch (errorCode)
                {
                    case gl.INVALID_ENUM:
                        MessageBox.Show("GL_INVALID_ENUM - An unacceptable value has been specified for an enumerated argument.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.INVALID_VALUE:
                        MessageBox.Show("GL_INVALID_VALUE - A numeric argument is out of range.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.INVALID_OPERATION:
                        MessageBox.Show("GL_INVALID_OPERATION - The specified operation is not allowed in the current state.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.STACK_OVERFLOW:
                        MessageBox.Show("GL_STACK_OVERFLOW - This function would cause a stack overflow.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.STACK_UNDERFLOW:
                        MessageBox.Show("GL_STACK_UNDERFLOW - This function would cause a stack underflow.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.OUT_OF_MEMORY:
                        MessageBox.Show("GL_OUT_OF_MEMORY - There is not enough memory left to execute the function.  The state of OpenGL has been left undefined.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default:
                        MessageBox.Show("Unknown GL error.  This should never happen.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }

            }
            
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        #endregion

        #region Setup

        protected virtual void OpenGLSetup()
        {

            gl.ClearColor(1, 1, 1, 1); 
            gl.ShadeModel(gl.SMOOTH);
            gl.FrontFace(gl.CCW);

            gl.LightModeli(gl.LIGHT_MODEL_TWO_SIDE, gl.TRUE);
            gl.LightModeli(gl.LIGHT_MODEL_LOCAL_VIEWER, gl.TRUE);

            // Setup and enable main light
            gl.Lightfv(gl.LIGHT0,  gl.AMBIENT, ambientLight);
            gl.Lightfv(gl.LIGHT0,  gl.DIFFUSE, mainLightDiffuse);
            gl.Lightfv(gl.LIGHT0, gl.SPECULAR, specular);
            gl.Lightfv(gl.LIGHT0, gl.POSITION, mainLightPos);
            gl.Enable( gl.LIGHT0);

            // Setup and enable side light
            gl.Lightfv(gl.LIGHT1,  gl.AMBIENT, ambientLight);
            gl.Lightfv(gl.LIGHT1,  gl.DIFFUSE, sideLightDiffuse);
            gl.Lightfv(gl.LIGHT1, gl.SPECULAR, specular);
            gl.Lightfv(gl.LIGHT1, gl.POSITION, sideLightPos);
            gl.Enable( gl.LIGHT1);

            // All materials hereafter have full specular reflectivity
            // with a moderated shine
            gl.Materialfv(gl.FRONT_AND_BACK, gl.SPECULAR, specref);
            gl.Materiali(gl.FRONT_AND_BACK, gl.SHININESS, 32);

            // Set Material properties to follow glColor values
            gl.ColorMaterial(gl.FRONT_AND_BACK, gl.AMBIENT_AND_DIFFUSE);

            quadric = glu.NewQuadric();

            glu.QuadricDrawStyle(quadric, glu.FILL);
            glu.QuadricNormals(quadric, gl.SMOOTH);
            glu.QuadricTexture(quadric, gl.TRUE);

        }


        #region dllimports

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        #endregion

        protected void FontMapping(float scale, IntPtr hDC)
        {

            Font font = new Font("Tahoma", 8.25f * scale);

            SelectObject(hDC, font.ToHfont());

            if (wgl.UseFontBitmaps(hDC, 0, 255, 1000) == false)

                Debug.WriteLine("wglUseFontBitmaps failed: font");

            Font boldFont = new Font("Tahoma", 8.25f * scale, FontStyle.Bold);

            SelectObject(hDC, boldFont.ToHfont());

            if (wgl.UseFontBitmaps(hDC, 0, 255, 2000) == false)

                Debug.WriteLine("wglUseFontBitmaps failed: boldFont");

            Font welcomeFont = new Font("Georgia", 14.0f * scale, FontStyle.Bold);

            SelectObject(hDC, welcomeFont.ToHfont());

            if (wgl.UseFontBitmaps(hDC, 0, 255, 3000) == false)

                Debug.WriteLine("wglUseFontBitmaps failed: welcomeFont");

        }

        protected void ViewportSetup(int width, int height)
        {

            // avoid division by zero
            if (height == 0)

                height = 1;

            // Set Viewport to window dimensions
            gl.Viewport(0, 0, width, height);

            // Get OpenGL Viewport
            int[] viewport = new int[4];
            gl.GetIntegerv(gl.VIEWPORT, viewport);

            viewportRect.X      = viewport[0];
            viewportRect.Y      = viewport[1];
            viewportRect.Width  = viewport[2];
            viewportRect.Height = viewport[3];

            viewportAspect = (float) width / (float) height;

        }

        protected void SceneSetup2D(float zNear, float zFar)
        {

            gl.Enable(gl.LIGHT0);
            gl.Enable(gl.LIGHT1);

            gl.MatrixMode(gl.PROJECTION);
            gl.LoadIdentity();

            gl.Ortho(0, this.Width, 0, this.Height, zNear, zFar);

        }

        protected void SceneSetupOrtho3D()
        {

            gl.Ortho(-this.Width / 2, this.Width / 2,
                -this.Height / 2, this.Height / 2, zNearOrtho, zFarOrtho);

        }

        protected void SceneSetupPerispective3D()
        {

            glu.Perspective(60, viewportAspect, zNearPerspective, zFarPerspective);
    
        }

        protected void ApplyZoom()
        {
            
            float widthScale  = viewportRect.Width  / zoomRect.Width;
            float heightScale = viewportRect.Height / zoomRect.Height;

            if (widthScale < heightScale)
            {

                float prevHeight = zoomRect.Height;

                zoomRect.Height  = zoomRect.Width / viewportAspect;
                zoomRect.Y      -= (zoomRect.Height - prevHeight) / 2.0f;
            
            }
            else
            {

                float prevWidth = zoomRect.Width;

                zoomRect.Width  = zoomRect.Height * viewportAspect;
                zoomRect.X     -= (zoomRect.Width - prevWidth) / 2.0f;

            }

            if (zoomRect.Width < 0.1f)
            {

                zoomRect.Width = 0.1f;
                zoomRect.Height = zoomRect.Width / viewportAspect;
            }

            if (zoomRect.Height < 0.1f)
            {

                zoomRect.Height = 0.1f;
                zoomRect.Width = zoomRect.Height * viewportAspect;

            }

            int[] viewport = new int[4] { 0, 0, (int) viewportRect.Width, (int) viewportRect.Height };

            glu.PickMatrix(zoomRect.X + zoomRect.Width / 2, zoomRect.Y + zoomRect.Height / 2, zoomRect.Width, zoomRect.Height, viewport);

            prevZoomRect = zoomRect;
            
        }

        // param can be gl.LINEAR or gl.NEAREST
        protected void LoadTextureFromResources(uint textureName, string name, int param)
        {

            gl.Enable(gl.TEXTURE_2D);

            using (Bitmap bitmap = new Bitmap(this.GetType(), name))
            {

                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                gl.BindTexture(gl.TEXTURE_2D, textureName);

                gl.TexParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, param);
                gl.TexParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, param);

                gl.TexImage2D(gl.TEXTURE_2D, 0, gl.RGB8,
                                bitmapData.Width, bitmapData.Height, 0,
                                gl.BGR_EXT, gl.UNSIGNED_BYTE,
                                bitmapData.Scan0);

                bitmap.UnlockBits(bitmapData);

            }

            gl.Disable(gl.TEXTURE_2D);

        }

        #endregion

        #region Focus handling

        protected override void OnLostFocus(EventArgs e)
        {

            hasFocus = false;

            action = actionType.None;

            Invalidate();

        }
        protected override void OnGotFocus(EventArgs e)
        {

            hasFocus = true;
            Invalidate();

        }

        #endregion

        /// <summary>
        /// Make the OpenGLControl rendering context current, 
        /// used when there are more OpenGLControls on the same form.
        /// </summary>
        public void MakeRenderingContextCurrent()
        {

            renderingContext.MakeCurrent();

        }

        private void InitializeStyles()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                Int32 CS_VREDRAW = 0x1;
                Int32 CS_HREDRAW = 0x2;
                Int32 CS_OWNDC   = 0x20;
                CreateParams cp  = base.CreateParams;
                cp.ClassStyle    = cp.ClassStyle | CS_VREDRAW | CS_HREDRAW | CS_OWNDC;

                return cp;
            }
        }

        public void SetZoomCursor()
        {

            if (zoomButtonDown)
                this.Cursor = zoomCursor;
            else
                this.Cursor = Cursors.Arrow;

        }

        public void SetPanCursor()
        {

            if (panButtonDown)
                this.Cursor = panCursor;
            else
                this.Cursor = Cursors.Arrow;

        }

        public void SetRotateCursor()
        {

            if (rotateButtonDown)
                this.Cursor = rotateCursor;
            else
                this.Cursor = Cursors.Arrow;

        }

        void DrawBoundingRect() {
            
                gl.PushMatrix();

                gl.Color3ub(0xff, 0, 0);

                gl.LineStipple(1, 0x0808);
                gl.Enable(gl.LINE_STIPPLE);

                gl.Begin(gl.LINE_LOOP);

                gl.Vertex2f( globalLeft, globalBottom);
                gl.Vertex2f(globalRight, globalBottom);
                gl.Vertex2f(globalRight, globalTop);
                gl.Vertex2f( globalLeft, globalTop);

                gl.End();

                gl.Disable(gl.LINE_STIPPLE);

                gl.PopMatrix();
            
        }

        public void ScaleNormals()
        {

            foreach (Entity ent in entities)

                ent.ScaleNormal(scaleTo100);

        }


        public virtual void ZoomFit() {}

        public virtual void ZoomWindow(int x1, int y1, int x2, int y2) {}

 

        protected override void OnResize(EventArgs e)
        {
            
            zoomRect = this.ClientRectangle;

            base.OnResize(e);

        }

    }

}