Imports System.Web.Services
Imports System.Threading

Public Class Service1
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Overloads Overrides Sub Dispose()
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> Public Function HelloWorld() As String
    '	HelloWorld = "Hello World"
    ' End Function

    <WebMethod()> Public Function DoSomeWork(ByVal Delay As Integer) As Integer

        Dim NewThread As Thread
        Dim RandomValue As Random

        'Get a handle to the thread the object is currently executing on
        NewThread = System.Threading.Thread.CurrentThread

        'Have the thread sleep for the number of milliseconds passed in as a parameter
        NewThread.Sleep(Delay)

        'Generate a random number to return as the results of the method call
        RandomValue = New Random(CInt(NewThread.Name) + Second(Now))
        DoSomeWork = CInt(RandomValue.NextDouble * 100)

    End Function

End Class
