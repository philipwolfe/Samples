using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace CodeRunner
{
	public class Game
	{
		public Game()
		{
			ClearAll();
		}
		
		public static void InitializeLevel(int nLevel)
		{
			Sound.PlayStart();

			m_nMonkTurn = 0;
			m_objLevel = new Level();
			m_objLevel.LoadLevel( nLevel );

			//m_objBrain = new StupidBrain();
			m_objBrain = new Brain();
			m_objBrain.InitializeNewLevel(m_objLevel);

			// position our hero
			m_objHero = new Hero();
			m_objHero.SetPosition(Utility.TileToScreen(m_objLevel.HeroPosition));

			// create the new monk objects
			m_aMonks = new ArrayList();
			for (int m=0; m<m_objLevel.MonkCount; m++)
			{
				Monk objMonk = new Monk();
				objMonk.SetPosition(Utility.TileToScreen(m_objLevel.MonkPosition(m)));
				m_aMonks.Add(objMonk);
			}

			// create the new gold objects
			m_aGold = new ArrayList();
			for (int n=0; n<m_objLevel.GoldCount; n++)
				m_aGold.Add(new Gold( m_objLevel.GoldPosition(n) ));

			// let the AI do some precalculation on the starting positions
			Game.Brain.OnHeroMoved();
			
			m_aHoles = new ArrayList();
		}

		public static void HandleKeypress(System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.NumPad4 || e.KeyCode==Keys.J || e.KeyCode==Keys.Left)
				m_nUserAction = UserAction.Left;
			else if (e.KeyCode==Keys.NumPad6 || e.KeyCode==Keys.L || e.KeyCode==Keys.Right)
				m_nUserAction = UserAction.Right;
			else if (e.KeyCode==Keys.Space)
				m_nUserAction = UserAction.Stop;
			else if (e.KeyCode==Keys.NumPad8 || e.KeyCode==Keys.I || e.KeyCode==Keys.Up)
				m_nUserAction = UserAction.Up;
			else if (e.KeyCode==Keys.Clear || e.KeyCode==Keys.NumPad2 || e.KeyCode==Keys.NumPad5 
					 || e.KeyCode==Keys.K || e.KeyCode==Keys.Down)
			{
				Vector hPos = Hero.Tile;
				if (Level.GetAt(hPos.XPos, hPos.YPos)==Element.Rope)
					m_nUserAction = UserAction.Fall;
				else
					m_nUserAction = UserAction.Down;
			}
			else if (e.KeyCode==Keys.Home || e.KeyCode==Keys.NumPad7 || e.KeyCode==Keys.U)
				m_nUserAction = UserAction.DigLeft;
			else if (e.KeyCode==Keys.PageUp || e.KeyCode==Keys.NumPad9 || e.KeyCode==Keys.O)
				m_nUserAction = UserAction.DigRight;
		}

		public static bool IterateFrame()
		{
			// new iteration, clear any invalidated rects
			// iterate the holes backwards so you can remove them
			for (int h=m_aHoles.Count-1; h>=0; h--)
			{
				Hole objHole = (Hole)m_aHoles[h];
				if (!objHole.Iterate())
				{
					Vector vecHole = objHole.Position;
					m_aHoles.RemoveAt(h);
				}
			}
			
			// move the hero
			int xOldPos = m_objHero.Tile.XPos;
			int yOldPos = m_objHero.Tile.YPos;
			m_objHero.Iterate();

			if (Game.GameState==GameState.Lost)
				return false;
			
			// if the hero changes position, allow the AI to do preparatory calculations before
			// moving the individual monks
			if (xOldPos!=m_objHero.Tile.XPos || yOldPos!=m_objHero.Tile.YPos)
				Game.Brain.OnHeroMoved();

			// iterate the monks at every other turn
			if (m_nMonkTurn==0)
			{
				for (int m=0; m<m_aMonks.Count; m++)
				{
					Monk objMonk = (Monk)m_aMonks[m];
					objMonk.Iterate();
				}
			}
			m_nMonkTurn++;
			if (m_nMonkTurn==Constants.MONK_SPEED) m_nMonkTurn = 0;

			// check the level winning condition
			if (Game.Gold.Count==0 && Hero.Position.YPos==0)
			{
				Game.GameState = GameState.Won;
				return false;
			}

			// check the losing condition
			Vector vecHero = Utility.ScreenToTile(Hero.Position);
			for (int m=0; m<m_aMonks.Count; m++)
			{
				Monk objMonk = (Monk)m_aMonks[m];
				Vector vecMonk = Utility.ScreenToTile(objMonk.Position);
				if (vecMonk.XPos==vecHero.XPos && vecMonk.YPos==vecHero.YPos)
				{
					Game.GameState = GameState.Lost;
					return false;
				}
			}


			return true;
		}

		public static int FindGoldAt(Vector pos)
		{
			for (int n=0; n<m_aGold.Count; n++)
			{
				Gold objGold = (Gold)m_aGold[n];
				if (objGold.Position.XPos == pos.XPos &&
					objGold.Position.YPos == pos.YPos)
					return n;
			}

			return -1;
		}

		public static void RemoveGold(int nGoldID)
		{
			m_aGold.RemoveAt(nGoldID);

			CheckGoldCount();
		}

		public static void AddGold(Vector vecTile)
		{
			Gold objGold = new Gold(vecTile);
			m_aGold.Add(objGold);
		}

		private static void CheckGoldCount()
		{
			if (m_aGold.Count==0)
			{
				// see if any of the monks are carrying
				for (int n=0; n<m_aMonks.Count; n++)
				{
					Monk objMonk = (Monk)m_aMonks[n];
					if (objMonk.IsCarrying)
						return;
				}

				// no more gold. 
				Sound.PlayEscape();

				// convert all escape hatches to ladders
				for (int x=0; x<Constants.BOARD_WIDTH; x++)
				{
					for (int y=0; y<Constants.BOARD_HEIGHT; y++)
					{
						if (m_objLevel.GetAt(x,y)==Element.Escape)
							m_objLevel.SetAt(x,y,Element.Ladder);
					}
				}
			}
		}

		public static int FindHoleAt(Vector pos)
		{
			for (int h=0; h<m_aHoles.Count; h++)
			{
				Hole objHole = (Hole)m_aHoles[h];
				if (objHole.Position.XPos == pos.XPos &&
					objHole.Position.YPos == pos.YPos)
					return h;
			}

			return -1;
		}

		public static int FindCompleteHoleAt(Vector pos)
		{
			int nHole = FindHoleAt(pos);
			if (nHole!=-1)
			{
				Hole objHole = (Hole)m_aHoles[nHole];
				if (!objHole.FallThrough)
					return -1;
			}

			return nHole;
		}

		public static int FindMonkAt(Vector pos)
		{
			for (int m=0; m<m_aMonks.Count; m++)
			{
				Monk objMonk = (Monk)m_aMonks[m];
				Vector abs = objMonk.AbsoluteTile;

				if (abs.XPos == pos.XPos &&	abs.YPos == pos.YPos)
					return m;
			}

			return -1;
		}

		public static GameState GameState { get { return m_nGameState; } set { m_nGameState = value; } }

//		public static bool FullRefresh { get { return m_bFullRefresh; } }
		public static Hero Hero { get { return m_objHero; } }
		public static Level Level { get { return m_objLevel; } }
		public static Brain Brain { get { return m_objBrain; } }
			
		public static ArrayList Monks { get { return m_aMonks; } }
		public static ArrayList Gold { get { return m_aGold; } }
		public static ArrayList Holes { get { return m_aHoles; } }

		public static UserAction UserAction { get { return m_nUserAction; } set { m_nUserAction = value; } }

		public static void ClearAll()
		{
			m_nMonkTurn = 0;
			m_nUserAction = UserAction.Stop;
			m_nGameState = GameState.Paused;
					
			m_objLevel = null;
			m_objHero = null;
			m_aMonks = null;
			m_aGold = null;
			m_aHoles = null;
		}
			
		// action
		private static int m_nMonkTurn;
		private static UserAction m_nUserAction;
		private static GameState m_nGameState;

		// level
		private static Brain m_objBrain;
		private static Level m_objLevel;
		private static Hero m_objHero;

		// lists
		private static ArrayList m_aMonks;
		private static ArrayList m_aHoles;
		private static ArrayList m_aGold;
	}
}
