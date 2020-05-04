Imports System.Web
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections



'@ <summary>
'@ Represents a clickable item within a context menu.
'@ </summary>
'@ <remarks>
'@ Items can be handled either within the client or on
'@ the server via a postback based on whether or not the
'@ ClientNotificationFunction property is declared
'@ </remarks>
Public Class ContextMenuItem
    Inherits Control


    '@ <summary>
    '@ Gets or sets the name of the custom client-side 
    '@ script to use for client-side event notifications.
    '@ </summary>
    Public Property ClientNotificationFunction() As String
        Get
            If Not ViewState("ClientNotificatonFunction") Is Nothing Then
                Return ViewState("ClientNotificatonFunction").ToString
            Else
                Return String.Empty
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("ClientNotificatonFunction") = Value
        End Set
    End Property


    '@ <summary>
    '@ Gets or sets the text to display for this item.
    '@ </summary>
    Public Property Text() As String
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


    '@ <summary>
    '@ The command argument to associate with this menu item
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

End Class
