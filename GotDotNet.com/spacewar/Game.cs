using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for Game.
	/// </summary>
	public class Game
	{
		KeyboardState	keyboardState;
		Ship			ship;
		Hashtable		otherPlayers = new Hashtable();
		Hashtable		wordCache = new Hashtable();
		Rectangle		windowBounds;						// bounds of our window...
		NetAcceptor		acceptor;
		Thread			netDataThread;
		Point			sunLocation = new Point(0, 0);
		int				buffersRead = 0;
		DirectDrawSurface7 surface;
		DirectSound		sound;
		public int[] shipColors = new int[] {0xFF00FF, 0xFFFF00, 0x00FFFF,
											 0xFF0000, 0x00FF00, 0x0000FF};
		SoundHandler soundHandler;
		byte[] sendBuffer = new byte[Constants.NetworkBufferSize];
		Stars			stars;
		Sun				sun;

		public Game()
		{
			keyboardState = new KeyboardState();
			
			keyboardState.Add(Keys.Z, GameKeys.Z);
			keyboardState.Add(Keys.X, GameKeys.X);
			keyboardState.Add(Keys.OemPeriod, GameKeys.Period);
			keyboardState.Add(Keys.OemQuestion, GameKeys.Question);
			keyboardState.Add(Keys.Escape, GameKeys.Escape, true);		// make escape sticky...
			keyboardState.Add(Keys.Space, GameKeys.Space);
			keyboardState.Add(Keys.F1, GameKeys.F1, true);
			keyboardState.Add(Keys.F5, GameKeys.F5, true);
			keyboardState.Add(Keys.F6, GameKeys.F6);
			keyboardState.Add(Keys.F7, GameKeys.F7);
			keyboardState.Add(Keys.F8, GameKeys.F8);
			keyboardState.Add(Keys.F9, GameKeys.F9);
			keyboardState.Add(Keys.F10, GameKeys.F10);

			RotatableShape.CreateShapes();

				// Set up the network acceptor;

			acceptor = new NetAcceptor(50000, new NetAcceptor.DataReadyHandler(RemoteDataHandler));
			ThreadStart threadStart = new ThreadStart(acceptor.AcceptLoop);
			netDataThread = new Thread(threadStart);
			netDataThread.Start();
			
		}

		public void Initialize(Rectangle bounds, 
			DirectDrawSurface7 surface,
			DirectSound sound)
		{
			this.windowBounds = bounds;
			this.surface = surface;
			this.sound = sound;

			if (soundHandler == null && sound != null)
			{
				soundHandler = new SoundHandler(sound);
			}

			sunLocation.X = windowBounds.Left + windowBounds.Width / 2;
			sunLocation.Y = windowBounds.Top + windowBounds.Height / 2;

			ship = new Ship(sunLocation);
			Random random = new Random((int) DateTime.Now.Ticks);
			ship.ScreenBounds = bounds;
			ship.SetRandomPosition(true);
			//ship.Position = new Vector(size.Width * 0.8f, size.Height / 2.0f);
			ship.HostName = System.Environment.MachineName;

			stars = new Stars(bounds, Constants.NumStars);
			sun = new Sun(sunLocation, Constants.SunSize);
		}

		public void Close()
		{
			acceptor.Close();
			netDataThread.Interrupt();
		}

		public KeyboardState KeyboardState
		{
			get
			{
				return keyboardState;
			}
		}

		public void WriteScores()
		{
			Point location = new Point(Constants.ScoreXOrigin + windowBounds.X, 
									   Constants.ScoreYOrigin + windowBounds.Y);
			Point scoreLocation = location;
			scoreLocation.X += Constants.ScoreOffest;

			ship.DrawHostName(surface, location, 0xFFFFFF);	// this ship is white...

			Word word = GetWordFromScore(ship.Score.ToString());
			int color = 0xFFFFFF;
			word.Draw(surface, color, Constants.LetterSpacing, scoreLocation);

			int shipIndex = 0;
			lock (otherPlayers)
			{
				foreach (RemotePlayer player in otherPlayers.Values)
				{
					if (!player.Active)
						continue;

					location.Y += Constants.ScoreVerticalSpacing;
					scoreLocation.Y += Constants.ScoreVerticalSpacing;
					player.Ship.DrawHostName(surface, location, shipColors[shipIndex]);
					word = GetWordFromScore(player.Ship.Score.ToString());
					word.Draw(surface, shipColors[shipIndex], Constants.LetterSpacing, scoreLocation);

					shipIndex = (shipIndex + 1) % shipColors.Length;
				}
			}
		}

		Word GetWordFromScore(string score)
		{
			Word word;

			word = (Word) wordCache[score];
			if (word != null)
				return word;

			word = new Word(score, Constants.LetterSize);
			wordCache.Add(score, word);
			return word;
		}

		public Ship CreateNewShip(string hostName)
		{
			Ship newShip;
			newShip = new Ship(sunLocation);
			newShip.ScreenBounds = windowBounds;
			newShip.HostName = hostName;
			return newShip;
		}
		
		public void MakeRemoteConnection(string hostName)
		{
				// Create a new player connection...
			hostName = hostName.ToUpper();
			Ship newShip = CreateNewShip(hostName);
			RemotePlayer player = new RemotePlayer(hostName, newShip);
			player.UpdateTime = DateTime.Now;
			player.DoRemoteConnection();

			lock (otherPlayers)
			{
				otherPlayers.Add(hostName, player);
			}
		}

			// Remote Data Handler
			//
			// Other players join the game simply by sending us an informational buffer
			// If there's a player that we don't have in our list, we'll add them
			// to our list of players.
			// To allow a single join to join all current players, we make sure that the
			// next buffer we get from current players gets sent to the new player, and
			// that will hook everything up...
		public unsafe void RemoteDataHandler(object sender, GameDataEventArgs args)
		{
			byte[] buffer = (byte[]) args.GameData;

			fixed (byte* pBuffer = buffer)
			{
				PtrHolder ptr = new PtrHolder(pBuffer);
				int scoreToMe = ptr.ReadInt();				// score value from other player
				string hostName = ptr.ReadString();
				buffersRead++;
				if (buffersRead % 100 == 0)
					Console.WriteLine("Read: {0}", buffersRead);

				//Console.WriteLine("{0}", buffer.Length);

				lock (otherPlayers)
				{
					RemotePlayer player = (RemotePlayer) otherPlayers[hostName];

					if (player == null)
					{
							// mark each existing player so we'll send the next
							// buffer to the next player...
						foreach (RemotePlayer currentPlayer in otherPlayers)
						{
							currentPlayer.ReflectToPlayer = hostName;
						}
						
						Console.Write("New Data from: {0} {1} bytes\r", hostName, buffer.Length);
						Ship newShip = CreateNewShip(hostName);
						newShip.FromPointer(ptr);

						player = new RemotePlayer(hostName, newShip);
						otherPlayers.Add(hostName, player);
						player.DoRemoteConnection();
					}
					else
					{
							// if we're reflecting, take this buffer and send it to 
							// the appropriate player...
						if (player.ReflectToPlayer != null)
						{
							RemotePlayer newPlayer = (RemotePlayer) otherPlayers[player.ReflectToPlayer];
							newPlayer.Send(buffer, buffer.Length);
							player.ReflectToPlayer = null;
						}
						player.Ship.FromPointer(ptr);
						player.ScoreToMe = scoreToMe;
					}
					player.UpdateTime = DateTime.Now;
					player.Active = true;
				}
			}
		}

		unsafe public void SendData()
		{
				// Convert the current state to a buffer...
			int length;
			fixed (byte* pBuffer = sendBuffer)
			{
				PtrHolder ptr = new PtrHolder(pBuffer);
				ptr.WriteInt(0);		// placeholder for score! Don't remove
				ptr.WriteString(ship.HostName);
				ship.ToPointer(ptr);
				length = (int) ((byte*) ptr.Ptr - pBuffer);

					// send this buffer to each client. 
					// we fill in their specific score specially...
				int score = 0;
				int* pScore = (int*) pBuffer;
				lock (otherPlayers)
				{
					foreach (RemotePlayer player in otherPlayers.Values)
					{
						if (!player.Active)
							continue;

						*pScore = player.ScoreToOther;	// save score at start of buffer...
						player.Send(sendBuffer, length);
						score += player.ScoreToMe;
					}
				}
				ship.Score = score;		
			}
		}

		void PlaySounds(Sounds otherShipSounds)
		{
			if (soundHandler != null)
			{
				Sounds soundsToPlay = ship.Sounds;

				if ((otherShipSounds & Sounds.ShipExplode) != 0)
					soundsToPlay |= Sounds.OtherShipExplode;

				if ((otherShipSounds & Sounds.ShipFire) != 0)
					soundsToPlay |= Sounds.OtherShipFire;

				if ((otherShipSounds & Sounds.ShipThrust) != 0)
					soundsToPlay |= Sounds.OtherShipThrust;

				if ((otherShipSounds & Sounds.ShipAppear) != 0)
					soundsToPlay |= Sounds.OtherShipAppear;

				Sounds directMap =
					Sounds.ShipHyper |
					Sounds.Taunt |
					Sounds.Dude1 |
					Sounds.Dude2 |
					Sounds.Dude3 |
					Sounds.Dude4 |
					Sounds.Dude5;

				Sounds soundsToCopy = otherShipSounds & directMap;

				soundsToPlay |= soundsToCopy;

				soundHandler.Play(soundsToPlay);
			}
		}

		void HandleKeys()
		{
			GameKeys gameKeyState = keyboardState.CurrentState;

			if ((gameKeyState & GameKeys.Z) != 0)
				ship.RotateLeft();
			if ((gameKeyState & GameKeys.X) != 0)
				ship.RotateRight();
			
			ship.SetThrust((gameKeyState & GameKeys.Period) != 0);

			if ((gameKeyState & GameKeys.Question) != 0)
				ship.Shoot();

			if ((gameKeyState & GameKeys.Space) != 0)
				ship.EnterHyper();

			if ((gameKeyState & GameKeys.F5) != 0)
			{
				ship.Sounds |= Sounds.Taunt;
				keyboardState.Clear(GameKeys.F5);
			}

			if ((gameKeyState & GameKeys.F6) != 0)
			{
				ship.Sounds |= Sounds.Dude1;
				keyboardState.Clear(GameKeys.F6);
			}

			if ((gameKeyState & GameKeys.F7) != 0)
			{
				ship.Sounds |= Sounds.Dude2;
				keyboardState.Clear(GameKeys.F7);
			}

			if ((gameKeyState & GameKeys.F8) != 0)
			{
				ship.Sounds |= Sounds.Dude3;
				keyboardState.Clear(GameKeys.F8);
			}

			if ((gameKeyState & GameKeys.F9) != 0)
			{
				ship.Sounds |= Sounds.Dude4;
				keyboardState.Clear(GameKeys.F9);
			}

			if ((gameKeyState & GameKeys.F10) != 0)
			{
				ship.Sounds |= Sounds.Dude5;
				keyboardState.Clear(GameKeys.F10);
			}
		}

		unsafe public void MainLoop()
		{
			ship.Sounds = (Sounds) 0;

			HandleKeys();

			// update my position, and tell others about it...
			ship.UpdatePosition();

			// update my state, and draw myself...
			int scoreForOtherPlayers = 0;
			ship.UpdateState(ref scoreForOtherPlayers);

			SendData();

			WriteScores();
			stars.Draw(surface);

			int shipColor = 0xFFFFFF;
			int shotColor = 0xFFFFFF;
			ship.Draw(surface, shipColor, shotColor);

				// Handle other ships
				// walk through all other players. For each player
				// 1) draw the ship
				// 2) check to see whether the other ship has killed us
				// 3) figure the score
				// 4) see if we need to time-out this ship
			int shipIndex = 0;
			Sounds otherShipSounds = (Sounds) 0;
			DateTime now = DateTime.Now;
			lock (otherPlayers)
			{
				foreach (RemotePlayer player in otherPlayers.Values)
				{
					if (!player.Active)
						continue;

					player.Ship.Draw(surface, shipColors[shipIndex], shotColor);
					shipIndex = (shipIndex + 1) % shipColors.Length;
					ship.TestShip(player);
					player.ScoreToOther += scoreForOtherPlayers;
					otherShipSounds |= player.Ship.Sounds;

						// if we haven't gotten an update in a while,
						// mark the player as inactive...
					TimeSpan delta = now - player.UpdateTime;
					if (delta.Seconds > Constants.RemoteTickTimeout)
					{
						player.Active = false;
					}
				}
			}

			sun.Draw(surface);

			PlaySounds(otherShipSounds);
		}
	}
}
