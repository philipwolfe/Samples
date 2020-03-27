// PinvokeLib.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "PinvokeLib.h"
#include <objbase.h>
#include <stdio.h>

BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    switch (ul_reason_for_call)
	{
		case DLL_PROCESS_ATTACH:
		case DLL_THREAD_ATTACH:
		case DLL_THREAD_DETACH:
		case DLL_PROCESS_DETACH:
			break;
    }
    return TRUE;
}

extern "C" PINVOKELIB_API int GetRectangleArea(MYRECTANGLE* pStruct)
{
	MYPOINT topLeft = pStruct->myPoints[0];
	MYPOINT bottomRight = pStruct->myPoints[1];

	// calc and return area
	return (bottomRight.x - topLeft.x) * (bottomRight.y - topLeft.y);
}

extern "C" PINVOKELIB_API void GetRectangleAreaCallBack(FPTR pf, MYRECTANGLE* pStruct)
{
	MYPOINT topLeft = pStruct->myPoints[0];
	MYPOINT bottomRight = pStruct->myPoints[1];

	// Calc area
	int area = (bottomRight.x - topLeft.x) * (bottomRight.y - topLeft.y);

	// Invoke CallBack Method to return area
	(*pf)(area);
}
