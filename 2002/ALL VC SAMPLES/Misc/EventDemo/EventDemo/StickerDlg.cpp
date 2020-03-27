// StickerDlg.cpp : implementation file
//

#include "stdafx.h"
#include "EventDemo.h"
#include "StickerDlg.h"

#include "EventDemoDlg.h"


// CStickerDlg dialog

IMPLEMENT_DYNAMIC(CStickerDlg, CDialog)
CStickerDlg::CStickerDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CStickerDlg::IDD, pParent),
	  m_pParent(NULL)
{
}

CStickerDlg::~CStickerDlg()
{
}

void CStickerDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CStickerDlg, CDialog)
END_MESSAGE_MAP()


// CStickerDlg message handlers

//*******************************************************************
//	CreateSticker
//
//	Creates a Sticker, initializes the message text and subscribes
//  the Sticker to receive the events from the main dialog.
//
//	PARAMS:	szMesssage - Sticker message.
//			pParent - pointer to the dialog that hosts the Sticker.
//
//	RETURNS:TRUE - if Sticker was successfully created.
//			FALSE - if function failed to create Sticker.
//*******************************************************************
BOOL CStickerDlg::CreateSticker(LPCTSTR szMesssage, CEventDemoDlg* pParent)
{
	BOOL bRet;

	// Create Sticker dialog.
	bRet = Create(IDD_STICKERDLG, pParent);

	// Set sticker message.
	SetDlgItemText(IDC_MESSAGE, szMesssage);

	m_pParent = pParent;

	// Subscribe for parent dialog event.
	if(m_pParent != NULL)
		__hook(&CEventDemoDlg::MoveParent, m_pParent, &CStickerDlg::OnMoveParent);

	return bRet;
}

//*******************************************************************
//	RemoveSticker
//
//	Unsubscribes Sticker from the parent dialog event and destroys
//	Sticker.
//*******************************************************************
void CStickerDlg::RemoveSticker()
{
	// Unsubscribe from the event.
	if(m_pParent != NULL)
		__unhook(&CEventDemoDlg::MoveParent, m_pParent, &CStickerDlg::OnMoveParent);

	// Destroy the Sticker.
	EndDialog(0);
}

//*******************************************************************
//	OnMoveParent
//
//	Recenters Sticker relative to the parent dialog.
//*******************************************************************
void CStickerDlg::OnMoveParent()
{
	// Recenter Sticker.
	CenterWindow(GetParent());
}

