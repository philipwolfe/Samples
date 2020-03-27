using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Data;

namespace DataReaderDataSet.TestDataDataSetTableAdapters
{
	public partial class IntegerDataTableAdapter
	{
			/// <summary>
			/// This method retrieves the data and puts it into the DataReader object, the DataReader
			/// object is then returned.  The DataReader is created using the CloseConnection option 
			/// otherwise, the Connection must remain open while the data is being accessed from a 
			/// DataReader
			/// </summary>
			/// <param name="dataType"></param>
			/// <param name="rows"></param>
			/// <returns></returns>
			public SqlDataReader retrieveData(string dataType, int rows)
			{
                // create the SqlDataReader
				SqlDataReader myReader;
				// create the SqlCommand
				SqlCommand command = new SqlCommand();
				
				string myQuery = "";

				// create the query strings
				if (dataType == "strings")
					myQuery = "SELECT TOP " + rows + " * FROM StringData ORDER BY value1";
				else
					myQuery = "SELECT TOP " + rows + " * FROM IntegerData ORDER BY value1";

                try
                {
                    // set the command text
                    command.CommandText = myQuery;
                    // set the connection
                    command.Connection = this.Connection;
                    // open the connection
                    command.Connection.Open();
                    // set the data reader
                    myReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
				finally { }

				return myReader;
			}

		/// <summary>
		/// This method retrieves the data and puts it into the dataset object. The result of this method
		/// is a bi-directional, read/write DataSet object.  Although its performance is lower than the DataReader,
		/// it still provides a number of functions that are unavailable to the DataReader object.
		/// </summary>
		/// <param name="dataType"></param>
		/// <param name="rows"></param>
		/// <returns></returns>
		public DataSet retrieveDataSet(string dataType, int rows)
		{
			// create the query string
			string myQuery = "";
			// create the dataset object
			DataSet myDataSet = new DataSet();
			// create the DataAdapter
			SqlDataAdapter myDataAdapter;
			// create the SqlCommand
			SqlCommand command = new SqlCommand();
			// set the connection 
			command.Connection = this.Connection;
			// open the connection
			command.Connection.Open();
				
			// set the query string
			if (dataType == "strings")
				myQuery = "SELECT TOP " + rows + " * FROM StringData ORDER BY value1";
			else
				myQuery = "SELECT TOP " + rows + " * FROM IntegerData ORDER BY value1";

            try
            {
                // set the command text
                command.CommandText = myQuery;
                // set the data adapter
                myDataAdapter = new SqlDataAdapter(command);
                // fill the dataset
                myDataAdapter.Fill(myDataSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }

			finally
			{
				// close the connection
				command.Connection.Close();
			}
			return myDataSet;
		}

	}

}
	

