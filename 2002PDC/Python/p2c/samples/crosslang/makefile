!IF EXIST ($(WINDIR)\SYSTEM32\MSCOREE.DLL)
SYSTEM=$(WINDIR)\SYSTEM32
!ELSE
SYSTEM=$(WINDIR)\SYSTEM
!ENDIF

_ALINK=al.exe
_BC=vbc.exe
_CL=cl.exe

_PYC=..\..\cpy.py
_PYCFLAGS=/debug
_PYCFLAGS_DLL=/dll /out:$*.dll
_PYCFLAGS_EXE=/out:$*.exe

COMREG=regasm.exe
TLBEXP=tlbexp.exe
SN=sn.exe

all:	PowerGenerator.dll MakeTable_py.exe

TableGen.dll CalendarGenerator.dll MultiGen.dll:
	@echo *** Before running this sample, you must perform the following:
	@echo 1) Locate and build the standard NGWS "CrossLang" sample.
	@echo 2) Copy *.dll and *.mod from that directory into this directory.
	@echo 3) Re-run this make process.
	fail

PowerGenerator.dll: PowerGenerator.py PowerGenerator.key TableGen.dll
	$(_PYC) $(_PYCFLAGS) $(_PYCFLAGS_DLL) /no-python-runtime /ref:../../Python.dll /ref:TableGen.dll /assembly-keyfile:PowerGenerator.key $*.py
	$(COMREG) PowerGenerator.dll
	$(TLBEXP) PowerGenerator.dll
	al -i:PowerGenerator.dll

# For the key file, we avoid remaking
PowerGenerator.key:
	if not exist PowerGenerator.key $(SN) -k PowerGenerator.key

MakeTable_py.exe: MakeTable.py PowerGenerator.dll TableGen.dll CalendarGenerator.dll MultiGen.dll
	$(_PYC) $(_PYCFLAGS) $(_PYCFLAGS_EXE) /ref:CalendarGenerator.dll /ref:MultiGen.dll /ref:PowerGenerator.dll /out:MakeTable_py.exe MakeTable.py

clean:
    -erase *.pdb *.exe *.dll *.reg *.tlb *.mod *.InstallLog *.InstallState
