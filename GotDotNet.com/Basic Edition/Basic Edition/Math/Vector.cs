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
using OpenGL;
using System.Drawing;

namespace openglFramework
{

    [Serializable]
	public struct Vector
	{

		public float x, y, z;

		public Vector(float x, float y, float z) 
		{
		
			this.x = x;
			this.y = y;
			this.z = z;

		}

        public Vector(float[] p)
        {

            this.x = p[0];
            this.y = p[1];
            this.z = p[2];

        }

        public Vector(double[] p)
        {

            this.x = (float) p[0];
            this.y = (float) p[1];
            this.z = (float) p[2];

        }


		public Vector(Point3D p0, Point3D p1) 
		{
		
			x = p1.x - p0.x;
			y = p1.y - p0.y;
			z = p1.z - p0.z;

		}

		public static Vector operator -(Vector v1, Vector v2) 
		{

			Vector result;
			
			result.x = v1.x - v2.x;
			result.y = v1.y - v2.y;
			result.z = v1.z - v2.z;

			return result;

		}

		public bool IsZero() 
		{
			return MU.floatEqualityTest(0.0f, (float) Length());
		}	

		public bool IsUnit() 
		{
			return MU.floatEqualityTest(1.0f, (float) Length());
		}

		public void Normalize() {

			double len = Length();

			if (MU.floatEqualityTest(0.0f, (float) len))	{	// if length is zero
							 
				x =	0.0f;
				y =	0.0f;
				z =	0.0f;
			
			}
			else {	// normalize
				
				x = (float) (x / len);
				y = (float) (y / len);
				z = (float) (z / len);

				zeroClamp();

			}

		}

		void zeroClamp() {

			x = MU.zeroClamp(x);
			y = MU.zeroClamp(y);
			z = MU.zeroClamp(z);

		}

		public double Length() {
			
			return Math.Sqrt(x*x + y*y + z*z);

		}

		public static Vector Cross(Vector a, Vector b) {
		
			return new Vector(a.y*b.z - a.z*b.y, a.z*b.x - a.x*b.z, a.x*b.y - a.y*b.x);

		
		}

        public static double[] Cross(double[] a, double[] b)
        {

            return new double[] {a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0]};


        }

        public static void Normalize(ref double[] v)
        {

            double len = Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);

            if (len > 0) 
            {

                v[0] = (v[0] / len);
                v[1] = (v[1] / len);
                v[2] = (v[2] / len);

            }

        }

        public static void Normalize(ref float[] v)
        {

            float len = (float) Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);

            if (len > 0)
            {

                v[0] = (v[0] / len);
                v[1] = (v[1] / len);
                v[2] = (v[2] / len);

            }

        }

        public static float[] Normal(float[] p1, float[] p2, float[] p3)
        {

            float[] v1 = new float[] {p2[0] - p1[0], p2[1] - p1[1], p2[2] - p1[2]};
            float[] v2 = new float[] { p3[0] - p1[0], p3[1] - p1[1], p3[2] - p1[2] };

            return Vector.Cross(v1, v2);

        }

        public static float[] Cross(float[] a, float[] b)
        {

            return new float[] { a[1] * b[2] - a[2] * b[1], a[2] * b[0] - a[0] * b[2], a[0] * b[1] - a[1] * b[0] };


        }

        public static double[] Subtract(double[] a, double[] b)
        {

            return new double[] { a[0] - b[0], a[1] - b[1], a[2] - b[2] };


        }


		public static float Dot(Vector u, Vector v) 
		{

			return u.x * v.x + u.y * v.y + u.z * v.z;

		}

		public float AngleOnXY()
		{

			return MU.radToDeg((float) Math.Atan2(y, x));

		}

		public float AngleFromXY()
		{

			double d = Math.Sqrt(x*x + y*y);

			return MU.radToDeg((float) Math.Atan2(z, d));

		}

		public void Draw(float scale, IntPtr quadric) 
		{

			gl.PushMatrix();

			// cone
			glu.Cylinder(quadric, 0.01*scale, 2*scale, 5*scale, 16, 1);
			gl.Translatef(0.0f, 0.0f, 5*scale);
			// cone tapping
			glu.Disk(quadric, 0.5f*scale, 2.0f*scale, 16, 1);
			// cylinder
			glu.Cylinder(quadric, 1.0*scale, 1.0*scale, 10*scale, 16, 1);
			gl.Translatef(0.0f, 0.0f, 10*scale);
			// cylinder capping
			glu.Disk(quadric, 0.01f*scale, 1.0f*scale, 16, 1);

			gl.PopMatrix();

		}




		public static void DefineOpenGLNormal(float[] p1, float[] p2, float[] p3) 
		{

			Vector v1 = new Vector(p2[0]-p1[0], p2[1]-p1[1], p2[2]-p1[2]);
			Vector v2 = new Vector(p3[0]-p1[0], p3[1]-p1[1], p3[2]-p1[2]);

			Vector normal = new Vector(0, 0, 0);

			normal = Vector.Cross(v1, v2);

            normal.Normalize();

			gl.Normal3f(normal.x, normal.y, normal.z);

			
		}

		public static Vector GetNormal(float[] p1, float[] p2, float[] p3) 
		{

			Vector v1 = new Vector(p2[0]-p1[0], p2[1]-p1[1], p2[2]-p1[2]);
			Vector v2 = new Vector(p3[0]-p1[0], p3[1]-p1[1], p3[2]-p1[2]);

			Vector normal = new Vector(0, 0, 0);

			normal = Vector.Cross(v1, v2);

			return normal;
			
		}

    }

        public class MU
        {

            const float epsilon = 0.001f;

            public static float zeroClamp(float val)
            {
                return (epsilon > Math.Abs(val)) ? 0.0f : val;
            }

            public static bool floatEqualityTest(float x, float val)
            {
                return (val - epsilon) < x && x < (val + epsilon);
            }

            public static void limitRange(float low, ref float val, float high)
            {

                if (val < low)

                    val = low;

                else if (val > high)

                    val = high;

            }

            public static float radToDeg(float angle)
            {

                return (float)(angle * 180.0 / Math.PI);

            }

            public static float degToRad(float angle)
            {

                return (float)(angle * Math.PI / 180.0);

            }

        }

        public class Point3D
        {

            public float x;
            public float y;
            public float z;

            //public Point3D() {}

            public Point3D(float x, float y, float z)
            {

                this.x = x;
                this.y = y;
                this.z = z;

            }

            public static Vector operator -(Point3D a, Point3D b)
            {

                return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);

            }

            public static Point3D operator +(Point3D a, Vector b)
            {

                return new Point3D(a.x + b.x, a.y + b.y, a.z + b.z);

            }

        }

        public class Segment
        {

            public Point3D p0;
            public Point3D p1;

        }

        public class Plane
        {

            public Point3D p0;
            public Vector n;

        }

	

}