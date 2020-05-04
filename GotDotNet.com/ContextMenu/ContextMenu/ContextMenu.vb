Imports System
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports MarkItUp.WebControls




'@ <summary>
'@ Represents a shortcut/context menu.
'@ </summary>
'@ <remarks>
'@ Contains a collection of clickable menu items.
'@ </remarks>
'@ <example>
'@ The following example shows you how to create a <see cref="ContextMenu" /> control on 
'@ your page and link to it from 2 <see cref="ContextMenuLink" /> controls.  The first ContextMenuLink
'@ renders itself as a clickable link while the second renders as a clickable
'@ image.
'@ <code>
'@ <%@ Register TagPrefix="miu" Namespace="MarkItUp.WebControls" Assembly="MarkItUp.WebControls.ContextMenu" %>
'@ <script runat="server" language="c#" >
'@    private void mnuLinks_ItemClick(object sender, MarkItUp.WebControls.ItemClickEventArgs e)
'@    {
'@        Response.Redirect( e.MenuItemCommandArgument ) ;
'@    }
'@ </script>
'@ 
'@ <script language="javascript">
'@     function NavigatiUrl( sender, e)
'@     {
'@         document.location.href = e.MenuItemCommandArgument ;
'@     }
'@ </script>
'@ 
'@ <form runat="server">
'@    <miu:contextmenu id="mnuLinks" runat="server" CommandName="Links">
'@        <miu:contextmenuitem id="mnuItemOne" runat="server" text="Home Page" CommandArgument="SiteHome" />
'@        <miu:contextmenuitem id="mnuItemTwo" runat="server" text="Cnn" CommandArgument="http://www.cnn.com" ClientNotificationFunction="NavigateUrl" />
'@        <miu:contextmenuitem id="mnuItemThree" runat="server" text="ASP.net" CommandArgument="http://www.asp.net" ClientNotificationFunction="NavigateUrl" />
'@        <miu:contextmenuitem id="mnuItemFour" runat="server" text="Amazon" CommandArgument="http://www.amazon.com" ClientNotificationFunction="NavigateUrl" />
'@    </miu:contextmenu>
'@ 
'@    <miu:contextmenulink id="lnkLinksA" runat="server" text="View Links" ContextMenuToOpen="mnuLinks" /><br />
'@    <miu:contextmenulink id="lnkLinksB" runat="server" text="View Links (2)" ContextMenuToOpen="mnuLinks" imageurl="Urls.gif" />
'@ </form>
'@ </code>
'@ </example>
< _
    ParseChildren(True, "Items"), _
    DefaultEvent("ItemClick"), _
    DefaultProperty("CommandName"), _
    ToolboxData("<{0}:ContextMenu runat=server></{0}:ContextMenu>"), _
    Description("Represents a shortcut menu.") _
> _
Public Class ContextMenu
    Inherits Control
    Implements IPostBackEventHandler

    Private mScriptKey As String = "MarkItUp.WebControls.ContextMenu"
    Dim mItems As New ContextMenuItemCollection

    '@ <summary>
    '@ The event that is raised when the user has clicks on a context menu item.
    '@ </summary>
    '@ <remarks>
    '@ This event is not raised when the item which is clicked is marked to 
    '@ be handled in the client.
    '@ </remarks>
    Public Event ItemClick As MarkItUp.WebControls.ContextItemClickEventHandler


    '@ <summary>
    '@ The command name to associate with members of this menu
    '@ </summary>
    Public Overridable Property CommandName() As String
        Get
            If Not ViewState("CommandName") Is Nothing Then
                Return ViewState("CommandName").ToString
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("CommandName") = Value
        End Set
    End Property


    '@ <summary>
    '@ Gets the collection of items in the list control.
    '@ </summary>
    Public Overridable Property Items() As ContextMenuItemCollection
        Get
            Return mItems
        End Get
        Set(ByVal Value As ContextMenuItemCollection)
            mItems = Value
        End Set
    End Property


    '@ <summary>
    '@ Raises the ItemClick event.
    '@ </summary>
    Public Overridable Sub OnItemClick(ByVal e As MarkItUp.WebControls.ItemClickEventArgs)
        RaiseEvent ItemClick(Me, e)
    End Sub


    '@ <summary>
    '@ Overrides <see cref="Control.OnPreRender"/>
    '@ </summary>
    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
        MyBase.OnPreRender(e)
        RegisterClientScript()
    End Sub


    '@ <summary>
    '@ Registers the neccessary clientscript for the context menu.
    '@ </summary>
    Protected Overridable Sub RegisterClientScript()

        ' First time only...
        If Not Me.Page.IsClientScriptBlockRegistered(mScriptKey) Then

            ' Insert the global array declaration...
            Dim strng As String = _
                String.Format( _
                    "<script language='javascript' type='text/javascript' >{0}var MarkItUp_ContextMenu = new Array() ;{0}", _
                    Environment.NewLine _
                )

            ' Insert the global scripts...
            Dim reader As New System.IO.StreamReader(GetType(ContextMenu).Assembly.GetManifestResourceStream(GetType(ContextMenu), "ContextMenuScript.js"))
            strng &= String.Format( _
                "{0}<!--{0}{1}{0}//-->{0}</script>", _
                Environment.NewLine, reader.ReadToEnd() _
            )
            Me.Page.RegisterClientScriptBlock(mScriptKey, strng)

        End If

        ' Every time this control appears on a page, add an entry into the global
        ' array declaration for this menu and its items...
        Dim meCtl As String = String.Format("<script language='javascript' type='text/javascript' >{1}MarkItUp_ContextMenu[""{0}""] = [[""" & Me.Page.GetPostBackEventReference(Me, "@menuResult@") & """],[{1}", Me.ClientID, Environment.NewLine)

        For Each item As ContextMenuItem In Me.Items
            meCtl &= "    [ """ & item.Text & """, """ & item.CommandArgument & """, """ & item.ClientNotificationFunction & """ ],"
        Next

        If meCtl.EndsWith(","c) Then
            meCtl = meCtl.Substring(0, meCtl.Length - 1)
        End If

        meCtl &= String.Format("]] ;</script>{0}", Environment.NewLine)

        Me.Page.RegisterClientScriptBlock(mScriptKey & "_" & Me.ClientID, meCtl)

    End Sub


    Public Function GetMenuOpenScript(ByVal commandArgument As String) As String
        Return "MarkItUp_ContextMenu_ShowMenu(this, '" & Me.ClientID & "', '" & commandArgument & "') ;"
    End Function


#Region " IPostbackEventHandler "

    Public Sub RaisePostBackEvent(ByVal eventArgument As String) Implements System.Web.UI.IPostBackEventHandler.RaisePostBackEvent
        Me.OnItemClick(New MarkItUp.WebControls.ItemClickEventArgs(eventArgument))
    End Sub

#End Region

End Class
