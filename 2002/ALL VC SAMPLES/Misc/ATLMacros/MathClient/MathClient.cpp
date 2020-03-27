// MathClient.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

#import "..\Bin\math.dll" no_namespace, raw_interfaces_only

int Quit()
{
	cout << "Press Enter to continue.";
	char c;
	cin >> c;

	return 0;
}

#ifdef _UNICODE
int wmain(int argc, wchar_t* argv[])
#else
int main(int argc, char* argv[])
#endif
{
	// Check arguments.
	if(argc != 4)
	{
		cout << "Wrong number of parameters." << endl;
		cout << "Use the following command line:" << endl;
		cout << "mathclient number1 + number2" << endl;
		cout << "to add two numbers or:" << endl;
		cout << "mathclient number1 - number2" << endl;
		cout << "to subtract two numbers." << endl;
		return Quit();
	}

	// Check operation, it should be + or -.
	if(*(argv[2]) != '+' && *(argv[2]) != '-')
	{
		cout << "Wrong operation, only + and - are supported." << endl;
		return Quit();
	}

	HRESULT hRes;
	long lResult;
    short sArg1 = atoi(argv[1]);
	short sArg2 = atoi(argv[3]);

	// Initializes the COM library.
	hRes = CoInitialize(NULL);

	if(FAILED(hRes))
	{
		cout << "Couldn't initialize COM library" << endl;
		return Quit();
	}

	// For + operation call Adder, for - call subtracter.
	if(*(argv[2]) == '+')
	{
		// Create Adder object.
		IAdderPtr pAdder(__uuidof(Adder));

		// Perform adding.
		hRes = pAdder->Add(sArg1, sArg2, &lResult);
	}
	else
	{
		// Create Subtracter object.
		ISubtracterPtr pSub(__uuidof(Subtracter));

		// Perform subtraction.
		hRes = pSub->Subtract(sArg1, sArg2, &lResult);
	}

	// If operation succeeded, print result, otherwise print error message.
	if(SUCCEEDED(hRes))
		cout << sArg1 <<" " << *(argv[2]) << " " <<  sArg2 << " = " << lResult << endl;
	else
		cout << "Error occurred." << endl;

	// Uninitialize the COM library.
	CoUninitialize();

	return Quit();
}
