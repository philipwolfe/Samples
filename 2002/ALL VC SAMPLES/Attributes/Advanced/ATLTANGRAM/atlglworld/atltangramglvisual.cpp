// AtlTangramGLVisual.cpp : Implementation of CAtlTangramGLVisual
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#include "stdafx.h"
#include "AtlGLWorldiface.h"
#include "AtlTangramGLVisual.h"
#include <olectl.h>

// STL Interfaces
#include <new.h>
#include <algorithm>
#include <xmemory>
#include <list>
#include "..\util.cpp"
#include "CGL.h"
#include "cgl.cpp"
#include "cgl-pal.cpp"
#include <math.h>
///////////////////////////////////////////////////////////
//
// Destructor
//
CAtlTangramGLVisual::~CAtlTangramGLVisual()
{

	// We keep a strong reference to the model.
	// Therefore, we need to release it here.
	m_pModel->Release() ;
	m_pModel = NULL ;

	// We maintain a weak reference to GdiWorld to avoid
	// reference cycles. A weak reference means that we
	// do not AddRef or Release the pointer.
	//m_pGdiWorld->Release() ;
	//m_pGdiWorld = NULL ;


	// Delete the vertex array.
	if (m_ptVertices != NULL)
	{
		delete [] m_ptVertices ;
	}

}

///////////////////////////////////////////////////////////
//
//                      ITangramVisual
//
///////////////////////////////////////////////////////////
//
// ITangramVisual::SetSelected Implementation.
//
HRESULT CAtlTangramGLVisual::SetSelected(BOOL bSelected)
{
	m_bSelected = bSelected ;

	// Update the display.
	HRESULT hr = m_pWorld->Animate() ;
	ASSERT_HRESULT(hr) ;

	return S_OK ;
}

///////////////////////////////////////////////////////////
//
// ITangramGLVisual::GetModel Implementation
//
HRESULT CAtlTangramGLVisual::GetModel(const IID& iid, IUnknown** ppI)
{
	if (!IsValidInterfaceOutParam(ppI))
	{
		ASSERT(0) ;
		return E_POINTER ;
	}

	return m_pModel->QueryInterface(iid, (void**)ppI)  ;
}

///////////////////////////////////////////////////////////
//
//                      ITangramGLVisual
//
///////////////////////////////////////////////////////////
//
// ITangramGLVisual::Initialize Implementation
//
HRESULT
CAtlTangramGLVisual::Initialize(IATLTangramModel* pModel, IAtlTangramGLWorld* pWorld)
{
	if (!IsValidInterface(pModel)|| !IsValidInterface(pWorld))
	{
		ASSERT(0) ;
		return E_POINTER ;
	}

	if (m_pModel != NULL || m_pWorld != NULL)
	{
		// Cannot re-initialize.
		ASSERT(0) ;
		return E_FAIL ;
	}

	// Keep a strong reference to the model.
	m_pModel = pModel ;
	m_pModel->AddRef() ;

	// To avoid a cyclical reference count, we have a weak reference to GLWorld.
	// Therefore, we do not AddRef this pointer.
	m_pWorld = pWorld ;

	// Get the number of vertices in the model.
	HRESULT hr = m_pModel->GetNumberOfVertices(&m_cVertices) ;
	ASSERT_HRESULT(hr) ;

	// Create an array to hold the vertices.
	m_ptVertices = new TangramPoint2d[m_cVertices] ;

	//  ----- Set up event sync -----
	return  AdviseConnectionPoint(pModel);
}


///////////////////////////////////////////////////////////
//
// ITangramGLVisual::DrawOn Implementation
//
HRESULT CAtlTangramGLVisual::DrawOn(IAtlTangramCanvas* pCanvas)
{
	// Preconditions.
	if (!m_bFirstEvent)
	{
		// We have not received a model change event to initialize use.
		return S_FALSE ;
	}

	if (!IsValidInterface(pCanvas))
	{
		ASSERT(0) ;
		return E_POINTER ;
	}

	double thickness = 0.01 ;

	if (m_bSelected)
	{
		glPolygonMode(GL_FRONT_AND_BACK, GL_LINE) ;
	}

	// Bottom
	glNormal3d(0.0, 0.0, -1.0) ;
	glBegin(GL_TRIANGLE_FAN);
		for (int i = 0 ; i < m_cVertices ; i++)
		{
			glVertex2d(m_ptVertices[i].x, m_ptVertices[i].y) ;
		}
	glEnd() ;

	// Top
	glNormal3d(0.0, 0.0, 1.0) ;
	glBegin(GL_TRIANGLE_FAN);
		for (i = 0 ; i < m_cVertices ; i++)
		{
			glVertex3d(m_ptVertices[i].x, m_ptVertices[i].y, thickness) ;
		}
	glEnd() ;

	//Sides
	for ( i = 0 ; i < m_cVertices ; i++)
	{
		int iNextIndex = (i+1) % m_cVertices ;

		// Compute Normal [v1 - v2] X [v2 - v3] see page 58 of RedBook

		// V1 = v1 - v2
		double X1 = m_ptVertices[i].x - m_ptVertices[iNextIndex].x ;
		double Y1 = m_ptVertices[i].y - m_ptVertices[iNextIndex].y ;
		double Z1 = 0.0 ; // 0.0f - 0.0f ;

		// V2 = v2 - v3
		double X2 = 0.0 ; //m_ptVertices[iNextIndex].x - m_ptVertices[iNextIndex].x;
		double Y2 = 0.0 ; //m_ptVertices[iNextIndex].y - m_ptVertices[iNextIndex].y;
		double Z2 = -thickness ; // 0.0 - thickness ;

		// V = V1 X V2
		double X = Y1 * Z2; //Y1*Z2 - Z1*Y2  = Y1*Z2 - 0.0*0.0;
		double Y = -X1 * Z2 ; //Z1*X2 - X1*Z2 = 0.0*0.0 - X1*Z2
		//double Z = 0.0 ; //X1*Y2 - Y1*X2 ;

		// Normalize
		double d = sqrt(X*X + Y*Y /*+ Z*Z*/) ;
		ASSERT( d != 0.0) ;
		X /= d ;
		Y /= d ;
		//Z /= d ;

		glNormal3d(X, Y, 0.0/*Z*/) ;

		glBegin(GL_QUADS) ;
			glVertex3d(m_ptVertices[i].x, m_ptVertices[i].y, 0.0) ;
			glVertex3d(m_ptVertices[iNextIndex].x, m_ptVertices[iNextIndex].y, 0.0) ;
			glVertex3d(m_ptVertices[iNextIndex].x, m_ptVertices[iNextIndex].y, thickness) ;
			glVertex3d(m_ptVertices[i].x, m_ptVertices[i].y, thickness) ;
		glEnd();
	}

	if (m_bSelected)
	{
		glPolygonMode(GL_FRONT_AND_BACK, GL_FILL) ;
	}

	return S_OK ;
}

///////////////////////////////////////////////////////////
//
//                  ITangramModelEvent
//
///////////////////////////////////////////////////////////
//
// ITangramModelEvent::OnModelChange
//
HRESULT __stdcall CAtlTangramGLVisual::OnModelChange()
{
	// Create an array to hold the new vertices.
	TangramPoint2d* pointds = new TangramPoint2d[m_cVertices] ;

	// Get the vertices from the model.
	HRESULT hr = m_pModel->GetVertices(m_cVertices, pointds) ;
	ASSERT_HRESULT(hr) ;

	// Convert the vertices to our coordinates.
	for (int i = 0 ; i < m_cVertices ; i++)
	{
		hr = m_pWorld->ModelToDevice(pointds[i], &m_ptVertices[i]) ;
		ASSERT_HRESULT(hr) ;
	}

	// Cleanup ;
	delete [] pointds;

	// We are in sync.
	m_bFirstEvent = TRUE ;

	// Update the display.
	hr = m_pWorld->Animate() ;
	ASSERT_HRESULT(hr) ;

	return S_OK ;
}

HRESULT CAtlTangramGLVisual::ReleaseConnectionPoint()
{
	HRESULT hr = S_OK;
	if (m_pModel != NULL)
	{
		hr = __unhook(IATLTangramModelEvent,m_pModel);
		ASSERT_HRESULT(hr);
	}
	return hr;
}

HRESULT __stdcall CAtlTangramGLVisual::AdviseConnectionPoint(IATLTangramModel* pModel)
{
	return __hook(IATLTangramModelEvent,pModel);
}
