// DHTMLEditorDoc.h : interface of the CDHTMLEditorDoc class
//


#pragma once

class CDHTMLEditorDoc : public CHtmlEditDoc
{
protected: // create from serialization only
	CDHTMLEditorDoc();
	DECLARE_DYNCREATE(CDHTMLEditorDoc)

// Attributes
public:

// Operations
public:

// Overrides
	public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Implementation
public:
	virtual ~CDHTMLEditorDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


