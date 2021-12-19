!include ..\..\..\..\master.mak

all: share.dll server.exe client.exe 

object.dll: object.cs share.dll
	$(_CS) $(_CS_DLL_FLAGS)  /debug+ /r:share.dll /r:System.Runtime.Remoting.dll /out:object.dll object.cs

share.dll: share.cs
	$(_CS) $(_CS_DLL_FLAGS)  /debug+ /out:share.dll share.cs

server.exe: server.cs object.dll
	$(_CS) /debug+ /r:object.dll /r:System.Runtime.Remoting.dll server.cs

client.exe: client.cs object.dll share.dll
	$(_CS) /debug+ /r:share.dll /r:object.dll /r:System.Runtime.Remoting.dll client.cs



