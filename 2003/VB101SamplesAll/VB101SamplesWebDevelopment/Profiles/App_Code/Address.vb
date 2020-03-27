Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls


Namespace Samples.Web.Profiles
    <Serializable()> _
     Public Class Address
        Private _street As String
        Private _city As String
        Private _state As String
        Private _zip As String


        Public Sub New()
        End Sub 'New


        Public Property Street() As String
            Get
                Return _street
            End Get
            Set(ByVal value As String)
                _street = value
            End Set
        End Property


        Public Property City() As String
            Get
                Return _city
            End Get
            Set(ByVal value As String)
                _city = value
            End Set
        End Property


        Public Property State() As String
            Get
                Return _state
            End Get
            Set(ByVal value As String)
                _state = value
            End Set
        End Property


        Public Property ZipCode() As String
            Get
                Return _zip
            End Get
            Set(ByVal value As String)
                _zip = value
            End Set
        End Property
    End Class 'Address
End Namespace 'Samples.Web.Profiles