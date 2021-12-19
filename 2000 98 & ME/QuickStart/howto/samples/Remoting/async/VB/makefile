!include ..\..\..\..\..\master.mak

all: object.dll server.exe client.exe

object.dll: object.vb
	$(_BC) /t:library /debug+ /r:System.Runtime.Remoting.dll object.vb

server.exe: server.vb object.dll
	$(_BC) /t:exe /debug+ /r:object.dll /r:System.Runtime.Remoting.dll server.vb

client.exe: client.vb object.dll
	$(_BC) /t:exe /debug+ /r:object.dll /r:System.Runtime.Remoting.dll client.vb



