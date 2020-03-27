Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Public Class Start_aspx
    Inherits System.Web.UI.Page

    ' Page events are wired up automatically to methods 
    ' with the following names:
    ' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    ' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    ' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    ' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    ' Page_SaveStateComplete, Page_Unload
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' TODO: Replace the path with ConfigurationSettings.ConnectionStrings["AppConnectionString1"].ConnectionString
        ' when this will work again. Currently causes compilation error.
        If Not System.IO.File.Exists("C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf") Then
            Response.Redirect("ConfigurationError.htm", True)
        End If
    End Sub 'Page_Load
End Class 'Start_aspx 