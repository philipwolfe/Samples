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

Imports System.Windows.Forms

Public Class FilterBuilder
    Private mFilter As Filter
    Private mInitialCondition As Hashtable

    Public ReadOnly Property Filter() As String
        Get
            Return mFilter.Condition
        End Get
    End Property

    Public Function ShowDialog(ByVal Table As DataTable, ByVal ConditionFormat As ConditionFormatEnum) As DialogResult
        Dim frm As New frmFilterBuilder(Table, mFilter, mInitialCondition, ConditionFormat)
        Return frm.ShowDialog()
    End Function

    Public Function ShowDialog(ByVal Table As DataTable) As DialogResult
        Return Me.ShowDialog(Table, ConditionFormatEnum.ADO)
    End Function

    Public Sub New()
        mFilter = New Filter
        mInitialCondition = New Hashtable(8)
    End Sub

End Class

Friend Class Filter
    Public Condition As String
End Class