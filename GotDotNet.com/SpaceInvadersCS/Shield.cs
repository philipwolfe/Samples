using System;

namespace Microsoft.Samples.SpaceInvaders
{
	// this class represents the player's shields
	// each shield is a single character, and every
	// single shield is tracked independently
	public class Shield
	{
		ItemPosition _position;

		bool _shieldFull;


		public Shield(ItemPosition ip)
		{
			_position = ip;
			_shieldFull = true;
		}

		[CLSCompliant(false)]
		public ItemPosition Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}


		public bool ShieldFull
		{
			get
			{
				return _shieldFull;
			}
			set
			{
				_shieldFull = value;
			}
		}
	}
}
