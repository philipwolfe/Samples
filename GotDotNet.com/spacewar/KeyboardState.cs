using System;
using System.Collections;
using System.Windows.Forms;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for KeyboardState.
	/// </summary>
	/// 
	
	class KeyTrack
	{
		Keys keyCode;
		GameKeys bitValue;
		bool pressed;
		bool sticky;

		public KeyTrack(Keys keyCode, GameKeys bitValue, bool sticky)
		{
			this.keyCode = keyCode;
			this.bitValue = bitValue;
			this.sticky = sticky;
		}
		
		public GameKeys BitValue
		{
			get
			{
				return bitValue;
			}
		}

		public Keys KeyCode
		{
			get
			{
				return keyCode;
			}
		}

		public bool Pressed
		{
			get
			{
				return pressed;
			}
			set
			{
				if (pressed != value)
				{
					//Console.WriteLine("{0}: {1}", this.keyCode, value);
				}

					// if we're sticky, you have to clear it yourself...
				if (sticky && !value)
					return;

				pressed = value;
			}
		}

		public bool Sticky
		{
			get
			{
				return sticky;
			}
			set
			{
				sticky = value;
			}
		}
	}


	public class KeyboardState
	{
		ArrayList keys = new ArrayList();
		GameKeys currentState;

		public KeyboardState()
		{
		}

		public void Add(Keys key, GameKeys bitValue)
		{
			keys.Add(new KeyTrack(key, bitValue, false));
		}

		public void Add(Keys key, GameKeys bitValue, bool sticky)
		{
			keys.Add(new KeyTrack(key, bitValue, sticky));
		}

		KeyTrack GetKey(Keys key)
		{
			foreach (KeyTrack keyTrack in keys)
			{
				if (keyTrack.KeyCode == key)
					return keyTrack;
			}
			return null;
		}

		public void KeyDown(Keys key)
		{
			KeyTrack keyTrack = GetKey(key);
			if (keyTrack == null)
				return;

			keyTrack.Pressed = true;
			currentState |= keyTrack.BitValue;
		}

		public void KeyUp(Keys key)
		{
			KeyTrack keyTrack = GetKey(key);
			if (keyTrack == null)
				return;

			keyTrack.Pressed = false;
			if ((currentState & keyTrack.BitValue) != 0)
			{
				currentState ^= keyTrack.BitValue;
			}
		}

		public void Clear(GameKeys key)
		{
			if ((currentState & key) != 0)
			{
				currentState ^= key;
			}
		}

		public GameKeys CurrentState
		{
			get
			{
				return currentState;
			}
		}
	}
}
