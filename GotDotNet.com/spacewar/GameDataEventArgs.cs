using System;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for GameDataEventArgs.
	/// </summary>
	public class GameDataEventArgs: EventArgs
	{
		object gameData;

		public GameDataEventArgs(object gameData)
		{
			this.gameData = gameData;
		}

		public object GameData
		{
			get
			{
				return gameData;
			}
		}
	}
}
