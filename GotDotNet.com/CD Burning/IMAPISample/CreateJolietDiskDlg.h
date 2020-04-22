#pragma once

#include "ATLIMAPI.h"
#include "FoldersAndFiles.h"

// CCreateJolietDiskDlg dialog

class CCreateJolietDiskDlg : public CDialog
{
	DECLARE_DYNAMIC(CCreateJolietDiskDlg)

public:
	CCreateJolietDiskDlg( CDiscMaster& dm, CWnd* pParent = NULL);   // standard constructor
	virtual ~CCreateJolietDiskDlg();

// Dialog Data
	enum { IDD = IDD_CREATE_JOLIET_DISK_DLG };

protected:
	CFoldersAndFiles m_folderAndFiles;
	CDiscMaster& m_dm;
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual BOOL OnInitDialog();

	DECLARE_MESSAGE_MAP()
public:
	CTreeCtrl m_folderTree;
	CListCtrl m_fileList;
	CListCtrl m_propertyList;
	afx_msg void OnBnClickedNewFolder();
	afx_msg void OnBnClickedDeleteFolder();
	afx_msg void OnBnClickedRenameFolder();
	afx_msg void OnTvnEndlabeleditFolderTree(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnBnClickedOk();
	afx_msg void OnTvnSelchangingFolderTree(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnTvnBeginlabeleditFolderTree(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnBnClickedAddFiles();
	afx_msg void OnBnClickedRemoveFiles();
	afx_msg void OnBnClickedRenameFile();
	afx_msg void OnLvnOdstatechangedFileList(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnLvnEndlabeleditFileList(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnBnClickedBurn();
	afx_msg void OnLvnItemchangedPropertyList(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnBnClickedEditProperty();
};
