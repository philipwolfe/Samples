using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Resources;

namespace csSnakeGame
{
	/// <summary>
	/// Summary description for frmSnake.
	/// </summary>
	public class frmSnake : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private bool mbGameOn = false;
		private bool mbGameInit = false;
		private clsSnake mcSnake;
		const int MOVE_INTERVAL = 300;
		const int GRID_WIDTH = 12;
		const int GRID_HEIGHT = 12;
		const int START_SNAKE_LENGTH = 6;
		private System.Windows.Forms.Button cmdNewGame;
		private System.Windows.Forms.Label lblScoreCaption;
		private System.Windows.Forms.Timer tmrSnake;
		private System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.PictureBox picMain;
		private System.Windows.Forms.PictureBox picFly;
		//private string crlf = "\r\n";
		
		public frmSnake()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//TODO: Add any initialization after the InitializeComponent() call
			this.picMain.BackColor = Color.FromArgb(255, 255, 225);
			this.picFly.BackColor = Color.FromArgb(255, 255, 225);

			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSnake_KeyPress);
			this.Resize += new System.EventHandler(this.frmSnake_Resize);
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblScore = new System.Windows.Forms.Label();
			this.cmdNewGame = new System.Windows.Forms.Button();
			this.picMain = new System.Windows.Forms.PictureBox();
			this.lblScoreCaption = new System.Windows.Forms.Label();
			this.tmrSnake = new System.Windows.Forms.Timer(this.components);
			this.picFly = new System.Windows.Forms.PictureBox();
			this.lblScore.BackColor = System.Drawing.SystemColors.Highlight;
			this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblScore.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblScore.Location = new System.Drawing.Point(56, 4);
			this.lblScore.Size = new System.Drawing.Size(36, 20);
			this.lblScore.TabIndex = 4;
			this.lblScore.Text = "0";
			this.cmdNewGame.Location = new System.Drawing.Point(96, 0);
			this.cmdNewGame.Size = new System.Drawing.Size(84, 24);
			this.cmdNewGame.TabIndex = 6;
			this.cmdNewGame.Text = "New Game";
			this.cmdNewGame.Click += new System.EventHandler(this.cmdNewGame_Click);
			this.picMain.BackColor = System.Drawing.SystemColors.Control;
			this.picMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picMain.Location = new System.Drawing.Point(4, 24);
			this.picMain.Size = new System.Drawing.Size(324, 360);
			this.picMain.TabIndex = 0;
			this.picMain.TabStop = false;
			this.lblScoreCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.lblScoreCaption.Location = new System.Drawing.Point(4, 8);
			this.lblScoreCaption.Size = new System.Drawing.Size(51, 16);
			this.lblScoreCaption.TabIndex = 5;
			this.lblScoreCaption.Text = "Score:";
			this.tmrSnake.Tick += new System.EventHandler(this.tmrSnake_Tick);
			this.picFly.Location = new System.Drawing.Point(336, -8);
			this.picFly.Size = new System.Drawing.Size(42, 42);
			this.picFly.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picFly.TabIndex = 7;
			this.picFly.TabStop = false;
			this.picFly.Visible = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 469);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.picFly,
																		  this.lblScore,
																		  this.cmdNewGame,
																		  this.lblScoreCaption,
																		  this.picMain});
			this.KeyPreview = true;
			this.Text = "C# Snake Game";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSnake_KeyPress);
			this.Load += new System.EventHandler(this.frmSnake_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmSnake());
		}

		private void cmdNewGame_Click(object sender, System.EventArgs e)
		{
			this.lblScore.Text = "0";
			string sCRLF = "\r\n";
			string sMsg;
			sMsg = "The goal is to eat as many flys as you can without crashing into yourself or the wall." + sCRLF;
			sMsg = sMsg + "Each time you eat a fly, your tail will grow by one square." + sCRLF;
			sMsg = sMsg + "Your direction can be changed using the number pad numbers 8,4,6, and 2." + sCRLF;
			sMsg = sMsg + "After this box closes hit one of the number keys to begin.  You can hit the 5 key to pause.";
			System.Windows.Forms.MessageBox.Show(sMsg, this.Text);
			mcSnake = new clsSnake(GRID_WIDTH, GRID_HEIGHT, START_SNAKE_LENGTH, this.picMain, this.picFly);

			mbGameOn = true;
			mcSnake.PaintSnake();
			this.tmrSnake.Enabled = true;
		}

		private void frmSnake_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			bool bGotMove=false;
			if (mbGameOn == false) return;
		
			switch (Convert.ToString(e.KeyChar))
			{
				case "8":
					mcSnake.addMove(0,-1);
					bGotMove = true;
					break;
				case "2":
					mcSnake.addMove(0,1);
					bGotMove = true;
					break;
				case "4":
					mcSnake.addMove(-1,0);
					bGotMove = true;
					break;
				case "6":
					mcSnake.addMove(1,0);
					bGotMove = true;
					break;
				case "5":
					//Freeze the game
					mbGameInit = false;
					break;
				case "32":
					//Freeze the game
					mbGameInit = false;
					break;
			}

			if (bGotMove)
			{
				if (mbGameInit == false && Convert.ToString(e.KeyChar) != "5" && Convert.ToString(e.KeyChar) != "32")
				{
					mbGameInit = true;
					tmrSnake.Interval = MOVE_INTERVAL;
					tmrSnake.Enabled = true;
				}
			}
		}

		private void frmSnake_Resize(object sender, System.EventArgs e)
		{
			this.picMain.Top = this.lblScore.Height + this.lblScore.Top + 4;
			this.picMain.Left = 4;
			this.picMain.Width = this.ClientRectangle.Width - this.picMain.Left * 2;
			this.picMain.Height = this.ClientRectangle.Height - this.picMain.Top - 4;
		}

		private void tmrSnake_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (mbGameInit == false) return;

				mcSnake.applyNextMove();
				this.lblScore.Text = mcSnake.Score().ToString();
				if (mcSnake.GameOver())
				{
					tmrSnake.Enabled = false;
					System.Windows.Forms.MessageBox.Show("Game Over");
				}
			}
			catch (Exception oErr)
			{
			}
			finally
			{
			}

		}

		private void frmSnake_Load(object sender, System.EventArgs e)
		{

		}
	
	}
}
