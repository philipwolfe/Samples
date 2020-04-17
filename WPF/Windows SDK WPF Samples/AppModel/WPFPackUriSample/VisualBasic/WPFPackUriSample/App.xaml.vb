Imports System.IO
Imports System.Reflection

' Interaction logic for App.xaml
Partial Public Class App
    Inherits System.Windows.Application

    Public Sub New()
        Me.InitializeComponent()

        ' Load two versions of an assembly with the same name
        Dim _path As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location)
        Assembly.LoadFile((_path & "\VersionedReferencedAssembly.dll"))
        Assembly.LoadFile((_path & "\Subfolder\VersionedReferencedAssembly.dll"))
    End Sub

End Class
