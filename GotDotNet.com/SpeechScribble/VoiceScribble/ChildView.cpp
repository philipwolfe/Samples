// ChildView.cpp : implementation of the CChildView class
//

#include "stdafx.h"
#include "Scribble.h"
#include "ChildView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



#define	IDC_RICH_EDIT_CTRL		101
/////////////////////////////////////////////////////////////////////////////
// CChildView
IMPLEMENT_DYNCREATE(CChildView, CWnd)
CChildView::CChildView()
{


	LOGFONT		lf;
	memset( &lf, 0, sizeof(LOGFONT));
	strcpy(lf.lfFaceName, "Courier New");
	lf.lfHeight		=	16;

	m_fontDefault.CreateFontIndirect( &lf );
}

CChildView::~CChildView()
{
}


BEGIN_MESSAGE_MAP(CChildView,	CWnd)
	//{{AFX_MSG_MAP(CChildView)
	ON_WM_CREATE()
	ON_WM_SIZE()
	ON_WM_CLOSE()
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_EDIT_COPY, OnEditCopy)
	ON_UPDATE_COMMAND_UI(ID_EDIT_COPY, OnUpdateEditCopy)
	ON_COMMAND(ID_EDIT_CUT, OnEditCut)
	ON_UPDATE_COMMAND_UI(ID_EDIT_CUT, OnUpdateEditCut)
	ON_COMMAND(ID_EDIT_PASTE, OnEditPaste)
	ON_UPDATE_COMMAND_UI(ID_EDIT_PASTE, OnUpdateEditPaste)
	ON_COMMAND(ID_EDIT_CLEAR, OnEditClear)
	ON_COMMAND(ID_EDIT_SELECT_ALL, OnEditSelectAll)
	ON_UPDATE_COMMAND_UI(ID_EDIT_SELECT_ALL, OnUpdateEditSelectAll)
	ON_WM_SETFOCUS()
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// CChildView message handlers

BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(NULL, IDC_ARROW), HBRUSH(COLOR_WINDOW+1), NULL);

	return TRUE;
}

int CChildView::OnCreate( LPCREATESTRUCT lpCS)
{
	int	iRet	=	CWnd::OnCreate(lpCS );
	DWORD	dwMask	;
	if(  iRet  >= 0 )
	{
		
		CRect	rc(0, 0, 0, 0);
		CHARFORMAT	cf;



		DWORD	dwStyle	=	WS_CHILD | WS_VISIBLE| WS_VSCROLL | WS_HSCROLL;
		dwStyle	|=	ES_AUTOHSCROLL |ES_AUTOVSCROLL|ES_LEFT |ES_MULTILINE ;
		

		_editCtrl.Create(dwStyle, rc, this, IDC_RICH_EDIT_CTRL);

		dwMask	=	_editCtrl.GetEventMask();
		dwMask	|=	ENM_CHANGE|ENM_SELCHANGE|ENM_KEYEVENTS|ENM_MOUSEEVENTS;
		
		_editCtrl.SetEventMask( dwMask);
		dwMask	=	_editCtrl.GetEventMask();

		_editCtrl.GetDefaultCharFormat(cf);
		cf.dwMask	|=	CFM_FACE | CFM_SIZE;
		cf.cbSize	=	16;
		_tcscpy( cf.szFaceName, "Courier New");
		_editCtrl.SetDefaultCharFormat(cf);


		SetFont(&m_fontDefault);
		_editCtrl.SetFont(&m_fontDefault);

	}

	return	iRet;
}
void CChildView::OnDraw(CDC *)
{
}

void CChildView::OnSize(UINT nType, int cx, int cy) 
{
	CWnd::OnSize(nType, cx, cy);
	CRect	rc;
	
	GetClientRect( &rc );

	_editCtrl.MoveWindow( rc );
	
}


void CChildView::ClearText()
{

	_editCtrl.SetSel(0, -1);
	
	_editCtrl.ReplaceSel(NULL);
	
	_editCtrl.SetSel(0, 0);
}






BOOL CChildView::OnCommand(WPARAM wParam, LPARAM lParam) 
{
	WORD		wID, wNotif;

	wID		=	LOWORD(wParam);
	wNotif	=	HIWORD(wParam);

	if( wID == IDC_RICH_EDIT_CTRL )
	{
		switch( wNotif )
		{
			case EN_CHANGE:
				{
					//_bChangedFlag	=	true;
				}	
				break;
			case EN_SETFOCUS:
				{
					CScribbleApp	*pApp = static_cast<CScribbleApp*>(AfxGetApp());
					pApp->OnModeEdit();
				}
				break;
			default:
				break;
		}
	}
	return CWnd::OnCommand(wParam, lParam);
}


void CChildView::OnClose() 
{
	CWnd::OnDestroy();
}


void	CChildView::SaveToFile(LPCTSTR szFile)
{
	EDITSTREAM	es;

	es.dwCookie		=	reinterpret_cast<DWORD>(szFile);
	es.dwError		=	0;
	es.pfnCallback	=	(EDITSTREAMCALLBACK)dumpProc;
	
	_editCtrl.StreamOut(SF_TEXT, es);
}


DWORD CALLBACK CChildView::dumpProc(DWORD dwCookie, LPBYTE pbBuff, LONG cb, LONG *pcb)
{
	LPCTSTR	strFileName	=	reinterpret_cast<LPCTSTR>(dwCookie);
	CFile	file;
	UINT	uFlags;

	if( strFileName )
	{
		uFlags	=	CFile::modeCreate | CFile::modeWrite;

		if(	file.Open(strFileName, uFlags)	)
		{
			file.SeekToEnd();
			file.Write( pbBuff, cb);
			*pcb	=	cb;

			file.Close();
			
			return 0L;
		}
	}

	return 1L;
}

void	CChildView::scrollTop()
{
	_editCtrl.LineScroll( -_editCtrl.GetLineCount());
}

void CChildView::OnEditCopy(void)
{
	_editCtrl.Copy();
}

void CChildView::OnUpdateEditCopy(CCmdUI *pCmdUI)
{
	long	lStart, lEnd;
	_editCtrl.GetSel(lStart, lEnd);

	pCmdUI->Enable( lEnd > lStart );
}

void CChildView::OnEditCut(void)
{
	_editCtrl.Cut();
}

void CChildView::OnUpdateEditCut(CCmdUI *pCmdUI)
{
	long	lStart, lEnd;
	_editCtrl.GetSel(lStart, lEnd);

	
	
	pCmdUI->Enable( lEnd > lStart );
}

void CChildView::OnEditPaste(void)
{
	_editCtrl.Paste();
}

void CChildView::OnUpdateEditPaste(CCmdUI *pCmdUI)
{
	pCmdUI->Enable( _editCtrl.CanPaste()  );
}

void CChildView::OnEditClear(void)
{
	_editCtrl.SetSel(0, -1);
	_editCtrl.Clear();
}


void CChildView::OnEditSelectAll(void)
{
	_editCtrl.SetSel(0, -1);
}

void CChildView::OnUpdateEditSelectAll(CCmdUI *pCmdUI)
{
	pCmdUI->Enable( TRUE );
}



void	CChildView::SetFormattedCode(const CStringArray* pArrLines)
{

	CString	strText;

	if( pArrLines )
	{
		for( int iIndex = 0; iIndex < pArrLines->GetSize(); iIndex ++ )
		{
			strText += pArrLines->GetAt( iIndex );
			strText += _T("\r\n");
		}
	}
	
	

	CHARFORMAT	cf;
	long	    nStart, nEnd;


	_editCtrl.SetSel(0, -1);
	_editCtrl.GetSel(nStart, nEnd);
	
	_editCtrl.ReplaceSel( strText );
	
	_editCtrl.SetSel(0, -1);
	_editCtrl.GetSelectionCharFormat( cf );
	
	cf.dwMask		=	CFM_COLOR;
	cf.dwEffects	=	0;
	cf.crTextColor	=	RGB(0, 0, 128);
	_editCtrl.SetSelectionCharFormat(cf);
	_editCtrl.SetSel(-1, -1);

	_editCtrl.LineScroll(_editCtrl.GetLineCount());

}

void	CChildView::HighlightLine(int /*iIndex*/)
{
/*	int nStart, nEnd;
	
	nStart = _editCtrl.LineIndex( iIndex + 1);
	if( nStart >= 0 )
	{
		nEnd = nStart + _editCtrl.LineLength( iIndex + 1);
		_editCtrl.SetSel( nStart, nEnd);
		UpdateWindow();
	}
*/	
}
void	CChildView::GetText(CString& strText)
{
	_editCtrl.SetSel(0, -1);
	strText = _editCtrl.GetSelText();

	// restore old sel
	_editCtrl.SetSel(-1, -1);
}


void	CChildView::AddLine(CString strLine, COLORREF col, bool bScrollToEnd)
{
	CHARFORMAT	cf;
	long	    nStart, nEnd;

	// Add the new line
	strLine += _T("\r\n");
	
	int		iStartLines	=	_editCtrl.GetLineCount();

	_editCtrl.SetSel(-1, -1);
	_editCtrl.GetSel(nStart, nEnd);
	
	_editCtrl.ReplaceSel( strLine);
	
	_editCtrl.SetSel(nStart, -1);
	_editCtrl.GetSelectionCharFormat( cf );
	
	cf.dwMask		=	CFM_COLOR;
	cf.dwEffects	=	0;
	cf.crTextColor	=	col;
	
	_editCtrl.SetSelectionCharFormat(cf);

	_editCtrl.SetSel(-1, -1);

	if( bScrollToEnd )
		_editCtrl.LineScroll( _editCtrl.GetLineCount() - iStartLines);
}


void CChildView::OnSetFocus(CWnd* pOldWnd)
{
	__super::OnSetFocus(pOldWnd);
	_editCtrl.SetFocus();
}



void CChildView::RemoveLastLine()
{
	int iLastLineChar	=	_editCtrl.LineIndex( _editCtrl.GetLineCount() -2 );
	_editCtrl.SetSel( iLastLineChar, -1);
	_editCtrl.Clear();
}