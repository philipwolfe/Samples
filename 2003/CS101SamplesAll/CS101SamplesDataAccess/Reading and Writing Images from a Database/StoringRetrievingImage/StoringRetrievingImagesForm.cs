#region Using Statements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using StoringRetrievingImage.MyImagesDataSetTableAdapters;

#endregion


namespace StoringRetrievingImage
{
	
	public partial class StoringRetrievingImagesForm : Form
	{
		// Keep track of the photograph dataset that is used to display the images.
		DataSet myPhotoDataSet = null;
		int currentPage = 0;

		public StoringRetrievingImagesForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// This event opens an OpenFileDialog so you can browse for 
		/// the image you want to upload. The filename textbox is then
		/// filled for when the image is uploaded.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void browseImageButton_Click(object sender, EventArgs e)
		{
            browseImageOpenFileDialog.Title = "Select an Image to Import";
            browseImageOpenFileDialog.Multiselect = false;
            browseImageOpenFileDialog.Filter = "JPEG Compressed Image(*.jpg)|*.jpg|Graphic Interchange Format (*.gif)|*.gif";
            browseImageOpenFileDialog.FilterIndex = 2;
            browseImageOpenFileDialog.FileName = "";
            browseImageOpenFileDialog.ShowDialog();
            
			imageNameTextBox.Text = browseImageOpenFileDialog.FileName;
		}

		/// <summary>
		/// This event prepares all the fields that we want to insert into the database.
		/// The photograph name and CategoryID are retrieved from their respective controls.
		/// The image data is first selected from the image file name text box.  The file is then opened
		/// and saved into a FileStream object.  This stream is then saved into a byte array which
		/// will be stored in the image data type.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void insertImageButton_Click(object sender, EventArgs e)
		{
            
            try
            {
                string myMessage;
                int myCategoryID = 0;
                if (imageNameTextBox.Text == "")
                    MessageBox.Show("Please Enter a File Name.", "Alert");
                else
                {
                    CategoriesTableAdapter myAdapter = new CategoriesTableAdapter();

                    browseImageOpenFileDialog.FileName = imageNameTextBox.Text;

                    foreach (string myFile in browseImageOpenFileDialog.FileNames)
                    {
                        // make sure the file is JPEG or GIF
                        System.IO.FileInfo testFile = new System.IO.FileInfo(myFile);
                        if (String.Compare(testFile.Extension, ".GIF", true) != 0 && String.Compare(testFile.Extension, ".JPG", true) != 0)
                        {
                            MessageBox.Show("This file type is not supported. Must be GIF or JPG. Please try again.","Alert");
                            continue;
                        }
                                                  
                        // Create a new stream to load this photo into
                        FileStream myStream = new FileStream(myFile,
                                                  FileMode.Open,
                                                  FileAccess.Read);

                        // Create a buffer to hold the stream of bytes
                        byte[] myImageBuffer = new byte[myStream.Length];
                        // Read the bytes from this stream and put it into the image buffer
                        myStream.Read(myImageBuffer, 0, (int)myStream.Length);
                        // Close the stream
                        myStream.Close();

                        // get the photograph name
                        string myPhotographName = photographNameTextBoxTextBox.Text;

                        // get the CategoryID
                        myCategoryID = Convert.ToInt32(categoriesComboBox.SelectedValue);

                        try
                        {
                            // Call the insertNewImage method passing the property parameters
                            myMessage = myAdapter.insertNewImage(myCategoryID, myPhotographName, ref myImageBuffer);
                            MessageBox.Show(myMessage, "Information");
                        }
                        catch
                        {
                            MessageBox.Show("There was an error inserting the image.  Please try again.","Alert");
                        }


                        myImageBuffer = null;
                    }

                    ResetDisplay();
                }
            }
            catch
            {
                MessageBox.Show("There was error inserting the image.  Please try again.", "Alert");
            }
		}

		/// <summary>
		/// In the Load event, the Category combobox is initialized,
		/// and the Previous and Next LinkLabels are set to not visible
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StoringRetrievingImagesForm_Load(object sender, EventArgs e)
		{
            try
            {
                CategoriesTableAdapter myAdapter = new CategoriesTableAdapter();
                DataSet myDataSet = null;
                myDataSet = myAdapter.getCategories();
                categoriesComboBox.DataSource = myDataSet.Tables[0];
                categoriesComboBox.DisplayMember = "CategoryName";
                categoriesComboBox.ValueMember = "CategoryID";

                nextLinkLabel.Visible = false;
                previousLinkLabel.Visible = false;
            }
            catch
            {
                MessageBox.Show("There was an error starting this application. Please restart.", "Alert");
                getImagesButton.Enabled = false;
                browseImageButton.Enabled = false;
                categoriesComboBox.Enabled = false;
                imageNameTextBox.Enabled = false;
                photographNameTextBoxTextBox.Enabled = false;
                insertImageButton.Enabled = false;
                nextLinkLabel.Enabled = false;
                previousLinkLabel.Enabled = false;
            }
		}

		/// <summary>
		/// The getImages_Click event calls the ResetDisplay to remove previous data on the 
		/// form and then calls the ShowImage method to display the new data on the form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void getImagesButton_Click(object sender, EventArgs e)
		{
            try
            {
                ResetDisplay();
                ShowImage();
            }
            catch
            {
                MessageBox.Show("There was an error displaying the images.  Please try again.","Alert");
            }
		}

		/// <summary>
		/// This method retrieves the data from the database using 
		/// the CategoryID,  This will bring back a DataSet of images that
		/// are all related by Category.  The proper information can also be 
		/// shown.  The data from the image field is assigned to a byte array which
		/// is read into a MemoryStream object and converted into a new BitMap.  This new
		/// BitMap is then assigned to the PictureBox control.
		/// </summary>
		private void ShowImage()
		{
            try
            {
                // create a new adapter object
                CategoriesTableAdapter myAdapter = new CategoriesTableAdapter();

                // get the CategoryID used to retrieve the images
                int myCategoryID = Convert.ToInt32(categoriesComboBox.SelectedValue);

                // DataSet of image information
                myPhotoDataSet = myAdapter.getImages(myCategoryID);

                // Set the Next Link Label
                SetNextLabel();

                if (myPhotoDataSet.Tables[0].Rows.Count > 0)
                {
                    // Display the name of the photograph that was stored
                    photographNameLabel.Text = myPhotoDataSet.Tables[0].Rows[currentPage]["Name"].ToString();

                    // Get the image data and stored it in a byte array
                    byte[] myByteArray = (byte[])myPhotoDataSet.Tables[0].Rows[currentPage]["Photograph"];

                    if (myByteArray.Length > 0)
                    {
                        // Create a new MemoryStream and write all the information from
                        // the byte array into the stream
                        MemoryStream myStream = new MemoryStream(myByteArray, true);
                        myStream.Write(myByteArray, 0, myByteArray.Length);

                        // Use the MemoryStream to create the new BitMap object
                        Bitmap FinalImage = new Bitmap(myStream);

                        // See if the image stored will fit in the picture box. If it's too big, 
                        // resize and create a new BitMap object and assign to the PictureBox control
                        if (FinalImage.Width > 217 && FinalImage.Height > 151)
                        {
                            Bitmap AlteredImage = new Bitmap(FinalImage, new Size(217, 151));
                            photographPictureBox.Image = AlteredImage;
                        }
                        else
                            photographPictureBox.Image = FinalImage;

                        // Close the stream
                        myStream.Close();
                    }
                }
                else
                {
                    MessageBox.Show("There are no photographs in this category yet!", "Alert");
                }
            }
            catch
            {
                MessageBox.Show("There was an error displaying this image.", "Alert");
            }
		}

		#region Helper functions

        /// <summary>
        /// This event increases the current page and displays the next image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void nextLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			currentPage++;
			ShowImage();
			previousLinkLabel.Visible = true;
		}

	/// <summary>
    /// This method determines whether or not the next label should be displayed
    /// </summary>
    /// <remarks></remarks>
    	private void SetNextLabel()
		{
			if (myPhotoDataSet != null)
			{
				if (myPhotoDataSet.Tables[0].Rows.Count > 1)
				{
					nextLinkLabel.Visible = true;
				}
			}
			else
				nextLinkLabel.Visible = false;

			if (myPhotoDataSet.Tables[0].Rows.Count == (currentPage + 1))
				nextLinkLabel.Visible = false;
		}

    /// <summary>
    /// This event updates the currrent page and then displays the previous image
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks></remarks>
        private void previousLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			currentPage--;
			ShowImage();
			if(currentPage == 0)
			previousLinkLabel.Visible = false;
		if (myPhotoDataSet.Tables[0].Rows.Count != (currentPage + 1))
			nextLinkLabel.Visible = true;
		}

	/// <summary>
    /// This method reinitiates the controls on the form.
    /// </summary>
        /// <remarks></remarks>
    	private void ResetDisplay()
		{
			photographPictureBox.Image = null;
			photographNameLabel.Text = "Photograph Name";
			currentPage = 0;
			previousLinkLabel.Visible = false;
			nextLinkLabel.Visible = false;
			photographNameTextBoxTextBox.Text = "";
			imageNameTextBox.Text = "";

		}

		#endregion
	}
}