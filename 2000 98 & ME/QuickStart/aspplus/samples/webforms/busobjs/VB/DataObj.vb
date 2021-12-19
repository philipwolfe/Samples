Imports System
Imports System.Data
Imports System.Data.SQL

Namespace DataLayer 

  Public Class DataObjVB

    Private _connStr As String

    Public Overloads Sub New() 

      MyBase.New()
      _connStr = ""
    End Sub

    Public Overloads Sub New(ConnStr As String) 

      MyBase.New()
      _connStr = ConnStr
    End Sub

    Public Property ConnectionString As String

      Get 
        Return _connStr
      End Get

      Set
        _connStr = Value
      End Set
    End Property

    Public Function GetCategories() As DataView

      Dim DS As DataSet
      Dim MyConnection As SQLConnection
      Dim MyCommand As SQLDataSetCommand

      MyConnection = New SQLConnection(_connStr)
      MyCommand = New SQLDataSetCommand("select distinct CategoryName from Categories", MyConnection)

      DS = new DataSet()
      MyCommand.FillDataSet(DS, "Categories")

      Return DS.Tables("Categories").DefaultView
    End Function

    Public Function GetProductsForCategory(Category As String) As DataView

      Dim DS As DataSet
      Dim MyConnection As SQLConnection
      Dim MyCommand As SQLDataSetCommand

      MyConnection = New SQLConnection(_connStr)

      MyCommand = New SQLDataSetCommand("select ProductName, ImagePath, UnitPrice, c.CategoryId  from Products p, Categories c where c.CategoryName='" & Category & "' and p.CategoryId = c.CategoryId", myConnection)

      DS = new DataSet()
      MyCommand.FillDataSet(DS, "Products")

      Return DS.Tables("Products").DefaultView
    End Function

  End Class

End Namespace