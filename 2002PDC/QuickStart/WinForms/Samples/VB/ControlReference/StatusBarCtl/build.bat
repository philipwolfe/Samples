@echo off
del /q ComboBoxCtl.Exe *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL /R:System.Drawing.DLL /R:System.WinForms.DLL
REM /R:System.ComponentModel.DLL /R:System.Collections.DLL /R:System.Resources.DLL

set _VB_EXE_FLAGS=/T:exe /debug+

echo compiling StatusBarCtl.EXE...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /out:StatusBarCtl.exe StatusBarCtl.vb > log.txt


