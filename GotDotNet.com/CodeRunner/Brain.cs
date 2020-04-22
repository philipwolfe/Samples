using System;

namespace CodeRunner
{
	public class Brain
	{
		public Brain()
		{
		}

		public virtual void InitializeNewLevel(Level objLevel)
		{
			m_objLevel = objLevel;
		}

		public virtual void OnHeroMoved()
		{
		}

		public virtual UserAction GetNextMove(Monk objMonk, Hero objHero)
		{
			int nHeroYPos = objHero.AbsoluteTile.YPos;	int nHeroXPos = objHero.AbsoluteTile.XPos;
			int nMonkYPos = objMonk.AbsoluteTile.YPos;	int nMonkXPos = objMonk.AbsoluteTile.XPos;

			if (nHeroYPos==nMonkYPos && objMonk.IsCenteredVertically())
			{
				if (nHeroXPos<nMonkXPos)
					return UserAction.Left;
				else if (nHeroXPos>nMonkXPos)
					return UserAction.Right;
				else
					return UserAction.Stop;
			}
			else
			{
				int nBestX = 100;
				if (nHeroYPos<nMonkYPos)
				{
					if (CanGoUp(nMonkXPos, nMonkYPos) && objMonk.IsCenteredHorizontally())
						return UserAction.Up;
					else
					{
						for (int x=0; x<Constants.BOARD_WIDTH; x++)
						{
							if (CanGoUp(x, nMonkYPos) && 
								System.Math.Abs(nMonkXPos-x)<System.Math.Abs(nMonkXPos-nBestX) &&
								CanGetTo(nMonkYPos, nMonkXPos, x))
								nBestX = x;
						}
					}
				}
				else
				{
					if (CanGoDown(nMonkXPos, nMonkYPos) && objMonk.IsCenteredHorizontally())
						return UserAction.Down;
					else
					{
						for (int x=0; x<Constants.BOARD_WIDTH; x++)
						{
							if (CanGoDown(x, nMonkYPos) && 
								System.Math.Abs(nMonkXPos-x)<System.Math.Abs(nMonkXPos-nBestX) &&
								CanGetTo(nMonkYPos, nMonkXPos, x))
								nBestX = x;
						}
					}
				}

				if (objMonk.IsCenteredVertically() && nBestX!=100)
				{
					if (nMonkXPos>nBestX)
						return UserAction.Left;
					else
						return UserAction.Right;
				}
			}

			return UserAction.Stop;
		}

		private bool CanGoUp(int x, int y)
		{
			if (y<=0) return false;

			Element	elAbove = m_objLevel.GetAt(x, y-1);

			if (m_objLevel.GetAt(x, y)==Element.Ladder && 
					(elAbove!=Element.Stone && elAbove!=Element.Trick &&
					 (elAbove!=Element.Brick || (elAbove==Element.Brick && Game.FindHoleAt(Utility.MakeVector(x, y-1))!=-1))))
				return true;
			else
				return false;
		}

		private bool CanGoDown(int x, int y)
		{
			if (y>=Constants.BOARD_HEIGHT-1)
				return false;

			Element elBelow = m_objLevel.GetAt(x, y+1);
			if (elBelow!=Element.Brick && elBelow!=Element.Stone)
				return true;
			else
				return false;
		}

		private bool CanGetTo(int nCurY, int nCurX, int nDestX)
		{
			do 
			{
				if (nDestX<nCurX)
					nCurX--;
				else
					nCurX++;

				if (!m_objLevel.IsPositionStable(Utility.MakeVector(nCurX, nCurY)))
				{
					if (nCurX==nDestX && 
						(m_objLevel.GetAt(nCurX, nCurY)==Element.None || 
						 m_objLevel.GetAt(nCurX, nCurY)==Element.Escape))
						return true;

					return false;
				}

			} while (nCurX!=nDestX);
			
			return true;
		}

		private Level m_objLevel;
	}
}
