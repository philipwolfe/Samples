<%@ WebService Language="VB" Class="DataTypes" %>

Imports System
Imports System.Web.Services

Public Enum Mode

    EOn = 1
    EOff = 2

End Enum

Public Class Order

   Public OrderID As Integer
   Public Price As Double
End Class

Public Class DataTypes

   Public Function <WebMethod()> SayHello() As String

       Return "Hello World!"
   End Function

   Public Function <WebMethod()> SayHelloName(Name As String) As String

       Return "Hello" & Name
   End Function

   Public Function <WebMethod()> GetIntArray() As Integer()

       Dim I As Integer
       Dim A As Integer()
       For I = 0 to 5
           A(I) = I*10
       Next
       Return A
   End Function

   Public Function <WebMethod()> GetMode() As Mode

       Return Mode.EOff
   End Function

   Public Function <WebMethod()> GetOrder() As Order

      Dim MyOrder As New Order

      MyOrder.Price=34.5
      MyOrder.OrderID = 323232

      Return MyOrder
   End Function

   Public Function <WebMethod()> GetOrders() As Order()

      Dim MyOrder(2) As Order

      MyOrder(0) = New Order()
      MyOrder(0).Price=34.5
      MyOrder(0).OrderID = 323232
      MyOrder(1) = New Order()
      MyOrder(1).Price=99.4
      MyOrder(1).OrderID = 645645

      Return MyOrder
   End Function

End Class
