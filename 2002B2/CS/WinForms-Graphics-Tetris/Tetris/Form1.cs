using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Tetris.NET
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label GameOver;
		private System.Windows.Forms.PictureBox PlayArea;
		private System.Windows.Forms.Label txtPaused;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Button cmdStart;
		private System.Windows.Forms.Label txtLines;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Button cmdPause;
		private System.Windows.Forms.Timer Timer1;
		private System.Windows.Forms.Label txtScore;
		private System.ComponentModel.IContainer components;

		private Block CurrentBlock;
		private int[,] InternalPlayArea = new int[11, 18];
		private bool JustLocked = false;
		private int intScore = 0;
		private int intLines = 0;
		private bool bPaused = false;
		private int intLevel = 0;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Game Initialisation
			InitGame();

			//Disable pause button
			cmdPause.Enabled = false;
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
			this.txtLines = new System.Windows.Forms.Label();
			this.GameOver = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.txtScore = new System.Windows.Forms.Label();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.cmdPause = new System.Windows.Forms.Button();
			this.cmdStart = new System.Windows.Forms.Button();
			this.PlayArea = new System.Windows.Forms.PictureBox();
			this.txtPaused = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.GroupBox2.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtLines
			// 
			this.txtLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.txtLines.Location = new System.Drawing.Point(8, 16);
			this.txtLines.Name = "txtLines";
			this.txtLines.Size = new System.Drawing.Size(80, 16);
			this.txtLines.TabIndex = 0;
			this.txtLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GameOver
			// 
			this.GameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.GameOver.ForeColor = System.Drawing.Color.Red;
			this.GameOver.Location = new System.Drawing.Point(8, 216);
			this.GameOver.Name = "GameOver";
			this.GameOver.Size = new System.Drawing.Size(88, 64);
			this.GameOver.TabIndex = 2;
			this.GameOver.Text = "Game Over";
			this.GameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.GameOver.Visible = false;
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtLines});
			this.GroupBox2.Location = new System.Drawing.Point(4, 64);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(96, 40);
			this.GroupBox2.TabIndex = 9;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Lines";
			// 
			// txtScore
			// 
			this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.txtScore.Location = new System.Drawing.Point(8, 16);
			this.txtScore.Name = "txtScore";
			this.txtScore.Size = new System.Drawing.Size(80, 16);
			this.txtScore.TabIndex = 0;
			this.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtScore});
			this.GroupBox1.Location = new System.Drawing.Point(4, 8);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(96, 40);
			this.GroupBox1.TabIndex = 8;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Score";
			// 
			// Timer1
			// 
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// cmdPause
			// 
			this.cmdPause.Location = new System.Drawing.Point(8, 336);
			this.cmdPause.Name = "cmdPause";
			this.cmdPause.TabIndex = 4;
			this.cmdPause.Text = "&Pause";
			this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
			// 
			// cmdStart
			// 
			this.cmdStart.Location = new System.Drawing.Point(8, 304);
			this.cmdStart.Name = "cmdStart";
			this.cmdStart.TabIndex = 1;
			this.cmdStart.Text = "&Start";
			this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
			// 
			// PlayArea
			// 
			this.PlayArea.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.PlayArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.PlayArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.PlayArea.Location = new System.Drawing.Point(104, 8);
			this.PlayArea.Name = "PlayArea";
			this.PlayArea.Size = new System.Drawing.Size(210, 352);
			this.PlayArea.TabIndex = 0;
			this.PlayArea.TabStop = false;
			// 
			// txtPaused
			// 
			this.txtPaused.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
			this.txtPaused.ForeColor = System.Drawing.Color.Red;
			this.txtPaused.Location = new System.Drawing.Point(8, 144);
			this.txtPaused.Name = "txtPaused";
			this.txtPaused.Size = new System.Drawing.Size(88, 32);
			this.txtPaused.TabIndex = 10;
			this.txtPaused.Text = "Paused";
			this.txtPaused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.txtPaused.Visible = false;
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(144, 80);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.TabIndex = 1;
			this.TextBox1.Text = "TextBox1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 365);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.PlayArea,
																		  this.cmdPause,
																		  this.GroupBox2,
																		  this.GroupBox1,
																		  this.TextBox1,
																		  this.GameOver,
																		  this.txtPaused,
																		  this.cmdStart});
			this.KeyPreview = true;
			this.Name = "Form1";
			this.Text = "Tetris.NET";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

			this.GroupBox2.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					if (CanMove(CurrentBlock, -1, 0))
					{
						DrawBlock(CurrentBlock, "Clear");
						CurrentBlock.MoveLeft();
						DrawBlock(CurrentBlock, "Draw");
					}
					break;
				case Keys.Right:
					if (CanMove(CurrentBlock, 1, 0))
					{	
						DrawBlock(CurrentBlock, "Clear");
						CurrentBlock.MoveRight();
						DrawBlock(CurrentBlock, "Draw");
					}
					break;
				case Keys.Up:
					DrawBlock(CurrentBlock, "Clear");
					CurrentBlock.Rotate();
					if (CanMove(CurrentBlock, 0, 0))
					{
						DrawBlock(CurrentBlock, "Draw");
					}
					else
					{
						CurrentBlock.Unrotate();
						DrawBlock(CurrentBlock, "Draw");
					}
					break;
				case Keys.Down:
					for (int i = CurrentBlock.CurY; i <= 16;i++)
					{
						if (CanMove(CurrentBlock, 0, 1))
						{
							DrawBlock(CurrentBlock, "Clear");
							CurrentBlock.MoveDown();
							DrawBlock(CurrentBlock, "Draw");
						}
	                    
					}
						
					JustLocked = false;   // Override JustLocked
					break;
			}
		}

		private void cmdPause_Click(object sender, System.EventArgs e)
		{
			if (bPaused == false)
			{
				bPaused = true;
				Timer1.Stop();
				txtPaused.Visible = true;
			}
			else
			{
				Timer1.Start();
				bPaused = false;
				txtPaused.Visible = false;
			}
		}

		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			//Check if we can go down - else create new block
			if (CanMove(CurrentBlock, 0, 1))
			{
				DrawBlock(CurrentBlock, "Clear");
				CurrentBlock.MoveDown();
				DrawBlock(CurrentBlock, "Draw");
				JustLocked = false;
			}
			else
			{
				if (JustLocked)
				{
					//Game Over
					GameOver.Visible = true;
					Timer1.Enabled = false;
					cmdStart.Enabled = true;
					cmdPause.Enabled = false;
				}
				else
				{
					DrawBlock(CurrentBlock, "Lock");
					CheckForLine();
					CreateNewBlock();
					JustLocked = true;
				}
			}
		}

		private void cmdStart_Click(object sender, System.EventArgs e)
		{
			InitGame();

			CreateNewBlock();
			Timer1.Interval = 800;
			Timer1.Enabled = true;
			cmdStart.Enabled = false;
			cmdPause.Enabled = true;
		}

		// Graphical Routines (Draw / Clear )
		public void subClearBox(int intX, int intY)
		{
			Graphics G;
			G = PlayArea.CreateGraphics();

			SolidBrush B;
			B = new SolidBrush(Color.White);

			Rectangle R = new Rectangle(4 + intX * 20,4 + intY * 20,19,19);
//			R.X = 4 + intX * 20;
//			R.Y = 4 + intY * 20;
//			R.Height = 19;
//			R.Width = 19;

			G.FillRectangle(B, R);

		}

		public void subDrawBox(int intX, int intY, Color intColor)
		{

			Graphics G;
			G = PlayArea.CreateGraphics();

			Pen P;
			P = new Pen(Color.Black);

			SolidBrush B;
			B = new SolidBrush(intColor);

			Rectangle R = new Rectangle(4 + intX * 20,4 + intY * 20,18,18);
//			R.X = 4 + intX * 20;
//			R.Y = 4 + intY * 20;
//			R.Height = 18;
//			R.Width = 18;

			G.FillRectangle(B, R);
			G.DrawRectangle(P, R);
		}

		// Block Manipulation Routines
		public void DrawBlock(Block theBlock, string Directive)
		{
			int[,] WorkArray = new int[4, 2];
			int i;
			string[] WorkArray2;
			string[] WorkArray3;

			WorkArray2 = System.Text.RegularExpressions.Regex.Split(theBlock.ReturnBlock(), "#");
			for (i = 0; i<=3; i++)
			{
				WorkArray3 = System.Text.RegularExpressions.Regex.Split(WorkArray2[i], ",");
				WorkArray[i, 0] = Convert.ToInt16(WorkArray3[0]);
				WorkArray[i, 1] = Convert.ToInt16(WorkArray3[1]);
			}

			for (i=0;i<=3;i++)
			{
				switch (Directive)
				{
					case "Clear":
						subClearBox(WorkArray[i, 0], WorkArray[i, 1]);
						InternalPlayArea[WorkArray[i, 0], WorkArray[i, 1]] = 0;
						break;
					case "Draw":
						subDrawBox(WorkArray[i, 0], WorkArray[i, 1], theBlock.BlockCol);
						InternalPlayArea[WorkArray[i, 0], WorkArray[i, 1]] = theBlock.BlockCol.ToArgb();
						break;
					case "Lock":
						subDrawBox(WorkArray[i, 0], WorkArray[i, 1], theBlock.BlockCol);
						InternalPlayArea[WorkArray[i, 0], WorkArray[i, 1]] = theBlock.BlockCol.ToArgb() - 1;
						break;
				}
			}

		}

		private bool CanMove(Block theblock, int intXdir, int intYdir)
		{
			int[,] WorkArray = new int[4, 2];
			int i;
			bool bCanMove;
			
			// Push coordinated to proposed ones
			string[] WorkArray2;
			string[] WorkArray3;
			WorkArray2 = System.Text.RegularExpressions.Regex.Split(theblock.ReturnBlock(), "#");
	
			for (i=0;i<= 3;i++)
			{
				WorkArray3 = System.Text.RegularExpressions.Regex.Split(WorkArray2[i], ",");
				WorkArray[i, 0] = Convert.ToInt16(WorkArray3[0]);
				WorkArray[i, 1] = Convert.ToInt16(WorkArray3[1]);
			}

			for (i=0;i<=3;i++)
			{
				WorkArray[i, 0] = WorkArray[i, 0] + intXdir;
				WorkArray[i, 1] = WorkArray[i, 1] + intYdir;
			}

			// Perform Checks
			bCanMove = true;

			// First check screen left/right boundaries
			if (bCanMove==true)
			{
				for (i = 0;i<=3;i++)
				{
					if ((WorkArray[i, 0] < 0) || (WorkArray[i, 0] > 9))
					{
						return false;
					}
				}
			}

			// Next check screen up/down boundaries
			if (bCanMove)
			{
				for (i=0;i<=3;i++)
				{
					if ((WorkArray[i, 1] < 0) || (WorkArray[i, 1] > 16))
					{
						return  false;
					}
				}
			}

			// Finally check if we trying to occupy a space which is already full
			if (bCanMove)
			{
				for (i = 0;i<=3;i++)
				{
					if ((InternalPlayArea[WorkArray[i, 0], WorkArray[i, 1]] != 0) && (InternalPlayArea[WorkArray[i, 0], WorkArray[i, 1]] != theblock.BlockCol.ToArgb()))
					{
						return  false;
					}
				}
			}
			return bCanMove;

		}

		private void CheckForLine()
		{
			//Check lines by working from bottom up
			int i; 
			int j;
			int k;
			int BoxCount;
			int LineCount;
			//Color NewColor;
			i = 16;
			LineCount = 0;

			while (i > 0)
			{
				BoxCount = 0;
				for (j = 0;j<=9;j++)
				{
					if (InternalPlayArea[j, i] != 0)
					{
						BoxCount++;
					}
				}
				if (BoxCount == 10)
				{
					LineCount++;
					// Clear Line
					for (k = i;k >=1;k--)
					{
						for (j = 0;j<=9;j++)
						{
							InternalPlayArea[j, k] = InternalPlayArea[j, k - 1];
							if (InternalPlayArea[j, k] == 0)
							{
								subClearBox(j, k);
							}
							else
							{
								//Color.FromArgb(InternalPlayArea[j, k]);
								//NewColor.FromArgb(InternalPlayArea[j, k]);
								subDrawBox(j, k, Color.FromArgb(InternalPlayArea[j, k]));
							}

						}
					}
				}
				else
				{
					i--;
				}

			}
			switch (LineCount)
			{
				case 1:
					intScore = intScore + 10;
					break;
				case 2:
					intScore = intScore + 50;
					break;
				case 3:
					intScore = intScore + 250;
					break;
				case 4:
					intScore = intScore + 400;
					break;
			}

			intLines = intLines + LineCount;

			//Increase the speed every ten lines, down to 100ms
			if ((intLines > 0) && (Timer1.Interval > 100))
			{
				if (intLines >= ((intLevel * 10) + 10))
				{
					intLevel++;
					Timer1.Interval = Timer1.Interval - 50;
				}
			}
			

			txtScore.Text = System.String.Format(intScore.ToString(), "#,##0");
			txtLines.Text = System.String.Format(intLines.ToString(), "#,##0");
		}

		private void InitGame()
		{
			GameOver.Visible = false;
			Timer1.Enabled = false;
			int i;
			int j;

			for (i = 0;i<= 9;i++)
			{
				for (j = 0;j<=16;j++)
				{
					InternalPlayArea[i, j] = 0;
				}
			}

			PlayArea.CreateGraphics().Clear(Color.White);

			intScore = 0;
			intLines = 0;
			txtScore.Text = 0.ToString();
			txtLines.Text = 0.ToString();

			this.KeyPreview = true;
		}

		private void CreateNewBlock()
		{
			CurrentBlock = new Block();
			CurrentBlock.Create();
			CurrentBlock.CurX = 4;
			CurrentBlock.CurY = 0;
			DrawBlock(CurrentBlock, "Draw");
		}

	}
}
