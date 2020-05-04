


'@ <summary>
'@ The signature for a method handling the <see cref="ContextMenu.ItemClick"/> event.
'@ </summary>
Public Delegate Sub ContextItemClickEventHandler(ByVal sender As Object, ByVal e As ItemClickEventArgs)

'@ <summary>
'@ The <see cref="EventArgs"/> for the <see cref="ContextMenu.ItemClick"/> event.
'@ </summary>
Public Class ItemClickEventArgs
    Inherits EventArgs

    Private mSplitChars As String = "___"

    Private mLinkCommandArgument As String = String.Empty
    Private mMenuItemCommandArgument As String = String.Empty

#Region " P U B L I C   P R O P E R T Y   A C C E S S O R S"

    '@ <summary>
    '@ This is the LinkCommandArgument property.
    '@ </summary>
    Public Property LinkCommandArgument() As String
        Get
            Return mLinkCommandArgument
        End Get
        Set(ByVal Value As String)
            mLinkCommandArgument = Value
        End Set
    End Property

    '@ <summary>
    '@ This is the CommandArgument property.
    '@ </summary>
    Public Property MenuItemCommandArgument() As String
        Get
            Return mMenuItemCommandArgument
        End Get
        Set(ByVal Value As String)
            mMenuItemCommandArgument = Value
        End Set
    End Property

#End Region


    '@ <summary>
    '@ Instantiates a <see cref="ItemClickEventArgs"/> with the given results.
    '@ </summary>
    '@ <param name="results"></param>
    Public Sub New(ByVal arg As String)
        Me.mLinkCommandArgument = String.Empty
        Me.mMenuItemCommandArgument = String.Empty

        If (arg <> "@menuResult@") Then
            Dim args As String() = Split(arg, mSplitChars)

            If (args.Length = 2) Then
                Me.mLinkCommandArgument = args(0)
                Me.mMenuItemCommandArgument = args(1)
            End If
        End If
    End Sub


End Class