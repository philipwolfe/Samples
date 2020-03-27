Imports System.IO
Imports System.Net
Imports System.Text

Public Class SimpleFTPClient

    Public Function Download(ByVal destinationFile As String, ByVal downloadUri As Uri) As FtpStatusCode

        Try
            ' Check if the URI is and FTP site
            If Not (downloadUri.Scheme = Uri.UriSchemeFtp) Then
                Throw New ArgumentException("URI is not an FTp site")
            End If

            ' Set up the request
            Dim ftpRequest As FtpWebRequest = CType(WebRequest.Create(downloadUri), FtpWebRequest)

            ' use the provided credentials
            If Me.m_isAnonymousUser = False Then
                ftpRequest.Credentials = New NetworkCredential(Me.m_userName, Me.m_password)
            End If

            ' Download a file. Look at the other methods to see all of the potential FTP features
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile

            ' get the response object
            Dim ftpResponse As FtpWebResponse = CType(ftpRequest.GetResponse, FtpWebResponse)
            Dim stream As Stream = Nothing
            Dim reader As StreamReader = Nothing
            Dim writer As StreamWriter = Nothing

            ' get the file as a stream from the response object and write it as 
            ' a file stream to the local PC
            Try
                stream = ftpResponse.GetResponseStream
                reader = New StreamReader(stream, Encoding.UTF8)
                writer = New StreamWriter(destinationFile, False)
                writer.Write(reader.ReadToEnd)
                Return ftpResponse.StatusCode
            Finally
                ' Allways close all streams
                stream.Close()
                reader.Close()
                writer.Close()
            End Try
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Property UserName() As String
        Get
            Return Me.m_userName
        End Get
        Set(ByVal value As String)
            Me.m_userName = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return Me.m_password
        End Get
        Set(ByVal value As String)
            Me.m_password = value
        End Set
    End Property

    Public Property IsAnonymousUser() As Boolean
        Get
            Return Me.m_isAnonymousUser
        End Get
        Set(ByVal value As Boolean)
            Me.m_isAnonymousUser = value
        End Set
    End Property

    Private m_userName As String
    Private m_password As String
    Private m_isAnonymousUser As Boolean

End Class
