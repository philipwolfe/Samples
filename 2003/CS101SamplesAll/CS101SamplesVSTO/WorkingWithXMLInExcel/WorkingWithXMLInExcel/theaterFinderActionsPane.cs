#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Working_with_XML_in_Excel
{
	partial class theaterFinderActionsPane : UserControl
	{
		IgnyteTheaterMovieService.Theater[] theaters = null;

		public theaterFinderActionsPane()
		{
			InitializeComponent();
		}

		/// <summary>
		/// This is the click event handler for the Find Theaters! button. 
		/// It makes the call to the Ignyte Theater/Movie service and fills 
		/// an array of Theater objects for use by the worksheet object.
		/// </summary>
		private void findTheatersButton_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			// Instantiate the proxy for the Web service.
			IgnyteTheaterMovieService.MovieInformation theaterMovieWebService = 
					new IgnyteTheaterMovieService.MovieInformation();
			
			// Initialize a radius variable and clear any existing 
			// theaters from a previous Web service calls.
			int radius;
			theatersListBox.DataSource = null;
			theatersListBox.Items.Clear();

            if (radiusComboBox.Text == "")
            {
                radiusComboBox.Text = "15";
            }

			radius = Int32.Parse(radiusComboBox.Text);

			try
			{
				// Fill the array of theaters by calling the Web service's 
				// GetTheatersAndMovies Web method. This method also returns 
				// an array of Movie objects exposed by each Theater object.
				theaters = theaterMovieWebService.GetTheatersAndMovies(zipCodeTextBox.Text, radius);

				// Bind the theaters array to the ListBox.
				theatersListBox.DisplayMember = "Name";
				theatersListBox.DataSource = theaters;
				// Deselect all options.
				theatersListBox.SelectedIndex = -1;
			}
			catch (System.Net.WebException webException)
			{
				MessageBox.Show("Web service could not be accessed. " + 
					"Please make sure you are connected to the Internet.");
				return;
			}

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// This is the Click event handler for the ListBox. It binds the ListObject 
		/// control on the worksheet to the array of Movie objects for the selected 
		/// theater.
		/// </summary>
		private void theatersListBox_Click(object sender, EventArgs e)
		{
				Globals.MoviesSheet.moviesListObject.DataSource = 
					theaters[theatersListBox.SelectedIndex].Movies;
		}
	}
}
