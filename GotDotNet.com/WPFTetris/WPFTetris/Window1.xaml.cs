using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using System.Threading;


/*
 *   
 * 
 * 
 */ 


namespace WPFTetris
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {


        public Label[,] blocksControls;

        public Point[] fallingBlock;
        public Point fallingBlockPosition;

        public Brush fallingBlockBrush;

        public Brush NO_BLOCK_BRUSH;
        public Brush FLASH_ROW_BRUSH;

        public Thickness NO_BLOCK_THICKNESS;
        public Thickness IN_BLOCK_THICKNESS;


        public int nextLevelScoreThreshold;
        public int currentScore;
        public int currentLevel;
        public const int ROW_REMOVED_POINTS = 100;

        public bool blockJustShowed;


        /* Everytime the Timer overflows the system does one move, 
         * either move the block down, or show next block */
        System.Windows.Forms.Timer blockStepTimer;

        public Window1()
        {
            InitializeComponent();

        }

        private void SetGridBackroundImage()
        {
            //ImageBrush image = new ImageBrush(
        }

        void Window1_Initialized(object sender, EventArgs e)
        {
            /**/
            SetGridBackroundImage();

            /**/
            nextLevelScoreThreshold = 500;
            currentLevel = 0;
            currentScore = 0;

            NO_BLOCK_BRUSH = Brushes.Transparent;
            FLASH_ROW_BRUSH = Brushes.White;
            NO_BLOCK_THICKNESS = new Thickness(0, 0, 0, 0);
            IN_BLOCK_THICKNESS = new Thickness(2, 2, 2, 2);

            /*Init blocks array*/
            int rowCount;
            int columnCount;

            rowCount = tetrisGrid.RowDefinitions.Count;
            columnCount = tetrisGrid.ColumnDefinitions.Count;
            
            /*init fallingBlock array*/
            fallingBlock = new Point[4];
            for (int i = 0; i < fallingBlock.Length; i++)
            {
                fallingBlock[i] = new Point(0,0);
            }

            /**/
            fallingBlockPosition = new Point(0,0);

            /**/
            blockStepTimer = new System.Windows.Forms.Timer();
            blockStepTimer.Interval = 700;
            blockStepTimer.Tick += new EventHandler(blockStepTimer_Tick);
            blockStepTimer.Enabled = false;

            AddBlocksControls();
        }


        private void AddBlocksControls()
        {
            int rowCount;
            int columnCount;

            rowCount = tetrisGrid.RowDefinitions.Count;
            columnCount = tetrisGrid.ColumnDefinitions.Count;

            blocksControls = new Label[rowCount,columnCount];

            for(int i = 0; i < rowCount; i++)
            {
                for(int j = 0; j < columnCount; j++)
                {
                    Label blockLabel = new Label();
                    blockLabel.Background = NO_BLOCK_BRUSH;
                    blocksControls[i, j] = blockLabel;



                    Border blockBorder = new Border();
                    blockBorder.BorderBrush = Brushes.Black;
                    blockBorder.Child = blockLabel;

                    /* Can't believe te following block of code works. 
                     * where the hell are the column and the row stored?!?
                     * Not in tetrisGrid, because the VM only knows that it
                     * is part of tetrisGrid _after_ both the row and col have
                     * been set.
                     */
                    Grid.SetRow(blockBorder, i);
                    Grid.SetColumn(blockBorder, j);
                    tetrisGrid.Children.Add(blockBorder);

                    
                }
            }

            
        }

        public void StartNewGame(object sender, RoutedEventArgs e)
        {
            blockStepTimer.Start();
            ShowNextBlock();
        }


        public void btnDebugAction_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Type = " + tetrisGrid.GetType().ToString()
                + "\n\n IsEquals to Grid.Type() = ");
        }





        private void blockStepTimer_Tick(object sender, EventArgs e)
        {
            MoveBlockDown();
        }




        /// <summary>
        /// Handles all KeyDown events for all controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Left:
                    MoveBlockLeft();
                    break;

                case Key.Right:
                    MoveBlockRight();
                    break;

                case Key.Down:
                    MoveBlockDown();
                    break;

                case Key.Up:
                    RotateBlockClockwise();
                    break;

                case Key.Pause:
                    TogglePauseState();
                    break;

                case Key.F2:
                    StartNewGame(null, null);
                    break;
    
                default:
                    break;
            }

            
        }

        private void RotateBlockClockwise()
        {
            ClearBlock();

            //using regular for loop beacuse foreach causes iterator problems
            for (int i = 0; i < fallingBlock.Length; i++)
            {
                int x = (int)fallingBlock[i].X;
                fallingBlock[i].X = fallingBlock[i].Y;
                fallingBlock[i].Y = -1 * x;
            }

            PaintBlock();
        }

        private void MoveBlockRight()
        {
            LinkedList<Point> rightestPoints = new LinkedList<Point>();
            int rightestX = int.MinValue;  //the highestValue, which is the lowest row

            foreach (Point p in fallingBlock)
            {
                if (rightestX == p.X)
                {
                    rightestPoints.AddFirst(p);
                }
                else if (rightestX < p.X)
                {
                    rightestX = (int)p.X;
                    rightestPoints.Clear();
                    rightestPoints.AddFirst(p);
                }
            }

            int baseX = (int)(fallingBlockPosition.X);
            int baseY = (int)(fallingBlockPosition.Y);

            int gridColumnCount = tetrisGrid.ColumnDefinitions.Count;

            /*Check that it can move down*/
            bool canMoveRight = true;
            foreach (Point p in rightestPoints)
            {
                /* -1 to check if the next possible value goes out of bounds*/
                if ((baseX + p.X + 1) >= gridColumnCount)
                {
                    canMoveRight = false;
                    break;
                }
                else if (blocksControls[(int)(baseY + p.Y), (int)(p.X + baseX + 1)].Background != NO_BLOCK_BRUSH)
                {
                    canMoveRight = false;
                    break;
                }
            }

            if (!canMoveRight)
            {
                return;
            }

            /*move right*/
            ClearBlock();
            fallingBlockPosition.X++;
            PaintBlock();

        }


        private void MoveBlockLeft()
        {
            LinkedList<Point> leftestPoints = new LinkedList<Point>();
            int leftestX = int.MaxValue;  //the highestValue, which is the lowest row

            foreach (Point p in fallingBlock)
            {
                if (leftestX == p.X)
                {
                    leftestPoints.AddFirst(p);
                }
                else if (leftestX > p.X)
                {
                    leftestX = (int)p.X;
                    leftestPoints.Clear();
                    leftestPoints.AddFirst(p);
                }
            }

            int baseX = (int)(fallingBlockPosition.X);
            int baseY = (int)(fallingBlockPosition.Y);



            /*Check that it can move down*/
            bool canMoveLeft = true;
            foreach (Point p in leftestPoints)
            {
                /* -1 to check if the next possible value goes out of bounds*/
                if ((baseX + p.X - 1) < 0)
                {
                    canMoveLeft = false;
                    break;
                }
                else if (blocksControls[(int)(baseY + p.Y), (int)(p.X + baseX - 1)].Background != NO_BLOCK_BRUSH)
                {
                    canMoveLeft = false;
                    break;
                }
            }

            if (!canMoveLeft)
            {
                return;
            }

            /*move left*/
            ClearBlock();
            fallingBlockPosition.X--;
            PaintBlock();

        }

        private void MoveBlockDown()
        {
            LinkedList<Point> lowestPoints = new LinkedList<Point>();
            int lowestY = int.MinValue;  //the highestValue, which is the lowest row

            foreach (Point p in fallingBlock)
            {
                if(lowestY == p.Y)
                {
                    lowestPoints.AddFirst(p);
                }
                else if (lowestY < p.Y)
                {
                    lowestY = (int)p.Y;
                    lowestPoints.Clear();
                    lowestPoints.AddFirst(p);
                }
            }

            int baseX = (int)(fallingBlockPosition.X);
            int baseY = (int)(fallingBlockPosition.Y);


            int gridRowCount = tetrisGrid.RowDefinitions.Count;

            /*Check that it can move down*/
            bool canMoveDown = true;
            foreach (Point p in lowestPoints)
            {
                /* +1 to check if the next possible value goes out of bounds*/
                if ((baseY + p.Y + 1) >= gridRowCount)
                {
                    canMoveDown = false;
                    break;
                }
                else if (blocksControls[(int)(baseY + p.Y + 1), (int)(p.X + baseX)].Background != NO_BLOCK_BRUSH)
                {
                    if (blockJustShowed)
                    {
                        LooseGame();
                        return;
                    }

                    canMoveDown = false;
                    break;
                }
            }

            if (!canMoveDown)
            {
                CheckForRowCompleted();
                ShowNextBlock();
                return; 
            }


            /*move down*/
            ClearBlock();
            fallingBlockPosition.Y++;
            blockJustShowed = false;
            PaintBlock();
            
        }

        private void CheckForRowCompleted()
        {
            int rowCount = tetrisGrid.RowDefinitions.Count;
            int columnCount = tetrisGrid.ColumnDefinitions.Count;

            int completedRow = -1;
            for (int row = rowCount - 1; row >= 0; row--)
            {
                bool completed = true;
                for (int col = 0; col < columnCount; col++)
                {
                    if (blocksControls[row, col].Background == NO_BLOCK_BRUSH)
                    {
                        completed = false;
                        break;
                    }
                }

                if (completed)
                {
                    completedRow = row;
                    break;
                }
            }


            if (completedRow != -1)
            {
                //FlashTetrisRow(completedRow);
                RemoveTetrisRow(completedRow);
                IncrementScore(ROW_REMOVED_POINTS);
                CheckForRowCompleted(); // and remove another one if exists
            }
        }



        /*Not being used right now*/
        private void FlashTetrisRow(int rowToFlash)
        {
            
            blockStepTimer.Stop();
            PaintRow(rowToFlash, FLASH_ROW_BRUSH);
            //Thread.Sleep(900);
        }

        private void RemoveTetrisRow(int rowToRemove)
        {
            int columnCount = tetrisGrid.ColumnDefinitions.Count;

            for (int row = rowToRemove; row > 0; row--)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    blocksControls[row, col].Background = blocksControls[row - 1, col].Background;

                    Border currentRowBorder = ((Border)blocksControls[row, col].Parent);
                    Border upperRowBorder =  ((Border)blocksControls[row - 1, col].Parent);
                    currentRowBorder.BorderThickness = upperRowBorder.BorderThickness;
                }
            }


            //clear topmost row
            for (int col = 0; col < columnCount; col++)
            {
                PaintRow(0, NO_BLOCK_BRUSH);

                Border blockBorder = (Border)blocksControls[0, col].Parent;
                blockBorder.BorderThickness = NO_BLOCK_THICKNESS;
                
            }
        }

        public void IncrementScore(int amount)
        {
            currentScore += amount;
            scoreLabel.Content = "" + currentScore;

            if (currentScore >= nextLevelScoreThreshold)
            {
                currentLevel++;
                levelLabel.Content = "" + currentLevel;

                nextLevelScoreThreshold += 10 * ROW_REMOVED_POINTS;

                blockStepTimer.Interval = (int)(.85 * blockStepTimer.Interval);
            }

            scoreLabel.Content = "" + currentScore;            
        }


        /* Paints only one row. Good for doing the flashing when a row is ocmpleted,
         * amongst other things. */
        private void PaintRow(int row, Brush brush)
        {
            int columnCount = tetrisGrid.ColumnDefinitions.Count;

            for( int col = 0; col < columnCount; col++)
            {
                blocksControls[row, col].Background = brush;
            }
        }


        private void ShowNextBlock()
        {
            int columnCount = tetrisGrid.ColumnDefinitions.Count;

            fallingBlock = GenerateRandomBlock();
            fallingBlockPosition = new Point(columnCount / 2,1);
            PaintBlock();
            blockJustShowed = true;
        }

        private void ClearBlock()
        {
            foreach (Point p in fallingBlock)
            {
                int i = (int)(fallingBlockPosition.X + p.X);
                int j = (int)(fallingBlockPosition.Y + p.Y);

                blocksControls[j,i].Background = NO_BLOCK_BRUSH;

                Border blockBorder = (Border)blocksControls[j, i].Parent;
                blockBorder.BorderThickness = NO_BLOCK_THICKNESS;
                
            }
        }

        private void PaintBlock()
        {
            foreach (Point p in fallingBlock)
            {
                int i = (int)(fallingBlockPosition.X + p.X);
                int j = (int)(fallingBlockPosition.Y + p.Y);

                blocksControls[j, i].Background = fallingBlockBrush;

                Border blockBorder = (Border)blocksControls[j, i].Parent;
                blockBorder.BorderThickness = IN_BLOCK_THICKNESS;
            }

        }


        private void LooseGame()
        {
            MessageBox.Show("You Lost");
            blockStepTimer.Stop();
        }



        private void TogglePauseState()
        {
            /*Toggle boolean value*/
            blockStepTimer.Enabled = !blockStepTimer.Enabled;
        }

        private Point[] GenerateRandomBlock()
        {
            Random rand = new Random();
            
            switch (rand.Next() % 7)
            {
                case 0: //T
                    fallingBlockBrush = Brushes.Green;
                    return new Point[]{
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,-1),
                        new Point(1,0),
                    };

                case 1: //LDer
                    fallingBlockBrush = Brushes.Red;
                    return new Point[]{
                        new Point(0,0),
                        new Point(0,-1),
                        new Point(0,1),
                        new Point(1,1),
                    };

                case 2: // _
                    fallingBlockBrush = Brushes.Lime;
                    return new Point[]{
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(1,0),
                        new Point(2,0),
                    };

                case 3: //LIzq
                    fallingBlockBrush = Brushes.Orange;
                    return new Point[]{
                        new Point(0,0),
                        new Point(0,-1),
                        new Point(0,1),
                        new Point(-1,1),
                    };


                case 4: //SDer (Z)
                    fallingBlockBrush = Brushes.Purple;
                    return new Point[]{
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,1),
                        new Point(1,1),
                    };


                case 5: //SIzq (S)
                    fallingBlockBrush = Brushes.Gray;
                    return new Point[]{
                        new Point(0,0),
                        new Point(1,0),
                        new Point(0,1),
                        new Point(-1,1),
                    };

                case 6: //Cuadro
                    fallingBlockBrush = Brushes.LightGoldenrodYellow;
                    return new Point[]{
                        new Point(0,0),
                        new Point(0,1),
                        new Point(1,0),
                        new Point(1,1),
                    };

                default:
                    return null;
                    
            }
        }
    }
}