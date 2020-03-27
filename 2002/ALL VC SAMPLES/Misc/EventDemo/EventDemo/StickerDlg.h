#pragma once


class CEventDemoDlg;

// CStickerDlg dialog
// Implements event receiver.

class CStickerDlg : public CDialog
{
	DECLARE_DYNAMIC(CStickerDlg)

public:
	CStickerDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~CStickerDlg();

	BOOL CreateSticker(LPCTSTR szMesssage, CEventDemoDlg* pParent);
	void RemoveSticker();

	// MoveParent event handler.
	void OnMoveParent();

// Dialog Data
	enum { IDD = IDD_STICKERDLG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	CEventDemoDlg* m_pParent;	// Pointer to the parent dialog.

	DECLARE_MESSAGE_MAP()
};
