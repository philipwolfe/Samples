// ==============================================================================
// Filename: CreateTable.h
//
// Summary:  managed cpp definition of the CreateTable class for the bank sample
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



namespace VC7Bank
{
    public	__gc __interface	ICreateTable
	{
		void	CreateAccount();
		void	CreateReceipt();
	};


    [
    	ComEmulate("VC7Bank.CreateTableOrig"), 
	    GuidAttribute("CA40AF73-9F9A-4f4f-AFF8-108B86778430") //, 
//        TransactionAttribute(TransactionOption::RequiresNew)
    ]
	public __gc class CreateTable
	{
    public:
        CreateTable() {}
	};


    [
    	ComVisible(false)
    ]
	public __gc class CreateTableOrig: public ICreateTable
	{
    public:
        void	CreateAccount();
		void	CreateReceipt();
	};

}