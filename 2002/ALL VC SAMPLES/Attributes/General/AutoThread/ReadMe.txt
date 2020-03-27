AutoThread:  Demonstrates the use of CComAutoThreadModule. 

This Sample illustrates the use of CComAutoThreadModule.  
The server is implemented in the Server.exe.  The module 
of the .exe has been derived from CComAutoThreadModule instead 
of CComModule.  The declaration of the server class uses the 
DECLARE_CLASSFACTORY_AUTO_THREAD() macro.

The Server interface has a single method, Sleep.  This method 
puts the server thread to sleep for a given amount of time.  
The client portion of the sample is an ActiveX control that 
invokes the server’s sleep method when it the user clicks on the 
control.  The client also has a property named Delay that 
represents how long the server thread will be put to sleep for.   
The control displays the text "Ready" when it is waiting for the user 
to click.  The string "Waiting" is displayed when the control is waiting 
for the server to finish sleeping.

Running the sample:

First compile the Server object and register the server 
executable.  Then compile the client. 

Start up two separate instances of the autodrive.exe
Click on one of the controls and notice that it takes one second 
for the server to return.  Position and resize the test containers 
so that both of them are visible at the same time.  Click on one 
of the controls and then quickly click on the other control.  You 
will notice that they finish waiting at approximately the same time.  
(If CComAutoThreadModule were not used, the first control would 
finish after one second but the second control would not finish 
until a full second after the first control was finished.  The 
second call to sleep would not occur until the first had finished.)  
You can use the Delay(PropGet) and Delay(PropPut) methods to adjust 
the number of milliseconds the server sleeps for.  If set properly 
the second call to sleep may return before the first call to sleep.
 
