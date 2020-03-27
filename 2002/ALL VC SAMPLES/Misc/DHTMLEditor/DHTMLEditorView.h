// DHTMLEditorView.h : interface of the CDHTMLEditorView class
//


#pragma once


class CDHTMLEditorView : public CHtmlEditView
{
protected: // create from serialization only
	CDHTMLEditorView();
	DECLARE_DYNCREATE(CDHTMLEditorView)

// Attributes
public:
	CDHTMLEditorDoc* GetDocument() const;

// Operations
public:

// Overrides
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:

// Implementation
public:
	virtual ~CDHTMLEditorView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	afx_msg BOOL ExecuteCommand(UINT nID);
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in DHTMLEditorView.cpp
inline CDHTMLEditorDoc* CDHTMLEditorView::GetDocument() const
   { return reinterpret_cast<CDHTMLEditorDoc*>(m_pDocument); }
#endif

