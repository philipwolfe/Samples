// ChildFrm.h : interface of the CChildFrame class
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.
/////////////////////////////////////////////////////////////////////////////

class CChildView;
class CScribbleView;
#include "TurtleGraphics.h"

class CChildFrame : public CMDIChildWnd,
	public CVoiceCmdTargetT<CChildFrame>
{
	DECLARE_DYNCREATE(CChildFrame)
public:
	CChildFrame();

// Attributes
protected:
	CSplitterWnd    m_wndWorkSplitter;
	CSplitterWnd	m_wndSplitter;

	CChildView			*_pTextView;
	CScribbleView		*_pScribbleView;
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CChildFrame)
	public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual BOOL OnCreateClient(LPCREATESTRUCT lpcs, CCreateContext* pContext);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CChildFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

// Generated message map functions
protected:
	//{{AFX_MSG(CChildFrame)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnDestroy();
	virtual BOOL OnCmdMsg(UINT nID, int nCode, void* pExtra, AFX_CMDHANDLERINFO* pHandlerInfo);


	DECLARE_VCOMMAND_MAP()

	BOOL	OnVoiceModeGraphic();
	BOOL	OnVoiceModeEdit();
	BOOL	OnCompile();
	BOOL	OnRun();
	BOOL	OnRESET();
	BOOL	OnUndo();

	BOOL	OnForward(SPPHRASE	*pPhrase);
	BOOL	OnLeft(SPPHRASE	*pPhrase);
	BOOL	OnRight(SPPHRASE	*pPhrase);

	BOOL	OnPenUp();
	BOOL	OnPenDown();
	BOOL	OnCLS();
	BOOL	OnSleep(SPPHRASE	*pPhrase);

	BOOL	OnDeclare(LPCTSTR strVar);
	BOOL	OnSet(SPPHRASE	*pPhrase);

	BOOL	OnIncrement(SPPHRASE	*pPhrase);
	BOOL	OnDecrement(SPPHRASE	*pPhrase);
	BOOL	OnDivide(SPPHRASE	*pPhrase);
	BOOL	OnMultiply(SPPHRASE	*pPhrase);

	BOOL	OnDo();
	BOOL	OnUntil(SPPHRASE	*pPhrase);
	BOOL	OnIf(SPPHRASE *pPhrase);
	BOOL	OnElse();
	BOOL	OnEndif();


	BOOL	OnProcedure(LPCTSTR strVar);
	BOOL	OnStartProcedure(LPCTSTR strVar);
	BOOL	OnCallProcedure(LPCTSTR strVar);
	BOOL	OnEndProcedure();
protected:
	void	ProcessVoiceTurtleGraphicsCommand(stTurtleGraphicsCmd& cmd);

	void	FillRuleFromPhrase(stTurtleGraphicsCmd& cmd, SPPHRASE* pPhrase, unsigned int iPos, LPCWSTR wszPropName=L"RVALUETYPE");
};

/////////////////////////////////////////////////////////////////////////////
