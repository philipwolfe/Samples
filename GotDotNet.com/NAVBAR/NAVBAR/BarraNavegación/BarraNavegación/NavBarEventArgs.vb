'***********************************************************************************************************
' From Spain: November 2002
'
' All code has been developed by:
' Jesús López is MCP SQL Server and Microsoft .NET MVP
' You can contact with Jesús in his web site (SqlRanger - http://www.sqlranger.com/)
'
' With a little contribution of:
' Jorge Serrano is Microsoft .NET MVP
' You can contact with Jorge in his web site (PortalVB.com - http://www.portalvb.com/)
'***********************************************************************************************************

Public Enum NavBarButtonEnum
    First
    Previous
    [Next]
    Last
    [New]
    Filter
    CancelFilter
    GoRecord
    Delete
    Undo
End Enum

Public Class NavBarErrorEventArgs
    Inherits EventArgs
    Private mRowView As DataRowView
    Private mErrors As Exception

    Public Sub New(ByVal CurrentRowView As DataRowView, ByVal Errors As Exception)
        mRowView = CurrentRowView
        mErrors = Errors
    End Sub

    Public ReadOnly Property CurrentRowView() As DataRowView
        Get
            Return mRowView
        End Get
    End Property

    Public ReadOnly Property Errors() As Exception
        Get
            Return mErrors
        End Get
    End Property
End Class

Public Class NavBarDeletingRowEventArgs
    Inherits EventArgs
    Private mRow As DataRow
    Private mCancel As Boolean

    Public Sub New(ByVal CurrentRow As DataRow)
        mRow = CurrentRow
        mCancel = False
    End Sub

    Public ReadOnly Property Row() As DataRow
        Get
            Return mRow
        End Get
    End Property

    Public Property Cancel() As Boolean
        Get
            Return mCancel
        End Get
        Set(ByVal Value As Boolean)
            mCancel = Value
        End Set
    End Property
End Class

Public Class NavBarBeforeNavEventArgs
    Inherits EventArgs
    Private mRowView As DataRowView
    Private mErrors As Exception
    Private mNavBarButton As NavBarButtonEnum
    Private mCancel As Boolean

    Public Sub New(ByVal CurrentRowView As DataRowView, ByVal NavBarButton As NavBarButtonEnum)
        mRowView = CurrentRowView
        mNavBarButton = NavBarButton
    End Sub

    Public ReadOnly Property CurrentRowView() As DataRowView
        Get
            Return mRowView
        End Get
    End Property

    Public ReadOnly Property NavBarButton() As NavBarButtonEnum
        Get
            Return Me.mNavBarButton
        End Get
    End Property

    Public Property Cancel() As Boolean
        Get
            Return Me.mCancel
        End Get
        Set(ByVal Value As Boolean)
            Me.mCancel = Value
        End Set
    End Property
End Class

Public Class NavBarAfterNavEventArgs
    Inherits EventArgs
    Private mRowView As DataRowView
    Private mErrors As Exception
    Private mNavBarButton As NavBarButtonEnum

    Public Sub New(ByVal CurrentRowView As DataRowView, ByVal NavBarButton As NavBarButtonEnum)
        mRowView = CurrentRowView
        mNavBarButton = NavBarButton
    End Sub

    Public ReadOnly Property CurrentRowView() As DataRowView
        Get
            Return mRowView
        End Get
    End Property

    Public ReadOnly Property NavBarButton() As NavBarButtonEnum
        Get
            Return Me.mNavBarButton
        End Get
    End Property

End Class