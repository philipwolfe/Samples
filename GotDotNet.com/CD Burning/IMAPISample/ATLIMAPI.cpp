#include "StdAfx.h"
#include "atlimapi.h"

/////////////////////////////////////////////////////////////////////////////
// class CDiscMaster
/////////////////////////////////////////////////////////////////////////////

CDiscMaster::CDiscMaster(void)
{
}

CDiscMaster::~CDiscMaster(void)
{
}

HRESULT CDiscMaster::Open()
{
	HRESULT hr = m_spDiscMaster.CoCreateInstance( __uuidof(MSDiscMasterObj) );
	if( SUCCEEDED( hr ) )
	{
		hr = m_spDiscMaster->Open();
		if( SUCCEEDED( hr ) )
		{
			IID iid;
			hr = GetActiveDiscMasterFormat( &iid );
			if( SUCCEEDED( hr ) )
			{
				hr = SetActiveDiscMasterFormat( iid );
				if( SUCCEEDED( hr ) )
				{
					HRESULT hrtemp = m_spDiscMaster->GetActiveDiscRecorder( &m_spDiscRecorder );
					ATLASSERT( SUCCEEDED(hrtemp) || hrtemp == IMAPI_E_NOACTIVERECORDER );
				}
			}
		}
	}
	return hr;
}

void CDiscMaster::Close()
{
	ATLASSERT( m_spDiscMaster != NULL );
	if( m_spDiscRecorder != NULL )
	{
	}
	if( m_spEnumDiscMasterFormats != NULL )
	{
		m_spEnumDiscMasterFormats.Release();
	}
	m_spDiscMaster->Close();
	m_spDiscMaster.Release();
}


HRESULT CDiscMaster::GetFirstDiscMasterFormat( LPIID lpiid )
{
	ATLASSERT( lpiid != NULL );
	ATLASSERT( m_spDiscMaster != NULL );
	HRESULT hr;
	if( m_spEnumDiscMasterFormats == NULL )
	{
		hr = m_spDiscMaster->EnumDiscMasterFormats( &m_spEnumDiscMasterFormats );
		if( FAILED( hr ) )
			return hr;
	}
	else
	{
		m_spEnumDiscMasterFormats->Reset();
	}

	ULONG cFetched;
	hr = m_spEnumDiscMasterFormats->Next( 1, lpiid, &cFetched );
	return hr;
}

HRESULT CDiscMaster::GetNextDiscMasterFormat( LPIID lpiid )
{
	ATLASSERT( lpiid != NULL );
	ATLASSERT( m_spDiscMaster != NULL );
	ATLASSERT( m_spEnumDiscMasterFormats != NULL );
	HRESULT hr;
	ULONG cFetched;
	hr = m_spEnumDiscMasterFormats->Next( 1, lpiid, &cFetched );
	return hr;
}

HRESULT CDiscMaster::GetActiveDiscMasterFormat( LPIID lpiid )
{
	ATLASSERT( lpiid != NULL );
	ATLASSERT( m_spDiscMaster != NULL );
	HRESULT hr = m_spDiscMaster->GetActiveDiscMasterFormat( lpiid );
	return hr;
}

HRESULT CDiscMaster::SetActiveDiscMasterFormat( REFIID riid )
{
	ATLASSERT( m_spDiscMaster != NULL );
	HRESULT hr = E_FAIL;
	if( riid == IID_IJolietDiscMaster )
	{
		if( m_spJolietDiscMaster != NULL )
			m_spJolietDiscMaster.Release();
		hr = m_spDiscMaster->SetActiveDiscMasterFormat( riid, (void**)&m_spJolietDiscMaster );
	}
	else if( riid == IID_IRedbookDiscMaster )
	{
		if( m_spRedbookDiscMaster != NULL )
			m_spRedbookDiscMaster.Release();
		hr = m_spDiscMaster->SetActiveDiscMasterFormat( riid, (void**)&m_spRedbookDiscMaster );
	}
	else
		ASSERT(FALSE); // invalid/unsupported disc master format specified!

	return hr;
}

HRESULT CDiscMaster::SetActiveDiscMasterFormat( REFIID riid, void** ppUnk )
{
	ATLASSERT( m_spDiscMaster != NULL );
	HRESULT hr = m_spDiscMaster->SetActiveDiscMasterFormat( riid, ppUnk );
	return hr;
}

HRESULT CDiscMaster::GetFirstDiscRecorder( CDiscRecorder& diskrecorder )
{
	ATLASSERT( m_spDiscMaster != NULL );
	HRESULT hr;
	if( m_spEnumDiscRecorders == NULL )
	{
		hr = m_spDiscMaster->EnumDiscRecorders( &m_spEnumDiscRecorders );
		if( FAILED( hr ) )
			return hr;
	}
	else
	{
		m_spEnumDiscRecorders->Reset();
	}

	diskrecorder.m_spDiscRecorder.Release();
	ULONG cFetched;
	hr = m_spEnumDiscRecorders->Next( 1, &(diskrecorder.m_spDiscRecorder), &cFetched );
	return hr;
}

HRESULT CDiscMaster::GetNextDiscRecorder( CDiscRecorder& diskrecorder )
{
	ATLASSERT( m_spDiscMaster != NULL );
	ATLASSERT( m_spEnumDiscRecorders != NULL );
	HRESULT hr;
	diskrecorder.m_spDiscRecorder.Release();
	ULONG cFetched;
	hr = m_spEnumDiscRecorders->Next( 1, &(diskrecorder.m_spDiscRecorder), &cFetched );
	return hr;
}

HRESULT CDiscMaster::GetActiveDiscRecorder( CDiscRecorder& diskrecorder )
{
	ATLASSERT( m_spDiscMaster != NULL );
	diskrecorder.m_spDiscRecorder.Release();
	HRESULT hr = m_spDiscMaster->GetActiveDiscRecorder( &(diskrecorder.m_spDiscRecorder) );
	return hr;
}

bool CDiscMaster::IsDiscRecorderActive()
{
	if( m_spDiscRecorder != NULL )
		return true;
	else
		return false;
}

HRESULT CDiscMaster::SetActiveDiscRecorder( CDiscRecorder& diskrecorder )
{
	ATLASSERT( m_spDiscMaster != NULL );
	ATLASSERT( diskrecorder.m_spDiscRecorder != NULL );
	ReleaseRecorder();
	m_spDiscRecorder = diskrecorder.m_spDiscRecorder;
	HRESULT hr = m_spDiscMaster->SetActiveDiscRecorder( m_spDiscRecorder );
	return hr;
}

HRESULT CDiscMaster::ClearFormatContent( )
{
	ATLASSERT( m_spDiscMaster != NULL );
	HRESULT hr = m_spDiscMaster->ClearFormatContent();
	return hr;
}

HRESULT CDiscMaster::ProgressAdvise( IDiscMasterProgressEvents* pEvents, UINT_PTR* pnCookie )
{
	ATLASSERT( m_spDiscMaster != NULL );
	return E_FAIL;
}

HRESULT CDiscMaster::ProgressUnadvise( UINT_PTR nCookie )
{
	ATLASSERT( m_spDiscMaster != NULL );
	return E_FAIL;
}

HRESULT CDiscMaster::RecordDisc( boolean bSimulate, boolean bEjectAfterBurn )
{
	ATLASSERT( m_spDiscMaster != NULL );
	HRESULT hr = m_spDiscMaster->RecordDisc( bSimulate, bEjectAfterBurn );
	return hr;
}

/////////////////////////////////////////////////////////////////////////////
// class CDiscRecorder
/////////////////////////////////////////////////////////////////////////////

CDiscRecorder::CDiscRecorder(void)
{
	m_fOpenExclusive = false;
}

CDiscRecorder::~CDiscRecorder(void)
{
	ReleaseRecorder();
}

void CDiscRecorder::ReleaseRecorder()
{
	if( m_spRecorderPropertyStorage != NULL )
		m_spRecorderPropertyStorage.Release();

	if( m_spRecorderPropertyEnum != NULL )
		m_spRecorderPropertyEnum.Release();

	if( m_spDiscRecorder != NULL )
	{
		if( m_fOpenExclusive )
		{
			HRESULT hr = m_spDiscRecorder->Close();
			ATLASSERT( SUCCEEDED( hr ) );
		}

		m_spDiscRecorder.Release();
	}
}

HRESULT CDiscRecorder::GetRecorderGUID( byte* pbyUniqueID, ULONG ulBufferSize, ULONG* pulReturnSizeRequired )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->GetRecorderGUID( pbyUniqueID, ulBufferSize, pulReturnSizeRequired );
}

HRESULT CDiscRecorder::GetRecorderType( long* fTypeCode )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->GetRecorderType( fTypeCode );
}

HRESULT CDiscRecorder::GetDisplayNames( BSTR* pbstrVendorID, BSTR* pbstrProductID, BSTR* pbstrRevision )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->GetDisplayNames( pbstrVendorID, pbstrProductID, pbstrRevision );
}

HRESULT CDiscRecorder::GetBasePnPID( BSTR* pbstrBasePnPID )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->GetBasePnPID( pbstrBasePnPID );
}

HRESULT CDiscRecorder::GetPath( BSTR* pbstrPath )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->GetPath( pbstrPath );
}

HRESULT CDiscRecorder::RecorderProperties_GetFirst( STATPROPSTG* rgelt )
{
	HRESULT hr;
	ATLASSERT( m_spDiscRecorder != NULL );
	if( m_spRecorderPropertyStorage == NULL )
	{
		hr = m_spDiscRecorder->GetRecorderProperties( &m_spRecorderPropertyStorage );
		if( FAILED( hr ) )
			return hr;
	}
	if( m_spRecorderPropertyEnum == NULL )
	{
		hr = m_spRecorderPropertyStorage->Enum( &m_spRecorderPropertyEnum );
		if( FAILED( hr ) )
			return hr;
	}
	else
		hr = m_spRecorderPropertyEnum->Reset();

	ULONG celtFetched;
	hr = m_spRecorderPropertyEnum->Next( 1, rgelt, &celtFetched );
	return hr;
}

HRESULT CDiscRecorder::RecorderProperties_GetNext( STATPROPSTG* rgelt )
{
	HRESULT hr;
	ATLASSERT( m_spDiscRecorder != NULL );
	ATLASSERT( m_spRecorderPropertyStorage != NULL );
	ATLASSERT( m_spRecorderPropertyEnum != NULL );

	ULONG celtFetched;
	hr = m_spRecorderPropertyEnum->Next( 1, rgelt, &celtFetched );
	return hr;
}

HRESULT CDiscRecorder::RecorderProperties_Read( PROPID propid, PROPVARIANT* pvar )
{
	HRESULT hr;
	ATLASSERT( m_spDiscRecorder != NULL );
	ATLASSERT( pvar != NULL );

	if( m_spRecorderPropertyStorage == NULL )
	{
		hr = m_spDiscRecorder->GetRecorderProperties( &m_spRecorderPropertyStorage );
		if( FAILED( hr ) )
			return hr;
	}

	PROPSPEC spec;
	spec.ulKind = PRSPEC_PROPID;
	spec.propid = propid;
	hr = m_spRecorderPropertyStorage->ReadMultiple( 1, &spec, pvar );
	return hr;
}

HRESULT CDiscRecorder::RecorderProperties_Write( PROPID propid, PROPVARIANT* pvar )
{
	HRESULT hr;
	ATLASSERT( m_spDiscRecorder != NULL );
	ATLASSERT( pvar != NULL );

	if( m_spRecorderPropertyStorage == NULL )
	{
		hr = m_spDiscRecorder->GetRecorderProperties( &m_spRecorderPropertyStorage );
		if( FAILED( hr ) )
			return hr;
	}

	PROPSPEC spec;
	spec.ulKind = PRSPEC_PROPID;
	spec.propid = propid;
	hr = m_spRecorderPropertyStorage->WriteMultiple( 1, &spec, pvar, 2 );
	return hr;
}

HRESULT CDiscRecorder::GetRecorderState( ULONG *pulDevStateFlags )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->GetRecorderState( pulDevStateFlags );
}

HRESULT CDiscRecorder::OpenExclusive()
{
	ATLASSERT( m_spDiscRecorder != NULL );
	ATLASSERT( !m_fOpenExclusive );
	HRESULT hr = m_spDiscRecorder->OpenExclusive();
	if( SUCCEEDED( hr ) )
		m_fOpenExclusive = true;
	
	return hr;
}

HRESULT CDiscRecorder::CloseExclusive()
{
	ATLASSERT( m_spDiscRecorder != NULL );
	ATLASSERT( m_fOpenExclusive );
	HRESULT hr = m_spDiscRecorder->Close();
	if( SUCCEEDED( hr ) )
		m_fOpenExclusive = false;

	return hr;
}

HRESULT CDiscRecorder::QueryMediaType( long* fMediaType, long* fMediaFlags )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->QueryMediaType( fMediaType, fMediaFlags );
}

HRESULT CDiscRecorder::QueryMediaInfo( byte* pbsessions, byte* pblasttrack, ULONG* ulstartaddress, ULONG* ulnextwritable, ULONG* ulfreeblocks )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->QueryMediaInfo( pbsessions, pblasttrack, ulstartaddress, ulnextwritable, ulfreeblocks );
}

HRESULT CDiscRecorder::Eject()
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->Eject();
}

HRESULT CDiscRecorder::Erase( boolean bFullErase )
{
	ATLASSERT( m_spDiscRecorder != NULL );
	return m_spDiscRecorder->Erase( bFullErase );
}

/////////////////////////////////////////////////////////////////////////////
// class CJolietDiscMaster
/////////////////////////////////////////////////////////////////////////////

CJolietDiscMaster::CJolietDiscMaster(void)
{
}

CJolietDiscMaster::~CJolietDiscMaster(void)
{
}

HRESULT CJolietDiscMaster::GetTotalDataBlocks( long* pnBlocks )
{
	ATLASSERT( m_spJolietDiscMaster != NULL );
	return m_spJolietDiscMaster->GetTotalDataBlocks( pnBlocks );
}

HRESULT CJolietDiscMaster::GetUsedDataBlocks( long* pnBlocks )
{
	ATLASSERT( m_spJolietDiscMaster != NULL );
	return m_spJolietDiscMaster->GetUsedDataBlocks( pnBlocks );
}

HRESULT CJolietDiscMaster::GetDataBlockSize( long* pnBlockBytes )
{
	ATLASSERT( m_spJolietDiscMaster != NULL );
	return m_spJolietDiscMaster->GetDataBlockSize( pnBlockBytes );
}

HRESULT CJolietDiscMaster::AddData( IStorage* pStorage, long lFileOverwrite )
{
	ATLASSERT( m_spJolietDiscMaster != NULL );
	HRESULT hr = m_spJolietDiscMaster->AddData( pStorage, lFileOverwrite );
	return hr;
}

HRESULT CJolietDiscMaster::JolietProperties_GetFirst( STATPROPSTG* rgelt )
{
	HRESULT hr;
	ATLASSERT( m_spJolietDiscMaster != NULL );
	if( m_spJolietPropertyStorage == NULL )
	{
		hr = m_spJolietDiscMaster->GetJolietProperties( &m_spJolietPropertyStorage );
		if( FAILED( hr ) )
			return hr;
	}
	if( m_spJolietPropertyEnum == NULL )
	{
		hr = m_spJolietPropertyStorage->Enum( &m_spJolietPropertyEnum );
		if( FAILED( hr ) )
			return hr;
	}
	else
		hr = m_spJolietPropertyEnum->Reset();

	ULONG celtFetched;
	hr = m_spJolietPropertyEnum->Next( 1, rgelt, &celtFetched );
	return hr;
}

HRESULT CJolietDiscMaster::JolietProperties_GetNext( STATPROPSTG* rgelt )
{
	HRESULT hr;
	ATLASSERT( m_spJolietDiscMaster != NULL );
	ATLASSERT( m_spJolietPropertyStorage != NULL );
	ATLASSERT( m_spJolietPropertyEnum != NULL );

	ULONG celtFetched;
	hr = m_spJolietPropertyEnum->Next( 1, rgelt, &celtFetched );
	return hr;
}

HRESULT CJolietDiscMaster::JolietProperties_Read( PROPID propid, PROPVARIANT* pvar )
{
	HRESULT hr;
	ATLASSERT( m_spJolietDiscMaster != NULL );
	ATLASSERT( pvar != NULL );

	if( m_spJolietPropertyStorage == NULL )
	{
		hr = m_spJolietDiscMaster->GetJolietProperties( &m_spJolietPropertyStorage );
		if( FAILED( hr ) )
			return hr;
	}

	PROPSPEC spec;
	spec.ulKind = PRSPEC_PROPID;
	spec.propid = propid;
	hr = m_spJolietPropertyStorage->ReadMultiple( 1, &spec, pvar );
	return hr;
}

HRESULT CJolietDiscMaster::JolietProperties_Write( PROPID propid, PROPVARIANT* pvar )
{
	HRESULT hr;
	ATLASSERT( m_spJolietDiscMaster != NULL );
	ATLASSERT( pvar != NULL );

	if( m_spJolietPropertyStorage == NULL )
	{
		hr = m_spJolietDiscMaster->GetJolietProperties( &m_spJolietPropertyStorage );
		if( FAILED( hr ) )
			return hr;
	}

	PROPSPEC spec;
	spec.ulKind = PRSPEC_PROPID;
	spec.propid = propid;
	hr = m_spJolietPropertyStorage->WriteMultiple( 1, &spec, pvar, 2 );
	return hr;
}

/////////////////////////////////////////////////////////////////////////////
// class CRedbookDiscMaster
/////////////////////////////////////////////////////////////////////////////

CRedbookDiscMaster::CRedbookDiscMaster(void)
{
}

CRedbookDiscMaster::~CRedbookDiscMaster(void)
{
}

HRESULT CRedbookDiscMaster::GetTotalAudioTracks( long* pnTracks )
{
	ATLASSERT( pnTracks != NULL );
	ATLASSERT( m_spRedbookDiscMaster != NULL );
	return m_spRedbookDiscMaster->GetTotalAudioTracks( pnTracks );
}

HRESULT CRedbookDiscMaster::GetTotalAudioBlocks( long* pnBlocks )
{
	ATLASSERT( pnBlocks != NULL );
	ATLASSERT( m_spRedbookDiscMaster != NULL );
	return m_spRedbookDiscMaster->GetTotalAudioBlocks( pnBlocks );
}

HRESULT CRedbookDiscMaster::GetUsedAudioBlocks( long* pnBlocks )
{
	ATLASSERT( pnBlocks != NULL );
	ATLASSERT( m_spRedbookDiscMaster != NULL );
	return m_spRedbookDiscMaster->GetUsedAudioBlocks( pnBlocks );
}

HRESULT CRedbookDiscMaster::GetAvailableAudioTrackBlocks( long* pnBlocks )
{
	ATLASSERT( pnBlocks != NULL );
	ATLASSERT( m_spRedbookDiscMaster != NULL );
	return m_spRedbookDiscMaster->GetAvailableAudioTrackBlocks( pnBlocks );
}

HRESULT CRedbookDiscMaster::GetAudioBlockSize( long* pnBlockBytes )
{
	ATLASSERT( pnBlockBytes != NULL );
	ATLASSERT( m_spRedbookDiscMaster != NULL );
	return m_spRedbookDiscMaster->GetAudioBlockSize( pnBlockBytes );
}

HRESULT CRedbookDiscMaster::CreateAudioTrack( long nBlocks )
{
	ATLASSERT( m_spRedbookDiscMaster != NULL );
	return m_spRedbookDiscMaster->CreateAudioTrack( nBlocks );
}

HRESULT CRedbookDiscMaster::AddAudioTrackBlocks( byte* pby, long cb )
{
	ATLASSERT( pby != NULL );
	ATLASSERT( m_spRedbookDiscMaster != NULL );
	return m_spRedbookDiscMaster->AddAudioTrackBlocks( pby, cb );
}

HRESULT CRedbookDiscMaster::CloseAudioTrack()
{
	ATLASSERT( m_spRedbookDiscMaster != NULL );
	return m_spRedbookDiscMaster->CloseAudioTrack();
}

CString GetVariantType( VARTYPE vt )
{
	CString csType;
	switch( vt )
	{
	case VT_EMPTY:
		csType = L"VT_EMPTY";
		break;
	case VT_NULL:
		csType = L"VT_NULL";
		break;
	case VT_I2:
		csType = L"VT_I2";
		break;
	case VT_I4:
		csType = L"VT_I4";
		break;
	case VT_R4:
		csType = L"VT_R4";
		break;
	case VT_R8:
		csType = L"VT_R8";
		break;
	case VT_CY:
		csType = L"VT_CY";
		break;
	case VT_DATE:
		csType = L"VT_DATE";
		break;
	case VT_BSTR:
		csType = L"VT_BSTR";
		break;
	case VT_DISPATCH:
		csType = L"VT_DISPATCH";
		break;
	case VT_ERROR:
		csType = L"VT_ERROR";
		break;
	case VT_BOOL:
		csType = L"VT_BOOL";
		break;
	case VT_VARIANT:
		csType = L"VT_VARIANT";
		break;
	case VT_DECIMAL:
		csType = L"VT_DECIMAL";
		break;
	case VT_RECORD:
		csType = L"VT_RECORD";
		break;
	case VT_UNKNOWN:
		csType = L"VT_UNKNOWN";
		break;
	case VT_I1:
		csType = L"VT_I1";
		break;
	case VT_UI1:
		csType = L"VT_UI1";
		break;
	case VT_UI2:
		csType = L"VT_UI2";
		break;
	case VT_UI4:
		csType = L"VT_UI4";
		break;
	case VT_INT:
		csType = L"VT_INT";
		break;
	case VT_UINT:
		csType = L"VT_UINT";
		break;
	case VT_VOID:
		csType = L"VT_VOID";
		break;
	case VT_HRESULT:
		csType = L"VT_HRESULT";
		break;
	case VT_PTR:
		csType = L"VT_PTR";
		break;
	case VT_SAFEARRAY:
		csType = L"VT_SAFEARRAY";
		break;
	case VT_CARRAY:
		csType = L"VT_CARRAY";
		break;
	case VT_USERDEFINED:
		csType = L"VT_USERDEFINED";
		break;
	case VT_LPSTR:
		csType = L"VT_LPSTR";
		break;
	case VT_LPWSTR:
		csType = L"VT_LPWSTR";
		break;
	case VT_FILETIME:
		csType = L"VT_FILETIME";
		break;
	case VT_BLOB:
		csType = L"VT_BLOB";
		break;
	case VT_STREAM:
		csType = L"VT_STREAM";
		break;
	case VT_STORAGE:
		csType = L"VT_STORAGE";
		break;
	case VT_STREAMED_OBJECT:
		csType = L"VT_STREAMED_OBJECT";
		break;
	case VT_STORED_OBJECT:
		csType = L"VT_STORED_OBJECT";
		break;
	case VT_BLOB_OBJECT:
		csType = L"VT_BLOB_OBJECT";
		break;
	case VT_CF:
		csType = L"VT_CF";
		break;
	case VT_CLSID:
		csType = L"VT_CLSID";
		break;
	case VT_VECTOR:
		csType = L"VT_VECTOR";
		break;
	case VT_ARRAY:
		csType = L"VT_ARRAY";
		break;
	case VT_BYREF:
		csType = L"VT_BYREF";
		break;
	case VT_RESERVED:
		csType = L"VT_RESERVED";
		break;
	default:
		csType.Format( L"Unknown (%d)", vt );
	}
	return csType;
}

CString GetVariantValue( PROPVARIANT& val )
{
	CString csValue;
	switch( val.vt )
	{
	case VT_EMPTY:
		csValue = "";
		break;
	case VT_NULL:
		csValue = "";
		break;
	case VT_I2:
		csValue.Format( L"%d", val.iVal );
		break;
	case VT_I4:
		csValue.Format( L"%d", val.lVal );
		break;
	case VT_R4:
		csValue.Format( L"%f", val.fltVal );
		break;
	case VT_R8:
		csValue.Format( L"%f", val.dblVal );
		break;
	case VT_CY:
		csValue = L"VT_CY";
		break;
	case VT_DATE:
		csValue = L"VT_DATE";
		break;
	case VT_BSTR:
		csValue.Format( L"%s", val.bstrVal );
		break;
	case VT_DISPATCH:
		csValue = L"VT_DISPATCH";
		break;
	case VT_ERROR:
		csValue = L"VT_ERROR";
		break;
	case VT_BOOL:
		csValue = val.boolVal ? L"true" : L"false";
		break;
	case VT_VARIANT:
		csValue = L"VT_VARIANT";
		break;
	case VT_DECIMAL:
		csValue = L"VT_DECIMAL";
		break;
	case VT_RECORD:
		csValue = L"VT_RECORD";
		break;
	case VT_UNKNOWN:
		csValue = L"VT_UNKNOWN";
		break;
	case VT_I1:
		csValue.Format( L"%d", val.cVal );
		break;
	case VT_UI1:
		csValue.Format( L"%d", val.bVal );
		break;
	case VT_UI2:
		csValue.Format( L"%d", val.uiVal );
		break;
	case VT_UI4:
		csValue.Format( L"%d", val.ulVal );
		break;
	case VT_INT:
		csValue.Format( L"%d", val.intVal );
		break;
	case VT_UINT:
		csValue.Format( L"%d", val.uintVal );
		break;
	case VT_VOID:
		csValue = L"VT_VOID";
		break;
	case VT_HRESULT:
		csValue = L"VT_HRESULT";
		break;
	case VT_PTR:
		csValue = L"VT_PTR";
		break;
	case VT_SAFEARRAY:
		csValue = L"VT_SAFEARRAY";
		break;
	case VT_CARRAY:
		csValue = L"VT_CARRAY";
		break;
	case VT_USERDEFINED:
		csValue = L"VT_USERDEFINED";
		break;
	case VT_LPSTR:
		csValue.Format( L"%S", val.pszVal );
		break;
	case VT_LPWSTR:
		csValue.Format( L"%s", val.pwszVal );
		break;
	case VT_FILETIME:
		csValue = L"VT_FILETIME";
		break;
	case VT_BLOB:
		csValue = L"VT_BLOB";
		break;
	case VT_STREAM:
		csValue.Format( L"0x%08x", val.pStream );
		break;
	case VT_STORAGE:
		csValue.Format( L"0x%08x", val.pStorage );
		break;
	case VT_STREAMED_OBJECT:
		csValue = L"VT_STREAMED_OBJECT";
		break;
	case VT_STORED_OBJECT:
		csValue = L"VT_STORED_OBJECT";
		break;
	case VT_BLOB_OBJECT:
		csValue = L"VT_BLOB_OBJECT";
		break;
	case VT_CF:
		csValue = L"VT_CF";
		break;
	case VT_CLSID:
		csValue = L"VT_CLSID";
		break;
	case VT_VECTOR:
		csValue = L"VT_VECTOR";
		break;
	case VT_ARRAY:
		csValue = L"VT_ARRAY";
		break;
	case VT_BYREF:
		csValue = L"VT_BYREF";
		break;
	case VT_RESERVED:
		csValue = L"VT_RESERVED";
		break;
	default:
		csValue.Format( L"Unknown (%d)", val.vt );
	}
	return csValue;
}

