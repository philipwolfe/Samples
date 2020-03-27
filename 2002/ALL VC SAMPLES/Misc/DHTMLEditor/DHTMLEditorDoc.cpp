// DHTMLEditorDoc.cpp : implementation of the CDHTMLEditorDoc class
//

#include "stdafx.h"
#include "DHTMLEditor.h"

#include "DHTMLEditorDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// CDHTMLEditorDoc

IMPLEMENT_DYNCREATE(CDHTMLEditorDoc, CHtmlEditDoc)

BEGIN_MESSAGE_MAP(CDHTMLEditorDoc, CHtmlEditDoc)
END_MESSAGE_MAP()


// CDHTMLEditorDoc construction/destruction

CDHTMLEditorDoc::CDHTMLEditorDoc()
{
	// TODO: add one-time construction code here

}

CDHTMLEditorDoc::~CDHTMLEditorDoc()
{
}

BOOL CDHTMLEditorDoc::OnNewDocument()
{
	if (!CHtmlEditDoc::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CDHTMLEditorDoc serialization

void CDHTMLEditorDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}


// CDHTMLEditorDoc diagnostics

#ifdef _DEBUG
void CDHTMLEditorDoc::AssertValid() const
{
	CHtmlEditDoc::AssertValid();
}

void CDHTMLEditorDoc::Dump(CDumpContext& dc) const
{
	CHtmlEditDoc::Dump(dc);
}
#endif //_DEBUG


// CDHTMLEditorDoc commands
