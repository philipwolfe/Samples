@echo off
del /q ComboBoxCtl.Exe *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL /R:System.Drawing.DLL /R:System.WinForms.DLL
REM /R:System.ComponentModel.DLL /R:System.Collections.DLL /R:System.Resources.DLL

set _VB_EXE_FLAGS=/T:exe /debug+

echo compiling HelloVB...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /out:ComboBoxCtl.exe ComboBoxCtl.vb > log.txt

