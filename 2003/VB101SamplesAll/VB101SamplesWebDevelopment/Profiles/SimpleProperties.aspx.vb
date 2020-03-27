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

Partial Public Class SimpleProperties_aspx
    Inherits System.Web.UI.Page

    ' Page events are wired up automatically to methods 
    ' with the following names:
    ' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    ' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    ' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    ' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    ' Page_SaveStateComplete, Page_Unload
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Profile.FirstName <> String.Empty And Profile.LastName <> String.Empty Then
            WelcomeMsgLabel.Text = GetWelcomeMessageText(Profile.FirstName, Profile.LastName)
        End If
    End Sub 'Page_Load


    Protected Sub SetProfileButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Page.Validate()
        If Page.IsValid Then
            ' Set the FirstName and LastName profile properties
            Profile.FirstName = FirstNameTextBox.Text
            Profile.LastName = LastNameTextBox.Text

            ' Set the welcome message
            WelcomeMsgLabel.Text = GetWelcomeMessageText(Profile.FirstName, Profile.LastName)
        End If
    End Sub 'SetProfileButton_Click


    Private Function GetWelcomeMessageText(ByVal firstName As String, ByVal lastName As String) As String
        Return String.Format("Welcome {0} {1}!", firstName, lastName)
    End Function 'GetWelcomeMessageText
End Class 'SimpleProperties_aspx