// DriveDlg.cpp : implementation file
//

#include "premdriv.h"
#include "MDrive.h"
#include "DriveDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#include "driver.h"

HDC hDrawDC;
int nHeight;
int nThreads=0;

/////////////////////////////////////////////////////////////////////////////
// CMDriveDlg dialog

CMDriveDlg::CMDriveDlg(CWnd* pParent /*=NULL*/)
    : CDialog(CMDriveDlg::IDD, pParent)
{
    //{{AFX_DATA_INIT(CMDriveDlg)
        // NOTE: the ClassWizard will add member initialization here
    //}}AFX_DATA_INIT
    // Note that LoadIcon does not require a subsequent DestroyIcon in Win32
    m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
    m_nAdviseCnt = 0;
    m_arrAdvise = NULL;
}

void CMDriveDlg::DoDataExchange(CDataExchange* pDX)
{
    CDialog::DoDataExchange(pDX);
    //{{AFX_DATA_MAP(CMDriveDlg)
        // NOTE: the ClassWizard will add DDX and DDV calls here
    //}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CMDriveDlg, CDialog)
    //{{AFX_MSG_MAP(CMDriveDlg)
    ON_WM_PAINT()
    ON_WM_QUERYDRAGICON()
    ON_BN_CLICKED(IDB_START, OnStart)
    ON_BN_CLICKED(IDB_STOP, OnStop)
    ON_BN_CLICKED(IDB_STOP_ALL, OnStopAll)
    ON_BN_CLICKED(IDB_ADVISE, OnAdvise)
    ON_BN_CLICKED(IDB_UNADVISE, OnUnadvise)
    //}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMDriveDlg message handlers

BOOL CMDriveDlg::OnInitDialog()
{
    CDialog::OnInitDialog();

    // Set the icon for this dialog.  The framework does this automatically
    //  when the application's main window is not a dialog
    SetIcon(m_hIcon, TRUE);         // Set big icon
    SetIcon(m_hIcon, FALSE);        // Set small icon
    
    CWnd* pWnd = GetDlgItem(IDC_PICTURE);
    hDrawDC = ::GetDC(pWnd->m_hWnd);
    CRect rect;
    pWnd->GetClientRect(&rect);
    nHeight = rect.Height();
    m_nMaxAdvises = rect.Width();
    m_arrAdvise = new DWORD[m_nMaxAdvises];

    if (FAILED(pRandom.CreateInstance(__uuidof(CoRandom))))
        AfxMessageBox("Could not create IRandom\n");
    
    return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CMDriveDlg::OnPaint() 
{
    if (IsIconic())
    {
        CPaintDC dc(this); // device context for painting

        SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

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
HCURSOR CMDriveDlg::OnQueryDragIcon()
{
    return (HCURSOR) m_hIcon;
}

void CMDriveDlg::OnStart() 
{
    if (nThreads < nMaxThreads)
    {
        if (SUCCEEDED(pRandom->get_Start(&m_arrID[nThreads])))
            nThreads++;
    }
}

void CMDriveDlg::OnStop() 
{
    if (nThreads > 0)
        Stop();
}

void CMDriveDlg::OnStopAll() 
{
    while (Stop())
        ;
}

BOOL CMDriveDlg::Stop()
{
    if (nThreads > 0)
    {
        pRandom->Stop = m_arrID[nThreads-1];
        --nThreads;
        return TRUE;
    }
    else
        return FALSE;
}

void CMDriveDlg::OnCancel() 
{
    OnStopAll();
    while (Unadvise())
        ;
    ::ReleaseDC(GetDlgItem(IDC_PICTURE)->m_hWnd, hDrawDC);
    CDialog::OnCancel();
}

void CMDriveDlg::OnOK() 
{
    OnStopAll();
    while (Unadvise())
        ;
    ::ReleaseDC(GetDlgItem(IDC_PICTURE)->m_hWnd, hDrawDC);
    CDialog::OnOK();
}

void CMDriveDlg::OnAdvise() 
{
    if (m_nAdviseCnt < m_nMaxAdvises)
    {
        IConnectionPointContainerPtr pCPC;
        IConnectionPointPtr pCP;
        IRandomEventPtr pRandomEvent;
        
        HRESULT hRes = S_OK;
        // Belaboring the point -- this is essentially CoCreateInstance
        CRandomEventClassFactory* pFact = new CRandomEventClassFactory;
        if (pFact == 0)
            hRes = E_OUTOFMEMORY;
        if (SUCCEEDED(hRes))
            hRes = pFact->CreateInstance(NULL, __uuidof(IRandomEvent), (void**) &pRandomEvent);
        delete pFact;
        
        pRandomEvent->ID = m_nAdviseCnt;
        try {
        if (SUCCEEDED(hRes))
            pCPC = pRandom;
        } catch(...) {
        AfxMessageBox("OnAdvise(IRandom::QI(IID_IConnectionPointContainer) Failed)\n");
        }
        if (SUCCEEDED(hRes))
            hRes = pCPC->FindConnectionPoint(__uuidof(IRandomEvent), &pCP);
        if (SUCCEEDED(hRes))
            hRes = pCP->Advise(pRandomEvent, &m_arrAdvise[m_nAdviseCnt++]);
        if (FAILED(hRes))
        {
            AfxMessageBox("Advise failed");
            m_nAdviseCnt--;
        }
    }
    else
        AfxMessageBox("No more advises");
}

void CMDriveDlg::OnUnadvise() 
{
    if (!Unadvise())
        AfxMessageBox("Unadvise failed");
}

BOOL CMDriveDlg::Unadvise()
{
    if (m_nAdviseCnt > 0)
    {
        IConnectionPointContainerPtr pCPC;
        IConnectionPointPtr pCP;
        try {
        pCPC = pRandom;
        } catch(...) {
        AfxMessageBox("OnAdvise(IRandom::QI(IID_IConnectionPointContainer) Failed)\n");
        return FALSE;
        }
        HRESULT hRes = pCPC->FindConnectionPoint(__uuidof(IRandomEvent), &pCP);
        if (SUCCEEDED(hRes))
            hRes = pCP->Unadvise(m_arrAdvise[--m_nAdviseCnt]);
        return (SUCCEEDED(hRes));
    }
    else
        return FALSE;
}
