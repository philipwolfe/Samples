// Contacts.h : Declaration of the CContacts
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

// code generated on Wednesday, April 18, 2001, 8:01 PM

[
	db_command(L" \
	SELECT \
		Birthday, \
		BusinessCity, \
		BusinessCountry, \
		BusinessFax, \
		BusinessPhone, \
		BusinessPostalCode, \
		BusinessState, \
		BusinessStreet, \
		Company, \
		ContactID, \
		Department, \
		EmailAddress, \
		FirstName, \
		HomeCity, \
		HomeCountry, \
		HomeFax, \
		HomePhone, \
		HomePostalCode, \
		HomeState, \
		HomeStreet, \
		JobTitle, \
		LastName, \
		MiddleName, \
		MobilePhone, \
		OtherPhone, \
		Suffix, \
		Title, \
		UserID, \
		WebPage \
		FROM Contacts WHERE UserID=? AND ContactID=?")
]
class CSelectContact
{
public:



	// In order to fix several issues with some providers, the code below may bind
	// columns in a different order than reported by the provider

	[ db_column(1)] TCHAR m_Birthday[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(2)] TCHAR m_BusinessCity[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(3) ] TCHAR m_BusinessCountry[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(4) ] TCHAR m_BusinessFax[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(5) ] TCHAR m_BusinessPhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(6) ] TCHAR m_BusinessPostalCode[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(7) ] TCHAR m_BusinessState[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(8) ] TCHAR m_BusinessStreet[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(9) ] TCHAR m_Company[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(10) ] LONG m_ContactID;
	[ db_column(11) ] TCHAR m_Department[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(12) ] TCHAR m_EmailAddress[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(13) ] TCHAR m_FirstName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(14) ] TCHAR m_HomeCity[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(15) ] TCHAR m_HomeCountry[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(16) ] TCHAR m_HomeFax[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(17) ] TCHAR m_HomePhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(18) ] TCHAR m_HomePostalCode[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(19) ] TCHAR m_HomeState[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(20) ] TCHAR m_HomeStreet[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(21) ] TCHAR m_JobTitle[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(22) ] TCHAR m_LastName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(23) ] TCHAR m_MiddleName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(24) ] TCHAR m_MobilePhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(25) ] TCHAR m_OtherPhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(26) ] TCHAR m_Suffix[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(27) ] TCHAR m_Title[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(28) ] LONG m_UserID;
	[ db_column(29) ] TCHAR m_WebPage[DB_MAX_CONTACT_FIELDLEN + 1];

	[ db_param(1) ]  LONG m_lUserID;
	[ db_param(2) ]  LONG m_lContactID;

};

[
	db_command(L" \
	SELECT \
		Birthday, \
		BusinessCity, \
		BusinessCountry, \
		BusinessFax, \
		BusinessPhone, \
		BusinessPostalCode, \
		BusinessState, \
		BusinessStreet, \
		Company, \
		ContactID, \
		Department, \
		EmailAddress, \
		FirstName, \
		HomeCity, \
		HomeCountry, \
		HomeFax, \
		HomePhone, \
		HomePostalCode, \
		HomeState, \
		HomeStreet, \
		JobTitle, \
		LastName, \
		MiddleName, \
		MobilePhone, \
		OtherPhone, \
		Suffix, \
		Title, \
		UserID, \
		WebPage \
		FROM Contacts WHERE UserID=?")
]
class CSelectContacts
{
public:



	// In order to fix several issues with some providers, the code below may bind
	// columns in a different order than reported by the provider

	[ db_column(1)] TCHAR m_Birthday[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(2)] TCHAR m_BusinessCity[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(3) ] TCHAR m_BusinessCountry[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(4) ] TCHAR m_BusinessFax[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(5) ] TCHAR m_BusinessPhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(6) ] TCHAR m_BusinessPostalCode[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(7) ] TCHAR m_BusinessState[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(8) ] TCHAR m_BusinessStreet[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(9) ] TCHAR m_Company[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(10) ] LONG m_ContactID;
	[ db_column(11) ] TCHAR m_Department[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(12) ] TCHAR m_EmailAddress[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(13) ] TCHAR m_FirstName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(14) ] TCHAR m_HomeCity[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(15) ] TCHAR m_HomeCountry[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(16) ] TCHAR m_HomeFax[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(17) ] TCHAR m_HomePhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(18) ] TCHAR m_HomePostalCode[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(19) ] TCHAR m_HomeState[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(20) ] TCHAR m_HomeStreet[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(21) ] TCHAR m_JobTitle[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(22) ] TCHAR m_LastName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(23) ] TCHAR m_MiddleName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(24) ] TCHAR m_MobilePhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(25) ] TCHAR m_OtherPhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(26) ] TCHAR m_Suffix[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(27) ] TCHAR m_Title[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_column(28) ] LONG m_UserID;
	[ db_column(29) ] TCHAR m_WebPage[DB_MAX_CONTACT_FIELDLEN + 1];

	[ db_param(1) ]  LONG m_lUserID;

};

[db_command(L"DELETE * FROM Contacts WHERE UserID=? and ContactID=?")]
class CDeleteContact
{
	public:

		[ db_param(1) ]  LONG m_lUserID;
		[ db_param(2) ]  LONG m_lContactID;
};

[db_command(L"DELETE * FROM Contacts")]
class CDeleteAllContacts
{

};

[
	db_command(L" \
	INSERT INTO Contacts( \
		Birthday, \
		BusinessCity, \
		BusinessCountry, \
		BusinessFax, \
		BusinessPhone, \
		BusinessPostalCode, \
		BusinessState, \
		BusinessStreet, \
		Company, \
		Department, \
		EmailAddress, \
		FirstName, \
		HomeCity, \
		HomeCountry, \
		HomeFax, \
		HomePhone, \
		HomePostalCode, \
		HomeState, \
		HomeStreet, \
		JobTitle, \
		LastName, \
		MiddleName, \
		MobilePhone, \
		OtherPhone, \
		Suffix, \
		Title, \
		UserID, \
		WebPage) \
		VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
]
class CInsertContact
{
public:

	// In order to fix several issues with some providers, the code below may bind
	// columns in a different order than reported by the provider

	[ db_param(1)] TCHAR m_Birthday[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(2)] TCHAR m_BusinessCity[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(3) ] TCHAR m_BusinessCountry[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(4) ] TCHAR m_BusinessFax[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(5) ] TCHAR m_BusinessPhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(6) ] TCHAR m_BusinessPostalCode[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(7) ] TCHAR m_BusinessState[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(8) ] TCHAR m_BusinessStreet[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(9) ] TCHAR m_Company[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(10) ] TCHAR m_Department[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(11) ] TCHAR m_EmailAddress[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(12) ] TCHAR m_FirstName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(13) ] TCHAR m_HomeCity[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(14) ] TCHAR m_HomeCountry[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(15) ] TCHAR m_HomeFax[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(16) ] TCHAR m_HomePhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(17) ] TCHAR m_HomePostalCode[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(18) ] TCHAR m_HomeState[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(19) ] TCHAR m_HomeStreet[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(20) ] TCHAR m_JobTitle[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(21) ] TCHAR m_LastName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(22) ] TCHAR m_MiddleName[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(23) ] TCHAR m_MobilePhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(24) ] TCHAR m_OtherPhone[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(25) ] TCHAR m_Suffix[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(26) ] TCHAR m_Title[DB_MAX_CONTACT_FIELDLEN + 1];
	[ db_param(27) ] LONG m_UserID;
	[ db_param(28) ] TCHAR m_WebPage[DB_MAX_CONTACT_FIELDLEN + 1];

};

