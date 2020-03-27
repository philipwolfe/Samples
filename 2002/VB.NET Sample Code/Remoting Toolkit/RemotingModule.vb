Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Module RemotingModule

    Public Sub ConfigureRemoting()

        Dim formatter As New BinaryClientFormatterSinkProvider()

        Dim channel As New HttpChannel(Nothing, formatter, Nothing)

        ChannelServices.RegisterChannel(channel)

        '-- To modify for your own use:

        '   Add a reference to a local copy of the DLL being remoted.
        '
        '   Replace OrderDetailObjects with the root namespace of the 
        '   class being remoted
        '
        '   Replace TestObject with the name of the class being remoted
        '
        '   Replace http://localhost/OrderDetailRemoter with the base 
        '   URL of the web app that has a reference to the remoted 
        '   class assembly, and has a config file entry to remote the class.
		'
		'	Add a similar entry for each class you want to access remotely.

        RemotingConfiguration.RegisterWellKnownClientType( _
            GetType(OrderDetailObjects.TestObject), "http://localhost/OrderDetailRemoter/TestObject.rem")

    End Sub
End Module
