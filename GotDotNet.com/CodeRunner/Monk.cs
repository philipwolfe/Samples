using System;
using System.Drawing;

namespace CodeRunner
{
	public class Monk : Runner
	{
		private static Random m_Rand = new System.Random(1);

		public Monk()
		{
			m_nCollisionCount = 0;
			m_bCarrying = false;
		}

		public bool IsCarrying 
		{
			get
			{
				return m_bCarrying;
			}
		}

		public bool IsTrapped
		{
			get
			{
				return m_bTrapped;
			}
		}

		protected override UserAction GetNextAction()
		{
			//can only get next move
			return Game.Brain.GetNextMove(this, Game.Hero);
		}

		protected override void PerformAction()
		{
			if (!m_bCarrying)
			{
				int nGoldID = Game.FindGoldAt(Tile);
				if (nGoldID!=-1)
				{
					if (m_Rand.Next(Constants.MONK_PICKUP_RATE)==Constants.MONK_PICKUP_RATE-1)					
					{
						m_bCarrying = true;
						Game.RemoveGold(nGoldID);
					}
				}
			}
			else
			{
				Element at = Game.Level.GetAt(Tile.XPos, Tile.YPos);
				Element below = Element.Stone;
				if (Tile.YPos<Constants.BOARD_HEIGHT-1)
					below = Game.Level.GetAt(Tile.XPos, Tile.YPos+1);
				if (at==Element.None && (below==Element.Stone || below==Element.Brick || 
					below==Element.Stone || below==Element.Brick))
				{
					if (Game.FindGoldAt(Tile)==-1)
					{
						if (m_Rand.Next(Constants.MONK_DROP_RATE)==Constants.MONK_DROP_RATE-1)
						{
							Game.AddGold(Tile);
							m_bCarrying = false;
						}
					}
				}
			}

			base.PerformAction();
		}

		protected override void Drop()
		{
			// check to see if the monk is falling into a dug hole
			Vector below = Utility.OffsetVector(AbsoluteTile, 0, 1);
			if (Game.FindHoleAt(below)!=-1)
			{
				if (m_bCarrying)
				{
					Game.AddGold(Tile);
					m_bCarrying = false;
				}

				m_bTrapped = true;
				m_nTrapCount = -1;
			}

			// do the fall
			base.Drop();
		}

		protected override bool IsActionComplete()
		{
			if (m_bTrapped)
			{
				if (!IsCenteredOnTile())
					return false;
				else
				{
					if (m_nTrapCount==-1)
						m_nTrapCount=0;  // kick off the counter

					if (m_nTrapCount>=Constants.MONK_TRAPTIME)
					{
						Vector posAbove = Utility.OffsetVector(Tile,0,-1);
						if (Game.FindMonkAt(posAbove)==-1)
						{
							m_nCurAction = UserAction.Climb;
							m_bTrapped = false;
						}
						
						m_nTrapCount = 0;

						return false;
					}
					else
						return false;
				}
			}

			return base.IsActionComplete();
		}

		protected override void OnCrushedByHole()
		{
			// show up somewhere else
			System.Random rnd = new System.Random();
			Element at = Element.Brick;
			bool bMoved = false;

			Vector pos = new Vector();

			for (pos.YPos=0; pos.YPos<Constants.BOARD_HEIGHT && !bMoved; pos.YPos++)
			{
				for (int n=0; n<Constants.BOARD_WIDTH/2 && !bMoved; n++)
				{
					pos.XPos = rnd.Next(0, Constants.BOARD_WIDTH-1);
					at = Game.Level.GetAt(pos.XPos, pos.YPos);
					if (at==Element.None || at==Element.Escape)
					{
						Reset();
						SetPosition( Utility.TileToScreen( pos ) );

						bMoved = true;
						break;
					}
				}
			}
		}
		
		protected override void ContinueAction()
		{
			if (m_bTrapped && m_nTrapCount>=0) 
			{
				m_nTrapCount++;
				return;
			}

			base.ContinueAction();
		}

		public override bool CanMoveTo(Vector newPos)
		{
//			if (IsTrapped) return true;
			for (int n=0; n<Game.Monks.Count; n++)
			{
				Monk objFriend = (Monk)Game.Monks[n];
				if (!objFriend.Equals(this))// && !objFriend.IsTrapped)
				{
					Vector othPos = objFriend.Position;
					Rectangle rectMine = new Rectangle(newPos.XPos,newPos.YPos,Constants.TILE_WIDTH,Constants.TILE_HEIGHT);
					Rectangle rectFriend = new Rectangle(othPos.XPos,othPos.YPos,Constants.TILE_WIDTH,Constants.TILE_HEIGHT);
					
					if (rectMine.IntersectsWith(rectFriend))
					{
						if (this.SuperiorTo(objFriend) && this.RunningOppositeTo(objFriend))
						{
							m_nCollisionCount++;
							if (m_nCollisionCount>3)
								return base.CanMoveTo(newPos);
						}

						m_nCurAction = Game.Brain.GetNextMove(this, Game.Hero);
						return false;
					}
				}
			}

			m_nCollisionCount = 0;
			return base.CanMoveTo(newPos);
		}

		private bool SuperiorTo(Monk objFriend)
		{
			for (int n=0; n<Game.Monks.Count; n++)
			{
				Monk objMonk = (Monk)Game.Monks[n];
				if (objMonk.Equals(this))
					return true;
				else if (objMonk.Equals(objFriend))
					return false;
			}

			return true;
		}


		protected override bool AboveMonk()
		{
			Vector posBelow = Utility.OffsetVector(Tile,0,1);
			int nMonkID = Game.FindMonkAt(posBelow);

			if (nMonkID==-1)
				return false;
			else
			{
				Monk objMonk = (Monk)Game.Monks[nMonkID];
				return objMonk.IsTrapped;
			}
		}

		private bool RunningOppositeTo(Monk objFriend)
		{
			if (objFriend.CurrentAction==UserAction.Left && this.CurrentAction==UserAction.Right)
				return true;

			if (objFriend.CurrentAction==UserAction.Right && this.CurrentAction==UserAction.Left)
				return true;

			return false;
		}

		public void Reset()
		{
			m_bTrapped = false;
			m_bCarrying = false;
			m_nTrapCount = 0;
		}

		private bool m_bTrapped;
		private bool m_bCarrying;
		private int m_nTrapCount;
		
		// don't be stuck in a collision for more than 3 iterations.
		private int m_nCollisionCount;
	}
}
