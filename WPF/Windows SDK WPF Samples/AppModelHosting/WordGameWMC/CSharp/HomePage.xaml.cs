namespace WordGameWMC
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Runtime.InteropServices;
    
using Microsoft.MediaCenter;

    public partial class HomePage : Page
    {
        Game game;
        PlayerScore playerScore;

        private void On_Loaded(object sender, EventArgs e)
        {
            guessCharacterSoftKeyboardTextBox.Focus();

            this.game = new Game();
            this.game.MaxGuessesAllowed = 6;
            this.game.LetterTried += game_LetterTried;
            this.game.GameEnded += game_GameEnded;
            this.DataContext = this.game;

            if (this.game.MoreWordsToGuess) this.game.NewWord();

            // Load player's score and bind to UI
            this.playerScore = PlayerScore.Load();
            this.scoresGrid.DataContext = this.playerScore;
        }

        private void newWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset UI
            this.goButton.IsEnabled = true;
            this.giveUpButton.IsEnabled = true;
            this.guessCharacterSoftKeyboardTextBox.Text = "";
            this.guessCharacterSoftKeyboardTextBox.Focus();
            ResetFaceImage();

            // Reset game            
            this.game.NewWord();
        }
        private void giveUpButton_Click(object sender, RoutedEventArgs e)
        {
            //Give the correct answer

            this.playerScore.GamesConceded += 1;
            PlayerScore.Save(this.playerScore);

            string msg = "The correct word was '" + this.game.CurrentWord + "'.";
            msg += "\n\nScore: " + this.playerScore.ToString();

            try
            {
                // Get media center host and show dialog box
                MediaCenterEnvironment mce = Microsoft.MediaCenter.Hosting.AddInHost.Current.MediaCenterEnvironment;
                mce.Dialog(msg, "WordGame!", DialogButtons.Ok, 1000, true);
            }
            catch (COMException ex)
            {
                MessageBox.Show(msg, "WordGame!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            this.goButton.IsEnabled = false;
            this.giveUpButton.IsEnabled = false;
        }
        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            this.game.TryLetter(guessCharacterSoftKeyboardTextBox.Text.ToLower());
        }
        void resetPlayerScoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.playerScore.Reset();
            PlayerScore.Save(this.playerScore);
        }

        void game_LetterTried(object sender, EventArgs e)
        {
            DrawFacePart();

            this.guessCharacterSoftKeyboardTextBox.Text = "";
            this.guessCharacterSoftKeyboardTextBox.Focus();
        }
        void game_GameEnded(object sender, EventArgs e)
        {
            string msg = "";

            switch (this.game.GameEndState)
            {
                case GameEndState.Won:
                    this.playerScore.GamesWon += 1;
                    ShowWinFace();
                    msg = "You Win!";
                    break;
                case GameEndState.Lost:
                    this.playerScore.GamesLost += 1;
                    ShowLoseFace();
                    msg = "You Lose!";
                    break;
            }
            PlayerScore.Save(this.playerScore);

            msg += "\n\nThe correct word was '" + this.game.CurrentWord + "'.";
            msg += "\n\nYour Score: " + this.playerScore.ToString();

            // Get media center host and show dialog box
            try
            {
                MediaCenterEnvironment mce = Microsoft.MediaCenter.Hosting.AddInHost.Current.MediaCenterEnvironment;
                mce.Dialog(msg, "WordGame!", DialogButtons.Ok, 1000, true);
            }
            catch (COMException ex)
            {
                MessageBox.Show(msg, "WordGame!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            this.goButton.IsEnabled = false;
            this.giveUpButton.IsEnabled = false;

            this.guessCharacterSoftKeyboardTextBox.Text = "";
            this.guessCharacterSoftKeyboardTextBox.Focus();
        }

        private void DrawFacePart()
        {
            switch (this.game.NumberOfGuesses)
            {
                case 1:
                    Face.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Face.Fill = (Brush)this.FindResource("faceFillBrush");
                    break;
                case 3:
                    LeftEye.Visibility = Visibility.Visible;
                    break;
                case 4:
                    RightEye.Visibility = Visibility.Visible;
                    break;
                case 5:
                    Nose.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ShowLoseFace()
        {
            Frown.Visibility = Visibility.Hidden;
        }

        private void ShowWinFace()
        {
            Face.Visibility = Visibility.Visible;
            Face.Fill = (Brush)this.FindResource("faceFillBrush");
            Nose.Visibility = Visibility.Visible;
            LeftEye.Visibility = Visibility.Visible;
            RightEye.Visibility = Visibility.Visible;
            Smile.Visibility = Visibility.Visible;
            Frown.Visibility = Visibility.Visible;
        }

        private void ResetFaceImage()
        {
            Face.Visibility = Visibility.Hidden;
            Face.Fill = null;
            Nose.Visibility = Visibility.Hidden;
            LeftEye.Visibility = Visibility.Hidden;
            RightEye.Visibility = Visibility.Hidden;
            Smile.Visibility = Visibility.Hidden;
            Frown.Visibility = Visibility.Hidden;
        }
    }
}