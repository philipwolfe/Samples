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

Module Types
    Public Function IsNummeric(ByVal Type As Type)
        Return Type.Equals(Type.GetType("System.Byte")) OrElse _
                Type.Equals(Type.GetType("System.Int16")) OrElse _
                Type.Equals(Type.GetType("System.Int32")) OrElse _
                Type.Equals(Type.GetType("System.Int64")) OrElse _
                Type.Equals(Type.GetType("System.Single")) OrElse _
                Type.Equals(Type.GetType("System.Double")) OrElse _
                Type.Equals(Type.GetType("System.Decimal"))
    End Function

    Public Function IsBoolean(ByVal Type As Type) As Boolean
        Return Type.Equals(Type.GetType("System.Boolean"))
    End Function

    Public Function IsString(ByVal Type As Type) As Boolean
        Return Type.Equals(Type.GetType("System.String"))
    End Function

    Public Function IsDate(ByVal Type As Type) As Boolean
        Return Type.Equals(Type.GetType("System.DateTime"))
    End Function

End Module