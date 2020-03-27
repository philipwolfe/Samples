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
Imports System.Collections
Namespace Microsoft.Samples.Web.DataAccess

    Public Class ProductCollection
        Inherits CollectionBase

        Public Sub New()
        End Sub

        Public Function Item(ByVal index As Integer) As Product
            Return CType(List(index), Product)
        End Function

        Public Function Add(ByVal product As Product) As Integer
            Return List.Add(product)
        End Function
    End Class
End Namespace
