Imports System
Imports System.Data
Imports System.Data.SQL
Imports DataLayer

Namespace BusinessLayer 

  Public Class BusObjVB

    Private Data As DataObjVB

    Public Sub New() 

      MyBase.New()
      Data = New DataObjVB("server=localhost;uid=sa;pwd=;database=grocertogo")
    End Sub

    Public Function GetCategories() As DataView

       Return Data.GetCategories()
    End Function

    Public Function GetProductsForCategory(Category As String, CustomerId As Integer) As DataView

       Dim View As DataView
       View = Data.GetProductsForCategory(Category)

       Dim Discount As Double = 0
       If (CustomerId >= 25) And (CustomerId < 50)
         Discount = .50
       Else If (CustomerId >= 50) And (CustomerId < 75)
         Discount = 1.00 
       Else If (CustomerId >= 75) And (CustomerId < 100)
         Discount = 1.50
       End If

       Dim I As Integer
       For I = 0 To View.Count - 1
         View(I)("UnitPrice") = CDbl(View(I)("UnitPrice").ToString()) - Discount
       Next

       Return View
    End Function

  End Class

End Namespace