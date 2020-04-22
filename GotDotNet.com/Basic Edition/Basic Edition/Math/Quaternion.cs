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
using System.Diagnostics;

namespace openglFramework
{
    /// <summary>
    /// Summary description for quat.
    /// </summary>
    public class Quaternion
    {

        float x, y, z, w;

        public Quaternion(float x, float y, float z, float w)
        {

            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;

        }

        public void Identity()
        {

            x = 0.0f;
            y = 0.0f;
            z = 0.0f;
            w = 1.0f;

        }

        public void AxisToQuat(Vector v, float angle)
        {

            double rad, scale;			// temp vars

            if (v.IsZero())
            {			// if axis is zero, then return quaternion (1,0,0,0)

                Identity();

                return;

            }

            Debug.Assert(v.IsUnit());	// make sure the axis is a unit vector

            rad = angle / 2;

            w = (float)Math.Cos(rad);

            scale = Math.Sin(rad);

            this.x = (float)(v.x * scale);
            this.y = (float)(v.y * scale);
            this.z = (float)(v.z * scale);

            Normalize();				// make sure a unit quaternion turns up

        }

        public void GetAxisAngle(ref Vector v, ref float angle)
        {

            double tempAngle;		// temp angle
            double scale;			// temp vars

            tempAngle = Math.Acos(w);

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            // Another version where scale is sqrt (x2 + y2 + z2)
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            scale = (float)Math.Sqrt(x * x + y * y + z * z);
            //	scale = (float)sin(temp_angle);

            Debug.Assert(0 <= tempAngle);				// make sure angle is 0 - PI
            Debug.Assert(Math.PI >= tempAngle);

            if (MU.floatEqualityTest(0.0f, (float)scale))
            {	// angle is 0 or 360 so just simply set axis to 0,0,1 with angle 0

                angle = 0.0f;

                v.x = 0.0f;
                v.y = 0.0f;
                v.z = 1.0f;		// any axis will do

            }
            else
            {

                angle = (float)(tempAngle * 2.0);		// angle in radians

                v.x = (float)(x / scale);
                v.y = (float)(y / scale);
                v.z = (float)(z / scale);

                v.Normalize();

                Debug.Assert(0.0f <= angle);			// make sure rotation around axis is 0 - 360
                Debug.Assert(2 * Math.PI >= angle);
                Debug.Assert(v.IsUnit());				// make sure a unit axis comes up

            }


        }

        public void Normalize()
        {

            double norm = Norm();

            Debug.Assert(!MU.floatEqualityTest(0.0f, (float)norm));		// norm should never be close to 0

            x = (float)(x / norm);
            y = (float)(y / norm);
            z = (float)(z / norm);
            w = (float)(w / norm);

            Debug.Assert(MU.floatEqualityTest(1.0f, (float)Norm()));	// must be normalized, safe

            MU.limitRange(-1.0f, ref w, 1.0f);

            MU.limitRange(-1.0f, ref x, 1.0f);
            MU.limitRange(-1.0f, ref y, 1.0f);
            MU.limitRange(-1.0f, ref z, 1.0f);


        }

        double Norm()
        {

            return Math.Sqrt(x * x + y * y + z * z + w * w);

        }

        public static Quaternion operator *(Quaternion a, Quaternion b)
        {

            double rx, ry, rz, rw;		// temp result

            rw = b.w * a.w - b.x * a.x - b.y * a.y - b.z * a.z;

            rx = b.w * a.x + b.x * a.w + b.y * a.z - b.z * a.y;
            ry = b.w * a.y + b.y * a.w + b.z * a.x - b.x * a.z;
            rz = b.w * a.z + b.z * a.w + b.x * a.y - b.y * a.x;

            return new Quaternion((float)rx, (float)ry, (float)rz, (float)rw);

        }

    }

}