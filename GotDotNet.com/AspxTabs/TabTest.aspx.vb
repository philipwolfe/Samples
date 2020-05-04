' Author:  Syed Javed Hashmi
' Created: 15/05/2006
' Email: softech.systems@gmail.com
' Modification History:
' --------------------------------------------------------------------------------------------
' Date        Author             Description
' 15/05/2006  Syed Javed Hashmi  Created
' --------------------------------------------------------------------------------------------
'

Public Class TabTest
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents tabContainer As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Submit1 As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents Dropdownlist2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tabContainer1 As System.Web.UI.HtmlControls.HtmlGenericControl

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' ----------------------------------------------------------------------------------------------------
        ' IF YOU READ THE COMMENTS, YOU WILL KNOW HOW TO CREATE TABS
        ' ----------------------------------------------------------------------------------------------------
        ' ** IMPORTANT NOTE ** : 
        '    To select a tab when page loads call selectTab function like this: <body onload="selectTab(1);">
        '    You can provide any valid tab number.
        '
        '    You implement a javascript function named tab_Clicked(). The clsTabs will provide notification
        '    when a tab is clicked. The information provided is ID of tab container, ID of tab clicked and
        '    the tab number. function tab_Clicked(tabContainerID, tabID, tabNumber)
        '    This will help you to reselect a tab when page reloads. Following is an example:
        '      <body onload="selectTab(3);">
        '
        '
        ' ----------------------------------------------------------------------------------------------------


        Dim Tabs As New clsTabs

        ' Number of tabs to create
        Tabs.TabProperties.NumberOfTabs = 4

        ' The name prefix to be used for tabs i.e. if "tab" is sypplied then id='tab1', id='tab2' ... etc will 
        ' be used to identify each tab using
        Tabs.TabProperties.TabNamePrefix = "gTab"

        ' You create your own work area where you put your control. These work areas are <DIV's
        ' You need to give them an ID and this is done using WorkAreaNamePrefix variable. It works
        ' just like TabNamePrefix. You provide this so that the tab class display and hide these
        ' <DIV's corresponding to the tab you click.
        Tabs.TabProperties.WorkAreaNamePrefix = "tabPage"

        ' You need to supply a <DIV to contain the tabs this class will genetate. You supply the ID
        ' of that <DIV here.
        Tabs.TabProperties.TabContainer = tabContainer

        ' You must supply an array of tab text and it should match NumberOfTabs
        Tabs.TabProperties.TabTexts = New String() {"Task List", "Task Detail", "Attachements", "Task History"}

        ' You must supply an array of tab widths and it should match NumberOfTabs
        Tabs.TabProperties.TabWidths = New Integer() {80, 140, 180, 220}

        ' When you click on a tab its text color will change to the one you specify here
        'Tabs.TabProperties.TabTextSelectedColor = System.Drawing.Color.Black
        Tabs.TabProperties.TabTextSelectedColor = System.Drawing.Color.DimGray

        ' When you click on another tab then previous tab's text color will change to the one you specify here
        'Tabs.TabProperties.TabTextUnselectedColor = System.Drawing.Color.LightGray
        Tabs.TabProperties.TabTextUnselectedColor = System.Drawing.Color.Silver

        ' Font for the tab text
        Tabs.TabProperties.TabTextFont = "Verdana"

        ' Font size for the tab text
        Tabs.TabProperties.TabTextFontSize = "10pt"

        ' When you click on a tab its background color will change to the one you specify here
        Tabs.TabProperties.TabSelectedColor = System.Drawing.Color.Gainsboro
        'Tabs.TabProperties.TabSelectedColor = System.Drawing.ColorTranslator.FromHtml("#6699CC")

        ' When you click on another tab then previous tab's background color will 
        ' change to the one you specify here
        Tabs.TabProperties.TabUnselectedColor = System.Drawing.Color.DimGray
        'Tabs.TabProperties.TabUnselectedColor = System.Drawing.ColorTranslator.FromHtml("#003366")

        'Tabs.TabProperties.BorderLeftColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")
        Tabs.TabProperties.BorderLeftColor = System.Drawing.Color.WhiteSmoke

        'Tabs.TabProperties.BorderTopBottom = System.Drawing.ColorTranslator.FromHtml("#99ccff")
        Tabs.TabProperties.BorderTopBottom = System.Drawing.Color.WhiteSmoke

        ' This is the color for the empty area at the end of last tab
        'Tabs.TabProperties.NonTabAreaColor = System.Drawing.Color.WhiteSmoke
        Tabs.TabProperties.NonTabAreaColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")

        Tabs.MakeTabs()




        Dim Tabs1 As New clsTabs

        Tabs1.TabProperties.NumberOfTabs = 2
        Tabs1.TabProperties.TabNamePrefix = "gT"
        Tabs1.TabProperties.WorkAreaNamePrefix = "TP"
        Tabs1.TabProperties.TabContainer = tabContainer1
        Tabs1.TabProperties.TabTexts = New String() {"Task List", "Task Detail"}
        Tabs1.TabProperties.TabWidths = New Integer() {80, 140}
        Tabs1.TabProperties.TabTextSelectedColor = System.Drawing.Color.DimGray
        Tabs1.TabProperties.TabTextUnselectedColor = System.Drawing.Color.Silver
        Tabs1.TabProperties.TabTextFont = "Verdana"
        Tabs1.TabProperties.TabTextFontSize = "10pt"
        Tabs1.TabProperties.TabSelectedColor = System.Drawing.Color.Gainsboro
        Tabs1.TabProperties.TabUnselectedColor = System.Drawing.Color.DimGray
        Tabs1.TabProperties.BorderLeftColor = System.Drawing.Color.WhiteSmoke
        Tabs1.TabProperties.BorderTopBottom = System.Drawing.Color.WhiteSmoke
        Tabs1.TabProperties.NonTabAreaColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")

        Tabs1.MakeTabs()

    End Sub


End Class
