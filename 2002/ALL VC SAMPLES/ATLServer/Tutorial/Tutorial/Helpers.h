// File: Helpers.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

namespace VCUE
{
    // A function template that wraps IServiceProvider::QueryService and sets the
    // GUID of the service to be the same as the GUID of the interface.
    template <class T>
    inline HRESULT QueryService(IServiceProvider* pServiceProvider, T** ppService)
    {
        return pServiceProvider->QueryService(__uuidof(T), ppService);
    }

    // A class that retrieves an OLE DB initialization string from a file (typically a .UDL file)
    class COleDbInitializationString
    {
    public:
        HRESULT LoadFromFile(LPCOLESTR szFile)
        {
            ATLASSERT(szFile != NULL);

            CComPtr<IDataInitialize> spDataInitialize;
            HRESULT hr = spDataInitialize.CoCreateInstance(__uuidof(MSDAINITIALIZE));
            if (SUCCEEDED(hr))
                hr = spDataInitialize->LoadStringFromStorage(szFile, &m_spInitializationString);

            return hr;
        }

        operator LPCOLESTR () const
        {
            return m_spInitializationString;
        }

    private:
        CComHeapPtr<OLECHAR> m_spInitializationString;
    };

    // Call this function to get the name of the module without the file extension
    // strPath      Reference to a string to hold the name of the module without the file extension
    // Returns true on success, false on failure
    inline bool GetModuleNoExtension(CStringW& strModule)
    {
        bool bSuccess = false;
        wchar_t szBuffer[_MAX_PATH];
        const size_t BufferCharacters = sizeof(szBuffer) / sizeof(szBuffer[0]);
        DWORD dwCharacters = GetModuleFileNameW(_AtlBaseModule.GetModuleInstance(), szBuffer, BufferCharacters);
        if (dwCharacters && (dwCharacters < BufferCharacters))
        {
            PathRemoveExtensionW(szBuffer);
            strModule = szBuffer;
            bSuccess = true;
        }

        return bSuccess;
    }

    // A function template that loads an OLE DB initialization string from a file
    // retrieves a connection to the database from the cache and opens
    // the rowset on the command object.
    // Templates are used because the OpenRowset function is injected by the db_command attribute
    template <class TDatabaseCommand>
    inline HRESULT OpenCommandRowset(IServiceProvider* pServiceProvider, TDatabaseCommand& dbCommand, LPCOLESTR szFile, LPCOLESTR szConnectionId = NULL)
    {
        ATLASSERT(pServiceProvider != NULL);
        ATLASSERT(szFile != NULL);

        // If the connection ID is not specified, just use the name of the file
        if (!szConnectionId)
            szConnectionId = szFile;

        HRESULT hr = E_UNEXPECTED;
        COleDbInitializationString initializationString;
        hr = initializationString.LoadFromFile(szFile);
        if (SUCCEEDED(hr))
        {
            CDataConnection connection;
            if (S_OK != GetDataSource(pServiceProvider, COLE2T(szConnectionId), initializationString, &connection))
                return E_FAIL;

            hr = dbCommand.OpenRowset(connection);

            #ifdef DEBUG
                if (FAILED(hr) || DB_S_ERRORSOCCURRED == hr)
                    AtlTraceErrorRecords(hr);
            #endif
        }

        return hr;
    }

    // This overload gets the name of the UDL file from the name of the module
    template <class TDatabaseCommand>
    inline HRESULT OpenCommandRowset(IServiceProvider* pServiceProvider, TDatabaseCommand& dbCommand)
    {
        ATLASSERT(pServiceProvider != NULL);

        CStringW strUdlFile;
        if (GetModuleNoExtension(strUdlFile))
        {
            strUdlFile.Append(L".udl");
            return OpenCommandRowset(pServiceProvider, dbCommand, strUdlFile);
        }
        return E_UNEXPECTED;
    }

    inline bool ItemIsPresent(const CHttpRequestParams& Map, LPCSTR Item)
    {
        const CHttpRequestParams::BaseMap& baseMap = Map;
        const CHttpRequestParams::CPair* pPair = baseMap.Lookup(Item);
        return pPair ? true : false;
    }

    inline LPCSTR GetLoginId(CHttpRequest& request)
    {
        // Check for existence of cookie
        if (!request.Cookies(COOKIE_NAME).IsEmpty())
        {
            const CCookie& cookieValidate = request.Cookies(COOKIE_NAME);

            // Check for presence of cookie value
            LPCSTR szSessionId = cookieValidate.Lookup(COOKIE_VALUE_NAME);
            if (szSessionId)
            {
                // Check length of cookie value
                if (strlen(szSessionId) <= COOKIE_VALUE_SIZE)
                {
                    return szSessionId;
                }
            }
        }

        return NULL;
    }

    inline HRESULT GetSession(IServiceProvider* pServiceProvider, LPCSTR szSessionId, ISession** ppSession)
    {
        HRESULT hr = E_UNEXPECTED;

        // Get the session state service.
        CComPtr<ISessionStateService> spSessionService;
        hr = QueryService(pServiceProvider, &spSessionService);

        if (SUCCEEDED(hr))
        {
            // Get the session.
            hr = spSessionService->GetSession(szSessionId, ppSession);
        }

        return hr;
    }

    // Call this function to return a simple error response to the user.
    // The HTTP status code defaults to 500 (a generic server error).
    inline HTTP_CODE SendError(CHttpResponse& response, const CStringA& strError, WORD wHttpStatus = 500)
    {
        // Clear any buffered headers (including cookies) and content.
        response.ClearResponse();

        // Suggest that clients and proxies do not cache this response.
        response.SetCacheControl("no-cache");
        response.SetExpires(0);

        // Set the status code in the response object.
        response.SetStatusCode(wHttpStatus);

        // Build the body of the response.
        response << "<html><head><title>ATL Server Tutorial</title></head><body><p>" << strError << "</p></body></html>";

        // Return a HTTP_CODE that tells the ATL Server code to discontinue processing of the SRF file.
        return HTTP_ERROR(wHttpStatus, SUBERR_NO_PROCESS);
    }

    template <class TCharArray>
    inline HRESULT SetOleDbStringMember(TCharArray& data, DBSTATUS& status, DBLENGTH& length, LPCSTR szNewValue)
    {
        // Ensure that only char arrays are allowed.
        static_cast<char[sizeof(data)]>(data);

        // Ensure that user passes valid string.
        ATLASSERT(szNewValue != NULL);

        HRESULT hr = E_FAIL;

        #pragma warning(push)
        #pragma warning(disable : 4267) // conversion from 'size_t' to 'DBLENGTH', possible loss of data

        length = strlen(szNewValue);
        
        #pragma warning(pop)

        // Check length of string.
        if (length && (length < sizeof(data)))
        {
            // Copy string.
            if (SafeStringCopy(data, szNewValue))
            {
                hr = S_OK;
                status = DBSTATUS_S_OK;
            }
        }
        
        // Reset data, length, status on failure
        if (FAILED(hr))
        {
            data[0] = 0;
            length = 0;
            status = DBSTATUS_S_ISNULL;
        }

        ATLASSERT(length < sizeof(data));
        ATLASSERT((FAILED(hr) && (0 == length) && (DBSTATUS_S_ISNULL == status)) || (SUCCEEDED(hr) && (0 != length) && (DBSTATUS_S_OK == status)));

        return hr;
    }


    class CTemporaryRevertToSelf
    {
    public:
        CTemporaryRevertToSelf(HRESULT& hr) throw()
            : m_hThreadToken(INVALID_HANDLE_VALUE)
            , m_hCurrentThread(GetCurrentThread())
        {
            ATLASSERT(GetCurrentThread() == m_hCurrentThread);

            hr = Open();

            if (SUCCEEDED(hr))
            {
                if (!RevertToSelf())
                {
                    hr = AtlHresultFromLastError();
                    Close();
                }
            }
        }

        ~CTemporaryRevertToSelf() throw()
        {
            ATLASSERT(GetCurrentThread() == m_hCurrentThread);

            // Enable this assertion
            // if you want to ensure Restore
            // is called explicitly
            // ATLASSERT(!IsOpen());

            HRESULT hr = Restore();
            ATLASSERT(SUCCEEDED(hr));
        }

        HRESULT Restore() throw()
        {
            ATLASSERT(GetCurrentThread() == m_hCurrentThread);

            HRESULT hr = S_OK;
            if (IsOpen())
            {
                if (!SetThreadToken(&m_hCurrentThread, m_hThreadToken))
                {
                    hr = AtlHresultFromLastError();
                }
                Close();
            }

            ATLASSERT(!IsOpen());
            return hr;
        }

    private:
        HANDLE m_hThreadToken;
        HANDLE m_hCurrentThread;

        HRESULT Open()
        {
            ATLASSERT(!IsOpen());

            BOOL bSuccess = OpenThreadToken(
                                m_hCurrentThread,
                                TOKEN_IMPERSONATE | TOKEN_DUPLICATE,
                                FALSE,
                                &m_hThreadToken
                                );

            ATLASSERT(bSuccess ? IsOpen() : !IsOpen());

            return bSuccess ? S_OK : AtlHresultFromLastError();
        }

        HRESULT Close()
        {
            ATLASSERT(IsOpen());

            BOOL bSuccess = CloseHandle(m_hThreadToken);
            m_hThreadToken = INVALID_HANDLE_VALUE;
            ATLASSERT(bSuccess);
            return bSuccess ? S_OK : AtlHresultFromLastError();
        }

        bool IsOpen()
        {
            return INVALID_HANDLE_VALUE != m_hThreadToken;
        }
    };

} // namespace VCUE