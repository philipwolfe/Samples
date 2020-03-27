// EnrolDoc.h : interface of the CEnrollDoc class
//
/////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#define HINT_ADD_COURSE 1
#define HINT_DELETE_COURSE 2

class CUpdateHint : public CObject
{
	DECLARE_DYNAMIC(CUpdateHint);
	CUpdateHint();
	CString m_strCourse;
};

class CEnrollDoc : public CDocument
{
protected: // create from serialization only
	CEnrollDoc();
	DECLARE_DYNCREATE(CEnrollDoc)

// Attributes
protected:
	CDatabase m_database;
public:
	CSectionSet m_sectionSet;
	CCourseSet m_courseSet; // for combobox in CSectionForm
	CCourseSet m_courseSetForForm; // for CCourseForm

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CEnrollDoc)
	public:
	virtual BOOL OnNewDocument();
	//}}AFX_VIRTUAL

	CDatabase* GetDatabase();

// Implementation
public:
	virtual ~CEnrollDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CEnrollDoc)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////
