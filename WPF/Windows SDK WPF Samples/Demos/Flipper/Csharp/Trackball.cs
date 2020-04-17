//---------------------------------------------------------------------------
//
// <copyright file="Trackball.cs" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
//
// Description: A trackball controls that allows rotation and scaling
// of a 3D scene.  It will require further work to be a general
// component.
//
//
//---------------------------------------------------------------------------

 
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;


namespace DemoDev
{
    public class Trackball
    {
        public Trackball()
        {
            Vector3D _translate = new Vector3D(0, 0, 0);
            Vector3D _translateDelta = new Vector3D(0, 0, 0);

            Reset();
        }

        public void Attach(FrameworkElement element)
        {
            element.MouseMove += this.MouseMoveHandler;
            element.MouseRightButtonDown += this.MouseDownHandler;
            element.MouseRightButtonUp += this.MouseUpHandler;
            element.MouseWheel += this.OnMouseWheel;
        }

        public void Detach(FrameworkElement element)
        {
            element.MouseMove -= this.MouseMoveHandler;
            element.MouseRightButtonDown -= this.MouseDownHandler;
            element.MouseRightButtonUp -= this.MouseUpHandler;
            element.MouseWheel -= this.OnMouseWheel;
        }

        public List<Viewport3D> Servants
        {
            get
            {
                if (_servants == null)
                    _servants = new List<Viewport3D>();

                return _servants;
            }
            set
            {
                _servants = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return _enabled && (_servants != null) && (_servants.Count > 0);
            }
            set
            {
                _enabled = value;
            }
        }

        // Updates the matrices of the servants using the rotation quaternion.
        private void Updateservants(Quaternion q, double s, Vector3D t)
        {
            //RotateTransform3D rotation = new RotateTransform3D(q,_center);
            //ScaleTransform3D scale = new ScaleTransform3D(new Vector3D(s,s,s));
            //Transform3DCollection rotateAndScale = new Transform3DCollection(rotation,scale);

            if (_servants != null)
            {
                foreach (Viewport3D i in _servants)
                {
                    ModelVisual3D mv = i.Children[0] as ModelVisual3D;
                    Transform3DGroup t3dg = mv.Transform as Transform3DGroup;

                    ScaleTransform3D _GroupScaleTransform = t3dg.Children[0] as ScaleTransform3D;
                    RotateTransform3D _GroupRotateTransform = t3dg.Children[1] as RotateTransform3D;
                    TranslateTransform3D _GroupTranslateTransform = t3dg.Children[2] as TranslateTransform3D;

                    _GroupScaleTransform.ScaleX = s;
                    _GroupScaleTransform.ScaleY = s;
                    _GroupScaleTransform.ScaleZ = s;
                    _GroupRotateTransform.Rotation = new AxisAngleRotation3D(q.Axis, q.Angle);
                    _GroupTranslateTransform.OffsetX = t.X;
                    _GroupTranslateTransform.OffsetY = t.Y;
                    _GroupTranslateTransform.OffsetZ = t.Z;

                    // Note that we don't copy constantly here, we copy the first time someone tries to
                    // trackball a frozen Models, but we replace it with a ChangeableReference
                    // and so subsequent interactions go through without a copy.
                    /*
                    if (i.Models.Transform.IsChangeable)
                    {
                        Model3DGroup mutableCopy = i.Models.Copy();
                        mutableCopy.StatusOfNextUse = UseStatus.ChangeableReference;
                        i.Models = mutableCopy;
                    }
                    i.Models.Transform = rotateAndScale;
                    */
                }
            }
        }


        private void MouseMoveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!Enabled) return;
            e.Handled = true;

            UIElement el = (UIElement)sender;

            if (el.IsMouseCaptured)
            {
                Vector delta = _point - e.MouseDevice.GetPosition(el);
                Vector3D t = new Vector3D();

                delta /= 2;
                Quaternion q = _rotation;

                if (_rotating == true)
                {
                    // We can redefine this 2D mouse delta as a 3D mouse delta
                    // where "into the screen" is Z
                    Vector3D mouse = new Vector3D(delta.X, -delta.Y, 0);
                    Vector3D axis = Vector3D.CrossProduct(mouse, new Vector3D(0, 0, 1));
                    double len = axis.Length;
                    if (len < 0.00001 || _scaling)
                        _rotationDelta = new Quaternion(new Vector3D(0, 0, 1), 0);
                    else
                        _rotationDelta = new Quaternion(axis, len);

                    q = _rotationDelta * _rotation;
                }
                else
                {
                    delta /= 20;
                    _translateDelta.X = delta.X * -1;
                    _translateDelta.Y = delta.Y;
                }

                t = _translate + _translateDelta;

                Updateservants(q, _scale * _scaleDelta, t);

            }
        }

        private void MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            if (!Enabled) return;
            e.Handled = true;


            if (Keyboard.IsKeyDown(Key.F1) == true)
            {
                Reset();
                return;
            }

            UIElement el = (UIElement)sender;
            _point = e.MouseDevice.GetPosition(el);
            // Initialize the center of rotation to the lookatpoint
            if (!_centered)
            {
                ProjectionCamera camera = (ProjectionCamera)_servants[0].Camera;
                _center = camera.LookDirection;
                _centered = true;
            }

            _scaling = (e.MiddleButton == MouseButtonState.Pressed);

            if (Keyboard.IsKeyDown(Key.Space) == false)
                _rotating = true;
            else
                _rotating = false;

            el.CaptureMouse();
        }

        private void MouseUpHandler(object sender, MouseButtonEventArgs e)
        {
            if (!_enabled) return;
            e.Handled = true;

            // Stuff the current initial + delta into initial so when we next move we
            // start at the right place.
            if (_rotating == true)
                _rotation = _rotationDelta * _rotation;
            else
            {
                _translate += _translateDelta;
                _translateDelta.X = 0;
                _translateDelta.Y = 0;
            }

            //_scale = _scaleDelta*_scale;
            UIElement el = (UIElement)sender;
            el.ReleaseMouseCapture();
        }

        void OnMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            e.Handled = true;

            _scaleDelta += (double)((double)e.Delta / (double)1000);
            Quaternion q = _rotation;

            Updateservants(q, _scale * _scaleDelta, _translate);
        }

        private void MouseDoubleClickHandler(object sender, MouseButtonEventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            _rotation = new Quaternion (0,0,0,1);
            _scale = 1;
            _translate.X = 0;
            _translate.Y = 0;
            _translate.Z = 0;
            _translateDelta.X = 0;
            _translateDelta.Y = 0;
            _translateDelta.Z = 0;

            // Clear delta too, because if reset is called because of a double click then the mouse
            // up handler will also be called and this way it won't do anything.
            _rotationDelta = Quaternion.Identity;
            _scaleDelta = 1;
            Updateservants(_rotation, _scale, _translate);
        }

        // The state of the trackball
        private bool _enabled;
        private Vector3D _center;
        private bool _centered;     // Have we already determined the rotation center?
        private double _scale;
        private Vector3D _translate;
        private Quaternion _rotation;
        private List<Viewport3D> _servants;

        // The state of the current drag
        private bool _scaling;              // Are we scaling?  NOTE otherwise we're rotating
        private double _scaleDelta;          // Change to scale because of this drag
        private Quaternion _rotationDelta;  // Change to rotation because of this drag
        private Point _point;               // Initial point of drag
        private Vector3D _translateDelta;
        private bool _rotating;
        private bool _translating;
    }
}

