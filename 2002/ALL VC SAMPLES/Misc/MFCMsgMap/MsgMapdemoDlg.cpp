// MsgMapdemoDlg.cpp : implementation file
//

#include "stdafx.h"
#include "MsgMapdemo.h"
#include "MsgMapdemoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CMsgMapdemoDlg dialog



CMsgMapdemoDlg::CMsgMapdemoDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CMsgMapdemoDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CMsgMapdemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CMsgMapdemoDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(ID_BTN_OK, OnBtnClicked)
	//}}AFX_MSG_MAP
	ON_MESSAGE(WM_USER_MESSAGE, OnUserMessage)
END_MESSAGE_MAP()


// CMsgMapdemoDlg message handlers

BOOL CMsgMapdemoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CMsgMapdemoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CMsgMapdemoDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CMsgMapdemoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

//*******************************************************************
//	OnUserMessage
//
//		Handles WM_USER_MESSAGE user message.
//		Advances the current position for a progress bar by the step.
//*******************************************************************
LRESULT CMsgMapdemoDlg::OnUserMessage(WPARAM wParam, LPARAM lParam)
//LRESULT CMsgMapDemoDlg::OnUserMessage(WPARAM wParam);	// 1. Try it in VC6 release build, it will crash.
														// In VC7 it will give you Compiler Error C2440.
//LRESULT CMsgMapDemoDlg::OnUserMessage();				// 2. Try it in VC6 release build, it will crash.
														// In VC7 it will give you Compiler Error C2440.
//void CMsgMapDemoDlg::OnUserMessage();					// 3. Try it in VC6 release build, it will crash.
														// In VC7 it will give you Compiler Error C2440.
														// Do not forget to update header file
														// with the function definitions.
{
	CWnd* pProgress;

	// Get a pointer to the progress bar window.
	pProgress = GetDlgItem(IDC_PROGRESS);

	// Move progress bar indicator one step.
	if(pProgress != NULL)
		pProgress->SendMessage(PBM_STEPIT);

	return 0;
}

//*******************************************************************
//	OnBtnClicked
//
//		Handles pressing dialog button.
//*******************************************************************
void CMsgMapdemoDlg::OnBtnClicked() 
{
	// Send use defined messasge to move progress indicator.
	SendMessage(WM_USER_MESSAGE);
}
