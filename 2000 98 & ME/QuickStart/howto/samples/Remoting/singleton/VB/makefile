!include ..\..\..\..\..\master.mak

all: object.dll server.exe client.exe

object.dll: object.vb
	$(_BC) $(_VB_DLL_FLAGS) /debug+ /r:System.Runtime.Remoting.dll object.vb

server.exe: server.vb object.dll
	$(_BC) /debug+ /r:object.dll /r:System.Runtime.Remoting.dll server.vb

client.exe: client.vb object.dll
	$(_BC) /debug+ /r:object.dll /r:System.Runtime.Remoting.dll client.vb



