﻿#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Management.Instrumentation;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum)]
[assembly: AssemblyTitle("service")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("service")]
[assembly: AssemblyCopyright("Copyright © Microsoft Corporation 2006.  All rights reserved.")]
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
[assembly: AssemblyVersion("1.0.*")]
// Specify where the user created objects will be located. Placed in ServiceModel 
// for convenience.
[assembly: Instrumented("root/ServiceModel")]
