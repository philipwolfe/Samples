Imports System
Imports System.Collections.Generic
imports System.Text
Imports System.ServiceModel
Imports System.IO
Imports System.Configuration

Namespace Microsoft.ServiceModel.Samples
    <ServiceContract()> _
    Public Interface IStreamedEchoService
        <OperationContract()> _
        Function Echo(ByVal data As Stream) As Stream
    End Interface

    Public Class StreamedEchoService
        Implements IStreamedEchoService
        Public Function Echo(ByVal data As Stream) As Stream Implements IStreamedEchoService.Echo
            Dim dataStorage As MemoryStream = New MemoryStream()
            Dim byteArray(8192) As Byte
            Dim bytesRead As Integer = data.Read(byteArray, 0, 8192)
            While bytesRead > 0
                dataStorage.Write(byteArray, 0, bytesRead)
                bytesRead = data.Read(byteArray, 0, 8192)
            End While
            data.Close()
            dataStorage.Seek(0, SeekOrigin.Begin)

            Return dataStorage
        End Function
    End Class
end namespace