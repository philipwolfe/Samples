Imports System.Web.Services
Imports FormInfo
Imports System.IO
Imports System.Reflection

Public Class FormsListWebService
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Overloads Overrides Sub Dispose()
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
    End Sub

#End Region

    Private MyFormsDirectory As String = "C:\Inetpub\wwwroot\FormsListWebService\Forms"
    Private MyBaseType As Type = GetType(System.Windows.Forms.UserControl)
    Private MyUrlLocation As String = "http://localhost/FormsListWebService/Forms/"

    <WebMethod()> Public Function GetFormsList() As FormInfo.FormInfo()

        Dim forms As New ArrayList()
        Dim basetype As Type = MyBaseType
        FindFormsInDirectory(basetype, MyUrlLocation, MyFormsDirectory, forms)

        Dim fiArray(forms.Count) As FormInfo.FormInfo
        forms.CopyTo(fiArray)

        Return fiArray

    End Function

    'Finds all the forms in all the assemblies in the given search path                                                        
    Private Sub FindFormsInDirectory(ByVal basetype As [Type], ByVal urlLocation As String, ByVal searchpath As String, ByVal forms As ArrayList)

        Dim f As FileInfo
        Dim d As New DirectoryInfo(searchpath)
        For Each f In d.GetFileSystemInfos("*.dll")

            Try

                Dim currentAsm As [Assembly] = [Assembly].LoadFrom(f.FullName)

                Dim temptype As Type

                For Each temptype In currentAsm.GetExportedTypes()
                    If (temptype.IsSubclassOf(basetype)) Then

                        Dim fi As New FormInfo.FormInfo()

                        fi.Name = GetName(temptype)
                        fi.Description = GetDescription(temptype)
                        fi.AssemblyName = temptype.[Module].Name
                        fi.TypeName = temptype.FullName
                        fi.UrlLocation = urlLocation
                        forms.Add(fi)
                    End If

                Next temptype


            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                'Log output...
            End Try

        Next f


    End Sub

    Private Function GetName(ByVal t As Type) As String
        Dim attributeArray As Attribute() = Attribute.GetCustomAttributes(t)
        Dim currentAttr As Attribute

        For Each currentAttr In attributeArray

            If (currentAttr.GetType() Is GetType(FormNameAttribute)) Then
                Dim fna As FormNameAttribute = CType(currentAttr, FormNameAttribute)
                Return fna.Name
            End If
        Next currentAttr

        Return t.ToString()

    End Function

    Private Function GetDescription(ByVal t As Type) As String
        Dim attributeArray As Attribute() = Attribute.GetCustomAttributes(t)
        Dim currentAttr As Attribute

        For Each currentAttr In attributeArray

            If (currentAttr.GetType() Is GetType(FormDescriptionAttribute)) Then
                Dim fda As FormDescriptionAttribute = CType(currentAttr, FormDescriptionAttribute)
                Return fda.Description
            End If
        Next currentAttr

        Return "No Description available"
    End Function





End Class
