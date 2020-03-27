Public Class theaterFinderActionsPane
    Private theaters As IgnyteTheaterMovieService.Theater()

    ''' <summary>
    ''' This is the click event handler for the Find Theaters! button. 
    ''' It makes the call to the Ignyte Theater'Movie service and fills 
    ''' an array of Theater objects for use by the worksheet object.
    ''' <'summary>
    Private Sub findTheatersButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles findTheatersButton.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        ' Instantiate the proxy for the Web service.
        Dim theaterMovieWebService As New IgnyteTheaterMovieService.MovieInformation()

        ' Initialize a radius variable and clear any existing 
        ' theaters from a previous Web service calls.
        Dim radius As Int32
        theatersListBox.DataSource = Nothing
        theatersListBox.Items.Clear()

        If radiusComboBox.Text = "" Then
            radiusComboBox.Text = "15"
        End If

        radius = Int32.Parse(radiusComboBox.Text)

        Try

            ' Fill the array of theaters by calling the Web service's 
            ' GetTheatersAndMovies Web method. This method also returns 
            ' an array of Movie objects exposed by each Theater object.
            theaters = theaterMovieWebService.GetTheatersAndMovies(zipCodeTextBox.Text, radius)

            ' Bind the theaters array to the ListBox.
            theatersListBox.DisplayMember = "Name"
            theatersListBox.DataSource = theaters
            ' Deselect all options.
            theatersListBox.SelectedIndex = -1

        Catch webException As System.Net.WebException
            MessageBox.Show("Web service could not be accessed. Please make sure you are connected to the Internet.")
            Exit Sub
        End Try

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    ''' <summary>
    ''' This is the Click event handler for the ListBox. It binds the ListObject 
    ''' control on the worksheet to the array of Movie objects for the selected 
    ''' theater.
    ''' <'summary>
    Private Sub theatersListBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles theatersListBox.Click
        Globals.MoviesSheet.moviesListObject.DataSource = theaters(theatersListBox.SelectedIndex).Movies
    End Sub
End Class
