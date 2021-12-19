Creating Windows Services Sample

The .NET framework makes it real easy to implement a service by providing the 
System.ServiceProcess.ServiceBase class. When you write a service, 
you inherit from this class and override some of its methods and set its properties 
(See below) and you’re ready to go, it’s that easy. 

How the sample works:
The WinService class’s constructor sets the service’s CanPauseAndContinue and 
ServiceName properties. The class overrides ServiceBase.OnStart to actually get 
the service started. In the OnStart override, it writes a log message to the event 
log then calls StartWorkerThread. This method creates a worker thread and uses it 
to do the actual processing. OnStop logs a message and calls StopThread, which 
interrupts then kills the thread that was started by StartWorkerThread. When the 
service is paused, OnPause logs a message then stops the worker thread. When the 
service resumes, OnContinue creates a new worker thread.

To run the service, the Main procedure instantiates an object from FileMonitorService 
and pass it to ServiceBase.Run. You can control whether service control events are 
automatically logged by setting the service’s AutoLog property to True or False. If 
you set it to True, the ServiceName property is used as the message source for messages 
logged to the event log. So be sure to set ServiceName before you set AutoLog to True 
otherwise you’ll get an exception.

After creating the service, you’ll want to install and run it. The code in installer.vb 
handles installing the WinService. Using this code you can customize aspects of your 
service such as the service name that appears under Computer Management\Services. You 
can also specify the service startup mode, e.g. manual or automatic. Once you’ve added 
this installer component, you can build your service executable. You then install it 
from a command prompt using InstallUtil.exe:

InstallUtil WinService.exe

This will instantiate and call the installer component that you added to your project. 
If you want to uninstall the service, you can do so using InstallUtil with the /u command 
line option:

InstallUtil /u WinService.exe

After WinService starts, it monitors for changes to files on the C:\  drive by using 
System.IO.FileSystemWatcher. WinService will detect and log changes to files on C:\ just 
so you can see some activity from the service. See the file monitoring sample for more 
information on monitoring the file system.


Properties	
AutoLog:
 If true, ServiceBase will automatically report service start, stop pause and continue to the event log.
CanPauseAndContinue:
The service is able to accept and process pause and continue commands.
CanShutdown:
The service needs to know when the system is shutting down.
CanStop:
 The service is able to accept stop commands. You’ll set this to True for most services you write. 
EventLog:
 A read-only property that gives you access to an EventLog object that you can use to write to the event log
ServiceName:
You set this property to indicate the name of the service. ServiceBase uses this name is used as the source for messages it writes to the event log.
Methods	
Dispose:
Call this method do dispose of the object immediately rather than waiting for the garbage collector to dispose of it.
OnContinue:
Override this method in your class to receive notifications of the continue command. You must also set CanPauseAndContinue to True.
OnCustomCommand:
Override this method to process custom commands sent to your service. A custom command is an integer between 128 and 256 that means something to your service. The integer representing the command that was issued is passed in as a parameter to this method. 
OnPause:
Override this method in your class to receive notifications of the pause command. You must also set CanPauseAndContinue to True.
OnShutdown:
Override this method in your class to receive notifications when the system is shutting down. You must also set CanShutdown to True.
OnStart:
Override this method in your class to receive notifications of the Start command. 
OnStop:
Override this method in your class to receive notifications of the stop command. You must also set CanStop to True.
Run:
The only shared method on this class. Call this method from your program’s Main procedure passing it an instance of the class that inherits from ServiceBase. This tells ServiceBase to load the service in memory so it can be started by the SCM.

