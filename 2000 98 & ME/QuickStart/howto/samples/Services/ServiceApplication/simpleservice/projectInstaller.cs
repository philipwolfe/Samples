using System;
using System.Collections;
using System.Configuration.Install;
using System.ServiceProcess;
using System.ComponentModel;

[RunInstallerAttribute(true)]
public class ProjectInstaller: Installer{

	private ServiceInstaller serviceInstaller;
	private ServiceProcessInstaller processInstaller;

	public ProjectInstaller(){
		
		processInstaller = new ServiceProcessInstaller();
    	serviceInstaller = new ServiceInstaller();

		// Service will run under system account
    	processInstaller.RunUnderSystemAccount = true;

		// Service will have Start Type of Manual
        serviceInstaller.StartType = ServiceStart.Manual;
    		
		serviceInstaller.ServiceName = "Hello-World Service";

    	Installers.Add(serviceInstaller);
    	Installers.Add(processInstaller);
	}
}    
