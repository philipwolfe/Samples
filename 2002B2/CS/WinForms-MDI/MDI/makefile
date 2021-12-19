!IFNDEF NETSAMPLEPATH
!ERROR Env Variable NETSAMPLEPATH must be defined: Parent directory of QuickStart Samples
!ENDIF

!include $(NETSAMPLEPATH)\QuickStart\master.mak


#--------------------------------------------------
TARGETS  = MDI.exe
SOURCES = MainForm.cs Document.cs
CLEANUP = *.exe  *.pdb
#--------------------------------------------------

_IMPORTS=$(_CS_WINFORMS_IMPORTS)

#--------------------------------------------------
all : $(TARGETS)
	rem Sample $(MAKEDIR)

$(TARGETS) : $(SOURCES)
	$(_CS) $(_CS_EXE_FLAGS) $(_IMPORTS) /out:$@ $(SOURCES)

	
clean :
	@for %i in ( $(CLEANUP) ) do @del %i
	@if exist obj $(_RMDIR) obj

