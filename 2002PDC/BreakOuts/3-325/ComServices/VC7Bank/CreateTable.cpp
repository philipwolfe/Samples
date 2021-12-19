// ==============================================================================
// Filename: CreateTable.cpp
//
// Summary:  managed cpp implememtation of the CreateTable class for the bank sample
// Classes:  UpdateReceipt.cs
//
// This file is part of the Microsoft COM+ Samples
//
// Copyright (C) 1995-1999 Microsoft Corporation. All rights reserved
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information reagrding Microsoft code samples.
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//

// import mscorlib definitions
#using "mscorlib.dll"
using namespace System;
using namespace System::Runtime::InteropServices;

// import definitions for ComServices support
#using "Microsoft.ComServices.dll"
using namespace Microsoft::ComServices;

//import definitions for ADO
#using "adodb.dll"
using namespace ADODB;

// import definition for account typelibrary
#using "account.dll"
using namespace ACCOUNTCom;

#define null 0

#include "CreateTable.h" 

namespace VC7Bank
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
    void	CreateTableOrig::CreateAccount()
	{
		try
		{
			_Connection* adoConn = null;
			String* vDSN = "FILEDSN=BankSample";
			String* strSQL = "";
			String* vbCrLf = "\n";
			Object*  vRowCount = new Object();

            adoConn = dynamic_cast<_Connection __gc *>(new __Connection());
            adoConn->Open (vDSN, null, null, (int)CommandTypeEnum::adCmdUnspecified);

		    String* msg = String::Concat(S"If not exists (Select name from sysobjects where name = 'Account')\n", 
									     S"BEGIN\nCREATE TABLE dbo.Account (\nAccountNo int NOT NULL ,\n",
									     S"Balance int NULL ,\nCONSTRAINT PK___1__10 PRIMARY KEY  CLUSTERED\n",
									     S"(\nAccountNo\n)\n)\nINSERT INTO Account VALUES (1,1000)\nEND\n");
            adoConn->Execute(strSQL,  &vRowCount, (int)ExecuteOptionEnum::adExecuteNoRecords);
            ContextUtil::SetComplete();
		}
		catch(Exception* e)
		{

            ContextUtil::SetAbort();
            String* msg = String::Concat(S"Error. Unable to create account table\n", e->ToString());
			throw new Exception (msg);
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
    void	CreateTableOrig::CreateReceipt()
	{
		try
		{
			_Connection* adoConn = null;
			String* strSQL = "";
			String* vDSN = "FILEDSN=BankSample";
			String* vbCrLf = "\n";
			Object*  vRowCount = new Object();

            adoConn = dynamic_cast<_Connection __gc *>(new __Connection());
            adoConn->Open(vDSN, null, null, (int)CommandTypeEnum::adCmdUnspecified);

		    String* msg = String::Concat(S"If not exists (Select name from sysobjects where name = 'Receipt')\n", 
									     S"BEGIN\nCREATE TABLE Receipt (NextReceipt int)\nINSERT INTO Receipt VALUES (1000)\nEND");
            adoConn->Execute(strSQL, &vRowCount, (int)ExecuteOptionEnum::adExecuteNoRecords);
            ContextUtil::SetComplete();
		}
		catch(Exception* e)
		{
            ContextUtil::SetAbort();
            String* msg = String::Concat(S"Error. Unable to create account table\n", e->ToString());
			throw new Exception (msg);
		}
	}
}