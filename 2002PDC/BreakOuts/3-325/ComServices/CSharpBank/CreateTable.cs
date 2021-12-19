namespace CSharpBank
{
    using System;
    using Microsoft.ComServices;
    using System.Runtime.InteropServices;
    using ACCOUNTCom;
    using ADODB;

	public	interface	ICreateTable
	{
		void	CreateAccount();
		void	CreateReceipt();
	}


    [
	ComEmulate("CSharpBank.CreateTableOrig"), 
	GuidAttribute("FD9A07BF-653A-45f3-97A1-FA721538F557"), 
	Transaction(TransactionOption.RequiresNew)
    ]
	public	class CreateTable
	{
	}


	internal class CreateTableOrig: ICreateTable
	{
		// F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		//
		// Function: CreateAccount
		//
		// This function creates the Account table
		//
		// Args:     None
		// Returns:  None
		//
		// F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public	void	CreateAccount()
		{
			try
			{
				_Connection adoConn = null;
				String vDSN = "FILEDSN=BankSample";
				String strSQL = "";
				String vbCrLf = "\n";
				Object  vRowCount = new Object();

                adoConn = (_Connection) new __Connection();
				adoConn.Open(vDSN, null, null, (int)CommandTypeEnum.adCmdUnspecified);
				strSQL = "If not exists (Select name from sysobjects where name = 'Account')" + vbCrLf + 
						 "BEGIN" + vbCrLf + "CREATE TABLE dbo.Account (" + vbCrLf +"AccountNo int NOT NULL ," +
						 vbCrLf + "Balance int NULL ," + vbCrLf + "CONSTRAINT PK___1__10 PRIMARY KEY  CLUSTERED" +
						 vbCrLf + "(" + vbCrLf + "AccountNo" + vbCrLf + ")" + vbCrLf + ")" + vbCrLf + 
						 "INSERT INTO Account VALUES (1,1000)" + vbCrLf + "INSERT INTO Account VALUES (2,1000)" + vbCrLf +
						 "END" + vbCrLf;
				adoConn.Execute(strSQL,  ref vRowCount, (int)ExecuteOptionEnum.adExecuteNoRecords);
				ContextUtil.SetComplete();
			}
			catch(Exception e)
			{

				ContextUtil.SetAbort();
				throw new Exception ("Error. Unable to create account table\n" + e);
			}
		}

		// F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		//
		// Function: CreateReceipt
		//
		// This function creates the Receipt Table
		//
		// Args:     None
		// Returns:  None
		//
		// F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public	void	CreateReceipt()
		{
			try
			{
				_Connection adoConn = null;
				String strSQL = "";
				String vDSN = "FILEDSN=BankSample";
				String vbCrLf = "\n";
				Object  vRowCount = new Object();

                adoConn = (_Connection) new __Connection();
				adoConn.Open(vDSN, null, null, (int)CommandTypeEnum.adCmdUnspecified);
				strSQL = strSQL + "If not exists (Select name from sysobjects where name = 'Receipt')" + vbCrLf +
								  "BEGIN" + vbCrLf + "CREATE TABLE Receipt (NextReceipt int)" + vbCrLf + 
								  "INSERT INTO Receipt VALUES (1000)" + vbCrLf + "END";
    			adoConn.Execute(strSQL, ref vRowCount, (int)ExecuteOptionEnum.adExecuteNoRecords);
  				ContextUtil.SetComplete();
			}
			catch(Exception e)
			{
				ContextUtil.SetAbort();
				throw new Exception ("Error. Unable to create account table\n" + e);
			}
		}
	}

}