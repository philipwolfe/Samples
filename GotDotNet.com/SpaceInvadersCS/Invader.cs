using System;
using System.Collections.Generic;

namespace Microsoft.Samples.SpaceInvaders
{
	// this class represents a logical 'invader',
	// which is basically comprised of its position
	[CLSCompliant(false)]
	public class Invader
	{
		ItemPosition _position;

		int _id;

		public Invader(ItemPosition ip, int id)
		{
			_position = ip;
			_id = id;
		}

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

		public int Identification
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public bool CanFire(List<Invader> invaders)
		{
			if (_id > 32)
				return true;

			foreach (Invader i in invaders)
			{
				if (i.Identification > _id && ((i.Identification - _id) % 8 == 0))
					return false;
			}
			return true;
		}
	}
}
