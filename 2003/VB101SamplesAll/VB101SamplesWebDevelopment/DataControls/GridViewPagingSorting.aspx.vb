Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text

Partial Public Class GridViewPagingSorting_aspx
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        If Page.IsPostBack Then
            EmployeesGridView.Visible = True
            EmployeesGridView.AllowSorting = EnableSortCheckbox.Checked
            EmployeesGridView.PageSize = Convert.ToInt32(NumPerPageTextBox.Text)
        End If
    End Sub 'OnLoad
End Class 'GridViewPagingSorting_aspx