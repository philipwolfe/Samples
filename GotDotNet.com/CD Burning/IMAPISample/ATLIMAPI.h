#pragma once

class CDiscRecorder
{
public:
	CDiscRecorder(void);
	virtual ~CDiscRecorder(void);

	HRESULT GetRecorderGUID( byte* pbyUniqueID, ULONG ulBufferSize, ULONG* pulReturnSizeRequired );
	HRESULT GetRecorderType( long* fTypeCode );
	HRESULT GetDisplayNames( BSTR* pbstrVendorID, BSTR* pbstrProductID, BSTR* pbstrRevision );
	HRESULT GetBasePnPID( BSTR* pbstrBasePnPID );
	HRESULT GetPath( BSTR* pbstrPath );
	HRESULT GetRecorderState( ULONG *pulDevStateFlags );
	HRESULT OpenExclusive();
	HRESULT CloseExclusive();
	HRESULT QueryMediaType( long* fMediaType, long* fMediaFlags );
	HRESULT QueryMediaInfo( byte* pbsessions, byte* pblasttrack, ULONG* ulstartaddress, ULONG* ulnextwritable, ULONG* ulfreeblocks );
	HRESULT Eject();
	HRESULT Erase( boolean bFullErase );
	void ReleaseRecorder();

	HRESULT RecorderProperties_GetFirst( STATPROPSTG* rgelt );
	HRESULT RecorderProperties_GetNext( STATPROPSTG* rgelt );
	HRESULT RecorderProperties_Read( PROPID propid, PROPVARIANT* pvar );
	HRESULT RecorderProperties_Write( PROPID propid, PROPVARIANT* pvar );

	bool m_fOpenExclusive;
	CComPtr<IDiscRecorder> m_spDiscRecorder;
	CComPtr<IPropertyStorage> m_spRecorderPropertyStorage;
	CComPtr<IEnumSTATPROPSTG> m_spRecorderPropertyEnum;
};

class CJolietDiscMaster
{
public:
	CJolietDiscMaster(void);
	virtual ~CJolietDiscMaster(void);

	HRESULT GetTotalDataBlocks( long* pnBlocks );
	HRESULT GetUsedDataBlocks( long* pnBlocks );
	HRESULT GetDataBlockSize( long* pnBlockBytes );
	HRESULT AddData( IStorage* pStorage, long lFileOverwrite );

	HRESULT JolietProperties_GetFirst( STATPROPSTG* rgelt );
	HRESULT JolietProperties_GetNext( STATPROPSTG* rgelt );
	HRESULT JolietProperties_Read( PROPID propid, PROPVARIANT* pvar );
	HRESULT JolietProperties_Write( PROPID propid, PROPVARIANT* pvar );

	CComPtr<IJolietDiscMaster> m_spJolietDiscMaster;
	CComPtr<IPropertyStorage> m_spJolietPropertyStorage;
	CComPtr<IEnumSTATPROPSTG> m_spJolietPropertyEnum;
};

class CRedbookDiscMaster
{
public:
	CRedbookDiscMaster(void);
	virtual ~CRedbookDiscMaster(void);

	HRESULT GetTotalAudioTracks( long* pnTracks );
	HRESULT GetTotalAudioBlocks( long* pnBlocks );
	HRESULT GetUsedAudioBlocks( long* pnBlocks );
	HRESULT GetAvailableAudioTrackBlocks( long* pnBlocks );
	HRESULT GetAudioBlockSize( long* pnBlockBytes );
	HRESULT CreateAudioTrack( long nBlocks );
	HRESULT AddAudioTrackBlocks( byte* pby, long cb );
	HRESULT CloseAudioTrack();

	CComPtr<IRedbookDiscMaster> m_spRedbookDiscMaster;
};

class CDiscMaster : 
	public CDiscRecorder, 
	public CJolietDiscMaster,
	public CRedbookDiscMaster
{
public:
	CDiscMaster(void);
	virtual ~CDiscMaster(void);

	HRESULT Open();
	void Close();

	HRESULT GetFirstDiscMasterFormat( LPIID lpiid );
	HRESULT GetNextDiscMasterFormat( LPIID lpiid );

	HRESULT GetActiveDiscMasterFormat( LPIID lpiid );
	HRESULT SetActiveDiscMasterFormat( REFIID riid );
	HRESULT SetActiveDiscMasterFormat( REFIID riid, void** ppUnk );

	HRESULT GetFirstDiscRecorder( CDiscRecorder& diskrecorder );
	HRESULT GetNextDiscRecorder( CDiscRecorder& diskrecorder );

	HRESULT GetActiveDiscRecorder( CDiscRecorder& diskrecorder );
	HRESULT SetActiveDiscRecorder( CDiscRecorder& diskrecorder );
	bool	IsDiscRecorderActive();

	HRESULT ClearFormatContent( );
	HRESULT RecordDisc( boolean bSimulate, boolean bEjectAfterBurn );

	HRESULT ProgressAdvise( IDiscMasterProgressEvents* pEvents, UINT_PTR* pnCookie );
	HRESULT ProgressUnadvise( UINT_PTR nCookie );

	CComPtr<IDiscMaster> m_spDiscMaster;
protected:
	CComPtr<IEnumDiscMasterFormats> m_spEnumDiscMasterFormats;
	CComPtr<IEnumDiscRecorders> m_spEnumDiscRecorders;
};


/////////////////////////////////////////////////////////////////////////////
// class IDiscMasterProgressEventsImpl
/////////////////////////////////////////////////////////////////////////////

class ATL_NO_VTABLE IDiscMasterProgressEventsImpl : public IDiscMasterProgressEvents
{
	long m_lRefCount;

public:
	IDiscMasterProgressEventsImpl(void)
	{
		m_lRefCount = 1;
	}

	STDMETHOD(QueryInterface)( REFIID riid, void** ppv )
	{
		if( riid == IID_IUnknown )
			*ppv = static_cast<IDiscMasterProgressEvents*>(this);
		else if( riid == IID_IDiscMasterProgressEvents )
			*ppv = static_cast<IDiscMasterProgressEvents*>(this);
		else
		{
			*ppv = NULL;
			return E_NOINTERFACE;
		}

		static_cast<IUnknown*>(*ppv)->AddRef();

		return S_OK;
	}

	STDMETHOD_(ULONG,AddRef)()
	{
		return InterlockedIncrement(&m_lRefCount);
	}

	STDMETHOD_(ULONG,Release)()
	{
		ULONG ul = InterlockedDecrement(&m_lRefCount);

		if( ul == 0 )
			delete this;

		return ul;
	}

	STDMETHOD(QueryCancel)( boolean* pbCancel )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyPnPActivity)()
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyAddProgress)( long nCompletedSteps, long nTotalSteps )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyBlockProgress)( long nCompleted, long nTotal )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyTrackProgress)( long nCurrentTrack, long nTotalTracks )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyPreparingBurn)( long nEstimatedSeconds )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyClosingDisc)( long nEstimatedSeconds )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyBurnComplete)( HRESULT status )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyEraseComplete)( HRESULT status )
	{
		return E_NOTIMPL;
	}
};

CString GetVariantValue( PROPVARIANT& val );
CString GetVariantType( VARTYPE vt );

/*
class IDiscMasterProgressEventsImpl :
	public CComObjectRootEx<CComSingleThreadModel>,
	public IDiscMasterProgressEvents
{
public:
	IDiscMasterProgressEventsImpl(void)
	{
	}

	virtual ~IDiscMasterProgressEventsImpl(void)
	{
	}

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	BEGIN_COM_MAP( IDiscMasterProgressEventsImpl )
		COM_INTERFACE_ENTRY( IDiscMasterProgressEvents )
	END_COM_MAP()

	HRESULT Init()
	{
		return S_OK;
	}

	STDMETHOD(QueryCancel)( boolean* pbCancel )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyPnPActivity)()
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyAddProgress)( long nCompletedSteps, long nTotalSteps )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyBlockProgress)( long nCompleted, long nTotal )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyTrackProgress)( long nCurrentTrack, long nTotalTracks )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyPreparingBurn)( long nEstimatedSeconds )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyClosingDisc)( long nEstimatedSeconds )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyBurnComplete)( HRESULT status )
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyEraseComplete)( HRESULT status )
	{
		return E_NOTIMPL;
	}
};
*/