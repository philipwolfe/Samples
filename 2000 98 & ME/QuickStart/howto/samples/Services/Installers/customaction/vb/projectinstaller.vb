Imports System
Imports System.Configuration.Install
Imports System.ComponentModel

public class <RunInstaller(true)> ProjectInstaller: Inherits Installer

	private customInstaller As CustomInstaller

	public sub New()
		MyBase.New()
		customInstaller = new CustomInstaller()
		Installers.Add(customInstaller)
	end sub
end class
