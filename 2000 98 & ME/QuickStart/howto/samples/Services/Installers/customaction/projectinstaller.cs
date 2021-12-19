using System;
using System.Configuration.Install;
using System.ComponentModel;

[RunInstaller(true)]
public class ProjectInstaller: Installer{

	private CustomInstaller customInstaller;

	public ProjectInstaller(){

		customInstaller = new CustomInstaller();
		Installers.Add(customInstaller);
	}
}
