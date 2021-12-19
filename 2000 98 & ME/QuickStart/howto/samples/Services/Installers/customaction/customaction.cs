using System;

public class Installers
{
	public static void Main(String[] args) 
	{
		string assemblyName = Environment.GetCommandLineArgs()[0];
		if(!assemblyName.EndsWith(".exe")){
			assemblyName = assemblyName + ".exe";
		}
		Console.WriteLine("Please run InstallUtil.exe " + assemblyName);
	}
}