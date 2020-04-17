//<SnippetIsoStorageCode1>
using System;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Xml.Serialization;
namespace WordGameWMC
{
[Serializable]
public class PlayerScore : INotifyPropertyChanged
{
    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            this.PropertyChanged(this, new PropertyChangedEventArgs("GamesPlayed"));
        }
    }
    
    #endregion

    int gamesWon;
    int gamesLost;
    int gamesConceded;

    public int GamesWon
    {
        get { return this.gamesWon; }
        set { this.gamesWon = value; OnPropertyChanged("GamesWon"); }
    }

    public int GamesLost
    {
        get { return this.gamesLost; }
        set { this.gamesLost = value; OnPropertyChanged("GamesLost"); }
    }

    public int GamesConceded
    {
        get { return this.gamesConceded; }
        set { this.gamesConceded = value; OnPropertyChanged("GamesConceded"); }
    }

    public int GamesPlayed
    {
        get { return this.gamesWon + this.GamesLost + this.gamesConceded; }
    }

    // Reset scores
    public void Reset()
    {
        this.GamesWon = 0;
        this.GamesLost = 0;
        this.GamesConceded = 0;
    }

    public override string ToString()
    {
        string winword = (this.gamesWon == 1 ? "Win" : "Wins");
        string lossword = (this.gamesLost == 1 ? "Loss" : "Losses");
        return string.Format("{0} {1}, {2} {3}, {4} concessions, {5} played", this.gamesWon, winword, this.gamesLost, lossword, this.gamesConceded, this.GamesPlayed);
    }

    #region Isolated Storage Persistence

    public static PlayerScore Load()
    {
        try
        {
            // Load the playerscore.xml file from isolated storage
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            using (Stream stream = new IsolatedStorageFileStream("playerscore.xml", FileMode.Open, isf))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerScore));
                return (PlayerScore)xmlSerializer.Deserialize(stream);
            }
        }
        catch (FileNotFoundException ex)
        {
            return new PlayerScore();
        }
    }

    public static void Save(PlayerScore playerScore)
    {
        // Save the playerscore.xml file to isolated storage
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        using (Stream stream = new IsolatedStorageFileStream("playerscore.xml", FileMode.Create, isf))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerScore));
            xmlSerializer.Serialize(stream, playerScore);
        }
    }

    #endregion
}
}