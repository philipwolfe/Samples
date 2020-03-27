Instructions:
1.	Build and deploy the ATL Server ISAPI DLL (see ..\MyIsapi\ReadMe.txt for details).
2.	Build ShowErrors.dll.
3.	Copy the following files to a single public virtual directory on your web server:
		ShowErrors.dll
		ShowErrors.srf
		Normal.css
4.	Create a subdirectory beneath the directory containing ShowErrors.srf and
	call it errors. In it create a new HTML page called 404.htm.
	Add information to that file to display to the user when a 404 error is requested.
5.	Use a browser to navigate to the SRF file and follow the instructions.