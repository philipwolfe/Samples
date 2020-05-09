Friend Class My

    Friend Shared ReadOnly Property Forms() As TheForms
        Get
            Return m_TheForms
        End Get
    End Property

    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never), _
    MyCodeGenerationAttribute(GetType(System.Windows.Forms.Form))> _
    Friend Class TheForms
        Public Shared ReadOnly Property Form1() As Object
            Get
                Return Nothing
            End Get
        End Property
    End Class

    Private Shared m_TheForms As TheForms
End Class

<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never), _
 System.AttributeUsage(System.AttributeTargets.Class, Inherited:=False, AllowMultiple:=False)> _
Public NotInheritable Class MyCodeGenerationAttribute : Inherits Attribute
    Sub New(ByVal FindTypesDerivedFrom As Type)
        If FindTypesDerivedFrom Is Nothing Then
            Throw New ArgumentNullException("Must specify a type")
        End If
        m_FindTypesDerivedFrom = FindTypesDerivedFrom
    End Sub

    Public ReadOnly Property FindTypesDerivedFrom() As Type
        Get
            Return m_FindTypesDerivedFrom
        End Get
    End Property

    Private m_FindTypesDerivedFrom As Type
End Class