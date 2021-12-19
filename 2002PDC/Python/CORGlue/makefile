CORGLUE_SRC = corglue.cs

REGASM=regasm.exe
KEY_FILE=..\..\ManagedPython.key

corglue.dll: $(CORGLUE_SRC) $(KEY_FILE)
	rem if exist corglue.dll $(COMREG) corglue.dll /u && del corglue.dll
	csc /nologo /assembly.title:"Python COM+ Compiler Glue Helper" /W:4 /a.keyfile:$(KEY_FILE) /target:library corglue.cs
	$(REGASM) corglue.dll /tlb:corglue.tlb
	al -i:CORGlue.dll

clean:
	- $(REGASM) /u corglue.dll /tlb:corglue.tlb
	- InstallUtil /u CORGlue.dll
	- del *.InstallLog
	- del corglue.tlb
	- del corglue.dll
	- del *.pdb
