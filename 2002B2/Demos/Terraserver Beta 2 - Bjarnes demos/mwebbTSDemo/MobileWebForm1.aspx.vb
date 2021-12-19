Imports System.Drawing
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports mwebbTSDemo.net.terraservice


Public Class MobileWebForm1
    Inherits System.Web.UI.MobileControls.MobilePage
    Protected WithEvents txtYear As System.Web.UI.MobileControls.TextBox
    Protected WithEvents lblResult As System.Web.UI.MobileControls.Label
    Protected WithEvents slPU As System.Web.UI.MobileControls.SelectionList
    Protected WithEvents lblPU As System.Web.UI.MobileControls.Label
    Protected WithEvents Label2 As System.Web.UI.MobileControls.Label
    Protected WithEvents btnCheck As System.Web.UI.MobileControls.Command
    Protected WithEvents Panel1 As System.Web.UI.MobileControls.Panel
    Protected WithEvents lblResultLabel As System.Web.UI.MobileControls.Label
    Protected WithEvents imgLogo As System.Web.UI.MobileControls.Image
    Protected WithEvents Label1 As System.Web.UI.MobileControls.Label
        Protected WithEvents Form1 As System.Web.UI.MobileControls.Form

#Region " Web Forms Designer Generated Code "
    
    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub
    
    Private Sub Form1_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Form1.Activate

    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click


        'Create a variable that refers to Terraserver's CensusServer
        Dim myCS As New CensusService()


        'Create a object that stores the Const from TerraServer
        Dim objPU As PoliticalUnit


        Dim txtPU As String


        txtPU = slPU.Selection.Text

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
        lblResult.Text = CStr(myCS.CountOfPoliticalUnit(objPU, CInt(txtYear.Text)))


        'Verbose and descriptive
        'lblResult.Text() = "There are " + CStr(myCS.CountOfPoliticalUnit(objPU, CInt(txtYear.Text))) + " of type " + txtPU + " in the Census Database."


    End Sub
End Class
