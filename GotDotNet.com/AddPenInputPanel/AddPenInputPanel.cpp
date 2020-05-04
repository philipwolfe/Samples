#include "StdAfx.h"

//lint -i"C:\Program Files\Microsoft Tablet PC Platform SDK\Include"
#include "AddPenInputPanel.h"
#include <comdef.h>
#include <peninputpanel.h>
#include <peninputpanel_i.c>
#include <map>


_COM_SMARTPTR_TYPEDEF(IPenInputPanel, __uuidof(IPenInputPanel));

namespace
{
	typedef std::map<HWND, IPenInputPanel*> map_t;

	typedef std::map<_bstr_t, WNDPROC> procmap_t;

	static procmap_t PROC_MAP;

	static map_t WINDOW_MAP;

	static bool PANEL_ACTIVE = true;

	static const int CLASS_NAME_SIZE = 255;
}

// Forward declarations
static bool HasSpinButton(HWND hEdit);
static bool IsInCombo(HWND hEdit);
static bool IsReadOnly(HWND hEdit);

/// Create the input panel and attach it to the window
/// \author Michael S. Scherotter
/// \section Revision History
/// 3/28/2003 MichaelS: Added put_AutoShow()
static void OnCreate(HWND hWnd) throw ()
{
	try
	{
    
        IPenInputPanelPtr pPanel(CLSID_PenInputPanel);

		if (pPanel)
		{
			HRESULT hResult = pPanel->put_AttachedEditWindow(reinterpret_cast<LONG_PTR>(hWnd));

			if (SUCCEEDED(hResult))
			{
				pPanel->put_AutoShow(VARIANT_FALSE);

				WINDOW_MAP[hWnd] = pPanel.Detach();
			}
		}
	}
	catch(...)
	{
		TRACE(_T("Could not create pen input panel.\n"));
	}
}

/// Show the pen input panel
/// \author Michael S. Scherotter
/// \section Revision History
/// 3/28/2003 MichaelS: Moved put_AutoShow() to OnCreate(); Added ::IsInCombo() and ::IsReadOnly()
static void OnSetFocus(HWND hWnd)
{
	// If the control has a spin button, do not show the input panel
	if (::HasSpinButton(hWnd))
	{
		return;
	}

	// If the control is in a combo box, do not show the input panel
	if (::IsInCombo(hWnd))
	{
		return;
	}

	// If the control is read-only, do not show the input panel
	if (::IsReadOnly(hWnd))
	{
		return;
	}
    
	// If the panel is not active, do not show the input panel
    if (!PANEL_ACTIVE)
	{
		return;
	}

	// If the control ID is NO_INPUT_PANEL_ID, do not show the input panel
	if (::GetDlgCtrlID(hWnd) == NO_INPUT_PANEL_ID)
	{
		return;
	}

	IPenInputPanel* pPanel = ::GetPenInputPanel(hWnd);

	if (pPanel == NULL)
	{
		return;
	}

	pPanel->put_Visible(VARIANT_TRUE);

	pPanel->Refresh();
}

/// Release the pen input panel and remove the window from the map
/// \author Michael S. Scherotter
static void OnDestroy(HWND hWnd)
{
	IPenInputPanel* pPanel = ::GetPenInputPanel(hWnd);

	if (pPanel == NULL)
	{
		return;
	}

	pPanel->Release();

	WINDOW_MAP.erase(hWnd);
}


/// Get the previous window procedure for a specific class
/// \author Michael S. Scherotter
static WNDPROC GetWindowProc(HWND hWnd)
{
	TCHAR className[CLASS_NAME_SIZE];

	if (::GetClassName(hWnd, className, CLASS_NAME_SIZE) == 0)
	{
		TRACE(_T("Could not get the class name of window.\n"));

		return NULL;
	}

	procmap_t::iterator i = PROC_MAP.find(className);

	if (i == PROC_MAP.end())
	{
		TRACE(_T("Could not find the class name [%s]in the map.\n"), className);

		return NULL;
	}

	return i->second;

}

/// Create the input panel on WM_CREATE, activate it on WM_SETFOCUS, and 
/// release it on WM_DESTROY
/// \author Michael S. Scherotter
LRESULT FAR PASCAL SubClassFunc(HWND hWnd,UINT message,WPARAM wParam,
      LPARAM lParam)
{
	switch(message)
	{
	case WM_CREATE:
		::OnCreate(hWnd);
		break;

	case WM_SETFOCUS:
		::OnSetFocus(hWnd);
		break;

	case WM_DESTROY:
		::OnDestroy(hWnd);
		break;

	default:
		break;
	};

	WNDPROC pProc = ::GetWindowProc(hWnd);

	if (pProc == NULL)
	{
		return 0;
	}
		
	return ::CallWindowProc(pProc, hWnd, message, wParam, lParam);
}

/// \author Michael S. Scherotter
bool AddPenInputPanel(LPCTSTR pClassName)
{
	try
	{
		IPenInputPanelPtr pPanel(CLSID_PenInputPanel);
	}
	catch (...)
	{
		return false;
	}

	ASSERT(pClassName);

	// Create a temporary window of the class type
	HWND hEditWnd = ::CreateWindow(pClassName, _T("Test"),
                        WS_CHILD,
                        0, 0, 50, 50,
						CWnd::GetDesktopWindow()->GetSafeHwnd(),
                        NULL,
						::AfxGetInstanceHandle(),
                        NULL);

	if (hEditWnd == NULL)
	{
		TRACE(_T("Could not create a test window of class %s.\n"), pClassName);

		return false;
	}

	// Set the window class's procedure (this is for all windows created of class pClassName
	WNDPROC prevProc = reinterpret_cast<WNDPROC>(::SetClassLong(hEditWnd, GCL_WNDPROC, reinterpret_cast<LONG_PTR>(SubClassFunc)));

	PROC_MAP[pClassName] = prevProc;

	// Destroy the temporary window
	:: DestroyWindow(hEditWnd);

	return true;
}

/// \author Michael S. Scherotter
bool ActivatePenInputPanel(bool bActive)
{
	bool bLast = PANEL_ACTIVE;

	PANEL_ACTIVE = bActive;

	return bLast;
}

/// \author Michael S. Scherotter
IPenInputPanel* GetPenInputPanel(HWND hWnd)
{
	map_t::iterator i = WINDOW_MAP.find(hWnd);

	if (i == WINDOW_MAP.end())
	{
		return NULL;
	}

	return i->second;
}

/// Check if control is associated with spin button
/// \author Michael S. Scherotter
/// \return true if control has associated spin button, false otherwise
static bool HasSpinButton(HWND hEdit)
{
	HWND hParent = ::GetParent(hEdit);

	HWND hChild = NULL;

	do
	{
		hChild = ::FindWindowEx(hParent, hChild, _T("msctls_updown32"), NULL);

		if (hChild != NULL)
		{
			HWND hBuddy = reinterpret_cast<HWND>(::SendMessage(hChild, UDM_GETBUDDY, 0, 0));

			if (hBuddy == hEdit)
			{
				return true;
			}
		}
	} while (hChild != NULL);
	
	return false;
}

/// Check whether an edit control is read-only
/// \author Michael S. Scherotter
/// \return true if the edit control is read-only, false otherwise
static bool IsReadOnly(HWND hEdit)
{
	LONG lStyle = ::GetWindowLong(hEdit, GWL_STYLE);

	if (lStyle & ES_READONLY)
	{
		return true;
	}

	return false;
}

/// Check whether an edit control is in a combo box
/// \author Michael S. Scherotter
/// \return true if the edit control is in a combo box, false otherwise
static bool IsInCombo(HWND hEdit)
{
	HWND hParent = ::GetParent(hEdit);

	if (hParent == NULL)
	{
		return false;
	}

	TCHAR className[CLASS_NAME_SIZE];

	int nLength = ::GetClassName(hParent, className, CLASS_NAME_SIZE);

	if (nLength == 0)
	{
		return false;
	}

	if (::_tcsnicmp(className, _T("ComboBox"), nLength - 1) == 0)
	{
		return true;
	}

	return false;
}

