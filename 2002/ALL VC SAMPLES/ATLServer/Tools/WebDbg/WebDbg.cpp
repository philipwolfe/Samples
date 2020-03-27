// WebDbg.cpp : Defines the class behaviors for the application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "WebDbg.h"
#include "DebugDialog.h"
#include "FilterDialog.h"
#include "PipeDlg.h"

#include "MainFrm.h"
#include "atlutil.h"
#include <tchar.h>
#include <atlsecurity.h>
#include <aclui.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CWebDbgApp

BEGIN_MESSAGE_MAP(CWebDbgApp, CWinApp)
	//{{AFX_MSG_MAP(CWebDbgApp)
	ON_COMMAND(ID_APP_ABOUT, OnAppAbout)
	ON_COMMAND(ID_VIEW_STACKTRACE, OnViewStacktrace)
	ON_COMMAND(ID_APP_PIPE, OnAppPipe)
	ON_COMMAND(ID_FILE_PERMISSIONS, OnAppPermissions)
	ON_UPDATE_COMMAND_UI(ID_VIEW_STACKTRACE, OnUpdateViewStacktrace)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// The one and only CWebDbgApp object

CWebDbgApp theApp;


class CPipeSecurityInformation : public CComObjectRootEx<CComSingleThreadModel>,
		public ISecurityInformation
{
public:
	HANDLE m_hObject;
	CStringW m_strObjectName;
	CSecurityDesc m_secDesc;
	CSecurityDesc m_secOriginal;

	SI_ACCESS m_access[1];

	CPipeSecurityInformation()
	{
		m_hObject = INVALID_HANDLE_VALUE;
	}

	HRESULT Init(HANDLE hObject, LPCWSTR wszObjectName)
	{
		memset(m_access, 0x00, sizeof(m_access));
		m_access[0].dwFlags = SI_ACCESS_GENERAL;
		m_access[0].pszName = MAKEINTRESOURCEW(IDS_ACCESS_PIPE);
		m_access[0].mask = FILE_GENERIC_WRITE|FILE_GENERIC_READ;

		m_hObject = hObject;
		try
		{
			if (!AtlGetSecurityDescriptor(m_hObject, SE_KERNEL_OBJECT, &m_secDesc, DACL_SECURITY_INFORMATION, true))
				return AtlHresultFromLastError();
		}
		catch (COleException *pE)
		{
			HRESULT hr = pE->m_sc;
			pE->Delete();
			return hr;
		}

		m_secOriginal = m_secDesc;
		m_strObjectName = wszObjectName;
		return S_OK;
	}

	BEGIN_COM_MAP(CPipeSecurityInformation)
		COM_INTERFACE_ENTRY_IID(IID_ISecurityInformation, ISecurityInformation)
	END_COM_MAP()

    // *** ISecurityInformation methods ***
    STDMETHOD(GetObjectInformation)(PSI_OBJECT_INFO pObjectInfo)
	{
		pObjectInfo->dwFlags = SI_EDIT_PERMS|SI_OWNER_READONLY;
		pObjectInfo->hInstance = AfxGetResourceHandle();
		pObjectInfo->pszServerName = NULL;
		pObjectInfo->pszObjectName = const_cast<LPWSTR>(static_cast<LPCWSTR>(m_strObjectName));
		return S_OK;
	}

    STDMETHOD(GetSecurity)(SECURITY_INFORMATION /*RequestedInformation*/,
                            PSECURITY_DESCRIPTOR *ppSecurityDescriptor,
                            BOOL fDefault)
	{
		HRESULT hr;

		if (!ppSecurityDescriptor)
			return E_POINTER;
		*ppSecurityDescriptor = NULL;

		CSecurityDesc *pSecDescToCopy = &m_secDesc;

		if (fDefault)
			pSecDescToCopy = &m_secOriginal;

		DWORD dwSize = 0;
		SECURITY_DESCRIPTOR *pSecDesc = NULL;
		try
		{
			pSecDescToCopy->GetSECURITY_DESCRIPTOR(NULL, &dwSize);
			pSecDesc = (SECURITY_DESCRIPTOR *) LocalAlloc(LHND, dwSize);
			if (!pSecDesc)
				return E_OUTOFMEMORY;
			pSecDescToCopy->GetSECURITY_DESCRIPTOR(pSecDesc, &dwSize);
		}
		catch (COleException *pE)
		{
			LocalFree(pSecDesc);
			hr = pE->m_sc;
			pE->Delete();
			return hr;
		}
		*ppSecurityDescriptor = pSecDesc;
		return S_OK;
	}

    STDMETHOD(SetSecurity)(SECURITY_INFORMATION SecurityInformation,
                            PSECURITY_DESCRIPTOR pSecurityDescriptor)
	{
		if (!pSecurityDescriptor)
			return E_POINTER;

		try
		{
			CSecurityDesc secDesc(*static_cast<SECURITY_DESCRIPTOR*>(pSecurityDescriptor));
			
			secDesc.MakeAbsolute();

			const SECURITY_DESCRIPTOR *pTempSecDesc = secDesc.GetPSECURITY_DESCRIPTOR();

			DWORD dwErr = SetSecurityInfo(m_hObject, SE_KERNEL_OBJECT, SecurityInformation,
				pTempSecDesc->Owner, pTempSecDesc->Group, pTempSecDesc->Dacl,
				pTempSecDesc->Sacl);
			if (dwErr != ERROR_SUCCESS)
				return AtlHresultFromWin32(dwErr);

			if (!AtlGetSecurityDescriptor(m_hObject, SE_KERNEL_OBJECT, &m_secDesc, DACL_SECURITY_INFORMATION, true))
				return AtlHresultFromLastError();
		}
		catch (COleException *pE)
		{
			HRESULT hr = pE->m_sc;
			pE->Delete();
			return hr;
		}
		return S_OK;
	}

    STDMETHOD(GetAccessRights) (const GUID* pguidObjectType,
                                DWORD /*dwFlags*/,
                                PSI_ACCESS *ppAccess,
                                ULONG *pcAccesses,
                                ULONG *piDefaultAccess)
	{
		if (pguidObjectType && !InlineIsEqualGUID(*pguidObjectType, GUID_NULL))
			return E_INVALIDARG;
		
		*ppAccess = m_access;
		*pcAccesses = sizeof(m_access)/sizeof(m_access[0]);
		*piDefaultAccess = 0;
		return S_OK;
	}

    STDMETHOD(MapGeneric) (const GUID *pguidObjectType,
                           UCHAR * /*pAceFlags*/,
                           ACCESS_MASK *pMask)
	{
		if (pguidObjectType && !InlineIsEqualGUID(*pguidObjectType, GUID_NULL))
			return E_INVALIDARG;
		GENERIC_MAPPING mapping;
		mapping.GenericAll = FILE_WRITE_DATA|FILE_READ_DATA|FILE_CREATE_PIPE_INSTANCE;
		mapping.GenericWrite = FILE_WRITE_DATA|FILE_CREATE_PIPE_INSTANCE;
		mapping.GenericRead = FILE_READ_DATA|FILE_CREATE_PIPE_INSTANCE;
		mapping.GenericExecute = 0;
		::MapGenericMask(pMask, &mapping);
		return S_OK;
	}
    
	STDMETHOD(GetInheritTypes) (PSI_INHERIT_TYPE *ppInheritTypes,
                                ULONG *pcInheritTypes)
	{
		if (!ppInheritTypes)
			return E_POINTER;

		*ppInheritTypes = NULL;
		
		if (!pcInheritTypes)
			return E_POINTER;

		*pcInheritTypes = 0;
		return S_OK;
	}

    STDMETHOD(PropertySheetPageCallback)(HWND /*hwnd*/, UINT /*uMsg*/, SI_PAGE_TYPE /*uPage*/)
	{
		return S_OK;
	}
};

UINT PipeServerThread(void* /* pvContext */)
{
	DWORD dwRead;

	HANDLE hPipe = theApp.GetPipe();
	if (hPipe == INVALID_HANDLE_VALUE)
		return 1;

	DEBUG_SERVER_MESSAGE Message;

	//Get the debugger
	TCHAR lpszDebugger[2048];
	TCHAR lpszCommandLine[500];
	TCHAR lpszExe[256];
	ULONG cbSize = 2048;
	HKEY hKey;
	RegOpenKeyEx(HKEY_LOCAL_MACHINE, _T("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AeDebug"), 0, KEY_READ, &hKey);
	RegQueryValueEx(hKey, _T("Debugger"), NULL, NULL, (unsigned char*) lpszDebugger, &cbSize);


	//Extract the name of the executable and the command line parameters
	//NOTE: I don't think this is portable

	//Skip the "
	int nDi = 0; 
	int nEi = 0;
	int nCi = 0;
	BOOL bBreakOnSpace = TRUE;

	//If the string starts with a ", don't break on space
	if (lpszDebugger[nDi] == _T('\"')) 
	{
		bBreakOnSpace = FALSE;
		nDi++;
	}	

	//Get the executable string
	while (1)
	{
		TCHAR ch = lpszDebugger[nDi++];
		if (bBreakOnSpace && ch == ' ')
			break;
		else if (ch == _T('\"'))
			break;
		lpszExe[nEi++] = ch;
	}
	
	//Make sure it's null terminated
	lpszExe[nEi] = '\0';

	while (1)
	{
		lpszCommandLine[nCi] = lpszDebugger[nDi++];

		//when we reach the end of the string recovered from the registry, break
		if (lpszCommandLine[nCi++] == '\0')
			break;
	}

	//intialize STARTUPINFO structure for CreateProcess
	STARTUPINFO startInfo;
	startInfo.cb = sizeof(STARTUPINFO);
	startInfo.lpReserved = NULL;
	startInfo.lpDesktop = NULL;
	startInfo.lpTitle = NULL;
	startInfo.dwFlags = 0;
	startInfo.cbReserved2 = 0;
	startInfo.lpReserved2 = NULL;


	ThreadMessageParam threadMessage;

	//Create an event to synchronize on for TRACE and ASSERT messages
	threadMessage.hEvent = CreateEvent(NULL, FALSE, NULL, NULL);
	if (threadMessage.hEvent == INVALID_HANDLE_VALUE)
	{
		return 1;
	}
	LPTSTR szMessage;
	LPTSTR szClientName;
	TCHAR szStackInfo[1025];
	CString strStackTrace;
	TCHAR szComputerName[MAX_COMPUTERNAME_LENGTH+1];
	DWORD dwComputerNameLen = sizeof(szComputerName)/sizeof(TCHAR)+sizeof(TCHAR);
	GetComputerName(szComputerName, &dwComputerNameLen);
	
	while (1)
	{
		strStackTrace.Empty();
		ConnectNamedPipe(hPipe, NULL);
		
		//Read the DEBUG_SERVER_MESSAGE structure from the pipe 
		BOOL bRet = ReadFile(hPipe, &Message, sizeof(Message), &dwRead, NULL);

		if (!bRet)
		{
//			TCHAR szErr[256];
//			sprintf(szErr, _T("Cannot Read From Pipe\r\nGetLastError() returned %d"), GetLastError());
//			theApp.m_pMainWnd->MessageBox(szErr, _T("Error"), MB_OK);
			DisconnectNamedPipe(hPipe);
			continue;
		}

		//If it is a quit Message from ExitInstance, break out of the loop
		if (Message.dwType == DEBUG_SERVER_MESSAGE_QUIT)
		{
			DisconnectNamedPipe(hPipe);
			break;
		}

		//Attempt to read the assert or trace text from the pipe
		szClientName = (LPTSTR)_alloca(sizeof(TCHAR)*Message.dwClientNameLen);
		bRet = ReadFile(hPipe, szClientName, Message.dwClientNameLen, &dwRead, NULL);
		if (!bRet)
		{
			DisconnectNamedPipe(hPipe);
			continue;
		}

		//Attempt to read the assert or trace text from the pipe
		szMessage = (LPTSTR)_alloca(sizeof(TCHAR)*Message.dwTextLen);
		bRet = ReadFile(hPipe, szMessage, Message.dwTextLen, &dwRead, NULL);
		if (!bRet)
		{
//			TCHAR szErr[256];
//			sprintf(szErr, _T("Cannot Read From Pipe\r\nGetLastError() returned %d"), GetLastError());
//			theApp.m_pMainWnd->MessageBox(szErr, _T("Error"), MB_OK);
			DisconnectNamedPipe(hPipe);
			continue;
		}

		//If it is a trace message
		if (Message.dwType == DEBUG_SERVER_MESSAGE_TRACE)
		{
			threadMessage.nMsgType = HPS_TRACE_MESSAGE;
		}
		else
		{
			threadMessage.nMsgType = HPS_ASSERT_MESSAGE;
		}
		
		theApp.m_pMainWnd->SendMessage(WM_USER, (WPARAM)szMessage, (LPARAM)&threadMessage);
		int nRet = threadMessage.nRet;

		//If we want stack trace information
		if (nRet == IDOK)
		{
			if (theApp.WantStackTrace())
			{
				int nStack = 1;
				WriteFile(hPipe, &nStack, sizeof(nStack), &dwRead, NULL);
				do
				{
					nRet = ReadFile(hPipe, szStackInfo, 1024, &dwRead, NULL);
					if (!nRet && GetLastError() != ERROR_MORE_DATA)
					{
						//Can't properly recover from this type of error
						//So clean up and return
						DisconnectNamedPipe(hPipe);
						CloseHandle(threadMessage.hEvent);
						return 0;
					}
					//concatenate
					strStackTrace += szStackInfo;
				} while (!nRet); //Repeat loop while ERROR_MORE_DATA
			}
			else //Else we just want to read the assert/trace message text
			{
				int nStack = 0;
				WriteFile(hPipe, &nStack, sizeof(nStack), &dwRead, NULL);
				strStackTrace = _T("");
			}
			CDebugDialog dlg(theApp.m_pMainWnd, theApp.WantStackTrace(), (_tcscmp(szClientName, szComputerName) == 0));
			dlg.InitData(threadMessage.nMsgType, Message.dwProcessId, szMessage, strStackTrace);
			nRet = dlg.DoModal();
		}
			
		switch (nRet)
		{
			case IDRETRY:
			{
				if (!Message.bIsDebuggerAttached)
				{
					SECURITY_ATTRIBUTES sa;
					sa.nLength = sizeof(sa);
					sa.lpSecurityDescriptor = NULL;
					sa.bInheritHandle = TRUE;
					HANDLE hEvent = CreateEvent(&sa, TRUE, FALSE, NULL);

					//Build the command line with the processId and event
					TCHAR lpszCmdLine[500];
					_stprintf(lpszCmdLine, lpszCommandLine, Message.dwProcessId, hEvent);

					PROCESS_INFORMATION processInfo;
					bRet = CreateProcess(lpszExe, lpszCmdLine, NULL, NULL, TRUE, 
						CREATE_DEFAULT_ERROR_MODE |CREATE_NEW_PROCESS_GROUP | NORMAL_PRIORITY_CLASS, 
						NULL, NULL, &startInfo, &processInfo);

					//We don't need these
					CloseHandle(processInfo.hProcess);
					CloseHandle(processInfo.hThread);

					theApp.m_pMainWnd->SetForegroundWindow();
					WaitForSingleObject(hEvent, 60000);

					CloseHandle(hEvent);
				}
				nRet = 1;
				break;
			}
			case IDABORT:
			{
				nRet = 2;
				break;
			}
			case IDCANCEL:
			case IDIGNORE:
			{
				nRet = 0;
				break;
			}
		}
		
		//Write the return value back to the pipe
		bRet = WriteFile(hPipe, &nRet, sizeof(nRet), &dwRead, NULL);
		if (!bRet)
		{
//			TCHAR szErr[256];
//			sprintf(szErr, _T("Cannot Write To Pipe\r\nGetLastError() returned %d"), GetLastError());
//			theApp.m_pMainWnd->MessageBox(szErr, _T("Error"), MB_OK);
			DisconnectNamedPipe(hPipe);
			continue;
		}
		FlushFileBuffers(hPipe);
		DisconnectNamedPipe(hPipe);
	}
	CloseHandle(threadMessage.hEvent);

	return 0;
}


/////////////////////////////////////////////////////////////////////////////
// CWebDbgApp construction

CWebDbgApp::CWebDbgApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
	m_nCmdShow = SW_SHOW;
	m_strPipeName = _T("\\\\.\\pipe\\AtlsDbgPipe");
	m_hPipe = INVALID_HANDLE_VALUE;
}

CWebDbgApp::~CWebDbgApp()
{
	if (m_hPipe != INVALID_HANDLE_VALUE)
		CloseHandle(m_hPipe);
}

/////////////////////////////////////////////////////////////////////////////
// CWebDbgApp initialization

BOOL CWebDbgApp::InitInstance()
{
	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

	// Change the registry key under which our settings are stored.
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization.
	SetRegistryKey(_T("HPS"));

	
	BOOL bFound = FALSE;
    m_hMutexOneInstance = CreateMutex(NULL,TRUE,_T("WebDbgOneInstanceOnly"));
    if(GetLastError() == ERROR_ALREADY_EXISTS)
        bFound = TRUE;
    if(m_hMutexOneInstance) 
        ReleaseMutex(m_hMutexOneInstance);
	

	if (!bFound)
	{
		// To create the main window, this code creates a new frame window
		// object and then sets it as the application's main window object.
		CMainFrame* pFrame = new CMainFrame;
		m_pMainWnd = pFrame;

		m_bWantStackTrace = GetProfileInt(_T("Settings"), _T("StackTrace"), 0);

		// create and load the frame with its resources

		pFrame->LoadFrame(IDR_MAINFRAME,
			WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, NULL,
			NULL);

		// The one and only window has been initialized, so show and update it.
		pFrame->ShowWindow(m_nCmdShow);
		pFrame->UpdateWindow();

		// create the named pipe
		if (!CreatePipe())
			return FALSE;
		BeginPipeThread();
	}

	return (bFound == TRUE ? FALSE : TRUE);
}

BOOL CWebDbgApp::CreatePipe()
{
	m_hPipe = CreateNamedPipe(theApp.GetPipeName(),
		PIPE_ACCESS_DUPLEX | WRITE_DAC, PIPE_TYPE_MESSAGE | PIPE_READMODE_MESSAGE | PIPE_WAIT, 
		PIPE_UNLIMITED_INSTANCES, 1024, 4096, 20000, NULL);
	
	if (m_hPipe == INVALID_HANDLE_VALUE)
	{
		AfxMessageBox(IDS_FAILED_CREATING_PIPE, MB_ICONSTOP);
		return FALSE;
	}
	else if (GetLastError() == ERROR_ALREADY_EXISTS)
	{
		CloseHandle(m_hPipe);
		m_hPipe = INVALID_HANDLE_VALUE;
		AfxMessageBox(IDS_PIPEALREADYEXISTS, MB_ICONSTOP);
		return FALSE;
	}
	return TRUE;
}

void CWebDbgApp::BeginPipeThread()
{
	AfxBeginThread(PipeServerThread, (void*) GetCurrentThreadId());
}

void CWebDbgApp::QuitPipeThread()
{
	DEBUG_SERVER_MESSAGE Message;
	memset(&Message, 0x00, sizeof(Message));

	//Send a quit message to the PipeServerThread
	Message.dwType = DEBUG_SERVER_MESSAGE_QUIT;

	SendPipeMessage(&Message);
}

BOOL CWebDbgApp::ExitInstance()
{
	QuitPipeThread();

	WriteProfileInt(_T("Settings"), _T("StackTrace"), m_bWantStackTrace);

	ReleaseMutex(m_hMutexOneInstance);

	return CWinApp::ExitInstance();
}


/////////////////////////////////////////////////////////////////////////////
// CWebDbgApp message handlers





/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
		// No message handlers
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

// App command to run the dialog
void CWebDbgApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

/////////////////////////////////////////////////////////////////////////////
// CWebDbgApp message handlers

void CWebDbgApp::OnViewStacktrace() 
{
	m_bWantStackTrace = !m_bWantStackTrace;
}


BOOL CWebDbgApp::WantStackTrace()
{
	return m_bWantStackTrace;
}

void CWebDbgApp::OnUpdateViewStacktrace(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck(m_bWantStackTrace ? 1 : 0);
}

void CWebDbgApp::OnAppPipe()
{
	CPipeDlg dlg;
	int nItem = m_strPipeName.ReverseFind(_T('\\'));
	dlg.m_PipeName = m_strPipeName.Right(m_strPipeName.GetLength()-nItem-1);
	int nRet = dlg.DoModal();
	if (nRet == IDOK)
	{
		// update the pipe name
		if ((dlg.m_PipeName.GetLength()) && (dlg.m_PipeName.GetLength() < MAX_PATH-10))
		{
			QuitPipeThread();

			if (!CreatePipe())
			{
				AfxPostQuitMessage(1);
				return;
			}

			m_strPipeName.Format(_T("\\\\.\\pipe\\%s"), (LPCTSTR)dlg.m_PipeName);

			BeginPipeThread();
		}
	}
}

typedef BOOL (__stdcall *PFNEDITSECURITY)(HWND, LPSECURITYINFO);

void CWebDbgApp::OnAppPermissions()
{
	HMODULE hDll = LoadLibrary(_T("aclui.dll"));
	if (hDll == NULL)
	{
		AfxMessageBox(IDS_ACLUI_REQUIRED, MB_ICONEXCLAMATION);
		return;
	}

	PFNEDITSECURITY pfnEditSecurity = (PFNEDITSECURITY) GetProcAddress(hDll, "EditSecurity");
	if (!pfnEditSecurity)
	{
		FreeLibrary(hDll);
		AfxMessageBox(IDS_ACLUI_REQUIRED, MB_ICONEXCLAMATION);
		return;
	}
	
	// turn of the pipe thread
	QuitPipeThread();

	do
	{
		CComObjectNoLock<CPipeSecurityInformation> *psecInfo = new CComObjectNoLock<CPipeSecurityInformation>();
		HRESULT hr = psecInfo->Init(m_hPipe, CT2W(GetPipeName()));
		if (FAILED(hr))
		{
			LPVOID lpMsgBuf;
			if (FormatMessage( 
				FORMAT_MESSAGE_ALLOCATE_BUFFER | 
				FORMAT_MESSAGE_FROM_SYSTEM | 
				FORMAT_MESSAGE_IGNORE_INSERTS,
				NULL,
				hr,
				MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), // Default language
				(LPTSTR) &lpMsgBuf,
				0,
				NULL 
			) != 0)
			{
				// Process any inserts in lpMsgBuf.
				// ...
				// Display the string.
				AfxMessageBox((LPCTSTR)lpMsgBuf, NULL, MB_ICONSTOP);
				// Free the buffer.
				LocalFree( lpMsgBuf );
			}
			else
				AfxMessageBox(IDS_UNKNOWN_ERROR, MB_ICONSTOP);
		}
		else
		{
			// We're ignoring the error here since if the user
			// canceled or an error occurs, we should have
			// the previous permissions
			(*pfnEditSecurity)(AfxGetMainWnd()->m_hWnd, psecInfo);
		}

		// before we recreate the pipe thread
		// make sure that the current user
		// has access to read/write from/to the pipe
		// since we use the pipe to control
		// the thread.  If the user cannot access
		// the pipe, then we have no way of shutting down
		// the pipe thread

		hr = TestAccessToPipe();

		if (hr == E_ACCESSDENIED)
		{
			AfxMessageBox(IDS_ACCESSDENIED, MB_ICONSTOP);
		}
		else
		{
			 if (FAILED(hr) && hr != HRESULT_FROM_WIN32(ERROR_PIPE_BUSY))
				AfxMessageBox(IDS_UNKNOWN_ERROR, MB_ICONSTOP);
			break;
		}
	} while (TRUE);

	BeginPipeThread();

	FreeLibrary(hDll);
}

// Try to open a handle to the named pipe.
// This function should only be called when
// the PipeServerThread is not running
HRESULT CWebDbgApp::TestAccessToPipe()
{
	HRESULT hr = S_OK;
	HANDLE hPipe = CreateFile(m_strPipeName, GENERIC_WRITE | GENERIC_READ,
		FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL);
		
	if (hPipe == INVALID_HANDLE_VALUE)
	{
		DWORD dwError = GetLastError();
		// we ignore ERROR_PIPE_BUSY since
		// we know no one is listining
		// on the pipe
		if (dwError != ERROR_PIPE_BUSY)
		{
			hr = HRESULT_FROM_WIN32(dwError);
		}
	}
	else
	{
		if (GetFileType(hPipe) != FILE_TYPE_PIPE)
		{
			hr = E_INVALIDARG;
		}
		CloseHandle(hPipe);
	}

	return hr;
}

// Send a message to the pipe.  The message cannot require getting
// a response from the server
HRESULT CWebDbgApp::SendPipeMessage(const DEBUG_SERVER_MESSAGE *pMsg)
{
	HRESULT hr = S_OK;
	DWORD dwWritten;

	//Open the pipe for writing
	HANDLE hPipe = CreateFile(m_strPipeName, GENERIC_WRITE | GENERIC_READ,
		FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL);
		
	if (hPipe == INVALID_HANDLE_VALUE)
	{
		hr = AtlHresultFromLastError();
	}
	else
	{
		if (GetFileType(hPipe) != FILE_TYPE_PIPE)
		{
			hr = E_INVALIDARG;
		}
		else
		{
			if (!WriteFile(hPipe, pMsg, sizeof(DEBUG_SERVER_MESSAGE), &dwWritten, NULL) ||
					dwWritten != sizeof(DEBUG_SERVER_MESSAGE))
			hr = AtlHresultFromLastError();
			DisconnectNamedPipe(hPipe);
		}

		CloseHandle(hPipe);
	}
	return hr;
}

