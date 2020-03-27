// OnlineAddressBookWS.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

namespace OnlineAddressBookWSService
{
const wchar_t MYDATASOURCE[] = L"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\OnlineAddressBookWS.mdb;Persist Security Info=False";

#define OABWS_UNEXPECTED_ERROR -1
#define OABWS_ERROR_INVALID_USER -2
#define OABWS_ERROR_INVALID_CONTACTNAME -3
#define OABWS_ERROR_USERID_ALREADY_EXISTS -4
#define OABWS_INVALID_PASSWORD -5
// all struct, enum, and typedefs for your webservice should go inside the namespace
/*
	struct SessionIDWrap{
		BSTR SessionID;
	};

*/	struct ContactItem{
		LONG m_ContactID;
		BSTR m_Birthday;
		BSTR m_BusinessCity;
		BSTR m_BusinessCountry;
		BSTR m_BusinessFax;
		BSTR m_BusinessPhone;
		BSTR m_BusinessPostalCode;
		BSTR m_BusinessState;
		BSTR m_BusinessStreet;
		BSTR m_Company;
		BSTR m_Department;
		BSTR m_EmailAddress;
		BSTR m_FirstName;
		BSTR m_HomeCity;
		BSTR m_HomeCountry;
		BSTR m_HomeFax;
		BSTR m_HomePhone;
		BSTR m_HomePostalCode;
		BSTR m_HomeState;
		BSTR m_HomeStreet;
		BSTR m_JobTitle;
		BSTR m_LastName;
		BSTR m_MiddleName;
		BSTR m_MobilePhone;
		BSTR m_OtherPhone;
		BSTR m_Suffix;
		BSTR m_Title;
		BSTR m_WebPage;
	};

// IOnlineAddressBookWSService - web service interface declaration
//
[
	uuid("97F8B70E-8A60-43DE-9198-23DEE5E4DB92"), 
	object
]
__interface IOnlineAddressBookWSService
{
	// HelloWorld is a sample ATL Server web service method.  It shows how to
	// declare a web service method and its in-parameters and out-parameters
	HRESULT LogOn([in] BSTR email,[in] BSTR password);
	HRESULT LogOff();
	HRESULT DeleteAllContacts();
	HRESULT GetAddressBookEntry([in] LONG lContactID,[out, retval] ContactItem *theContactItem);
	HRESULT GetContactList([out] int *arrSize,[out,size_is(*arrSize)] BSTR **NameList,[out,size_is(*arrSize)] LONG **IDList);
	HRESULT CreateAccount([in] BSTR strEmail, [in] BSTR strPassword,[in] BSTR strFirstName,[in] BSTR strLastName);
	HRESULT InsertContact([in] ContactItem newContactItem);
	// TODO: Add additional web service methods here
};


// OnlineAddressBookWSService - web service implementation
//
[
	request_handler(name="Default", sdl="GenOnlineAddressBookWSServiceWSDL"),
	soap_handler(
		name="OnlineAddressBookWSService", 
		namespace="urn:OnlineAddressBookWSService",
		protocol="soap",style="document",use="literal"
	)
]
class COnlineAddressBookWSService :
	public IOnlineAddressBookWSService
{
public:
	

    BSTR m_SessionID;


	// uncomment the service declaration(s) if you want to use
	// a service that was generated with your ISAPI extension
	CComPtr<ISessionStateService> m_spSessionSvc;
	CComPtr<ISession>	m_spSession;
	CDataConnection m_dc;
	HTTP_CODE InitializeHandler(AtlServerRequest *pRequestInfo, IServiceProvider *pProvider)
	{
		if (HTTP_SUCCESS != CSoapHandler<COnlineAddressBookWSService>::InitializeHandler(pRequestInfo, pProvider))
			return HTTP_FAIL;

		// Get the ISessionStateService from the ISAPI extension
		if (FAILED(pProvider->QueryService(__uuidof(ISessionStateService), 
						__uuidof(ISessionStateService), (void **)&m_spSessionSvc)))
			return HTTP_FAIL;

		// Uncomment the following code to retrieve a data source
		// connection from the data source cache. Replace connection_name
		// with a string used to identify the connection and
		// connection_string with an OLEDB connection string
		// which is valid for your data source. This code assumes that 
		// the service provider pointed to by m_spServiceProvider
		// can provide an IDataSourceCache pointer to a data source 
		// cache service (usually implemented in the ISAPI extension).

		if (S_OK != GetDataSource(  pProvider, 
									_T("onlinecatalog"),
									MYDATASOURCE , 
									&m_dc )){

			ATLTRACE(_T("GetDataSouce Failed.  Make sure MYDATASOUCE is properly defined"));
			return HTTP_FAIL;

									}
		return HTTP_SUCCESS;
	}	
protected:


	[ soap_method ]
    [ soap_header(value="m_SessionID",required=true,in=true,out=false) ]
	HRESULT LogOff()
	{
		if(S_OK!=m_spSessionSvc->CloseSession(CW2A(m_SessionID)))
			return OABWS_UNEXPECTED_ERROR;
		return S_OK;
	}

	[ soap_method ]
    [ soap_header(value="m_SessionID",required=true,in=true,out=false) ]
	HRESULT DeleteAllContacts()
	{
		CDeleteAllContacts DeleteAllContacts;
		if(S_OK!=DeleteAllContacts.Open(m_dc))
			return OABWS_UNEXPECTED_ERROR;
		else
			return S_OK;
	}

	[ soap_method ]
    [ soap_header(value="m_SessionID",required=true,in=false,out=true) ]
	HRESULT LogOn(/*[in]*/ BSTR strEmail, /*[in]*/ BSTR strPassword)
	{
		CLoginUser loginUser;
		lstrcpyn(loginUser.m_param_szEmail, CW2CT(strEmail), DB_MAX_STRLEN);
		
		HRESULT hr = loginUser.OpenRowset(m_dc, FALSE);
		if (hr != S_OK)
			return OABWS_UNEXPECTED_ERROR;

		hr = loginUser.MoveFirst();
		if (hr != S_OK)
		{
			loginUser.Close();
			return OABWS_ERROR_INVALID_USER;
		}

		// If the passwords match
		if (hr == S_OK)
		{
			hr = CompareSecret(
				(const BYTE*) (LPCSTR) strPassword, CComBSTR(strPassword).Length(),
				(BYTE*) loginUser.m_szSalt, lstrlen(loginUser.m_szSalt),
				(BYTE*) loginUser.m_szPassword, lstrlen(loginUser.m_szPassword));
		}

		if(hr!=S_OK)
			return OABWS_INVALID_PASSWORD;

		//If we're here user was validated
		char newSessionID[MAX_SESSION_KEY_LEN];
		DWORD temp=MAX_SESSION_KEY_LEN;
		m_spSessionSvc->CreateNewSession(newSessionID,&temp,&m_spSession);
		if(!m_spSession)
			return OABWS_UNEXPECTED_ERROR;
		m_spSession->SetVariable("userID",CComVariant(loginUser.m_lUserID));
		CComBSTR bstrOut(newSessionID);
		m_SessionID=bstrOut.Detach();

		return S_OK;

	}
	// TODO: Add additional web service methods here

	[ soap_method ]
	[ soap_header(value="m_SessionID",required=true,in=true,out=true) ]
	HRESULT GetAddressBookEntry(/*[in]*/LONG lContactID,/*[out, retval]*/ ContactItem *theContactItem){
		CSelectContact SelectContact;
		HRESULT hr=OABWS_UNEXPECTED_ERROR;

		hr=m_spSessionSvc->GetSession(CW2A(m_SessionID),&m_spSession);
		if(hr!=S_OK)
			return OABWS_UNEXPECTED_ERROR;
		//if(hr==S_OK){
			CComVariant userId;
			hr=m_spSession->GetVariable("userID",&userId);
			if(hr!=S_OK)
				return OABWS_UNEXPECTED_ERROR;
			SelectContact.m_lUserID=userId.lVal;
			SelectContact.m_lContactID=lContactID;
			if(S_OK!=SelectContact.Open(m_dc))
				return OABWS_UNEXPECTED_ERROR;
			if(S_OK!=SelectContact.MoveFirst()){
				SelectContact.Close();
				return OABWS_ERROR_INVALID_CONTACTNAME;
			}
			//got it

			theContactItem->m_ContactID=lContactID;


			CComBSTR temp(SelectContact.m_Birthday);
			theContactItem->m_Birthday=temp.Detach();

			temp=SelectContact.m_BusinessCity;
			theContactItem->m_BusinessCity=temp.Detach();

			temp=SelectContact.m_BusinessCountry;
			theContactItem->m_BusinessCountry=temp.Detach();

			temp=SelectContact.m_BusinessFax;
			theContactItem->m_BusinessFax=temp.Detach();

			temp=SelectContact.m_BusinessPhone;
			theContactItem->m_BusinessPhone=temp.Detach();

			temp=SelectContact.m_BusinessPostalCode;
			theContactItem->m_BusinessPostalCode=temp.Detach();

			temp=SelectContact.m_BusinessState;
			theContactItem->m_BusinessState=temp.Detach();

			temp=SelectContact.m_BusinessStreet;
			theContactItem->m_BusinessStreet=temp.Detach();

			temp=SelectContact.m_Company;
			theContactItem->m_Company=temp.Detach();

			temp=SelectContact.m_Department;
			theContactItem->m_Department=temp.Detach();

			temp=SelectContact.m_EmailAddress;
			theContactItem->m_EmailAddress=temp.Detach();

			temp=SelectContact.m_FirstName;
			theContactItem->m_FirstName=temp.Detach();

			temp=SelectContact.m_HomeCity;
			theContactItem->m_HomeCity=temp.Detach();

			temp=SelectContact.m_HomeCountry;
			theContactItem->m_HomeCountry=temp.Detach();

			temp=SelectContact.m_HomeFax;
			theContactItem->m_HomeFax=temp.Detach();

			temp=SelectContact.m_HomePhone;
			theContactItem->m_HomePhone=temp.Detach();

			temp=SelectContact.m_HomePostalCode;
			theContactItem->m_HomePostalCode=temp.Detach();

			temp=SelectContact.m_HomeState;
			theContactItem->m_HomeState=temp.Detach();

			temp=SelectContact.m_HomeStreet;
			theContactItem->m_HomeStreet=temp.Detach();

			temp=SelectContact.m_JobTitle;
			theContactItem->m_JobTitle=temp.Detach();

			temp=SelectContact.m_LastName;
			theContactItem->m_LastName=temp.Detach();

			temp=SelectContact.m_MiddleName;
			theContactItem->m_MiddleName=temp.Detach();

			temp=SelectContact.m_MobilePhone;
			theContactItem->m_MobilePhone=temp.Detach();

			temp=SelectContact.m_OtherPhone;
			theContactItem->m_OtherPhone=temp.Detach();

			temp=SelectContact.m_Suffix;
			theContactItem->m_Suffix=temp.Detach();

			temp=SelectContact.m_Title;
			theContactItem->m_Title=temp.Detach();

			temp=SelectContact.m_WebPage;
			theContactItem->m_WebPage=temp.Detach();





			SelectContact.Close();



		return S_OK;
	}

	[ soap_method ]
	[ soap_header(value="m_SessionID",required=true,in=true,out=false) ]
	HRESULT GetContactList(int *arrSize,BSTR **NameList, LONG **IDList){
		CSelectContacts SelectContacts;
		HRESULT hr;

		hr=m_spSessionSvc->GetSession(CW2A(m_SessionID),&m_spSession);
		if(hr!=S_OK)
			return S_FALSE;
		//if(hr==S_OK){
			CComVariant userId;
			hr=m_spSession->GetVariable("userID",&userId);
			if(hr!=S_OK)
				return E_UNEXPECTED;
			SelectContacts.m_lUserID=userId.lVal;
			if(S_OK!=SelectContacts.Open(m_dc))
				return S_FALSE;
			if(S_OK!=SelectContacts.MoveFirst()){
				SelectContacts.Close();
				return S_FALSE;
			}
		CAtlArray<CComBSTR> names;
		CAtlArray<LONG> IDs;
		CString tempName;
		tempName.Format(_T("%s %s"),SelectContacts.m_FirstName,SelectContacts.m_LastName);
		names.Add(tempName.GetBuffer());
		IDs.Add(SelectContacts.m_ContactID);
		while(SelectContacts.MoveNext()==S_OK){
			tempName.Format(_T("%s %s"),SelectContacts.m_FirstName,SelectContacts.m_LastName);
			names.Add(tempName.GetBuffer());
			IDs.Add(SelectContacts.m_ContactID);
		}
		SelectContacts.Close();

		*arrSize=(int)names.GetCount();
		*NameList=(BSTR*) GetMemMgr()->Allocate(sizeof(BSTR)*(*arrSize));
		*IDList=(LONG*) GetMemMgr()->Allocate(sizeof(LONG)*(*arrSize));
		for(int i=0;i<*arrSize;i++){
			(*IDList)[i]=IDs.GetAt(i);
			(*NameList)[i]=(names.GetAt(i)).Detach();

		}
		return S_OK;

	}
	
	[soap_method]
	HRESULT CreateAccount(BSTR strEmail, BSTR strPassword,BSTR strFirstName, BSTR strLastName){
		CAddUser addUser;
		HRESULT hr;

		lstrcpyn(addUser.m_szFirstName, CW2CT(strFirstName),DB_MAX_STRLEN);
		lstrcpyn(addUser.m_szLastName, CW2CT(strLastName),DB_MAX_STRLEN);
		lstrcpyn(addUser.m_szEmail, CW2CT(strEmail),DB_MAX_STRLEN);

		DWORD dwSaltLen = 4;
		DWORD dwPasswordLen = DB_MAX_STRLEN;
		hr = HashSecret(
			(const BYTE*) (LPCSTR) strPassword, CComBSTR(strPassword).Length(),
			(BYTE*) addUser.m_szSalt, dwSaltLen,
			(BYTE*) addUser.m_szPassword, dwPasswordLen);
		if (FAILED(hr))
			return OABWS_UNEXPECTED_ERROR;

		addUser.m_szSalt[dwSaltLen] = 0;
		addUser.m_szPassword[dwPasswordLen] = 0;

		hr = addUser.OpenRowset(m_dc, NULL);
		if (hr != S_OK)
			return OABWS_ERROR_USERID_ALREADY_EXISTS;

		return S_OK;

	}

	[soap_method]
	[ soap_header(value="m_SessionID",required=true,in=true,out=false) ]
	HRESULT InsertContact(ContactItem newContactItem){
		HRESULT hr;
		hr=m_spSessionSvc->GetSession(CW2A(m_SessionID),&m_spSession);
		if(hr!=S_OK)
			return OABWS_UNEXPECTED_ERROR;
		CComVariant userId;
		hr=m_spSession->GetVariable("userID",&userId);
		if(hr!=S_OK)
			return OABWS_UNEXPECTED_ERROR;
		


				CInsertContact icSP;

	//	icSP.m_ContactID=newContactItem.m_ContactID;
		icSP.m_UserID=userId.lVal;

		lstrcpyn(icSP.m_Birthday,CW2T(newContactItem.m_Birthday),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_BusinessCity,CW2T(newContactItem.m_BusinessCity),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_BusinessCountry,CW2T(newContactItem.m_BusinessCountry),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_BusinessFax,CW2T(newContactItem.m_BusinessFax),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_BusinessPhone,CW2T(newContactItem.m_BusinessPhone),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_BusinessPostalCode,CW2T(newContactItem.m_BusinessPostalCode),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_BusinessState,CW2T(newContactItem.m_BusinessState),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_BusinessStreet,CW2T(newContactItem.m_BusinessStreet),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_Company,CW2T(newContactItem.m_Company),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_Department,CW2T(newContactItem.m_Department),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_EmailAddress,CW2T(newContactItem.m_EmailAddress),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_FirstName,CW2T(newContactItem.m_FirstName),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_HomeCity,CW2T(newContactItem.m_HomeCity),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_HomeCountry,CW2T(newContactItem.m_HomeCountry),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_HomeFax,CW2T(newContactItem.m_HomeFax),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_HomePhone,CW2T(newContactItem.m_HomePhone),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_HomePostalCode,CW2T(newContactItem.m_HomePostalCode),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_HomeState,CW2T(newContactItem.m_HomeState),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_HomeStreet,CW2T(newContactItem.m_HomeStreet),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_JobTitle,CW2T(newContactItem.m_JobTitle),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_LastName,CW2T(newContactItem.m_LastName),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_MiddleName,CW2T(newContactItem.m_MiddleName),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_MobilePhone,CW2T(newContactItem.m_MobilePhone),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_OtherPhone,CW2T(newContactItem.m_OtherPhone),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_Suffix,CW2T(newContactItem.m_Suffix),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_Title,CW2T(newContactItem.m_Title),DB_MAX_CONTACT_FIELDLEN);
		lstrcpyn( icSP.m_WebPage,CW2T(newContactItem.m_WebPage),DB_MAX_CONTACT_FIELDLEN);


		
		hr=icSP.Open(m_dc);
		if(hr==S_OK)
			icSP.Close();
			
		return hr;
	


	}



	HRESULT GenerateAppError(IWriteStream *pStream, HRESULT hr){
		if (pStream == NULL)
		{
			return E_INVALIDARG;
		}

		LPWSTR pwszMessage = NULL;	

			switch(hr){
				case OABWS_UNEXPECTED_ERROR:
					pwszMessage = L"An Unexpected Application Error Occurred";
					break;
				case OABWS_ERROR_INVALID_USER:
					pwszMessage = L"The User Trying to Log On doesn't exist";
					break;
				case OABWS_ERROR_INVALID_CONTACTNAME:
					pwszMessage = L"The contact name you're looking for doesn't exist";
					break;
				case OABWS_ERROR_USERID_ALREADY_EXISTS:
					pwszMessage = L"Accout creation failed, possible causes include that email address being in use already and lack of write permissions on the DB";
					break;
				case OABWS_INVALID_PASSWORD:
					pwszMessage = L"Invalid Password";
					break;




				default:
					pwszMessage = L"Something quite misterious happened";
			}
			
		

		hr = SoapFault(SOAP_E_SERVER, pwszMessage, -1);

		return hr;

	}
	
}; // class COnlineAddressBookWSService

} // namespace OnlineAddressBookWSService
