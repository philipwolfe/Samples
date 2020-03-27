// This is the main project file for VC++ application project 
// generated using an Application Wizard.
//

#include "stdafx.h"

#using <mscorlib.dll>

#define NULL (void*)0

// Add access to .NET Framework classes.
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Data::OleDb;

int main(void)
{
	OleDbConnection* connection;	// ADO connection.
	OleDbCommand* command;			// ADO command
	OleDbDataReader* dataReader;	// ADO data reader

	try
	{
		// Create connection, set connection string and open connection to
		// specified database.
		connection = new OleDbConnection();
		connection->set_ConnectionString(S"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Data\\grocertogo.mdb;Persist Security Info=False");
		
		connection->Open();

		// Create command and get data reader by executing this command.
		command = new OleDbCommand(S"SELECT ProductName, UnitPrice FROM Products", connection);
		dataReader = command->ExecuteReader();

		// Print table header
		Console::WriteLine(S"_____________________________________");
		Console::WriteLine(S"Product                       | Price");
		Console::WriteLine(S"_____________________________________");

		// Iterate through rows set and print data.
		while(dataReader->Read())
			Console::WriteLine(S"{0, -30}| {1}", dataReader->get_Item("ProductName"), dataReader->get_Item("UnitPrice"));

		// Print table footer.
		Console::WriteLine(S"_____________________________________");


		// Close DataReader
		dataReader->Close();
		// Close connection.
		connection->Close();
	}
	catch(Exception* e)
	{
		// Print error message and close connection.
		Console::WriteLine("Error occured: {0}", e->Message);
		if (dataReader && !dataReader->IsClosed) 
			dataReader->Close();
		if (connection->State == ConnectionState::Open) 
			connection->Close();
	}

    return 0;
}