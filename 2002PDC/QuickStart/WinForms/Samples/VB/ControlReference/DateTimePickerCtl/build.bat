@echo off
del /q *.exe *.resources *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL /R:System.WinForms.DLL /R:System.Drawing.DLL /R:Microsoft.Win32.InterOp.DLL

set _VB_EXE_FLAGS=/debug+

echo compiling DateTimePickerCtl...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /out:DateTimePickerCtl.exe DateTimePickerCtl.vb ChangeColorDlg.vb 
