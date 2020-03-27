<%@ Page language="VB" debug="true" %>

<%@Import namespace="System.IO" %>

<Script runat=Server>
	Sub Page_Load(sender As Object, args As EventArgs)
	'This routine takes an image from the local directory and streams
	'its content to the requesting client via the output stream.
	
		Dim fs As FileStream
		
		Try
			Dim appbase As String
			appbase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase()
			
			'Create or override a file in the local directory
			fs = New FileStream(appbase & "mypic.jpg", FileMode.Open)
		
			'Copy the content from the local file to the output stream
			CopyData(fs, Response.OutputStream)
		Catch exp As Exception
		  Response.Write(exp.Message)
		Finally
		
			'Make sure the streams are closed
			Try
			  Response.OutputStream.Close()
			Catch
			  ' Eat any Error
			End Try
			Try
			  If Not fs Is Nothing Then fs.Close()
			Catch
			  ' Eat any Error
			End Try

		End Try
		
	End Sub
	
	Private Sub CopyData(ByVal FromStream As Stream, ByVal ToStream As Stream)
        	'This routine copies content from one stream to another, regardless
        	'of the media represented by the stream.

	        'This will track the # bytes read from the FromStream
        	Dim nBytesRead As Integer

	        'The maximum size of each read
        	Const m_Size As Integer = 4096
        	Dim bytes(m_Size) As Byte

	        'Read the first bit of content, then write and read all the content
        	'From the FromStream to the ToStream.
        	nBytesRead = FromStream.Read(bytes, 0, m_Size)
        	While nBytesRead > 0
	            	ToStream.Write(bytes, 0, nBytesRead)
        	    	nBytesRead = FromStream.Read(bytes, 0, m_Size)
        	End While

	End Sub</Script>