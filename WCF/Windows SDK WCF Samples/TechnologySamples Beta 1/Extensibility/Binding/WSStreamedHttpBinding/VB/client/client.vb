Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.Net

Namespace Microsoft.ServiceModel.Samples
    Class Client
        Shared Sub Main()
            ' WARNING: This code is only needed for test certificates such as those created by makecert. It is 
            ' not recommended for production code.
            PermissiveCertificatePolicy.Enact("CN=ServiceModelSamples-HTTPS-Server")

            Dim proxy As StreamedEchoServiceProxy = New StreamedEchoServiceProxy()

            Console.Write("Enter the filename of the file you want to duplicate: ")
            Dim filename As String = Console.ReadLine()

            Dim readStream As FileStream = New FileStream(filename, FileMode.Open)
            Dim data As Stream = proxy.Echo(readStream)

            Dim writeStream As FileStream = New FileStream("Copy of " + filename, FileMode.Create)

            Dim byteArray(8192) As Byte
            Dim bytesRead As Integer = data.Read(byteArray, 0, 8192)
            While bytesRead > 0
                writeStream.Write(byteArray, 0, bytesRead)
                bytesRead = data.Read(byteArray, 0, 8192)
            End While

            readStream.Close()
            writeStream.Close()
            data.Close()

            Console.WriteLine("Press ENTER to exit.")
            Console.ReadLine()
        End Sub
    End Class

    ' This code is only needed for test certificates such as those created by makecert
 ' WARNING: This code is only needed for test certificates such as those created by makecert. It is 
    ' not recommended for production code.
    Class PermissiveCertificatePolicy

        Dim subjectName As String
        Shared currentPolicy As PermissiveCertificatePolicy
        Public Sub New(ByVal subjectName As String)
            Me.subjectName = subjectName
            ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf RemoteCertValidate)
        End Sub

        Public Shared Sub Enact(ByVal subjectName As String)
            currentPolicy = New PermissiveCertificatePolicy(subjectName)
        End Sub

        Function RemoteCertValidate(ByVal sender As Object, ByVal cert As X509Certificate, ByVal chain As X509Chain, ByVal err As System.Net.Security.SslPolicyErrors) As Boolean

            If (cert.Subject = subjectName) Then
                Return True
            End If

            Return False
        End Function
    End Class
End Namespace