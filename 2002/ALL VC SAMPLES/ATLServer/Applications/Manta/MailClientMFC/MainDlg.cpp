// MainDlg.cpp : implementation file
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "MailClientMFC.h"
#include "MainDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMainDlg dialog

CMainDlg::CMainDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CMainDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAILICON);
}

void CMainDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_MSGLIST, m_ctrlMsgList);
}

BEGIN_MESSAGE_MAP(CMainDlg, CDialog)
	ON_NOTIFY(NM_DBLCLK, IDC_MSGLIST, OnMessageDblClick)
	ON_MESSAGE(WM_TRAYEVENT, OnTrayEvent)
	ON_WM_SYSCOMMAND()
	ON_WM_TIMER()
	ON_COMMAND(IDC_CHECKMAIL, OnCheckMail)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMainDlg message handlers

BOOL CMainDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// Setup the listview columns
	m_ctrlMsgList.InsertColumn(0, "", LVCFMT_LEFT, 18);
	m_ctrlMsgList.InsertColumn(1, "From:", LVCFMT_LEFT, 108);
	m_ctrlMsgList.InsertColumn(2, "Subject:", LVCFMT_LEFT, 90);
	m_ctrlMsgList.InsertColumn(3, "Date:", LVCFMT_LEFT, 70);

	// Load the unread and read bitmaps
	m_bmpUnread.LoadBitmap(IDB_UNREADBMP);
	m_bmpRead.LoadBitmap(IDB_READBMP);

	// Create the image list and add the bitmaps
	m_imgList.Create(16, 16, ILC_COLOR16, 2, 0);
	m_imgList.Add(&m_bmpUnread, RGB(5, 5, 5));
	m_imgList.Add(&m_bmpRead, RGB(5, 5, 5));
	
	// Associate the image list with the listview
	m_ctrlMsgList.SetImageList(&m_imgList, LVSIL_SMALL);

	// Set to highlight the full row
	ListView_SetExtendedListViewStyle(m_ctrlMsgList, LVS_EX_FULLROWSELECT);

	// Set the initial check mail timer
	SetTimer(TIMERID_CHECKMAIL, 1, NULL);
	return TRUE;  
}

void CMainDlg::OnTimer(UINT nIDEvent)
{
	// If this is a check mail timer
	if (nIDEvent == TIMERID_CHECKMAIL)
	{
		// Kill the timer
		KillTimer(TIMERID_CHECKMAIL);
		// Check mail
		OnCheckMail();
		// Reset the timer for 5 minutes
		SetTimer(TIMERID_CHECKMAIL, 300000, NULL);
	}
}

void CMainDlg::OnSysCommand(UINT uCode, LONG lPos)
{
	// If this is a minimize system command
	if (uCode == SC_MINIMIZE)
	{
		NOTIFYICONDATA nid;

		// Fill out the notify icon data struct
		nid.cbSize = sizeof(NOTIFYICONDATA);
		nid.hWnd = m_hWnd;
        nid.uID = 101;
		nid.uFlags = NIF_ICON | NIF_MESSAGE | NIF_TIP;
		nid.uCallbackMessage = WM_TRAYEVENT;
		nid.hIcon = m_hIcon;
		lstrcpy(nid.szTip, "MantaWeb Mail Service Client");

		// Add the icon to the tray
		Shell_NotifyIcon(NIM_ADD, &nid);
		// Hide the main dialog
		ShowWindow(SW_HIDE);
		return;
	}
	return CDialog::OnSysCommand(uCode, lPos);
}

LRESULT CMainDlg::OnTrayEvent(WPARAM wp, LPARAM lp)
{
	wp;
	// If the user double clicked the tray icon
	if (lp == WM_LBUTTONDBLCLK)
	{
		NOTIFYICONDATA nid;

		nid.cbSize = sizeof(NOTIFYICONDATA);
		nid.hWnd = m_hWnd;
		nid.uID = 101;
        
		// Delete the tray icon
		Shell_NotifyIcon(NIM_DELETE, &nid);
		// Show the main dialog
		ShowWindow(SW_SHOWNORMAL);
	}
	return 0;
}

void CMainDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting
		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

HCURSOR CMainDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CMainDlg::OnCancel()
{
	// Check to see if they want to quit
	if (MessageBox("Are you sure you want to quit?", "MantaWeb Mail Service Client", MB_YESNO | MB_ICONINFORMATION) == IDNO)
		return;
	// Return OK since we're quiting
	return CDialog::OnOK();
}

void CMainDlg::OnCheckMail()
{
	// Disable the check mail button
	DisableCheckMailButton();

	// Delete all existing items in the listview
	m_ctrlMsgList.DeleteAllItems();

	CMailClientApp* pMailApp = (CMailClientApp*) AfxGetApp();

	int iMessageCount=0;
	// Get the message count
	if (FAILED(m_mailService.GetMessageCount(pMailApp->GetUserID(), pMailApp->GetSessionID(), &iMessageCount)))
	{
		// An error occured, assume that the session became invalid
		int lUserID=-1;
		CComBSTR bstrSessionID;
		bool bFailed = false;
		// Attempt to relogin
		if (FAILED(m_mailService.Login(CComBSTR(pMailApp->GetLogin()), CComBSTR(pMailApp->GetPassword()), &lUserID, &bstrSessionID)))
		{
			bFailed = true;
			MessageBox("Could not login to mail service.  Unspecified error.", "MantaWeb Mail Service Error", MB_OK | MB_ICONHAND);
		}
		else if (lUserID == -1)	// Login failed
		{
			MessageBox("Could not login to mail service.  Your password was changed.", "MantaWeb Mail Service Error", MB_OK | MB_ICONINFORMATION);
			EndDialog(IDCANCEL);
			return;
		}
		else if (FAILED(m_mailService.GetMessageCount(lUserID, bstrSessionID, &iMessageCount)))
		{
			// Login succeeded, but we could not get the message count
			bFailed = true;
            MessageBox("Could not get the message count.", "MantaWeb Mail Service Error", MB_OK | MB_ICONHAND);
		}
		// Reset the session and user id
		pMailApp->SetSessionID(bstrSessionID);
		pMailApp->SetUserID(lUserID);

		if (bFailed)
		{
			EnableCheckMailButton();
			return;
		}
	}

	int iUnreadCount;
	// Get the unread message count
	if (FAILED(m_mailService.GetUnreadCount(pMailApp->GetUserID(), pMailApp->GetSessionID(), &iUnreadCount)))
	{
		MessageBox("Could not get the unread message count.", "MantaWeb Mail Service Error", MB_OK | MB_ICONHAND);
		EnableCheckMailButton();
		return;
	}

	// If there are messages
	if (iMessageCount > 0)
	{
		// Set the msg count text
		CString strText;
		strText.Format("You have %d (%d unread) message(s):", iMessageCount, iUnreadCount);
		SetDlgItemText(IDC_MSGTEXT, strText);

		// Get the messages from the service
		struct _MSGDATA *msgData=NULL;
		int iOutMsgCount = 0;
		if (FAILED(m_mailService.GetMessages(pMailApp->GetUserID(), pMailApp->GetSessionID(),iMessageCount, &msgData, &iOutMsgCount)))
		{
			MessageBox("Could not retrieve the messages.", "MantaWeb Mail Service Error", MB_OK | MB_ICONHAND);
			EnableCheckMailButton();
			return;
		}
		CString strMsg;
		int index=0;
		USES_CONVERSION;
		for (int i = 0; i < iOutMsgCount; i++)
		{
			// For each message, add to the listview
			index = m_ctrlMsgList.InsertItem(m_ctrlMsgList.GetItemCount(), "", (msgData[i].m_bMarkedRead) ? 1 : 0);
			m_ctrlMsgList.SetItemText(index, 1, W2CT(msgData[i].m_bstrFrom));
			m_ctrlMsgList.SetItemText(index, 2, W2CT(msgData[i].m_bstrSubject));
			m_ctrlMsgList.SetItemText(index, 3, COleDateTime((DATE)msgData[i].m_DateSent).Format("%m/%d/%Y"));
			m_ctrlMsgList.SetItemData(index, (DWORD) msgData[i].m_lMessageID);
			// Cleanup the members of the MSGDATA struct
			AtlCleanupValue(&msgData[i]);
		}
		// Delete the array
		delete[] msgData;
	}
	else
	{
		SetDlgItemText(IDC_MSGTEXT, "You have no messages in your Inbox.");
	}
	// Enable the check mail button
	EnableCheckMailButton();
}

void CMainDlg::DisableCheckMailButton()
{
	// Change the text and disable the button
	GetDlgItem(IDC_CHECKMAIL)->SetWindowText("Checking Mail...");
	GetDlgItem(IDC_CHECKMAIL)->EnableWindow(FALSE);
}

void CMainDlg::EnableCheckMailButton()
{
	// Change the text back and enable the button
	GetDlgItem(IDC_CHECKMAIL)->SetWindowText("Check For New Messages");
	GetDlgItem(IDC_CHECKMAIL)->EnableWindow();
}

void CMainDlg::OnMessageDblClick(NMHDR* pNMHDR, LRESULT* pResult)
{
	pNMHDR;
	DWORD dwPos = GetMessagePos();
	CPoint pt(LOWORD(dwPos), HIWORD(dwPos));
	UINT uFlags=0;

	// Convert from screen to listview client coords
	m_ctrlMsgList.ScreenToClient(&pt);

	// Hit test the point
	int nItem = m_ctrlMsgList.HitTest(pt, &uFlags);

	// If no item was found
	if (nItem == -1)
	{
		LVHITTESTINFO lvhti;
		lvhti.pt = pt;
		// Hit test on a subitem
		m_ctrlMsgList.SubItemHitTest(&lvhti);

		// No subitem found, take no action
		if (!(lvhti.flags & LVHT_ONITEMLABEL) || lvhti.iItem == -1)
			return;

		// Item was found
		nItem = lvhti.iItem;
	}
	// Get the item data (message id)
	DWORD_PTR msgID = m_ctrlMsgList.GetItemData(nItem);
	CString strURL;

	// Get the app pointer
	CMailClientApp* pMailApp = (CMailClientApp*) AfxGetApp();

	CComBSTR bstrURL;
	// Get the launch url from the service
	if (FAILED(m_mailService.GetLaunchURL(pMailApp->GetUserID(), pMailApp->GetSessionID(), static_cast<int>(msgID), &bstrURL)))
	{
		MessageBox("Could not retrieve launch URL.", "Mail Service Error", MB_OK | MB_ICONHAND);
		return;
	}
	USES_CONVERSION;
	// Open the browser to the url
	if (ShellExecute(NULL, "open", W2CT(bstrURL), NULL, NULL, SW_SHOWNORMAL) < (HINSTANCE) 32)
	{
		MessageBox("Could not launch default browser.", "Mail Service Error", MB_OK | MB_ICONHAND);
		return;
	}
	// Set the item's image to read
	m_ctrlMsgList.SetItem(nItem, 0, LVIF_IMAGE, NULL, 1, NULL, (UINT)-1, NULL, NULL);
	*pResult = 0;
}	