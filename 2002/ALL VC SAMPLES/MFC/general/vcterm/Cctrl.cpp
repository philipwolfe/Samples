// cctrl.cpp : implementation of the CCommCtrl class

// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

// Machine generated IDispatch wrapper class(es) created by Microsoft Visual C++

// NOTE: Do not modify the contents of this file.  If this class is regenerated by
// Microsoft Visual C++, your modifications will be overwritten.

#include "stdafx.h"
#include "cctrl.h"

/////////////////////////////////////////////////////////////////////////////
// CCommCtrl

IMPLEMENT_DYNCREATE(CCommCtrl, CWnd)

/////////////////////////////////////////////////////////////////////////////
// CCommCtrl properties

BOOL CCommCtrl::GetCDHolding()
{
	BOOL result;
	GetProperty(0x1, VT_BOOL, (void*)&result);
	return result;
}

void CCommCtrl::SetCDHolding(BOOL propVal)
{
	SetProperty(0x1, VT_BOOL, propVal);
}

long CCommCtrl::GetCDTimeout()
{
	long result;
	GetProperty(0x2, VT_I4, (void*)&result);
	return result;
}

void CCommCtrl::SetCDTimeout(long propVal)
{
	SetProperty(0x2, VT_I4, propVal);
}

short CCommCtrl::GetCommID()
{
	short result;
	GetProperty(0x3, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetCommID(short propVal)
{
	SetProperty(0x3, VT_I2, propVal);
}

short CCommCtrl::GetCommPort()
{
	short result;
	GetProperty(0x4, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetCommPort(short propVal)
{
	SetProperty(0x4, VT_I2, propVal);
}

BOOL CCommCtrl::GetCTSHolding()
{
	BOOL result;
	GetProperty(0x5, VT_BOOL, (void*)&result);
	return result;
}

void CCommCtrl::SetCTSHolding(BOOL propVal)
{
	SetProperty(0x5, VT_BOOL, propVal);
}

long CCommCtrl::GetCTSTimeout()
{
	long result;
	GetProperty(0x6, VT_I4, (void*)&result);
	return result;
}

void CCommCtrl::SetCTSTimeout(long propVal)
{
	SetProperty(0x6, VT_I4, propVal);
}

BOOL CCommCtrl::GetDSRHolding()
{
	BOOL result;
	GetProperty(0x7, VT_BOOL, (void*)&result);
	return result;
}

void CCommCtrl::SetDSRHolding(BOOL propVal)
{
	SetProperty(0x7, VT_BOOL, propVal);
}

long CCommCtrl::GetDSRTimeout()
{
	long result;
	GetProperty(0x8, VT_I4, (void*)&result);
	return result;
}

void CCommCtrl::SetDSRTimeout(long propVal)
{
	SetProperty(0x8, VT_I4, propVal);
}

BOOL CCommCtrl::GetDTREnable()
{
	BOOL result;
	GetProperty(0x9, VT_BOOL, (void*)&result);
	return result;
}

void CCommCtrl::SetDTREnable(BOOL propVal)
{
	SetProperty(0x9, VT_BOOL, propVal);
}

long CCommCtrl::GetHandshaking()
{
	long result;
	GetProperty(0xa, VT_I4, (void*)&result);
	return result;
}

void CCommCtrl::SetHandshaking(long propVal)
{
	SetProperty(0xa, VT_I4, propVal);
}

short CCommCtrl::GetInBufferSize()
{
	short result;
	GetProperty(0xb, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetInBufferSize(short propVal)
{
	SetProperty(0xb, VT_I2, propVal);
}

short CCommCtrl::GetInBufferCount()
{
	short result;
	GetProperty(0xc, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetInBufferCount(short propVal)
{
	SetProperty(0xc, VT_I2, propVal);
}

BOOL CCommCtrl::GetBreak()
{
	BOOL result;
	GetProperty(0xd, VT_BOOL, (void*)&result);
	return result;
}

void CCommCtrl::SetBreak(BOOL propVal)
{
	SetProperty(0xd, VT_BOOL, propVal);
}

short CCommCtrl::GetInputLen()
{
	short result;
	GetProperty(0xe, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetInputLen(short propVal)
{
	SetProperty(0xe, VT_I2, propVal);
}

long CCommCtrl::GetInterval()
{
	long result;
	GetProperty(0xf, VT_I4, (void*)&result);
	return result;
}

void CCommCtrl::SetInterval(long propVal)
{
	SetProperty(0xf, VT_I4, propVal);
}

BOOL CCommCtrl::GetNullDiscard()
{
	BOOL result;
	GetProperty(0x10, VT_BOOL, (void*)&result);
	return result;
}

void CCommCtrl::SetNullDiscard(BOOL propVal)
{
	SetProperty(0x10, VT_BOOL, propVal);
}

short CCommCtrl::GetOutBufferSize()
{
	short result;
	GetProperty(0x11, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetOutBufferSize(short propVal)
{
	SetProperty(0x11, VT_I2, propVal);
}

short CCommCtrl::GetOutBufferCount()
{
	short result;
	GetProperty(0x12, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetOutBufferCount(short propVal)
{
	SetProperty(0x12, VT_I2, propVal);
}

CString CCommCtrl::GetParityReplace()
{
	CString result;
	GetProperty(0x13, VT_BSTR, (void*)&result);
	return result;
}

void CCommCtrl::SetParityReplace(LPCTSTR propVal)
{
	SetProperty(0x13, VT_BSTR, propVal);
}

BOOL CCommCtrl::GetPortOpen()
{
	BOOL result;
	GetProperty(0x14, VT_BOOL, (void*)&result);
	return result;
}

void CCommCtrl::SetPortOpen(BOOL propVal)
{
	SetProperty(0x14, VT_BOOL, propVal);
}

short CCommCtrl::GetRThreshold()
{
	short result;
	GetProperty(0x15, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetRThreshold(short propVal)
{
	SetProperty(0x15, VT_I2, propVal);
}

BOOL CCommCtrl::GetRTSEnable()
{
	BOOL result;
	GetProperty(0x16, VT_BOOL, (void*)&result);
	return result;
}

void CCommCtrl::SetRTSEnable(BOOL propVal)
{
	SetProperty(0x16, VT_BOOL, propVal);
}

CString CCommCtrl::GetSettings()
{
	CString result;
	GetProperty(0x17, VT_BSTR, (void*)&result);
	return result;
}

void CCommCtrl::SetSettings(LPCTSTR propVal)
{
	SetProperty(0x17, VT_BSTR, propVal);
}

short CCommCtrl::GetSThreshold()
{
	short result;
	GetProperty(0x18, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetSThreshold(short propVal)
{
	SetProperty(0x18, VT_I2, propVal);
}

VARIANT CCommCtrl::GetOutput()
{
	VARIANT result;
	GetProperty(0x19, VT_VARIANT, (void*)&result);
	return result;
}

void CCommCtrl::SetOutput(const VARIANT& propVal)
{
	SetProperty(0x19, VT_VARIANT, &propVal);
}

CString CCommCtrl::GetInput()
{
	CString result;
	GetProperty(0x1a, VT_BSTR, (void*)&result);
	return result;
}

void CCommCtrl::SetInput(LPCTSTR propVal)
{
	SetProperty(0x1a, VT_BSTR, propVal);
}

short CCommCtrl::GetCommEvent()
{
	short result;
	GetProperty(0x1b, VT_I2, (void*)&result);
	return result;
}

void CCommCtrl::SetCommEvent(short propVal)
{
	SetProperty(0x1b, VT_I2, propVal);
}

/////////////////////////////////////////////////////////////////////////////
// CCommCtrl operations

void CCommCtrl::AboutBox()
{
	InvokeHelper(0xfffffdd8, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
}