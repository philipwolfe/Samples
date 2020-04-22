using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CodeRunner
{
	public class GameWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer GameLoop;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem mnuHelpAbout;
		private System.Windows.Forms.MenuItem mnuOpenPuzzle;
		private System.Windows.Forms.MenuItem mnuNextLevel;
		private System.Windows.Forms.MenuItem mnuPreviousLevel;
		private System.Windows.Forms.MenuItem mnuFileExit;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mnuGotoLevel;
		private System.Windows.Forms.MenuItem mnuRestart;
		private System.ComponentModel.IContainer components;
		
		#region VS.Net Generated Code


		public GameWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			InitializeGame(1);
			InitializeWindow();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GameWindow));
			this.GameLoop = new System.Windows.Forms.Timer(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuOpenPuzzle = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.mnuFileExit = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.mnuNextLevel = new System.Windows.Forms.MenuItem();
			this.mnuPreviousLevel = new System.Windows.Forms.MenuItem();
			this.mnuRestart = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuGotoLevel = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
			// 
			// GameLoop
			// 
			this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem8,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuOpenPuzzle,
																					  this.menuItem11,
																					  this.mnuFileExit});
			this.menuItem1.Text = "&File";
			// 
			// mnuOpenPuzzle
			// 
			this.mnuOpenPuzzle.Index = 0;
			this.mnuOpenPuzzle.Text = "Open &Puzzle File...";
			this.mnuOpenPuzzle.Click += new System.EventHandler(this.mnuOpenPuzzle_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 1;
			this.menuItem11.Text = "-";
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Index = 2;
			this.mnuFileExit.Text = "E&xit";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuNextLevel,
																					  this.mnuPreviousLevel,
																					  this.mnuRestart,
																					  this.menuItem4,
																					  this.mnuGotoLevel});
			this.menuItem8.Text = "&Level";
			// 
			// mnuNextLevel
			// 
			this.mnuNextLevel.Index = 0;
			this.mnuNextLevel.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.mnuNextLevel.Text = "&Next Level";
			this.mnuNextLevel.Click += new System.EventHandler(this.mnuNextLevel_Click);
			// 
			// mnuPreviousLevel
			// 
			this.mnuPreviousLevel.Index = 1;
			this.mnuPreviousLevel.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.mnuPreviousLevel.Text = "&Previous Level";
			this.mnuPreviousLevel.Click += new System.EventHandler(this.mnuPreviousLevel_Click);
			// 
			// mnuRestart
			// 
			this.mnuRestart.Index = 2;
			this.mnuRestart.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.mnuRestart.Text = "&Restart Level";
			this.mnuRestart.Click += new System.EventHandler(this.mnuRestart_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "-";
			// 
			// mnuGotoLevel
			// 
			this.mnuGotoLevel.Index = 4;
			this.mnuGotoLevel.Text = "&Goto Level";
			this.mnuGotoLevel.Click += new System.EventHandler(this.mnuGotoLevel_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuHelpAbout});
			this.menuItem2.Text = "&Help";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Index = 0;
			this.mnuHelpAbout.Text = "&About Code Runner...";
			// 
			// GameWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(580, 341);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "GameWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lode Runner";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameWindow_Paint);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new GameWindow());
		}
		#endregion

		void InitializeGame(int nLevel)
		{
			Game.GameState = GameState.Paused;
			m_nCurLevel = nLevel;

			// initialize level 1
			Game.ClearAll();
			Game.InitializeLevel(m_nCurLevel);
			Pause();

			// initialize render
			m_objRenderer = new Renderer( this );
			m_objRenderer.Initialize();
		}
		
		void InitializeWindow()
		{
			System.Drawing.Size sizForm = new System.Drawing.Size();
			sizForm.Width = (Constants.BOARD_WIDTH * Constants.TILE_WIDTH) + (Constants.LEFT_OFFSET * 2);
			sizForm.Height = (Constants.BOARD_HEIGHT * Constants.TILE_HEIGHT) + (Constants.TOP_OFFSET * 2);
			this.ClientSize = sizForm;

			// Initialize the window so that all drawing happens in WM_PAINT
			// and so that we use double buffering
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
		}
		

		private void GameLoop_Tick(object sender, System.EventArgs e)
		{
			if (!DoIteration())
			{
				if (Game.GameState==GameState.Won)
				{
					Sound.PlayVictory();
					if (m_nCurLevel<Game.Level.GetLevelCount())
						InitializeGame(m_nCurLevel+1);
					else
						InitializeGame(1);
				}
				else
				{
					Sound.PlayDeath();
					InitializeGame(m_nCurLevel);
				}
			}
		}

		private bool DoIteration()
		{	
			// if we are not paused, then kick it!!
			if (Game.GameState!=GameState.Paused)
			{
				if (!Game.IterateFrame())
					return false;

				// repaint the modified areas
//				if (Game.FullRefresh)
//					m_objRenderer.ShowEscape(this);

				this.Invalidate();
			}

			return true;
		}

		private void GameWindow_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// draw the current screen
			m_objRenderer.Paint(e);	
		}

		private void GameWindow_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Game.GameState==GameState.Paused)
				UnPause();
			else if (e.KeyCode==Keys.P)
			{
				Pause();
				return;
			}

			Game.HandleKeypress(e);
		}

		private void Pause()
		{
			GameLoop.Enabled = false;

			this.Text = "Lode Runner (Paused)";
			Game.GameState = GameState.Paused;
		}

		private void UnPause()
		{
			Game.GameState = GameState.Running;
			this.Text = "Lode Runner - Level " + Game.Level.LevelNumber.ToString();

			GameLoop.Interval=Constants.TIMER_INTERVAL;
			GameLoop.Enabled = true;
		}

		// menu handlers
		private void mnuFileExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnuNextLevel_Click(object sender, System.EventArgs e)
		{
			if (m_nCurLevel<Game.Level.GetLevelCount())
				InitializeGame(m_nCurLevel+1);
		}

		private void mnuRestart_Click(object sender, System.EventArgs e)
		{
			InitializeGame(m_nCurLevel);
		}

		private void mnuPreviousLevel_Click(object sender, System.EventArgs e)
		{
			if (m_nCurLevel>1)
				InitializeGame(m_nCurLevel-1);
		}

		private void mnuGotoLevel_Click(object sender, System.EventArgs e)
		{
			Pause();

			GoToLevel frmGoto = new GoToLevel();
			frmGoto.LevelNum = m_nCurLevel;

			frmGoto.ShowDialog(this);

			if (frmGoto.LevelNum>0)
			{
				InitializeGame(frmGoto.LevelNum);				
			}
		}

		private void mnuOpenPuzzle_Click(object sender, System.EventArgs e)
		{
			Pause();

			System.Windows.Forms.OpenFileDialog openDlg = new System.Windows.Forms.OpenFileDialog();
			openDlg.InitialDirectory = Constants.APP_DIR + @"Levels\";
			openDlg.CheckFileExists = true;
			openDlg.Filter = "Puzzle Files (*.pzl)|*.pzl";
			openDlg.FilterIndex = 1;
			openDlg.Multiselect = false;
			if (openDlg.ShowDialog(this)==DialogResult.OK)
			{
				Game.Level.SetLevelFile(openDlg.FileName);
				InitializeGame(1);
			}
		}

		// internal state variables
		private Renderer m_objRenderer;
		private int m_nCurLevel;
	}
}
