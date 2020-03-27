// FilesHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#define MAX_FORM_SIZE			10485760	// Max form size is 10 megs (in bytes)
#define FILE_READ_BUFFER_SIZE	4096		// Max bytes read per pass from a file

// Change this root path to store files at a different location
// Note: the directory permissions for Everyone should be set to full control
const char MANTAWEB_FILESTORE_ROOT[] = "C:\\MantaWeb_FileStore";

// class CFilesHandler
// This handler is responsible for displaying the virtual file system.
// Users can upload and download files, create folders, and delete files and folders.
class CFilesHandler
	: public CRequestHandlerT<CFilesHandler>,
	  public CMantaWebBase<CFilesHandler>
{
private:
	CAtlArray<WIN32_FIND_DATA> m_FolderList;	// List to store folder data for the current folder
	CAtlArray<WIN32_FIND_DATA> m_FileList;		// List to store file data for the current folder
	UINT m_iCurIndex;							// Current index in the list
	bool m_bDisplayFiles;						// Boolean if we're displaying the files to the user
	bool m_bHadFiles;							// Boolean to specify if the user had any files or folders
	bool m_bCreateFolderError;					// Boolean to specify if there was an error creating a folder
	bool m_bUploadFileError;					// Boolean to specify if there was an error uploading a file
	CStringA m_strCurFolder;					// User's current folder
	CStringA m_strHomeFolder;					// User's home folder

public:
	// Default Constructor
	CFilesHandler() : m_iCurIndex(0),
					  m_bHadFiles(false),
					  m_bDisplayFiles(false),
					  m_bCreateFolderError(false),
					  m_bUploadFileError(false)
	{
	}
    
	DWORD MaxFormSize()
	{
		// Allow up to MAX_FORM_SIZE bytes of form data
		return MAX_FORM_SIZE;
	}

	DWORD FormFlags()
	{
		// Allow files of all types.
		return ATL_FORM_FLAG_NONE;
	}

	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");
		
		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		const CHttpRequestParams& QueryParams = m_HttpRequest.GetQueryParams();
		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();

		// Set the home and current folders
		m_strHomeFolder.Format("%s\\%s", MANTAWEB_FILESTORE_ROOT, GetLogin());
		m_strCurFolder = m_strHomeFolder;
	
		// Set the new current folder
		if (QueryParams.Lookup("changefolder") != NULL)
			m_strCurFolder += QueryParams.Lookup("folder");
		else if (FormFields.Lookup("curfolder") != NULL)
			m_strCurFolder += FormFields.Lookup("curfolder");
		
		// Validate the current folder
		if (!ValidatePath(m_strCurFolder))
			m_strCurFolder = m_strHomeFolder;

		// Check the desired action
		if (FormFields.Lookup("createform") != NULL && 
			FormFields.Lookup("curfolder") != NULL && 
			FormFields.Lookup("folder") != NULL)
		{
			// Create a new folder
			CStringA strDirectory;
			strDirectory.Format("%s%s\\%s", m_strHomeFolder, FormFields.Lookup("curfolder"), FormFields.Lookup("folder"));
			if (ValidatePath(strDirectory))
				m_bCreateFolderError = !(CreateDirectory(strDirectory, NULL));
			else
				m_bCreateFolderError = true;
		}
		else if (FormFields.Lookup("uploadform") != NULL)	// Upload a file
			m_bUploadFileError = !(SaveUploadedFile());
		else if (FormFields.Lookup("deleteform") != NULL)	// Delete marked items
			DeleteMarkedFiles();
		else if (QueryParams.Lookup("download") != NULL)	// Download a file
		{
			DownloadFile(QueryParams.Lookup("file"));
			return HTTP_SUCCESS_NO_PROCESS;
		}

		// If the directory doesn't exist
		if (!SetCurrentDirectory(m_strCurFolder))
		{
			m_strCurFolder = m_strHomeFolder;		// Reset the current folder
			CreateDirectory(m_strCurFolder, NULL);	// Create the home directory to be safe
		}

		// Load the directory info into the arrays
		m_bHadFiles = GetFolderData();
		
		if (m_FolderList.IsEmpty())
			m_bDisplayFiles = true;

		// Modify the current folder path to show the user a relative path
		m_strCurFolder.TrimRight('\\');
		int nBegin = m_strHomeFolder.GetLength();
		LPSTR pszBuffer = m_strCurFolder.GetBuffer();
		strcpy(pszBuffer, &pszBuffer[nBegin]);
		m_strCurFolder.ReleaseBuffer();
		m_strCurFolder.TrimLeft('\\');

		return HTTP_SUCCESS;
	}

	HTTP_CODE Uninitialize(HTTP_CODE hcError)
	{
		// Ensure that all files are deleted so that we don't run out of space.
		m_HttpRequest.DeleteFiles();
		return hcError;
	}

	HTTP_CODE OnCurrentFolder()
	{
		// Respond with the current folder
		m_HttpResponse << m_strCurFolder;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnCurrentFolderEscaped()
	{
		// Respond with the current folder escaped
		CString esc;
		EscapeToCString(esc, m_strCurFolder);
		m_HttpResponse << esc;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnNotAtRoot()
	{
		// Return HTTP_SUCCESS if we're not at the user's home folder ("")
		return (m_strCurFolder == "") ? HTTP_S_FALSE : HTTP_SUCCESS;
	}		
	
	HTTP_CODE OnIsFile()
	{
		// Return HTTP_SUCCESS if the current return is a file
		return (!m_bDisplayFiles) ? HTTP_S_FALSE : HTTP_SUCCESS;
	}

	HTTP_CODE OnFileName()
	{
		// Respond with the file name
		if (!m_bDisplayFiles)
			m_HttpResponse << m_FolderList[m_iCurIndex].cFileName;
		else
			m_HttpResponse << m_FileList[m_iCurIndex].cFileName;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnFileNameEscaped()
	{
		// Respond with the file name escaped
		CString esc;
		if (!m_bDisplayFiles)
			EscapeToCString(esc, m_FolderList[m_iCurIndex].cFileName);
		else
			EscapeToCString(esc, m_FileList[m_iCurIndex].cFileName);
		m_HttpResponse << esc;
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnFileSize()
	{
		// Respond with the file size (32 bit size limit)
		if (!m_bDisplayFiles)
			m_HttpResponse << m_FolderList[m_iCurIndex].nFileSizeLow;
		else
			m_HttpResponse << m_FileList[m_iCurIndex].nFileSizeLow;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnFileType()
	{
		// Respond with the file type
		if (!m_bDisplayFiles)
			m_HttpResponse << "Folder";
		else
		{
			CString strExt = PathFindExtension(m_FileList[m_iCurIndex].cFileName);
			strExt.MakeUpper();
			
			if (strExt == ".JPG" || strExt == ".GIF" || strExt == ".BMP" || strExt == ".TGA")
				m_HttpResponse << "Image File";
			else if (strExt == ".HTML" || strExt == ".HTM" || strExt == ".XML" || strExt == ".CSS")
				m_HttpResponse << "Web File";
			else if (strExt == ".MP3" || strExt == ".WMA" || strExt == ".WAV")
				m_HttpResponse << "Audio File";
			else if (strExt == ".MPEG" || strExt == ".MPG")
				m_HttpResponse << "Video File";
			else if (strExt == ".EXE")
				m_HttpResponse << "Executable File";
			else if (strExt == ".DOC")
				m_HttpResponse << "Microsoft Word Document";
			else if (strExt == ".XLS")
				m_HttpResponse << "Microsoft Excel Document";
			else if (strExt == ".MDB")
				m_HttpResponse << "Microsoft Access Database";
			else if (strExt == ".TXT")
				m_HttpResponse << "Text Document";
			else
				m_HttpResponse << strExt << " File";
		}
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnCreationDate()
	{
		FILETIME creationTime;
		FILETIME localFileTime;

		// Respond with the file creation time
		if (!m_bDisplayFiles)
			creationTime = m_FolderList[m_iCurIndex].ftCreationTime;
		else
			creationTime = m_FileList[m_iCurIndex].ftCreationTime;
		
		if (FileTimeToLocalFileTime(&creationTime, &localFileTime))
		{
			COleDateTime date(localFileTime);
			m_HttpResponse << date.Format("%m/%d/%Y %I:%M %p");
		}
		else
			m_HttpResponse << "unknown";
		
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnFilesLeft()
	{
		// If we're displaying the file list
		if (m_bDisplayFiles)
		{
			// If we're pass the array's count, break the loop
			if (m_iCurIndex >= m_FileList.GetCount())
				return HTTP_S_FALSE;
		}
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnNextFile()
	{
		m_iCurIndex++;
		// If we're displaying folders
		if (!m_bDisplayFiles)
		{
			// If we're pass the array's count, switch to displaying files
			if (m_iCurIndex >= m_FolderList.GetCount())
			{
				m_bDisplayFiles = true;
				m_iCurIndex = 0;
			}
		}
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnDisableDeleteButton()
	{
		// If there were no files in the directory, disable the delete button
		if (!m_bHadFiles)
			m_HttpResponse << "disabled";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnUploadError()
	{
		// Return HTTP_SUCCESS if there was an upload error
		return (m_bUploadFileError) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	HTTP_CODE OnCreateFolderError()
	{
		// Return HTTP_SUCCESS if there was a create folder error
		return (m_bCreateFolderError) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CFilesHandler)
		REPLACEMENT_METHOD_ENTRY("CurrentFolder", OnCurrentFolder)
		REPLACEMENT_METHOD_ENTRY("CurrentFolderEscaped", OnCurrentFolderEscaped)
		REPLACEMENT_METHOD_ENTRY("NotAtRoot", OnNotAtRoot)
		REPLACEMENT_METHOD_ENTRY("IsFile", OnIsFile)
		REPLACEMENT_METHOD_ENTRY("FileName", OnFileName)
		REPLACEMENT_METHOD_ENTRY("FileNameEscaped", OnFileNameEscaped)
		REPLACEMENT_METHOD_ENTRY("FileSize", OnFileSize)
		REPLACEMENT_METHOD_ENTRY("FileType", OnFileType)
		REPLACEMENT_METHOD_ENTRY("CreationDate", OnCreationDate)
		REPLACEMENT_METHOD_ENTRY("FilesLeft", OnFilesLeft)
		REPLACEMENT_METHOD_ENTRY("NextFile", OnNextFile)
		REPLACEMENT_METHOD_ENTRY("DisableDeleteButton", OnDisableDeleteButton)
		REPLACEMENT_METHOD_ENTRY("UploadError", OnUploadError)
		REPLACEMENT_METHOD_ENTRY("CreateFolderError", OnCreateFolderError)
	END_REPLACEMENT_METHOD_MAP()

protected:

	bool GetFolderData()
	{
		HANDLE hFindHandle;
		CStringA strFindPath;
		WIN32_FIND_DATA findData;
		strFindPath.Format("%s\\*.*", m_strCurFolder);

		hFindHandle = ::FindFirstFile(strFindPath, &findData);
		if (hFindHandle == INVALID_HANDLE_VALUE)
			return false;
		
		// Ignore the directory '.'
		if (!FindNextFile(hFindHandle, &findData))
		{
			FindClose(hFindHandle);
			return false;
		}
		
		// Ignore the directory '..'
		if (!FindNextFile(hFindHandle, &findData))
		{
			FindClose(hFindHandle);
			return false;
		}
		BOOL bFindFiles = TRUE;
		// Add each folder and file in the directory to their arrays
		while (bFindFiles)
		{
			// If this is a folder, add to the folder list
			if (findData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
				m_FolderList.Add(findData);
			else
				m_FileList.Add(findData);	// Add to file list
			
			bFindFiles = FindNextFile(hFindHandle, &findData);
		}
		FindClose(hFindHandle);
		return true;
	}

	bool ValidatePath(CStringA& strDir)
	{
		// Validate the path by getting the full path name
		CHAR szFullPath[MAX_PATH + 1];
		GetFullPathName(strDir, MAX_PATH, szFullPath, NULL);
		
		// If the user's home directory does not match the same substring in the
		// requested directory, do not allow them to access it
		if (strncmp(szFullPath, m_strHomeFolder, m_strHomeFolder.GetLength()) != 0)
			return false;
		strDir = szFullPath;
		return true;
	}

	bool DeleteMarkedFiles()
	{
		POSITION pos;
		LPCSTR varname;
		LPCSTR varvalue;
		bool bSucceeded = true;
		CStringA strTemp;

		// Get the first form var
		pos = m_HttpRequest.GetFirstFormVar(&varname, &varvalue);
		while (pos != NULL)
		{
			strTemp.Format("%s\\", m_strCurFolder);
			// If this is a delete file request
			if (strncmp(varname, "file_", 5) == 0)
			{
				// Delete the file
				strTemp += (varname + 5);
				if (!DeleteFile(strTemp))
					bSucceeded = false;
			}
			else if (strncmp(varname, "folder_", 7) == 0)	// Delete folder request
			{
				// Delete the folder
				strTemp += (varname + 7);
				if (!RemoveDirectory(strTemp))
					bSucceeded = false;
			}
			// Get the next form var
			pos = m_HttpRequest.GetNextFormVar(pos, &varname, &varvalue);
		}
		return bSucceeded;
	}

	bool SaveUploadedFile()
	{
		IHttpFile* pFile;
		POSITION pos;
		LPCSTR varname;
		CStringA strTemp;
		bool bSucceeded = true;

		// Get each file posted
		pos = m_HttpRequest.GetFirstFile(&varname, &pFile);
		while (pos != NULL)
		{
			// If the file is not 0 bytes
			if (pFile->GetFileSize() > 0)
			{
				// Copy the temp file to the user's current folder
				strTemp.Format("%s\\%s", m_strCurFolder, pFile->GetFileName());
				if (!CopyFile(pFile->GetTempFileName(), strTemp, true))
					bSucceeded = false;
			}
			else
				bSucceeded = false;
			// Get the next file
			pos = m_HttpRequest.GetNextFile(pos, &varname, &pFile);
		}
		return bSucceeded;
	}

	BOOL DownloadFile(LPCSTR lpszFilename)
	{
		BOOL bSucceeded = TRUE;
		
		// Validate the file to be downloaded
		CString strFile;
		strFile.Format("%s\\%s", m_strCurFolder, lpszFilename);
		if (!ValidatePath(strFile))
			return FALSE;

		// Open the file
		CAtlFile file;
		if (FAILED(file.Create(strFile, GENERIC_READ, FILE_SHARE_READ, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL)))
			return FALSE;

		CString strSize;

		// Set the headers
		strSize.Format("%d", GetFileSize(file, NULL));
		m_HttpResponse.SetContentType("application/octet-stream");
		m_HttpResponse.AppendHeader("Content-Length", strSize);
				
		// Send the headers to the client
		CComPtr<IHttpServerContext> spContext;
		m_HttpRequest.GetServerContext(&spContext);

		bSucceeded = m_HttpResponse.SendHeadersInternal();
		if (bSucceeded)
		{
			DWORD dwBytesRead;
			char buf[FILE_READ_BUFFER_SIZE];
		
			while (1)
			{
				// Read in FILE_READ_BUFFER_SIZE bytes from the file
				if (FAILED(file.Read(buf, FILE_READ_BUFFER_SIZE, dwBytesRead)))
				{
					bSucceeded = FALSE;
					break;
				}
				if (dwBytesRead == 0)
					break;

				// Write the bytes to the client
				if (!spContext->WriteClient(buf, &dwBytesRead))
				{
					bSucceeded = FALSE;
					break;
				}
				ATLASSERT(dwBytesRead != 0);
			}
		}
		return bSucceeded;
	}

}; // class CFilesHandler
