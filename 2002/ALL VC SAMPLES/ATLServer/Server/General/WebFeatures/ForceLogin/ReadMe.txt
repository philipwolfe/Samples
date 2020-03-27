Instructions:
1.	Build and deploy the ATL Server ISAPI DLL (see ..\MyIsapi\ReadMe.txt for details). 
2.	Build ForceLogin.dll.
3.	Copy the following files to a single public virtual directory on your web server:
		ForceLogin.dll
		LoginPage.srf
		ProtectedResource.srf
		Normal.css
4.	Use a browser to navigate to ProtectedResource.srf and follow the instructions.