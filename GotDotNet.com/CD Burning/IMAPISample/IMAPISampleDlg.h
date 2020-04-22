// IMAPISampleDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include "ATLIMAPI.h"


// CIMAPISampleDlg dialog
class CIMAPISampleDlg : public CDialog
{
// Construction
public:
	CIMAPISampleDlg(CWnd* pParent = NULL);	// standard constructor
	~CIMAPISampleDlg();						// standard destructor

// Dialog Data
	enum { IDD = IDD_IMAPISAMPLE_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;
	CDiscMaster m_dm;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()

	void UpdateFormatsList();
	void UpdateDriveList();
	void UpdateDriveFormatInfo();

public:
	afx_msg void OnLbnSelchangeFormatsList();
	afx_msg void OnLbnSelchangeDrivesList();
	CListBox m_listFormats;
	CListBox m_listDrives;
	CEdit m_formatInfo;
	CEdit m_driveInfo;
	afx_msg void OnBnClickedRefreshInfo();
	afx_msg void OnBnClickedOpenExclusive();
	afx_msg void OnBnClickedEject();
	afx_msg void OnBnClickedErase();
	afx_msg void OnBnClickedQueryMediaInfo();
	afx_msg void OnBnClickedQueryMediaType();
	afx_msg void OnBnClickedCreateCD();
};
