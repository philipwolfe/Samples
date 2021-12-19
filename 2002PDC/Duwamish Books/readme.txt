----------------------------------------------------------------------------------------------------------------------
Duwamish Books 7.0 Readme for Visual Studio 7.0 Pre-Release (c) 2000 Microsoft Corporation. All rights reserved.
---------------------------------------------------------------------------------------------------------------------- 

This release is provided for evaluation purposes only. It contains pre-release code, documentation and specifications, 
and is not at the level of performance and compatibility of the final product offering. This release is confidential and 
proprietary to Microsoft and its suppliers. Do not disclose or provide copies of this product or any information 
relating to it to any other party, or use it for any other purpose than as provided in the End User License Agreement 
without the prior written consent of Microsoft.

Duwamish Books 7.0 Readme includes updated information for the documentation provided with Microsoft(r) Visual Studio(tm) 
-- Development System for Windows(r) and the Internet. 

The information in this document is more up-to-date than the information in the Help system. Many of the issues 
outlined in this document will be corrected in upcoming releases.

---------
Contents
---------

This documentation provides late-breaking installation instructions for Duwamish Books 7.0.

[1] Known issues

[2] Up-to-Date Installation Instructions

	* Command line build
	* Installing Duwamish Books 7.0
	* Removing and Repairing Duwamish Books 7.0

--------------
Known Issues
--------------

Running Duwamish Books 7.0 From Visual Studio 7.0
-------------------------------------------------------

To run Duwamish Books 7.0 from the Visual Studio 7.0 IDE, you need to:

	make the web project the startup project. You can do this by right-clicking
	on the web project and selecting Set as Startup Project.
	
	make default.aspx the start page. You can do this by right-clicking on the 
	file default.aspx and making it the start page.


Before running Performance Tests against Duwamish Books
------------------------------------------------------------

1. There is a line in the config.web configuration file in the application root directory that is required when
running Duwamish from the Visual Studio IDE:

	 <compilation debugmode="true" />

If you want to run a retail version of Duwamish Books, it is advised that you set debugmode to "false".


--------------------
Command line build
--------------------

All of the following instructions assume that you are in the install directory for Duwamish Books 7.0.

Install Duwamish Books 7.0 using the steps outlined in the section Installing Duwamish Books 7.0

Command line build of  Duwamish Books 7.0
----------------------------------------------

To compile from the command line, change directory to the directory that Duwamish 7.0 is installed and type:

	nmake /a -f duwamish.mak CFG=<config> all

where <config> is one of Debug or Release. If you omit the CFG= then Debug is the default. Please note that both 
Debug and Release binaries are built into the same output directory (the Virtual Root for the Duwamish sample) and, 
therefore, it is strongly recommended that the /a (force make) option is used as shown above.

-------------------------------
Installing Duwamish Books 7.0
-------------------------------

To install Duwamish Books 7.0

1. Locate the Duwamish7 folder at the following location: 
	[Directory Visual Studio is installed]: /VS Enterprise Samples/Duwamish Books 7.0/Duwamish Books 7

2. Select and run the Duwamish 7 Windows Installer Package file.
	The Welcome to Duwamish 7 Setup Wizard appears.

3. Select Next to continue.

	Note   You can select Cancel at any time to terminate the installation or Previous to return to the previous page.  
	If you cancel, re-running the application to remove installed items is recommended.  
	See Removing and Repairing Duwamish Books 7.0 for more information.

4. The License Agreement appears.  After reading the attached End User License Agreement, accept the terms of the 
agreement to continue installation by selecting I Agree.  
Click Next to proceed.

5. The Select Components page appears with all components selected by default.

	For initial installations, accept all default settings.  Change the settings only if one of the exceptions below applies to you. 
	(Note, once the installation process has been run, you will have to uninstall the product and run the setup application again if 
	you wish to change any of these settings.)

	a. Web and Application:  If you are installing Duwamish Books 7.0 on this machine for the first time, 
	you should accept the default selection.  However, if you have already installed the Web and Application 
	component in a previous installation, you can elect to bypass its installation.

	b. Database:  This default should be accepted for first time installations.  You can optionally install the 
	database component separately -- to a network server, for example (see Remote Database for configuration details).

	c. Source Files:  This component is selected by default.  It is recommended but not required.  
	Accepting the default selection will provide easy access to the application's source code in htm files. 
	 If you previously installed this component, you can elect to bypass its installation.

6. Select Next to continue.
	Note  If you are not installing the database at this time, the Duwamish 7 Setup Wizard will jump to the Confirm Installation page.

7. The Select a Virtual Directory page appears.  
	Select a name for the Virtual Directory name. This will be the name you use when accessing Duwamish 7 from the web.
	e.g. http://localhost/Duwamish7/default.aspx - where Duwamish7 is the virtual directory name.
	Select Next to continue.

8. The Select A Database page appears.

	a. Database:  "Duwamish7" is the default value.  If a database matching the name in this field already exists on the 
	target machine and you attempt to proceed, the following message will appear, "Cannot create the database 
	"Database Name":  database by this name already exists.  Do you want to use the existing database?"  
	If this occurs you can:
	- Select Yes to use the existing database.
	- Return to the Select Components page, deselect the Database component and proceed (Not recommended).
	- Select No to return to the Select a Database page.  If you do so, you must change the name in the "Database" 
	field to create a new database before proceeding.

	b. Machine:  The installation package automatically populates this field with the local machine name 
	and installs the database component to this machine unless otherwise specified.  If you wish to install 
	the database to another machine (for example, to a Web Farm), enter the appropriate server machine 
	name and refer to the Remote Database InstallationvtoriWebFarmConfiguration for configuration details.

	c. User:  Enter any valid, SQL Server 7.0 system administrator user name or accept the default "sa" value.
	Important  Duwamish Books requires system administrator access to SQL Server 7.0.  For more 
	information see Configuring SQL Server in Duwamish Books 7.0 in the help documentation.
	
	d. Password:  Enter any valid, SQL Server password or accept the default value.

9. Select Next to continue the setup process.

10. The Confirm Installation page appears.  Select Next to install Duwamish 7.

11. The Installing Duwamish 7 page appears.

12. When the Installation Complete page appears, select Close to exit.


-------------------------------------------
Removing and Repairing Duwamish Books
-------------------------------------------


To Repair Duwamish Books 7.0
---------------------------------

1. Locate the Duwamish7 folder at the following location:  
[Directory Visual Studio is installed]:/VS Enterprise Samples/Duwamish Books 7.0/Duwamish Books 7

2. Select and run the Duwamish Windows Installer Package file.

3. The Welcome to the Duwamish 7 Setup Wizard page appears as follows:

4. Repair is selected by default.  This utility will restore Duwamish Books to its original state if application components become corrupted.

5. Select Finish to repair the application.


To Remove Duwamish Books 7.0
----------------------------------

Currently the removal utility does not remove the Duwamish 7 database.

  To completely remove the application perform the following steps.

1. Locate the Duwamish7 folder at the following location:  
	[Directory Visual Studio is installed]:/Enterprise Samples/Duwamish Books 7.0/Duwamish Books 7

2. Select and run the Duwamish Windows Installer Package file.

3. The Welcome to the Duwamish 7 Setup Wizard page appears.  Select Remove and Finish to remove components
.
4. Open SQL Server and select the database containing the Duwamish Books catalog tables.

5. Right click on the appropriate database and select Delete.

6. Select OK to delete the database.

