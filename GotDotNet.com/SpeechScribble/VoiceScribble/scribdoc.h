// ScribDoc.h : interface of the CScribbleDoc class
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
#include "TurtleGraphics.h"

// Forward declaration of data structure class
class CScribbleItem;

/////////////////////////////////////////////////////////////////////////////
// class CStroke
//
// A stroke is a series of connected points in the scribble drawing.
// A scribble document may have multiple strokes.

class CStroke : public CObject
{
public:
	CStroke(CTurtleGraphicsParser	*TurtleGraphicsParser);

protected:
	CStroke();
	DECLARE_SERIAL(CStroke)

// Attributes
protected:
	CTurtle				m_turtle;
	CTurtleGraphicsParser			*m_pTurtleGraphicsParser;

public:
	arTurtleGraphicsCmds m_cmdArray;   // series of connected points
	CRect m_rectBounding; // smallest rect that surrounds all
										// of the points in the stroke
										// measured in MM_LOENGLISH units
										// (0.01 inches, with Y-axis inverted)

	CPoint					m_ptStart;
public:
	CRect& GetBoundingRect() { return m_rectBounding; }

// Operations
public:
	void FinishStroke();

public:
	virtual void Serialize(CArchive& ar);
};



class CScribbleDoc : public COleServerDoc
					 
{
protected: // create from serialization only
	CScribbleDoc();
	DECLARE_DYNCREATE(CScribbleDoc)

// Attributes
protected:
	// The document keeps track of the current pen width on
	// behalf of all views. We'd like the user interface of
	// Scribble to be such that if the user chooses the Draw
	// Thick Line command, it will apply to all views, not just
	// the view that currently has the focus.

	stTurtleDraw	m_turtleDraw;
	CTurtleGraphicsParser		m_TurtleGraphicsParser;

public:
	// Turtle interface
	void			ExecTurtleCommand(stTurtleGraphicsCmd&	cmd);

	void			Reset();
	void			RemoveLastLine();


protected:
	CSize				m_sizeDoc;
	
	CStroke*			m_pCurrStroke;
	ITurtleGraphicsEditorHandler* m_pEditorHandler;
	ITurtleGraphicsEditorHandler* m_pErrEditorHandler;
	CStringArray		m_arDeclaredVars;
	CStringArray		m_arDeclaredProcs;
	CStringArray		m_arStdVars;

public:
	void SetTurtleGraphicsEditorHandler( ITurtleGraphicsEditorHandler* pEdit)
	{
		m_pEditorHandler	=	pEdit;
		m_TurtleGraphicsParser.SetTurtleGraphicsEditorHandler( pEdit );
	}

	void SetErrorEditorHandler( ITurtleGraphicsEditorHandler* pEdit)
	{
		m_pErrEditorHandler	=	pEdit;
	}

	CTypedPtrList<CObList,CStroke*>     m_strokeList;   

	CSize			GetDocSize() { return m_sizeDoc; }
	CScribbleItem*	GetEmbeddedItem()
		{ return (CScribbleItem*)COleServerDoc::GetEmbeddedItem(); }

// Operations
protected:
	CStroke*	NewStroke();
	void		FinishStroke();
	void		SetRecognizableVars();
	void		SetRecognizableProcs();
	void		AddGrammarVariable(LPCTSTR	strName);
	void		AddGrammarProc(LPCTSTR	strName);
	void		CheckForParsingErrors();

public:
// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CScribbleDoc)
	protected:
	virtual COleServerItem* OnGetEmbeddedItem();
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);
	virtual BOOL OnOpenDocument(LPCTSTR lpszPathName);
	virtual void DeleteContents();
	//}}AFX_VIRTUAL

// Implementation
protected:
	void ReplacePen();
	void OnSetItemRects(LPCRECT lpPosRect, LPCRECT lpClipRect);

public:
	virtual ~CScribbleDoc();
	virtual BOOL OnSaveDocument(LPCTSTR lpszPathName );
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	void            InitDocument(LPCTSTR szFileName = NULL);

// Generated message map functions
protected:
	//{{AFX_MSG(CScribbleDoc)
	afx_msg void OnEditClearAll();
	afx_msg void OnUpdateEditClearAll(CCmdUI* pCmdUI);
	afx_msg void OnEditCopy();
	//}}AFX_MSG
	afx_msg void OnUpdateTurtleGraphicsCompile(CCmdUI *pCmdUI);
	afx_msg void OnUpdateTurtleGraphicsRun(CCmdUI *pCmdUI);


public:
	afx_msg void OnTurtleGraphicsCompile();
	afx_msg void OnTurtleGraphicsRun();


	DECLARE_MESSAGE_MAP()

public:
	void	DrawTurtle(CDC*	pDC);
};

