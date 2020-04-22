// EnterVariantDlg.cpp : implementation file
//

#include "stdafx.h"
#include "IMAPISample.h"
#include "EnterVariantDlg.h"


// CEnterVariantDlg dialog

IMPLEMENT_DYNAMIC(CEnterVariantDlg, CDialog)
CEnterVariantDlg::CEnterVariantDlg( PROPVARIANT& var, CWnd* pParent /*=NULL*/)
	: CDialog(CEnterVariantDlg::IDD, pParent), m_var( var )
{
}

CEnterVariantDlg::~CEnterVariantDlg()
{
}

void CEnterVariantDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBO, m_combo);
	DDX_Control(pDX, IDC_EDIT, m_edit);
	DDX_Control(pDX, IDC_VALUE_LABEL, m_label);
}


BEGIN_MESSAGE_MAP(CEnterVariantDlg, CDialog)
	ON_BN_CLICKED(IDOK, OnBnClickedOk)
END_MESSAGE_MAP()


BOOL CEnterVariantDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	CString csVal;
	SetWindowText( L"Edit property:" );
	switch( m_var.vt )
	{
	case VT_I1:
		csVal.Format( L"%d", m_var.cVal );
		m_label.SetWindowText( L"Enter integer (I1) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_I2:
		csVal.Format( L"%d", m_var.iVal );
		m_label.SetWindowText( L"Enter integer (I2) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_I4:
		csVal.Format( L"%d", m_var.lVal );
		m_label.SetWindowText( L"Enter integer (I4) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_INT:
		csVal.Format( L"%d", m_var.intVal );
		m_label.SetWindowText( L"Enter integer (INT) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_UI1:
		csVal.Format( L"%d", m_var.bVal );
		m_label.SetWindowText( L"Enter integer (UI1) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_UI2:
		csVal.Format( L"%d", m_var.uiVal );
		m_label.SetWindowText( L"Enter integer (UI2) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_UI4:
		csVal.Format( L"%d", m_var.ulVal );
		m_label.SetWindowText( L"Enter integer (UI4) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_UINT:
		csVal.Format( L"%d", m_var.uintVal );
		m_label.SetWindowText( L"Enter integer (UINT) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_R4:
		csVal.Format( L"%f", m_var.fltVal );
		m_label.SetWindowText( L"Enter floating point (R4) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_R8:
		csVal.Format( L"%f", m_var.dblVal );
		m_label.SetWindowText( L"Enter floating point (R8) value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_BSTR:
		if( m_var.bstrVal )
		{
			csVal.Format( L"%s", m_var.bstrVal );
			SysFreeString( m_var.bstrVal );
		}
		m_label.SetWindowText( L"Enter string value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_LPSTR:
		csVal.Format( L"%S", m_var.pszVal );
		m_label.SetWindowText( L"Enter string value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_LPWSTR:
		csVal.Format( L"%s", m_var.pwszVal );
		m_label.SetWindowText( L"Enter string value:" );
		m_combo.ShowWindow( FALSE );
		m_edit.SetWindowText( csVal );
		break;
	case VT_BOOL:
		m_label.SetWindowText( L"Choose boolean value:" );
		if( m_var.boolVal )
			m_combo.SetCurSel( 0 );
		else
			m_combo.SetCurSel( 1 );
		m_edit.ShowWindow( FALSE );
		break;
	default:
		MessageBox( L"Unsupported value type!" );
		PostMessage( WM_COMMAND, IDCANCEL, NULL );
	}
	return TRUE;
}

// CEnterVariantDlg message handlers

void CEnterVariantDlg::OnBnClickedOk()
{
	CString csVal;
	switch( m_var.vt )
	{
	case VT_I1:
		m_edit.GetWindowText( csVal );
		m_var.cVal = _wtoi( csVal );
		break;
	case VT_I2:
		m_edit.GetWindowText( csVal );
		m_var.iVal = _wtoi( csVal );
		break;
	case VT_I4:
		m_edit.GetWindowText( csVal );
		m_var.lVal = _wtoi( csVal );
		break;
	case VT_INT:
		m_edit.GetWindowText( csVal );
		m_var.intVal = _wtoi( csVal );
		break;
	case VT_UI1:
		m_edit.GetWindowText( csVal );
		m_var.bVal = _wtoi( csVal );
		break;
	case VT_UI2:
		m_edit.GetWindowText( csVal );
		m_var.uiVal = _wtoi( csVal );
		break;
	case VT_UI4:
		m_edit.GetWindowText( csVal );
		m_var.ulVal = _wtoi( csVal );
		break;
	case VT_UINT:
		m_edit.GetWindowText( csVal );
		m_var.uintVal = _wtoi( csVal );
		break;
	case VT_R4:
		m_edit.GetWindowText( csVal );
		m_var.fltVal = _wtof( csVal );
		break;
	case VT_R8:
		m_edit.GetWindowText( csVal );
		m_var.dblVal = _wtof( csVal );
		break;
	case VT_BSTR:
	case VT_LPSTR:
	case VT_LPWSTR:
		{
			m_edit.GetWindowText( csVal );
			CComBSTR bstrVal = csVal;
			m_var.vt = VT_BSTR;
			m_var.bstrVal = bstrVal.Detach();
		}
		break;
	case VT_BOOL:
		if( m_combo.GetCurSel() == 0 )
			m_var.boolVal = TRUE;
		else
			m_var.boolVal = FALSE;
		break;
	}	
	OnOK();
}
