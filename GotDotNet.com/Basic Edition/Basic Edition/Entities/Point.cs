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
    class Point : Entity
    {

        public Point(float x, float y, float z, Color color) : base (color)
        {

            vertices = new float[1][];
            vertices2D = new float[1][];

            vertices[0] = new float[3];

            vertices[0][0] = x;
            vertices[0][1] = y;
            vertices[0][2] = z;

        }

        public override void Draw()
        {

            SetOpenGLColor();

            gl.Disable(gl.LIGHTING);

            gl.Begin(gl.POINTS);
            gl.Vertex3fv(vertices[0]);
            gl.End();

        }

        public override void DrawWireframe()
        {

            SetOpenGLColor();

            gl.Begin(gl.POINTS);
            gl.Vertex3fv(vertices[0]);
            gl.End();

        }

    }
}
