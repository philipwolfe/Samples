// DHTMLEditor.h : main header file for the DHTMLEditor application
//
#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols


// CDHTMLEditorApp:
// See DHTMLEditor.cpp for the implementation of this class
//

class CDHTMLEditorApp : public CWinApp
{
public:
	CDHTMLEditorApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CDHTMLEditorApp theApp;