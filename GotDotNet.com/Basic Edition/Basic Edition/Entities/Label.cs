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
using System.Diagnostics;

namespace openglFramework
{
    public class Label
    {

        protected int xPos;
        protected int yPos;

        protected string text;

        public Label(string text)
        {

            this.text = text;

        }

        public void UpdatePos(float x, float y, float z)
        {

            float winX, winY, winZ;

            Project(x, y, z, out winX, out winY, out winZ);

            xPos = (int) winX;
            yPos = (int) winY;

        }

                public string Text
        {
            get { return text; }
            set {

                text = value;

               
            
                }
        }


        public static void Project(double x, double y, double z, out float winX, out float winY, out float winZ)
        {

            double[] modelMatrix        = new double[16];
            double[] projectionMatrix   = new double[16];
            int[]    viewport           = new int[4];

            gl.GetDoublev (gl.MODELVIEW_MATRIX,  modelMatrix);
            gl.GetDoublev (gl.PROJECTION_MATRIX, projectionMatrix);
            gl.GetIntegerv(gl.VIEWPORT, viewport);

            double tmpX, tmpY, tmpZ;

            if (glu.Project(x, y, z, modelMatrix, projectionMatrix, viewport, out tmpX, out tmpY, out tmpZ) == gl.FALSE)

                Debug.WriteLine("gluProject failed.");

            // cast to float
            winX = (float) tmpX;
            winY = (float) tmpY;
            winZ = (float) tmpZ;

        }

        public virtual void Draw(float layer, float positionScale)
        {

            Draw(0, 0, positionScale);

        }

        public void Draw(int offsetX, int offsetY, float positionScale)
        {

            gl.RasterPos2f(xPos * positionScale + offsetX , yPos * positionScale + offsetY);

            gl.ListBase(1000); // normal

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);

        }

            
    }
}
