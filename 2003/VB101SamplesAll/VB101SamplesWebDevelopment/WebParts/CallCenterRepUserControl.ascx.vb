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

Partial Public Class CallCenterRepUserControl_ascx
    Inherits System.Web.UI.UserControl

    ' Page events are wired up automatically to methods 
    ' with the following names:
    ' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    ' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    ' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    ' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    ' Page_SaveStateComplete, Page_Unload

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub 'Page_Load

    <Personalizable()> _
    Public Property Name() As String
        Get
            Return NameTextbox.Text
        End Get
        Set(ByVal value As String)
            NameTextbox.Text = value
        End Set
    End Property


    <Personalizable()> _
    Public Property EmployeeId() As String
        Get
            Return EmployeeIdTextbox.Text
        End Get
        Set(ByVal value As String)
            EmployeeIdTextbox.Text = value
        End Set
    End Property


    <Personalizable()> _
    Public Property Extension() As String
        Get
            Return ExtensionTextbox.Text
        End Get
        Set(ByVal value As String)
            ExtensionTextbox.Text = value
        End Set
    End Property


    <Personalizable()> _
    Public Property DepartmentNumber() As String
        Get
            Return DepartmentNumberTextbox.Text
        End Get
        Set(ByVal value As String)
            DepartmentNumberTextbox.Text = value
        End Set
    End Property
End Class 'CallCenterRepUserControl_ascx