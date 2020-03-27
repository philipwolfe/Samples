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
Imports Samples.Web.Profiles

Partial Public Class ComplexProperties_aspx
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


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
        UpdateBuddyList()
        DisplayAddress()
    End Sub 'Page_PreRender


    Private Sub DisplayAddress()
        If Not (Profile.Address Is Nothing) Then
            StreetTextBox.Text = Profile.Address.Street
            CityTextBox.Text = Profile.Address.City
            StateTextBox.Text = Profile.Address.State
            ZipCodeTextBox.Text = Profile.Address.ZipCode
        End If
    End Sub 'DisplayAddress


    Private Sub UpdateBuddyList()
        Dim buddies As ArrayList = Profile.BuddyList

        If Not IsNothing(buddies) Then
            If buddies.Count > 0 Then
                BuddyDropDownList.DataSource = Profile.BuddyList
                BuddyDropDownList.DataBind()

                BuddyDropDownList.Visible = True
                DeleteButton.Visible = True
                NoBuddiesMsg.Visible = False
            Else
                BuddyDropDownList.Visible = False
                DeleteButton.Visible = False
                NoBuddiesMsg.Visible = True
            End If
        Else
            BuddyDropDownList.Visible = False
            DeleteButton.Visible = False
            NoBuddiesMsg.Visible = True
        End If
    End Sub 'UpdateBuddyList


    Protected Sub AddButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If BuddyNameTextBox.Text.Trim <> "" Then
            If IsNothing(Profile.BuddyList) Then
                Profile.BuddyList = New ArrayList()
            End If

            Profile.BuddyList.Add(BuddyNameTextBox.Text)
            UpdateBuddyList()
            BuddyNameTextBox.Text = ""
        End If
    End Sub 'AddButton_Click

    Protected Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Profile.BuddyList.RemoveAt(BuddyDropDownList.SelectedIndex)
        UpdateBuddyList()
    End Sub 'DeleteBuddyButton_Click

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Profile.Address Is Nothing Then
            ' Create a new Address object
            Dim addr As New Address()
            addr.Street = StreetTextBox.Text
            addr.City = CityTextBox.Text
            addr.State = StateTextBox.Text
            addr.ZipCode = ZipCodeTextBox.Text

            ' Add it to the profile
            Profile.Address = addr
        Else
            ' Update the one we already have
            Profile.Address.Street = StreetTextBox.Text
            Profile.Address.City = CityTextBox.Text
            Profile.Address.State = StateTextBox.Text
            Profile.Address.ZipCode = ZipCodeTextBox.Text
        End If
    End Sub 'SaveButton_Click
End Class 'ComplexProperties_aspx