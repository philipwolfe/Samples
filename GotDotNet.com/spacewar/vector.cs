
namespace SpaceWar
{
using System;
	using System.Runtime.Serialization;

[Serializable]
public struct Vector: ISerializable
{
	public Vector(SerializationInfo info, StreamingContext context)
	{
		x = info.GetSingle("x");
		y = info.GetSingle("y");
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("x", x);
		info.AddValue("y", y);
	}

		public Vector(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

	public Vector(MyPointF point)
	{
		this.x = point.X;
		this.y = point.Y;
	}

	public Vector(MyPointF p1, MyPointF p2)
	{
		this.x = p2.X - p1.X;
		this.y = p2.Y - p1.Y;
	}

	public unsafe void FromPointer(PtrHolder p)
	{
		float* pFloat = (float*) p.Ptr;
		x = *pFloat;
		pFloat++;
		y = *pFloat;
		pFloat++;
		p.Ptr = pFloat;
	}

	public unsafe void ToPointer(PtrHolder p)
	{
		float* pFloat = (float*) p.Ptr;
		*pFloat = x;
		pFloat++;
		*pFloat = y;
		pFloat++;
		p.Ptr = pFloat;
	}


	public override string ToString()
		{
			return String.Format("({0} {1})", x, y);
		}

		public float Length 
		{
			get
			{
				return((float) Math.Sqrt(x * x + y * y));
			}
		}
		/// <summary>
		/// Multiply a vector by a scalar. 
		/// </summary>
		/// <param name="v">The vector</param>
		/// <param name="mult">Scalar to multiply by</param>
		public static Vector operator*(Vector v, float mult)
		{
			Vector	result;
			result.x = v.x * mult;
			result.y = v.y * mult;

			return(result);
		}

		/// <summary>
		/// Subtract one vector from another
		/// </summary>
		/// <param name="v">Vector</param>
		/// <param name="sub">Vector to subtract from the first vector</param>
		public static Vector operator-(Vector v, Vector sub)
		{
			return(new Vector(v.x - sub.x, v.y - sub.y));
		}

		/// <summary>
		/// Add one vector to another
		/// </summary>
		/// <param name="v1">Vector</param>
		/// <param name="v2">Vector to add to the first vector</param>
		public static Vector operator+(Vector v1, Vector v2)
		{
			return(new Vector(v1.x + v2.x, v1.y + v2.y));
		}

		/// <summary>
		/// Dot Product of two vectors. Not divided to be a unit vector.
		/// </summary>
		/// <param name="v1">Vector 1</param>
		/// <param name="v2">Vector 2</param>
		public static float DotProduct(Vector v1, Vector v2)
		{
			return(v1.x * v2.x + v1.y * v2.y);
		}

		public Vector MakeUnit()
		{
			float length = Length;
			return(new Vector(x / length, y / length));
		}


	public static implicit operator MyPointF(Vector vec)
	{
		return new MyPointF(vec.x, vec.y);
	}

	public float X
	{
		get
		{
			return x;
		}
		set
		{
			x = value;
		}
	}

	public float Y
	{
		get
		{
			return y;
		}
		set
		{
			y = value;
		}
	}

	float x;
	float y;	
}

}
