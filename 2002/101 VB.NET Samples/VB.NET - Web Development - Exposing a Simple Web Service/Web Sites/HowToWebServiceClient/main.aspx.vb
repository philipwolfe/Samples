'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Public Class Main
	Inherits System.Web.UI.Page
	Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents grdProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnTenMost As System.Web.UI.WebControls.Button
    Protected WithEvents btnAbout As System.Web.UI.WebControls.Button

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

    ' This routine handles the click event for the "About..." button.
    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        ' Open the About page
        Response.Redirect("about.aspx")
    End Sub

    ' This routine handles the click event for the "Get Ten Most Expensive Products"
    ' button. The Web service proxy class is instantiated. The results of the Web 
    ' method call are then bound to the DataGrid.
    Private Sub btnTenMost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTenMost.Click
        Dim ws As New localhost.Main()
        grdProducts.DataSource = ws.GetTenMostExpensiveProducts
        grdProducts.DataBind()
    End Sub

    ' This routine handles the Web page's Load event.
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            ' So that we only need to set the title of the application once, we use 
            ' the AssemblyInfo class (defined in the AssemblyInfo.vb file) to read the 
            ' AssemblyTitle attribute.
            Dim ainfo As New AssemblyInfo()

            Me.lblTitle.Text = ainfo.Title
        End If
    End Sub
End Class
