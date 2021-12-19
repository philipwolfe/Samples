Imports System

public class Installers
	public shared sub Main()
		Dim assemblyName As String = Environment.GetCommandLineArgs()(0)
		If(Not assemblyName.EndsWith(".exe")) Then
			assemblyName = assemblyName + ".exe"
		End If
		Console.WriteLine("Please run InstallUtil.exe " + assemblyName)
	end sub
end class