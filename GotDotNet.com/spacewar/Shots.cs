using System;
using System.Drawing;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for Shots.
	/// </summary>
	[Serializable]
	public class Shots
	{

		Shot[] shots;
			[NonSerialized]	
		int cyclesSinceShot = 0;
			[NonSerialized]	
		Rectangle screenBounds;	
		//Size screenSize;					// size of the screen...

		public Shots()
		{
			shots = new Shot[Constants.NumShots];
			for (int count = 0; count < Constants.NumShots; count++)
			{
				shots[count] = new Shot();
			}
		}

		public unsafe void FromPointer(PtrHolder ptr)
		{
			for (int count = 0; count < Constants.NumShots; count++)
			{
				shots[count].FromPointer(ptr);
			}
		}

		public unsafe void ToPointer(PtrHolder ptr)
		{
			for (int count = 0; count < Constants.NumShots; count++)
			{
				shots[count].ToPointer(ptr);
			}
		}

		public Rectangle ScreenBounds
		{
			get
			{
				return screenBounds;
			}
			set
			{
				screenBounds = value;
			}
		}

		public bool Shoot(Vector position, Vector velocity, float angle)
		{
			if (cyclesSinceShot < Constants.ShotDeltaCycles)
				return false;

			cyclesSinceShot = 0;

			MyPointF shotPoint = new MyPointF(Constants.ShotVelocity, 0f);

			Vector shotVelocity = new Vector(shotPoint.Rotate(angle));
			if (Constants.ShotAddShipVelocity)
			{
				shotVelocity += velocity;
			}

			foreach (Shot shot in shots)
			{
				if (!shot.Alive)
				{
					shot.SetShot(position, shotVelocity);
					return true;
				}
			}
			return false;
		}

		public void UpdatePosition(Point sunLocation)
		{
			cyclesSinceShot++;

			foreach (Shot shot in shots)
			{
				shot.UpdatePosition(screenBounds, sunLocation);
			}
		}

		public void Clear()
		{
			foreach (Shot shot in shots)
			{
				shot.Alive = false;
			}
		}
		public bool TestShots(Ship ship)
		{
			foreach (Shot shot in shots)
			{
				if (shot.Alive)
				{
					float distance = (shot.Position - ship.Position).Length;
					if (distance < Constants.ShotCollisionLimit)
					{
						shot.Alive = false;
						return true;
					}
				}
			}
			return false;
		}

		public void Draw(DirectDrawSurface7 surface)
		{
			foreach (Shot shot in shots)
			{
				shot.Draw(surface);
			}
		}
	}
}
