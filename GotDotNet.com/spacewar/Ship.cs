using System;
using System.Drawing;
using DxVBLib;

namespace SpaceWar
{

	/// <summary>
	/// Summary description for Ship.
	/// </summary>
	public class Ship
	{
		int[] flameFrame = new int[] {3, 4, 5, 4};

		Vector position;
		Vector velocity;
		Shots shots = new Shots();
		ShipState state = ShipState.Dead;		// current state
		string hostName;
		RotatableShape outline;

		Vector originalPosition;				// where we started...
		//Size screenSize;
		Rectangle screenBounds;
		int waitCount = 10;							// wait count before state transition.
		int flameIndex = -1;					// no flame
		int score;								// our score
		int	scoreForOthers;						// score to add to other players...
		int deathCount;							// # of times we've died...
		float hyperSuccess = Constants.HyperSuccessFactor;		// chance of a hyper being successful...

		Word hostNameWord;
		//SoundHandler soundHandler;
		Point sunLocation;
		Sounds sounds;

		static Ship()
		{
				// outline of the ship, with 3 flames...
			MyPointF pointNose = new MyPointF(0f, 4f);
			MyPointF pointRight = new MyPointF(2f, -2f);
			MyPointF pointLeft = new MyPointF(-2f, -2f);
			MyPointF flameBase = new MyPointF(0f, -2f);
			MyPointF flameEnd1 = new MyPointF(0f, -4f);
			MyPointF flameEnd2 = new MyPointF(0.5f, -4f);
			MyPointF flameEnd3 = new MyPointF(-0.5f, -4f);

			RotatableShape.AddLine(pointNose, pointRight, Constants.ShipSize);								
			RotatableShape.AddLine(pointNose, pointLeft, Constants.ShipSize);								
			RotatableShape.AddLine(pointLeft, pointRight, Constants.ShipSize);								
			RotatableShape.AddLine(flameBase, flameEnd1, Constants.ShipSize);								
			RotatableShape.AddLine(flameBase, flameEnd2, Constants.ShipSize);								
			RotatableShape.AddLine(flameBase, flameEnd3, Constants.ShipSize);								
		}

		public Ship(Point sunLocation)
		{
			this.sunLocation = sunLocation;
			outline = new RotatableShape();
		}

		public unsafe void FromPointer(PtrHolder ptr)
		{
			position.FromPointer(ptr);	
			outline.FromPointer(ptr);
			shots.FromPointer(ptr);
			state = (ShipState) ptr.ReadInt();
			waitCount = ptr.ReadInt();
			deathCount = ptr.ReadInt();
			flameIndex = ptr.ReadInt();
			hostName = ptr.ReadString();
			sounds = (Sounds) ptr.ReadInt();
			score = ptr.ReadInt();
		}

		public unsafe void ToPointer(PtrHolder ptr)
		{
			position.ToPointer(ptr);
			outline.ToPointer(ptr);
			shots.ToPointer(ptr);
			ptr.WriteInt((int) state);
			ptr.WriteInt(waitCount);
			ptr.WriteInt(deathCount);
			ptr.WriteInt(flameIndex);
			ptr.WriteString(hostName);
			ptr.WriteInt((int) sounds);
			ptr.WriteInt(score);
		}


		public void Shoot()
		{
			if (this.state != ShipState.Normal)
			{
				return;
			}

			float angle = outline.Angle + 90f;

				// find out the location of the front of the ship...
			Line line = outline.GetCurrentLineByIndex(0);
			Vector noseOffset = new Vector(line.End1.X, line.End1.Y);

			bool shot = shots.Shoot(position + noseOffset, velocity, angle);
			if (shot)
			{
				sounds |= Sounds.ShipFire;
			}
		}

		public void SetThrust(bool thrust)
		{
			SetFlame(thrust);

			if (thrust && (state == ShipState.Normal))
			{
				float angle = outline.Angle + 90f;
	
				MyPointF acceleration = new MyPointF(Constants.EngineThrust, 0f);

				velocity += new Vector(acceleration.Rotate(angle));
				sounds |= Sounds.ShipThrust;
			}
			else
			{
				if ((sounds & Sounds.ShipThrust) != 0)
					sounds ^= Sounds.ShipThrust;
			}
		}

			// set the flame on or off. 
			// if the is on and it was on last frame, we go to the next line
			// in the flicker sequence...
		void SetFlame(bool flameOn)
		{
			if (!flameOn)
			{
				flameIndex = -1;
			}
			else
			{
				flameIndex = ((flameIndex + 1) % 4);
			}
		}

		public int DeathCount
		{
			get
			{
				return deathCount;
			}
			set
			{
				deathCount = value;
			}
		}

		public int Score
		{
			get
			{
				return score;
			}
			set
			{
				score = value;
			}
		}

		public string HostName
		{
			get
			{
				return hostName;
			}
			set
			{
				hostName = value;
			}
		}

		public Vector Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
			}
		}

		public Vector Velocity
		{
			get
			{
				return velocity;
			}
			set
			{
				velocity = value;
			}
		}

		public Rectangle ScreenBounds
		{
			set
			{
				screenBounds = value;
				shots.ScreenBounds = screenBounds;
			}
		}

		public Sounds Sounds
		{
			get
			{
				return sounds;
			}
			set
			{
				sounds = value;
			}
		}

		public void EnterHyper()
		{
			if (state != ShipState.Normal)
				return;

			SetState(ShipState.HyperCharge);
		}

		public void SetRandomPosition(bool setOriginal)
		{
			while (true)
			{
				position = new Vector(screenBounds.Left + Constants.random.Next(screenBounds.Width), 
					screenBounds.Top + Constants.random.Next(screenBounds.Height));
				Vector dist = position - new Vector(sunLocation);
				if (dist.Length > Constants.ShipSunCreationDistance)
					break;
			}
			if (setOriginal)
			{
				originalPosition = position;
			}
		}

		void SetState(ShipState newState)
		{
			switch (newState)
			{
				case ShipState.Dying:
					deathCount++;
					waitCount = Constants.DyingCycle;
					sounds |= Sounds.ShipExplode;
					break;

				case ShipState.Dead:
					waitCount = Constants.DeadCycleWait;
					position = new Vector(-1000f, -1000f);	// not on board
					break;

				case ShipState.Normal:
					if (state == ShipState.Hyper)
					{
						SetRandomPosition(false);
					}
					else
					{
						position = originalPosition;
						velocity = new Vector(0.0f, 0.0f);
					}
					hyperSuccess = Constants.HyperSuccessFactor;
					shots.Clear();
					sounds |= Sounds.ShipAppear;
					break;

				case ShipState.HyperCharge:
					sounds |= Sounds.ShipHyper;
					waitCount = Constants.HyperChargeWait;
					break;

				case ShipState.Hyper:
					position = new Vector( -1000f, -1000f);		// not on board...
					waitCount = Constants.HyperCycleWait;
					break;
			}
			state = newState;
		}

		public void UpdatePosition()
		{
			shots.UpdatePosition(sunLocation);

			if ((state != ShipState.Normal) &&
				(state != ShipState.HyperCharge))
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

				// update velocity due to the gravity of the sun...
			Vector gravity = new Vector(position, sunLocation);
			float length = gravity.Length;
			gravity = (gravity.MakeUnit() * Constants.G) * (1.0f / (length * length));
			velocity += gravity;
			if (length < Constants.SunCollisionLimit)
			{
				SetState(ShipState.Dying);
				scoreForOthers++;
			}
		}

		public void UpdateState(ref int scoreForOtherPlayers)
		{
			if (state == ShipState.Dying)
			{
				this.waitCount--;
				if (waitCount == 0)
				{
					SetState(ShipState.Dead);
				}
			}

			if (state == ShipState.Dead)
			{
				this.waitCount--;
				if (waitCount == 0)
				{
					SetState(ShipState.Normal);
				}
			}

			if (state == ShipState.HyperCharge)
			{
				this.waitCount--;
				this.outline.ChangeCurrentStep(Constants.RotateSteps / 2);
				//this.outline.ChangeCurrentStep(5 - Constants.random.Next(10));
				if (waitCount == 0)
				{
						// if we didn't make it, we're dying...
					double randValue = Constants.random.NextDouble();
					if (hyperSuccess < randValue)
					{
						SetState(ShipState.Dying);
						scoreForOthers++;
					}
					else
					{
						SetState(ShipState.Hyper);
					}
				}
			}
			if (state == ShipState.Hyper)
			{
				this.waitCount--;
				if (waitCount == 0)
				{
					hyperSuccess -= Constants.HyperSuccessDegradation;
					float save = this.hyperSuccess;
					SetState(ShipState.Normal);
					hyperSuccess = save;
				}
			}

			scoreForOtherPlayers = scoreForOthers;
			scoreForOthers = 0;
		}

			// see if the other ship has hit us, or if the other shots have hit us
		public void TestShip(RemotePlayer player)
		{
			Ship otherShip = player.Ship;

				// if we're not alive, don't do any tests...
			if (state != ShipState.Normal)
				return;

				// Test if their shots are close enough to us. 
			if (otherShip.shots.TestShots(this))
			{
				SetState(ShipState.Dying);
				player.ScoreToOther += 2;		// give them 2 points
			}

			Vector delta = this.position - otherShip.position;
			if (delta.Length < Constants.ShipCollisionLimit)
			{
				SetState(ShipState.Dying);
				scoreForOthers++;				// all other players get a point...
			}
		}

		public void Draw(DirectDrawSurface7 surface, int shipColor, int shotColor)
		{
			if ((state == ShipState.Dead) ||
				(state == ShipState.Hyper))
				return;

			if (state == ShipState.Dying)
			{
				float factor = (float) this.waitCount / Constants.DyingCycle;

				int c1 = (int) ((shipColor & 0xFF0000) * factor) & 0xFF0000;
				int c2 = (int) ((shipColor & 0x00FF00) * factor) & 0x00FF00;
				int c3 = (int) ((shipColor & 0x0000FF) * factor) & 0x0000FF;

				shipColor = c1 + c2 + c3;
			}

			surface.SetForeColor(shipColor);
			outline.Center = new Point((int) position.X, (int) position.Y);

			outline.Draw(surface, 0, 2);	// draw ship...
			if (flameIndex != -1)
			{
				outline.Draw(surface, flameFrame[flameIndex], flameFrame[flameIndex]);
			}

			surface.SetForeColor(shotColor);
			shots.Draw(surface);
		}

		public void DrawHostName(DirectDrawSurface7 surface, Point location, int color)
		{
			if (hostName == null)
				return;

			if (hostNameWord == null)
			{
				hostNameWord = new Word(hostName, Constants.LetterSize);
			}

			hostNameWord.Draw(surface, color, Constants.LetterSpacing, location);
		}

		public void RotateLeft()
		{
			outline.DecrementCurrentStep();
		}

		public void RotateRight()
		{
			outline.IncrementCurrentStep();
		}
	}
}
