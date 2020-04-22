using System;

namespace CodeRunner
{
	public class Gold
	{
		public Gold()
		{
		}

		public Gold(Vector pos)
		{
			Position = pos;
		}
		
		public int CarryingMonk 
		{   
			set { m_nMonk = value; }
			get { return m_nMonk; } 
		}

		public Vector Position 
		{  
			set { m_pos = value; }
			get { return m_pos; } 
		}

		private int m_nMonk;
		private Vector m_pos;
	}
}
