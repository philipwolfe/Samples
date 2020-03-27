// File: atlglworldiface.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

[ object,
  uuid(3B6E16C2-D21E-4217-B811-D49CFFA56450),
  helpstring("IAtlTangramGLWorld Interface"),
  pointer_default(unique)
]
__interface IAtlTangramGLWorld : IAtlTangramWorld
{
   HRESULT ModelToDevice([in] TangramPoint2d pptIn, [out] TangramPoint2d* pptOut) ;
};


[ object,
  uuid(27AAB2B0-29A9-403D-A224-F32AD3686602),
  helpstring("IAtlTangramGLVisual Interface"),
  pointer_default(unique)
]
__interface IAtlTangramGLVisual : IAtlTangramVisual
{
	HRESULT Initialize([in] IATLTangramModel* pModel, [in] IAtlTangramGLWorld* pWorld) ;	
	HRESULT DrawOn([in] IAtlTangramCanvas* pCanvas) ;    	
	[helpstring("method ReleaseConnectionPoint")] HRESULT ReleaseConnectionPoint();
};

