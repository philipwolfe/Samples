========================================================================
IME Sample
========================================================================

The following sample illustrates how to set IME mode in controls. Specially this sample uses
edit control for this purpose. 

To use this sample with non-Unicode IME, select Win32 Release/Win32 Debug configuration. 
But if you want to use Unicode IME,  select Win32 ReleaseU/Win32 DebugU.

IMEEdit.cpp
-----------------
CIMEEdit is a sub class of CEdit. This file shows how to manage IME message and display string. 

1. The limitation of string buffer in sample code
	- 30 UNICODE chars

2. Display caret
	- How to calculate caret position with each East Asia IME
	- How to draw dotted underline with each East Asia IME
	- How to invert composition string with East Asia IME
	
3. Candidate/composition window
	- How to set the position of candidate/composition window

4. Composition string
	- How to get composition string from IME and display string

5. Surrogate char in UNICODE  
	- How to manage surrogate char 
	- Surrogate char will be display if you compile with _UNICODE option 


IMEModeDlg.cpp
------------------------
CIMDlg show hot wo set/get IME mode. It show next behaviors

1. Change the IME option by check box
	- Save the selected option.
	- If Japanese IME, get WM_IME_NOTIFY (IMN_SETCOMPOSITIONWINDOW) to check return of focus.  
	- Set options in IME
	- Get feedback from IME using WM_IME_NOTIFY (IMN_SETCONVERSIONMODE or IMN_SETSENTENCEMODE)
	- Display changed option.

2. Change the IME option by IME window 
	- Get feedback from IME using WM_IME_NOTIFY (IMN_SETCONVERSIONMODE or IMN_SETSENTENCEMODE)
	- Display changed option.

3. Change the input language by IME window 
	- Get WM_INPUTLANGCHANGE message
	- Create font and enable/disable check box
	- Get default setting of IME
	- Display default setting

4. Toggling in Japanese IME 
	- Get WM_ WM_IME_NOTIFY (IMN_SETOPENSTATUS) message
	- Check open status and display current setting.
