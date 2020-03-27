
// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the PINVOKELIB_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// PINVOKELIB_API functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef PINVOKELIB_EXPORTS
#define PINVOKELIB_API __declspec(dllexport)
#else
#define PINVOKELIB_API __declspec(dllimport)
#endif

typedef struct _MYPOINT
{
	int x; 
	int y; 
} MYPOINT;
extern "C" PINVOKELIB_API int TestArrayOfStructs(MYPOINT* pPointArray, int size);

typedef struct _MYRECTANGLE
{
	MYPOINT myPoints[2]; // 0 = TopLeft, 1 = BottomRight
} MYRECTANGLE;
extern "C" PINVOKELIB_API int GetRectangleArea(MYRECTANGLE* pStruct);

typedef void (CALLBACK *FPTR)( int i );
extern "C" PINVOKELIB_API void GetRectangleAreaCallBack(FPTR pf, MYRECTANGLE* pStruct);

