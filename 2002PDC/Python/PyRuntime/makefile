!IFNDEF CORSDK
CORSDK=..\..
!ENDIF

!IF EXIST ($(WINDIR)\SYSTEM32\MSCOREE.DLL)
SYSTEM=$(WINDIR)\SYSTEM32
!ELSE
SYSTEM=$(WINDIR)\SYSTEM
!ENDIF

KEY_FILE=..\..\ManagedPython.key
PYRUNTIME_DLL=..\p2c\Python.dll

all: $(PYRUNTIME_DLL)

$(PYRUNTIME_DLL): PyRuntime.cs $(KEY_FILE)
	csc /nologo /target:library /out:$(PYRUNTIME_DLL) /a.keyfile:$(KEY_FILE) /debug+ PyRuntime.cs
	al -i:$(PYRUNTIME_DLL)

clean:
	- InstallUtil /u $(PYRUNTIME_DLL)
	- del ..\p2c\Python.InstallLog
	- del InstallLog.InstallLog
	- del $(PYRUNTIME_DLL)
	- del *.pdb