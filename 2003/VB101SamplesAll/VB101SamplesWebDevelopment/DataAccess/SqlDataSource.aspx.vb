Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text

Partial Public Class SqlDataSource_aspx
    Inherits System.Web.UI.Page

    ' Page events are wired up automatically to methods 
    ' with the following names:
    ' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    ' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    ' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    ' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    ' Page_SaveStateComplete, Page_Unload
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
    End Sub 'Page_Load

    Protected Sub GetProductsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetProductsButton.Click
        ProductsGridView.Visible = True
    End Sub
End Class 'SqlDataSource_aspx