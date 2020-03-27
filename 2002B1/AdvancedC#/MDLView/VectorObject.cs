namespace MdlView
{
	using System;

	/// <summary>
	/// Base class from which all vector objects derive (The only derived class is Model @ the moment =-)
	/// </summary>
	/// <remarks>
	/// The class is marked abstract, so it cannot be instanciated
	/// </remarks>
	internal abstract class VectorObject
	{		
		protected internal static float[] Cos_Look;
		protected internal static float[] Sin_Look;
		
		protected int angleX, angleY, angleZ;
		protected Position worldPos;
		protected Matrix GlobalView;
		protected float scaleFactor;
		protected internal Matrix RotateMatrix;

		/// <summary>
		/// A derived class must implement a way to add polygons to our world (hence, addToList)
		/// </summary>
		/// <param name="WorldList">A list that holds polygons for our world</param>
		/// <param name="renderType">The current rendering type for the object</param>
		/// <param name="TransX">Local screen translation</param>
		/// <param name="TransY">Local screen translation</param>
		protected internal abstract void AddToList(ref RenderList WorldList, enumRenderingMode renderType, int TransX, int TransY);
		
		/// <summary>
		/// A derived class must implement a way to rotate the object
		/// </summary>
		protected internal abstract void RotateObject();

		/// <summary>
		/// Translates an object from its current position
		/// </summary>
		/// <param name="TX">X translation offset</param>
		/// <param name="TY">Y translation offset</param>
		/// <param name="TZ">Z translation offset</param>
		public void Translate(int TX, int TY, int TZ)
		{
			worldPos.X += TX;
			worldPos.Y += TY;
			worldPos.Z += TZ;
		}

		/// <summary>
		/// Rotates an object (really just stores the rotation angles)
		/// </summary>
		/// <param name="AX">Rotation angle X</param>
		/// <param name="AY">Rotation angle Y</param>
		/// <param name="AZ">Rotation angle Z</param>
		public void Rotate(int AX, int AY, int AZ)
		{
			angleX = AX;
			angleY = AY;
			angleZ = AZ;
		}

		/// <summary>
		/// Puts the object in a certain world position
		/// </summary>
		/// <param name="X">The X position</param>
		/// <param name="Y">The Y position</param>
		/// <param name="Z">The Z position</param>
		public void Position(int X, int Y, int Z)
		{
			worldPos.X = X;
			worldPos.Y = Y;
			worldPos.Z = Z;
		}

		/// <summary>
		/// Property that gets and sets the objects scale
		/// </summary>
		public float Scale
		{
			get
			{
				return scaleFactor;
			}
			set
			{
				scaleFactor = value;
			}
		}

		/// <summary>
		/// Creates a vector from two points
		/// </summary>
		/// <param name="u">The starting point in 3-d space (x, y, z)</param>
		/// <param name="v">The ending point in 3-d space (x, y, z)</param>
		protected internal static Vector MakeVector(Vector u, Vector v) 
		{
			Vector result;

			result.x = v.x - u.x;
			result.y = v.y - u.y;
			result.z = v.z - u.z;

			return result;
		}

		/// <summary>
		/// Calculates a unitized crossproduct (magnitude = 1)
		/// </summary>
		/// <param name="u">1st vector for cross product</param>
		/// <param name="v">2nd vector for cross product</param>
		/// <remarks>
		/// The cross (inner) product returns the normal of two vectors.  We use this information
		/// for backface culling.  Normals can actually point in one of two directions.  That is,
		/// u, v is different then u, v.  It is in fact CrossProduct(u, v) = -CrossProduct(v, u).  
		/// If your object looks inside out when you're removing backfaces, try switching the u and v.
		/// </remarks>
		protected internal static Vector CrossProduct(Vector u, Vector v)
		{
			float Magnitude;
			Vector result;

			result.x = (u.y * v.z - u.z * v.y);
			result.y = -(u.x * v.z - u.z * v.x);
			result.z = (u.x * v.y - u.y * v.x);

			Magnitude = (float)Math.Sqrt(result.x * result.x + result.y * result.y + result.z * result.z);

			// Unitize normal
			if (Magnitude != 0) 
			{
				result.x /= Magnitude;
				result.y /= Magnitude;
				result.z /= Magnitude;
			}

			return result;
		}
	
		/// <summary>
		/// Rotates a single point
		/// </summary>
		/// <param name="point">The point to be rotated</param>
		/// <param name="AX">The desired x rotation of the point</param>
		/// <param name="AY">The desired y rotation of the point</param>
		/// <param name="AZ">The desired z rotation of the point</param>
		protected internal static Vector SingleRotate(Vector point, int AX, int AY, int AZ)
		{
			int Product;
			Matrix RotateX = new Matrix(false);
			Matrix RotateY = new Matrix(false);
			Matrix RotateZ = new Matrix(false);
			Matrix Rotate = new Matrix(false);
			Matrix Temp = new Matrix(false);
			Vector result;

			// Special case - no rotation
			if ((AX == 0) && (AY == 0) && (AZ == 0))
			{
				result.x = point.x;
				result.y = point.y;
				result.z = point.z;
				return result;
			}

			Product = 0;

			Matrix.identity(ref Rotate);

			if (AX > 0) 
			{
				Matrix.identity(ref RotateX);

				RotateX[1, 1] = Cos_Look[AX];
				RotateX[1, 2] = Sin_Look[AX];
				RotateX[2, 1] = -(Sin_Look[AX]);
				RotateX[2, 2] = Cos_Look[AX];

				Product |= 4;
			}

			if (AY > 0)
			{
				Matrix.identity(ref RotateY);

				RotateY[0, 0] = Cos_Look[AY];
				RotateY[0, 2] = -(Sin_Look[AY]);
				RotateY[2, 0] = Sin_Look[AY];
				RotateY[2, 2] = Cos_Look[AY];

				Product |= 2;
			}

			if (AZ > 0)
			{
				Matrix.identity(ref RotateZ);

				RotateZ[0, 0] = Cos_Look[AZ];
				RotateZ[0, 1] = Sin_Look[AZ];
				RotateZ[1, 0] = -(Sin_Look[AZ]);
				RotateZ[1, 1] = Cos_Look[AZ];

				Product |= 1;
			}

			switch(Product)
			{
				case 1:
					Matrix.copy(RotateZ, ref Rotate);
					break;
				case 2:
					Matrix.copy(RotateY, ref Rotate);
					break;
				case 3:
					Rotate = RotateZ * RotateY;
					break;
				case 4:
					Matrix.copy(RotateX, ref Rotate);
					break;
				case 5:
					Rotate = RotateZ * RotateX;
					break;
				case 6:
					Rotate = RotateX * RotateY;
					break;
				case 7:
					Temp = RotateX * RotateY;
					Rotate = Temp * RotateZ;
					break;
			}

			result.x = point.x * Rotate[0, 0] +
				point.y * Rotate[1, 0] + point.z * Rotate[2, 0];
			result.y = point.x * Rotate[0, 1] + 
				point.y * Rotate[1, 1] + point.z * Rotate[2, 1];
			result.z = point.x * Rotate[0, 2] +
				point.y * Rotate[1, 2] + point.z * Rotate[2, 2];

			return result;				
		}

		/// <summary>
		/// Create a 'global view' based on viewer position
		/// </summary>
		/// <param name="PosX">The viewer's x position</param>
		/// <param name="PosY">The viewer's y position</param>
		/// <param name="PosZ">The viewer's z position</param>
		/// <param name="AngX">The viewer's x angle</param>
		/// <param name="AngY">The viewer's y angle</param>
		/// <param name="AngZ">The viewer's z angle</param>
		protected void CreateWorldToCamera(int PosX, int PosY, int PosZ, int AngX, int AngY, int AngZ)
		{
			Matrix RotateX = new Matrix(false);
			Matrix RotateY = new Matrix(false);
			Matrix RotateZ = new Matrix(false);
			Matrix Translate = new Matrix(false);
			Matrix Result1 = new Matrix(false);
			Matrix Result2 = new Matrix(false);

			Matrix.identity(ref Translate);
			Matrix.identity(ref RotateX);
			Matrix.identity(ref RotateY);
			Matrix.identity(ref RotateZ);

			Translate[3, 0] = -PosX;
			Translate[3, 1] = -PosY;
			Translate[3, 2] = -PosZ;

			RotateX[1, 1] = Cos_Look[AngX];
			RotateX[1, 2] = -Sin_Look[AngX];
			RotateX[2, 1] = Sin_Look[AngX];
			RotateX[2, 2] = Cos_Look[AngX];

			RotateY[0, 0] = Cos_Look[AngY];
			RotateY[0, 2] = Sin_Look[AngY];
			RotateY[2, 0] = -Sin_Look[AngY];
			RotateY[2, 2] = Cos_Look[AngY];

			RotateZ[0, 0] = Cos_Look[AngZ];
			RotateZ[0, 1] = -Sin_Look[AngZ];
			RotateZ[1, 0] = Sin_Look[AngZ];
			RotateZ[1, 1] = Cos_Look[AngZ];

			Result1 = Translate * RotateX;
			Result2 = Result1 * RotateY;
			GlobalView = Result2 * RotateZ;
		}

		/// <summary>
		/// Returns the dotproduct of two vectors
		/// </summary>
		/// <param name="u">The 1st vector for the dot product</param>
		/// <param name="v">The 2nd vector for the dot product</param>
		protected internal static float DotProduct(Vector u, Vector v)
		{
			return ((u.x * v.x) + (u.y * v.y) + (u.z * v.z));
		}
	}
}
