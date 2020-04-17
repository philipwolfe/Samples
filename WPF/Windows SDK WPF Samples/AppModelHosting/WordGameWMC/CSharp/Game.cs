namespace WordGameWMC
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Resources;
    using System.Collections;
    using System.IO;
    using System.ComponentModel;
    using System.Threading;
    using System.Text;

    public class Game : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        Stack<string> masterWordList;

        string currentWord;
        string guessedSoFar;
        string lettersUsed = "";
        int numberOfGuesses;
        int maxGuessesAllowed = 6;
        GameEndState gameEndState;

        public Game()
        {
            LoadGameData();
        }

        public event EventHandler LetterTried;
        public event EventHandler GameEnded;

        public bool MoreWordsToGuess
        {
            get { return (this.masterWordList.Peek() != null); }
        }
        public void NewWord()
        {
            this.currentWord = this.masterWordList.Pop().ToLower();
            this.guessedSoFar = new string('*', this.currentWord.Length);
            this.lettersUsed = "";
            this.numberOfGuesses = 0;
            this.gameEndState = GameEndState.Incomplete;

            OnPropertyChanged("CurrentWord");
            OnPropertyChanged("GuessedSoFar");
            OnPropertyChanged("LettersUsed");
            OnPropertyChanged("NumberOfGuesses");
            OnPropertyChanged("GuessesRemaining");
            OnPropertyChanged("GameEndState");
        }
        public void TryLetter(string letter)
        {
            // Make sure letter was passed
            if (string.IsNullOrEmpty(letter))
            {
                this.gameEndState = GameEndState.Incomplete;
                OnPropertyChanged("GameEndState");
                if (this.LetterTried != null) this.LetterTried(this, EventArgs.Empty);
                return;
            }

            letter = letter.ToLower();

            // Already used?
            if (this.lettersUsed.Contains(letter))
            {
                this.gameEndState = GameEndState.Incomplete;
                OnPropertyChanged("GameEndState");
                if (this.LetterTried != null) this.LetterTried(this, EventArgs.Empty);
                return;
            }

            this.lettersUsed += letter;
            OnPropertyChanged("LettersUsed");

            // Letter found?
            if (this.currentWord.Contains(letter))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < this.currentWord.Length; i++)
                {
                    if ((this.currentWord[i].ToString() == letter) && (this.guessedSoFar[i].ToString() == "*"))
                    {
                        sb.Append(letter);
                    }
                    else
                    {
                        sb.Append(this.guessedSoFar[i]);
                    }
                }
                this.guessedSoFar = sb.ToString();
                OnPropertyChanged("GuessedSoFar");

                // A letter was found and the word was guessed
                if (this.currentWord == this.guessedSoFar)
                {
                    this.gameEndState = GameEndState.Won;
                    OnPropertyChanged("GameEndState");
                    if (this.GameEnded != null) this.GameEnded(this, EventArgs.Empty);
                    return;
                }

                // A letter was found but the word wasn't guessed
                this.gameEndState = GameEndState.Incomplete;
                OnPropertyChanged("GameEndState");
                if (this.LetterTried != null) this.LetterTried(this, EventArgs.Empty);
                return;
            }

            this.numberOfGuesses += 1;
            OnPropertyChanged("NumberOfGuesses");
            OnPropertyChanged("GuessesRemaining");

            // Any more chances?
            if (this.numberOfGuesses == this.maxGuessesAllowed)
            {
                this.gameEndState = GameEndState.Lost;
                OnPropertyChanged("GameEndState");
                if (this.GameEnded != null) this.GameEnded(this, EventArgs.Empty);
            }

            this.gameEndState = GameEndState.Incomplete;
            OnPropertyChanged("GameEndState");
            if (this.LetterTried != null) this.LetterTried(this, EventArgs.Empty);
        }

        public string CurrentWord
        {
            get { return this.currentWord; }
        }
        public string GuessedSoFar
        {
            get { return this.guessedSoFar; }
        }
        public string LettersUsed
        {
            get { return this.lettersUsed; }
        }
        public int NumberOfGuesses
        {
            get { return this.numberOfGuesses; }
        }
        public int MaxGuessesAllowed
        {
            get { return this.maxGuessesAllowed; }
            set
            {
                this.maxGuessesAllowed = value;
                OnPropertyChanged("MaxGuessesAllowed");
            }
        }
        public int GuessesRemaining {
            get { return this.maxGuessesAllowed - this.numberOfGuesses; }
        }
        public GameEndState GameEndState
        {
            get { return this.gameEndState; }
        }

        private void LoadGameData()
        {
            StringCollection wordList = new StringCollection();
            this.masterWordList = new Stack<string>();

            // Get word data from site of origin or, if can't find it at site of origin, use the default
            using (Stream stream = GetWordListStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream) wordList.Add(reader.ReadLine());
            }

            // Fill master word list in a random order
            Random r = new Random();
            for (int i = 0; i < wordList.Count; i++)
            {
                int index = r.Next(wordList.Count);
                this.masterWordList.Push(wordList[index]);
                wordList.RemoveAt(index);
            }
        }
        private Stream GetWordListStream()
        {
            // Get word list from site of origin or, if not there, from the default resource file stream
            StreamResourceInfo sooStream = Application.GetRemoteStream(new Uri("pack://siteoforigin:,,,/WordList.txt", UriKind.Absolute));
            if (sooStream.Stream != null)
            {
                return sooStream.Stream;
            }
            else
            {
                StreamResourceInfo res = Application.GetResourceStream(new Uri("DefaultWordList.txt", UriKind.Relative));
                return res.Stream;
            }
        }
    }
}