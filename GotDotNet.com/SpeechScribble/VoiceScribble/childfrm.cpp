// ChildFrm.cpp : implementation of the CChildFrame class
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

#include "ChildFrm.h"
#include "ChildView.h"

#include "ScribDoc.h"
#include "ScribVw.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CChildFrame

IMPLEMENT_DYNCREATE(CChildFrame, CMDIChildWnd)

BEGIN_MESSAGE_MAP(CChildFrame, CMDIChildWnd)
	//{{AFX_MSG_MAP(CChildFrame)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG_MAP
//	ON_WM_CLOSE()
ON_WM_DESTROY()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CChildFrame construction/destruction
BEGIN_VCOMMAND_MAP(CChildFrame)
	ON_VCOMMAND_SIMPLE(VID_MODE_EDIT, OnVoiceModeEdit)
	ON_VCOMMAND_SIMPLE(VID_MODE_GRAPH, OnVoiceModeGraphic)
	ON_VCOMMAND_SIMPLE(VID_COMPILE, OnCompile)
	ON_VCOMMAND_SIMPLE(VID_RUN, OnRun)
	ON_VCOMMAND_EX(VID_FORWARD, OnForward)
	ON_VCOMMAND_EX(VID_LEFT, OnLeft)
	ON_VCOMMAND_EX(VID_RIGHT, OnRight)
	ON_VCOMMAND_SIMPLE(VID_PENUP, OnPenUp)
	ON_VCOMMAND_SIMPLE(VID_PENDOWN, OnPenDown)
	ON_VCOMMAND_SIMPLE(VID_CLS, OnCLS)
	ON_VCOMMAND_EX(VID_SLEEP, OnSleep)
	ON_VCOMMAND_PARAM(VID_DECLARE, 1, OnDeclare)
	ON_VCOMMAND_EX(VID_SET, OnSet)
	ON_VCOMMAND_EX(VID_INCREMENT, OnIncrement)
	ON_VCOMMAND_EX(VID_DECREMENT, OnDecrement)
	ON_VCOMMAND_EX(VID_MULTIPLY, OnMultiply)
	ON_VCOMMAND_EX(VID_DIVIDE, OnDivide)
	ON_VCOMMAND_SIMPLE(VID_DO, OnDo)
	ON_VCOMMAND_EX(VID_UNTIL, OnUntil)
	ON_VCOMMAND_EX(VID_IF, OnIf)
	ON_VCOMMAND_SIMPLE(VID_ELSE, OnElse)
	ON_VCOMMAND_SIMPLE(VID_ENDIF, OnEndif)
	ON_VCOMMAND_PARAM(VID_PROCEDURE, 1, OnProcedure)
	ON_VCOMMAND_PARAM(VID_CALL, 1, OnCallProcedure)
	ON_VCOMMAND_PARAM(VID_START, 1, OnStartProcedure)
	ON_VCOMMAND_SIMPLE(VID_END, OnEndProcedure)
	ON_VCOMMAND_SIMPLE(VID_RESET, OnRESET)
	ON_VCOMMAND_SIMPLE(VID_UNDO, OnUndo)
END_VCOMMAND_MAP()

CChildFrame::CChildFrame()
{
	_pScribbleView = NULL;
	_pTextView = NULL;
	g_SpeechEngine->AddSubscriber(this);
	
}

CChildFrame::~CChildFrame()
{
	g_SpeechEngine->RemoveSubscriber(this);
}

BOOL CChildFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CMDIChildWnd::PreCreateWindow(cs) )
		return FALSE;
	cs.style |= WS_MAXIMIZE;
	cs.dwExStyle &= ~WS_EX_CLIENTEDGE;

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CChildFrame diagnostics

#ifdef _DEBUG
void CChildFrame::AssertValid() const
{
	CMDIChildWnd::AssertValid();
}

void CChildFrame::Dump(CDumpContext& dc) const
{
	CMDIChildWnd::Dump(dc);
}

#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CChildFrame message handlers

BOOL CChildFrame::OnCreateClient(LPCREATESTRUCT lpcs, CCreateContext* pContext) 
{

	BOOL bRet = FALSE;

	
	bRet	=	m_wndWorkSplitter.CreateStatic(this, 2, 1);
	
	// add the second splitter pane - which is a nested splitter with 2 rows
	bRet = m_wndSplitter.CreateStatic(
		&m_wndWorkSplitter,     // our parent window is the first splitter
		1, 2,               // the new splitter is 2 rows, 1 column
		WS_CHILD | WS_VISIBLE | WS_BORDER,  // style, WS_BORDER is needed
		m_wndWorkSplitter.IdFromRowCol(0, 0)
			// new splitter is in the first row, 2nd column of first splitter
	   );

	
	CSize	size;
	size.cx = lpcs->cx - GetSystemMetrics(SM_CXBORDER);
	size.cy = lpcs->cy - GetSystemMetrics(SM_CYBORDER);
	
	
	m_wndWorkSplitter.SetRowInfo( 0, size.cy, size.cy);
	
	bRet	=	m_wndWorkSplitter.CreateView( 1, 0, RUNTIME_CLASS(CChildView), size, pContext);
	
	size.cx = lpcs->cx - GetSystemMetrics(SM_CXBORDER);
	size.cy = lpcs->cy - GetSystemMetrics(SM_CYBORDER);
	size.cy	= 4*size.cy/5;
	size.cx = 3*size.cx/4;
	
	if( bRet )
		bRet	=	m_wndSplitter.CreateView( 0, 0, RUNTIME_CLASS(CScribbleView), size, pContext);
	
	size.cx  = lpcs->cx - GetSystemMetrics(SM_CXBORDER);
	size.cx = size.cx/4;
	if( bRet )
		bRet	=	m_wndSplitter.CreateView( 0, 1, RUNTIME_CLASS(CChildView), size, NULL/*, /*pContext*/);

	_pTextView	=	static_cast<CChildView*>(m_wndSplitter.GetPane( 0, 1));
	
	_pScribbleView	=	static_cast<CScribbleView*>(m_wndSplitter.GetPane(0, 0));
	if( _pScribbleView )
	{
		_pScribbleView->GetDocument()->SetTurtleGraphicsEditorHandler(static_cast<ITurtleGraphicsEditorHandler*>(_pTextView) );

		CChildView	*pErrView = static_cast<CChildView*>(m_wndWorkSplitter.GetPane( 1, 0));
		if( pErrView )
			_pScribbleView->GetDocument()->SetErrorEditorHandler( pErrView );
	}

	
	CMDIFrameWnd* pMainWnd = (CMDIFrameWnd*)AfxGetApp()->m_pMainWnd;
	pMainWnd->MDIMaximize( this);
	return bRet;

}


void CChildFrame::OnDestroy()
{
	CMDIChildWnd::OnDestroy();

	if( _pTextView )
	{
		delete _pTextView;
		_pTextView = NULL;
	}

}

BOOL CChildFrame::OnCmdMsg(UINT nID, int nCode, void* pExtra, AFX_CMDHANDLERINFO* pHandlerInfo)
{
	if(_pTextView !=	NULL)
	{
		if( _pTextView->OnCmdMsg(nID, nCode, pExtra, pHandlerInfo) )
			return TRUE;
	}
	return CMDIChildWnd::OnCmdMsg(nID, nCode, pExtra, pHandlerInfo);
}




// Voice Handling routines
void	CChildFrame::ProcessVoiceTurtleGraphicsCommand(stTurtleGraphicsCmd& cmd)
{
	if( _pScribbleView != NULL )
	{
		_pScribbleView->GetDocument()->ExecTurtleCommand(cmd);
	}
}



void	CChildFrame::FillRuleFromPhrase(stTurtleGraphicsCmd& cmd, SPPHRASE* pPhrase, unsigned int iPos, LPCWSTR wszPropName)
{
	CComVariant	var;
	int			iMode = VID_RVALTYPE_INT;	// assume numeric
	int			iFirstChild;

	// chances are it is a var
	if( SUCCEEDED(GetPhraseProperty( pPhrase->pProperties, wszPropName, var, iFirstChild)) )
	{
		iMode = var.intVal;
	}

	if( pPhrase->Rule.ulCountOfElements <= iPos )
	{
		// Cannot be a variable
		iMode = VID_RVALTYPE_INT;
	}

	switch( iMode )
	{
		case VID_RVALTYPE_INT:
			// Numeric
			cmd.iNumParam1 = SAPI_ParseNumberHelper(pPhrase, (ULONG)iPos);
			break;
		case VID_RVALTYPE_VAR:
			// Variable
			{		
				CW2T	strVar(pPhrase->pElements[iPos].pszDisplayText);
				cmd.strRVal = strVar;
			}
			break;
	}
}


BOOL	CChildFrame::OnVoiceModeGraphic()
{
	if( _pScribbleView )
		_pScribbleView->SetFocus();
	
	CScribbleApp	*pApp = static_cast<CScribbleApp*>(AfxGetApp());
	pApp->OnModeGraphic();
	return TRUE;
}
BOOL	CChildFrame::OnVoiceModeEdit()
{
	if( _pTextView )
		_pTextView->SetFocus();
	
	CScribbleApp	*pApp = static_cast<CScribbleApp*>(AfxGetApp());
	pApp->OnModeEdit();
	return TRUE;
}

BOOL	CChildFrame::OnCompile()
{
	if( _pScribbleView != NULL )
	{
		_pScribbleView->GetDocument()->OnTurtleGraphicsCompile();
	}
	return TRUE;
}

BOOL	CChildFrame::OnRun()
{
	if( _pScribbleView != NULL )
	{
		_pScribbleView->GetDocument()->OnTurtleGraphicsRun();
	}
	// forward the message
	return FALSE;
}



BOOL	CChildFrame::OnForward(SPPHRASE *pPhrase)
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eFORWARD;
	FillRuleFromPhrase(cmd, pPhrase, 1);
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;

}

BOOL	CChildFrame::OnRight(SPPHRASE *pPhrase)
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eRIGHT;
	FillRuleFromPhrase(cmd, pPhrase, 1);
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnLeft(SPPHRASE *pPhrase)
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eLEFT;
	FillRuleFromPhrase(cmd, pPhrase, 1);
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}


BOOL	CChildFrame::OnPenUp()
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	ePENUP;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnPenDown()
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	ePENDOWN;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}


BOOL	CChildFrame::OnCLS()
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eCLS;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnSleep(SPPHRASE *pPhrase)
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eSLEEP;
	FillRuleFromPhrase(cmd, pPhrase, 1);
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnDeclare(LPCTSTR strVar)
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eDECLARE;
	cmd.strLVal = strVar;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}


BOOL	CChildFrame::OnSet(SPPHRASE	*pPhrase)
{
	stTurtleGraphicsCmd	cmd;
	ASSERT( pPhrase );
	ASSERT( pPhrase->Rule.ulCountOfElements >= 3 );
	cmd.cmd	=	eSET;
	CW2T	strVarName( pPhrase->pElements[1].pszDisplayText);
	cmd.strLVal = strVarName;

	FillRuleFromPhrase(cmd, pPhrase, 3);
	ProcessVoiceTurtleGraphicsCommand(cmd);

	return TRUE;
}


BOOL	CChildFrame::OnIncrement(SPPHRASE	*pPhrase)
{
	stTurtleGraphicsCmd	cmd;

	ASSERT( pPhrase );
	ASSERT( pPhrase->Rule.ulCountOfElements >= 3 );


	cmd.cmd	=	eINCREMENT;
	CW2T	strVarName( pPhrase->pElements[1].pszDisplayText);
	cmd.strLVal = strVarName;

	FillRuleFromPhrase( cmd, pPhrase, 3);

	
	ProcessVoiceTurtleGraphicsCommand(cmd);
	
	return TRUE;
}

BOOL	CChildFrame::OnDecrement(SPPHRASE	*pPhrase)
{
	stTurtleGraphicsCmd	cmd;

	ASSERT( pPhrase );
	ASSERT( pPhrase->Rule.ulCountOfElements >= 3 );

	cmd.cmd	=	eDECREMENT;
	CW2T	strVarName( pPhrase->pElements[1].pszDisplayText);
	cmd.strLVal = strVarName;

	FillRuleFromPhrase( cmd, pPhrase, 3);
	
	ProcessVoiceTurtleGraphicsCommand(cmd);

	return TRUE;
}

BOOL	CChildFrame::OnMultiply(SPPHRASE	*pPhrase)
{
	stTurtleGraphicsCmd	cmd;

	ASSERT( pPhrase );
	ASSERT( pPhrase->Rule.ulCountOfElements >= 3 );

	cmd.cmd	=	eMULTIPLY;
	CW2T	strVarName( pPhrase->pElements[1].pszDisplayText);
	cmd.strLVal = strVarName;

	FillRuleFromPhrase( cmd, pPhrase, 3);

	ProcessVoiceTurtleGraphicsCommand(cmd);

	return TRUE;
}

BOOL	CChildFrame::OnDivide(SPPHRASE	*pPhrase)
{
	stTurtleGraphicsCmd	cmd;

	ASSERT( pPhrase );
	ASSERT( pPhrase->Rule.ulCountOfElements >= 3 );

	cmd.cmd	=	eDIVIDE;
	CW2T	strVarName( pPhrase->pElements[1].pszDisplayText);
	cmd.strLVal = strVarName;

	FillRuleFromPhrase( cmd, pPhrase, 3);

	ProcessVoiceTurtleGraphicsCommand(cmd);

	return TRUE;
}


BOOL	CChildFrame::OnDo()
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eDO;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnUntil(SPPHRASE	*pPhrase)
{
	
	// The function will return TRUE immediately after any error occurs, 
	// to stop processing of the VCommand

	// adding two commands
	stTurtleGraphicsCmd	cmdVerb, cmdParam;

	cmdVerb.cmd = eUNTIL;

	CComVariant	var;
	int			iBoolOperator = 0;	// assume <=
	int			iFirstChild;

	// chances are it is a var
	if( SUCCEEDED(GetPhraseProperty( pPhrase->pProperties, L"OPTYPE", var, iFirstChild)) )
	{
		iBoolOperator = var.intVal;
	}
	else
		return TRUE;


	// chances are it is a var
	if( FAILED(GetPhraseProperty( pPhrase->pProperties, L"RVALUETYPE", var, iFirstChild)) )
		return TRUE;

	switch( iBoolOperator )
	{
		case VID_LEQ: 
			cmdParam.cmd = eLEQ; 
			break;
		case VID_GEQ: 
			cmdParam.cmd = eGEQ; 
			break;
		case VID_EQ: 
			cmdParam.cmd = eEQ; 
			break;
		case VID_GT: 
			cmdParam.cmd = eGT; 
			break;
		case VID_LT: 
			cmdParam.cmd = eLT; 
			break;
		case VID_DIFF: 
			cmdParam.cmd = eDIFF; 
			break;
		default:
			return TRUE;
	}
	

	ASSERT( pPhrase->Rule.ulCountOfElements > 1 );
	CW2T	strOperatorLVal(pPhrase->pElements[1].pszDisplayText);
	cmdParam.strLVal = strOperatorLVal;

	FillRuleFromPhrase( cmdParam, pPhrase, iFirstChild);

	ProcessVoiceTurtleGraphicsCommand(cmdVerb);
	ProcessVoiceTurtleGraphicsCommand(cmdParam);
	
	

	
	return TRUE;
}
BOOL	CChildFrame::OnIf(SPPHRASE *pPhrase)
{
	// The function will return TRUE immediately after any error occurs, 
	// to stop processing of the VCommand

	// adding two commands
	stTurtleGraphicsCmd	cmdVerb, cmdParam;

	cmdVerb.cmd = eIF;

	CComVariant	var;
	int			iBoolOperator = 0;	// assume <=
	int			iFirstChild;

	// chances are it is a var
	if( SUCCEEDED(GetPhraseProperty( pPhrase->pProperties, L"OPTYPE", var, iFirstChild)) )
	{
		iBoolOperator = var.intVal;
	}
	else
		return TRUE;


	// chances are it is a var
	if( FAILED(GetPhraseProperty( pPhrase->pProperties, L"RVALUETYPE", var, iFirstChild)) )
		return TRUE;

	switch( iBoolOperator )
	{
		case VID_LEQ: 
			cmdParam.cmd = eLEQ; 
			break;
		case VID_GEQ: 
			cmdParam.cmd = eGEQ; 
			break;
		case VID_EQ: 
			cmdParam.cmd = eEQ; 
			break;
		case VID_GT: 
			cmdParam.cmd = eGT; 
			break;
		case VID_LT: 
			cmdParam.cmd = eLT; 
			break;
		case VID_DIFF: 
			cmdParam.cmd = eDIFF; 
			break;
		default:
			return TRUE;
	}
	

	ASSERT( pPhrase->Rule.ulCountOfElements > 1 );
	CW2T	strOperatorLVal(pPhrase->pElements[1].pszDisplayText);
	cmdParam.strLVal = strOperatorLVal;

	FillRuleFromPhrase( cmdParam, pPhrase, iFirstChild);

	ProcessVoiceTurtleGraphicsCommand(cmdVerb);
	ProcessVoiceTurtleGraphicsCommand(cmdParam);
	
	return TRUE;
}
BOOL	CChildFrame::OnElse()
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eELSE;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnEndif()
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eENDIF;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnRESET()
{
	if( _pScribbleView != NULL )
	{
		_pScribbleView->GetDocument()->Reset();
	}
	return TRUE;
}

BOOL	CChildFrame::OnUndo()
{
	if( _pScribbleView != NULL )
	{
		_pScribbleView->GetDocument()->RemoveLastLine();
	}
	return TRUE;
}

BOOL	CChildFrame::OnProcedure(LPCTSTR strVar)
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	ePROCEDURE;
	cmd.strLVal = strVar;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnStartProcedure(LPCTSTR strVar)
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eSTART;
	cmd.strLVal = strVar;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnCallProcedure(LPCTSTR strVar)
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eCALL;
	cmd.strLVal = strVar;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}

BOOL	CChildFrame::OnEndProcedure()
{
	stTurtleGraphicsCmd	cmd;
	cmd.cmd	=	eEND;
	ProcessVoiceTurtleGraphicsCommand(cmd);
	return TRUE;
}
