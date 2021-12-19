#needed so we can say foo.dll: foo.cpp and it will just work
.SUFFIXES: .tlb  .il .dll .cpp .cs .vb .rc .ocx

#Define ProgramFiles if not defined
!IFNDEF ProgramFiles
ProgramFiles=$(WINDIR)\..\Program Files
!ENDIF


#define debug flags if DEBUG=1 is true, default is true
DEBUG=1
!IF $(DEBUG) == 1
_C_DBG_FLAGS=/Zi
_L_DBG_FLAGS=/debug
_CS_DBG_FLAGS=/debug+
_VB_DBG_FLAGS=/debug+
!ENDIF

#define the names of the compilers we ship
_BC=vbc.exe
_CL=cl.exe
_C1=C1.dll
_CX=c1xx.dll
_C2=c2.dll
_CS=csc.exe
_ASSEM=ilasm.exe

#define the names of some common tools
_TLBIMP=tlbimp.exe
_TLBEXP=tlbexp.exe
_REGASM=regasm.exe
_REGSVR=regsvr32.exe
_RSC=rc.exe
_AL=al.exe
_SN=sn.exe

#define our basic link line for managed code
_LINK=link.exe

#define our basic core lib
_LIBS=kernel32.lib mscoree.lib

#this is used for compiling C# samples
#reset this in individual sample makefile to your imports if required
_IMPORTS=

#this is used for compiling C# samples, that use Resources
#reset this in individual sample makefile to your resource imports if required
_WIN32RES=

#This is used for compiling C# samples that use Assembly and key files
#reset this in individual sample makefile to your resource imports if required
_KEYFILE=

#this is used for compiling C# samples
#set the default out directory to .
_OUTDIR=.

#set some command C++ flags
_CCFLAGS=/CLR 
_CFLAGS=$(_CCFLAGS) $(_C_DBG_FLAGS) /c

#set some command link flags
_LFLAGS=$(_L_DBG_FLAGS) /nod:libcpmt.lib
_LDFLAGS=-dll $(_L_DBG_FLAGS) /nod:libcpmt.lib

#set some common C# flags, default is debug
_CS_DLL_FLAGS=/t:library $(_CS_DBG_FLAGS)
_CS_MOD_FLAGS=/t:module $(_CS_DBG_FLAGS)
_CS_EXE_FLAGS=$(_CS_DBG_FLAGS)

#set some common vb flags
_VB_OPTION_FLAGS=/optionstrict-
_VB_DLL_FLAGS=/t:library $(_VB_DBG_FLAGS) $(_VB_OPTION_FLAGS)
_VB_EXE_FLAGS=/t:exe $(_VB_DBG_FLAGS) $(_VB_OPTION_FLAGS)


#default compile and link for c++ files building a dll
#note: name.cpp and name.dll must match
.cpp.dll:
	$(_CL) $(_CFLAGS) $*.cpp
	$(_LINK) $(_LDFLAGS) $(_LIBS) /out:$(_OUTDIR)\$@ $*.obj

#default compile and link for c++ files building a exe
#note: name.cpp and name.dll must match
.cpp.exe:
	$(_CL) $(_CFLAGS) $*.cpp
	$(_LINK) $(_LFLAGS) $(_LIBS) /out:$(_OUTDIR)\$@ $*.obj

#default compile and link for c++ files building an obj
#note: name.cpp and name.obj must match
.cpp.obj:	
	$(_CL) $(_CFLAGS) $*.cpp

#default compile and link for c++ files building an exe
#note: name.obj and name.exe must match
#
#referencing makefiles depend on the .obj files and not the .cpp files
.obj.exe:
        if not "."=="$(_OUTDIR)" if not exist $(_OUTDIR) md $(_OUTDIR)
	$(_LINK) $(_LFLAGS) $(_LIBS) /out:$(_OUTDIR)\$@ $**

#default compile and link for c++ files building a dll
#note: name.obj and name.dll must match
#
#referencing makefiles depend on the .obj files and not the .cpp files
.obj.dll:
        if not "."=="$(_OUTDIR)" if not exist $(_OUTDIR) md $(_OUTDIR)
	$(_LINK) $(_LDFLAGS) $(_LIBS) /out:$(_OUTDIR)\$@ $**

#default compiling vb files
#note: name.vb and name.dll must match
.vb.dll:
        if not "."=="$(_OUTDIR)" if not exist $(_OUTDIR) md $(_OUTDIR)
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**

.vb.exe:
        if not "."=="$(_OUTDIR)" if not exist $(_OUTDIR) md $(_OUTDIR)
	$(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS)  /out:$(_OUTDIR)\$@ $**

#default compiling C# files
#note: name.cs and name.dll must match
#note: we will create the output dir if it does not exist
.cs.dll:
        if not "."=="$(_OUTDIR)" if not exist $(_OUTDIR) md $(_OUTDIR)
	$(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $** $(_WIN32RES) $(_KEYFILE)


#default compiling C# files
#note: name.cs and name.exe must match
.cs.exe:
        if not "."=="$(_OUTDIR)" if not exist $(_OUTDIR) md $(_OUTDIR)
	$(_CS) $(_CS_EXE_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $** $(_WIN32RES) $(_KEYFILE)	


#default importing tlb files
#note: name.tlb and name.dll must match
.tlb.dll:
	$(_TLBIMP) $*.tlb

#default registering dlls
#note: name.tlb and name.reg must match
.dll.reg:
	$(_REGASM) $*.dll /tlb:$*.tlb
	$(_AL) -i:$*.dll

#default for registering an ocx

.ocx.reg:
	$(_REGSVR) /s $*.ocx

#define for compiling il to an exe
.il.exe:
	$(_ASSEM) $*.il

#define for compiling il to a dll
.il.dll:
	$(_ASSEM) $*.il /DLL

#define for compiling asm to an exe
.asm.exe:
	$(_ASSEM) $*.asm

#define for compiling asm to an exe
.asm.dll:
	$(_ASSEM) $*.asm /DLL

.res.rc:
   $(_RSC) $**

default:	
	nmake all
clean : 
	@-del /Q *.obj *.tlb *.reg

clobber :	clean
        @-del /Q *.exe *.dll

