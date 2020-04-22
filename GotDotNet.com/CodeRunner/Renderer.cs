//#define STARS

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace CodeRunner
{
	/// <summary>
	/// Summary description for Renderer.
	/// </summary>
	public class Renderer
	{
		private static Random m_Rand = new System.Random(1);

		public Renderer(Form mainWindow)
		{
			m_mainWindow = mainWindow;

			// load the tiles
			Graphics g = Graphics.FromHwnd(m_mainWindow.Handle);
			m_bmpMonkTile = LoadBitmap(Constants.APP_DIR + @"Resources\Monks.bmp", g);
			m_bmpHeroTile = LoadBitmap(Constants.APP_DIR + @"Resources\Hero.bmp", g);
			m_bmpShadowTile = LoadBitmap(Constants.APP_DIR + @"Resources\Shadow.bmp", g);
			m_bmpGameTile = LoadBitmap(Constants.APP_DIR + @"Resources\Tiles.bmp", g);
			m_bmpGoldTile = LoadBitmap(Constants.APP_DIR + @"Resources\StarGold.bmp", g);

			// load the game background
			m_bmpBackground = CreateBackground( m_mainWindow );
		}

		public void Initialize()
		{
			m_mainWindow.Invalidate();
		}

		private Bitmap LoadBitmap(string strFilename, Graphics g)
		{
			Bitmap bmpTile = new Bitmap(strFilename);
			bmpTile.MakeTransparent(System.Drawing.Color.Black);
			
			Bitmap bmpTrans = new Bitmap(bmpTile.Width, bmpTile.Height, g);
			Graphics gTrans = System.Drawing.Graphics.FromImage( bmpTrans );
			gTrans.DrawImage(bmpTile, 0, 0, bmpTile.Width, bmpTile.Height);
			
			return bmpTrans;
		}

		public void Paint(System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			DrawBackground(g);
			
			DrawDropShadows(g);
			DrawGold(g, true);
			DrawMonks(g, true);
			DrawHero(g, true);

			DrawGameBoard(g, false);
			DrawGold(g, false);
			DrawMonks(g, false);
			DrawHero(g, false);

			DrawBorders(g);
		}

		public void DrawBorders(Graphics g)
		{
			// draw border
			DrawBitmapTile(g, m_bmpGameTile, 1, 7, Utility.TileToScreen(0,0));
			DrawBitmapTile(g, m_bmpGameTile, 7, 7, Utility.TileToScreen(0,Constants.BOARD_HEIGHT+1));
			for (int x=0; x<Constants.BOARD_WIDTH; x++)
			{
				DrawBitmapTile(g, m_bmpGameTile, 2, 7, Utility.TileToScreen(x+1,0));
				DrawBitmapTile(g, m_bmpGameTile, 8, 7, Utility.TileToScreen(x+1,Constants.BOARD_HEIGHT+1));
			}
			DrawBitmapTile(g, m_bmpGameTile, 3, 7, Utility.TileToScreen(Constants.BOARD_WIDTH+1,0));
			DrawBitmapTile(g, m_bmpGameTile, 9, 7, Utility.TileToScreen(Constants.BOARD_WIDTH+1, Constants.BOARD_HEIGHT+1));
		
			for (int y=0; y<Constants.BOARD_HEIGHT; y++)
			{
				DrawBitmapTile(g, m_bmpGameTile, 4, 7, Utility.TileToScreen(0, y+1));
				DrawBitmapTile(g, m_bmpGameTile, 6, 7, Utility.TileToScreen(Constants.BOARD_WIDTH+1, y+1));
			}

		}

		public void DrawDropShadows(Graphics g)
		{
			DrawGameBoard(g, true);
		}

		private Bitmap CreateBackground(Form mainWindow)
		{
			Bitmap bmpBackground = new Bitmap((Constants.TILE_WIDTH * (Constants.BOARD_WIDTH+2)), 
				(Constants.TILE_HEIGHT * (Constants.BOARD_HEIGHT+2)), System.Drawing.Graphics.FromHwnd(mainWindow.Handle));
			Graphics g = System.Drawing.Graphics.FromImage( bmpBackground );

			Bitmap bmpFromFile = new Bitmap(Constants.APP_DIR + @"Resources\Background.bmp");
			g.DrawImage(bmpFromFile, Constants.TILE_WIDTH, Constants.TILE_HEIGHT, (Constants.TILE_WIDTH * Constants.BOARD_WIDTH),
						(Constants.TILE_HEIGHT * Constants.BOARD_HEIGHT));

			return bmpBackground;
		}

		private void DrawBackground(Graphics g)
		{
			g.DrawImage(m_bmpBackground, 0, 0, m_bmpBackground.Width, m_bmpBackground.Height);
		}

		private void DrawGameBoard(Graphics g, bool bShadow)
		{
			// loop through the game elements
			Level objLevel = Game.Level;
			for (int y=0; y<Constants.BOARD_HEIGHT; y++)
			{
				for (int x=0; x<Constants.BOARD_WIDTH; x++)
				{
					int xTile = 0;
					int yTile = 1;
					Vector pos = Utility.TileToScreen(x+1, y+1);
					if (bShadow)
					{
						yTile = 2;
						pos = Utility.OffsetVector(pos, 4, 3);
					}

					switch (objLevel.GetAt(x,y))
					{
						case Element.Brick:
						{
							int nHole = Game.FindHoleAt(Utility.MakeVector(x,y));
							if (nHole==-1)
								xTile = 2; 
							else
							{
								if (!bShadow)
								{
									Hole objHole = (Hole)Game.Holes[nHole];
									if (objHole.Depth<Constants.HOLE_ANIMATION_ITERATION)
									{
										int ySize = objHole.Depth * (Constants.TILE_HEIGHT/Constants.HOLE_ANIMATION_ITERATION);

										Rectangle rcFrame = new Rectangle((2-1)*Constants.TILE_WIDTH, (1-1)*Constants.TILE_HEIGHT, Constants.TILE_WIDTH, Constants.TILE_HEIGHT - ySize);
										g.DrawImage(m_bmpGameTile, pos.XPos, pos.YPos + ySize, rcFrame, GraphicsUnit.Pixel);
									}
								}
							}

							break;
						}

						case Element.Ladder: xTile = 4; break;
						case Element.Rope:	 xTile = 5; break;
						case Element.Stone:  xTile = 3; break;
						case Element.Trick:  xTile = 2; break;
					}

					if (xTile>0)
						DrawBitmapTile(g, m_bmpGameTile, xTile, yTile, pos);
				}
			}
		}

		// draw my hero
		private void DrawHero(System.Drawing.Graphics g, bool bShadow)
		{
			DrawRunner(g, Game.Hero, m_bmpHeroTile, bShadow);
		}

		// draw all the bad guys
		private void DrawMonks(System.Drawing.Graphics g, bool bShadow)
		{
			for (int m=0; m<Game.Monks.Count; m++)
			{
				Monk objMonk = (Monk)Game.Monks[m];
				DrawRunner(g, objMonk, m_bmpMonkTile, bShadow);
			}
		}

		// generic draw runner
		private void DrawRunner(System.Drawing.Graphics g, Runner objRunner, System.Drawing.Bitmap bmpTile, bool bShadow)
		{
			Vector pos = Utility.OffsetVector(objRunner.Position, Constants.LEFT_OFFSET, Constants.TOP_OFFSET);
			
			Vector vecTile = objRunner.Tile;
			Element objElem = Game.Level.GetAt(vecTile.XPos, vecTile.YPos);
            
			int nRow = 0; int nColOffset = 0;

			if (objRunner.CurrentAction==UserAction.Fall)
			{
				if (objElem==Element.Ladder)
					nRow = 7;
				else
					nRow = 6;
			}
			else if (objRunner.CurrentAction==UserAction.Stop)
			{
				if (objElem==Element.Rope)
					nRow = 4;
				else if (objElem==Element.Ladder)
					nRow = 7;
				else
					nRow = 1;
			}
			else if (objRunner.CurrentAction==UserAction.Right)
			{
				if (objElem==Element.Rope)
					nRow = 5;
				else
					nRow = 3;
			}
			else if (objRunner.CurrentAction==UserAction.Left)
			{
				if (objElem==Element.Rope)
					nRow = 4;
				else
					nRow = 2;
			}
			else if (objRunner.CurrentAction==UserAction.Up || objRunner.CurrentAction==UserAction.Down ||
				objRunner.CurrentAction==UserAction.Climb)
			{
				nRow = 7;
			}
			else if (objRunner.CurrentAction==UserAction.DigLeft)
				nRow = 8;
			else if (objRunner.CurrentAction==UserAction.DigRight)
			{
				nRow = 8;
				nColOffset = 6;
			}

			if (bShadow)
			{
				bmpTile = m_bmpShadowTile;
				pos = Utility.OffsetVector(pos, 4, 3);
			}
	
			DrawBitmapTile(g, bmpTile, objRunner.AnimCell + nColOffset, nRow, pos);
		}

		// draw the gold
		private void DrawGold(System.Drawing.Graphics g, bool bDropShadow)
		{
			if (Game.Gold.Count==0)
				return;

			for (int n=0; n<Game.Gold.Count; n++)
			{
				int nIndex = ((m_lGoldIteration + n) % Constants.GOLD_ANIMATION_ITERATION) + 1;

				Gold objGold = (Gold)Game.Gold[n];
				Vector posGold = Utility.OffsetVector( Utility.TileToScreen(objGold.Position), Constants.LEFT_OFFSET, Constants.TOP_OFFSET);

				if (bDropShadow)
				{
					posGold = Utility.OffsetVector(posGold, 4, 3);
					DrawBitmapTile(g, m_bmpGameTile, 8, 2, posGold);	
				}
				else
					DrawBitmapTile(g, m_bmpGameTile, 8, 1, posGold);	
			}

			if (m_nGoldToAnimate==-1 || (m_nGoldToAnimate>=Game.Gold.Count))
			{
				m_nGoldToAnimate=-1;

				int nRand = m_Rand.Next(1,20);
				if (nRand==10)
				{
					m_nGoldToAnimate = m_Rand.Next(0, Game.Gold.Count);
					m_nGoldAnimDir = 1;
				}
			}

			if (m_nGoldToAnimate>-1)
			{
				m_nGoldAnimCell += m_nGoldAnimDir;
		
				Gold objGold = (Gold)Game.Gold[m_nGoldToAnimate];
				Vector posGold = Utility.OffsetVector( Utility.TileToScreen(objGold.Position), Constants.LEFT_OFFSET, Constants.TOP_OFFSET);
				DrawBitmapTile(g, m_bmpGameTile, 8+m_nGoldAnimCell, 5, posGold);

				if (m_nGoldAnimCell==0)
					m_nGoldToAnimate = -1;
				else if (m_nGoldAnimCell>4)
					m_nGoldAnimDir = -1;
			}
		}

		private void DrawBitmapTile(System.Drawing.Graphics g, Bitmap bmpTile, int xSquare, int ySquare, Vector pos)
		{
			Rectangle rcFrame = new Rectangle((xSquare-1)*Constants.TILE_WIDTH, (ySquare-1)*Constants.TILE_HEIGHT, Constants.TILE_WIDTH, Constants.TILE_HEIGHT);
			g.DrawImage(bmpTile, pos.XPos, pos.YPos, rcFrame, GraphicsUnit.Pixel);
		}

		private int m_nGoldToAnimate = -1;
		private int m_nGoldAnimCell = 0;
		private int m_nGoldAnimDir = 0;
		
		private int m_lGoldIteration = 0;
		private Form m_mainWindow;
		
		private Bitmap m_bmpHeroTile;
		private Bitmap m_bmpMonkTile;
		private Bitmap m_bmpGameTile;
		private Bitmap m_bmpGoldTile;
		private Bitmap m_bmpShadowTile;
		
		private Bitmap m_bmpBackground;
	}
}
