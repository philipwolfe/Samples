Option Strict On
Friend Class MakeHelpFile
    Friend Function SaveEmbeddedHelpFile() As Boolean
        ' 
        'Record the this running assembly 
        Dim ThisExe As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly
        ' 
        'to simplify things, also record assembly name 
        Dim ThisExeName As String = ThisExe.GetName.Name
        'Misc. items...a byte array, a binary writer, a stream, etc. 
        Dim Data() As Byte
        Dim BinaryWriter As IO.BinaryWriter
        Dim DataStream As IO.Stream
        Dim WriteStream As IO.FileStream
        Dim UserFolder As String
        ' 
        'Set/Create a directory for the help file
        UserFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\TrafficViewer\"
        IO.Directory.CreateDirectory(UserFolder)
        ' 
        ' Set the Stream to read from, to the resource stream of the embedded object; in this case it is this executable.
        DataStream = ThisExe.GetManifestResourceStream(ThisExeName & ".HelpPage.htm")
        ' 
        ' Set the file stream to where the file will be saved to 
        WriteStream = New IO.FileStream(UserFolder & "\" & "TrafficViewerHelp.htm", IO.FileMode.OpenOrCreate)
        ' 
        'set the binary writer
        BinaryWriter = New IO.BinaryWriter(WriteStream)
        ' 
        ' before setting the byte array, verify the the embedded file was found
        ' Note that the embedded file's path has to be 100% correct, with correct
        ' case, or the embedded file will not be located.
        '
        If Not DataStream Is Nothing Then
            'Set the length of the byte array used. 
            ReDim Data(CInt(DataStream.Length - 1))
            ' 
            'Read the resource into the byte array 
            DataStream.Read(Data, 0, CInt(DataStream.Length - 1))
            ' 
            'Write embedded resource to file 
            BinaryWriter.Write(Data)
            'close writer 
            BinaryWriter.Close()
            '
            'verify helpfile exists
            If IO.File.Exists(UserFolder & "\" & "TrafficViewerHelp.htm") Then
                Return True
            Else
                Return False
            End If
        Else ' The embedded file was not found.
            Return False
        End If
    End Function
End Class
