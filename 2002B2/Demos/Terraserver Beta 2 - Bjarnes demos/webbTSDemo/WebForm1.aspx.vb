Imports webbTSDemo.net.terraservice
Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblResult As System.Web.UI.WebControls.Label
    Protected WithEvents txtYear As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddPU As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnCheck As System.Web.UI.WebControls.Button
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image

    Dim strArgs As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here


    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click


        'Create a variable that refers to Terraserver's CensusServer
        Dim myCS As New CensusService()


        'Create a object that stores the Const from TerraServer
        Dim objPU As PoliticalUnit



        Dim txtPU As String

        txtPU = ddPU.SelectedItem.Text

        If txtPU = "CensusTract" Then

            objPU = PoliticalUnit.CensusTract
        ElseIf txtPU = "City" Then
            objPU = PoliticalUnit.City
        ElseIf txtPU = "County" Then
            objPU = PoliticalUnit.County
        ElseIf txtPU = "State" Then

            objPU = PoliticalUnit.State

        Else
            objPU = PoliticalUnit.Unknown
        End If


        'Short and to the point
        'lblResult.Text = CStr(myCS.CountOfPoliticalUnit(objPU, CInt(txtYear.Text)))


        'Verbose and descriptive
        lblResult.Text() = "There are " + CStr(myCS.CountOfPoliticalUnit(objPU, CInt(txtYear.Text))) + " of type " + txtPU + " in the Census Database."


    End Sub
End Class
