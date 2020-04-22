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
using System.Drawing;
using OpenGL;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;

namespace openglFramework
{
    [Serializable]
    public abstract class Entity
    {

        protected Color color;
        protected float[][] vertices;
        protected float[][] vertices2D;

        public Entity(Color color)
        {

            this.color = color;

        }

        public Color Color
        {

            get { return color; }

            set { color = value; }

        }

        public virtual void Draw()
        {

        }

        public virtual void DrawEdges() { }

        public virtual void DrawWireframe() { }

        public virtual void DrawNormal(float length) { }

        public virtual void DrawNodes()
        {

            foreach (float[] v in vertices)

                gl.Vertex3fv(v);

        }

        public virtual void FlipNormal() { }

        public virtual void DrawForShadow() { }

        public virtual void ScaleNormal(float scale) { }

        public virtual void UpdateRefinement(float chordalErr) { }

        public virtual void LoadTexture(uint[] textureNames) { }

        public virtual void BoundingBox(ref float xMin, ref float yMin, ref float zMin, ref float xMax, ref float yMax, ref float zMax)
        {

            foreach (float[] vertex in vertices)
            {

                if (vertex[0] < xMin)

                    xMin = vertex[0];

                if (vertex[0] > xMax)

                    xMax = vertex[0];

                if (vertex[1] < yMin)

                    yMin = vertex[1];

                if (vertex[1] > yMax)

                    yMax = vertex[1];

                if (vertex[2] < zMin)

                    zMin = vertex[2];

                if (vertex[2] > zMax)

                    zMax = vertex[2];


            }

        }

        protected virtual void SetOpenGLColor()
        {

            gl.Color4ub(color.R, color.G, color.B, 127);

        }

    }
    }
