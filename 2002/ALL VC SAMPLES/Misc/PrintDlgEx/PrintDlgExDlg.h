// PrintDlgExDlg.h : header file
//

#pragma once


// CPrintDlgExDlg dialog
class CPrintDlgExDlg : public CDialog
{
// Construction
public:
	CPrintDlgExDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_PRINTDLGEX_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;
	void Print(HDC hdc);

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnPrint();
	afx_msg void OnPrintNew();
	DECLARE_MESSAGE_MAP()
};
