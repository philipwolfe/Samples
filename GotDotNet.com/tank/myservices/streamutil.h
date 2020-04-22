#pragma once

class CWriteStreamOnFileA : public IWriteStream
{
private:

	HANDLE m_hFile;

public:

	CWriteStreamOnFileA()
		:m_hFile(INVALID_HANDLE_VALUE)
	{
	}

	~CWriteStreamOnFileA()
	{
		if (m_hFile != INVALID_HANDLE_VALUE)
		{
			CloseHandle(m_hFile);
		}
	}

	HRESULT Init(LPCSTR szFile, DWORD dwCreationDisposition = CREATE_NEW)
	{
		if (szFile == NULL)
		{
			return E_INVALIDARG;
		}

		m_hFile = CreateFileA(szFile, GENERIC_WRITE, FILE_SHARE_READ, NULL, 
			dwCreationDisposition, FILE_ATTRIBUTE_NORMAL, NULL);

		if (m_hFile == INVALID_HANDLE_VALUE)
		{
			return AtlHresultFromLastError();
		}

		return S_OK;
	}

	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten)
	{
		ATLASSERT( szOut != NULL );
		ATLASSERT( m_hFile != INVALID_HANDLE_VALUE );

		if (nLen < 0)
		{
			nLen = (int) strlen(szOut);
		}

		DWORD dwWritten = 0;
		if (WriteFile(m_hFile, szOut, nLen, &dwWritten, NULL) != FALSE)
		{
			if (pdwWritten != NULL)
			{
				*pdwWritten = dwWritten;
			}

			return S_OK;
		}

		return AtlHresultFromLastError();
	}

	HRESULT FlushStream()
	{
		ATLASSERT( m_hFile != INVALID_HANDLE_VALUE );

		if (FlushFileBuffers(m_hFile) != FALSE)
		{
			return S_OK;
		}

		return AtlHresultFromLastError();
	}
}; // class CWriteStreamOnFileA

class CWriteStreamOnString : public IWriteStream, public CString
{
	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten)
	{
		CString temp;
		temp.SetString(szOut, nLen);

		(*this) += temp;

		return S_OK;
	}

	HRESULT FlushStream()
	{
		return S_OK;
	}
};

#ifdef _DEBUG

class CWriteStreamOnStdout : public IWriteStream
{
public:

	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten)
	{
		ATLASSERT( szOut != NULL );

		if (nLen < 0)
		{
			nLen = (int) strlen(szOut);
		}
		
		printf("%.*s", nLen, szOut);
		return S_OK;
	}

	HRESULT FlushStream()
	{
		return S_OK;
	}

}; // class CWriteStreamOnStdout

#endif
