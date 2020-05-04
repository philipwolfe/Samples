#pragma once

interface IPenInputPanel;

/// Add Pen input to all instances of specific window class
/// possible classes are "Edit", "RichEdit20A", or "RichEdit20W"
/// \author Michael S. Scherotter
/// \retval true if successful
/// \retval false if unsuccessful
/// \note This would be typically called at the beginning of an application
/// before any instances of the controls are created.
/// \note Sample Usage:
/// \code
///	::AfxInitRichEdit2();
///
///	::AddPenInputPanel(_T("Edit"));
/// ::AddPenInputPanel(_T("RichEdit20A"));
///	::AddPenInputPanel(_T("RichEdit20W"));
/// \endcode
//lint -sem(AddPenInputPanel,1p)
bool AddPenInputPanel(LPCTSTR pClassName);

/// Globally activates or deactivates the pen input panel
/// \author Michael S. Scherotter
/// \return the last state of the input panel
bool ActivatePenInputPanel(bool bActive);

/// Get the input panel for a control, if any
/// \author Michael S. Scherotter
/// \note do not call Release() on the returned pointer
/// \return pointer to the input panel or NULL
//lint -sem(GetPenInputPanel,r_null)
IPenInputPanel* GetPenInputPanel(HWND hWnd);

/// Windows that should not have the input panel should have this control ID
#define NO_INPUT_PANEL_ID 10000
