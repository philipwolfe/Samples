#pragma once
#include "afxwin.h"


// CEnterVariantDlg dialog

class CEnterVariantDlg : public CDialog
{
	DECLARE_DYNAMIC(CEnterVariantDlg)

public:
	CEnterVariantDlg( PROPVARIANT& var, CWnd* pParent = NULL);   // standard constructor
	virtual ~CEnterVariantDlg();

// Dialog Data
	enum { IDD = IDD_ENTER_VARIANT_DLG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual BOOL OnInitDialog();
	PROPVARIANT& m_var;
	DECLARE_MESSAGE_MAP()
public:
	CComboBox m_combo;
	CEdit m_edit;
	CStatic m_label;
	afx_msg void OnBnClickedOk();
};
