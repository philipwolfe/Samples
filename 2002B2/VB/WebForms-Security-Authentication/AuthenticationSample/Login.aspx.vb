Imports System.Drawing
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security
Imports System.IO


Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents LoginValCust As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents Submit1 As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents txtUser As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtPassword As System.Web.UI.HtmlControls.HtmlInputText

    'These constants match a valid user name and password prepopulated in the custom XML data store
    Private Const VALID_USER As String = "User1"
    Private Const VALID_PASSWORD As String = "Password1"

#Region " Web Forms Designer Generated Code "
    
    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()

    End Sub

#End Region

    Protected Sub Page_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Private Sub Submit1_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack() Then ' Evals true first time browser hits the page	
            'Prefill the user and password fields with valid entries from the custom XML data store
            txtUser().Value = VALID_USER
            txtPassword().Value = VALID_PASSWORD
        End If
    End Sub

    Public Sub LoginServerValidate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ServerValidateEventArgs)
        'This function performs server-side validation for the custom validator control LoginValCust
        'The function name is referenced by the OnServerValidate event in the custom validator control HTML tag.
        If (AuthenticateUser(txtUser().Value, txtPassword().Value) = False) Then
            e.IsValid = False
        End If

    End Sub


    Private Function AuthenticateUser(ByVal strUser As String, ByVal strPassword As String) As Boolean
        'This function validates the entered user name and password against the custom XML data store Users.xml        
        Dim dsUsers As New DataSet()
        Dim dtUsers As DataTable
        Dim drUsers() As DataRow
        Dim strFilter As String
        Dim fs As FileStream
        Dim xmlStream As StreamReader

        'Open the XML file
        fs = New FileStream(Server.MapPath("Users.xml"), FileMode.Open, FileAccess.Read)

        'Read the XML document into a DataSet
        xmlStream = New StreamReader(fs)
        dsUsers.ReadXml(xmlStream)

        'Close the XML file        
        fs.Close()

        'Create a data row array by filtering on the entered user name and password        
        dtUsers = dsUsers.Tables(0)
        strFilter = "name='" & strUser & "' and password='" & strPassword & "'"
        drUsers = dtUsers.Select(strFilter)

        'If the length of the array is greater than zero, then a match was found in the data store
        If drUsers.Length > 0 Then
            'Upon success, set an in-memory authentication cookie for the user
            'The cookie name is set in the security section of the config.web file 
            FormsAuthentication.RedirectFromLoginPage(userName:=strUser, createPersistentCookie:=False)
            AuthenticateUser = True
        Else
            AuthenticateUser = False
        End If
    End Function

End Class
