'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports System
Imports System.Reflection
Imports System.Resources


<Assembly: AssemblyTitle("XML Documentation Tool")> 
<Assembly: AssemblyDescription("Creates and manages XML Documentation")> 
<Assembly: AssemblyCompany("Microsoft Corporation")> 
<Assembly: AssemblyCopyright("Copyright (C) Microsoft Corp. 1999-2002.  All Rights Reserved.")> 
<Assembly: CLSCompliant(True)> 
<Assembly: NeutralResourcesLanguageAttribute("en-US")> 

' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:

<Assembly: AssemblyVersion("1.0.*")> 

#Region " Helper Class to Get Information for the About form. "
' This class uses the System.Reflection.Assembly class to
' access assembly meta-data
' This class is not a normal feature of AssemblyInfo.vb
Public Class AssemblyInfo
    ' Used by Helper Functions to access information from Assembly Attributes
    Private myType As Type

    Public Sub New()
        myType = GetType(MainWindow)
    End Sub

    Public ReadOnly Property AsmName() As String
        Get
            Return myType.Assembly.GetName.Name.ToString()
        End Get
    End Property
    Public ReadOnly Property AsmFQName() As String
        Get
            Return myType.Assembly.GetName.FullName.ToString()
        End Get
    End Property
    Public ReadOnly Property CodeBase() As String
        Get
            Return myType.Assembly.CodeBase
        End Get
    End Property
    Public ReadOnly Property Copyright() As String
        Get
            Dim at As Type = GetType(AssemblyCopyrightAttribute)
            Dim r() As Object = myType.Assembly.GetCustomAttributes(at, False)
            Dim ct As AssemblyCopyrightAttribute = CType(r(0), AssemblyCopyrightAttribute)
            Return ct.Copyright
        End Get
    End Property
    Public ReadOnly Property Company() As String
        Get
            Dim at As Type = GetType(AssemblyCopyrightAttribute)
            Dim r() As Object = myType.Assembly.GetCustomAttributes(at, False)
            Dim ct As AssemblyCompanyAttribute = CType(r(0), AssemblyCompanyAttribute)
            Return ct.Company
        End Get
    End Property
    Public ReadOnly Property Description() As String
        Get
            Dim at As Type = GetType(AssemblyDescriptionAttribute)
            Dim r() As Object = myType.Assembly.GetCustomAttributes(at, False)
            Dim da As AssemblyDescriptionAttribute = CType(r(0), AssemblyDescriptionAttribute)
            Return da.Description
        End Get
    End Property
    Public ReadOnly Property Product() As String
        Get
            Dim at As Type = GetType(AssemblyProductAttribute)
            Dim r() As Object = myType.Assembly.GetCustomAttributes(at, False)
            Dim pt As AssemblyProductAttribute = CType(r(0), AssemblyProductAttribute)
            Return pt.Product
        End Get
    End Property
    Public ReadOnly Property Title() As String
        Get
            Dim at As Type = GetType(AssemblyTitleAttribute)
            Dim r() As Object = myType.Assembly.GetCustomAttributes(at, False)
            Dim ta As AssemblyTitleAttribute = CType(r(0), AssemblyTitleAttribute)
            Return ta.Title
        End Get
    End Property
    Public ReadOnly Property Version() As String
        Get
            Return myType.Assembly.GetName.Version.ToString()
        End Get
    End Property
End Class

#End Region