' Author:  Syed Javed Hashmi
' Created: 15/05/2006
' Email: softech.systems@gmail.com
' Modification History:
' --------------------------------------------------------------------------------------------
' Date        Author             Description
' 15/05/2006  Syed Javed Hashmi  Created
' --------------------------------------------------------------------------------------------

Public Class clsTabs


    Public Structure sTabProperties
        Dim NumberOfTabs As Integer
        Dim TabNamePrefix As String
        Dim WorkAreaNamePrefix As String
        Dim TabContainer As System.Web.UI.HtmlControls.HtmlGenericControl
        Dim TabTexts() As String
        Dim TabWidths() As Integer
        Dim TabTextUnselectedColor As System.Drawing.Color
        Dim TabTextSelectedColor As System.Drawing.Color
        Dim TabTextFont As String
        Dim TabTextFontSize As String
        Dim TabSelectedColor As System.Drawing.Color
        Dim TabUnselectedColor As System.Drawing.Color
        Dim NonTabAreaColor As System.Drawing.Color
        Dim BorderLeftColor As System.Drawing.Color
        Dim BorderTopBottom As System.Drawing.Color
    End Structure


    Public TabProperties As New sTabProperties


    Public Sub MakeTabs()

        Dim strHTML As New System.Text.StringBuilder
        Dim i As Integer

        With TabProperties

            ' CSS --
            strHTML.Append(" <STYLE type='text/css'>" & vbCrLf)
            strHTML.Append("   TD.clsTab         {BACKGROUND-COLOR: " & HtmlColor(.TabUnselectedColor) & "; BORDER-BOTTOM: " & HtmlColor(.BorderTopBottom) & " 2px inset; BORDER-LEFT: " & HtmlColor(.TabSelectedColor) & " 1px  solid; BORDER-RIGHT: " & HtmlColor(.TabSelectedColor) & " 1px  solid; BORDER-TOP: " & HtmlColor(.TabUnselectedColor) & " 2px  solid; font-family: " & .TabTextFont & "; color: " & HtmlColor(.TabTextUnselectedColor) & "; font-size: " & .TabTextFontSize & "; CURSOR: hand}" & vbCrLf)
            strHTML.Append("   TD.clsTabSelected {BACKGROUND-COLOR: " & HtmlColor(.TabSelectedColor) & "; BORDER-BOTTOM: " & HtmlColor(.TabSelectedColor) & "     solid; BORDER-LEFT: " & HtmlColor(.BorderLeftColor) & " 1px outset; BORDER-RIGHT: " & HtmlColor(.BorderTopBottom) & " 0px outset; BORDER-TOP: " & HtmlColor(.BorderTopBottom) & " 2px outset; font-family: " & .TabTextFont & "; color: " & HtmlColor(.TabTextSelectedColor) & "; font-size: " & .TabTextFontSize & "; font-weight:bold; CURSOR: hand}" & vbCrLf)
            strHTML.Append(" </STYLE>" & vbCrLf & vbCrLf)
            ' --

            ' SCRIPTS --
            strHTML.Append("<script language='javascript'>" & vbCrLf & vbCrLf)
            strHTML.Append("var numberOfTabs_" & .TabContainer.ID & " = " & .NumberOfTabs & ";" & vbCrLf & vbCrLf)
            strHTML.Append("function " & .TabContainer.ID & "_tabClicked(selectedTab)" & vbCrLf)
            strHTML.Append("{" & vbCrLf)
            strHTML.Append("    " & .TabContainer.ID & "_selectTab(selectedTab.id.charAt(selectedTab.id.length - 1));" & vbCrLf)
            strHTML.Append("    tab_Clicked('" & .TabContainer.ID & "', selectedTab.id, selectedTab.id.charAt(selectedTab.id.length - 1));" & vbCrLf)
            strHTML.Append("}" & vbCrLf & vbCrLf)

            strHTML.Append("function " & .TabContainer.ID & "_selectTab(tabToSelect)" & vbCrLf)
            strHTML.Append("{" & vbCrLf)
            strHTML.Append("    if (tabToSelect < 1 || tabToSelect > numberOfTabs_" & .TabContainer.ID & ")" & vbCrLf)
            strHTML.Append("     {" & vbCrLf)
            strHTML.Append("      return false;" & vbCrLf)
            strHTML.Append("     }" & vbCrLf)
            strHTML.Append("    " & .TabContainer.ID & "_resetTabs();" & vbCrLf)
            strHTML.Append("	document.all.item('" & .TabNamePrefix & "' + tabToSelect).className='clsTabSelected';" & vbCrLf)
            strHTML.Append("	document.all.item('" & .WorkAreaNamePrefix & "' + tabToSelect).style.display = 'inline';" & vbCrLf)
            strHTML.Append("}" & vbCrLf & vbCrLf)

            strHTML.Append("function " & .TabContainer.ID & "_resetTabs()" & vbCrLf)
            strHTML.Append("{" & vbCrLf)
            strHTML.Append("    for (i = 1; i < numberOfTabs_" & .TabContainer.ID & " + 1; i++)" & vbCrLf)
            strHTML.Append("    {" & vbCrLf)
            strHTML.Append("		document.all.item('" & .TabNamePrefix & "' + i).className='clsTab';" & vbCrLf)
            strHTML.Append("		document.all.item('" & .WorkAreaNamePrefix & "' + i).style.display='none';" & vbCrLf)
            strHTML.Append("	}" & vbCrLf & vbCrLf)
            strHTML.Append("}" & vbCrLf & vbCrLf)
            strHTML.Append("</script>" & vbCrLf & vbCrLf)
            ' --

            ' Tabs --
            strHTML.Append("<table border='1' width='100%' id='tabsTable' cellspacing='0'>" & vbCrLf)
            strHTML.Append("	<tr>" & vbCrLf)

            For i = 1 To .NumberOfTabs
                strHTML.Append("		<td id='" & .TabNamePrefix & i & "' onclick='" & .TabContainer.ID & "_tabClicked(this);' align='center' width='" & .TabWidths(i - 1) & "'>" & .TabTexts(i - 1) & "</td>" & vbCrLf)
            Next

            strHTML.Append("		<td id='" & .TabNamePrefix & .NumberOfTabs + 1 & "' align='center' style='border: 1px solid " & HtmlColor(.TabSelectedColor) & "; background-color:" & HtmlColor(.NonTabAreaColor) & "'></td>" & vbCrLf)
            strHTML.Append("	</tr>" & vbCrLf)
            strHTML.Append("	<tr style='BACKGROUND-COLOR: " & HtmlColor(.TabSelectedColor) & "'>" & vbCrLf)
            strHTML.Append("		<td colspan='" & .NumberOfTabs + 1 & "' style='border: 1px solid " & HtmlColor(.TabSelectedColor) & "'>&nbsp;</td>" & vbCrLf)
            strHTML.Append("	</tr>" & vbCrLf)
            strHTML.Append("</table>" & vbCrLf)

            .TabContainer.InnerHtml = strHTML.ToString
            ' --

        End With

    End Sub


    Private Function HtmlColor(ByVal SystemDrawingColor As System.Drawing.Color) As String
        Return System.Drawing.ColorTranslator.ToHtml(SystemDrawingColor)
    End Function


End Class
