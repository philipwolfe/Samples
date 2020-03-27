//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.
//
// netClient.cpp
//
// Implements our .net client

#include "stdafx.h"
typedef int BOOL;
const int TRUE = 1;
const int FALSE = 0;

#using <mscorlib.dll>
using namespace System;

#ifdef _DEBUG
#using "..\netQStat\debug\netQStat.dll"
#else
#using "..\netQStat\release\netQStat.dll"
#endif

// This is the entry point for this application
#ifdef _UNICODE
int wmain(void)
#else
int main(void)
#endif
{
	netMeanCalc* pnetMeanCalc = new netMeanCalc;
	pnetMeanCalc->Initialize(1000);

	for (int k = 1; k <= 10; k++) {
		pnetMeanCalc->AddDataPoint(k);
	}

	double nArithmeticMean = 0;
	double nGeometricMean = 0;
	double nHarmonicMean = 0;
	double nQuadraticMean = 0;
	
	BOOL ret;

	ret = pnetMeanCalc->ArithmeticMean(&nArithmeticMean);
	if (ret == TRUE) {
		Console::Write(S"The Arithmetic Mean is: ");
		Console::WriteLine(nArithmeticMean.ToString(S"n2"));
	} else {
		Console::WriteLine(S"Unable to calculate Arithmetic Mean");
	}
	
	ret = pnetMeanCalc->GeometricMean(&nGeometricMean);
	if (ret == TRUE) {
		Console::Write(S"The Geometric Mean is: ");
		Console::WriteLine(nGeometricMean.ToString(S"n2"));
	} else {
		Console::WriteLine(S"Unable to calculate Geometric Mean");
	}
	
	ret = pnetMeanCalc->HarmonicMean(&nHarmonicMean);
	if (ret == TRUE) {
		Console::Write(S"The Harmonic Mean is: ");
		Console::WriteLine(nHarmonicMean.ToString(S"n2"));
	} else {
		Console::WriteLine(S"Unable to calculate Harmonic Mean");
	}

	ret = pnetMeanCalc->QuadraticMean(&nQuadraticMean);
	if (ret == TRUE) {
		Console::Write(S"The Quadratic Mean is: ");
		Console::WriteLine(nQuadraticMean.ToString(S"n2"));
	} else {
		Console::WriteLine(S"Unable to calculate Quadratic Mean");
	}

	return 0;
}