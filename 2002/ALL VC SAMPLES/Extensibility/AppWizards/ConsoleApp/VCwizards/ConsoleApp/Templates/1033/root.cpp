// [!output PROJECT_NAME].cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
[!if SUPPORT_MFC]
#include "[!output PROJECT_NAME].h"
[!endif]


[!if SUPPORT_MFC]
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// The one and only application object

CWinApp theApp;

using namespace std;

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	// initialize MFC and print and error on failure
	if (!AfxWinInit(::GetModuleHandle(NULL), NULL, ::GetCommandLine(), 0))
	{
		// TODO: change error code to suit your needs
		cerr << _T("Fatal Error: MFC initialization failed") << endl;
		nRetCode = 1;
	}
	else
	{
		// TODO: code your application's behavior here.
	}

	return nRetCode;
}
[!else]

int main(int argc, char* argv[])
{
	return 0;
}
[!endif]
