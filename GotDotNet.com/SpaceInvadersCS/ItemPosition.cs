using System;
using System.Diagnostics;

namespace Microsoft.Samples.SpaceInvaders
{
	// an enum for the direction and position in which
	// the players ship is moving
	public enum ShipPosition
	{
		Initial = 0,
		MoveLeft = 1,
		MoveRight = 2
	}

	// this class represents the position of an entity,
	// and can include a the position of a shield, a bullet,
	// or an invader
	public class ItemPosition
	{
		private int _left;

		private int _top;


		public ItemPosition(int left, int top)
		{
			_left = left;
			_top = top;
		}


		public int Left
		{
			get
			{
				//TraceListener tl = new TraceListener
				return _left;
			}
			set
			{
				_left = value;
			}
		}


		public int Top
		{
			get
			{
				return _top;
			}
			set
			{
				_top = value;
			}
		}
	}
}
