using System;
using System.Drawing;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for Shot.
	/// </summary>
	[Serializable]
	public class Shot
	{
		Vector position;
			[NonSerialized]
		Vector velocity;
		int age = -1;

		public Shot()
		{
		}

		public unsafe void FromPointer(PtrHolder ptr)
		{
			position.FromPointer(ptr);
			age = ptr.ReadInt();
		}

		public unsafe void ToPointer(PtrHolder ptr)
		{
			position.ToPointer(ptr);
			ptr.WriteInt(age);
		}



		public bool Alive
		{
			get
			{
				return (age != -1);
			}
			set
			{
				if (value == true)
					age = 0;
				else
					age = -1;
			}
		}

		public Vector Position
		{
			get
			{
				return position;
			}
		}

		public void SetShot(Vector position, Vector velocity)
		{
			age = 0;
			this.position = position;
			this.velocity = velocity;
		}


		public void UpdatePosition(Rectangle screenBounds, Point sunLocation)
		{
			if (age == -1)
				return;

			position += velocity;

			if (position.X > screenBounds.Right)
				position.X = screenBounds.Left;

			if (position.X < screenBounds.Left)
				position.X = screenBounds.Right;

			if (position.Y > screenBounds.Bottom)
				position.Y = screenBounds.Top;

			if (position.Y < screenBounds.Top)
				position.Y = screenBounds.Bottom;

			if (Constants.ShotGravity)
			{
					// update velocity due to the gravity of the sun...
				Vector gravity = new Vector(position, sunLocation);
				float length = gravity.Length;
				gravity = (gravity.MakeUnit() * Constants.G) * (1.0f / (length * length));
				velocity += gravity;

				if (length < Constants.ShotSunCollisionLimit)
				{
					age = Constants.ShotLifetime;
				}
			}

			age++;

			if (age >= Constants.ShotLifetime)
			{
				age = -1;
			}
		}

		public void Draw(DirectDrawSurface7 surface)
		{
			if (age == -1)
				return;

			int x = (int) position.X;
			int y = (int) position.Y;
			surface.DrawLine(x, y, x + 1, y);
			surface.DrawLine(x, y + 1, x + 1, y + 1);
		}
	}
}
