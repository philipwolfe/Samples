using System;
using System.Collections;
using System.Drawing;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for Word.
	/// </summary>
	public class Word
	{
		string word;
		ArrayList letters = new ArrayList();

		public Word(string word, float scale)
		{
			this.word = word;

			foreach (char c in word)
			{
				Letter letter = new Letter(c);
				letter.SetLetter(scale);
				letters.Add(letter);
			}
		}

		public void Draw(DirectDrawSurface7 surface, int color, int step, Point location)
		{
			foreach (Letter letter in letters)
			{
				letter.Draw(surface, color, location);
				location.X += step;
			}
		}
	}
}
