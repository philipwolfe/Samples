// ScribDoc.cpp : implementation of the CScribbleDoc class
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "Scribble.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#include "ScribDoc.h"
#include "ScribItm.h"
#include "PenDlg.h"
#include "ScribVw.h"


/////////////////////////////////////////////////////////////////////////////
// CScribbleDoc

IMPLEMENT_DYNCREATE(CScribbleDoc, COleServerDoc)

BEGIN_MESSAGE_MAP(CScribbleDoc, COleServerDoc)
	//{{AFX_MSG_MAP(CScribbleDoc)
	ON_COMMAND(ID_EDIT_CLEAR_ALL, OnEditClearAll)
	ON_UPDATE_COMMAND_UI(ID_EDIT_CLEAR_ALL, OnUpdateEditClearAll)
	ON_COMMAND(ID_EDIT_COPY, OnEditCopy)
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_FILE_SEND_MAIL, OnFileSendMail)
	ON_UPDATE_COMMAND_UI(ID_FILE_SEND_MAIL, OnUpdateFileSendMail)
	ON_COMMAND(ID_TurtleGraphics_COMPILE, OnTurtleGraphicsCompile)
	ON_UPDATE_COMMAND_UI(ID_TurtleGraphics_COMPILE, OnUpdateTurtleGraphicsCompile)
	ON_COMMAND(ID_TurtleGraphics_RUN, OnTurtleGraphicsRun)
	ON_UPDATE_COMMAND_UI(ID_TurtleGraphics_RUN, OnUpdateTurtleGraphicsRun)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CScribbleDoc construction/destruction

CScribbleDoc::CScribbleDoc()
{
	// Use OLE compound files
	EnableCompoundFile();
	m_pCurrStroke	=	NULL;
	m_sizeDoc = CSize(200, 200);

	m_pErrEditorHandler = NULL;
	m_pEditorHandler = NULL;

	m_arStdVars.Add( _T("PEN"));
	m_arStdVars.Add( _T("COLOR"));
	m_arStdVars.Add( _T("DELTA"));
	m_arStdVars.Add( _T("STEP"));
	m_arStdVars.Add( _T("SLEEP_TIME"));

}

CScribbleDoc::~CScribbleDoc()
{
}

BOOL CScribbleDoc::OnNewDocument()
{
	if (!COleServerDoc::OnNewDocument())
		return FALSE;
	InitDocument();
	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CScribbleDoc serialization

void CScribbleDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		ar << m_sizeDoc;
	}
	else
	{
		ar >> m_sizeDoc;
	}
	m_strokeList.Serialize(ar);
}

/////////////////////////////////////////////////////////////////////////////
// CScribbleDoc diagnostics

#ifdef _DEBUG
void CScribbleDoc::AssertValid() const
{
	COleServerDoc::AssertValid();
}

void CScribbleDoc::Dump(CDumpContext& dc) const
{
	COleServerDoc::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CScribbleDoc commands

BOOL CScribbleDoc::OnOpenDocument(LPCTSTR lpszPathName) 
{
	InitDocument(lpszPathName);
	m_pCurrStroke->m_ptStart.x = TURTLE_START_X;
	m_pCurrStroke->m_ptStart.y = TURTLE_START_Y;
	return TRUE;
}

void CScribbleDoc::DeleteContents() 
{
	while (!m_strokeList.IsEmpty())
	{
		delete m_strokeList.RemoveHead();
	}
	COleServerDoc::DeleteContents();
}

void CScribbleDoc::InitDocument(LPCTSTR lpszPathName)
{
	m_pCurrStroke	=	NewStroke();

	m_turtleDraw	=	m_TurtleGraphicsParser.m_turtle.m_turtleDraw;
	SetRecognizableVars();

	if( lpszPathName && m_pEditorHandler)
	{
		// read from file
		CFile	file;

		if( file.Open( lpszPathName, CFile::modeRead) )
		{
			char		*pBuff = NULL;
			UINT		dwSize = (UINT)file.GetLength();

			pBuff = new char[dwSize + 1];
			if( pBuff )
			{
				file.Read(pBuff, dwSize);
				pBuff[dwSize] = 0;

				try
				{
					CString	strText = pBuff;
					m_pEditorHandler->AddLine( strText, RGB(0, 0, 0), false );
				}
				catch(...)
				{
				}
				delete[] pBuff;
			}
			file.Close();
		}
	}
	
	m_sizeDoc = CSize(200,200);
}

CStroke* CScribbleDoc::NewStroke()
{
	bool		bNeedCreation = true;
	CStroke*	pStrokeItem = m_pCurrStroke;

	if(m_pCurrStroke)
	{
		// create ONLY if this is not empty
		bNeedCreation = m_pCurrStroke->m_cmdArray.GetSize() > 0;
		m_pCurrStroke->FinishStroke();
	}
	
	if( bNeedCreation )
	{
		pStrokeItem = new CStroke(&m_TurtleGraphicsParser);

		m_strokeList.AddTail(pStrokeItem);

	}
	return pStrokeItem;
}




/////////////////////////////////////////////////////////////////////////////
// CStroke

IMPLEMENT_SERIAL(CStroke, CObject, 2)
CStroke::CStroke()
{
	// This empty constructor should be used by serialization only
}

CStroke::CStroke(CTurtleGraphicsParser	*pTurtleGraphicsParser)
{
	m_ptStart.SetPoint(TURTLE_START_X, TURTLE_START_Y);
	m_rectBounding.SetRectEmpty();
	m_pTurtleGraphicsParser = pTurtleGraphicsParser;
}

void CStroke::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		ar << m_rectBounding;
		ar	<< m_ptStart;
		m_cmdArray.Serialize(ar);
	}
	else
	{
		ar >> m_rectBounding;
		ar >> m_ptStart;
		m_cmdArray.Serialize(ar);
	}
}

void CScribbleDoc::OnEditClearAll() 
{
	DeleteContents();
	UpdateAllViews(NULL);
}


void CScribbleDoc::OnUpdateEditClearAll(CCmdUI* pCmdUI) 
{
	// Enable the command user interface object (menu item or tool bar
	// button) if the document is non-empty, i.e., has at least one stroke.
	pCmdUI->Enable(!m_strokeList.IsEmpty());
}


void CStroke::FinishStroke()
{
	CTurtle	tempTurtle;

	tempTurtle.SetStartPoint( m_ptStart.x, m_ptStart.y);
	
	m_rectBounding.SetRectEmpty();

	for (int i=1; i < m_cmdArray.GetSize(); i++)
	{
		switch(m_cmdArray[i].cmd)
		{
			case eCLS:
				break;
			case eFORWARD:
				tempTurtle.Forward(m_cmdArray[i].iNumParam1);
				break;
			case eLEFT:
				tempTurtle.OffsetAngle(m_cmdArray[i].iNumParam1);
				break;
			case eRIGHT:
				tempTurtle.OffsetAngle(-m_cmdArray[i].iNumParam1);
				break;
			default:
				break;
		}
	}

//	m_rectBounding
	m_rectBounding.left = tempTurtle.m_nLeftBoundary;
	m_rectBounding.right = tempTurtle.m_nRightBoundary;
	m_rectBounding.top = tempTurtle.m_nTopBoundary;
	m_rectBounding.bottom = tempTurtle.m_nBottomBoundary;
	return;
}

COleServerItem* CScribbleDoc::OnGetEmbeddedItem()
{
	// OnGetEmbeddedItem is called by the framework to get the COleServerItem
	//  that is associated with the document.  It is only called when necessary.

	CScribbleItem* pItem = new CScribbleItem(this);
	ASSERT_VALID(pItem);
	return pItem;
}

void CScribbleDoc::OnSetItemRects(LPCRECT lpPosRect, LPCRECT lpClipRect)
{
	// call base class to change the size of the window
	COleServerDoc::OnSetItemRects(lpPosRect, lpClipRect);

	// notify first view that scroll info should change
	POSITION pos = GetFirstViewPosition();
	CScribbleView* pView = (CScribbleView*)GetNextView(pos);
	pView->ResyncScrollSizes();
}

void CScribbleDoc::OnEditCopy()
{
	CScribbleItem* pItem = GetEmbeddedItem();
	pItem->CopyToClipboard(TRUE);
}


void CScribbleDoc::ExecTurtleCommand(stTurtleGraphicsCmd&	cmd)
{
	// add the command to the current stroke
	// now update the view, do a line from start to end

	CScribbleApp	*pApp = static_cast<CScribbleApp*>(AfxGetApp());
	
	m_pErrEditorHandler->ClearText();


	if( pApp->m_bIsEditMode )
	{
		CString		strCmdText;
		TurtleGraphicsLex_GetCmdDescription( cmd, strCmdText);
		switch( cmd.cmd )
		{
		case  eDECLARE :
			AddGrammarVariable( cmd.strLVal );
			break;
		case  ePROCEDURE :
			AddGrammarProc( cmd.strLVal );
			break;
		}

		this->m_pEditorHandler->AddLine( strCmdText );
	}
	else
	{
		// Graphic Mode --add the command and execute it
		POSITION	pos	=	GetFirstViewPosition();
		CScribbleView*	pView	=	static_cast<CScribbleView*>(GetNextView( pos ));
		
		if( pView )
		{
			CClientDC		dc(pView);
			CRect			rc;

			pView->OnPrepareDC(&dc);  // set up mapping mode and viewport origin

			// hide the turtle
			DrawTurtle(&dc);


			// run the command directly
			m_TurtleGraphicsParser.m_pDC = &dc;
			m_TurtleGraphicsParser.m_bExecuting = true;
			m_TurtleGraphicsParser.SimpleTurtleGraphicsCommand( cmd );
			m_TurtleGraphicsParser.m_bExecuting = false;


			// save the bitmap

			m_pCurrStroke->m_cmdArray.Add(cmd);
			bool bRet = m_TurtleGraphicsParser.check(&m_pCurrStroke->m_cmdArray);

			m_turtleDraw	=	m_TurtleGraphicsParser.m_turtle.m_turtleDraw;
			if( !bRet )
			{
				CheckForParsingErrors();
			}
			// redraw the turtle
			DrawTurtle(&dc);
			
		}
	}
}


void CScribbleDoc::OnTurtleGraphicsCompile()
{
	CString		strStream;
	if( m_pEditorHandler)
	{
		this->m_pEditorHandler->GetText(strStream);
		m_pErrEditorHandler->ClearText();

		CTurtleGraphicsScanner	scan;
		stTurtleGraphicsCmd	cmd;

		m_pCurrStroke->m_cmdArray.RemoveAll();
		scan.SetStream( strStream);

		eLexError	lexRet;
		while( (lexRet = scan.GetNextTurtleGraphicsCmd(cmd)) == eLEX_OK)
		{
			m_pCurrStroke->m_cmdArray.Add( cmd );
		}
		if(lexRet != eLEX_EOF )
		{
			if( m_pErrEditorHandler && scan.m_bErrorsOccured )
			{
				CString strErr;
				strErr.Format(_T("ERROR (%d) -- %s"), 
						scan.m_iErrLine + 1, scan.m_strErrorDescription);
				m_pErrEditorHandler->AddLine( strErr, RGB(255, 0, 0));
			}
			return;
		}

		bool bRet  = m_TurtleGraphicsParser.check(&m_pCurrStroke->m_cmdArray);
		if( !bRet )
		{
			CheckForParsingErrors();
		}


		m_pCurrStroke->m_cmdArray.RemoveAll();
	}
}

void CScribbleDoc::OnUpdateTurtleGraphicsCompile(CCmdUI* pCmdUI)
{
	CScribbleApp*	pApp	=	static_cast<CScribbleApp*>(AfxGetApp());
	pCmdUI->Enable( pApp->m_bIsEditMode );
}

void CScribbleDoc::OnTurtleGraphicsRun()
{
	CString		strStream;
	POSITION	pos	=	GetFirstViewPosition();
	CScribbleView*	pView	=	static_cast<CScribbleView*>(GetNextView( pos ));


	if( pView && m_pEditorHandler)
	{
		m_pErrEditorHandler->ClearText();
		this->m_pEditorHandler->GetText(strStream);

		CTurtleGraphicsScanner	scan;
		stTurtleGraphicsCmd	cmd;

		m_pCurrStroke->m_cmdArray.RemoveAll();
		scan.SetStream( strStream);

		eLexError	lexRet;
		while( (lexRet = scan.GetNextTurtleGraphicsCmd(cmd)) == eLEX_OK)
		{
			m_pCurrStroke->m_cmdArray.Add( cmd );
		}
		if(lexRet != eLEX_EOF )
		{
			if( m_pErrEditorHandler && scan.m_bErrorsOccured )
			{
				CString strErr;
				strErr.Format(_T("ERROR (%d) -- %s"), 
						scan.m_iErrLine + 1, scan.m_strErrorDescription);
				m_pErrEditorHandler->AddLine( strErr, RGB(255, 0, 0));
			}
			return;
		}

		CClientDC	dc(pView);

		pView->OnPrepareDC(&dc);  // set up mapping mode and viewport origin
		
		// hide the turtle
		DrawTurtle( &dc );

		bool bRet = m_TurtleGraphicsParser.run(&m_pCurrStroke->m_cmdArray, &dc);

		// show the turtle
		m_turtleDraw	=	m_TurtleGraphicsParser.m_turtle.m_turtleDraw;
		DrawTurtle( &dc );

		if( !bRet )
		{
			CheckForParsingErrors();
		}


	}

}

void CScribbleDoc::OnUpdateTurtleGraphicsRun(CCmdUI *pCmdUI)
{
	CScribbleApp*	pApp	=	static_cast<CScribbleApp*>(AfxGetApp());
	pCmdUI->Enable( pApp->m_bIsEditMode );
}


void CScribbleDoc::AddGrammarVariable(LPCTSTR	strName)
{
	m_arDeclaredVars.Add( strName );
	g_SpeechEngine->EnableGrammar(false);
	g_SpeechEngine->EnableRule(VID_CURRENT_VARS, false);
	g_SpeechEngine->AddSingleWordTerminalTransition( NULL, VID_CURRENT_VARS, strName);
	g_SpeechEngine->CommitGrammar();
	g_SpeechEngine->EnableRule(VID_CURRENT_VARS);
	g_SpeechEngine->EnableGrammar();

}

void CScribbleDoc::AddGrammarProc(LPCTSTR	strName)
{
	m_arDeclaredVars.Add( strName );
	g_SpeechEngine->EnableGrammar(false);
	g_SpeechEngine->EnableRule(VID_CURRENT_PROCS, false);
	g_SpeechEngine->AddSingleWordTerminalTransition( NULL, VID_CURRENT_PROCS, strName);
	g_SpeechEngine->CommitGrammar();
	g_SpeechEngine->EnableRule(VID_CURRENT_PROCS);
	g_SpeechEngine->EnableGrammar();

}



void CScribbleDoc::SetRecognizableVars()
{
	INT_PTR	iIndex, iSize;
	g_SpeechEngine->EnableGrammar(false);
	g_SpeechEngine->EnableRule(VID_CURRENT_VARS, false);
	g_SpeechEngine->ClearRule( NULL, VID_CURRENT_VARS);
	
	// Add standard vars
	iSize = m_arStdVars.GetSize();
	for( iIndex = 0; iIndex < iSize; iIndex ++ )
	{
		g_SpeechEngine->AddSingleWordTerminalTransition( NULL, VID_CURRENT_VARS, m_arStdVars.GetAt(iIndex));
	}


	// Add custom vars
	iSize = m_arDeclaredVars.GetSize();
	for( iIndex = 0; iIndex < iSize; iIndex ++ )
	{
		g_SpeechEngine->AddSingleWordTerminalTransition( NULL, VID_CURRENT_VARS, m_arDeclaredVars.GetAt(iIndex));
	}

	g_SpeechEngine->CommitGrammar();
	g_SpeechEngine->EnableRule(VID_CURRENT_VARS);
	g_SpeechEngine->EnableGrammar();

}

void CScribbleDoc::SetRecognizableProcs()
{
	INT_PTR	iIndex, iSize;
	g_SpeechEngine->EnableGrammar(false);
	g_SpeechEngine->EnableRule(VID_CURRENT_PROCS, false);
	g_SpeechEngine->ClearRule( NULL, VID_CURRENT_PROCS);
	

	// Add custom vars
	iSize = m_arDeclaredProcs.GetSize();
	for( iIndex = 0; iIndex < iSize; iIndex ++ )
	{
		g_SpeechEngine->AddSingleWordTerminalTransition( NULL, VID_CURRENT_PROCS, m_arDeclaredProcs.GetAt(iIndex));
	}

	g_SpeechEngine->CommitGrammar();
	g_SpeechEngine->EnableRule(VID_CURRENT_PROCS);
	g_SpeechEngine->EnableGrammar();

}

void CScribbleDoc::Reset()
{
	m_pCurrStroke->m_cmdArray.RemoveAll();
	

	if( m_pEditorHandler )
		m_pEditorHandler->ClearText();

	if( m_pErrEditorHandler)
		m_pErrEditorHandler->ClearText();

	m_arDeclaredProcs.RemoveAll();
	m_arDeclaredVars.RemoveAll();
	SetRecognizableVars();
	
	// reset the parser
	m_TurtleGraphicsParser.check( &m_pCurrStroke->m_cmdArray);
	m_turtleDraw	=	m_TurtleGraphicsParser.m_turtle.m_turtleDraw;
	UpdateAllViews(NULL);
}

void CScribbleDoc::RemoveLastLine()
{
	INT_PTR iSize = m_pCurrStroke->m_cmdArray.GetSize();
	if( iSize > 0 )
	{
		stTurtleGraphicsCmd	cmd = m_pCurrStroke->m_cmdArray.GetAt( iSize - 1);

		m_pCurrStroke->m_cmdArray.RemoveAt( iSize - 1);
		
		switch ( cmd.cmd )
		{
			case eDECLARE:
			{
				// remove the last var
				iSize = m_arDeclaredVars.GetSize();
				if( iSize > 0 )
				{
					m_arDeclaredVars.RemoveAt( iSize - 1);
					// reset the variables recognized by the grammar
					SetRecognizableVars();
				}
			}
			break;
			case ePROCEDURE:
			{
				// remove the last var
				iSize = m_arDeclaredProcs.GetSize();
				if( iSize > 0 )
				{
					m_arDeclaredProcs.RemoveAt( iSize - 1);
					// reset the variables recognized by the grammar
					SetRecognizableProcs();
				}
			}
			break;
		}
	}

	m_pEditorHandler->RemoveLastLine();
	UpdateAllViews(NULL);
}


void CScribbleDoc::CheckForParsingErrors()
{
	if( m_pErrEditorHandler )
	{
		if( m_TurtleGraphicsParser.m_bErrorsOccured )
		{
			CString strErr;
			strErr.Format(_T("PARSE ERROR (%d) -- %s"), 
					m_TurtleGraphicsParser.m_iErrLine + 1, m_TurtleGraphicsParser.m_strErrorDescription);
			m_pErrEditorHandler->AddLine( strErr, RGB(255, 0, 0));
		}
		if( m_TurtleGraphicsParser.m_bWarningsOccured )
		{
			
			INT_PTR	iIndex, iSize;
			iSize	=	m_TurtleGraphicsParser.m_arrWarns.GetSize();
			for( iIndex  =0; iIndex < iSize; iIndex++)
			{
				CString strErr;
				strErr.Format(_T("WARNING (%d) -- %s"), 
						m_TurtleGraphicsParser.m_arrWarns[iIndex].line + 1, m_TurtleGraphicsParser.m_arrWarns[iIndex].warn);
				m_pErrEditorHandler->AddLine( strErr, RGB(0, 255, 0));
			}
		}
	}
}


void	CScribbleDoc::DrawTurtle(CDC*	pDC)
{
	ASSERT( pDC != NULL );

	stTurtleDraw temp = m_turtleDraw;
	int iOldROP = pDC->SetROP2( R2_XORPEN);

	if( !temp.pt1.x && !temp.pt2.x && !temp.pt3.x && !temp.pt4.x &&
		!temp.pt1.y && !temp.pt2.y && !temp.pt3.y && !temp.pt4.y  )
	{
		// NULL -- No need to temp
		return;
	}

	CPen	pen;
	pen.CreatePen(PS_SOLID, 4, RGB(0, 255, 255));
	CPen* pOldPen = pDC->SelectObject( &pen);
	pDC->LPtoDP( reinterpret_cast<LPPOINT>(&temp), 4);
	pDC->MoveTo( temp.pt1 );
	pDC->LineTo( temp.pt2 );
	pDC->LineTo( temp.pt3 );
	pDC->LineTo( temp.pt4 );
	pDC->LineTo( temp.pt1 );

	pDC->SelectObject( &pOldPen);
	iOldROP = pDC->SetROP2( iOldROP);
}


BOOL CScribbleDoc::OnSaveDocument(LPCTSTR lpszPathName )
{

	if(m_pEditorHandler)
	{
		m_pEditorHandler->SaveToFile(lpszPathName);
	}

	return TRUE;
}