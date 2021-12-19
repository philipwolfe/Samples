
' ==============================================================================
' Filename: Account.vbp
'
' Summary:  Visual Basic implememtation of the create table class for the bank sample
' Classes:  CreateTable.cls
'
' This file is part of the Microsoft COM+ Samples
'
' Copyright (C) 1995-1999 Microsoft Corporation. All rights reserved
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information reagrding Microsoft code samples.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'

'

imports System
imports ADODB
imports Microsoft.ComServices
imports Microsoft.VisualBasic
imports System.Runtime.InteropServices

namespace VB7Bank

	public class <GuidAttribute("869DD7AE-62B6-45ed-B999-0702A7702B29"), _
				  ComEmulateAttribute("VB7Bank.CreateTableOrig"), _
				  TransactionAttribute(TransactionOption.RequiresNew)> _
				  CreateTable
	end class

	public interface ICreateTable
		sub CreateAccount()
		sub CreateReceipt()
	end interface


	public class <ComVisible(false)> CreateTableOrig
				implements ICreateTable

		private const strConnect = "FILEDSN=BankSample"

		' F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		'
		' Function: CreateAccount
		'
		' This function creates the Account table
		'
		' Args:     None
		' Returns:  None
		'
		' F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public sub CreateAccount()	implements ICreateTable.CreateAccount

			try
				dim adoConn as __Connection
				dim strSQL as String
				dim varRows as Object
				varRows = new Object()

				adoConn = new __Connection
				adoConn.Open(strConnect)

				' Add Account Table
				strSQL = "If not exists (Select name from sysobjects where name = 'Account')" & ControlChars.CrLf & _
						 "BEGIN" & ControlChars.CrLf & _
						 "CREATE TABLE Account (" & ControlChars.CrLf & _
							"AccountNo int NOT NULL ," & ControlChars.CrLf & _
							"Balance int NULL ," & ControlChars.CrLf & _
							"CONSTRAINT PK___1__10 PRIMARY KEY  CLUSTERED" & ControlChars.CrLf & _
							"(" & ControlChars.CrLf & _
								"AccountNo" & ControlChars.CrLf & _
							")" & ControlChars.CrLf & _
						 ")" & ControlChars.CrLf & _
						 "INSERT INTO Account VALUES (1,1000)" & ControlChars.CrLf & _
						 "INSERT INTO Account VALUES (2,1000)" & ControlChars.CrLf & _
						 "END" & ControlChars.CrLf

				adoConn.Execute(strSQL, varRows, 128)

			catch e as Exception
				throw new Exception ("Bank.CreateTable.CreateAccount" + e.ToString())

			end try

		end sub


		' F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		'
		' Function: CreateReceipt
		'
		' This function creates the Receipt Table
		'
		' Args:     None
		' Returns:  None
		'
		' F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public sub CreateReceipt()	implements ICreateTable.CreateReceipt

			try
				dim adoConn As __Connection
				dim strSQL As String
				dim varRows as Object

				varRows = new Object()
				adoConn = New __Connection
				adoConn.Open(strConnect)

				' Add Receipt Table
				strSQL = strSQL & _
						"If not exists (Select name from sysobjects where name = 'Receipt')" & ControlChars.CrLf & _
						"BEGIN" & ControlChars.CrLf & _
						"CREATE TABLE Receipt (NextReceipt int)" & ControlChars.CrLf & _
						"INSERT INTO Receipt VALUES (1000)" & ControlChars.CrLf & _
						"END"

				adoConn.Execute(strSQL, varRows, 128)

			catch e as Exception
				throw new Exception ("Bank.CreateTable.CreateAccount" + e.ToString())

			end try
		end sub

	end class

end namespace