using System;

namespace CodeRunner
{
	public abstract class Brain
	{
		public Brain()
		{
		}

		public abstract void InitializeNewLevel(Level objLevel);

		public abstract void OnHeroMoved();

		public abstract UserAction GetNextMove(Monk objMonk, Hero objHero);
	}
}
