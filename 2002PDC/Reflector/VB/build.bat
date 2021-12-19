@echo off
del /q Reflector.exe Factorial.dll *.tlb *.reg *.obj *.pdb

set _IMPORTS=/R:System.DLL

set _VB_DLL_FLAGS=/T:library /debug+
set _VB_EXE_FLAGS=/T:exe /debug+

echo compiling factoral.dll ...
vbc %_VB_DLL_FLAGS% %_IMPORTS% /out:factorial.dll Factorial.vb 

echo.
echo compiling reflector.exe ...
vbc %_VB_EXE_FLAGS% %_IMPORTS% /out:Reflector.exe Reflector.vb 

