!include ..\..\..\..\master.mak

all: object.dll server.exe client.exe

object.dll: object.cs
	$(_CS) $(_CS_DLL_FLAGS) /debug+ /r:System.Runtime.Remoting.dll object.cs

server.exe: server.cs object.dll
	$(_CS) /debug+ /r:object.dll /r:System.Runtime.Remoting.dll server.cs

client.exe: client.cs object.dll
	$(_CS) /debug+ /r:object.dll /r:System.Runtime.Remoting.dll client.cs



