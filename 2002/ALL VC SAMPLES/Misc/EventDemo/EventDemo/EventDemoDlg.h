// EventDemoDlg.h : header file
//

#pragma once

class CStickerDlg;
// CEventDemoDlg dialog
// Implements event source.

class CEventDemoDlg : public CDialog
{
// Construction
public:
	CEventDemoDlg(CWnd* pParent = NULL);	// standard constructor

	// Event definition.
	__event void MoveParent();
	
	// Dialog Data
	enum { IDD = IDD_EVENTDEMO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

	CStickerDlg* pSticker;


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnCreateSticker();
	afx_msg void OnMove(int x,int y);
	DECLARE_MESSAGE_MAP()
};
