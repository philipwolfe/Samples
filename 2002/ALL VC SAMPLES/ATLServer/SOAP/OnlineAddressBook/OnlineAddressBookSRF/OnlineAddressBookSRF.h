// OnlineAddressBookSRF.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

template <typename T>
void MapSOAPArrayToATLArray(T *mySOAParray, const int sizeOfArray,CAtlArray<T> &OutArray){
	for(int i=0;i<sizeOfArray;i++)
		OutArray.Add(mySOAParray[i]);
	AtlCleanupArray<T>(mySOAParray,sizeOfArray);
	free(mySOAParray);
}


[ request_handler("Default") ]
class COnlineAddressBookSRFHandler
{
private:

	OnlineAddressBookWSService::COnlineAddressBookWSService m_OAWS;
	CStringA m_SessionID;
	bool m_auth;
	CAtlArray<int> m_IDList;
	int m_IDCounter;
	OnlineAddressBookWSService::ContactItem m_CurrentContactItem;
	bool m_blue;

protected:
public:
	HTTP_CODE ValidateAndExchange()
	{

		m_auth=false;
		m_blue=false;
		m_HttpResponse.SetContentType("text/html");
	
		if(m_HttpRequest.GetSessionCookie().IsEmpty()){//no Session
			CString email,password;
			if(S_OK==m_HttpRequest.GetFormVars().Exchange("email",&email)&&S_OK==m_HttpRequest.GetFormVars().Exchange("password",&password))
			{
				if(S_OK==m_OAWS.LogOn(CComBSTR(email),CComBSTR(password))){
					m_SessionID=m_OAWS.m_SessionID;
					CSessionCookie mySC(m_SessionID);
					m_HttpResponse.AppendCookie(mySC);
					m_auth=true;
				}


			}
			else
				m_auth=false;

		}
		else{
			m_HttpRequest.GetSessionCookie().GetValue(m_SessionID);
			m_OAWS.m_SessionID=CComBSTR(m_SessionID);
			m_auth=true;
		}
	 
		return HTTP_SUCCESS;
	}
 
protected:



	[ tag_name(name = "authenticated") ]
	HTTP_CODE Onauthenticated(void)
	{
		if(m_auth)
			return HTTP_SUCCESS;
		else
			return HTTP_S_FALSE;
	}


	[ tag_name(name = "StartAddressList") ]
	HTTP_CODE OnStartAddressList(void)
	{

		HRESULT hr;
		BSTR *NameList=NULL;
		BSTR *temp1=NULL;
		int *IDList=NULL;
		int *temp2=NULL;
		int nameListSize,IDListSize;
		m_IDList.RemoveAll();
		hr=m_OAWS.GetContactList(&NameList,&nameListSize,&IDList,&IDListSize);
		if(S_OK==hr){
			MapSOAPArrayToATLArray<int>(IDList,IDListSize,m_IDList);
			AtlCleanupArray(NameList,nameListSize);
			free(NameList);
			m_IDCounter=0;
			return HTTP_SUCCESS;
		}
		else
			return HTTP_FAIL;
		
		

	}


	[ tag_name(name = "StillRecords") ]
	HTTP_CODE OnStillRecords(void)
	{
		AtlCleanupValue(&m_CurrentContactItem);
		if(m_IDCounter<m_IDList.GetCount()){
			HRESULT hr;
			hr=m_OAWS.GetAddressBookEntry(m_IDList[m_IDCounter],&m_CurrentContactItem);
			m_IDCounter++;
			return HTTP_SUCCESS;
		}
		else
			return HTTP_S_FALSE;
	}


	[ tag_name(name = "Name") ]
	HTTP_CODE OnName(void)
	{
		m_HttpResponse<<m_CurrentContactItem.m_FirstName<<" "<<m_CurrentContactItem.m_LastName;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "email") ]
	HTTP_CODE Onemail(void)
	{
		m_HttpResponse<<m_CurrentContactItem.m_EmailAddress;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "HomePhone") ]
	HTTP_CODE OnHomePhone(void)
	{
		m_HttpResponse<<m_CurrentContactItem.m_HomePhone;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "WorkPhone") ]
	HTTP_CODE OnWorkPhone(void)
	{

			m_HttpResponse<<m_CurrentContactItem.m_BusinessPhone;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "MPhone") ]
	HTTP_CODE OnMPhone(void)
	{
		
		m_HttpResponse<<m_CurrentContactItem.m_MobilePhone;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "URL") ]
	HTTP_CODE OnURL(void)
	{
		m_HttpResponse<<m_CurrentContactItem.m_WebPage;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "HAddy") ]
	HTTP_CODE OnHAddy(void)
	{
		m_HttpResponse<<m_CurrentContactItem.m_HomeStreet<<"<br>"<<m_CurrentContactItem.m_HomeCity<<" "<<m_CurrentContactItem.m_HomeState<<" "<<m_CurrentContactItem.m_HomePostalCode<<"<br>"<<m_CurrentContactItem.m_HomeCountry;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "WAddy") ]
	HTTP_CODE OnWAddy(void)
	{
		m_HttpResponse<<m_CurrentContactItem.m_BusinessStreet<<"<br>"<<m_CurrentContactItem.m_BusinessCity<<" "<<m_CurrentContactItem.m_BusinessState<<" "<<m_CurrentContactItem.m_BusinessPostalCode<<"<br>"<<m_CurrentContactItem.m_BusinessCountry;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "Comp") ]
	HTTP_CODE OnComp(void)
	{
		m_HttpResponse<<m_CurrentContactItem.m_Company;
		return HTTP_SUCCESS;
	}


	[ tag_name(name = "getRowColor") ]
	HTTP_CODE OngetRowColor(void)
	{
		if(m_blue){
			m_HttpResponse<<"#33ccff";
			m_blue=false;
		}
		else{
			m_HttpResponse<<"#33ff00";
			m_blue=true;
		}
		return HTTP_SUCCESS;
	}
}; // class COnlineAddressBookSRFHandler
