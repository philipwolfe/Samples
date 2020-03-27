// MsgMapdemoDlg.h : header file
//

#pragma once

#define WM_USER_MESSAGE (WM_APP + 1)	// User defined message.

// CMsgMapdemoDlg dialog
class CMsgMapdemoDlg : public CDialog
{
// Construction
public:
	CMsgMapdemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_MSGMAPDEMO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnBtnClicked();
	afx_msg LRESULT OnUserMessage(WPARAM wParam, LPARAM lParam);
//	afx_msg LRESULT OnUserMessage(WPARAM wParam);	// 1. Try it in VC6 release build, it will crash.
													// In VC7 it will give you Compiler Error C2440.
//	afx_msg LRESULT OnUserMessage();				// 2. Try it in VC6 release build, it will crash.
													// In VC7 it will give you Compiler Error C2440.
//	afx_msg void OnUserMessage();					// 3. Try it in VC6 release build, it will crash.
													// In VC7 it will give you Compiler Error C2440.
													// Do not forget to update source file
													// with function definition.
	DECLARE_MESSAGE_MAP()
};
