Instructions:
1.	Build and deploy the ATL Server ISAPI DLL (see ..\MyIsapi\ReadMe.txt for details). 
2.	Build Form.dll.
3.	Copy the following files to a single public virtual directory on your web server:
		Form.dll
		Form.srf
		Normal.css

This DLL and SRF is used by other parts of this sample and is not intended to be navigated to
directly. Follow the instructions in the other ReadMe.txt files.