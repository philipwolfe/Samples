#Region "Imports"

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Net

#End Region

Namespace Amazon

    Partial Public Class Details

        Private _image As Image

        ' Override ToString method to display product 
        ' name in list box.
        Overrides Function ToString() As String
            Return ProductName
        End Function

        ' Image of associated item.
        Public ReadOnly Property ItemImage() As Image
            Get
                If (_image Is Nothing) Then

                    Dim webReq As WebRequest = WebRequest.Create(Me.ImageUrlMedium)
                    Dim webResp As WebResponse = webReq.GetResponse()
                    _image = Image.FromStream(webResp.GetResponseStream())
                End If
                Return _image
            End Get
        End Property

    End Class

End Namespace




