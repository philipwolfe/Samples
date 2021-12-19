Imports System
Imports System.Collections
Imports System.Configuration.Install
Imports System.ServiceProcess
Imports System.ComponentModel

public class <RunInstaller(true)> ProjectInstaller: inherits installer

	private serviceInstaller As ServiceInstaller
	private processInstaller As ServiceProcessInstaller

	public Sub New() 
		MyBase.New()
                
	        processInstaller = new ServiceProcessInstaller()
    	        serviceInstaller = new ServiceInstaller()

		' Service will run under system account
    	        processInstaller.RunUnderSystemAccount = true

		' Service will have Start Type of Manual
                serviceInstaller.StartType = ServiceStart.Manual
    		
		serviceInstaller.ServiceName = "Hello-World Service"

    	        Installers.Add(serviceInstaller)
    	        Installers.Add(processInstaller)
	end sub
end class    
