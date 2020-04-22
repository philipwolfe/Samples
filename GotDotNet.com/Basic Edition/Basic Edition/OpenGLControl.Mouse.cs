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

using System.Drawing;
using System.Windows.Forms;
using OpenGL;
using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace openglFramework
{

    public partial class OpenGLControl : UserControl
    {

        // Zoom/Pan/Rotate
        const float rotationScale    = 4.0f;

        // Buttons
        private bool zoomButtonDown         = false;
        private bool panButtonDown          = false;
        private bool rotateButtonDown       = false;
        private bool zoomWindowButtonDown   = false;

        // Cursors
        Cursor zoomCursor;
        Cursor panCursor;
        Cursor rotateCursor;


        protected Quaternion cameraQuat;		// camera quaternion

        protected Vector lastPoint;
        protected Vector curPoint;

        protected float rotAngle;
        protected Vector rotAxis;

        protected int panDeltaX;
        protected int panDeltaY;


        protected enum actionType
        {

            None,
            Zoom,
            Pan,
            Rotate,
            ZoomWindow,
            SelectByPick,
            SelectByBox,
            SelectVisibleByPick,
            SelectVisibleByBox
            
        }

        protected actionType action;

        #region Properties

        [CategoryAttribute("ZPR")]
        public bool ZoomButtonDown
        {
            get { return zoomButtonDown; }
            set { zoomButtonDown = value; }
        }
        [CategoryAttribute("ZPR")]
        public bool PanButtonDown
        {
            get { return panButtonDown; }
            set{panButtonDown = value; }
        }
        [CategoryAttribute("ZPR")]
        public bool RotateButtonDown
        {
            get { return rotateButtonDown; }
            set{ rotateButtonDown = value; }
        }
        [CategoryAttribute("ZPR")]
        public bool ZoomWindowButtonDown
        {
            get { return zoomWindowButtonDown; }
            set { zoomWindowButtonDown = value; }
        }

        #endregion

        protected override void OnMouseDown(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && zoomWindowButtonDown)
            {

                action = actionType.ZoomWindow;

                curPoint.x = e.X;
                curPoint.y = e.Y;
                lastPoint.x = curPoint.x;
                lastPoint.y = curPoint.y;

            }

            else if ((e.Button == MouseButtons.Middle && (Control.ModifierKeys & Keys.Shift) == Keys.Shift) || 
                zoomButtonDown)
                {

                    action = actionType.Zoom;

                    Cursor = zoomCursor;

                    lastPoint.x = e.X;
                    lastPoint.y = e.Y;

                }

            else if ((e.Button == MouseButtons.Middle && (Control.ModifierKeys & Keys.Control) == Keys.Control) ||
                     panButtonDown)
                {

                    action = actionType.Pan;

                    Cursor = panCursor;

                    lastPoint.x = e.X;
                    lastPoint.y = e.Y;

                }
            else if (e.Button == MouseButtons.Middle || rotateButtonDown)
                {

                    action = actionType.Rotate;

                    Cursor = rotateCursor;

                    lastPoint = TrackBallMapping(e.X, e.Y, this.Width, this.Height);

                }   

            base.OnMouseDown(e);

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {

            Vector direction;

            float pixelDiff;
            float ratio = prevZoomRect.Width / viewportRect.Width;

            switch (action)
            {

                case actionType.Rotate: curPoint = TrackBallMapping(e.X, e.Y, this.Width, this.Height);

                    direction = curPoint - lastPoint;

                    float velocity = (float)direction.Length();

                    if (velocity > 0.0001f)
                    {

                        rotAxis = Vector.Cross(lastPoint, curPoint);

                        rotAxis.Normalize(); // needed from UpdateCameraQuat

                        rotAngle = velocity * rotationScale;

                        UpdateCameraQuat(true);

                        AxisAndAngleOnStatusBar();

                        Invalidate();

                    }

                    lastPoint = curPoint;

                    break;

                case actionType.Zoom : pixelDiff = lastPoint.y - e.Y;

                    // Set the current point, so the lastPoint will be saved properly below. 
                    curPoint.x = (float) e.X;
                    curPoint.y = (float) e.Y;

                    Invalidate();

                    lastPoint = curPoint;

                    break;

                case actionType.Pan:

                    // Set the current point, so the lastPoint will be saved properly below. 
                    curPoint.x = (float) e.X;
                    curPoint.y = (float) e.Y;
  
                    break;

                case actionType.ZoomWindow: 
                    
                    curPoint.x = e.X;
                    curPoint.y = e.Y;

                    Invalidate();

                    break;

            }

            base.OnMouseMove(e);

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {

            action = actionType.None;

            Invalidate();

            Cursor = Cursors.Arrow;

            ((MainForm)this.Parent).StatusText("");

            base.OnMouseUp(e);

        }

        protected virtual void DrawSelectionBox(byte r, byte g, byte b)
        {

        }

        protected void AxisAndAngleOnStatusBar()
        {

            ((MainForm)this.Parent).StatusText("Axis: (" + rotAxis.x.ToString("f2") + ", " + rotAxis.y.ToString("f2") + ", " + rotAxis.z.ToString("f2") + ") Angle: " + MU.radToDeg(rotAngle).ToString("f2") + " deg");

        }

        protected void UpdateCameraQuat(bool additive)
        {

            Quaternion axisQuat;		// quaternion from the rotation axis
            Quaternion tempQuat;		// temp quaternion

            axisQuat = new Quaternion(0, 0, 0, 1.0f);

            axisQuat.AxisToQuat(rotAxis, rotAngle);				// build the quaternion representing the quaternion change

            tempQuat = cameraQuat;								// copy temp quaternion as the *= operator does not

            if (additive)

                cameraQuat = tempQuat * axisQuat;

            else

                cameraQuat = axisQuat;

            cameraQuat.GetAxisAngle(ref rotAxis, ref rotAngle);		// get angle axis representation

        }

        Vector TrackBallMapping(int x, int y, int width, int height)
        {

            Vector result;

            result.x = (2.0f * x - width) / width;
            result.y = (height - 2.0f * y) / height;
            result.z = 0;

            float d;

            d = (float)result.Length();
            d = (d < 1.0f) ? d : 1.0f;

            result.z = (float) Math.Sqrt(1.001f - d * d);

            result.Normalize();

            return result;

        }


    }

}