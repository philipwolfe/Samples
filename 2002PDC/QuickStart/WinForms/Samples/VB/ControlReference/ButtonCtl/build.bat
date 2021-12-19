@echo off
del /q *.exe *.resources *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL /R:System.WinForms.DLL /R:System.Drawing.DLL /R:Microsoft.Win32.InterOp.DLL

set _SOURCERES=ButtonCtl.resX
set _TARGETRES=Microsoft.Samples.WinForms.vb.ButtonCtl.ButtonCtl.resources

set _VB_EXE_FLAGS=/T:exe /debug+

echo building resources...
ResXtoResources /compile %_SOURCERES% %_TARGETRES%

echo compiling ButtonCtl...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /res:%_TARGETRES% /out:ButtonCtl.exe ButtonCtl.vb


