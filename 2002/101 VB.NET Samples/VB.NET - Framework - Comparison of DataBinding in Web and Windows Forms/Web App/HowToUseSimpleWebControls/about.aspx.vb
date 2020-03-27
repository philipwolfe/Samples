'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class about
	Inherits System.Web.UI.Page
	Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
	Protected WithEvents lblVersion As System.Web.UI.WebControls.Label
	Protected WithEvents lblCopyright As System.Web.UI.WebControls.Label
	Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
	Protected WithEvents lblCodebase As System.Web.UI.WebControls.Label
	Protected WithEvents btnBack As System.Web.UI.WebControls.Button

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
		If Not Page.IsPostBack Then
			' Only load the data once
			' Set the labels identitying the Title, Version, and Description by
			' reading Assembly meta-data originally entered in the AssemblyInfo.vb file
			' using the AssemblyInfo class defined in the same file
			Dim ainfo As New AssemblyInfo()

			Me.lblTitle.Text = ainfo.Title
			Me.lblVersion.Text = String.Format("Version {0}", ainfo.Version)
			Me.lblCopyright.Text = ainfo.Copyright
			Me.lblDescription.Text = ainfo.Description
			Me.lblCodebase.Text = ainfo.CodeBase
		End If
	End Sub

	Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
		' Return to the Main page
		Response.Redirect("main.aspx")
	End Sub
End Class
