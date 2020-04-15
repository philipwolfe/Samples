<%@ Page language=VB debug="true" %>

<%@Import namespace="System.IO" %>

<Script runat=Server>
	Sub Page_Load(sender As Object, args As EventArgs)
	'This routine receives text from a client as well as
	'returns text to the client. It uses the input and 
	'output streams to pass the data between the client
	'and web server.
	
		Dim sr As StreamReader
		Dim sw As StreamWriter
		
		Try
		
			'Place a text-based reader over the input stream.
			sr = New StreamReader(Request.InputStream)
			
			'Read in the text passed from the client.
			dim str As String = sr.ReadToEnd()
			sr.Close
			
			'Place a text-based writer over the output stream.
			sw = New StreamWriter(Response.OutputStream)
			
			'Write some content into the output stream.
			sw.WriteLine("You passed me " & str)
			sw.Close
			
		Finally
		
			'Make sure the streams are closed
			If Not sw Is Nothing Then sw.Close()
			If Not sr Is Nothing Then sr.Close()
			
		End Try
		
	End Sub
</Script>