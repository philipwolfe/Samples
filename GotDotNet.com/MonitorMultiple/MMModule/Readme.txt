
See the included sample web project


Configure using the web.config:

step 1)  Add the module:
Make sure the MMModule is copied to your /bin directory.

Add this to the <system.web> section:
<httpModules>
	<add type="MMModule.MultipleMonitorModule,MMModule"
	name="MMModule" />
</httpModules>



Step 2) Configure the paths to watch:

Add this to the <configuration> section:

<configSections>
  <section name="MMModulePaths"
	type="MMModule.MWatcherConfigHandler,MMModule"/>
</configSections>

<MMModulePaths>
		<!-- 
			Each <path...> specifies another path to watch
			<path
			  value=["~/somedir" | "c:\absolutepath]"]	- - the path to watch, either relative to application root
												or absolute drive. (note, proper permissions for the thread running
												this app are required!
			  extensions=["*" | ["ext1;ext2;...;extn"]	- - the extensions to watch. Changes involving other files
												are ignored
			  restartOnCreate=["true" | "false"] (default=true)	- - OPTIONAL: Does creating a matching file cause an appdomain restart?
			  restartOnRename=["true" | "false"] (default=true)	- - OPTIONAL: Does renaming a matching file cause an appdomain restart?
			  restartOnChange=["true" | "false"] (default=true)	- - OPTIONAL: Does changing a matching file cause an appdomain restart?
			  
		-->
		<path value="~/subdir" extensions="dll;txt" restartOnCreate="false" />
		<path value="~/" extensions="*" restartOnRename="false" />		
</MMModulePaths>