// Scribble.h : main header file for the SCRIBBLE application
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols


#include "SpeechRecoEnv.h"
#include "VoiceCmdIDs.h"

class CErrorFrm;

/////////////////////////////////////////////////////////////////////////////
// CScribbleApp:
// See Scribble.cpp for the implementation of this class
//

extern CSAPIWrapper_SpeechRecoEnv* g_SpeechEngine;

class CScribbleApp : public CWinApp,
					 public CVoiceCmdTargetT<CScribbleApp>
{
public:
	CScribbleApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CScribbleApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL
public:
	bool			m_bIsEditMode;
	CSAPIWrapper_SpeechRecoEnv	m_speechRecoEnv;

protected:
	CErrorFrm		*m_pFrmError;
// Implementation
	COleTemplateServer m_server;
		// Server object for document creation

	//{{AFX_MSG(CScribbleApp)
	afx_msg void OnAppAbout();
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
	afx_msg void OnUpdateModeGraphic(CCmdUI *pCmdUI);
	afx_msg void OnUpdateModeEdit(CCmdUI *pCmdUI);
	afx_msg void OnUpdateEnableGrammar(CCmdUI *pCmdUI);
	afx_msg void OnUpdateDisableGrammar(CCmdUI *pCmdUI);
	afx_msg void OnEnableGrammar();
	afx_msg void OnDisableGrammar();
	


public:

	afx_msg void OnModeGraphic();
	afx_msg void OnModeEdit();
	
	
	DECLARE_VCOMMAND_MAP()

	BOOL	OnVoiceModeGraphic();
	BOOL	OnVoiceModeEdit();


protected:
	// Enables/disables specific commands according to the current mode
	void	EnableModeCommands();

public:
	virtual int ExitInstance();
};


/////////////////////////////////////////////////////////////////////////////
