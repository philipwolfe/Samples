Imports System.Runtime.Serialization



<DataContract()> _
Public Class SystemInfo
    Public Function GetHTMLContent() As String
        Dim sw As New System.IO.StringWriter
        sw.WriteLine("<h2>Machine Name: {0}</h2>", MachineName)
        sw.WriteLine("<h3>Processor Count: {0}</h3>", ProcessorCount)
        sw.WriteLine("<h3>OS Version: {0}</h3>", OSVersion)
        sw.WriteLine("<h3>CLR Version: {0}</h3>", Version)
        Return sw.ToString()
    End Function

    Public Sub New()
        MachineName = Environment.MachineName
        ProcessorCount = Environment.ProcessorCount
        OSVersion = Environment.OSVersion.ToString()
        Version = Environment.Version.ToString()
    End Sub

    Public Overrides Function ToString() As String
        Dim sw As New System.IO.StringWriter
        sw.WriteLine("Machine Name: {0}", MachineName)
        sw.WriteLine("Processor Count: {0}", ProcessorCount)
        sw.WriteLine("OS Version: {0}", OSVersion)
        sw.WriteLine("CLR Version: {0}", Version)
        Return sw.ToString()
    End Function


    <DataMember()> Public MachineName As String
    <DataMember()> Public ProcessorCount As Integer
    <DataMember()> Public OSVersion As String
    <DataMember()> Public Version As String

End Class

