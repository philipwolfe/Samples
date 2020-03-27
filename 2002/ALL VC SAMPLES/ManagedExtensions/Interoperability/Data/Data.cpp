#using <mscorlib.dll>
using namespace System;

#using "System.dll"
#using "System.Data.dll"

using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Data::SqlClient;

void main()
{
	// Query user for user id and password
	Console::Write(S"Enter User ID for Northwind Database :");
	String *userId = Console::ReadLine();
	Console::Write(S"Enter password : ");
	String *password = Console::ReadLine();	

	// Connect to the SQL Database and issue a SELECT command all in one statement
	String *query = S"SELECT * FROM Categories";
	// build connect string with the userid and password
	String *connectString = String::Format(S"Data Source=localhost;Database=Northwind;UID={0};Password={1};", userId, password);

	//You can use this format if you are connecting with a known user name and password,
	// however it is not recommended to store these in the source for security reasons
	//String *connectString =  S"Data Source=localhost;Database=Northwind;UID=sa;Password=;";

	SqlConnection* sqlconn = new SqlConnection(connectString);
	sqlconn->Open();
	SqlCommand *sqlCommand = new SqlCommand(query, sqlconn);

	// Create a SqlDataReader to enumerate the result of executing the command against the database.
	SqlDataReader *dataReader = sqlCommand->ExecuteReader();

	// Find number of columns in result
	int numCols = dataReader->FieldCount;

	// Display number of columns returned from query
	Console::Write(S"No. of columns:");
	Console::WriteLine(numCols);

	// Display the data, separated by tabs
	while(dataReader->Read())
	{
		for (int c = 0; c < numCols; c++)
		{
			Console::Write(dataReader->Item[c]->ToString());
			Console::Write(S"\t");
		}
		Console::WriteLine(S"");
	}
}