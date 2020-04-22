#pragma once
#include "ATLIMAPI.h"

// CCreateRedbookDiskDlg dialog

class CCreateRedbookDiskDlg : public CDialog
{
	DECLARE_DYNAMIC(CCreateRedbookDiskDlg)

public:
	CCreateRedbookDiskDlg( CDiscMaster& dm, CWnd* pParent = NULL);   // standard constructor
	virtual ~CCreateRedbookDiskDlg();

// Dialog Data
	enum { IDD = IDD_CREATE_REDBOOK_DISK_DLG };

protected:
	CDiscMaster& m_dm;
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual BOOL OnInitDialog();
	void UpdateButtons();

	DECLARE_MESSAGE_MAP()
public:
	CListCtrl m_tracksList;
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedAddTrack();
	afx_msg void OnBnClickedDeleteTrack();
	afx_msg void OnBnClickedMoveUp();
	afx_msg void OnBnClickedMoveDown();
	afx_msg void OnBnClickedBurn();
	afx_msg void OnLvnItemchangedTracksList(NMHDR *pNMHDR, LRESULT *pResult);
};
