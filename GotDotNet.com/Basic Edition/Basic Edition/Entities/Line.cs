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
using System.Collections;
using System.ComponentModel;

namespace openglFramework
{
    [Serializable]
    class Line : Entity
    {

        public Line(float[] p1, float[] p2, Color color) : base (color)
        {

            vertices   = new float[2][];
            vertices2D = new float[2][];

            vertices[0] = new float[3];
            vertices[1] = new float[3];

            vertices[0] = p1;
            vertices[1] = p2;

        }

        public override void Draw()
        {

            SetOpenGLColor();

            gl.Disable(gl.LIGHTING);

            gl.Begin(gl.LINES);

            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);

            gl.End();

        }

        public override void DrawWireframe()
        {

            SetOpenGLColor();

            gl.Begin(gl.LINES);

            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);

            gl.End();

        }

    }
}
