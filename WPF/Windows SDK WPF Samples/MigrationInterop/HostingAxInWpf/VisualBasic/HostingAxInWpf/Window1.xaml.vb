'<snippet10>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Class Window1
    Inherits Window
    
    Public Sub New()
        InitializeComponent()
    End Sub


    Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' Create the interop host control.
        Dim host As New System.Windows.Forms.Integration.WindowsFormsHost()

        ' Create the ActiveX control.
        Dim axWmp As New AxWMPLib.AxWindowsMediaPlayer()

        ' Assign the ActiveX control as the host control's child.
        host.Child = axWmp

        ' Add the interop host control to the Grid
        ' control's collection of child controls.
        Me.grid1.Children.Add(host)

        ' Play a .wav file with the ActiveX control.
        axWmp.URL = "C:\WINDOWS\Media\Windows XP Startup.wav"

    End Sub

End Class
'</snippet10>