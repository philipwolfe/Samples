using System;

namespace Microsoft.Samples.SpaceInvaders
{
	// this class represents the large characters printed
	// on the start screen, and when a game is over
	public class Letter
	{
		ConsoleColor _color;

		string[] _values;

		string _id;


		public Letter(string id, ConsoleColor color, string[] values)
		{
			_color = color;
			_values = values;
			_id = id;
		}


		public string[] GetValues()
		{
			return _values;
		}


		public string Identification
		{
			get { return _id; }
		}


		public ConsoleColor Color
		{
			get
			{
				return _color;
			}
		}
	}
}
