@echo off
del /q GC.exe *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL

set _VB_EXE_FLAGS=/T:exe /debug+

echo compiling GC...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /out:GC.exe GC.vb >log.txt

