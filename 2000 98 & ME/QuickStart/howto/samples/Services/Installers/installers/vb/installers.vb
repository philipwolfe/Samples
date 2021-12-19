Imports System
Imports System.Diagnostics
Imports System.Messaging

' run InstallUtil.exe installers.exe
' verify that the evnet log was created
' verify that the message queue was created
' run InstallUtil.exe /u installers.exe
' verify that the message queue was removed
' verify that the event log was removed
public class Installers

	public shared sub Main()

		Dim resourcesInstalled As Boolean
		resourcesInstalled = true

		if (not MessageQueue.Exists(".\InstallersSample")) then
			Console.WriteLine("This application requires InstallersSample Message Queue to be installed.")
			resourcesInstalled = false
		end if

		if (not EventLog.SourceExists("InstallersSample")) then
			Console.WriteLine("This application requires InstallersSample Event Log Source to be setup.")
			resourcesInstalled = false
		end if

		if (not resourcesInstalled) then
			Console.WriteLine("Please run InstallUtil.exe " + Environment.GetCommandLineArgs()(0))
			return
		end if

		' the application may proceed!
		Console.WriteLine("Message Queue and Event Log are installed!")
	end sub
end class