// ChildView.h : interface of the CChildView class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_CHILDVIEW_H__0F64348D_F36B_4B27_BD27_6C8D6BADA5BA__INCLUDED_)
#define AFX_CHILDVIEW_H__0F64348D_F36B_4B27_BD27_6C8D6BADA5BA__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CChildView window
#include "TurtleGraphics.h"

class CChildView : public CWnd,
				   public ITurtleGraphicsEditorHandler
{
	DECLARE_DYNCREATE( CChildView )
// Construction
public:
	CChildView();

// ITurtleGraphicsEditorHandler interface
public:
	void	SetFormattedCode(const CStringArray* pArrLines);
	void	HighlightLine(int iIndex);


// Operations
public:
	void		scrollTop();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CChildView)
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual BOOL OnCommand(WPARAM wParam, LPARAM lParam);
	virtual void OnDraw(CDC *);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CChildView();

	void	ClearText();
	void	DisplayText(CStringArray*	pArrLines);
	void	HilightLine(int iIndex);
	void	GetText(CString& strText);
	void	AddLine(CString strLine, COLORREF col, bool bScrollToEnd);
	void	RemoveLastLine();
	void	SaveToFile(LPCTSTR szFile);


	// Generated message map functions
protected:
	//{{AFX_MSG(CChildView)
	afx_msg int OnCreate( LPCREATESTRUCT lpCreateStruct );
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnClose();
	//}}AFX_MSG
	afx_msg void OnEditCopy(void);
	afx_msg void OnUpdateEditCopy(CCmdUI *pCmdUI);
	afx_msg void OnEditCut(void);
	afx_msg void OnUpdateEditCut(CCmdUI *pCmdUI);
	afx_msg void OnEditPaste(void);
	afx_msg void OnUpdateEditPaste(CCmdUI *pCmdUI);
	afx_msg void OnEditClear();
	afx_msg void OnEditSelectAll(void);
	afx_msg void OnUpdateEditSelectAll(CCmdUI *pCmdUI);
	DECLARE_MESSAGE_MAP()

protected:
	CRichEditCtrl		_editCtrl;
	CFont				m_fontDefault;

	static DWORD CALLBACK dumpProc(DWORD dwCookie, LPBYTE pbBuff, LONG cb, LONG *pcb);
public:
	
private:
	
protected:
public:
	afx_msg void OnSetFocus(CWnd* pOldWnd);
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_CHILDVIEW_H__0F64348D_F36B_4B27_BD27_6C8D6BADA5BA__INCLUDED_)
