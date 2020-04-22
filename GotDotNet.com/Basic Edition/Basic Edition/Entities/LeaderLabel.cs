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

namespace openglFramework
{
    class LeaderLabel : Label
    {

        float x, y, z;

        protected int yDistance;

        public LeaderLabel(float x, float y, float z, string text, int yDistance) : base(text)
        {

            this.x = x;
            this.y = y;
            this.z = z;

            this.text = text;
            this.yDistance = yDistance;

        }

        public override void Draw(float layer, float positionScale)
        {

            Draw(0, yDistance, positionScale);

            gl.LineWidth(1.0f / positionScale);

            gl.Begin(gl.LINES);

            gl.Vertex3f(xPos * positionScale, yPos * positionScale + 5, layer);
            gl.Vertex3f(xPos * positionScale, yPos * positionScale + yDistance - 5, layer);

            gl.End();

        }

        public void UpdatePos()
        {

            float winX, winY, winZ;

            Project(x, y, z, out winX, out winY, out winZ);

            xPos = (int)winX;
            yPos = (int)winY;

        }
           
    }
}
