// SectSet.h : interface of the CSectionSet class
//
/////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

class CSectionSet : public CRecordset
{
public:
	CSectionSet(CDatabase* pDatabase = NULL);
	DECLARE_DYNAMIC(CSectionSet)

// Field/Param Data
	//{{AFX_FIELD(CSectionSet, CRecordset)
	CString	m_CourseID;
	CString	m_SectionNo;
	CString	m_InstructorID;
	CString	m_RoomNo;
	CString	m_Schedule;
	int	m_Capacity;
	//}}AFX_FIELD
	CString m_strCourseIDParam;

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CSectionSet)
	public:
	virtual CString GetDefaultSQL(); 	// default SQL for Recordset
	virtual void DoFieldExchange(CFieldExchange* pFX);	// RFX support
	//}}AFX_VIRTUAL

// Implementation
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

};
