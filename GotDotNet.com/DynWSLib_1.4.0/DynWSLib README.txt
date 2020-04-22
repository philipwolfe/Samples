DynWSLib 1.4.0
==============
Did you ever think about invoking your XML Web Services dynamically without having to generate a client side proxy class at design/compile time with wsdl.exe or Visual Studio .NET? - No need to know the exact Web Service description and endpoint at compile/design time. Just get your WSDL from UDDI (or from wherever you want, e.g. XMethods), specify the type to instantiate and the methods to call ... voila! Can be used from any .NET application or even an unmanaged resource.


Features:
---------
- No need to add WSDL descriptions during design time
- Point-and-run Web Services invocation functionality
- Ready-to-run user experience when using the library
- Also resolves imports of external schemas
- Works with complex types
- Provides a better means to completely hide the Web Services bound functionality from client apps -> think Grid computing
- Caching mechanism to improve performance of already 'well known' Web Services (pre-compiled assemblies)
- Access the raw SOAP messages for request and response
- Sample client application for testing purposes


Issues:
-------
- not a 'good' .NET citizen: not FxCop 1.21 'compliant'
- performance could be better in general
- lots of testing still needed
- Documentation sucks
- Clear up init process: perhaps add explicit Init() method
- Simple sample usage in C#, VB.NET, Managed C++


Credits:
--------
- Alex De Jarnatt: the god of WSDL and Schemas in the XML Web Services team. You rock!
- Nadia Romeo: thanks for testing the lib so much and such hard!
- Pierre Greborio: thanks for testing and providing a lot of valuable input.


DISCLAIMER:
The sample is provided as is. Be sure that it is actually only a sample and does not in any sense conform to any coding guidelines and has not been proven to be a stable product! The code has not been reviewed by third parties or even been refactored for optimization - be sure that it is still much improvable.
The author cannot be made responsible for any damage or inconveniencies but is willed to accept any questions and comments to this sample.
Please notice that this code is only a technology demo and should not be included unedited into any serious project.
The code is not documented.


Christian Weyer, July 2003
For questions and comments: cw@eyesoft.de
