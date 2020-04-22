using System;

namespace CodeRunner
{
	/// <summary>
	/// Summary description for BunglerBrain.
	/// </summary>
	public class BunglerBrain : Brain
	{
		public BunglerBrain()
		{
			m_aUpGoal = new uint[Constants.BOARD_WIDTH+2];
			m_aDownGoal = new uint[Constants.BOARD_WIDTH+2];
		}

		public override void InitializeNewLevel(Level objLevel)
		{
			ScanLevelGrid();
		}

		public override void OnHeroMoved()
		{
			PrepareFlagsRelativeToHero();
		}

		public override UserAction GetNextMove(Monk objMonk, Hero objHero)
		{
			// don't think if you are not on a tile
			if (!objMonk.IsCenteredHorizontally() && !objMonk.IsCenteredVertically())
				return objMonk.CurrentAction;

			int nMonkXPos = objMonk.Tile.XPos+1;
			int nMonkYPos = objMonk.Tile.YPos;
			int nHeroXPos = objHero.Tile.XPos+1;
			int nHeroYPos = objHero.Tile.YPos;
			uint nBitFlag = (uint)1 << nMonkYPos;
			int x = nMonkXPos;

			// if the Monk and the Player are on the same vertical row, then seek a straight line if possible
			if (objMonk.IsCenteredVertically())
			{
				if (nMonkYPos==nHeroYPos)
				{
					// they are on the same spot, so may as well stop cause game is over.
					if (nMonkXPos==nHeroXPos) return UserAction.Stop;

					// seek a stable and enterable line to the player
					if (x<nHeroXPos)
					{
						x++;
						while ((m_aEnterable[x] & m_aStable[x] & nBitFlag)!=0)
						{
							if (x==nHeroXPos) return UserAction.Right;
							x++;
						}
					}
					else
					{
						x--;
						while ((m_aEnterable[x] & m_aStable[x] & nBitFlag)!=0)
						{
							if (x==nHeroXPos) return UserAction.Left;
							x--;
						}
					}
				}
			}

			// time to scan vertically
			m_nMask = (1<<(Constants.BOARD_HEIGHT))-1;
			m_nBitsBelowMonk = (uint)m_nMask & ((uint)-nBitFlag) & (~nBitFlag);
			m_nBitsAboveMonk = (uint)nBitFlag-1;

			m_nBestDist = 500;		// don't know what this is yet
			m_nBestDir = UserAction.Stop;
			m_nThisDir = UserAction.Stop;

			if (objMonk.IsCenteredHorizontally())
			{
				if ((m_aCantAscend[nMonkXPos]&nBitFlag)==0)
				{
					m_nThisDir = UserAction.Up;
					if (UpRate(m_aUpGoal[nMonkXPos] & m_nBitsAboveMonk, 0)==0) 
						return m_nBestDir;
				}
				if ((m_aCantDescend[nMonkXPos]&nBitFlag)==0)
				{
					m_nThisDir = UserAction.Down;
					if (DownRate(m_aDownGoal[nMonkXPos] & m_nBitsBelowMonk & m_nMask, 0)==0) 
						return m_nBestDir;
				}
			}
			
			if (objMonk.IsCenteredVertically())
			{
				// check left of the monk to see if we can go up or down
				m_nThisDir = UserAction.Left;
				x = nMonkXPos;
				while ((m_aEnterable[--x]&nBitFlag)!=0)
				{
					if ((m_aCantDescend[x]&nBitFlag)==0)
						if (DownRate(m_aDownGoal[x] & m_nBitsBelowMonk, nMonkXPos-x)==0) break;
					if ((m_aStable[x]&nBitFlag)==0)
						break;
					if ((m_aCantAscend[x]&nBitFlag)==0)
						if (UpRate(m_aUpGoal[x] & m_nBitsAboveMonk, nMonkXPos-x)==0) break;
				}

				// check right of the monk to see if we can go up or down
				m_nThisDir = UserAction.Right;
				x = nMonkXPos;
				while ((m_aEnterable[++x]&nBitFlag)!=0)
				{
					if ((m_aCantDescend[x]&nBitFlag)==0)
						if (DownRate(m_aDownGoal[x] & m_nBitsBelowMonk, x-nMonkXPos)==0) break;
					if ((m_aStable[x]&nBitFlag)==0)
						break;
					if ((m_aCantAscend[x]&nBitFlag)==0)
						if (UpRate(m_aUpGoal[x] & m_nBitsAboveMonk, x-nMonkXPos)==0) break;
				}
			}

			return m_nBestDir;
		}

		private int UpRate(uint nBits, int nDelta)
		{
			uint ax = 1<<(Constants.BOARD_HEIGHT);
			while ((ax & nBits)==0)
				ax>>=1;

			ax&=m_nMask;
            if (ax==0) return 1;

			if ((ax & m_nBitsAboveHero)!=0)
			{
				m_nMask = (uint)(-(ax+ax) & m_nBitsAboveHero);
				if (m_nMask!=0)
				{
					m_nBestDir = m_nThisDir;
					return (int)m_nBestDir;
				}

				m_nMask = (m_nBitsAboveHero>>1)+1;
				if (nDelta<m_nBestDist)
				{
					m_nBestDist = nDelta;
					m_nBestDir = m_nThisDir;
				}
				return 0;
			}
			else
			{
				m_nMask = ax-1;
				m_nBestDir = m_nThisDir;
				return (int)m_nBestDir;
			}
		}

		private int DownRate(uint nBits, int nDelta)
		{
			if (nBits==0) return 1;
			uint ax = ((nBits-1)^nBits) & nBits;

			ax&=m_nMask;
			if (ax==0) return 1;
			if ((ax & m_nBitsAboveHero)!=0)
			{
				m_nMask = (uint)(-(ax+ax) & m_nBitsAboveHero);
				if (m_nMask!=0)
				{
					m_nBestDir = m_nThisDir;
					return (int)m_nBestDir;
				}

				m_nMask = (m_nBitsAboveHero>>1) + 1;
				if (nDelta<m_nBestDist)
				{
					m_nBestDist = nDelta;
					m_nBestDir = m_nThisDir;
				}
				return 0;
			}
			else
			{
				m_nMask = ax-1;
				m_nBestDir = m_nThisDir;
				return (int)m_nBestDir;
			}
		}

		private void PrepareFlagsRelativeToHero()
		{
			//m_bMovesPrepared = true;

			Hero objHero = Game.Hero;
			int nHeroXPos = objHero.Tile.XPos+1;
			int nHeroYPos = objHero.Tile.YPos;
			uint nBitFlag = (uint)1 << nHeroYPos;
			
			// bits above and below inclusive.
			m_nBitsBelowHero = (((1<<Constants.BOARD_HEIGHT)-1) & (uint)-nBitFlag);
			m_nBitsAboveHero = (nBitFlag<<1)-1;

			for(int x=1;x<=Constants.BOARD_WIDTH;x++)				// scan through the X axis
			{
				int xDest=x;						
				if(x<nHeroXPos) xDest++;			// if i<x position of hero, j=position to right of i /  j is ideal x direction
				if(x>nHeroXPos) xDest--;			// if i>x position of hero, j=position to left of i

				uint nDir=m_aStable[x] & m_aStable[xDest] & m_aEnterable[xDest];			// t = bits are what rows can you move on the towards hero 
				m_aUpGoal[x]=(nDir & m_nBitsAboveHero) | m_aCantAscend[x];			// upgoal = bits of t above hero and any bit you cant ascend	
				m_aDownGoal[x]=(nDir & m_nBitsBelowHero) | m_aCantDescend[x];		// downgoal = bits of t below hero and any bit you cant descend
			}
		}

		private void ScanLevelGrid()
		{
			// these arrays represent properties of each cell in the level/board.
			// the bits of the integer represent the Y axis.  the X axis is the elements in the array
			m_aEnterable = new uint[Constants.BOARD_WIDTH+2];
			m_aStable = new uint[Constants.BOARD_WIDTH+2];
			m_aCantDescend = new uint[Constants.BOARD_WIDTH+2];
			m_aCantAscend = new uint[Constants.BOARD_WIDTH+2];

			for (int x=1; x<=Constants.BOARD_WIDTH; x++)
			{
				m_aCantAscend[x] = 1;
				m_aCantDescend[x] = m_aEnterable[x] = m_aStable[x] = 0;

				for (int y=0; y<Constants.BOARD_HEIGHT; y++)
				{
					uint nBitSet = (uint)1 << y;
					
					Element at = Game.Level.GetAt(x-1,y);
					Element below = (y<Constants.BOARD_HEIGHT-1) ? Game.Level.GetAt(x-1,y+1) : Element.Stone;
					
					if (at==Element.None || at==Element.Ladder || at==Element.Escape || at==Element.Rope)
						m_aEnterable[x] |= nBitSet;

					if (at!=Element.Ladder)
						m_aCantAscend[x] |= nBitSet;

					if (below==Element.Brick || below==Element.Stone || below==Element.Trick)
						m_aCantDescend[x] |= nBitSet;
					
					if ((at==Element.Rope || at==Element.Ladder) || 
						(below==Element.Brick || below==Element.Stone || below==Element.Ladder || below==Element.Trick))
						m_aStable[x] |= nBitSet;
				}

				// set the borders
				m_aEnterable[0] = 0;
				m_aEnterable[Constants.BOARD_WIDTH+1] = 0;

				// m_bMovedPrepared = false;
			}
		}

		// running thought variables
		// private bool m_bMovesPrepared;

		private uint[] m_aDownGoal;
		private uint[] m_aUpGoal;
		uint m_nBitsBelowHero;
		uint m_nBitsAboveHero;

		uint m_nBitsBelowMonk;
		uint m_nBitsAboveMonk;

		int m_nBestDist;
		UserAction m_nBestDir;
		UserAction m_nThisDir;
		uint m_nMask;
		
		// level preanalysis variables
		private uint[] m_aEnterable;
		private uint[] m_aStable;
		private uint[] m_aCantAscend;
		private uint[] m_aCantDescend;
	}
}
