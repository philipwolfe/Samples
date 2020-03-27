// Index.H
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

BOOL IsExistentIndex(CDaoTableDef *pTableDef, CString strIndexName);
BOOL createNewIndex(CDaoTableDef *pTableDef, CDaoIndexInfo *pIndexInfo);
BOOL getIndexInfo(CDaoTableDef *pTableDef, CDaoIndexInfo *pIndexInfo,
				  int IndexIndex, BOOL bReportErrors = TRUE);
BOOL deleteIndex(CDaoTableDef *pTableDef, CString strIndexName);