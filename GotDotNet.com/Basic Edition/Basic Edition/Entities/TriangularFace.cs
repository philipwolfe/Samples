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
    class TriangularFace : Entity
    {

        // allow fast redrawing
        protected float[] normal;

        public TriangularFace(float[] p1, float[] p2, float[] p3, Color color) : base (color)
        {

            vertices   = new float[3][];
            vertices2D = new float[3][];

            vertices[0] = new float[3];
            vertices[1] = new float[3];
            vertices[2] = new float[3];

            vertices[0] = p1;
            vertices[1] = p2;
            vertices[2] = p3;

            normal = Vector.Normal(vertices[0], vertices[1], vertices[2]);


        }

        // born for ReadBinarySTL
        public TriangularFace(float[] n, float[] p1, float[] p2, float[] p3, Color color)
            : base(color)
        {

            vertices = new float[3][];
            vertices2D = new float[3][];

            vertices[0] = new float[3];
            vertices[1] = new float[3];
            vertices[2] = new float[3];

            vertices[0] = p1;
            vertices[1] = p2;
            vertices[2] = p3;

            normal = n;

        }

        public override void ScaleNormal(float scale)
        {

            Vector.Normalize(ref normal);

            normal[0] *= scale;
            normal[1] *= scale;
            normal[2] *= scale;

        }

        public override void Draw()
        {

            SetOpenGLColor();

            gl.Enable(gl.LIGHTING);

            gl.Begin(gl.TRIANGLES);
            gl.Normal3fv(normal);
            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.Vertex3fv(vertices[2]);
            gl.End();

        }

        public override void DrawNormal(float length) 
        {

            float normLength = (float) Math.Sqrt(normal[0] * normal[0] + normal[1] * normal[1] + normal[2] * normal[2]);

            gl.Vertex3fv(vertices[0]);
            gl.Vertex3f(vertices[0][0] + normal[0] * length / normLength,
                        vertices[0][1] + normal[1] * length / normLength,
                        vertices[0][2] + normal[2] * length / normLength);
        
        }

        public override void FlipNormal() 
        {

            normal[0] = -normal[0];
            normal[1] = -normal[1];
            normal[2] = -normal[2];

            // invert vertices order to be in line with normal direction
            float[] tmp = new float[3];

            vertices[1].CopyTo(tmp, 0);

            vertices[1] = vertices[2];
            vertices[2] = tmp;

        
        }


        public override void DrawEdges()
        {

            // NORMAL NOT NEEDED

            SetOpenGLColor();

            gl.Begin(gl.TRIANGLES);
            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.Vertex3fv(vertices[2]);
            gl.End();
        }

        public override void DrawWireframe()
        {

            // NORMAL NOT NEEDED

            SetOpenGLColor();

            gl.Begin(gl.TRIANGLES);
            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.Vertex3fv(vertices[2]);
            gl.End();
        }

        public override void DrawForShadow()
        {

            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.Vertex3fv(vertices[2]);

        }


    }
}