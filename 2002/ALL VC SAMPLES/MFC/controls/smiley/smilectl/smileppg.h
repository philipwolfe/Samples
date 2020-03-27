// SmilePpg.h : Declaration of the CSmilePropPage property page class.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

////////////////////////////////////////////////////////////////////////////
// CSmilePropPage : See SmilePpg.cpp.cpp for implementation.

class CSmilePropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CSmilePropPage)
	DECLARE_OLECREATE_EX(CSmilePropPage)

// Constructor
public:
	CSmilePropPage();

// Dialog Data
	//{{AFX_DATA(CSmilePropPage)
	enum { IDD = IDD_PROPPAGE_Smile };
	CString m_strCaption;
	BOOL m_bSad;
	//}}AFX_DATA

// Implementation
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Message maps
protected:
	//{{AFX_MSG(CSmilePropPage)
		// NOTE - ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

};

#ifdef _USRDLL
class CSmileColorPropPage : public CColorPropPage
{
	DECLARE_DYNCREATE(CSmileColorPropPage)
	DECLARE_OLECREATE_EX(CSmileColorPropPage)
};

class CSmileFontPropPage : public CFontPropPage
{
	DECLARE_DYNCREATE(CSmileFontPropPage)
	DECLARE_OLECREATE_EX(CSmileFontPropPage)
};

#endif
