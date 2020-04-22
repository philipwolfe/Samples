using System;
using System.Drawing;

namespace CodeRunner
{
	public abstract class Runner
	{
		public Runner()
		{
			m_nCurAction = UserAction.Stop;
			ResetCycle();
		}

		public void SetPosition(Vector pos)
		{
			SetPosition(pos.XPos, pos.YPos);
		}
		
		public void SetPosition(int XPos, int YPos)
		{
			m_Pos.XPos = XPos;
			m_Pos.YPos = YPos;
		}

		public void ResetCycle()
		{
			m_nAnimCycle = 1;
		}

		public int IncrementCycle()
		{
			m_nAnimCycle++;
			if (m_nAnimCycle>AnimationCycle)
				ResetCycle();

			return m_nAnimCycle;
		}


		#region Old Code
//		protected virtual void OnMove()
//		{
//		}
//
//		protected virtual void OnCenteredOnTile()
//		{
//		}
//
//		protected virtual bool UseNormalIteration()
//		{
//			return true;
//		}
//
//		protected virtual void PerformAction(ref int DeltX, ref int DeltY)
//		{
//			// just handle movement on the base class
//			if (m_nCurAction==UserAction.Left)
//				DeltX = -Constants.HERO_XSPEED;
//			else if (m_nCurAction==UserAction.Right)
//				DeltX = Constants.HERO_XSPEED;
//			else if (m_nCurAction==UserAction.Up)
//				DeltY = -Constants.HERO_YSPEED;
//			else if (m_nCurAction==UserAction.Down)
//				DeltY = Constants.HERO_YSPEED;
//		}
//
//		public virtual void Iterate()
//		{
//			if (m_nCurAction!=UserAction.Stop)
//				IncrementCycle();
//
//			if (UseNormalIteration())
//			{
//				OnMove();
//				//CheckProcessUserAction();
//
//				if (IsCenteredOnTile())
//				{
//					OnCenteredOnTile();
//					CheckFalling();
//				}
//			}
//
//			int DeltX = 0, DeltY = 0;
//			if (m_bFalling)
//				DeltY = Constants.HERO_FALLSPEED;
//			else
//			{
//				if (m_nCurAction==UserAction.Stop)
//					return;
//
//				PerformAction(ref DeltX, ref DeltY);
//			}
//
//			Vector newPos = Utility.OffsetVector(m_Pos, DeltX, DeltY);
//			m_Pos = newPos;
//		}
		#endregion

		public bool IsCenteredOnTile()
		{
			if (m_Pos.YPos % Constants.TILE_HEIGHT==0 && m_Pos.XPos % Constants.TILE_WIDTH==0)
				return true;
			else
				return false;
		}

		public bool IsCenteredHorizontally()
		{
			if (m_Pos.XPos % Constants.TILE_WIDTH==0)
				return true;
			else
				return false;
		}

		public bool IsCenteredVertically()
		{
			if (m_Pos.YPos % Constants.TILE_HEIGHT==0)
				return true;
			else
				return false;
		}

		public Vector Position { get { return m_Pos; } }
		public Vector Tile
		{
			get
			{
				Vector vecTile = Utility.OffsetVector(m_Pos, Constants.TILE_WIDTH/2, Constants.TILE_HEIGHT/2);
				vecTile.XPos /= Constants.TILE_WIDTH;
				vecTile.YPos /= Constants.TILE_HEIGHT;
				return vecTile;
			}
		}

		public Rectangle GetRectangle()
		{
			return new Rectangle(m_Pos.XPos,m_Pos.YPos,Constants.TILE_WIDTH,Constants.TILE_HEIGHT);
		}

		public Vector AbsoluteTile
		{
			get
			{
				Vector vecTile = m_Pos;
				vecTile.XPos /= Constants.TILE_WIDTH;
				vecTile.YPos /= Constants.TILE_HEIGHT;
				return vecTile;
			}
		}


		// iteration loop and virtual methods
		public void Iterate()
		{
			// check to see if the player is dead
			if (IsCrushed())
			{
				OnCrushedByHole();
				return;
			}

			// check to see if digging or falling or trapped where no other
			// action is possible until completed.
			if (!IsActionComplete())
				ContinueAction();
			else
			{
				// check if we are falling
				if (ShouldBeFalling())
					Drop();
				else
				{
					// if we are not, then see if there is a next move requested
					UserAction attempt = GetNextAction();
					if (IsValidAction(attempt))
						m_nCurAction = attempt;
					else
						m_nCurAction = UserAction.Stop;
				}

				PerformAction();
			}
		}

		private bool IsCrushed()
		{
			Element at = Game.Level.GetAt(Tile.XPos, Tile.YPos);
			if (at==Element.Brick && Game.FindHoleAt(Tile)==-1)
				return true;

			return false;
		}

		protected abstract void OnCrushedByHole();

		protected virtual bool IsActionComplete()
		{
			if (m_nCurAction==UserAction.Stop)
				return true;

			// for directional moves, just make sure that the user is centered
			return IsCenteredOnTile();
		}

		protected virtual void ContinueAction()
		{
			MoveRunner();
		}

		protected virtual bool ShouldBeFalling()
		{
			bool bFalling = false;

			if (!IsCenteredOnTile())
				return false;

			if (m_nCurAction==UserAction.Climb)
				return false;

			// first check if falling
			Vector pos = Tile;
			Vector posBelow = Utility.OffsetVector(pos,0,1);
			if (pos.YPos<Constants.BOARD_HEIGHT-1)
			{
				Element below = Game.Level.GetAt(posBelow.XPos, posBelow.YPos);
				if ((below==Element.None || below==Element.Escape || below==Element.Rope || below==Element.Trick ||
					(below==Element.Brick && Game.FindCompleteHoleAt(posBelow)!=-1)) && !AboveMonk())
				{
					Element at = Game.Level.GetAt(pos.XPos, pos.YPos);
					if (at==Element.Rope)
					{
						if (m_nCurAction==UserAction.Down)
							bFalling = true;
					}
					else if (at!=Element.Ladder)
						bFalling = true;
				}
			}

			return bFalling;
		}

		protected virtual bool AboveMonk()
		{
			Vector posBelow = Utility.OffsetVector(Tile,0,1);
			return (bool)(Game.FindMonkAt(posBelow)!=-1);
		}

		protected virtual void Drop()
		{
			m_nCurAction = UserAction.Fall;
		}

		protected virtual UserAction GetNextAction()
		{
			//this should be overriden
			return UserAction.Stop;
		}

		public virtual bool IsValidAction(UserAction act)
		{
			int DirX = 0, DirY = 0;
			
			//check the directional stuff only
			switch (act)
			{
				case UserAction.Left: DirX = -1; break;
				case UserAction.Right: DirX = 1; break;
				case UserAction.Up: DirY = -1; break;
				case UserAction.Down: DirY = 1; break;
				case UserAction.Fall: DirY = 1; break;
			}

			return !IsDestinationBlocked(DirX, DirY);
		}

		protected virtual void PerformAction()
		{
			// just move the guy
			MoveRunner();
		}

		protected virtual bool IsDestinationBlocked(int DeltaX, int DeltaY)
		{
			Vector pos = Utility.OffsetVector(Tile, DeltaX, DeltaY);

			if (DeltaY==-1 && Game.Level.GetAt(pos.XPos, pos.YPos+1)!=Element.Ladder)
				return true;

			return Game.Level.IsPositionBlocked(pos);
		}

		protected void MoveRunner()
		{
			// do the directional stuff
			int DirX = 0, DirY = 0;
			switch (m_nCurAction)
			{
				case (UserAction.Left): DirX = -Constants.HERO_XSPEED; break;
				case (UserAction.Right): DirX = Constants.HERO_XSPEED; break;
				case (UserAction.Up): DirY = -Constants.HERO_YSPEED; break;
				case (UserAction.Down): DirY = Constants.HERO_YSPEED; break;
				case (UserAction.Fall): DirY = Constants.HERO_YSPEED; break;
				case (UserAction.Climb): DirY = -Constants.HERO_YSPEED; break;
			}

			Vector newPos = Utility.OffsetVector(m_Pos, DirX, DirY);
			if (CanMoveTo(newPos))
			{
				m_Pos = newPos;

				if (DirX!=0 || DirY!=0)
					IncrementCycle();
			}
		}

		public virtual bool CanMoveTo(Vector newPos)
		{
			return true;
		}

		// properties
		public int Cycle { get { return m_nAnimCycle; } }
		public int AnimCell { get { return Cycle;	} }

		public UserAction CurrentAction 
		{ 
			get { return m_nCurAction; }
			set { m_nCurAction = value; } 
		}


		// internal members
		private const int AnimationCycle = 12;
		protected Vector m_Pos;
		protected int m_nAnimCycle;
		protected UserAction m_nCurAction;
	}
}
