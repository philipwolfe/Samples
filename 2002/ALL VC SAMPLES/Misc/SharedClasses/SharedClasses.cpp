// SharedClasses.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "SharedClasses.h"

#include <Windowsx.h>	// GET_X_LPARAM and GET_Y_LPARAM defined there.
#include <atltypes.h>	// CPoint, CRect, CSize support.
#include <atlstr.h>		// CString support.

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

CRect rectEllipse;			// Rectangle to track mouse movement.

CString strCoord;			// String to print ellipse coordinates and dimensions.

bool bLBtnPressed = false;	// Flag to keep left mouse button state.

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPSTR     lpCmdLine,
                     int       nCmdShow)
{
 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_SHAREDCLASSES, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow)) 
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, (LPCTSTR)IDC_SHAREDCLASSES);

	// Main message loop:
	while (GetMessage(&msg, NULL, 0, 0)) 
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg)) 
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX); 

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= (WNDPROC)WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, (LPCTSTR)IDI_SHAREDCLASSES);
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= (LPCTSTR)IDC_SHAREDCLASSES;
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, (LPCTSTR)IDI_SMALL);

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HANDLE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, unsigned, WORD, LONG)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

	switch (message) 
	{
	case WM_COMMAND:
		wmId    = LOWORD(wParam); 
		wmEvent = HIWORD(wParam); 
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, (LPCTSTR)IDD_ABOUTBOX, hWnd, (DLGPROC)About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...

		// Draw the ellipse using coordinates from mouse input.
		::Ellipse(	hdc, 
					rectEllipse.left - rectEllipse.Width(),
					rectEllipse.top - rectEllipse.Height(),
					rectEllipse.left + rectEllipse.Width(),
					rectEllipse.top + rectEllipse.Height());

		// If ellipse is not a dot or line, print center coordinates
		// and dimensions. Otherwise print prompt to draw ellipse.
		if(rectEllipse.Width() != 0 && rectEllipse.Height() != 0)
		{
			strCoord.Format(_T("Center coordinates %d,%d     X-size %d, Y-Size %d"),
							rectEllipse.left,
							rectEllipse.top,
							2 * rectEllipse.Width(),
							2 * rectEllipse.Height());
		}
		else
			strCoord = _T("Use your mouse to draw ellipse in the window");

		::TextOut(hdc, 5, 5 , strCoord, strCoord.GetLength());

		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_LBUTTONDOWN:
		// Save beginning point.
		rectEllipse.left = GET_X_LPARAM(lParam); 
		rectEllipse.top = GET_Y_LPARAM(lParam);

		// Set flag that keeps mouse button state.
		bLBtnPressed = true;

		// Capture mouse input.
		::SetCapture(hWnd);
		break;
	case WM_LBUTTONUP:
	
		// Reset flag that keeps mouse button state.
		bLBtnPressed = false;

		// Release mouse input.
		::ReleaseCapture();

		// Redraw window.
		::InvalidateRect(hWnd, NULL, TRUE);
		::UpdateWindow(hWnd);
		break;
	case WM_MOUSEMOVE:

		// If mouse button is pressed update rectangle that
		// tracks mouse movement with new coordinates,
		// and redraw window.
		if(bLBtnPressed)
		{
			rectEllipse.right = GET_X_LPARAM(lParam); 
			rectEllipse.bottom = GET_Y_LPARAM(lParam);

			::InvalidateRect(hWnd, NULL, TRUE);
			::UpdateWindow(hWnd);
		}
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
LRESULT CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_INITDIALOG:
		return TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL) 
		{
			EndDialog(hDlg, LOWORD(wParam));
			return TRUE;
		}
		break;
	}
	return FALSE;
}
