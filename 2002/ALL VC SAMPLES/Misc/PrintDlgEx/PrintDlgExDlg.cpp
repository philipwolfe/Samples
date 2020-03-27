// PrintDlgExDlg.cpp : implementation file
//

#include "stdafx.h"
#include "PrintDlgEx.h"
#include "PrintDlgExDlg.h"

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


// CPrintDlgExDlg dialog



CPrintDlgExDlg::CPrintDlgExDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPrintDlgExDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CPrintDlgExDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CPrintDlgExDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_BN_CLICKED(ID_PRINT, OnPrint)
	ON_BN_CLICKED(ID_PRINT_NEW, OnPrintNew)
END_MESSAGE_MAP()


// CPrintDlgExDlg message handlers

BOOL CPrintDlgExDlg::OnInitDialog()
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

void CPrintDlgExDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CPrintDlgExDlg::OnPaint() 
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
HCURSOR CPrintDlgExDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

//*******************************************************************
//	OnPrint
//		Handles Print button. Calls old fashion Print Dialog,
//		gets Printer device context and calls function to print
//		text from edit box.
//*******************************************************************
void CPrintDlgExDlg::OnPrint()
{
	// Create old fashion print dialog.
	CPrintDialog dlgPrint(FALSE);

	// Show the dialog, if user press OK button, DoModal
	// function returns IDOK, so we prints.
	if(dlgPrint.DoModal() == IDOK)
	{
		HDC hdc = dlgPrint.GetPrinterDC();
		// Print using device context we got from dialog.
		Print(hdc);

		// Clean up. We are responsible for deleting the device context.
		::DeleteDC(hdc);
	}
}

//*******************************************************************
//	OnPrintNew
//		Handles "Print new style"  button. Calls W2K type
//		Print Dialog, gets Printer device context and calls function
//		to print text from edit box.
//*******************************************************************
void CPrintDlgExDlg::OnPrintNew()
{
	// Create new looking Print Dialog with default flags.
	CPrintDialogEx dlgPrint;

	// After constructing a CPrintDialogEx object, you can use
	// m_pdex member to set various aspects of the dialog box before
	// calling the DoModal member function. For more information on
	// the m_pdex structure, see PRINTDLGEX in the Platform SDK.

	// To obtain device context from dialog we should set this flag.
	dlgPrint.m_pdex.Flags |= PD_RETURNDC;

	// Documentation says that this member must be a valid window handle;
	// it cannot be NULL. Let's make it happy.
	dlgPrint.m_pdex.hwndOwner = GetSafeHwnd();

	// To find out what action was chosen another technique is used
	// for CPrintDialogEx class.
	// INT_PTR value that DoModal function returns is actually an HRESULT.
	// DoModal calls PrintDlgEx internally and passes it's returned value.
	// See the Return Values section in PrintDlgEx in the Platform SDK.
	//
	// So at first we check if DoModal call succeeded and if it is,
	// the dwResultAction member of the m_pdex structure contains the
	// outcome of the dialog.

	// The dwResultAction can be one of the following values:
	// PD_RESULT_APPLY - The user clicked the Apply button and later clicked
	//				     the Cancel button,
	// PD_RESULT_CANCEL - The user clicked the Cancel button.
	// PD_RESULT_PRINT - The user clicked the Print button.
	if(dlgPrint.DoModal() == S_OK && dlgPrint.m_pdex.dwResultAction)
	{
		HDC hdc = dlgPrint.GetPrinterDC();
		// Print using device context we got from dialog.
		Print(hdc);

		// Clean up. We are responsible for deleting the device context.
		::DeleteDC(hdc);
	}
}

//*******************************************************************
//	Print
//		Prints content of the edit box to the printer.
//
//	PARAMS:	hdc - handle of the printer device context to print.
//*******************************************************************
void CPrintDlgExDlg::Print(HDC hdc)
{
	// Check device context.
	if(hdc == NULL)
		return;

	CWnd* pEdit;				// Pointer to the edit box window.
	CString strTextToPrint;		// Text from the edit box.
	CString strRow;				// Row that we print.

	// Obtain text from the edit box.
	// Print default string if empty.
	pEdit = GetDlgItem(IDC_EDIT);

	if(pEdit != NULL)
		GetDlgItemText(IDC_EDIT, strTextToPrint);

	if(strTextToPrint.IsEmpty())
		strTextToPrint = _T("There is nothing to print");

	// Replace tabs with spaces.
	strTextToPrint.Replace(_T("\t"), _T("    "));

	// Create a CDC from the passed handle to the printer device context.
	CDC dcPrinter;
	dcPrinter.Attach(hdc);

	// Call StartDoc() to begin printing.
	DOCINFO docinfo;
	memset(&docinfo, 0, sizeof(docinfo));
	docinfo.cbSize = sizeof(docinfo);
	docinfo.lpszDocName = _T("MFC Windows 2000 print dialog demo");

	// If it fails, complain and exit gracefully.
	if (dcPrinter.StartDoc(&docinfo) < 0)
	{
		MessageBox(_T("Printer wouldn't initialize"));
		return;
	}

	// Start a page.
	if (dcPrinter.StartPage() < 0)
	{
		MessageBox(_T("Could not start page"));
		dcPrinter.AbortDoc();
		return;
	}

	int nX;				// X coordinate of the text to print.
	int nY;				// X coordinate of the text to print..
	int nRowHeight;		// Height of the row of text on printer.
	TEXTMETRIC tm;

	// Get text height.
	dcPrinter.GetTextMetrics(&tm);
	nRowHeight = tm.tmHeight + tm.tmExternalLeading;

	// Get page margins.
	nX = dcPrinter.GetDeviceCaps(PHYSICALOFFSETX);
	nY = dcPrinter.GetDeviceCaps(PHYSICALOFFSETY);


	int nBegin = 0;
	int nEnd = 0;
	int nLength = strTextToPrint.GetLength();

	// Parse multiline text into rows.
	do
	{
		// Get next end of line symbol.
		nEnd = strTextToPrint.Find("\r\n", nBegin);

		// If it is not the last row, extract the next row and
		// adjust position to begin next iteration.
		if(nEnd >=0)
		{
			strRow = strTextToPrint.Mid(nBegin, nEnd-nBegin);
			nBegin = nEnd + 2;
		}
		// It is a last row, get it all.
		else
			strRow = strTextToPrint.Mid(nBegin);

		// Print current row on printer.
		dcPrinter.TextOut(nX, nY, strRow, strRow.GetLength());

		// Adjust y position to print new row.
		nY += nRowHeight;

		// We reached end of text, so exit from loop.
		if(nBegin >= nLength)
			break;

	}while(nEnd >= 0);

	// Finish print job.
	dcPrinter.EndPage();
	dcPrinter.EndDoc();

	return;
}
