DispSink: Demonstrates handling events fired from a 
singleton COM server through a dispatch interface. 

This sample demonstrates the use of connection points on
dispatch interfaces.  

The server is a singleton object that has it’s own dual 
interface as well as a dispatch interface used for firing 
off events.  The server object takes data that is given to 
it through it’s dual interface’s Send method and transmits 
it to all connected components through the Transfer event 
on it’s dispatch interface.

The client is an ActiveX control that contains a server 
object. The control responds to the Transfer event fired by 
the server object and has it’s own dual interface that has 
Connect, Send, and Disconnect methods.  If the Transfer event 
is fired with a variant containing a BSTR, the string is 
displayed in the center of the control.

Running the Sample:

First compile the server.exe and register it.  Then compile 
the client.  Open up the Test Container and insert one or 
more of the client controls into the container. Invoke the 
connect method on all of the controls.  

Invoke the Send method on one of the controls.  Change the 
Parameter Type field of the Invoke Methods dialog to VT_BSTR 
and then type any string into the Parameter Value box.  Press 
the invoke button.  The string will be displayed in the center 
of all connected controls.
