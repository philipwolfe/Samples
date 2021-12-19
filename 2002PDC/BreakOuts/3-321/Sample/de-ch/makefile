.SUFFIXES: .vbp .tlb .dll .asm .cpp
!IFNDEF CORSDK
CORSDK=..\..\..
!ENDIF

!IFNDEF WINSYSDIR
!IF EXIST($(WINDIR)\SYSTEM32\MSCOREE.DLL
WINSYSDIR=$(WINDIR)\SYSTEM32
!ELSE
WINSYSDIR=$(WINDIR)\SYSTEM
!ENDIF
!ENDIF

_VC=$(CORSDK)\compiler\VC
_VB=$(CORSDK)\compiler\VB
_COOL=$(CORSDK)\compiler\COOL
_BIN=$(CORSDK)\bin
_COOLC=csc.exe
_BC=$(_VB)\bc.exe
_CL=$(_VC)\cl.exe
_C1=$(_VC)\C1.dll
_CX=$(_VC)\c1xx.dll
_C2=$(_VC)\c2.dll
_ASSEM=$(_BIN)\assem.exe
_TLBIMP=$(_BIN)\tlbimp.exe
_COMREG=$(_BIN)\comreg.exe
_LM=$(_BIN)\lm.exe
_LINK=$(_VC)\link.exe
_LIBS=$(CORSDK)\lib\mscoree.lib

_CCFLAGS = /com+ /I$(_VC) /I$(WINSYSDIR)
_CFLAGS = $(_CCFLAGS) /c
_LFLAGS= -noentry
_LDFLAGS= -noentry -dll

_COOL_DLL_FLAGS= /dll 
_COOL_MOD_FLAGS= /t:module
_COOL_EXE_FLAGS= 

.cool.dll:
	$(_COOL_DLL_FLAGS) $*.cs

.cool.exe:
	$(_COOL_EXE_FLAGS) $*.cs

.cpp.dll:
	$(_CL) $(_CFLAGS) $*.cpp
	$(_LINK) $(_LDFLAGS) $(_LIBS) $*.obj

.cpp.exe:
	$(_CL) $(_CFLAGS) $*.cpp
	$(_LINK) $(_LFLAGS) $(_LIBS) $*.obj

.cpp.obj:	
	$(_CL) $(_CFLAGS) $*.cpp

.obj.exe:
	$(_LINK) $(_LFLAGS) $(_LIBS) $*.obj

.obj.dll:
	$(_LINK) $(_LDFLAGS) $(_LIBS) $*.obj

.vbp.dll:
	$(_BC) -i $*.vbp -o $*.dll

.tlb.dll:
	$(_TLBIMP) /Tlb $*.tlb /Fe $*.dll

.dll.reg:
	$(_COMREG) $*.dll

.asm.exe:
	$(_ASSEM) $*.asm

.asm.dll:
	$(_ASSEM) $*.asm /DLL

all: MakeRes BuildAsm

clean:
	@-del /Q *.dll *.tlb *.reg

clobber:	clean
	@-del /Q *.exe *.dll


MakeRes: 
        @-resgen MyStrings.de-ch.txt MyStrings.de-ch.resources

BuildAsm:
        @-al /out:Math.Resources.Dll /v:1.0.0.0 /c:de-ch /embed:MyStrings.de-ch.resources,MyStrings.de-ch.resources,Y






