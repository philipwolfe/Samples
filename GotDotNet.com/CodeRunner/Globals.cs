using System;
using System.Reflection;

namespace CodeRunner
{
	public class Constants
	{
		public static string APP_DIR = AppDomain.CurrentDomain.BaseDirectory;

		public const int TIMER_INTERVAL = 25;

		public const int TILE_WIDTH = 24;
		public const int TILE_HEIGHT = 24;
		public const int BOARD_WIDTH = 28;
		public const int BOARD_HEIGHT = 16;

		public const int GOLD_ANIMATION_ITERATION = 12;
		public const int GOLD_ANIMATION_SPEED = 4;
		
		public const int LEFT_OFFSET = 24;
		public const int TOP_OFFSET = 24;

		public const int HERO_XSPEED = 3;
		public const int HERO_YSPEED = 2;
		public const int HERO_FALLSPEED = 3;

		public const int MONK_SPEED = 2;

		public const int MONK_TRAPTIME = 50;
		public const int HOLE_LIFETIME = 330;
		public const int HOLE_ANIMATION_ITERATION = 6;

		public const int SLEEP_TIME = 0;

		public const int MONK_PICKUP_RATE = 3;
		public const int MONK_DROP_RATE = 25;
	};

	public struct Vector
	{
		public int XPos;
		public int YPos;
	};

	public class Utility
	{
		public static Vector TileToScreen(Vector tile)
		{
			tile.XPos = tile.XPos * Constants.TILE_WIDTH;
			tile.YPos = tile.YPos * Constants.TILE_HEIGHT;
			return tile;
		}

		public static Vector ScreenToTile(Vector pix)
		{
			pix.XPos = pix.XPos / Constants.TILE_WIDTH;
			pix.YPos = pix.YPos / Constants.TILE_HEIGHT;
			return pix;
		}

		public static Vector MakeVector(int x, int y)
		{
			Vector vecTemp;
			vecTemp.XPos = x;
			vecTemp.YPos = y;
			return vecTemp;
		}

		public static Vector TileToScreen(int xPos, int yPos)
		{
			Vector pos = new Vector();
			pos.XPos = xPos;
			pos.YPos = yPos;

			return TileToScreen(pos);
		}

		public static Vector OffsetVector(Vector pos, int xOffset, int yOffset)
		{	
			pos.XPos += xOffset;
			pos.YPos += yOffset;
			
			return pos;
		}
	}

	public enum Element
	{
		None = 0,
		Brick = 1,
		Ladder = 2,
		Rope = 3,
		Stone = 4,
		Trick = 5,
		Escape = 6
	};

	public enum UserAction
	{
		Stop = 0,
		Left = 1,
		Right = 2,
		Up = 3,
		Down = 4,
		DigLeft = 5,
		DigRight = 6,
		Fall = 7,
		Climb = 8
	};

	public enum GameState
	{
		Running = 0,
		Paused = 1,
		Won = 2,
		Lost = 3
	}
}
