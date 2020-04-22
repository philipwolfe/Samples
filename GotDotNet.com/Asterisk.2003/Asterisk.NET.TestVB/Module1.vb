Imports Asterisk.NET.Manager
Imports Asterisk.NET.FastAGI
Imports Asterisk.NET.Manager.Event

Module Module1

	Dim WithEvents dam As AsteriskManager

	Sub Main()
		checkManagerAPI()
	End Sub

	Sub checkManagerAPI()
		dam = New AsteriskManager("192.168.110.10", 5038, "admin", "amp111")

		Try
			dam.Initialize()
			Console.WriteLine(dam.Version)

		Catch ex As Exception
			Console.WriteLine(ex.Message)
			Console.ReadLine()
			dam.Logoff()
			Exit Sub
		End Try

		Console.WriteLine("Press ENTER key to originate call.")
		Console.WriteLine("Start phone (or connect) or make a call to see events.")
		Console.WriteLine("After all events press a key to originate call.")
		Console.ReadLine()

		Dim oc As Originate
		oc = New Originate
		oc.Channel = "IAX2/5628"
		oc.CallerId = ".NET"
		oc.Exten = "5624"
		oc.Variable = "VAR1=abc|VAR2=def"
		oc.SetVariable("VAR3", "ghi")
		dam.OriginateCall(oc)

		Console.WriteLine("Press ENTER key to next test.")
		Console.ReadLine()

		dam.Logoff()

	End Sub

	Sub dam_NewChannel(ByVal sender As Object, ByVal e As NewChannelEvent) Handles dam.NewChannel
		Console.WriteLine("New channel Event")
		Console.WriteLine("	Channel		" + e.Channel)
		Console.WriteLine("	CallerId	" + e.CallerId)
		Console.WriteLine("	CallerIdName	" + e.CallerIdName)
		Console.WriteLine("	State		" + e.State)
		Console.WriteLine("	DateReceived	" + e.DateReceived.ToString)
	End Sub

	Sub dam_Dial(ByVal sender As Object, ByVal e As DialEvent) Handles dam.Dial
		Console.WriteLine("Dial Event")
		Console.WriteLine("	CallerId	" + e.CallerId)
		Console.WriteLine("	CallerIdName	" + e.CallerIdName)
		Console.WriteLine("	tDestination	" + e.Destination)
		Console.WriteLine("	DestUniqueId	" + e.DestUniqueId)
		Console.WriteLine("	Src		" + e.Src)
		Console.WriteLine("	SrcUniqueId	" + e.SrcUniqueId)
	End Sub

	Sub dam_OriginateFailure(ByVal sender As Object, ByVal e As OriginateFailureEvent) Handles dam.OriginateFailure
		Console.WriteLine("Originate Failure Event")
		Console.WriteLine("	Channel		" + e.Channel)
		Console.WriteLine("	UniqueId	" + e.UniqueId)
		Console.WriteLine("	Context		" + e.Context)
	End Sub

	Sub dam_OriginateSuccess(ByVal sender As Object, ByVal e As OriginateSuccessEvent) Handles dam.OriginateSuccess
		Console.WriteLine("Originate Success Event")
		Console.WriteLine("	Channel		" + e.Channel)
		Console.WriteLine("	UniqueId	" + e.UniqueId)
		Console.WriteLine("	Context		" + e.Context)
	End Sub

	Sub dam_Hangup(ByVal sender As Object, ByVal e As HangupEvent) Handles dam.Hangup
		Console.WriteLine("Hangup Event")
		Console.WriteLine("	Channel		" + e.Channel)
		Console.WriteLine("	UniqueId	" + e.UniqueId)
	End Sub

	Sub dam_Events(ByVal sender As Object, ByVal e As ManagerEvent) Handles dam.Events
		Console.WriteLine("+++ Event : " + e.GetType().FullName)
	End Sub

End Module
