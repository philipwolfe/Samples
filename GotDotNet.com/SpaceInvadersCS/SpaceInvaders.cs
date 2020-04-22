using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Diagnostics;

// this application utilizes the Console features of
// intercepting keys, getting a key as it's pressed,
// coloring, and moving buffer regions to make a space
// invaders application. It also takes advantage of the
// feature of generics for any collections it uses

// NOTE you will see that most exceptions caught by trying to use tracing are caught uncoditionally
// This is because this is a side-feature of the game (the tracing of data, the ability to have a demo-mode)
// If this fails, it should not cause the game to crash, so we ignore it
namespace Microsoft.Samples.SpaceInvaders
{
	public enum GameState
	{
		Waiting = 0,
		Playing = 1,
		Over = 2
	}

	public enum GameDetail
	{
		ShipBulletMissed = 0,
		ShipBulletHitInvader = 1,
		ShipBulletHitShield = 2,
		InvaderBulletMissed = 3,
		InvaderBulletHitShip = 4,
		InvaderBulletHitShield = 5,
		BulletsCollided = 6,
		StageCleared = 7,
		GameStarted = 8,
		ShipMovedLeft = 9,
		ShipMovedRight = 10,
		ShipFired = 11,
		InvaderFired = 12,
		WrongKeyPressed = 13,
		GameEnded = 14
	}

	[CLSCompliant(false)]
	public class Invaders
	{
		// collections
		TraceSource ts;
		SortedList<int,string[]> highScores;
		List<ItemPosition> liShipBullets;
		List<ItemPosition> liInvaderBullets;
		List<Invader> liInvaders;
		List<Shield> liShieldPositions;
		string[] scoreNames;
		Dictionary<string, Letter> letters;

		ConsoleColor initialBackColor;
		ConsoleColor initialForeColor;
		int initialWindowWidth;
		int initialWindowHeight;
		int initialBufferWidth;
		int initialBufferHeight;
		string initialTitle;

		// constants
		private const char halfShield = (char)9617;
		private const char fullShield = (char)9608;
		const int initInvaderTime = 850;

		// events
		System.Timers.Timer getSerialKeys = new System.Timers.Timer(60);
		System.Timers.Timer clearLcdScreen = new System.Timers.Timer(1500);
		System.Timers.Timer shipBulletTimer = new System.Timers.Timer (70);
		System.Timers.Timer HighScoreTimer = new System.Timers.Timer(14000);
		System.Timers.Timer shipDestroyedTimer = new System.Timers.Timer (250);
		System.Timers.Timer explosionTimer = new System.Timers.Timer (35);
		System.Timers.Timer invadersTimer = new System.Timers.Timer ();
		System.Timers.Timer invadersBulletTimer = new System.Timers.Timer (90);
		
		// variables
		int score = 0;
		SerialLcd lcd;
		int maxInvaderLeft;
		int minInvaderLeft;
		bool invadersMoveRight;
		int iterationCount = 0;
		ItemPosition currentShipPosition;
		ItemPosition invaderExplosion;
		int invaderExplosionState = 0;
		int shipCount = 3;
		bool highScoreDisplayed = false;
		bool shipBeingDestroyed = false;
		bool gettingName = false;
		bool demoMode = false;
		bool demoNotHighScore = false;
		GameState gameOver = GameState.Waiting;
		bool invadersReset = false;
		int shipExplosionState = 0;
		bool movesInvalid;
		bool _mute;

		// this member is to help ensure that any actions which get through from a previous
		// iteration, do not actually become actioned
		DateTime iterationStartTime;

		[STAThread]
		static void Main (string[] args)
		{
			Trace.CorrelationManager.StartLogicalOperation();
			Invaders id = new Invaders ();
			id.Run();
		}

		void Run() {
			highScores = GetScores();

			Initialize ();
			StartScreen();
			lcd = new SerialLcd();

			// this loop captures the keys pressed when
			// the game is waiting to be played
			// it only supports viewing the main and highscore
			// screens, or exitting the application
			Stopwatch swEnterDemoMode = new Stopwatch();

			while (true)
			{	
				if (!swEnterDemoMode.IsRunning)
				{
					swEnterDemoMode.Start();
				}
				// this runs demo mode every 15 seconds...
				while (!Console.KeyAvailable)
				{
					// just resets the lcd display
					if (lcd.IsOpen)
					{
						lcd.Reset();
					}

					if (!demoNotHighScore)
					{
						if (swEnterDemoMode.ElapsedMilliseconds > 8000)
						{
							ShowHighScores(7000);
							demoNotHighScore = true;
							swEnterDemoMode.Reset();
							swEnterDemoMode.Start();
						}
					}
					else
					{
						if (swEnterDemoMode.ElapsedMilliseconds > 14000)
						{
							HighScoreTimer.Enabled = false;
							RunDemoMode(20000);
							swEnterDemoMode.Reset();
							swEnterDemoMode.Start();
							StartScreen();
							demoNotHighScore = false;
						}
					}
				}
				swEnterDemoMode.Reset();
				ConsoleKeyInfo cki = Console.ReadKey (true);
				gameOver = GameState.Waiting;

				switch (cki.Key)
				{
					case (ConsoleKey.Escape) :
						if (highScoreDisplayed)
						{
							HighScoreTimer.Enabled = false;
							ListenerOperations.Clear(ts);
							StartScreen();
							if (ts == null)
							{
								ts = ListenerOperations.InitializeListener();
							}
							break;
						}
						else
						{
							// exit game
							try
							{
								ts.Flush();
							}
							catch
							{
							}
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Gray;
							Console.CursorVisible = true;

							// write out the high scores
							SetScores();
							Trace.CorrelationManager.StopLogicalOperation();
							if (lcd.IsOpen)
							{
								lcd.Close();
							}
							// reset the initial values for the window...
							Console.BackgroundColor = initialBackColor;
							Console.ForegroundColor = initialForeColor;
							Console.Title = initialTitle;
							Console.BufferHeight = initialBufferHeight;
							Console.BufferWidth = initialBufferWidth;
							Console.WindowHeight = initialWindowHeight;
							Console.WindowWidth = initialWindowWidth;
							Console.SetWindowPosition(0, 0);
							Console.Clear();
							return;
						}				
					case (ConsoleKey.S) :
						HighScoreTimer.Enabled = false;
						// start game
						demoMode = false;
						StartGame();
						Play();
						while (gettingName || (gameOver == GameState.Over) || (gameOver == GameState.Playing)) {}

						StartScreen();
						break;
					case (ConsoleKey.D):
						HighScoreTimer.Enabled = false;
						ListenerOperations.Clear(ts);
						RunDemoMode(int.MaxValue);
						if (ts == null)
						{
							ts = ListenerOperations.InitializeListener();
						}
						demoMode = false;
						score = 0;
						gameOver = GameState.Waiting;
						gettingName = false;
						Reset();
						ClearLists();
						StartScreen();
						break;
					case (ConsoleKey.O) :
						OpenLcd();
						break;
					case (ConsoleKey.C) :
						CloseLcd();
						break;
					case (ConsoleKey.H) :
						HighScoreTimer.Enabled = false;
						// Display the high score table
						ShowHighScores(12000);
						break;

					case (ConsoleKey.M) :
						// Mute
						_mute = !_mute;
						break;
					case (ConsoleKey.Q):
						// Mute
						HighScoreTimer.Enabled = false;
						StartScreen();
						break;
					default:
						try
						{
							ts.TraceEvent(TraceEventType.Error, (int)GameDetail.WrongKeyPressed, "User pressed the wrong key: " + cki.Key);
						}
						catch
						{
						}
						break;
				}
			}
		}

		void OpenLcd()
		{
			if (!lcd.IsOpen)
			{
				getSerialKeys.Elapsed += new ElapsedEventHandler(OnSerialKeysEvent);
				clearLcdScreen.Elapsed += new ElapsedEventHandler(OnSerialLcdClearedEvent);
				lcd.Open();
			}
		}

		void CloseLcd()
		{
			if (lcd.IsOpen)
			{
				getSerialKeys.Elapsed -= new ElapsedEventHandler(OnSerialKeysEvent);
				clearLcdScreen.Elapsed += new ElapsedEventHandler(OnSerialLcdClearedEvent);
				lcd.Close();
			}
		}

		void RunDemoMode(int millisecondDuration)
		{
			// this is simply a guarantee...
			ListenerOperations.RemoveListenerFromSource(ts, "gamedemo");

			demoMode = true;
			SortedList<long,GameEvent> gameEvents;

			try
			{
				gameEvents = GetGameEvents("demo.log");
			}
			catch
			{
				// exceptions will generally be a file format error,
				// or the file doesn't exist: these are not important
				// from the game perspective... if we get any kind of exception
				// trying to run the demo mode, simply ignore it...
				return;
			}

			Stopwatch sw = new Stopwatch();
			sw.Start();
			StartGame();
			DrawShip(ShipPosition.Initial);
			DrawHighScore();
			
			Stopwatch swDuration = new Stopwatch();
			swDuration.Start();

			foreach (GameEvent ge in gameEvents.Values) {
				while (true)
				{
					if (!Console.KeyAvailable && swDuration.ElapsedMilliseconds < millisecondDuration)
					{
						if (sw.ElapsedTicks > ge.Ticks)
						{
							// this functionality is pretty much a copy of what
							// is in the Play() function, for ShipFired,
							// movedleft and movedright
							// InvaderFired is basically what generateinvaderbullet does
							switch (ge.GameDetail)
							{
								case GameDetail.InvaderFired:
									try
									{
										// INVADERID
										int invID = Convert.ToInt32(ge.Message.Substring(0, 3).Trim(), CultureInfo.InvariantCulture);

										foreach (Invader i in liInvaders)
										{
											if (i.Identification == invID)
											{
												ShootInvaderBullet(i);
												break;
											}
										}	
									}
									catch
									{
										// the try/catch block is here, because the timing can get a little off
										// and it can try to make a non-existent invader fire...
										// if it does that, then simply ignore it
									}

									break;

								case GameDetail.ShipFired:
									if (!shipBeingDestroyed)
									{
										lock (this)
										{
											ShootBullet();
										}
									}

									break;

								case GameDetail.ShipMovedLeft:
									if (!shipBeingDestroyed)
									{
										lock (this)
										{
											DrawShip(ShipPosition.MoveLeft);
										}
									}

									break;

								case GameDetail.ShipMovedRight:
									if (!shipBeingDestroyed)
									{
										lock (this)
										{
											DrawShip(ShipPosition.MoveRight);
										}
									}

									break;

								default:
									break;
							}
							break;
						}
					}
					else
					{
						// just make sure we eat the key...
						if (Console.KeyAvailable)
						{
							ConsoleKeyInfo cki = Console.ReadKey(true);
						}
						Reset();
						
						return;
					}
				}
			}
			Reset();
		}

		SortedList<long,GameEvent> GetGameEvents(string fileName)
		{
			string[] lines = File.ReadAllLines(fileName);
			SortedList<long,GameEvent> sd = new SortedList<long,GameEvent>();
			long startOfGame = 0;
			long currentTicks = 0;

			foreach (string line in lines)
			{
				string[] vals = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

				if (Convert.ToInt32(vals[2], CultureInfo.InvariantCulture) == (int)GameDetail.GameStarted)
				{
					startOfGame = Convert.ToInt64(vals[4], CultureInfo.InvariantCulture);
				}

				currentTicks = Convert.ToInt64(vals[4], CultureInfo.InvariantCulture) - startOfGame;
				sd.Add(currentTicks, new GameEvent(vals[1], vals[2], vals[3], currentTicks));
			}

			return sd;
		}

		void ShowHighScores(int millisecondDuration)
		{
			// get the high scores first: make sure we can retrieve them ...
			HighScoreTimer.Enabled = false;
			HighScoreTimer.Interval = millisecondDuration;
			Console.Clear();
			lock (this)
			{
				DrawLetters(12, 1, 15, 0, false, new string[] { "H", "I", "G", "H" });
				DrawLetters(12, 9, 9, 0, false, new string[] { "S", "C", "O", "R", "E", "S" });

				for (int i = 0; i < 10; i++)
				{
					Console.SetCursorPosition(11, 17 + (i * 2));
					WriteEntry(String.Format(CultureInfo.CurrentCulture, "{0,-8}", 
							scoreNames[i]) + "................................. " +
							String.Format(CultureInfo.CurrentCulture, "{0}  {1:00000}", 
							GetVal(i + 1, 0), 
							Convert.ToInt32(GetVal(i + 1, 1), 
							CultureInfo.CurrentCulture)), 
							GetNextColor(i));
				}
			}
			highScoreDisplayed = true;
			HighScoreTimer.Enabled = true;
		}

		string GetVal(int element, int index)
		{
			return ((string[])HighScores[element])[index];
		}

		SortedList<int,string[]> GetScores()
		{
			SortedList<int, string[]> scores = new SortedList<int, string[]>();
			RegistryKey rk = null;

			try
			{
					rk = Registry.LocalMachine.CreateSubKey(@"Software\Demos\ConsoleInvaders");

				for (int i = 0; i < 10; i++)
				{
					string s = ((char)(65 + i)).ToString(Thread.CurrentThread.CurrentCulture);
					scores.Add(i + 1, 
						(string[])rk.GetValue("Score" + (i + 1).ToString(Thread.CurrentThread.CurrentCulture), new string[] { s + s + s, (5000 - (i * 500)).ToString(Thread.CurrentThread.CurrentCulture) }, RegistryValueOptions.None));
				}
			}
			catch
			{
				// once again, this aspect of the game is not perceived to be CRITICAL
				// to the main functionality. If we did not successfully get the data out
				// of the registry, don't panic: just make a new table
				for (int i = 0; i < 10; i++)
				{
					string s = ((char)(65 + i)).ToString(Thread.CurrentThread.CurrentCulture);
					scores[i + 1] = new string[] {s + s + s, (5000 - (i * 500)).ToString(Thread.CurrentThread.CurrentCulture)};
				}
			}
			finally
			{
				rk.Close();
			}

			return scores;
		}

		void SetScores()
		{
			RegistryKey rk = null;
			try
			{
				rk = Registry.LocalMachine.OpenSubKey(@"Software\Demos\ConsoleInvaders", true);

				rk.SetValue("Score1", HighScores[1]);
				rk.SetValue("Score2", HighScores[2]);
				rk.SetValue("Score3", HighScores[3]);
				rk.SetValue("Score4", HighScores[4]);
				rk.SetValue("Score5", HighScores[5]);
				rk.SetValue("Score6", HighScores[6]);
				rk.SetValue("Score7", HighScores[7]);
				rk.SetValue("Score8", HighScores[8]);
				rk.SetValue("Score9", HighScores[9]);
				rk.SetValue("Score10", HighScores[10]);
			}
			catch
			{
				// if we failed to write, it's not critical to the game.
				// So don't cause the game to crash, just continue
				// Note: this raises an fxcop error
			}
			finally
			{
				rk.Close();
			}
		}

		void WriteScore(int scoreToWrite)
		{
			lock (this)
			{
				int valToWriteOver = 0;

				for (int i = 0; i < HighScores.Count; i++) {
					if (scoreToWrite > Convert.ToInt32((HighScores.Values[i])[1], CultureInfo.InvariantCulture))
					{
						valToWriteOver = HighScores.Keys[i];
						break;
					}
				}

				if (valToWriteOver > 0)
				{
					Console.Clear();
					lock (this)
					{
						Console.SetCursorPosition(15, 6);
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.Write("You made the high score table!");
						Console.SetCursorPosition(15, Console.CursorTop + 2);
						Console.Write("Please enter your initals ==> AAA");
						Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
					}
					string initials = CaptureInitials();

					for (int i = 10; i > valToWriteOver; i--)
					{
						HighScores[i] = HighScores[i - 1];
					}

					HighScores[valToWriteOver] = new String[] { initials, scoreToWrite.ToString(Thread.CurrentThread.CurrentCulture) };
				}
			}
			
		}

		string CaptureInitials()
		{
			Char curA = (char)65;
			Char curB = (char)65;
			Char curC = (char)65;
			int position = 0;
			gettingName = true;

			while (true)
			{
				Console.CursorSize = 100;
				Console.CursorVisible = true;
				ConsoleKeyInfo cki = Console.ReadKey(true);

				switch (cki.Key) {
					case ConsoleKey.DownArrow:
						if (position == 0)
						{
							SetValUp(ref curA);
						}
						else if (position == 1)
						{
							SetValUp(ref curB);
						}
						else
						{
							SetValUp(ref curC);
						}
						Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
						break;
					case ConsoleKey.UpArrow:
						if (position == 0)
						{
							SetValDown(ref curA);
						}
						else if (position == 1)
						{
							SetValDown(ref curB);
						}
						else
						{
							SetValDown(ref curC);
						}
						Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
						break;

					case ConsoleKey.LeftArrow:
						if (position > 0)
						{
							position = position - 1;
							Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
						}
						else
						{
							position = position + 2;
							Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
						}
						break;

					case ConsoleKey.RightArrow:
						if (position < 2)
						{
							position = position + 1;
							Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
						}
						else
						{
							position = position - 2;
							Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
						}
						break;
					case ConsoleKey.SpaceBar:
						if (position == 1)
						{
							Console.Write(" ");
							position++;
						}
						break;
					case ConsoleKey.BackSpace :
						if (position > 0)
						{
							Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
							position--;
						}
						break;
					case ConsoleKey.Enter:
						if (position == 2)
						{
							Console.CursorVisible = false;
							return curA.ToString(Thread.CurrentThread.CurrentCulture) + curB.ToString(Thread.CurrentThread.CurrentCulture) + curC.ToString(Thread.CurrentThread.CurrentCulture);
						}
						else
						{
							position++;
						}
						break;
				}

				if (cki.Key >= ConsoleKey.A && cki.Key <= ConsoleKey.Z)
				{
					Console.Write((char)cki.Key);
					if (position == 2)
					{
						Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
						curC = (char)cki.Key;
					}
					else
					{
						if (position == 0)
						{
							curA = (char)cki.Key;
						}
						else if (position == 1)
						{
							curB = (char)cki.Key;
						}
						position++;
					}
				}
			}
		}

		void SetValUp(ref char curVal)
		{
			if (curVal < (char)(65 + 25))
			{
				curVal++;
			}
			else
			{
				curVal = (char)65;
			}

			Console.Write(curVal);
		}

		void SetValDown(ref char curVal)
		{
			if (Convert.ToInt32(curVal, CultureInfo.InvariantCulture) > 65)
			{
				curVal--;
			}
			else
			{
				curVal = (char)(65 + 25);
			}

			Console.Write(curVal);
		}

		SortedList<int, string[]> HighScores
		{
			get { return highScores; }
		}

		void Play()
		{
			DrawShip (ShipPosition.Initial);
			DrawHighScore();
			while (true)
			{
				// THIS loop, is simply to ensure an extra key is not captured by accident...
				while (!Console.KeyAvailable)
				{
					if ((gameOver == GameState.Over) || (gameOver == GameState.Waiting) || gettingName)
					{
						// show gameover!
						DisplayGameOver(400);
						ts.Flush();
						return;
					}
				}

				ConsoleKeyInfo cki = Console.ReadKey (true);

				switch (cki.Key)
				{
					case (ConsoleKey.LeftArrow) :
						// move the ship left ...
						if (!shipBeingDestroyed)
						{
							lock (this)
							{
								DrawShip(ShipPosition.MoveLeft);
							}
						}

						break;

					case (ConsoleKey.RightArrow) :
						// move the ship right ...
						if (!shipBeingDestroyed)
						{
							lock (this)
							{
								DrawShip(ShipPosition.MoveRight);
							}
						}

						break;

					case (ConsoleKey.SpaceBar) :
						// bullet was fired!
						if (!shipBeingDestroyed)
						{
							lock (this)
							{
								ShootBullet();
							}
						}
						break;
					case (ConsoleKey.Escape) :
						EndGame();
						return;
					case (ConsoleKey.M) :
						_mute = !_mute;
						break;
					case (ConsoleKey.P):
						// loop here until p pressed again ...
						DisableTimers(false);
						lock (this)
						{
							HideInvaders();
							DrawLetters( 14, 12, 8, 0, false, new string[] { "P", "A", "U", "S", "E", "D" });
							while (true)
							{
								ConsoleKeyInfo ckNext = Console.ReadKey(true);

								if (ckNext.Key == ConsoleKey.P)
								{
									if (lcd.IsOpen)
									{
										WriteLcdLine(null, null);
									}
									break;
								}
								else if (ckNext.Key == ConsoleKey.Escape)
								{
									EndGame();
									return;
								}
								else if (ckNext.Key == ConsoleKey.O)
								{
									OpenLcd();
								}
								else if (ckNext.Key == ConsoleKey.C)
								{
									CloseLcd();
								}
							}
							DrawLetters(14, 12, 8, 0, true, new string[] { "P", "A", "U", "S", "E", "D" });
							ShowInvaders();
						}
						DisableTimers(true);			
						break;

					default:
						ts.TraceEvent(TraceEventType.Error,(int)GameDetail.WrongKeyPressed, "Invalid key: " + cki.Key);
						break;

				}
			}
		}

		void EndGame()
		{
			if (!demoMode)
			{
				ts.TraceEvent(TraceEventType.Information, (int)GameDetail.GameEnded, "Game Ended, oh well...");
				WriteLcdLine("Goodbye", null);
			}

			ListenerOperations.Clear(ts);
			Console.Clear();
			DisableTimers(false);
			ClearLists();
			gameOver = GameState.Waiting;
			if (ts == null)
			{
				ts = ListenerOperations.InitializeListener();
			}
			return;
		}

		void WriteLcdLine(string line1, string line2)
		{
			if (lcd.IsOpen)
			{

				clearLcdScreen.Enabled = false;
				lcd.WriteLine1(CenterLcdLine(line1));
				lcd.WriteLine2(CenterLcdLine(line2));
				clearLcdScreen.Enabled = true;
			}
		}

		string CenterLcdLine(string line)
		{
			if (line == null)
			{
				return "";
			}

			string centeredLine = line;
			int left = (17 - centeredLine.Length) / 2;
			for (int i = 0; i < left; i++)
			{
				centeredLine = " " + centeredLine;
			}
			return centeredLine;
		}

		void DrawHighScore()
		{
			Console.SetCursorPosition(28, 0);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("HIGH SCORE ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("{0:00000}", Convert.ToInt32(highScores[1][1], CultureInfo.InvariantCulture));
		}

		void HideInvaders()
		{
			lock (this)
			{
				foreach (Invader i in liInvaders)
				{
					Console.MoveBufferArea(0, 0, 3, 1, i.Position.Left, i.Position.Top);
				}
			}
		}

		void ShowInvaders()
		{
			foreach (Invader i in liInvaders)
			{
				DrawInvader(i.Position.Left, i.Position.Top, GetNextColor((i.Position.Top - 2) / 3));
				
			}
		}

		void ClearLists ()
		{
			liShipBullets = new List<ItemPosition>();
			liShieldPositions = new List<Shield>();
			liInvaders = new List<Invader>();
			liInvaderBullets = new List<ItemPosition>();
		}

		void WriteEntry (string entry, ConsoleColor foreColor)
		{
			Console.ForegroundColor = foreColor;
			Console.Write (entry);
		}

		void Initialize ()
		{
			
			// copy the initial state of the window...
			initialBackColor = Console.BackgroundColor;
			initialForeColor = Console.ForegroundColor;
			initialTitle = Console.Title;
			initialBufferHeight = Console.BufferHeight;
			initialBufferWidth = Console.BufferWidth;
			initialWindowHeight = Console.WindowHeight;
			initialWindowWidth = Console.WindowWidth;
			Console.BackgroundColor = ConsoleColor.Black;

			Console.SetWindowPosition(0,0);
			if (Console.WindowHeight > 72 || Console.WindowWidth > 36)
                Console.SetWindowSize (10, 10);
			Console.SetBufferSize(73, 37);
			Console.SetWindowSize (Console.BufferWidth, Console.BufferHeight);

			// this line is to ensure the background is black...
			Console.Clear();

			Console.CursorVisible = false;
			Console.Title = "Managed Space Invaders";
			HighScoreTimer.Elapsed += new ElapsedEventHandler(OnHighScoreTimedEvent);
			shipBulletTimer.Elapsed += new ElapsedEventHandler(OnBulletTimedEvent);
			invadersTimer.Elapsed += new ElapsedEventHandler(OnInvadersTimedEvent);
			invadersBulletTimer.Elapsed += new ElapsedEventHandler(OnInvadersBulletTimedEvent);
			explosionTimer.Elapsed += new ElapsedEventHandler(OnInvadersExplosion);
			shipDestroyedTimer.Elapsed += new ElapsedEventHandler(OnShipDestroyed);

			scoreNames = new string[10];
			scoreNames[0] = "First";
			scoreNames[1] = "Second";
			scoreNames[2] = "Third";
			scoreNames[3] = "Fourth";
			scoreNames[4] = "Fifth";
			scoreNames[5] = "Sixth";
			scoreNames[6] = "Seventh";
			scoreNames[7] = "Eighth";
			scoreNames[8] = "Ninth";
			scoreNames[9] = "Tenth";

			MakeLetters();

			if (ts == null)
			{
				ts = ListenerOperations.InitializeListener();
			}
		}

		void MakeLetters() 
		{
			letters = new Dictionary<string,Letter>();
			letters.Add("S", new Letter("S", ConsoleColor.White, new string[] { "SSSSS", "S   S", "S", "SSSSS", "    S", "S   S", "SSSSS" }));
			letters.Add("P", new Letter("P", ConsoleColor.Green, new string[] { "PPPPP", "P   P", "P   P", "PPPPP", "P", "P", "P" }));
			letters.Add("A", new Letter("A", ConsoleColor.Red, new string[] { "  A", " AAA", " A A", "AA AA", "AAAAA", "A   A", "A   A" }));
			letters.Add("C", new Letter("C", ConsoleColor.Gray, new string[] { "CCCCC", "C   C", "C", "C", "C", "C   C", "CCCCC" }));
			letters.Add("E", new Letter("E", ConsoleColor.Blue, new string[] { "EEEEE", "E", "E", "EEE", "E", "E", "EEEEE" }));
			letters.Add("I", new Letter("I", ConsoleColor.Blue, new string[] { "IIIII", "  I", "  I", "  I", "  I", "  I", "IIIII" }));
			letters.Add("N", new Letter("N", ConsoleColor.DarkYellow, new string[] { "N   N", "NN  N", "NN  N", "N N N", "N  NN", "N  NN", "N   N" }));
			letters.Add("V", new Letter("V", ConsoleColor.Yellow, new string[] { "V   V", "V   V", "V   V", "V   V", "V   V", " V V", "  V" }));
			letters.Add("D", new Letter("D", ConsoleColor.Magenta, new string[] { "DDD", "D  D", "D   D", "D   D", "D   D", "D  D", "DDD" }));
			letters.Add("R", new Letter("R", ConsoleColor.Cyan, new string[] { "RRRR", "R  R", "R   R", "RRRRR", "R   R", "R   R", "R   R" }));
			letters.Add("O", new Letter("O", ConsoleColor.Gray, new string[] { "OOOOO", "O   O", "O   O", "O   O", "O   O", "O   O", "OOOOO" }));
			letters.Add("G", new Letter("G", ConsoleColor.Blue, new string[] { "GGGGG", "G   G", "G", "G", "G  GG", "G   G", "GGGGG" }));
			letters.Add("M", new Letter("M", ConsoleColor.White, new string[] { "M   M", "MM MM", "M M M", "M M M", "M   M", "M   M", "M   M" }));
			letters.Add("U", new Letter("U", ConsoleColor.Green, new string[] { "U   U", "U   U", "U   U", "U   U", "U   U", "U   U", " UUU" }));
			letters.Add("H", new Letter("H", ConsoleColor.Green, new string[] { "H   H", "H   H", "H   H", "HHHHH", "H   H", "H   H", "H   H" }));
			}

		void Reset()
		{
			DisableTimers(false);
			ResetTimers();
		}

		void DrawLetters(int left, int top, int leftAddition, int sleep, bool blackOut, params string[] rows)
		{
			int count = 0;
			int leftPos = left;

			foreach (string row in rows)
			{
				lock (this)
				{
					foreach (string s in letters[row].GetValues())
					{
						Console.SetCursorPosition(leftPos, top + count);
						WriteEntry(s, blackOut ? ConsoleColor.Black : letters[row].Color);
						count++;
					}
				}
				if (sleep > 0)
					Thread.Sleep(sleep);

				leftPos += leftAddition;
				count = 0;
			}
		}

		void StartScreen ()
		{
			Console.Clear();
			// space
			DrawLetters( 11, 4, 12, 0, false, new string[] { "S", "P", "A", "C", "E" });

			// invaders
			DrawLetters(10, 12, 7, 0, false, new string[] { "I", "N", "V", "A", "D", "E", "R", "S" });

			Console.SetCursorPosition (8, 22);
			WriteEntry("Esc    End Game", ConsoleColor.Cyan);
			Console.SetCursorPosition (8, 24);
			WriteEntry("S      Start New Game", ConsoleColor.White);
			Console.SetCursorPosition (8, 26);
			WriteEntry("P      Pause (In Game)", ConsoleColor.Green);
			Console.SetCursorPosition (8, 28);
			WriteEntry("H      High Score Table", ConsoleColor.Red);
			Console.SetCursorPosition(8, 30);
			WriteEntry("M      Mute/Unmute Sound", ConsoleColor.Magenta);

			Console.SetCursorPosition (8, 22);
			for (int i = 1; i < 12; i++)
			{
				ConsoleColor color = GetNextColor (i);
				DrawInvader( 50, i + 21, color);
				Console.SetCursorPosition (55, i + 21);
				WriteEntry (" = " + String.Format (CultureInfo.CurrentCulture, "{0:00}", (i * 5)) + " points", color);
			}
			highScoreDisplayed = false;
		}

		void StartGame ()
		{
			gameOver = GameState.Playing;
			
			if (!demoMode)
			{
				ListenerOperations.StartGameTrace(ts);
				ListenerOperations.RemoveListenerFromSource(ts, "gamestats");
				File.Delete("gamestats.log");
				ListenerOperations.AddListenerToSource(ts, ListenerOperations.GetListener("gamestats"));
				ListenerOperations.RemoveListenerFromSource(ts, "gamedemo");
				File.Delete("demo.log");
				ListenerOperations.AddListenerToSource(ts, ListenerOperations.GetListener("gamedemo"));
			}

			if (!demoMode)
			{
				ts.TraceEvent(TraceEventType.Information, (int)GameDetail.GameStarted, "Game Started");
				WriteLcdLine("Good Luck!", null);
			}

			Console.Clear ();
			iterationCount = 0;
			ClearLists();
			Reset();

			// other variables to initialize ...
			highScoreDisplayed = false;
			shipBeingDestroyed = false;
			invadersMoveRight = true;
			shipCount = 3;
			iterationCount = 0;

			// Score
			ScoreUpdate ();

			// Ships
			DrawReserveShips ();
			InitializeInvaders (iterationCount);
			iterationCount++;
			iterationStartTime = DateTime.Now;
			invadersBulletTimer.Enabled = true;
			getSerialKeys.Enabled = true;

			// shields
			DrawShields ();
		}

		void DrawReserveShips ()
		{
			lock (this)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				for (int i = 2; i > 0; i--)
					Console.MoveBufferArea(0, 0, 3, 1, Console.WindowWidth - 3 - (3 * i), 0);

				for (int i = shipCount - 1; i > 0; i--)
				{
					Console.SetCursorPosition(Console.WindowWidth - 3 - (3 * i), 0);
					Console.Write("{0}{1}{2}", (char)9568, (char)9575, (char)9571);
				}
			}
		}

		void DrawShields ()
		{
			liShieldPositions = new List<Shield>();
			lock (this)
			{
				Console.ForegroundColor = ConsoleColor.Gray;
				for (int i = 0; i < 5; i++)
				{
					Console.SetCursorPosition(i * 14 + 5, Console.WindowHeight - 8);
					Console.Write("{0}{0}{0}{0}{0}{0}", fullShield);
					Console.SetCursorPosition(i * 14 + 5, Console.WindowHeight - 7);
					Console.Write("{0}{0}  {0}{0}", fullShield);
					Console.SetCursorPosition(i * 14 + 5, Console.WindowHeight - 6);
					Console.Write("{0}{0}  {0}{0}", fullShield);
					for (int j = 5; j <= 10; j++)
					{
						liShieldPositions.Add(new Shield(new ItemPosition(i * 14 + j, Console.WindowHeight - 8)));
					}

					for (int j = 0; j <= 1; j++)
					{
						liShieldPositions.Add(new Shield(new ItemPosition(i * 14 + 5, Console.WindowHeight - (7 - j))));
						liShieldPositions.Add(new Shield(new ItemPosition(i * 14 + 6, Console.WindowHeight - (7 - j))));
						liShieldPositions.Add(new Shield(new ItemPosition(i * 14 + 9, Console.WindowHeight - (7 - j))));
						liShieldPositions.Add(new Shield(new ItemPosition(i * 14 + 10, Console.WindowHeight - (7 - j))));
					}
				}
			}
		}

		void ResolveShieldCollisions ()
		{
			for (int i = 0; i < liShieldPositions.Count; i++)
			{
				bool destroyed = false;

				foreach (ItemPosition ip in liInvaderBullets)
				{
					if (ip.Left == liShieldPositions[i].Position.Left && ip.Top == liShieldPositions[i].Position.Top)
					{
						lock (this)
						{
							Console.MoveBufferArea(0, 0, 1, 1, ip.Left, ip.Top);
							liShieldPositions.RemoveAt(i);
							i--;
							destroyed = true;
						}

						if (!demoMode)
						{
							ts.TraceEvent(TraceEventType.Information, (int) GameDetail.InvaderBulletHitShield, "Invader bullet hit shield");
						}
						liInvaderBullets.Remove(ip);
						break;
					}
				}

				if (!destroyed)
				{
					foreach (ItemPosition ip in liShipBullets)
					{
						if (ip.Left == liShieldPositions[i].Position.Left && ip.Top == liShieldPositions[i].Position.Top)
						{
							lock (this)
							{
								Console.MoveBufferArea(0, 0, 1, 1, ip.Left, ip.Top);
								liShieldPositions.RemoveAt(i);
								i--;
							}
							if (!demoMode)
							{
								ts.TraceEvent(TraceEventType.Information, (int) GameDetail.ShipBulletHitShield, "Interesting, shooting own shield?");
							}
							liShipBullets.Remove(ip);
							break;
						}
					}
				}
			}
		}

		void InitializeInvaders (int topRow)
		{
			invadersTimer.Enabled = false;
			invadersTimer.Interval = initInvaderTime;
			liInvaders = new List<Invader>();
			invadersMoveRight = false;

			int initCursorLeft = Console.CursorLeft;
			int initCursorTop = Console.CursorTop;
			int invaderCount = 0;

			lock (this)
			{
				Console.BackgroundColor = ConsoleColor.Black;
				for (int j = topRow; j < 5 + topRow; j++)
				{
					ConsoleColor foreColor = GetNextColor(j + 1);

					for (int i = 0; i < 8; i++)
					{
						int k = i * 7 + 5;
						int l = (j * 3 + 2) + 3;

						Console.SetCursorPosition(k, l);
						invaderCount++;
						liInvaders.Add(new Invader(new ItemPosition(k, l), invaderCount));
						Console.ForegroundColor = foreColor;
						Console.Write("{0}{1}{2}", (char)9561, (char)9573, (char)9564);
					}
				}

				Console.BackgroundColor = ConsoleColor.Black;
				Console.SetCursorPosition(initCursorLeft, initCursorTop);
			}
			invadersTimer.Enabled = true;
		}

		void DrawInvader (int left, int top, ConsoleColor foreColor)
		{
			lock (this)
			{
				Console.SetCursorPosition(left, top);
				Console.ForegroundColor = foreColor;
				Console.Write("{0}{1}{2}", (char)9561, (char)9573, (char)9564);
			}
		}

		void GenerateInvaderBullet ()
		{
			Random r = new Random (DateTime.Now.Millisecond);
			int next = r.Next (1000);

			if (next > (1000 - 40 * iterationCount))
			{
				List<Invader> InvadersCanFire = new List<Invader>();

				// identify a random invader, and have it shoot
				foreach (Invader ipInvader in liInvaders)
				{
					if (ipInvader.CanFire (liInvaders))
						InvadersCanFire.Add (ipInvader);
				}

				int nextInvader = r.Next (InvadersCanFire.Count);
				Invader invader = InvadersCanFire[nextInvader];

				ShootInvaderBullet(invader);
			}
		}

		void ShootInvaderBullet(Invader invader)
		{
			liInvaderBullets.Add(new ItemPosition(invader.Position.Left + 1, invader.Position.Top + 1));
			if (!demoMode)
			{
				ts.TraceEvent(TraceEventType.Information, (int)GameDetail.InvaderFired, invader.Identification + " Invader fired, will it hit?? (aaargh!)");
			}

			lock (this)
			{
				Console.SetCursorPosition(invader.Position.Left + 1, invader.Position.Top + 1);
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write((char)9553);
			}
		}

		ConsoleColor GetNextColor (int j)
		{
			switch (j)
			{
				case (0) :
					return ConsoleColor.Red;
				case (1):
					return ConsoleColor.White;
				case (2):
					return ConsoleColor.Gray;
				case (3):
					return ConsoleColor.Yellow;
				case (4):
					return ConsoleColor.Green;
				case (5):
					return ConsoleColor.Cyan;
				case (6):
					return ConsoleColor.DarkYellow;
				case (7):
					return ConsoleColor.DarkGreen;
				case (8):
					return ConsoleColor.Blue;
				case (9):
					return ConsoleColor.Magenta;
				case (10):
					return ConsoleColor.Red;
				case (11):
					return ConsoleColor.DarkRed;
				default:
					return ConsoleColor.DarkRed;
			}
		}

		void DrawInvaderAt (Invader ip, ref int invaderMaxLeft, ref int invaderMinLeft)
		{
			if (!invadersMoveRight)
			{
				lock (this)
				{
					Console.MoveBufferArea(0, 0, 3, 1, ip.Position.Left, ip.Position.Top);
					DrawInvader(ip.Position.Left + 1, ip.Position.Top, GetNextColor((ip.Position.Top - 2) / 3));
				}
			}
			else
			{
				lock (this)
				{
					Console.MoveBufferArea(0, 0, 3, 1, ip.Position.Left, ip.Position.Top);
					DrawInvader(ip.Position.Left - 1, ip.Position.Top, GetNextColor((ip.Position.Top - 2) / 3));
				}
			}

			if (invaderMaxLeft < ip.Position.Left)
				invaderMaxLeft = ip.Position.Left;

			if (invaderMinLeft > ip.Position.Left)
				invaderMinLeft = ip.Position.Left;
		}

		void MoveInvadersDown ()
		{
			lock (this)
			{
				// remove any valid entries in the shields
				int temp = liShieldPositions.Count - 1;
				int maxTop = liInvaders[liInvaders.Count - 1].Position.Top + 3;
				for (int i = temp; i >= 0; i--)
				{
					if (maxTop >= liShieldPositions[i].Position.Top)
					{
						Console.SetCursorPosition(liShieldPositions[i].Position.Left, liShieldPositions[i].Position.Top);
						Console.Write(" ");
						liShieldPositions.RemoveAt(i);
					}
				}

				//move the invaders down...
				for (int i = liInvaders.Count - 1; i >= 0; i--)
				{
					ItemPosition ip = liInvaders[i].Position;

					Console.MoveBufferArea(0, 0, 3, 1, ip.Left, ip.Top);
					ip.Top = ip.Top + 3;
					DrawInvader(ip.Left, ip.Top, GetNextColor((ip.Top - 2) / 3));
				}
			}

			if (liInvaders[liInvaders.Count - 1].Position.Top >= currentShipPosition.Top)
			{
				gameOver = GameState.Waiting;
				return;
			}

			invadersMoveRight = !invadersMoveRight;
		}

		void RedrawInvaders ()
		{
			int initCursorLeft = Console.CursorLeft;
			int initCursorTop = Console.CursorTop;
			int tempInvaderMaxLeft = 0;
			int tempInvaderMinLeft = Console.WindowWidth;

			if (!invadersMoveRight)
			{
				if (maxInvaderLeft < Console.WindowWidth - 5)
				{
					foreach (Invader i in liInvaders)
					{
						DrawInvaderAt (i, ref tempInvaderMaxLeft, ref tempInvaderMinLeft);
						i.Position.Left = i.Position.Left + 1;
					}
				}
				else
				{
					MoveInvadersDown ();
				}
			}
			else
			{
				if (minInvaderLeft > 3)
				{
					foreach (Invader ip in liInvaders)
					{
						DrawInvaderAt (ip, ref tempInvaderMaxLeft, ref tempInvaderMinLeft);
						ip.Position.Left = ip.Position.Left - 1;
					}
				}
				else
				{
					MoveInvadersDown ();
				}
			}

			minInvaderLeft = tempInvaderMinLeft;
			maxInvaderLeft = tempInvaderMaxLeft;
		}

		void ShootBullet ()
		{
			// logic is peppered which allows multiple bullets
			// to fire. This code here ensures that in this
			// version, only one does, but we could allow
			// more than 1 in the future
			if (liShipBullets.Count == 1)
			{
				return;
			}

			// beep
			//ItemPosition
			if (!_mute)
			{
				Console.Beep(1300, 15);
				Console.Beep(1300, 15);
				Console.Beep(1280, 15);
				Console.Beep(1260, 15);
			}

			//NativeOverlapped
			Console.BackgroundColor = ConsoleColor.Black;
			if (!demoMode)
			{
				ts.TraceEvent(TraceEventType.Information, (int)GameDetail.ShipFired, "Ship fired, best of luck!");
			}
			lock (this)
			{
				Console.SetCursorPosition(currentShipPosition.Left + 1, currentShipPosition.Top - 1);
			}
			liShipBullets.Add (new ItemPosition (currentShipPosition.Left + 1, currentShipPosition.Top - 1));
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write ("|");
			Console.ForegroundColor = ConsoleColor.White;


			shipBulletTimer.Enabled = true;
		}

		void DrawShip (ShipPosition sp)
		{
			if (sp == ShipPosition.Initial)
			{
				lock (this)
				{
					RedrawShip(Console.WindowWidth / 2 - 1);
					currentShipPosition = new ItemPosition(Console.WindowWidth / 2 - 1, Console.CursorTop);
				}
			}
			else if (sp == ShipPosition.MoveLeft && currentShipPosition.Left > 2)
			{
				if (!demoMode)
				{
					ts.TraceEvent(TraceEventType.Information, (int)GameDetail.ShipMovedLeft, "Moving Left");
				}

				lock (this)
				{
					Console.SetCursorPosition(currentShipPosition.Left, currentShipPosition.Top);
					Console.Write("   ");
					currentShipPosition.Left = currentShipPosition.Left - 1;
					RedrawShip(currentShipPosition.Left);
				}

				ResolveShipDestroyed();
			}
			else if (sp == ShipPosition.MoveRight && currentShipPosition.Left < Console.WindowWidth - 4)
			{
				if (!demoMode)
				{
					ts.TraceEvent(TraceEventType.Information, (int)GameDetail.ShipMovedRight, "Moving Right");
				}

				lock (this)
				{
					Console.SetCursorPosition(currentShipPosition.Left, currentShipPosition.Top);
					Console.Write("   ");
					currentShipPosition.Left = currentShipPosition.Left + 1;
					RedrawShip(currentShipPosition.Left);
				}

				ResolveShipDestroyed();
			}
		}

		void RedrawShip(int left)
		{
			Console.SetCursorPosition(left, Console.WindowHeight - 2);
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("{0}{1}{2}", (char) 9568, (char) 9575, (char) 9571);
		}

		void ScoreUpdate ()
		{
			lock (this)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(10, 0);
				Console.Write(String.Format(CultureInfo.CurrentCulture, "{0:00000}", score));
				if (score > Convert.ToInt32(HighScores[1][1], CultureInfo.InvariantCulture))
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.SetCursorPosition(39, 0);
					Console.Write("{0:00000}", score);
				}
			}
		}

		bool ShootDownInvader (ItemPosition bullet, Invader invader)
		{
			if (bullet.Top == invader.Position.Top && bullet.Left >= invader.Position.Left && bullet.Left < invader.Position.Left + 3)
			{
				// reset timer!
				if (liInvaders.Count == 1)
				{
					invadersReset = true;
					invadersTimer.Interval = initInvaderTime;
				}

				//destroyInvader!
				liShipBullets.Remove (bullet);
				lock (this)
				{
					Console.MoveBufferArea(0, 0, 3, 1, invader.Position.Left, invader.Position.Top);
				}

				int row = ((invader.Position.Top - 2) / 3);
				score += (row + 1) * 5;
				ScoreUpdate ();
				lock (this)
				{
					Console.SetCursorPosition(invader.Position.Left, invader.Position.Top);
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write("{0}{0}{0}", (char)9788);
				}
				invaderExplosion = invader.Position;
				liInvaders.Remove (invader);
				explosionTimer.Enabled = true;

				if (liInvaders.Count == 0)
				{
					Thread.Sleep(1000);
					//while (invaderExploding) { }
					Console.MoveBufferArea(0, 0, 3, 1, invaderExplosion.Left, invaderExplosion.Top);
					lock (this)
					{
						InitializeInvaders(iterationCount);
						DrawShields();
					}
					iterationCount++;
					iterationStartTime = DateTime.Now;
					invadersReset = false;
					movesInvalid = true;
					Thread.Sleep(2000);
					movesInvalid = false;
					return true;
				}

				switch (Convert.ToInt32(invadersTimer.Interval, CultureInfo.InvariantCulture))
				{
					case (initInvaderTime) :
						if (liInvaders.Count < 35)
							invadersTimer.Interval = 700;
						break;
					case (700) :
						if (liInvaders.Count < 28)
							invadersTimer.Interval = 550;
						break;
					case (550):
						if (liInvaders.Count < 20)
							invadersTimer.Interval = 350;
						break;
					case (350):
						if (liInvaders.Count < 10)
							invadersTimer.Interval = 175;
						break;
					case (175):
						if (liInvaders.Count < 5)
							invadersTimer.Interval = 90;
						break;
					case (90):
						if (liInvaders.Count < 3)
							invadersTimer.Interval = 50;
						break;
					case (50):
						if (liInvaders.Count < 2)
							invadersTimer.Interval = 40;
						break;
					default:
						if (liInvaders.Count < 1)
							invadersTimer.Interval = initInvaderTime;
						break;
				}

				return true;
			}

			return false;
		}

		private void ResolveBulletCollisions ()
		{
			for (int i = liShipBullets.Count - 1; i >= 0; i--)
			{
				foreach (ItemPosition ipib in liInvaderBullets)
				{
					if (liShipBullets[i].Left == ipib.Left)
					{
						if (ipib.Top == liShipBullets[i].Top)
						{
							if (!demoMode)
							{
								ts.TraceEvent(TraceEventType.Information, (int)GameDetail.BulletsCollided, "Bullets collided");
							}

							Console.MoveBufferArea(0, 0, 1, 1, liShipBullets[i].Left, liShipBullets[i].Top);
							liInvaderBullets.Remove(ipib);
							liShipBullets.RemoveAt(i);
							break;
						}
					}
				}
			}
		}

		private void InvaderDestroyed ()
		{
			bool invaderShot = false;

			for (int i=0; i < liShipBullets.Count;i++)
			//foreach (ItemPosition ipBullet in liShipBullets)
			{
				foreach (Invader ipInvader in liInvaders)
				{
					invaderShot = ShootDownInvader(liShipBullets[i], ipInvader);
					if (invaderShot)
					{
						if (!demoMode)
						{
							ts.TraceEvent(TraceEventType.Information, (int)GameDetail.ShipBulletHitInvader, "Good shot! Invader destroyed");
							WriteLcdLine("DIRECT HIT!", null);

						}
						if (!_mute)
						{
							Console.Beep(100, 15);
							Console.Beep(120, 15);
							Console.Beep(140, 15);
						}
						break;
					}
				}

				if (!invaderShot)
				{
					if (liShipBullets[i].Top <= 3)
					{
						if (!demoMode)
						{
							ts.TraceEvent(TraceEventType.Information, (int)GameDetail.ShipBulletMissed, "Talk about terrible, you missed them!");
							WriteLcdLine("Missed!", "Practice maybe?");
						}
						lock (this)
						{
							Console.MoveBufferArea(0, 0, 1, 1, liShipBullets[i].Left, liShipBullets[i].Top);
							liShipBullets.RemoveAt(i);
							i--;
						}
					}
					else
					{
						lock (this)
						{
							Console.MoveBufferArea(0, 0, 1, 1, liShipBullets[i].Left, liShipBullets[i].Top);
							liShipBullets[i].Top = liShipBullets[i].Top - 1;
							Console.SetCursorPosition(liShipBullets[i].Left, liShipBullets[i].Top);
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.Write("|");
						}						
					}
				}
			}

			if (liShipBullets.Count == 0)
				shipBulletTimer.Enabled = false;
		}

		void ResolveShipDestroyed ()
		{
			lock (this)
			{
				foreach (ItemPosition ip in liInvaderBullets)
				{
					if (ip.Top == currentShipPosition.Top)
					{
						if (ip.Left >= currentShipPosition.Left && ip.Left <= currentShipPosition.Left + 2)
						{
							if (!demoMode)
							{
								ts.TraceEvent(TraceEventType.Information, (int)GameDetail.InvaderBulletHitShip, "Silly, silly, silly... AVOID the bullets");
								WriteLcdLine("DOH!", "Move, silly!");
							}
							shipBeingDestroyed = true;

							// explode ship!
							shipCount -= 1;

							// draw over the existing bullets
							lock (this)
							{
								foreach (ItemPosition ipi in liInvaderBullets)
								{
									Console.MoveBufferArea(0, 0, 1, 1, ipi.Left, ipi.Top);
								}
							}

							// reset the invader bullets ...
							liInvaderBullets = new List<ItemPosition>();
							invadersBulletTimer.Enabled = false;
							invadersTimer.Enabled = false;
							shipBulletTimer.Enabled = false;
							shipDestroyedTimer.Enabled = true;
						}
					}
				}
			}
		}

		void DisableTimers (bool enable)
		{
			lock (this)
			{
				invadersBulletTimer.Enabled = enable;
				invadersTimer.Enabled = enable;
				shipBulletTimer.Enabled = enable;

				// these timers should never be enabled, except
				// inline as appropriate
				shipDestroyedTimer.Enabled = false;
				explosionTimer.Enabled = false;
			}
		}

		void ResetTimers()
		{
			invadersBulletTimer.Interval = 90;
			invadersTimer.Interval = 850;
			shipBulletTimer.Interval = 70;
			shipDestroyedTimer.Interval = 250;
			explosionTimer.Interval = 35;
		}

		void DisplayGameOver (int preSleep)
		{
			lock (this)
			{
				if (gameOver == GameState.Waiting)
				{
					if (!demoMode)
					{
						gameOver = GameState.Over;
						Reset();
						if (preSleep > 0)
							Thread.Sleep(preSleep);

						Console.Clear();
						ScoreUpdate();
						WriteScore(score);
						Console.Clear();
						DrawLetters(22, (Console.WindowHeight / 2) - 13, 8, 350, false, new string[] { "G", "A", "M", "E" });
						DrawLetters(22, (Console.WindowHeight / 2) - 3, 8, 350, false, new string[] { "O", "V", "E", "R" });
						DisplayGameStatistics();
						score = 0;
						Thread.Sleep(10000);
					}
					score = 0;
					gameOver = GameState.Waiting;
					gettingName = false;
				}
			}
		}

		private void DisplayGameStatistics()
		{
			lock (this)
			{
				try
				{
					ts.Flush();
				}
				finally
				{
					ts.Listeners["gamestats"].Close();
					ts.Listeners.Remove("gamestats");
					ts.Listeners["gamedemo"].Close();
					ts.Listeners.Remove("gamedemo");
				}

				try
				{
					string[] data = File.ReadAllLines("gamestats.log");
					GameData gd = new GameData();

					int startValue = 0;

					for (int i = data.Length - 1; i >= 0; i--)
					{
						string[] vals = data[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

						if (Convert.ToInt32(vals[2], CultureInfo.InvariantCulture) == 8)
						{
							startValue = i;
							break;
						}
					}

					for (int i = startValue; i < data.Length; i++)
					{
						string[] vals = data[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
						long itemKey = Convert.ToInt64(vals[4], CultureInfo.InvariantCulture);

						while (true)
						{
							if (gd.Events.ContainsKey(itemKey))
							{
								itemKey++;
							}
							else
							{
								break;
							}
						}

						gd.Events.Add(itemKey, new GameEvent(vals[1], vals[2], vals[3], itemKey));
					}

					int totalShipShotsFired = 0;
					int totalShipShotsHitInvaders = 0;
					int totalShipShotsHitShield = 0;
					int totalShipMoves = 0;

					foreach (GameEvent ge in gd.Events.Values)
					{
						if (ge.GameDetail == GameDetail.ShipFired)
							totalShipShotsFired++;

						if (ge.GameDetail == GameDetail.ShipBulletHitInvader)
							totalShipShotsHitInvaders++;

						if (ge.GameDetail == GameDetail.ShipBulletHitShield)
							totalShipShotsHitShield++;

						if (ge.GameDetail == GameDetail.ShipMovedLeft || ge.GameDetail == GameDetail.ShipMovedRight)
							totalShipMoves++;
					}
					lock (this)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.SetCursorPosition(30, 24);
						Console.Write("Game  Statistics");
						Console.ForegroundColor = ConsoleColor.Red;
						Console.SetCursorPosition(17, 25);
						Console.Write("------------------------------------------");
						Console.SetCursorPosition(17, 26);
						Console.Write("-                                        -");
						Console.SetCursorPosition(17, 27);
						Console.Write("-                                        -");
						Console.SetCursorPosition(17, 28);
						Console.Write("-                                        -");
						Console.SetCursorPosition(17, 29);
						Console.Write("-                                        -");
						Console.SetCursorPosition(17, 30);
						Console.Write("-                                        -");
						Console.SetCursorPosition(17, 31);
						Console.Write("-                                        -");
						Console.SetCursorPosition(17, 32);
						Console.Write("------------------------------------------");
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.SetCursorPosition(19, 26);
						Console.Write("{0,-30}{1}", "Total Ship Moves", totalShipMoves);
						Console.SetCursorPosition(19, 28);
						Console.Write("{0,-30}{1}", "Total Shots Fired", totalShipShotsFired);
						Console.SetCursorPosition(19, 29);
						Console.Write("{0,-30}{1}", "Invaders Destroyed", totalShipShotsHitInvaders);
						Console.SetCursorPosition(19, 30);
						Console.Write("{0,-30}{1:p}", "Accuracy", Convert.ToDouble(totalShipShotsHitInvaders, CultureInfo.InvariantCulture) / Convert.ToDouble(totalShipShotsFired, CultureInfo.InvariantCulture));
						Console.SetCursorPosition(19, 31);
						Console.Write("{0,-30}{1:0.00}", "Average score per alien", Convert.ToDouble(score, CultureInfo.InvariantCulture) / Convert.ToDouble(totalShipShotsHitInvaders, CultureInfo.InvariantCulture));
					}
				}
				catch (IndexOutOfRangeException)
				{
					// writing out the stats for the game is non-critical to the game. If
					// we don't succeed at it, then don't panic. It will in all likelihood be due
					// to some kind of error getting the information out of the gamestats
					// file, and this shouldn't cause the game to crash

					// IndexOutOfRange is caused because the log file is not correctly formed,
					// and the expected entry (because the file is split on semicolons) was not found
				}
			}
		}

		// Specify what you want to happen when the event is raised.
		private void OnBulletTimedEvent (object source, ElapsedEventArgs e)
		{
			lock (this)
			{
				if (!movesInvalid)
				{
					if (liShipBullets.Count == 0)
					{
						shipBulletTimer.Enabled = false;
						return;
					}

					ResolveBulletCollisions();
					ResolveShieldCollisions();
					InvaderDestroyed();
				}
			}
		}

		private void OnInvadersTimedEvent (object source, ElapsedEventArgs e)
		{
			if (!invadersReset)
			{
				if (e.SignalTime >= iterationStartTime)
				{
					lock (this)
					{
						if (!movesInvalid)
						{
							if (!_mute)
							{
								if (invadersBulletTimer.Interval <= 90)
								{
									if (invadersBulletTimer.Interval <= 50)
									{
										Console.Beep(40, 5);
									}
									else
									{
										Console.Beep(40, 15);
									}
								}
								else
								{
									Console.Beep(40, 30);
								}
							}
							RedrawInvaders();
							InvaderDestroyed();
						}
					}
				}
			}
		}

		private void OnShipDestroyed (object source, ElapsedEventArgs e)
		{
			lock (this)
			{
				if (shipExplosionState < 4)
				{
					lock (this)
					{
						if (!_mute)
						{
							Console.Beep(50, 30);
							Console.Beep(46, 30);
							Console.Beep(42, 30);
							Console.Beep(46, 30);
						}
						Console.SetCursorPosition(currentShipPosition.Left, currentShipPosition.Top);

						if (shipExplosionState == 0)
							Console.ForegroundColor = ConsoleColor.DarkYellow;
						else if (shipExplosionState == 1)
							Console.ForegroundColor = ConsoleColor.Yellow;
						else if (shipExplosionState == 2)
							Console.ForegroundColor = ConsoleColor.Green;
						else if (shipExplosionState == 3)
							Console.ForegroundColor = ConsoleColor.Red;

						Console.Write("{0}{0}{0}", (char)9788);
					}
					shipExplosionState++;
				}
				else
				{
					if (shipCount == 0)
					{
						gameOver = GameState.Waiting;
						return;
					}
					shipDestroyedTimer.Enabled = false;
					Console.SetCursorPosition(currentShipPosition.Left, currentShipPosition.Top);
					Thread.Sleep(1500);
					Console.Write("   ");
					Thread.Sleep(1500);
					shipExplosionState = 0;
					DrawShip(ShipPosition.Initial);
					DrawReserveShips();

					invadersBulletTimer.Enabled = true;
					invadersTimer.Enabled = true;
					shipBulletTimer.Enabled = true;
					shipBeingDestroyed = false;
				}
			}
		}

		private void OnInvadersExplosion (object source, ElapsedEventArgs e)
		{
			lock (this)
			{
				if (invaderExplosion != null)
				{
					if (invaderExplosionState < 2)
					{
						Console.SetCursorPosition(invaderExplosion.Left, invaderExplosion.Top);
						if (invaderExplosionState == 0)
							Console.ForegroundColor = ConsoleColor.DarkYellow;
						else
							Console.ForegroundColor = ConsoleColor.Yellow;

						Console.Write("{0}{0}{0}", (char)9788);
						invaderExplosionState++;
					}
					else
					{
						invaderExplosionState = 0;
						Console.MoveBufferArea(0, 0, 3, 1, invaderExplosion.Left, invaderExplosion.Top);
						invaderExplosion = null;
						explosionTimer.Enabled = false;
					}
				}
			}
		}

		private void OnInvadersBulletTimedEvent (object source, ElapsedEventArgs e)
		{
			if (e.SignalTime >= iterationStartTime)
			{
				lock (this)
				{
					if (!movesInvalid)
					{
						ResolveBulletCollisions();
						ResolveShieldCollisions();
						for (int i = 0; i < liInvaderBullets.Count; i++)
						{
							if (liInvaderBullets[i].Top >= Console.WindowHeight - 2)
							{
								if (!demoMode)
								{
									ts.TraceEvent(TraceEventType.Information, (int)GameDetail.InvaderBulletMissed, "Invader bullet missed");
								}

								Console.MoveBufferArea(0, 0, 1, 1, liInvaderBullets[i].Left, liInvaderBullets[i].Top);
								liInvaderBullets.RemoveAt(i);
								i--;
							}
							else
							{
								Console.MoveBufferArea(0, 0, 1, 1, liInvaderBullets[i].Left, liInvaderBullets[i].Top);
								liInvaderBullets[i].Top = liInvaderBullets[i].Top + 1;
								Console.SetCursorPosition(liInvaderBullets[i].Left, liInvaderBullets[i].Top);
								Console.ForegroundColor = ConsoleColor.White;
								Console.Write((char)9553);
							}
						}

						if (!demoMode)
						{
							GenerateInvaderBullet();
						}

						ResolveShipDestroyed();
					}
				}
			}
		}

		private void OnHighScoreTimedEvent(object source, ElapsedEventArgs e)
		{
			StartScreen();
			HighScoreTimer.Enabled = false;
		}

		private void OnSerialLcdClearedEvent(object source, ElapsedEventArgs e)
		{
			lcd.WriteLine1("");
			lcd.WriteLine2("");
			clearLcdScreen.Enabled = false;
		}

		private void OnSerialKeysEvent(object source, ElapsedEventArgs e)
		{
			switch (lcd.Key)
			{
				case LcdKey.Up :
					// do nothing
					break;

				case LcdKey.Down :
					// do nothing
					break;

				case LcdKey.Left :
					// move left!
					if (!shipBeingDestroyed)
					{
						lock (this)
						{
							DrawShip(ShipPosition.MoveLeft);
						}
					}
					break;

				case LcdKey.Right :
					//move right!
					if (!shipBeingDestroyed)
					{
						lock (this)
						{
							DrawShip(ShipPosition.MoveRight);

						}
					}
					break;

				case LcdKey.Enter :
					// fire a bullet!
					if (!shipBeingDestroyed)
					{
						lock (this)
						{
							ShootBullet();
						}
					}
					lcd.Key = LcdKey.None;
					break;
				case LcdKey.Exit :
					Console.Clear();
					DisableTimers(false);
					ClearLists();
					if (!demoMode)
					{
						ts.TraceEvent(TraceEventType.Information, (int)GameDetail.GameEnded, "Game Ended");
						WriteLcdLine("Game Ended", null);
					}
					Environment.Exit(0);
					return;
				default:
					break;
			}			
		}
	}
}