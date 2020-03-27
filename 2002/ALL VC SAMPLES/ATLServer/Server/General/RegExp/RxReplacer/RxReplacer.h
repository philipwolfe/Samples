// (c) 2000 Microsoft Corporation
// RxReplacer.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

[ request_handler("Default") ]
class CRxReplacerHandler
{
private:
	// Put private members here
	CRxUtil<> myRxUtil;
	CString regex,newexp;

protected:
	// Put protected members here
	
public:
	// Put public members here

	HTTP_CODE ModifyIncomingFile(){
		POSITION pos = m_HttpRequest.m_Files.GetStartPosition();
		IHttpFile* pFile =  m_HttpRequest.m_Files.GetNextValue(pos);

		HRESULT hr;
		CAtlFile file;
		
		char *buffer=new char[(DWORD)pFile->GetFileSize()+1];
		hr=file.Create(CA2CT(pFile->GetTempFileName()),GENERIC_READ, FILE_SHARE_READ,
		OPEN_EXISTING, FILE_FLAG_SEQUENTIAL_SCAN );
		if(FAILED(hr)){
			m_HttpResponse<<"Problems Opening Uploaded File";
			return HTTP_FAIL;
		}

		DWORD Bsize,old=(DWORD)pFile->GetFileSize();
		hr=file.Read(buffer,old,Bsize);
		if(FAILED(hr)){
			m_HttpResponse<<"Problems Reading";
			return HTTP_FAIL;
		}
		buffer[Bsize]=0;
		//m_OriginalFile=buffer;
		

		bool global=false;
		bool usevars=false;
		bool casesensitive=true;
		CString contenttype;

		m_HttpRequest.FormVars.Exchange("usevars",&usevars);
		m_HttpRequest.FormVars.Exchange("global",&global);
		m_HttpRequest.FormVars.Exchange("regex",&regex);
		m_HttpRequest.FormVars.Exchange("newexp",&newexp);
		m_HttpRequest.FormVars.Exchange("contenttype",&contenttype);
		m_HttpRequest.FormVars.Exchange("casesensitive",&casesensitive);

		CString temp=buffer;
		_ATLTRY{
			hr=myRxUtil.s(temp,regex,newexp,global,usevars,casesensitive);  //do the regular expression substitution
			if((S_OK==hr)||(S_NO_MATCH==hr)){//Normal outcome is either S_OK or no matches...anything else means there was a problem
				m_HttpResponse.SetContentType(CT2A(contenttype));
				m_HttpResponse<<temp;
			}
			else{
				m_HttpResponse<<"Problems with the regular expresion...error #"<<hr;
			}
		}
		_ATLCATCH(e){
			_ATLDELETEEXCEPTION( e );
			m_HttpResponse<<"Problems with the regular expresion...you might have had too many nested groups";

		}

		delete[] buffer;
		return HTTP_SUCCESS_NO_PROCESS; //stops processing of the rest of the srf file.
	}

	HTTP_CODE ValidateAndExchange()
	{
		// TODO: Put all initialization and validation code here
		
		// Set the content-type
		m_HttpResponse.SetContentType("text/html");
		if (m_HttpRequest.m_Files.GetCount()){
			
			return ModifyIncomingFile();
		}
		
		return HTTP_SUCCESS;
	}

	HTTP_CODE Uninitialize(DWORD dwError)
	{
		// Ensure that all files are deleted so that we don't run out of space.
		m_HttpRequest.DeleteFiles();
		return dwError;
	}

	HTTP_CODE FormFlags()
	{
		// Allow files of all types.
		return ATL_FORM_FLAG_NONE;
	}
}; // class CRxReplacerHandler
