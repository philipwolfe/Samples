using System;

namespace CodeRunner
{
	public class Hole
	{
		public Hole(Vector pos)
		{
			SetPos(pos);
			m_nDepth = 0;
			m_nTicker = 0;
		}

		public void SetPos(Vector pos)
		{
			m_Pos = pos;
		}

		public int Depth
		{
			get { return m_nDepth; }
		}

		public bool FallThrough
		{
			get { return true; } //return (bool)(m_nDepth > 1); }
		}

		public bool Iterate()
		{
			m_nTicker++;

			// check if we need to invalidate
			if (m_nTicker<=Constants.HOLE_ANIMATION_ITERATION || 
				m_nTicker>=Constants.HOLE_LIFETIME - Constants.HOLE_ANIMATION_ITERATION)
			{
				if (m_nTicker<=Constants.HOLE_ANIMATION_ITERATION)
					m_nDepth = m_nTicker;

				if (m_nTicker>=Constants.HOLE_LIFETIME - Constants.HOLE_ANIMATION_ITERATION)
					m_nDepth = Constants.HOLE_LIFETIME - m_nTicker;

				// about to change state add me to the invalid rects
				Vector screen = Utility.OffsetVector( Utility.TileToScreen(m_Pos), Constants.LEFT_OFFSET, Constants.TOP_OFFSET);
			}

			if (m_nTicker==Constants.HOLE_LIFETIME)
				return false;
			else
				return true;
		}

		public Vector Position { get { return m_Pos; } }

		private int m_nTicker = 0;
		private int m_nDepth = 0;
		private Vector m_Pos;
	}
}
