// File: atlmodeliface.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once


[
  object,
  uuid(5E471EE3-C9DF-4A75-BDD5-2B3734F89A7C),
  helpstring("ITangramModelEvent Interface"),
  pointer_default(unique)
]
__interface IATLTangramModelEvent: IUnknown
{
	HRESULT OnModelChange() ;
};

///////////////////////////////////////////////////////////
//
// Interface IATLTangramTransform
// {D5056310-B0F4-11d0-B69F-00A0C903487A}
[ object,
  uuid(35C6036F-DE8E-466B-8DA2-93410D01C685),
  helpstring("IATLTangramTransform Interface"),
  pointer_default(unique)
]
__interface IATLTangramTransform : IUnknown
{
	HRESULT Translate([in]double x, [in]double y) ;
	HRESULT GetTranslation([out] TangramPoint2d* point);
	HRESULT Rotate([in] double fDegrees) ;
	HRESULT GetRotation([out] double* pRotation) ;
};

///////////////////////////////////////////////////////////
//
// Interface IATLTangramModel
// {060BAAA2-B076-11D0-B69F-00A0C903487A}
[ object,
  uuid(C674D0EB-C541-4BE5-A250-17D920E293D1),
  helpstring("IATLTangramModel Interface"),
  pointer_default(unique)
]
__interface IATLTangramModel : IUnknown
{
	HRESULT GetNumberOfVertices([out] long* pcVertices) ;
 	HRESULT GetVertices(	[in] long cVertices, 
							[out, size_is(cVertices)] TangramPoint2d *points); 
	HRESULT SetVertices(	[in] long cVertices, 
							[in, size_is(cVertices)] TangramPoint2d* points) ;
};
