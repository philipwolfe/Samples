#Region "Using Statements"

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports StoringRetrievingImage.MyImagesDataSetTableAdapters

#End Region

Public Class StoringRetrievingImagesForm

    Dim myPhotoDataSet As DataSet
    Dim currentPage As Integer = 0

    ''' <summary>
    ''' This event opens an OpenFileDialog so you can browse for 
    ''' the image you want to upload. The filename textbox is then
    ''' filled for when the image is uploaded.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub browseImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseImageButton.Click

        browseImageOpenFileDialog.Title = "Select an Image to Import"
        browseImageOpenFileDialog.Multiselect = False
        browseImageOpenFileDialog.Filter = "JPEG Compressed Image(*.jpg)|*.jpg|Graphic Interchange Format (*.gif)|*.gif"
        browseImageOpenFileDialog.FilterIndex = 2
        browseImageOpenFileDialog.FileName = ""
        browseImageOpenFileDialog.ShowDialog()
        imageNameTextBox.Text = browseImageOpenFileDialog.FileName

    End Sub

    ''' <summary>
    ''' This event prepares all the fields that we want to insert into the database.
    ''' The photograph name and CategoryID are retrieved from their respective controls.
    ''' The image data is first selected from the image file name text box.  The file is then opened
    ''' and saved into a FileStream object.  This stream is then saved into a byte array which
    ''' will be stored in the image data type.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub insertImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles insertImageButton.Click
        Try

            Dim myMessage As String
            Dim myCategoryID As Integer = 0
            If imageNameTextBox.Text = "" Then
                MessageBox.Show("Please Enter a File Name.", "Alert")
            Else

                Dim myAdapter As CategoriesTableAdapter = New CategoriesTableAdapter()

                browseImageOpenFileDialog.FileName = imageNameTextBox.Text
                Dim myFile As String
                For Each myFile In browseImageOpenFileDialog.FileNames

                    ' make sure the file is JPEG or GIF
                    Dim testFile As System.IO.FileInfo = New System.IO.FileInfo(myFile)
                    If Not String.Compare(testFile.Extension, ".GIF", True) = 0 _
                    And Not String.Compare(testFile.Extension, ".JPG", True) = 0 Then
                        MessageBox.Show("This file type is not supported. Must be GIF or JPG. Please try again.", "Alert")
                        Continue For
                    End If

                    '' Create a new stream to load this photo into
                    Dim myStream As FileStream = New FileStream(myFile, FileMode.Open, FileAccess.Read)
                    '' Create a buffer to hold the stream of bytes
                    Dim myImageBuffer(myStream.Length) As Byte


                    '' Read the bytes from this stream and put it into the image buffer
                    myStream.Read(myImageBuffer, 0, Convert.ToInt32(myStream.Length))
                    '' Close the stream
                    myStream.Close()

                    '' get the photograph name
                    Dim myPhotographName As String = photographNameTextBoxTextBox.Text

                    '' get the CategoryID
                    myCategoryID = Convert.ToInt32(categoriesComboBox.SelectedValue)

                    Try

                        '' Call the insertNewImage method passing the property parameters
                        myMessage = myAdapter.insertNewImage(myCategoryID, myPhotographName, myImageBuffer)
                        MessageBox.Show(myMessage, "Information")

                    Catch ex As Exception

                        MessageBox.Show("There was an error inserting this image. Please try again.", "Alert")
                    End Try


                    myImageBuffer = Nothing
                Next

                ResetDisplay()
            End If
        Catch ex As Exception
            MessageBox.Show("There was an error inserting this image.  Please try again.", "Alert")
        End Try
    End Sub

    ''' <summary>
    ''' In the Load event, the Category combobox is initialized,
    ''' and the Previous and Next LinkLabels are set to not visible
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StoringRetrievingImagesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim myAdapter As CategoriesTableAdapter = New CategoriesTableAdapter()
        Dim myDataSet As DataSet
        Try

        myDataSet = myAdapter.getCategories()
            categoriesComboBox.DataSource = myDataSet.Tables(0)
            categoriesComboBox.DisplayMember = "CategoryName"
            categoriesComboBox.ValueMember = "CategoryID"

            nextLinkLabel.Visible = False
            previousLinkLabel.Visible = False
        Catch ex As Exception
            MessageBox.Show("There was an error starting this application. Please restart.", "Alert")
            getImagesButton.Enabled = False
            browseImageButton.Enabled = False
            categoriesComboBox.Enabled = False
            imageNameTextBox.Enabled = False
            photographNameTextBoxTextBox.Enabled = False
            insertImageButton.Enabled = False
            nextLinkLabel.Enabled = False
            previousLinkLabel.Enabled = False

        End Try

    End Sub

    ''' <summary>
    ''' The getImages_Click event calls the ResetDisplay to remove previous data on the 
    ''' form and then calls the ShowImage method to display the new data on the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub getImagesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getImagesButton.Click
        Try
            ResetDisplay()
            ShowImage()
        Catch ex As Exception
            MessageBox.Show("There was an error displaying the images.  Please try again.", "Alert")
        End Try
    End Sub

    ''' <summary>
    ''' This method retrieves the data from the database using 
    ''' the CategoryID,  This will bring back a DataSet of images that
    ''' are all related by Category.  The proper information can also be 
    ''' shown.  The data from the image field is assigned to a byte array which
    ''' is read into a MemoryStream object and converted into a new BitMap.  This new
    ''' BitMap is then assigned to the PictureBox control.
    ''' </summary>
    Private Sub ShowImage()

        Try

        '' create a new adapter object
            Dim myAdapter As CategoriesTableAdapter = New CategoriesTableAdapter()

            '' get the CategoryID used to retrieve the images
            Dim myCategoryID As Integer = Convert.ToInt32(categoriesComboBox.SelectedValue)

            '' DataSet of image information
            myPhotoDataSet = myAdapter.getImages(myCategoryID)

            '' Set the Next Link Label
            SetNextLabel()

            If myPhotoDataSet.Tables(0).Rows.Count > 0 Then

                '' Display the name of the photograph that was stored
                photographNameLabel.Text = myPhotoDataSet.Tables(0).Rows(currentPage).Item("Name").ToString()

                '' Get the image data and stored it in a byte array
                Dim myByteArray() As Byte = myPhotoDataSet.Tables(0).Rows(currentPage).Item("Photograph")

                If myByteArray.Length > 0 Then

                    '' Create a new MemoryStream and write all the information from
                    '' the byte array into the stream
                    Dim myStream As MemoryStream = New MemoryStream(myByteArray, True)
                    myStream.Write(myByteArray, 0, myByteArray.Length)

                    '' Use the MemoryStream to create the new BitMap object
                    Dim FinalImage As Bitmap = New Bitmap(myStream)

                    '' See if the image stored will fit in the picture box. If it's too big, 
                    '' resize and create a new BitMap object and assign to the PictureBox control
                    If FinalImage.Width > 217 And FinalImage.Height > 151 Then

                        Dim AlteredImage As Bitmap = New Bitmap(FinalImage, New Size(217, 151))
                        photographPictureBox.Image = AlteredImage

                    Else
                        photographPictureBox.Image = FinalImage
                    End If
                    '' Close the stream
                    myStream.Close()
                End If


            Else
                MessageBox.Show("There are no photographs in this category yet!", "Alert")
            End If
        Catch ex As Exception
            MessageBox.Show("There was an error displaying this image.", "Alert")
        End Try

    End Sub

#Region "Helper functions"

    ''' <summary>
    ''' This event increases the current page and displays the next image
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub nextLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles nextLinkLabel.LinkClicked

        currentPage = currentPage + 1
        ShowImage()
        previousLinkLabel.Visible = True
    End Sub

    ''' <summary>
    ''' This method determines whether or not the next label should be displayed
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetNextLabel()

        If myPhotoDataSet.Tables(0).Rows.Count > 0 Then
            If myPhotoDataSet.Tables(0).Rows.Count > 1 Then

                nextLinkLabel.Visible = True
            Else
                nextLinkLabel.Visible = False
            End If

            If myPhotoDataSet.Tables(0).Rows.Count = (currentPage + 1) Then
                nextLinkLabel.Visible = False
            End If


        End If
    End Sub

    ''' <summary>
    ''' This event updates the currrent page and then displays the previous image
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub previousLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles previousLinkLabel.LinkClicked

        currentPage = currentPage - 1
        ShowImage()
        If currentPage = 0 Then
            previousLinkLabel.Visible = False
        End If
        If Not (myPhotoDataSet.Tables(0).Rows.Count = (currentPage + 1)) Then
            nextLinkLabel.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' This method reinitiates the controls on the form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetDisplay()

        photographPictureBox.Image = Nothing
        photographNameLabel.Text = "Photograph Name"
        currentPage = 0
        previousLinkLabel.Visible = False
        nextLinkLabel.Visible = False
        photographNameTextBoxTextBox.Text = ""
        imageNameTextBox.Text = ""

    End Sub

#End Region

End Class
