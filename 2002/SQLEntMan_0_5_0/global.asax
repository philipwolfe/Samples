<object id="ConnectionString" class="ASPEnterpriseManager.ConnectionString" runat="Server" scope="Session" />
<object id="AppInterface" class="ASPEnterpriseManager.XPInterface" runat="Server" scope="Application" />

	<script language="VB" Runat="server">
	
		Sub Application_Error(ByVal Sender as Object, ByVal E as EventArgs)
			
			With Response
					.write ("<table width=""100%"" height=""90%"">")
					.write ("<tr><td align=""center"" valign=""middle"">")
					AppInterface.DrawWindowHeader ("An Error has Occurred", "javascript:history.back();", "400")
						.write ("<table width=""100%"" style=""font-family: Trebuchet MS, Arial; font-size: 10pt;"">")
						.write ("<tr><Td>")
						.write ("<img src=""images/IconCritical.gif"" align=""left"">")
						.write ("</td><td  style=""padding: 10px;"">")
						.write ("<b>Error:</b> &nbsp; " & Server.GetLastError.InnerException.Message.ToString & "<br>")
						.write ("<b>Source:</b> &nbsp;  " & Server.GetLastError.InnerException.Source.ToString  & "<br>")
						
						.write ("</td></tr>")
						.write ("<tr><td colspan=""2"" align=""center"">")
						.write ("<br>")
						.write ("<input type=""button"" value=""OK"" onclick=""history.back();"" style="" width: 100px;"">")
						.write ("</td></tr>")
						.write ("</table>")
							
						.write ("<br>")	
					AppInterface.DrawWindowFooter()
					.write ("</td></tr>")
					.write ("</table>")
					.End
			End With
		End Sub
		
	</script>