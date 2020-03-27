// DHTMLDialogDlg.h : header file
//

#pragma once


// CDHTMLDialogDlg dialog
class CDHTMLDialogDlg : public CDHtmlDialog
{
// Construction
public:
	CDHTMLDialogDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_DHTMLDIALOG_DIALOG, IDH = IDR_HTML_DHTMLDIALOG_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

	HRESULT OnButtonOK(IHTMLElement *pElement);
	HRESULT OnButtonCancel(IHTMLElement *pElement);

	HRESULT OnCheckClick(IHTMLElement *pElement);

// Implementation
protected:
	HICON m_hIcon;
	bool  m_LinkActive;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
	DECLARE_DHTML_EVENT_MAP()
};
