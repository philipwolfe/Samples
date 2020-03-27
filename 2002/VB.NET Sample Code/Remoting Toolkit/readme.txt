This is a very simple example of how to easily
utilize .NET Remoting using IIS as an application
server, and a binary formatter for serialization.

You get ease of management, firewall friendliness
(HTTP) and the speed of compressed binary data.

DLL:

	Your remotable class must derive from MarshalByRefObject.
    If you use a Component as the base class of your 
    business object, you will be ok. This is a best-practice
    for most projects.
   
	Supply a copy of the DLL to the web application and to the
    client application, even though the client will not use it
    directly. 
   
Web Application:

	Simply create a new web app that has a reference to the
	DLL.
	
	See the Web.Config file included here for instructions 
	on how to configure the web app.
	
Windows Client:

	Add a reference to System.Runtime.Remoting

	Add a reference to the DLL and include the DLL with the 
	exe file when you distribute.
	
	Add the RemotingModule.vb file to your project and modify
	it according to the comments therein.
	
	In the Form_Load of your Windows app, call ConfigureRemoting.
	
	Use the classes as you would normally.