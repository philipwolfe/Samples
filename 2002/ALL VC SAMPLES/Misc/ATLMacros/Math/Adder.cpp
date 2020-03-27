// Adder.cpp : Implementation of CAdder

#include "stdafx.h"
#include "Math.h"
#include "Adder.h"


// CAdder


//*******************************************************************
//	Add
//
//	PURPOSE:
//		Implements Add method of the IAdder interface.
//		Returns sum of first two arguments.
//
//	PARAMETERS:
//		sAddend1
//			[in] - first addend.
//		sAddend2
//			[in] - second addend.
//		plSum
//			[in] - pointer to the sum.
//
//	RETURN VALUE:
//		S_OK - if the function succeeds.
//		E_INVALIDARG - if NULL is passed as a plSum.
//********************************************************************
STDMETHODIMP CAdder::Add(short sAddend1, short sAddend2, long* plSum)
{
	// Check pointer.
	if(plSum == NULL)
		return E_INVALIDARG;

	// Do addition.
	*plSum = sAddend1 + sAddend2;

	return S_OK;
}
