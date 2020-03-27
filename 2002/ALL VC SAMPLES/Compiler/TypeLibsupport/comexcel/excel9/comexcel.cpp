// Copyright (C) 1992-1998 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Visual C++ Language  Reference and related
// electronic documentation provided with Microsoft Visual C++.
// See these sources for detailed information regarding the
// Microsoft Visual C++ product.

// NOTE: This example will only work with Excel9 in Office2000
// Compile with cl /GX comexcel.cpp
#include "stdafx.h"

#define USE_PROGID 1
#define USE_LIBID 0

#if USE_PROGID
#import "progid:Excel.Sheet.8" auto_search auto_rename rename_search_namespace("Office9")
#elif USE_LIBID
#import "libid:{00020813-0000-0000-C000-000000000046}" auto_search auto_rename version(1.3) lcid(0) no_search_namespace
#else
#pragma message ("Make sure excel9.olb is on the path")
#import "excel9.olb" auto_search auto_rename
#endif




void dump_com_error(_com_error &e)
{
    _tprintf(_T("Oops - hit an error!\n"));
    _tprintf(_T("\a\tCode = %08lx\n"), e.Error());
    _tprintf(_T("\a\tCode meaning = %s\n"), e.ErrorMessage());
    _bstr_t bstrSource(e.Source());
    _bstr_t bstrDescription(e.Description());
    _tprintf(_T("\a\tSource = %s\n"), (LPCTSTR) bstrSource);
    _tprintf(_T("\a\tDescription = %s\n"), (LPCTSTR) bstrDescription);
}

// If this is placed in the scope of the smart pointers, they must be
// explicitly Release(d) before CoUninitialize() is called.  If any reference
// count is non-zero, a protection fault will occur.
struct StartOle {
    StartOle() { CoInitialize(NULL); }
    ~StartOle() { CoUninitialize(); }
} _inst_StartOle;

void main()
{
    using namespace Excel;

    _ApplicationPtr pXL;

    try {
    pXL.CreateInstance(L"Excel.Application.9");

    pXL->Visible[0] = VARIANT_TRUE;

    WorkbooksPtr pBooks = pXL->Workbooks;
    _WorkbookPtr pBook  = pBooks->Add((long)xlWorksheet);

    _WorksheetPtr pSheet = pXL->ActiveSheet;
        
    try {
        // This one will fail
        pSheet->Name = "Market Share?";
    } catch (_com_error &e) {
        dump_com_error(e);
    }

    pSheet->Name = "Market Share!";

    pSheet->Range["A2"]->Value = "Company A";
    pSheet->Range["B2"]->Value = "Company B";
    pSheet->Range["C2"]->Value = "Company C";
    pSheet->Range["D2"]->Value = "Company D";

    pSheet->Range["A3"]->Value = 75.0;
    pSheet->Range["B3"]->Value = 14.0;
    pSheet->Range["C3"]->Value = 7.0;
    pSheet->Range["D3"]->Value = 4.0;
    
    Sleep(1000);

    RangePtr  pRange  = pSheet->Range["A2:D3"];
    _ChartPtr  pChart  = pBook->Charts->Add();
    
    pChart->ChartWizard((Range*) pRange, (long) xl3DPie, 7L, (long) xlRows,
        1L, 0L, 2L, "Market Share");

    Sleep(6000);

    pBook->Saved[0] = VARIANT_TRUE;
    pXL->Quit();
    } catch(_com_error &e) {
    dump_com_error(e);
    }
}