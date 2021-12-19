@echo off
del /q WinTalk.exe *.resources *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL /R:System.WinForms.DLL /R:System.Drawing.DLL /R:Microsoft.Win32.InterOp.DLL /R:System.Net.DLL

set _VB_EXE_FLAGS=/T:exe /debug+

echo compiling vb...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /out:WinTalk.exe ConnectDialog.vb DataEdit.vb SendEdit.vb WinTalk.vb 

