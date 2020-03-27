'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Public Class MSMQOrders
	' We might use Properties for a 'real' application
	Public Number As Integer
	Public Customer As String
	Public RequiredBy As Date

	Public Sub Process(ByVal State As Object)
		' Write out a trace to know that the message has been processed.
		Trace.WriteLine(Number & " - " & Customer & " - " & RequiredBy)
		' Put the thread to sleep to simulate doing some real
		' work like writing the information to the database.
		Threading.Thread.Sleep(2000)
	End Sub
End Class
