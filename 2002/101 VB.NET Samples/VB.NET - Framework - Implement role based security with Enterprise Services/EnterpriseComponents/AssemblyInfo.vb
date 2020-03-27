Imports System.Reflection
Imports System.Runtime.InteropServices

' This Imports lets you use Attributes like "ApplicationNameAttribute"
' and "ApplicationActivation" (see below). Remember that you must set a
' Reference to this namespace in order to Import it.
Imports System.EnterpriseServices

' The SecurityRoleAttribute lets you add role-based security to this
' assembly. It accepts parameters including the role name, a
' description, and a boolean indicating whether the Everyone group
' should be added to this role. Choosing True is convenient for testing
' purposes, since it gives the Everyone group access to the component,
' but be sure to make it false before you deploy.
'
' See the Supplier class for details on how to control access via
' these roles. Note that user accounts must be added to these roles
' manually in the COM+ Explorer once the application has been added to
' the COM+ Catalog.
<Assembly: SecurityRoleAttribute("Managers", Description:="Managers have complete access", SetEveryoneAccess:=False)>
<Assembly: SecurityRoleAttribute("Clerks", Description:="Clerks have limited access", SetEveryoneAccess:=False)>

' The ApplicationAccessControlAttribute lets you control where access
' checks are performed. The options are:
'
' Application: Enable access checks only at the process level. No
'     access checks are made at the component, interface, or method
'     level.
' ApplicationComponent: Enable access checks at every level on
'     calls into the application.
<Assembly: ApplicationAccessControlAttribute(AccessChecksLevel:=AccessChecksLevelOption.ApplicationComponent)>

' The ApplicationNameAttribute specifies the Name for the COM+
' application this assembly will be a part of. When the assembly is
' first invoked, the COM+ application will be created if it doesn't yet
' exist, provided the calling application has Administrator privileges.
<Assembly: ApplicationNameAttribute("VB.NET How-To Implement Role-Based Security in Enterprise Services")>

' The ApplicationIDAttribute provides COM+ with a GUID as the
' application identifier.
<Assembly: ApplicationIDAttribute("52E273A0-0154-4E28-B176-650A6FBF17C5")>

' The ApplicationActivation attribute specifies where assembly
' components are loaded when they're activated.
'
' Library : components run in the creator's process
' Server : components run in a system process, dllhost.exe.
<Assembly: ApplicationActivation(ActivationOption.Library)>

' The DescriptionAttribute shows up in the application's properties in
' the COM+ Explorer.
<Assembly: DescriptionAttribute("VB.NET How-To: Implement Enterprise Services Role-Based Security")>

' The AssemblyKeyFile attribute identifies the file containing the
' Public/Private key pair we're using to sign the assembly. It's
' located in the Application folder, so we must indicate that it's two
' levels above the assembly itself.
'
' The .snk file was generated at the command line with sn.exe, like
' this: sn -k KeyFile.snk
<Assembly: AssemblyKeyFile("..\..\KeyFile.snk")>

<Assembly: AssemblyTitle("VB.NET How-To: Implement Role-Based Security in Enterprise Services")>
<Assembly: AssemblyDescription("Microsoft Visual Basic .NET How-To: Implement Role-Based Security in Enterprise Services")>
<Assembly: AssemblyCompany("Microsoft Corporation")>
<Assembly: AssemblyProduct("Microsoft Visual Basic .NET How To: 2002")>
<Assembly: AssemblyCopyright("Copyright © 2002 Microsoft Corporation.  All rights reserved.")>
<Assembly: CLSCompliant(True)>

<Assembly: AssemblyVersion("1.0.0.0")>
