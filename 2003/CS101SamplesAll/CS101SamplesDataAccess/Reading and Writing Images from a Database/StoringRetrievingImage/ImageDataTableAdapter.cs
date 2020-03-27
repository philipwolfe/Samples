#region Using Statements

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;

#endregion

namespace StoringRetrievingImage.MyImagesDataSetTableAdapters
{

	public partial class CategoriesTableAdapter
	{

		/// <summary>
		/// The insertNewImage method takes all the information about the image and stores it
		/// in the database.  This method accesses a stored procedure to insert the data and returns
		/// the success statement or error message.
		/// </summary>
		/// <param name="CategoryID"></param>
		/// <param name="photographName"></param>
		/// <param name="buffer"></param>
		/// <returns></returns>
		public string insertNewImage(int CategoryID, string photographName, ref byte[] myBuffer)
		{
			string message = "";
			SqlConnection myConnection;
			myConnection = Connection;

			try
			{
				myConnection.Open();
			
				// Create a stored procedure command
				SqlCommand myCommand = new SqlCommand("sp_InsertPhoto", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

				// Add the Name parameter and set the photographName as the value
                myCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = photographName;
				// Add the image parameter and set myBuffer as the value.
                myCommand.Parameters.Add("@image", SqlDbType.Image).Value = myBuffer;
				// Add the CategoryID parameter and set the CategoryID as the value
                myCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = CategoryID;

				// Execute the insert
                myCommand.ExecuteNonQuery();

				// Close the Connection
				myConnection.Close();

				// Assign the success message
				message = "Inserted Successfully!";
				
			}
			catch (Exception ex)
			{
				// Assign the error message
				message = ex.Message.ToString();
			}

			return message;
		}

		/// <summary>
		/// The getCategories method is a general method that returns a DataSet with Category
		/// information in it.
		/// </summary>
		/// <returns></returns>
		public DataSet getCategories()
		{
			SqlConnection myConnection;
			SqlCommand myCommand;
			string myQuery = "";
			DataSet myDataSet = new DataSet();
			SqlDataAdapter myAdapter;
			myConnection = Connection;

			try
			{
				myConnection.Open();
				myQuery = "SELECT * FROM Categories ORDER BY CategoryName";
				myCommand = new SqlCommand();
				myCommand.CommandText = myQuery;
				myCommand.Connection = myConnection;
				myAdapter = new SqlDataAdapter(myCommand);
				myAdapter.Fill(myDataSet);
				myConnection.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return myDataSet;
		}

		/// <summary>
		/// The getImages method accesses the database and return Image information
		/// based on the CategoryID that is passed in.
		/// </summary>
		/// <param name="CategoryID"></param>
		/// <returns></returns>
		public DataSet getImages(int CategoryID)
		{
			SqlConnection myConnection;
			SqlCommand myCommand;
			string myQuery = "";
			DataSet myDataSet = new DataSet();
			SqlDataAdapter myAdapter;
			myConnection = Connection;
			
			try
			{
				myConnection.Open();
				myQuery = "SELECT * FROM Photographs WHERE CategoryID = " + CategoryID;
				myCommand = new SqlCommand();
				myCommand.CommandText = myQuery;
				myCommand.Connection = myConnection;
				myAdapter = new SqlDataAdapter(myCommand);
				myAdapter.Fill(myDataSet);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return myDataSet;
		}


	}

}