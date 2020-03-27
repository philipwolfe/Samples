Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class ViewUsers_aspx
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' ALTERNATE WAY:
        ' The GetAllUsers method returns an object of type MembershipUserCollection. This
        ' collection can then be used as a datasource for other controls to bind to, such
        ' as the GridView control. The GetAllUsers method is overloaded and also exposes
        ' a version to do paging.
        'Dim coll As MembershipUserCollection = Membership.GetAllUsers()
        'GridView1.DataSource = coll
        'GridView1.DataBind()
    End Sub
End Class 'ViewUsers_aspx