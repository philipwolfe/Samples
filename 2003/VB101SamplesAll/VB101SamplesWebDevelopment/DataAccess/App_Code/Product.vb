Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace Microsoft.Samples.Web.DataAccess

    Public Class Product

        Public Sub New()
        End Sub
        Private _productId As Integer

        Public Property ProductId() As Integer
            Get
                Return _productId
            End Get
            Set(ByVal value As Integer)
                _productId = value
            End Set
        End Property
        Private _name As String

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Private _productNumber As String

        Public Property ProductNumber() As String
            Get
                Return _productNumber
            End Get
            Set(ByVal value As String)
                _productNumber = value
            End Set
        End Property
        Private _reorderPoint As Integer

        Public Property ReorderPoint() As Integer
            Get
                Return _reorderPoint
            End Get
            Set(ByVal value As Integer)
                _reorderPoint = value
            End Set
        End Property
        Private _standardCost As Decimal

        Public Property StandardCost() As Decimal
            Get
                Return _standardCost
            End Get
            Set(ByVal value As Decimal)
                _standardCost = value
            End Set
        End Property
        Private _listPrice As Decimal

        Public Property ListPrice() As Decimal
            Get
                Return _listPrice
            End Get
            Set(ByVal value As Decimal)
                _listPrice = value
            End Set
        End Property
    End Class
End Namespace
