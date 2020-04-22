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
using System.Text;
using OpenGL;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace openglFramework
{
    [Serializable]
    class RichLine : Line
    {

        protected float weight;
        protected ushort pattern;

        public RichLine(float[] p1, float[] p2, Color color, float weight, ushort pattern) : base (p1, p2, color)
        {

            this.weight = weight;
            this.pattern = pattern;

        }

        #region Properties

        [CategoryAttribute("Attributes")]
        public float Weight
        {
            get { return weight; }
            set
            {

                weight = value;

            }
        }

        [CategoryAttribute("Attributes")]
        public ushort Pattern
        {
            get { return pattern; }
            set
            {

                pattern = value;

            }
        }

        #endregion

        public override void Draw()
        {

            SetOpenGLColor();

            gl.Disable(gl.LIGHTING);

            gl.LineWidth(weight);
            gl.LineStipple(3, pattern);
            gl.Enable(gl.LINE_STIPPLE);

            gl.Begin(gl.LINES);
            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.End();

            gl.LineWidth(1.0f);
            gl.Disable(gl.LINE_STIPPLE);
        
        }


    }
}
