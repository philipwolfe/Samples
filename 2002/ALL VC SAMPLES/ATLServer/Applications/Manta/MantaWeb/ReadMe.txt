========================================================================
       ATL SERVER SAMPLE : MantaWeb Project Overview
========================================================================

To build and run this sample
1.	Copy MantaWeb\MantaWeb.mdb to a local folder on your machine.
	Ensure that the database is not read-only.
	
2.	Open the solution file, MantaWeb.sln, in the Visual Studio development environment.

3.	Open Common\MWS_Common.h and change the definition of MANTAWEB_CONNECTION_STRING
	to match the location of MantaWeb.mdb on your machine.
	
4.	Create a folder on your machine that can be used to store files uploaded to the site.
	Ensure that the folder's security settings allow read and write access to users of the site.
	
5.	Open FileStore\FilesHandler.h and change the definition of MANTAWEB_FILESTORE_ROOT
	to match the location of the folder created in the previous step.
	
6.	Build the solution. This will also deploy the solution to the local web server.

7.	Remove MailService.h and MailService.wsdl from the MailClientMFC project.

8.	Right-click the MailClientMFC project in Solution Exprlorer, select Add Web Reference...
	and add a reference to the following URL:
	http://localhost/mantaweb/cgi-bin/MailService.dll?Handler=GenMailServiceSDL
	
9.	Rebuild the MailClientMFC project.

10.	Use Internet Services Manager to add login.srf as a default document for the
	MantaWeb virtual directory.
	
11.	Use a web browser to view http://localhost/mantaweb/login.srf.

12.	Sign up for an account. Be sure to provide values for all the requested information.

13.	Log in to the site.

14.	Use the site to send mail and manage your personal information.

15.	Use MailClient.exe to view mail.

(c) 2000 Microsoft Corporation