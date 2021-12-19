///////////////////////////////////////////////////////////////////////////////
//
//  Asteroids.cs
//
//  Usage:
//
//  Keyboard Controls:
//
//  S            - Start Game    P           - Pause Game
//  Cursor Left  - Rotate Left   Cursor Up   - Fire Thrusters
//  Cursor Right - Rotate Right  Cursor Down - Fire Retro Thrusters
//  Spacebar     - Fire Cannon   H           - Hyperspace
//  M            - Toggle Sound  D           - Toggle Graphics Detail
//
///////////////////////////////////////////////////////////////////////////////
//
//  The Sprite class defines a game object, including it's 
//  shape, position, movement and rotation. It also can detemine if 
//  two objects collide.
//
///////////////////////////////////////////////////////////////////////////////

namespace Asteroids
{
	using System;
	using System.Diagnostics;
    using System.Drawing;
	using System.Drawing.Drawing2D;
	using System.Threading;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
	using System.Resources;
	/// <summary>
	/// 
	/// </summary>
	public class Sprite 
	{
		private static bool JVM_SUX = true;
		
		/// <summary>Dimensions of the graphics area.</summary>
		public static Size Screen;

		/// <summary>Initial sprite shape, centered at the origin (0,0).</summary>
		public GraphicsPath shape;                 

		/// <summary>Active flag.</summary>
		public bool active;

		/// <summary>Current angle of rotation.</summary>
		public double  angle;

		/// <summary>Amount to change the rotation angle.</summary>
		public double  deltaAngle;

		/// <summary>Current position on screen.</summary>
		public double  currentX, currentY;

		/// <summary>Amount to change the screen position.</summary>
		public double  deltaX, deltaY;

		private Matrix location = new Matrix();
		private Region space = new Region();

		/// <summary>
		/// Location of the sprite.
		/// </summary>
		/// <remarks>
		/// Final location and shape of sprite after applying rotation and
		/// moving to screen position. Used for drawing on the screen and
		/// in detecting collisions.
		/// </remarks>
		public GraphicsPath sprite;                

		// Constructors:

		public Sprite() 
		{
			this.shape = new GraphicsPath();
			this.active = false;
			this.angle = 0.0;
			this.deltaAngle = 0.0;
			this.currentX = 0.0;
			this.currentY = 0.0;
			this.deltaX = 0.0;
			this.deltaY = 0.0;
			this.sprite = new GraphicsPath();
		}

		// Methods:

		/// <summary>
		/// Update the rotation and position.
		/// </summary>
		/// <remarks>
		/// Update the rotation and position of the sprite based 
		/// on the delta values. If the sprite moves off the edge 
		/// of the screen, it is wrapped around to the other side.
		/// </remarks>
		public void advance() 
		{
			this.angle += this.deltaAngle;
			if (this.angle < 0)
				this.angle += 2 * Math.PI;
			if (this.angle > 2 * Math.PI)
				this.angle -= 2 * Math.PI;
			this.currentX += this.deltaX;
			if (this.currentX < -Screen.Width / 2)
				this.currentX += Screen.Width;
			if (this.currentX > Screen.Width / 2)
				this.currentX -= Screen.Width;
			this.currentY -= this.deltaY;
			if (this.currentY < -Screen.Height / 2)
				this.currentY += Screen.Height;
			if (this.currentY > Screen.Height / 2)
				this.currentY -= Screen.Height;
		}

		/// <summary>
		/// Render the sprite.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Render the sprite's shape and location by
		/// rotating and translating its render matrix.
		/// </para>
		/// </remarks>
		public void render() 
		{
			try
			{
				if( JVM_SUX )
				{
					location.Reset();
					float x = (float) Math.Round(this.currentX) + Screen.Width / 2;
					float y = (float) Math.Round(this.currentY) + Screen.Height / 2;
					double theta = this.angle * ( 180 / Math.PI ); //* (float)(2 * Math.PI)
					
					location.Rotate((float)theta, MatrixOrder.Append );				
					location.Translate( x, y, MatrixOrder.Append );

					this.sprite.Reset();
					this.sprite.AddPath( this.shape, true);
					this.sprite.CloseFigure();
 					this.sprite.Transform( location );
				}
				else
				{
					Point[] points = new Point[ this.shape.PathPoints.Length ]; 
					for (int i = 0; i < this.shape.PathPoints.Length; i++)
					{
						float x_pt = this.shape.PathPoints[i].X;
						float y_pt = this.shape.PathPoints[i].Y;
						double cos = Math.Cos(this.angle);
						double sin = -Math.Sin(this.angle);
						points[i].X = (int)( Math.Round( x_pt * cos + y_pt * sin ) + Math.Round(this.currentX) + Screen.Width / 2 );
						points[i].Y = (int)( Math.Round( y_pt * cos - x_pt * sin ) + Math.Round(this.currentY) + Screen.Height / 2 );
					}
					this.sprite.Reset();
					this.sprite.AddPolygon( points );
				}
			}
			catch (Exception e) 
			{
				Debug.Write(e.ToString());
			}
		}

		/// <summary>
		/// Determine if one sprite overlaps with another, i.e., 
		/// if any vertice of one sprite lands inside the other.
		/// </summary>
		/// <param name="s"> </param>
		public bool isColliding(Sprite s) 
		{
			try
			{
				if(JVM_SUX)
				{
					lock(Asteroids.offGraphics)
					{
						space.MakeInfinite();
						space.Intersect( sprite );
						space.Intersect( s.sprite );
							if( !space.IsEmpty(Asteroids.offGraphics ) )
								return true;
					}	
				}
				else
				{
					GraphicsPath path1 = s.sprite;
					GraphicsPath path2 = this.sprite;
					PointF[] polygon1 = s.sprite.PathPoints;
					PointF[] polygon2 = this.sprite.PathPoints;

					for (int i = 0; i < polygon1.Length; i++)
						if (path2.IsVisible(polygon1[i].X, polygon1[i].Y))
							return true;
					for (int i = 0; i < polygon2.Length; i++)
						if (path1.IsVisible(polygon2[i].X, polygon2[i].Y))
							return true;
				}
			}
			catch (Exception e) 
			{
				Debug.Write(e.ToString());
			}

			return false;
		}
	}


    public class Asteroids: System.Windows.Forms.Form
    {
		public static Random random = new Random();

		//
		// Thread control variables.
		//
		private static bool CREATE_THREAD = false;
		Thread loopThread;
		bool gameLoop = !CREATE_THREAD;
		float T0 = 0; 
		float T = 0;

		//
		// Constants
		//

		/// <summary>Milliseconds between screen updates.</summary>
		public const int DELAY = 10;

		/// <summary>Starting number of ships per game.</summary>
		public const int MAX_SHIPS = 3;

		/// <summary>Maximum number of sprites for photons, asteroids, and explosions.</summary>
		public const int MAX_SHOTS =  6;
		public const int MAX_ROCKS =  8;
		public const int MAX_SCRAP = 20;

		/// <summary>Counter starting values.</summary>
		public const int SCRAP_COUNT = 30;
		public const int HYPER_COUNT = 60;
		public const int STORM_PAUSE = 30;
		public const int UFO_PASSES  =  3;

		/// <summary>Asteroid shape and size ranges.</summary>
		public const int MIN_ROCK_SIDES =  8;
		public const int MAX_ROCK_SIDES = 12;
		public const int MIN_ROCK_SIZE  = 20;
		public const int MAX_ROCK_SIZE  = 40;
		public const int MIN_ROCK_SPEED =  2;
		public const int MAX_ROCK_SPEED = 12;

		/// <summary>Points for shooting different objects.</summary>
		public const int BIG_POINTS    =  25;
		public const int SMALL_POINTS  =  50;
		public const int UFO_POINTS    = 250;
		public const int MISSLE_POINTS = 500;

		/// <summary>Number of points needed to earn a new ship.</summary>
		public const int NEW_SHIP_POINTS = 5000;

		/// <summary>Number of points between flying saucers.</summary>
		public const int NEW_UFO_POINTS  = 2750;

		/// <summary>Background stars.</summary>
		Point[] stars;
		int     numStars;

		//
		// Game data.
		//

		int score;
		int highScore;
		int newShipScore;
		int newUfoScore;

		bool loaded = false;
		bool paused = false;
		bool playing = false;
		bool sound = false;
		bool detail = false;

		//
		// Key flags.
		//

		bool left  = false;
		bool right = false;
		bool up    = false;
		bool down  = false;

		//
		// Sprite objects.
		//

		Sprite   ship;
		Sprite   ufo;
		Sprite   missle;
		Sprite[] photons    = new Sprite[MAX_SHOTS];
		Sprite[] asteroids  = new Sprite[MAX_ROCKS];
		Sprite[] explosions = new Sprite[MAX_SCRAP];

		//
		// Ship data.
		//

		/// <summary>Number of ships left to play, including current one.</summary>
		int shipsLeft;

		/// <summary>Time counter for ship explosion.</summary>
		int shipCounter;

		/// <summary>Time counter for hyperspace.</summary>
		int hyperCounter;

		//
		// Photon data.
		//

		/// <summary>Time counter for life of a photon.</summary>
		int[] photonCounter = new int[MAX_SHOTS];

		/// <summary>Next available photon sprite.</summary>
		int   photonIndex;

		//
		// Flying saucer data.
		//

		/// <summary>Number of flying saucer passes.</summary>
		int ufoPassesLeft;

		/// <summary>Time counter for each pass.</summary>
		int ufoCounter;

		//
		// Missle data.
		//

		/// <summary>Counter for life of missle.</summary>
		int missleCounter;

		//
		// Asteroid data.
		//

		/// <summary>Asteroid size flag.</summary>
		bool[]	asteroidIsSmall = new bool[MAX_ROCKS];

		/// <summary>Break-time counter.</summary>
		int     asteroidsCounter;

		/// <summary>Asteroid speed.</summary>
		int     asteroidsSpeed;

		/// <summary>Number of active asteroids.</summary>
		int     asteroidsLeft;

		//
		// Explosion data.
		//

		/// <summary>Time counters for explosions.</summary>
		int[] explosionCounter = new int[MAX_SCRAP];

		/// <summary>Next available explosion sprite.</summary>
		int   explosionIndex;

		//
		// Sound clips.
		//
		/*
		AudioClip crashSound;
		AudioClip explosionSound;
		AudioClip fireSound;
		AudioClip missleSound;
		AudioClip saucerSound;
		AudioClip thrustersSound;
		AudioClip warpSound;
		*/

		//
		// Flags for looping sound clips.
		//

		private bool thrustersPlaying = false;
		//private bool saucerPlaying = false;
		//private bool misslePlaying = false;

		//
		// Values for the offscreen image.
		//

		Size offDimension;
		Image offImage;
		public static Graphics offGraphics;

		// Font data.

		Font font = new Font("Helvetica", 12);

		// Applet information.
		public static string[] Info = new string[]
		{
            "C# Asteroids, Copyright 2000 by Michael Lambert.",
			"Based on Asteroids, Copyright 1998 by Mike Hall.",
			"All Rights Reserved."
		};

		// Applet information.
		public static string[] Help = new string[]
		{
			"S\t\t- Start Game\n",
			"P\t\t- Pause Game\n",
			"Cursor Up\t- Fire Thrusters\n",
			"Cursor Down\t- Fire Retro Thrusters\n",
			"Cursor Left\t- Rotate Left\n",
			"Cursor Right\t- Rotate Right\n",
			"Spacebar\t- Fire Cannon\n",
			"H\t\t- Hyperspace\n",
			"M\t\t- Toggle Sound\n",
			"D\t\t- Toggle Graphics Detail\n"
		};


        public Asteroids()
        {
			init();

			Start();
        }

		protected override void OnClosing(CancelEventArgs e)
		{
			Stop();
		}


		public void init() 
		{
			int i;
			
				// Take credit.
				foreach(string s in Info)
					System.Console.WriteLine(s);
			
				// Find the size of the screen and set the values for sprites.
				 
				Graphics g = this.CreateGraphics();
				Size d = this.Size;
				Sprite.Screen.Width = this.ClientRectangle.Width;
				Sprite.Screen.Height = this.ClientRectangle.Width;

				// Generate starry background.
				GenerateStarfield();

				// Create shape for the ship sprite.

				ship = new Sprite();
				PointF[] ship_pts = 
				{
					new PointF(0, -10),
					new PointF(7, 10),
					new PointF(-7, 10)
				};
				ship.shape.AddPolygon( ship_pts	);
				ship.shape.CloseFigure();

				// Create shape for the photon sprites.

				for (i = 0; i < MAX_SHOTS; i++) 
				{
					photons[i] = new Sprite();
					PointF[] photon_pts = 
					{
						new PointF(1, 1),
						new PointF(1, -1),
						new PointF(-1, 1),
						new PointF(-1, -1)
						
					};
					photons[i].shape.AddPolygon(photon_pts);
					photons[i].shape.CloseFigure();
				}

				// Create shape for the flying saucer.

				ufo = new Sprite();
				PointF[] ufo_pts = 
				{
					new PointF(-15, 0),
					new PointF(-10, -5),
					new PointF(-5, -5),
					new PointF(-5, -9),
					new PointF(5, -9),
					new PointF(5, -5),
					new PointF(10, -5),
					new PointF(15, 0),
					new PointF(10, 5),
					new PointF(-10, 5)
				};
				ufo.shape.AddPolygon( ufo_pts );
				ufo.shape.CloseFigure();

				// Create shape for the guided missle.

				missle = new Sprite();
				PointF[] missle_pts = 
				{
					new PointF(0, -4),
					new PointF(1, -3),
					new PointF(1, 3),
					new PointF(2, 4),
					new PointF(-2, 4),
					new PointF(-1, 3),
					new PointF(-1, -3)
				};
				missle.shape.AddPolygon( missle_pts );
				missle.shape.CloseFigure();
			
				// Create asteroid sprites.

				for (i = 0; i < MAX_ROCKS; i++)
				  asteroids[i] = new Sprite();

				// Create explosion sprites.

				for (i = 0; i < MAX_SCRAP; i++)
				  explosions[i] = new Sprite();

				// Initialize game data and put us in 'game over' mode.

				highScore = 0;
				sound = true;
				
				detail = true;

				initGame();

				endGame();

				g.Dispose();
		}

		private void GenerateStarfield() 
		{
			numStars = Sprite.Screen.Width * Sprite.Screen.Height / 5000;
			stars = new Point[numStars];
			for(int i = 0; i < numStars; i++)
			  stars[i] = new Point((int) (random.NextDouble() * Sprite.Screen.Width), (int) (random.NextDouble() * Sprite.Screen.Height));
		}

		protected override void OnPaintBackground( PaintEventArgs pevent ) 
		{
			// Eliminating Flicker
		}
		protected override void OnPaint( PaintEventArgs e ) 
		{
			Size d = this.Size;
			int i;
			int c;
			String s;
			SizeF stringSize;
			Pen penRGB = new Pen( Color.White, 1);

			// Create the offscreen graphics context, if no good one exists.
			if (offGraphics == null || d.Width != offDimension.Width || d.Height != offDimension.Height) 
			{
				offDimension = d;
				offImage = new Bitmap(offDimension.Width, offDimension.Height, e.Graphics);
				offGraphics = Graphics.FromImage(offImage);
			}

			lock(offGraphics)
			{
				// Fill in background and stars.
				offGraphics.FillRectangle( Brushes.Black, offGraphics.ClipBounds);
				if (detail) 
				{
					lock(stars)
					{
						foreach(Point pt in stars)
							offGraphics.DrawEllipse(Pens.White, pt.X, pt.Y, 1, 1);
					}
				}

				// Draw photon bullets.
				lock(photons)
				{
					for (i = 0; i < MAX_SHOTS; i++)
						if (photons[i].active)
							offGraphics.DrawPath(Pens.White, photons[i].sprite );
				}

				// Draw the guided missle, counter is used to quickly fade color to black when near expiration.
				c = Math.Min(missleCounter * 24, 255);
				penRGB.Color = Color.FromArgb(c,c,c);
				lock(missle)
				{
					if (missle.active) 
						offGraphics.DrawPath( penRGB, missle.sprite );
				}

				// Draw the asteroids.
				lock( asteroids )
				{
					foreach( Sprite asteroid in asteroids )
					{
						if (asteroid.active) 
						{
							if (detail) 
								offGraphics.FillPath( Brushes.Black, asteroid.sprite ); 

							offGraphics.DrawPath(Pens.White, asteroid.sprite );
						}
					}
				}

				// Draw the flying saucer.
				if (ufo.active) 
				{
					if (detail) 
						offGraphics.DrawPath(Pens.Black, ufo.sprite );

					offGraphics.DrawPath(Pens.White, ufo.sprite);
				}

				// Draw the ship, counter is used to fade color to white on hyperspace.
				c = 255 - (255 / HYPER_COUNT) * hyperCounter;
				lock(ship)
				{
					if (ship.active) 
					{
						if (detail && hyperCounter == 0) 
							offGraphics.DrawPath(Pens.Black, ship.sprite );

						penRGB.Color = Color.FromArgb(c, c, c);
						offGraphics.DrawPath(penRGB, ship.sprite);
					}
				}

				// Draw any explosion debris, counters are used to fade color to black.
				lock(explosions)
				{
					for (i = 0; i < MAX_SCRAP; i++)
					{
						if (explosions[i].active) 
						{
							c = (255 / SCRAP_COUNT) * explosionCounter [i];
							
							penRGB.Color = Color.FromArgb(c, c, c);
							offGraphics.DrawPath( penRGB, explosions[i].sprite );
						}
					}
				}

				// Display status and messages.
				SizeF fontSize = offGraphics.MeasureString("W", font, offDimension.Width );
				offGraphics.DrawString("Score: " + score, font, Brushes.White, fontSize.Width, font.Height);
				offGraphics.DrawString("Ships: " + shipsLeft, font, Brushes.White, fontSize.Width, offDimension.Height - font.Height*3);

				s = "High: " + highScore;
				stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
				offGraphics.DrawString(s, font, Brushes.White, offDimension.Width - (fontSize.Width + stringSize.Width), font.Height);

#if DEBUG
				s = "Time: " + T.ToString();
				stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
				offGraphics.DrawString(s, font, Brushes.White, offDimension.Width - (fontSize.Width + stringSize.Width), offDimension.Height - font.Height*3);
#endif // DEBUG

				if (!sound) 
				{
					s = "Mute";
					stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
					offGraphics.DrawString(s, font, Brushes.White, 
						offDimension.Width - (fontSize.Width + stringSize.Width), 
						offDimension.Height - font.Height);
				}
				if (!playing) 
				{
					s = "C #  A S T E R O I D S";
					stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
					offGraphics.DrawString(s, font, Brushes.White, (offDimension.Width - stringSize.Width) / 2, offDimension.Height / 2);

					for(int info = 0; info < Info.Length; info++)
					{
						stringSize = offGraphics.MeasureString(Info[info], font, offDimension.Width);
						offGraphics.DrawString(Info[info], font, Brushes.White, (offDimension.Width - stringSize.Width) / 2, offDimension.Height / 2 + font.Height * (info+1));
					}

					if (!loaded) 
					{
						s = "Loading sounds...";
						stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
						offGraphics.DrawString(s, font, Brushes.White, (offDimension.Width - stringSize.Width) / 2, offDimension.Height / 4);
					}
					else 
					{
						s = "Game Over";
						stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
						offGraphics.DrawString(s, font, Brushes.White, (offDimension.Width - stringSize.Width) / 2, offDimension.Height / 4);
						s = "'S' to Start\n'P' to Pause";
						stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
						offGraphics.DrawString(s, font, Brushes.White, (offDimension.Width - stringSize.Width) / 2, offDimension.Height / 4 + font.Height);
					}
				}
				else if (paused) 
				{
					s = "Game Paused";
					stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
					offGraphics.DrawString(s, font, Brushes.White, (offDimension.Width - stringSize.Width) / 2, offDimension.Height / 4);
					s = "Keyboard Controls";
					stringSize = offGraphics.MeasureString(s, font, offDimension.Width);
					offGraphics.DrawString(s, font, Brushes.White, (offDimension.Width - stringSize.Width) / 2, offDimension.Height / 3);

					for(int info = 0; info < Help.Length; info++)
					{
						stringSize = offGraphics.MeasureString(Help[info], font, offDimension.Width);
						offGraphics.DrawString(Help[info], font, Brushes.White, offDimension.Width / 4, offDimension.Height / 3 + font.Height * (info+2));
					}

				}

				// Copy the off screen buffer to the screen.
				e.Graphics.DrawImage( offImage, 0, 0 );

				penRGB.Dispose();
			}
		}

		public void initGame() 
		{

			// Initialize game data and sprites.

			score = 0;
			shipsLeft = MAX_SHIPS;
			asteroidsSpeed = MIN_ROCK_SPEED;
			newShipScore = NEW_SHIP_POINTS;
			newUfoScore = NEW_UFO_POINTS;

			initShip();
			initPhotons();
			stopUfo();
			stopMissle();
			initAsteroids();
			initExplosions();

			playing = true;
			paused = false;
		}

		public void endGame() 
		{
			// Stop ship, flying saucer, guided missle and associated sounds.

			playing = false;

			stopShip();
			stopUfo();
			stopMissle();
		}


		public void initAsteroids() 
		{
			int i, j;
			int s;
			double theta, r;

			// Create random shapes, positions and movements for each asteroid.

			for (i = 0; i < MAX_ROCKS; i++) 
			{
				// Create a jagged shape for the asteroid and give it a random rotation.

				s = MIN_ROCK_SIDES + (int) (random.NextDouble() * (MAX_ROCK_SIDES - MIN_ROCK_SIDES));
				//s = random.Next(MIN_ROCK_SIDES, MAX_ROCK_SIDES);
				Point[] pts = new Point[ s ];
				for (j = 0; j < s; j ++) 
				{
					theta = 2 * Math.PI / s * j;
					r = (MIN_ROCK_SIZE + (int) (random.NextDouble() * (MAX_ROCK_SIZE - MIN_ROCK_SIZE))) / 2;
					//r = random.Next(MIN_ROCK_SIDES, MAX_ROCK_SIDES)/2;
					pts[j].X = (int) -Math.Round(r * Math.Sin(theta));
					pts[j].Y = (int)  Math.Round(r * Math.Cos(theta));
				}

				asteroids[i].shape.Reset();// = new GraphicsPath();
				//asteroids[i].shape.addPoint(x, y);
				asteroids[i].shape.AddPolygon( pts );
				asteroids[i].active = true;
				asteroids[i].angle = 0.0;
				asteroids[i].deltaAngle = (random.NextDouble() - 0.5) / 10;

				// Place the asteroid at one edge of the screen.

				if (random.NextDouble() < 0.5) 
				{
					asteroids[i].currentX = -Sprite.Screen.Width / 2;
					if (random.NextDouble() < 0.5)
						asteroids[i].currentX = Sprite.Screen.Width / 2;
					//asteroids[i].currentY = random.Next() * Sprite.Screen.Height;
					asteroids[i].currentY = random.Next(Sprite.Screen.Height);
				}
				else 
				{
					//asteroids[i].currentX = random.Next() * Sprite.Screen.Width;
					asteroids[i].currentX = random.Next(Sprite.Screen.Width);
					asteroids[i].currentY = -Sprite.Screen.Height / 2;
					if (random.Next() < 0.5)
						asteroids[i].currentY = Sprite.Screen.Height / 2;
				}

				// Set a random motion for the asteroid.

				//asteroids[i].deltaX = random.Next() * asteroidsSpeed;
				asteroids[i].deltaX = random.Next(asteroidsSpeed);
				if (random.NextDouble() < 0.5)
					asteroids[i].deltaX = -asteroids[i].deltaX;
				//asteroids[i].deltaY = random.Next() * asteroidsSpeed;
				asteroids[i].deltaY = random.Next(asteroidsSpeed);
				if (random.NextDouble() < 0.5)
					asteroids[i].deltaY = -asteroids[i].deltaY;

				asteroids[i].render();
				asteroidIsSmall[i] = false;
			}

			asteroidsCounter = STORM_PAUSE;
			asteroidsLeft = MAX_ROCKS;
			if (asteroidsSpeed < MAX_ROCK_SPEED)
				asteroidsSpeed++;
		}

		public void updateAsteroids() 
		{

			int i, j;

			// Move any active asteroids and check for collisions.

			for (i = 0; i < MAX_ROCKS; i++)
				if (asteroids[i].active) 
				{
					asteroids[i].advance();
					asteroids[i].render();

					// If hit by photon, kill asteroid and advance score. If asteroid is large,
					// make some smaller ones to replace it.

					for (j = 0; j < MAX_SHOTS; j++)
						if (photons[j].active && asteroids[i].active && asteroids[i].isColliding(photons[j])) 
						{
							asteroidsLeft--;
							asteroids[i].active = false;
							photons[j].active = false;
							// if (sound)
							// 	explosionSound.play();
							explode(asteroids[i]);
							if (!asteroidIsSmall[i]) 
							{
								score += BIG_POINTS;
								initSmallAsteroids(i);
							}
							else
								score += SMALL_POINTS;
						}

					// If the ship is not in hyperspace, see if it is hit.

					if (ship.active && hyperCounter <= 0 && asteroids[i].active && asteroids[i].isColliding(ship)) 
					{
						// if (sound)
						//	crashSound.play();
						explode(ship);
						stopShip();
						stopUfo();
						stopMissle();
					}

				}
		}

		public void initExplosions() 
		{
			for (int i = 0; i < MAX_SCRAP; i++) 
			{
				//explosions[i].shape = new GraphicsPath();
				explosions[i].shape.Reset();
				//explosions[i].shape = new Polygon();
				explosions[i].active = false;
				explosionCounter[i] = 0;
			}
			explosionIndex = 0;
		}

		public void explode(Sprite s) 
		{
			int c, i, j, k;

			// Create sprites for explosion animation. The each individual line segment of the given sprite
			// is used to create a new sprite that will move outward  from the sprite's original position
			// with a random rotation.

			s.render();
			c = 2;
			if (detail || s.sprite.PathPoints.Length < 6)
				c = 1;

			for (i = 0; i < s.sprite.PathPoints.Length; i += c) 
			{
				explosionIndex++;
				if (explosionIndex >= MAX_SCRAP)
					explosionIndex = 0;
				explosions[explosionIndex].active = true;

				j = i + 1;
				if (j >= s.sprite.PathPoints.Length)
					j -= s.sprite.PathPoints.Length;
				k = j + 1;
				if (k >= s.sprite.PathPoints.Length)
					k -= s.sprite.PathPoints.Length;

				PointF[] points =
				{
					new PointF( s.shape.PathPoints[i].X, s.shape.PathPoints[i].Y ),
					new PointF( s.shape.PathPoints[j].X, s.shape.PathPoints[j].Y ),
					new PointF( s.shape.PathPoints[k].X, s.shape.PathPoints[k].Y )
				};

				//explosions[explosionIndex].shape = new GraphicsPath();
				explosions[explosionIndex].shape.Reset();
				explosions[explosionIndex].shape.AddPolygon( points );
				explosions[explosionIndex].angle = s.angle;
				explosions[explosionIndex].deltaAngle = (random.NextDouble() * 2 * Math.PI - Math.PI) / 15;
				explosions[explosionIndex].currentX = s.currentX;
				explosions[explosionIndex].currentY = s.currentY;

				explosions[explosionIndex].deltaX = -s.shape.PathPoints[i].X / 5;
				explosions[explosionIndex].deltaY = -s.shape.PathPoints[i].Y / 5;
				//explosions[explosionIndex].deltaX = -s.shape.xpoints[i] / 5;
				//explosions[explosionIndex].deltaY = -s.shape.ypoints[i] / 5;
				explosionCounter[explosionIndex] = SCRAP_COUNT;
			}
		}

		public void updateExplosions() 
		{
			// Move any active explosion debris. Stop explosion when its counter has expired.
			for (int i = 0; i < MAX_SCRAP; i++)
			{
				if (explosions[i].active) 
				{
					explosions[i].advance();
					explosions[i].render();
					if (--explosionCounter[i] < 0)
						explosions[i].active = false;
				}
			}
		}

		public void initShip() 
		{
			ship.active = true;
			ship.angle = 0.0;
			ship.deltaAngle = 0.0;
			ship.currentX = 0.0;
			ship.currentY = 0.0;
			ship.deltaX = 0.0;
			ship.deltaY = 0.0;
			ship.render();
			// if (loaded)
			//	thrustersSound.stop();
			thrustersPlaying = false;

			hyperCounter = 0;
		}

		public void updateShip() 
		{
			double dx, dy, limit;

			if (!playing)
				return;

			// Rotate the ship if left or right cursor key is down.

			if (right) 
			{
				ship.angle += Math.PI / 32.0;
				if (ship.angle > 2 * Math.PI)
					ship.angle -= 2 * Math.PI;
			}
			if (left) 
			{
				ship.angle -= Math.PI / 32.0;
				if (ship.angle < 0)
					ship.angle += 2 * Math.PI;
			}

			// Fire thrusters if up or down cursor key is down. Don't let ship go past
			// the speed limit.

			dx = Math.Sin(ship.angle);
			dy =  Math.Cos(ship.angle);
			limit = 0.8 * MIN_ROCK_SIZE;
			if (up) 
			{
				if (ship.deltaX + dx > -limit && ship.deltaX + dx < limit)
					ship.deltaX += dx;
				if (ship.deltaY + dy > -limit && ship.deltaY + dy < limit)
					ship.deltaY += dy;
			}
			if (down) 
			{
				if (ship.deltaX - dx > -limit && ship.deltaX - dx < limit)
					ship.deltaX -= dx;
				if (ship.deltaY - dy > -limit && ship.deltaY - dy < limit)
					ship.deltaY -= dy;
			}

			// Move the ship. If it is currently in hyperspace, advance the countdown.

			if (ship.active) 
			{
				ship.advance();
				ship.render();
				if (hyperCounter > 0)
					hyperCounter--;
			}

				// Ship is exploding, advance the countdown or create a new ship if it is
				// done exploding. The new ship is added as though it were in hyperspace.
				// (This gives the player time to move the ship if it is in imminent danger.)
				// If that was the last ship, end the game.

			else
				if (--shipCounter <= 0)
				if (shipsLeft > 0) 
				{
					initShip();
					hyperCounter = HYPER_COUNT;
				}
				else
					endGame();
		}

		public void stopShip() 
		{
			ship.active = false;
			shipCounter = SCRAP_COUNT;
			if (shipsLeft > 0)
				shipsLeft--;

			// if (loaded)
			//	thrustersSound.stop();
			thrustersPlaying = false;
		}

		public void initPhotons() 
		{
			int i;

			for (i = 0; i < MAX_SHOTS; i++) 
			{
				photons[i].active = false;
				photonCounter[i] = 0;
			}
			photonIndex = 0;
		}

		public void updatePhotons() 
		{
			int i;

			// Move any active photons. Stop it when its counter has expired.

			for (i = 0; i < MAX_SHOTS; i++)
				if (photons[i].active) 
				{
					photons[i].advance();
					photons[i].render();
					if (--photonCounter[i] < 0)
						photons[i].active = false;
				}
		}

		public void initUfo() 
		{

			// Randomly set flying saucer at left or right edge of the screen.

			ufo.active = true;
			ufo.currentX = -Sprite.Screen.Width / 2;
			ufo.currentY = random.NextDouble() * Sprite.Screen.Height;
			ufo.deltaX = MIN_ROCK_SPEED + random.NextDouble() * (MAX_ROCK_SPEED - MIN_ROCK_SPEED);
			if (random.NextDouble() < 0.5) 
			{
				ufo.deltaX = -ufo.deltaX;
				ufo.currentX = Sprite.Screen.Width / 2;
			}
			ufo.deltaY = MIN_ROCK_SPEED + random.NextDouble() * (MAX_ROCK_SPEED - MIN_ROCK_SPEED);
			if (random.NextDouble() < 0.5)
				ufo.deltaY = -ufo.deltaY;
			ufo.render();

			//saucerPlaying = true;

			//if (sound)
			//	saucerSound.loop();

			// Set counter for this pass.

			ufoCounter = (int) Math.Floor(Sprite.Screen.Width / Math.Abs(ufo.deltaX));
		}

		public void updateUfo() 
		{
			int i, d;

			// Move the flying saucer and check for collision with a photon. Stop it when its
			// counter has expired.

			if (ufo.active) 
			{
				ufo.advance();
				ufo.render();
				if (--ufoCounter <= 0)
					if (--ufoPassesLeft > 0)
						initUfo();
					else
						stopUfo();
				else 
				{
					for (i = 0; i < MAX_SHOTS; i++)
						if (photons[i].active && ufo.isColliding(photons[i])) 
						{
							//if (sound)
							//	crashSound.play();
							explode(ufo);
							stopUfo();
							score += UFO_POINTS;
						}

					// On occassion, fire a missle at the ship if the saucer is not
					// too close to it.

					d = (int) Math.Max(Math.Abs(ufo.currentX - ship.currentX), Math.Abs(ufo.currentY - ship.currentY));
					if (ship.active && hyperCounter <= 0 && ufo.active && !missle.active &&
						d > 4 * MAX_ROCK_SIZE && random.NextDouble() < .03)
						initMissle();
				}
			}
		}

		public void stopUfo() 
		{
			ufo.active = false;
			ufoCounter = 0;
			ufoPassesLeft = 0;
			//if (loaded)
			//	saucerSound.stop();
			//saucerPlaying = false;
		}

		public void initMissle() 
		{
			missle.active = true;
			missle.angle = 0.0;
			missle.deltaAngle = 0.0;
			missle.currentX = ufo.currentX;
			missle.currentY = ufo.currentY;
			missle.deltaX = 0.0;
			missle.deltaY = 0.0;
			missle.render();
			missleCounter = 3 * Math.Max(Sprite.Screen.Width, Sprite.Screen.Height) / MIN_ROCK_SIZE;
			//if (sound)
			//	missleSound.loop();
			//misslePlaying = true;
		}

		public void updateMissle() 
		{
			int i;

			// Move the guided missle and check for collision with ship or photon. Stop it when its
			// counter has expired.

			if (missle.active) 
			{
				if (--missleCounter <= 0)
					stopMissle();
				else 
				{
					guideMissle();
					missle.advance();
					missle.render();
					for (i = 0; i < MAX_SHOTS; i++)
						if (photons[i].active && missle.isColliding(photons[i])) 
						{
							// if (sound)
							//	crashSound.play();
							explode(missle);
							stopMissle();
							score += MISSLE_POINTS;
						}
					if (missle.active && ship.active && hyperCounter <= 0 && ship.isColliding(missle)) 
					{
						//	if (sound)
						//		crashSound.play();
						explode(ship);
						stopShip();
						stopUfo();
						stopMissle();
					}
				}
			}
		}

		public void guideMissle() 
		{
			double dx, dy, angle;

			if (!ship.active || hyperCounter > 0)
				return;

			// Find the angle needed to hit the ship.

			dx = ship.currentX - missle.currentX;
			dy = ship.currentY - missle.currentY;
			if (dx == 0 && dy == 0)
				angle = 0;
			if (dx == 0) 
			{
				if (dy < 0)
					angle = -Math.PI / 2;
				else
					angle = Math.PI / 2;
			}
			else 
			{
				angle = Math.Atan(Math.Abs(dy / dx));
				if (dy > 0)
					angle = -angle;
				if (dx < 0)
					angle = Math.PI - angle;
			}

			// Adjust angle for screen coordinates.

			missle.angle = angle - Math.PI / 2;

			// Change the missle's angle so that it points toward the ship.

			missle.deltaX = MIN_ROCK_SIZE / 3 * Math.Sin(missle.angle);
			missle.deltaY = MIN_ROCK_SIZE / 3 *  Math.Cos(missle.angle);
		}

		public void stopMissle() 
		{
			missle.active = false;
			missleCounter = 0;
			// if (loaded)
			//	missleSound.stop();
			//misslePlaying = false;
		}

		public void initSmallAsteroids(int n) 
		{
			int count;
			int i, j;
			int s;
			double tempX, tempY;
			double theta, r;

			// Create one or two smaller asteroids from a larger one using inactive asteroids. The new
			// asteroids will be placed in the same position as the old one but will have a new, smaller
			// shape and new, randomly generated movements.

			count = 0;
			i = 0;
			tempX = asteroids[n].currentX;
			tempY = asteroids[n].currentY;
			do 
			{
				if (!asteroids[i].active) 
				{
					s = MIN_ROCK_SIDES + (int) (random.NextDouble() * (MAX_ROCK_SIDES - MIN_ROCK_SIDES));
					//s = random.Next(MIN_ROCK_SIDES, MAX_ROCK_SIDES);
					PointF[] points = new PointF[s];
					for (j = 0; j < s; j ++)
					{
						theta = 2 * Math.PI / s * j;
						r = (MIN_ROCK_SIZE + (int) (random.NextDouble() * (MAX_ROCK_SIZE - MIN_ROCK_SIZE))) / 4;
						//r = random.Next(MIN_ROCK_SIZE, MAX_ROCK_SIZE)/4;
						points[j].X = (int) -Math.Round(r * Math.Sin(theta));
						points[j].Y = (int)  Math.Round(r * Math.Cos(theta));
						//asteroids[i].shape.addPoint(x, y);
					}
					//asteroids[i].shape = new GraphicsPath();
					asteroids[i].shape.Reset();
					asteroids[i].shape.AddPolygon( points );
					asteroids[i].active = true;
					asteroids[i].angle = 0.0;
					asteroids[i].deltaAngle = (random.NextDouble() - 0.5) / 10;
					asteroids[i].currentX = tempX;
					asteroids[i].currentY = tempY;
					asteroids[i].deltaX = random.NextDouble() * 2 * asteroidsSpeed - asteroidsSpeed;
					asteroids[i].deltaY = random.NextDouble() * 2 * asteroidsSpeed - asteroidsSpeed;
					asteroids[i].render();
					asteroidIsSmall[i] = true;
					count++;
					asteroidsLeft++;
				}
				i++;
			} while (i < MAX_ROCKS && count < 2);
		}
		private void LoadSounds()
		{

		}

		protected override void OnKeyDown( KeyEventArgs e )
		{
			// public bool keyDown(Event e, int key) {
			 
			// Check if any cursor keys have been pressed and set flags.

			if (e.KeyCode == Keys.Left)
				left = true;
			if (e.KeyCode == Keys.Right)
				right = true;
			if (e.KeyCode == Keys.Up)
				up = true;
			if (e.KeyCode == Keys.Down)
				down = true;

			if ((up || down) && ship.active && !thrustersPlaying) 
			{
				// if( sound && !paused )
				//		thrustersSound.loop();
				thrustersPlaying = true;
			}

			// Spacebar: fire a photon and start its counter.

			if (e.KeyCode == Keys.Space && ship.active) 
			{
				// if (sound & !paused)
				//	 fireSound.play();
				photonIndex++;
				if (photonIndex >= MAX_SHOTS)
					photonIndex = 0;
				photons[photonIndex].active = true;
				photons[photonIndex].currentX = ship.currentX;
				photons[photonIndex].currentY = ship.currentY;

  				photons[photonIndex].deltaX = MIN_ROCK_SIZE * Math.Sin(ship.angle);
				photons[photonIndex].deltaY = MIN_ROCK_SIZE *  Math.Cos(ship.angle);
				photonCounter[photonIndex] = Math.Min(Sprite.Screen.Width, Sprite.Screen.Height) / MIN_ROCK_SIZE;
			}

			// 'H' key: warp ship into hyperspace by moving to a random location and starting counter.

			if (e.KeyCode == Keys.H && ship.active && hyperCounter <= 0) 
			{
				ship.currentX = random.NextDouble() * Sprite.Screen.Width;
				ship.currentX = random.NextDouble() * Sprite.Screen.Height;
				hyperCounter = HYPER_COUNT;
			}

			// 'P' key: toggle pause mode and start or stop any active looping sound clips.

			if (e.KeyCode == Keys.P)
			{
				paused = !paused;
			}

			// 'M' key: toggle sound on or off and stop any looping sound clips.

			if (e.KeyCode == Keys.M && loaded) 
			{
				sound = !sound;
			}

			// 'D' key: toggle graphics detail on or off.

			if (e.KeyCode == Keys.D)
				detail = !detail;

			// 'S' key: start the game, if not already in progress.

			if (e.KeyCode == Keys.S && loaded && !playing)
				initGame();

			base.OnKeyDown(e);
		}

		protected override void OnKeyUp( KeyEventArgs e ) 
		{
			// Check if any cursor keys where released and set flags.

			if (e.KeyCode == Keys.Left)
				left = false;
			if (e.KeyCode == Keys.Right)
				right = false;
			if (e.KeyCode == Keys.Up)
				up = false;
			if (e.KeyCode == Keys.Down)
				down = false;

			if (!up && !down && thrustersPlaying) 
			{
				//thrustersSound.stop();
				thrustersPlaying = false;
			}

			base.OnKeyUp(e);
		}

		protected override void OnResize( EventArgs e )
		{
			paused = true;
			Sprite.Screen.Width = this.Size.Width;
			Sprite.Screen.Height = this.Size.Height;
			GenerateStarfield();
			base.OnResize( e );
		}

		public void Start() 
		{
			if( CREATE_THREAD )
			{
				if (loopThread == null) 
				{
					loopThread = new Thread( new ThreadStart(this.Run) );
					loopThread.Start();
				}
			}
			else
			{
				gameLoop = true;
				ThreadPool.QueueUserWorkItem( new WaitCallback( this.WorkItemSleep ), null );
			}
		}

		public void Stop() 
		{
			if( CREATE_THREAD )
			{
				loopThread.Abort(); 
				
				loopThread.Join();
				
				loopThread = null;
			}
			else
				gameLoop = false;
		}

		/// <summary>
		/// This is the main loop. 
		/// </summary>
		private void Run() 
		{
			try
			{
				
				LoadSounds();

				loaded = true;

				while( true )
				{
					try 
					{

						T0 = Environment.TickCount;

						if( !paused )
						{
							ProcessSprites( );
							ProcessStats( );
						}

						//
						// Update the screen and go to sleep until the next loop.
						//
						Invalidate(Region);

						Thread.Sleep(DELAY);

						T = Environment.TickCount - T0;
					}
					catch( ThreadInterruptedException )
					{
						break;
					}
				}
			}
			catch (Exception e) 
			{
				Debug.Write(e.ToString());
			}
		}

		private void WorkItemSleep(object state) 
		{
			LoadSounds();

            loaded = true;

			T0 = Environment.TickCount;

			Thread.Sleep(DELAY);

			ThreadPool.QueueUserWorkItem( new WaitCallback( this.WorkItemCalc ), null );
		}

		private void WorkItemCalc(object state)
		{
			if( !paused )
			{
				ProcessSprites();
				ProcessStats();
			}

			ThreadPool.QueueUserWorkItem( new WaitCallback( this.WorkItemPaint ), null );
		}
		private void WorkItemPaint(object state)
		{
			//
			// Update the screen and goto sleep until the next state.
			//
			Invalidate(Region);

			T = Environment.TickCount - T0;

			ThreadPool.QueueUserWorkItem( new WaitCallback( this.WorkItemSleep ), null );
		}

		/// <summary>Move and process all sprites.</summary>
		private void ProcessSprites()
		{
			lock(ship)
				updateShip();

			lock(photons)
				updatePhotons();

			lock(ufo)
				updateUfo();

			lock(missle)
				updateMissle();

			lock(asteroids)
				updateAsteroids();

			lock(explosions)
				updateExplosions();
		}

		/// <summary>
		/// Check the score and advance high score, add a new ship 
		/// or start the flying saucer as necessary.
		/// </summary>
		private void ProcessStats()
		{
			if (score > highScore)
				highScore = score;
			if (score > newShipScore) 
			{
				newShipScore += NEW_SHIP_POINTS;
				shipsLeft++;
			}
			if (playing && score > newUfoScore && !ufo.active) 
			{
				newUfoScore += NEW_UFO_POINTS;
				ufoPassesLeft = UFO_PASSES;
				initUfo();
			}

			// If all asteroids have been destroyed create a new batch.
			if (asteroidsLeft <= 0)
				if (--asteroidsCounter <= 0)
					initAsteroids();
		}
    }

	public class AsteroidsApp : Asteroids 
	{
		/// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;

		public AsteroidsApp()
		{
            InitializeComponent();
		}

        /// <summary>
        ///    Clean up any resources being used.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            components.Dispose();
        }

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(500, 500);
            this.Text = "C# Asteroids";
        }

		public void Main2( )
		{
			Application.Run( this );
		}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args) 
        {
            Application.Run(new AsteroidsApp());
        }
	}

	public class AsteroidsApp2 : AsteroidsApp
	{
		public AsteroidsApp2()
		{
			base.Main2();
		}

	    
	}

}  // Namespace
