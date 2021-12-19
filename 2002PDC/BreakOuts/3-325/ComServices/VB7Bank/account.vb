
' ==============================================================================
' Filename: Account.vbp
'
' Summary:  Visual Basic implememtation of the account class for the bank sample
' Classes:  Account.cls
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

imports System
imports Microsoft.ComServices
imports System.Runtime.InteropServices
imports ADODB
imports ACCOUNTCom
imports Microsoft.VisualBasic

option strict off


namespace VB7Bank

	public class <ComEmulateAttribute("VB7Bank.AccountOrig"), _
				  GuidAttribute("869DD7AE-62B6-45ed-B999-0702A7702B28"), _
				  TransactionAttribute(TransactionOption.Required)> _
				  Account
	end class

	public class <ComVisible(false)> AccountOrig
		implements IAccount

		private const strConnect = "FILEDSN=BankSample"


		' F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		'
		' Function: Post
		'
		' This function posts a banking transaction to an account
		'
		' Args:     lngAccount -    Account to be posted
		'           lngAmount -     Amount to be posted
		' Returns:  String -        Account Balance
		'
		' F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public  function Post(ByVal lngAccountNo As Integer, ByVal lngAmount As Integer) As String Implements IAccount.Post

			dim strResult as String
			dim adoRS as ADODB._RecordSet
			dim adoConn as ADODB.__Connection
			dim	bSuccess as boolean
			bSuccess = false

			try

				' check for security
				if (lngAmount > 500 or lngAmount < -500) then
					if not ContextUtil.IsCallerInRole("Managers") then
						throw new Exception("Need 'Managers' role for amounts over $500")
					end if
				end if

				dim varRows As Object
				dim strSQL As String
				varRows = new Object()
				adoConn = new __Connection()
				adoConn.Open(strConnect)

		TryAgain:
				try
				    strSQL = "UPDATE Account SET Balance = Balance + " & lngAmount & _
					         " WHERE AccountNo = " & lngAccountNo
					adoConn.Execute( strSQL, varRows, 128)

				catch e as exception
					dim ct As ICreateTable
					ct = new CreateTable
					ct.CreateAccount()
					goto TryAgain

				end try

				' get resulting balance which may have been further updated via triggers
				strSQL = "SELECT Balance FROM Account WHERE AccountNo = " & lngAccountNo
				adoRS = adoConn.Execute( strSQL, varRows, -1)


				dim intBalance as integer
				intBalance =  cint(adoRS.Fields("Balance").Value)

				' check if account is overdrawn
				if (intBalance) < 0 then
					throw new Exception("Error. Account " + Str$(lngAccountNo) + " would be overdrawn by " + Str$(intBalance) + ". Balance is still " + Str$(intBalance - lngAmount) + ".")
				else
					if lngAmount < 0 then
						strResult = strResult & "Debit from account " & lngAccountNo & ", "
					else
						strResult = strResult & "Credit to account " & lngAccountNo & ", "
					end if
					strResult = strResult + "balance is $" + intBalance.ToString() + " (VB7)"
				end if
				bSuccess = true

			finally
				if bSuccess then
					ContextUtil.SetComplete()
					post = strResult
				else
					ContextUtil.SetAbort()
					post = "Failed"
				end if
			end try

		end function

	end class

end namespace