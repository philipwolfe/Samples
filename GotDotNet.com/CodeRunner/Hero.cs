using System;

namespace CodeRunner
{

	public class Hero : Runner
	{
		public Hero() 
		{
		} 

		protected override void PerformAction()
		{
			int nGoldID = Game.FindGoldAt(Tile);
			if (nGoldID!=-1)
			{
				Sound.PlayGetGold();
				Game.RemoveGold(nGoldID);
			}

			if (m_nCurAction==UserAction.DigLeft)
				StartDig(-1);
			else if (m_nCurAction==UserAction.DigRight)
				StartDig(1);
			else
				base.PerformAction();
		}

		protected override UserAction GetNextAction()
		{
			// the next action should be the user's request
			return Game.UserAction;
		}

		protected override void OnCrushedByHole()
		{
			Game.GameState = GameState.Lost;
		}

		protected override void ContinueAction()
		{
			if (m_nCurAction==UserAction.DigLeft || m_nCurAction==UserAction.DigRight)
				IncrementCycle();

			base.ContinueAction();
		}

		protected override bool IsActionComplete()
		{
			// check to see if the move is in the opposite direction to cancel the current move
			if (m_nCurAction==UserAction.Left && Game.UserAction==UserAction.Right)
				return true;

			if (m_nCurAction==UserAction.Right && Game.UserAction==UserAction.Left)
				return true;

			if (m_nCurAction==UserAction.Up && Game.UserAction==UserAction.Down)
				return true;

			if (m_nCurAction==UserAction.Down && Game.UserAction==UserAction.Up)
				return true;

			if (m_nCurAction==UserAction.DigLeft || m_nCurAction==UserAction.DigRight)
			{
				if (Cycle>=Constants.HOLE_ANIMATION_ITERATION)
					return true;
				else
					return false;
			}

			return base.IsActionComplete();
		}

		public override bool IsValidAction(UserAction act)
		{
			// if the requests are digs, check to see if we can do it
			if (act==UserAction.DigLeft || act==UserAction.DigRight)
			{
				int nPos = (act==UserAction.DigLeft) ? -1 : 1;
				
				// if there is a blocking tile directly to the right or left of us, then don't dig
				if (IsDestinationBlocked(nPos,0))
					return false;

				Vector dig = Utility.OffsetVector(Tile, nPos, 1);

				if (dig.XPos>=0 && dig.XPos<Constants.BOARD_WIDTH && dig.YPos<Constants.BOARD_HEIGHT)
				{
					Vector aboveDig = Utility.OffsetVector(Tile, nPos, 0);
					Element above = Game.Level.GetAt(aboveDig.XPos, aboveDig.YPos);
					if (above==Element.Ladder)
						return false;

					Element at = Game.Level.GetAt(dig.XPos, dig.YPos);
					if (at==Element.Brick)
					{
						// make sure there isn't a hole in there already
						if (Game.FindHoleAt(dig)==-1)
							return true;
					}
				}

				return false;
			}

			return base.IsValidAction(act);
		}


		private void StartDig(int nPos)
		{
			Sound.PlayDig();
			Vector dig = Utility.OffsetVector(Tile, nPos, 1);

			// clear the animation cycle
			ResetCycle();
			Game.Holes.Add(new Hole(dig));

			// after digging, don't continue digging, just stop
			Game.UserAction = UserAction.Stop;
		}
	}
}
