// VCUE_Photonicity.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_PHOTONICITY_H___205A590F_9F06_4DCA_9D76_233A112AED05___INCLUDED_)
#define _VCUE_PHOTONICITY_H___205A590F_9F06_4DCA_9D76_233A112AED05___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include <atlisapi.h>
#include "VCUE_OLEDBClient.h"
#include "VCUE_ServerContext.h"
#include "VCUE_Time.h"

namespace VCUE
{
	namespace Photonicity
	{
		class CTableImage
		{
		public:
			CTableImage()
			{
				Clear();
			}

			void Clear()
			{
				m_ID = 0;
				m_Data.Clear();
				m_Bytes = 0;
				m_Width = 0;
				m_Height = 0;
				m_BitsPerPixel = 0;
				m_MimeType[0] = 0;
				ZeroMemory(&m_Created, sizeof(m_Created));
				ZeroMemory(&m_Modified, sizeof(m_Modified));
				m_Owner = 0;
			}

			LONG m_ID;
			CBLOBItem m_Data;
			LONG m_Bytes;
			LONG m_Width;
			LONG m_Height;
			LONG m_BitsPerPixel;
			char m_MimeType[51];
			DBTIMESTAMP m_Created;
			DBTIMESTAMP m_Modified;
			LONG m_Owner;
		};

		class CImageAdder : public CTableImage
		{
		public:
			LONG m_Format;

			CImageAdder()
			{
				m_Format = 0;
			}

			void Clear()
			{
				CTableImage::Clear();
				m_Format = 0;
			}

		BEGIN_PARAM_MAP(CImageAdder)
			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			VCUE_BLOB_COLUMN_ENTRY(1, m_Data)

			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			COLUMN_ENTRY(2, m_Bytes)

			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			COLUMN_ENTRY(3, m_Width)

			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			COLUMN_ENTRY(4, m_Height)

			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			COLUMN_ENTRY(5, m_BitsPerPixel)

			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			COLUMN_ENTRY(6, m_Format)

			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			COLUMN_ENTRY(7, m_Owner)

			SET_PARAM_TYPE(DBPARAMIO_OUTPUT)
			COLUMN_ENTRY(8, m_ID)
		END_PARAM_MAP()
		};

		class CImageGetter : public CTableImage
		{
		public:

		BEGIN_PARAM_MAP(CImageGetter)
			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			COLUMN_ENTRY(1, m_ID)
		END_PARAM_MAP()

		BEGIN_COLUMN_MAP(CImageGetter)
			COLUMN_ENTRY(1, m_ID)
			VCUE_BLOB_COLUMN_ENTRY(2, m_Data)
			COLUMN_ENTRY(3, m_Bytes)
			COLUMN_ENTRY(4, m_Width)
			COLUMN_ENTRY(5, m_Height)
			COLUMN_ENTRY(6, m_BitsPerPixel)
			COLUMN_ENTRY(7, m_MimeType)
			COLUMN_ENTRY(8, m_Created)
			COLUMN_ENTRY(9, m_Modified)
			COLUMN_ENTRY(10, m_Owner)
		END_COLUMN_MAP()
		};

		class CImageDeleter : public CTableImage
		{
		public:

		BEGIN_PARAM_MAP(CImageDeleter)
			SET_PARAM_TYPE(DBPARAMIO_INPUT)
			COLUMN_ENTRY(1, m_ID)
		END_PARAM_MAP()
		};


		// Call Execute. If it returns a success HRESULT, the image was
		// successfully added to the database.
		class CSprocInsertImage : public CCommand< CAccessor< CImageAdder >, CRowset, CMultipleResults >
		{
		public:
			HRESULT Execute(CSession& theSession,
						   ISequentialStream* pData,
						   LONG lBytes,
						   LONG lWidth,
						   LONG lHeight,
						   LONG lBitsPerPixel,
						   LONG lFormat,
						   LONG lOwner,
						   LONG& lID
						   )
			{
				// Set the data members
				m_Data.SetData(pData, lBytes);
				m_Bytes = lBytes;
				m_Width = lWidth;
				m_Height = lHeight;
				m_BitsPerPixel = lBitsPerPixel;
				m_Format = lFormat;
				m_Owner = lOwner;

				// Execute the stored procedure
				HRESULT hr = Open(theSession, "{ CALL sproc_InsertImage(?, ?, ?, ?, ?, ?, ?, ?) }");

				if (OleDbSucceeded(hr))
				{
					// Get to the end of the results in order to get the out param
					DBROWCOUNT pulRowsAffected = 0;
					while (GetNextResult(&pulRowsAffected) == S_OK);
					lID = m_ID;
				}

				return hr;
			}
		};

		// Call Execute. If it returns a success HRESULT,
		// the image was successfully deleted.
		class CSprocDeleteImage : public CCommand< CAccessor< CImageDeleter > >
		{
		public:
			HRESULT Execute(CSession& theSession, LONG lID)
			{
				m_ID = lID;
				HRESULT hr = Open(theSession, "{ CALL sproc_DeleteImage(?) }");
				return hr;
			}
		};

		// Call Execute.
		class CSprocGetImage : public CCommand< CAccessor< CImageGetter > >
		{
		public:

			// Description:
			//	Call this function to execute the stored procedure that will
			//	pull information about an image from the database.
			//
			// Parameters:
			//	theSession	The OLE DB session.
			//	lID			The ID of the requested image.
			//
			// Returns:
			//	S_OK						Success. Data members contain the info for the requested image.
			//	DB_S_ENDOFROWSET			The image is not in the database.
			//	Other OLE DB status code	Database, network, or some other failure or information.
			// 
			// Remarks:
			//	If this function returns a success HRESULT other than DB_S_ENDOFROWSET,
			//	the data members of this class will hold the information about the image matching
			//	that ID specified by lID.
			//
			// See:
			//	CSprocInsertImage | CSprocDeleteImage
			HRESULT Execute(CSession& theSession, LONG lID)
			{
				m_ID = lID;
				HRESULT hr = Open(theSession, "{ CALL sproc_GetImage(?) }");
				if (OleDbSucceeded(hr))
					hr = MoveFirst();
				return hr;
			}
		};

		// Description:
		//	Call this function to put an image and appropriate headers into the HTTP response.
		//
		// Parameters:
		//	theImage	The image to send.
		//	theResponse	The HTTP response object.
		//	bSendBody	Defaults to true. Set to false for HEAD requests.
		//
		// Returns:
		//	S_OK			The image was sent.
		//	S_FALSE			The client has recent content.
		//	E_UNEXPECTED	Unexpected failure.
		inline HRESULT SendImage(CTableImage& theImage, CHttpResponse& theResponse, bool bSendBody = true)
		{
			COleDateTime tModified(DbTimeStampToCOleDateTime(theImage.m_Modified));
			COleDateTimeSpan tsEqual;
			IHttpServerContext	*pServerContext = NULL;
			if( SUCCEEDED(theResponse.GetServerContext( &pServerContext)) )
			{
				bool	bClientHasRecentContent = false;
				bClientHasRecentContent = ClientHasRecentContent(pServerContext, tModified, tsEqual);
				
				pServerContext->Release();
				if( bClientHasRecentContent )
				{
					return S_FALSE;
				}
			}

			// TODO - set accept range bytes, etag, etc?
			theResponse.SetContentType(theImage.m_MimeType);
			theResponse.AppendHeader("Content-Length", ToCStringA(theImage.m_Bytes));
			theResponse.AppendHeader("Last-Modified", COleDateTimeToHttpDate(tModified));

			if (bSendBody)
			{
				ULONG ulBytesRead = 0;
				ULONG ulTotalBytesRead = 0;
				char szChunk[4096]; // TODO - allow configuration of chunk size?
				do
				{
					HRESULT hr = theImage.m_Data.Read(szChunk, sizeof(szChunk), &ulBytesRead);
					if (SUCCEEDED(hr))
					{
						if (ulBytesRead)
						{
							theResponse.WriteLen(szChunk, ulBytesRead);
							ulTotalBytesRead += ulBytesRead;
						}
					}
					else
					{
						return E_UNEXPECTED;
					}

				} while (sizeof(szChunk) == ulBytesRead);

				ATLASSERT(ulTotalBytesRead == static_cast<ULONG>(theImage.m_Bytes));
			}

			return S_OK;
		}

		// Description:
		//	Call this function to put an image and appropriate headers into the HTTP response.
		//
		// Parameters:
		//	theSession	The database session representing a connection to the database holding the image.
		//	lID			The ID of the image to send.
		//	theResponse	The HTTP response object.
		//	bSendBody	Defaults to true. Set to false for HEAD requests.
		//
		// Returns:
		//	S_OK			The image was sent.
		//	S_FALSE			The client has recent content.
		//	E_UNEXPECTED	Unexpected failure.
		//	DB_S_xxx or other OLE DB failure
		inline HRESULT SendImage(CSession& theSession, LONG lID, CHttpResponse& theResponse, bool bSendBody = true)
		{
			CSprocGetImage sprocGet;
			HRESULT hr = sprocGet.Execute(theSession, lID);
			if (S_OK == hr) // Can succeed with no records
			{
				hr = SendImage(sprocGet, theResponse, bSendBody);
			}
			return hr;
		}


	} // namespace Photonicity

} // namespace VCUE

#endif // !defined(_VCUE_PHOTONICITY_H___205A590F_9F06_4DCA_9D76_233A112AED05___INCLUDED_)
