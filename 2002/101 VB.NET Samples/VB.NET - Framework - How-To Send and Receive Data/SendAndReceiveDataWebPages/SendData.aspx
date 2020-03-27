<%@ Page language="VB" debug="true" %>

<%@Import namespace="System.IO" %>

<Script runat=Server>
	Sub Page_Load(sender As Object, args As EventArgs)
	'This method receives content from the request stream
	'and copies the content into a file in the local directory.
	
		Dim fs As FileStream
		Dim sr As StreamReader
                Dim stm As Stream
		Try
		
			'Capture the current directory for the application
			Dim appbase As String
			appbase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase()
			
			'Create or override a file in the local directory
			fs = New FileStream(appbase & "datafile.txt", FileMode.Create)

			
			'Copy the content into the file at the web server
			CopyData(Request.InputStream, fs)
			
		Finally
		
			'Make sure the streams are closed
			Request.InputStream.Close()
			If Not fs Is Nothing Then fs.Close()
			
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