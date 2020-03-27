To test the Secure SOAP sample, the web server must have a digital certificate.
This certificate is usually issued by a Certification Authority.

Steps to get and install a certificate on your web server:

A) Generate a certificate request 
B) Obtain a certificate from a Certification Authority
	B1) Make your machine a temporary certification authority
C) Install the certificate on your web server
D) Configure a virtual folder to require secure channel
E) (only for test CA) -  add your CA to the Trusted Root Certification Authorities store.



Below are details on how to perform each step:

A) Generate a certificate request 
=================================
Steps :
1) Open the Internet Information Services Manager console
2) In the Web Site properties, the "Directory Security" panel, press "Server Certificate..."
3) Server Certificate page : Select "Create a new certificate"
4) Delayed or Immediate... page : Select "Prepare the request now, but send it later"
5) Fill the required information in the following pages then save the certificate request as a file



B) Obtain a certificate from a Certification Authority
=======================================================
	B1) Make your machine a temporary certification aurhority
	=========================================================
	Only for test reason, your Windows Server machine can temporarily become a certification authority.

	To do that :
	1) In Control Panel, select Add/Remove Programs and select Add/Remove Windows Components
	2) Select Certificate Services in the Windows Component wizard
	3) In the next page (CA Type), select "Stand-alone root CA"
	4) In the next page (CA Identifying Information), enter a name like "Test CA %machine_name%" 
	5) Complete the wizard

Steps to resolve the certificate request for your server :
1) Start the Certification Authority management console (usually from Administrative Tools)
2) Use All Tasks->Submit new request from the Action menu to point to the certificate request file generated at step A5 above
If this option is not available in the All Tasks menu, then :
	- from the command prompt, launch certReq.exe
	- select the certificate request file generated at step A5 above
	- select your local Certificate Authority (usually, the last in the "Select Certificate Authority" list
	
3) In the Pending Requests  view, select the request you just issued and, from the All Tasks menu select Issue
4) In the Issued Certificates view, select the certificate you just issued and, from the All Tasks menu select Export Binary Data
In the Export Binary Data dialog, select Binary Certificate column from the combo box and the "Save binary data to a file" export option

If the Save Export Binary Data option is not available in the All Tasks menu, then :
	- remember the request ID of the crtificate you just issued (usually, the first column in the Issued Certificates view)
	- from the command prompt, launch certReq -retrieve -binary <reqID>
6) Save the data as a *.cer file




C) Install the certificate on your web server
=============================================
1) In the Internet Information Services Manager console, launch the same "Directory Security" \ "Server Certificate..." wizard  as in A
2) Pending Certificate Request page :  Select "Process the pending request and install the certificate"
3) Browse to the *.cer file obtained from the CA (or generated at step B6 above)




D) Configure a virtual folder to require secure channel
=======================================================
1) In the virtual folder properties, select the "Directory Security" panel
2) Select "Edit..." in the Secure Communication group
3) Check the "Require Secure Channel (SSL)" option


E) (only for test CA) -  add your CA to the Trusted Root Certification Authorities store.
=========================================================================================
If you are using a real CA this step is probably not required
Otherwise, the CA should be admitted as trusted on your client machine (which may be the same as the server)
This is necessary to avoid certificate validation errors that would prevent the sample from working

A simple way of adding your CA to the Trusted Root Certification Authorities store is to launch Internet Explorer and to browse
to the Virtual Folder that requires SSL (step D3 above). If the machine is the same for the client and the server, it is better 
to use  " https://<your_machine>..."  instead of "https://localhost...", because the certificate is issued on the server name

1) In the Security Alert dialog that pops-up when browsing the https Virtual Folder , select "View Certificate".
2) On the Certification Path panel, select the root of the certificate (the parent node of the certificate)
3) This node should be marked with an x and the Certificate Status field should contain:
 "This CA Root certificate is not trusted because it is not in the Trusted Root Certification Authorities store."
4) Push View Certificate...
5) Push Install Certificate and use the other default settings


