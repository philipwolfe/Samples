Imports System.Windows.Navigation

Public Class Page1
    Inherits Page

    Implements IProvideCustomContentState

    Shared Sub New()
        ' Register the local property with the journalable dependency property
        Page1.CreatedProperty = DependencyProperty.Register("Created", GetType(DateTime), GetType(Page1), New FrameworkPropertyMetadata(DateTime.Now, FrameworkPropertyMetadataOptions.Journal))
    End Sub

    Public Sub New()
        Me.InitializeComponent()
        Me.timeTextBlock.Text = Me.Created.ToLongTimeString
    End Sub

    Function GetContentState() As CustomContentState Implements IProvideCustomContentState.GetContentState
        Return ContentImageCustomContentState.GetContentImageCustomContentState(Me, CInt(MyBase.ActualWidth), CInt(MyBase.ActualHeight))
    End Function

    ' Property to register with the journalable dependency property
    Public Property Created() As DateTime
        Get
            Return CDate(MyBase.GetValue(Page1.CreatedProperty))
        End Get
        Set(ByVal value As DateTime)
            MyBase.SetValue(Page1.CreatedProperty, value)
        End Set
    End Property

    ' Journalable dependency property to remember datetime
    Public Shared ReadOnly CreatedProperty As DependencyProperty

End Class
