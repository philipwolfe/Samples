Imports System
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports MarkItUp.WebControls



'@ <summary>
'@ Opens the specified ContextMenu
'@ </summary>
< _
    DefaultProperty("ContextMenuToOpen"), _
    Designer(GetType(MenuLinkDesigner)) _
> _
Public Class ContextMenuLink
    Inherits System.Web.UI.WebControls.WebControl


    '@ <summary>
    '@ Gets or sets the url of the image to display.
    '@ </summary>
    < _
        Description("Gets or sets the url of the image to display."), _
        Category("Appearance"), _
        DefaultValue(""), _
        Bindable(True), _
        EditorAttribute(GetType(System.Web.UI.Design.ImageUrlEditor), GetType(System.Drawing.Design.UITypeEditor)) _
    > _
    Public Overridable Property ImageUrl() As String
        Get
            If Not ViewState("ImageUrl") Is Nothing Then
                Return ViewState("ImageUrl").ToString
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("ImageUrl") = Value
        End Set
    End Property


    '@ <summary>
    '@ Gets or sets the text to display for this item.
    '@ </summary>
    < _
        Description("Gets or sets the Text of the link."), _
        Category("Appearance"), _
        DefaultValue(""), _
        Bindable(True) _
    > _
    Public Overridable Property Text() As String
        Get
            If Not ViewState("Text") Is Nothing Then
                Return ViewState("Text").ToString
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("Text") = Value
        End Set
    End Property


    < _
        Description("Gets or sets the Id of the ContextMenu to associate with the link."), _
        Category("Appearance"), _
        DefaultValue(""), _
        Bindable(True), _
        TypeConverter(GetType(MenuControlConverter)) _
    > _
    Public Overridable Property ContextMenuToOpen() As String
        Get
            If Not ViewState("ContextMenuToOpen") Is Nothing Then
                Return ViewState("ContextMenuToOpen").ToString
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("ContextMenuToOpen") = Value
        End Set
    End Property


    '@ <summary>
    '@ The command argument to associate with this menu link
    '@ </summary>
    Public Property CommandArgument() As String
        Get
            If Not ViewState("CommandArgument") Is Nothing Then
                Return ViewState("CommandArgument").ToString
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("CommandArgument") = Value
        End Set
    End Property



    '@ <summary>
    '@ Overrides <see cref="WebControl.TagKey"/>.
    '@ </summary>
    Protected Overrides ReadOnly Property TagKey() As System.Web.UI.HtmlTextWriterTag
        Get
            Return HtmlTextWriterTag.A
        End Get
    End Property


    Protected Overrides Sub RenderChildren(ByVal writer As System.Web.UI.HtmlTextWriter)
        If Not Me.ImageUrl Is String.Empty Then
            Dim image As New System.Web.UI.WebControls.Image
            image.ImageUrl = Me.ImageUrl
            image.AlternateText = Me.Text
            image.RenderControl(writer)
        Else
            writer.Write(Me.Text)
        End If
    End Sub

    Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)
        If Not (System.Web.HttpContext.Current Is Nothing) AndAlso Not Me.Page Is Nothing AndAlso Me.Enabled AndAlso Me.ContextMenuToOpen.Length > 0 Then
            Dim menu As Object
            menu = Me.NamingContainer.FindControl(Me.ContextMenuToOpen)

            If menu Is Nothing Then
                menu = Me.Page.FindControl(Me.ContextMenuToOpen)
            End If

            If menu Is Nothing Then
                Throw New InvalidOperationException("Cannot find a ContextMenu with the id '" & Me.ContextMenuToOpen & "'")
            End If
            writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:void(0);")
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, CType(menu, ContextMenu).GetMenuOpenScript(Me.CommandArgument))
        Else
            writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:void(0);")
        End If

        MyBase.AddAttributesToRender(writer)
    End Sub
End Class
