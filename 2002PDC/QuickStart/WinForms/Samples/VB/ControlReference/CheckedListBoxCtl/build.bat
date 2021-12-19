@echo off
del /q *.exe *.resources *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL /R:System.WinForms.DLL /R:System.Drawing.DLL /R:Microsoft.Win32.InterOp.DLL

set _SOURCERES=CheckedListBox.resX
set _TARGETRES=Microsoft.Samples.WinForms.vb.CheckedListBox.CheckedListBox.resources

set _VB_EXE_FLAGS=/T:exe /debug+

echo compiling CheckedListBox...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /out:CheckedListBoxCtl.exe CheckedListBoxCtl.vb


