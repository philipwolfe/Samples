// Session.h : Declaration of the CUpdateSession
//
// This is a part of the ActiveX Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// ActiveX Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// ActiveX Template Library product.

#ifndef __CUpdateSession_H_
#define __CUpdateSession_H_
#include "resource.h"       // main symbols
#include "rowset.h"
#include <tchar.h>

class CUpdateSessionTRSchemaRowset;
class CUpdateSessionColSchemaRowset;
class CUpdateSessionPTSchemaRowset;
/////////////////////////////////////////////////////////////////////////////
// CUpdateSession
class ATL_NO_VTABLE CUpdateSession : 
	public CComObjectRootEx<CComMultiThreadModel>,
	public IGetDataSourceImpl<CUpdateSession>,
	public IOpenRowsetImpl<CUpdateSession>,
	public ISessionPropertiesImpl<CUpdateSession>,
	public IObjectWithSiteSessionImpl<CUpdateSession>,
	public IDBSchemaRowsetImpl<CUpdateSession>,
	public IDBCreateCommandImpl<CUpdateSession, CUpdateCommand>
{
public:
	CUpdateSession()
	{
	}
	HRESULT FinalConstruct()
	{
		return FInit();
	}
	STDMETHOD(OpenRowset)(IUnknown *pUnk, DBID *pTID, DBID *pInID, REFIID riid,
					   ULONG cSets, DBPROPSET rgSets[], IUnknown **ppRowset)
	{
		RUpdateRowset* pRowset;
		return CreateRowset(pUnk, pTID, pInID, riid, cSets, rgSets, ppRowset, pRowset);
	}

	void SetRestrictions(ULONG cRestrictions, GUID* rguidSchema, ULONG* rgRestrictions)
	{
		for (ULONG l=0; l<cRestrictions; l++)
		{
			if (InlineIsEqualGUID(rguidSchema[l], DBSCHEMA_TABLES))
				rgRestrictions[l] = 0x0C;
			else if (InlineIsEqualGUID(rguidSchema[l], DBSCHEMA_COLUMNS))
				rgRestrictions[l] = 0x04;
			else if (InlineIsEqualGUID(rguidSchema[l], DBSCHEMA_PROVIDER_TYPES))
				rgRestrictions[l] = 0x00;
		}
	}

BEGIN_PROPSET_MAP(CUpdateSession)
	BEGIN_PROPERTY_SET(DBPROPSET_SESSION)
		PROPERTY_INFO_ENTRY(SESS_AUTOCOMMITISOLEVELS)
	END_PROPERTY_SET(DBPROPSET_SESSION)
END_PROPSET_MAP()
BEGIN_COM_MAP(CUpdateSession)
	COM_INTERFACE_ENTRY(IGetDataSource)
	COM_INTERFACE_ENTRY(IOpenRowset)
	COM_INTERFACE_ENTRY(ISessionProperties)
	COM_INTERFACE_ENTRY(IObjectWithSite)
	COM_INTERFACE_ENTRY(IDBCreateCommand)
	COM_INTERFACE_ENTRY(IDBSchemaRowset)
END_COM_MAP()
BEGIN_SCHEMA_MAP(CUpdateSession)
	SCHEMA_ENTRY(DBSCHEMA_TABLES, CUpdateSessionTRSchemaRowset)
	SCHEMA_ENTRY(DBSCHEMA_COLUMNS, CUpdateSessionColSchemaRowset)
	SCHEMA_ENTRY(DBSCHEMA_PROVIDER_TYPES, CUpdateSessionPTSchemaRowset)
END_SCHEMA_MAP()

	///////////////////////////////////////////////////////////////////////
	// OLE DB Conformance Test Functions:  Necessary for compliance

	virtual HRESULT	IsValidValue(ULONG /*iCurSet*/, DBPROP* pDBProp)
	{
		ATLASSERT(pDBProp != NULL);
		DWORD dwPropertyID = pDBProp->dwPropertyID;
		CComVariant var = pDBProp->vValue;

		switch(dwPropertyID)
		{
		case DBPROP_SESS_AUTOCOMMITISOLEVELS:
			{
				DWORD dwMask = (DBPROPVAL_TI_CHAOS |
					DBPROPVAL_TI_READUNCOMMITTED |
					DBPROPVAL_TI_BROWSE |
					DBPROPVAL_TI_CURSORSTABILITY | 
					DBPROPVAL_TI_READCOMMITTED | 
					DBPROPVAL_TI_REPEATABLEREAD |
					DBPROPVAL_TI_SERIALIZABLE |
					DBPROPVAL_TI_ISOLATED);

				// Check to see if someone set us a value other than
				// those allowed in the specification
				if (var.lVal & ~dwMask)
					return S_FALSE;
			}
			break;
		default:
			break;
		}
		return S_OK;
	}

};
class CUpdateSessionTRSchemaRowset : 
	public CSchemaRowsetImpl< CUpdateSessionTRSchemaRowset, CTABLESRow, CUpdateSession>
{
public:
BEGIN_PROPSET_MAP(CUpdateSessionTRSchemaRowset)
	BEGIN_PROPERTY_SET(DBPROPSET_ROWSET)
		PROPERTY_INFO_ENTRY(IAccessor)
		PROPERTY_INFO_ENTRY(IColumnsInfo)
		PROPERTY_INFO_ENTRY(IConvertType)
		PROPERTY_INFO_ENTRY(IRowset)
		PROPERTY_INFO_ENTRY(IRowsetIdentity)
		PROPERTY_INFO_ENTRY(IRowsetInfo)
		PROPERTY_INFO_ENTRY(CANFETCHBACKWARDS)
		PROPERTY_INFO_ENTRY(CANHOLDROWS)
		PROPERTY_INFO_ENTRY(CANSCROLLBACKWARDS)
		PROPERTY_INFO_ENTRY_VALUE(MAXOPENROWS, 0)
		PROPERTY_INFO_ENTRY_VALUE(MAXROWS, 0)
	END_PROPERTY_SET(DBPROPSET_ROWSET)
END_PROPSET_MAP()

	HRESULT Execute(DBROWCOUNT* pcRowsAffected, ULONG cRestrictions, 
				const VARIANT* rgRestrictions)
	{
		USES_CONVERSION;
		CTABLESRow trData;
		FILE* pFile = NULL;
		TCHAR szFile[255];
		bool bNameSet = false;

		// Handle any restrictions sent to us.  We only handle
		// the TABLE_NAME & TABLE_TYPE restictions (the 3rd and 4th 
		// restrictions in DBSCHEMA_TABLES...look in IDBSchemaRowsets 
		// in part 2 of the prog. ref) so our restrictions are 0x08 & 0x04 
		// for a total of (0x0C)
		if (cRestrictions >= 3 && rgRestrictions[2].vt != VT_EMPTY)
		{
			CComBSTR bstrName = rgRestrictions[2].bstrVal;
			if ((rgRestrictions[2].vt == VT_BSTR) && (bstrName != (BSTR)NULL))
			{
				// Check to see if the file exists
				_tcscpy(&szFile[0], OLE2T(bstrName));
				if (szFile[0] == _T('\0') || ((pFile = _tfopen(&szFile[0], _T("r"))) == NULL))
				{
					return S_OK;	// Their restriction was invalid return no data
				}
				else
				{
					fclose(pFile);
					bNameSet = true;
				}
			}
		}

		// TABLE_TYPE restriction
		if (cRestrictions >=4 && rgRestrictions[3].vt != VT_EMPTY)
		{
			CComBSTR bstrType = rgRestrictions[3].bstrVal;
			if ((rgRestrictions[3].vt == VT_BSTR) && (bstrType != (BSTR)NULL))
			{
				// This is kind of a blind restriction.  We only really support
				// TABLES so if we get anything else, we just return an empty
				// rowset
				if (_tcscmp(_T("TABLE"), OLE2T(bstrType)) != 0)
					return S_OK;
			}
		}
		
		// The user didn't specify a TABLE_NAME restriction
		if (bNameSet == false)
		{
			// Use the property in DBPROP_INIT_CATALOG.  To do so first call
			// IGetDataSource::GetDataSource for the pointer to the data
			// source object's IDBProperties interface
			CComPtr<IGetDataSource> spGetSource;
			CComPtr<IDBProperties> spProps;
			CDBPropIDSet set(DBPROPSET_DBINIT);
			set.AddPropertyID(DBPROP_INIT_CATALOG);
			DBPROPSET* pPropSet = NULL;
			ULONG ulPropSet = 0;

			// Get a pointer back to our session object
			HRESULT hr = GetSite(__uuidof(IGetDataSource), (void**)&spGetSource);
			if (FAILED(hr))
				return hr;
			
			// Now get a pointer to the IDBProperties interface on the data source
			hr = spGetSource->GetDataSource(__uuidof(IDBProperties), (IUnknown**)&spProps);
			if (FAILED(hr))
				return hr;

			hr = spProps->GetProperties(1, &set, &ulPropSet, &pPropSet);
			if (FAILED(hr))
				return hr;

			if (pPropSet != NULL)
			{
				CComVariant varCatalog = pPropSet->rgProperties[0].vValue;
				_tcscpy(szFile, OLE2T(varCatalog.bstrVal));
				::CoTaskMemFree(pPropSet->rgProperties);
				::CoTaskMemFree(pPropSet);
			}
			else
				_tcscpy(szFile, _T(""));
		}


		// Bring over the data
		lstrcpyW(trData.m_szType, OLESTR("TABLE"));
		lstrcpyW(trData.m_szDesc, OLESTR("The Directory Table"));
		lstrcpynW(trData.m_szTable, T2OLE(szFile), SIZEOF_MEMBER(CTABLESRow, m_szTable));

		_ATLTRY
		{
			m_rgRowData.Add(trData);
		}
		_ATLCATCHALL()
		{
			return E_OUTOFMEMORY;
		}
		//if (!m_rgRowData.Add(trData))
		//	return E_OUTOFMEMORY;
		*pcRowsAffected = 1;
		return S_OK;
	}

	virtual DBSTATUS GetDBStatus(CSimpleRow* , ATLCOLUMNINFO* pColInfo)
	{
		ATLASSERT(pColInfo != NULL);

		switch(pColInfo->iOrdinal)
		{
		case 3:
		case 4:
		case 6:
			return DBSTATUS_S_OK;
			break;
		default:
			return DBSTATUS_S_ISNULL;
			break;
		}
	}
};
class CUpdateSessionColSchemaRowset : 
	public CSchemaRowsetImpl< CUpdateSessionColSchemaRowset, CCOLUMNSRow, CUpdateSession>
{
public:
BEGIN_PROPSET_MAP(CUpdateSessionColSchemaRowset)
	BEGIN_PROPERTY_SET(DBPROPSET_ROWSET)
		PROPERTY_INFO_ENTRY(IAccessor)
		PROPERTY_INFO_ENTRY(IColumnsInfo)
		PROPERTY_INFO_ENTRY(IConvertType)
		PROPERTY_INFO_ENTRY(IRowset)
		PROPERTY_INFO_ENTRY(IRowsetIdentity)
		PROPERTY_INFO_ENTRY(IRowsetInfo)
		PROPERTY_INFO_ENTRY(CANFETCHBACKWARDS)
		PROPERTY_INFO_ENTRY(CANHOLDROWS)
		PROPERTY_INFO_ENTRY(CANSCROLLBACKWARDS)
		PROPERTY_INFO_ENTRY_VALUE(MAXOPENROWS, 0)
		PROPERTY_INFO_ENTRY_VALUE(MAXROWS, 0)
	END_PROPERTY_SET(DBPROPSET_ROWSET)
END_PROPSET_MAP()

	HRESULT Execute(DBROWCOUNT* pcRowsAffected, ULONG cRestrictions, 
				const VARIANT* rgRestrictions)
	{

		USES_CONVERSION;
		CCOLUMNSRow trData[5];
		FILE* pFile = NULL;
		TCHAR szFile[255];
		bool bNameSet = false;

		// Note, we don't describe the bookmark column here because it may or may
		// not be returned.

		// Handle any restrictions sent to us.  Note, we only handle
		// the TABLE_NAME restiction 
		if (cRestrictions >= 3 && rgRestrictions[2].vt != VT_EMPTY)
		{
			CComBSTR bstrName = rgRestrictions[2].bstrVal;
			if ((rgRestrictions[2].vt == VT_BSTR) && (bstrName != (BSTR)NULL))
			{
				// Check to see if the file exists
				_tcscpy(&szFile[0], OLE2T(bstrName));
				if (szFile[0] == _T('\0') || ((pFile = _tfopen(&szFile[0], _T("r"))) == NULL))
				{
					return S_OK;	// Their restriction was invalid return no data
				}
				else
				{
					fclose(pFile);
					bNameSet = true;
				}
			}
		}

		// The user didn't specify a TABLE_NAME restriction
		if (bNameSet == false)
			_tcscpy(szFile, _T("C:\\public\\myData.txt")); // modify the path to point to your default data file


		// Setup column names
		lstrcpyW(trData[0].m_szColumnName, OLESTR("Fixed"));
		lstrcpyW(trData[1].m_szColumnName, OLESTR("Command"));
		lstrcpyW(trData[2].m_szColumnName, OLESTR("Text"));
		lstrcpyW(trData[3].m_szColumnName, OLESTR("Command2"));
		lstrcpyW(trData[4].m_szColumnName, OLESTR("Text2"));

		// Set up description columns
		lstrcpyW(trData[0].m_szDescription, OLESTR("Fixed"));
		lstrcpyW(trData[1].m_szDescription, OLESTR("Command"));
		lstrcpyW(trData[2].m_szDescription, OLESTR("Text"));
		lstrcpyW(trData[3].m_szDescription, OLESTR("Command2"));
		lstrcpyW(trData[4].m_szDescription, OLESTR("Text2"));

		// Set up column names
		for (long l=0; l<=4; l++)
			lstrcpyW(trData[l].m_szTableName, T2OLE(szFile));

		// Set up column 1
		trData[0].m_ulOrdinalPosition = 1;
		trData[0].m_bIsNullable = VARIANT_FALSE;
		trData[0].m_bColumnHasDefault = VARIANT_TRUE;
		trData[0].m_nDataType = DBTYPE_UI4;
		trData[0].m_nNumericPrecision = 10;
		trData[0].m_ulColumnFlags = DBCOLUMNFLAGS_WRITE | DBCOLUMNFLAGS_ISFIXEDLENGTH;
		lstrcpyW(trData[0].m_szColumnDefault, OLESTR("0"));
		m_rgRowData.Add(trData[0]);

		// Fill out common fields between columns
		for (l=1; l<=4; l++)
		{
			trData[l].m_ulOrdinalPosition = l+1;
			trData[l].m_bIsNullable = VARIANT_TRUE;
			trData[l].m_bColumnHasDefault = VARIANT_TRUE;
			trData[l].m_ulCharMaxLength = 16;
			trData[l].m_ulCharOctetLength = 16;
			trData[l].m_ulColumnFlags = DBCOLUMNFLAGS_WRITE | DBCOLUMNFLAGS_ISNULLABLE;
			trData[l].m_nDataType = DBTYPE_STR;
			lstrcpyW(trData[l].m_szColumnDefault, OLESTR("Default"));

			// Add to the row data									   
			m_rgRowData.Add(trData[l]);
		}

		*pcRowsAffected = 5;		// for the five columns
		return S_OK;

#ifdef _LATER
		DBID dbid;
		TCHAR szDir[MAX_PATH + 1];

		memset(&dbid, 0, sizeof(DBID));
		_tcscpy(&szDir[0], _T("c:\\public\\myData.txt")); // modify the path to point to your default data file
		dbid.uName.pwszName = T2OLE(szDir);
		dbid.eKind = DBKIND_NAME;
		return InitFromRowset < _RowsetArrayType > (m_rgRowData, &dbid, NULL, m_spUnkSite, pcRowsAffected);
#endif // _LATER
	}

	virtual DBSTATUS GetDBStatus(CSimpleRow* pRow, ATLCOLUMNINFO* pColInfo)
	{
		ATLASSERT(pColInfo != NULL);

		switch(pColInfo->iOrdinal)
		{
		case 3:		// TABLE_NAME
		case 4:		// COLUMN_NAME
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
			return DBSTATUS_S_OK;
			break;

		case 14:	// CHARACTER_MAXIMUM_LENGTH
		case 15:	// CHARACTER_OCTET_LENGTH
			// The first column is fixed so we return a NULL for the character &
			// octet lengths
			if (pRow->m_iRowset == 0)
				return DBSTATUS_S_ISNULL;
			else
				return DBSTATUS_S_OK;
			break;

		case 16:	// NUMERIC_PRECISION
			if (pRow->m_iRowset == 0)
				return DBSTATUS_S_OK;
			else
				return DBSTATUS_S_ISNULL;
			break;

		case 28:
			return DBSTATUS_S_OK;
			break;
		default:
			return DBSTATUS_S_ISNULL;
			break;
		}
	}
};
class CUpdateSessionPTSchemaRowset : 
	public CSchemaRowsetImpl< CUpdateSessionPTSchemaRowset, CPROVIDER_TYPERow, CUpdateSession>
{
public:
BEGIN_PROPSET_MAP(CUpdateSessionPTSchemaRowset)
	BEGIN_PROPERTY_SET(DBPROPSET_ROWSET)
		PROPERTY_INFO_ENTRY(IAccessor)
		PROPERTY_INFO_ENTRY(IColumnsInfo)
		PROPERTY_INFO_ENTRY(IConvertType)
		PROPERTY_INFO_ENTRY(IRowset)
		PROPERTY_INFO_ENTRY(IRowsetIdentity)
		PROPERTY_INFO_ENTRY(IRowsetInfo)
		PROPERTY_INFO_ENTRY(CANFETCHBACKWARDS)
		PROPERTY_INFO_ENTRY(CANHOLDROWS)
		PROPERTY_INFO_ENTRY(CANSCROLLBACKWARDS)
		PROPERTY_INFO_ENTRY_VALUE(MAXOPENROWS, 0)
		PROPERTY_INFO_ENTRY_VALUE(MAXROWS, 0)
	END_PROPERTY_SET(DBPROPSET_ROWSET)
END_PROPSET_MAP()

	HRESULT Execute(DBROWCOUNT* pcRowsAffected, ULONG, const VARIANT*)
	{
		USES_CONVERSION;
		CPROVIDER_TYPERow trData[2];

		memset(&trData, 0, sizeof(CPROVIDER_TYPERow) * 2);

		lstrcpyW(trData[0].m_szName, OLESTR("Long"));
		trData[0].m_nType = DBTYPE_UI4;
		trData[0].m_ulSize = 4;
		trData[0].m_bIsLong = VARIANT_FALSE;
		trData[0].m_bIsNullable = VARIANT_FALSE;
		trData[0].m_bCaseSensitive = VARIANT_FALSE;
		trData[0].m_ulSearchable = DB_UNSEARCHABLE;
		trData[0].m_bBestMatch = VARIANT_TRUE;	// required for SQL Server DTS
		m_rgRowData.Add(trData[0]);

		lstrcpyW(trData[1].m_szName, OLESTR("String"));
		trData[1].m_nType = DBTYPE_STR;
		trData[1].m_ulSize = 16;
		trData[1].m_bIsLong = VARIANT_FALSE;
		trData[1].m_bIsNullable = VARIANT_FALSE;
		trData[1].m_bCaseSensitive = VARIANT_FALSE;
		trData[1].m_ulSearchable = DB_UNSEARCHABLE;
		trData[1].m_bBestMatch = VARIANT_TRUE;	// required for SQL Server DTS
		m_rgRowData.Add(trData[1]);
		
		*pcRowsAffected = 2;
		return S_OK;
	}

	virtual DBSTATUS GetDBStatus(CSimpleRow* , ATLCOLUMNINFO* pColInfo)
	{
		ATLASSERT(pColInfo != NULL);

		switch(pColInfo->iOrdinal)
		{
		case 1:		// TYPE_NAME
		case 2:		// DATA_TYPE
		case 3:		// COLUMN_SIZE
		case 7:		// IS_NULLABLE
		case 8:		// CASE_SENSITIVE
		case 9:		// SEARCHABLE
		case 11:	// FIXED_PREC_SCALE
		case 19:	// IS_LONG
		case 20:	// BEST_MATCH
			return DBSTATUS_S_OK;
			break;
		default:
			return DBSTATUS_S_ISNULL;
			break;
		}
	}
};

#endif //__CUpdateSession_H_