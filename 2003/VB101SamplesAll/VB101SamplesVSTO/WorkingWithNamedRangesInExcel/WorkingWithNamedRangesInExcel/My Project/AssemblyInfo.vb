Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Tools.Excel

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("WorkingWithNamedRangesInExcel")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("WorkingWithNamedRangesInExcel")> 
<Assembly: AssemblyCopyright("Copyright ©  2005")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("91ba37bb-729c-4a1d-88a1-350896515c4d")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.0.0")> 
<Assembly: AssemblyFileVersion("1.0.0.0")> 

' The ExcelLocale1033 attribute controls the locale that is passed to the Excel
' object model. Setting ExcelLocale1033 to true causes the Excel object model to 
' act the same in all locales, which matches the behavior of Visual Basic for 
' Applications. Setting ExcelLocale1033 to false causes the Excel object model to
' act differently when users have different locale settings, which matches the 
' behavior of Visual Studio Tools for Office, Version 2003. This can cause unexpected 
' results in locale-sensitive information such as formula names and date formats.

<Assembly: ExcelLocale1033(True)>
