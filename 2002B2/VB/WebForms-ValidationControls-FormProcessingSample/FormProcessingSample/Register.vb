Option Strict On
Option Explicit On 

'The following Imports statements were auto-generated
Imports System
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Microsoft.VisualBasic

Public Class Register
    Inherits System.Web.UI.Page
    Protected WithEvents WebForm1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Submit1 As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents txtEmailValReg As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents txtEmailValReq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtEmail As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtZipCodeValReg As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents txtZipCodeValReq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtZipCode As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents ddlStateValReq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ddlState As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCityValReq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCity As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtNameValReq As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtName As System.Web.UI.HtmlControls.HtmlInputText
       
#Region " Web Forms Designer Generated Code "
    
    Dim WithEvents Register As System.Web.UI.Page
    
    Sub New()
        Register = Me
    End Sub
    
    'CODEGEN: This procedure is required by the Web Form Designer
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    End Sub
    
#End Region
    
    Public Sub Submit1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick
	Response.Redirect("Confirm.aspx?txtName=" & Request.Form("txtName") & "&txtCity=" & Request.Form("txtCity") & "&txtState=" & Request.Form("ddlState") & "&txtZipCode= " & Request.Form("txtZipCode") & "&txtEmail=" & Request.Form("txtEmail"))
    End Sub

    Protected Sub Register_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Register.Load
        If Not IsPostBack Then   ' Evals true first time browser hits the page	
            'The first time the page is loaded, retrieve the U.S. states DataSet
            'from the ASP.NET cache and bind it to the State dropdownlist control.
            Dim dsStates As DataSet

            'Retrieve the DataSet from the cache
            dsStates = CType(Cache("dsStates"), DataSet)

            'Bind the DataSet to the dropdownlist control
            With ddlState
                .DataSource = dsStates.Tables(0).DefaultView
                .DataValueField = "abbrev"
                .DataTextField = "name"
                .DataBind()
            End With

            'The following validation control properties are duplicated here for demo purposes
            'so they can be documented.

            'Two validation controls are used for both the Zip Code and Email fields
            '(a Required validation control and a Regular Expression validation control)
            'Because the error messages are mutually exclusive for each pair, 
            'the Display property is set to "Dynamic" so each message can be displayed
            'in the same location on the form. 
            txtZipCodeValReq.Display = WebControls.ValidatorDisplay.Dynamic
            txtZipCodeValReg.Display = WebControls.ValidatorDisplay.Dynamic
            txtEmailValReq.Display = WebControls.ValidatorDisplay.Dynamic
            txtEmailValReg.Display = WebControls.ValidatorDisplay.Dynamic

            'Regular Expression validators are used to validate the Zip Code and Email address.
            'Built-in standard expressions exist for both field formats.  The standard
            'expressions are available from the property builder for the ValidationExpression property.

            'U.S. ZIP Code standard expression
            txtZipCodeValReg.ValidationExpression = "\d{5}(-\d{4})?"
            'Internet E-mail Address standard expression
            txtEmailValReg.ValidationExpression = "[\w-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
        End If
    End Sub

    Protected Sub Register_Init(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Register.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

End Class
