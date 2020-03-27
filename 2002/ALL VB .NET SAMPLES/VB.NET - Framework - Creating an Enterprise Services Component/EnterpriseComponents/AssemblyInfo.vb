Imports System.Reflection
Imports System.Runtime.InteropServices

' This Imports lets you use Attributes like "ApplicationNameAttribute"
' and "ApplicationActivation" (see below). Remember that you must set a
' Reference to this namespace in order to Import it.
Imports System.EnterpriseServices

' The ApplicationNameAttribute specifies the Name for the COM+
' application this assembly will be a part of. When the assembly is
' first invoked, the COM+ application will be created if it doesn't yet
' exist, provided the calling application has Administrator privileges.
<Assembly: ApplicationNameAttribute("VB.NET How-To Create Enterprise Services Components")> 

' The ApplicationIDAttribute provides COM+ with a GUID as the
' application identifier.
<Assembly: ApplicationIDAttribute("F3F4E0DA-6712-4AA9-9F48-871A81FD2844")> 

' The ApplicationActivation attribute specifies where assembly
' components are loaded when they're activated.
'
' Library : components run in the creator's process
' Server : components run in a system process, dllhost.exe.
<Assembly: ApplicationActivation(ActivationOption.Library)> 

' The DescriptionAttribute shows up in the application's properties in
' the COM+ Explorer.
<Assembly: DescriptionAttribute("VB.NET How-To Data Access Components")> 

' The AssemblyKeyFile attribute identifies the file containing the
' Public/Private key pair we're using to sign the assembly. It's
' located in the Application folder, so we must indicate that it's two
' levels above the assembly itself.
'
' The .snk file was generated at the command line with sn.exe, like
' this: sn -k KeyFile.snk
<Assembly: AssemblyKeyFile("..\..\KeyFile.snk")> 

<Assembly: AssemblyTitle("VB.NET How-To: Create Enterprise Services Components")> 
<Assembly: AssemblyDescription("Microsoft Visual Basic .NET How-To: Create Enterprise Services Components")> 
<Assembly: AssemblyCompany("Microsoft Corporation")> 
<Assembly: AssemblyProduct("Microsoft Visual Basic .NET How To: 2002")>
<Assembly: AssemblyCopyright("Copyright © 2002 Microsoft Corporation. All rights reserved.")>
<Assembly: CLSCompliant(True)>
<Assembly: AssemblyVersion("1.0.0.0")>
