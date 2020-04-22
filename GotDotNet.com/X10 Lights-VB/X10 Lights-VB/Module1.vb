Imports CraigsCreations.com.X10
Imports System.IO
Imports System.IO.IsolatedStorage

Module Module1

    Sub Main()
        ' Connect to the Web service
        Dim quoteService As Net.xmethods.services.netxmethodsservicesstockquoteStockQuoteService = New X10_Lights.net.xmethods.services.netxmethodsservicesstockquoteStockQuoteService

        ' Check current value by retrieving it from the Web service
        Dim currentValue As Single = quoteService.getQuote("msft")

        ' Check previous value by retrieving it from isolated storage
        Dim previousValue As Single = 0
        Try
            Dim isoStream As IsolatedStorageFileStream = New IsolatedStorageFileStream("quote.txt", FileMode.Open)
            Dim quoteReader As StreamReader = New StreamReader(isoStream)
            previousValue = Single.Parse(quoteReader.ReadLine)
            quoteReader.Close()
        Catch
            ' File didn't exist, so this must be the first time we've run.
            ' Just leave value at 0.
        End Try

        ' If the value hasn't changed, don't update the lights
        If (currentValue <> previousValue) Then
            ' Initialize X10 Controller
            Dim x10 As IX10Controller = New X10CM11aController(HouseCode.N, "COM1")

            ' Replace the unit codes in the following two lines with unit codes
            ' that you assign to your lamps
            Dim redLamp As X10Lamp = New X10Lamp(x10, 6)
            Dim greenLamp As X10Lamp = New X10Lamp(x10, 7)

            If (currentValue > previousValue) Then
                redLamp.Off()
                greenLamp.On()
            ElseIf (previousValue > currentValue) Then
                greenLamp.Off()
                redLamp.On()
            End If
        End If
        Console.WriteLine(("Previous: $" _
                        + (previousValue.ToString + (", Current: $" + currentValue.ToString))))

        ' Save the current value to Isolated Storage
        Dim isoStreamWriter As IsolatedStorageFileStream = New IsolatedStorageFileStream("quote.txt", FileMode.Create)
        Dim quoteWriter As StreamWriter = New StreamWriter(isoStreamWriter)
        quoteWriter.WriteLine(currentValue.ToString)
        quoteWriter.Close()
    End Sub

End Module
