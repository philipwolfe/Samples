Public Class MarginsDialogBox
    Inherits Window

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    ' Validate all dependency objects in a window
    Private Function IsValid(ByVal node As DependencyObject) As Boolean

        ' Check if dependency object was passed and if dependency object is valid.
        ' NOTE: Validation.GetHasError works for controls that have validation rules attached 
        If ((Not node Is Nothing) AndAlso Validation.GetHasError(node)) Then
            ' If the dependency object is invalid, and it can receive the focus,
            ' set the focus
            If TypeOf node Is IInputElement Then
                Keyboard.Focus(DirectCast(node, IInputElement))
            End If
            Return False
        End If

        ' If this dependency object is valid, check all child dependency objects
        Dim subnode As Object
        For Each subnode In LogicalTreeHelper.GetChildren(node)
            If (TypeOf subnode Is DependencyObject AndAlso Not Me.IsValid(DirectCast(subnode, DependencyObject))) Then
                ' If a child dependency object is invalid, return false immediately,
                ' otherwise keep checking
                Return False
            End If
        Next

        ' All dependency objects are valid
        Return True

    End Function

    Private Sub okButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Me.IsValid(Me) Then
            MyBase.DialogResult = New Nullable(Of Boolean)(True)
        End If
    End Sub

    Public Property DocumentMargin() As Thickness
        Get
            Return DirectCast(MyBase.DataContext, Thickness)
        End Get
        Set(ByVal value As Thickness)
            MyBase.DataContext = value
        End Set
    End Property

End Class