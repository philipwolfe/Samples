Mailer Sample
Description 

Mailer is a simple app that allows you to fill in a form and send it via SMTP email. 
This app demonstrates the SMTP mail classes provided with ATL Server.  

Requirements 

NT Server with IIS installed.

Build Instructions and How to Run

In order to set up Mailer to run on your system, you must do the following: 

Open the Mailer.sln in Visual Studio 7 
Build Mailer.dll (DEBUG) 
Close the Mailer solution 
Open the MailerIsapi.sln in Visual Studio 7 
Build MailerIsapi.dll (DEBUG) 
Create a Mailer directory under your c:\inetpub directory 
Right click on My Computer and select Manage 
Navigate to Services and Applications->IIS 
Right click on Default Web Site, select New->Virtual Directory 
Create a directory named Mailer with a path equal to that of your c:\inetpub\Mailer, add execute permissions and Finish. 
Build the project then copy the .htm, .srf, files necessary to c:\inetpub\mailer 
Copy Mailerisapi.dll from the MailerIsapi\debug directory to c:\inetpub\mailer 
Copy Mailer.dll from the Mailer\debug directory to c:\inetpub\mailer 
Right click on the Virtual directory and select Properties and go to Configurations. 
Add C:\Inetpub\vcbids\mailerisapi.dll Extension srf 
Add C:\Inetpub\vcbids\mailerisapi.dll Extension dll 
Using a web browser, browse to http://< system name >/mailer/mailsamp.htm 
Compose your message and Send Message!

The "Server" field refers to the SMTP server you are sending to (e.g. smtp.foo.com) (required field). 
The "Sender Name" field refers the friendly name of the sender (e.g. John Doe) (optional field). 
The "From" field refers the sender's email address (e.g. johndoe@foo.com) (required field). 
The "Recipient Name" field refers the friendly name of the recipient (e.g. Jane Doe) (optional field). 
The "To" field refers the recipient email address (e.g. janedoe@foo.com) (required field). 
The "CC" field refers the CC recipient email address(es), seperated by commas, semi-colons or spaces (e.g. joe@foo.com, frank@foo.com) (optional field). 
The "Subject" field refers the subject of the message (optional field). 
The "Message" field refers the message body (optional field). 
The "Priority" dropdown lets you choose the priority of your message. 
The 3 file fields allow you to attach up to 3 files to your message and choose your encoding scheme (optional). 
 

Copyright (C) 1999 Microsoft Corporation. All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation. See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
