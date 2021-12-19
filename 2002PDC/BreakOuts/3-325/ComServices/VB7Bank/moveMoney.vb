
' ==============================================================================
' Filename: Account.vbp
'
' Summary:  Visual Basic implememtation of the MoveMoney component for the bank sample
' Classes:  MoveMoney.cls
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
imports ACCOUNTCom
imports Microsoft.ComServices
imports Microsoft.VisualBasic
imports System.Runtime.InteropServices
option strict off

namespace VB7Bank

	public class <GuidAttribute("869DD7AE-62B6-45ed-B999-0702A7702B2A"), _
				  ComEmulateAttribute("VB7Bank.MoveMoneyOrig"), _
				  TransactionAttribute(TransactionOption.Required)> _
				  MoveMoney
	end class


	public class <ComVisible(false)> MoveMoneyOrig
				implements IMoveMoney

		public m_PrimeAccount as integer
		public m_SecondAccount as integer

		private const ERROR_NUMBER =  0
		private const APP_ERROR = -2147467008

		' F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		'
		' Function: Perform
		'
		' This function performs a bank transaction
		'
		' Args:     PrimeAccount -   "From" Account
		'           SecondAccount -  "To" Account
		'           Amount -         Amount of transaction
		'           TranType -       Transaction Type
		'                               (1 = Withdrawal,
		'                                2 = Deposit,
		'                                3 = Transfer)
		'
		' Returns:  String -        Account Balance
		'
		' F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public function perform(ByVal lngPrimeAccount As Integer, ByVal lngSecondAccount As Integer, ByVal lngAmount As Integer, ByVal TranType As Integer) As String Implements IMoveMoney.Perform

			dim strResult as String

			try

				' check for security
				if (lngAmount > 500 Or lngAmount < -500) then
					if not  ContextUtil.IsCallerInRole("Managers") then
						throw new Exception("Need 'Managers' role for amounts over $500")
					end if
				end if

				' create the account object using our context
				dim objAccount as IAccount
				objAccount = new Account()
				
				if objAccount is nothing then
					throw new Exception("Could not create account object")
				end if

				' call the post function based on the transaction type
				select case TranType
				case 1
					strResult = objAccount.Post(lngPrimeAccount, 0 - lngAmount)
					if strResult = "" then
						throw new Exception(strResult)
					end if

				case 2
					strResult = objAccount.Post(lngPrimeAccount, lngAmount)
					if strResult = "" then
						throw new Exception(strResult)
					end if

				case 3
					dim strResult1 As String
					dim strResult2 As String

					' do the credit
					strResult1 = objAccount.Post(lngSecondAccount, lngAmount)
					if strResult1 = "" then
						throw new Exception(strResult1)
					else
						' then do the debit
						strResult2 = objAccount.Post(lngPrimeAccount, 0 - lngAmount)
						if strResult2 = "" then
							throw new Exception(strResult2)
						else
							strResult = strResult1 + "  " + strResult2
						end if
					end if

				case else
					throw new Exception("Invalid Transaction Type")

				end select

				' Get Receipt Number for the transaction
				dim objReceiptNo As IGetReceipt
				objReceiptNo = new GetReceipt()

				dim intReceiptNo As integer
				intReceiptNo = objReceiptNo.GetNextReceipt
				if intReceiptNo > 0 then
					strResult = strResult & "; Receipt No: " & Str$(intReceiptNo)
				end if

				ContextUtil.SetComplete()                  ' we are finished and happy
				Perform = strResult
				exit function

			catch e as Exception
				ContextUtil.SetAbort()						' we are unhappy
				perform = ""								' indicate that an error occured
				throw new Exception("Bank.MoveMoney.Perform" + e.ToString())

			end try

		end Function


		' F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		'
		' Function: StatefulPerform
		'
		' This function performs a bank transaction using current state
		'
		' Args:     Amount -         Amount of transaction
		'           TranType -       Transaction Type
		'                               (1 = Withdrawal,
		'                                2 = Deposit,
		'                                3 = Transfer)
		'
		' Returns:  String -        Account Balance
		'
		' F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public function StatefulPerform(ByVal Amount As integer, ByVal TranType As integer) As String
		   StatefulPerform = Perform(m_PrimeAccount, m_SecondAccount, Amount, TranType)
		end function


		' F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		'
		' Function: PrimeAccount
		'
		' This function  s the Prime account state information
		'
		' Args:     second -    Account number
		' Returns:  None
		''
		' F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public sub PrimeAccount(ByVal prime As Long)
			m_PrimeAccount = prime
		end sub


		' F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
		'
		' Function: SecondAccount
		'
		' This function  s the Second account state information
		'
		' Args:     second -    Account number
		' Returns:  None
		'
		' F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
		public sub SecondAccount(ByVal second As Long)
			m_SecondAccount = second
		end sub

	end class

end namespace
