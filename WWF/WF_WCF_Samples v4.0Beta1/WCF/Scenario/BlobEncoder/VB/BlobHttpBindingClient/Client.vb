'----------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'----------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Xml

Namespace Microsoft.Samples.BlobMessageEncoder

	Friend Class Client
		Private Const TestFileName As String = "smallsuccess.gif"

		Public Shared Sub Main()
			' Typically this request would be constructed by a web browser or non-WCF application instead of using WCF

			Console.WriteLine("Starting client with BlobHttpBinding")

			Using cf As ChannelFactory(Of IHttpHandler) = New ChannelFactory(Of IHttpHandler)("blobHttpBinding")
				Dim channel As IHttpHandler = cf.CreateChannel()
				Console.WriteLine("Client channel created")

				Dim blob As Message = Message.CreateMessage(MessageVersion.None, "*", New BlobBodyWriter(TestFileName))
				Dim httpRequestProperty As New HttpRequestMessageProperty()
				httpRequestProperty.Headers.Add("Content-Type", "application/octet-stream")
				blob.Properties.Add(HttpRequestMessageProperty.Name, httpRequestProperty)

				Console.WriteLine("Client calling service")
				Dim reply As Message = channel.ProcessRequest(blob)

				'Get bytes from the reply 
				Dim reader As XmlDictionaryReader = reply.GetReaderAtBodyContents()
				reader.MoveToElement()
				Dim name As String = reader.Name
                Console.WriteLine("First element in the blob message is : <" & name & ">")

				Dim array() As Byte = reader.ReadElementContentAsBase64()
				Dim replyMessage As String = System.Text.Encoding.UTF8.GetString(array)
				Console.WriteLine("Client received a reply from service of length :" & replyMessage.Length)
			End Using

			Console.WriteLine("Done")
			Console.WriteLine("Press <ENTER> to exit client")
			Console.ReadLine()

		End Sub

		Private Class BlobBodyWriter
			Inherits BodyWriter
			Private testFileName As String

			Public Sub New(ByVal testFileName As String)
				MyBase.New(False)
				Me.testFileName = testFileName
			End Sub

			Protected Overrides Sub OnWriteBodyContents(ByVal writer As XmlDictionaryWriter)
				writer.WriteStartElement("Binary")

                Dim fs As New FileStream(Me.testFileName, FileMode.Open)

                If fs.Length > Integer.MaxValue Then
                    Throw New ApplicationException(String.Format("{0} is too large.", Me.testFileName))
                End If

                Dim tmp(CInt(fs.Length - 1)) As Byte

                fs.Read(tmp, 0, tmp.Length)
                writer.WriteBase64(tmp, 0, CInt(Fix(tmp.Length)))

				writer.WriteEndElement()
				fs.Close()
			End Sub

		End Class

	End Class
End Namespace
