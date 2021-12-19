using System;
using System.Collections;
using System.Configuration.Install;

public class CustomInstaller: Installer{

	public override void Install(IDictionary state) {
		Context.LogMessage("Installing");
		base.Install(state);
		Console.WriteLine("Installing: Any code could be executed here!");
	}

	public override void Uninstall(IDictionary state) {
		Context.LogMessage("Uninstalling");
		Console.WriteLine("Uninstalling: Any code could be executed here!");
		base.Uninstall(state);
	}
}
