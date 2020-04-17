#region Using directives

using System.Reflection;
using System.Runtime.CompilerServices;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("WorkflowAdminService")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("E-Business Test Labs")]
[assembly: AssemblyProduct("WorkflowAdminService")]
[assembly: AssemblyCopyright("Copyright @ E-Business Test Labs 2004")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.0.0")]

////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Because the assembly does not have a valid strong name signature, the verification of that signature 
//must be turned off. You can do this by using the –Vr option with the Strong Name tool. 

//The following example turns off verification for an assembly called myAssembly.dll. 

//sn –Vr myAssembly.dll
//Caution Use the -Vr option only during development. Adding an assembly to the skip verification list 
//creates a security vulnerability. A malicious assembly could use the fully specified assembly name 
//(assembly name, version, culture, and public key token) of the assembly added to the skip verification list 
//to fake its identity. This would allow the malicious assembly to also skip verification.