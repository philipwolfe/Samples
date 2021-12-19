Imports System
Imports System.Collections
Imports System.Configuration.Install

public class CustomInstaller: Inherits Installer

	public overrides sub Install(state As IDictionary)
		Context.LogMessage("Installing")
		MyBase.Install(state)
		Console.WriteLine("Installing: Any code could be executed here!")
	end sub

	public overrides sub Uninstall(state As IDictionary)
		Context.LogMessage("Uninstalling")
		Console.WriteLine("Uninstalling: Any code could be executed here!")
		MyBase.Uninstall(state)
	end sub
end class
