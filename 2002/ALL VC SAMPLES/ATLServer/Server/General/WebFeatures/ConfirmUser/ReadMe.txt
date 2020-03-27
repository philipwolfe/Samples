Instructions:
1.	Build and deploy the ATL Server ISAPI DLL (see ..\MyIsapi\ReadMe.txt for details).
2.	Create a SQL server database and run the following SQL scripts to create the tables
	and stored procedures necessary for this sample:
		Signup.sql
3.	Double-click on ConfirmUser.udl and configure the data link properties to point to 
	the database you just set up.
4.	Configure an SMTP server and edit the code in ConfirmUser.cpp to use that server.
	(A warning advising you to change the server name will appear during the compilation).
5.	Build ConfirmUser.dll.
6.	Copy the following files to a single public virtual directory on your web server:
		ConfirmUser.dll
		ConfirmUser.srf
		ConfirmUser.udl
		Normal.css
7.	Use a browser to navigate to the SRF file and follow the instructions.