Instructions:
1.	Build and deploy the ATL Server ISAPI DLL (see ..\MyIsapi\ReadMe.txt for details).
2.	Create a SQL server database and run the following SQL scripts to create the tables
	and stored procedures necessary for this sample:
		ShowImage.sql
3.	Double-click on ShowImage.udl and configure the data link properties to point to 
	the database you just set up. 
4.	Build ShowImage.dll.
5.	Copy the following files to a single public virtual directory on your web server:
		ShowImage.dll
		ShowImage.srf
		ShowImage.udl
		Normal.css
	Make sure that the Form files are in the same virtual directory.
6.	Use a browser to navigate to the SRF file and follow the instructions.