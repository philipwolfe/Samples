using System;
using System.IO;
using System.NewXml;
using System.Data;
using System.Data.SQL;

namespace PDC.ADOPlus
{
	public class Demo1
	{ 
		public static void Main(string[] args)
		{
			Console.WriteLine("Starting...");
			Demo1Routines sample = new Demo1Routines();

			Console.WriteLine("Getting a Connection...");
			SQLConnection connect = sample.DoConnect();

			Console.WriteLine("Executing the Command...");
			SQLCommand cmd = sample.DoCommand(connect);

			Console.WriteLine("Results from DataReader:");
			sample.DoGetData(cmd);

			Console.WriteLine("Building a DataSet...");
			DataSet ds = sample.DoDataSet();

			Console.WriteLine("Updating from the DataSet...");
			SQLDataSetCommand dsc = sample.DoDataSetCommand(ds,connect);

			Console.WriteLine("Results from XML:");
			sample.DoXml(ds);

			Console.WriteLine("Restoring original data...");
			sample.RestoreData(ds,dsc);

			Console.WriteLine("Done!");
		}
	}

	public class Demo1Routines
	{
		public SQLConnection DoConnect()
		{
			// Create an instance of an SQLConnection object
			SQLConnection cnn = new SQLConnection();

			// Set the connection string
			cnn.ConnectionString = "server=localhost;uid=sa;database=pubs";

			//Open the Connection
			cnn.Open();

			return cnn;
		}

		public SQLCommand DoCommand(SQLConnection cnn)
		{
			// Create Command
			SQLCommand cmd = new SQLCommand();

			// Set command's active connection and command text
			cmd.ActiveConnection = cnn;
			cmd.CommandText = "Select au_lname from authors where state = @param1";

			// Create parameter and set value
			cmd.Parameters.Add( 
				new SQLParameter("@param1", System.Type.GetType("System.String"),2) );
			cmd.Parameters["@param1"].Value = "CA";

			return cmd;
		}

		public void DoGetData(SQLCommand cmd)
		{
			// Define DataReader
			IDataReader dr;

			// Execute Command and retrieve results
			cmd.Execute(out dr);

			while(dr.Read())
			{
				Console.WriteLine("Name = " + dr["au_lname"]);
			}
			dr.Close();
		}

		public DataSet DoDataSet()
		{
			// Create a "Pubs" DataSet
			DataSet pubs = new DataSet("Pubs");

			//Create an "Inventory" Table
			DataTable inventory = new DataTable("Inventory");
			inventory.Columns.Add("TitleID",System.Type.GetType("System.Int32"));
			inventory.Columns.Add("Quantity",System.Type.GetType("System.Int32"));

			// Add Inventory table to Pubs DataSet
			pubs.Tables.Add(inventory);

			// Add a record to the Inventory table
			DataRow row = inventory.NewRow();
			row["TitleID"]=1;
			row["Quantity"]=25;
			inventory.Rows.Add(row);

			return pubs;
		}

		public SQLDataSetCommand DoDataSetCommand(DataSet pubs, SQLConnection cnn)
		{
			// Create a DataSetCommand
			SQLDataSetCommand dataSetCommand = new SQLDataSetCommand(
					"Select * from authors",
					cnn);
 
			dataSetCommand.FillDataSet(pubs, "Authors");
 
			// make some changes to the customer data in the dataset
 
			pubs.Tables["Authors"].Rows[0]["au_lname"]="NewAuthor";
			dataSetCommand.Update(pubs, "Authors");

			return dataSetCommand;
		}

		public void DoXml(DataSet pubs)
		{
    			XmlDataDocument xmlDocument = new XmlDataDocument(pubs);
        		DataDocumentNavigator xmlNavigator = new DataDocumentNavigator(xmlDocument);

        		// Get all the authors from CA
        		xmlNavigator.Select("//Authors[string(state)='CA']/au_lname");

			while(xmlNavigator.MoveToNextSelected())
			{
				Console.WriteLine("Name = " + xmlNavigator.InnerText);

			}

 		}


		public void RestoreData(DataSet pubs, SQLDataSetCommand dataSetCommand)
		{
			pubs.Tables["Authors"].Rows[0]["au_lname"]="White";
			dataSetCommand.Update(pubs, "Authors");
		}
	}
}
