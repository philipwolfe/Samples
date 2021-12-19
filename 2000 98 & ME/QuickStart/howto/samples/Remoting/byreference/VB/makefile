!include ..\..\..\..\..\master.mak

all: object.dll share.dll server.exe client.exe 

object.dll: object.vb share.dll
	$(_BC) $(_CS_DLL_FLAGS) /r:share.dll /r:System.Runtime.Remoting.dll /debug+ /out:object.dll object.vb

share.dll: share.vb
	$(_BC) $(_CS_DLL_FLAGS) /optionstrict- /debug+ /out:share.dll share.vb

server.exe: server.vb object.dll
	$(_BC) /debug+ /r:object.dll /r:System.Runtime.Remoting.dll server.vb

client.exe: client.vb object.dll share.dll
	$(_BC) /debug+ /r:object.dll /r:share.dll /r:System.Runtime.Remoting.dll client.vb



