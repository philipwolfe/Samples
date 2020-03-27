try 
{
	// Create a project engine
	var projEngine = new ActiveXObject( "VisualStudio.VCProjectEngine.7" );

	// Load a project
	var project = projEngine.LoadProject("MyProject.vcproj");
	if (project == null)
		print("load failed");
	else
	{
		//Change the project's name
		project.Name = "Voila";
		//Add a new configuration
		project.AddConfiguration("Whichever Name");
		
		// Get the debug configuration and change the type to application
		var configuration = project.Configurations.Item("Debug");
		if(configuration != null)
		{
			configuration.ConfigurationType = 1		//typeApplication;
		}
		else
			print("I Couldn't find the configuration");

		// Get the linker tool from the configration.
		var linkerTool = configuration.Tools.Item("VCLinkerTool");
		if(linkerTool != null)
		{
			// Change the ShowProgress property to "Display All Progress Messages (/VERBOSE)"
			linkerTool.ShowProgress = 1		//linkProgressAll;
		}
		else
			print("I Couldn't find the linkerTool");

		// Add a cpp file called New.cpp
		if (project.CanAddFile("New.cpp")) 
			project.AddFile("New.cpp");
		else
			print("I Couldn't add the file");

		// Access the files collection
		var filesCollection = project.Files;
		if(filesCollection != null)
		{
			// Access a cpp files called Existing.cpp that is already in the project.
			var file = filesCollection.Item("Existing.cpp");

			if(file != null)
			{
				// Access the release configuration of this file.
				var fileConfiguration = file.FileConfigurations.Item("Release|Win32");

				// Get the compiler tool associated with this file.
				var compilerTool = fileConfiguration.Tool;

				// Change the optimization property to Full Optimization (/Ox)
				compilerTool.Optimization = 3		//optimizeFull;
			}
			else
				print("I Couldn't find the file");

			// Save the project.
			project.ProjectFile = "MyNewProject.vcproj"
			project.Save();
		}
		else
			print("I Couldn't find the file collection");
	}
}
catch ( e ) 
{
	print("Operation failed for the following reason: " + e);
}
