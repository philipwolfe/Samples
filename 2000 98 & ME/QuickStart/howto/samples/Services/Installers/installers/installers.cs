using System;
using System.Diagnostics;
using System.Messaging;

// run InstallUtil.exe installers.exe
// verify that the evnet log was created
// verify that the message queue was created
// run InstallUtil.exe /u installers.exe
// verify that the message queue was removed
// verify that the event log was removed
public class Installers
{
	public static void Main(String[] args) 
	{
		bool resourcesInstalled = true;
		if(!MessageQueue.Exists(".\\InstallersSample"))
		{
			Console.WriteLine("This application requires InstallersSample Message Queue to be installed.");
			resourcesInstalled = false;
			
		}
		if(!EventLog.SourceExists("InstallersSample"))
		{
			Console.WriteLine("This application requires InstallersSample Event Log Source to be setup.");
			resourcesInstalled = false;
		}

		if(!resourcesInstalled){
			Console.WriteLine("Please run InstallUtil.exe " + Environment.GetCommandLineArgs()[0]);
			return;
		}

		// the application may proceed!
		Console.WriteLine("Message Queue and Event Log are installed!");
	}
}