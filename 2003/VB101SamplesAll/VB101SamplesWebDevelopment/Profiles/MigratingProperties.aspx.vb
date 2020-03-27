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

Partial Public Class MigratingProperties_aspx
    Inherits System.Web.UI.Page

    Public Street, City, State, ZipCode As String

    ' Page events are wired up automatically to methods 
    ' with the following names:
    ' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    ' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    ' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    ' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    ' Page_SaveStateComplete, Page_Unload
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'Page_Load

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
        If Not Profile.IsAnonymous Then
            Dim buddies As ArrayList = Profile.BuddyList
            ProfilePanel.Visible = True
            AnonUserMsg.Visible = False

            If Not IsNothing(buddies) Then
                If buddies.Count > 0 Then
                    BuddyDropDownList.DataSource = buddies
                    BuddyDropDownList.DataBind()

                    BuddyDropDownList.Visible = True
                    NoBuddiesMsg.Visible = False
                Else
                    BuddyDropDownList.Visible = False
                    NoBuddiesMsg.Visible = True
                End If
            Else
                ProfilePanel.Visible = False
                AnonUserMsg.Visible = True
            End If

            If Not IsNothing(Profile.Address) Then
                Street = Profile.Address.Street
                City = Profile.Address.City
                State = Profile.Address.State
                ZipCode = Profile.Address.ZipCode
            End If
        Else
            ProfilePanel.Visible = False
            AnonUserMsg.Visible = True
        End If
    End Sub 'Page_PreRender
End Class 'MigratingProperties_aspx