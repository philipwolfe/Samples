Imports System
Imports System.Data
Imports System.Data.SQL
Imports System.Collections

Namespace Market

   Public Class InventoryDB 
   
      Public Function GetProducts(Byval categoryID as Integer) as DataTable

          Dim sqlConnection1 as SQLConnection
          sqlConnection1 = new SQLConnection("server=localhost;uid=sa;pwd=;database=grocertogo")

          Dim sqlAdapter1 as SQLDataSetCommand
          sqlAdapter1 = new SQLDataSetCommand("Select * from Products where categoryid=" & CStr(categoryID), SQLConnection1)

          Dim products As New Dataset
          sqlAdapter1.FillDataSet(products, "products")

          Getproducts = products.Tables(0)
      End Function


      public Function GetProduct(productID As Integer) As DataRow

          Dim SQLConnection1 As SQLConnection
          SQLConnection1 = new SQLConnection("server=localhost;uid=sa;pwd=;database=grocertogo")

          Dim SQLAdapter1 As SQLDataSetCommand
          sqlAdapter1 = new SQLDataSetCommand("Select * from Products where productID=" & CStr(productID), sqlConnection1)

          Dim product As New DataSet
          sqlAdapter1.FillDataSet(product, "product")

          GetProduct = product.Tables(0).Rows(0)
      End Function


      public Function GetProductCalories(productID As Integer) As DataTable 

          Dim SQLConnection1 As SQLConnection
          SQLConnection1 = New SQLConnection("server=localhost;uid=sa;pwd=;database=grocertogo")

          Dim SQLAdapter1 As SQLDataSetCommand
          sqlAdapter1 = new SQLDataSetCommand("Select * from ProductDetails where productID=" & CStr(productID), sqlConnection1)
          
          Dim details As new DataSet
          sqlAdapter1.FillDataSet(details, "details")

          GetProductCalories = details.Tables(0)
      End Function
   End Class




   public class OrderItem 
   
      public m_ProductID As Integer
      public m_Quantity As Integer
      public m_Name As String
      public m_Price As Double


      public Sub New(ProductID As Integer, Name As String, Price As Double, Quantity As Integer)      
         MyBase.New
         me.m_ProductID = ProductID
         me.m_Quantity = Quantity
         me.m_Name = Name
         me.m_Price = Price
      End Sub
 

      public Readonly Property ProductID As Integer
         Get 
           ProductID = m_ProductID
         End Get
      End Property


      public Property Quantity As Integer      
         Get 
           Quantity = m_Quantity
         End Get

         Set 
           m_Quantity = Value
         End Set
      End Property      

      public Readonly Property Name As String
         Get 
           Name = m_Name
         End Get
      End Property

      public Readonly Property Price As Double
        Get 
          Price = m_Price
        End Get
      End Property

      public Readonly Property Total As Double 
        Get 
          Total = m_Quantity * m_Price
        End Get
      End Property

   End Class


   public class OrderList  
   
      private m_Orders As Hashtable = new Hashtable
      private m_TaxRate As Double = 0.08

      public Readonly Property SubTotal As Double
      
         Get 
          
            If (m_Orders.Count = 0) then 
               SubTotal = 0.0
            End If
            
            Dim x as OrderItem
            For Each x in m_Orders.Values
               SubTotal += x.Price * x.Quantity
            Next x

         End Get
      End Property


      public Property TaxRate As Double
         Get 
           TaxRate = m_TaxRate
         End Get

         Set 
           m_TaxRate = TaxRate
         End Set
      End Property


      public Readonly Property Tax As Double
         Get 
           Tax = SubTotal * m_TaxRate
         End Get
      End Property

      public Readonly Property Total As Double
         Get 
           Total = SubTotal * (1 + m_TaxRate)
         End Get
      End Property

      public Readonly Property Values As ICollection
         Get
            Values = m_Orders.Values
         End Get
      End Property


' This is the Default property
      public Default Readonly Property DefaultProp(name As String) As OrderItem
         Get
            DefaultProp = CType(m_Orders(name),OrderItem)
         End Get
      End Property


      public Sub Add(value As OrderItem)
         If Microsoft.VisualBasic.IsNothing(m_Orders(value.Name)) Then
            m_Orders.Add(value.Name, value)
         Else
            Dim oI as OrderItem
            oI = Ctype(m_Orders(value.Name), OrderItem)
            oI.Quantity = oI.Quantity + 1
         End If
      End Sub

      public Sub ClearCart()
         m_Orders.Clear()
      End Sub


   End Class

End Namespace




