@echo off
del /q *.exe *.resources *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL /R:System.WinForms.DLL /R:System.Drawing.DLL /R:Microsoft.Win32.InterOp.DLL /R:QuartzTypeLib.dll

set _VB_EXE_FLAGS=/T:exe /debug+

echo compiling ButtonCtl...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /out:VideoPlayer.exe VideoPlayer.vb


