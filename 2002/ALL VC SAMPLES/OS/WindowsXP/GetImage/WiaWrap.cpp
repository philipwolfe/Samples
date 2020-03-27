/*++

Copyright (c) Microsoft Corporation. All rights reserved.

--*/


#include "stdafx.h"
#include "resource.h"

#include "DataCallback.h"
#include "ProgressDlg.h"
#include "WiaWrap.h"

//////////////////////////////////////////////////////////////////////////
//
// ReadPropertyLong
//

HRESULT 
ReadPropertyLong(
    IWiaPropertyStorage *pWiaPropertyStorage, 
    const CPropSpec     &PropSpec, 
    LONG                *plResult
)
{
    CPropVariant PropVariant;

    HRESULT hr = pWiaPropertyStorage->ReadMultiple(
        1, 
        &PropSpec, 
        &PropVariant
    );

    if (FAILED(hr))
    {
        return hr;
    }

    // Generally, the return value should be checked against S_FALSE.
    // If ReadMultiple returns S_FALSE, it means the property name or ID
    // had valid syntax, but it didn't exist in this property set, so
    // no properties were retrieved, and each PROPVARIANT structure is set 
    // to VT_EMPTY. But the following switch statement will handle this case
    // and return E_FAIL. So the caller of ReadPropertyLong does not need
    // to check for S_FALSE explicitly.

    switch (PropVariant.vt)
    {
        case VT_I1:
        {
            *plResult = (LONG) PropVariant.cVal;
            return S_OK;
        }

        case VT_UI1:
        {
            *plResult = (LONG) PropVariant.bVal;
            return S_OK;
        }

        case VT_I2:
        {
            *plResult = (LONG) PropVariant.iVal;
            return S_OK;
        }

        case VT_UI2:
        {
            *plResult = (LONG) PropVariant.uiVal;
            return S_OK;
        }

        case VT_I4:
        {
            *plResult = (LONG) PropVariant.lVal;
            return S_OK;
        }

        case VT_UI4:
        {
            *plResult = (LONG) PropVariant.ulVal;
            return S_OK;
        }

        case VT_INT:
        {
            *plResult = (LONG) PropVariant.intVal;
            return S_OK;
        }

        case VT_UINT:
        {
            *plResult = (LONG) PropVariant.uintVal;
            return S_OK;
        }

        case VT_R4:
        {
            *plResult = (LONG) (PropVariant.fltVal + 0.5);
            return S_OK;
        }

        case VT_R8:
        {
            *plResult = (LONG) (PropVariant.dblVal + 0.5);
            return S_OK;
        }

        default:
        {
            return E_FAIL;
        }
    }

    return S_OK;
}

//////////////////////////////////////////////////////////////////////////
//
// ReadPropertyGuid
//

HRESULT 
ReadPropertyGuid(
    IWiaPropertyStorage *pWiaPropertyStorage, 
    const CPropSpec     &PropSpec, 
    GUID                *pguidResult
)
{
    CPropVariant PropVariant;

    HRESULT hr = pWiaPropertyStorage->ReadMultiple(
        1, 
        &PropSpec, 
        &PropVariant
    );

    if (FAILED(hr))
    {
        return hr;
    }

    // Generally, the return value should be checked against S_FALSE.
    // If ReadMultiple returns S_FALSE, it means the property name or ID
    // had valid syntax, but it didn't exist in this property set, so
    // no properties were retrieved, and each PROPVARIANT structure is set 
    // to VT_EMPTY. But the following switch statement will handle this case
    // and return E_FAIL. So the caller of ReadPropertyGuid does not need
    // to check for S_FALSE explicitly.

    switch (PropVariant.vt)
    {
        case VT_CLSID:
        {
            *pguidResult = *PropVariant.puuid; 
            return S_OK;
        }

        case VT_BSTR:
        {
            return CLSIDFromString(PropVariant.bstrVal, pguidResult);
        }

        case VT_LPWSTR:
        {
            return CLSIDFromString(PropVariant.pwszVal, pguidResult);
        }

        case VT_LPSTR:
        {
            USES_CONVERSION;
            return CLSIDFromString(A2W(PropVariant.pszVal), pguidResult);
        }

        default:
        {
            return E_FAIL;
        }
    }
}

//////////////////////////////////////////////////////////////////////////
//
// WriteProperty
//

HRESULT 
WriteProperty(
    IWiaPropertyStorage *pWiaPropertyStorage, 
    const CPropSpec     &PropSpec, 
    const CPropVariant  &PropVariant,
    PROPID               propidNameFirst
)
{
    return pWiaPropertyStorage->WriteMultiple(
        1,
        &PropSpec,
        &PropVariant,
        propidNameFirst
    );
}

//////////////////////////////////////////////////////////////////////////
//
// WiaGetNumDevices
//

HRESULT 
WiaGetNumDevices(
    IWiaDevMgr *pSuppliedWiaDevMgr,
    ULONG      *pulNumDevices
)
{
    HRESULT hr;

    // Validate and initialize output parameters

    if (pulNumDevices == NULL)
    {
        return E_POINTER;
    }

    *pulNumDevices = 0;

    // Create a connection to the local WIA device manager

    CComPtr<IWiaDevMgr> pWiaDevMgr = pSuppliedWiaDevMgr;

    if (pWiaDevMgr == NULL)
    {
        hr = pWiaDevMgr.CoCreateInstance(CLSID_WiaDevMgr);

        if (FAILED(hr))
        {
            return hr;
        }
    }

    // Get a list of all the WIA devices on the system

    CComPtr<IEnumWIA_DEV_INFO> pIEnumWIA_DEV_INFO;

    hr = pWiaDevMgr->EnumDeviceInfo(
        0,
        &pIEnumWIA_DEV_INFO
    );

    if (FAILED(hr))
    {
        return hr;
    }

    // Get the number of WIA devices

    ULONG celt;

    hr = pIEnumWIA_DEV_INFO->GetCount(&celt);

    if (FAILED(hr))
    {
        return hr;
    }

    *pulNumDevices = celt;

    return S_OK;
}

//////////////////////////////////////////////////////////////////////////
//
// DefaultProgressCallback
//

HRESULT 
CALLBACK 
DefaultProgressCallback(
    LONG   lStatus,
    LONG   lPercentComplete,
    PVOID  pParam
)
{
    CProgressDlg *pProgressDlg = (CProgressDlg *) pParam;

    // If the user has pressed the cancel button, abort transfer

    if (pProgressDlg->Cancelled())
    {
        return S_FALSE;
    }

    // Form the message text

	UINT uID;

    switch (lStatus)
    {
        case IT_STATUS_TRANSFER_FROM_DEVICE:
		{
			uID = IDS_STATUS_TRANSFER_FROM_DEVICE;
            break;
		}

        case IT_STATUS_PROCESSING_DATA:
		{
            uID = IDS_STATUS_PROCESSING_DATA;
            break;
		}

        case IT_STATUS_TRANSFER_TO_CLIENT:
		{
            uID = IDS_STATUS_TRANSFER_TO_CLIENT;
            break;
		}

		default:
		{
			return E_INVALIDARG;
		}
    }		

    TCHAR szFormat[DEFAULT_STRING_SIZE] = _T("%d");

	LoadString(g_hInstance, uID, szFormat, COUNTOF(szFormat));

    TCHAR szStatusText[DEFAULT_STRING_SIZE];

	_sntprintf(szStatusText, COUNTOF(szStatusText), szFormat, lPercentComplete);

    // Update the progress bar values

    pProgressDlg->SetMessage(szStatusText);

    pProgressDlg->SetPercent(lPercentComplete);

    return S_OK;
}

//////////////////////////////////////////////////////////////////////////
//
// WiaGetImage
//

HRESULT 
WiaGetImage(
    HWND                 hWndParent,
    LONG                 lDeviceType,
    LONG                 lFlags,
    LONG                 lIntent,
    IWiaDevMgr          *pSuppliedWiaDevMgr,
    IWiaItem            *pSuppliedItemRoot,
    PFNPROGRESSCALLBACK  pfnProgressCallback,
    PVOID                pProgressCallbackParam,
    GUID                *pguidFormat,
    LONG                *plCount,
    IStream             ***pppStream
)
{
    HRESULT hr;

    // Validate and initialize output parameters

    if (plCount == NULL)
    {
        return E_POINTER;
    }

    if (pppStream == NULL)
    {
        return E_POINTER;
    }

    *plCount = 0;
    *pppStream = NULL;

    // Initialize the local root item variable with the supplied value.
    // If no value is supplied, display the device selection common dialog.

    CComPtr<IWiaItem> pItemRoot = pSuppliedItemRoot;

    if (pItemRoot == NULL)
    {
        // Initialize the device manager pointer with the supplied value
        // If no value is supplied, connect to the local device manager

        CComPtr<IWiaDevMgr> pWiaDevMgr = pSuppliedWiaDevMgr;

        if (pWiaDevMgr == NULL)
        {
            hr = pWiaDevMgr.CoCreateInstance(CLSID_WiaDevMgr);

            if (FAILED(hr))
            {
                return hr;
            }
        }
    
        // Display the device selection common dialog

        hr = pWiaDevMgr->SelectDeviceDlg(
            hWndParent,
            lDeviceType,
            lFlags,
            0,
            &pItemRoot
        );

        if (FAILED(hr) || hr == S_FALSE)
        {
            return hr;
        }
    }

    // Display the image selection common dialog 

    CComPtrArray<IWiaItem> ppIWiaItem;

    hr = pItemRoot->DeviceDlg(
        hWndParent,
        lFlags,
        lIntent,
        &ppIWiaItem.Count(),
        &ppIWiaItem
    );

    if (FAILED(hr) || hr == S_FALSE)
    {
        return hr;
    }

    // For ADF scanners, the common dialog explicitly sets the page count to one.
    // So in order the transfer multiple images, set the page count to ALL_PAGES
    // if the WIA_DEVICE_DIALOG_SINGLE_IMAGE flag is not specified, 

    if (!(lFlags & WIA_DEVICE_DIALOG_SINGLE_IMAGE))
    {
        // Get the property storage interface pointer for the root item

        CComQIPtr<IWiaPropertyStorage> pWiaRootPropertyStorage(pItemRoot);

        if (pWiaRootPropertyStorage == NULL)
        {
            return E_NOINTERFACE;
        }

        // Determine if the selected device is a scanner or not

        LONG nDevType;

        hr = ReadPropertyLong(
            pWiaRootPropertyStorage, 
            WIA_DIP_DEV_TYPE, 
            &nDevType
        );

        if (SUCCEEDED(hr) && (GET_STIDEVICE_TYPE(nDevType) == StiDeviceTypeScanner))
        {
            // Determine if the document feeder is selected or not

            LONG nDocumentHandlingSelect;

            hr = ReadPropertyLong(
                pWiaRootPropertyStorage, 
                WIA_DPS_DOCUMENT_HANDLING_SELECT, 
                &nDocumentHandlingSelect
            );

            if (SUCCEEDED(hr) && (nDocumentHandlingSelect & FEEDER))
            {
                WriteProperty(
                    pWiaRootPropertyStorage,
                    WIA_DPS_PAGES,
                    ALL_PAGES,
                    WIA_DPS_FIRST
                );
            }
        }
    }

    // If a status callback function is not supplied, use the default.
    // The default displays a simple dialog with a progress bar and cancel button.

    CComPtr<CProgressDlg> pProgressDlg;

    if (pfnProgressCallback == NULL)
    {
        pfnProgressCallback = DefaultProgressCallback;

        pProgressDlg = new CProgressDlg(hWndParent);

        pProgressCallbackParam = (CProgressDlg *) pProgressDlg;
    }

    // Create the data callback interface

    CComPtr<CDataCallback> pDataCallback = new CDataCallback(
        pfnProgressCallback,
        pProgressCallbackParam,
        plCount, 
        pppStream
    );

    if (pDataCallback == NULL)
    {
        return E_OUTOFMEMORY;
    }

    // Start the transfer of the selected items

    for (int i = 0; i < ppIWiaItem.Count(); ++i)
    {
        // Get the interface pointers

        CComQIPtr<IWiaPropertyStorage> pWiaPropertyStorage(ppIWiaItem[i]);

        if (pWiaPropertyStorage == NULL)
        {
            return E_NOINTERFACE;
        }

        CComQIPtr<IWiaDataTransfer> pIWiaDataTransfer(ppIWiaItem[i]);

        if (pIWiaDataTransfer == NULL)
        {
            return E_NOINTERFACE;
        }

        // Set the transfer type

        hr = WriteProperty(
            pWiaPropertyStorage,
            WIA_IPA_TYMED,
            TYMED_CALLBACK,
            WIA_IPA_FIRST
        );

        if (FAILED(hr))
        {
            return hr;
        }

        // If there is no transfer format specified, use the device default

        GUID guidFormat = GUID_NULL;

        if (pguidFormat == NULL)
        {
            pguidFormat = &guidFormat;
        }

        if (*pguidFormat == GUID_NULL)
        {
            hr = ReadPropertyGuid(
                pWiaPropertyStorage,
                WIA_IPA_PREFERRED_FORMAT,
                pguidFormat
            );

            if (FAILED(hr))
            {
                return hr;
            }
        }

        // Set the transfer format

        hr = WriteProperty(
            pWiaPropertyStorage,
            WIA_IPA_FORMAT,
            *pguidFormat,
            WIA_IPA_FIRST
        );

        if (FAILED(hr))
        {
            return hr;
        }

        // Read the transfer buffer size from the device, default to 64K

        LONG nBufferSize;

        hr = ReadPropertyLong(
            pWiaPropertyStorage, 
            WIA_IPA_BUFFER_SIZE, 
            &nBufferSize
        );

        if (FAILED(hr))
        {
            nBufferSize = 64 * 1024;
        }

        // Choose double buffered transfer for better performance

        WIA_DATA_TRANSFER_INFO WiaDataTransferInfo = { 0 };

        WiaDataTransferInfo.ulSize        = sizeof(WIA_DATA_TRANSFER_INFO);
        WiaDataTransferInfo.ulBufferSize  = 2 * nBufferSize;
        WiaDataTransferInfo.bDoubleBuffer = TRUE;

        // Start the transfer

        hr = pIWiaDataTransfer->idtGetBandedData(
            &WiaDataTransferInfo,
            pDataCallback
        );

        if (FAILED(hr) || hr == S_FALSE)
        {
            return hr;
        }
    }

    return S_OK;
}

