// Subtracter.cpp : Implementation of CSubtracter

#include "stdafx.h"
#include "Math.h"
#include "Subtracter.h"


// CSubtracter


//*******************************************************************
//	Subtract
//
//	PURPOSE:
//		Implements Subtract method of the ISubtracter interface.
//		Returns residual of first two arguments.
//
//	PARAMETERS:
//		lMinuend
//			[in] - first addend.
//		lSubtrahend
//			[in] - second addend.
//		plResidual
//			[in] - pointer to the residual.
//
//	RETURN VALUE:
//		S_OK - if the function succeeds.
//		E_INVALIDARG - if NULL is passed as a plResidual.
//********************************************************************
STDMETHODIMP CSubtracter::Subtract(long lMinuend, long lSubtrahend, long* plResidual)
{
	// Check pointer.
	if(plResidual == NULL)
		return E_INVALIDARG;

	// Do sabtraction.
	*plResidual = lMinuend - lSubtrahend;

	return S_OK;
}
