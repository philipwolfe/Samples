// DHTMLEditorView.cpp : implementation of the CDHTMLEditorView class
//

#include "stdafx.h"
#include "DHTMLEditor.h"

#include "DHTMLEditorDoc.h"
#include "DHTMLEditorView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// CDHTMLEditorView

IMPLEMENT_DYNCREATE(CDHTMLEditorView, CHtmlEditView)

BEGIN_MESSAGE_MAP(CDHTMLEditorView, CHtmlEditView)
	ON_COMMAND_EX(ID_MODE_VIEW, ExecuteCommand)
	ON_COMMAND_EX(ID_MODE_EDIT, ExecuteCommand)
	ON_COMMAND_EX(ID_FORMAT_FONT, ExecuteCommand)
	ON_COMMAND_EX(ID_EDIT_CUT, ExecuteCommand)
	ON_COMMAND_EX(ID_EDIT_COPY, ExecuteCommand)
	ON_COMMAND_EX(ID_EDIT_PASTE, ExecuteCommand)
	ON_COMMAND_EX(ID_FORMAT_INSERTIMAGE, ExecuteCommand)
	ON_COMMAND_EX(ID_EDIT_UNDO, ExecuteCommand)
END_MESSAGE_MAP()

// CDHTMLEditorView construction/destruction

CDHTMLEditorView::CDHTMLEditorView()
{
	// TODO: add construction code here

}

CDHTMLEditorView::~CDHTMLEditorView()
{
}

BOOL CDHTMLEditorView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CDHTMLEditorView drawing

void CDHTMLEditorView::OnDraw(CDC* /*pDC*/)
{
	CDHTMLEditorDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	// TODO: add draw code for native data here
}


// CDHTMLEditorView diagnostics

#ifdef _DEBUG
void CDHTMLEditorView::AssertValid() const
{
	CView::AssertValid();
}

void CDHTMLEditorView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CDHTMLEditorDoc* CDHTMLEditorView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CDHTMLEditorDoc)));
	return (CDHTMLEditorDoc*)m_pDocument;
}
#endif //_DEBUG


// CDHTMLEditorView message handlers
//*******************************************************************
//	ExecuteCommand
//
//		Function maps menu command to the MSHTML Editor commands
//		and executes them.
//
//	RETURNS:
//		TRUE - if function succeeded.
//		FALSE - if function failed.
//*******************************************************************
BOOL CDHTMLEditorView::ExecuteCommand(UINT nID)
{
	// Map menu command to the MSHTML Editor commands.
	HRESULT hRes;

	switch(nID)
	{
		case ID_MODE_VIEW:
			hRes = SetDesignMode(FALSE);
			break;
		case ID_MODE_EDIT:
			hRes = SetDesignMode(TRUE);
			break;
		case ID_FORMAT_FONT:
			hRes = Font();
			break;
		case ID_EDIT_CUT:
			hRes = Cut();
			break;
		case ID_EDIT_COPY:
			hRes = Copy();
			break;
		case ID_EDIT_PASTE:
			hRes = Paste();
			break;
		case ID_FORMAT_INSERTIMAGE:
			hRes = Image();
			break;
		case ID_EDIT_UNDO:
//			hRes = Undo();
			break;
		default:
			return FALSE;
	}

	return hRes == S_OK ? TRUE : FALSE;
}
