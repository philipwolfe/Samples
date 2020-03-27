Instructions:
1.	Build and deploy the ATL Server ISAPI DLL (see ..\MyIsapi\ReadMe.txt for details).
2.	Get browscaps.xml and ensure that it's in the same directory
	as the ISAPI DLL.
2.	Build ShowBrowser.dll.
3.	Copy the following files to a single public virtual directory on your web server:
		ShowBrowser.dll
		ShowBrowser.srf
		Normal.css
4. Use a browser to navigate to the SRF file and follow the instructions.