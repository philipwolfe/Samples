<%@ Control %>
<SCRIPT language="vb" runat="server">
        Public m_linkDownloadSample As String = String.Empty
        Public m_linkRunSample As String = String.Empty
        Public m_linkDownloadDotNetFramework As String = "<IMG height=""7"" src=""../images/imgArwrt.gif"" width=""7"">&nbsp;<A class=""vsEvalSmall"" HREF=""http://www.microsoft.com/downloads/details.aspx?FamilyId=262D25E3-F589-4842-8157-034D1E7CF3A3&displaylang=en"" target=""_new"">Download .NET Framework 1.1</A><BR>"

		Private m_windowsApp As Boolean
		Private m_hrefRun As String
		Private m_hrefDownload As String
	
        Public Property windowsApp() As Boolean
            Get
                Return m_windowsApp
            End Get
            Set(ByVal Value As Boolean)
                m_windowsApp = Value
            End Set
        End Property

        Public Property hrefRun() As String
            Get
                Return m_hrefRun
            End Get
            Set(ByVal Value As String)
                m_hrefRun = Value
            End Set
        End Property
        
		Public Property hrefDownload() As String
            Get
                Return m_hrefDownload
            End Get
            Set(ByVal Value As String)
                m_hrefDownload = Value
            End Set
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ConfigureLinks()
            RegisterRunScript()
        End Sub
		
		Private Sub RegisterRunScript()
			Dim RunScript As String = "<scri"
			RunScript += "pt language=""JavaScript"">"
			RunScript += " function preventRun() {"
			RunScript += " alert(""You will need to install the .NET Framework version 1.1 to run this sample: \n\n"
			RunScript += "1. Download the .NET Framework version 1.1 using the link at the top of the page. \n"
			RunScript += "2. Install the Framework. \n"
			RunScript += "3. Close all browser windows, then return to this site to run the sample."");"
			RunScript += " return false;"
			RunScript += "} </scri"
			RunScript += "pt>"
			Page.RegisterClientScriptBlock("RunScript",RunScript)
		End Sub

        Private Sub ConfigureLinks()

            Dim strUserAgent As String = Request.ServerVariables("HTTP_USER_AGENT")

			' links to run and download
            m_linkDownloadSample = "<A class=""vsEvalSmall"" HREF=""" & m_hrefDownload & """ target=""_new"">Download Completed Sample</A>"

            If (strUserAgent.IndexOf(".NET CLR 1.1.4322") > -1) Then
				m_linkDownloadDotNetFramework = String.Empty
				m_linkRunSample = "<A class=""vsEvalSmall"" HREF=""" & m_hrefRun & """ target=""_new"">Run Sample Application</A>"
			ElseIf m_windowsApp = True Then
				m_linkRunSample = "<A class=""vsEvalSmall"" HREF=""" & m_hrefRun & """ target=""_new"" onClick=""return preventRun()"">Run Sample Application</A>"
			Else
				m_linkRunSample = "<A class=""vsEvalSmall"" HREF=""" & m_hrefRun & """ target=""_new"">Run Sample Application</A>"
            End If 
        End Sub

        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
			
            ' write table of links
            writer.Write( _
        "<table cellpadding=""5"" border=""0""><tr valign=""bottom""><td>" & m_linkDownloadDotNetFramework & _
          "<IMG height=""7"" src=""../images/imgArwrt.gif"" width=""7"">&nbsp;" & m_linkRunSample & "<br>" & _
          "<IMG height=""7"" src=""../images/imgArwrt.gif"" width=""7"">&nbsp;" & m_linkDownloadSample & _
         "</td>" & _
         "<td>" & _
          "<IMG height=""7"" src=""../images/imgArwrt.gif"" width=""7"">&nbsp;<A class=""vsEvalSmall"" HREF=""mailto:vseval@microsoft.com?subject=Feedback"">Submit Feedback</A><br>" & _
          "<IMG height=""7"" src=""../images/imgArwrt.gif"" width=""7"">&nbsp;<a class=""vsEvalSmall"" href=""../default.aspx"">Rapid Evaluation Home</a>" & _
         "</td></tr></table>")

        End Sub
</SCRIPT>