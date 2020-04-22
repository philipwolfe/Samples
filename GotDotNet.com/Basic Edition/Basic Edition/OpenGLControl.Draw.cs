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
using System.Diagnostics;

namespace openglFramework
{
    public partial class OpenGLControl : UserControl
    {

        // Lighting
        float[] ambientLight = { 0.10f, 0.10f, 0.10f, 1.00f };
        float[] mainLightDiffuse = { 0.75f, 0.75f, 0.75f, 1.00f };
        float[] sideLightDiffuse = { 0.20f, 0.20f, 0.20f, 1.00f };

        float[] mainLightPos = { -50.0f, +150.0f, +100.0f, 0.0f };	// x z y
        float[] sideLightPos = { +100.0f, -50.0f, +100.0f, 0.0f };	// x z y

        float[] specular = { 0.75f, 0.75f, 0.75f, 1.00f };
        float[] specref = { 1.00f, 1.00f, 1.00f, 1.00f };

        // Background Gradient colors
        protected Color backgroundTopColor;
        protected Color backgroundBottomColor;
        protected float edgeWeight       = 2.0f;
        protected float wireframeWeight  = 1.5f;

        // Layer Concept
        protected float zNearPerspective = 10;
        protected float zFarPerspective  = 500;
        protected float viewportAspect;

        protected float zNearOrtho       = 10;
        protected float zFarOrtho        = 500;

        protected float zModel           = -60;

        protected float zBackground      = -500;
        protected float zZoomAndSelBox   = 0;
        protected float zUcsIcon         = +100;
        protected float zLabels          = +200;

        public enum projectionType
        {

            Parallel,
            Perspective
        }

        protected projectionType projectionMode = projectionType.Perspective;

        // Hide/Show
        protected bool showBoundingBox  = false;
        protected bool showUcsIcon      = true;
        protected bool showOrigin       = false;
        protected bool showLabels       = true;
        protected bool showLegend       = true;
        protected bool showProgress     = true;
        protected bool showNormals      = true;
        protected bool showLights       = false;
        protected bool showNodes        = false;

        protected float visibleNormalsLength = 4.0f;

        // Quadrics: spheres, cones, cylinders, etc...
        protected IntPtr quadric;
        
        // Labels
        Label xUcsLabel;
        Label yUcsLabel;
        Label zUcsLabel;
        Label originLabel;


        public enum shadingType
        {

            Wireframe,
            Shaded,
            ShadedAndEdges,
            Orientation

        }

        protected shadingType renderMode = shadingType.ShadedAndEdges;

        public enum backgroundType
        {

            None,
            Gradient,
            Bitmap

        }

        protected backgroundType backgroundMode = backgroundType.Gradient;

        public enum shadowType
        {

            None,
            Opaque,
            Transparent

        }

        protected shadowType shadowMode = shadowType.None;

        // Curves and circles precision
        protected float chordalErr = 0.1f;

        // Scale to obtain a fixed size model of 100 units
        protected float scaleTo100  = .5f;

        // frames per second
        protected int fps;

        protected bool backFaceCulling;
        protected float pointSize = 4;

        // number of welcome text redraws
        protected int welcomeCount = 30;

        #region Properties

        public int Fps
        {
            get { return fps; }
        }

        public bool BackFaceCulling
        {

            get { return backFaceCulling; }
            set { 
                backFaceCulling = value;
      
                Invalidate();
            }

        }

        public float EdgeWeight
        {

            get { return edgeWeight; }
            set { edgeWeight = value; }

        }

        public float WireframeWeight
        {

            get { return wireframeWeight; }
            set { wireframeWeight = value; }

        }

        public float PointSize
        {

            get { return pointSize; }
            set { pointSize = value; }

        }

        public float ChordalErr
        {
            get { return chordalErr; }
            set
            {
                chordalErr = value;
                Invalidate();
            }
        }

        [CategoryAttribute("Hide/Show")]
        public bool ShowBoundingBox
        {
            get { return showBoundingBox; }
            set
            {
                showBoundingBox = value;
                Invalidate();
            }
        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowOrigin
        {
            get { return showOrigin; }
            set
            {
                showOrigin = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowLabels
        {
            get { return showLabels; }
            set
            {
                showLabels = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowLegend
        {

            get { return showLegend; }
            set { showLegend = value; }

        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowProgress
        {
            get { return showProgress; }
            set
            {
                showProgress = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowUCSIcon
        {

            get { return showUcsIcon; }
            set { showUcsIcon = value; }

        }
        public backgroundType BackgroundMode
        {
            get { return backgroundMode; }
            set
            {
                backgroundMode = value;
                Invalidate();
            }
        }

        [CategoryAttribute("Shadow")]
        public shadowType ShadowMode
        {
            get { return shadowMode; }
            set
            {
                shadowMode = value;
                Invalidate();
            }
        }

        [CategoryAttribute("Hide/Show")]
        public bool ShowNormals
        {
            get { return showNormals; }
            set
            {
                showNormals = value;
                Invalidate();
            }
        }

        [CategoryAttribute("Hide/Show")]
        public bool ShowLights
        {
            get { return showLights; }
            set
            {
                showLights = value;
                Invalidate();
            }
        }

        [CategoryAttribute("Hide/Show")]
        public bool ShowNodes
        {
            get { return showNodes; }
            set
            {
                showNodes = value;
                Invalidate();
            }
        }

        public float FieldOfView
        {           
            get { return -zModel; }
            set
            {
                zModel = -value;
                Invalidate();
            }
        }

        #endregion

        #region Main drawing function

        public void DrawScene(float scale)
        {

            int StartTickCount = Environment.TickCount;

       
            gl.Enable(gl.DEPTH_TEST);
            gl.Clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

            ViewportSetup((int)(this.Width * scale), (int)(this.Height * scale));

            #region First step: Background

            if (backgroundMode != backgroundType.None)
            {

                SceneSetup2D((-zBackground) - 10, (-zBackground) + 10);

                DrawBackground();

            }

            #endregion

            #region Second step: Model

            gl.Clear(gl.DEPTH_BUFFER_BIT);

            gl.Enable(gl.LIGHT0);
            gl.Disable(gl.LIGHT1);

            gl.MatrixMode(gl.PROJECTION);
            gl.LoadIdentity();

            ApplyZoom();

            switch (projectionMode)
            {

                case projectionType.Parallel:
                    SceneSetupOrtho3D();
                    break;

                case projectionType.Perspective:
                    SceneSetupPerispective3D();
                    break;
            }  

            Draw3D();

            #endregion

            #region Third step: Zoom, Selection boxes, UCS icon, labels

            gl.Clear(gl.DEPTH_BUFFER_BIT);

            SceneSetup2D((-zLabels) -10, (-zZoomAndSelBox) + 10);

            Draw2D();

            #endregion

            gl.Flush();

            renderingContext.SwapBuffers();


            int MS = Environment.TickCount - StartTickCount;

            if (MS > 0)

                fps = (int) (1000.0f / MS);
        
        }

        #endregion

        protected void DrawOrigin(float radius)
        {

            gl.Enable(gl.LIGHTING);

            gl.Color3ub(255, 255, 255);


            glu.Sphere(quadric, radius, 32, 32);

            originLabel.UpdatePos(0, 0, 0);


        }

        protected void DrawEntities()
        {

            #region Entities

            gl.PointSize(pointSize);

            switch (renderMode)
            {

                case shadingType.Wireframe:
                    gl.PolygonMode(gl.FRONT_AND_BACK, gl.LINE);
                    gl.LineWidth(1.0f);
                    gl.Disable(gl.LIGHTING);
                    gl.Disable(gl.CULL_FACE);

                    foreach (Entity ent in entities)

                        ent.DrawWireframe();

                    break;

                case shadingType.Shaded:
                    gl.Enable(gl.COLOR_MATERIAL);
                    if (backFaceCulling) gl.Enable(gl.CULL_FACE);
                    gl.PolygonMode(gl.FRONT_AND_BACK, gl.FILL);

                    foreach (Entity ent in entities)

                        ent.Draw();

                    break;

                case shadingType.ShadedAndEdges:
                    gl.Enable(gl.COLOR_MATERIAL);
                    gl.PolygonMode(gl.FRONT_AND_BACK, gl.FILL);
                    if (backFaceCulling) gl.Enable(gl.CULL_FACE);
                    gl.Enable(gl.POLYGON_OFFSET_FILL);
                    gl.PolygonOffset(1.0f, 1.0f);

                    foreach (Entity ent in entities)

                        ent.Draw();

                    gl.Disable(gl.POLYGON_OFFSET_FILL);

                    break;

                case shadingType.Orientation:
                    gl.Disable(gl.COLOR_MATERIAL);
                    gl.Materialfv(gl.FRONT, gl.AMBIENT_AND_DIFFUSE, new float[3] { 1, 1, 1 });
                    gl.Materialfv(gl.BACK, gl.AMBIENT_AND_DIFFUSE, new float[3] { 0, 0, 0 });
                    if (backFaceCulling) gl.Enable(gl.CULL_FACE);
                    gl.PolygonMode(gl.FRONT_AND_BACK, gl.FILL);

                    foreach (Entity ent in entities)

                        ent.Draw();

                    break;

            }

            gl.Disable(gl.LIGHTING);

            #endregion

            #region Edges

            switch (renderMode)
            {

                case shadingType.ShadedAndEdges:
                    gl.PolygonMode(gl.FRONT_AND_BACK, gl.LINE);
                    if (backFaceCulling)
                        
                        gl.Enable(gl.CULL_FACE);

                    gl.LineWidth(edgeWeight);  
                    
                    foreach (Entity ent in entities)

                        ent.DrawEdges();

                    break;

            }

            #endregion

        }

        protected void DrawUcsIcon()
        {

            gl.PolygonMode(gl.FRONT_AND_BACK, gl.FILL);
            gl.Enable(gl.COLOR_MATERIAL);
            gl.Disable(gl.CULL_FACE);

            if (openglVersion >= 1.2f)
                gl.Enable(gl.RESCALE_NORMAL);
            else
                gl.Enable(gl.NORMALIZE);

            gl.PushMatrix();

            if (hasFocus)

                gl.Color3ub(255, 0, 0);

            else

                gl.Color3ub(0xBF, 0x40, 0x40);

            glu.Sphere(quadric, 4, 16, 16);

            DrawAxisArrow(xUcsLabel);

            gl.PopMatrix();


            gl.PushMatrix();

            if (hasFocus)

                gl.Color3ub(0, 255, 0);

            else

                gl.Color3ub(0x40, 0xBF, 0x40);

            gl.Rotatef(90F, 0.0F, 0.0F, 1.0F);

            DrawAxisArrow(yUcsLabel);

            gl.PopMatrix();


            gl.PushMatrix();

            if (hasFocus)

                gl.Color3ub(0, 0, 255);

            else

                gl.Color3ub(0x40, 0x40, 0xBF);

            gl.Rotatef(-90F, 0.0F, 1.0F, 0.0F);

            DrawAxisArrow(zUcsLabel);

            gl.PopMatrix();

            if (openglVersion >= 1.2f)
                gl.Disable(gl.RESCALE_NORMAL);
            else
                gl.Disable(gl.NORMALIZE);


        }

        protected void DrawAxisArrow(Label label)
        {

            // Cylinder
            gl.PushMatrix();

            gl.Rotatef(90F, 0F, 1F, 0F);
            glu.Cylinder(quadric, 1.75, 1.75, 20, 16, 1);

            gl.PopMatrix();

            // Cone
            gl.PushMatrix();

            gl.Translatef(20, 0.0f, 0.0f);
            gl.Rotatef(90F, 0F, 1F, 0F);
            glu.Cylinder(quadric, 5, 0, 14, 16, 1);

            gl.PopMatrix();

            // Cone tapping
            gl.PushMatrix();

            gl.Translatef(20, 0.0f, 0.0f);
            gl.Rotatef(-90F, 0F, 1F, 0F);
            glu.Disk(quadric, 1.75, 5, 16, 1);

            gl.PopMatrix();

            // Label
            label.UpdatePos(40, 0, 0);

        }

        protected void DrawBox(int firstX, int firstY, int secondX, int secondY, int zOffset)
        {

            gl.Vertex3i(firstX, firstY, (int)zZoomAndSelBox + zOffset);
            gl.Vertex3i(secondX, firstY, (int)zZoomAndSelBox + zOffset);

            gl.Vertex3i(secondX, secondY, (int)zZoomAndSelBox + zOffset);
            gl.Vertex3i(firstX, secondY, (int)zZoomAndSelBox + zOffset);

        }

        #region Overridables

        protected virtual void DrawBackground()
        {

            gl.MatrixMode(gl.MODELVIEW);
            gl.LoadIdentity();

            gl.Disable(gl.LIGHTING);


            gl.PolygonMode(gl.FRONT, gl.FILL);
            gl.Begin(gl.POLYGON);

            gl.Color3ub(backgroundBottomColor.R, backgroundBottomColor.G, backgroundBottomColor.B);
            gl.Vertex3f(0.0f, 0.0f, zBackground);

            gl.Vertex3f(this.Width, 0.0f, zBackground);

            gl.Color3ub(backgroundTopColor.R, backgroundTopColor.G, backgroundTopColor.B);
            gl.Vertex3f(this.Width, this.Height, zBackground);

            gl.Vertex3f(0.0f, this.Height, zBackground);

            gl.End();

        }

        protected virtual void Draw2D()
        {

            // used in off-screen renderings bigger than control client area
            float labelPositionScaling = this.Width / viewportRect.Width;

            gl.MatrixMode(gl.MODELVIEW);

            gl.LoadIdentity();

            // An optimum compromise that allows all primitives to be specified 
            // at integer positions, while still ensuring predictable rasterization, 
            // is to translate x and y by 0.375
            gl.Translatef(0.375f, 0.375f, 0.0f);

            gl.Disable(gl.LIGHTING);
            gl.LineWidth(1.0f);


       //   DrawBoundingRect();

            gl.Enable(gl.LIGHTING);

            if (showUcsIcon)
            {

                gl.PushMatrix();

                // axis icon position
                gl.Translatef(50.0f, 50.0f, zUcsIcon);

                // axis icon rotation
                gl.Rotatef(MU.radToDeg(rotAngle), rotAxis.x, rotAxis.y, rotAxis.z);		// multiply into matrix

                // swaps axis Y with Z
                gl.Rotatef(-90.0f, 1.0f, 0.0f, 0.0f);

                DrawUcsIcon();

                gl.PopMatrix();

            }

            // Labels

            gl.Disable(gl.LIGHTING);
            gl.PushMatrix();

            if (showUcsIcon && hasFocus)
            {

                gl.Color3ub(63, 63, 63);

                xUcsLabel.Draw(zLabels, labelPositionScaling);
                yUcsLabel.Draw(zLabels, labelPositionScaling);
                zUcsLabel.Draw(zLabels, labelPositionScaling);

            }

            if (showOrigin)
            {

                gl.Color3ub(63, 63, 63);

                originLabel.Draw(0, 20, labelPositionScaling);

            }

            if (showLabels)
            {

                if (backgroundMode == backgroundType.None)
                    gl.Color3ub(0, 0, 0);
                else
                    gl.Color3ub(255, 255, 255);

                foreach (Label l in labels)

                    l.Draw(zLabels, labelPositionScaling);

            }

            gl.PopMatrix();

            // Legend and Progress bar

            gl.Disable(gl.LIGHTING);
            gl.PushMatrix();

            if (showLegend)
                
                DrawLegend();

            if (showProgress)

                DrawProgressBar();
            
            gl.Color3ub(180, 180, 180);

            if (stencilBits == 0)
            
                DrawText(Width-366, Height-50, "Stencil buffer not available. Transparent shadow will not be rendered.");

              
            if (welcomeCount > 0)
            {

                DrawWelcomeText(Width/2-58, Height - 120, "Welcome to");
                DrawWelcomeText(Width/2-120, Height - 150, "C# OpenGL Framework");

                welcomeCount--;

            }
            

            gl.PopMatrix();
         
        }

        protected virtual void Draw3D()
        {

            gl.MatrixMode(gl.MODELVIEW);
            gl.LoadIdentity();
      
            // Move out Z axis so we can see everything (needed only for Perspective view)
            gl.Translatef(0, 0, zModel);

            #region Light bulbs

            gl.PushMatrix();

            gl.Scalef(scaleTo100, scaleTo100, scaleTo100);

            if (showLights)
            {


                DrawMainLight();

                DrawSideLight();


            }

            gl.PopMatrix();

            #endregion

            if (projectionMode == projectionType.Perspective && // we see it only in perspective mode
                shadowMode != shadowType.None)

                DrawShadow();

            gl.Rotatef(MU.radToDeg(rotAngle), rotAxis.x, rotAxis.y, rotAxis.z);		// multiply into matrix

            // this command swaps the Y and Z axis
            gl.Rotatef(-90.0f, 1.0f, 0.0f, 0.0f);

            CenterTheModel();

            if (showOrigin)

                DrawOrigin(1.0f);

            // give to the model a fixed size: 100 units
            gl.Scalef(scaleTo100, scaleTo100, scaleTo100);

            foreach (LeaderLabel l in labels)

                l.UpdatePos();

            gl.Enable(gl.NORMALIZE);

            DrawEntities();

            gl.Disable(gl.NORMALIZE);
            
        }

        private void DrawMainLight()
        {

            gl.Enable(gl.LIGHTING);

            gl.Color3ub(255, 255, 255);

            gl.PushMatrix();

            gl.Translatef(mainLightPos[0], mainLightPos[1], mainLightPos[2]);

            glu.Sphere(quadric, 4, 8, 8);

//            mainLightLabel.UpdatePos(0, 0, 0);

            gl.PopMatrix();

        }

        private void DrawSideLight()
        {

            gl.Enable(gl.LIGHTING);

            gl.Color3ub(255, 255, 255);

            gl.PushMatrix();

            gl.Translatef(sideLightPos[0], sideLightPos[1], sideLightPos[2]);

            glu.Sphere(quadric, 4, 8, 8);

            //            sideLightLabel.UpdatePos(0, 0, 0);

            gl.PopMatrix();

        }


        protected virtual void DrawShadow()
        {


        }

        protected virtual void DrawLegend()
        {


        }

        protected virtual void DrawProgressBar()
        {


        }

        protected virtual void DrawSelectableEntities()
        {

        }

        #endregion

        protected void CenterTheModel()
        {

            gl.Translatef(-(globalMin[0] + xSize / 2) * scaleTo100,
                          -(globalMin[1] + ySize / 2) * scaleTo100,
                          -(globalMin[2] + zSize / 2) * scaleTo100);

        }

        #region Text Drawing

        protected void DrawText(int x, int y, string text)
        {

            gl.ListBase(1000); // normal

            gl.RasterPos2f(x, y);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);

        }

        protected void DrawBoldText(int x, int y, string text)
        {

            gl.ListBase(2000); // bold

            gl.RasterPos2f(x, y);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);

        }

        protected void DrawWelcomeText(int x, int y, string text)
        {

            gl.ListBase(3000); // welcome

            gl.Color3ub(0xff, 0xff, 0xff);

            gl.RasterPos2f(x, y);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);

            gl.Color3ub(0, 0, 0);

            gl.RasterPos2f(x + 1, y + 1);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);


            gl.RasterPos2f(x + 1, y - 1);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);


            gl.RasterPos2f(x - 1, y - 1);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);


            gl.RasterPos2f(x - 1, y + 1);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);


        }

        #endregion


    }

}
