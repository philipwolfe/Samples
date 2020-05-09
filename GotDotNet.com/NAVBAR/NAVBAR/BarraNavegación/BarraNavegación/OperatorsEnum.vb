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

Public Enum OperatorsEnum
    Equal
    Different
    Contain
    StartBy
    Between
    BiggerThan
    BiggerEqual
    LessThan
    LessEqual
    IsNull
    NotIsNull
    IsTrue
    IsFalse
End Enum

Public Enum OperatorCardinalityEnum
    Unary
    Binary
    Ternary
End Enum

Public Structure Operator
    Public Op As OperatorsEnum
    Public Sub New(ByVal Op As OperatorsEnum)
        Me.Op = Op
    End Sub
    Public Overrides Function ToString() As String
        Select Case Me.Op
            Case OperatorsEnum.StartBy
                Return "Start By"
            Case OperatorsEnum.Contain
                Return "Contain"
            Case OperatorsEnum.Different
                Return "Different"
            Case OperatorsEnum.IsFalse
                Return "Is False"
            Case OperatorsEnum.IsNull
                Return "Is Empty"
            Case OperatorsEnum.IsTrue
                Return "Is True"
            Case OperatorsEnum.Equal
                Return "Is Equal"
            Case OperatorsEnum.BiggerThan
                Return "Bigger Than"
            Case OperatorsEnum.BiggerEqual
                Return "Bigger Or Equal Than"
            Case OperatorsEnum.LessThan
                Return "Less Than"
            Case OperatorsEnum.LessEqual
                Return "Less Or Equal Than"
            Case OperatorsEnum.NotIsNull
                Return "Isn't Empty"
            Case OperatorsEnum.Between
                Return "Between"
        End Select
    End Function

    Public ReadOnly Property AsString() As String
        Get
            Select Case Me.Op
                Case OperatorsEnum.StartBy, OperatorsEnum.Contain
                    Return "LIKE"
                Case OperatorsEnum.Different
                    Return "<>"
                Case OperatorsEnum.IsFalse
                    Return "=0"
                Case OperatorsEnum.IsNull
                    Return "IS NULL"
                Case OperatorsEnum.IsTrue
                    Return "=1"
                Case OperatorsEnum.Equal
                    Return "="
                Case OperatorsEnum.BiggerThan
                    Return ">"
                Case OperatorsEnum.BiggerEqual
                    Return ">="
                Case OperatorsEnum.LessThan
                    Return "<"
                Case OperatorsEnum.LessEqual
                    Return "<="
                Case OperatorsEnum.NotIsNull
                    Return "NOT IS NULL"
                Case OperatorsEnum.Between
                    Return "BETWEEN"
            End Select
        End Get
    End Property

    Public ReadOnly Property Cardinality() As OperatorCardinalityEnum
        Get
            Select Case Me.Op
                Case OperatorsEnum.IsFalse, OperatorsEnum.IsNull, OperatorsEnum.IsTrue, OperatorsEnum.NotIsNull
                    Return OperatorCardinalityEnum.Unary
                Case OperatorsEnum.Between
                    Return OperatorCardinalityEnum.Ternary
                Case Else
                    Return OperatorCardinalityEnum.Binary
            End Select
        End Get
    End Property

End Structure