using System;
using System.IO;
using System.Collections;
using System.Storage.Core;
using System.Storage.Contact;
using MSAvalon.Windows;
using MSAvalon.Windows.Controls;
using MSAvalon.Windows.Documents;
using MSAvalon.Windows.Navigation;
using MSAvalon.Windows.Shapes;
using MSAvalon.Windows.Serialization;
using MSAvalon.Windows.Media;
using MSAvalon.Windows.Media.Animation;

namespace WinFSCRM
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>

    public partial class Main : Window
    {
		private ArrayList clientList;
		private ArrayList noteList;
		private ArrayList eventList;
		private StorageManager sm;

		private void LoadProgram(object sender, EventArgs ea)
		{
			MessageBox.Show("You must click the 'Create Sample Data' button in order for the demo to work.  You only have to click it the first time you run the program.  Similarly, if you want to remove the data, click 'Remove Sample Data'");
		}

		private void RunSearch(object sender, ClickEventArgs e)
		{
			if (sm == null)
			{
				sm = new StorageManager("WinFSCRM");
			}
			searchResults.Items.Clear();
			foreach (string result in sm.RunFullSearch(query.Text))
			{
				searchResults.Items.Add(result);
			}
		}

		private void clients_Click(object sender, ClickEventArgs e)
		{
			if(clientList == null || clientList.Count == 0)
			{
				if (sm == null)
				{
					sm = new StorageManager("WinFSCRM");
				}
				clientList = new ArrayList(sm.GetClients());
				foreach(Person person in clientList)
				{
					clients.Items.Add(person.DisplayName);
				}
			}
			clients.Visibility = Visibility.Visible;

			LengthAnimation clientsLA = (clients.GetAnimations(ComboBox.HeightProperty) as LengthAnimationCollection)[0] as LengthAnimation;

			clientsLA.Ended += new EventHandler(clientsLA_Ended);
			clientsLA.BeginIn(0);
		}

		private void Events_Click(object sender, ClickEventArgs e)
		{
			if (eventList == null || eventList.Count == 0)
			{
				if (sm == null)
				{
					sm = new StorageManager("WinFSCRM");
				}
				eventList = new ArrayList(sm.GetEvents());
				foreach (Event ev in eventList)
				{
					events.Items.Add(ev.DisplayName);
				}
			}

			events.Visibility = Visibility.Visible;

			LengthAnimation eventsLA = (events.GetAnimations(ComboBox.HeightProperty) as LengthAnimationCollection)[0] as LengthAnimation;

			eventsLA.Ended += new EventHandler(eventsLA_Ended);
			eventsLA.BeginIn(0);
		}

		private void Notes_Click(object sender, ClickEventArgs e)
		{
			if (noteList == null || noteList.Count == 0)
			{
				if (sm == null)
				{
					sm = new StorageManager("WinFSCRM");
				}
				noteList = new ArrayList(sm.GetNotes());
				foreach (System.Storage.Core.Document document in noteList)
				{
					notes.Items.Add(document.DisplayName);
				}
			}

			notes.Visibility = Visibility.Visible;

			LengthAnimation notesLA = (notes.GetAnimations(ComboBox.HeightProperty) as LengthAnimationCollection)[0] as LengthAnimation;

			notesLA.Ended += new EventHandler(notesLA_Ended);
			notesLA.BeginIn(0);
		}

		private void Products_Click(object sender, ClickEventArgs e)
		{
			MessageBox.Show("Sorry, there are no products, since there is not support for extensions in WinFS, yet.");
		}


		private void clientsLA_Ended(object sender, EventArgs e)
		{
			clients.Height = new Length(30);
		}

		private void notesLA_Ended(object sender, EventArgs e)
		{
			notes.Height = new Length(30);
		}

		private void eventsLA_Ended(object sender, EventArgs e)
		{
			events.Height = new Length(30);
		}
		
		private void clients_SelectionChanged(object sender, SelectionChangedEventArgs args)
		{
			ClientInformation ci = null;
			if(this.ContentArea.Children.Count > 0 && this.ContentArea.Children[0] is ClientInformation)
			{
				ci = this.ContentArea.Children[0] as ClientInformation;
			}
			else
			{
				this.ContentArea.Children.Clear();
				ci = new ClientInformation();
				this.ContentArea.Children.Add(ci);
			}
			ci.LoadData(this.clientList[clients.SelectedIndex] as Person);
		}

		private void notes_SelectionChanged(object sender, SelectionChangedEventArgs args)
		{
			NoteBody nb = null;

			if (this.ContentArea.Children.Count > 0 && this.ContentArea.Children[0] is NoteBody)
			{
				nb = this.ContentArea.Children[0] as NoteBody;
			}
			else
			{
				this.ContentArea.Children.Clear();
				nb = new NoteBody();
				this.ContentArea.Children.Add(nb);
			}

			nb.LoadNote(this.noteList[notes.SelectedIndex] as System.Storage.Core.Document);
		}

		private void events_SelectionChanged(object sender, SelectionChangedEventArgs args)
		{
			EventInformation ei = null;

			if (this.ContentArea.Children.Count > 0 && this.ContentArea.Children[0] is EventInformation)
			{
				ei = this.ContentArea.Children[0] as EventInformation;
			}
			else
			{
				this.ContentArea.Children.Clear();
				ei = new EventInformation();
				this.ContentArea.Children.Add(ei);
			}

			ei.LoadEvent(this.eventList[events.SelectedIndex] as System.Storage.Core.Event);
		}

		private void create_Click(object sender, ClickEventArgs e)
		{
			if (sm == null)
			{
				sm = new StorageManager("WinFSCRM");
			}
			sm.CreateSampleData();
		}

		private void remove_Click(object sender, ClickEventArgs e)
		{
			if (sm == null)
			{
				sm = new StorageManager("WinFSCRM");
			}
			sm.DeleteSampleData();
		}
	}
}