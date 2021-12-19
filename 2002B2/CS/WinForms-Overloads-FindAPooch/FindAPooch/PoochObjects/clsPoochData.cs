using System;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace Pooch
{
	/// <summary>
	/// Summary description for clsPoochData.
	/// </summary>
	public class clsPoochData
	{
		public clsPoochData()
		{
			//
			// TODO: Add constructor logic here
			//
			cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Environment.CurrentDirectory + "\\FindAPooch.mdb");

		}

		//This object will be used for connecting to the DB
		private OleDbConnection cn;

		//The Browse method for getting all the pooches.
		public DataSet BrowseByBreed()
		{
			return this.GetAllBreeds();
		}

		//Browse method to return all the pooches or by particular breed
		public DataSet BrowseByBreed(long lngBreed)
		{
			if (lngBreed > 0)
			{
				return this.GetByBreed(lngBreed);
			}
			else
			{
				return this.GetAll();
			}
		}

	//Method to return all pooches by City
	public DataSet BrowseByCity(string strCity)
	{
		return this.GetByCity(strCity);
	}

	//Method to return all pooches By City and Breed
	public DataSet BrowseByCity(string strCity, long lngBreed)
	{
		return this.GetByCityBreed(strCity, lngBreed);
	}
        
	//Method to return all pooches by State
	public DataSet BrowseByState(string strState)
	{	
		return this.GetByState(strState);            
	}
        
	//Method to return all pooches by State and City
	public DataSet BrowseByState(string strState, string strCity)
	{
		return this.GetByStateCity(strState, strCity);
	}
        
	//Method to return all pooches by State and Breed
	public DataSet BrowseByState(string strState , long lngBreed )
	{
		return this.GetByStateBreed(strState, lngBreed);
	}

	//Method to return all pooches by State, City, and Breed
	public DataSet BrowseByState(string strState, string strCity, long lngBreed)
	{
		return this.GetByStateCityBreed(strState, strCity, lngBreed);
	}
        
        
	//Method to Return all Breeds in DB
	private DataSet GetAllBreeds()
	{
		DataSet dsBreeds;
		OleDbDataAdapter dsCmd;
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT DISTINCT breedid,breeddesc FROM breeds ORDER BY breedid";

		//Create a new dataset object.
		dsBreeds = new DataSet();
		//Create a new OleDbDataAdapter object
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		//Populate the dataset.
		dsCmd.Fill(dsBreeds, "breeds");

		return dsBreeds;
	}

	//Internal method for getting all the pooches from the DB.
	private DataSet GetAll()
	{
		DataSet dsDogs;
		OleDbDataAdapter dsCmd;
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT dogs.Name,dogs.City,dogs.State,breeds.breeddesc AS Breeds FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid";

		dsDogs = new DataSet();
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		dsCmd.Fill(dsDogs, "dogs");

		return dsDogs;
	}
        
	//Internal method for getting pooches by state from the DB.
	private DataSet GetByState(string strState)
	{
		DataSet dsDogs;
		OleDbDataAdapter dsCmd;
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE state = '" + strState + "'";

		dsDogs = new DataSet();
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		dsCmd.Fill(dsDogs, "dogs");
	            
		return dsDogs;
	}
        
	//Internal method for getting pooches by breed from the DB.
	private DataSet GetByBreed(long lngBreed)
	{
		DataSet dsDogs;
		OleDbDataAdapter dsCmd;
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE breeds.breedid = " + lngBreed;

		dsDogs = new DataSet();
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		dsCmd.Fill(dsDogs, "dogs");

		return dsDogs;            
	}
        
	//Internal method for getting pooches by city and state from the DB.
	private DataSet GetByStateCity(string strState, string strCity)
	{
		DataSet dsDogs;
		OleDbDataAdapter dsCmd; 
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE city = '" + strCity + "' and state = '" + strState + "'";

		dsDogs = new DataSet();
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		dsCmd.Fill(dsDogs, "dogs");
	            
		return dsDogs;            
	}
        
	//Internal method for getting pooches by city, state and breed from the DB.
	private DataSet GetByStateCityBreed(string strState, string strCity , long lngBreed)
	{
		DataSet dsDogs;
		OleDbDataAdapter dsCmd;
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE city = '" + strCity + "' and state = '" + strState + "' and breeds.breedid = " +lngBreed;

		dsDogs = new DataSet();
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		dsCmd.Fill(dsDogs, "dogs");

		return dsDogs;
	}

	//Internal method for getting pooches by state and breed from the DB.
	private DataSet GetByStateBreed(string strState, long lngBreed)
	{
		DataSet dsDogs;
		OleDbDataAdapter dsCmd;
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT Name,City,State,breeds.breeddesc As Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE state = '" + strState + "' and breeds.breedid = " + lngBreed;

		dsDogs = new DataSet();
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		dsCmd.Fill(dsDogs, "dogs");

		return dsDogs;            
	}
	//Internal method for getting pooches by city from the DB.
	private DataSet GetByCity(string strCity)
	{
		DataSet dsDogs;
		OleDbDataAdapter dsCmd;
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE City = '" + strCity + "'";

		dsDogs = new DataSet();
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		dsCmd.Fill(dsDogs, "dogs");
	            
		return dsDogs;            
	}
        
	//Internal method for getting pooches by Breed and City
	private DataSet GetByCityBreed(string strCity, long lngBreed)
	{
		DataSet dsDogs;
		OleDbDataAdapter dsCmd;
		//DataRow dsRow;
		string strSQL;

		strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE City = '" + strCity + "' and breeds.breedid = " + lngBreed;

		dsDogs = new DataSet();
		dsCmd = new OleDbDataAdapter(strSQL, cn);
		dsCmd.Fill(dsDogs, "dogs");

		return dsDogs;
	}

}
}
